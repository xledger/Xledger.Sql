using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OdbcQualifiedJoinTableReference : TableReference, IEquatable<OdbcQualifiedJoinTableReference> {
        protected TableReference tableReference;
    
        public TableReference TableReference => tableReference;
    
        public OdbcQualifiedJoinTableReference(TableReference tableReference = null) {
            this.tableReference = tableReference;
        }
    
        public ScriptDom.OdbcQualifiedJoinTableReference ToMutableConcrete() {
            var ret = new ScriptDom.OdbcQualifiedJoinTableReference();
            ret.TableReference = (ScriptDom.TableReference)tableReference.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(tableReference is null)) {
                h = h * 23 + tableReference.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OdbcQualifiedJoinTableReference);
        } 
        
        public bool Equals(OdbcQualifiedJoinTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<TableReference>.Default.Equals(other.TableReference, tableReference)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OdbcQualifiedJoinTableReference left, OdbcQualifiedJoinTableReference right) {
            return EqualityComparer<OdbcQualifiedJoinTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OdbcQualifiedJoinTableReference left, OdbcQualifiedJoinTableReference right) {
            return !(left == right);
        }
    
        public static OdbcQualifiedJoinTableReference FromMutable(ScriptDom.OdbcQualifiedJoinTableReference fragment) {
            return (OdbcQualifiedJoinTableReference)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
