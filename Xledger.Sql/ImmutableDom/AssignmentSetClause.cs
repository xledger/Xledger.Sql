using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AssignmentSetClause : SetClause, IEquatable<AssignmentSetClause> {
        VariableReference variable;
        ColumnReferenceExpression column;
        ScalarExpression newValue;
        ScriptDom.AssignmentKind assignmentKind = ScriptDom.AssignmentKind.Equals;
    
        public VariableReference Variable => variable;
        public ColumnReferenceExpression Column => column;
        public ScalarExpression NewValue => newValue;
        public ScriptDom.AssignmentKind AssignmentKind => assignmentKind;
    
        public AssignmentSetClause(VariableReference variable = null, ColumnReferenceExpression column = null, ScalarExpression newValue = null, ScriptDom.AssignmentKind assignmentKind = ScriptDom.AssignmentKind.Equals) {
            this.variable = variable;
            this.column = column;
            this.newValue = newValue;
            this.assignmentKind = assignmentKind;
        }
    
        public ScriptDom.AssignmentSetClause ToMutableConcrete() {
            var ret = new ScriptDom.AssignmentSetClause();
            ret.Variable = (ScriptDom.VariableReference)variable.ToMutable();
            ret.Column = (ScriptDom.ColumnReferenceExpression)column.ToMutable();
            ret.NewValue = (ScriptDom.ScalarExpression)newValue.ToMutable();
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
            if (!(column is null)) {
                h = h * 23 + column.GetHashCode();
            }
            if (!(newValue is null)) {
                h = h * 23 + newValue.GetHashCode();
            }
            h = h * 23 + assignmentKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AssignmentSetClause);
        } 
        
        public bool Equals(AssignmentSetClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<VariableReference>.Default.Equals(other.Variable, variable)) {
                return false;
            }
            if (!EqualityComparer<ColumnReferenceExpression>.Default.Equals(other.Column, column)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.NewValue, newValue)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AssignmentKind>.Default.Equals(other.AssignmentKind, assignmentKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AssignmentSetClause left, AssignmentSetClause right) {
            return EqualityComparer<AssignmentSetClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AssignmentSetClause left, AssignmentSetClause right) {
            return !(left == right);
        }
    
    }

}
