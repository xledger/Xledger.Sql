using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DurabilityTableOption : TableOption, IEquatable<DurabilityTableOption> {
        ScriptDom.DurabilityTableOptionKind durabilityTableOptionKind = ScriptDom.DurabilityTableOptionKind.SchemaOnly;
    
        public ScriptDom.DurabilityTableOptionKind DurabilityTableOptionKind => durabilityTableOptionKind;
    
        public DurabilityTableOption(ScriptDom.DurabilityTableOptionKind durabilityTableOptionKind = ScriptDom.DurabilityTableOptionKind.SchemaOnly, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.durabilityTableOptionKind = durabilityTableOptionKind;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.DurabilityTableOption ToMutableConcrete() {
            var ret = new ScriptDom.DurabilityTableOption();
            ret.DurabilityTableOptionKind = durabilityTableOptionKind;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + durabilityTableOptionKind.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DurabilityTableOption);
        } 
        
        public bool Equals(DurabilityTableOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DurabilityTableOptionKind>.Default.Equals(other.DurabilityTableOptionKind, durabilityTableOptionKind)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DurabilityTableOption left, DurabilityTableOption right) {
            return EqualityComparer<DurabilityTableOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DurabilityTableOption left, DurabilityTableOption right) {
            return !(left == right);
        }
    
    }

}