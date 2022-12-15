using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MergeStatement : DataModificationStatement, IEquatable<MergeStatement> {
        protected MergeSpecification mergeSpecification;
    
        public MergeSpecification MergeSpecification => mergeSpecification;
    
        public MergeStatement(MergeSpecification mergeSpecification = null, WithCtesAndXmlNamespaces withCtesAndXmlNamespaces = null, IReadOnlyList<OptimizerHint> optimizerHints = null) {
            this.mergeSpecification = mergeSpecification;
            this.withCtesAndXmlNamespaces = withCtesAndXmlNamespaces;
            this.optimizerHints = ImmList<OptimizerHint>.FromList(optimizerHints);
        }
    
        public ScriptDom.MergeStatement ToMutableConcrete() {
            var ret = new ScriptDom.MergeStatement();
            ret.MergeSpecification = (ScriptDom.MergeSpecification)mergeSpecification.ToMutable();
            ret.WithCtesAndXmlNamespaces = (ScriptDom.WithCtesAndXmlNamespaces)withCtesAndXmlNamespaces.ToMutable();
            ret.OptimizerHints.AddRange(optimizerHints.SelectList(c => (ScriptDom.OptimizerHint)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(mergeSpecification is null)) {
                h = h * 23 + mergeSpecification.GetHashCode();
            }
            if (!(withCtesAndXmlNamespaces is null)) {
                h = h * 23 + withCtesAndXmlNamespaces.GetHashCode();
            }
            h = h * 23 + optimizerHints.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MergeStatement);
        } 
        
        public bool Equals(MergeStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<MergeSpecification>.Default.Equals(other.MergeSpecification, mergeSpecification)) {
                return false;
            }
            if (!EqualityComparer<WithCtesAndXmlNamespaces>.Default.Equals(other.WithCtesAndXmlNamespaces, withCtesAndXmlNamespaces)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<OptimizerHint>>.Default.Equals(other.OptimizerHints, optimizerHints)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MergeStatement left, MergeStatement right) {
            return EqualityComparer<MergeStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MergeStatement left, MergeStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MergeStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.mergeSpecification, othr.mergeSpecification);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withCtesAndXmlNamespaces, othr.withCtesAndXmlNamespaces);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optimizerHints, othr.optimizerHints);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (MergeStatement left, MergeStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MergeStatement left, MergeStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MergeStatement left, MergeStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MergeStatement left, MergeStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
