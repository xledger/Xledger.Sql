using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DatabaseConfigurationSetOption : TSqlFragment, IEquatable<DatabaseConfigurationSetOption> {
        protected ScriptDom.DatabaseConfigSetOptionKind optionKind = ScriptDom.DatabaseConfigSetOptionKind.MaxDop;
        protected Identifier genericOptionKind;
    
        public ScriptDom.DatabaseConfigSetOptionKind OptionKind => optionKind;
        public Identifier GenericOptionKind => genericOptionKind;
    
        public DatabaseConfigurationSetOption(ScriptDom.DatabaseConfigSetOptionKind optionKind = ScriptDom.DatabaseConfigSetOptionKind.MaxDop, Identifier genericOptionKind = null) {
            this.optionKind = optionKind;
            this.genericOptionKind = genericOptionKind;
        }
    
        public ScriptDom.DatabaseConfigurationSetOption ToMutableConcrete() {
            var ret = new ScriptDom.DatabaseConfigurationSetOption();
            ret.OptionKind = optionKind;
            ret.GenericOptionKind = (ScriptDom.Identifier)genericOptionKind?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            if (!(genericOptionKind is null)) {
                h = h * 23 + genericOptionKind.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DatabaseConfigurationSetOption);
        } 
        
        public bool Equals(DatabaseConfigurationSetOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DatabaseConfigSetOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.GenericOptionKind, genericOptionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DatabaseConfigurationSetOption left, DatabaseConfigurationSetOption right) {
            return EqualityComparer<DatabaseConfigurationSetOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DatabaseConfigurationSetOption left, DatabaseConfigurationSetOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DatabaseConfigurationSetOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.genericOptionKind, othr.genericOptionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DatabaseConfigurationSetOption left, DatabaseConfigurationSetOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DatabaseConfigurationSetOption left, DatabaseConfigurationSetOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DatabaseConfigurationSetOption left, DatabaseConfigurationSetOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DatabaseConfigurationSetOption left, DatabaseConfigurationSetOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DatabaseConfigurationSetOption FromMutable(ScriptDom.DatabaseConfigurationSetOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DatabaseConfigurationSetOption)) { return TSqlFragment.FromMutable(fragment) as DatabaseConfigurationSetOption; }
            return new DatabaseConfigurationSetOption(
                optionKind: fragment.OptionKind,
                genericOptionKind: ImmutableDom.Identifier.FromMutable(fragment.GenericOptionKind)
            );
        }
    
    }

}
