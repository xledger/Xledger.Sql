using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateExternalDataSourceStatement : ExternalDataSourceStatement, IEquatable<CreateExternalDataSourceStatement> {
        public CreateExternalDataSourceStatement(Identifier name = null, ScriptDom.ExternalDataSourceType dataSourceType = ScriptDom.ExternalDataSourceType.HADOOP, Literal location = null, ScriptDom.ExternalDataSourcePushdownOption? pushdownOption = null, IReadOnlyList<ExternalDataSourceOption> externalDataSourceOptions = null) {
            this.name = name;
            this.dataSourceType = dataSourceType;
            this.location = location;
            this.pushdownOption = pushdownOption;
            this.externalDataSourceOptions = externalDataSourceOptions.ToImmArray<ExternalDataSourceOption>();
        }
    
        public ScriptDom.CreateExternalDataSourceStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateExternalDataSourceStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.DataSourceType = dataSourceType;
            ret.Location = (ScriptDom.Literal)location?.ToMutable();
            ret.PushdownOption = pushdownOption;
            ret.ExternalDataSourceOptions.AddRange(externalDataSourceOptions.Select(c => (ScriptDom.ExternalDataSourceOption)c?.ToMutable()));
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
            h = h * 23 + dataSourceType.GetHashCode();
            if (!(location is null)) {
                h = h * 23 + location.GetHashCode();
            }
            h = h * 23 + pushdownOption.GetHashCode();
            h = h * 23 + externalDataSourceOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateExternalDataSourceStatement);
        } 
        
        public bool Equals(CreateExternalDataSourceStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalDataSourceType>.Default.Equals(other.DataSourceType, dataSourceType)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Location, location)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalDataSourcePushdownOption?>.Default.Equals(other.PushdownOption, pushdownOption)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExternalDataSourceOption>>.Default.Equals(other.ExternalDataSourceOptions, externalDataSourceOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateExternalDataSourceStatement left, CreateExternalDataSourceStatement right) {
            return EqualityComparer<CreateExternalDataSourceStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateExternalDataSourceStatement left, CreateExternalDataSourceStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateExternalDataSourceStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.dataSourceType, othr.dataSourceType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.location, othr.location);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.pushdownOption, othr.pushdownOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.externalDataSourceOptions, othr.externalDataSourceOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateExternalDataSourceStatement left, CreateExternalDataSourceStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateExternalDataSourceStatement left, CreateExternalDataSourceStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateExternalDataSourceStatement left, CreateExternalDataSourceStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateExternalDataSourceStatement left, CreateExternalDataSourceStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateExternalDataSourceStatement FromMutable(ScriptDom.CreateExternalDataSourceStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateExternalDataSourceStatement)) { throw new NotImplementedException("Unexpected subtype of CreateExternalDataSourceStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateExternalDataSourceStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                dataSourceType: fragment.DataSourceType,
                location: ImmutableDom.Literal.FromMutable(fragment.Location),
                pushdownOption: fragment.PushdownOption,
                externalDataSourceOptions: fragment.ExternalDataSourceOptions.ToImmArray(ImmutableDom.ExternalDataSourceOption.FromMutable)
            );
        }
    
    }

}
