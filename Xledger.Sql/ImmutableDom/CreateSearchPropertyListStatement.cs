using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateSearchPropertyListStatement : TSqlStatement, IEquatable<CreateSearchPropertyListStatement> {
        Identifier name;
        MultiPartIdentifier sourceSearchPropertyList;
        Identifier owner;
    
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
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.SourceSearchPropertyList = (ScriptDom.MultiPartIdentifier)sourceSearchPropertyList.ToMutable();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
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
    
    }

}
