using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AuditTarget : TSqlFragment, IEquatable<AuditTarget> {
        protected ScriptDom.AuditTargetKind targetKind = ScriptDom.AuditTargetKind.File;
        protected IReadOnlyList<AuditTargetOption> targetOptions;
    
        public ScriptDom.AuditTargetKind TargetKind => targetKind;
        public IReadOnlyList<AuditTargetOption> TargetOptions => targetOptions;
    
        public AuditTarget(ScriptDom.AuditTargetKind targetKind = ScriptDom.AuditTargetKind.File, IReadOnlyList<AuditTargetOption> targetOptions = null) {
            this.targetKind = targetKind;
            this.targetOptions = targetOptions.ToImmArray<AuditTargetOption>();
        }
    
        public ScriptDom.AuditTarget ToMutableConcrete() {
            var ret = new ScriptDom.AuditTarget();
            ret.TargetKind = targetKind;
            ret.TargetOptions.AddRange(targetOptions.Select(c => (ScriptDom.AuditTargetOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + targetKind.GetHashCode();
            h = h * 23 + targetOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AuditTarget);
        } 
        
        public bool Equals(AuditTarget other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AuditTargetKind>.Default.Equals(other.TargetKind, targetKind)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<AuditTargetOption>>.Default.Equals(other.TargetOptions, targetOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AuditTarget left, AuditTarget right) {
            return EqualityComparer<AuditTarget>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AuditTarget left, AuditTarget right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AuditTarget)that;
            compare = Comparer.DefaultInvariant.Compare(this.targetKind, othr.targetKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.targetOptions, othr.targetOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AuditTarget left, AuditTarget right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AuditTarget left, AuditTarget right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AuditTarget left, AuditTarget right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AuditTarget left, AuditTarget right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AuditTarget FromMutable(ScriptDom.AuditTarget fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AuditTarget)) { throw new NotImplementedException("Unexpected subtype of AuditTarget not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AuditTarget(
                targetKind: fragment.TargetKind,
                targetOptions: fragment.TargetOptions.ToImmArray(ImmutableDom.AuditTargetOption.FromMutable)
            );
        }
    
    }

}
