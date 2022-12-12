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
    
    }

}
