using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecutableProcedureReference : ExecutableEntity, IEquatable<ExecutableProcedureReference> {
        protected ProcedureReferenceName procedureReference;
        protected AdHocDataSource adHocDataSource;
    
        public ProcedureReferenceName ProcedureReference => procedureReference;
        public AdHocDataSource AdHocDataSource => adHocDataSource;
    
        public ExecutableProcedureReference(ProcedureReferenceName procedureReference = null, AdHocDataSource adHocDataSource = null, IReadOnlyList<ExecuteParameter> parameters = null) {
            this.procedureReference = procedureReference;
            this.adHocDataSource = adHocDataSource;
            this.parameters = parameters.ToImmArray<ExecuteParameter>();
        }
    
        public ScriptDom.ExecutableProcedureReference ToMutableConcrete() {
            var ret = new ScriptDom.ExecutableProcedureReference();
            ret.ProcedureReference = (ScriptDom.ProcedureReferenceName)procedureReference?.ToMutable();
            ret.AdHocDataSource = (ScriptDom.AdHocDataSource)adHocDataSource?.ToMutable();
            ret.Parameters.AddRange(parameters.Select(c => (ScriptDom.ExecuteParameter)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(procedureReference is null)) {
                h = h * 23 + procedureReference.GetHashCode();
            }
            if (!(adHocDataSource is null)) {
                h = h * 23 + adHocDataSource.GetHashCode();
            }
            h = h * 23 + parameters.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecutableProcedureReference);
        } 
        
        public bool Equals(ExecutableProcedureReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ProcedureReferenceName>.Default.Equals(other.ProcedureReference, procedureReference)) {
                return false;
            }
            if (!EqualityComparer<AdHocDataSource>.Default.Equals(other.AdHocDataSource, adHocDataSource)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExecuteParameter>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecutableProcedureReference left, ExecutableProcedureReference right) {
            return EqualityComparer<ExecutableProcedureReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecutableProcedureReference left, ExecutableProcedureReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExecutableProcedureReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.procedureReference, othr.procedureReference);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.adHocDataSource, othr.adHocDataSource);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExecutableProcedureReference left, ExecutableProcedureReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExecutableProcedureReference left, ExecutableProcedureReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExecutableProcedureReference left, ExecutableProcedureReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExecutableProcedureReference left, ExecutableProcedureReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExecutableProcedureReference FromMutable(ScriptDom.ExecutableProcedureReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExecutableProcedureReference)) { throw new NotImplementedException("Unexpected subtype of ExecutableProcedureReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecutableProcedureReference(
                procedureReference: ImmutableDom.ProcedureReferenceName.FromMutable(fragment.ProcedureReference),
                adHocDataSource: ImmutableDom.AdHocDataSource.FromMutable(fragment.AdHocDataSource),
                parameters: fragment.Parameters.ToImmArray(ImmutableDom.ExecuteParameter.FromMutable)
            );
        }
    
    }

}
