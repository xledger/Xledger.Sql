using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OpenJsonTableReference : TableReferenceWithAlias, IEquatable<OpenJsonTableReference> {
        protected ScalarExpression variable;
        protected ScalarExpression rowPattern;
        protected IReadOnlyList<SchemaDeclarationItemOpenjson> schemaDeclarationItems;
    
        public ScalarExpression Variable => variable;
        public ScalarExpression RowPattern => rowPattern;
        public IReadOnlyList<SchemaDeclarationItemOpenjson> SchemaDeclarationItems => schemaDeclarationItems;
    
        public OpenJsonTableReference(ScalarExpression variable = null, ScalarExpression rowPattern = null, IReadOnlyList<SchemaDeclarationItemOpenjson> schemaDeclarationItems = null, Identifier alias = null, bool forPath = false) {
            this.variable = variable;
            this.rowPattern = rowPattern;
            this.schemaDeclarationItems = ImmList<SchemaDeclarationItemOpenjson>.FromList(schemaDeclarationItems);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.OpenJsonTableReference ToMutableConcrete() {
            var ret = new ScriptDom.OpenJsonTableReference();
            ret.Variable = (ScriptDom.ScalarExpression)variable?.ToMutable();
            ret.RowPattern = (ScriptDom.ScalarExpression)rowPattern?.ToMutable();
            ret.SchemaDeclarationItems.AddRange(schemaDeclarationItems.SelectList(c => (ScriptDom.SchemaDeclarationItemOpenjson)c?.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias?.ToMutable();
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
            if (!(rowPattern is null)) {
                h = h * 23 + rowPattern.GetHashCode();
            }
            h = h * 23 + schemaDeclarationItems.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OpenJsonTableReference);
        } 
        
        public bool Equals(OpenJsonTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Variable, variable)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.RowPattern, rowPattern)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SchemaDeclarationItemOpenjson>>.Default.Equals(other.SchemaDeclarationItems, schemaDeclarationItems)) {
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
        
        public static bool operator ==(OpenJsonTableReference left, OpenJsonTableReference right) {
            return EqualityComparer<OpenJsonTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OpenJsonTableReference left, OpenJsonTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OpenJsonTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.variable, othr.variable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.rowPattern, othr.rowPattern);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.schemaDeclarationItems, othr.schemaDeclarationItems);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OpenJsonTableReference left, OpenJsonTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OpenJsonTableReference left, OpenJsonTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OpenJsonTableReference left, OpenJsonTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OpenJsonTableReference left, OpenJsonTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OpenJsonTableReference FromMutable(ScriptDom.OpenJsonTableReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OpenJsonTableReference)) { throw new NotImplementedException("Unexpected subtype of OpenJsonTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OpenJsonTableReference(
                variable: ImmutableDom.ScalarExpression.FromMutable(fragment.Variable),
                rowPattern: ImmutableDom.ScalarExpression.FromMutable(fragment.RowPattern),
                schemaDeclarationItems: fragment.SchemaDeclarationItems.SelectList(ImmutableDom.SchemaDeclarationItemOpenjson.FromMutable),
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
