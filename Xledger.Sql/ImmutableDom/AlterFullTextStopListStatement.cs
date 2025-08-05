using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterFullTextStopListStatement : TSqlStatement, IEquatable<AlterFullTextStopListStatement> {
        protected Identifier name;
        protected FullTextStopListAction action;
    
        public Identifier Name => name;
        public FullTextStopListAction Action => action;
    
        public AlterFullTextStopListStatement(Identifier name = null, FullTextStopListAction action = null) {
            this.name = name;
            this.action = action;
        }
    
        public ScriptDom.AlterFullTextStopListStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterFullTextStopListStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Action = (ScriptDom.FullTextStopListAction)action?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(action is null)) {
                h = h * 23 + action.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterFullTextStopListStatement);
        } 
        
        public bool Equals(AlterFullTextStopListStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<FullTextStopListAction>.Default.Equals(other.Action, action)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterFullTextStopListStatement left, AlterFullTextStopListStatement right) {
            return EqualityComparer<AlterFullTextStopListStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterFullTextStopListStatement left, AlterFullTextStopListStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterFullTextStopListStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.action, othr.action);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterFullTextStopListStatement left, AlterFullTextStopListStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterFullTextStopListStatement left, AlterFullTextStopListStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterFullTextStopListStatement left, AlterFullTextStopListStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterFullTextStopListStatement left, AlterFullTextStopListStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterFullTextStopListStatement FromMutable(ScriptDom.AlterFullTextStopListStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterFullTextStopListStatement)) { throw new NotImplementedException("Unexpected subtype of AlterFullTextStopListStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterFullTextStopListStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                action: ImmutableDom.FullTextStopListAction.FromMutable(fragment.Action)
            );
        }
    
    }

}
