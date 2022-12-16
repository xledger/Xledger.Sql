using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class InsertStatement : DataModificationStatement, IEquatable<InsertStatement> {
        protected InsertSpecification insertSpecification;
    
        public InsertSpecification InsertSpecification => insertSpecification;
    
        public InsertStatement(InsertSpecification insertSpecification = null, WithCtesAndXmlNamespaces withCtesAndXmlNamespaces = null, IReadOnlyList<OptimizerHint> optimizerHints = null) {
            this.insertSpecification = insertSpecification;
            this.withCtesAndXmlNamespaces = withCtesAndXmlNamespaces;
            this.optimizerHints = ImmList<OptimizerHint>.FromList(optimizerHints);
        }
    
        public ScriptDom.InsertStatement ToMutableConcrete() {
            var ret = new ScriptDom.InsertStatement();
            ret.InsertSpecification = (ScriptDom.InsertSpecification)insertSpecification?.ToMutable();
            ret.WithCtesAndXmlNamespaces = (ScriptDom.WithCtesAndXmlNamespaces)withCtesAndXmlNamespaces?.ToMutable();
            ret.OptimizerHints.AddRange(optimizerHints.SelectList(c => (ScriptDom.OptimizerHint)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(insertSpecification is null)) {
                h = h * 23 + insertSpecification.GetHashCode();
            }
            if (!(withCtesAndXmlNamespaces is null)) {
                h = h * 23 + withCtesAndXmlNamespaces.GetHashCode();
            }
            h = h * 23 + optimizerHints.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as InsertStatement);
        } 
        
        public bool Equals(InsertStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<InsertSpecification>.Default.Equals(other.InsertSpecification, insertSpecification)) {
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
        
        public static bool operator ==(InsertStatement left, InsertStatement right) {
            return EqualityComparer<InsertStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(InsertStatement left, InsertStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (InsertStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.insertSpecification, othr.insertSpecification);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withCtesAndXmlNamespaces, othr.withCtesAndXmlNamespaces);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optimizerHints, othr.optimizerHints);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (InsertStatement left, InsertStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(InsertStatement left, InsertStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (InsertStatement left, InsertStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(InsertStatement left, InsertStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
