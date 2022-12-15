using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FromClause : TSqlFragment, IEquatable<FromClause> {
        protected IReadOnlyList<TableReference> tableReferences;
        protected IReadOnlyList<PredictTableReference> predictTableReference;
    
        public IReadOnlyList<TableReference> TableReferences => tableReferences;
        public IReadOnlyList<PredictTableReference> PredictTableReference => predictTableReference;
    
        public FromClause(IReadOnlyList<TableReference> tableReferences = null, IReadOnlyList<PredictTableReference> predictTableReference = null) {
            this.tableReferences = ImmList<TableReference>.FromList(tableReferences);
            this.predictTableReference = ImmList<PredictTableReference>.FromList(predictTableReference);
        }
    
        public ScriptDom.FromClause ToMutableConcrete() {
            var ret = new ScriptDom.FromClause();
            ret.TableReferences.AddRange(tableReferences.SelectList(c => (ScriptDom.TableReference)c.ToMutable()));
            ret.PredictTableReference.AddRange(predictTableReference.SelectList(c => (ScriptDom.PredictTableReference)c.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FromClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.tableReferences, othr.tableReferences);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.predictTableReference, othr.predictTableReference);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (FromClause left, FromClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FromClause left, FromClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FromClause left, FromClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FromClause left, FromClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
