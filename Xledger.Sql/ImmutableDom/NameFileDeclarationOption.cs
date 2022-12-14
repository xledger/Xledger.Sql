using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class NameFileDeclarationOption : FileDeclarationOption, IEquatable<NameFileDeclarationOption> {
        protected IdentifierOrValueExpression logicalFileName;
        protected bool isNewName = false;
    
        public IdentifierOrValueExpression LogicalFileName => logicalFileName;
        public bool IsNewName => isNewName;
    
        public NameFileDeclarationOption(IdentifierOrValueExpression logicalFileName = null, bool isNewName = false, ScriptDom.FileDeclarationOptionKind optionKind = ScriptDom.FileDeclarationOptionKind.Name) {
            this.logicalFileName = logicalFileName;
            this.isNewName = isNewName;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.NameFileDeclarationOption ToMutableConcrete() {
            var ret = new ScriptDom.NameFileDeclarationOption();
            ret.LogicalFileName = (ScriptDom.IdentifierOrValueExpression)logicalFileName.ToMutable();
            ret.IsNewName = isNewName;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(logicalFileName is null)) {
                h = h * 23 + logicalFileName.GetHashCode();
            }
            h = h * 23 + isNewName.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as NameFileDeclarationOption);
        } 
        
        public bool Equals(NameFileDeclarationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.LogicalFileName, logicalFileName)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsNewName, isNewName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.FileDeclarationOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(NameFileDeclarationOption left, NameFileDeclarationOption right) {
            return EqualityComparer<NameFileDeclarationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(NameFileDeclarationOption left, NameFileDeclarationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (NameFileDeclarationOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.logicalFileName, othr.logicalFileName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isNewName, othr.isNewName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (NameFileDeclarationOption left, NameFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(NameFileDeclarationOption left, NameFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (NameFileDeclarationOption left, NameFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(NameFileDeclarationOption left, NameFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static NameFileDeclarationOption FromMutable(ScriptDom.NameFileDeclarationOption fragment) {
            return (NameFileDeclarationOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
