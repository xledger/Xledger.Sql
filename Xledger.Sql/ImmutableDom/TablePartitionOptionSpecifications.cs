using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TablePartitionOptionSpecifications : PartitionSpecifications, IEquatable<TablePartitionOptionSpecifications> {
        ScriptDom.PartitionTableOptionRange range = ScriptDom.PartitionTableOptionRange.NotSpecified;
        IReadOnlyList<ScalarExpression> boundaryValues;
    
        public ScriptDom.PartitionTableOptionRange Range => range;
        public IReadOnlyList<ScalarExpression> BoundaryValues => boundaryValues;
    
        public TablePartitionOptionSpecifications(ScriptDom.PartitionTableOptionRange range = ScriptDom.PartitionTableOptionRange.NotSpecified, IReadOnlyList<ScalarExpression> boundaryValues = null) {
            this.range = range;
            this.boundaryValues = boundaryValues is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(boundaryValues);
        }
    
        public ScriptDom.TablePartitionOptionSpecifications ToMutableConcrete() {
            var ret = new ScriptDom.TablePartitionOptionSpecifications();
            ret.Range = range;
            ret.BoundaryValues.AddRange(boundaryValues.Select(c => (ScriptDom.ScalarExpression)c.ToMutable()));
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
    
    }

}
