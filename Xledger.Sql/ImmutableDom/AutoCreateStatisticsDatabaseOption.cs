using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AutoCreateStatisticsDatabaseOption : OnOffDatabaseOption, IEquatable<AutoCreateStatisticsDatabaseOption> {
        bool hasIncremental = false;
        ScriptDom.OptionState incrementalState = ScriptDom.OptionState.NotSet;
    
        public bool HasIncremental => hasIncremental;
        public ScriptDom.OptionState IncrementalState => incrementalState;
    
        public AutoCreateStatisticsDatabaseOption(bool hasIncremental = false, ScriptDom.OptionState incrementalState = ScriptDom.OptionState.NotSet, ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.hasIncremental = hasIncremental;
            this.incrementalState = incrementalState;
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.AutoCreateStatisticsDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.AutoCreateStatisticsDatabaseOption();
            ret.HasIncremental = hasIncremental;
            ret.IncrementalState = incrementalState;
            ret.OptionState = optionState;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + hasIncremental.GetHashCode();
            h = h * 23 + incrementalState.GetHashCode();
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AutoCreateStatisticsDatabaseOption);
        } 
        
        public bool Equals(AutoCreateStatisticsDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.HasIncremental, hasIncremental)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.IncrementalState, incrementalState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AutoCreateStatisticsDatabaseOption left, AutoCreateStatisticsDatabaseOption right) {
            return EqualityComparer<AutoCreateStatisticsDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AutoCreateStatisticsDatabaseOption left, AutoCreateStatisticsDatabaseOption right) {
            return !(left == right);
        }
    
    }

}
