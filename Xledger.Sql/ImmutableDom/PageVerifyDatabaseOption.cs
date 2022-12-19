using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PageVerifyDatabaseOption : DatabaseOption, IEquatable<PageVerifyDatabaseOption> {
        protected ScriptDom.PageVerifyDatabaseOptionKind @value = ScriptDom.PageVerifyDatabaseOptionKind.None;
    
        public ScriptDom.PageVerifyDatabaseOptionKind Value => @value;
    
        public PageVerifyDatabaseOption(ScriptDom.PageVerifyDatabaseOptionKind @value = ScriptDom.PageVerifyDatabaseOptionKind.None, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.PageVerifyDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.PageVerifyDatabaseOption();
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
            return Equals(obj as PageVerifyDatabaseOption);
        } 
        
        public bool Equals(PageVerifyDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.PageVerifyDatabaseOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PageVerifyDatabaseOption left, PageVerifyDatabaseOption right) {
            return EqualityComparer<PageVerifyDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PageVerifyDatabaseOption left, PageVerifyDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (PageVerifyDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (PageVerifyDatabaseOption left, PageVerifyDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(PageVerifyDatabaseOption left, PageVerifyDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (PageVerifyDatabaseOption left, PageVerifyDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(PageVerifyDatabaseOption left, PageVerifyDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static PageVerifyDatabaseOption FromMutable(ScriptDom.PageVerifyDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.PageVerifyDatabaseOption)) { throw new NotImplementedException("Unexpected subtype of PageVerifyDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PageVerifyDatabaseOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
