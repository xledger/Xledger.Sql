using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WitnessDatabaseOption : DatabaseOption, IEquatable<WitnessDatabaseOption> {
        protected Literal witnessServer;
        protected bool isOff = false;
    
        public Literal WitnessServer => witnessServer;
        public bool IsOff => isOff;
    
        public WitnessDatabaseOption(Literal witnessServer = null, bool isOff = false, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.witnessServer = witnessServer;
            this.isOff = isOff;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.WitnessDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.WitnessDatabaseOption();
            ret.WitnessServer = (ScriptDom.Literal)witnessServer?.ToMutable();
            ret.IsOff = isOff;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(witnessServer is null)) {
                h = h * 23 + witnessServer.GetHashCode();
            }
            h = h * 23 + isOff.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WitnessDatabaseOption);
        } 
        
        public bool Equals(WitnessDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.WitnessServer, witnessServer)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsOff, isOff)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WitnessDatabaseOption left, WitnessDatabaseOption right) {
            return EqualityComparer<WitnessDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WitnessDatabaseOption left, WitnessDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (WitnessDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.witnessServer, othr.witnessServer);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isOff, othr.isOff);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (WitnessDatabaseOption left, WitnessDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(WitnessDatabaseOption left, WitnessDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (WitnessDatabaseOption left, WitnessDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(WitnessDatabaseOption left, WitnessDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static WitnessDatabaseOption FromMutable(ScriptDom.WitnessDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.WitnessDatabaseOption)) { throw new NotImplementedException("Unexpected subtype of WitnessDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WitnessDatabaseOption(
                witnessServer: ImmutableDom.Literal.FromMutable(fragment.WitnessServer),
                isOff: fragment.IsOff,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
