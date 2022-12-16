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
            ret.Algorithm = (ScriptDom.StringLiteral)algorithm?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ColumnEncryptionAlgorithmNameParameter)that;
            compare = Comparer.DefaultInvariant.Compare(this.algorithm, othr.algorithm);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameterKind, othr.parameterKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ColumnEncryptionAlgorithmNameParameter left, ColumnEncryptionAlgorithmNameParameter right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ColumnEncryptionAlgorithmNameParameter left, ColumnEncryptionAlgorithmNameParameter right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ColumnEncryptionAlgorithmNameParameter left, ColumnEncryptionAlgorithmNameParameter right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ColumnEncryptionAlgorithmNameParameter left, ColumnEncryptionAlgorithmNameParameter right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
