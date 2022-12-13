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
            ret.Variable = (ScriptDom.VariableReference)variable.ToMutable();
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
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
    
        public static SelectSetVariable FromMutable(ScriptDom.SelectSetVariable fragment) {
            return (SelectSetVariable)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
