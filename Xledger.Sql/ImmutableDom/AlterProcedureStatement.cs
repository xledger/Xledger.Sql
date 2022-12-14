using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterProcedureStatement : ProcedureStatementBody, IEquatable<AlterProcedureStatement> {
        public AlterProcedureStatement(ProcedureReference procedureReference = null, bool isForReplication = false, IReadOnlyList<ProcedureOption> options = null, IReadOnlyList<ProcedureParameter> parameters = null, StatementList statementList = null, MethodSpecifier methodSpecifier = null) {
            this.procedureReference = procedureReference;
            this.isForReplication = isForReplication;
            this.options = ImmList<ProcedureOption>.FromList(options);
            this.parameters = ImmList<ProcedureParameter>.FromList(parameters);
            this.statementList = statementList;
            this.methodSpecifier = methodSpecifier;
        }
    
        public ScriptDom.AlterProcedureStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterProcedureStatement();
            ret.ProcedureReference = (ScriptDom.ProcedureReference)procedureReference?.ToMutable();
            ret.IsForReplication = isForReplication;
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.ProcedureOption)c?.ToMutable()));
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ProcedureParameter)c?.ToMutable()));
            ret.StatementList = (ScriptDom.StatementList)statementList?.ToMutable();
            ret.MethodSpecifier = (ScriptDom.MethodSpecifier)methodSpecifier?.ToMutable();
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
            h = h * 23 + isForReplication.GetHashCode();
            h = h * 23 + options.GetHashCode();
            h = h * 23 + parameters.GetHashCode();
            if (!(statementList is null)) {
                h = h * 23 + statementList.GetHashCode();
            }
            if (!(methodSpecifier is null)) {
                h = h * 23 + methodSpecifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterProcedureStatement);
        } 
        
        public bool Equals(AlterProcedureStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ProcedureReference>.Default.Equals(other.ProcedureReference, procedureReference)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsForReplication, isForReplication)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ProcedureOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ProcedureParameter>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<StatementList>.Default.Equals(other.StatementList, statementList)) {
                return false;
            }
            if (!EqualityComparer<MethodSpecifier>.Default.Equals(other.MethodSpecifier, methodSpecifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterProcedureStatement left, AlterProcedureStatement right) {
            return EqualityComparer<AlterProcedureStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterProcedureStatement left, AlterProcedureStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterProcedureStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.procedureReference, othr.procedureReference);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isForReplication, othr.isForReplication);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.statementList, othr.statementList);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.methodSpecifier, othr.methodSpecifier);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterProcedureStatement left, AlterProcedureStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterProcedureStatement left, AlterProcedureStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterProcedureStatement left, AlterProcedureStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterProcedureStatement left, AlterProcedureStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterProcedureStatement FromMutable(ScriptDom.AlterProcedureStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterProcedureStatement)) { throw new NotImplementedException("Unexpected subtype of AlterProcedureStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterProcedureStatement(
                procedureReference: ImmutableDom.ProcedureReference.FromMutable(fragment.ProcedureReference),
                isForReplication: fragment.IsForReplication,
                options: fragment.Options.SelectList(ImmutableDom.ProcedureOption.FromMutable),
                parameters: fragment.Parameters.SelectList(ImmutableDom.ProcedureParameter.FromMutable),
                statementList: ImmutableDom.StatementList.FromMutable(fragment.StatementList),
                methodSpecifier: ImmutableDom.MethodSpecifier.FromMutable(fragment.MethodSpecifier)
            );
        }
    
    }

}
