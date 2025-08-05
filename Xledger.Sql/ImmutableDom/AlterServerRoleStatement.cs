using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerRoleStatement : AlterRoleStatement, IEquatable<AlterServerRoleStatement> {
        public AlterServerRoleStatement(AlterRoleAction action = null, Identifier name = null) {
            this.action = action;
            this.name = name;
        }
    
        public new ScriptDom.AlterServerRoleStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerRoleStatement();
            ret.Action = (ScriptDom.AlterRoleAction)action?.ToMutable();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(action is null)) {
                h = h * 23 + action.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterServerRoleStatement);
        } 
        
        public bool Equals(AlterServerRoleStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<AlterRoleAction>.Default.Equals(other.Action, action)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerRoleStatement left, AlterServerRoleStatement right) {
            return EqualityComparer<AlterServerRoleStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerRoleStatement left, AlterServerRoleStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterServerRoleStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.action, othr.action);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterServerRoleStatement left, AlterServerRoleStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterServerRoleStatement left, AlterServerRoleStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterServerRoleStatement left, AlterServerRoleStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterServerRoleStatement left, AlterServerRoleStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterServerRoleStatement FromMutable(ScriptDom.AlterServerRoleStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterServerRoleStatement)) { throw new NotImplementedException("Unexpected subtype of AlterServerRoleStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerRoleStatement(
                action: ImmutableDom.AlterRoleAction.FromMutable(fragment.Action),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name)
            );
        }
    
    }

}
