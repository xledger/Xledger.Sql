using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetTextSizeStatement : TSqlStatement, IEquatable<SetTextSizeStatement> {
        protected ScalarExpression textSize;
    
        public ScalarExpression TextSize => textSize;
    
        public SetTextSizeStatement(ScalarExpression textSize = null) {
            this.textSize = textSize;
        }
    
        public ScriptDom.SetTextSizeStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetTextSizeStatement();
            ret.TextSize = (ScriptDom.ScalarExpression)textSize.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(textSize is null)) {
                h = h * 23 + textSize.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetTextSizeStatement);
        } 
        
        public bool Equals(SetTextSizeStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.TextSize, textSize)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetTextSizeStatement left, SetTextSizeStatement right) {
            return EqualityComparer<SetTextSizeStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetTextSizeStatement left, SetTextSizeStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SetTextSizeStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.textSize, othr.textSize);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SetTextSizeStatement left, SetTextSizeStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SetTextSizeStatement left, SetTextSizeStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SetTextSizeStatement left, SetTextSizeStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SetTextSizeStatement left, SetTextSizeStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SetTextSizeStatement FromMutable(ScriptDom.SetTextSizeStatement fragment) {
            return (SetTextSizeStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
