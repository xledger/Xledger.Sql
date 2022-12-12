using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralOpenRowsetCosmosOption : OpenRowsetCosmosOption, IEquatable<LiteralOpenRowsetCosmosOption> {
        Literal @value;
    
        public Literal Value => @value;
    
        public LiteralOpenRowsetCosmosOption(Literal @value = null, ScriptDom.OpenRowsetCosmosOptionKind optionKind = ScriptDom.OpenRowsetCosmosOptionKind.Provider) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LiteralOpenRowsetCosmosOption ToMutableConcrete() {
            var ret = new ScriptDom.LiteralOpenRowsetCosmosOption();
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
            return Equals(obj as LiteralOpenRowsetCosmosOption);
        } 
        
        public bool Equals(LiteralOpenRowsetCosmosOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OpenRowsetCosmosOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralOpenRowsetCosmosOption left, LiteralOpenRowsetCosmosOption right) {
            return EqualityComparer<LiteralOpenRowsetCosmosOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralOpenRowsetCosmosOption left, LiteralOpenRowsetCosmosOption right) {
            return !(left == right);
        }
    
    }

}