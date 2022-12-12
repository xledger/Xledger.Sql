using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class HavingClause : TSqlFragment, IEquatable<HavingClause> {
        BooleanExpression searchCondition;
    
        public BooleanExpression SearchCondition => searchCondition;
    
        public HavingClause(BooleanExpression searchCondition = null) {
            this.searchCondition = searchCondition;
        }
    
        public ScriptDom.HavingClause ToMutableConcrete() {
            var ret = new ScriptDom.HavingClause();
            ret.SearchCondition = (ScriptDom.BooleanExpression)searchCondition.ToMutable();
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
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as HavingClause);
        } 
        
        public bool Equals(HavingClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.SearchCondition, searchCondition)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(HavingClause left, HavingClause right) {
            return EqualityComparer<HavingClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(HavingClause left, HavingClause right) {
            return !(left == right);
        }
    
    }

}
