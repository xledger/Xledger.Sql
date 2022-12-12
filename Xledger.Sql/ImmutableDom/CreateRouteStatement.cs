using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateRouteStatement : RouteStatement, IEquatable<CreateRouteStatement> {
        Identifier owner;
    
        public Identifier Owner => owner;
    
        public CreateRouteStatement(Identifier owner = null, Identifier name = null, IReadOnlyList<RouteOption> routeOptions = null) {
            this.owner = owner;
            this.name = name;
            this.routeOptions = routeOptions is null ? ImmList<RouteOption>.Empty : ImmList<RouteOption>.FromList(routeOptions);
        }
    
        public ScriptDom.CreateRouteStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateRouteStatement();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.RouteOptions.AddRange(routeOptions.Select(c => (ScriptDom.RouteOption)c.ToMutable()));
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
    
    }

}
