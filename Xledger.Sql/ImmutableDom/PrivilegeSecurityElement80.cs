using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PrivilegeSecurityElement80 : SecurityElement80, IEquatable<PrivilegeSecurityElement80> {
        protected IReadOnlyList<Privilege80> privileges;
        protected SchemaObjectName schemaObjectName;
        protected IReadOnlyList<Identifier> columns;
    
        public IReadOnlyList<Privilege80> Privileges => privileges;
        public SchemaObjectName SchemaObjectName => schemaObjectName;
        public IReadOnlyList<Identifier> Columns => columns;
    
        public PrivilegeSecurityElement80(IReadOnlyList<Privilege80> privileges = null, SchemaObjectName schemaObjectName = null, IReadOnlyList<Identifier> columns = null) {
            this.privileges = ImmList<Privilege80>.FromList(privileges);
            this.schemaObjectName = schemaObjectName;
            this.columns = ImmList<Identifier>.FromList(columns);
        }
    
        public ScriptDom.PrivilegeSecurityElement80 ToMutableConcrete() {
            var ret = new ScriptDom.PrivilegeSecurityElement80();
            ret.Privileges.AddRange(privileges.SelectList(c => (ScriptDom.Privilege80)c?.ToMutable()));
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName?.ToMutable();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + privileges.GetHashCode();
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            h = h * 23 + columns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PrivilegeSecurityElement80);
        } 
        
        public bool Equals(PrivilegeSecurityElement80 other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Privilege80>>.Default.Equals(other.Privileges, privileges)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PrivilegeSecurityElement80 left, PrivilegeSecurityElement80 right) {
            return EqualityComparer<PrivilegeSecurityElement80>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PrivilegeSecurityElement80 left, PrivilegeSecurityElement80 right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (PrivilegeSecurityElement80)that;
            compare = Comparer.DefaultInvariant.Compare(this.privileges, othr.privileges);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (PrivilegeSecurityElement80 left, PrivilegeSecurityElement80 right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(PrivilegeSecurityElement80 left, PrivilegeSecurityElement80 right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (PrivilegeSecurityElement80 left, PrivilegeSecurityElement80 right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(PrivilegeSecurityElement80 left, PrivilegeSecurityElement80 right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
