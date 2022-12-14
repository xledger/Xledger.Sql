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
            this.externalStreamOptions = ImmList<ExternalStreamOption>.FromList(externalStreamOptions);
        }
    
        public ScriptDom.CreateExternalStreamStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateExternalStreamStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Location = (ScriptDom.Literal)location?.ToMutable();
            ret.InputOptions = (ScriptDom.Literal)inputOptions?.ToMutable();
            ret.OutputOptions = (ScriptDom.Literal)outputOptions?.ToMutable();
            ret.ExternalStreamOptions.AddRange(externalStreamOptions.SelectList(c => (ScriptDom.ExternalStreamOption)c?.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateExternalStreamStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.location, othr.location);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.inputOptions, othr.inputOptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.outputOptions, othr.outputOptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.externalStreamOptions, othr.externalStreamOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateExternalStreamStatement left, CreateExternalStreamStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateExternalStreamStatement left, CreateExternalStreamStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateExternalStreamStatement left, CreateExternalStreamStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateExternalStreamStatement left, CreateExternalStreamStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateExternalStreamStatement FromMutable(ScriptDom.CreateExternalStreamStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateExternalStreamStatement)) { throw new NotImplementedException("Unexpected subtype of CreateExternalStreamStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateExternalStreamStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                location: ImmutableDom.Literal.FromMutable(fragment.Location),
                inputOptions: ImmutableDom.Literal.FromMutable(fragment.InputOptions),
                outputOptions: ImmutableDom.Literal.FromMutable(fragment.OutputOptions),
                externalStreamOptions: fragment.ExternalStreamOptions.SelectList(ImmutableDom.ExternalStreamOption.FromMutable)
            );
        }
    
    }

}
