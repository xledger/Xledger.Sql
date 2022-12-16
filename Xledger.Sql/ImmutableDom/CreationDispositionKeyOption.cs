using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreationDispositionKeyOption : KeyOption, IEquatable<CreationDispositionKeyOption> {
        protected bool isCreateNew = false;
    
        public bool IsCreateNew => isCreateNew;
    
        public CreationDispositionKeyOption(bool isCreateNew = false, ScriptDom.KeyOptionKind optionKind = ScriptDom.KeyOptionKind.KeySource) {
            this.isCreateNew = isCreateNew;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.CreationDispositionKeyOption ToMutableConcrete() {
            var ret = new ScriptDom.CreationDispositionKeyOption();
            ret.IsCreateNew = isCreateNew;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isCreateNew.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreationDispositionKeyOption);
        } 
        
        public bool Equals(CreationDispositionKeyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsCreateNew, isCreateNew)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.KeyOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreationDispositionKeyOption left, CreationDispositionKeyOption right) {
            return EqualityComparer<CreationDispositionKeyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreationDispositionKeyOption left, CreationDispositionKeyOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreationDispositionKeyOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.isCreateNew, othr.isCreateNew);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreationDispositionKeyOption left, CreationDispositionKeyOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreationDispositionKeyOption left, CreationDispositionKeyOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreationDispositionKeyOption left, CreationDispositionKeyOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreationDispositionKeyOption left, CreationDispositionKeyOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
