using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetVariableStatement : TSqlStatement, IEquatable<SetVariableStatement> {
        protected VariableReference variable;
        protected ScriptDom.SeparatorType separatorType = ScriptDom.SeparatorType.NotSpecified;
        protected Identifier identifier;
        protected bool functionCallExists = false;
        protected IReadOnlyList<ScalarExpression> parameters;
        protected ScalarExpression expression;
        protected CursorDefinition cursorDefinition;
        protected ScriptDom.AssignmentKind assignmentKind = ScriptDom.AssignmentKind.Equals;
    
        public VariableReference Variable => variable;
        public ScriptDom.SeparatorType SeparatorType => separatorType;
        public Identifier Identifier => identifier;
        public bool FunctionCallExists => functionCallExists;
        public IReadOnlyList<ScalarExpression> Parameters => parameters;
        public ScalarExpression Expression => expression;
        public CursorDefinition CursorDefinition => cursorDefinition;
        public ScriptDom.AssignmentKind AssignmentKind => assignmentKind;
    
        public SetVariableStatement(VariableReference variable = null, ScriptDom.SeparatorType separatorType = ScriptDom.SeparatorType.NotSpecified, Identifier identifier = null, bool functionCallExists = false, IReadOnlyList<ScalarExpression> parameters = null, ScalarExpression expression = null, CursorDefinition cursorDefinition = null, ScriptDom.AssignmentKind assignmentKind = ScriptDom.AssignmentKind.Equals) {
            this.variable = variable;
            this.separatorType = separatorType;
            this.identifier = identifier;
            this.functionCallExists = functionCallExists;
            this.parameters = ImmList<ScalarExpression>.FromList(parameters);
            this.expression = expression;
            this.cursorDefinition = cursorDefinition;
            this.assignmentKind = assignmentKind;
        }
    
        public ScriptDom.SetVariableStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetVariableStatement();
            ret.Variable = (ScriptDom.VariableReference)variable.ToMutable();
            ret.SeparatorType = separatorType;
            ret.Identifier = (ScriptDom.Identifier)identifier.ToMutable();
            ret.FunctionCallExists = functionCallExists;
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            ret.CursorDefinition = (ScriptDom.CursorDefinition)cursorDefinition.ToMutable();
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
            h = h * 23 + separatorType.GetHashCode();
            if (!(identifier is null)) {
                h = h * 23 + identifier.GetHashCode();
            }
            h = h * 23 + functionCallExists.GetHashCode();
            h = h * 23 + parameters.GetHashCode();
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            if (!(cursorDefinition is null)) {
                h = h * 23 + cursorDefinition.GetHashCode();
            }
            h = h * 23 + assignmentKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetVariableStatement);
        } 
        
        public bool Equals(SetVariableStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<VariableReference>.Default.Equals(other.Variable, variable)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SeparatorType>.Default.Equals(other.SeparatorType, separatorType)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Identifier, identifier)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.FunctionCallExists, functionCallExists)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<CursorDefinition>.Default.Equals(other.CursorDefinition, cursorDefinition)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AssignmentKind>.Default.Equals(other.AssignmentKind, assignmentKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetVariableStatement left, SetVariableStatement right) {
            return EqualityComparer<SetVariableStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetVariableStatement left, SetVariableStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SetVariableStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.variable, othr.variable);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.separatorType, othr.separatorType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.identifier, othr.identifier);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.functionCallExists, othr.functionCallExists);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.cursorDefinition, othr.cursorDefinition);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.assignmentKind, othr.assignmentKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static SetVariableStatement FromMutable(ScriptDom.SetVariableStatement fragment) {
            return (SetVariableStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
