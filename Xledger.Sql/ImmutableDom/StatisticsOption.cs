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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (StatisticsOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (StatisticsOption left, StatisticsOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(StatisticsOption left, StatisticsOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (StatisticsOption left, StatisticsOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(StatisticsOption left, StatisticsOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static StatisticsOption FromMutable(ScriptDom.StatisticsOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.StatisticsOption)) { return TSqlFragment.FromMutable(fragment) as StatisticsOption; }
            return new StatisticsOption(
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
