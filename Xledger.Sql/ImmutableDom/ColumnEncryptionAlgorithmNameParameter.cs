using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnEncryptionAlgorithmNameParameter : ColumnEncryptionKeyValueParameter, IEquatable<ColumnEncryptionAlgorithmNameParameter> {
        protected StringLiteral algorithm;
    
        public StringLiteral Algorithm => algorithm;
    
        public ColumnEncryptionAlgorithmNameParameter(StringLiteral algorithm = null, ScriptDom.ColumnEncryptionKeyValueParameterKind parameterKind = ScriptDom.ColumnEncryptionKeyValueParameterKind.ColumnMasterKeyName) {
            this.algorithm = algorithm;
            this.parameterKind = parameterKind;
        }
    
        public ScriptDom.ColumnEncryptionAlgorithmNameParameter ToMutableConcrete() {
            var ret = new ScriptDom.ColumnEncryptionAlgorithmNameParameter();
            ret.Algorithm = (ScriptDom.StringLiteral)algorithm.ToMutable();
            ret.ParameterKind = parameterKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(algorithm is null)) {
                h = h * 23 + algorithm.GetHashCode();
            }
            h = h * 23 + parameterKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnEncryptionAlgorithmNameParameter);
        } 
        
        public bool Equals(ColumnEncryptionAlgorithmNameParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Algorithm, algorithm)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ColumnEncryptionKeyValueParameterKind>.Default.Equals(other.ParameterKind, parameterKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnEncryptionAlgorithmNameParameter left, ColumnEncryptionAlgorithmNameParameter right) {
            return EqualityComparer<ColumnEncryptionAlgorithmNameParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnEncryptionAlgorithmNameParameter left, ColumnEncryptionAlgorithmNameParameter right) {
            return !(left == right);
        }
    
        public static ColumnEncryptionAlgorithmNameParameter FromMutable(ScriptDom.ColumnEncryptionAlgorithmNameParameter fragment) {
            return (ColumnEncryptionAlgorithmNameParameter)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
