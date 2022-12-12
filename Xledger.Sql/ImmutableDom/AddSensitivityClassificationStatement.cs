using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AddSensitivityClassificationStatement : SensitivityClassificationStatement, IEquatable<AddSensitivityClassificationStatement> {
        IReadOnlyList<SensitivityClassificationOption> options;
    
        public IReadOnlyList<SensitivityClassificationOption> Options => options;
    
        public AddSensitivityClassificationStatement(IReadOnlyList<SensitivityClassificationOption> options = null, IReadOnlyList<ColumnReferenceExpression> columns = null) {
            this.options = options is null ? ImmList<SensitivityClassificationOption>.Empty : ImmList<SensitivityClassificationOption>.FromList(options);
            this.columns = columns is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(columns);
        }
    
        public ScriptDom.AddSensitivityClassificationStatement ToMutableConcrete() {
            var ret = new ScriptDom.AddSensitivityClassificationStatement();
            ret.Options.AddRange(options.Select(c => (ScriptDom.SensitivityClassificationOption)c.ToMutable()));
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            h = h * 23 + columns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AddSensitivityClassificationStatement);
        } 
        
        public bool Equals(AddSensitivityClassificationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<SensitivityClassificationOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AddSensitivityClassificationStatement left, AddSensitivityClassificationStatement right) {
            return EqualityComparer<AddSensitivityClassificationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AddSensitivityClassificationStatement left, AddSensitivityClassificationStatement right) {
            return !(left == right);
        }
    
    }

}
