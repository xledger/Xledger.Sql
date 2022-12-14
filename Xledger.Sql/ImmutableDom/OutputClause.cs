using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OutputClause : TSqlFragment, IEquatable<OutputClause> {
        protected IReadOnlyList<SelectElement> selectColumns;
    
        public IReadOnlyList<SelectElement> SelectColumns => selectColumns;
    
        public OutputClause(IReadOnlyList<SelectElement> selectColumns = null) {
            this.selectColumns = ImmList<SelectElement>.FromList(selectColumns);
        }
    
        public ScriptDom.OutputClause ToMutableConcrete() {
            var ret = new ScriptDom.OutputClause();
            ret.SelectColumns.AddRange(selectColumns.SelectList(c => (ScriptDom.SelectElement)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + selectColumns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OutputClause);
        } 
        
        public bool Equals(OutputClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<SelectElement>>.Default.Equals(other.SelectColumns, selectColumns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OutputClause left, OutputClause right) {
            return EqualityComparer<OutputClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OutputClause left, OutputClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OutputClause)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.selectColumns, othr.selectColumns);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static OutputClause FromMutable(ScriptDom.OutputClause fragment) {
            return (OutputClause)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
