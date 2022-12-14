using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TSqlScript : TSqlFragment, IEquatable<TSqlScript> {
        protected IReadOnlyList<TSqlBatch> batches;
    
        public IReadOnlyList<TSqlBatch> Batches => batches;
    
        public TSqlScript(IReadOnlyList<TSqlBatch> batches = null) {
            this.batches = ImmList<TSqlBatch>.FromList(batches);
        }
    
        public ScriptDom.TSqlScript ToMutableConcrete() {
            var ret = new ScriptDom.TSqlScript();
            ret.Batches.AddRange(batches.SelectList(c => (ScriptDom.TSqlBatch)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + batches.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TSqlScript);
        } 
        
        public bool Equals(TSqlScript other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<TSqlBatch>>.Default.Equals(other.Batches, batches)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TSqlScript left, TSqlScript right) {
            return EqualityComparer<TSqlScript>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TSqlScript left, TSqlScript right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TSqlScript)that;
            compare = Comparer.DefaultInvariant.Compare(this.batches, othr.batches);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (TSqlScript left, TSqlScript right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TSqlScript left, TSqlScript right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TSqlScript left, TSqlScript right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TSqlScript left, TSqlScript right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TSqlScript FromMutable(ScriptDom.TSqlScript fragment) {
            return (TSqlScript)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
