using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropClusteredConstraintValueOption : DropClusteredConstraintOption, IEquatable<DropClusteredConstraintValueOption> {
        protected Literal optionValue;
    
        public Literal OptionValue => optionValue;
    
        public DropClusteredConstraintValueOption(Literal optionValue = null, ScriptDom.DropClusteredConstraintOptionKind optionKind = ScriptDom.DropClusteredConstraintOptionKind.MaxDop) {
            this.optionValue = optionValue;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.DropClusteredConstraintValueOption ToMutableConcrete() {
            var ret = new ScriptDom.DropClusteredConstraintValueOption();
            ret.OptionValue = (ScriptDom.Literal)optionValue?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(optionValue is null)) {
                h = h * 23 + optionValue.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropClusteredConstraintValueOption);
        } 
        
        public bool Equals(DropClusteredConstraintValueOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DropClusteredConstraintOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropClusteredConstraintValueOption left, DropClusteredConstraintValueOption right) {
            return EqualityComparer<DropClusteredConstraintValueOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropClusteredConstraintValueOption left, DropClusteredConstraintValueOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropClusteredConstraintValueOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionValue, othr.optionValue);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (DropClusteredConstraintValueOption left, DropClusteredConstraintValueOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropClusteredConstraintValueOption left, DropClusteredConstraintValueOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropClusteredConstraintValueOption left, DropClusteredConstraintValueOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropClusteredConstraintValueOption left, DropClusteredConstraintValueOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
