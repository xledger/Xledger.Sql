using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DatabaseConfigurationClearOption : TSqlFragment, IEquatable<DatabaseConfigurationClearOption> {
        protected ScriptDom.DatabaseConfigClearOptionKind optionKind = 0;
        protected BinaryLiteral planHandle;
    
        public ScriptDom.DatabaseConfigClearOptionKind OptionKind => optionKind;
        public BinaryLiteral PlanHandle => planHandle;
    
        public DatabaseConfigurationClearOption(ScriptDom.DatabaseConfigClearOptionKind optionKind = 0, BinaryLiteral planHandle = null) {
            this.optionKind = optionKind;
            this.planHandle = planHandle;
        }
    
        public ScriptDom.DatabaseConfigurationClearOption ToMutableConcrete() {
            var ret = new ScriptDom.DatabaseConfigurationClearOption();
            ret.OptionKind = optionKind;
            ret.PlanHandle = (ScriptDom.BinaryLiteral)planHandle?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            if (!(planHandle is null)) {
                h = h * 23 + planHandle.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DatabaseConfigurationClearOption);
        } 
        
        public bool Equals(DatabaseConfigurationClearOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DatabaseConfigClearOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<BinaryLiteral>.Default.Equals(other.PlanHandle, planHandle)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DatabaseConfigurationClearOption left, DatabaseConfigurationClearOption right) {
            return EqualityComparer<DatabaseConfigurationClearOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DatabaseConfigurationClearOption left, DatabaseConfigurationClearOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DatabaseConfigurationClearOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.planHandle, othr.planHandle);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (DatabaseConfigurationClearOption left, DatabaseConfigurationClearOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DatabaseConfigurationClearOption left, DatabaseConfigurationClearOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DatabaseConfigurationClearOption left, DatabaseConfigurationClearOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DatabaseConfigurationClearOption left, DatabaseConfigurationClearOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
