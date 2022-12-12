using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseRemoveFileStatement : AlterDatabaseStatement, IEquatable<AlterDatabaseRemoveFileStatement> {
        protected Identifier file;
    
        public Identifier File => file;
    
        public AlterDatabaseRemoveFileStatement(Identifier file = null, Identifier databaseName = null, bool useCurrent = false) {
            this.file = file;
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabaseRemoveFileStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseRemoveFileStatement();
            ret.File = (ScriptDom.Identifier)file.ToMutable();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName.ToMutable();
            ret.UseCurrent = useCurrent;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(file is null)) {
                h = h * 23 + file.GetHashCode();
            }
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + useCurrent.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseRemoveFileStatement);
        } 
        
        public bool Equals(AlterDatabaseRemoveFileStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.File, file)) {
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
        
        public static bool operator ==(AlterDatabaseRemoveFileStatement left, AlterDatabaseRemoveFileStatement right) {
            return EqualityComparer<AlterDatabaseRemoveFileStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseRemoveFileStatement left, AlterDatabaseRemoveFileStatement right) {
            return !(left == right);
        }
    
    }

}
