using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FetchType : TSqlFragment, IEquatable<FetchType> {
        protected ScriptDom.FetchOrientation orientation = ScriptDom.FetchOrientation.None;
        protected ScalarExpression rowOffset;
    
        public ScriptDom.FetchOrientation Orientation => orientation;
        public ScalarExpression RowOffset => rowOffset;
    
        public FetchType(ScriptDom.FetchOrientation orientation = ScriptDom.FetchOrientation.None, ScalarExpression rowOffset = null) {
            this.orientation = orientation;
            this.rowOffset = rowOffset;
        }
    
        public ScriptDom.FetchType ToMutableConcrete() {
            var ret = new ScriptDom.FetchType();
            ret.Orientation = orientation;
            ret.RowOffset = (ScriptDom.ScalarExpression)rowOffset.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + orientation.GetHashCode();
            if (!(rowOffset is null)) {
                h = h * 23 + rowOffset.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FetchType);
        } 
        
        public bool Equals(FetchType other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.FetchOrientation>.Default.Equals(other.Orientation, orientation)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.RowOffset, rowOffset)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FetchType left, FetchType right) {
            return EqualityComparer<FetchType>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FetchType left, FetchType right) {
            return !(left == right);
        }
    
        public static FetchType FromMutable(ScriptDom.FetchType fragment) {
            return (FetchType)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
