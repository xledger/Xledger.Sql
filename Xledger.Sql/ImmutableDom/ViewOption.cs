using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ViewOption : TSqlFragment, IEquatable<ViewOption> {
        protected ScriptDom.ViewOptionKind optionKind = ScriptDom.ViewOptionKind.Encryption;
    
        public ScriptDom.ViewOptionKind OptionKind => optionKind;
    
        public ViewOption(ScriptDom.ViewOptionKind optionKind = ScriptDom.ViewOptionKind.Encryption) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ViewOption ToMutableConcrete() {
            var ret = new ScriptDom.ViewOption();
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
            return Equals(obj as ViewOption);
        } 
        
        public bool Equals(ViewOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ViewOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ViewOption left, ViewOption right) {
            return EqualityComparer<ViewOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ViewOption left, ViewOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ViewOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ViewOption left, ViewOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ViewOption left, ViewOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ViewOption left, ViewOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ViewOption left, ViewOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ViewOption FromMutable(ScriptDom.ViewOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ViewOption)) { return TSqlFragment.FromMutable(fragment) as ViewOption; }
            return new ViewOption(
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
