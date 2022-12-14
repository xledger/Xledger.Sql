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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ColumnMasterKeyStoreProviderNameParameter)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameterKind, othr.parameterKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ColumnMasterKeyStoreProviderNameParameter left, ColumnMasterKeyStoreProviderNameParameter right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ColumnMasterKeyStoreProviderNameParameter left, ColumnMasterKeyStoreProviderNameParameter right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ColumnMasterKeyStoreProviderNameParameter left, ColumnMasterKeyStoreProviderNameParameter right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ColumnMasterKeyStoreProviderNameParameter left, ColumnMasterKeyStoreProviderNameParameter right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ColumnMasterKeyStoreProviderNameParameter FromMutable(ScriptDom.ColumnMasterKeyStoreProviderNameParameter fragment) {
            return (ColumnMasterKeyStoreProviderNameParameter)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
