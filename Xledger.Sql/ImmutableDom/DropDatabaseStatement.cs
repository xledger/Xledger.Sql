using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropDatabaseStatement : TSqlStatement, IEquatable<DropDatabaseStatement> {
        protected IReadOnlyList<Identifier> databases;
        protected bool isIfExists = false;
    
        public IReadOnlyList<Identifier> Databases => databases;
        public bool IsIfExists => isIfExists;
    
        public DropDatabaseStatement(IReadOnlyList<Identifier> databases = null, bool isIfExists = false) {
            this.databases = databases is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(databases);
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropDatabaseStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropDatabaseStatement();
            ret.Databases.AddRange(databases.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + databases.GetHashCode();
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropDatabaseStatement);
        } 
        
        public bool Equals(DropDatabaseStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Databases, databases)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropDatabaseStatement left, DropDatabaseStatement right) {
            return EqualityComparer<DropDatabaseStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropDatabaseStatement left, DropDatabaseStatement right) {
            return !(left == right);
        }
    
    }

}
