using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalLibraryFileOption : TSqlFragment, IEquatable<ExternalLibraryFileOption> {
        protected ScalarExpression content;
        protected StringLiteral path;
        protected Identifier platform;
    
        public ScalarExpression Content => content;
        public StringLiteral Path => path;
        public Identifier Platform => platform;
    
        public ExternalLibraryFileOption(ScalarExpression content = null, StringLiteral path = null, Identifier platform = null) {
            this.content = content;
            this.path = path;
            this.platform = platform;
        }
    
        public ScriptDom.ExternalLibraryFileOption ToMutableConcrete() {
            var ret = new ScriptDom.ExternalLibraryFileOption();
            ret.Content = (ScriptDom.ScalarExpression)content?.ToMutable();
            ret.Path = (ScriptDom.StringLiteral)path?.ToMutable();
            ret.Platform = (ScriptDom.Identifier)platform?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(content is null)) {
                h = h * 23 + content.GetHashCode();
            }
            if (!(path is null)) {
                h = h * 23 + path.GetHashCode();
            }
            if (!(platform is null)) {
                h = h * 23 + platform.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalLibraryFileOption);
        } 
        
        public bool Equals(ExternalLibraryFileOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Content, content)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Path, path)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Platform, platform)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalLibraryFileOption left, ExternalLibraryFileOption right) {
            return EqualityComparer<ExternalLibraryFileOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalLibraryFileOption left, ExternalLibraryFileOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExternalLibraryFileOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.content, othr.content);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.path, othr.path);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.platform, othr.platform);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExternalLibraryFileOption left, ExternalLibraryFileOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExternalLibraryFileOption left, ExternalLibraryFileOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExternalLibraryFileOption left, ExternalLibraryFileOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExternalLibraryFileOption left, ExternalLibraryFileOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExternalLibraryFileOption FromMutable(ScriptDom.ExternalLibraryFileOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExternalLibraryFileOption)) { throw new NotImplementedException("Unexpected subtype of ExternalLibraryFileOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalLibraryFileOption(
                content: ImmutableDom.ScalarExpression.FromMutable(fragment.Content),
                path: ImmutableDom.StringLiteral.FromMutable(fragment.Path),
                platform: ImmutableDom.Identifier.FromMutable(fragment.Platform)
            );
        }
    
    }

}
