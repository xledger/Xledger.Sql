using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SpatialIndexRegularOption : SpatialIndexOption, IEquatable<SpatialIndexRegularOption> {
        protected IndexOption option;
    
        public IndexOption Option => option;
    
        public SpatialIndexRegularOption(IndexOption option = null) {
            this.option = option;
        }
    
        public ScriptDom.SpatialIndexRegularOption ToMutableConcrete() {
            var ret = new ScriptDom.SpatialIndexRegularOption();
            ret.Option = (ScriptDom.IndexOption)option?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(option is null)) {
                h = h * 23 + option.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SpatialIndexRegularOption);
        } 
        
        public bool Equals(SpatialIndexRegularOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IndexOption>.Default.Equals(other.Option, option)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SpatialIndexRegularOption left, SpatialIndexRegularOption right) {
            return EqualityComparer<SpatialIndexRegularOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SpatialIndexRegularOption left, SpatialIndexRegularOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SpatialIndexRegularOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.option, othr.option);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SpatialIndexRegularOption left, SpatialIndexRegularOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SpatialIndexRegularOption left, SpatialIndexRegularOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SpatialIndexRegularOption left, SpatialIndexRegularOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SpatialIndexRegularOption left, SpatialIndexRegularOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SpatialIndexRegularOption FromMutable(ScriptDom.SpatialIndexRegularOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SpatialIndexRegularOption)) { throw new NotImplementedException("Unexpected subtype of SpatialIndexRegularOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SpatialIndexRegularOption(
                option: ImmutableDom.IndexOption.FromMutable(fragment.Option)
            );
        }
    
    }

}
