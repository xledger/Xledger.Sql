using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateAssemblyStatement : AssemblyStatement, IEquatable<CreateAssemblyStatement> {
        protected Identifier owner;
    
        public Identifier Owner => owner;
    
        public CreateAssemblyStatement(Identifier owner = null, Identifier name = null, IReadOnlyList<ScalarExpression> parameters = null, IReadOnlyList<AssemblyOption> options = null) {
            this.owner = owner;
            this.name = name;
            this.parameters = ImmList<ScalarExpression>.FromList(parameters);
            this.options = ImmList<AssemblyOption>.FromList(options);
        }
    
        public ScriptDom.CreateAssemblyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateAssemblyStatement();
            ret.Owner = (ScriptDom.Identifier)owner?.ToMutable();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ScalarExpression)c?.ToMutable()));
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AssemblyOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + parameters.GetHashCode();
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateAssemblyStatement);
        } 
        
        public bool Equals(CreateAssemblyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
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
        
        public static bool operator ==(CreateAssemblyStatement left, CreateAssemblyStatement right) {
            return EqualityComparer<CreateAssemblyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateAssemblyStatement left, CreateAssemblyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateAssemblyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateAssemblyStatement left, CreateAssemblyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateAssemblyStatement left, CreateAssemblyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateAssemblyStatement left, CreateAssemblyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateAssemblyStatement left, CreateAssemblyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
