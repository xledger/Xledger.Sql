using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropIndexClause : DropIndexClauseBase, IEquatable<DropIndexClause> {
        protected Identifier index;
        protected SchemaObjectName @object;
        protected IReadOnlyList<IndexOption> options;
    
        public Identifier Index => index;
        public SchemaObjectName Object => @object;
        public IReadOnlyList<IndexOption> Options => options;
    
        public DropIndexClause(Identifier index = null, SchemaObjectName @object = null, IReadOnlyList<IndexOption> options = null) {
            this.index = index;
            this.@object = @object;
            this.options = ImmList<IndexOption>.FromList(options);
        }
    
        public ScriptDom.DropIndexClause ToMutableConcrete() {
            var ret = new ScriptDom.DropIndexClause();
            ret.Index = (ScriptDom.Identifier)index?.ToMutable();
            ret.Object = (ScriptDom.SchemaObjectName)@object?.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.IndexOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(index is null)) {
                h = h * 23 + index.GetHashCode();
            }
            if (!(@object is null)) {
                h = h * 23 + @object.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropIndexClause);
        } 
        
        public bool Equals(DropIndexClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Index, index)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Object, @object)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IndexOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropIndexClause left, DropIndexClause right) {
            return EqualityComparer<DropIndexClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropIndexClause left, DropIndexClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropIndexClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.index, othr.index);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@object, othr.@object);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropIndexClause left, DropIndexClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropIndexClause left, DropIndexClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropIndexClause left, DropIndexClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropIndexClause left, DropIndexClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropIndexClause FromMutable(ScriptDom.DropIndexClause fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropIndexClause)) { throw new NotImplementedException("Unexpected subtype of DropIndexClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropIndexClause(
                index: ImmutableDom.Identifier.FromMutable(fragment.Index),
                @object: ImmutableDom.SchemaObjectName.FromMutable(fragment.Object),
                options: fragment.Options.SelectList(ImmutableDom.IndexOption.FromMutable)
            );
        }
    
    }

}
