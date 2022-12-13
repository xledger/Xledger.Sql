using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnMasterKeyPathParameter : ColumnMasterKeyParameter, IEquatable<ColumnMasterKeyPathParameter> {
        protected StringLiteral path;
    
        public StringLiteral Path => path;
    
        public ColumnMasterKeyPathParameter(StringLiteral path = null, ScriptDom.ColumnMasterKeyParameterKind parameterKind = ScriptDom.ColumnMasterKeyParameterKind.KeyStoreProviderName) {
            this.path = path;
            this.parameterKind = parameterKind;
        }
    
        public ScriptDom.ColumnMasterKeyPathParameter ToMutableConcrete() {
            var ret = new ScriptDom.ColumnMasterKeyPathParameter();
            ret.Path = (ScriptDom.StringLiteral)path.ToMutable();
            ret.ParameterKind = parameterKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(path is null)) {
                h = h * 23 + path.GetHashCode();
            }
            h = h * 23 + parameterKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnMasterKeyPathParameter);
        } 
        
        public bool Equals(ColumnMasterKeyPathParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Path, path)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ColumnMasterKeyParameterKind>.Default.Equals(other.ParameterKind, parameterKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnMasterKeyPathParameter left, ColumnMasterKeyPathParameter right) {
            return EqualityComparer<ColumnMasterKeyPathParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnMasterKeyPathParameter left, ColumnMasterKeyPathParameter right) {
            return !(left == right);
        }
    
        public static ColumnMasterKeyPathParameter FromMutable(ScriptDom.ColumnMasterKeyPathParameter fragment) {
            return (ColumnMasterKeyPathParameter)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
