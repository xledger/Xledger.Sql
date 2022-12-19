using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PartitionFunctionCall : PrimaryExpression, IEquatable<PartitionFunctionCall> {
        protected Identifier databaseName;
        protected Identifier functionName;
        protected IReadOnlyList<ScalarExpression> parameters;
    
        public Identifier DatabaseName => databaseName;
        public Identifier FunctionName => functionName;
        public IReadOnlyList<ScalarExpression> Parameters => parameters;
    
        public PartitionFunctionCall(Identifier databaseName = null, Identifier functionName = null, IReadOnlyList<ScalarExpression> parameters = null, Identifier collation = null) {
            this.databaseName = databaseName;
            this.functionName = functionName;
            this.parameters = ImmList<ScalarExpression>.FromList(parameters);
            this.collation = collation;
        }
    
        public ScriptDom.PartitionFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.PartitionFunctionCall();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName?.ToMutable();
            ret.FunctionName = (ScriptDom.Identifier)functionName?.ToMutable();
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ScalarExpression)c?.ToMutable()));
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            if (!(functionName is null)) {
                h = h * 23 + functionName.GetHashCode();
            }
            h = h * 23 + parameters.GetHashCode();
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PartitionFunctionCall);
        } 
        
        public bool Equals(PartitionFunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DatabaseName, databaseName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.FunctionName, functionName)) {
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
        
        public static bool operator ==(PartitionFunctionCall left, PartitionFunctionCall right) {
            return EqualityComparer<PartitionFunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PartitionFunctionCall left, PartitionFunctionCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (PartitionFunctionCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.databaseName, othr.databaseName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.functionName, othr.functionName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (PartitionFunctionCall left, PartitionFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(PartitionFunctionCall left, PartitionFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (PartitionFunctionCall left, PartitionFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(PartitionFunctionCall left, PartitionFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static PartitionFunctionCall FromMutable(ScriptDom.PartitionFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.PartitionFunctionCall)) { throw new NotImplementedException("Unexpected subtype of PartitionFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PartitionFunctionCall(
                databaseName: ImmutableDom.Identifier.FromMutable(fragment.DatabaseName),
                functionName: ImmutableDom.Identifier.FromMutable(fragment.FunctionName),
                parameters: fragment.Parameters.SelectList(ImmutableDom.ScalarExpression.FromMutable),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
