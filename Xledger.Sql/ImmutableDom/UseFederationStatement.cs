using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UseFederationStatement : TSqlStatement, IEquatable<UseFederationStatement> {
        Identifier federationName;
        Identifier distributionName;
        ScalarExpression @value;
        bool filtering = false;
    
        public Identifier FederationName => federationName;
        public Identifier DistributionName => distributionName;
        public ScalarExpression Value => @value;
        public bool Filtering => filtering;
    
        public UseFederationStatement(Identifier federationName = null, Identifier distributionName = null, ScalarExpression @value = null, bool filtering = false) {
            this.federationName = federationName;
            this.distributionName = distributionName;
            this.@value = @value;
            this.filtering = filtering;
        }
    
        public ScriptDom.UseFederationStatement ToMutableConcrete() {
            var ret = new ScriptDom.UseFederationStatement();
            ret.FederationName = (ScriptDom.Identifier)federationName.ToMutable();
            ret.DistributionName = (ScriptDom.Identifier)distributionName.ToMutable();
            ret.Value = (ScriptDom.ScalarExpression)@value.ToMutable();
            ret.Filtering = filtering;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(federationName is null)) {
                h = h * 23 + federationName.GetHashCode();
            }
            if (!(distributionName is null)) {
                h = h * 23 + distributionName.GetHashCode();
            }
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + filtering.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UseFederationStatement);
        } 
        
        public bool Equals(UseFederationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.FederationName, federationName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DistributionName, distributionName)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.Filtering, filtering)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UseFederationStatement left, UseFederationStatement right) {
            return EqualityComparer<UseFederationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UseFederationStatement left, UseFederationStatement right) {
            return !(left == right);
        }
    
    }

}