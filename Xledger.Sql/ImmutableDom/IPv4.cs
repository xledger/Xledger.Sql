using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IPv4 : TSqlFragment, IEquatable<IPv4> {
        protected Literal octetOne;
        protected Literal octetTwo;
        protected Literal octetThree;
        protected Literal octetFour;
    
        public Literal OctetOne => octetOne;
        public Literal OctetTwo => octetTwo;
        public Literal OctetThree => octetThree;
        public Literal OctetFour => octetFour;
    
        public IPv4(Literal octetOne = null, Literal octetTwo = null, Literal octetThree = null, Literal octetFour = null) {
            this.octetOne = octetOne;
            this.octetTwo = octetTwo;
            this.octetThree = octetThree;
            this.octetFour = octetFour;
        }
    
        public ScriptDom.IPv4 ToMutableConcrete() {
            var ret = new ScriptDom.IPv4();
            ret.OctetOne = (ScriptDom.Literal)octetOne?.ToMutable();
            ret.OctetTwo = (ScriptDom.Literal)octetTwo?.ToMutable();
            ret.OctetThree = (ScriptDom.Literal)octetThree?.ToMutable();
            ret.OctetFour = (ScriptDom.Literal)octetFour?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(octetOne is null)) {
                h = h * 23 + octetOne.GetHashCode();
            }
            if (!(octetTwo is null)) {
                h = h * 23 + octetTwo.GetHashCode();
            }
            if (!(octetThree is null)) {
                h = h * 23 + octetThree.GetHashCode();
            }
            if (!(octetFour is null)) {
                h = h * 23 + octetFour.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IPv4);
        } 
        
        public bool Equals(IPv4 other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.OctetOne, octetOne)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.OctetTwo, octetTwo)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.OctetThree, octetThree)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.OctetFour, octetFour)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IPv4 left, IPv4 right) {
            return EqualityComparer<IPv4>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IPv4 left, IPv4 right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (IPv4)that;
            compare = Comparer.DefaultInvariant.Compare(this.octetOne, othr.octetOne);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.octetTwo, othr.octetTwo);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.octetThree, othr.octetThree);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.octetFour, othr.octetFour);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (IPv4 left, IPv4 right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(IPv4 left, IPv4 right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (IPv4 left, IPv4 right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(IPv4 left, IPv4 right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
