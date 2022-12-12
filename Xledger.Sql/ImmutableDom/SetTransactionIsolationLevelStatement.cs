using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetTransactionIsolationLevelStatement : TSqlStatement, IEquatable<SetTransactionIsolationLevelStatement> {
        ScriptDom.IsolationLevel level = ScriptDom.IsolationLevel.None;
    
        public ScriptDom.IsolationLevel Level => level;
    
        public SetTransactionIsolationLevelStatement(ScriptDom.IsolationLevel level = ScriptDom.IsolationLevel.None) {
            this.level = level;
        }
    
        public ScriptDom.SetTransactionIsolationLevelStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetTransactionIsolationLevelStatement();
            ret.Level = level;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + level.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetTransactionIsolationLevelStatement);
        } 
        
        public bool Equals(SetTransactionIsolationLevelStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.IsolationLevel>.Default.Equals(other.Level, level)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetTransactionIsolationLevelStatement left, SetTransactionIsolationLevelStatement right) {
            return EqualityComparer<SetTransactionIsolationLevelStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetTransactionIsolationLevelStatement left, SetTransactionIsolationLevelStatement right) {
            return !(left == right);
        }
    
    }

}