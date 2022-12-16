using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationSetHadrClusterStatement : TSqlStatement, IEquatable<AlterServerConfigurationSetHadrClusterStatement> {
        protected IReadOnlyList<AlterServerConfigurationHadrClusterOption> options;
    
        public IReadOnlyList<AlterServerConfigurationHadrClusterOption> Options => options;
    
        public AlterServerConfigurationSetHadrClusterStatement(IReadOnlyList<AlterServerConfigurationHadrClusterOption> options = null) {
            this.options = ImmList<AlterServerConfigurationHadrClusterOption>.FromList(options);
        }
    
        public ScriptDom.AlterServerConfigurationSetHadrClusterStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationSetHadrClusterStatement();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AlterServerConfigurationHadrClusterOption)c?.ToMutable()));
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
            return Equals(obj as AlterServerConfigurationSetHadrClusterStatement);
        } 
        
        public bool Equals(AlterServerConfigurationSetHadrClusterStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<AlterServerConfigurationHadrClusterOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationSetHadrClusterStatement left, AlterServerConfigurationSetHadrClusterStatement right) {
            return EqualityComparer<AlterServerConfigurationSetHadrClusterStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationSetHadrClusterStatement left, AlterServerConfigurationSetHadrClusterStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterServerConfigurationSetHadrClusterStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterServerConfigurationSetHadrClusterStatement left, AlterServerConfigurationSetHadrClusterStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterServerConfigurationSetHadrClusterStatement left, AlterServerConfigurationSetHadrClusterStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterServerConfigurationSetHadrClusterStatement left, AlterServerConfigurationSetHadrClusterStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterServerConfigurationSetHadrClusterStatement left, AlterServerConfigurationSetHadrClusterStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
