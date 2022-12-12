using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ServiceContract : TSqlFragment, IEquatable<ServiceContract> {
        protected Identifier name;
        protected ScriptDom.AlterAction action = ScriptDom.AlterAction.None;
    
        public Identifier Name => name;
        public ScriptDom.AlterAction Action => action;
    
        public ServiceContract(Identifier name = null, ScriptDom.AlterAction action = ScriptDom.AlterAction.None) {
            this.name = name;
            this.action = action;
        }
    
        public ScriptDom.ServiceContract ToMutableConcrete() {
            var ret = new ScriptDom.ServiceContract();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Action = action;
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
            h = h * 23 + action.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ServiceContract);
        } 
        
        public bool Equals(ServiceContract other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AlterAction>.Default.Equals(other.Action, action)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ServiceContract left, ServiceContract right) {
            return EqualityComparer<ServiceContract>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ServiceContract left, ServiceContract right) {
            return !(left == right);
        }
    
    }

}
