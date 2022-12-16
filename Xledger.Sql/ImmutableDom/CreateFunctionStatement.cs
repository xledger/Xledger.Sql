using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateFunctionStatement : FunctionStatementBody, IEquatable<CreateFunctionStatement> {
        public CreateFunctionStatement(SchemaObjectName name = null, FunctionReturnType returnType = null, IReadOnlyList<FunctionOption> options = null, OrderBulkInsertOption orderHint = null, IReadOnlyList<ProcedureParameter> parameters = null, StatementList statementList = null, MethodSpecifier methodSpecifier = null) {
            this.name = name;
            this.returnType = returnType;
            this.options = ImmList<FunctionOption>.FromList(options);
            this.orderHint = orderHint;
            this.parameters = ImmList<ProcedureParameter>.FromList(parameters);
            this.statementList = statementList;
            this.methodSpecifier = methodSpecifier;
        }
    
        public ScriptDom.CreateFunctionStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateFunctionStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name?.ToMutable();
            ret.ReturnType = (ScriptDom.FunctionReturnType)returnType?.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.FunctionOption)c?.ToMutable()));
            ret.OrderHint = (ScriptDom.OrderBulkInsertOption)orderHint?.ToMutable();
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
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(returnType is null)) {
                h = h * 23 + returnType.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            if (!(orderHint is null)) {
                h = h * 23 + orderHint.GetHashCode();
            }
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
            return Equals(obj as CreateFunctionStatement);
        } 
        
        public bool Equals(CreateFunctionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<FunctionReturnType>.Default.Equals(other.ReturnType, returnType)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<FunctionOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<OrderBulkInsertOption>.Default.Equals(other.OrderHint, orderHint)) {
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
        
        public static bool operator ==(CreateFunctionStatement left, CreateFunctionStatement right) {
            return EqualityComparer<CreateFunctionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateFunctionStatement left, CreateFunctionStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateFunctionStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.returnType, othr.returnType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.orderHint, othr.orderHint);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.statementList, othr.statementList);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.methodSpecifier, othr.methodSpecifier);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateFunctionStatement left, CreateFunctionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateFunctionStatement left, CreateFunctionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateFunctionStatement left, CreateFunctionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateFunctionStatement left, CreateFunctionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
