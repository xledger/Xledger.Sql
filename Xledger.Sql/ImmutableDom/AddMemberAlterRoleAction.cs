using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AddMemberAlterRoleAction : AlterRoleAction, IEquatable<AddMemberAlterRoleAction> {
        protected Identifier member;
    
        public Identifier Member => member;
    
        public AddMemberAlterRoleAction(Identifier member = null) {
            this.member = member;
        }
    
        public ScriptDom.AddMemberAlterRoleAction ToMutableConcrete() {
            var ret = new ScriptDom.AddMemberAlterRoleAction();
            ret.Member = (ScriptDom.Identifier)member?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(member is null)) {
                h = h * 23 + member.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AddMemberAlterRoleAction);
        } 
        
        public bool Equals(AddMemberAlterRoleAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Member, member)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AddMemberAlterRoleAction left, AddMemberAlterRoleAction right) {
            return EqualityComparer<AddMemberAlterRoleAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AddMemberAlterRoleAction left, AddMemberAlterRoleAction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AddMemberAlterRoleAction)that;
            compare = Comparer.DefaultInvariant.Compare(this.member, othr.member);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AddMemberAlterRoleAction left, AddMemberAlterRoleAction right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AddMemberAlterRoleAction left, AddMemberAlterRoleAction right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AddMemberAlterRoleAction left, AddMemberAlterRoleAction right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AddMemberAlterRoleAction left, AddMemberAlterRoleAction right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AddMemberAlterRoleAction FromMutable(ScriptDom.AddMemberAlterRoleAction fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AddMemberAlterRoleAction)) { throw new NotImplementedException("Unexpected subtype of AddMemberAlterRoleAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AddMemberAlterRoleAction(
                member: ImmutableDom.Identifier.FromMutable(fragment.Member)
            );
        }
    
    }

}
