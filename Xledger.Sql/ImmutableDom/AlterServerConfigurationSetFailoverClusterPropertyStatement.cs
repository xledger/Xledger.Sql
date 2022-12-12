using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationSetFailoverClusterPropertyStatement : TSqlStatement, IEquatable<AlterServerConfigurationSetFailoverClusterPropertyStatement> {
        protected IReadOnlyList<AlterServerConfigurationFailoverClusterPropertyOption> options;
    
        public IReadOnlyList<AlterServerConfigurationFailoverClusterPropertyOption> Options => options;
    
        public AlterServerConfigurationSetFailoverClusterPropertyStatement(IReadOnlyList<AlterServerConfigurationFailoverClusterPropertyOption> options = null) {
            this.options = options is null ? ImmList<AlterServerConfigurationFailoverClusterPropertyOption>.Empty : ImmList<AlterServerConfigurationFailoverClusterPropertyOption>.FromList(options);
        }
    
        public ScriptDom.AlterServerConfigurationSetFailoverClusterPropertyStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationSetFailoverClusterPropertyStatement();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterServerConfigurationSetFailoverClusterPropertyStatement);
        } 
        
        public bool Equals(AlterServerConfigurationSetFailoverClusterPropertyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<AlterServerConfigurationFailoverClusterPropertyOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationSetFailoverClusterPropertyStatement left, AlterServerConfigurationSetFailoverClusterPropertyStatement right) {
            return EqualityComparer<AlterServerConfigurationSetFailoverClusterPropertyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationSetFailoverClusterPropertyStatement left, AlterServerConfigurationSetFailoverClusterPropertyStatement right) {
            return !(left == right);
        }
    
    }

}
