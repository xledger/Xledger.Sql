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
            this.brokerPriorityParameters = ImmList<BrokerPriorityParameter>.FromList(brokerPriorityParameters);
        }
    
        public ScriptDom.CreateBrokerPriorityStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateBrokerPriorityStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.BrokerPriorityParameters.AddRange(brokerPriorityParameters.SelectList(c => (ScriptDom.BrokerPriorityParameter)c?.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateBrokerPriorityStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.brokerPriorityParameters, othr.brokerPriorityParameters);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateBrokerPriorityStatement left, CreateBrokerPriorityStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateBrokerPriorityStatement left, CreateBrokerPriorityStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateBrokerPriorityStatement left, CreateBrokerPriorityStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateBrokerPriorityStatement left, CreateBrokerPriorityStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
