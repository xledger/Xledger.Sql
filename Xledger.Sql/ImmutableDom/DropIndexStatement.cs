using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropIndexStatement : TSqlStatement, IEquatable<DropIndexStatement> {
        protected IReadOnlyList<DropIndexClauseBase> dropIndexClauses;
        protected bool isIfExists = false;
    
        public IReadOnlyList<DropIndexClauseBase> DropIndexClauses => dropIndexClauses;
        public bool IsIfExists => isIfExists;
    
        public DropIndexStatement(IReadOnlyList<DropIndexClauseBase> dropIndexClauses = null, bool isIfExists = false) {
            this.dropIndexClauses = dropIndexClauses is null ? ImmList<DropIndexClauseBase>.Empty : ImmList<DropIndexClauseBase>.FromList(dropIndexClauses);
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropIndexStatement();
            ret.DropIndexClauses.AddRange(dropIndexClauses.SelectList(c => (ScriptDom.DropIndexClauseBase)c.ToMutable()));
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + dropIndexClauses.GetHashCode();
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropIndexStatement);
        } 
        
        public bool Equals(DropIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<DropIndexClauseBase>>.Default.Equals(other.DropIndexClauses, dropIndexClauses)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropIndexStatement left, DropIndexStatement right) {
            return EqualityComparer<DropIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropIndexStatement left, DropIndexStatement right) {
            return !(left == right);
        }
    
        public static DropIndexStatement FromMutable(ScriptDom.DropIndexStatement fragment) {
            return (DropIndexStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
