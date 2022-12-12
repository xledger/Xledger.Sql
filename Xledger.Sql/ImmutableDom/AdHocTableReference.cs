using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AdHocTableReference : TableReferenceWithAlias, IEquatable<AdHocTableReference> {
        protected AdHocDataSource dataSource;
        protected SchemaObjectNameOrValueExpression @object;
    
        public AdHocDataSource DataSource => dataSource;
        public SchemaObjectNameOrValueExpression Object => @object;
    
        public AdHocTableReference(AdHocDataSource dataSource = null, SchemaObjectNameOrValueExpression @object = null, Identifier alias = null, bool forPath = false) {
            this.dataSource = dataSource;
            this.@object = @object;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.AdHocTableReference ToMutableConcrete() {
            var ret = new ScriptDom.AdHocTableReference();
            ret.DataSource = (ScriptDom.AdHocDataSource)dataSource.ToMutable();
            ret.Object = (ScriptDom.SchemaObjectNameOrValueExpression)@object.ToMutable();
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(dataSource is null)) {
                h = h * 23 + dataSource.GetHashCode();
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
            return Equals(obj as AdHocTableReference);
        } 
        
        public bool Equals(AdHocTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<AdHocDataSource>.Default.Equals(other.DataSource, dataSource)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectNameOrValueExpression>.Default.Equals(other.Object, @object)) {
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
        
        public static bool operator ==(AdHocTableReference left, AdHocTableReference right) {
            return EqualityComparer<AdHocTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AdHocTableReference left, AdHocTableReference right) {
            return !(left == right);
        }
    
    }

}
