using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LedgerTableOption : TableOption, IEquatable<LedgerTableOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
        protected ScriptDom.OptionState appendOnly = ScriptDom.OptionState.NotSet;
        protected LedgerViewOption ledgerViewOption;
    
        public ScriptDom.OptionState OptionState => optionState;
        public ScriptDom.OptionState AppendOnly => appendOnly;
        public LedgerViewOption LedgerViewOption => ledgerViewOption;
    
        public LedgerTableOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.OptionState appendOnly = ScriptDom.OptionState.NotSet, LedgerViewOption ledgerViewOption = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.optionState = optionState;
            this.appendOnly = appendOnly;
            this.ledgerViewOption = ledgerViewOption;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LedgerTableOption ToMutableConcrete() {
            var ret = new ScriptDom.LedgerTableOption();
            ret.OptionState = optionState;
            ret.AppendOnly = appendOnly;
            ret.LedgerViewOption = (ScriptDom.LedgerViewOption)ledgerViewOption?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + appendOnly.GetHashCode();
            if (!(ledgerViewOption is null)) {
                h = h * 23 + ledgerViewOption.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LedgerTableOption);
        } 
        
        public bool Equals(LedgerTableOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.AppendOnly, appendOnly)) {
                return false;
            }
            if (!EqualityComparer<LedgerViewOption>.Default.Equals(other.LedgerViewOption, ledgerViewOption)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LedgerTableOption left, LedgerTableOption right) {
            return EqualityComparer<LedgerTableOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LedgerTableOption left, LedgerTableOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LedgerTableOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.appendOnly, othr.appendOnly);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.ledgerViewOption, othr.ledgerViewOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (LedgerTableOption left, LedgerTableOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(LedgerTableOption left, LedgerTableOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (LedgerTableOption left, LedgerTableOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(LedgerTableOption left, LedgerTableOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
