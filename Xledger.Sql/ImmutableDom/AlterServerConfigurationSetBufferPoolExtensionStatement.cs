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
            this.options = ImmList<AlterServerConfigurationBufferPoolExtensionOption>.FromList(options);
        }
    
        public ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AlterServerConfigurationBufferPoolExtensionOption)c?.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterServerConfigurationSetBufferPoolExtensionStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterServerConfigurationSetBufferPoolExtensionStatement left, AlterServerConfigurationSetBufferPoolExtensionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterServerConfigurationSetBufferPoolExtensionStatement left, AlterServerConfigurationSetBufferPoolExtensionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterServerConfigurationSetBufferPoolExtensionStatement left, AlterServerConfigurationSetBufferPoolExtensionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterServerConfigurationSetBufferPoolExtensionStatement left, AlterServerConfigurationSetBufferPoolExtensionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
