using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MultiPartIdentifier : TSqlFragment, IEquatable<MultiPartIdentifier> {
        protected IReadOnlyList<Identifier> identifiers;
    
        public IReadOnlyList<Identifier> Identifiers => identifiers;
    
        public MultiPartIdentifier(IReadOnlyList<Identifier> identifiers = null) {
            this.identifiers = ImmList<Identifier>.FromList(identifiers);
        }
    
        public ScriptDom.MultiPartIdentifier ToMutableConcrete() {
            var ret = new ScriptDom.MultiPartIdentifier();
            ret.Identifiers.AddRange(identifiers.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + identifiers.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MultiPartIdentifier);
        } 
        
        public bool Equals(MultiPartIdentifier other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Identifiers, identifiers)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MultiPartIdentifier left, MultiPartIdentifier right) {
            return EqualityComparer<MultiPartIdentifier>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MultiPartIdentifier left, MultiPartIdentifier right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MultiPartIdentifier)that;
            compare = Comparer.DefaultInvariant.Compare(this.identifiers, othr.identifiers);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (MultiPartIdentifier left, MultiPartIdentifier right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MultiPartIdentifier left, MultiPartIdentifier right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MultiPartIdentifier left, MultiPartIdentifier right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MultiPartIdentifier left, MultiPartIdentifier right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
