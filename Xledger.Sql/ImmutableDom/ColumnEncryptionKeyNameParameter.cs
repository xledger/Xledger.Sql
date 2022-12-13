using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnEncryptionKeyNameParameter : ColumnEncryptionDefinitionParameter, IEquatable<ColumnEncryptionKeyNameParameter> {
        protected Identifier name;
    
        public Identifier Name => name;
    
        public ColumnEncryptionKeyNameParameter(Identifier name = null, ScriptDom.ColumnEncryptionDefinitionParameterKind parameterKind = ScriptDom.ColumnEncryptionDefinitionParameterKind.ColumnEncryptionKey) {
            this.name = name;
            this.parameterKind = parameterKind;
        }
    
        public ScriptDom.ColumnEncryptionKeyNameParameter ToMutableConcrete() {
            var ret = new ScriptDom.ColumnEncryptionKeyNameParameter();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ParameterKind = parameterKind;
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
            h = h * 23 + parameterKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnEncryptionKeyNameParameter);
        } 
        
        public bool Equals(ColumnEncryptionKeyNameParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ColumnEncryptionDefinitionParameterKind>.Default.Equals(other.ParameterKind, parameterKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnEncryptionKeyNameParameter left, ColumnEncryptionKeyNameParameter right) {
            return EqualityComparer<ColumnEncryptionKeyNameParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnEncryptionKeyNameParameter left, ColumnEncryptionKeyNameParameter right) {
            return !(left == right);
        }
    
        public static ColumnEncryptionKeyNameParameter FromMutable(ScriptDom.ColumnEncryptionKeyNameParameter fragment) {
            return (ColumnEncryptionKeyNameParameter)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
