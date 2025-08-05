using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateSearchPropertyListStatement : TSqlStatement, IEquatable<CreateSearchPropertyListStatement> {
        protected Identifier name;
        protected MultiPartIdentifier sourceSearchPropertyList;
        protected Identifier owner;
    
        public Identifier Name => name;
        public MultiPartIdentifier SourceSearchPropertyList => sourceSearchPropertyList;
        public Identifier Owner => owner;
    
        public CreateSearchPropertyListStatement(Identifier name = null, MultiPartIdentifier sourceSearchPropertyList = null, Identifier owner = null) {
            this.name = name;
            this.sourceSearchPropertyList = sourceSearchPropertyList;
            this.owner = owner;
        }
    
        public ScriptDom.CreateSearchPropertyListStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateSearchPropertyListStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.SourceSearchPropertyList = (ScriptDom.MultiPartIdentifier)sourceSearchPropertyList?.ToMutable();
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
            if (!(sourceSearchPropertyList is null)) {
                h = h * 23 + sourceSearchPropertyList.GetHashCode();
            }
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateSearchPropertyListStatement);
        } 
        
        public bool Equals(CreateSearchPropertyListStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<MultiPartIdentifier>.Default.Equals(other.SourceSearchPropertyList, sourceSearchPropertyList)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateSearchPropertyListStatement left, CreateSearchPropertyListStatement right) {
            return EqualityComparer<CreateSearchPropertyListStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateSearchPropertyListStatement left, CreateSearchPropertyListStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateSearchPropertyListStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sourceSearchPropertyList, othr.sourceSearchPropertyList);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateSearchPropertyListStatement left, CreateSearchPropertyListStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateSearchPropertyListStatement left, CreateSearchPropertyListStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateSearchPropertyListStatement left, CreateSearchPropertyListStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateSearchPropertyListStatement left, CreateSearchPropertyListStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateSearchPropertyListStatement FromMutable(ScriptDom.CreateSearchPropertyListStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateSearchPropertyListStatement)) { throw new NotImplementedException("Unexpected subtype of CreateSearchPropertyListStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSearchPropertyListStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                sourceSearchPropertyList: ImmutableDom.MultiPartIdentifier.FromMutable(fragment.SourceSearchPropertyList),
                owner: ImmutableDom.Identifier.FromMutable(fragment.Owner)
            );
        }
    
    }

}
