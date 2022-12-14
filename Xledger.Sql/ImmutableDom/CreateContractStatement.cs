using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateContractStatement : TSqlStatement, IEquatable<CreateContractStatement> {
        protected Identifier name;
        protected IReadOnlyList<ContractMessage> messages;
        protected Identifier owner;
    
        public Identifier Name => name;
        public IReadOnlyList<ContractMessage> Messages => messages;
        public Identifier Owner => owner;
    
        public CreateContractStatement(Identifier name = null, IReadOnlyList<ContractMessage> messages = null, Identifier owner = null) {
            this.name = name;
            this.messages = ImmList<ContractMessage>.FromList(messages);
            this.owner = owner;
        }
    
        public ScriptDom.CreateContractStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateContractStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Messages.AddRange(messages.SelectList(c => (ScriptDom.ContractMessage)c.ToMutable()));
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
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
            h = h * 23 + messages.GetHashCode();
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateContractStatement);
        } 
        
        public bool Equals(CreateContractStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ContractMessage>>.Default.Equals(other.Messages, messages)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateContractStatement left, CreateContractStatement right) {
            return EqualityComparer<CreateContractStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateContractStatement left, CreateContractStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateContractStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.messages, othr.messages);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static CreateContractStatement FromMutable(ScriptDom.CreateContractStatement fragment) {
            return (CreateContractStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
