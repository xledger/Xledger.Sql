using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SelectStarExpression : SelectElement, IEquatable<SelectStarExpression> {
        protected MultiPartIdentifier qualifier;
    
        public MultiPartIdentifier Qualifier => qualifier;
    
        public SelectStarExpression(MultiPartIdentifier qualifier = null) {
            this.qualifier = qualifier;
        }
    
        public ScriptDom.SelectStarExpression ToMutableConcrete() {
            var ret = new ScriptDom.SelectStarExpression();
            ret.Qualifier = (ScriptDom.MultiPartIdentifier)qualifier?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(qualifier is null)) {
                h = h * 23 + qualifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SelectStarExpression);
        } 
        
        public bool Equals(SelectStarExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<MultiPartIdentifier>.Default.Equals(other.Qualifier, qualifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SelectStarExpression left, SelectStarExpression right) {
            return EqualityComparer<SelectStarExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SelectStarExpression left, SelectStarExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SelectStarExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.qualifier, othr.qualifier);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SelectStarExpression left, SelectStarExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SelectStarExpression left, SelectStarExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SelectStarExpression left, SelectStarExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SelectStarExpression left, SelectStarExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SelectStarExpression FromMutable(ScriptDom.SelectStarExpression fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SelectStarExpression)) { throw new NotImplementedException("Unexpected subtype of SelectStarExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SelectStarExpression(
                qualifier: ImmutableDom.MultiPartIdentifier.FromMutable(fragment.Qualifier)
            );
        }
    
    }

}
