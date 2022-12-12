using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DeclareCursorStatement : TSqlStatement, IEquatable<DeclareCursorStatement> {
        Identifier name;
        CursorDefinition cursorDefinition;
    
        public Identifier Name => name;
        public CursorDefinition CursorDefinition => cursorDefinition;
    
        public DeclareCursorStatement(Identifier name = null, CursorDefinition cursorDefinition = null) {
            this.name = name;
            this.cursorDefinition = cursorDefinition;
        }
    
        public ScriptDom.DeclareCursorStatement ToMutableConcrete() {
            var ret = new ScriptDom.DeclareCursorStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.CursorDefinition = (ScriptDom.CursorDefinition)cursorDefinition.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(cursorDefinition is null)) {
                h = h * 23 + cursorDefinition.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DeclareCursorStatement);
        } 
        
        public bool Equals(DeclareCursorStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<CursorDefinition>.Default.Equals(other.CursorDefinition, cursorDefinition)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DeclareCursorStatement left, DeclareCursorStatement right) {
            return EqualityComparer<DeclareCursorStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DeclareCursorStatement left, DeclareCursorStatement right) {
            return !(left == right);
        }
    
    }

}
