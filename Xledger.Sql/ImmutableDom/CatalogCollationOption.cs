using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CatalogCollationOption : DatabaseOption, IEquatable<CatalogCollationOption> {
        protected ScriptDom.CatalogCollation? catalogCollation;
    
        public ScriptDom.CatalogCollation? CatalogCollation => catalogCollation;
    
        public CatalogCollationOption(ScriptDom.CatalogCollation? catalogCollation = null, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.catalogCollation = catalogCollation;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.CatalogCollationOption ToMutableConcrete() {
            var ret = new ScriptDom.CatalogCollationOption();
            ret.CatalogCollation = catalogCollation;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + catalogCollation.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CatalogCollationOption);
        } 
        
        public bool Equals(CatalogCollationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.CatalogCollation?>.Default.Equals(other.CatalogCollation, catalogCollation)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CatalogCollationOption left, CatalogCollationOption right) {
            return EqualityComparer<CatalogCollationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CatalogCollationOption left, CatalogCollationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CatalogCollationOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.catalogCollation, othr.catalogCollation);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CatalogCollationOption left, CatalogCollationOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CatalogCollationOption left, CatalogCollationOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CatalogCollationOption left, CatalogCollationOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CatalogCollationOption left, CatalogCollationOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CatalogCollationOption FromMutable(ScriptDom.CatalogCollationOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CatalogCollationOption)) { throw new NotImplementedException("Unexpected subtype of CatalogCollationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CatalogCollationOption(
                catalogCollation: fragment.CatalogCollation,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
