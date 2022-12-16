using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DeleteMergeAction : MergeAction, IEquatable<DeleteMergeAction> {
        public DeleteMergeAction() {

        }
    
        public ScriptDom.DeleteMergeAction ToMutableConcrete() {
            var ret = new ScriptDom.DeleteMergeAction();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DeleteMergeAction);
        } 
        
        public bool Equals(DeleteMergeAction other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(DeleteMergeAction left, DeleteMergeAction right) {
            return EqualityComparer<DeleteMergeAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DeleteMergeAction left, DeleteMergeAction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DeleteMergeAction)that;
            return compare;
        } 
        public static bool operator < (DeleteMergeAction left, DeleteMergeAction right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DeleteMergeAction left, DeleteMergeAction right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DeleteMergeAction left, DeleteMergeAction right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DeleteMergeAction left, DeleteMergeAction right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
