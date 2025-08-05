using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SingleValueTypeCopyOption : CopyStatementOptionBase, IEquatable<SingleValueTypeCopyOption> {
        protected IdentifierOrValueExpression singleValue;
    
        public IdentifierOrValueExpression SingleValue => singleValue;
    
        public SingleValueTypeCopyOption(IdentifierOrValueExpression singleValue = null) {
            this.singleValue = singleValue;
        }
    
        public ScriptDom.SingleValueTypeCopyOption ToMutableConcrete() {
            var ret = new ScriptDom.SingleValueTypeCopyOption();
            ret.SingleValue = (ScriptDom.IdentifierOrValueExpression)singleValue?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(singleValue is null)) {
                h = h * 23 + singleValue.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SingleValueTypeCopyOption);
        } 
        
        public bool Equals(SingleValueTypeCopyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.SingleValue, singleValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SingleValueTypeCopyOption left, SingleValueTypeCopyOption right) {
            return EqualityComparer<SingleValueTypeCopyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SingleValueTypeCopyOption left, SingleValueTypeCopyOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SingleValueTypeCopyOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.singleValue, othr.singleValue);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SingleValueTypeCopyOption left, SingleValueTypeCopyOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SingleValueTypeCopyOption left, SingleValueTypeCopyOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SingleValueTypeCopyOption left, SingleValueTypeCopyOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SingleValueTypeCopyOption left, SingleValueTypeCopyOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SingleValueTypeCopyOption FromMutable(ScriptDom.SingleValueTypeCopyOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SingleValueTypeCopyOption)) { throw new NotImplementedException("Unexpected subtype of SingleValueTypeCopyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SingleValueTypeCopyOption(
                singleValue: ImmutableDom.IdentifierOrValueExpression.FromMutable(fragment.SingleValue)
            );
        }
    
    }

}
