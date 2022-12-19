using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterColumnEncryptionKeyStatement : ColumnEncryptionKeyStatement, IEquatable<AlterColumnEncryptionKeyStatement> {
        protected ScriptDom.ColumnEncryptionKeyAlterType alterType = ScriptDom.ColumnEncryptionKeyAlterType.Add;
    
        public ScriptDom.ColumnEncryptionKeyAlterType AlterType => alterType;
    
        public AlterColumnEncryptionKeyStatement(ScriptDom.ColumnEncryptionKeyAlterType alterType = ScriptDom.ColumnEncryptionKeyAlterType.Add, Identifier name = null, IReadOnlyList<ColumnEncryptionKeyValue> columnEncryptionKeyValues = null) {
            this.alterType = alterType;
            this.name = name;
            this.columnEncryptionKeyValues = ImmList<ColumnEncryptionKeyValue>.FromList(columnEncryptionKeyValues);
        }
    
        public ScriptDom.AlterColumnEncryptionKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterColumnEncryptionKeyStatement();
            ret.AlterType = alterType;
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.ColumnEncryptionKeyValues.AddRange(columnEncryptionKeyValues.SelectList(c => (ScriptDom.ColumnEncryptionKeyValue)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + alterType.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + columnEncryptionKeyValues.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterColumnEncryptionKeyStatement);
        } 
        
        public bool Equals(AlterColumnEncryptionKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ColumnEncryptionKeyAlterType>.Default.Equals(other.AlterType, alterType)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnEncryptionKeyValue>>.Default.Equals(other.ColumnEncryptionKeyValues, columnEncryptionKeyValues)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterColumnEncryptionKeyStatement left, AlterColumnEncryptionKeyStatement right) {
            return EqualityComparer<AlterColumnEncryptionKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterColumnEncryptionKeyStatement left, AlterColumnEncryptionKeyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterColumnEncryptionKeyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.alterType, othr.alterType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columnEncryptionKeyValues, othr.columnEncryptionKeyValues);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterColumnEncryptionKeyStatement left, AlterColumnEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterColumnEncryptionKeyStatement left, AlterColumnEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterColumnEncryptionKeyStatement left, AlterColumnEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterColumnEncryptionKeyStatement left, AlterColumnEncryptionKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterColumnEncryptionKeyStatement FromMutable(ScriptDom.AlterColumnEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterColumnEncryptionKeyStatement)) { throw new NotImplementedException("Unexpected subtype of AlterColumnEncryptionKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterColumnEncryptionKeyStatement(
                alterType: fragment.AlterType,
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                columnEncryptionKeyValues: fragment.ColumnEncryptionKeyValues.SelectList(ImmutableDom.ColumnEncryptionKeyValue.FromMutable)
            );
        }
    
    }

}
