using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropSearchPropertyListAction : SearchPropertyListAction, IEquatable<DropSearchPropertyListAction> {
        protected StringLiteral propertyName;
    
        public StringLiteral PropertyName => propertyName;
    
        public DropSearchPropertyListAction(StringLiteral propertyName = null) {
            this.propertyName = propertyName;
        }
    
        public ScriptDom.DropSearchPropertyListAction ToMutableConcrete() {
            var ret = new ScriptDom.DropSearchPropertyListAction();
            ret.PropertyName = (ScriptDom.StringLiteral)propertyName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(propertyName is null)) {
                h = h * 23 + propertyName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropSearchPropertyListAction);
        } 
        
        public bool Equals(DropSearchPropertyListAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.PropertyName, propertyName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropSearchPropertyListAction left, DropSearchPropertyListAction right) {
            return EqualityComparer<DropSearchPropertyListAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropSearchPropertyListAction left, DropSearchPropertyListAction right) {
            return !(left == right);
        }
    
        public static DropSearchPropertyListAction FromMutable(ScriptDom.DropSearchPropertyListAction fragment) {
            return (DropSearchPropertyListAction)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
