using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TableHashDistributionPolicy : TableDistributionPolicy, IEquatable<TableHashDistributionPolicy> {
        protected Identifier distributionColumn;
        protected IReadOnlyList<Identifier> distributionColumns;
    
        public Identifier DistributionColumn => distributionColumn;
        public IReadOnlyList<Identifier> DistributionColumns => distributionColumns;
    
        public TableHashDistributionPolicy(Identifier distributionColumn = null, IReadOnlyList<Identifier> distributionColumns = null) {
            this.distributionColumn = distributionColumn;
            this.distributionColumns = ImmList<Identifier>.FromList(distributionColumns);
        }
    
        public ScriptDom.TableHashDistributionPolicy ToMutableConcrete() {
            var ret = new ScriptDom.TableHashDistributionPolicy();
            ret.DistributionColumn = (ScriptDom.Identifier)distributionColumn?.ToMutable();
            ret.DistributionColumns.AddRange(distributionColumns.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(distributionColumn is null)) {
                h = h * 23 + distributionColumn.GetHashCode();
            }
            h = h * 23 + distributionColumns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TableHashDistributionPolicy);
        } 
        
        public bool Equals(TableHashDistributionPolicy other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DistributionColumn, distributionColumn)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.DistributionColumns, distributionColumns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TableHashDistributionPolicy left, TableHashDistributionPolicy right) {
            return EqualityComparer<TableHashDistributionPolicy>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TableHashDistributionPolicy left, TableHashDistributionPolicy right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TableHashDistributionPolicy)that;
            compare = Comparer.DefaultInvariant.Compare(this.distributionColumn, othr.distributionColumn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.distributionColumns, othr.distributionColumns);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (TableHashDistributionPolicy left, TableHashDistributionPolicy right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TableHashDistributionPolicy left, TableHashDistributionPolicy right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TableHashDistributionPolicy left, TableHashDistributionPolicy right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TableHashDistributionPolicy left, TableHashDistributionPolicy right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TableHashDistributionPolicy FromMutable(ScriptDom.TableHashDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.TableHashDistributionPolicy)) { throw new NotImplementedException("Unexpected subtype of TableHashDistributionPolicy not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableHashDistributionPolicy(
                distributionColumn: ImmutableDom.Identifier.FromMutable(fragment.DistributionColumn),
                distributionColumns: fragment.DistributionColumns.SelectList(ImmutableDom.Identifier.FromMutable)
            );
        }
    
    }

}
