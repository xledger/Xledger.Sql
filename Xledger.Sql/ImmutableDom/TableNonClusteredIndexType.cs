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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TableNonClusteredIndexType)that;
            return compare;
        } 
        
        public static bool operator < (TableNonClusteredIndexType left, TableNonClusteredIndexType right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TableNonClusteredIndexType left, TableNonClusteredIndexType right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TableNonClusteredIndexType left, TableNonClusteredIndexType right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TableNonClusteredIndexType left, TableNonClusteredIndexType right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TableNonClusteredIndexType FromMutable(ScriptDom.TableNonClusteredIndexType fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.TableNonClusteredIndexType)) { throw new NotImplementedException("Unexpected subtype of TableNonClusteredIndexType not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableNonClusteredIndexType(
                
            );
        }
    
    }

}
