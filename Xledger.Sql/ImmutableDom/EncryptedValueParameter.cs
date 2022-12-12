using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EncryptedValueParameter : ColumnEncryptionKeyValueParameter, IEquatable<EncryptedValueParameter> {
        BinaryLiteral @value;
    
        public BinaryLiteral Value => @value;
    
        public EncryptedValueParameter(BinaryLiteral @value = null, ScriptDom.ColumnEncryptionKeyValueParameterKind parameterKind = ScriptDom.ColumnEncryptionKeyValueParameterKind.ColumnMasterKeyName) {
            this.@value = @value;
            this.parameterKind = parameterKind;
        }
    
        public ScriptDom.EncryptedValueParameter ToMutableConcrete() {
            var ret = new ScriptDom.EncryptedValueParameter();
            ret.Value = (ScriptDom.BinaryLiteral)@value.ToMutable();
            ret.ParameterKind = parameterKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + parameterKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EncryptedValueParameter);
        } 
        
        public bool Equals(EncryptedValueParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BinaryLiteral>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ColumnEncryptionKeyValueParameterKind>.Default.Equals(other.ParameterKind, parameterKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EncryptedValueParameter left, EncryptedValueParameter right) {
            return EqualityComparer<EncryptedValueParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EncryptedValueParameter left, EncryptedValueParameter right) {
            return !(left == right);
        }
    
    }

}
