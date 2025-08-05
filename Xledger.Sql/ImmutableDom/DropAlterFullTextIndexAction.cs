using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropAlterFullTextIndexAction : AlterFullTextIndexAction, IEquatable<DropAlterFullTextIndexAction> {
        protected IReadOnlyList<Identifier> columns;
        protected bool withNoPopulation = false;
    
        public IReadOnlyList<Identifier> Columns => columns;
        public bool WithNoPopulation => withNoPopulation;
    
        public DropAlterFullTextIndexAction(IReadOnlyList<Identifier> columns = null, bool withNoPopulation = false) {
            this.columns = columns.ToImmArray<Identifier>();
            this.withNoPopulation = withNoPopulation;
        }
    
        public ScriptDom.DropAlterFullTextIndexAction ToMutableConcrete() {
            var ret = new ScriptDom.DropAlterFullTextIndexAction();
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.Identifier)c?.ToMutable()));
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
            return Equals(obj as DropAlterFullTextIndexAction);
        } 
        
        public bool Equals(DropAlterFullTextIndexAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithNoPopulation, withNoPopulation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropAlterFullTextIndexAction left, DropAlterFullTextIndexAction right) {
            return EqualityComparer<DropAlterFullTextIndexAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropAlterFullTextIndexAction left, DropAlterFullTextIndexAction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropAlterFullTextIndexAction)that;
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withNoPopulation, othr.withNoPopulation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropAlterFullTextIndexAction left, DropAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropAlterFullTextIndexAction left, DropAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropAlterFullTextIndexAction left, DropAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropAlterFullTextIndexAction left, DropAlterFullTextIndexAction right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropAlterFullTextIndexAction FromMutable(ScriptDom.DropAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropAlterFullTextIndexAction)) { throw new NotImplementedException("Unexpected subtype of DropAlterFullTextIndexAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropAlterFullTextIndexAction(
                columns: fragment.Columns.ToImmArray(ImmutableDom.Identifier.FromMutable),
                withNoPopulation: fragment.WithNoPopulation
            );
        }
    
    }

}
