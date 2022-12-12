using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OutputIntoClause : TSqlFragment, IEquatable<OutputIntoClause> {
        IReadOnlyList<SelectElement> selectColumns;
        TableReference intoTable;
        IReadOnlyList<ColumnReferenceExpression> intoTableColumns;
    
        public IReadOnlyList<SelectElement> SelectColumns => selectColumns;
        public TableReference IntoTable => intoTable;
        public IReadOnlyList<ColumnReferenceExpression> IntoTableColumns => intoTableColumns;
    
        public OutputIntoClause(IReadOnlyList<SelectElement> selectColumns = null, TableReference intoTable = null, IReadOnlyList<ColumnReferenceExpression> intoTableColumns = null) {
            this.selectColumns = selectColumns is null ? ImmList<SelectElement>.Empty : ImmList<SelectElement>.FromList(selectColumns);
            this.intoTable = intoTable;
            this.intoTableColumns = intoTableColumns is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(intoTableColumns);
        }
    
        public ScriptDom.OutputIntoClause ToMutableConcrete() {
            var ret = new ScriptDom.OutputIntoClause();
            ret.SelectColumns.AddRange(selectColumns.Select(c => (ScriptDom.SelectElement)c.ToMutable()));
            ret.IntoTable = (ScriptDom.TableReference)intoTable.ToMutable();
            ret.IntoTableColumns.AddRange(intoTableColumns.Select(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + selectColumns.GetHashCode();
            if (!(intoTable is null)) {
                h = h * 23 + intoTable.GetHashCode();
            }
            h = h * 23 + intoTableColumns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OutputIntoClause);
        } 
        
        public bool Equals(OutputIntoClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<SelectElement>>.Default.Equals(other.SelectColumns, selectColumns)) {
                return false;
            }
            if (!EqualityComparer<TableReference>.Default.Equals(other.IntoTable, intoTable)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.IntoTableColumns, intoTableColumns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OutputIntoClause left, OutputIntoClause right) {
            return EqualityComparer<OutputIntoClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OutputIntoClause left, OutputIntoClause right) {
            return !(left == right);
        }
    
    }

}