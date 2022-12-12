using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteAsProcedureOption : ProcedureOption, IEquatable<ExecuteAsProcedureOption> {
        ExecuteAsClause executeAs;
    
        public ExecuteAsClause ExecuteAs => executeAs;
    
        public ExecuteAsProcedureOption(ExecuteAsClause executeAs = null, ScriptDom.ProcedureOptionKind optionKind = ScriptDom.ProcedureOptionKind.Encryption) {
            this.executeAs = executeAs;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExecuteAsProcedureOption ToMutableConcrete() {
            var ret = new ScriptDom.ExecuteAsProcedureOption();
            ret.ExecuteAs = (ScriptDom.ExecuteAsClause)executeAs.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(executeAs is null)) {
                h = h * 23 + executeAs.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecuteAsProcedureOption);
        } 
        
        public bool Equals(ExecuteAsProcedureOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ExecuteAsClause>.Default.Equals(other.ExecuteAs, executeAs)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ProcedureOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecuteAsProcedureOption left, ExecuteAsProcedureOption right) {
            return EqualityComparer<ExecuteAsProcedureOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecuteAsProcedureOption left, ExecuteAsProcedureOption right) {
            return !(left == right);
        }
    
    }

}
