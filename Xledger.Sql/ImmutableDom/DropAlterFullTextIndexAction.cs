using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropAlterFullTextIndexAction : AlterFullTextIndexAction, IEquatable<DropAlterFullTextIndexAction> {
        protected IReadOnlyList<Identifier> columns;
        protected bool withNoPopulation = false;
    
        public IReadOnlyList<Identifier> Columns => columns;
        public bool WithNoPopulation => withNoPopulation;
    
        public DropAlterFullTextIndexAction(IReadOnlyList<Identifier> columns = null, bool withNoPopulation = false) {
            this.columns = columns is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(columns);
            this.withNoPopulation = withNoPopulation;
        }
    
        public ScriptDom.DropAlterFullTextIndexAction ToMutableConcrete() {
            var ret = new ScriptDom.DropAlterFullTextIndexAction();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.WithNoPopulation = withNoPopulation;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columns.GetHashCode();
            h = h * 23 + withNoPopulation.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropAlterFullTextIndexAction);
        } 
        
        public bool Equals(DropAlterFullTextIndexAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithNoPopulation, withNoPopulation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropAlterFullTextIndexAction left, DropAlterFullTextIndexAction right) {
            return EqualityComparer<DropAlterFullTextIndexAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropAlterFullTextIndexAction left, DropAlterFullTextIndexAction right) {
            return !(left == right);
        }
    
    }

}
