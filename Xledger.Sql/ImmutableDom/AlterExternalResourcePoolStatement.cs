using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterExternalResourcePoolStatement : ExternalResourcePoolStatement, IEquatable<AlterExternalResourcePoolStatement> {
        public AlterExternalResourcePoolStatement(Identifier name = null, IReadOnlyList<ExternalResourcePoolParameter> externalResourcePoolParameters = null) {
            this.name = name;
            this.externalResourcePoolParameters = externalResourcePoolParameters is null ? ImmList<ExternalResourcePoolParameter>.Empty : ImmList<ExternalResourcePoolParameter>.FromList(externalResourcePoolParameters);
        }
    
        public ScriptDom.AlterExternalResourcePoolStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterExternalResourcePoolStatement();
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
            return Equals(obj as AlterExternalResourcePoolStatement);
        } 
        
        public bool Equals(AlterExternalResourcePoolStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExternalResourcePoolParameter>>.Default.Equals(other.ExternalResourcePoolParameters, externalResourcePoolParameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterExternalResourcePoolStatement left, AlterExternalResourcePoolStatement right) {
            return EqualityComparer<AlterExternalResourcePoolStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterExternalResourcePoolStatement left, AlterExternalResourcePoolStatement right) {
            return !(left == right);
        }
    
    }

}
