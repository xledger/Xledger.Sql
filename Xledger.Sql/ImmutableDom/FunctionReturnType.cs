using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class FunctionReturnType : TSqlFragment {
        public static FunctionReturnType FromMutable(ScriptDom.FunctionReturnType fragment) => (FunctionReturnType)TSqlFragment.FromMutable(fragment);
    
    }

}
