using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateExternalTableStatement : ExternalTableStatement, IEquatable<CreateExternalTableStatement> {
        public CreateExternalTableStatement(SchemaObjectName schemaObjectName = null, IReadOnlyList<ExternalTableColumnDefinition> columnDefinitions = null, Identifier dataSource = null, IReadOnlyList<ExternalTableOption> externalTableOptions = null, SelectStatement selectStatement = null) {
            this.schemaObjectName = schemaObjectName;
            this.columnDefinitions = columnDefinitions is null ? ImmList<ExternalTableColumnDefinition>.Empty : ImmList<ExternalTableColumnDefinition>.FromList(columnDefinitions);
            this.dataSource = dataSource;
            this.externalTableOptions = externalTableOptions is null ? ImmList<ExternalTableOption>.Empty : ImmList<ExternalTableOption>.FromList(externalTableOptions);
            this.selectStatement = selectStatement;
        }
    
        public ScriptDom.CreateExternalTableStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateExternalTableStatement();
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            ret.ColumnDefinitions.AddRange(columnDefinitions.SelectList(c => (ScriptDom.ExternalTableColumnDefinition)c.ToMutable()));
            ret.DataSource = (ScriptDom.Identifier)dataSource.ToMutable();
            ret.ExternalTableOptions.AddRange(externalTableOptions.SelectList(c => (ScriptDom.ExternalTableOption)c.ToMutable()));
            ret.SelectStatement = (ScriptDom.SelectStatement)selectStatement.ToMutable();
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
            h = h * 23 + columnDefinitions.GetHashCode();
            if (!(dataSource is null)) {
                h = h * 23 + dataSource.GetHashCode();
            }
            h = h * 23 + externalTableOptions.GetHashCode();
            if (!(selectStatement is null)) {
                h = h * 23 + selectStatement.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateExternalTableStatement);
        } 
        
        public bool Equals(CreateExternalTableStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExternalTableColumnDefinition>>.Default.Equals(other.ColumnDefinitions, columnDefinitions)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DataSource, dataSource)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExternalTableOption>>.Default.Equals(other.ExternalTableOptions, externalTableOptions)) {
                return false;
            }
            if (!EqualityComparer<SelectStatement>.Default.Equals(other.SelectStatement, selectStatement)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateExternalTableStatement left, CreateExternalTableStatement right) {
            return EqualityComparer<CreateExternalTableStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateExternalTableStatement left, CreateExternalTableStatement right) {
            return !(left == right);
        }
    
        public static CreateExternalTableStatement FromMutable(ScriptDom.CreateExternalTableStatement fragment) {
            return (CreateExternalTableStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
