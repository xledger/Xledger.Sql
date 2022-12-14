using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ResultColumnDefinition : TSqlFragment, IEquatable<ResultColumnDefinition> {
        protected ColumnDefinitionBase columnDefinition;
        protected NullableConstraintDefinition nullable;
    
        public ColumnDefinitionBase ColumnDefinition => columnDefinition;
        public NullableConstraintDefinition Nullable => nullable;
    
        public ResultColumnDefinition(ColumnDefinitionBase columnDefinition = null, NullableConstraintDefinition nullable = null) {
            this.columnDefinition = columnDefinition;
            this.nullable = nullable;
        }
    
        public ScriptDom.ResultColumnDefinition ToMutableConcrete() {
            var ret = new ScriptDom.ResultColumnDefinition();
            ret.ColumnDefinition = (ScriptDom.ColumnDefinitionBase)columnDefinition?.ToMutable();
            ret.Nullable = (ScriptDom.NullableConstraintDefinition)nullable?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(columnDefinition is null)) {
                h = h * 23 + columnDefinition.GetHashCode();
            }
            if (!(nullable is null)) {
                h = h * 23 + nullable.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ResultColumnDefinition);
        } 
        
        public bool Equals(ResultColumnDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ColumnDefinitionBase>.Default.Equals(other.ColumnDefinition, columnDefinition)) {
                return false;
            }
            if (!EqualityComparer<NullableConstraintDefinition>.Default.Equals(other.Nullable, nullable)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ResultColumnDefinition left, ResultColumnDefinition right) {
            return EqualityComparer<ResultColumnDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ResultColumnDefinition left, ResultColumnDefinition right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ResultColumnDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.columnDefinition, othr.columnDefinition);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.nullable, othr.nullable);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ResultColumnDefinition left, ResultColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ResultColumnDefinition left, ResultColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ResultColumnDefinition left, ResultColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ResultColumnDefinition left, ResultColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ResultColumnDefinition FromMutable(ScriptDom.ResultColumnDefinition fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ResultColumnDefinition)) { throw new NotImplementedException("Unexpected subtype of ResultColumnDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ResultColumnDefinition(
                columnDefinition: ImmutableDom.ColumnDefinitionBase.FromMutable(fragment.ColumnDefinition),
                nullable: ImmutableDom.NullableConstraintDefinition.FromMutable(fragment.Nullable)
            );
        }
    
    }

}
