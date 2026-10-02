using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class VectorTypeIndexOption : IndexOption, IEquatable<VectorTypeIndexOption> {
        protected ScriptDom.VectorIndexType vectorType = ScriptDom.VectorIndexType.DiskANN;
    
        public ScriptDom.VectorIndexType VectorType => vectorType;
    
        public VectorTypeIndexOption(ScriptDom.VectorIndexType vectorType = ScriptDom.VectorIndexType.DiskANN, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.vectorType = vectorType;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.VectorTypeIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.VectorTypeIndexOption();
            ret.VectorType = vectorType;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + vectorType.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as VectorTypeIndexOption);
        } 
        
        public bool Equals(VectorTypeIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.VectorIndexType>.Default.Equals(other.VectorType, vectorType)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.IndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(VectorTypeIndexOption left, VectorTypeIndexOption right) {
            return EqualityComparer<VectorTypeIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(VectorTypeIndexOption left, VectorTypeIndexOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (VectorTypeIndexOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.vectorType, othr.vectorType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (VectorTypeIndexOption left, VectorTypeIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(VectorTypeIndexOption left, VectorTypeIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (VectorTypeIndexOption left, VectorTypeIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(VectorTypeIndexOption left, VectorTypeIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static VectorTypeIndexOption FromMutable(ScriptDom.VectorTypeIndexOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.VectorTypeIndexOption)) { throw new NotImplementedException("Unexpected subtype of VectorTypeIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new VectorTypeIndexOption(
                vectorType: fragment.VectorType,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
