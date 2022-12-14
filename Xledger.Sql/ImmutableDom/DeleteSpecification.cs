using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DeleteSpecification : UpdateDeleteSpecificationBase, IEquatable<DeleteSpecification> {
        public DeleteSpecification(FromClause fromClause = null, WhereClause whereClause = null, TableReference target = null, TopRowFilter topRowFilter = null, OutputIntoClause outputIntoClause = null, OutputClause outputClause = null) {
            this.fromClause = fromClause;
            this.whereClause = whereClause;
            this.target = target;
            this.topRowFilter = topRowFilter;
            this.outputIntoClause = outputIntoClause;
            this.outputClause = outputClause;
        }
    
        public ScriptDom.DeleteSpecification ToMutableConcrete() {
            var ret = new ScriptDom.DeleteSpecification();
            ret.FromClause = (ScriptDom.FromClause)fromClause.ToMutable();
            ret.WhereClause = (ScriptDom.WhereClause)whereClause.ToMutable();
            ret.Target = (ScriptDom.TableReference)target.ToMutable();
            ret.TopRowFilter = (ScriptDom.TopRowFilter)topRowFilter.ToMutable();
            ret.OutputIntoClause = (ScriptDom.OutputIntoClause)outputIntoClause.ToMutable();
            ret.OutputClause = (ScriptDom.OutputClause)outputClause.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(fromClause is null)) {
                h = h * 23 + fromClause.GetHashCode();
            }
            if (!(whereClause is null)) {
                h = h * 23 + whereClause.GetHashCode();
            }
            if (!(target is null)) {
                h = h * 23 + target.GetHashCode();
            }
            if (!(topRowFilter is null)) {
                h = h * 23 + topRowFilter.GetHashCode();
            }
            if (!(outputIntoClause is null)) {
                h = h * 23 + outputIntoClause.GetHashCode();
            }
            if (!(outputClause is null)) {
                h = h * 23 + outputClause.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DeleteSpecification);
        } 
        
        public bool Equals(DeleteSpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<FromClause>.Default.Equals(other.FromClause, fromClause)) {
                return false;
            }
            if (!EqualityComparer<WhereClause>.Default.Equals(other.WhereClause, whereClause)) {
                return false;
            }
            if (!EqualityComparer<TableReference>.Default.Equals(other.Target, target)) {
                return false;
            }
            if (!EqualityComparer<TopRowFilter>.Default.Equals(other.TopRowFilter, topRowFilter)) {
                return false;
            }
            if (!EqualityComparer<OutputIntoClause>.Default.Equals(other.OutputIntoClause, outputIntoClause)) {
                return false;
            }
            if (!EqualityComparer<OutputClause>.Default.Equals(other.OutputClause, outputClause)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DeleteSpecification left, DeleteSpecification right) {
            return EqualityComparer<DeleteSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DeleteSpecification left, DeleteSpecification right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DeleteSpecification)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.fromClause, othr.fromClause);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.whereClause, othr.whereClause);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.target, othr.target);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.topRowFilter, othr.topRowFilter);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.outputIntoClause, othr.outputIntoClause);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.outputClause, othr.outputClause);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static DeleteSpecification FromMutable(ScriptDom.DeleteSpecification fragment) {
            return (DeleteSpecification)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
