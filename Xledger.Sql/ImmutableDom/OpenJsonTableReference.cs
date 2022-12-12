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
            this.schemaDeclarationItems = schemaDeclarationItems is null ? ImmList<SchemaDeclarationItemOpenjson>.Empty : ImmList<SchemaDeclarationItemOpenjson>.FromList(schemaDeclarationItems);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.OpenJsonTableReference ToMutableConcrete() {
            var ret = new ScriptDom.OpenJsonTableReference();
            ret.Variable = (ScriptDom.ScalarExpression)variable.ToMutable();
            ret.RowPattern = (ScriptDom.ScalarExpression)rowPattern.ToMutable();
            ret.SchemaDeclarationItems.AddRange(schemaDeclarationItems.SelectList(c => (ScriptDom.SchemaDeclarationItemOpenjson)c.ToMutable()));
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
    
    }

}
