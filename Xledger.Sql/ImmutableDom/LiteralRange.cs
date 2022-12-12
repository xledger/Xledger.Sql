using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralRange : TSqlFragment, IEquatable<LiteralRange> {
        Literal from;
        Literal to;
    
        public Literal From => from;
        public Literal To => to;
    
        public LiteralRange(Literal from = null, Literal to = null) {
            this.from = from;
            this.to = to;
        }
    
        public ScriptDom.LiteralRange ToMutableConcrete() {
            var ret = new ScriptDom.LiteralRange();
            ret.From = (ScriptDom.Literal)from.ToMutable();
            ret.To = (ScriptDom.Literal)to.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(from is null)) {
                h = h * 23 + from.GetHashCode();
            }
            if (!(to is null)) {
                h = h * 23 + to.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LiteralRange);
        } 
        
        public bool Equals(LiteralRange other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.From, from)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.To, to)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralRange left, LiteralRange right) {
            return EqualityComparer<LiteralRange>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralRange left, LiteralRange right) {
            return !(left == right);
        }
    
    }

}