using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SendStatement : TSqlStatement, IEquatable<SendStatement> {
        protected IReadOnlyList<ScalarExpression> conversationHandles;
        protected IdentifierOrValueExpression messageTypeName;
        protected ScalarExpression messageBody;
    
        public IReadOnlyList<ScalarExpression> ConversationHandles => conversationHandles;
        public IdentifierOrValueExpression MessageTypeName => messageTypeName;
        public ScalarExpression MessageBody => messageBody;
    
        public SendStatement(IReadOnlyList<ScalarExpression> conversationHandles = null, IdentifierOrValueExpression messageTypeName = null, ScalarExpression messageBody = null) {
            this.conversationHandles = conversationHandles is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(conversationHandles);
            this.messageTypeName = messageTypeName;
            this.messageBody = messageBody;
        }
    
        public ScriptDom.SendStatement ToMutableConcrete() {
            var ret = new ScriptDom.SendStatement();
            ret.ConversationHandles.AddRange(conversationHandles.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.MessageTypeName = (ScriptDom.IdentifierOrValueExpression)messageTypeName.ToMutable();
            ret.MessageBody = (ScriptDom.ScalarExpression)messageBody.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + conversationHandles.GetHashCode();
            if (!(messageTypeName is null)) {
                h = h * 23 + messageTypeName.GetHashCode();
            }
            if (!(messageBody is null)) {
                h = h * 23 + messageBody.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SendStatement);
        } 
        
        public bool Equals(SendStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.ConversationHandles, conversationHandles)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.MessageTypeName, messageTypeName)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.MessageBody, messageBody)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SendStatement left, SendStatement right) {
            return EqualityComparer<SendStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SendStatement left, SendStatement right) {
            return !(left == right);
        }
    
    }

}
