using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RenameAlterRoleAction : AlterRoleAction, IEquatable<RenameAlterRoleAction> {
        protected Identifier newName;
    
        public Identifier NewName => newName;
    
        public RenameAlterRoleAction(Identifier newName = null) {
            this.newName = newName;
        }
    
        public ScriptDom.RenameAlterRoleAction ToMutableConcrete() {
            var ret = new ScriptDom.RenameAlterRoleAction();
            ret.NewName = (ScriptDom.Identifier)newName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(newName is null)) {
                h = h * 23 + newName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RenameAlterRoleAction);
        } 
        
        public bool Equals(RenameAlterRoleAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.NewName, newName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RenameAlterRoleAction left, RenameAlterRoleAction right) {
            return EqualityComparer<RenameAlterRoleAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RenameAlterRoleAction left, RenameAlterRoleAction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RenameAlterRoleAction)that;
            compare = Comparer.DefaultInvariant.Compare(this.newName, othr.newName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (RenameAlterRoleAction left, RenameAlterRoleAction right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(RenameAlterRoleAction left, RenameAlterRoleAction right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (RenameAlterRoleAction left, RenameAlterRoleAction right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(RenameAlterRoleAction left, RenameAlterRoleAction right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
