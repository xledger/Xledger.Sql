using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TSqlBatch : TSqlFragment, IEquatable<TSqlBatch> {
        protected IReadOnlyList<TSqlStatement> statements;
    
        public IReadOnlyList<TSqlStatement> Statements => statements;
    
        public TSqlBatch(IReadOnlyList<TSqlStatement> statements = null) {
            this.statements = statements.ToImmArray<TSqlStatement>();
        }
    
        public ScriptDom.TSqlBatch ToMutableConcrete() {
            var ret = new ScriptDom.TSqlBatch();
            ret.Statements.AddRange(statements.Select(c => (ScriptDom.TSqlStatement)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + statements.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TSqlBatch);
        } 
        
        public bool Equals(TSqlBatch other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<TSqlStatement>>.Default.Equals(other.Statements, statements)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TSqlBatch left, TSqlBatch right) {
            return EqualityComparer<TSqlBatch>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TSqlBatch left, TSqlBatch right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TSqlBatch)that;
            compare = Comparer.DefaultInvariant.Compare(this.statements, othr.statements);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (TSqlBatch left, TSqlBatch right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TSqlBatch left, TSqlBatch right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TSqlBatch left, TSqlBatch right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TSqlBatch left, TSqlBatch right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TSqlBatch FromMutable(ScriptDom.TSqlBatch fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.TSqlBatch)) { throw new NotImplementedException("Unexpected subtype of TSqlBatch not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TSqlBatch(
                statements: fragment.Statements.ToImmArray(ImmutableDom.TSqlStatement.FromMutable)
            );
        }
    
    }

}
