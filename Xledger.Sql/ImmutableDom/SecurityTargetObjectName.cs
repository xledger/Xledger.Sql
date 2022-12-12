using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SecurityTargetObjectName : TSqlFragment, IEquatable<SecurityTargetObjectName> {
        protected MultiPartIdentifier multiPartIdentifier;
    
        public MultiPartIdentifier MultiPartIdentifier => multiPartIdentifier;
    
        public SecurityTargetObjectName(MultiPartIdentifier multiPartIdentifier = null) {
            this.multiPartIdentifier = multiPartIdentifier;
        }
    
        public ScriptDom.SecurityTargetObjectName ToMutableConcrete() {
            var ret = new ScriptDom.SecurityTargetObjectName();
            ret.MultiPartIdentifier = (ScriptDom.MultiPartIdentifier)multiPartIdentifier.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(multiPartIdentifier is null)) {
                h = h * 23 + multiPartIdentifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SecurityTargetObjectName);
        } 
        
        public bool Equals(SecurityTargetObjectName other) {
            if (other is null) { return false; }
            if (!EqualityComparer<MultiPartIdentifier>.Default.Equals(other.MultiPartIdentifier, multiPartIdentifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SecurityTargetObjectName left, SecurityTargetObjectName right) {
            return EqualityComparer<SecurityTargetObjectName>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SecurityTargetObjectName left, SecurityTargetObjectName right) {
            return !(left == right);
        }
    
    }

}
