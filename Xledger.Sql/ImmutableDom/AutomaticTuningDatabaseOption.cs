using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AutomaticTuningDatabaseOption : DatabaseOption, IEquatable<AutomaticTuningDatabaseOption> {
        ScriptDom.AutomaticTuningState automaticTuningState = ScriptDom.AutomaticTuningState.NotSet;
        IReadOnlyList<AutomaticTuningOption> options;
    
        public ScriptDom.AutomaticTuningState AutomaticTuningState => automaticTuningState;
        public IReadOnlyList<AutomaticTuningOption> Options => options;
    
        public AutomaticTuningDatabaseOption(ScriptDom.AutomaticTuningState automaticTuningState = ScriptDom.AutomaticTuningState.NotSet, IReadOnlyList<AutomaticTuningOption> options = null, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.automaticTuningState = automaticTuningState;
            this.options = options is null ? ImmList<AutomaticTuningOption>.Empty : ImmList<AutomaticTuningOption>.FromList(options);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.AutomaticTuningDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.AutomaticTuningDatabaseOption();
            ret.AutomaticTuningState = automaticTuningState;
            ret.Options.AddRange(options.Select(c => (ScriptDom.AutomaticTuningOption)c.ToMutable()));
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + automaticTuningState.GetHashCode();
            h = h * 23 + options.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AutomaticTuningDatabaseOption);
        } 
        
        public bool Equals(AutomaticTuningDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AutomaticTuningState>.Default.Equals(other.AutomaticTuningState, automaticTuningState)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<AutomaticTuningOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AutomaticTuningDatabaseOption left, AutomaticTuningDatabaseOption right) {
            return EqualityComparer<AutomaticTuningDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AutomaticTuningDatabaseOption left, AutomaticTuningDatabaseOption right) {
            return !(left == right);
        }
    
    }

}
