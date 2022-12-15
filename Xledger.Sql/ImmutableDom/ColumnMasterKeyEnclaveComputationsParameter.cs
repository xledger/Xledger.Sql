using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnMasterKeyEnclaveComputationsParameter : ColumnMasterKeyParameter, IEquatable<ColumnMasterKeyEnclaveComputationsParameter> {
        protected BinaryLiteral signature;
    
        public BinaryLiteral Signature => signature;
    
        public ColumnMasterKeyEnclaveComputationsParameter(BinaryLiteral signature = null, ScriptDom.ColumnMasterKeyParameterKind parameterKind = ScriptDom.ColumnMasterKeyParameterKind.KeyStoreProviderName) {
            this.signature = signature;
            this.parameterKind = parameterKind;
        }
    
        public ScriptDom.ColumnMasterKeyEnclaveComputationsParameter ToMutableConcrete() {
            var ret = new ScriptDom.ColumnMasterKeyEnclaveComputationsParameter();
            ret.Signature = (ScriptDom.BinaryLiteral)signature.ToMutable();
            ret.ParameterKind = parameterKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(signature is null)) {
                h = h * 23 + signature.GetHashCode();
            }
            h = h * 23 + parameterKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnMasterKeyEnclaveComputationsParameter);
        } 
        
        public bool Equals(ColumnMasterKeyEnclaveComputationsParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BinaryLiteral>.Default.Equals(other.Signature, signature)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ColumnMasterKeyParameterKind>.Default.Equals(other.ParameterKind, parameterKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnMasterKeyEnclaveComputationsParameter left, ColumnMasterKeyEnclaveComputationsParameter right) {
            return EqualityComparer<ColumnMasterKeyEnclaveComputationsParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnMasterKeyEnclaveComputationsParameter left, ColumnMasterKeyEnclaveComputationsParameter right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ColumnMasterKeyEnclaveComputationsParameter)that;
            compare = Comparer.DefaultInvariant.Compare(this.signature, othr.signature);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameterKind, othr.parameterKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ColumnMasterKeyEnclaveComputationsParameter left, ColumnMasterKeyEnclaveComputationsParameter right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ColumnMasterKeyEnclaveComputationsParameter left, ColumnMasterKeyEnclaveComputationsParameter right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ColumnMasterKeyEnclaveComputationsParameter left, ColumnMasterKeyEnclaveComputationsParameter right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ColumnMasterKeyEnclaveComputationsParameter left, ColumnMasterKeyEnclaveComputationsParameter right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
