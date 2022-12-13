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
            ret.Name = (ScriptDom.IdentifierOrValueExpression)name.ToMutable();
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
    
        public static CommitTransactionStatement FromMutable(ScriptDom.CommitTransactionStatement fragment) {
            return (CommitTransactionStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
