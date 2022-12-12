using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ReconfigureStatement : TSqlStatement, IEquatable<ReconfigureStatement> {
        bool withOverride = false;
    
        public bool WithOverride => withOverride;
    
        public ReconfigureStatement(bool withOverride = false) {
            this.withOverride = withOverride;
        }
    
        public ScriptDom.ReconfigureStatement ToMutableConcrete() {
            var ret = new ScriptDom.ReconfigureStatement();
            ret.WithOverride = withOverride;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + withOverride.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ReconfigureStatement);
        } 
        
        public bool Equals(ReconfigureStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.WithOverride, withOverride)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ReconfigureStatement left, ReconfigureStatement right) {
            return EqualityComparer<ReconfigureStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ReconfigureStatement left, ReconfigureStatement right) {
            return !(left == right);
        }
    
    }

}
