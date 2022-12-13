using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileDeclaration : TSqlFragment, IEquatable<FileDeclaration> {
        protected IReadOnlyList<FileDeclarationOption> options;
        protected bool isPrimary = false;
    
        public IReadOnlyList<FileDeclarationOption> Options => options;
        public bool IsPrimary => isPrimary;
    
        public FileDeclaration(IReadOnlyList<FileDeclarationOption> options = null, bool isPrimary = false) {
            this.options = options is null ? ImmList<FileDeclarationOption>.Empty : ImmList<FileDeclarationOption>.FromList(options);
            this.isPrimary = isPrimary;
        }
    
        public ScriptDom.FileDeclaration ToMutableConcrete() {
            var ret = new ScriptDom.FileDeclaration();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.FileDeclarationOption)c.ToMutable()));
            ret.IsPrimary = isPrimary;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            h = h * 23 + isPrimary.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FileDeclaration);
        } 
        
        public bool Equals(FileDeclaration other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<FileDeclarationOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsPrimary, isPrimary)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FileDeclaration left, FileDeclaration right) {
            return EqualityComparer<FileDeclaration>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FileDeclaration left, FileDeclaration right) {
            return !(left == right);
        }
    
        public static FileDeclaration FromMutable(ScriptDom.FileDeclaration fragment) {
            return (FileDeclaration)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
