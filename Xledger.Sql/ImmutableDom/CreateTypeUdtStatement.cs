using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateTypeUdtStatement : CreateTypeStatement, IEquatable<CreateTypeUdtStatement> {
        AssemblyName assemblyName;
    
        public AssemblyName AssemblyName => assemblyName;
    
        public CreateTypeUdtStatement(AssemblyName assemblyName = null, SchemaObjectName name = null) {
            this.assemblyName = assemblyName;
            this.name = name;
        }
    
        public ScriptDom.CreateTypeUdtStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateTypeUdtStatement();
            ret.AssemblyName = (ScriptDom.AssemblyName)assemblyName.ToMutable();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(assemblyName is null)) {
                h = h * 23 + assemblyName.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateTypeUdtStatement);
        } 
        
        public bool Equals(CreateTypeUdtStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<AssemblyName>.Default.Equals(other.AssemblyName, assemblyName)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateTypeUdtStatement left, CreateTypeUdtStatement right) {
            return EqualityComparer<CreateTypeUdtStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateTypeUdtStatement left, CreateTypeUdtStatement right) {
            return !(left == right);
        }
    
    }

}
