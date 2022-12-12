using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalResourcePoolStatement : TSqlStatement, IEquatable<ExternalResourcePoolStatement> {
        Identifier name;
        IReadOnlyList<ExternalResourcePoolParameter> externalResourcePoolParameters;
    
        public Identifier Name => name;
        public IReadOnlyList<ExternalResourcePoolParameter> ExternalResourcePoolParameters => externalResourcePoolParameters;
    
        public ExternalResourcePoolStatement(Identifier name = null, IReadOnlyList<ExternalResourcePoolParameter> externalResourcePoolParameters = null) {
            this.name = name;
            this.externalResourcePoolParameters = externalResourcePoolParameters is null ? ImmList<ExternalResourcePoolParameter>.Empty : ImmList<ExternalResourcePoolParameter>.FromList(externalResourcePoolParameters);
        }
    
        public ScriptDom.ExternalResourcePoolStatement ToMutableConcrete() {
            var ret = new ScriptDom.ExternalResourcePoolStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ExternalResourcePoolParameters.AddRange(externalResourcePoolParameters.Select(c => (ScriptDom.ExternalResourcePoolParameter)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + externalResourcePoolParameters.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalResourcePoolStatement);
        } 
        
        public bool Equals(ExternalResourcePoolStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExternalResourcePoolParameter>>.Default.Equals(other.ExternalResourcePoolParameters, externalResourcePoolParameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalResourcePoolStatement left, ExternalResourcePoolStatement right) {
            return EqualityComparer<ExternalResourcePoolStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalResourcePoolStatement left, ExternalResourcePoolStatement right) {
            return !(left == right);
        }
    
    }

}
