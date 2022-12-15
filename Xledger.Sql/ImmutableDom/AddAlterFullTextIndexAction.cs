using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AddAlterFullTextIndexAction : AlterFullTextIndexAction, IEquatable<AddAlterFullTextIndexAction> {
        protected IReadOnlyList<FullTextIndexColumn> columns;
        protected bool withNoPopulation = false;
    
        public IReadOnlyList<FullTextIndexColumn> Columns => columns;
        public bool WithNoPopulation => withNoPopulation;
    
        public AddAlterFullTextIndexAction(IReadOnlyList<FullTextIndexColumn> columns = null, bool withNoPopulation = false) {
            this.columns = ImmList<FullTextIndexColumn>.FromList(columns);
            this.withNoPopulation = withNoPopulation;
        }
    
        public ScriptDom.AddAlterFullTextIndexAction ToMutableConcrete() {
            var ret = new ScriptDom.AddAlterFullTextIndexAction();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.FullTextIndexColumn)c.ToMutable()));
            ret.WithNoPopulation = withNoPopulation;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columns.GetHashCode();
            h = h * 23 + withNoPopulation.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AddAlterFullTextIndexAction);
        } 
        
        public bool Equals(AddAlterFullTextIndexAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<FullTextIndexColumn>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithNoPopulation, withNoPopulation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AddAlterFullTextIndexAction left, AddAlterFullTextIndexAction right) {
            return EqualityComparer<AddAlterFullTextIndexAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AddAlterFullTextIndexAction left, AddAlterFullTextIndexAction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AddAlterFullTextIndexAction)that;
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withNoPopulation, othr.withNoPopulation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AddAlterFullTextIndexAction left, AddAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AddAlterFullTextIndexAction left, AddAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AddAlterFullTextIndexAction left, AddAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AddAlterFullTextIndexAction left, AddAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
