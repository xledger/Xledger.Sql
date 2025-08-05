using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterSearchPropertyListStatement : TSqlStatement, IEquatable<AlterSearchPropertyListStatement> {
        protected Identifier name;
        protected SearchPropertyListAction action;
    
        public Identifier Name => name;
        public SearchPropertyListAction Action => action;
    
        public AlterSearchPropertyListStatement(Identifier name = null, SearchPropertyListAction action = null) {
            this.name = name;
            this.action = action;
        }
    
        public ScriptDom.AlterSearchPropertyListStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterSearchPropertyListStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Action = (ScriptDom.SearchPropertyListAction)action?.ToMutable();
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
            return Equals(obj as AlterSearchPropertyListStatement);
        } 
        
        public bool Equals(AlterSearchPropertyListStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<SearchPropertyListAction>.Default.Equals(other.Action, action)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterSearchPropertyListStatement left, AlterSearchPropertyListStatement right) {
            return EqualityComparer<AlterSearchPropertyListStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterSearchPropertyListStatement left, AlterSearchPropertyListStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterSearchPropertyListStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.action, othr.action);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterSearchPropertyListStatement left, AlterSearchPropertyListStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterSearchPropertyListStatement left, AlterSearchPropertyListStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterSearchPropertyListStatement left, AlterSearchPropertyListStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterSearchPropertyListStatement left, AlterSearchPropertyListStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterSearchPropertyListStatement FromMutable(ScriptDom.AlterSearchPropertyListStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterSearchPropertyListStatement)) { throw new NotImplementedException("Unexpected subtype of AlterSearchPropertyListStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterSearchPropertyListStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                action: ImmutableDom.SearchPropertyListAction.FromMutable(fragment.Action)
            );
        }
    
    }

}
