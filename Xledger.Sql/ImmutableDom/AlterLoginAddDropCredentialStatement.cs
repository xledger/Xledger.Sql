using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterLoginAddDropCredentialStatement : AlterLoginStatement, IEquatable<AlterLoginAddDropCredentialStatement> {
        protected bool isAdd = false;
        protected Identifier credentialName;
    
        public bool IsAdd => isAdd;
        public Identifier CredentialName => credentialName;
    
        public AlterLoginAddDropCredentialStatement(bool isAdd = false, Identifier credentialName = null, Identifier name = null) {
            this.isAdd = isAdd;
            this.credentialName = credentialName;
            this.name = name;
        }
    
        public ScriptDom.AlterLoginAddDropCredentialStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterLoginAddDropCredentialStatement();
            ret.IsAdd = isAdd;
            ret.CredentialName = (ScriptDom.Identifier)credentialName.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isAdd.GetHashCode();
            if (!(credentialName is null)) {
                h = h * 23 + credentialName.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterLoginAddDropCredentialStatement);
        } 
        
        public bool Equals(AlterLoginAddDropCredentialStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsAdd, isAdd)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.CredentialName, credentialName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterLoginAddDropCredentialStatement left, AlterLoginAddDropCredentialStatement right) {
            return EqualityComparer<AlterLoginAddDropCredentialStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterLoginAddDropCredentialStatement left, AlterLoginAddDropCredentialStatement right) {
            return !(left == right);
        }
    
        public static AlterLoginAddDropCredentialStatement FromMutable(ScriptDom.AlterLoginAddDropCredentialStatement fragment) {
            return (AlterLoginAddDropCredentialStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
