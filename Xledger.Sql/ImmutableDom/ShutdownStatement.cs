using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ShutdownStatement : TSqlStatement, IEquatable<ShutdownStatement> {
        protected bool withNoWait = false;
    
        public bool WithNoWait => withNoWait;
    
        public ShutdownStatement(bool withNoWait = false) {
            this.withNoWait = withNoWait;
        }
    
        public ScriptDom.ShutdownStatement ToMutableConcrete() {
            var ret = new ScriptDom.ShutdownStatement();
            ret.WithNoWait = withNoWait;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + withNoWait.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ShutdownStatement);
        } 
        
        public bool Equals(ShutdownStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.WithNoWait, withNoWait)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ShutdownStatement left, ShutdownStatement right) {
            return EqualityComparer<ShutdownStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ShutdownStatement left, ShutdownStatement right) {
            return !(left == right);
        }
    
        public static ShutdownStatement FromMutable(ScriptDom.ShutdownStatement fragment) {
            return (ShutdownStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
