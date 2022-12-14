using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropEventNotificationStatement : TSqlStatement, IEquatable<DropEventNotificationStatement> {
        protected IReadOnlyList<Identifier> notifications;
        protected EventNotificationObjectScope scope;
    
        public IReadOnlyList<Identifier> Notifications => notifications;
        public EventNotificationObjectScope Scope => scope;
    
        public DropEventNotificationStatement(IReadOnlyList<Identifier> notifications = null, EventNotificationObjectScope scope = null) {
            this.notifications = ImmList<Identifier>.FromList(notifications);
            this.scope = scope;
        }
    
        public ScriptDom.DropEventNotificationStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropEventNotificationStatement();
            ret.Notifications.AddRange(notifications.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.Scope = (ScriptDom.EventNotificationObjectScope)scope.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + notifications.GetHashCode();
            if (!(scope is null)) {
                h = h * 23 + scope.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropEventNotificationStatement);
        } 
        
        public bool Equals(DropEventNotificationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Notifications, notifications)) {
                return false;
            }
            if (!EqualityComparer<EventNotificationObjectScope>.Default.Equals(other.Scope, scope)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropEventNotificationStatement left, DropEventNotificationStatement right) {
            return EqualityComparer<DropEventNotificationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropEventNotificationStatement left, DropEventNotificationStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropEventNotificationStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.notifications, othr.notifications);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.scope, othr.scope);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (DropEventNotificationStatement left, DropEventNotificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropEventNotificationStatement left, DropEventNotificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropEventNotificationStatement left, DropEventNotificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropEventNotificationStatement left, DropEventNotificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropEventNotificationStatement FromMutable(ScriptDom.DropEventNotificationStatement fragment) {
            return (DropEventNotificationStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
