using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateLoginStatement : TSqlStatement, IEquatable<CreateLoginStatement> {
        protected Identifier name;
        protected CreateLoginSource source;
    
        public Identifier Name => name;
        public CreateLoginSource Source => source;
    
        public CreateLoginStatement(Identifier name = null, CreateLoginSource source = null) {
            this.name = name;
            this.source = source;
        }
    
        public ScriptDom.CreateLoginStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateLoginStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Source = (ScriptDom.CreateLoginSource)source.ToMutable();
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
            if (!(source is null)) {
                h = h * 23 + source.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateLoginStatement);
        } 
        
        public bool Equals(CreateLoginStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<CreateLoginSource>.Default.Equals(other.Source, source)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateLoginStatement left, CreateLoginStatement right) {
            return EqualityComparer<CreateLoginStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateLoginStatement left, CreateLoginStatement right) {
            return !(left == right);
        }
    
        public static CreateLoginStatement FromMutable(ScriptDom.CreateLoginStatement fragment) {
            return (CreateLoginStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
