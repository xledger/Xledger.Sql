using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FunctionCall : PrimaryExpression, IEquatable<FunctionCall> {
        protected CallTarget callTarget;
        protected Identifier functionName;
        protected IReadOnlyList<ScalarExpression> parameters;
        protected ScriptDom.UniqueRowFilter uniqueRowFilter = ScriptDom.UniqueRowFilter.NotSpecified;
        protected OverClause overClause;
        protected WithinGroupClause withinGroupClause;
        protected IReadOnlyList<Identifier> ignoreRespectNulls;
        protected Identifier trimOptions;
        protected IReadOnlyList<JsonKeyValue> jsonParameters;
        protected IReadOnlyList<Identifier> absentOrNullOnNull;
    
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
            this.parameters = ImmList<ScalarExpression>.FromList(parameters);
            this.uniqueRowFilter = uniqueRowFilter;
            this.overClause = overClause;
            this.withinGroupClause = withinGroupClause;
            this.ignoreRespectNulls = ImmList<Identifier>.FromList(ignoreRespectNulls);
            this.trimOptions = trimOptions;
            this.jsonParameters = ImmList<JsonKeyValue>.FromList(jsonParameters);
            this.absentOrNullOnNull = ImmList<Identifier>.FromList(absentOrNullOnNull);
            this.collation = collation;
        }
    
        public ScriptDom.FunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.FunctionCall();
            ret.CallTarget = (ScriptDom.CallTarget)callTarget.ToMutable();
            ret.FunctionName = (ScriptDom.Identifier)functionName.ToMutable();
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.UniqueRowFilter = uniqueRowFilter;
            ret.OverClause = (ScriptDom.OverClause)overClause.ToMutable();
            ret.WithinGroupClause = (ScriptDom.WithinGroupClause)withinGroupClause.ToMutable();
            ret.IgnoreRespectNulls.AddRange(ignoreRespectNulls.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.TrimOptions = (ScriptDom.Identifier)trimOptions.ToMutable();
            ret.JsonParameters.AddRange(jsonParameters.SelectList(c => (ScriptDom.JsonKeyValue)c.ToMutable()));
            ret.AbsentOrNullOnNull.AddRange(absentOrNullOnNull.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FunctionCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.callTarget, othr.callTarget);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.functionName, othr.functionName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.uniqueRowFilter, othr.uniqueRowFilter);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.overClause, othr.overClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withinGroupClause, othr.withinGroupClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.ignoreRespectNulls, othr.ignoreRespectNulls);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.trimOptions, othr.trimOptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.jsonParameters, othr.jsonParameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.absentOrNullOnNull, othr.absentOrNullOnNull);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (FunctionCall left, FunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FunctionCall left, FunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FunctionCall left, FunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FunctionCall left, FunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FunctionCall FromMutable(ScriptDom.FunctionCall fragment) {
            return (FunctionCall)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
