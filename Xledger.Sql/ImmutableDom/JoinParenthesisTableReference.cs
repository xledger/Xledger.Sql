using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class JoinParenthesisTableReference : TableReference, IEquatable<JoinParenthesisTableReference> {
        TableReference join;
    
        public TableReference Join => join;
    
        public JoinParenthesisTableReference(TableReference join = null) {
            this.join = join;
        }
    
        public ScriptDom.JoinParenthesisTableReference ToMutableConcrete() {
            var ret = new ScriptDom.JoinParenthesisTableReference();
            ret.Join = (ScriptDom.TableReference)join.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(join is null)) {
                h = h * 23 + join.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as JoinParenthesisTableReference);
        } 
        
        public bool Equals(JoinParenthesisTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<TableReference>.Default.Equals(other.Join, join)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(JoinParenthesisTableReference left, JoinParenthesisTableReference right) {
            return EqualityComparer<JoinParenthesisTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(JoinParenthesisTableReference left, JoinParenthesisTableReference right) {
            return !(left == right);
        }
    
    }

}
