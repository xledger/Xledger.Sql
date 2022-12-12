using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LockEscalationTableOption : TableOption, IEquatable<LockEscalationTableOption> {
        ScriptDom.LockEscalationMethod @value = ScriptDom.LockEscalationMethod.Table;
    
        public ScriptDom.LockEscalationMethod Value => @value;
    
        public LockEscalationTableOption(ScriptDom.LockEscalationMethod @value = ScriptDom.LockEscalationMethod.Table, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LockEscalationTableOption ToMutableConcrete() {
            var ret = new ScriptDom.LockEscalationTableOption();
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
            return Equals(obj as LockEscalationTableOption);
        } 
        
        public bool Equals(LockEscalationTableOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.LockEscalationMethod>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LockEscalationTableOption left, LockEscalationTableOption right) {
            return EqualityComparer<LockEscalationTableOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LockEscalationTableOption left, LockEscalationTableOption right) {
            return !(left == right);
        }
    
    }

}