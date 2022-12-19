using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateFullTextCatalogStatement : FullTextCatalogStatement, IEquatable<CreateFullTextCatalogStatement> {
        protected Identifier fileGroup;
        protected Literal path;
        protected bool isDefault = false;
        protected Identifier owner;
    
        public Identifier FileGroup => fileGroup;
        public Literal Path => path;
        public bool IsDefault => isDefault;
        public Identifier Owner => owner;
    
        public CreateFullTextCatalogStatement(Identifier fileGroup = null, Literal path = null, bool isDefault = false, Identifier owner = null, Identifier name = null, IReadOnlyList<FullTextCatalogOption> options = null) {
            this.fileGroup = fileGroup;
            this.path = path;
            this.isDefault = isDefault;
            this.owner = owner;
            this.name = name;
            this.options = ImmList<FullTextCatalogOption>.FromList(options);
        }
    
        public ScriptDom.CreateFullTextCatalogStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateFullTextCatalogStatement();
            ret.FileGroup = (ScriptDom.Identifier)fileGroup?.ToMutable();
            ret.Path = (ScriptDom.Literal)path?.ToMutable();
            ret.IsDefault = isDefault;
            ret.Owner = (ScriptDom.Identifier)owner?.ToMutable();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.FullTextCatalogOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(fileGroup is null)) {
                h = h * 23 + fileGroup.GetHashCode();
            }
            if (!(path is null)) {
                h = h * 23 + path.GetHashCode();
            }
            h = h * 23 + isDefault.GetHashCode();
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateFullTextCatalogStatement);
        } 
        
        public bool Equals(CreateFullTextCatalogStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.FileGroup, fileGroup)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Path, path)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsDefault, isDefault)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<FullTextCatalogOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateFullTextCatalogStatement left, CreateFullTextCatalogStatement right) {
            return EqualityComparer<CreateFullTextCatalogStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateFullTextCatalogStatement left, CreateFullTextCatalogStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateFullTextCatalogStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.fileGroup, othr.fileGroup);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.path, othr.path);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isDefault, othr.isDefault);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateFullTextCatalogStatement left, CreateFullTextCatalogStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateFullTextCatalogStatement left, CreateFullTextCatalogStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateFullTextCatalogStatement left, CreateFullTextCatalogStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateFullTextCatalogStatement left, CreateFullTextCatalogStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateFullTextCatalogStatement FromMutable(ScriptDom.CreateFullTextCatalogStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateFullTextCatalogStatement)) { throw new NotImplementedException("Unexpected subtype of CreateFullTextCatalogStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateFullTextCatalogStatement(
                fileGroup: ImmutableDom.Identifier.FromMutable(fragment.FileGroup),
                path: ImmutableDom.Literal.FromMutable(fragment.Path),
                isDefault: fragment.IsDefault,
                owner: ImmutableDom.Identifier.FromMutable(fragment.Owner),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                options: fragment.Options.SelectList(ImmutableDom.FullTextCatalogOption.FromMutable)
            );
        }
    
    }

}
