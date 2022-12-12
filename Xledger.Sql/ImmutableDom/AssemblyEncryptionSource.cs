using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AssemblyEncryptionSource : EncryptionSource, IEquatable<AssemblyEncryptionSource> {
        Identifier assembly;
    
        public Identifier Assembly => assembly;
    
        public AssemblyEncryptionSource(Identifier assembly = null) {
            this.assembly = assembly;
        }
    
        public ScriptDom.AssemblyEncryptionSource ToMutableConcrete() {
            var ret = new ScriptDom.AssemblyEncryptionSource();
            ret.Assembly = (ScriptDom.Identifier)assembly.ToMutable();
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
    
    }

}
