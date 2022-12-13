using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetCommandStatement : TSqlStatement, IEquatable<SetCommandStatement> {
        protected IReadOnlyList<SetCommand> commands;
    
        public IReadOnlyList<SetCommand> Commands => commands;
    
        public SetCommandStatement(IReadOnlyList<SetCommand> commands = null) {
            this.commands = commands is null ? ImmList<SetCommand>.Empty : ImmList<SetCommand>.FromList(commands);
        }
    
        public ScriptDom.SetCommandStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetCommandStatement();
            ret.Commands.AddRange(commands.SelectList(c => (ScriptDom.SetCommand)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + commands.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetCommandStatement);
        } 
        
        public bool Equals(SetCommandStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<SetCommand>>.Default.Equals(other.Commands, commands)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetCommandStatement left, SetCommandStatement right) {
            return EqualityComparer<SetCommandStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetCommandStatement left, SetCommandStatement right) {
            return !(left == right);
        }
    
        public static SetCommandStatement FromMutable(ScriptDom.SetCommandStatement fragment) {
            return (SetCommandStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
