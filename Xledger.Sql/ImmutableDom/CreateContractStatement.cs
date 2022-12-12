using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateContractStatement : TSqlStatement, IEquatable<CreateContractStatement> {
        Identifier name;
        IReadOnlyList<ContractMessage> messages;
        Identifier owner;
    
        public Identifier Name => name;
        public IReadOnlyList<ContractMessage> Messages => messages;
        public Identifier Owner => owner;
    
        public CreateContractStatement(Identifier name = null, IReadOnlyList<ContractMessage> messages = null, Identifier owner = null) {
            this.name = name;
            this.messages = messages is null ? ImmList<ContractMessage>.Empty : ImmList<ContractMessage>.FromList(messages);
            this.owner = owner;
        }
    
        public ScriptDom.CreateContractStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateContractStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Messages.AddRange(messages.Select(c => (ScriptDom.ContractMessage)c.ToMutable()));
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
    
    }

}
