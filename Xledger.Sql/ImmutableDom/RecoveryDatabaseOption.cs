using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RecoveryDatabaseOption : DatabaseOption, IEquatable<RecoveryDatabaseOption> {
        protected ScriptDom.RecoveryDatabaseOptionKind @value = ScriptDom.RecoveryDatabaseOptionKind.None;
    
        public ScriptDom.RecoveryDatabaseOptionKind Value => @value;
    
        public RecoveryDatabaseOption(ScriptDom.RecoveryDatabaseOptionKind @value = ScriptDom.RecoveryDatabaseOptionKind.None, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.RecoveryDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.RecoveryDatabaseOption();
            ret.Value = @value;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + @value.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RecoveryDatabaseOption);
        } 
        
        public bool Equals(RecoveryDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.RecoveryDatabaseOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RecoveryDatabaseOption left, RecoveryDatabaseOption right) {
            return EqualityComparer<RecoveryDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RecoveryDatabaseOption left, RecoveryDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RecoveryDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (RecoveryDatabaseOption left, RecoveryDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(RecoveryDatabaseOption left, RecoveryDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (RecoveryDatabaseOption left, RecoveryDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(RecoveryDatabaseOption left, RecoveryDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static RecoveryDatabaseOption FromMutable(ScriptDom.RecoveryDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.RecoveryDatabaseOption)) { throw new NotImplementedException("Unexpected subtype of RecoveryDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RecoveryDatabaseOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
