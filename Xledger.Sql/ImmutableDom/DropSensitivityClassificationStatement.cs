using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropSensitivityClassificationStatement : SensitivityClassificationStatement, IEquatable<DropSensitivityClassificationStatement> {
        public DropSensitivityClassificationStatement(IReadOnlyList<ColumnReferenceExpression> columns = null) {
            this.columns = columns is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(columns);
        }
    
        public ScriptDom.DropSensitivityClassificationStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropSensitivityClassificationStatement();
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropSensitivityClassificationStatement);
        } 
        
        public bool Equals(DropSensitivityClassificationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropSensitivityClassificationStatement left, DropSensitivityClassificationStatement right) {
            return EqualityComparer<DropSensitivityClassificationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropSensitivityClassificationStatement left, DropSensitivityClassificationStatement right) {
            return !(left == right);
        }
    
    }

}
