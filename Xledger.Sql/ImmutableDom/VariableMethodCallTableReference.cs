using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class VariableMethodCallTableReference : TableReferenceWithAliasAndColumns, IEquatable<VariableMethodCallTableReference> {
        protected VariableReference variable;
        protected Identifier methodName;
        protected IReadOnlyList<ScalarExpression> parameters;
    
        public VariableReference Variable => variable;
        public Identifier MethodName => methodName;
        public IReadOnlyList<ScalarExpression> Parameters => parameters;
    
        public VariableMethodCallTableReference(VariableReference variable = null, Identifier methodName = null, IReadOnlyList<ScalarExpression> parameters = null, IReadOnlyList<Identifier> columns = null, Identifier alias = null, bool forPath = false) {
            this.variable = variable;
            this.methodName = methodName;
            this.parameters = ImmList<ScalarExpression>.FromList(parameters);
            this.columns = ImmList<Identifier>.FromList(columns);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.VariableMethodCallTableReference ToMutableConcrete() {
            var ret = new ScriptDom.VariableMethodCallTableReference();
            ret.Variable = (ScriptDom.VariableReference)variable.ToMutable();
            ret.MethodName = (ScriptDom.Identifier)methodName.ToMutable();
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (VariableMethodCallTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.variable, othr.variable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.methodName, othr.methodName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (VariableMethodCallTableReference left, VariableMethodCallTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(VariableMethodCallTableReference left, VariableMethodCallTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (VariableMethodCallTableReference left, VariableMethodCallTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(VariableMethodCallTableReference left, VariableMethodCallTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static VariableMethodCallTableReference FromMutable(ScriptDom.VariableMethodCallTableReference fragment) {
            return (VariableMethodCallTableReference)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
