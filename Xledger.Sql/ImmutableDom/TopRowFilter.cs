using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TopRowFilter : TSqlFragment, IEquatable<TopRowFilter> {
        protected ScalarExpression expression;
        protected bool percent = false;
        protected bool withTies = false;
    
        public ScalarExpression Expression => expression;
        public bool Percent => percent;
        public bool WithTies => withTies;
    
        public TopRowFilter(ScalarExpression expression = null, bool percent = false, bool withTies = false) {
            this.expression = expression;
            this.percent = percent;
            this.withTies = withTies;
        }
    
        public ScriptDom.TopRowFilter ToMutableConcrete() {
            var ret = new ScriptDom.TopRowFilter();
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            ret.Percent = percent;
            ret.WithTies = withTies;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            h = h * 23 + percent.GetHashCode();
            h = h * 23 + withTies.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TopRowFilter);
        } 
        
        public bool Equals(TopRowFilter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.Percent, percent)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithTies, withTies)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TopRowFilter left, TopRowFilter right) {
            return EqualityComparer<TopRowFilter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TopRowFilter left, TopRowFilter right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TopRowFilter)that;
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.percent, othr.percent);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withTies, othr.withTies);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (TopRowFilter left, TopRowFilter right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TopRowFilter left, TopRowFilter right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TopRowFilter left, TopRowFilter right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TopRowFilter left, TopRowFilter right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TopRowFilter FromMutable(ScriptDom.TopRowFilter fragment) {
            return (TopRowFilter)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
