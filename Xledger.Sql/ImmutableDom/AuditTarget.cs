using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AuditTarget : TSqlFragment, IEquatable<AuditTarget> {
        protected ScriptDom.AuditTargetKind targetKind = ScriptDom.AuditTargetKind.File;
        protected IReadOnlyList<AuditTargetOption> targetOptions;
    
        public ScriptDom.AuditTargetKind TargetKind => targetKind;
        public IReadOnlyList<AuditTargetOption> TargetOptions => targetOptions;
    
        public AuditTarget(ScriptDom.AuditTargetKind targetKind = ScriptDom.AuditTargetKind.File, IReadOnlyList<AuditTargetOption> targetOptions = null) {
            this.targetKind = targetKind;
            this.targetOptions = targetOptions is null ? ImmList<AuditTargetOption>.Empty : ImmList<AuditTargetOption>.FromList(targetOptions);
        }
    
        public ScriptDom.AuditTarget ToMutableConcrete() {
            var ret = new ScriptDom.AuditTarget();
            ret.TargetKind = targetKind;
            ret.TargetOptions.AddRange(targetOptions.SelectList(c => (ScriptDom.AuditTargetOption)c.ToMutable()));
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
    
        public static AuditTarget FromMutable(ScriptDom.AuditTarget fragment) {
            return (AuditTarget)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
