using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SearchedCaseExpression : CaseExpression, IEquatable<SearchedCaseExpression> {
        protected IReadOnlyList<SearchedWhenClause> whenClauses;
    
        public IReadOnlyList<SearchedWhenClause> WhenClauses => whenClauses;
    
        public SearchedCaseExpression(IReadOnlyList<SearchedWhenClause> whenClauses = null, ScalarExpression elseExpression = null, Identifier collation = null) {
            this.whenClauses = whenClauses.ToImmArray<SearchedWhenClause>();
            this.elseExpression = elseExpression;
            this.collation = collation;
        }
    
        public ScriptDom.SearchedCaseExpression ToMutableConcrete() {
            var ret = new ScriptDom.SearchedCaseExpression();
            ret.WhenClauses.AddRange(whenClauses.Select(c => (ScriptDom.SearchedWhenClause)c?.ToMutable()));
            ret.ElseExpression = (ScriptDom.ScalarExpression)elseExpression?.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
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
            return Equals(obj as SearchedCaseExpression);
        } 
        
        public bool Equals(SearchedCaseExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<SearchedWhenClause>>.Default.Equals(other.WhenClauses, whenClauses)) {
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
        
        public static bool operator ==(SearchedCaseExpression left, SearchedCaseExpression right) {
            return EqualityComparer<SearchedCaseExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SearchedCaseExpression left, SearchedCaseExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SearchedCaseExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.whenClauses, othr.whenClauses);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.elseExpression, othr.elseExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SearchedCaseExpression left, SearchedCaseExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SearchedCaseExpression left, SearchedCaseExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SearchedCaseExpression left, SearchedCaseExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SearchedCaseExpression left, SearchedCaseExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SearchedCaseExpression FromMutable(ScriptDom.SearchedCaseExpression fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SearchedCaseExpression)) { throw new NotImplementedException("Unexpected subtype of SearchedCaseExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SearchedCaseExpression(
                whenClauses: fragment.WhenClauses.ToImmArray(ImmutableDom.SearchedWhenClause.FromMutable),
                elseExpression: ImmutableDom.ScalarExpression.FromMutable(fragment.ElseExpression),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
