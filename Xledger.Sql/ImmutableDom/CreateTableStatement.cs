using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateTableStatement : TSqlStatement, IEquatable<CreateTableStatement> {
        SchemaObjectName schemaObjectName;
        bool asEdge = false;
        bool asFileTable = false;
        bool asNode = false;
        TableDefinition definition;
        FileGroupOrPartitionScheme onFileGroupOrPartitionScheme;
        FederationScheme federationScheme;
        IdentifierOrValueExpression textImageOn;
        IReadOnlyList<TableOption> options;
        SelectStatement selectStatement;
        IReadOnlyList<Identifier> ctasColumns;
        IdentifierOrValueExpression fileStreamOn;
    
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
            this.options = options is null ? ImmList<TableOption>.Empty : ImmList<TableOption>.FromList(options);
            this.selectStatement = selectStatement;
            this.ctasColumns = ctasColumns is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(ctasColumns);
            this.fileStreamOn = fileStreamOn;
        }
    
        public ScriptDom.CreateTableStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateTableStatement();
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            ret.AsEdge = asEdge;
            ret.AsFileTable = asFileTable;
            ret.AsNode = asNode;
            ret.Definition = (ScriptDom.TableDefinition)definition.ToMutable();
            ret.OnFileGroupOrPartitionScheme = (ScriptDom.FileGroupOrPartitionScheme)onFileGroupOrPartitionScheme.ToMutable();
            ret.FederationScheme = (ScriptDom.FederationScheme)federationScheme.ToMutable();
            ret.TextImageOn = (ScriptDom.IdentifierOrValueExpression)textImageOn.ToMutable();
            ret.Options.AddRange(options.Select(c => (ScriptDom.TableOption)c.ToMutable()));
            ret.SelectStatement = (ScriptDom.SelectStatement)selectStatement.ToMutable();
            ret.CtasColumns.AddRange(ctasColumns.Select(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.FileStreamOn = (ScriptDom.IdentifierOrValueExpression)fileStreamOn.ToMutable();
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
    
    }

}