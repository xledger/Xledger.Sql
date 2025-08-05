using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CloseSymmetricKeyStatement : TSqlStatement, IEquatable<CloseSymmetricKeyStatement> {
        protected Identifier name;
        protected bool all = false;
    
        public Identifier Name => name;
        public bool All => all;
    
        public CloseSymmetricKeyStatement(Identifier name = null, bool all = false) {
            this.name = name;
            this.all = all;
        }
    
        public ScriptDom.CloseSymmetricKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CloseSymmetricKeyStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.All = all;
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
            h = h * 23 + all.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CloseSymmetricKeyStatement);
        } 
        
        public bool Equals(CloseSymmetricKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.All, all)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CloseSymmetricKeyStatement left, CloseSymmetricKeyStatement right) {
            return EqualityComparer<CloseSymmetricKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CloseSymmetricKeyStatement left, CloseSymmetricKeyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CloseSymmetricKeyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.all, othr.all);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CloseSymmetricKeyStatement left, CloseSymmetricKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CloseSymmetricKeyStatement left, CloseSymmetricKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CloseSymmetricKeyStatement left, CloseSymmetricKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CloseSymmetricKeyStatement left, CloseSymmetricKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CloseSymmetricKeyStatement FromMutable(ScriptDom.CloseSymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CloseSymmetricKeyStatement)) { throw new NotImplementedException("Unexpected subtype of CloseSymmetricKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CloseSymmetricKeyStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                all: fragment.All
            );
        }
    
    }

}
