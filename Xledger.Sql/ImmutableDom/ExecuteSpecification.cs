using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteSpecification : TSqlFragment, IEquatable<ExecuteSpecification> {
        protected VariableReference variable;
        protected Identifier linkedServer;
        protected ExecuteContext executeContext;
        protected ExecutableEntity executableEntity;
    
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
            ret.Variable = (ScriptDom.VariableReference)variable?.ToMutable();
            ret.LinkedServer = (ScriptDom.Identifier)linkedServer?.ToMutable();
            ret.ExecuteContext = (ScriptDom.ExecuteContext)executeContext?.ToMutable();
            ret.ExecutableEntity = (ScriptDom.ExecutableEntity)executableEntity?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExecuteSpecification)that;
            compare = Comparer.DefaultInvariant.Compare(this.variable, othr.variable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.linkedServer, othr.linkedServer);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.executeContext, othr.executeContext);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.executableEntity, othr.executableEntity);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExecuteSpecification left, ExecuteSpecification right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExecuteSpecification left, ExecuteSpecification right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExecuteSpecification left, ExecuteSpecification right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExecuteSpecification left, ExecuteSpecification right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExecuteSpecification FromMutable(ScriptDom.ExecuteSpecification fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExecuteSpecification)) { throw new NotImplementedException("Unexpected subtype of ExecuteSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteSpecification(
                variable: ImmutableDom.VariableReference.FromMutable(fragment.Variable),
                linkedServer: ImmutableDom.Identifier.FromMutable(fragment.LinkedServer),
                executeContext: ImmutableDom.ExecuteContext.FromMutable(fragment.ExecuteContext),
                executableEntity: ImmutableDom.ExecutableEntity.FromMutable(fragment.ExecutableEntity)
            );
        }
    
    }

}
