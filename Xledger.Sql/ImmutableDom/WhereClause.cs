using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WhereClause : TSqlFragment, IEquatable<WhereClause> {
        protected BooleanExpression searchCondition;
        protected CursorId cursor;
    
        public BooleanExpression SearchCondition => searchCondition;
        public CursorId Cursor => cursor;
    
        public WhereClause(BooleanExpression searchCondition = null, CursorId cursor = null) {
            this.searchCondition = searchCondition;
            this.cursor = cursor;
        }
    
        public ScriptDom.WhereClause ToMutableConcrete() {
            var ret = new ScriptDom.WhereClause();
            ret.SearchCondition = (ScriptDom.BooleanExpression)searchCondition.ToMutable();
            ret.Cursor = (ScriptDom.CursorId)cursor.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(searchCondition is null)) {
                h = h * 23 + searchCondition.GetHashCode();
            }
            if (!(cursor is null)) {
                h = h * 23 + cursor.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WhereClause);
        } 
        
        public bool Equals(WhereClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.SearchCondition, searchCondition)) {
                return false;
            }
            if (!EqualityComparer<CursorId>.Default.Equals(other.Cursor, cursor)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WhereClause left, WhereClause right) {
            return EqualityComparer<WhereClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WhereClause left, WhereClause right) {
            return !(left == right);
        }
    
        public static WhereClause FromMutable(ScriptDom.WhereClause fragment) {
            return (WhereClause)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
