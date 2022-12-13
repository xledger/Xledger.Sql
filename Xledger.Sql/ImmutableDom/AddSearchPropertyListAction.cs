using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AddSearchPropertyListAction : SearchPropertyListAction, IEquatable<AddSearchPropertyListAction> {
        protected StringLiteral propertyName;
        protected StringLiteral guid;
        protected IntegerLiteral id;
        protected StringLiteral description;
    
        public StringLiteral PropertyName => propertyName;
        public StringLiteral Guid => guid;
        public IntegerLiteral Id => id;
        public StringLiteral Description => description;
    
        public AddSearchPropertyListAction(StringLiteral propertyName = null, StringLiteral guid = null, IntegerLiteral id = null, StringLiteral description = null) {
            this.propertyName = propertyName;
            this.guid = guid;
            this.id = id;
            this.description = description;
        }
    
        public ScriptDom.AddSearchPropertyListAction ToMutableConcrete() {
            var ret = new ScriptDom.AddSearchPropertyListAction();
            ret.PropertyName = (ScriptDom.StringLiteral)propertyName.ToMutable();
            ret.Guid = (ScriptDom.StringLiteral)guid.ToMutable();
            ret.Id = (ScriptDom.IntegerLiteral)id.ToMutable();
            ret.Description = (ScriptDom.StringLiteral)description.ToMutable();
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
            if (!(guid is null)) {
                h = h * 23 + guid.GetHashCode();
            }
            if (!(id is null)) {
                h = h * 23 + id.GetHashCode();
            }
            if (!(description is null)) {
                h = h * 23 + description.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AddSearchPropertyListAction);
        } 
        
        public bool Equals(AddSearchPropertyListAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.PropertyName, propertyName)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Guid, guid)) {
                return false;
            }
            if (!EqualityComparer<IntegerLiteral>.Default.Equals(other.Id, id)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Description, description)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AddSearchPropertyListAction left, AddSearchPropertyListAction right) {
            return EqualityComparer<AddSearchPropertyListAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AddSearchPropertyListAction left, AddSearchPropertyListAction right) {
            return !(left == right);
        }
    
        public static AddSearchPropertyListAction FromMutable(ScriptDom.AddSearchPropertyListAction fragment) {
            return (AddSearchPropertyListAction)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
