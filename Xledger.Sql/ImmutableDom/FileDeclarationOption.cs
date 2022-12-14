using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileDeclarationOption : TSqlFragment, IEquatable<FileDeclarationOption> {
        protected ScriptDom.FileDeclarationOptionKind optionKind = ScriptDom.FileDeclarationOptionKind.Name;
    
        public ScriptDom.FileDeclarationOptionKind OptionKind => optionKind;
    
        public FileDeclarationOption(ScriptDom.FileDeclarationOptionKind optionKind = ScriptDom.FileDeclarationOptionKind.Name) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.FileDeclarationOption ToMutableConcrete() {
            var ret = new ScriptDom.FileDeclarationOption();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FileDeclarationOption);
        } 
        
        public bool Equals(FileDeclarationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.FileDeclarationOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FileDeclarationOption left, FileDeclarationOption right) {
            return EqualityComparer<FileDeclarationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FileDeclarationOption left, FileDeclarationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FileDeclarationOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (FileDeclarationOption left, FileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FileDeclarationOption left, FileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FileDeclarationOption left, FileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FileDeclarationOption left, FileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FileDeclarationOption FromMutable(ScriptDom.FileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.FileDeclarationOption)) { return TSqlFragment.FromMutable(fragment) as FileDeclarationOption; }
            return new FileDeclarationOption(
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
