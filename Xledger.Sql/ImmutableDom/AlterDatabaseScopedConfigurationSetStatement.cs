using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseScopedConfigurationSetStatement : AlterDatabaseScopedConfigurationStatement, IEquatable<AlterDatabaseScopedConfigurationSetStatement> {
        protected DatabaseConfigurationSetOption option;
    
        public DatabaseConfigurationSetOption Option => option;
    
        public AlterDatabaseScopedConfigurationSetStatement(DatabaseConfigurationSetOption option = null, bool secondary = false) {
            this.option = option;
            this.secondary = secondary;
        }
    
        public ScriptDom.AlterDatabaseScopedConfigurationSetStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseScopedConfigurationSetStatement();
            ret.Option = (ScriptDom.DatabaseConfigurationSetOption)option?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterDatabaseScopedConfigurationSetStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.option, othr.option);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.secondary, othr.secondary);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterDatabaseScopedConfigurationSetStatement left, AlterDatabaseScopedConfigurationSetStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterDatabaseScopedConfigurationSetStatement left, AlterDatabaseScopedConfigurationSetStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterDatabaseScopedConfigurationSetStatement left, AlterDatabaseScopedConfigurationSetStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterDatabaseScopedConfigurationSetStatement left, AlterDatabaseScopedConfigurationSetStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
