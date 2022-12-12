using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AvailabilityReplica : TSqlFragment, IEquatable<AvailabilityReplica> {
        protected StringLiteral serverName;
        protected IReadOnlyList<AvailabilityReplicaOption> options;
    
        public StringLiteral ServerName => serverName;
        public IReadOnlyList<AvailabilityReplicaOption> Options => options;
    
        public AvailabilityReplica(StringLiteral serverName = null, IReadOnlyList<AvailabilityReplicaOption> options = null) {
            this.serverName = serverName;
            this.options = options is null ? ImmList<AvailabilityReplicaOption>.Empty : ImmList<AvailabilityReplicaOption>.FromList(options);
        }
    
        public ScriptDom.AvailabilityReplica ToMutableConcrete() {
            var ret = new ScriptDom.AvailabilityReplica();
            ret.ServerName = (ScriptDom.StringLiteral)serverName.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AvailabilityReplicaOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(serverName is null)) {
                h = h * 23 + serverName.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AvailabilityReplica);
        } 
        
        public bool Equals(AvailabilityReplica other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.ServerName, serverName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<AvailabilityReplicaOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AvailabilityReplica left, AvailabilityReplica right) {
            return EqualityComparer<AvailabilityReplica>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AvailabilityReplica left, AvailabilityReplica right) {
            return !(left == right);
        }
    
    }

}
