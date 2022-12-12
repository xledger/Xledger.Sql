using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UnpivotedTableReference : TableReferenceWithAlias, IEquatable<UnpivotedTableReference> {
        TableReference tableReference;
        IReadOnlyList<ColumnReferenceExpression> inColumns;
        Identifier pivotColumn;
        Identifier valueColumn;
    
        public TableReference TableReference => tableReference;
        public IReadOnlyList<ColumnReferenceExpression> InColumns => inColumns;
        public Identifier PivotColumn => pivotColumn;
        public Identifier ValueColumn => valueColumn;
    
        public UnpivotedTableReference(TableReference tableReference = null, IReadOnlyList<ColumnReferenceExpression> inColumns = null, Identifier pivotColumn = null, Identifier valueColumn = null, Identifier alias = null, bool forPath = false) {
            this.tableReference = tableReference;
            this.inColumns = inColumns is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(inColumns);
            this.pivotColumn = pivotColumn;
            this.valueColumn = valueColumn;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.UnpivotedTableReference ToMutableConcrete() {
            var ret = new ScriptDom.UnpivotedTableReference();
            ret.TableReference = (ScriptDom.TableReference)tableReference.ToMutable();
            ret.InColumns.AddRange(inColumns.Select(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            ret.PivotColumn = (ScriptDom.Identifier)pivotColumn.ToMutable();
            ret.ValueColumn = (ScriptDom.Identifier)valueColumn.ToMutable();
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
            if (!(valueColumn is null)) {
                h = h * 23 + valueColumn.GetHashCode();
            }
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UnpivotedTableReference);
        } 
        
        public bool Equals(UnpivotedTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<TableReference>.Default.Equals(other.TableReference, tableReference)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.InColumns, inColumns)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.PivotColumn, pivotColumn)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ValueColumn, valueColumn)) {
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
        
        public static bool operator ==(UnpivotedTableReference left, UnpivotedTableReference right) {
            return EqualityComparer<UnpivotedTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UnpivotedTableReference left, UnpivotedTableReference right) {
            return !(left == right);
        }
    
    }

}
