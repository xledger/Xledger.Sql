using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateExternalLanguageStatement : ExternalLanguageStatement, IEquatable<CreateExternalLanguageStatement> {
        protected Identifier owner;
    
        public Identifier Owner => owner;
    
        public CreateExternalLanguageStatement(Identifier owner = null, Identifier name = null, IReadOnlyList<ExternalLanguageFileOption> externalLanguageFiles = null) {
            this.owner = owner;
            this.name = name;
            this.externalLanguageFiles = externalLanguageFiles.ToImmArray<ExternalLanguageFileOption>();
        }
    
        public ScriptDom.CreateExternalLanguageStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateExternalLanguageStatement();
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
            return Equals(obj as CreateExternalLanguageStatement);
        } 
        
        public bool Equals(CreateExternalLanguageStatement other) {
            if (other is null) { return false; }
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
        
        public static bool operator ==(CreateExternalLanguageStatement left, CreateExternalLanguageStatement right) {
            return EqualityComparer<CreateExternalLanguageStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateExternalLanguageStatement left, CreateExternalLanguageStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateExternalLanguageStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.externalLanguageFiles, othr.externalLanguageFiles);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateExternalLanguageStatement left, CreateExternalLanguageStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateExternalLanguageStatement left, CreateExternalLanguageStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateExternalLanguageStatement left, CreateExternalLanguageStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateExternalLanguageStatement left, CreateExternalLanguageStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateExternalLanguageStatement FromMutable(ScriptDom.CreateExternalLanguageStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateExternalLanguageStatement)) { throw new NotImplementedException("Unexpected subtype of CreateExternalLanguageStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateExternalLanguageStatement(
                owner: ImmutableDom.Identifier.FromMutable(fragment.Owner),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                externalLanguageFiles: fragment.ExternalLanguageFiles.ToImmArray(ImmutableDom.ExternalLanguageFileOption.FromMutable)
            );
        }
    
    }

}
