using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnEncryptionKeyValue : TSqlFragment, IEquatable<ColumnEncryptionKeyValue> {
        protected IReadOnlyList<ColumnEncryptionKeyValueParameter> parameters;
    
        public IReadOnlyList<ColumnEncryptionKeyValueParameter> Parameters => parameters;
    
        public ColumnEncryptionKeyValue(IReadOnlyList<ColumnEncryptionKeyValueParameter> parameters = null) {
            this.parameters = ImmList<ColumnEncryptionKeyValueParameter>.FromList(parameters);
        }
    
        public ScriptDom.ColumnEncryptionKeyValue ToMutableConcrete() {
            var ret = new ScriptDom.ColumnEncryptionKeyValue();
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ColumnEncryptionKeyValueParameter)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + parameters.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnEncryptionKeyValue);
        } 
        
        public bool Equals(ColumnEncryptionKeyValue other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ColumnEncryptionKeyValueParameter>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnEncryptionKeyValue left, ColumnEncryptionKeyValue right) {
            return EqualityComparer<ColumnEncryptionKeyValue>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnEncryptionKeyValue left, ColumnEncryptionKeyValue right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ColumnEncryptionKeyValue)that;
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ColumnEncryptionKeyValue left, ColumnEncryptionKeyValue right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ColumnEncryptionKeyValue left, ColumnEncryptionKeyValue right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ColumnEncryptionKeyValue left, ColumnEncryptionKeyValue right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ColumnEncryptionKeyValue left, ColumnEncryptionKeyValue right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
