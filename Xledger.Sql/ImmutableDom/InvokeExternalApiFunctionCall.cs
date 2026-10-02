using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class InvokeExternalApiFunctionCall : PrimaryExpression, IEquatable<InvokeExternalApiFunctionCall> {
        protected StringLiteral functionSetName;
        protected StringLiteral functionName;
        protected IReadOnlyList<ScalarExpression> arguments;
    
        public StringLiteral FunctionSetName => functionSetName;
        public StringLiteral FunctionName => functionName;
        public IReadOnlyList<ScalarExpression> Arguments => arguments;
    
        public InvokeExternalApiFunctionCall(StringLiteral functionSetName = null, StringLiteral functionName = null, IReadOnlyList<ScalarExpression> arguments = null, Identifier collation = null) {
            this.functionSetName = functionSetName;
            this.functionName = functionName;
            this.arguments = arguments.ToImmArray<ScalarExpression>();
            this.collation = collation;
        }
    
        public ScriptDom.InvokeExternalApiFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.InvokeExternalApiFunctionCall();
            ret.FunctionSetName = (ScriptDom.StringLiteral)functionSetName?.ToMutable();
            ret.FunctionName = (ScriptDom.StringLiteral)functionName?.ToMutable();
            ret.Arguments.AddRange(arguments.Select(c => (ScriptDom.ScalarExpression)c?.ToMutable()));
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(functionSetName is null)) {
                h = h * 23 + functionSetName.GetHashCode();
            }
            if (!(functionName is null)) {
                h = h * 23 + functionName.GetHashCode();
            }
            h = h * 23 + arguments.GetHashCode();
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as InvokeExternalApiFunctionCall);
        } 
        
        public bool Equals(InvokeExternalApiFunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.FunctionSetName, functionSetName)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.FunctionName, functionName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Arguments, arguments)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(InvokeExternalApiFunctionCall left, InvokeExternalApiFunctionCall right) {
            return EqualityComparer<InvokeExternalApiFunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(InvokeExternalApiFunctionCall left, InvokeExternalApiFunctionCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (InvokeExternalApiFunctionCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.functionSetName, othr.functionSetName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.functionName, othr.functionName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.arguments, othr.arguments);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (InvokeExternalApiFunctionCall left, InvokeExternalApiFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(InvokeExternalApiFunctionCall left, InvokeExternalApiFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (InvokeExternalApiFunctionCall left, InvokeExternalApiFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(InvokeExternalApiFunctionCall left, InvokeExternalApiFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static InvokeExternalApiFunctionCall FromMutable(ScriptDom.InvokeExternalApiFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.InvokeExternalApiFunctionCall)) { throw new NotImplementedException("Unexpected subtype of InvokeExternalApiFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InvokeExternalApiFunctionCall(
                functionSetName: ImmutableDom.StringLiteral.FromMutable(fragment.FunctionSetName),
                functionName: ImmutableDom.StringLiteral.FromMutable(fragment.FunctionName),
                arguments: fragment.Arguments.ToImmArray(ImmutableDom.ScalarExpression.FromMutable),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
