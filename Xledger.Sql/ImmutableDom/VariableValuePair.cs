using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class VariableValuePair : TSqlFragment, IEquatable<VariableValuePair> {
        protected VariableReference variable;
        protected ScalarExpression @value;
        protected bool isForUnknown = false;
    
        public VariableReference Variable => variable;
        public ScalarExpression Value => @value;
        public bool IsForUnknown => isForUnknown;
    
        public VariableValuePair(VariableReference variable = null, ScalarExpression @value = null, bool isForUnknown = false) {
            this.variable = variable;
            this.@value = @value;
            this.isForUnknown = isForUnknown;
        }
    
        public ScriptDom.VariableValuePair ToMutableConcrete() {
            var ret = new ScriptDom.VariableValuePair();
            ret.Variable = (ScriptDom.VariableReference)variable?.ToMutable();
            ret.Value = (ScriptDom.ScalarExpression)@value?.ToMutable();
            ret.IsForUnknown = isForUnknown;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(variable is null)) {
                h = h * 23 + variable.GetHashCode();
            }
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + isForUnknown.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as VariableValuePair);
        } 
        
        public bool Equals(VariableValuePair other) {
            if (other is null) { return false; }
            if (!EqualityComparer<VariableReference>.Default.Equals(other.Variable, variable)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsForUnknown, isForUnknown)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(VariableValuePair left, VariableValuePair right) {
            return EqualityComparer<VariableValuePair>.Default.Equals(left, right);
        }
        
        public static bool operator !=(VariableValuePair left, VariableValuePair right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (VariableValuePair)that;
            compare = Comparer.DefaultInvariant.Compare(this.variable, othr.variable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isForUnknown, othr.isForUnknown);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (VariableValuePair left, VariableValuePair right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(VariableValuePair left, VariableValuePair right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (VariableValuePair left, VariableValuePair right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(VariableValuePair left, VariableValuePair right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static VariableValuePair FromMutable(ScriptDom.VariableValuePair fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.VariableValuePair)) { throw new NotImplementedException("Unexpected subtype of VariableValuePair not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new VariableValuePair(
                variable: ImmutableDom.VariableReference.FromMutable(fragment.Variable),
                @value: ImmutableDom.ScalarExpression.FromMutable(fragment.Value),
                isForUnknown: fragment.IsForUnknown
            );
        }
    
    }

}
