using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IndexTableHint : TableHint, IEquatable<IndexTableHint> {
        protected IReadOnlyList<IdentifierOrValueExpression> indexValues;
    
        public IReadOnlyList<IdentifierOrValueExpression> IndexValues => indexValues;
    
        public IndexTableHint(IReadOnlyList<IdentifierOrValueExpression> indexValues = null, ScriptDom.TableHintKind hintKind = ScriptDom.TableHintKind.None) {
            this.indexValues = ImmList<IdentifierOrValueExpression>.FromList(indexValues);
            this.hintKind = hintKind;
        }
    
        public ScriptDom.IndexTableHint ToMutableConcrete() {
            var ret = new ScriptDom.IndexTableHint();
            ret.IndexValues.AddRange(indexValues.SelectList(c => (ScriptDom.IdentifierOrValueExpression)c.ToMutable()));
            ret.HintKind = hintKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + indexValues.GetHashCode();
            h = h * 23 + hintKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IndexTableHint);
        } 
        
        public bool Equals(IndexTableHint other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<IdentifierOrValueExpression>>.Default.Equals(other.IndexValues, indexValues)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableHintKind>.Default.Equals(other.HintKind, hintKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IndexTableHint left, IndexTableHint right) {
            return EqualityComparer<IndexTableHint>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IndexTableHint left, IndexTableHint right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (IndexTableHint)that;
            compare = Comparer.DefaultInvariant.Compare(this.indexValues, othr.indexValues);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.hintKind, othr.hintKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (IndexTableHint left, IndexTableHint right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(IndexTableHint left, IndexTableHint right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (IndexTableHint left, IndexTableHint right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(IndexTableHint left, IndexTableHint right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
