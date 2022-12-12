using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterLoginOptionsStatement : AlterLoginStatement, IEquatable<AlterLoginOptionsStatement> {
        IReadOnlyList<PrincipalOption> options;
    
        public IReadOnlyList<PrincipalOption> Options => options;
    
        public AlterLoginOptionsStatement(IReadOnlyList<PrincipalOption> options = null, Identifier name = null) {
            this.options = options is null ? ImmList<PrincipalOption>.Empty : ImmList<PrincipalOption>.FromList(options);
            this.name = name;
        }
    
        public ScriptDom.AlterLoginOptionsStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterLoginOptionsStatement();
            ret.Options.AddRange(options.Select(c => (ScriptDom.PrincipalOption)c.ToMutable()));
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterLoginOptionsStatement);
        } 
        
        public bool Equals(AlterLoginOptionsStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<PrincipalOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterLoginOptionsStatement left, AlterLoginOptionsStatement right) {
            return EqualityComparer<AlterLoginOptionsStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterLoginOptionsStatement left, AlterLoginOptionsStatement right) {
            return !(left == right);
        }
    
    }

}
