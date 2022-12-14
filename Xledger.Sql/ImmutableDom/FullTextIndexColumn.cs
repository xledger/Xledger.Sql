using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FullTextIndexColumn : TSqlFragment, IEquatable<FullTextIndexColumn> {
        protected Identifier name;
        protected Identifier typeColumn;
        protected IdentifierOrValueExpression languageTerm;
        protected bool statisticalSemantics = false;
    
        public Identifier Name => name;
        public Identifier TypeColumn => typeColumn;
        public IdentifierOrValueExpression LanguageTerm => languageTerm;
        public bool StatisticalSemantics => statisticalSemantics;
    
        public FullTextIndexColumn(Identifier name = null, Identifier typeColumn = null, IdentifierOrValueExpression languageTerm = null, bool statisticalSemantics = false) {
            this.name = name;
            this.typeColumn = typeColumn;
            this.languageTerm = languageTerm;
            this.statisticalSemantics = statisticalSemantics;
        }
    
        public ScriptDom.FullTextIndexColumn ToMutableConcrete() {
            var ret = new ScriptDom.FullTextIndexColumn();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.TypeColumn = (ScriptDom.Identifier)typeColumn.ToMutable();
            ret.LanguageTerm = (ScriptDom.IdentifierOrValueExpression)languageTerm.ToMutable();
            ret.StatisticalSemantics = statisticalSemantics;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(typeColumn is null)) {
                h = h * 23 + typeColumn.GetHashCode();
            }
            if (!(languageTerm is null)) {
                h = h * 23 + languageTerm.GetHashCode();
            }
            h = h * 23 + statisticalSemantics.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FullTextIndexColumn);
        } 
        
        public bool Equals(FullTextIndexColumn other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.TypeColumn, typeColumn)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.LanguageTerm, languageTerm)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.StatisticalSemantics, statisticalSemantics)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FullTextIndexColumn left, FullTextIndexColumn right) {
            return EqualityComparer<FullTextIndexColumn>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FullTextIndexColumn left, FullTextIndexColumn right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FullTextIndexColumn)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.typeColumn, othr.typeColumn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.languageTerm, othr.languageTerm);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.statisticalSemantics, othr.statisticalSemantics);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (FullTextIndexColumn left, FullTextIndexColumn right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FullTextIndexColumn left, FullTextIndexColumn right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FullTextIndexColumn left, FullTextIndexColumn right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FullTextIndexColumn left, FullTextIndexColumn right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FullTextIndexColumn FromMutable(ScriptDom.FullTextIndexColumn fragment) {
            return (FullTextIndexColumn)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
