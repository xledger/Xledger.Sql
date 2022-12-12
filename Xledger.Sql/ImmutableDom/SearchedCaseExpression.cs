using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SearchedCaseExpression : CaseExpression, IEquatable<SearchedCaseExpression> {
        protected IReadOnlyList<SearchedWhenClause> whenClauses;
    
        public IReadOnlyList<SearchedWhenClause> WhenClauses => whenClauses;
    
        public SearchedCaseExpression(IReadOnlyList<SearchedWhenClause> whenClauses = null, ScalarExpression elseExpression = null, Identifier collation = null) {
            this.whenClauses = whenClauses is null ? ImmList<SearchedWhenClause>.Empty : ImmList<SearchedWhenClause>.FromList(whenClauses);
            this.elseExpression = elseExpression;
            this.collation = collation;
        }
    
        public ScriptDom.SearchedCaseExpression ToMutableConcrete() {
            var ret = new ScriptDom.SearchedCaseExpression();
            ret.WhenClauses.AddRange(whenClauses.SelectList(c => (ScriptDom.SearchedWhenClause)c.ToMutable()));
            ret.ElseExpression = (ScriptDom.ScalarExpression)elseExpression.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
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
    
    }

}
