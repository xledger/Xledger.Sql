using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class NamedTableReference : TableReferenceWithAlias, IEquatable<NamedTableReference> {
        SchemaObjectName schemaObject;
        IReadOnlyList<TableHint> tableHints;
        TableSampleClause tableSampleClause;
        TemporalClause temporalClause;
    
        public SchemaObjectName SchemaObject => schemaObject;
        public IReadOnlyList<TableHint> TableHints => tableHints;
        public TableSampleClause TableSampleClause => tableSampleClause;
        public TemporalClause TemporalClause => temporalClause;
    
        public NamedTableReference(SchemaObjectName schemaObject = null, IReadOnlyList<TableHint> tableHints = null, TableSampleClause tableSampleClause = null, TemporalClause temporalClause = null, Identifier alias = null, bool forPath = false) {
            this.schemaObject = schemaObject;
            this.tableHints = tableHints is null ? ImmList<TableHint>.Empty : ImmList<TableHint>.FromList(tableHints);
            this.tableSampleClause = tableSampleClause;
            this.temporalClause = temporalClause;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.NamedTableReference ToMutableConcrete() {
            var ret = new ScriptDom.NamedTableReference();
            ret.SchemaObject = (ScriptDom.SchemaObjectName)schemaObject.ToMutable();
            ret.TableHints.AddRange(tableHints.Select(c => (ScriptDom.TableHint)c.ToMutable()));
            ret.TableSampleClause = (ScriptDom.TableSampleClause)tableSampleClause.ToMutable();
            ret.TemporalClause = (ScriptDom.TemporalClause)temporalClause.ToMutable();
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
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
            h = h * 23 + tableHints.GetHashCode();
            if (!(tableSampleClause is null)) {
                h = h * 23 + tableSampleClause.GetHashCode();
            }
            if (!(temporalClause is null)) {
                h = h * 23 + temporalClause.GetHashCode();
            }
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as NamedTableReference);
        } 
        
        public bool Equals(NamedTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObject, schemaObject)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<TableHint>>.Default.Equals(other.TableHints, tableHints)) {
                return false;
            }
            if (!EqualityComparer<TableSampleClause>.Default.Equals(other.TableSampleClause, tableSampleClause)) {
                return false;
            }
            if (!EqualityComparer<TemporalClause>.Default.Equals(other.TemporalClause, temporalClause)) {
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
        
        public static bool operator ==(NamedTableReference left, NamedTableReference right) {
            return EqualityComparer<NamedTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(NamedTableReference left, NamedTableReference right) {
            return !(left == right);
        }
    
    }

}