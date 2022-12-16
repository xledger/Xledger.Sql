using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateServerRoleStatement : CreateRoleStatement, IEquatable<CreateServerRoleStatement> {
        public CreateServerRoleStatement(Identifier owner = null, Identifier name = null) {
            this.owner = owner;
            this.name = name;
        }
    
        public ScriptDom.CreateServerRoleStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateServerRoleStatement();
            ret.Owner = (ScriptDom.Identifier)owner?.ToMutable();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateServerRoleStatement);
        } 
        
        public bool Equals(CreateServerRoleStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateServerRoleStatement left, CreateServerRoleStatement right) {
            return EqualityComparer<CreateServerRoleStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateServerRoleStatement left, CreateServerRoleStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateServerRoleStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateServerRoleStatement left, CreateServerRoleStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateServerRoleStatement left, CreateServerRoleStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateServerRoleStatement left, CreateServerRoleStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateServerRoleStatement left, CreateServerRoleStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
