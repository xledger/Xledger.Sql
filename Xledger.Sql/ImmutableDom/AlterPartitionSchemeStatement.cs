using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterPartitionSchemeStatement : TSqlStatement, IEquatable<AlterPartitionSchemeStatement> {
        protected Identifier name;
        protected IdentifierOrValueExpression fileGroup;
    
        public Identifier Name => name;
        public IdentifierOrValueExpression FileGroup => fileGroup;
    
        public AlterPartitionSchemeStatement(Identifier name = null, IdentifierOrValueExpression fileGroup = null) {
            this.name = name;
            this.fileGroup = fileGroup;
        }
    
        public ScriptDom.AlterPartitionSchemeStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterPartitionSchemeStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.FileGroup = (ScriptDom.IdentifierOrValueExpression)fileGroup.ToMutable();
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
            if (!(fileGroup is null)) {
                h = h * 23 + fileGroup.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterPartitionSchemeStatement);
        } 
        
        public bool Equals(AlterPartitionSchemeStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.FileGroup, fileGroup)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterPartitionSchemeStatement left, AlterPartitionSchemeStatement right) {
            return EqualityComparer<AlterPartitionSchemeStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterPartitionSchemeStatement left, AlterPartitionSchemeStatement right) {
            return !(left == right);
        }
    
    }

}
