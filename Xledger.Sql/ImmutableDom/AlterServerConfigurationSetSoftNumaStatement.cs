using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationSetSoftNumaStatement : TSqlStatement, IEquatable<AlterServerConfigurationSetSoftNumaStatement> {
        protected IReadOnlyList<AlterServerConfigurationSoftNumaOption> options;
    
        public IReadOnlyList<AlterServerConfigurationSoftNumaOption> Options => options;
    
        public AlterServerConfigurationSetSoftNumaStatement(IReadOnlyList<AlterServerConfigurationSoftNumaOption> options = null) {
            this.options = ImmList<AlterServerConfigurationSoftNumaOption>.FromList(options);
        }
    
        public ScriptDom.AlterServerConfigurationSetSoftNumaStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationSetSoftNumaStatement();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AlterServerConfigurationSoftNumaOption)c?.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterServerConfigurationSetSoftNumaStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterServerConfigurationSetSoftNumaStatement left, AlterServerConfigurationSetSoftNumaStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterServerConfigurationSetSoftNumaStatement left, AlterServerConfigurationSetSoftNumaStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterServerConfigurationSetSoftNumaStatement left, AlterServerConfigurationSetSoftNumaStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterServerConfigurationSetSoftNumaStatement left, AlterServerConfigurationSetSoftNumaStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterServerConfigurationSetSoftNumaStatement FromMutable(ScriptDom.AlterServerConfigurationSetSoftNumaStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterServerConfigurationSetSoftNumaStatement)) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationSetSoftNumaStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationSetSoftNumaStatement(
                options: fragment.Options.SelectList(ImmutableDom.AlterServerConfigurationSoftNumaOption.FromMutable)
            );
        }
    
    }

}
