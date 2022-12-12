using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateCryptographicProviderStatement : TSqlStatement, IEquatable<CreateCryptographicProviderStatement> {
        Identifier name;
        Literal file;
    
        public Identifier Name => name;
        public Literal File => file;
    
        public CreateCryptographicProviderStatement(Identifier name = null, Literal file = null) {
            this.name = name;
            this.file = file;
        }
    
        public ScriptDom.CreateCryptographicProviderStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateCryptographicProviderStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.File = (ScriptDom.Literal)file.ToMutable();
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
            if (!(file is null)) {
                h = h * 23 + file.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateCryptographicProviderStatement);
        } 
        
        public bool Equals(CreateCryptographicProviderStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.File, file)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateCryptographicProviderStatement left, CreateCryptographicProviderStatement right) {
            return EqualityComparer<CreateCryptographicProviderStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateCryptographicProviderStatement left, CreateCryptographicProviderStatement right) {
            return !(left == right);
        }
    
    }

}
