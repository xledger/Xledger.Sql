using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RouteOption : TSqlFragment, IEquatable<RouteOption> {
        protected ScriptDom.RouteOptionKind optionKind = ScriptDom.RouteOptionKind.Address;
        protected Literal literal;
    
        public ScriptDom.RouteOptionKind OptionKind => optionKind;
        public Literal Literal => literal;
    
        public RouteOption(ScriptDom.RouteOptionKind optionKind = ScriptDom.RouteOptionKind.Address, Literal literal = null) {
            this.optionKind = optionKind;
            this.literal = literal;
        }
    
        public ScriptDom.RouteOption ToMutableConcrete() {
            var ret = new ScriptDom.RouteOption();
            ret.OptionKind = optionKind;
            ret.Literal = (ScriptDom.Literal)literal.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            if (!(literal is null)) {
                h = h * 23 + literal.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RouteOption);
        } 
        
        public bool Equals(RouteOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.RouteOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Literal, literal)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RouteOption left, RouteOption right) {
            return EqualityComparer<RouteOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RouteOption left, RouteOption right) {
            return !(left == right);
        }
    
    }

}
