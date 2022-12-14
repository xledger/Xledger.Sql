using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SearchPropertyListFullTextIndexOption : FullTextIndexOption, IEquatable<SearchPropertyListFullTextIndexOption> {
        protected bool isOff = false;
        protected Identifier propertyListName;
    
        public bool IsOff => isOff;
        public Identifier PropertyListName => propertyListName;
    
        public SearchPropertyListFullTextIndexOption(bool isOff = false, Identifier propertyListName = null, ScriptDom.FullTextIndexOptionKind optionKind = ScriptDom.FullTextIndexOptionKind.ChangeTracking) {
            this.isOff = isOff;
            this.propertyListName = propertyListName;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.SearchPropertyListFullTextIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.SearchPropertyListFullTextIndexOption();
            ret.IsOff = isOff;
            ret.PropertyListName = (ScriptDom.Identifier)propertyListName?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isOff.GetHashCode();
            if (!(propertyListName is null)) {
                h = h * 23 + propertyListName.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SearchPropertyListFullTextIndexOption);
        } 
        
        public bool Equals(SearchPropertyListFullTextIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsOff, isOff)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.PropertyListName, propertyListName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.FullTextIndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SearchPropertyListFullTextIndexOption left, SearchPropertyListFullTextIndexOption right) {
            return EqualityComparer<SearchPropertyListFullTextIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SearchPropertyListFullTextIndexOption left, SearchPropertyListFullTextIndexOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SearchPropertyListFullTextIndexOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.isOff, othr.isOff);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.propertyListName, othr.propertyListName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SearchPropertyListFullTextIndexOption left, SearchPropertyListFullTextIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SearchPropertyListFullTextIndexOption left, SearchPropertyListFullTextIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SearchPropertyListFullTextIndexOption left, SearchPropertyListFullTextIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SearchPropertyListFullTextIndexOption left, SearchPropertyListFullTextIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SearchPropertyListFullTextIndexOption FromMutable(ScriptDom.SearchPropertyListFullTextIndexOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SearchPropertyListFullTextIndexOption)) { throw new NotImplementedException("Unexpected subtype of SearchPropertyListFullTextIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SearchPropertyListFullTextIndexOption(
                isOff: fragment.IsOff,
                propertyListName: ImmutableDom.Identifier.FromMutable(fragment.PropertyListName),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
