using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralTableHint : TableHint, IEquatable<LiteralTableHint> {
        Literal @value;
    
        public Literal Value => @value;
    
        public LiteralTableHint(Literal @value = null, ScriptDom.TableHintKind hintKind = ScriptDom.TableHintKind.None) {
            this.@value = @value;
            this.hintKind = hintKind;
        }
    
        public ScriptDom.LiteralTableHint ToMutableConcrete() {
            var ret = new ScriptDom.LiteralTableHint();
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            ret.HintKind = hintKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + hintKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LiteralTableHint);
        } 
        
        public bool Equals(LiteralTableHint other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableHintKind>.Default.Equals(other.HintKind, hintKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralTableHint left, LiteralTableHint right) {
            return EqualityComparer<LiteralTableHint>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralTableHint left, LiteralTableHint right) {
            return !(left == right);
        }
    
    }

}