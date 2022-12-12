using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AssemblyName : TSqlFragment, IEquatable<AssemblyName> {
        Identifier name;
        Identifier className;
    
        public Identifier Name => name;
        public Identifier ClassName => className;
    
        public AssemblyName(Identifier name = null, Identifier className = null) {
            this.name = name;
            this.className = className;
        }
    
        public ScriptDom.AssemblyName ToMutableConcrete() {
            var ret = new ScriptDom.AssemblyName();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ClassName = (ScriptDom.Identifier)className.ToMutable();
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
            if (!(className is null)) {
                h = h * 23 + className.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AssemblyName);
        } 
        
        public bool Equals(AssemblyName other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ClassName, className)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AssemblyName left, AssemblyName right) {
            return EqualityComparer<AssemblyName>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AssemblyName left, AssemblyName right) {
            return !(left == right);
        }
    
    }

}
