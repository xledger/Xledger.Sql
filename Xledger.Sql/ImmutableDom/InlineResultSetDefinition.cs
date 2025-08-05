using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class InlineResultSetDefinition : ResultSetDefinition, IEquatable<InlineResultSetDefinition> {
        protected IReadOnlyList<ResultColumnDefinition> resultColumnDefinitions;
    
        public IReadOnlyList<ResultColumnDefinition> ResultColumnDefinitions => resultColumnDefinitions;
    
        public InlineResultSetDefinition(IReadOnlyList<ResultColumnDefinition> resultColumnDefinitions = null, ScriptDom.ResultSetType resultSetType = ScriptDom.ResultSetType.Inline) {
            this.resultColumnDefinitions = resultColumnDefinitions.ToImmArray<ResultColumnDefinition>();
            this.resultSetType = resultSetType;
        }
    
        public new ScriptDom.InlineResultSetDefinition ToMutableConcrete() {
            var ret = new ScriptDom.InlineResultSetDefinition();
            ret.ResultColumnDefinitions.AddRange(resultColumnDefinitions.Select(c => (ScriptDom.ResultColumnDefinition)c?.ToMutable()));
            ret.ResultSetType = resultSetType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + resultColumnDefinitions.GetHashCode();
            h = h * 23 + resultSetType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as InlineResultSetDefinition);
        } 
        
        public bool Equals(InlineResultSetDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ResultColumnDefinition>>.Default.Equals(other.ResultColumnDefinitions, resultColumnDefinitions)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ResultSetType>.Default.Equals(other.ResultSetType, resultSetType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(InlineResultSetDefinition left, InlineResultSetDefinition right) {
            return EqualityComparer<InlineResultSetDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(InlineResultSetDefinition left, InlineResultSetDefinition right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (InlineResultSetDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.resultColumnDefinitions, othr.resultColumnDefinitions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.resultSetType, othr.resultSetType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (InlineResultSetDefinition left, InlineResultSetDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(InlineResultSetDefinition left, InlineResultSetDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (InlineResultSetDefinition left, InlineResultSetDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(InlineResultSetDefinition left, InlineResultSetDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static InlineResultSetDefinition FromMutable(ScriptDom.InlineResultSetDefinition fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.InlineResultSetDefinition)) { throw new NotImplementedException("Unexpected subtype of InlineResultSetDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InlineResultSetDefinition(
                resultColumnDefinitions: fragment.ResultColumnDefinitions.ToImmArray(ImmutableDom.ResultColumnDefinition.FromMutable),
                resultSetType: fragment.ResultSetType
            );
        }
    
    }

}
