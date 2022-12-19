using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SystemTimePeriodDefinition : TSqlFragment, IEquatable<SystemTimePeriodDefinition> {
        protected Identifier startTimeColumn;
        protected Identifier endTimeColumn;
    
        public Identifier StartTimeColumn => startTimeColumn;
        public Identifier EndTimeColumn => endTimeColumn;
    
        public SystemTimePeriodDefinition(Identifier startTimeColumn = null, Identifier endTimeColumn = null) {
            this.startTimeColumn = startTimeColumn;
            this.endTimeColumn = endTimeColumn;
        }
    
        public ScriptDom.SystemTimePeriodDefinition ToMutableConcrete() {
            var ret = new ScriptDom.SystemTimePeriodDefinition();
            ret.StartTimeColumn = (ScriptDom.Identifier)startTimeColumn?.ToMutable();
            ret.EndTimeColumn = (ScriptDom.Identifier)endTimeColumn?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(startTimeColumn is null)) {
                h = h * 23 + startTimeColumn.GetHashCode();
            }
            if (!(endTimeColumn is null)) {
                h = h * 23 + endTimeColumn.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SystemTimePeriodDefinition);
        } 
        
        public bool Equals(SystemTimePeriodDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.StartTimeColumn, startTimeColumn)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.EndTimeColumn, endTimeColumn)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SystemTimePeriodDefinition left, SystemTimePeriodDefinition right) {
            return EqualityComparer<SystemTimePeriodDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SystemTimePeriodDefinition left, SystemTimePeriodDefinition right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SystemTimePeriodDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.startTimeColumn, othr.startTimeColumn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.endTimeColumn, othr.endTimeColumn);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SystemTimePeriodDefinition left, SystemTimePeriodDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SystemTimePeriodDefinition left, SystemTimePeriodDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SystemTimePeriodDefinition left, SystemTimePeriodDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SystemTimePeriodDefinition left, SystemTimePeriodDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SystemTimePeriodDefinition FromMutable(ScriptDom.SystemTimePeriodDefinition fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SystemTimePeriodDefinition)) { throw new NotImplementedException("Unexpected subtype of SystemTimePeriodDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SystemTimePeriodDefinition(
                startTimeColumn: ImmutableDom.Identifier.FromMutable(fragment.StartTimeColumn),
                endTimeColumn: ImmutableDom.Identifier.FromMutable(fragment.EndTimeColumn)
            );
        }
    
    }

}
