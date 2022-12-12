using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MemoryOptimizedTableOption : TableOption, IEquatable<MemoryOptimizedTableOption> {
        ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public MemoryOptimizedTableOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.MemoryOptimizedTableOption ToMutableConcrete() {
            var ret = new ScriptDom.MemoryOptimizedTableOption();
            ret.OptionState = optionState;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MemoryOptimizedTableOption);
        } 
        
        public bool Equals(MemoryOptimizedTableOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MemoryOptimizedTableOption left, MemoryOptimizedTableOption right) {
            return EqualityComparer<MemoryOptimizedTableOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MemoryOptimizedTableOption left, MemoryOptimizedTableOption right) {
            return !(left == right);
        }
    
    }

}