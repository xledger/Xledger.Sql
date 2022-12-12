using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FromClause : TSqlFragment, IEquatable<FromClause> {
        IReadOnlyList<TableReference> tableReferences;
        IReadOnlyList<PredictTableReference> predictTableReference;
    
        public IReadOnlyList<TableReference> TableReferences => tableReferences;
        public IReadOnlyList<PredictTableReference> PredictTableReference => predictTableReference;
    
        public FromClause(IReadOnlyList<TableReference> tableReferences = null, IReadOnlyList<PredictTableReference> predictTableReference = null) {
            this.tableReferences = tableReferences is null ? ImmList<TableReference>.Empty : ImmList<TableReference>.FromList(tableReferences);
            this.predictTableReference = predictTableReference is null ? ImmList<PredictTableReference>.Empty : ImmList<PredictTableReference>.FromList(predictTableReference);
        }
    
        public ScriptDom.FromClause ToMutableConcrete() {
            var ret = new ScriptDom.FromClause();
            ret.TableReferences.AddRange(tableReferences.Select(c => (ScriptDom.TableReference)c.ToMutable()));
            ret.PredictTableReference.AddRange(predictTableReference.Select(c => (ScriptDom.PredictTableReference)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + tableReferences.GetHashCode();
            h = h * 23 + predictTableReference.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FromClause);
        } 
        
        public bool Equals(FromClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<TableReference>>.Default.Equals(other.TableReferences, tableReferences)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<PredictTableReference>>.Default.Equals(other.PredictTableReference, predictTableReference)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FromClause left, FromClause right) {
            return EqualityComparer<FromClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FromClause left, FromClause right) {
            return !(left == right);
        }
    
    }

}
