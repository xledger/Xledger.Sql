using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnMasterKeyStoreProviderNameParameter : ColumnMasterKeyParameter, IEquatable<ColumnMasterKeyStoreProviderNameParameter> {
        protected StringLiteral name;
    
        public StringLiteral Name => name;
    
        public ColumnMasterKeyStoreProviderNameParameter(StringLiteral name = null, ScriptDom.ColumnMasterKeyParameterKind parameterKind = ScriptDom.ColumnMasterKeyParameterKind.KeyStoreProviderName) {
            this.name = name;
            this.parameterKind = parameterKind;
        }
    
        public ScriptDom.ColumnMasterKeyStoreProviderNameParameter ToMutableConcrete() {
            var ret = new ScriptDom.ColumnMasterKeyStoreProviderNameParameter();
            ret.Name = (ScriptDom.StringLiteral)name.ToMutable();
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
            return Equals(obj as ColumnMasterKeyStoreProviderNameParameter);
        } 
        
        public bool Equals(ColumnMasterKeyStoreProviderNameParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ColumnMasterKeyParameterKind>.Default.Equals(other.ParameterKind, parameterKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnMasterKeyStoreProviderNameParameter left, ColumnMasterKeyStoreProviderNameParameter right) {
            return EqualityComparer<ColumnMasterKeyStoreProviderNameParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnMasterKeyStoreProviderNameParameter left, ColumnMasterKeyStoreProviderNameParameter right) {
            return !(left == right);
        }
    
        public static ColumnMasterKeyStoreProviderNameParameter FromMutable(ScriptDom.ColumnMasterKeyStoreProviderNameParameter fragment) {
            return (ColumnMasterKeyStoreProviderNameParameter)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
