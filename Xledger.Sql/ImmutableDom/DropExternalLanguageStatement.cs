using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropExternalLanguageStatement : TSqlStatement, IEquatable<DropExternalLanguageStatement> {
        protected Identifier name;
        protected Identifier owner;
    
        public Identifier Name => name;
        public Identifier Owner => owner;
    
        public DropExternalLanguageStatement(Identifier name = null, Identifier owner = null) {
            this.name = name;
            this.owner = owner;
        }
    
        public ScriptDom.DropExternalLanguageStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropExternalLanguageStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Owner = (ScriptDom.Identifier)owner?.ToMutable();
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
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropExternalLanguageStatement);
        } 
        
        public bool Equals(DropExternalLanguageStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropExternalLanguageStatement left, DropExternalLanguageStatement right) {
            return EqualityComparer<DropExternalLanguageStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropExternalLanguageStatement left, DropExternalLanguageStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropExternalLanguageStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropExternalLanguageStatement left, DropExternalLanguageStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropExternalLanguageStatement left, DropExternalLanguageStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropExternalLanguageStatement left, DropExternalLanguageStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropExternalLanguageStatement left, DropExternalLanguageStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropExternalLanguageStatement FromMutable(ScriptDom.DropExternalLanguageStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropExternalLanguageStatement)) { throw new NotImplementedException("Unexpected subtype of DropExternalLanguageStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropExternalLanguageStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                owner: ImmutableDom.Identifier.FromMutable(fragment.Owner)
            );
        }
    
    }

}
