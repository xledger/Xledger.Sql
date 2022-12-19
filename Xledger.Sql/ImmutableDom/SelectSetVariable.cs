using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SelectSetVariable : SelectElement, IEquatable<SelectSetVariable> {
        protected VariableReference variable;
        protected ScalarExpression expression;
        protected ScriptDom.AssignmentKind assignmentKind = ScriptDom.AssignmentKind.Equals;
    
        public VariableReference Variable => variable;
        public ScalarExpression Expression => expression;
        public ScriptDom.AssignmentKind AssignmentKind => assignmentKind;
    
        public SelectSetVariable(VariableReference variable = null, ScalarExpression expression = null, ScriptDom.AssignmentKind assignmentKind = ScriptDom.AssignmentKind.Equals) {
            this.variable = variable;
            this.expression = expression;
            this.assignmentKind = assignmentKind;
        }
    
        public ScriptDom.SelectSetVariable ToMutableConcrete() {
            var ret = new ScriptDom.SelectSetVariable();
            ret.Variable = (ScriptDom.VariableReference)variable?.ToMutable();
            ret.Expression = (ScriptDom.ScalarExpression)expression?.ToMutable();
            ret.AssignmentKind = assignmentKind;
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
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            h = h * 23 + assignmentKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SelectSetVariable);
        } 
        
        public bool Equals(SelectSetVariable other) {
            if (other is null) { return false; }
            if (!EqualityComparer<VariableReference>.Default.Equals(other.Variable, variable)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AssignmentKind>.Default.Equals(other.AssignmentKind, assignmentKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SelectSetVariable left, SelectSetVariable right) {
            return EqualityComparer<SelectSetVariable>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SelectSetVariable left, SelectSetVariable right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SelectSetVariable)that;
            compare = Comparer.DefaultInvariant.Compare(this.variable, othr.variable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.assignmentKind, othr.assignmentKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SelectSetVariable left, SelectSetVariable right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SelectSetVariable left, SelectSetVariable right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SelectSetVariable left, SelectSetVariable right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SelectSetVariable left, SelectSetVariable right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SelectSetVariable FromMutable(ScriptDom.SelectSetVariable fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SelectSetVariable)) { throw new NotImplementedException("Unexpected subtype of SelectSetVariable not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SelectSetVariable(
                variable: ImmutableDom.VariableReference.FromMutable(fragment.Variable),
                expression: ImmutableDom.ScalarExpression.FromMutable(fragment.Expression),
                assignmentKind: fragment.AssignmentKind
            );
        }
    
    }

}
