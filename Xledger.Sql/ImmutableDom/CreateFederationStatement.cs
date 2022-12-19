using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateFederationStatement : TSqlStatement, IEquatable<CreateFederationStatement> {
        protected Identifier name;
        protected Identifier distributionName;
        protected DataTypeReference dataType;
    
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
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.DistributionName = (ScriptDom.Identifier)distributionName?.ToMutable();
            ret.DataType = (ScriptDom.DataTypeReference)dataType?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateFederationStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.distributionName, othr.distributionName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.dataType, othr.dataType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateFederationStatement left, CreateFederationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateFederationStatement left, CreateFederationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateFederationStatement left, CreateFederationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateFederationStatement left, CreateFederationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateFederationStatement FromMutable(ScriptDom.CreateFederationStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateFederationStatement)) { throw new NotImplementedException("Unexpected subtype of CreateFederationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateFederationStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                distributionName: ImmutableDom.Identifier.FromMutable(fragment.DistributionName),
                dataType: ImmutableDom.DataTypeReference.FromMutable(fragment.DataType)
            );
        }
    
    }

}
