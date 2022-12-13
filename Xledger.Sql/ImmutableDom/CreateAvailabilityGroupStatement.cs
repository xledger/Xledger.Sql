using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateAvailabilityGroupStatement : AvailabilityGroupStatement, IEquatable<CreateAvailabilityGroupStatement> {
        public CreateAvailabilityGroupStatement(Identifier name = null, IReadOnlyList<AvailabilityGroupOption> options = null, IReadOnlyList<Identifier> databases = null, IReadOnlyList<AvailabilityReplica> replicas = null) {
            this.name = name;
            this.options = options is null ? ImmList<AvailabilityGroupOption>.Empty : ImmList<AvailabilityGroupOption>.FromList(options);
            this.databases = databases is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(databases);
            this.replicas = replicas is null ? ImmList<AvailabilityReplica>.Empty : ImmList<AvailabilityReplica>.FromList(replicas);
        }
    
        public ScriptDom.CreateAvailabilityGroupStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateAvailabilityGroupStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AvailabilityGroupOption)c.ToMutable()));
            ret.Databases.AddRange(databases.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.Replicas.AddRange(replicas.SelectList(c => (ScriptDom.AvailabilityReplica)c.ToMutable()));
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
            h = h * 23 + options.GetHashCode();
            h = h * 23 + databases.GetHashCode();
            h = h * 23 + replicas.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateAvailabilityGroupStatement);
        } 
        
        public bool Equals(CreateAvailabilityGroupStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<AvailabilityGroupOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Databases, databases)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<AvailabilityReplica>>.Default.Equals(other.Replicas, replicas)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateAvailabilityGroupStatement left, CreateAvailabilityGroupStatement right) {
            return EqualityComparer<CreateAvailabilityGroupStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateAvailabilityGroupStatement left, CreateAvailabilityGroupStatement right) {
            return !(left == right);
        }
    
        public static CreateAvailabilityGroupStatement FromMutable(ScriptDom.CreateAvailabilityGroupStatement fragment) {
            return (CreateAvailabilityGroupStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
