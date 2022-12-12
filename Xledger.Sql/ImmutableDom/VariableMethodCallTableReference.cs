using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class VariableMethodCallTableReference : TableReferenceWithAliasAndColumns, IEquatable<VariableMethodCallTableReference> {
        VariableReference variable;
        Identifier methodName;
        IReadOnlyList<ScalarExpression> parameters;
    
        public VariableReference Variable => variable;
        public Identifier MethodName => methodName;
        public IReadOnlyList<ScalarExpression> Parameters => parameters;
    
        public VariableMethodCallTableReference(VariableReference variable = null, Identifier methodName = null, IReadOnlyList<ScalarExpression> parameters = null, IReadOnlyList<Identifier> columns = null, Identifier alias = null, bool forPath = false) {
            this.variable = variable;
            this.methodName = methodName;
            this.parameters = parameters is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(parameters);
            this.columns = columns is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(columns);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.VariableMethodCallTableReference ToMutableConcrete() {
            var ret = new ScriptDom.VariableMethodCallTableReference();
            ret.Variable = (ScriptDom.VariableReference)variable.ToMutable();
            ret.MethodName = (ScriptDom.Identifier)methodName.ToMutable();
            ret.Parameters.AddRange(parameters.Select(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
            ret.ForPath = forPath;
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
            if (!(methodName is null)) {
                h = h * 23 + methodName.GetHashCode();
            }
            h = h * 23 + parameters.GetHashCode();
            h = h * 23 + columns.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as VariableMethodCallTableReference);
        } 
        
        public bool Equals(VariableMethodCallTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<VariableReference>.Default.Equals(other.Variable, variable)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.MethodName, methodName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Alias, alias)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForPath, forPath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(VariableMethodCallTableReference left, VariableMethodCallTableReference right) {
            return EqualityComparer<VariableMethodCallTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(VariableMethodCallTableReference left, VariableMethodCallTableReference right) {
            return !(left == right);
        }
    
    }

}
