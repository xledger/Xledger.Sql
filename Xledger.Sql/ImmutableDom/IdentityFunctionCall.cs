using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IdentityFunctionCall : ScalarExpression, IEquatable<IdentityFunctionCall> {
        protected DataTypeReference dataType;
        protected ScalarExpression seed;
        protected ScalarExpression increment;
    
        public DataTypeReference DataType => dataType;
        public ScalarExpression Seed => seed;
        public ScalarExpression Increment => increment;
    
        public IdentityFunctionCall(DataTypeReference dataType = null, ScalarExpression seed = null, ScalarExpression increment = null) {
            this.dataType = dataType;
            this.seed = seed;
            this.increment = increment;
        }
    
        public ScriptDom.IdentityFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.IdentityFunctionCall();
            ret.DataType = (ScriptDom.DataTypeReference)dataType.ToMutable();
            ret.Seed = (ScriptDom.ScalarExpression)seed.ToMutable();
            ret.Increment = (ScriptDom.ScalarExpression)increment.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(dataType is null)) {
                h = h * 23 + dataType.GetHashCode();
            }
            if (!(seed is null)) {
                h = h * 23 + seed.GetHashCode();
            }
            if (!(increment is null)) {
                h = h * 23 + increment.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IdentityFunctionCall);
        } 
        
        public bool Equals(IdentityFunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.DataType, dataType)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Seed, seed)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Increment, increment)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IdentityFunctionCall left, IdentityFunctionCall right) {
            return EqualityComparer<IdentityFunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IdentityFunctionCall left, IdentityFunctionCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (IdentityFunctionCall)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.dataType, othr.dataType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.seed, othr.seed);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.increment, othr.increment);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static IdentityFunctionCall FromMutable(ScriptDom.IdentityFunctionCall fragment) {
            return (IdentityFunctionCall)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
