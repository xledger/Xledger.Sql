using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class KillQueryNotificationSubscriptionStatement : TSqlStatement, IEquatable<KillQueryNotificationSubscriptionStatement> {
        Literal subscriptionId;
        bool all = false;
    
        public Literal SubscriptionId => subscriptionId;
        public bool All => all;
    
        public KillQueryNotificationSubscriptionStatement(Literal subscriptionId = null, bool all = false) {
            this.subscriptionId = subscriptionId;
            this.all = all;
        }
    
        public ScriptDom.KillQueryNotificationSubscriptionStatement ToMutableConcrete() {
            var ret = new ScriptDom.KillQueryNotificationSubscriptionStatement();
            ret.SubscriptionId = (ScriptDom.Literal)subscriptionId.ToMutable();
            ret.All = all;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(subscriptionId is null)) {
                h = h * 23 + subscriptionId.GetHashCode();
            }
            h = h * 23 + all.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as KillQueryNotificationSubscriptionStatement);
        } 
        
        public bool Equals(KillQueryNotificationSubscriptionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.SubscriptionId, subscriptionId)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.All, all)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(KillQueryNotificationSubscriptionStatement left, KillQueryNotificationSubscriptionStatement right) {
            return EqualityComparer<KillQueryNotificationSubscriptionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(KillQueryNotificationSubscriptionStatement left, KillQueryNotificationSubscriptionStatement right) {
            return !(left == right);
        }
    
    }

}
