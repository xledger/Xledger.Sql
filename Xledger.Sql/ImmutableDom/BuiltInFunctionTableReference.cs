using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BuiltInFunctionTableReference : TableReferenceWithAlias, IEquatable<BuiltInFunctionTableReference> {
        protected Identifier name;
        protected IReadOnlyList<ScalarExpression> parameters;
    
        public Identifier Name => name;
        public IReadOnlyList<ScalarExpression> Parameters => parameters;
    
        public BuiltInFunctionTableReference(Identifier name = null, IReadOnlyList<ScalarExpression> parameters = null, Identifier alias = null, bool forPath = false) {
            this.name = name;
            this.parameters = parameters.ToImmArray<ScalarExpression>();
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.BuiltInFunctionTableReference ToMutableConcrete() {
            var ret = new ScriptDom.BuiltInFunctionTableReference();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Parameters.AddRange(parameters.Select(c => (ScriptDom.ScalarExpression)c?.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias?.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + parameters.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BuiltInFunctionTableReference);
        } 
        
        public bool Equals(BuiltInFunctionTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Parameters, parameters)) {
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
        
        public static bool operator ==(BuiltInFunctionTableReference left, BuiltInFunctionTableReference right) {
            return EqualityComparer<BuiltInFunctionTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BuiltInFunctionTableReference left, BuiltInFunctionTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BuiltInFunctionTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (BuiltInFunctionTableReference left, BuiltInFunctionTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BuiltInFunctionTableReference left, BuiltInFunctionTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BuiltInFunctionTableReference left, BuiltInFunctionTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BuiltInFunctionTableReference left, BuiltInFunctionTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static BuiltInFunctionTableReference FromMutable(ScriptDom.BuiltInFunctionTableReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.BuiltInFunctionTableReference)) { throw new NotImplementedException("Unexpected subtype of BuiltInFunctionTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BuiltInFunctionTableReference(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                parameters: fragment.Parameters.ToImmArray(ImmutableDom.ScalarExpression.FromMutable),
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
