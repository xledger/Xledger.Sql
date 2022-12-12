using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationSetSoftNumaStatement : TSqlStatement, IEquatable<AlterServerConfigurationSetSoftNumaStatement> {
        IReadOnlyList<AlterServerConfigurationSoftNumaOption> options;
    
        public IReadOnlyList<AlterServerConfigurationSoftNumaOption> Options => options;
    
        public AlterServerConfigurationSetSoftNumaStatement(IReadOnlyList<AlterServerConfigurationSoftNumaOption> options = null) {
            this.options = options is null ? ImmList<AlterServerConfigurationSoftNumaOption>.Empty : ImmList<AlterServerConfigurationSoftNumaOption>.FromList(options);
        }
    
        public ScriptDom.AlterServerConfigurationSetSoftNumaStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationSetSoftNumaStatement();
            ret.Options.AddRange(options.Select(c => (ScriptDom.AlterServerConfigurationSoftNumaOption)c.ToMutable()));
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
            return Equals(obj as AlterServerConfigurationSetSoftNumaStatement);
        } 
        
        public bool Equals(AlterServerConfigurationSetSoftNumaStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<AlterServerConfigurationSoftNumaOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationSetSoftNumaStatement left, AlterServerConfigurationSetSoftNumaStatement right) {
            return EqualityComparer<AlterServerConfigurationSetSoftNumaStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationSetSoftNumaStatement left, AlterServerConfigurationSetSoftNumaStatement right) {
            return !(left == right);
        }
    
    }

}
