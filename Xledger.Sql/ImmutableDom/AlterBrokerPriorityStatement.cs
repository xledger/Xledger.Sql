using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterBrokerPriorityStatement : BrokerPriorityStatement, IEquatable<AlterBrokerPriorityStatement> {
        public AlterBrokerPriorityStatement(Identifier name = null, IReadOnlyList<BrokerPriorityParameter> brokerPriorityParameters = null) {
            this.name = name;
            this.brokerPriorityParameters = brokerPriorityParameters is null ? ImmList<BrokerPriorityParameter>.Empty : ImmList<BrokerPriorityParameter>.FromList(brokerPriorityParameters);
        }
    
        public ScriptDom.AlterBrokerPriorityStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterBrokerPriorityStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.BrokerPriorityParameters.AddRange(brokerPriorityParameters.Select(c => (ScriptDom.BrokerPriorityParameter)c.ToMutable()));
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
            return Equals(obj as AlterBrokerPriorityStatement);
        } 
        
        public bool Equals(AlterBrokerPriorityStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<BrokerPriorityParameter>>.Default.Equals(other.BrokerPriorityParameters, brokerPriorityParameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterBrokerPriorityStatement left, AlterBrokerPriorityStatement right) {
            return EqualityComparer<AlterBrokerPriorityStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterBrokerPriorityStatement left, AlterBrokerPriorityStatement right) {
            return !(left == right);
        }
    
    }

}
