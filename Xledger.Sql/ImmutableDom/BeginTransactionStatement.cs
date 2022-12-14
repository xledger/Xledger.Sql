using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BeginTransactionStatement : TransactionStatement, IEquatable<BeginTransactionStatement> {
        protected bool distributed = false;
        protected bool markDefined = false;
        protected ValueExpression markDescription;
    
        public bool Distributed => distributed;
        public bool MarkDefined => markDefined;
        public ValueExpression MarkDescription => markDescription;
    
        public BeginTransactionStatement(bool distributed = false, bool markDefined = false, ValueExpression markDescription = null, IdentifierOrValueExpression name = null) {
            this.distributed = distributed;
            this.markDefined = markDefined;
            this.markDescription = markDescription;
            this.name = name;
        }
    
        public ScriptDom.BeginTransactionStatement ToMutableConcrete() {
            var ret = new ScriptDom.BeginTransactionStatement();
            ret.Distributed = distributed;
            ret.MarkDefined = markDefined;
            ret.MarkDescription = (ScriptDom.ValueExpression)markDescription?.ToMutable();
            ret.Name = (ScriptDom.IdentifierOrValueExpression)name?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + distributed.GetHashCode();
            h = h * 23 + markDefined.GetHashCode();
            if (!(markDescription is null)) {
                h = h * 23 + markDescription.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BeginTransactionStatement);
        } 
        
        public bool Equals(BeginTransactionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.Distributed, distributed)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.MarkDefined, markDefined)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.MarkDescription, markDescription)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BeginTransactionStatement left, BeginTransactionStatement right) {
            return EqualityComparer<BeginTransactionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BeginTransactionStatement left, BeginTransactionStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BeginTransactionStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.distributed, othr.distributed);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.markDefined, othr.markDefined);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.markDescription, othr.markDescription);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (BeginTransactionStatement left, BeginTransactionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BeginTransactionStatement left, BeginTransactionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BeginTransactionStatement left, BeginTransactionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BeginTransactionStatement left, BeginTransactionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static BeginTransactionStatement FromMutable(ScriptDom.BeginTransactionStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.BeginTransactionStatement)) { throw new NotImplementedException("Unexpected subtype of BeginTransactionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BeginTransactionStatement(
                distributed: fragment.Distributed,
                markDefined: fragment.MarkDefined,
                markDescription: ImmutableDom.ValueExpression.FromMutable(fragment.MarkDescription),
                name: ImmutableDom.IdentifierOrValueExpression.FromMutable(fragment.Name)
            );
        }
    
    }

}
