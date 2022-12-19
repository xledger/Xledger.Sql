using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TablePartitionOptionSpecifications : PartitionSpecifications, IEquatable<TablePartitionOptionSpecifications> {
        protected ScriptDom.PartitionTableOptionRange range = ScriptDom.PartitionTableOptionRange.NotSpecified;
        protected IReadOnlyList<ScalarExpression> boundaryValues;
    
        public ScriptDom.PartitionTableOptionRange Range => range;
        public IReadOnlyList<ScalarExpression> BoundaryValues => boundaryValues;
    
        public TablePartitionOptionSpecifications(ScriptDom.PartitionTableOptionRange range = ScriptDom.PartitionTableOptionRange.NotSpecified, IReadOnlyList<ScalarExpression> boundaryValues = null) {
            this.range = range;
            this.boundaryValues = ImmList<ScalarExpression>.FromList(boundaryValues);
        }
    
        public ScriptDom.TablePartitionOptionSpecifications ToMutableConcrete() {
            var ret = new ScriptDom.TablePartitionOptionSpecifications();
            ret.Range = range;
            ret.BoundaryValues.AddRange(boundaryValues.SelectList(c => (ScriptDom.ScalarExpression)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + range.GetHashCode();
            h = h * 23 + boundaryValues.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TablePartitionOptionSpecifications);
        } 
        
        public bool Equals(TablePartitionOptionSpecifications other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.PartitionTableOptionRange>.Default.Equals(other.Range, range)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.BoundaryValues, boundaryValues)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TablePartitionOptionSpecifications left, TablePartitionOptionSpecifications right) {
            return EqualityComparer<TablePartitionOptionSpecifications>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TablePartitionOptionSpecifications left, TablePartitionOptionSpecifications right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TablePartitionOptionSpecifications)that;
            compare = Comparer.DefaultInvariant.Compare(this.range, othr.range);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.boundaryValues, othr.boundaryValues);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (TablePartitionOptionSpecifications left, TablePartitionOptionSpecifications right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TablePartitionOptionSpecifications left, TablePartitionOptionSpecifications right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TablePartitionOptionSpecifications left, TablePartitionOptionSpecifications right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TablePartitionOptionSpecifications left, TablePartitionOptionSpecifications right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TablePartitionOptionSpecifications FromMutable(ScriptDom.TablePartitionOptionSpecifications fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.TablePartitionOptionSpecifications)) { throw new NotImplementedException("Unexpected subtype of TablePartitionOptionSpecifications not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TablePartitionOptionSpecifications(
                range: fragment.Range,
                boundaryValues: fragment.BoundaryValues.SelectList(ImmutableDom.ScalarExpression.FromMutable)
            );
        }
    
    }

}
