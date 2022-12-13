using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseScopedConfigurationClearStatement : AlterDatabaseScopedConfigurationStatement, IEquatable<AlterDatabaseScopedConfigurationClearStatement> {
        protected DatabaseConfigurationClearOption option;
    
        public DatabaseConfigurationClearOption Option => option;
    
        public AlterDatabaseScopedConfigurationClearStatement(DatabaseConfigurationClearOption option = null, bool secondary = false) {
            this.option = option;
            this.secondary = secondary;
        }
    
        public ScriptDom.AlterDatabaseScopedConfigurationClearStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseScopedConfigurationClearStatement();
            ret.Option = (ScriptDom.DatabaseConfigurationClearOption)option.ToMutable();
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
            return Equals(obj as AlterDatabaseScopedConfigurationClearStatement);
        } 
        
        public bool Equals(AlterDatabaseScopedConfigurationClearStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DatabaseConfigurationClearOption>.Default.Equals(other.Option, option)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.Secondary, secondary)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterDatabaseScopedConfigurationClearStatement left, AlterDatabaseScopedConfigurationClearStatement right) {
            return EqualityComparer<AlterDatabaseScopedConfigurationClearStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseScopedConfigurationClearStatement left, AlterDatabaseScopedConfigurationClearStatement right) {
            return !(left == right);
        }
    
        public static AlterDatabaseScopedConfigurationClearStatement FromMutable(ScriptDom.AlterDatabaseScopedConfigurationClearStatement fragment) {
            return (AlterDatabaseScopedConfigurationClearStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
