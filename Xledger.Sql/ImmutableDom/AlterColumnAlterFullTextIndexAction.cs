using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterColumnAlterFullTextIndexAction : AlterFullTextIndexAction, IEquatable<AlterColumnAlterFullTextIndexAction> {
        protected FullTextIndexColumn column;
        protected bool withNoPopulation = false;
    
        public FullTextIndexColumn Column => column;
        public bool WithNoPopulation => withNoPopulation;
    
        public AlterColumnAlterFullTextIndexAction(FullTextIndexColumn column = null, bool withNoPopulation = false) {
            this.column = column;
            this.withNoPopulation = withNoPopulation;
        }
    
        public ScriptDom.AlterColumnAlterFullTextIndexAction ToMutableConcrete() {
            var ret = new ScriptDom.AlterColumnAlterFullTextIndexAction();
            ret.Column = (ScriptDom.FullTextIndexColumn)column?.ToMutable();
            ret.WithNoPopulation = withNoPopulation;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(column is null)) {
                h = h * 23 + column.GetHashCode();
            }
            h = h * 23 + withNoPopulation.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterColumnAlterFullTextIndexAction);
        } 
        
        public bool Equals(AlterColumnAlterFullTextIndexAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<FullTextIndexColumn>.Default.Equals(other.Column, column)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithNoPopulation, withNoPopulation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterColumnAlterFullTextIndexAction left, AlterColumnAlterFullTextIndexAction right) {
            return EqualityComparer<AlterColumnAlterFullTextIndexAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterColumnAlterFullTextIndexAction left, AlterColumnAlterFullTextIndexAction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterColumnAlterFullTextIndexAction)that;
            compare = Comparer.DefaultInvariant.Compare(this.column, othr.column);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withNoPopulation, othr.withNoPopulation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterColumnAlterFullTextIndexAction left, AlterColumnAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterColumnAlterFullTextIndexAction left, AlterColumnAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterColumnAlterFullTextIndexAction left, AlterColumnAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterColumnAlterFullTextIndexAction left, AlterColumnAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
