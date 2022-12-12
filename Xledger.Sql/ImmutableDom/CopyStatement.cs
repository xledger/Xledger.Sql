using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CopyStatement : TSqlStatement, IEquatable<CopyStatement> {
        protected IReadOnlyList<StringLiteral> from;
        protected SchemaObjectName into;
        protected IReadOnlyList<CopyOption> options;
        protected IReadOnlyList<OptimizerHint> optimizerHints;
    
        public IReadOnlyList<StringLiteral> From => from;
        public SchemaObjectName Into => into;
        public IReadOnlyList<CopyOption> Options => options;
        public IReadOnlyList<OptimizerHint> OptimizerHints => optimizerHints;
    
        public CopyStatement(IReadOnlyList<StringLiteral> from = null, SchemaObjectName into = null, IReadOnlyList<CopyOption> options = null, IReadOnlyList<OptimizerHint> optimizerHints = null) {
            this.from = from is null ? ImmList<StringLiteral>.Empty : ImmList<StringLiteral>.FromList(from);
            this.into = into;
            this.options = options is null ? ImmList<CopyOption>.Empty : ImmList<CopyOption>.FromList(options);
            this.optimizerHints = optimizerHints is null ? ImmList<OptimizerHint>.Empty : ImmList<OptimizerHint>.FromList(optimizerHints);
        }
    
        public ScriptDom.CopyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CopyStatement();
            ret.From.AddRange(from.SelectList(c => (ScriptDom.StringLiteral)c.ToMutable()));
            ret.Into = (ScriptDom.SchemaObjectName)into.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.CopyOption)c.ToMutable()));
            ret.OptimizerHints.AddRange(optimizerHints.SelectList(c => (ScriptDom.OptimizerHint)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + from.GetHashCode();
            if (!(into is null)) {
                h = h * 23 + into.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            h = h * 23 + optimizerHints.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CopyStatement);
        } 
        
        public bool Equals(CopyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<StringLiteral>>.Default.Equals(other.From, from)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Into, into)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<CopyOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<OptimizerHint>>.Default.Equals(other.OptimizerHints, optimizerHints)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CopyStatement left, CopyStatement right) {
            return EqualityComparer<CopyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CopyStatement left, CopyStatement right) {
            return !(left == right);
        }
    
    }

}
