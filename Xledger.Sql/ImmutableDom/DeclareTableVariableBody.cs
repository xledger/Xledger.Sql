using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DeclareTableVariableBody : TSqlFragment, IEquatable<DeclareTableVariableBody> {
        protected Identifier variableName;
        protected bool asDefined = false;
        protected TableDefinition definition;
    
        public Identifier VariableName => variableName;
        public bool AsDefined => asDefined;
        public TableDefinition Definition => definition;
    
        public DeclareTableVariableBody(Identifier variableName = null, bool asDefined = false, TableDefinition definition = null) {
            this.variableName = variableName;
            this.asDefined = asDefined;
            this.definition = definition;
        }
    
        public ScriptDom.DeclareTableVariableBody ToMutableConcrete() {
            var ret = new ScriptDom.DeclareTableVariableBody();
            ret.VariableName = (ScriptDom.Identifier)variableName.ToMutable();
            ret.AsDefined = asDefined;
            ret.Definition = (ScriptDom.TableDefinition)definition.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(variableName is null)) {
                h = h * 23 + variableName.GetHashCode();
            }
            h = h * 23 + asDefined.GetHashCode();
            if (!(definition is null)) {
                h = h * 23 + definition.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DeclareTableVariableBody);
        } 
        
        public bool Equals(DeclareTableVariableBody other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.VariableName, variableName)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.AsDefined, asDefined)) {
                return false;
            }
            if (!EqualityComparer<TableDefinition>.Default.Equals(other.Definition, definition)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DeclareTableVariableBody left, DeclareTableVariableBody right) {
            return EqualityComparer<DeclareTableVariableBody>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DeclareTableVariableBody left, DeclareTableVariableBody right) {
            return !(left == right);
        }
    
    }

}
