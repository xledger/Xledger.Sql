using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UpdateMergeAction : MergeAction, IEquatable<UpdateMergeAction> {
        protected IReadOnlyList<SetClause> setClauses;
    
        public IReadOnlyList<SetClause> SetClauses => setClauses;
    
        public UpdateMergeAction(IReadOnlyList<SetClause> setClauses = null) {
            this.setClauses = setClauses is null ? ImmList<SetClause>.Empty : ImmList<SetClause>.FromList(setClauses);
        }
    
        public ScriptDom.UpdateMergeAction ToMutableConcrete() {
            var ret = new ScriptDom.UpdateMergeAction();
            ret.SetClauses.AddRange(setClauses.SelectList(c => (ScriptDom.SetClause)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + setClauses.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UpdateMergeAction);
        } 
        
        public bool Equals(UpdateMergeAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<SetClause>>.Default.Equals(other.SetClauses, setClauses)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UpdateMergeAction left, UpdateMergeAction right) {
            return EqualityComparer<UpdateMergeAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UpdateMergeAction left, UpdateMergeAction right) {
            return !(left == right);
        }
    
        public static UpdateMergeAction FromMutable(ScriptDom.UpdateMergeAction fragment) {
            return (UpdateMergeAction)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
