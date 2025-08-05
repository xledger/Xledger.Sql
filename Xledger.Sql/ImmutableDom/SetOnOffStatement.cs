using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SetOnOffStatement : TSqlStatement {
        protected bool isOn;
    
        public bool IsOn => isOn;
    
        public static SetOnOffStatement FromMutable(ScriptDom.SetOnOffStatement fragment) => (SetOnOffStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
