using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class AvailabilityReplicaOption : TSqlFragment {
        protected ScriptDom.AvailabilityReplicaOptionKind optionKind;
    
        public ScriptDom.AvailabilityReplicaOptionKind OptionKind => optionKind;
    
        public static AvailabilityReplicaOption FromMutable(ScriptDom.AvailabilityReplicaOption fragment) {
            return (AvailabilityReplicaOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
