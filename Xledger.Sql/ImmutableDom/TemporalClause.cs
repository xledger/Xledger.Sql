using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TemporalClause : TSqlFragment, IEquatable<TemporalClause> {
        protected ScriptDom.TemporalClauseType temporalClauseType = ScriptDom.TemporalClauseType.AsOf;
        protected ScalarExpression startTime;
        protected ScalarExpression endTime;
    
        public ScriptDom.TemporalClauseType TemporalClauseType => temporalClauseType;
        public ScalarExpression StartTime => startTime;
        public ScalarExpression EndTime => endTime;
    
        public TemporalClause(ScriptDom.TemporalClauseType temporalClauseType = ScriptDom.TemporalClauseType.AsOf, ScalarExpression startTime = null, ScalarExpression endTime = null) {
            this.temporalClauseType = temporalClauseType;
            this.startTime = startTime;
            this.endTime = endTime;
        }
    
        public ScriptDom.TemporalClause ToMutableConcrete() {
            var ret = new ScriptDom.TemporalClause();
            ret.TemporalClauseType = temporalClauseType;
            ret.StartTime = (ScriptDom.ScalarExpression)startTime?.ToMutable();
            ret.EndTime = (ScriptDom.ScalarExpression)endTime?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + temporalClauseType.GetHashCode();
            if (!(startTime is null)) {
                h = h * 23 + startTime.GetHashCode();
            }
            if (!(endTime is null)) {
                h = h * 23 + endTime.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TemporalClause);
        } 
        
        public bool Equals(TemporalClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.TemporalClauseType>.Default.Equals(other.TemporalClauseType, temporalClauseType)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.StartTime, startTime)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.EndTime, endTime)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TemporalClause left, TemporalClause right) {
            return EqualityComparer<TemporalClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TemporalClause left, TemporalClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TemporalClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.temporalClauseType, othr.temporalClauseType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.startTime, othr.startTime);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.endTime, othr.endTime);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (TemporalClause left, TemporalClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TemporalClause left, TemporalClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TemporalClause left, TemporalClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TemporalClause left, TemporalClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TemporalClause FromMutable(ScriptDom.TemporalClause fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.TemporalClause)) { throw new NotImplementedException("Unexpected subtype of TemporalClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TemporalClause(
                temporalClauseType: fragment.TemporalClauseType,
                startTime: ImmutableDom.ScalarExpression.FromMutable(fragment.StartTime),
                endTime: ImmutableDom.ScalarExpression.FromMutable(fragment.EndTime)
            );
        }
    
    }

}
