using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GrantStatement80 : SecurityStatementBody80, IEquatable<GrantStatement80> {
        bool withGrantOption = false;
        Identifier asClause;
    
        public bool WithGrantOption => withGrantOption;
        public Identifier AsClause => asClause;
    
        public GrantStatement80(bool withGrantOption = false, Identifier asClause = null, SecurityElement80 securityElement80 = null, SecurityUserClause80 securityUserClause80 = null) {
            this.withGrantOption = withGrantOption;
            this.asClause = asClause;
            this.securityElement80 = securityElement80;
            this.securityUserClause80 = securityUserClause80;
        }
    
        public ScriptDom.GrantStatement80 ToMutableConcrete() {
            var ret = new ScriptDom.GrantStatement80();
            ret.WithGrantOption = withGrantOption;
            ret.AsClause = (ScriptDom.Identifier)asClause.ToMutable();
            ret.SecurityElement80 = (ScriptDom.SecurityElement80)securityElement80.ToMutable();
            ret.SecurityUserClause80 = (ScriptDom.SecurityUserClause80)securityUserClause80.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + withGrantOption.GetHashCode();
            if (!(asClause is null)) {
                h = h * 23 + asClause.GetHashCode();
            }
            if (!(securityElement80 is null)) {
                h = h * 23 + securityElement80.GetHashCode();
            }
            if (!(securityUserClause80 is null)) {
                h = h * 23 + securityUserClause80.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GrantStatement80);
        } 
        
        public bool Equals(GrantStatement80 other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.WithGrantOption, withGrantOption)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.AsClause, asClause)) {
                return false;
            }
            if (!EqualityComparer<SecurityElement80>.Default.Equals(other.SecurityElement80, securityElement80)) {
                return false;
            }
            if (!EqualityComparer<SecurityUserClause80>.Default.Equals(other.SecurityUserClause80, securityUserClause80)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GrantStatement80 left, GrantStatement80 right) {
            return EqualityComparer<GrantStatement80>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GrantStatement80 left, GrantStatement80 right) {
            return !(left == right);
        }
    
    }

}
