using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalModelTypeSpecification : TSqlFragment, IEquatable<ExternalModelTypeSpecification> {
        protected ScriptDom.ExternalModelTypeOption optionKind = ScriptDom.ExternalModelTypeOption.EMBEDDINGS;
    
        public ScriptDom.ExternalModelTypeOption OptionKind => optionKind;
    
        public ExternalModelTypeSpecification(ScriptDom.ExternalModelTypeOption optionKind = ScriptDom.ExternalModelTypeOption.EMBEDDINGS) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExternalModelTypeSpecification ToMutableConcrete() {
            var ret = new ScriptDom.ExternalModelTypeSpecification();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalModelTypeSpecification);
        } 
        
        public bool Equals(ExternalModelTypeSpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ExternalModelTypeOption>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalModelTypeSpecification left, ExternalModelTypeSpecification right) {
            return EqualityComparer<ExternalModelTypeSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalModelTypeSpecification left, ExternalModelTypeSpecification right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExternalModelTypeSpecification)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExternalModelTypeSpecification left, ExternalModelTypeSpecification right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExternalModelTypeSpecification left, ExternalModelTypeSpecification right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExternalModelTypeSpecification left, ExternalModelTypeSpecification right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExternalModelTypeSpecification left, ExternalModelTypeSpecification right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExternalModelTypeSpecification FromMutable(ScriptDom.ExternalModelTypeSpecification fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExternalModelTypeSpecification)) { throw new NotImplementedException("Unexpected subtype of ExternalModelTypeSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalModelTypeSpecification(
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
