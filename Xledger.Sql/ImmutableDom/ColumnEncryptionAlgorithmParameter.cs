using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnEncryptionAlgorithmParameter : ColumnEncryptionDefinitionParameter, IEquatable<ColumnEncryptionAlgorithmParameter> {
        protected StringLiteral encryptionAlgorithm;
    
        public StringLiteral EncryptionAlgorithm => encryptionAlgorithm;
    
        public ColumnEncryptionAlgorithmParameter(StringLiteral encryptionAlgorithm = null, ScriptDom.ColumnEncryptionDefinitionParameterKind parameterKind = ScriptDom.ColumnEncryptionDefinitionParameterKind.ColumnEncryptionKey) {
            this.encryptionAlgorithm = encryptionAlgorithm;
            this.parameterKind = parameterKind;
        }
    
        public ScriptDom.ColumnEncryptionAlgorithmParameter ToMutableConcrete() {
            var ret = new ScriptDom.ColumnEncryptionAlgorithmParameter();
            ret.EncryptionAlgorithm = (ScriptDom.StringLiteral)encryptionAlgorithm.ToMutable();
            ret.ParameterKind = parameterKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(encryptionAlgorithm is null)) {
                h = h * 23 + encryptionAlgorithm.GetHashCode();
            }
            h = h * 23 + parameterKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnEncryptionAlgorithmParameter);
        } 
        
        public bool Equals(ColumnEncryptionAlgorithmParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.EncryptionAlgorithm, encryptionAlgorithm)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ColumnEncryptionDefinitionParameterKind>.Default.Equals(other.ParameterKind, parameterKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnEncryptionAlgorithmParameter left, ColumnEncryptionAlgorithmParameter right) {
            return EqualityComparer<ColumnEncryptionAlgorithmParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnEncryptionAlgorithmParameter left, ColumnEncryptionAlgorithmParameter right) {
            return !(left == right);
        }
    
        public static ColumnEncryptionAlgorithmParameter FromMutable(ScriptDom.ColumnEncryptionAlgorithmParameter fragment) {
            return (ColumnEncryptionAlgorithmParameter)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
