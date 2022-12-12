using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SystemVersioningTableOption : TableOption, IEquatable<SystemVersioningTableOption> {
        ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
        ScriptDom.OptionState consistencyCheckEnabled = ScriptDom.OptionState.NotSet;
        SchemaObjectName historyTable;
        RetentionPeriodDefinition retentionPeriod;
    
        public ScriptDom.OptionState OptionState => optionState;
        public ScriptDom.OptionState ConsistencyCheckEnabled => consistencyCheckEnabled;
        public SchemaObjectName HistoryTable => historyTable;
        public RetentionPeriodDefinition RetentionPeriod => retentionPeriod;
    
        public SystemVersioningTableOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.OptionState consistencyCheckEnabled = ScriptDom.OptionState.NotSet, SchemaObjectName historyTable = null, RetentionPeriodDefinition retentionPeriod = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.optionState = optionState;
            this.consistencyCheckEnabled = consistencyCheckEnabled;
            this.historyTable = historyTable;
            this.retentionPeriod = retentionPeriod;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.SystemVersioningTableOption ToMutableConcrete() {
            var ret = new ScriptDom.SystemVersioningTableOption();
            ret.OptionState = optionState;
            ret.ConsistencyCheckEnabled = consistencyCheckEnabled;
            ret.HistoryTable = (ScriptDom.SchemaObjectName)historyTable.ToMutable();
            ret.RetentionPeriod = (ScriptDom.RetentionPeriodDefinition)retentionPeriod.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + consistencyCheckEnabled.GetHashCode();
            if (!(historyTable is null)) {
                h = h * 23 + historyTable.GetHashCode();
            }
            if (!(retentionPeriod is null)) {
                h = h * 23 + retentionPeriod.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SystemVersioningTableOption);
        } 
        
        public bool Equals(SystemVersioningTableOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.ConsistencyCheckEnabled, consistencyCheckEnabled)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.HistoryTable, historyTable)) {
                return false;
            }
            if (!EqualityComparer<RetentionPeriodDefinition>.Default.Equals(other.RetentionPeriod, retentionPeriod)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SystemVersioningTableOption left, SystemVersioningTableOption right) {
            return EqualityComparer<SystemVersioningTableOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SystemVersioningTableOption left, SystemVersioningTableOption right) {
            return !(left == right);
        }
    
    }

}