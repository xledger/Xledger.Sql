using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CursorOption : TSqlFragment, IEquatable<CursorOption> {
        protected ScriptDom.CursorOptionKind optionKind = ScriptDom.CursorOptionKind.Local;
    
        public ScriptDom.CursorOptionKind OptionKind => optionKind;
    
        public CursorOption(ScriptDom.CursorOptionKind optionKind = ScriptDom.CursorOptionKind.Local) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.CursorOption ToMutableConcrete() {
            var ret = new ScriptDom.CursorOption();
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
            return Equals(obj as CursorOption);
        } 
        
        public bool Equals(CursorOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.CursorOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CursorOption left, CursorOption right) {
            return EqualityComparer<CursorOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CursorOption left, CursorOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CursorOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CursorOption left, CursorOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CursorOption left, CursorOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CursorOption left, CursorOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CursorOption left, CursorOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CursorOption FromMutable(ScriptDom.CursorOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CursorOption)) { throw new NotImplementedException("Unexpected subtype of CursorOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CursorOption(
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
