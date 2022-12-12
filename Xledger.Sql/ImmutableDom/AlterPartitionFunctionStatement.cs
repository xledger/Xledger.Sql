using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterPartitionFunctionStatement : TSqlStatement, IEquatable<AlterPartitionFunctionStatement> {
        protected Identifier name;
        protected bool isSplit = false;
        protected ScalarExpression boundary;
    
        public Identifier Name => name;
        public bool IsSplit => isSplit;
        public ScalarExpression Boundary => boundary;
    
        public AlterPartitionFunctionStatement(Identifier name = null, bool isSplit = false, ScalarExpression boundary = null) {
            this.name = name;
            this.isSplit = isSplit;
            this.boundary = boundary;
        }
    
        public ScriptDom.AlterPartitionFunctionStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterPartitionFunctionStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.IsSplit = isSplit;
            ret.Boundary = (ScriptDom.ScalarExpression)boundary.ToMutable();
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
            h = h * 23 + isSplit.GetHashCode();
            if (!(boundary is null)) {
                h = h * 23 + boundary.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterPartitionFunctionStatement);
        } 
        
        public bool Equals(AlterPartitionFunctionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsSplit, isSplit)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Boundary, boundary)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterPartitionFunctionStatement left, AlterPartitionFunctionStatement right) {
            return EqualityComparer<AlterPartitionFunctionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterPartitionFunctionStatement left, AlterPartitionFunctionStatement right) {
            return !(left == right);
        }
    
    }

}
