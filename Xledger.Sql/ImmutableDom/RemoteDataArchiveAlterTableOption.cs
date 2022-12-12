using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RemoteDataArchiveAlterTableOption : TableOption, IEquatable<RemoteDataArchiveAlterTableOption> {
        ScriptDom.RdaTableOption rdaTableOption = ScriptDom.RdaTableOption.Disable;
        ScriptDom.MigrationState migrationState = ScriptDom.MigrationState.Paused;
        bool isMigrationStateSpecified = false;
        bool isFilterPredicateSpecified = false;
        FunctionCall filterPredicate;
    
        public ScriptDom.RdaTableOption RdaTableOption => rdaTableOption;
        public ScriptDom.MigrationState MigrationState => migrationState;
        public bool IsMigrationStateSpecified => isMigrationStateSpecified;
        public bool IsFilterPredicateSpecified => isFilterPredicateSpecified;
        public FunctionCall FilterPredicate => filterPredicate;
    
        public RemoteDataArchiveAlterTableOption(ScriptDom.RdaTableOption rdaTableOption = ScriptDom.RdaTableOption.Disable, ScriptDom.MigrationState migrationState = ScriptDom.MigrationState.Paused, bool isMigrationStateSpecified = false, bool isFilterPredicateSpecified = false, FunctionCall filterPredicate = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.rdaTableOption = rdaTableOption;
            this.migrationState = migrationState;
            this.isMigrationStateSpecified = isMigrationStateSpecified;
            this.isFilterPredicateSpecified = isFilterPredicateSpecified;
            this.filterPredicate = filterPredicate;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.RemoteDataArchiveAlterTableOption ToMutableConcrete() {
            var ret = new ScriptDom.RemoteDataArchiveAlterTableOption();
            ret.RdaTableOption = rdaTableOption;
            ret.MigrationState = migrationState;
            ret.IsMigrationStateSpecified = isMigrationStateSpecified;
            ret.IsFilterPredicateSpecified = isFilterPredicateSpecified;
            ret.FilterPredicate = (ScriptDom.FunctionCall)filterPredicate.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + rdaTableOption.GetHashCode();
            h = h * 23 + migrationState.GetHashCode();
            h = h * 23 + isMigrationStateSpecified.GetHashCode();
            h = h * 23 + isFilterPredicateSpecified.GetHashCode();
            if (!(filterPredicate is null)) {
                h = h * 23 + filterPredicate.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RemoteDataArchiveAlterTableOption);
        } 
        
        public bool Equals(RemoteDataArchiveAlterTableOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.RdaTableOption>.Default.Equals(other.RdaTableOption, rdaTableOption)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.MigrationState>.Default.Equals(other.MigrationState, migrationState)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsMigrationStateSpecified, isMigrationStateSpecified)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsFilterPredicateSpecified, isFilterPredicateSpecified)) {
                return false;
            }
            if (!EqualityComparer<FunctionCall>.Default.Equals(other.FilterPredicate, filterPredicate)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RemoteDataArchiveAlterTableOption left, RemoteDataArchiveAlterTableOption right) {
            return EqualityComparer<RemoteDataArchiveAlterTableOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RemoteDataArchiveAlterTableOption left, RemoteDataArchiveAlterTableOption right) {
            return !(left == right);
        }
    
    }

}