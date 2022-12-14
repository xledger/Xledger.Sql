using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OpenRowsetCosmosOption : TSqlFragment, IEquatable<OpenRowsetCosmosOption> {
        protected ScriptDom.OpenRowsetCosmosOptionKind optionKind = ScriptDom.OpenRowsetCosmosOptionKind.Provider;
    
        public ScriptDom.OpenRowsetCosmosOptionKind OptionKind => optionKind;
    
        public OpenRowsetCosmosOption(ScriptDom.OpenRowsetCosmosOptionKind optionKind = ScriptDom.OpenRowsetCosmosOptionKind.Provider) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OpenRowsetCosmosOption ToMutableConcrete() {
            var ret = new ScriptDom.OpenRowsetCosmosOption();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OpenRowsetCosmosOption);
        } 
        
        public bool Equals(OpenRowsetCosmosOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OpenRowsetCosmosOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OpenRowsetCosmosOption left, OpenRowsetCosmosOption right) {
            return EqualityComparer<OpenRowsetCosmosOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OpenRowsetCosmosOption left, OpenRowsetCosmosOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OpenRowsetCosmosOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static OpenRowsetCosmosOption FromMutable(ScriptDom.OpenRowsetCosmosOption fragment) {
            return (OpenRowsetCosmosOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
