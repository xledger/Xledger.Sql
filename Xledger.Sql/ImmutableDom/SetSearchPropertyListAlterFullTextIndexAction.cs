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
            ret.SearchPropertyListOption = (ScriptDom.SearchPropertyListFullTextIndexOption)searchPropertyListOption?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SetSearchPropertyListAlterFullTextIndexAction)that;
            compare = Comparer.DefaultInvariant.Compare(this.searchPropertyListOption, othr.searchPropertyListOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withNoPopulation, othr.withNoPopulation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SetSearchPropertyListAlterFullTextIndexAction left, SetSearchPropertyListAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SetSearchPropertyListAlterFullTextIndexAction left, SetSearchPropertyListAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SetSearchPropertyListAlterFullTextIndexAction left, SetSearchPropertyListAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SetSearchPropertyListAlterFullTextIndexAction left, SetSearchPropertyListAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SetSearchPropertyListAlterFullTextIndexAction FromMutable(ScriptDom.SetSearchPropertyListAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SetSearchPropertyListAlterFullTextIndexAction)) { throw new NotImplementedException("Unexpected subtype of SetSearchPropertyListAlterFullTextIndexAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetSearchPropertyListAlterFullTextIndexAction(
                searchPropertyListOption: ImmutableDom.SearchPropertyListFullTextIndexOption.FromMutable(fragment.SearchPropertyListOption),
                withNoPopulation: fragment.WithNoPopulation
            );
        }
    
    }

}
