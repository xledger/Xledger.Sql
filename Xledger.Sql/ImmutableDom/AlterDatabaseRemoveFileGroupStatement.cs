using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseRemoveFileGroupStatement : AlterDatabaseStatement, IEquatable<AlterDatabaseRemoveFileGroupStatement> {
        Identifier fileGroup;
    
        public Identifier FileGroup => fileGroup;
    
        public AlterDatabaseRemoveFileGroupStatement(Identifier fileGroup = null, Identifier databaseName = null, bool useCurrent = false) {
            this.fileGroup = fileGroup;
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabaseRemoveFileGroupStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseRemoveFileGroupStatement();
            ret.FileGroup = (ScriptDom.Identifier)fileGroup.ToMutable();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName.ToMutable();
            ret.UseCurrent = useCurrent;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(fileGroup is null)) {
                h = h * 23 + fileGroup.GetHashCode();
            }
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + useCurrent.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseRemoveFileGroupStatement);
        } 
        
        public bool Equals(AlterDatabaseRemoveFileGroupStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.FileGroup, fileGroup)) {
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
        
        public static bool operator ==(AlterDatabaseRemoveFileGroupStatement left, AlterDatabaseRemoveFileGroupStatement right) {
            return EqualityComparer<AlterDatabaseRemoveFileGroupStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseRemoveFileGroupStatement left, AlterDatabaseRemoveFileGroupStatement right) {
            return !(left == right);
        }
    
    }

}