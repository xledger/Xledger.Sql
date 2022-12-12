using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationSetDiagnosticsLogStatement : TSqlStatement, IEquatable<AlterServerConfigurationSetDiagnosticsLogStatement> {
        IReadOnlyList<AlterServerConfigurationDiagnosticsLogOption> options;
    
        public IReadOnlyList<AlterServerConfigurationDiagnosticsLogOption> Options => options;
    
        public AlterServerConfigurationSetDiagnosticsLogStatement(IReadOnlyList<AlterServerConfigurationDiagnosticsLogOption> options = null) {
            this.options = options is null ? ImmList<AlterServerConfigurationDiagnosticsLogOption>.Empty : ImmList<AlterServerConfigurationDiagnosticsLogOption>.FromList(options);
        }
    
        public ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement();
            ret.Options.AddRange(options.Select(c => (ScriptDom.AlterServerConfigurationDiagnosticsLogOption)c.ToMutable()));
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
            return Equals(obj as AlterServerConfigurationSetDiagnosticsLogStatement);
        } 
        
        public bool Equals(AlterServerConfigurationSetDiagnosticsLogStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<AlterServerConfigurationDiagnosticsLogOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationSetDiagnosticsLogStatement left, AlterServerConfigurationSetDiagnosticsLogStatement right) {
            return EqualityComparer<AlterServerConfigurationSetDiagnosticsLogStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationSetDiagnosticsLogStatement left, AlterServerConfigurationSetDiagnosticsLogStatement right) {
            return !(left == right);
        }
    
    }

}
