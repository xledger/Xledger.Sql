using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SingleValueTypeCopyOption : CopyStatementOptionBase, IEquatable<SingleValueTypeCopyOption> {
        IdentifierOrValueExpression singleValue;
    
        public IdentifierOrValueExpression SingleValue => singleValue;
    
        public SingleValueTypeCopyOption(IdentifierOrValueExpression singleValue = null) {
            this.singleValue = singleValue;
        }
    
        public ScriptDom.SingleValueTypeCopyOption ToMutableConcrete() {
            var ret = new ScriptDom.SingleValueTypeCopyOption();
            ret.SingleValue = (ScriptDom.IdentifierOrValueExpression)singleValue.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(singleValue is null)) {
                h = h * 23 + singleValue.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SingleValueTypeCopyOption);
        } 
        
        public bool Equals(SingleValueTypeCopyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.SingleValue, singleValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SingleValueTypeCopyOption left, SingleValueTypeCopyOption right) {
            return EqualityComparer<SingleValueTypeCopyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SingleValueTypeCopyOption left, SingleValueTypeCopyOption right) {
            return !(left == right);
        }
    
    }

}
