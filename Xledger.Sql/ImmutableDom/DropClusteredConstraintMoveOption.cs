using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropClusteredConstraintMoveOption : DropClusteredConstraintOption, IEquatable<DropClusteredConstraintMoveOption> {
        protected FileGroupOrPartitionScheme optionValue;
    
        public FileGroupOrPartitionScheme OptionValue => optionValue;
    
        public DropClusteredConstraintMoveOption(FileGroupOrPartitionScheme optionValue = null, ScriptDom.DropClusteredConstraintOptionKind optionKind = ScriptDom.DropClusteredConstraintOptionKind.MaxDop) {
            this.optionValue = optionValue;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.DropClusteredConstraintMoveOption ToMutableConcrete() {
            var ret = new ScriptDom.DropClusteredConstraintMoveOption();
            ret.OptionValue = (ScriptDom.FileGroupOrPartitionScheme)optionValue?.ToMutable();
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
            return Equals(obj as DropClusteredConstraintMoveOption);
        } 
        
        public bool Equals(DropClusteredConstraintMoveOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<FileGroupOrPartitionScheme>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DropClusteredConstraintOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropClusteredConstraintMoveOption left, DropClusteredConstraintMoveOption right) {
            return EqualityComparer<DropClusteredConstraintMoveOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropClusteredConstraintMoveOption left, DropClusteredConstraintMoveOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropClusteredConstraintMoveOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionValue, othr.optionValue);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropClusteredConstraintMoveOption left, DropClusteredConstraintMoveOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropClusteredConstraintMoveOption left, DropClusteredConstraintMoveOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropClusteredConstraintMoveOption left, DropClusteredConstraintMoveOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropClusteredConstraintMoveOption left, DropClusteredConstraintMoveOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropClusteredConstraintMoveOption FromMutable(ScriptDom.DropClusteredConstraintMoveOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropClusteredConstraintMoveOption)) { throw new NotImplementedException("Unexpected subtype of DropClusteredConstraintMoveOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropClusteredConstraintMoveOption(
                optionValue: ImmutableDom.FileGroupOrPartitionScheme.FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
