using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ExternalModelStatement : TSqlStatement {
        protected Identifier name;
        protected Literal location;
        protected Literal apiFormat;
        protected ScriptDom.ExternalModelTypeOption? modelType;
        protected ExternalModelTypeSpecification modelTypeSpecification;
        protected Literal modelName;
        protected Identifier credential;
        protected Literal parameters;
        protected Literal localRuntimePath;
    
        public Identifier Name => name;
        public Literal Location => location;
        public Literal ApiFormat => apiFormat;
        public ScriptDom.ExternalModelTypeOption? ModelType => modelType;
        public ExternalModelTypeSpecification ModelTypeSpecification => modelTypeSpecification;
        public Literal ModelName => modelName;
        public Identifier Credential => credential;
        public Literal Parameters => parameters;
        public Literal LocalRuntimePath => localRuntimePath;
    
        public static ExternalModelStatement FromMutable(ScriptDom.ExternalModelStatement fragment) => (ExternalModelStatement)TSqlFragment.FromMutable(fragment);
    
    }

}
