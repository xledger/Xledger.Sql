using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class DataModificationSpecification : TSqlFragment {
        protected TableReference target;
        protected TopRowFilter topRowFilter;
        protected OutputIntoClause outputIntoClause;
        protected OutputClause outputClause;
    
        public TableReference Target => target;
        public TopRowFilter TopRowFilter => topRowFilter;
        public OutputIntoClause OutputIntoClause => outputIntoClause;
        public OutputClause OutputClause => outputClause;
    
        public static DataModificationSpecification FromMutable(ScriptDom.DataModificationSpecification fragment) => (DataModificationSpecification)TSqlFragment.FromMutable(fragment);
    
    }

}
