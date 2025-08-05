using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MaxSizeAuditTargetOption : AuditTargetOption, IEquatable<MaxSizeAuditTargetOption> {
        protected bool isUnlimited = false;
        protected Literal size;
        protected ScriptDom.MemoryUnit unit = ScriptDom.MemoryUnit.Unspecified;
    
        public bool IsUnlimited => isUnlimited;
        public Literal Size => size;
        public ScriptDom.MemoryUnit Unit => unit;
    
        public MaxSizeAuditTargetOption(bool isUnlimited = false, Literal size = null, ScriptDom.MemoryUnit unit = ScriptDom.MemoryUnit.Unspecified, ScriptDom.AuditTargetOptionKind optionKind = ScriptDom.AuditTargetOptionKind.MaxRolloverFiles) {
            this.isUnlimited = isUnlimited;
            this.size = size;
            this.unit = unit;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.MaxSizeAuditTargetOption ToMutableConcrete() {
            var ret = new ScriptDom.MaxSizeAuditTargetOption();
            ret.IsUnlimited = isUnlimited;
            ret.Size = (ScriptDom.Literal)size?.ToMutable();
            ret.Unit = unit;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isUnlimited.GetHashCode();
            if (!(size is null)) {
                h = h * 23 + size.GetHashCode();
            }
            h = h * 23 + unit.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MaxSizeAuditTargetOption);
        } 
        
        public bool Equals(MaxSizeAuditTargetOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsUnlimited, isUnlimited)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Size, size)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.MemoryUnit>.Default.Equals(other.Unit, unit)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AuditTargetOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MaxSizeAuditTargetOption left, MaxSizeAuditTargetOption right) {
            return EqualityComparer<MaxSizeAuditTargetOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MaxSizeAuditTargetOption left, MaxSizeAuditTargetOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MaxSizeAuditTargetOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.isUnlimited, othr.isUnlimited);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.size, othr.size);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.unit, othr.unit);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (MaxSizeAuditTargetOption left, MaxSizeAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MaxSizeAuditTargetOption left, MaxSizeAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MaxSizeAuditTargetOption left, MaxSizeAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MaxSizeAuditTargetOption left, MaxSizeAuditTargetOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static MaxSizeAuditTargetOption FromMutable(ScriptDom.MaxSizeAuditTargetOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.MaxSizeAuditTargetOption)) { throw new NotImplementedException("Unexpected subtype of MaxSizeAuditTargetOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MaxSizeAuditTargetOption(
                isUnlimited: fragment.IsUnlimited,
                size: ImmutableDom.Literal.FromMutable(fragment.Size),
                unit: fragment.Unit,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
