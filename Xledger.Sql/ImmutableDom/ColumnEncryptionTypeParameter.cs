using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnEncryptionTypeParameter : ColumnEncryptionDefinitionParameter, IEquatable<ColumnEncryptionTypeParameter> {
        protected ScriptDom.ColumnEncryptionType encryptionType = ScriptDom.ColumnEncryptionType.Deterministic;
    
        public ScriptDom.ColumnEncryptionType EncryptionType => encryptionType;
    
        public ColumnEncryptionTypeParameter(ScriptDom.ColumnEncryptionType encryptionType = ScriptDom.ColumnEncryptionType.Deterministic, ScriptDom.ColumnEncryptionDefinitionParameterKind parameterKind = ScriptDom.ColumnEncryptionDefinitionParameterKind.ColumnEncryptionKey) {
            this.encryptionType = encryptionType;
            this.parameterKind = parameterKind;
        }
    
        public ScriptDom.ColumnEncryptionTypeParameter ToMutableConcrete() {
            var ret = new ScriptDom.ColumnEncryptionTypeParameter();
            ret.EncryptionType = encryptionType;
            ret.ParameterKind = parameterKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + encryptionType.GetHashCode();
            h = h * 23 + parameterKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnEncryptionTypeParameter);
        } 
        
        public bool Equals(ColumnEncryptionTypeParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ColumnEncryptionType>.Default.Equals(other.EncryptionType, encryptionType)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ColumnEncryptionDefinitionParameterKind>.Default.Equals(other.ParameterKind, parameterKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnEncryptionTypeParameter left, ColumnEncryptionTypeParameter right) {
            return EqualityComparer<ColumnEncryptionTypeParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnEncryptionTypeParameter left, ColumnEncryptionTypeParameter right) {
            return !(left == right);
        }
    
        public static ColumnEncryptionTypeParameter FromMutable(ScriptDom.ColumnEncryptionTypeParameter fragment) {
            return (ColumnEncryptionTypeParameter)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
