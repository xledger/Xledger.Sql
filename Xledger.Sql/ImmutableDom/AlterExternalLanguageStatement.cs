using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterExternalLanguageStatement : ExternalLanguageStatement, IEquatable<AlterExternalLanguageStatement> {
        protected Identifier platform;
        protected Identifier operation;
        protected Identifier owner;
    
        public Identifier Platform => platform;
        public Identifier Operation => operation;
        public Identifier Owner => owner;
    
        public AlterExternalLanguageStatement(Identifier platform = null, Identifier operation = null, Identifier owner = null, Identifier name = null, IReadOnlyList<ExternalLanguageFileOption> externalLanguageFiles = null) {
            this.platform = platform;
            this.operation = operation;
            this.owner = owner;
            this.name = name;
            this.externalLanguageFiles = externalLanguageFiles.ToImmArray<ExternalLanguageFileOption>();
        }
    
        public ScriptDom.AlterExternalLanguageStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterExternalLanguageStatement();
            ret.Platform = (ScriptDom.Identifier)platform?.ToMutable();
            ret.Operation = (ScriptDom.Identifier)operation?.ToMutable();
            ret.Owner = (ScriptDom.Identifier)owner?.ToMutable();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.ExternalLanguageFiles.AddRange(externalLanguageFiles.Select(c => (ScriptDom.ExternalLanguageFileOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(platform is null)) {
                h = h * 23 + platform.GetHashCode();
            }
            if (!(operation is null)) {
                h = h * 23 + operation.GetHashCode();
            }
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + externalLanguageFiles.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterExternalLanguageStatement);
        } 
        
        public bool Equals(AlterExternalLanguageStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Platform, platform)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Operation, operation)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExternalLanguageFileOption>>.Default.Equals(other.ExternalLanguageFiles, externalLanguageFiles)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterExternalLanguageStatement left, AlterExternalLanguageStatement right) {
            return EqualityComparer<AlterExternalLanguageStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterExternalLanguageStatement left, AlterExternalLanguageStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterExternalLanguageStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.platform, othr.platform);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.operation, othr.operation);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.externalLanguageFiles, othr.externalLanguageFiles);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterExternalLanguageStatement left, AlterExternalLanguageStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterExternalLanguageStatement left, AlterExternalLanguageStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterExternalLanguageStatement left, AlterExternalLanguageStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterExternalLanguageStatement left, AlterExternalLanguageStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterExternalLanguageStatement FromMutable(ScriptDom.AlterExternalLanguageStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterExternalLanguageStatement)) { throw new NotImplementedException("Unexpected subtype of AlterExternalLanguageStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterExternalLanguageStatement(
                platform: ImmutableDom.Identifier.FromMutable(fragment.Platform),
                operation: ImmutableDom.Identifier.FromMutable(fragment.Operation),
                owner: ImmutableDom.Identifier.FromMutable(fragment.Owner),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                externalLanguageFiles: fragment.ExternalLanguageFiles.ToImmArray(ImmutableDom.ExternalLanguageFileOption.FromMutable)
            );
        }
    
    }

}
