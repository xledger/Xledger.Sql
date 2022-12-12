using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateRemoteServiceBindingStatement : RemoteServiceBindingStatementBase, IEquatable<CreateRemoteServiceBindingStatement> {
        Literal service;
        Identifier owner;
    
        public Literal Service => service;
        public Identifier Owner => owner;
    
        public CreateRemoteServiceBindingStatement(Literal service = null, Identifier owner = null, Identifier name = null, IReadOnlyList<RemoteServiceBindingOption> options = null) {
            this.service = service;
            this.owner = owner;
            this.name = name;
            this.options = options is null ? ImmList<RemoteServiceBindingOption>.Empty : ImmList<RemoteServiceBindingOption>.FromList(options);
        }
    
        public ScriptDom.CreateRemoteServiceBindingStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateRemoteServiceBindingStatement();
            ret.Service = (ScriptDom.Literal)service.ToMutable();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Options.AddRange(options.Select(c => (ScriptDom.RemoteServiceBindingOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(service is null)) {
                h = h * 23 + service.GetHashCode();
            }
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateRemoteServiceBindingStatement);
        } 
        
        public bool Equals(CreateRemoteServiceBindingStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Service, service)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<RemoteServiceBindingOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateRemoteServiceBindingStatement left, CreateRemoteServiceBindingStatement right) {
            return EqualityComparer<CreateRemoteServiceBindingStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateRemoteServiceBindingStatement left, CreateRemoteServiceBindingStatement right) {
            return !(left == right);
        }
    
    }

}
