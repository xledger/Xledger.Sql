using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class KillQueryNotificationSubscriptionStatement : TSqlStatement, IEquatable<KillQueryNotificationSubscriptionStatement> {
        protected Literal subscriptionId;
        protected bool all = false;
    
        public Literal SubscriptionId => subscriptionId;
        public bool All => all;
    
        public KillQueryNotificationSubscriptionStatement(Literal subscriptionId = null, bool all = false) {
            this.subscriptionId = subscriptionId;
            this.all = all;
        }
    
        public ScriptDom.KillQueryNotificationSubscriptionStatement ToMutableConcrete() {
            var ret = new ScriptDom.KillQueryNotificationSubscriptionStatement();
            ret.SubscriptionId = (ScriptDom.Literal)subscriptionId?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (KillQueryNotificationSubscriptionStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.subscriptionId, othr.subscriptionId);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.all, othr.all);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (KillQueryNotificationSubscriptionStatement left, KillQueryNotificationSubscriptionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(KillQueryNotificationSubscriptionStatement left, KillQueryNotificationSubscriptionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (KillQueryNotificationSubscriptionStatement left, KillQueryNotificationSubscriptionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(KillQueryNotificationSubscriptionStatement left, KillQueryNotificationSubscriptionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static KillQueryNotificationSubscriptionStatement FromMutable(ScriptDom.KillQueryNotificationSubscriptionStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.KillQueryNotificationSubscriptionStatement)) { throw new NotImplementedException("Unexpected subtype of KillQueryNotificationSubscriptionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new KillQueryNotificationSubscriptionStatement(
                subscriptionId: ImmutableDom.Literal.FromMutable(fragment.SubscriptionId),
                all: fragment.All
            );
        }
    
    }

}
