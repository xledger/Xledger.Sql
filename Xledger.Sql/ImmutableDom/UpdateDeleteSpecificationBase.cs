using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class UpdateDeleteSpecificationBase : DataModificationSpecification {
        protected FromClause fromClause;
        protected WhereClause whereClause;
    
        public FromClause FromClause => fromClause;
        public WhereClause WhereClause => whereClause;
    
        public static UpdateDeleteSpecificationBase FromMutable(ScriptDom.UpdateDeleteSpecificationBase fragment) => (UpdateDeleteSpecificationBase)TSqlFragment.FromMutable(fragment);
    
    }

}
