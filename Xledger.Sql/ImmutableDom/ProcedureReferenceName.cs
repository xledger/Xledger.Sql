using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ProcedureReferenceName : TSqlFragment, IEquatable<ProcedureReferenceName> {
        protected ProcedureReference procedureReference;
        protected VariableReference procedureVariable;
    
        public ProcedureReference ProcedureReference => procedureReference;
        public VariableReference ProcedureVariable => procedureVariable;
    
        public ProcedureReferenceName(ProcedureReference procedureReference = null, VariableReference procedureVariable = null) {
            this.procedureReference = procedureReference;
            this.procedureVariable = procedureVariable;
        }
    
        public ScriptDom.ProcedureReferenceName ToMutableConcrete() {
            var ret = new ScriptDom.ProcedureReferenceName();
            ret.ProcedureReference = (ScriptDom.ProcedureReference)procedureReference?.ToMutable();
            ret.ProcedureVariable = (ScriptDom.VariableReference)procedureVariable?.ToMutable();
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
            if (!(procedureVariable is null)) {
                h = h * 23 + procedureVariable.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ProcedureReferenceName);
        } 
        
        public bool Equals(ProcedureReferenceName other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ProcedureReference>.Default.Equals(other.ProcedureReference, procedureReference)) {
                return false;
            }
            if (!EqualityComparer<VariableReference>.Default.Equals(other.ProcedureVariable, procedureVariable)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ProcedureReferenceName left, ProcedureReferenceName right) {
            return EqualityComparer<ProcedureReferenceName>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ProcedureReferenceName left, ProcedureReferenceName right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ProcedureReferenceName)that;
            compare = Comparer.DefaultInvariant.Compare(this.procedureReference, othr.procedureReference);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.procedureVariable, othr.procedureVariable);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ProcedureReferenceName left, ProcedureReferenceName right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ProcedureReferenceName left, ProcedureReferenceName right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ProcedureReferenceName left, ProcedureReferenceName right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ProcedureReferenceName left, ProcedureReferenceName right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
