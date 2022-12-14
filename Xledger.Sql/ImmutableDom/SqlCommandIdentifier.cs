using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SqlCommandIdentifier : Identifier, IEquatable<SqlCommandIdentifier> {
        public SqlCommandIdentifier(string @value = null, ScriptDom.QuoteType quoteType = ScriptDom.QuoteType.NotQuoted) {
            this.@value = @value;
            this.quoteType = quoteType;
        }
    
        public ScriptDom.SqlCommandIdentifier ToMutableConcrete() {
            var ret = new ScriptDom.SqlCommandIdentifier();
            ret.Value = @value;
            ret.QuoteType = quoteType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + quoteType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SqlCommandIdentifier);
        } 
        
        public bool Equals(SqlCommandIdentifier other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QuoteType>.Default.Equals(other.QuoteType, quoteType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SqlCommandIdentifier left, SqlCommandIdentifier right) {
            return EqualityComparer<SqlCommandIdentifier>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SqlCommandIdentifier left, SqlCommandIdentifier right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SqlCommandIdentifier)that;
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.quoteType, othr.quoteType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SqlCommandIdentifier left, SqlCommandIdentifier right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SqlCommandIdentifier left, SqlCommandIdentifier right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SqlCommandIdentifier left, SqlCommandIdentifier right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SqlCommandIdentifier left, SqlCommandIdentifier right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SqlCommandIdentifier FromMutable(ScriptDom.SqlCommandIdentifier fragment) {
            return (SqlCommandIdentifier)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
