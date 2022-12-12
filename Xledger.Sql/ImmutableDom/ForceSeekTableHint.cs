using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ForceSeekTableHint : TableHint, IEquatable<ForceSeekTableHint> {
        protected IdentifierOrValueExpression indexValue;
        protected IReadOnlyList<ColumnReferenceExpression> columnValues;
    
        public IdentifierOrValueExpression IndexValue => indexValue;
        public IReadOnlyList<ColumnReferenceExpression> ColumnValues => columnValues;
    
        public ForceSeekTableHint(IdentifierOrValueExpression indexValue = null, IReadOnlyList<ColumnReferenceExpression> columnValues = null, ScriptDom.TableHintKind hintKind = ScriptDom.TableHintKind.None) {
            this.indexValue = indexValue;
            this.columnValues = columnValues is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(columnValues);
            this.hintKind = hintKind;
        }
    
        public ScriptDom.ForceSeekTableHint ToMutableConcrete() {
            var ret = new ScriptDom.ForceSeekTableHint();
            ret.IndexValue = (ScriptDom.IdentifierOrValueExpression)indexValue.ToMutable();
            ret.ColumnValues.AddRange(columnValues.SelectList(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            ret.HintKind = hintKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(indexValue is null)) {
                h = h * 23 + indexValue.GetHashCode();
            }
            h = h * 23 + columnValues.GetHashCode();
            h = h * 23 + hintKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ForceSeekTableHint);
        } 
        
        public bool Equals(ForceSeekTableHint other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.IndexValue, indexValue)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.ColumnValues, columnValues)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableHintKind>.Default.Equals(other.HintKind, hintKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ForceSeekTableHint left, ForceSeekTableHint right) {
            return EqualityComparer<ForceSeekTableHint>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ForceSeekTableHint left, ForceSeekTableHint right) {
            return !(left == right);
        }
    
    }

}
