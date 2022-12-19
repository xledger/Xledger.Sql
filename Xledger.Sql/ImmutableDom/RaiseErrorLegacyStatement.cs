using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RaiseErrorLegacyStatement : TSqlStatement, IEquatable<RaiseErrorLegacyStatement> {
        protected ScalarExpression firstParameter;
        protected ValueExpression secondParameter;
    
        public ScalarExpression FirstParameter => firstParameter;
        public ValueExpression SecondParameter => secondParameter;
    
        public RaiseErrorLegacyStatement(ScalarExpression firstParameter = null, ValueExpression secondParameter = null) {
            this.firstParameter = firstParameter;
            this.secondParameter = secondParameter;
        }
    
        public ScriptDom.RaiseErrorLegacyStatement ToMutableConcrete() {
            var ret = new ScriptDom.RaiseErrorLegacyStatement();
            ret.FirstParameter = (ScriptDom.ScalarExpression)firstParameter?.ToMutable();
            ret.SecondParameter = (ScriptDom.ValueExpression)secondParameter?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(firstParameter is null)) {
                h = h * 23 + firstParameter.GetHashCode();
            }
            if (!(secondParameter is null)) {
                h = h * 23 + secondParameter.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RaiseErrorLegacyStatement);
        } 
        
        public bool Equals(RaiseErrorLegacyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.FirstParameter, firstParameter)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.SecondParameter, secondParameter)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RaiseErrorLegacyStatement left, RaiseErrorLegacyStatement right) {
            return EqualityComparer<RaiseErrorLegacyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RaiseErrorLegacyStatement left, RaiseErrorLegacyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RaiseErrorLegacyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.firstParameter, othr.firstParameter);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.secondParameter, othr.secondParameter);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (RaiseErrorLegacyStatement left, RaiseErrorLegacyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(RaiseErrorLegacyStatement left, RaiseErrorLegacyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (RaiseErrorLegacyStatement left, RaiseErrorLegacyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(RaiseErrorLegacyStatement left, RaiseErrorLegacyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static RaiseErrorLegacyStatement FromMutable(ScriptDom.RaiseErrorLegacyStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.RaiseErrorLegacyStatement)) { throw new NotImplementedException("Unexpected subtype of RaiseErrorLegacyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RaiseErrorLegacyStatement(
                firstParameter: ImmutableDom.ScalarExpression.FromMutable(fragment.FirstParameter),
                secondParameter: ImmutableDom.ValueExpression.FromMutable(fragment.SecondParameter)
            );
        }
    
    }

}
