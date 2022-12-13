using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AvailabilityGroupOption : TSqlFragment {
        protected ScriptDom.AvailabilityGroupOptionKind optionKind;
    
        public ScriptDom.AvailabilityGroupOptionKind OptionKind => optionKind;
    
        public static AvailabilityGroupOption FromMutable(ScriptDom.AvailabilityGroupOption fragment) {
            return (AvailabilityGroupOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
