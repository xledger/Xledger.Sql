using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalFileFormatContainerOption : ExternalFileFormatOption, IEquatable<ExternalFileFormatContainerOption> {
        protected IReadOnlyList<ExternalFileFormatOption> suboptions;
    
        public IReadOnlyList<ExternalFileFormatOption> Suboptions => suboptions;
    
        public ExternalFileFormatContainerOption(IReadOnlyList<ExternalFileFormatOption> suboptions = null, ScriptDom.ExternalFileFormatOptionKind optionKind = ScriptDom.ExternalFileFormatOptionKind.SerDeMethod) {
            this.suboptions = suboptions is null ? ImmList<ExternalFileFormatOption>.Empty : ImmList<ExternalFileFormatOption>.FromList(suboptions);
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExternalFileFormatContainerOption ToMutableConcrete() {
            var ret = new ScriptDom.ExternalFileFormatContainerOption();
            ret.Suboptions.AddRange(suboptions.SelectList(c => (ScriptDom.ExternalFileFormatOption)c.ToMutable()));
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
    
    }

}
