using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class StatementWithCtesAndXmlNamespaces : TSqlStatement {
        protected WithCtesAndXmlNamespaces withCtesAndXmlNamespaces;
        protected IReadOnlyList<OptimizerHint> optimizerHints;
    
        public WithCtesAndXmlNamespaces WithCtesAndXmlNamespaces => withCtesAndXmlNamespaces;
        public IReadOnlyList<OptimizerHint> OptimizerHints => optimizerHints;
    
        public static StatementWithCtesAndXmlNamespaces FromMutable(ScriptDom.StatementWithCtesAndXmlNamespaces fragment) => (StatementWithCtesAndXmlNamespaces)TSqlFragment.FromMutable(fragment);
    
    }

}
