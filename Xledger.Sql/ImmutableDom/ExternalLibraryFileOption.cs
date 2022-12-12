using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalLibraryFileOption : TSqlFragment, IEquatable<ExternalLibraryFileOption> {
        ScalarExpression content;
        StringLiteral path;
        Identifier platform;
    
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
            ret.Content = (ScriptDom.ScalarExpression)content.ToMutable();
            ret.Path = (ScriptDom.StringLiteral)path.ToMutable();
            ret.Platform = (ScriptDom.Identifier)platform.ToMutable();
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
    
    }

}
