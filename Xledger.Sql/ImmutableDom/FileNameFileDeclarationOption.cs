using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileNameFileDeclarationOption : FileDeclarationOption, IEquatable<FileNameFileDeclarationOption> {
        protected Literal oSFileName;
    
        public Literal OSFileName => oSFileName;
    
        public FileNameFileDeclarationOption(Literal oSFileName = null, ScriptDom.FileDeclarationOptionKind optionKind = ScriptDom.FileDeclarationOptionKind.Name) {
            this.oSFileName = oSFileName;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.FileNameFileDeclarationOption ToMutableConcrete() {
            var ret = new ScriptDom.FileNameFileDeclarationOption();
            ret.OSFileName = (ScriptDom.Literal)oSFileName.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(oSFileName is null)) {
                h = h * 23 + oSFileName.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FileNameFileDeclarationOption);
        } 
        
        public bool Equals(FileNameFileDeclarationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.OSFileName, oSFileName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.FileDeclarationOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FileNameFileDeclarationOption left, FileNameFileDeclarationOption right) {
            return EqualityComparer<FileNameFileDeclarationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FileNameFileDeclarationOption left, FileNameFileDeclarationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FileNameFileDeclarationOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.oSFileName, othr.oSFileName);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static FileNameFileDeclarationOption FromMutable(ScriptDom.FileNameFileDeclarationOption fragment) {
            return (FileNameFileDeclarationOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
