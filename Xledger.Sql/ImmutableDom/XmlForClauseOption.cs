using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class XmlForClauseOption : ForClause, IEquatable<XmlForClauseOption> {
        ScriptDom.XmlForClauseOptions optionKind = ScriptDom.XmlForClauseOptions.None;
        Literal @value;
    
        public ScriptDom.XmlForClauseOptions OptionKind => optionKind;
        public Literal Value => @value;
    
        public XmlForClauseOption(ScriptDom.XmlForClauseOptions optionKind = ScriptDom.XmlForClauseOptions.None, Literal @value = null) {
            this.optionKind = optionKind;
            this.@value = @value;
        }
    
        public ScriptDom.XmlForClauseOption ToMutableConcrete() {
            var ret = new ScriptDom.XmlForClauseOption();
            ret.OptionKind = optionKind;
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as XmlForClauseOption);
        } 
        
        public bool Equals(XmlForClauseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.XmlForClauseOptions>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(XmlForClauseOption left, XmlForClauseOption right) {
            return EqualityComparer<XmlForClauseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(XmlForClauseOption left, XmlForClauseOption right) {
            return !(left == right);
        }
    
    }

}
