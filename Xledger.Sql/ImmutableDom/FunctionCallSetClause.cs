using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FunctionCallSetClause : SetClause, IEquatable<FunctionCallSetClause> {
        protected FunctionCall mutatorFunction;
    
        public FunctionCall MutatorFunction => mutatorFunction;
    
        public FunctionCallSetClause(FunctionCall mutatorFunction = null) {
            this.mutatorFunction = mutatorFunction;
        }
    
        public ScriptDom.FunctionCallSetClause ToMutableConcrete() {
            var ret = new ScriptDom.FunctionCallSetClause();
            ret.MutatorFunction = (ScriptDom.FunctionCall)mutatorFunction?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(mutatorFunction is null)) {
                h = h * 23 + mutatorFunction.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FunctionCallSetClause);
        } 
        
        public bool Equals(FunctionCallSetClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<FunctionCall>.Default.Equals(other.MutatorFunction, mutatorFunction)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FunctionCallSetClause left, FunctionCallSetClause right) {
            return EqualityComparer<FunctionCallSetClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FunctionCallSetClause left, FunctionCallSetClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FunctionCallSetClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.mutatorFunction, othr.mutatorFunction);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (FunctionCallSetClause left, FunctionCallSetClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FunctionCallSetClause left, FunctionCallSetClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FunctionCallSetClause left, FunctionCallSetClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FunctionCallSetClause left, FunctionCallSetClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FunctionCallSetClause FromMutable(ScriptDom.FunctionCallSetClause fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.FunctionCallSetClause)) { throw new NotImplementedException("Unexpected subtype of FunctionCallSetClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FunctionCallSetClause(
                mutatorFunction: ImmutableDom.FunctionCall.FromMutable(fragment.MutatorFunction)
            );
        }
    
    }

}
