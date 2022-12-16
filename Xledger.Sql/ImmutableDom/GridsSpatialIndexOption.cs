using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GridsSpatialIndexOption : SpatialIndexOption, IEquatable<GridsSpatialIndexOption> {
        protected IReadOnlyList<GridParameter> gridParameters;
    
        public IReadOnlyList<GridParameter> GridParameters => gridParameters;
    
        public GridsSpatialIndexOption(IReadOnlyList<GridParameter> gridParameters = null) {
            this.gridParameters = ImmList<GridParameter>.FromList(gridParameters);
        }
    
        public ScriptDom.GridsSpatialIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.GridsSpatialIndexOption();
            ret.GridParameters.AddRange(gridParameters.SelectList(c => (ScriptDom.GridParameter)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + gridParameters.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GridsSpatialIndexOption);
        } 
        
        public bool Equals(GridsSpatialIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<GridParameter>>.Default.Equals(other.GridParameters, gridParameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GridsSpatialIndexOption left, GridsSpatialIndexOption right) {
            return EqualityComparer<GridsSpatialIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GridsSpatialIndexOption left, GridsSpatialIndexOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GridsSpatialIndexOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.gridParameters, othr.gridParameters);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (GridsSpatialIndexOption left, GridsSpatialIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GridsSpatialIndexOption left, GridsSpatialIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GridsSpatialIndexOption left, GridsSpatialIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GridsSpatialIndexOption left, GridsSpatialIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
