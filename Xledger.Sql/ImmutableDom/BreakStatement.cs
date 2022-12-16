using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BreakStatement : TSqlStatement, IEquatable<BreakStatement> {
        public BreakStatement() {

        }
    
        public ScriptDom.BreakStatement ToMutableConcrete() {
            var ret = new ScriptDom.BreakStatement();
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
            return Equals(obj as BreakStatement);
        } 
        
        public bool Equals(BreakStatement other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(BreakStatement left, BreakStatement right) {
            return EqualityComparer<BreakStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BreakStatement left, BreakStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BreakStatement)that;
            return compare;
        } 
        public static bool operator < (BreakStatement left, BreakStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BreakStatement left, BreakStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BreakStatement left, BreakStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BreakStatement left, BreakStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
