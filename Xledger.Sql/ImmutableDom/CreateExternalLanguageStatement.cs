using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateExternalLanguageStatement : ExternalLanguageStatement, IEquatable<CreateExternalLanguageStatement> {
        Identifier owner;
    
        public Identifier Owner => owner;
    
        public CreateExternalLanguageStatement(Identifier owner = null, Identifier name = null, IReadOnlyList<ExternalLanguageFileOption> externalLanguageFiles = null) {
            this.owner = owner;
            this.name = name;
            this.externalLanguageFiles = externalLanguageFiles is null ? ImmList<ExternalLanguageFileOption>.Empty : ImmList<ExternalLanguageFileOption>.FromList(externalLanguageFiles);
        }
    
        public ScriptDom.CreateExternalLanguageStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateExternalLanguageStatement();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ExternalLanguageFiles.AddRange(externalLanguageFiles.Select(c => (ScriptDom.ExternalLanguageFileOption)c.ToMutable()));
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
    
    }

}
