using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class QueryExpression : TSqlFragment {
        protected OrderByClause orderByClause;
        protected OffsetClause offsetClause;
        protected ForClause forClause;
    
        public OrderByClause OrderByClause => orderByClause;
        public OffsetClause OffsetClause => offsetClause;
        public ForClause ForClause => forClause;
    
        public static QueryExpression FromMutable(ScriptDom.QueryExpression fragment) {
            return (QueryExpression)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
