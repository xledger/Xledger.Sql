using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RemoteDataArchiveDatabaseOption : DatabaseOption, IEquatable<RemoteDataArchiveDatabaseOption> {
        ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
        IReadOnlyList<RemoteDataArchiveDatabaseSetting> settings;
    
        public ScriptDom.OptionState OptionState => optionState;
        public IReadOnlyList<RemoteDataArchiveDatabaseSetting> Settings => settings;
    
        public RemoteDataArchiveDatabaseOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, IReadOnlyList<RemoteDataArchiveDatabaseSetting> settings = null, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.optionState = optionState;
            this.settings = settings is null ? ImmList<RemoteDataArchiveDatabaseSetting>.Empty : ImmList<RemoteDataArchiveDatabaseSetting>.FromList(settings);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.RemoteDataArchiveDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.RemoteDataArchiveDatabaseOption();
            ret.OptionState = optionState;
            ret.Settings.AddRange(settings.Select(c => (ScriptDom.RemoteDataArchiveDatabaseSetting)c.ToMutable()));
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + settings.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RemoteDataArchiveDatabaseOption);
        } 
        
        public bool Equals(RemoteDataArchiveDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<RemoteDataArchiveDatabaseSetting>>.Default.Equals(other.Settings, settings)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RemoteDataArchiveDatabaseOption left, RemoteDataArchiveDatabaseOption right) {
            return EqualityComparer<RemoteDataArchiveDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RemoteDataArchiveDatabaseOption left, RemoteDataArchiveDatabaseOption right) {
            return !(left == right);
        }
    
    }

}
