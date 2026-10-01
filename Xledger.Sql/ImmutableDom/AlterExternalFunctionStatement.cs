using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterExternalFunctionStatement : ExternalFunctionStatement, IEquatable<AlterExternalFunctionStatement> {
        public AlterExternalFunctionStatement(SchemaObjectName name = null, IReadOnlyList<ProcedureParameter> parameters = null, DataTypeReference returnType = null, SchemaObjectName externalName = null) {
            this.name = name;
            this.parameters = parameters.ToImmArray<ProcedureParameter>();
            this.returnType = returnType;
            this.externalName = externalName;
        }
    
        public ScriptDom.AlterExternalFunctionStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterExternalFunctionStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name?.ToMutable();
            ret.Parameters.AddRange(parameters.Select(c => (ScriptDom.ProcedureParameter)c?.ToMutable()));
            ret.ReturnType = (ScriptDom.DataTypeReference)returnType?.ToMutable();
            ret.ExternalName = (ScriptDom.SchemaObjectName)externalName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + parameters.GetHashCode();
            if (!(returnType is null)) {
                h = h * 23 + returnType.GetHashCode();
            }
            if (!(externalName is null)) {
                h = h * 23 + externalName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterExternalFunctionStatement);
        } 
        
        public bool Equals(AlterExternalFunctionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ProcedureParameter>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.ReturnType, returnType)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.ExternalName, externalName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterExternalFunctionStatement left, AlterExternalFunctionStatement right) {
            return EqualityComparer<AlterExternalFunctionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterExternalFunctionStatement left, AlterExternalFunctionStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterExternalFunctionStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.returnType, othr.returnType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.externalName, othr.externalName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterExternalFunctionStatement left, AlterExternalFunctionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterExternalFunctionStatement left, AlterExternalFunctionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterExternalFunctionStatement left, AlterExternalFunctionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterExternalFunctionStatement left, AlterExternalFunctionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterExternalFunctionStatement FromMutable(ScriptDom.AlterExternalFunctionStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterExternalFunctionStatement)) { throw new NotImplementedException("Unexpected subtype of AlterExternalFunctionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterExternalFunctionStatement(
                name: ImmutableDom.SchemaObjectName.FromMutable(fragment.Name),
                parameters: fragment.Parameters.ToImmArray(ImmutableDom.ProcedureParameter.FromMutable),
                returnType: ImmutableDom.DataTypeReference.FromMutable(fragment.ReturnType),
                externalName: ImmutableDom.SchemaObjectName.FromMutable(fragment.ExternalName)
            );
        }
    
    }

}
