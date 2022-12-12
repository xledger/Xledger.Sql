using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UpdateCall : BooleanExpression, IEquatable<UpdateCall> {
        protected Identifier identifier;
    
        public Identifier Identifier => identifier;
    
        public UpdateCall(Identifier identifier = null) {
            this.identifier = identifier;
        }
    
        public ScriptDom.UpdateCall ToMutableConcrete() {
            var ret = new ScriptDom.UpdateCall();
            ret.Identifier = (ScriptDom.Identifier)identifier.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(identifier is null)) {
                h = h * 23 + identifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UpdateCall);
        } 
        
        public bool Equals(UpdateCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Identifier, identifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UpdateCall left, UpdateCall right) {
            return EqualityComparer<UpdateCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UpdateCall left, UpdateCall right) {
            return !(left == right);
        }
    
    }

}
