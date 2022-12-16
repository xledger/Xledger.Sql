using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ComputeClause : TSqlFragment, IEquatable<ComputeClause> {
        protected IReadOnlyList<ComputeFunction> computeFunctions;
        protected IReadOnlyList<ScalarExpression> byExpressions;
    
        public IReadOnlyList<ComputeFunction> ComputeFunctions => computeFunctions;
        public IReadOnlyList<ScalarExpression> ByExpressions => byExpressions;
    
        public ComputeClause(IReadOnlyList<ComputeFunction> computeFunctions = null, IReadOnlyList<ScalarExpression> byExpressions = null) {
            this.computeFunctions = ImmList<ComputeFunction>.FromList(computeFunctions);
            this.byExpressions = ImmList<ScalarExpression>.FromList(byExpressions);
        }
    
        public ScriptDom.ComputeClause ToMutableConcrete() {
            var ret = new ScriptDom.ComputeClause();
            ret.ComputeFunctions.AddRange(computeFunctions.SelectList(c => (ScriptDom.ComputeFunction)c?.ToMutable()));
            ret.ByExpressions.AddRange(byExpressions.SelectList(c => (ScriptDom.ScalarExpression)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + computeFunctions.GetHashCode();
            h = h * 23 + byExpressions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ComputeClause);
        } 
        
        public bool Equals(ComputeClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ComputeFunction>>.Default.Equals(other.ComputeFunctions, computeFunctions)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.ByExpressions, byExpressions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ComputeClause left, ComputeClause right) {
            return EqualityComparer<ComputeClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ComputeClause left, ComputeClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ComputeClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.computeFunctions, othr.computeFunctions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.byExpressions, othr.byExpressions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ComputeClause left, ComputeClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ComputeClause left, ComputeClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ComputeClause left, ComputeClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ComputeClause left, ComputeClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
