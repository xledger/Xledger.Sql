using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
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
            this.dropFiles = ImmList<Literal>.FromList(dropFiles);
            this.isDropAll = isDropAll;
            this.addFiles = ImmList<AddFileSpec>.FromList(addFiles);
            this.name = name;
            this.parameters = ImmList<ScalarExpression>.FromList(parameters);
            this.options = ImmList<AssemblyOption>.FromList(options);
        }
    
        public ScriptDom.AlterAssemblyStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterAssemblyStatement();
            ret.DropFiles.AddRange(dropFiles.SelectList(c => (ScriptDom.Literal)c.ToMutable()));
            ret.IsDropAll = isDropAll;
            ret.AddFiles.AddRange(addFiles.SelectList(c => (ScriptDom.AddFileSpec)c.ToMutable()));
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AssemblyOption)c.ToMutable()));
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
            compare = StructuralComparisons.StructuralComparer.Compare(this.dropFiles, othr.dropFiles);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.isDropAll, othr.isDropAll);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.addFiles, othr.addFiles);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AlterAssemblyStatement FromMutable(ScriptDom.AlterAssemblyStatement fragment) {
            return (AlterAssemblyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
