using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DbccOption : TSqlFragment, IEquatable<DbccOption> {
        protected ScriptDom.DbccOptionKind optionKind = ScriptDom.DbccOptionKind.AllErrorMessages;
    
        public ScriptDom.DbccOptionKind OptionKind => optionKind;
    
        public DbccOption(ScriptDom.DbccOptionKind optionKind = ScriptDom.DbccOptionKind.AllErrorMessages) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.DbccOption ToMutableConcrete() {
            var ret = new ScriptDom.DbccOption();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DbccOption);
        } 
        
        public bool Equals(DbccOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DbccOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DbccOption left, DbccOption right) {
            return EqualityComparer<DbccOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DbccOption left, DbccOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DbccOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DbccOption left, DbccOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DbccOption left, DbccOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DbccOption left, DbccOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DbccOption left, DbccOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DbccOption FromMutable(ScriptDom.DbccOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DbccOption)) { throw new NotImplementedException("Unexpected subtype of DbccOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DbccOption(
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
