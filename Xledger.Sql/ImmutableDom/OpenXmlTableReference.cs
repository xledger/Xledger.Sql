using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OpenXmlTableReference : TableReferenceWithAlias, IEquatable<OpenXmlTableReference> {
        protected VariableReference variable;
        protected ValueExpression rowPattern;
        protected ValueExpression flags;
        protected IReadOnlyList<SchemaDeclarationItem> schemaDeclarationItems;
        protected SchemaObjectName tableName;
    
        public VariableReference Variable => variable;
        public ValueExpression RowPattern => rowPattern;
        public ValueExpression Flags => flags;
        public IReadOnlyList<SchemaDeclarationItem> SchemaDeclarationItems => schemaDeclarationItems;
        public SchemaObjectName TableName => tableName;
    
        public OpenXmlTableReference(VariableReference variable = null, ValueExpression rowPattern = null, ValueExpression flags = null, IReadOnlyList<SchemaDeclarationItem> schemaDeclarationItems = null, SchemaObjectName tableName = null, Identifier alias = null, bool forPath = false) {
            this.variable = variable;
            this.rowPattern = rowPattern;
            this.flags = flags;
            this.schemaDeclarationItems = schemaDeclarationItems.ToImmArray<SchemaDeclarationItem>();
            this.tableName = tableName;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.OpenXmlTableReference ToMutableConcrete() {
            var ret = new ScriptDom.OpenXmlTableReference();
            ret.Variable = (ScriptDom.VariableReference)variable?.ToMutable();
            ret.RowPattern = (ScriptDom.ValueExpression)rowPattern?.ToMutable();
            ret.Flags = (ScriptDom.ValueExpression)flags?.ToMutable();
            ret.SchemaDeclarationItems.AddRange(schemaDeclarationItems.Select(c => (ScriptDom.SchemaDeclarationItem)c?.ToMutable()));
            ret.TableName = (ScriptDom.SchemaObjectName)tableName?.ToMutable();
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
            if (!(flags is null)) {
                h = h * 23 + flags.GetHashCode();
            }
            h = h * 23 + schemaDeclarationItems.GetHashCode();
            if (!(tableName is null)) {
                h = h * 23 + tableName.GetHashCode();
            }
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OpenXmlTableReference);
        } 
        
        public bool Equals(OpenXmlTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<VariableReference>.Default.Equals(other.Variable, variable)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.RowPattern, rowPattern)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.Flags, flags)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SchemaDeclarationItem>>.Default.Equals(other.SchemaDeclarationItems, schemaDeclarationItems)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.TableName, tableName)) {
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
        
        public static bool operator ==(OpenXmlTableReference left, OpenXmlTableReference right) {
            return EqualityComparer<OpenXmlTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OpenXmlTableReference left, OpenXmlTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OpenXmlTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.variable, othr.variable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.rowPattern, othr.rowPattern);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.flags, othr.flags);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.schemaDeclarationItems, othr.schemaDeclarationItems);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.tableName, othr.tableName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OpenXmlTableReference left, OpenXmlTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OpenXmlTableReference left, OpenXmlTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OpenXmlTableReference left, OpenXmlTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OpenXmlTableReference left, OpenXmlTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OpenXmlTableReference FromMutable(ScriptDom.OpenXmlTableReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OpenXmlTableReference)) { throw new NotImplementedException("Unexpected subtype of OpenXmlTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OpenXmlTableReference(
                variable: ImmutableDom.VariableReference.FromMutable(fragment.Variable),
                rowPattern: ImmutableDom.ValueExpression.FromMutable(fragment.RowPattern),
                flags: ImmutableDom.ValueExpression.FromMutable(fragment.Flags),
                schemaDeclarationItems: fragment.SchemaDeclarationItems.ToImmArray(ImmutableDom.SchemaDeclarationItem.FromMutable),
                tableName: ImmutableDom.SchemaObjectName.FromMutable(fragment.TableName),
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
