using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateExternalStreamStatement : ExternalStreamStatement, IEquatable<CreateExternalStreamStatement> {
        public CreateExternalStreamStatement(Identifier name = null, Literal location = null, Literal inputOptions = null, Literal outputOptions = null, IReadOnlyList<ExternalStreamOption> externalStreamOptions = null) {
            this.name = name;
            this.location = location;
            this.inputOptions = inputOptions;
            this.outputOptions = outputOptions;
            this.externalStreamOptions = externalStreamOptions is null ? ImmList<ExternalStreamOption>.Empty : ImmList<ExternalStreamOption>.FromList(externalStreamOptions);
        }
    
        public ScriptDom.CreateExternalStreamStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateExternalStreamStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Location = (ScriptDom.Literal)location.ToMutable();
            ret.InputOptions = (ScriptDom.Literal)inputOptions.ToMutable();
            ret.OutputOptions = (ScriptDom.Literal)outputOptions.ToMutable();
            ret.ExternalStreamOptions.AddRange(externalStreamOptions.Select(c => (ScriptDom.ExternalStreamOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(location is null)) {
                h = h * 23 + location.GetHashCode();
            }
            if (!(inputOptions is null)) {
                h = h * 23 + inputOptions.GetHashCode();
            }
            if (!(outputOptions is null)) {
                h = h * 23 + outputOptions.GetHashCode();
            }
            h = h * 23 + externalStreamOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateExternalStreamStatement);
        } 
        
        public bool Equals(CreateExternalStreamStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Location, location)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.InputOptions, inputOptions)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.OutputOptions, outputOptions)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExternalStreamOption>>.Default.Equals(other.ExternalStreamOptions, externalStreamOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateExternalStreamStatement left, CreateExternalStreamStatement right) {
            return EqualityComparer<CreateExternalStreamStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateExternalStreamStatement left, CreateExternalStreamStatement right) {
            return !(left == right);
        }
    
    }

}
