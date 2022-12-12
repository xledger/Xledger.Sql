using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnOffFullTextCatalogOption : FullTextCatalogOption, IEquatable<OnOffFullTextCatalogOption> {
        ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public OnOffFullTextCatalogOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.FullTextCatalogOptionKind optionKind = ScriptDom.FullTextCatalogOptionKind.AccentSensitivity) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OnOffFullTextCatalogOption ToMutableConcrete() {
            var ret = new ScriptDom.OnOffFullTextCatalogOption();
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
            return Equals(obj as OnOffFullTextCatalogOption);
        } 
        
        public bool Equals(OnOffFullTextCatalogOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.FullTextCatalogOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnOffFullTextCatalogOption left, OnOffFullTextCatalogOption right) {
            return EqualityComparer<OnOffFullTextCatalogOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnOffFullTextCatalogOption left, OnOffFullTextCatalogOption right) {
            return !(left == right);
        }
    
    }

}