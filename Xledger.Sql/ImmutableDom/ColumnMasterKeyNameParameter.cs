using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnMasterKeyNameParameter : ColumnEncryptionKeyValueParameter, IEquatable<ColumnMasterKeyNameParameter> {
        protected Identifier name;
    
        public Identifier Name => name;
    
        public ColumnMasterKeyNameParameter(Identifier name = null, ScriptDom.ColumnEncryptionKeyValueParameterKind parameterKind = ScriptDom.ColumnEncryptionKeyValueParameterKind.ColumnMasterKeyName) {
            this.name = name;
            this.parameterKind = parameterKind;
        }
    
        public ScriptDom.ColumnMasterKeyNameParameter ToMutableConcrete() {
            var ret = new ScriptDom.ColumnMasterKeyNameParameter();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
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
            return Equals(obj as ColumnMasterKeyNameParameter);
        } 
        
        public bool Equals(ColumnMasterKeyNameParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ColumnEncryptionKeyValueParameterKind>.Default.Equals(other.ParameterKind, parameterKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnMasterKeyNameParameter left, ColumnMasterKeyNameParameter right) {
            return EqualityComparer<ColumnMasterKeyNameParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnMasterKeyNameParameter left, ColumnMasterKeyNameParameter right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ColumnMasterKeyNameParameter)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameterKind, othr.parameterKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ColumnMasterKeyNameParameter left, ColumnMasterKeyNameParameter right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ColumnMasterKeyNameParameter left, ColumnMasterKeyNameParameter right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ColumnMasterKeyNameParameter left, ColumnMasterKeyNameParameter right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ColumnMasterKeyNameParameter left, ColumnMasterKeyNameParameter right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
