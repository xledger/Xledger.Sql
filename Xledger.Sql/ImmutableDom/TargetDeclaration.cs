using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TargetDeclaration : TSqlFragment, IEquatable<TargetDeclaration> {
        protected EventSessionObjectName objectName;
        protected IReadOnlyList<EventDeclarationSetParameter> targetDeclarationParameters;
    
        public EventSessionObjectName ObjectName => objectName;
        public IReadOnlyList<EventDeclarationSetParameter> TargetDeclarationParameters => targetDeclarationParameters;
    
        public TargetDeclaration(EventSessionObjectName objectName = null, IReadOnlyList<EventDeclarationSetParameter> targetDeclarationParameters = null) {
            this.objectName = objectName;
            this.targetDeclarationParameters = targetDeclarationParameters is null ? ImmList<EventDeclarationSetParameter>.Empty : ImmList<EventDeclarationSetParameter>.FromList(targetDeclarationParameters);
        }
    
        public ScriptDom.TargetDeclaration ToMutableConcrete() {
            var ret = new ScriptDom.TargetDeclaration();
            ret.ObjectName = (ScriptDom.EventSessionObjectName)objectName.ToMutable();
            ret.TargetDeclarationParameters.AddRange(targetDeclarationParameters.SelectList(c => (ScriptDom.EventDeclarationSetParameter)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(objectName is null)) {
                h = h * 23 + objectName.GetHashCode();
            }
            h = h * 23 + targetDeclarationParameters.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TargetDeclaration);
        } 
        
        public bool Equals(TargetDeclaration other) {
            if (other is null) { return false; }
            if (!EqualityComparer<EventSessionObjectName>.Default.Equals(other.ObjectName, objectName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<EventDeclarationSetParameter>>.Default.Equals(other.TargetDeclarationParameters, targetDeclarationParameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TargetDeclaration left, TargetDeclaration right) {
            return EqualityComparer<TargetDeclaration>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TargetDeclaration left, TargetDeclaration right) {
            return !(left == right);
        }
    
        public static TargetDeclaration FromMutable(ScriptDom.TargetDeclaration fragment) {
            return (TargetDeclaration)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
