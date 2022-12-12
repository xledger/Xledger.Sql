using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateFederationStatement : TSqlStatement, IEquatable<CreateFederationStatement> {
        Identifier name;
        Identifier distributionName;
        DataTypeReference dataType;
    
        public Identifier Name => name;
        public Identifier DistributionName => distributionName;
        public DataTypeReference DataType => dataType;
    
        public CreateFederationStatement(Identifier name = null, Identifier distributionName = null, DataTypeReference dataType = null) {
            this.name = name;
            this.distributionName = distributionName;
            this.dataType = dataType;
        }
    
        public ScriptDom.CreateFederationStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateFederationStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.DistributionName = (ScriptDom.Identifier)distributionName.ToMutable();
            ret.DataType = (ScriptDom.DataTypeReference)dataType.ToMutable();
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
            if (!(distributionName is null)) {
                h = h * 23 + distributionName.GetHashCode();
            }
            if (!(dataType is null)) {
                h = h * 23 + dataType.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateFederationStatement);
        } 
        
        public bool Equals(CreateFederationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DistributionName, distributionName)) {
                return false;
            }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.DataType, dataType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateFederationStatement left, CreateFederationStatement right) {
            return EqualityComparer<CreateFederationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateFederationStatement left, CreateFederationStatement right) {
            return !(left == right);
        }
    
    }

}
