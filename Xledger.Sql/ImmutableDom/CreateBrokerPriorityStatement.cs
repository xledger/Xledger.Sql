using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateBrokerPriorityStatement : BrokerPriorityStatement, IEquatable<CreateBrokerPriorityStatement> {
        public CreateBrokerPriorityStatement(Identifier name = null, IReadOnlyList<BrokerPriorityParameter> brokerPriorityParameters = null) {
            this.name = name;
            this.brokerPriorityParameters = brokerPriorityParameters is null ? ImmList<BrokerPriorityParameter>.Empty : ImmList<BrokerPriorityParameter>.FromList(brokerPriorityParameters);
        }
    
        public ScriptDom.CreateBrokerPriorityStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateBrokerPriorityStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.BrokerPriorityParameters.AddRange(brokerPriorityParameters.SelectList(c => (ScriptDom.BrokerPriorityParameter)c.ToMutable()));
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
            h = h * 23 + brokerPriorityParameters.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateBrokerPriorityStatement);
        } 
        
        public bool Equals(CreateBrokerPriorityStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<BrokerPriorityParameter>>.Default.Equals(other.BrokerPriorityParameters, brokerPriorityParameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateBrokerPriorityStatement left, CreateBrokerPriorityStatement right) {
            return EqualityComparer<CreateBrokerPriorityStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateBrokerPriorityStatement left, CreateBrokerPriorityStatement right) {
            return !(left == right);
        }
    
        public static CreateBrokerPriorityStatement FromMutable(ScriptDom.CreateBrokerPriorityStatement fragment) {
            return (CreateBrokerPriorityStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
