using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LowPriorityLockWaitTableSwitchOption : TableSwitchOption, IEquatable<LowPriorityLockWaitTableSwitchOption> {
        IReadOnlyList<LowPriorityLockWaitOption> options;
    
        public IReadOnlyList<LowPriorityLockWaitOption> Options => options;
    
        public LowPriorityLockWaitTableSwitchOption(IReadOnlyList<LowPriorityLockWaitOption> options = null, ScriptDom.TableSwitchOptionKind optionKind = ScriptDom.TableSwitchOptionKind.LowPriorityLockWait) {
            this.options = options is null ? ImmList<LowPriorityLockWaitOption>.Empty : ImmList<LowPriorityLockWaitOption>.FromList(options);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LowPriorityLockWaitTableSwitchOption ToMutableConcrete() {
            var ret = new ScriptDom.LowPriorityLockWaitTableSwitchOption();
            ret.Options.AddRange(options.Select(c => (ScriptDom.LowPriorityLockWaitOption)c.ToMutable()));
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LowPriorityLockWaitTableSwitchOption);
        } 
        
        public bool Equals(LowPriorityLockWaitTableSwitchOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<LowPriorityLockWaitOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableSwitchOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LowPriorityLockWaitTableSwitchOption left, LowPriorityLockWaitTableSwitchOption right) {
            return EqualityComparer<LowPriorityLockWaitTableSwitchOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LowPriorityLockWaitTableSwitchOption left, LowPriorityLockWaitTableSwitchOption right) {
            return !(left == right);
        }
    
    }

}
