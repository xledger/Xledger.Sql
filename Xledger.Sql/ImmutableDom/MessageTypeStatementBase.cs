using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class MessageTypeStatementBase : TSqlStatement {
        protected Identifier name;
        protected ScriptDom.MessageValidationMethod validationMethod;
        protected SchemaObjectName xmlSchemaCollectionName;
    
        public Identifier Name => name;
        public ScriptDom.MessageValidationMethod ValidationMethod => validationMethod;
        public SchemaObjectName XmlSchemaCollectionName => xmlSchemaCollectionName;
    
        public static MessageTypeStatementBase FromMutable(ScriptDom.MessageTypeStatementBase fragment) {
            return (MessageTypeStatementBase)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
