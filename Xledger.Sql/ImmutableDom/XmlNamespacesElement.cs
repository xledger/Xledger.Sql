using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class XmlNamespacesElement : TSqlFragment {
        protected StringLiteral @string;
    
        public StringLiteral String => @string;
    
        public static XmlNamespacesElement FromMutable(ScriptDom.XmlNamespacesElement fragment) {
            return (XmlNamespacesElement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
