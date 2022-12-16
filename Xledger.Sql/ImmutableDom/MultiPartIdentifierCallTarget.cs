using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MultiPartIdentifierCallTarget : CallTarget, IEquatable<MultiPartIdentifierCallTarget> {
        protected MultiPartIdentifier multiPartIdentifier;
    
        public MultiPartIdentifier MultiPartIdentifier => multiPartIdentifier;
    
        public MultiPartIdentifierCallTarget(MultiPartIdentifier multiPartIdentifier = null) {
            this.multiPartIdentifier = multiPartIdentifier;
        }
    
        public ScriptDom.MultiPartIdentifierCallTarget ToMutableConcrete() {
            var ret = new ScriptDom.MultiPartIdentifierCallTarget();
            ret.MultiPartIdentifier = (ScriptDom.MultiPartIdentifier)multiPartIdentifier?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(multiPartIdentifier is null)) {
                h = h * 23 + multiPartIdentifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MultiPartIdentifierCallTarget);
        } 
        
        public bool Equals(MultiPartIdentifierCallTarget other) {
            if (other is null) { return false; }
            if (!EqualityComparer<MultiPartIdentifier>.Default.Equals(other.MultiPartIdentifier, multiPartIdentifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MultiPartIdentifierCallTarget left, MultiPartIdentifierCallTarget right) {
            return EqualityComparer<MultiPartIdentifierCallTarget>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MultiPartIdentifierCallTarget left, MultiPartIdentifierCallTarget right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MultiPartIdentifierCallTarget)that;
            compare = Comparer.DefaultInvariant.Compare(this.multiPartIdentifier, othr.multiPartIdentifier);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (MultiPartIdentifierCallTarget left, MultiPartIdentifierCallTarget right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MultiPartIdentifierCallTarget left, MultiPartIdentifierCallTarget right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MultiPartIdentifierCallTarget left, MultiPartIdentifierCallTarget right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MultiPartIdentifierCallTarget left, MultiPartIdentifierCallTarget right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
