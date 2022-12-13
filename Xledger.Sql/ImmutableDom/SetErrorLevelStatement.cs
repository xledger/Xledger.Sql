using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetErrorLevelStatement : TSqlStatement, IEquatable<SetErrorLevelStatement> {
        protected ScalarExpression level;
    
        public ScalarExpression Level => level;
    
        public SetErrorLevelStatement(ScalarExpression level = null) {
            this.level = level;
        }
    
        public ScriptDom.SetErrorLevelStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetErrorLevelStatement();
            ret.Level = (ScriptDom.ScalarExpression)level.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(level is null)) {
                h = h * 23 + level.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetErrorLevelStatement);
        } 
        
        public bool Equals(SetErrorLevelStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Level, level)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetErrorLevelStatement left, SetErrorLevelStatement right) {
            return EqualityComparer<SetErrorLevelStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetErrorLevelStatement left, SetErrorLevelStatement right) {
            return !(left == right);
        }
    
        public static SetErrorLevelStatement FromMutable(ScriptDom.SetErrorLevelStatement fragment) {
            return (SetErrorLevelStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
