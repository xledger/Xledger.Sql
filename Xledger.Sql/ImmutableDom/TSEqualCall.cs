using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TSEqualCall : BooleanExpression, IEquatable<TSEqualCall> {
        protected ScalarExpression firstExpression;
        protected ScalarExpression secondExpression;
    
        public ScalarExpression FirstExpression => firstExpression;
        public ScalarExpression SecondExpression => secondExpression;
    
        public TSEqualCall(ScalarExpression firstExpression = null, ScalarExpression secondExpression = null) {
            this.firstExpression = firstExpression;
            this.secondExpression = secondExpression;
        }
    
        public ScriptDom.TSEqualCall ToMutableConcrete() {
            var ret = new ScriptDom.TSEqualCall();
            ret.FirstExpression = (ScriptDom.ScalarExpression)firstExpression?.ToMutable();
            ret.SecondExpression = (ScriptDom.ScalarExpression)secondExpression?.ToMutable();
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
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TSEqualCall);
        } 
        
        public bool Equals(TSEqualCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.FirstExpression, firstExpression)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.SecondExpression, secondExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TSEqualCall left, TSEqualCall right) {
            return EqualityComparer<TSEqualCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TSEqualCall left, TSEqualCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TSEqualCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.firstExpression, othr.firstExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.secondExpression, othr.secondExpression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (TSEqualCall left, TSEqualCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TSEqualCall left, TSEqualCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TSEqualCall left, TSEqualCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TSEqualCall left, TSEqualCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TSEqualCall FromMutable(ScriptDom.TSEqualCall fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.TSEqualCall)) { throw new NotImplementedException("Unexpected subtype of TSEqualCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TSEqualCall(
                firstExpression: ImmutableDom.ScalarExpression.FromMutable(fragment.FirstExpression),
                secondExpression: ImmutableDom.ScalarExpression.FromMutable(fragment.SecondExpression)
            );
        }
    
    }

}
