using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalFileFormatLiteralOption : ExternalFileFormatOption, IEquatable<ExternalFileFormatLiteralOption> {
        protected Literal @value;
    
        public Literal Value => @value;
    
        public ExternalFileFormatLiteralOption(Literal @value = null, ScriptDom.ExternalFileFormatOptionKind optionKind = ScriptDom.ExternalFileFormatOptionKind.SerDeMethod) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExternalFileFormatLiteralOption ToMutableConcrete() {
            var ret = new ScriptDom.ExternalFileFormatLiteralOption();
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalFileFormatLiteralOption);
        } 
        
        public bool Equals(ExternalFileFormatLiteralOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalFileFormatOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalFileFormatLiteralOption left, ExternalFileFormatLiteralOption right) {
            return EqualityComparer<ExternalFileFormatLiteralOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalFileFormatLiteralOption left, ExternalFileFormatLiteralOption right) {
            return !(left == right);
        }
    
    }

}
