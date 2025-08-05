using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AvailabilityReplicaOption : TSqlFragment {
        protected ScriptDom.AvailabilityReplicaOptionKind optionKind;
    
        public ScriptDom.AvailabilityReplicaOptionKind OptionKind => optionKind;
    
        public static AvailabilityReplicaOption FromMutable(ScriptDom.AvailabilityReplicaOption fragment) => (AvailabilityReplicaOption)TSqlFragment.FromMutable(fragment);
    
    }

}
