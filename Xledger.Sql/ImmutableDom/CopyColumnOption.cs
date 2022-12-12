using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CopyColumnOption : CopyStatementOptionBase, IEquatable<CopyColumnOption> {
        Identifier columnName;
        ScalarExpression defaultValue;
        IntegerLiteral fieldNumber;
    
        public Identifier ColumnName => columnName;
        public ScalarExpression DefaultValue => defaultValue;
        public IntegerLiteral FieldNumber => fieldNumber;
    
        public CopyColumnOption(Identifier columnName = null, ScalarExpression defaultValue = null, IntegerLiteral fieldNumber = null) {
            this.columnName = columnName;
            this.defaultValue = defaultValue;
            this.fieldNumber = fieldNumber;
        }
    
        public ScriptDom.CopyColumnOption ToMutableConcrete() {
            var ret = new ScriptDom.CopyColumnOption();
            ret.ColumnName = (ScriptDom.Identifier)columnName.ToMutable();
            ret.DefaultValue = (ScriptDom.ScalarExpression)defaultValue.ToMutable();
            ret.FieldNumber = (ScriptDom.IntegerLiteral)fieldNumber.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(columnName is null)) {
                h = h * 23 + columnName.GetHashCode();
            }
            if (!(defaultValue is null)) {
                h = h * 23 + defaultValue.GetHashCode();
            }
            if (!(fieldNumber is null)) {
                h = h * 23 + fieldNumber.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CopyColumnOption);
        } 
        
        public bool Equals(CopyColumnOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ColumnName, columnName)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.DefaultValue, defaultValue)) {
                return false;
            }
            if (!EqualityComparer<IntegerLiteral>.Default.Equals(other.FieldNumber, fieldNumber)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CopyColumnOption left, CopyColumnOption right) {
            return EqualityComparer<CopyColumnOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CopyColumnOption left, CopyColumnOption right) {
            return !(left == right);
        }
    
    }

}