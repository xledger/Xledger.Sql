using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MergeActionClause : TSqlFragment, IEquatable<MergeActionClause> {
        protected ScriptDom.MergeCondition condition = ScriptDom.MergeCondition.NotSpecified;
        protected BooleanExpression searchCondition;
        protected MergeAction action;
    
        public ScriptDom.MergeCondition Condition => condition;
        public BooleanExpression SearchCondition => searchCondition;
        public MergeAction Action => action;
    
        public MergeActionClause(ScriptDom.MergeCondition condition = ScriptDom.MergeCondition.NotSpecified, BooleanExpression searchCondition = null, MergeAction action = null) {
            this.condition = condition;
            this.searchCondition = searchCondition;
            this.action = action;
        }
    
        public ScriptDom.MergeActionClause ToMutableConcrete() {
            var ret = new ScriptDom.MergeActionClause();
            ret.Condition = condition;
            ret.SearchCondition = (ScriptDom.BooleanExpression)searchCondition?.ToMutable();
            ret.Action = (ScriptDom.MergeAction)action?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + condition.GetHashCode();
            if (!(searchCondition is null)) {
                h = h * 23 + searchCondition.GetHashCode();
            }
            if (!(action is null)) {
                h = h * 23 + action.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MergeActionClause);
        } 
        
        public bool Equals(MergeActionClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.MergeCondition>.Default.Equals(other.Condition, condition)) {
                return false;
            }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.SearchCondition, searchCondition)) {
                return false;
            }
            if (!EqualityComparer<MergeAction>.Default.Equals(other.Action, action)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MergeActionClause left, MergeActionClause right) {
            return EqualityComparer<MergeActionClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MergeActionClause left, MergeActionClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MergeActionClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.condition, othr.condition);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.searchCondition, othr.searchCondition);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.action, othr.action);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (MergeActionClause left, MergeActionClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MergeActionClause left, MergeActionClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MergeActionClause left, MergeActionClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MergeActionClause left, MergeActionClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static MergeActionClause FromMutable(ScriptDom.MergeActionClause fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.MergeActionClause)) { throw new NotImplementedException("Unexpected subtype of MergeActionClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MergeActionClause(
                condition: fragment.Condition,
                searchCondition: ImmutableDom.BooleanExpression.FromMutable(fragment.SearchCondition),
                action: ImmutableDom.MergeAction.FromMutable(fragment.Action)
            );
        }
    
    }

}
