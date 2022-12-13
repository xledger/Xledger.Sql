using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class StatementWithCtesAndXmlNamespaces : TSqlStatement {
        protected WithCtesAndXmlNamespaces withCtesAndXmlNamespaces;
        protected IReadOnlyList<OptimizerHint> optimizerHints;
    
        public WithCtesAndXmlNamespaces WithCtesAndXmlNamespaces => withCtesAndXmlNamespaces;
        public IReadOnlyList<OptimizerHint> OptimizerHints => optimizerHints;
    
        public static StatementWithCtesAndXmlNamespaces FromMutable(ScriptDom.StatementWithCtesAndXmlNamespaces fragment) {
            return (StatementWithCtesAndXmlNamespaces)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
