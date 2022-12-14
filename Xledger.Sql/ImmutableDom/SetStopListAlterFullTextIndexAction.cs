using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetStopListAlterFullTextIndexAction : AlterFullTextIndexAction, IEquatable<SetStopListAlterFullTextIndexAction> {
        protected StopListFullTextIndexOption stopListOption;
        protected bool withNoPopulation = false;
    
        public StopListFullTextIndexOption StopListOption => stopListOption;
        public bool WithNoPopulation => withNoPopulation;
    
        public SetStopListAlterFullTextIndexAction(StopListFullTextIndexOption stopListOption = null, bool withNoPopulation = false) {
            this.stopListOption = stopListOption;
            this.withNoPopulation = withNoPopulation;
        }
    
        public ScriptDom.SetStopListAlterFullTextIndexAction ToMutableConcrete() {
            var ret = new ScriptDom.SetStopListAlterFullTextIndexAction();
            ret.StopListOption = (ScriptDom.StopListFullTextIndexOption)stopListOption.ToMutable();
            ret.WithNoPopulation = withNoPopulation;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(stopListOption is null)) {
                h = h * 23 + stopListOption.GetHashCode();
            }
            h = h * 23 + withNoPopulation.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetStopListAlterFullTextIndexAction);
        } 
        
        public bool Equals(SetStopListAlterFullTextIndexAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StopListFullTextIndexOption>.Default.Equals(other.StopListOption, stopListOption)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithNoPopulation, withNoPopulation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetStopListAlterFullTextIndexAction left, SetStopListAlterFullTextIndexAction right) {
            return EqualityComparer<SetStopListAlterFullTextIndexAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetStopListAlterFullTextIndexAction left, SetStopListAlterFullTextIndexAction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SetStopListAlterFullTextIndexAction)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.stopListOption, othr.stopListOption);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.withNoPopulation, othr.withNoPopulation);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static SetStopListAlterFullTextIndexAction FromMutable(ScriptDom.SetStopListAlterFullTextIndexAction fragment) {
            return (SetStopListAlterFullTextIndexAction)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
