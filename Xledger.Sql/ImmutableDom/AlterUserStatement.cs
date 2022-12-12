using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterUserStatement : UserStatement, IEquatable<AlterUserStatement> {
        public AlterUserStatement(Identifier name = null, IReadOnlyList<PrincipalOption> userOptions = null) {
            this.name = name;
            this.userOptions = userOptions is null ? ImmList<PrincipalOption>.Empty : ImmList<PrincipalOption>.FromList(userOptions);
        }
    
        public ScriptDom.AlterUserStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterUserStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.UserOptions.AddRange(userOptions.SelectList(c => (ScriptDom.PrincipalOption)c.ToMutable()));
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
            h = h * 23 + userOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterUserStatement);
        } 
        
        public bool Equals(AlterUserStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<PrincipalOption>>.Default.Equals(other.UserOptions, userOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterUserStatement left, AlterUserStatement right) {
            return EqualityComparer<AlterUserStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterUserStatement left, AlterUserStatement right) {
            return !(left == right);
        }
    
    }

}
