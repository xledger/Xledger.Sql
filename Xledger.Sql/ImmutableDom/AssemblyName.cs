using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AssemblyName : TSqlFragment, IEquatable<AssemblyName> {
        protected Identifier name;
        protected Identifier className;
    
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AssemblyName)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.className, othr.className);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AssemblyName FromMutable(ScriptDom.AssemblyName fragment) {
            return (AssemblyName)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
