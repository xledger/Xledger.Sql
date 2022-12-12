using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterFunctionStatement : FunctionStatementBody, IEquatable<AlterFunctionStatement> {
        public AlterFunctionStatement(SchemaObjectName name = null, FunctionReturnType returnType = null, IReadOnlyList<FunctionOption> options = null, OrderBulkInsertOption orderHint = null, IReadOnlyList<ProcedureParameter> parameters = null, StatementList statementList = null, MethodSpecifier methodSpecifier = null) {
            this.name = name;
            this.returnType = returnType;
            this.options = options is null ? ImmList<FunctionOption>.Empty : ImmList<FunctionOption>.FromList(options);
            this.orderHint = orderHint;
            this.parameters = parameters is null ? ImmList<ProcedureParameter>.Empty : ImmList<ProcedureParameter>.FromList(parameters);
            this.statementList = statementList;
            this.methodSpecifier = methodSpecifier;
        }
    
        public ScriptDom.AlterFunctionStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterFunctionStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            ret.ReturnType = (ScriptDom.FunctionReturnType)returnType.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.FunctionOption)c.ToMutable()));
            ret.OrderHint = (ScriptDom.OrderBulkInsertOption)orderHint.ToMutable();
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ProcedureParameter)c.ToMutable()));
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
            return Equals(obj as AlterFunctionStatement);
        } 
        
        public bool Equals(AlterFunctionStatement other) {
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
        
        public static bool operator ==(AlterFunctionStatement left, AlterFunctionStatement right) {
            return EqualityComparer<AlterFunctionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterFunctionStatement left, AlterFunctionStatement right) {
            return !(left == right);
        }
    
    }

}
