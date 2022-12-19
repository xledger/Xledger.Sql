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
            ret.Path = (ScriptDom.StringLiteral)path?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ColumnMasterKeyPathParameter)that;
            compare = Comparer.DefaultInvariant.Compare(this.path, othr.path);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameterKind, othr.parameterKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ColumnMasterKeyPathParameter left, ColumnMasterKeyPathParameter right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ColumnMasterKeyPathParameter left, ColumnMasterKeyPathParameter right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ColumnMasterKeyPathParameter left, ColumnMasterKeyPathParameter right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ColumnMasterKeyPathParameter left, ColumnMasterKeyPathParameter right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ColumnMasterKeyPathParameter FromMutable(ScriptDom.ColumnMasterKeyPathParameter fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ColumnMasterKeyPathParameter)) { throw new NotImplementedException("Unexpected subtype of ColumnMasterKeyPathParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnMasterKeyPathParameter(
                path: ImmutableDom.StringLiteral.FromMutable(fragment.Path),
                parameterKind: fragment.ParameterKind
            );
        }
    
    }

}
