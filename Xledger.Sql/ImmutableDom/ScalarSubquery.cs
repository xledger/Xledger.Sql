using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ScalarSubquery : PrimaryExpression, IEquatable<ScalarSubquery> {
        QueryExpression queryExpression;
    
        public QueryExpression QueryExpression => queryExpression;
    
        public ScalarSubquery(QueryExpression queryExpression = null, Identifier collation = null) {
            this.queryExpression = queryExpression;
            this.collation = collation;
        }
    
        public ScriptDom.ScalarSubquery ToMutableConcrete() {
            var ret = new ScriptDom.ScalarSubquery();
            ret.QueryExpression = (ScriptDom.QueryExpression)queryExpression.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(queryExpression is null)) {
                h = h * 23 + queryExpression.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ScalarSubquery);
        } 
        
        public bool Equals(ScalarSubquery other) {
            if (other is null) { return false; }
            if (!EqualityComparer<QueryExpression>.Default.Equals(other.QueryExpression, queryExpression)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ScalarSubquery left, ScalarSubquery right) {
            return EqualityComparer<ScalarSubquery>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ScalarSubquery left, ScalarSubquery right) {
            return !(left == right);
        }
    
    }

}
