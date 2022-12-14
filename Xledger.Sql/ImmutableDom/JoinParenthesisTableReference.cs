using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class JoinParenthesisTableReference : TableReference, IEquatable<JoinParenthesisTableReference> {
        protected TableReference join;
    
        public TableReference Join => join;
    
        public JoinParenthesisTableReference(TableReference join = null) {
            this.join = join;
        }
    
        public ScriptDom.JoinParenthesisTableReference ToMutableConcrete() {
            var ret = new ScriptDom.JoinParenthesisTableReference();
            ret.Join = (ScriptDom.TableReference)join?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(join is null)) {
                h = h * 23 + join.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as JoinParenthesisTableReference);
        } 
        
        public bool Equals(JoinParenthesisTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<TableReference>.Default.Equals(other.Join, join)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(JoinParenthesisTableReference left, JoinParenthesisTableReference right) {
            return EqualityComparer<JoinParenthesisTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(JoinParenthesisTableReference left, JoinParenthesisTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (JoinParenthesisTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.join, othr.join);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (JoinParenthesisTableReference left, JoinParenthesisTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(JoinParenthesisTableReference left, JoinParenthesisTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (JoinParenthesisTableReference left, JoinParenthesisTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(JoinParenthesisTableReference left, JoinParenthesisTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static JoinParenthesisTableReference FromMutable(ScriptDom.JoinParenthesisTableReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.JoinParenthesisTableReference)) { throw new NotImplementedException("Unexpected subtype of JoinParenthesisTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new JoinParenthesisTableReference(
                join: ImmutableDom.TableReference.FromMutable(fragment.Join)
            );
        }
    
    }

}
