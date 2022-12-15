using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationSetExternalAuthenticationStatement : TSqlStatement, IEquatable<AlterServerConfigurationSetExternalAuthenticationStatement> {
        protected IReadOnlyList<AlterServerConfigurationExternalAuthenticationOption> options;
    
        public IReadOnlyList<AlterServerConfigurationExternalAuthenticationOption> Options => options;
    
        public AlterServerConfigurationSetExternalAuthenticationStatement(IReadOnlyList<AlterServerConfigurationExternalAuthenticationOption> options = null) {
            this.options = ImmList<AlterServerConfigurationExternalAuthenticationOption>.FromList(options);
        }
    
        public ScriptDom.AlterServerConfigurationSetExternalAuthenticationStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationSetExternalAuthenticationStatement();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AlterServerConfigurationExternalAuthenticationOption)c.ToMutable()));
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
            return Equals(obj as AlterServerConfigurationSetExternalAuthenticationStatement);
        } 
        
        public bool Equals(AlterServerConfigurationSetExternalAuthenticationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<AlterServerConfigurationExternalAuthenticationOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationSetExternalAuthenticationStatement left, AlterServerConfigurationSetExternalAuthenticationStatement right) {
            return EqualityComparer<AlterServerConfigurationSetExternalAuthenticationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationSetExternalAuthenticationStatement left, AlterServerConfigurationSetExternalAuthenticationStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterServerConfigurationSetExternalAuthenticationStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterServerConfigurationSetExternalAuthenticationStatement left, AlterServerConfigurationSetExternalAuthenticationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterServerConfigurationSetExternalAuthenticationStatement left, AlterServerConfigurationSetExternalAuthenticationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterServerConfigurationSetExternalAuthenticationStatement left, AlterServerConfigurationSetExternalAuthenticationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterServerConfigurationSetExternalAuthenticationStatement left, AlterServerConfigurationSetExternalAuthenticationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
