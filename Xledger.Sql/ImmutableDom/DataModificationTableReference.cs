using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DataModificationTableReference : TableReferenceWithAliasAndColumns, IEquatable<DataModificationTableReference> {
        protected DataModificationSpecification dataModificationSpecification;
    
        public DataModificationSpecification DataModificationSpecification => dataModificationSpecification;
    
        public DataModificationTableReference(DataModificationSpecification dataModificationSpecification = null, IReadOnlyList<Identifier> columns = null, Identifier alias = null, bool forPath = false) {
            this.dataModificationSpecification = dataModificationSpecification;
            this.columns = columns is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(columns);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.DataModificationTableReference ToMutableConcrete() {
            var ret = new ScriptDom.DataModificationTableReference();
            ret.DataModificationSpecification = (ScriptDom.DataModificationSpecification)dataModificationSpecification.ToMutable();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(dataModificationSpecification is null)) {
                h = h * 23 + dataModificationSpecification.GetHashCode();
            }
            h = h * 23 + columns.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DataModificationTableReference);
        } 
        
        public bool Equals(DataModificationTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DataModificationSpecification>.Default.Equals(other.DataModificationSpecification, dataModificationSpecification)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
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
        
        public static bool operator ==(DataModificationTableReference left, DataModificationTableReference right) {
            return EqualityComparer<DataModificationTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DataModificationTableReference left, DataModificationTableReference right) {
            return !(left == right);
        }
    
        public static DataModificationTableReference FromMutable(ScriptDom.DataModificationTableReference fragment) {
            return (DataModificationTableReference)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
