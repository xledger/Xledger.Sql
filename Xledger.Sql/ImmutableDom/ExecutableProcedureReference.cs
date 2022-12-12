using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
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
            this.parameters = parameters is null ? ImmList<ExecuteParameter>.Empty : ImmList<ExecuteParameter>.FromList(parameters);
        }
    
        public ScriptDom.ExecutableProcedureReference ToMutableConcrete() {
            var ret = new ScriptDom.ExecutableProcedureReference();
            ret.ProcedureReference = (ScriptDom.ProcedureReferenceName)procedureReference.ToMutable();
            ret.AdHocDataSource = (ScriptDom.AdHocDataSource)adHocDataSource.ToMutable();
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ExecuteParameter)c.ToMutable()));
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
    
    }

}
