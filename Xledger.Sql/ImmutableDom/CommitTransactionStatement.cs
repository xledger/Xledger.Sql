using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CommitTransactionStatement : TransactionStatement, IEquatable<CommitTransactionStatement> {
        protected ScriptDom.OptionState delayedDurabilityOption = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState DelayedDurabilityOption => delayedDurabilityOption;
    
        public CommitTransactionStatement(ScriptDom.OptionState delayedDurabilityOption = ScriptDom.OptionState.NotSet, IdentifierOrValueExpression name = null) {
            this.delayedDurabilityOption = delayedDurabilityOption;
            this.name = name;
        }
    
        public ScriptDom.CommitTransactionStatement ToMutableConcrete() {
            var ret = new ScriptDom.CommitTransactionStatement();
            ret.DelayedDurabilityOption = delayedDurabilityOption;
            ret.Name = (ScriptDom.IdentifierOrValueExpression)name?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + delayedDurabilityOption.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CommitTransactionStatement);
        } 
        
        public bool Equals(CommitTransactionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.DelayedDurabilityOption, delayedDurabilityOption)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CommitTransactionStatement left, CommitTransactionStatement right) {
            return EqualityComparer<CommitTransactionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CommitTransactionStatement left, CommitTransactionStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CommitTransactionStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.delayedDurabilityOption, othr.delayedDurabilityOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CommitTransactionStatement left, CommitTransactionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CommitTransactionStatement left, CommitTransactionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CommitTransactionStatement left, CommitTransactionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CommitTransactionStatement left, CommitTransactionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
