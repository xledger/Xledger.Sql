using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GetConversationGroupStatement : WaitForSupportedStatement, IEquatable<GetConversationGroupStatement> {
        protected VariableReference groupId;
        protected SchemaObjectName queue;
    
        public VariableReference GroupId => groupId;
        public SchemaObjectName Queue => queue;
    
        public GetConversationGroupStatement(VariableReference groupId = null, SchemaObjectName queue = null) {
            this.groupId = groupId;
            this.queue = queue;
        }
    
        public ScriptDom.GetConversationGroupStatement ToMutableConcrete() {
            var ret = new ScriptDom.GetConversationGroupStatement();
            ret.GroupId = (ScriptDom.VariableReference)groupId?.ToMutable();
            ret.Queue = (ScriptDom.SchemaObjectName)queue?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(groupId is null)) {
                h = h * 23 + groupId.GetHashCode();
            }
            if (!(queue is null)) {
                h = h * 23 + queue.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GetConversationGroupStatement);
        } 
        
        public bool Equals(GetConversationGroupStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<VariableReference>.Default.Equals(other.GroupId, groupId)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Queue, queue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GetConversationGroupStatement left, GetConversationGroupStatement right) {
            return EqualityComparer<GetConversationGroupStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GetConversationGroupStatement left, GetConversationGroupStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GetConversationGroupStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.groupId, othr.groupId);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.queue, othr.queue);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (GetConversationGroupStatement left, GetConversationGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GetConversationGroupStatement left, GetConversationGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GetConversationGroupStatement left, GetConversationGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GetConversationGroupStatement left, GetConversationGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
