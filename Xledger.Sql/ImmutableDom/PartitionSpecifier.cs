using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PartitionSpecifier : TSqlFragment, IEquatable<PartitionSpecifier> {
        protected ScalarExpression number;
        protected bool all = false;
    
        public ScalarExpression Number => number;
        public bool All => all;
    
        public PartitionSpecifier(ScalarExpression number = null, bool all = false) {
            this.number = number;
            this.all = all;
        }
    
        public ScriptDom.PartitionSpecifier ToMutableConcrete() {
            var ret = new ScriptDom.PartitionSpecifier();
            ret.Number = (ScriptDom.ScalarExpression)number.ToMutable();
            ret.All = all;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(number is null)) {
                h = h * 23 + number.GetHashCode();
            }
            h = h * 23 + all.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PartitionSpecifier);
        } 
        
        public bool Equals(PartitionSpecifier other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Number, number)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.All, all)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PartitionSpecifier left, PartitionSpecifier right) {
            return EqualityComparer<PartitionSpecifier>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PartitionSpecifier left, PartitionSpecifier right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (PartitionSpecifier)that;
            compare = Comparer.DefaultInvariant.Compare(this.number, othr.number);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.all, othr.all);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (PartitionSpecifier left, PartitionSpecifier right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(PartitionSpecifier left, PartitionSpecifier right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (PartitionSpecifier left, PartitionSpecifier right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(PartitionSpecifier left, PartitionSpecifier right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static PartitionSpecifier FromMutable(ScriptDom.PartitionSpecifier fragment) {
            return (PartitionSpecifier)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
