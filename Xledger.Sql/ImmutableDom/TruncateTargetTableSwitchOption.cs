using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TruncateTargetTableSwitchOption : TableSwitchOption, IEquatable<TruncateTargetTableSwitchOption> {
        bool truncateTarget = false;
    
        public bool TruncateTarget => truncateTarget;
    
        public TruncateTargetTableSwitchOption(bool truncateTarget = false, ScriptDom.TableSwitchOptionKind optionKind = ScriptDom.TableSwitchOptionKind.LowPriorityLockWait) {
            this.truncateTarget = truncateTarget;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.TruncateTargetTableSwitchOption ToMutableConcrete() {
            var ret = new ScriptDom.TruncateTargetTableSwitchOption();
            ret.TruncateTarget = truncateTarget;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + truncateTarget.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TruncateTargetTableSwitchOption);
        } 
        
        public bool Equals(TruncateTargetTableSwitchOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.TruncateTarget, truncateTarget)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableSwitchOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TruncateTargetTableSwitchOption left, TruncateTargetTableSwitchOption right) {
            return EqualityComparer<TruncateTargetTableSwitchOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TruncateTargetTableSwitchOption left, TruncateTargetTableSwitchOption right) {
            return !(left == right);
        }
    
    }

}
