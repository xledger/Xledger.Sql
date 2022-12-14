using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ParameterizationDatabaseOption : DatabaseOption, IEquatable<ParameterizationDatabaseOption> {
        protected bool isSimple = false;
    
        public bool IsSimple => isSimple;
    
        public ParameterizationDatabaseOption(bool isSimple = false, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.isSimple = isSimple;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ParameterizationDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.ParameterizationDatabaseOption();
            ret.IsSimple = isSimple;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isSimple.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ParameterizationDatabaseOption);
        } 
        
        public bool Equals(ParameterizationDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsSimple, isSimple)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ParameterizationDatabaseOption left, ParameterizationDatabaseOption right) {
            return EqualityComparer<ParameterizationDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ParameterizationDatabaseOption left, ParameterizationDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ParameterizationDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.isSimple, othr.isSimple);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ParameterizationDatabaseOption left, ParameterizationDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ParameterizationDatabaseOption left, ParameterizationDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ParameterizationDatabaseOption left, ParameterizationDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ParameterizationDatabaseOption left, ParameterizationDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ParameterizationDatabaseOption FromMutable(ScriptDom.ParameterizationDatabaseOption fragment) {
            return (ParameterizationDatabaseOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
