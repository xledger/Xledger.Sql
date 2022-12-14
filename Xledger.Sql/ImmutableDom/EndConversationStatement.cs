using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EndConversationStatement : TSqlStatement, IEquatable<EndConversationStatement> {
        protected ScalarExpression conversation;
        protected bool withCleanup = false;
        protected ValueExpression errorCode;
        protected ValueExpression errorDescription;
    
        public ScalarExpression Conversation => conversation;
        public bool WithCleanup => withCleanup;
        public ValueExpression ErrorCode => errorCode;
        public ValueExpression ErrorDescription => errorDescription;
    
        public EndConversationStatement(ScalarExpression conversation = null, bool withCleanup = false, ValueExpression errorCode = null, ValueExpression errorDescription = null) {
            this.conversation = conversation;
            this.withCleanup = withCleanup;
            this.errorCode = errorCode;
            this.errorDescription = errorDescription;
        }
    
        public ScriptDom.EndConversationStatement ToMutableConcrete() {
            var ret = new ScriptDom.EndConversationStatement();
            ret.Conversation = (ScriptDom.ScalarExpression)conversation.ToMutable();
            ret.WithCleanup = withCleanup;
            ret.ErrorCode = (ScriptDom.ValueExpression)errorCode.ToMutable();
            ret.ErrorDescription = (ScriptDom.ValueExpression)errorDescription.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(conversation is null)) {
                h = h * 23 + conversation.GetHashCode();
            }
            h = h * 23 + withCleanup.GetHashCode();
            if (!(errorCode is null)) {
                h = h * 23 + errorCode.GetHashCode();
            }
            if (!(errorDescription is null)) {
                h = h * 23 + errorDescription.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EndConversationStatement);
        } 
        
        public bool Equals(EndConversationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Conversation, conversation)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithCleanup, withCleanup)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.ErrorCode, errorCode)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.ErrorDescription, errorDescription)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EndConversationStatement left, EndConversationStatement right) {
            return EqualityComparer<EndConversationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EndConversationStatement left, EndConversationStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (EndConversationStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.conversation, othr.conversation);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withCleanup, othr.withCleanup);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.errorCode, othr.errorCode);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.errorDescription, othr.errorDescription);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (EndConversationStatement left, EndConversationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(EndConversationStatement left, EndConversationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (EndConversationStatement left, EndConversationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(EndConversationStatement left, EndConversationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static EndConversationStatement FromMutable(ScriptDom.EndConversationStatement fragment) {
            return (EndConversationStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
