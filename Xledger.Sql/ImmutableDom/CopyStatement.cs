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
            this.from = ImmList<StringLiteral>.FromList(from);
            this.into = into;
            this.options = ImmList<CopyOption>.FromList(options);
            this.optimizerHints = ImmList<OptimizerHint>.FromList(optimizerHints);
        }
    
        public ScriptDom.CopyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CopyStatement();
            ret.From.AddRange(from.SelectList(c => (ScriptDom.StringLiteral)c?.ToMutable()));
            ret.Into = (ScriptDom.SchemaObjectName)into?.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.CopyOption)c?.ToMutable()));
            ret.OptimizerHints.AddRange(optimizerHints.SelectList(c => (ScriptDom.OptimizerHint)c?.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CopyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.from, othr.from);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.into, othr.into);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optimizerHints, othr.optimizerHints);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CopyStatement left, CopyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CopyStatement left, CopyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CopyStatement left, CopyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CopyStatement left, CopyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CopyStatement FromMutable(ScriptDom.CopyStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CopyStatement)) { throw new NotImplementedException("Unexpected subtype of CopyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CopyStatement(
                from: fragment.From.SelectList(ImmutableDom.StringLiteral.FromMutable),
                into: ImmutableDom.SchemaObjectName.FromMutable(fragment.Into),
                options: fragment.Options.SelectList(ImmutableDom.CopyOption.FromMutable),
                optimizerHints: fragment.OptimizerHints.SelectList(ImmutableDom.OptimizerHint.FromMutable)
            );
        }
    
    }

}
