using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterExternalModelStatement : ExternalModelStatement, IEquatable<AlterExternalModelStatement> {
        public AlterExternalModelStatement(Identifier name = null, Literal location = null, Literal apiFormat = null, ScriptDom.ExternalModelTypeOption? modelType = null, ExternalModelTypeSpecification modelTypeSpecification = null, Literal modelName = null, Identifier credential = null, Literal parameters = null, Literal localRuntimePath = null) {
            this.name = name;
            this.location = location;
            this.apiFormat = apiFormat;
            this.modelType = modelType;
            this.modelTypeSpecification = modelTypeSpecification;
            this.modelName = modelName;
            this.credential = credential;
            this.parameters = parameters;
            this.localRuntimePath = localRuntimePath;
        }
    
        public ScriptDom.AlterExternalModelStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterExternalModelStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Location = (ScriptDom.Literal)location?.ToMutable();
            ret.ApiFormat = (ScriptDom.Literal)apiFormat?.ToMutable();
            ret.ModelType = modelType;
            ret.ModelTypeSpecification = (ScriptDom.ExternalModelTypeSpecification)modelTypeSpecification?.ToMutable();
            ret.ModelName = (ScriptDom.Literal)modelName?.ToMutable();
            ret.Credential = (ScriptDom.Identifier)credential?.ToMutable();
            ret.Parameters = (ScriptDom.Literal)parameters?.ToMutable();
            ret.LocalRuntimePath = (ScriptDom.Literal)localRuntimePath?.ToMutable();
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
            if (!(location is null)) {
                h = h * 23 + location.GetHashCode();
            }
            if (!(apiFormat is null)) {
                h = h * 23 + apiFormat.GetHashCode();
            }
            h = h * 23 + modelType.GetHashCode();
            if (!(modelTypeSpecification is null)) {
                h = h * 23 + modelTypeSpecification.GetHashCode();
            }
            if (!(modelName is null)) {
                h = h * 23 + modelName.GetHashCode();
            }
            if (!(credential is null)) {
                h = h * 23 + credential.GetHashCode();
            }
            if (!(parameters is null)) {
                h = h * 23 + parameters.GetHashCode();
            }
            if (!(localRuntimePath is null)) {
                h = h * 23 + localRuntimePath.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterExternalModelStatement);
        } 
        
        public bool Equals(AlterExternalModelStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Location, location)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.ApiFormat, apiFormat)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalModelTypeOption?>.Default.Equals(other.ModelType, modelType)) {
                return false;
            }
            if (!EqualityComparer<ExternalModelTypeSpecification>.Default.Equals(other.ModelTypeSpecification, modelTypeSpecification)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.ModelName, modelName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Credential, credential)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.LocalRuntimePath, localRuntimePath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterExternalModelStatement left, AlterExternalModelStatement right) {
            return EqualityComparer<AlterExternalModelStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterExternalModelStatement left, AlterExternalModelStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterExternalModelStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.location, othr.location);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.apiFormat, othr.apiFormat);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.modelType, othr.modelType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.modelTypeSpecification, othr.modelTypeSpecification);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.modelName, othr.modelName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.credential, othr.credential);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.localRuntimePath, othr.localRuntimePath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterExternalModelStatement left, AlterExternalModelStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterExternalModelStatement left, AlterExternalModelStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterExternalModelStatement left, AlterExternalModelStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterExternalModelStatement left, AlterExternalModelStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterExternalModelStatement FromMutable(ScriptDom.AlterExternalModelStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterExternalModelStatement)) { throw new NotImplementedException("Unexpected subtype of AlterExternalModelStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterExternalModelStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                location: ImmutableDom.Literal.FromMutable(fragment.Location),
                apiFormat: ImmutableDom.Literal.FromMutable(fragment.ApiFormat),
                modelType: fragment.ModelType,
                modelTypeSpecification: ImmutableDom.ExternalModelTypeSpecification.FromMutable(fragment.ModelTypeSpecification),
                modelName: ImmutableDom.Literal.FromMutable(fragment.ModelName),
                credential: ImmutableDom.Identifier.FromMutable(fragment.Credential),
                parameters: ImmutableDom.Literal.FromMutable(fragment.Parameters),
                localRuntimePath: ImmutableDom.Literal.FromMutable(fragment.LocalRuntimePath)
            );
        }
    
    }

}
