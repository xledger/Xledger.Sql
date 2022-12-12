using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MoveToDropIndexOption : IndexOption, IEquatable<MoveToDropIndexOption> {
        FileGroupOrPartitionScheme moveTo;
    
        public FileGroupOrPartitionScheme MoveTo => moveTo;
    
        public MoveToDropIndexOption(FileGroupOrPartitionScheme moveTo = null, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.moveTo = moveTo;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.MoveToDropIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.MoveToDropIndexOption();
            ret.MoveTo = (ScriptDom.FileGroupOrPartitionScheme)moveTo.ToMutable();
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
    
    }

}
