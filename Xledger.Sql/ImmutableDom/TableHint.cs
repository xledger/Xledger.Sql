using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TableHint : TSqlFragment, IEquatable<TableHint> {
        protected ScriptDom.TableHintKind hintKind = ScriptDom.TableHintKind.None;
    
        public ScriptDom.TableHintKind HintKind => hintKind;
    
        public TableHint(ScriptDom.TableHintKind hintKind = ScriptDom.TableHintKind.None) {
            this.hintKind = hintKind;
        }
    
        public ScriptDom.TableHint ToMutableConcrete() {
            var ret = new ScriptDom.TableHint();
            ret.HintKind = hintKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + hintKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TableHint);
        } 
        
        public bool Equals(TableHint other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.TableHintKind>.Default.Equals(other.HintKind, hintKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TableHint left, TableHint right) {
            return EqualityComparer<TableHint>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TableHint left, TableHint right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TableHint)that;
            compare = Comparer.DefaultInvariant.Compare(this.hintKind, othr.hintKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (TableHint left, TableHint right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TableHint left, TableHint right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TableHint left, TableHint right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TableHint left, TableHint right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
