using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ReturnStatement : TSqlStatement, IEquatable<ReturnStatement> {
        protected ScalarExpression expression;
    
        public ScalarExpression Expression => expression;
    
        public ReturnStatement(ScalarExpression expression = null) {
            this.expression = expression;
        }
    
        public ScriptDom.ReturnStatement ToMutableConcrete() {
            var ret = new ScriptDom.ReturnStatement();
            ret.Expression = (ScriptDom.ScalarExpression)expression?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ReturnStatement);
        } 
        
        public bool Equals(ReturnStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ReturnStatement left, ReturnStatement right) {
            return EqualityComparer<ReturnStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ReturnStatement left, ReturnStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ReturnStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ReturnStatement left, ReturnStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ReturnStatement left, ReturnStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ReturnStatement left, ReturnStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ReturnStatement left, ReturnStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ReturnStatement FromMutable(ScriptDom.ReturnStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ReturnStatement)) { throw new NotImplementedException("Unexpected subtype of ReturnStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ReturnStatement(
                expression: ImmutableDom.ScalarExpression.FromMutable(fragment.Expression)
            );
        }
    
    }

}
