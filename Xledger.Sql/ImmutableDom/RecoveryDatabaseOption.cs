using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RecoveryDatabaseOption : DatabaseOption, IEquatable<RecoveryDatabaseOption> {
        ScriptDom.RecoveryDatabaseOptionKind @value = ScriptDom.RecoveryDatabaseOptionKind.None;
    
        public ScriptDom.RecoveryDatabaseOptionKind Value => @value;
    
        public RecoveryDatabaseOption(ScriptDom.RecoveryDatabaseOptionKind @value = ScriptDom.RecoveryDatabaseOptionKind.None, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.RecoveryDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.RecoveryDatabaseOption();
            ret.Value = @value;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + @value.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RecoveryDatabaseOption);
        } 
        
        public bool Equals(RecoveryDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.RecoveryDatabaseOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RecoveryDatabaseOption left, RecoveryDatabaseOption right) {
            return EqualityComparer<RecoveryDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RecoveryDatabaseOption left, RecoveryDatabaseOption right) {
            return !(left == right);
        }
    
    }

}
