using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class VectorMetricIndexOption : IndexOption, IEquatable<VectorMetricIndexOption> {
        protected ScriptDom.VectorMetricType metricType = ScriptDom.VectorMetricType.Cosine;
    
        public ScriptDom.VectorMetricType MetricType => metricType;
    
        public VectorMetricIndexOption(ScriptDom.VectorMetricType metricType = ScriptDom.VectorMetricType.Cosine, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.metricType = metricType;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.VectorMetricIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.VectorMetricIndexOption();
            ret.MetricType = metricType;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + metricType.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as VectorMetricIndexOption);
        } 
        
        public bool Equals(VectorMetricIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.VectorMetricType>.Default.Equals(other.MetricType, metricType)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.IndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(VectorMetricIndexOption left, VectorMetricIndexOption right) {
            return EqualityComparer<VectorMetricIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(VectorMetricIndexOption left, VectorMetricIndexOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (VectorMetricIndexOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.metricType, othr.metricType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (VectorMetricIndexOption left, VectorMetricIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(VectorMetricIndexOption left, VectorMetricIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (VectorMetricIndexOption left, VectorMetricIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(VectorMetricIndexOption left, VectorMetricIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static VectorMetricIndexOption FromMutable(ScriptDom.VectorMetricIndexOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.VectorMetricIndexOption)) { throw new NotImplementedException("Unexpected subtype of VectorMetricIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new VectorMetricIndexOption(
                metricType: fragment.MetricType,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
