using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CursorId : TSqlFragment, IEquatable<CursorId> {
        protected bool isGlobal = false;
        protected IdentifierOrValueExpression name;
    
        public bool IsGlobal => isGlobal;
        public IdentifierOrValueExpression Name => name;
    
        public CursorId(bool isGlobal = false, IdentifierOrValueExpression name = null) {
            this.isGlobal = isGlobal;
            this.name = name;
        }
    
        public ScriptDom.CursorId ToMutableConcrete() {
            var ret = new ScriptDom.CursorId();
            ret.IsGlobal = isGlobal;
            ret.Name = (ScriptDom.IdentifierOrValueExpression)name.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isGlobal.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CursorId);
        } 
        
        public bool Equals(CursorId other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsGlobal, isGlobal)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CursorId left, CursorId right) {
            return EqualityComparer<CursorId>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CursorId left, CursorId right) {
            return !(left == right);
        }
    
    }

}
