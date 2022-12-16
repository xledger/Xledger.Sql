using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SimpleCaseExpression : CaseExpression, IEquatable<SimpleCaseExpression> {
        protected ScalarExpression inputExpression;
        protected IReadOnlyList<SimpleWhenClause> whenClauses;
    
        public ScalarExpression InputExpression => inputExpression;
        public IReadOnlyList<SimpleWhenClause> WhenClauses => whenClauses;
    
        public SimpleCaseExpression(ScalarExpression inputExpression = null, IReadOnlyList<SimpleWhenClause> whenClauses = null, ScalarExpression elseExpression = null, Identifier collation = null) {
            this.inputExpression = inputExpression;
            this.whenClauses = ImmList<SimpleWhenClause>.FromList(whenClauses);
            this.elseExpression = elseExpression;
            this.collation = collation;
        }
    
        public ScriptDom.SimpleCaseExpression ToMutableConcrete() {
            var ret = new ScriptDom.SimpleCaseExpression();
            ret.InputExpression = (ScriptDom.ScalarExpression)inputExpression?.ToMutable();
            ret.WhenClauses.AddRange(whenClauses.SelectList(c => (ScriptDom.SimpleWhenClause)c?.ToMutable()));
            ret.ElseExpression = (ScriptDom.ScalarExpression)elseExpression?.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(inputExpression is null)) {
                h = h * 23 + inputExpression.GetHashCode();
            }
            h = h * 23 + whenClauses.GetHashCode();
            if (!(elseExpression is null)) {
                h = h * 23 + elseExpression.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SimpleCaseExpression);
        } 
        
        public bool Equals(SimpleCaseExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.InputExpression, inputExpression)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SimpleWhenClause>>.Default.Equals(other.WhenClauses, whenClauses)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.ElseExpression, elseExpression)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SimpleCaseExpression left, SimpleCaseExpression right) {
            return EqualityComparer<SimpleCaseExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SimpleCaseExpression left, SimpleCaseExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SimpleCaseExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.inputExpression, othr.inputExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.whenClauses, othr.whenClauses);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.elseExpression, othr.elseExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SimpleCaseExpression left, SimpleCaseExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SimpleCaseExpression left, SimpleCaseExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SimpleCaseExpression left, SimpleCaseExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SimpleCaseExpression left, SimpleCaseExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
