using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IndexType : TSqlFragment, IEquatable<IndexType> {
        protected ScriptDom.IndexTypeKind? indexTypeKind;
    
        public ScriptDom.IndexTypeKind? IndexTypeKind => indexTypeKind;
    
        public IndexType(ScriptDom.IndexTypeKind? indexTypeKind = null) {
            this.indexTypeKind = indexTypeKind;
        }
    
        public ScriptDom.IndexType ToMutableConcrete() {
            var ret = new ScriptDom.IndexType();
            ret.IndexTypeKind = indexTypeKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + indexTypeKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IndexType);
        } 
        
        public bool Equals(IndexType other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.IndexTypeKind?>.Default.Equals(other.IndexTypeKind, indexTypeKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IndexType left, IndexType right) {
            return EqualityComparer<IndexType>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IndexType left, IndexType right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (IndexType)that;
            compare = Comparer.DefaultInvariant.Compare(this.indexTypeKind, othr.indexTypeKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (IndexType left, IndexType right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(IndexType left, IndexType right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (IndexType left, IndexType right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(IndexType left, IndexType right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
