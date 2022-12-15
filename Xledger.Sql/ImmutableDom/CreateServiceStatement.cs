using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateServiceStatement : AlterCreateServiceStatementBase, IEquatable<CreateServiceStatement> {
        protected Identifier owner;
    
        public Identifier Owner => owner;
    
        public CreateServiceStatement(Identifier owner = null, Identifier name = null, SchemaObjectName queueName = null, IReadOnlyList<ServiceContract> serviceContracts = null) {
            this.owner = owner;
            this.name = name;
            this.queueName = queueName;
            this.serviceContracts = ImmList<ServiceContract>.FromList(serviceContracts);
        }
    
        public ScriptDom.CreateServiceStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateServiceStatement();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.QueueName = (ScriptDom.SchemaObjectName)queueName.ToMutable();
            ret.ServiceContracts.AddRange(serviceContracts.SelectList(c => (ScriptDom.ServiceContract)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(queueName is null)) {
                h = h * 23 + queueName.GetHashCode();
            }
            h = h * 23 + serviceContracts.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateServiceStatement);
        } 
        
        public bool Equals(CreateServiceStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.QueueName, queueName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ServiceContract>>.Default.Equals(other.ServiceContracts, serviceContracts)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateServiceStatement left, CreateServiceStatement right) {
            return EqualityComparer<CreateServiceStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateServiceStatement left, CreateServiceStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateServiceStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.queueName, othr.queueName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.serviceContracts, othr.serviceContracts);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateServiceStatement left, CreateServiceStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateServiceStatement left, CreateServiceStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateServiceStatement left, CreateServiceStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateServiceStatement left, CreateServiceStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
