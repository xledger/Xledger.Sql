using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SourceDeclaration : ScalarExpression, IEquatable<SourceDeclaration> {
        protected EventSessionObjectName @value;
    
        public EventSessionObjectName Value => @value;
    
        public SourceDeclaration(EventSessionObjectName @value = null) {
            this.@value = @value;
        }
    
        public ScriptDom.SourceDeclaration ToMutableConcrete() {
            var ret = new ScriptDom.SourceDeclaration();
            ret.Value = (ScriptDom.EventSessionObjectName)@value.ToMutable();
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
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SourceDeclaration);
        } 
        
        public bool Equals(SourceDeclaration other) {
            if (other is null) { return false; }
            if (!EqualityComparer<EventSessionObjectName>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SourceDeclaration left, SourceDeclaration right) {
            return EqualityComparer<SourceDeclaration>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SourceDeclaration left, SourceDeclaration right) {
            return !(left == right);
        }
    
    }

}
