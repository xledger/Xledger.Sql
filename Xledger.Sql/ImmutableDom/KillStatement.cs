using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class KillStatement : TSqlStatement, IEquatable<KillStatement> {
        ScalarExpression parameter;
        bool withStatusOnly = false;
    
        public ScalarExpression Parameter => parameter;
        public bool WithStatusOnly => withStatusOnly;
    
        public KillStatement(ScalarExpression parameter = null, bool withStatusOnly = false) {
            this.parameter = parameter;
            this.withStatusOnly = withStatusOnly;
        }
    
        public ScriptDom.KillStatement ToMutableConcrete() {
            var ret = new ScriptDom.KillStatement();
            ret.Parameter = (ScriptDom.ScalarExpression)parameter.ToMutable();
            ret.WithStatusOnly = withStatusOnly;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(parameter is null)) {
                h = h * 23 + parameter.GetHashCode();
            }
            h = h * 23 + withStatusOnly.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as KillStatement);
        } 
        
        public bool Equals(KillStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Parameter, parameter)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithStatusOnly, withStatusOnly)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(KillStatement left, KillStatement right) {
            return EqualityComparer<KillStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(KillStatement left, KillStatement right) {
            return !(left == right);
        }
    
    }

}