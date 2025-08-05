using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CoalesceExpression : PrimaryExpression, IEquatable<CoalesceExpression> {
        protected IReadOnlyList<ScalarExpression> expressions;
    
        public IReadOnlyList<ScalarExpression> Expressions => expressions;
    
        public CoalesceExpression(IReadOnlyList<ScalarExpression> expressions = null, Identifier collation = null) {
            this.expressions = expressions.ToImmArray<ScalarExpression>();
            this.collation = collation;
        }
    
        public ScriptDom.CoalesceExpression ToMutableConcrete() {
            var ret = new ScriptDom.CoalesceExpression();
            ret.Expressions.AddRange(expressions.Select(c => (ScriptDom.ScalarExpression)c?.ToMutable()));
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + expressions.GetHashCode();
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CoalesceExpression);
        } 
        
        public bool Equals(CoalesceExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Expressions, expressions)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CoalesceExpression left, CoalesceExpression right) {
            return EqualityComparer<CoalesceExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CoalesceExpression left, CoalesceExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CoalesceExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.expressions, othr.expressions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CoalesceExpression left, CoalesceExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CoalesceExpression left, CoalesceExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CoalesceExpression left, CoalesceExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CoalesceExpression left, CoalesceExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CoalesceExpression FromMutable(ScriptDom.CoalesceExpression fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CoalesceExpression)) { throw new NotImplementedException("Unexpected subtype of CoalesceExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CoalesceExpression(
                expressions: fragment.Expressions.ToImmArray(ImmutableDom.ScalarExpression.FromMutable),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
