using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DatabaseAuditAction : TSqlFragment, IEquatable<DatabaseAuditAction> {
        protected ScriptDom.DatabaseAuditActionKind actionKind = ScriptDom.DatabaseAuditActionKind.Select;
    
        public ScriptDom.DatabaseAuditActionKind ActionKind => actionKind;
    
        public DatabaseAuditAction(ScriptDom.DatabaseAuditActionKind actionKind = ScriptDom.DatabaseAuditActionKind.Select) {
            this.actionKind = actionKind;
        }
    
        public ScriptDom.DatabaseAuditAction ToMutableConcrete() {
            var ret = new ScriptDom.DatabaseAuditAction();
            ret.ActionKind = actionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + actionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DatabaseAuditAction);
        } 
        
        public bool Equals(DatabaseAuditAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DatabaseAuditActionKind>.Default.Equals(other.ActionKind, actionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DatabaseAuditAction left, DatabaseAuditAction right) {
            return EqualityComparer<DatabaseAuditAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DatabaseAuditAction left, DatabaseAuditAction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DatabaseAuditAction)that;
            compare = Comparer.DefaultInvariant.Compare(this.actionKind, othr.actionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (DatabaseAuditAction left, DatabaseAuditAction right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DatabaseAuditAction left, DatabaseAuditAction right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DatabaseAuditAction left, DatabaseAuditAction right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DatabaseAuditAction left, DatabaseAuditAction right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
