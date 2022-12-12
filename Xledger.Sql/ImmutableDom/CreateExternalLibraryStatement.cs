using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateExternalLibraryStatement : ExternalLibraryStatement, IEquatable<CreateExternalLibraryStatement> {
        Identifier owner;
    
        public Identifier Owner => owner;
    
        public CreateExternalLibraryStatement(Identifier owner = null, Identifier name = null, StringLiteral language = null, IReadOnlyList<ExternalLibraryFileOption> externalLibraryFiles = null) {
            this.owner = owner;
            this.name = name;
            this.language = language;
            this.externalLibraryFiles = externalLibraryFiles is null ? ImmList<ExternalLibraryFileOption>.Empty : ImmList<ExternalLibraryFileOption>.FromList(externalLibraryFiles);
        }
    
        public ScriptDom.CreateExternalLibraryStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateExternalLibraryStatement();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Language = (ScriptDom.StringLiteral)language.ToMutable();
            ret.ExternalLibraryFiles.AddRange(externalLibraryFiles.Select(c => (ScriptDom.ExternalLibraryFileOption)c.ToMutable()));
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
            return Equals(obj as CreateExternalLibraryStatement);
        } 
        
        public bool Equals(CreateExternalLibraryStatement other) {
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
        
        public static bool operator ==(CreateExternalLibraryStatement left, CreateExternalLibraryStatement right) {
            return EqualityComparer<CreateExternalLibraryStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateExternalLibraryStatement left, CreateExternalLibraryStatement right) {
            return !(left == right);
        }
    
    }

}