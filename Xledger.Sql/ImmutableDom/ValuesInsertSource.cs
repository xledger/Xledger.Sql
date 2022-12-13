using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ValuesInsertSource : InsertSource, IEquatable<ValuesInsertSource> {
        protected bool isDefaultValues = false;
        protected IReadOnlyList<RowValue> rowValues;
    
        public bool IsDefaultValues => isDefaultValues;
        public IReadOnlyList<RowValue> RowValues => rowValues;
    
        public ValuesInsertSource(bool isDefaultValues = false, IReadOnlyList<RowValue> rowValues = null) {
            this.isDefaultValues = isDefaultValues;
            this.rowValues = rowValues is null ? ImmList<RowValue>.Empty : ImmList<RowValue>.FromList(rowValues);
        }
    
        public ScriptDom.ValuesInsertSource ToMutableConcrete() {
            var ret = new ScriptDom.ValuesInsertSource();
            ret.IsDefaultValues = isDefaultValues;
            ret.RowValues.AddRange(rowValues.SelectList(c => (ScriptDom.RowValue)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isDefaultValues.GetHashCode();
            h = h * 23 + rowValues.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ValuesInsertSource);
        } 
        
        public bool Equals(ValuesInsertSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsDefaultValues, isDefaultValues)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<RowValue>>.Default.Equals(other.RowValues, rowValues)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ValuesInsertSource left, ValuesInsertSource right) {
            return EqualityComparer<ValuesInsertSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ValuesInsertSource left, ValuesInsertSource right) {
            return !(left == right);
        }
    
        public static ValuesInsertSource FromMutable(ScriptDom.ValuesInsertSource fragment) {
            return (ValuesInsertSource)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
