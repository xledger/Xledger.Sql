using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class JsonForClause : ForClause, IEquatable<JsonForClause> {
        protected IReadOnlyList<JsonForClauseOption> options;
    
        public IReadOnlyList<JsonForClauseOption> Options => options;
    
        public JsonForClause(IReadOnlyList<JsonForClauseOption> options = null) {
            this.options = ImmList<JsonForClauseOption>.FromList(options);
        }
    
        public ScriptDom.JsonForClause ToMutableConcrete() {
            var ret = new ScriptDom.JsonForClause();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.JsonForClauseOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as JsonForClause);
        } 
        
        public bool Equals(JsonForClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<JsonForClauseOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(JsonForClause left, JsonForClause right) {
            return EqualityComparer<JsonForClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(JsonForClause left, JsonForClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (JsonForClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (JsonForClause left, JsonForClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(JsonForClause left, JsonForClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (JsonForClause left, JsonForClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(JsonForClause left, JsonForClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static JsonForClause FromMutable(ScriptDom.JsonForClause fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.JsonForClause)) { throw new NotImplementedException("Unexpected subtype of JsonForClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new JsonForClause(
                options: fragment.Options.SelectList(ImmutableDom.JsonForClauseOption.FromMutable)
            );
        }
    
    }

}
