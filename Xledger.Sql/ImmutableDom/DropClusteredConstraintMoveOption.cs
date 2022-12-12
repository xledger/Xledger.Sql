using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropClusteredConstraintMoveOption : DropClusteredConstraintOption, IEquatable<DropClusteredConstraintMoveOption> {
        FileGroupOrPartitionScheme optionValue;
    
        public FileGroupOrPartitionScheme OptionValue => optionValue;
    
        public DropClusteredConstraintMoveOption(FileGroupOrPartitionScheme optionValue = null, ScriptDom.DropClusteredConstraintOptionKind optionKind = ScriptDom.DropClusteredConstraintOptionKind.MaxDop) {
            this.optionValue = optionValue;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.DropClusteredConstraintMoveOption ToMutableConcrete() {
            var ret = new ScriptDom.DropClusteredConstraintMoveOption();
            ret.OptionValue = (ScriptDom.FileGroupOrPartitionScheme)optionValue.ToMutable();
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
    
    }

}
