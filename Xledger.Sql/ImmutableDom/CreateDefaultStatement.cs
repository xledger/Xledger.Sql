using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateDefaultStatement : TSqlStatement, IEquatable<CreateDefaultStatement> {
        SchemaObjectName name;
        ScalarExpression expression;
    
        public SchemaObjectName Name => name;
        public ScalarExpression Expression => expression;
    
        public CreateDefaultStatement(SchemaObjectName name = null, ScalarExpression expression = null) {
            this.name = name;
            this.expression = expression;
        }
    
        public ScriptDom.CreateDefaultStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateDefaultStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
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
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateDefaultStatement);
        } 
        
        public bool Equals(CreateDefaultStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateDefaultStatement left, CreateDefaultStatement right) {
            return EqualityComparer<CreateDefaultStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateDefaultStatement left, CreateDefaultStatement right) {
            return !(left == right);
        }
    
    }

}