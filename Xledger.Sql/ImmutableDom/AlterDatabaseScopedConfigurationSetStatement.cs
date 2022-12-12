using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseScopedConfigurationSetStatement : AlterDatabaseScopedConfigurationStatement, IEquatable<AlterDatabaseScopedConfigurationSetStatement> {
        DatabaseConfigurationSetOption option;
    
        public DatabaseConfigurationSetOption Option => option;
    
        public AlterDatabaseScopedConfigurationSetStatement(DatabaseConfigurationSetOption option = null, bool secondary = false) {
            this.option = option;
            this.secondary = secondary;
        }
    
        public ScriptDom.AlterDatabaseScopedConfigurationSetStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseScopedConfigurationSetStatement();
            ret.Option = (ScriptDom.DatabaseConfigurationSetOption)option.ToMutable();
            ret.Secondary = secondary;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(option is null)) {
                h = h * 23 + option.GetHashCode();
            }
            h = h * 23 + secondary.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseScopedConfigurationSetStatement);
        } 
        
        public bool Equals(AlterDatabaseScopedConfigurationSetStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DatabaseConfigurationSetOption>.Default.Equals(other.Option, option)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.Secondary, secondary)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterDatabaseScopedConfigurationSetStatement left, AlterDatabaseScopedConfigurationSetStatement right) {
            return EqualityComparer<AlterDatabaseScopedConfigurationSetStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseScopedConfigurationSetStatement left, AlterDatabaseScopedConfigurationSetStatement right) {
            return !(left == right);
        }
    
    }

}
