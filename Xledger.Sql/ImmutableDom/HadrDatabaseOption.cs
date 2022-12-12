using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class HadrDatabaseOption : DatabaseOption, IEquatable<HadrDatabaseOption> {
        ScriptDom.HadrDatabaseOptionKind hadrOption = ScriptDom.HadrDatabaseOptionKind.Suspend;
    
        public ScriptDom.HadrDatabaseOptionKind HadrOption => hadrOption;
    
        public HadrDatabaseOption(ScriptDom.HadrDatabaseOptionKind hadrOption = ScriptDom.HadrDatabaseOptionKind.Suspend, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.hadrOption = hadrOption;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.HadrDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.HadrDatabaseOption();
            ret.HadrOption = hadrOption;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + hadrOption.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as HadrDatabaseOption);
        } 
        
        public bool Equals(HadrDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.HadrDatabaseOptionKind>.Default.Equals(other.HadrOption, hadrOption)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(HadrDatabaseOption left, HadrDatabaseOption right) {
            return EqualityComparer<HadrDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(HadrDatabaseOption left, HadrDatabaseOption right) {
            return !(left == right);
        }
    
    }

}