using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileStreamOnDropIndexOption : IndexOption, IEquatable<FileStreamOnDropIndexOption> {
        IdentifierOrValueExpression fileStreamOn;
    
        public IdentifierOrValueExpression FileStreamOn => fileStreamOn;
    
        public FileStreamOnDropIndexOption(IdentifierOrValueExpression fileStreamOn = null, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.fileStreamOn = fileStreamOn;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.FileStreamOnDropIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.FileStreamOnDropIndexOption();
            ret.FileStreamOn = (ScriptDom.IdentifierOrValueExpression)fileStreamOn.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(fileStreamOn is null)) {
                h = h * 23 + fileStreamOn.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FileStreamOnDropIndexOption);
        } 
        
        public bool Equals(FileStreamOnDropIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.FileStreamOn, fileStreamOn)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.IndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FileStreamOnDropIndexOption left, FileStreamOnDropIndexOption right) {
            return EqualityComparer<FileStreamOnDropIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FileStreamOnDropIndexOption left, FileStreamOnDropIndexOption right) {
            return !(left == right);
        }
    
    }

}