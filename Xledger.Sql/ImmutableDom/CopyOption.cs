using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CopyOption : TSqlFragment, IEquatable<CopyOption> {
        protected ScriptDom.CopyOptionKind kind = 0;
        protected CopyStatementOptionBase @value;
    
        public ScriptDom.CopyOptionKind Kind => kind;
        public CopyStatementOptionBase Value => @value;
    
        public CopyOption(ScriptDom.CopyOptionKind kind = 0, CopyStatementOptionBase @value = null) {
            this.kind = kind;
            this.@value = @value;
        }
    
        public ScriptDom.CopyOption ToMutableConcrete() {
            var ret = new ScriptDom.CopyOption();
            ret.Kind = kind;
            ret.Value = (ScriptDom.CopyStatementOptionBase)@value.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + kind.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CopyOption);
        } 
        
        public bool Equals(CopyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.CopyOptionKind>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            if (!EqualityComparer<CopyStatementOptionBase>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CopyOption left, CopyOption right) {
            return EqualityComparer<CopyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CopyOption left, CopyOption right) {
            return !(left == right);
        }
    
        public static CopyOption FromMutable(ScriptDom.CopyOption fragment) {
            return (CopyOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
