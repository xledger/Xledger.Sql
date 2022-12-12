using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnEncryptionKeyValue : TSqlFragment, IEquatable<ColumnEncryptionKeyValue> {
        IReadOnlyList<ColumnEncryptionKeyValueParameter> parameters;
    
        public IReadOnlyList<ColumnEncryptionKeyValueParameter> Parameters => parameters;
    
        public ColumnEncryptionKeyValue(IReadOnlyList<ColumnEncryptionKeyValueParameter> parameters = null) {
            this.parameters = parameters is null ? ImmList<ColumnEncryptionKeyValueParameter>.Empty : ImmList<ColumnEncryptionKeyValueParameter>.FromList(parameters);
        }
    
        public ScriptDom.ColumnEncryptionKeyValue ToMutableConcrete() {
            var ret = new ScriptDom.ColumnEncryptionKeyValue();
            ret.Parameters.AddRange(parameters.Select(c => (ScriptDom.ColumnEncryptionKeyValueParameter)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + parameters.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnEncryptionKeyValue);
        } 
        
        public bool Equals(ColumnEncryptionKeyValue other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ColumnEncryptionKeyValueParameter>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnEncryptionKeyValue left, ColumnEncryptionKeyValue right) {
            return EqualityComparer<ColumnEncryptionKeyValue>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnEncryptionKeyValue left, ColumnEncryptionKeyValue right) {
            return !(left == right);
        }
    
    }

}
