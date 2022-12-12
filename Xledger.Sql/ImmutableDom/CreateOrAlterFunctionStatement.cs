using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateOrAlterFunctionStatement : FunctionStatementBody, IEquatable<CreateOrAlterFunctionStatement> {
        public CreateOrAlterFunctionStatement(SchemaObjectName name = null, FunctionReturnType returnType = null, IReadOnlyList<FunctionOption> options = null, OrderBulkInsertOption orderHint = null, IReadOnlyList<ProcedureParameter> parameters = null, StatementList statementList = null, MethodSpecifier methodSpecifier = null) {
            this.name = name;
            this.returnType = returnType;
            this.options = options is null ? ImmList<FunctionOption>.Empty : ImmList<FunctionOption>.FromList(options);
            this.orderHint = orderHint;
            this.parameters = parameters is null ? ImmList<ProcedureParameter>.Empty : ImmList<ProcedureParameter>.FromList(parameters);
            this.statementList = statementList;
            this.methodSpecifier = methodSpecifier;
        }
    
        public ScriptDom.CreateOrAlterFunctionStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateOrAlterFunctionStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            ret.ReturnType = (ScriptDom.FunctionReturnType)returnType.ToMutable();
            ret.Options.AddRange(options.Select(c => (ScriptDom.FunctionOption)c.ToMutable()));
            ret.OrderHint = (ScriptDom.OrderBulkInsertOption)orderHint.ToMutable();
            ret.Parameters.AddRange(parameters.Select(c => (ScriptDom.ProcedureParameter)c.ToMutable()));
            ret.StatementList = (ScriptDom.StatementList)statementList.ToMutable();
            ret.MethodSpecifier = (ScriptDom.MethodSpecifier)methodSpecifier.ToMutable();
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
            return Equals(obj as CreateOrAlterFunctionStatement);
        } 
        
        public bool Equals(CreateOrAlterFunctionStatement other) {
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
        
        public static bool operator ==(CreateOrAlterFunctionStatement left, CreateOrAlterFunctionStatement right) {
            return EqualityComparer<CreateOrAlterFunctionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateOrAlterFunctionStatement left, CreateOrAlterFunctionStatement right) {
            return !(left == right);
        }
    
    }

}
