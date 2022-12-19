using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class DropClusteredConstraintOption : TSqlFragment {
        protected ScriptDom.DropClusteredConstraintOptionKind optionKind;
    
        public ScriptDom.DropClusteredConstraintOptionKind OptionKind => optionKind;
    
        public static DropClusteredConstraintOption FromMutable(ScriptDom.DropClusteredConstraintOption fragment) => (DropClusteredConstraintOption)TSqlFragment.FromMutable(fragment);
    
    }

}
