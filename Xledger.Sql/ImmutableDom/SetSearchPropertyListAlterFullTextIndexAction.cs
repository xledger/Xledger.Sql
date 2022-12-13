using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetSearchPropertyListAlterFullTextIndexAction : AlterFullTextIndexAction, IEquatable<SetSearchPropertyListAlterFullTextIndexAction> {
        protected SearchPropertyListFullTextIndexOption searchPropertyListOption;
        protected bool withNoPopulation = false;
    
        public SearchPropertyListFullTextIndexOption SearchPropertyListOption => searchPropertyListOption;
        public bool WithNoPopulation => withNoPopulation;
    
        public SetSearchPropertyListAlterFullTextIndexAction(SearchPropertyListFullTextIndexOption searchPropertyListOption = null, bool withNoPopulation = false) {
            this.searchPropertyListOption = searchPropertyListOption;
            this.withNoPopulation = withNoPopulation;
        }
    
        public ScriptDom.SetSearchPropertyListAlterFullTextIndexAction ToMutableConcrete() {
            var ret = new ScriptDom.SetSearchPropertyListAlterFullTextIndexAction();
            ret.SearchPropertyListOption = (ScriptDom.SearchPropertyListFullTextIndexOption)searchPropertyListOption.ToMutable();
            ret.WithNoPopulation = withNoPopulation;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(searchPropertyListOption is null)) {
                h = h * 23 + searchPropertyListOption.GetHashCode();
            }
            h = h * 23 + withNoPopulation.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetSearchPropertyListAlterFullTextIndexAction);
        } 
        
        public bool Equals(SetSearchPropertyListAlterFullTextIndexAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SearchPropertyListFullTextIndexOption>.Default.Equals(other.SearchPropertyListOption, searchPropertyListOption)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithNoPopulation, withNoPopulation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetSearchPropertyListAlterFullTextIndexAction left, SetSearchPropertyListAlterFullTextIndexAction right) {
            return EqualityComparer<SetSearchPropertyListAlterFullTextIndexAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetSearchPropertyListAlterFullTextIndexAction left, SetSearchPropertyListAlterFullTextIndexAction right) {
            return !(left == right);
        }
    
        public static SetSearchPropertyListAlterFullTextIndexAction FromMutable(ScriptDom.SetSearchPropertyListAlterFullTextIndexAction fragment) {
            return (SetSearchPropertyListAlterFullTextIndexAction)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
