using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TableNonClusteredIndexType : TableIndexType, IEquatable<TableNonClusteredIndexType> {
        public TableNonClusteredIndexType() {

        }
    
        public ScriptDom.TableNonClusteredIndexType ToMutableConcrete() {
            var ret = new ScriptDom.TableNonClusteredIndexType();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TableNonClusteredIndexType);
        } 
        
        public bool Equals(TableNonClusteredIndexType other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(TableNonClusteredIndexType left, TableNonClusteredIndexType right) {
            return EqualityComparer<TableNonClusteredIndexType>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TableNonClusteredIndexType left, TableNonClusteredIndexType right) {
            return !(left == right);
        }
    
        public static TableNonClusteredIndexType FromMutable(ScriptDom.TableNonClusteredIndexType fragment) {
            return (TableNonClusteredIndexType)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
