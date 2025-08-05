using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
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
            ret.Name = (ScriptDom.SchemaObjectName)name?.ToMutable();
            ret.Expression = (ScriptDom.BooleanExpression)expression?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateRuleStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateRuleStatement left, CreateRuleStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateRuleStatement left, CreateRuleStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateRuleStatement left, CreateRuleStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateRuleStatement left, CreateRuleStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateRuleStatement FromMutable(ScriptDom.CreateRuleStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateRuleStatement)) { throw new NotImplementedException("Unexpected subtype of CreateRuleStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateRuleStatement(
                name: ImmutableDom.SchemaObjectName.FromMutable(fragment.Name),
                expression: ImmutableDom.BooleanExpression.FromMutable(fragment.Expression)
            );
        }
    
    }

}
