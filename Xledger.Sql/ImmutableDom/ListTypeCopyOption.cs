using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ListTypeCopyOption : CopyStatementOptionBase, IEquatable<ListTypeCopyOption> {
        IReadOnlyList<CopyStatementOptionBase> options;
    
        public IReadOnlyList<CopyStatementOptionBase> Options => options;
    
        public ListTypeCopyOption(IReadOnlyList<CopyStatementOptionBase> options = null) {
            this.options = options is null ? ImmList<CopyStatementOptionBase>.Empty : ImmList<CopyStatementOptionBase>.FromList(options);
        }
    
        public ScriptDom.ListTypeCopyOption ToMutableConcrete() {
            var ret = new ScriptDom.ListTypeCopyOption();
            ret.Options.AddRange(options.Select(c => (ScriptDom.CopyStatementOptionBase)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ListTypeCopyOption);
        } 
        
        public bool Equals(ListTypeCopyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<CopyStatementOptionBase>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ListTypeCopyOption left, ListTypeCopyOption right) {
            return EqualityComparer<ListTypeCopyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ListTypeCopyOption left, ListTypeCopyOption right) {
            return !(left == right);
        }
    
    }

}
