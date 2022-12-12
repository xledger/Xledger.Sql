using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterFederationStatement : TSqlStatement, IEquatable<AlterFederationStatement> {
        Identifier name;
        ScriptDom.AlterFederationKind kind = ScriptDom.AlterFederationKind.Unknown;
        Identifier distributionName;
        ScalarExpression boundary;
    
        public Identifier Name => name;
        public ScriptDom.AlterFederationKind Kind => kind;
        public Identifier DistributionName => distributionName;
        public ScalarExpression Boundary => boundary;
    
        public AlterFederationStatement(Identifier name = null, ScriptDom.AlterFederationKind kind = ScriptDom.AlterFederationKind.Unknown, Identifier distributionName = null, ScalarExpression boundary = null) {
            this.name = name;
            this.kind = kind;
            this.distributionName = distributionName;
            this.boundary = boundary;
        }
    
        public ScriptDom.AlterFederationStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterFederationStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Kind = kind;
            ret.DistributionName = (ScriptDom.Identifier)distributionName.ToMutable();
            ret.Boundary = (ScriptDom.ScalarExpression)boundary.ToMutable();
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
            h = h * 23 + kind.GetHashCode();
            if (!(distributionName is null)) {
                h = h * 23 + distributionName.GetHashCode();
            }
            if (!(boundary is null)) {
                h = h * 23 + boundary.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterFederationStatement);
        } 
        
        public bool Equals(AlterFederationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AlterFederationKind>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DistributionName, distributionName)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Boundary, boundary)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterFederationStatement left, AlterFederationStatement right) {
            return EqualityComparer<AlterFederationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterFederationStatement left, AlterFederationStatement right) {
            return !(left == right);
        }
    
    }

}
