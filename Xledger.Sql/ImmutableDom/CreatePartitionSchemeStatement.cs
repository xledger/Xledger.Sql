using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreatePartitionSchemeStatement : TSqlStatement, IEquatable<CreatePartitionSchemeStatement> {
        protected Identifier name;
        protected Identifier partitionFunction;
        protected bool isAll = false;
        protected IReadOnlyList<IdentifierOrValueExpression> fileGroups;
    
        public Identifier Name => name;
        public Identifier PartitionFunction => partitionFunction;
        public bool IsAll => isAll;
        public IReadOnlyList<IdentifierOrValueExpression> FileGroups => fileGroups;
    
        public CreatePartitionSchemeStatement(Identifier name = null, Identifier partitionFunction = null, bool isAll = false, IReadOnlyList<IdentifierOrValueExpression> fileGroups = null) {
            this.name = name;
            this.partitionFunction = partitionFunction;
            this.isAll = isAll;
            this.fileGroups = ImmList<IdentifierOrValueExpression>.FromList(fileGroups);
        }
    
        public ScriptDom.CreatePartitionSchemeStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreatePartitionSchemeStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.PartitionFunction = (ScriptDom.Identifier)partitionFunction?.ToMutable();
            ret.IsAll = isAll;
            ret.FileGroups.AddRange(fileGroups.SelectList(c => (ScriptDom.IdentifierOrValueExpression)c?.ToMutable()));
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
            if (!(partitionFunction is null)) {
                h = h * 23 + partitionFunction.GetHashCode();
            }
            h = h * 23 + isAll.GetHashCode();
            h = h * 23 + fileGroups.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreatePartitionSchemeStatement);
        } 
        
        public bool Equals(CreatePartitionSchemeStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.PartitionFunction, partitionFunction)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsAll, isAll)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IdentifierOrValueExpression>>.Default.Equals(other.FileGroups, fileGroups)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreatePartitionSchemeStatement left, CreatePartitionSchemeStatement right) {
            return EqualityComparer<CreatePartitionSchemeStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreatePartitionSchemeStatement left, CreatePartitionSchemeStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreatePartitionSchemeStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.partitionFunction, othr.partitionFunction);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isAll, othr.isAll);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fileGroups, othr.fileGroups);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreatePartitionSchemeStatement left, CreatePartitionSchemeStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreatePartitionSchemeStatement left, CreatePartitionSchemeStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreatePartitionSchemeStatement left, CreatePartitionSchemeStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreatePartitionSchemeStatement left, CreatePartitionSchemeStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreatePartitionSchemeStatement FromMutable(ScriptDom.CreatePartitionSchemeStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreatePartitionSchemeStatement)) { throw new NotImplementedException("Unexpected subtype of CreatePartitionSchemeStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreatePartitionSchemeStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                partitionFunction: ImmutableDom.Identifier.FromMutable(fragment.PartitionFunction),
                isAll: fragment.IsAll,
                fileGroups: fragment.FileGroups.SelectList(ImmutableDom.IdentifierOrValueExpression.FromMutable)
            );
        }
    
    }

}
