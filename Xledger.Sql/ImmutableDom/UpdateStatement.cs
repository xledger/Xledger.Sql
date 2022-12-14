using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UpdateStatement : DataModificationStatement, IEquatable<UpdateStatement> {
        protected UpdateSpecification updateSpecification;
    
        public UpdateSpecification UpdateSpecification => updateSpecification;
    
        public UpdateStatement(UpdateSpecification updateSpecification = null, WithCtesAndXmlNamespaces withCtesAndXmlNamespaces = null, IReadOnlyList<OptimizerHint> optimizerHints = null) {
            this.updateSpecification = updateSpecification;
            this.withCtesAndXmlNamespaces = withCtesAndXmlNamespaces;
            this.optimizerHints = ImmList<OptimizerHint>.FromList(optimizerHints);
        }
    
        public ScriptDom.UpdateStatement ToMutableConcrete() {
            var ret = new ScriptDom.UpdateStatement();
            ret.UpdateSpecification = (ScriptDom.UpdateSpecification)updateSpecification?.ToMutable();
            ret.WithCtesAndXmlNamespaces = (ScriptDom.WithCtesAndXmlNamespaces)withCtesAndXmlNamespaces?.ToMutable();
            ret.OptimizerHints.AddRange(optimizerHints.SelectList(c => (ScriptDom.OptimizerHint)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(updateSpecification is null)) {
                h = h * 23 + updateSpecification.GetHashCode();
            }
            if (!(withCtesAndXmlNamespaces is null)) {
                h = h * 23 + withCtesAndXmlNamespaces.GetHashCode();
            }
            h = h * 23 + optimizerHints.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UpdateStatement);
        } 
        
        public bool Equals(UpdateStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<UpdateSpecification>.Default.Equals(other.UpdateSpecification, updateSpecification)) {
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
        
        public static bool operator ==(UpdateStatement left, UpdateStatement right) {
            return EqualityComparer<UpdateStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UpdateStatement left, UpdateStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (UpdateStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.updateSpecification, othr.updateSpecification);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withCtesAndXmlNamespaces, othr.withCtesAndXmlNamespaces);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optimizerHints, othr.optimizerHints);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (UpdateStatement left, UpdateStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(UpdateStatement left, UpdateStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (UpdateStatement left, UpdateStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(UpdateStatement left, UpdateStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static UpdateStatement FromMutable(ScriptDom.UpdateStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.UpdateStatement)) { throw new NotImplementedException("Unexpected subtype of UpdateStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UpdateStatement(
                updateSpecification: ImmutableDom.UpdateSpecification.FromMutable(fragment.UpdateSpecification),
                withCtesAndXmlNamespaces: ImmutableDom.WithCtesAndXmlNamespaces.FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.SelectList(ImmutableDom.OptimizerHint.FromMutable)
            );
        }
    
    }

}
