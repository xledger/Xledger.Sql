using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MoveConversationStatement : TSqlStatement, IEquatable<MoveConversationStatement> {
        protected ScalarExpression conversation;
        protected ScalarExpression group;
    
        public ScalarExpression Conversation => conversation;
        public ScalarExpression Group => group;
    
        public MoveConversationStatement(ScalarExpression conversation = null, ScalarExpression group = null) {
            this.conversation = conversation;
            this.group = group;
        }
    
        public ScriptDom.MoveConversationStatement ToMutableConcrete() {
            var ret = new ScriptDom.MoveConversationStatement();
            ret.Conversation = (ScriptDom.ScalarExpression)conversation.ToMutable();
            ret.Group = (ScriptDom.ScalarExpression)group.ToMutable();
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
            if (!(group is null)) {
                h = h * 23 + group.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MoveConversationStatement);
        } 
        
        public bool Equals(MoveConversationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Conversation, conversation)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Group, group)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MoveConversationStatement left, MoveConversationStatement right) {
            return EqualityComparer<MoveConversationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MoveConversationStatement left, MoveConversationStatement right) {
            return !(left == right);
        }
    
        public static MoveConversationStatement FromMutable(ScriptDom.MoveConversationStatement fragment) {
            return (MoveConversationStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
