using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FunctionCall : PrimaryExpression, IEquatable<FunctionCall> {
        CallTarget callTarget;
        Identifier functionName;
        IReadOnlyList<ScalarExpression> parameters;
        ScriptDom.UniqueRowFilter uniqueRowFilter = ScriptDom.UniqueRowFilter.NotSpecified;
        OverClause overClause;
        WithinGroupClause withinGroupClause;
        IReadOnlyList<Identifier> ignoreRespectNulls;
        Identifier trimOptions;
        IReadOnlyList<JsonKeyValue> jsonParameters;
        IReadOnlyList<Identifier> absentOrNullOnNull;
    
        public CallTarget CallTarget => callTarget;
        public Identifier FunctionName => functionName;
        public IReadOnlyList<ScalarExpression> Parameters => parameters;
        public ScriptDom.UniqueRowFilter UniqueRowFilter => uniqueRowFilter;
        public OverClause OverClause => overClause;
        public WithinGroupClause WithinGroupClause => withinGroupClause;
        public IReadOnlyList<Identifier> IgnoreRespectNulls => ignoreRespectNulls;
        public Identifier TrimOptions => trimOptions;
        public IReadOnlyList<JsonKeyValue> JsonParameters => jsonParameters;
        public IReadOnlyList<Identifier> AbsentOrNullOnNull => absentOrNullOnNull;
    
        public FunctionCall(CallTarget callTarget = null, Identifier functionName = null, IReadOnlyList<ScalarExpression> parameters = null, ScriptDom.UniqueRowFilter uniqueRowFilter = ScriptDom.UniqueRowFilter.NotSpecified, OverClause overClause = null, WithinGroupClause withinGroupClause = null, IReadOnlyList<Identifier> ignoreRespectNulls = null, Identifier trimOptions = null, IReadOnlyList<JsonKeyValue> jsonParameters = null, IReadOnlyList<Identifier> absentOrNullOnNull = null, Identifier collation = null) {
            this.callTarget = callTarget;
            this.functionName = functionName;
            this.parameters = parameters is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(parameters);
            this.uniqueRowFilter = uniqueRowFilter;
            this.overClause = overClause;
            this.withinGroupClause = withinGroupClause;
            this.ignoreRespectNulls = ignoreRespectNulls is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(ignoreRespectNulls);
            this.trimOptions = trimOptions;
            this.jsonParameters = jsonParameters is null ? ImmList<JsonKeyValue>.Empty : ImmList<JsonKeyValue>.FromList(jsonParameters);
            this.absentOrNullOnNull = absentOrNullOnNull is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(absentOrNullOnNull);
            this.collation = collation;
        }
    
        public ScriptDom.FunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.FunctionCall();
            ret.CallTarget = (ScriptDom.CallTarget)callTarget.ToMutable();
            ret.FunctionName = (ScriptDom.Identifier)functionName.ToMutable();
            ret.Parameters.AddRange(parameters.Select(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.UniqueRowFilter = uniqueRowFilter;
            ret.OverClause = (ScriptDom.OverClause)overClause.ToMutable();
            ret.WithinGroupClause = (ScriptDom.WithinGroupClause)withinGroupClause.ToMutable();
            ret.IgnoreRespectNulls.AddRange(ignoreRespectNulls.Select(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.TrimOptions = (ScriptDom.Identifier)trimOptions.ToMutable();
            ret.JsonParameters.AddRange(jsonParameters.Select(c => (ScriptDom.JsonKeyValue)c.ToMutable()));
            ret.AbsentOrNullOnNull.AddRange(absentOrNullOnNull.Select(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(callTarget is null)) {
                h = h * 23 + callTarget.GetHashCode();
            }
            if (!(functionName is null)) {
                h = h * 23 + functionName.GetHashCode();
            }
            h = h * 23 + parameters.GetHashCode();
            h = h * 23 + uniqueRowFilter.GetHashCode();
            if (!(overClause is null)) {
                h = h * 23 + overClause.GetHashCode();
            }
            if (!(withinGroupClause is null)) {
                h = h * 23 + withinGroupClause.GetHashCode();
            }
            h = h * 23 + ignoreRespectNulls.GetHashCode();
            if (!(trimOptions is null)) {
                h = h * 23 + trimOptions.GetHashCode();
            }
            h = h * 23 + jsonParameters.GetHashCode();
            h = h * 23 + absentOrNullOnNull.GetHashCode();
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FunctionCall);
        } 
        
        public bool Equals(FunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<CallTarget>.Default.Equals(other.CallTarget, callTarget)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.FunctionName, functionName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.UniqueRowFilter>.Default.Equals(other.UniqueRowFilter, uniqueRowFilter)) {
                return false;
            }
            if (!EqualityComparer<OverClause>.Default.Equals(other.OverClause, overClause)) {
                return false;
            }
            if (!EqualityComparer<WithinGroupClause>.Default.Equals(other.WithinGroupClause, withinGroupClause)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.IgnoreRespectNulls, ignoreRespectNulls)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.TrimOptions, trimOptions)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<JsonKeyValue>>.Default.Equals(other.JsonParameters, jsonParameters)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.AbsentOrNullOnNull, absentOrNullOnNull)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FunctionCall left, FunctionCall right) {
            return EqualityComparer<FunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FunctionCall left, FunctionCall right) {
            return !(left == right);
        }
    
    }

}
