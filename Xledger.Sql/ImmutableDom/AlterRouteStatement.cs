using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterRouteStatement : RouteStatement, IEquatable<AlterRouteStatement> {
        public AlterRouteStatement(Identifier name = null, IReadOnlyList<RouteOption> routeOptions = null) {
            this.name = name;
            this.routeOptions = routeOptions is null ? ImmList<RouteOption>.Empty : ImmList<RouteOption>.FromList(routeOptions);
        }
    
        public ScriptDom.AlterRouteStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterRouteStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.RouteOptions.AddRange(routeOptions.Select(c => (ScriptDom.RouteOption)c.ToMutable()));
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
    
    }

}
