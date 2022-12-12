using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterCryptographicProviderStatement : TSqlStatement, IEquatable<AlterCryptographicProviderStatement> {
        Identifier name;
        ScriptDom.EnableDisableOptionType option = ScriptDom.EnableDisableOptionType.None;
        Literal file;
    
        public Identifier Name => name;
        public ScriptDom.EnableDisableOptionType Option => option;
        public Literal File => file;
    
        public AlterCryptographicProviderStatement(Identifier name = null, ScriptDom.EnableDisableOptionType option = ScriptDom.EnableDisableOptionType.None, Literal file = null) {
            this.name = name;
            this.option = option;
            this.file = file;
        }
    
        public ScriptDom.AlterCryptographicProviderStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterCryptographicProviderStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Option = option;
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
            h = h * 23 + option.GetHashCode();
            if (!(file is null)) {
                h = h * 23 + file.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterCryptographicProviderStatement);
        } 
        
        public bool Equals(AlterCryptographicProviderStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.EnableDisableOptionType>.Default.Equals(other.Option, option)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.File, file)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterCryptographicProviderStatement left, AlterCryptographicProviderStatement right) {
            return EqualityComparer<AlterCryptographicProviderStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterCryptographicProviderStatement left, AlterCryptographicProviderStatement right) {
            return !(left == right);
        }
    
    }

}