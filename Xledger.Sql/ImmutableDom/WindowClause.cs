using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WindowClause : TSqlFragment, IEquatable<WindowClause> {
        IReadOnlyList<WindowDefinition> windowDefinition;
    
        public IReadOnlyList<WindowDefinition> WindowDefinition => windowDefinition;
    
        public WindowClause(IReadOnlyList<WindowDefinition> windowDefinition = null) {
            this.windowDefinition = windowDefinition is null ? ImmList<WindowDefinition>.Empty : ImmList<WindowDefinition>.FromList(windowDefinition);
        }
    
        public ScriptDom.WindowClause ToMutableConcrete() {
            var ret = new ScriptDom.WindowClause();
            ret.WindowDefinition.AddRange(windowDefinition.Select(c => (ScriptDom.WindowDefinition)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + windowDefinition.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WindowClause);
        } 
        
        public bool Equals(WindowClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<WindowDefinition>>.Default.Equals(other.WindowDefinition, windowDefinition)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WindowClause left, WindowClause right) {
            return EqualityComparer<WindowClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WindowClause left, WindowClause right) {
            return !(left == right);
        }
    
    }

}
