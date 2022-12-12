using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalLanguageFileOption : TSqlFragment, IEquatable<ExternalLanguageFileOption> {
        ScalarExpression content;
        StringLiteral fileName;
        StringLiteral path;
        Identifier platform;
        StringLiteral parameters;
        StringLiteral environmentVariables;
    
        public ScalarExpression Content => content;
        public StringLiteral FileName => fileName;
        public StringLiteral Path => path;
        public Identifier Platform => platform;
        public StringLiteral Parameters => parameters;
        public StringLiteral EnvironmentVariables => environmentVariables;
    
        public ExternalLanguageFileOption(ScalarExpression content = null, StringLiteral fileName = null, StringLiteral path = null, Identifier platform = null, StringLiteral parameters = null, StringLiteral environmentVariables = null) {
            this.content = content;
            this.fileName = fileName;
            this.path = path;
            this.platform = platform;
            this.parameters = parameters;
            this.environmentVariables = environmentVariables;
        }
    
        public ScriptDom.ExternalLanguageFileOption ToMutableConcrete() {
            var ret = new ScriptDom.ExternalLanguageFileOption();
            ret.Content = (ScriptDom.ScalarExpression)content.ToMutable();
            ret.FileName = (ScriptDom.StringLiteral)fileName.ToMutable();
            ret.Path = (ScriptDom.StringLiteral)path.ToMutable();
            ret.Platform = (ScriptDom.Identifier)platform.ToMutable();
            ret.Parameters = (ScriptDom.StringLiteral)parameters.ToMutable();
            ret.EnvironmentVariables = (ScriptDom.StringLiteral)environmentVariables.ToMutable();
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
            if (!(fileName is null)) {
                h = h * 23 + fileName.GetHashCode();
            }
            if (!(path is null)) {
                h = h * 23 + path.GetHashCode();
            }
            if (!(platform is null)) {
                h = h * 23 + platform.GetHashCode();
            }
            if (!(parameters is null)) {
                h = h * 23 + parameters.GetHashCode();
            }
            if (!(environmentVariables is null)) {
                h = h * 23 + environmentVariables.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalLanguageFileOption);
        } 
        
        public bool Equals(ExternalLanguageFileOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Content, content)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.FileName, fileName)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Path, path)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Platform, platform)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.EnvironmentVariables, environmentVariables)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalLanguageFileOption left, ExternalLanguageFileOption right) {
            return EqualityComparer<ExternalLanguageFileOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalLanguageFileOption left, ExternalLanguageFileOption right) {
            return !(left == right);
        }
    
    }

}