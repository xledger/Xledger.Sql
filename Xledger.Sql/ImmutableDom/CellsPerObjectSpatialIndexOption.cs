using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CellsPerObjectSpatialIndexOption : SpatialIndexOption, IEquatable<CellsPerObjectSpatialIndexOption> {
        protected Literal @value;
    
        public Literal Value => @value;
    
        public CellsPerObjectSpatialIndexOption(Literal @value = null) {
            this.@value = @value;
        }
    
        public ScriptDom.CellsPerObjectSpatialIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.CellsPerObjectSpatialIndexOption();
            ret.Value = (ScriptDom.Literal)@value?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CellsPerObjectSpatialIndexOption);
        } 
        
        public bool Equals(CellsPerObjectSpatialIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CellsPerObjectSpatialIndexOption left, CellsPerObjectSpatialIndexOption right) {
            return EqualityComparer<CellsPerObjectSpatialIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CellsPerObjectSpatialIndexOption left, CellsPerObjectSpatialIndexOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CellsPerObjectSpatialIndexOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CellsPerObjectSpatialIndexOption left, CellsPerObjectSpatialIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CellsPerObjectSpatialIndexOption left, CellsPerObjectSpatialIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CellsPerObjectSpatialIndexOption left, CellsPerObjectSpatialIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CellsPerObjectSpatialIndexOption left, CellsPerObjectSpatialIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
