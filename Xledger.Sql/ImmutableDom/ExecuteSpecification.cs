using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteSpecification : TSqlFragment, IEquatable<ExecuteSpecification> {
        VariableReference variable;
        Identifier linkedServer;
        ExecuteContext executeContext;
        ExecutableEntity executableEntity;
    
        public VariableReference Variable => variable;
        public Identifier LinkedServer => linkedServer;
        public ExecuteContext ExecuteContext => executeContext;
        public ExecutableEntity ExecutableEntity => executableEntity;
    
        public ExecuteSpecification(VariableReference variable = null, Identifier linkedServer = null, ExecuteContext executeContext = null, ExecutableEntity executableEntity = null) {
            this.variable = variable;
            this.linkedServer = linkedServer;
            this.executeContext = executeContext;
            this.executableEntity = executableEntity;
        }
    
        public ScriptDom.ExecuteSpecification ToMutableConcrete() {
            var ret = new ScriptDom.ExecuteSpecification();
            ret.Variable = (ScriptDom.VariableReference)variable.ToMutable();
            ret.LinkedServer = (ScriptDom.Identifier)linkedServer.ToMutable();
            ret.ExecuteContext = (ScriptDom.ExecuteContext)executeContext.ToMutable();
            ret.ExecutableEntity = (ScriptDom.ExecutableEntity)executableEntity.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(variable is null)) {
                h = h * 23 + variable.GetHashCode();
            }
            if (!(linkedServer is null)) {
                h = h * 23 + linkedServer.GetHashCode();
            }
            if (!(executeContext is null)) {
                h = h * 23 + executeContext.GetHashCode();
            }
            if (!(executableEntity is null)) {
                h = h * 23 + executableEntity.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecuteSpecification);
        } 
        
        public bool Equals(ExecuteSpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<VariableReference>.Default.Equals(other.Variable, variable)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.LinkedServer, linkedServer)) {
                return false;
            }
            if (!EqualityComparer<ExecuteContext>.Default.Equals(other.ExecuteContext, executeContext)) {
                return false;
            }
            if (!EqualityComparer<ExecutableEntity>.Default.Equals(other.ExecutableEntity, executableEntity)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecuteSpecification left, ExecuteSpecification right) {
            return EqualityComparer<ExecuteSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecuteSpecification left, ExecuteSpecification right) {
            return !(left == right);
        }
    
    }

}
