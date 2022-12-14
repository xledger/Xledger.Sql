using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterExternalLibraryStatement : ExternalLibraryStatement, IEquatable<AlterExternalLibraryStatement> {
        protected Identifier owner;
    
        public Identifier Owner => owner;
    
        public AlterExternalLibraryStatement(Identifier owner = null, Identifier name = null, StringLiteral language = null, IReadOnlyList<ExternalLibraryFileOption> externalLibraryFiles = null) {
            this.owner = owner;
            this.name = name;
            this.language = language;
            this.externalLibraryFiles = ImmList<ExternalLibraryFileOption>.FromList(externalLibraryFiles);
        }
    
        public ScriptDom.AlterExternalLibraryStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterExternalLibraryStatement();
            ret.Owner = (ScriptDom.Identifier)owner?.ToMutable();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Language = (ScriptDom.StringLiteral)language?.ToMutable();
            ret.ExternalLibraryFiles.AddRange(externalLibraryFiles.SelectList(c => (ScriptDom.ExternalLibraryFileOption)c?.ToMutable()));
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
            if (!(language is null)) {
                h = h * 23 + language.GetHashCode();
            }
            h = h * 23 + externalLibraryFiles.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterExternalLibraryStatement);
        } 
        
        public bool Equals(AlterExternalLibraryStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Language, language)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExternalLibraryFileOption>>.Default.Equals(other.ExternalLibraryFiles, externalLibraryFiles)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterExternalLibraryStatement left, AlterExternalLibraryStatement right) {
            return EqualityComparer<AlterExternalLibraryStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterExternalLibraryStatement left, AlterExternalLibraryStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterExternalLibraryStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.language, othr.language);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.externalLibraryFiles, othr.externalLibraryFiles);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterExternalLibraryStatement left, AlterExternalLibraryStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterExternalLibraryStatement left, AlterExternalLibraryStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterExternalLibraryStatement left, AlterExternalLibraryStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterExternalLibraryStatement left, AlterExternalLibraryStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterExternalLibraryStatement FromMutable(ScriptDom.AlterExternalLibraryStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterExternalLibraryStatement)) { throw new NotImplementedException("Unexpected subtype of AlterExternalLibraryStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterExternalLibraryStatement(
                owner: ImmutableDom.Identifier.FromMutable(fragment.Owner),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                language: ImmutableDom.StringLiteral.FromMutable(fragment.Language),
                externalLibraryFiles: fragment.ExternalLibraryFiles.SelectList(ImmutableDom.ExternalLibraryFileOption.FromMutable)
            );
        }
    
    }

}
