using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FullTextStopListAction : TSqlFragment, IEquatable<FullTextStopListAction> {
        protected bool isAdd = false;
        protected bool isAll = false;
        protected Literal stopWord;
        protected IdentifierOrValueExpression languageTerm;
    
        public bool IsAdd => isAdd;
        public bool IsAll => isAll;
        public Literal StopWord => stopWord;
        public IdentifierOrValueExpression LanguageTerm => languageTerm;
    
        public FullTextStopListAction(bool isAdd = false, bool isAll = false, Literal stopWord = null, IdentifierOrValueExpression languageTerm = null) {
            this.isAdd = isAdd;
            this.isAll = isAll;
            this.stopWord = stopWord;
            this.languageTerm = languageTerm;
        }
    
        public ScriptDom.FullTextStopListAction ToMutableConcrete() {
            var ret = new ScriptDom.FullTextStopListAction();
            ret.IsAdd = isAdd;
            ret.IsAll = isAll;
            ret.StopWord = (ScriptDom.Literal)stopWord.ToMutable();
            ret.LanguageTerm = (ScriptDom.IdentifierOrValueExpression)languageTerm.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isAdd.GetHashCode();
            h = h * 23 + isAll.GetHashCode();
            if (!(stopWord is null)) {
                h = h * 23 + stopWord.GetHashCode();
            }
            if (!(languageTerm is null)) {
                h = h * 23 + languageTerm.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FullTextStopListAction);
        } 
        
        public bool Equals(FullTextStopListAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsAdd, isAdd)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsAll, isAll)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.StopWord, stopWord)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.LanguageTerm, languageTerm)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FullTextStopListAction left, FullTextStopListAction right) {
            return EqualityComparer<FullTextStopListAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FullTextStopListAction left, FullTextStopListAction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FullTextStopListAction)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.isAdd, othr.isAdd);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.isAll, othr.isAll);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.stopWord, othr.stopWord);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.languageTerm, othr.languageTerm);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static FullTextStopListAction FromMutable(ScriptDom.FullTextStopListAction fragment) {
            return (FullTextStopListAction)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
