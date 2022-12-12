using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OpenRowsetTableReference : TableReferenceWithAlias, IEquatable<OpenRowsetTableReference> {
        StringLiteral providerName;
        StringLiteral dataSource;
        StringLiteral userId;
        StringLiteral password;
        StringLiteral providerString;
        StringLiteral query;
        SchemaObjectName @object;
    
        public StringLiteral ProviderName => providerName;
        public StringLiteral DataSource => dataSource;
        public StringLiteral UserId => userId;
        public StringLiteral Password => password;
        public StringLiteral ProviderString => providerString;
        public StringLiteral Query => query;
        public SchemaObjectName Object => @object;
    
        public OpenRowsetTableReference(StringLiteral providerName = null, StringLiteral dataSource = null, StringLiteral userId = null, StringLiteral password = null, StringLiteral providerString = null, StringLiteral query = null, SchemaObjectName @object = null, Identifier alias = null, bool forPath = false) {
            this.providerName = providerName;
            this.dataSource = dataSource;
            this.userId = userId;
            this.password = password;
            this.providerString = providerString;
            this.query = query;
            this.@object = @object;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.OpenRowsetTableReference ToMutableConcrete() {
            var ret = new ScriptDom.OpenRowsetTableReference();
            ret.ProviderName = (ScriptDom.StringLiteral)providerName.ToMutable();
            ret.DataSource = (ScriptDom.StringLiteral)dataSource.ToMutable();
            ret.UserId = (ScriptDom.StringLiteral)userId.ToMutable();
            ret.Password = (ScriptDom.StringLiteral)password.ToMutable();
            ret.ProviderString = (ScriptDom.StringLiteral)providerString.ToMutable();
            ret.Query = (ScriptDom.StringLiteral)query.ToMutable();
            ret.Object = (ScriptDom.SchemaObjectName)@object.ToMutable();
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(providerName is null)) {
                h = h * 23 + providerName.GetHashCode();
            }
            if (!(dataSource is null)) {
                h = h * 23 + dataSource.GetHashCode();
            }
            if (!(userId is null)) {
                h = h * 23 + userId.GetHashCode();
            }
            if (!(password is null)) {
                h = h * 23 + password.GetHashCode();
            }
            if (!(providerString is null)) {
                h = h * 23 + providerString.GetHashCode();
            }
            if (!(query is null)) {
                h = h * 23 + query.GetHashCode();
            }
            if (!(@object is null)) {
                h = h * 23 + @object.GetHashCode();
            }
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OpenRowsetTableReference);
        } 
        
        public bool Equals(OpenRowsetTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.ProviderName, providerName)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.DataSource, dataSource)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.UserId, userId)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Password, password)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.ProviderString, providerString)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Query, query)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Object, @object)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Alias, alias)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForPath, forPath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OpenRowsetTableReference left, OpenRowsetTableReference right) {
            return EqualityComparer<OpenRowsetTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OpenRowsetTableReference left, OpenRowsetTableReference right) {
            return !(left == right);
        }
    
    }

}