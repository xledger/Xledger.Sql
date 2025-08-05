using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MoveToDropIndexOption : IndexOption, IEquatable<MoveToDropIndexOption> {
        protected FileGroupOrPartitionScheme moveTo;
    
        public FileGroupOrPartitionScheme MoveTo => moveTo;
    
        public MoveToDropIndexOption(FileGroupOrPartitionScheme moveTo = null, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.moveTo = moveTo;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.MoveToDropIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.MoveToDropIndexOption();
            ret.MoveTo = (ScriptDom.FileGroupOrPartitionScheme)moveTo?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(moveTo is null)) {
                h = h * 23 + moveTo.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MoveToDropIndexOption);
        } 
        
        public bool Equals(MoveToDropIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<FileGroupOrPartitionScheme>.Default.Equals(other.MoveTo, moveTo)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.IndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MoveToDropIndexOption left, MoveToDropIndexOption right) {
            return EqualityComparer<MoveToDropIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MoveToDropIndexOption left, MoveToDropIndexOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MoveToDropIndexOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.moveTo, othr.moveTo);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (MoveToDropIndexOption left, MoveToDropIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MoveToDropIndexOption left, MoveToDropIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MoveToDropIndexOption left, MoveToDropIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MoveToDropIndexOption left, MoveToDropIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static MoveToDropIndexOption FromMutable(ScriptDom.MoveToDropIndexOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.MoveToDropIndexOption)) { throw new NotImplementedException("Unexpected subtype of MoveToDropIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MoveToDropIndexOption(
                moveTo: ImmutableDom.FileGroupOrPartitionScheme.FromMutable(fragment.MoveTo),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
