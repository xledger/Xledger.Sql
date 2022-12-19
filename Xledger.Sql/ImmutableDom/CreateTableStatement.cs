using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateTableStatement : TSqlStatement, IEquatable<CreateTableStatement> {
        protected SchemaObjectName schemaObjectName;
        protected bool asEdge = false;
        protected bool asFileTable = false;
        protected bool asNode = false;
        protected TableDefinition definition;
        protected FileGroupOrPartitionScheme onFileGroupOrPartitionScheme;
        protected FederationScheme federationScheme;
        protected IdentifierOrValueExpression textImageOn;
        protected IReadOnlyList<TableOption> options;
        protected SelectStatement selectStatement;
        protected IReadOnlyList<Identifier> ctasColumns;
        protected IdentifierOrValueExpression fileStreamOn;
    
        public SchemaObjectName SchemaObjectName => schemaObjectName;
        public bool AsEdge => asEdge;
        public bool AsFileTable => asFileTable;
        public bool AsNode => asNode;
        public TableDefinition Definition => definition;
        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme => onFileGroupOrPartitionScheme;
        public FederationScheme FederationScheme => federationScheme;
        public IdentifierOrValueExpression TextImageOn => textImageOn;
        public IReadOnlyList<TableOption> Options => options;
        public SelectStatement SelectStatement => selectStatement;
        public IReadOnlyList<Identifier> CtasColumns => ctasColumns;
        public IdentifierOrValueExpression FileStreamOn => fileStreamOn;
    
        public CreateTableStatement(SchemaObjectName schemaObjectName = null, bool asEdge = false, bool asFileTable = false, bool asNode = false, TableDefinition definition = null, FileGroupOrPartitionScheme onFileGroupOrPartitionScheme = null, FederationScheme federationScheme = null, IdentifierOrValueExpression textImageOn = null, IReadOnlyList<TableOption> options = null, SelectStatement selectStatement = null, IReadOnlyList<Identifier> ctasColumns = null, IdentifierOrValueExpression fileStreamOn = null) {
            this.schemaObjectName = schemaObjectName;
            this.asEdge = asEdge;
            this.asFileTable = asFileTable;
            this.asNode = asNode;
            this.definition = definition;
            this.onFileGroupOrPartitionScheme = onFileGroupOrPartitionScheme;
            this.federationScheme = federationScheme;
            this.textImageOn = textImageOn;
            this.options = ImmList<TableOption>.FromList(options);
            this.selectStatement = selectStatement;
            this.ctasColumns = ImmList<Identifier>.FromList(ctasColumns);
            this.fileStreamOn = fileStreamOn;
        }
    
        public ScriptDom.CreateTableStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateTableStatement();
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName?.ToMutable();
            ret.AsEdge = asEdge;
            ret.AsFileTable = asFileTable;
            ret.AsNode = asNode;
            ret.Definition = (ScriptDom.TableDefinition)definition?.ToMutable();
            ret.OnFileGroupOrPartitionScheme = (ScriptDom.FileGroupOrPartitionScheme)onFileGroupOrPartitionScheme?.ToMutable();
            ret.FederationScheme = (ScriptDom.FederationScheme)federationScheme?.ToMutable();
            ret.TextImageOn = (ScriptDom.IdentifierOrValueExpression)textImageOn?.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.TableOption)c?.ToMutable()));
            ret.SelectStatement = (ScriptDom.SelectStatement)selectStatement?.ToMutable();
            ret.CtasColumns.AddRange(ctasColumns.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.FileStreamOn = (ScriptDom.IdentifierOrValueExpression)fileStreamOn?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            h = h * 23 + asEdge.GetHashCode();
            h = h * 23 + asFileTable.GetHashCode();
            h = h * 23 + asNode.GetHashCode();
            if (!(definition is null)) {
                h = h * 23 + definition.GetHashCode();
            }
            if (!(onFileGroupOrPartitionScheme is null)) {
                h = h * 23 + onFileGroupOrPartitionScheme.GetHashCode();
            }
            if (!(federationScheme is null)) {
                h = h * 23 + federationScheme.GetHashCode();
            }
            if (!(textImageOn is null)) {
                h = h * 23 + textImageOn.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            if (!(selectStatement is null)) {
                h = h * 23 + selectStatement.GetHashCode();
            }
            h = h * 23 + ctasColumns.GetHashCode();
            if (!(fileStreamOn is null)) {
                h = h * 23 + fileStreamOn.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateTableStatement);
        } 
        
        public bool Equals(CreateTableStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.AsEdge, asEdge)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.AsFileTable, asFileTable)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.AsNode, asNode)) {
                return false;
            }
            if (!EqualityComparer<TableDefinition>.Default.Equals(other.Definition, definition)) {
                return false;
            }
            if (!EqualityComparer<FileGroupOrPartitionScheme>.Default.Equals(other.OnFileGroupOrPartitionScheme, onFileGroupOrPartitionScheme)) {
                return false;
            }
            if (!EqualityComparer<FederationScheme>.Default.Equals(other.FederationScheme, federationScheme)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.TextImageOn, textImageOn)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<TableOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<SelectStatement>.Default.Equals(other.SelectStatement, selectStatement)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.CtasColumns, ctasColumns)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.FileStreamOn, fileStreamOn)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateTableStatement left, CreateTableStatement right) {
            return EqualityComparer<CreateTableStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateTableStatement left, CreateTableStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateTableStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.asEdge, othr.asEdge);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.asFileTable, othr.asFileTable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.asNode, othr.asNode);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.definition, othr.definition);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.onFileGroupOrPartitionScheme, othr.onFileGroupOrPartitionScheme);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.federationScheme, othr.federationScheme);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.textImageOn, othr.textImageOn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.selectStatement, othr.selectStatement);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.ctasColumns, othr.ctasColumns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fileStreamOn, othr.fileStreamOn);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateTableStatement left, CreateTableStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateTableStatement left, CreateTableStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateTableStatement left, CreateTableStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateTableStatement left, CreateTableStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateTableStatement FromMutable(ScriptDom.CreateTableStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateTableStatement)) { throw new NotImplementedException("Unexpected subtype of CreateTableStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateTableStatement(
                schemaObjectName: ImmutableDom.SchemaObjectName.FromMutable(fragment.SchemaObjectName),
                asEdge: fragment.AsEdge,
                asFileTable: fragment.AsFileTable,
                asNode: fragment.AsNode,
                definition: ImmutableDom.TableDefinition.FromMutable(fragment.Definition),
                onFileGroupOrPartitionScheme: ImmutableDom.FileGroupOrPartitionScheme.FromMutable(fragment.OnFileGroupOrPartitionScheme),
                federationScheme: ImmutableDom.FederationScheme.FromMutable(fragment.FederationScheme),
                textImageOn: ImmutableDom.IdentifierOrValueExpression.FromMutable(fragment.TextImageOn),
                options: fragment.Options.SelectList(ImmutableDom.TableOption.FromMutable),
                selectStatement: ImmutableDom.SelectStatement.FromMutable(fragment.SelectStatement),
                ctasColumns: fragment.CtasColumns.SelectList(ImmutableDom.Identifier.FromMutable),
                fileStreamOn: ImmutableDom.IdentifierOrValueExpression.FromMutable(fragment.FileStreamOn)
            );
        }
    
    }

}
