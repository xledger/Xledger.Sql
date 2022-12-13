using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CloseSymmetricKeyStatement : TSqlStatement, IEquatable<CloseSymmetricKeyStatement> {
        protected Identifier name;
        protected bool all = false;
    
        public Identifier Name => name;
        public bool All => all;
    
        public CloseSymmetricKeyStatement(Identifier name = null, bool all = false) {
            this.name = name;
            this.all = all;
        }
    
        public ScriptDom.CloseSymmetricKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CloseSymmetricKeyStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.All = all;
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
            h = h * 23 + all.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CloseSymmetricKeyStatement);
        } 
        
        public bool Equals(CloseSymmetricKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.All, all)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CloseSymmetricKeyStatement left, CloseSymmetricKeyStatement right) {
            return EqualityComparer<CloseSymmetricKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CloseSymmetricKeyStatement left, CloseSymmetricKeyStatement right) {
            return !(left == right);
        }
    
        public static CloseSymmetricKeyStatement FromMutable(ScriptDom.CloseSymmetricKeyStatement fragment) {
            return (CloseSymmetricKeyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
