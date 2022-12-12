using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class NameFileDeclarationOption : FileDeclarationOption, IEquatable<NameFileDeclarationOption> {
        IdentifierOrValueExpression logicalFileName;
        bool isNewName = false;
    
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
    
    }

}
