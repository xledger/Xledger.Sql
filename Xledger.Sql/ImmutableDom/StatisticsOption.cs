using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class StatisticsOption : TSqlFragment, IEquatable<StatisticsOption> {
        protected ScriptDom.StatisticsOptionKind optionKind = ScriptDom.StatisticsOptionKind.FullScan;
    
        public ScriptDom.StatisticsOptionKind OptionKind => optionKind;
    
        public StatisticsOption(ScriptDom.StatisticsOptionKind optionKind = ScriptDom.StatisticsOptionKind.FullScan) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.StatisticsOption ToMutableConcrete() {
            var ret = new ScriptDom.StatisticsOption();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as StatisticsOption);
        } 
        
        public bool Equals(StatisticsOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.StatisticsOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(StatisticsOption left, StatisticsOption right) {
            return EqualityComparer<StatisticsOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(StatisticsOption left, StatisticsOption right) {
            return !(left == right);
        }
    
    }

}
