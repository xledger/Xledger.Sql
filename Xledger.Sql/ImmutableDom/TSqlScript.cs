using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TSqlScript : TSqlFragment, IEquatable<TSqlScript> {
        IReadOnlyList<TSqlBatch> batches;
    
        public IReadOnlyList<TSqlBatch> Batches => batches;
    
        public TSqlScript(IReadOnlyList<TSqlBatch> batches = null) {
            this.batches = batches is null ? ImmList<TSqlBatch>.Empty : ImmList<TSqlBatch>.FromList(batches);
        }
    
        public ScriptDom.TSqlScript ToMutableConcrete() {
            var ret = new ScriptDom.TSqlScript();
            ret.Batches.AddRange(batches.Select(c => (ScriptDom.TSqlBatch)c.ToMutable()));
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
    
    }

}
