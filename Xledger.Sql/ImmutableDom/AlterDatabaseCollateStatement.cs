using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseCollateStatement : AlterDatabaseStatement, IEquatable<AlterDatabaseCollateStatement> {
        Identifier collation;
    
        public Identifier Collation => collation;
    
        public AlterDatabaseCollateStatement(Identifier collation = null, Identifier databaseName = null, bool useCurrent = false) {
            this.collation = collation;
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabaseCollateStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseCollateStatement();
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName.ToMutable();
            ret.UseCurrent = useCurrent;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + useCurrent.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseCollateStatement);
        } 
        
        public bool Equals(AlterDatabaseCollateStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
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
        
        public static bool operator ==(AlterDatabaseCollateStatement left, AlterDatabaseCollateStatement right) {
            return EqualityComparer<AlterDatabaseCollateStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseCollateStatement left, AlterDatabaseCollateStatement right) {
            return !(left == right);
        }
    
    }

}