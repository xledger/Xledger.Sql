using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ProcedureOption : TSqlFragment, IEquatable<ProcedureOption> {
        protected ScriptDom.ProcedureOptionKind optionKind = ScriptDom.ProcedureOptionKind.Encryption;
    
        public ScriptDom.ProcedureOptionKind OptionKind => optionKind;
    
        public ProcedureOption(ScriptDom.ProcedureOptionKind optionKind = ScriptDom.ProcedureOptionKind.Encryption) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ProcedureOption ToMutableConcrete() {
            var ret = new ScriptDom.ProcedureOption();
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
            return Equals(obj as ProcedureOption);
        } 
        
        public bool Equals(ProcedureOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ProcedureOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ProcedureOption left, ProcedureOption right) {
            return EqualityComparer<ProcedureOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ProcedureOption left, ProcedureOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ProcedureOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ProcedureOption left, ProcedureOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ProcedureOption left, ProcedureOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ProcedureOption left, ProcedureOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ProcedureOption left, ProcedureOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ProcedureOption FromMutable(ScriptDom.ProcedureOption fragment) {
            return (ProcedureOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
