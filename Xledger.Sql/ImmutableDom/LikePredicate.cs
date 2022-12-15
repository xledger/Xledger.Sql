using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LikePredicate : BooleanExpression, IEquatable<LikePredicate> {
        protected ScalarExpression firstExpression;
        protected ScalarExpression secondExpression;
        protected bool notDefined = false;
        protected bool odbcEscape = false;
        protected ScalarExpression escapeExpression;
    
        public ScalarExpression FirstExpression => firstExpression;
        public ScalarExpression SecondExpression => secondExpression;
        public bool NotDefined => notDefined;
        public bool OdbcEscape => odbcEscape;
        public ScalarExpression EscapeExpression => escapeExpression;
    
        public LikePredicate(ScalarExpression firstExpression = null, ScalarExpression secondExpression = null, bool notDefined = false, bool odbcEscape = false, ScalarExpression escapeExpression = null) {
            this.firstExpression = firstExpression;
            this.secondExpression = secondExpression;
            this.notDefined = notDefined;
            this.odbcEscape = odbcEscape;
            this.escapeExpression = escapeExpression;
        }
    
        public ScriptDom.LikePredicate ToMutableConcrete() {
            var ret = new ScriptDom.LikePredicate();
            ret.FirstExpression = (ScriptDom.ScalarExpression)firstExpression.ToMutable();
            ret.SecondExpression = (ScriptDom.ScalarExpression)secondExpression.ToMutable();
            ret.NotDefined = notDefined;
            ret.OdbcEscape = odbcEscape;
            ret.EscapeExpression = (ScriptDom.ScalarExpression)escapeExpression.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(firstExpression is null)) {
                h = h * 23 + firstExpression.GetHashCode();
            }
            if (!(secondExpression is null)) {
                h = h * 23 + secondExpression.GetHashCode();
            }
            h = h * 23 + notDefined.GetHashCode();
            h = h * 23 + odbcEscape.GetHashCode();
            if (!(escapeExpression is null)) {
                h = h * 23 + escapeExpression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LikePredicate);
        } 
        
        public bool Equals(LikePredicate other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.FirstExpression, firstExpression)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.SecondExpression, secondExpression)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.NotDefined, notDefined)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.OdbcEscape, odbcEscape)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.EscapeExpression, escapeExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LikePredicate left, LikePredicate right) {
            return EqualityComparer<LikePredicate>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LikePredicate left, LikePredicate right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LikePredicate)that;
            compare = Comparer.DefaultInvariant.Compare(this.firstExpression, othr.firstExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.secondExpression, othr.secondExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.notDefined, othr.notDefined);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.odbcEscape, othr.odbcEscape);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.escapeExpression, othr.escapeExpression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (LikePredicate left, LikePredicate right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(LikePredicate left, LikePredicate right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (LikePredicate left, LikePredicate right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(LikePredicate left, LikePredicate right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
