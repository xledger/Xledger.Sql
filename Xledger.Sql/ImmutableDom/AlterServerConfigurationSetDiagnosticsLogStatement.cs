using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationSetDiagnosticsLogStatement : TSqlStatement, IEquatable<AlterServerConfigurationSetDiagnosticsLogStatement> {
        protected IReadOnlyList<AlterServerConfigurationDiagnosticsLogOption> options;
    
        public IReadOnlyList<AlterServerConfigurationDiagnosticsLogOption> Options => options;
    
        public AlterServerConfigurationSetDiagnosticsLogStatement(IReadOnlyList<AlterServerConfigurationDiagnosticsLogOption> options = null) {
            this.options = ImmList<AlterServerConfigurationDiagnosticsLogOption>.FromList(options);
        }
    
        public ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AlterServerConfigurationDiagnosticsLogOption)c.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterServerConfigurationSetDiagnosticsLogStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AlterServerConfigurationSetDiagnosticsLogStatement FromMutable(ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement fragment) {
            return (AlterServerConfigurationSetDiagnosticsLogStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
