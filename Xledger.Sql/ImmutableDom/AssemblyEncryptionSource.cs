using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AssemblyEncryptionSource : EncryptionSource, IEquatable<AssemblyEncryptionSource> {
        protected Identifier assembly;
    
        public Identifier Assembly => assembly;
    
        public AssemblyEncryptionSource(Identifier assembly = null) {
            this.assembly = assembly;
        }
    
        public ScriptDom.AssemblyEncryptionSource ToMutableConcrete() {
            var ret = new ScriptDom.AssemblyEncryptionSource();
            ret.Assembly = (ScriptDom.Identifier)assembly?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(assembly is null)) {
                h = h * 23 + assembly.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AssemblyEncryptionSource);
        } 
        
        public bool Equals(AssemblyEncryptionSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Assembly, assembly)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AssemblyEncryptionSource left, AssemblyEncryptionSource right) {
            return EqualityComparer<AssemblyEncryptionSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AssemblyEncryptionSource left, AssemblyEncryptionSource right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AssemblyEncryptionSource)that;
            compare = Comparer.DefaultInvariant.Compare(this.assembly, othr.assembly);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AssemblyEncryptionSource left, AssemblyEncryptionSource right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AssemblyEncryptionSource left, AssemblyEncryptionSource right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AssemblyEncryptionSource left, AssemblyEncryptionSource right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AssemblyEncryptionSource left, AssemblyEncryptionSource right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AssemblyEncryptionSource FromMutable(ScriptDom.AssemblyEncryptionSource fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AssemblyEncryptionSource)) { throw new NotImplementedException("Unexpected subtype of AssemblyEncryptionSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AssemblyEncryptionSource(
                assembly: ImmutableDom.Identifier.FromMutable(fragment.Assembly)
            );
        }
    
    }

}
