using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BackwardsCompatibleDropIndexClause : DropIndexClauseBase, IEquatable<BackwardsCompatibleDropIndexClause> {
        protected ChildObjectName index;
    
        public ChildObjectName Index => index;
    
        public BackwardsCompatibleDropIndexClause(ChildObjectName index = null) {
            this.index = index;
        }
    
        public ScriptDom.BackwardsCompatibleDropIndexClause ToMutableConcrete() {
            var ret = new ScriptDom.BackwardsCompatibleDropIndexClause();
            ret.Index = (ScriptDom.ChildObjectName)index?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(index is null)) {
                h = h * 23 + index.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BackwardsCompatibleDropIndexClause);
        } 
        
        public bool Equals(BackwardsCompatibleDropIndexClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ChildObjectName>.Default.Equals(other.Index, index)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BackwardsCompatibleDropIndexClause left, BackwardsCompatibleDropIndexClause right) {
            return EqualityComparer<BackwardsCompatibleDropIndexClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BackwardsCompatibleDropIndexClause left, BackwardsCompatibleDropIndexClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BackwardsCompatibleDropIndexClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.index, othr.index);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (BackwardsCompatibleDropIndexClause left, BackwardsCompatibleDropIndexClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BackwardsCompatibleDropIndexClause left, BackwardsCompatibleDropIndexClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BackwardsCompatibleDropIndexClause left, BackwardsCompatibleDropIndexClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BackwardsCompatibleDropIndexClause left, BackwardsCompatibleDropIndexClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static BackwardsCompatibleDropIndexClause FromMutable(ScriptDom.BackwardsCompatibleDropIndexClause fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.BackwardsCompatibleDropIndexClause)) { throw new NotImplementedException("Unexpected subtype of BackwardsCompatibleDropIndexClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BackwardsCompatibleDropIndexClause(
                index: ImmutableDom.ChildObjectName.FromMutable(fragment.Index)
            );
        }
    
    }

}
