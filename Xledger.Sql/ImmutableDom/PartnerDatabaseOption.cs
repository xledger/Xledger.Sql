using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PartnerDatabaseOption : DatabaseOption, IEquatable<PartnerDatabaseOption> {
        protected Literal partnerServer;
        protected ScriptDom.PartnerDatabaseOptionKind partnerOption = ScriptDom.PartnerDatabaseOptionKind.None;
        protected Literal timeout;
    
        public Literal PartnerServer => partnerServer;
        public ScriptDom.PartnerDatabaseOptionKind PartnerOption => partnerOption;
        public Literal Timeout => timeout;
    
        public PartnerDatabaseOption(Literal partnerServer = null, ScriptDom.PartnerDatabaseOptionKind partnerOption = ScriptDom.PartnerDatabaseOptionKind.None, Literal timeout = null, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.partnerServer = partnerServer;
            this.partnerOption = partnerOption;
            this.timeout = timeout;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.PartnerDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.PartnerDatabaseOption();
            ret.PartnerServer = (ScriptDom.Literal)partnerServer?.ToMutable();
            ret.PartnerOption = partnerOption;
            ret.Timeout = (ScriptDom.Literal)timeout?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(partnerServer is null)) {
                h = h * 23 + partnerServer.GetHashCode();
            }
            h = h * 23 + partnerOption.GetHashCode();
            if (!(timeout is null)) {
                h = h * 23 + timeout.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PartnerDatabaseOption);
        } 
        
        public bool Equals(PartnerDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.PartnerServer, partnerServer)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PartnerDatabaseOptionKind>.Default.Equals(other.PartnerOption, partnerOption)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Timeout, timeout)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PartnerDatabaseOption left, PartnerDatabaseOption right) {
            return EqualityComparer<PartnerDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PartnerDatabaseOption left, PartnerDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (PartnerDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.partnerServer, othr.partnerServer);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.partnerOption, othr.partnerOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.timeout, othr.timeout);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (PartnerDatabaseOption left, PartnerDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(PartnerDatabaseOption left, PartnerDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (PartnerDatabaseOption left, PartnerDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(PartnerDatabaseOption left, PartnerDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static PartnerDatabaseOption FromMutable(ScriptDom.PartnerDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.PartnerDatabaseOption)) { throw new NotImplementedException("Unexpected subtype of PartnerDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PartnerDatabaseOption(
                partnerServer: ImmutableDom.Literal.FromMutable(fragment.PartnerServer),
                partnerOption: fragment.PartnerOption,
                timeout: ImmutableDom.Literal.FromMutable(fragment.Timeout),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
