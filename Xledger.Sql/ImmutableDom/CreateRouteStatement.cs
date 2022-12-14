using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateRouteStatement : RouteStatement, IEquatable<CreateRouteStatement> {
        protected Identifier owner;
    
        public Identifier Owner => owner;
    
        public CreateRouteStatement(Identifier owner = null, Identifier name = null, IReadOnlyList<RouteOption> routeOptions = null) {
            this.owner = owner;
            this.name = name;
            this.routeOptions = ImmList<RouteOption>.FromList(routeOptions);
        }
    
        public ScriptDom.CreateRouteStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateRouteStatement();
            ret.Owner = (ScriptDom.Identifier)owner?.ToMutable();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.RouteOptions.AddRange(routeOptions.SelectList(c => (ScriptDom.RouteOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + routeOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateRouteStatement);
        } 
        
        public bool Equals(CreateRouteStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<RouteOption>>.Default.Equals(other.RouteOptions, routeOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateRouteStatement left, CreateRouteStatement right) {
            return EqualityComparer<CreateRouteStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateRouteStatement left, CreateRouteStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateRouteStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.routeOptions, othr.routeOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateRouteStatement left, CreateRouteStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateRouteStatement left, CreateRouteStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateRouteStatement left, CreateRouteStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateRouteStatement left, CreateRouteStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateRouteStatement FromMutable(ScriptDom.CreateRouteStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateRouteStatement)) { throw new NotImplementedException("Unexpected subtype of CreateRouteStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateRouteStatement(
                owner: ImmutableDom.Identifier.FromMutable(fragment.Owner),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                routeOptions: fragment.RouteOptions.SelectList(ImmutableDom.RouteOption.FromMutable)
            );
        }
    
    }

}
