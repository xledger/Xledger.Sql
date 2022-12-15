using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UnqualifiedJoin : JoinTableReference, IEquatable<UnqualifiedJoin> {
        protected ScriptDom.UnqualifiedJoinType unqualifiedJoinType = ScriptDom.UnqualifiedJoinType.CrossJoin;
    
        public ScriptDom.UnqualifiedJoinType UnqualifiedJoinType => unqualifiedJoinType;
    
        public UnqualifiedJoin(ScriptDom.UnqualifiedJoinType unqualifiedJoinType = ScriptDom.UnqualifiedJoinType.CrossJoin, TableReference firstTableReference = null, TableReference secondTableReference = null) {
            this.unqualifiedJoinType = unqualifiedJoinType;
            this.firstTableReference = firstTableReference;
            this.secondTableReference = secondTableReference;
        }
    
        public ScriptDom.UnqualifiedJoin ToMutableConcrete() {
            var ret = new ScriptDom.UnqualifiedJoin();
            ret.UnqualifiedJoinType = unqualifiedJoinType;
            ret.FirstTableReference = (ScriptDom.TableReference)firstTableReference.ToMutable();
            ret.SecondTableReference = (ScriptDom.TableReference)secondTableReference.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + unqualifiedJoinType.GetHashCode();
            if (!(firstTableReference is null)) {
                h = h * 23 + firstTableReference.GetHashCode();
            }
            if (!(secondTableReference is null)) {
                h = h * 23 + secondTableReference.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UnqualifiedJoin);
        } 
        
        public bool Equals(UnqualifiedJoin other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.UnqualifiedJoinType>.Default.Equals(other.UnqualifiedJoinType, unqualifiedJoinType)) {
                return false;
            }
            if (!EqualityComparer<TableReference>.Default.Equals(other.FirstTableReference, firstTableReference)) {
                return false;
            }
            if (!EqualityComparer<TableReference>.Default.Equals(other.SecondTableReference, secondTableReference)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UnqualifiedJoin left, UnqualifiedJoin right) {
            return EqualityComparer<UnqualifiedJoin>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UnqualifiedJoin left, UnqualifiedJoin right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (UnqualifiedJoin)that;
            compare = Comparer.DefaultInvariant.Compare(this.unqualifiedJoinType, othr.unqualifiedJoinType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.firstTableReference, othr.firstTableReference);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.secondTableReference, othr.secondTableReference);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (UnqualifiedJoin left, UnqualifiedJoin right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(UnqualifiedJoin left, UnqualifiedJoin right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (UnqualifiedJoin left, UnqualifiedJoin right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(UnqualifiedJoin left, UnqualifiedJoin right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
