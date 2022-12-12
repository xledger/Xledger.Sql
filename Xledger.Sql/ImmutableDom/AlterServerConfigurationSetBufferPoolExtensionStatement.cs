using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationSetBufferPoolExtensionStatement : TSqlStatement, IEquatable<AlterServerConfigurationSetBufferPoolExtensionStatement> {
        protected IReadOnlyList<AlterServerConfigurationBufferPoolExtensionOption> options;
    
        public IReadOnlyList<AlterServerConfigurationBufferPoolExtensionOption> Options => options;
    
        public AlterServerConfigurationSetBufferPoolExtensionStatement(IReadOnlyList<AlterServerConfigurationBufferPoolExtensionOption> options = null) {
            this.options = options is null ? ImmList<AlterServerConfigurationBufferPoolExtensionOption>.Empty : ImmList<AlterServerConfigurationBufferPoolExtensionOption>.FromList(options);
        }
    
        public ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AlterServerConfigurationBufferPoolExtensionOption)c.ToMutable()));
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
            return Equals(obj as AlterServerConfigurationSetBufferPoolExtensionStatement);
        } 
        
        public bool Equals(AlterServerConfigurationSetBufferPoolExtensionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<AlterServerConfigurationBufferPoolExtensionOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationSetBufferPoolExtensionStatement left, AlterServerConfigurationSetBufferPoolExtensionStatement right) {
            return EqualityComparer<AlterServerConfigurationSetBufferPoolExtensionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationSetBufferPoolExtensionStatement left, AlterServerConfigurationSetBufferPoolExtensionStatement right) {
            return !(left == right);
        }
    
    }

}
