using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropPartitionFunctionStatement : DropUnownedObjectStatement, IEquatable<DropPartitionFunctionStatement> {
        public DropPartitionFunctionStatement(Identifier name = null, bool isIfExists = false) {
            this.name = name;
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropPartitionFunctionStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropPartitionFunctionStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.IsIfExists = isIfExists;
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
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropPartitionFunctionStatement);
        } 
        
        public bool Equals(DropPartitionFunctionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropPartitionFunctionStatement left, DropPartitionFunctionStatement right) {
            return EqualityComparer<DropPartitionFunctionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropPartitionFunctionStatement left, DropPartitionFunctionStatement right) {
            return !(left == right);
        }
    
    }

}
