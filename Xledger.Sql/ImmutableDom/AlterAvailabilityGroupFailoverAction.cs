using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterAvailabilityGroupFailoverAction : AlterAvailabilityGroupAction, IEquatable<AlterAvailabilityGroupFailoverAction> {
        protected IReadOnlyList<AlterAvailabilityGroupFailoverOption> options;
    
        public IReadOnlyList<AlterAvailabilityGroupFailoverOption> Options => options;
    
        public AlterAvailabilityGroupFailoverAction(IReadOnlyList<AlterAvailabilityGroupFailoverOption> options = null, ScriptDom.AlterAvailabilityGroupActionType actionType = ScriptDom.AlterAvailabilityGroupActionType.Failover) {
            this.options = ImmList<AlterAvailabilityGroupFailoverOption>.FromList(options);
            this.actionType = actionType;
        }
    
        public ScriptDom.AlterAvailabilityGroupFailoverAction ToMutableConcrete() {
            var ret = new ScriptDom.AlterAvailabilityGroupFailoverAction();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AlterAvailabilityGroupFailoverOption)c?.ToMutable()));
            ret.ActionType = actionType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            h = h * 23 + actionType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterAvailabilityGroupFailoverAction);
        } 
        
        public bool Equals(AlterAvailabilityGroupFailoverAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<AlterAvailabilityGroupFailoverOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AlterAvailabilityGroupActionType>.Default.Equals(other.ActionType, actionType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterAvailabilityGroupFailoverAction left, AlterAvailabilityGroupFailoverAction right) {
            return EqualityComparer<AlterAvailabilityGroupFailoverAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterAvailabilityGroupFailoverAction left, AlterAvailabilityGroupFailoverAction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterAvailabilityGroupFailoverAction)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.actionType, othr.actionType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterAvailabilityGroupFailoverAction left, AlterAvailabilityGroupFailoverAction right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterAvailabilityGroupFailoverAction left, AlterAvailabilityGroupFailoverAction right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterAvailabilityGroupFailoverAction left, AlterAvailabilityGroupFailoverAction right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterAvailabilityGroupFailoverAction left, AlterAvailabilityGroupFailoverAction right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
