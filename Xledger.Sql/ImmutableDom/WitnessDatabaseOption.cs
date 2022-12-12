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
    
        public ScriptDom.WitnessDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.WitnessDatabaseOption();
            ret.WitnessServer = (ScriptDom.Literal)witnessServer.ToMutable();
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
    
    }

}
