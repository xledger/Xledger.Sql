using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterBrokerPriorityStatement : BrokerPriorityStatement, IEquatable<AlterBrokerPriorityStatement> {
        public AlterBrokerPriorityStatement(Identifier name = null, IReadOnlyList<BrokerPriorityParameter> brokerPriorityParameters = null) {
            this.name = name;
            this.brokerPriorityParameters = brokerPriorityParameters.ToImmArray<BrokerPriorityParameter>();
        }
    
        public ScriptDom.AlterBrokerPriorityStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterBrokerPriorityStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.BrokerPriorityParameters.AddRange(brokerPriorityParameters.Select(c => (ScriptDom.BrokerPriorityParameter)c?.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterBrokerPriorityStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.brokerPriorityParameters, othr.brokerPriorityParameters);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterBrokerPriorityStatement left, AlterBrokerPriorityStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterBrokerPriorityStatement left, AlterBrokerPriorityStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterBrokerPriorityStatement left, AlterBrokerPriorityStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterBrokerPriorityStatement left, AlterBrokerPriorityStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterBrokerPriorityStatement FromMutable(ScriptDom.AlterBrokerPriorityStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterBrokerPriorityStatement)) { throw new NotImplementedException("Unexpected subtype of AlterBrokerPriorityStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterBrokerPriorityStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                brokerPriorityParameters: fragment.BrokerPriorityParameters.ToImmArray(ImmutableDom.BrokerPriorityParameter.FromMutable)
            );
        }
    
    }

}
