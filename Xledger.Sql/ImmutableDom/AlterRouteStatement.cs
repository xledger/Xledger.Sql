using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterRouteStatement : RouteStatement, IEquatable<AlterRouteStatement> {
        public AlterRouteStatement(Identifier name = null, IReadOnlyList<RouteOption> routeOptions = null) {
            this.name = name;
            this.routeOptions = routeOptions.ToImmArray<RouteOption>();
        }
    
        public ScriptDom.AlterRouteStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterRouteStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.RouteOptions.AddRange(routeOptions.Select(c => (ScriptDom.RouteOption)c?.ToMutable()));
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
            h = h * 23 + routeOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterRouteStatement);
        } 
        
        public bool Equals(AlterRouteStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<RouteOption>>.Default.Equals(other.RouteOptions, routeOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterRouteStatement left, AlterRouteStatement right) {
            return EqualityComparer<AlterRouteStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterRouteStatement left, AlterRouteStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterRouteStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.routeOptions, othr.routeOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterRouteStatement left, AlterRouteStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterRouteStatement left, AlterRouteStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterRouteStatement left, AlterRouteStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterRouteStatement left, AlterRouteStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterRouteStatement FromMutable(ScriptDom.AlterRouteStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterRouteStatement)) { throw new NotImplementedException("Unexpected subtype of AlterRouteStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterRouteStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                routeOptions: fragment.RouteOptions.ToImmArray(ImmutableDom.RouteOption.FromMutable)
            );
        }
    
    }

}
