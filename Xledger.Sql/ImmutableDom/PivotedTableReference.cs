using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PivotedTableReference : TableReferenceWithAlias, IEquatable<PivotedTableReference> {
        protected TableReference tableReference;
        protected IReadOnlyList<Identifier> inColumns;
        protected ColumnReferenceExpression pivotColumn;
        protected IReadOnlyList<ColumnReferenceExpression> valueColumns;
        protected MultiPartIdentifier aggregateFunctionIdentifier;
    
        public TableReference TableReference => tableReference;
        public IReadOnlyList<Identifier> InColumns => inColumns;
        public ColumnReferenceExpression PivotColumn => pivotColumn;
        public IReadOnlyList<ColumnReferenceExpression> ValueColumns => valueColumns;
        public MultiPartIdentifier AggregateFunctionIdentifier => aggregateFunctionIdentifier;
    
        public PivotedTableReference(TableReference tableReference = null, IReadOnlyList<Identifier> inColumns = null, ColumnReferenceExpression pivotColumn = null, IReadOnlyList<ColumnReferenceExpression> valueColumns = null, MultiPartIdentifier aggregateFunctionIdentifier = null, Identifier alias = null, bool forPath = false) {
            this.tableReference = tableReference;
            this.inColumns = inColumns is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(inColumns);
            this.pivotColumn = pivotColumn;
            this.valueColumns = valueColumns is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(valueColumns);
            this.aggregateFunctionIdentifier = aggregateFunctionIdentifier;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.PivotedTableReference ToMutableConcrete() {
            var ret = new ScriptDom.PivotedTableReference();
            ret.TableReference = (ScriptDom.TableReference)tableReference.ToMutable();
            ret.InColumns.AddRange(inColumns.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.PivotColumn = (ScriptDom.ColumnReferenceExpression)pivotColumn.ToMutable();
            ret.ValueColumns.AddRange(valueColumns.SelectList(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            ret.AggregateFunctionIdentifier = (ScriptDom.MultiPartIdentifier)aggregateFunctionIdentifier.ToMutable();
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(tableReference is null)) {
                h = h * 23 + tableReference.GetHashCode();
            }
            h = h * 23 + inColumns.GetHashCode();
            if (!(pivotColumn is null)) {
                h = h * 23 + pivotColumn.GetHashCode();
            }
            h = h * 23 + valueColumns.GetHashCode();
            if (!(aggregateFunctionIdentifier is null)) {
                h = h * 23 + aggregateFunctionIdentifier.GetHashCode();
            }
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PivotedTableReference);
        } 
        
        public bool Equals(PivotedTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<TableReference>.Default.Equals(other.TableReference, tableReference)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.InColumns, inColumns)) {
                return false;
            }
            if (!EqualityComparer<ColumnReferenceExpression>.Default.Equals(other.PivotColumn, pivotColumn)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.ValueColumns, valueColumns)) {
                return false;
            }
            if (!EqualityComparer<MultiPartIdentifier>.Default.Equals(other.AggregateFunctionIdentifier, aggregateFunctionIdentifier)) {
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
        
        public static bool operator ==(PivotedTableReference left, PivotedTableReference right) {
            return EqualityComparer<PivotedTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PivotedTableReference left, PivotedTableReference right) {
            return !(left == right);
        }
    
    }

}
