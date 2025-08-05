using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalFileFormatContainerOption : ExternalFileFormatOption, IEquatable<ExternalFileFormatContainerOption> {
        protected IReadOnlyList<ExternalFileFormatOption> suboptions;
    
        public IReadOnlyList<ExternalFileFormatOption> Suboptions => suboptions;
    
        public ExternalFileFormatContainerOption(IReadOnlyList<ExternalFileFormatOption> suboptions = null, ScriptDom.ExternalFileFormatOptionKind optionKind = ScriptDom.ExternalFileFormatOptionKind.SerDeMethod) {
            this.suboptions = suboptions.ToImmArray<ExternalFileFormatOption>();
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExternalFileFormatContainerOption ToMutableConcrete() {
            var ret = new ScriptDom.ExternalFileFormatContainerOption();
            ret.Suboptions.AddRange(suboptions.Select(c => (ScriptDom.ExternalFileFormatOption)c?.ToMutable()));
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + suboptions.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalFileFormatContainerOption);
        } 
        
        public bool Equals(ExternalFileFormatContainerOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ExternalFileFormatOption>>.Default.Equals(other.Suboptions, suboptions)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalFileFormatOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalFileFormatContainerOption left, ExternalFileFormatContainerOption right) {
            return EqualityComparer<ExternalFileFormatContainerOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalFileFormatContainerOption left, ExternalFileFormatContainerOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExternalFileFormatContainerOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.suboptions, othr.suboptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExternalFileFormatContainerOption left, ExternalFileFormatContainerOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExternalFileFormatContainerOption left, ExternalFileFormatContainerOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExternalFileFormatContainerOption left, ExternalFileFormatContainerOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExternalFileFormatContainerOption left, ExternalFileFormatContainerOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExternalFileFormatContainerOption FromMutable(ScriptDom.ExternalFileFormatContainerOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExternalFileFormatContainerOption)) { throw new NotImplementedException("Unexpected subtype of ExternalFileFormatContainerOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalFileFormatContainerOption(
                suboptions: fragment.Suboptions.ToImmArray(ImmutableDom.ExternalFileFormatOption.FromMutable),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
