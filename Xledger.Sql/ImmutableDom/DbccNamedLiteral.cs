using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DbccNamedLiteral : TSqlFragment, IEquatable<DbccNamedLiteral> {
        string name;
        ScalarExpression @value;
    
        public string Name => name;
        public ScalarExpression Value => @value;
    
        public DbccNamedLiteral(string name = null, ScalarExpression @value = null) {
            this.name = name;
            this.@value = @value;
        }
    
        public ScriptDom.DbccNamedLiteral ToMutableConcrete() {
            var ret = new ScriptDom.DbccNamedLiteral();
            ret.Name = name;
            ret.Value = (ScriptDom.ScalarExpression)@value.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DbccNamedLiteral);
        } 
        
        public bool Equals(DbccNamedLiteral other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DbccNamedLiteral left, DbccNamedLiteral right) {
            return EqualityComparer<DbccNamedLiteral>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DbccNamedLiteral left, DbccNamedLiteral right) {
            return !(left == right);
        }
    
    }

}
