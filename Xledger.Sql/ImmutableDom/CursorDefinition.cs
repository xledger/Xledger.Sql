using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CursorDefinition : TSqlFragment, IEquatable<CursorDefinition> {
        protected IReadOnlyList<CursorOption> options;
        protected SelectStatement select;
    
        public IReadOnlyList<CursorOption> Options => options;
        public SelectStatement Select => select;
    
        public CursorDefinition(IReadOnlyList<CursorOption> options = null, SelectStatement select = null) {
            this.options = options is null ? ImmList<CursorOption>.Empty : ImmList<CursorOption>.FromList(options);
            this.select = select;
        }
    
        public ScriptDom.CursorDefinition ToMutableConcrete() {
            var ret = new ScriptDom.CursorDefinition();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.CursorOption)c.ToMutable()));
            ret.Select = (ScriptDom.SelectStatement)select.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            if (!(select is null)) {
                h = h * 23 + select.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CursorDefinition);
        } 
        
        public bool Equals(CursorDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<CursorOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<SelectStatement>.Default.Equals(other.Select, select)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CursorDefinition left, CursorDefinition right) {
            return EqualityComparer<CursorDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CursorDefinition left, CursorDefinition right) {
            return !(left == right);
        }
    
    }

}
