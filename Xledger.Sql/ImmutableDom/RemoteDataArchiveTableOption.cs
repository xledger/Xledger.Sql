using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RemoteDataArchiveTableOption : TableOption, IEquatable<RemoteDataArchiveTableOption> {
        protected ScriptDom.RdaTableOption rdaTableOption = ScriptDom.RdaTableOption.Disable;
        protected ScriptDom.MigrationState migrationState = ScriptDom.MigrationState.Paused;
    
        public ScriptDom.RdaTableOption RdaTableOption => rdaTableOption;
        public ScriptDom.MigrationState MigrationState => migrationState;
    
        public RemoteDataArchiveTableOption(ScriptDom.RdaTableOption rdaTableOption = ScriptDom.RdaTableOption.Disable, ScriptDom.MigrationState migrationState = ScriptDom.MigrationState.Paused, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.rdaTableOption = rdaTableOption;
            this.migrationState = migrationState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.RemoteDataArchiveTableOption ToMutableConcrete() {
            var ret = new ScriptDom.RemoteDataArchiveTableOption();
            ret.RdaTableOption = rdaTableOption;
            ret.MigrationState = migrationState;
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
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RemoteDataArchiveTableOption);
        } 
        
        public bool Equals(RemoteDataArchiveTableOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.RdaTableOption>.Default.Equals(other.RdaTableOption, rdaTableOption)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.MigrationState>.Default.Equals(other.MigrationState, migrationState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RemoteDataArchiveTableOption left, RemoteDataArchiveTableOption right) {
            return EqualityComparer<RemoteDataArchiveTableOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RemoteDataArchiveTableOption left, RemoteDataArchiveTableOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RemoteDataArchiveTableOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.rdaTableOption, othr.rdaTableOption);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.migrationState, othr.migrationState);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static RemoteDataArchiveTableOption FromMutable(ScriptDom.RemoteDataArchiveTableOption fragment) {
            return (RemoteDataArchiveTableOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
