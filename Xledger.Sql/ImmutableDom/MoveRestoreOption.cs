using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MoveRestoreOption : RestoreOption, IEquatable<MoveRestoreOption> {
        protected ValueExpression logicalFileName;
        protected ValueExpression oSFileName;
    
        public ValueExpression LogicalFileName => logicalFileName;
        public ValueExpression OSFileName => oSFileName;
    
        public MoveRestoreOption(ValueExpression logicalFileName = null, ValueExpression oSFileName = null, ScriptDom.RestoreOptionKind optionKind = 0) {
            this.logicalFileName = logicalFileName;
            this.oSFileName = oSFileName;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.MoveRestoreOption ToMutableConcrete() {
            var ret = new ScriptDom.MoveRestoreOption();
            ret.LogicalFileName = (ScriptDom.ValueExpression)logicalFileName.ToMutable();
            ret.OSFileName = (ScriptDom.ValueExpression)oSFileName.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(logicalFileName is null)) {
                h = h * 23 + logicalFileName.GetHashCode();
            }
            if (!(oSFileName is null)) {
                h = h * 23 + oSFileName.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MoveRestoreOption);
        } 
        
        public bool Equals(MoveRestoreOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.LogicalFileName, logicalFileName)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.OSFileName, oSFileName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.RestoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MoveRestoreOption left, MoveRestoreOption right) {
            return EqualityComparer<MoveRestoreOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MoveRestoreOption left, MoveRestoreOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MoveRestoreOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.logicalFileName, othr.logicalFileName);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.oSFileName, othr.oSFileName);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static MoveRestoreOption FromMutable(ScriptDom.MoveRestoreOption fragment) {
            return (MoveRestoreOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
