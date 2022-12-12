using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BackupOption : TSqlFragment, IEquatable<BackupOption> {
        protected ScriptDom.BackupOptionKind optionKind = ScriptDom.BackupOptionKind.None;
        protected ScalarExpression @value;
    
        public ScriptDom.BackupOptionKind OptionKind => optionKind;
        public ScalarExpression Value => @value;
    
        public BackupOption(ScriptDom.BackupOptionKind optionKind = ScriptDom.BackupOptionKind.None, ScalarExpression @value = null) {
            this.optionKind = optionKind;
            this.@value = @value;
        }
    
        public ScriptDom.BackupOption ToMutableConcrete() {
            var ret = new ScriptDom.BackupOption();
            ret.OptionKind = optionKind;
            ret.Value = (ScriptDom.ScalarExpression)@value.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BackupOption);
        } 
        
        public bool Equals(BackupOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.BackupOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BackupOption left, BackupOption right) {
            return EqualityComparer<BackupOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BackupOption left, BackupOption right) {
            return !(left == right);
        }
    
    }

}
