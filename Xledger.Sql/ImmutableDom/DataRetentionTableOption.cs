using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DataRetentionTableOption : TableOption, IEquatable<DataRetentionTableOption> {
        ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
        Identifier filterColumn;
        RetentionPeriodDefinition retentionPeriod;
    
        public ScriptDom.OptionState OptionState => optionState;
        public Identifier FilterColumn => filterColumn;
        public RetentionPeriodDefinition RetentionPeriod => retentionPeriod;
    
        public DataRetentionTableOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, Identifier filterColumn = null, RetentionPeriodDefinition retentionPeriod = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.optionState = optionState;
            this.filterColumn = filterColumn;
            this.retentionPeriod = retentionPeriod;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.DataRetentionTableOption ToMutableConcrete() {
            var ret = new ScriptDom.DataRetentionTableOption();
            ret.OptionState = optionState;
            ret.FilterColumn = (ScriptDom.Identifier)filterColumn.ToMutable();
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
            if (!(filterColumn is null)) {
                h = h * 23 + filterColumn.GetHashCode();
            }
            if (!(retentionPeriod is null)) {
                h = h * 23 + retentionPeriod.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DataRetentionTableOption);
        } 
        
        public bool Equals(DataRetentionTableOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.FilterColumn, filterColumn)) {
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
        
        public static bool operator ==(DataRetentionTableOption left, DataRetentionTableOption right) {
            return EqualityComparer<DataRetentionTableOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DataRetentionTableOption left, DataRetentionTableOption right) {
            return !(left == right);
        }
    
    }

}
