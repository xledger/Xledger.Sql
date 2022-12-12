using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IndexTableHint : TableHint, IEquatable<IndexTableHint> {
        IReadOnlyList<IdentifierOrValueExpression> indexValues;
    
        public IReadOnlyList<IdentifierOrValueExpression> IndexValues => indexValues;
    
        public IndexTableHint(IReadOnlyList<IdentifierOrValueExpression> indexValues = null, ScriptDom.TableHintKind hintKind = ScriptDom.TableHintKind.None) {
            this.indexValues = indexValues is null ? ImmList<IdentifierOrValueExpression>.Empty : ImmList<IdentifierOrValueExpression>.FromList(indexValues);
            this.hintKind = hintKind;
        }
    
        public ScriptDom.IndexTableHint ToMutableConcrete() {
            var ret = new ScriptDom.IndexTableHint();
            ret.IndexValues.AddRange(indexValues.Select(c => (ScriptDom.IdentifierOrValueExpression)c.ToMutable()));
            ret.HintKind = hintKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + indexValues.GetHashCode();
            h = h * 23 + hintKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IndexTableHint);
        } 
        
        public bool Equals(IndexTableHint other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<IdentifierOrValueExpression>>.Default.Equals(other.IndexValues, indexValues)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableHintKind>.Default.Equals(other.HintKind, hintKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IndexTableHint left, IndexTableHint right) {
            return EqualityComparer<IndexTableHint>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IndexTableHint left, IndexTableHint right) {
            return !(left == right);
        }
    
    }

}
