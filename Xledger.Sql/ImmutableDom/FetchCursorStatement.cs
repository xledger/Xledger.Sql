using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FetchCursorStatement : CursorStatement, IEquatable<FetchCursorStatement> {
        protected FetchType fetchType;
        protected IReadOnlyList<VariableReference> intoVariables;
    
        public FetchType FetchType => fetchType;
        public IReadOnlyList<VariableReference> IntoVariables => intoVariables;
    
        public FetchCursorStatement(FetchType fetchType = null, IReadOnlyList<VariableReference> intoVariables = null, CursorId cursor = null) {
            this.fetchType = fetchType;
            this.intoVariables = ImmList<VariableReference>.FromList(intoVariables);
            this.cursor = cursor;
        }
    
        public ScriptDom.FetchCursorStatement ToMutableConcrete() {
            var ret = new ScriptDom.FetchCursorStatement();
            ret.FetchType = (ScriptDom.FetchType)fetchType.ToMutable();
            ret.IntoVariables.AddRange(intoVariables.SelectList(c => (ScriptDom.VariableReference)c.ToMutable()));
            ret.Cursor = (ScriptDom.CursorId)cursor.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(fetchType is null)) {
                h = h * 23 + fetchType.GetHashCode();
            }
            h = h * 23 + intoVariables.GetHashCode();
            if (!(cursor is null)) {
                h = h * 23 + cursor.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FetchCursorStatement);
        } 
        
        public bool Equals(FetchCursorStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<FetchType>.Default.Equals(other.FetchType, fetchType)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<VariableReference>>.Default.Equals(other.IntoVariables, intoVariables)) {
                return false;
            }
            if (!EqualityComparer<CursorId>.Default.Equals(other.Cursor, cursor)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FetchCursorStatement left, FetchCursorStatement right) {
            return EqualityComparer<FetchCursorStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FetchCursorStatement left, FetchCursorStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FetchCursorStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.fetchType, othr.fetchType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.intoVariables, othr.intoVariables);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.cursor, othr.cursor);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (FetchCursorStatement left, FetchCursorStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FetchCursorStatement left, FetchCursorStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FetchCursorStatement left, FetchCursorStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FetchCursorStatement left, FetchCursorStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FetchCursorStatement FromMutable(ScriptDom.FetchCursorStatement fragment) {
            return (FetchCursorStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
