using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateRuleStatement : TSqlStatement, IEquatable<CreateRuleStatement> {
        protected SchemaObjectName name;
        protected BooleanExpression expression;
    
        public SchemaObjectName Name => name;
        public BooleanExpression Expression => expression;
    
        public CreateRuleStatement(SchemaObjectName name = null, BooleanExpression expression = null) {
            this.name = name;
            this.expression = expression;
        }
    
        public ScriptDom.CreateRuleStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateRuleStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            ret.Expression = (ScriptDom.BooleanExpression)expression.ToMutable();
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
            return Equals(obj as CreateRuleStatement);
        } 
        
        public bool Equals(CreateRuleStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateRuleStatement left, CreateRuleStatement right) {
            return EqualityComparer<CreateRuleStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateRuleStatement left, CreateRuleStatement right) {
            return !(left == right);
        }
    
    }

}
