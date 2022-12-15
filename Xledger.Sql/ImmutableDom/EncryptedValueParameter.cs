using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EncryptedValueParameter : ColumnEncryptionKeyValueParameter, IEquatable<EncryptedValueParameter> {
        protected BinaryLiteral @value;
    
        public BinaryLiteral Value => @value;
    
        public EncryptedValueParameter(BinaryLiteral @value = null, ScriptDom.ColumnEncryptionKeyValueParameterKind parameterKind = ScriptDom.ColumnEncryptionKeyValueParameterKind.ColumnMasterKeyName) {
            this.@value = @value;
            this.parameterKind = parameterKind;
        }
    
        public ScriptDom.EncryptedValueParameter ToMutableConcrete() {
            var ret = new ScriptDom.EncryptedValueParameter();
            ret.Value = (ScriptDom.BinaryLiteral)@value.ToMutable();
            ret.ParameterKind = parameterKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + parameterKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EncryptedValueParameter);
        } 
        
        public bool Equals(EncryptedValueParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BinaryLiteral>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ColumnEncryptionKeyValueParameterKind>.Default.Equals(other.ParameterKind, parameterKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EncryptedValueParameter left, EncryptedValueParameter right) {
            return EqualityComparer<EncryptedValueParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EncryptedValueParameter left, EncryptedValueParameter right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (EncryptedValueParameter)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameterKind, othr.parameterKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (EncryptedValueParameter left, EncryptedValueParameter right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(EncryptedValueParameter left, EncryptedValueParameter right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (EncryptedValueParameter left, EncryptedValueParameter right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(EncryptedValueParameter left, EncryptedValueParameter right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
