using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterAssemblyStatement : AssemblyStatement, IEquatable<AlterAssemblyStatement> {
        protected IReadOnlyList<Literal> dropFiles;
        protected bool isDropAll = false;
        protected IReadOnlyList<AddFileSpec> addFiles;
    
        public IReadOnlyList<Literal> DropFiles => dropFiles;
        public bool IsDropAll => isDropAll;
        public IReadOnlyList<AddFileSpec> AddFiles => addFiles;
    
        public AlterAssemblyStatement(IReadOnlyList<Literal> dropFiles = null, bool isDropAll = false, IReadOnlyList<AddFileSpec> addFiles = null, Identifier name = null, IReadOnlyList<ScalarExpression> parameters = null, IReadOnlyList<AssemblyOption> options = null) {
            this.dropFiles = dropFiles.ToImmArray<Literal>();
            this.isDropAll = isDropAll;
            this.addFiles = addFiles.ToImmArray<AddFileSpec>();
            this.name = name;
            this.parameters = parameters.ToImmArray<ScalarExpression>();
            this.options = options.ToImmArray<AssemblyOption>();
        }
    
        public ScriptDom.AlterAssemblyStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterAssemblyStatement();
            ret.DropFiles.AddRange(dropFiles.Select(c => (ScriptDom.Literal)c?.ToMutable()));
            ret.IsDropAll = isDropAll;
            ret.AddFiles.AddRange(addFiles.Select(c => (ScriptDom.AddFileSpec)c?.ToMutable()));
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Parameters.AddRange(parameters.Select(c => (ScriptDom.ScalarExpression)c?.ToMutable()));
            ret.Options.AddRange(options.Select(c => (ScriptDom.AssemblyOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + dropFiles.GetHashCode();
            h = h * 23 + isDropAll.GetHashCode();
            h = h * 23 + addFiles.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + parameters.GetHashCode();
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterAssemblyStatement);
        } 
        
        public bool Equals(AlterAssemblyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Literal>>.Default.Equals(other.DropFiles, dropFiles)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsDropAll, isDropAll)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<AddFileSpec>>.Default.Equals(other.AddFiles, addFiles)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<AssemblyOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterAssemblyStatement left, AlterAssemblyStatement right) {
            return EqualityComparer<AlterAssemblyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterAssemblyStatement left, AlterAssemblyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterAssemblyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.dropFiles, othr.dropFiles);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isDropAll, othr.isDropAll);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.addFiles, othr.addFiles);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterAssemblyStatement left, AlterAssemblyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterAssemblyStatement left, AlterAssemblyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterAssemblyStatement left, AlterAssemblyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterAssemblyStatement left, AlterAssemblyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterAssemblyStatement FromMutable(ScriptDom.AlterAssemblyStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterAssemblyStatement)) { throw new NotImplementedException("Unexpected subtype of AlterAssemblyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterAssemblyStatement(
                dropFiles: fragment.DropFiles.ToImmArray(ImmutableDom.Literal.FromMutable),
                isDropAll: fragment.IsDropAll,
                addFiles: fragment.AddFiles.ToImmArray(ImmutableDom.AddFileSpec.FromMutable),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                parameters: fragment.Parameters.ToImmArray(ImmutableDom.ScalarExpression.FromMutable),
                options: fragment.Options.ToImmArray(ImmutableDom.AssemblyOption.FromMutable)
            );
        }
    
    }

}
