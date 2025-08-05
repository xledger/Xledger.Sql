using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SchemaObjectFunctionTableReference : TableReferenceWithAliasAndColumns, IEquatable<SchemaObjectFunctionTableReference> {
        protected SchemaObjectName schemaObject;
        protected IReadOnlyList<ScalarExpression> parameters;
    
        public SchemaObjectName SchemaObject => schemaObject;
        public IReadOnlyList<ScalarExpression> Parameters => parameters;
    
        public SchemaObjectFunctionTableReference(SchemaObjectName schemaObject = null, IReadOnlyList<ScalarExpression> parameters = null, IReadOnlyList<Identifier> columns = null, Identifier alias = null, bool forPath = false) {
            this.schemaObject = schemaObject;
            this.parameters = parameters.ToImmArray<ScalarExpression>();
            this.columns = columns.ToImmArray<Identifier>();
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.SchemaObjectFunctionTableReference ToMutableConcrete() {
            var ret = new ScriptDom.SchemaObjectFunctionTableReference();
            ret.SchemaObject = (ScriptDom.SchemaObjectName)schemaObject?.ToMutable();
            ret.Parameters.AddRange(parameters.Select(c => (ScriptDom.ScalarExpression)c?.ToMutable()));
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias?.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(schemaObject is null)) {
                h = h * 23 + schemaObject.GetHashCode();
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
            return Equals(obj as SchemaObjectFunctionTableReference);
        } 
        
        public bool Equals(SchemaObjectFunctionTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObject, schemaObject)) {
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
        
        public static bool operator ==(SchemaObjectFunctionTableReference left, SchemaObjectFunctionTableReference right) {
            return EqualityComparer<SchemaObjectFunctionTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SchemaObjectFunctionTableReference left, SchemaObjectFunctionTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SchemaObjectFunctionTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.schemaObject, othr.schemaObject);
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
        
        public static bool operator < (SchemaObjectFunctionTableReference left, SchemaObjectFunctionTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SchemaObjectFunctionTableReference left, SchemaObjectFunctionTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SchemaObjectFunctionTableReference left, SchemaObjectFunctionTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SchemaObjectFunctionTableReference left, SchemaObjectFunctionTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SchemaObjectFunctionTableReference FromMutable(ScriptDom.SchemaObjectFunctionTableReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SchemaObjectFunctionTableReference)) { throw new NotImplementedException("Unexpected subtype of SchemaObjectFunctionTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SchemaObjectFunctionTableReference(
                schemaObject: ImmutableDom.SchemaObjectName.FromMutable(fragment.SchemaObject),
                parameters: fragment.Parameters.ToImmArray(ImmutableDom.ScalarExpression.FromMutable),
                columns: fragment.Columns.ToImmArray(ImmutableDom.Identifier.FromMutable),
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
