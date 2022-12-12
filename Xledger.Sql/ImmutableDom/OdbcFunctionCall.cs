using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OdbcFunctionCall : PrimaryExpression, IEquatable<OdbcFunctionCall> {
        protected Identifier name;
        protected bool parametersUsed = false;
        protected IReadOnlyList<ScalarExpression> parameters;
    
        public Identifier Name => name;
        public bool ParametersUsed => parametersUsed;
        public IReadOnlyList<ScalarExpression> Parameters => parameters;
    
        public OdbcFunctionCall(Identifier name = null, bool parametersUsed = false, IReadOnlyList<ScalarExpression> parameters = null, Identifier collation = null) {
            this.name = name;
            this.parametersUsed = parametersUsed;
            this.parameters = parameters is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(parameters);
            this.collation = collation;
        }
    
        public ScriptDom.OdbcFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.OdbcFunctionCall();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ParametersUsed = parametersUsed;
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + parametersUsed.GetHashCode();
            h = h * 23 + parameters.GetHashCode();
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OdbcFunctionCall);
        } 
        
        public bool Equals(OdbcFunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ParametersUsed, parametersUsed)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OdbcFunctionCall left, OdbcFunctionCall right) {
            return EqualityComparer<OdbcFunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OdbcFunctionCall left, OdbcFunctionCall right) {
            return !(left == right);
        }
    
    }

}
