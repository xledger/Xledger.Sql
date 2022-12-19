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
            this.parameters = ImmList<ScalarExpression>.FromList(parameters);
            this.collation = collation;
        }
    
        public ScriptDom.OdbcFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.OdbcFunctionCall();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.ParametersUsed = parametersUsed;
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ScalarExpression)c?.ToMutable()));
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OdbcFunctionCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parametersUsed, othr.parametersUsed);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OdbcFunctionCall left, OdbcFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OdbcFunctionCall left, OdbcFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OdbcFunctionCall left, OdbcFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OdbcFunctionCall left, OdbcFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OdbcFunctionCall FromMutable(ScriptDom.OdbcFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OdbcFunctionCall)) { throw new NotImplementedException("Unexpected subtype of OdbcFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OdbcFunctionCall(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                parametersUsed: fragment.ParametersUsed,
                parameters: fragment.Parameters.SelectList(ImmutableDom.ScalarExpression.FromMutable),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
