using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IndexStateOption : IndexOption, IEquatable<IndexStateOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public IndexStateOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.IndexStateOption ToMutableConcrete() {
            var ret = new ScriptDom.IndexStateOption();
            ret.OptionState = optionState;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IndexStateOption);
        } 
        
        public bool Equals(IndexStateOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.IndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IndexStateOption left, IndexStateOption right) {
            return EqualityComparer<IndexStateOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IndexStateOption left, IndexStateOption right) {
            return !(left == right);
        }
    
        public static IndexStateOption FromMutable(ScriptDom.IndexStateOption fragment) {
            return (IndexStateOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
