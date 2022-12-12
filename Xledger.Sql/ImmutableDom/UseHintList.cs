using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UseHintList : OptimizerHint, IEquatable<UseHintList> {
        IReadOnlyList<StringLiteral> hints;
    
        public IReadOnlyList<StringLiteral> Hints => hints;
    
        public UseHintList(IReadOnlyList<StringLiteral> hints = null, ScriptDom.OptimizerHintKind hintKind = ScriptDom.OptimizerHintKind.Unspecified) {
            this.hints = hints is null ? ImmList<StringLiteral>.Empty : ImmList<StringLiteral>.FromList(hints);
            this.hintKind = hintKind;
        }
    
        public ScriptDom.UseHintList ToMutableConcrete() {
            var ret = new ScriptDom.UseHintList();
            ret.Hints.AddRange(hints.Select(c => (ScriptDom.StringLiteral)c.ToMutable()));
            ret.HintKind = hintKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + hints.GetHashCode();
            h = h * 23 + hintKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UseHintList);
        } 
        
        public bool Equals(UseHintList other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<StringLiteral>>.Default.Equals(other.Hints, hints)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptimizerHintKind>.Default.Equals(other.HintKind, hintKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UseHintList left, UseHintList right) {
            return EqualityComparer<UseHintList>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UseHintList left, UseHintList right) {
            return !(left == right);
        }
    
    }

}
