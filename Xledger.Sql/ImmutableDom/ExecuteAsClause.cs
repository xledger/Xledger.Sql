using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteAsClause : TSqlFragment, IEquatable<ExecuteAsClause> {
        protected ScriptDom.ExecuteAsOption executeAsOption = ScriptDom.ExecuteAsOption.Caller;
        protected Literal literal;
    
        public ScriptDom.ExecuteAsOption ExecuteAsOption => executeAsOption;
        public Literal Literal => literal;
    
        public ExecuteAsClause(ScriptDom.ExecuteAsOption executeAsOption = ScriptDom.ExecuteAsOption.Caller, Literal literal = null) {
            this.executeAsOption = executeAsOption;
            this.literal = literal;
        }
    
        public ScriptDom.ExecuteAsClause ToMutableConcrete() {
            var ret = new ScriptDom.ExecuteAsClause();
            ret.ExecuteAsOption = executeAsOption;
            ret.Literal = (ScriptDom.Literal)literal?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + executeAsOption.GetHashCode();
            if (!(literal is null)) {
                h = h * 23 + literal.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecuteAsClause);
        } 
        
        public bool Equals(ExecuteAsClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ExecuteAsOption>.Default.Equals(other.ExecuteAsOption, executeAsOption)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Literal, literal)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecuteAsClause left, ExecuteAsClause right) {
            return EqualityComparer<ExecuteAsClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecuteAsClause left, ExecuteAsClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExecuteAsClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.executeAsOption, othr.executeAsOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.literal, othr.literal);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ExecuteAsClause left, ExecuteAsClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExecuteAsClause left, ExecuteAsClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExecuteAsClause left, ExecuteAsClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExecuteAsClause left, ExecuteAsClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
