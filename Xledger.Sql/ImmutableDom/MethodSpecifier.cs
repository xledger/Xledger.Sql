using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MethodSpecifier : TSqlFragment, IEquatable<MethodSpecifier> {
        protected Identifier assemblyName;
        protected Identifier className;
        protected Identifier methodName;
    
        public Identifier AssemblyName => assemblyName;
        public Identifier ClassName => className;
        public Identifier MethodName => methodName;
    
        public MethodSpecifier(Identifier assemblyName = null, Identifier className = null, Identifier methodName = null) {
            this.assemblyName = assemblyName;
            this.className = className;
            this.methodName = methodName;
        }
    
        public ScriptDom.MethodSpecifier ToMutableConcrete() {
            var ret = new ScriptDom.MethodSpecifier();
            ret.AssemblyName = (ScriptDom.Identifier)assemblyName.ToMutable();
            ret.ClassName = (ScriptDom.Identifier)className.ToMutable();
            ret.MethodName = (ScriptDom.Identifier)methodName.ToMutable();
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
            if (!(className is null)) {
                h = h * 23 + className.GetHashCode();
            }
            if (!(methodName is null)) {
                h = h * 23 + methodName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MethodSpecifier);
        } 
        
        public bool Equals(MethodSpecifier other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.AssemblyName, assemblyName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ClassName, className)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.MethodName, methodName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MethodSpecifier left, MethodSpecifier right) {
            return EqualityComparer<MethodSpecifier>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MethodSpecifier left, MethodSpecifier right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MethodSpecifier)that;
            compare = Comparer.DefaultInvariant.Compare(this.assemblyName, othr.assemblyName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.className, othr.className);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.methodName, othr.methodName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (MethodSpecifier left, MethodSpecifier right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MethodSpecifier left, MethodSpecifier right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MethodSpecifier left, MethodSpecifier right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MethodSpecifier left, MethodSpecifier right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static MethodSpecifier FromMutable(ScriptDom.MethodSpecifier fragment) {
            return (MethodSpecifier)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
