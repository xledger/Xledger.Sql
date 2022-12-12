using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseModifyNameStatement : AlterDatabaseStatement, IEquatable<AlterDatabaseModifyNameStatement> {
        Identifier newDatabaseName;
    
        public Identifier NewDatabaseName => newDatabaseName;
    
        public AlterDatabaseModifyNameStatement(Identifier newDatabaseName = null, Identifier databaseName = null, bool useCurrent = false) {
            this.newDatabaseName = newDatabaseName;
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabaseModifyNameStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseModifyNameStatement();
            ret.NewDatabaseName = (ScriptDom.Identifier)newDatabaseName.ToMutable();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName.ToMutable();
            ret.UseCurrent = useCurrent;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(newDatabaseName is null)) {
                h = h * 23 + newDatabaseName.GetHashCode();
            }
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + useCurrent.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseModifyNameStatement);
        } 
        
        public bool Equals(AlterDatabaseModifyNameStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.NewDatabaseName, newDatabaseName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DatabaseName, databaseName)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.UseCurrent, useCurrent)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterDatabaseModifyNameStatement left, AlterDatabaseModifyNameStatement right) {
            return EqualityComparer<AlterDatabaseModifyNameStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseModifyNameStatement left, AlterDatabaseModifyNameStatement right) {
            return !(left == right);
        }
    
    }

}
