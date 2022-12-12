using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UseStatement : TSqlStatement, IEquatable<UseStatement> {
        protected Identifier databaseName;
    
        public Identifier DatabaseName => databaseName;
    
        public UseStatement(Identifier databaseName = null) {
            this.databaseName = databaseName;
        }
    
        public ScriptDom.UseStatement ToMutableConcrete() {
            var ret = new ScriptDom.UseStatement();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UseStatement);
        } 
        
        public bool Equals(UseStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DatabaseName, databaseName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UseStatement left, UseStatement right) {
            return EqualityComparer<UseStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UseStatement left, UseStatement right) {
            return !(left == right);
        }
    
    }

}
