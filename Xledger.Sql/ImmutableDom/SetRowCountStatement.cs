using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetRowCountStatement : TSqlStatement, IEquatable<SetRowCountStatement> {
        ValueExpression numberRows;
    
        public ValueExpression NumberRows => numberRows;
    
        public SetRowCountStatement(ValueExpression numberRows = null) {
            this.numberRows = numberRows;
        }
    
        public ScriptDom.SetRowCountStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetRowCountStatement();
            ret.NumberRows = (ScriptDom.ValueExpression)numberRows.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(numberRows is null)) {
                h = h * 23 + numberRows.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetRowCountStatement);
        } 
        
        public bool Equals(SetRowCountStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.NumberRows, numberRows)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetRowCountStatement left, SetRowCountStatement right) {
            return EqualityComparer<SetRowCountStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetRowCountStatement left, SetRowCountStatement right) {
            return !(left == right);
        }
    
    }

}
