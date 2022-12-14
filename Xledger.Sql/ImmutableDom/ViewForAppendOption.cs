using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ViewForAppendOption : ViewOption, IEquatable<ViewForAppendOption> {
        public ViewForAppendOption(ScriptDom.ViewOptionKind optionKind = ScriptDom.ViewOptionKind.Encryption) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ViewForAppendOption ToMutableConcrete() {
            var ret = new ScriptDom.ViewForAppendOption();
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
            return Equals(obj as ViewForAppendOption);
        } 
        
        public bool Equals(ViewForAppendOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ViewOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ViewForAppendOption left, ViewForAppendOption right) {
            return EqualityComparer<ViewForAppendOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ViewForAppendOption left, ViewForAppendOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ViewForAppendOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static ViewForAppendOption FromMutable(ScriptDom.ViewForAppendOption fragment) {
            return (ViewForAppendOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
