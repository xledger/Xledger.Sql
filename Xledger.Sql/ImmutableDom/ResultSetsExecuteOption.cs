using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ResultSetsExecuteOption : ExecuteOption, IEquatable<ResultSetsExecuteOption> {
        ScriptDom.ResultSetsOptionKind resultSetsOptionKind = ScriptDom.ResultSetsOptionKind.Undefined;
        IReadOnlyList<ResultSetDefinition> definitions;
    
        public ScriptDom.ResultSetsOptionKind ResultSetsOptionKind => resultSetsOptionKind;
        public IReadOnlyList<ResultSetDefinition> Definitions => definitions;
    
        public ResultSetsExecuteOption(ScriptDom.ResultSetsOptionKind resultSetsOptionKind = ScriptDom.ResultSetsOptionKind.Undefined, IReadOnlyList<ResultSetDefinition> definitions = null, ScriptDom.ExecuteOptionKind optionKind = ScriptDom.ExecuteOptionKind.Recompile) {
            this.resultSetsOptionKind = resultSetsOptionKind;
            this.definitions = definitions is null ? ImmList<ResultSetDefinition>.Empty : ImmList<ResultSetDefinition>.FromList(definitions);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ResultSetsExecuteOption ToMutableConcrete() {
            var ret = new ScriptDom.ResultSetsExecuteOption();
            ret.ResultSetsOptionKind = resultSetsOptionKind;
            ret.Definitions.AddRange(definitions.Select(c => (ScriptDom.ResultSetDefinition)c.ToMutable()));
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + resultSetsOptionKind.GetHashCode();
            h = h * 23 + definitions.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ResultSetsExecuteOption);
        } 
        
        public bool Equals(ResultSetsExecuteOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ResultSetsOptionKind>.Default.Equals(other.ResultSetsOptionKind, resultSetsOptionKind)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ResultSetDefinition>>.Default.Equals(other.Definitions, definitions)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExecuteOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ResultSetsExecuteOption left, ResultSetsExecuteOption right) {
            return EqualityComparer<ResultSetsExecuteOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ResultSetsExecuteOption left, ResultSetsExecuteOption right) {
            return !(left == right);
        }
    
    }

}