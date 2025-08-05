using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetIdentityInsertStatement : SetOnOffStatement, IEquatable<SetIdentityInsertStatement> {
        protected SchemaObjectName table;
    
        public SchemaObjectName Table => table;
    
        public SetIdentityInsertStatement(SchemaObjectName table = null, bool isOn = false) {
            this.table = table;
            this.isOn = isOn;
        }
    
        public ScriptDom.SetIdentityInsertStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetIdentityInsertStatement();
            ret.Table = (ScriptDom.SchemaObjectName)table?.ToMutable();
            ret.IsOn = isOn;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(table is null)) {
                h = h * 23 + table.GetHashCode();
            }
            h = h * 23 + isOn.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetIdentityInsertStatement);
        } 
        
        public bool Equals(SetIdentityInsertStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Table, table)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsOn, isOn)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetIdentityInsertStatement left, SetIdentityInsertStatement right) {
            return EqualityComparer<SetIdentityInsertStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetIdentityInsertStatement left, SetIdentityInsertStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SetIdentityInsertStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.table, othr.table);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isOn, othr.isOn);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SetIdentityInsertStatement left, SetIdentityInsertStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SetIdentityInsertStatement left, SetIdentityInsertStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SetIdentityInsertStatement left, SetIdentityInsertStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SetIdentityInsertStatement left, SetIdentityInsertStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SetIdentityInsertStatement FromMutable(ScriptDom.SetIdentityInsertStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SetIdentityInsertStatement)) { throw new NotImplementedException("Unexpected subtype of SetIdentityInsertStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetIdentityInsertStatement(
                table: ImmutableDom.SchemaObjectName.FromMutable(fragment.Table),
                isOn: fragment.IsOn
            );
        }
    
    }

}
