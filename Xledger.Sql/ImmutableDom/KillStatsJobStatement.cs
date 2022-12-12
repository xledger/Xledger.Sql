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
            ret.JobId = (ScriptDom.ScalarExpression)jobId.ToMutable();
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
    
    }

}
