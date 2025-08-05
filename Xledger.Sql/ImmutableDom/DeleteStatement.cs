using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DeleteStatement : DataModificationStatement, IEquatable<DeleteStatement> {
        protected DeleteSpecification deleteSpecification;
    
        public DeleteSpecification DeleteSpecification => deleteSpecification;
    
        public DeleteStatement(DeleteSpecification deleteSpecification = null, WithCtesAndXmlNamespaces withCtesAndXmlNamespaces = null, IReadOnlyList<OptimizerHint> optimizerHints = null) {
            this.deleteSpecification = deleteSpecification;
            this.withCtesAndXmlNamespaces = withCtesAndXmlNamespaces;
            this.optimizerHints = optimizerHints.ToImmArray<OptimizerHint>();
        }
    
        public ScriptDom.DeleteStatement ToMutableConcrete() {
            var ret = new ScriptDom.DeleteStatement();
            ret.DeleteSpecification = (ScriptDom.DeleteSpecification)deleteSpecification?.ToMutable();
            ret.WithCtesAndXmlNamespaces = (ScriptDom.WithCtesAndXmlNamespaces)withCtesAndXmlNamespaces?.ToMutable();
            ret.OptimizerHints.AddRange(optimizerHints.Select(c => (ScriptDom.OptimizerHint)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(deleteSpecification is null)) {
                h = h * 23 + deleteSpecification.GetHashCode();
            }
            if (!(withCtesAndXmlNamespaces is null)) {
                h = h * 23 + withCtesAndXmlNamespaces.GetHashCode();
            }
            h = h * 23 + optimizerHints.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DeleteStatement);
        } 
        
        public bool Equals(DeleteStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DeleteSpecification>.Default.Equals(other.DeleteSpecification, deleteSpecification)) {
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
        
        public static bool operator ==(DeleteStatement left, DeleteStatement right) {
            return EqualityComparer<DeleteStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DeleteStatement left, DeleteStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DeleteStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.deleteSpecification, othr.deleteSpecification);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withCtesAndXmlNamespaces, othr.withCtesAndXmlNamespaces);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optimizerHints, othr.optimizerHints);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DeleteStatement left, DeleteStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DeleteStatement left, DeleteStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DeleteStatement left, DeleteStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DeleteStatement left, DeleteStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DeleteStatement FromMutable(ScriptDom.DeleteStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DeleteStatement)) { throw new NotImplementedException("Unexpected subtype of DeleteStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DeleteStatement(
                deleteSpecification: ImmutableDom.DeleteSpecification.FromMutable(fragment.DeleteSpecification),
                withCtesAndXmlNamespaces: ImmutableDom.WithCtesAndXmlNamespaces.FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.ToImmArray(ImmutableDom.OptimizerHint.FromMutable)
            );
        }
    
    }

}
