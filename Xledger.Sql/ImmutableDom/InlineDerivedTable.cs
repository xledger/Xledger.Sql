using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class InlineDerivedTable : TableReferenceWithAliasAndColumns, IEquatable<InlineDerivedTable> {
        protected IReadOnlyList<RowValue> rowValues;
    
        public IReadOnlyList<RowValue> RowValues => rowValues;
    
        public InlineDerivedTable(IReadOnlyList<RowValue> rowValues = null, IReadOnlyList<Identifier> columns = null, Identifier alias = null, bool forPath = false) {
            this.rowValues = ImmList<RowValue>.FromList(rowValues);
            this.columns = ImmList<Identifier>.FromList(columns);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.InlineDerivedTable ToMutableConcrete() {
            var ret = new ScriptDom.InlineDerivedTable();
            ret.RowValues.AddRange(rowValues.SelectList(c => (ScriptDom.RowValue)c.ToMutable()));
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + rowValues.GetHashCode();
            h = h * 23 + columns.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as InlineDerivedTable);
        } 
        
        public bool Equals(InlineDerivedTable other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<RowValue>>.Default.Equals(other.RowValues, rowValues)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Alias, alias)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForPath, forPath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(InlineDerivedTable left, InlineDerivedTable right) {
            return EqualityComparer<InlineDerivedTable>.Default.Equals(left, right);
        }
        
        public static bool operator !=(InlineDerivedTable left, InlineDerivedTable right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (InlineDerivedTable)that;
            compare = Comparer.DefaultInvariant.Compare(this.rowValues, othr.rowValues);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (InlineDerivedTable left, InlineDerivedTable right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(InlineDerivedTable left, InlineDerivedTable right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (InlineDerivedTable left, InlineDerivedTable right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(InlineDerivedTable left, InlineDerivedTable right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
