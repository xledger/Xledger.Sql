using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UnpivotedTableReference : TableReferenceWithAlias, IEquatable<UnpivotedTableReference> {
        protected TableReference tableReference;
        protected IReadOnlyList<ColumnReferenceExpression> inColumns;
        protected Identifier pivotColumn;
        protected Identifier valueColumn;
    
        public TableReference TableReference => tableReference;
        public IReadOnlyList<ColumnReferenceExpression> InColumns => inColumns;
        public Identifier PivotColumn => pivotColumn;
        public Identifier ValueColumn => valueColumn;
    
        public UnpivotedTableReference(TableReference tableReference = null, IReadOnlyList<ColumnReferenceExpression> inColumns = null, Identifier pivotColumn = null, Identifier valueColumn = null, Identifier alias = null, bool forPath = false) {
            this.tableReference = tableReference;
            this.inColumns = inColumns.ToImmArray<ColumnReferenceExpression>();
            this.pivotColumn = pivotColumn;
            this.valueColumn = valueColumn;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.UnpivotedTableReference ToMutableConcrete() {
            var ret = new ScriptDom.UnpivotedTableReference();
            ret.TableReference = (ScriptDom.TableReference)tableReference?.ToMutable();
            ret.InColumns.AddRange(inColumns.Select(c => (ScriptDom.ColumnReferenceExpression)c?.ToMutable()));
            ret.PivotColumn = (ScriptDom.Identifier)pivotColumn?.ToMutable();
            ret.ValueColumn = (ScriptDom.Identifier)valueColumn?.ToMutable();
            ret.Alias = (ScriptDom.Identifier)alias?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (UnpivotedTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.tableReference, othr.tableReference);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.inColumns, othr.inColumns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.pivotColumn, othr.pivotColumn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.valueColumn, othr.valueColumn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (UnpivotedTableReference left, UnpivotedTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(UnpivotedTableReference left, UnpivotedTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (UnpivotedTableReference left, UnpivotedTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(UnpivotedTableReference left, UnpivotedTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static UnpivotedTableReference FromMutable(ScriptDom.UnpivotedTableReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.UnpivotedTableReference)) { throw new NotImplementedException("Unexpected subtype of UnpivotedTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UnpivotedTableReference(
                tableReference: ImmutableDom.TableReference.FromMutable(fragment.TableReference),
                inColumns: fragment.InColumns.ToImmArray(ImmutableDom.ColumnReferenceExpression.FromMutable),
                pivotColumn: ImmutableDom.Identifier.FromMutable(fragment.PivotColumn),
                valueColumn: ImmutableDom.Identifier.FromMutable(fragment.ValueColumn),
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
