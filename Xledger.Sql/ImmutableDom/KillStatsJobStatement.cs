using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class KillStatsJobStatement : TSqlStatement, IEquatable<KillStatsJobStatement> {
        protected ScalarExpression jobId;
    
        public ScalarExpression JobId => jobId;
    
        public KillStatsJobStatement(ScalarExpression jobId = null) {
            this.jobId = jobId;
        }
    
        public ScriptDom.KillStatsJobStatement ToMutableConcrete() {
            var ret = new ScriptDom.KillStatsJobStatement();
            ret.JobId = (ScriptDom.ScalarExpression)jobId?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(jobId is null)) {
                h = h * 23 + jobId.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as KillStatsJobStatement);
        } 
        
        public bool Equals(KillStatsJobStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.JobId, jobId)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(KillStatsJobStatement left, KillStatsJobStatement right) {
            return EqualityComparer<KillStatsJobStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(KillStatsJobStatement left, KillStatsJobStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (KillStatsJobStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.jobId, othr.jobId);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (KillStatsJobStatement left, KillStatsJobStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(KillStatsJobStatement left, KillStatsJobStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (KillStatsJobStatement left, KillStatsJobStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(KillStatsJobStatement left, KillStatsJobStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static KillStatsJobStatement FromMutable(ScriptDom.KillStatsJobStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.KillStatsJobStatement)) { throw new NotImplementedException("Unexpected subtype of KillStatsJobStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new KillStatsJobStatement(
                jobId: ImmutableDom.ScalarExpression.FromMutable(fragment.JobId)
            );
        }
    
    }

}
