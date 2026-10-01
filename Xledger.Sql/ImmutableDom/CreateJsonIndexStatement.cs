using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateJsonIndexStatement : IndexStatement, IEquatable<CreateJsonIndexStatement> {
        protected Identifier jsonColumn;
        protected IReadOnlyList<StringLiteral> forJsonPaths;
    
        public Identifier JsonColumn => jsonColumn;
        public IReadOnlyList<StringLiteral> ForJsonPaths => forJsonPaths;
    
        public CreateJsonIndexStatement(Identifier jsonColumn = null, IReadOnlyList<StringLiteral> forJsonPaths = null, Identifier name = null, SchemaObjectName onName = null, IReadOnlyList<IndexOption> indexOptions = null) {
            this.jsonColumn = jsonColumn;
            this.forJsonPaths = forJsonPaths.ToImmArray<StringLiteral>();
            this.name = name;
            this.onName = onName;
            this.indexOptions = indexOptions.ToImmArray<IndexOption>();
        }
    
        public ScriptDom.CreateJsonIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateJsonIndexStatement();
            ret.JsonColumn = (ScriptDom.Identifier)jsonColumn?.ToMutable();
            ret.ForJsonPaths.AddRange(forJsonPaths.Select(c => (ScriptDom.StringLiteral)c?.ToMutable()));
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.OnName = (ScriptDom.SchemaObjectName)onName?.ToMutable();
            ret.IndexOptions.AddRange(indexOptions.Select(c => (ScriptDom.IndexOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(jsonColumn is null)) {
                h = h * 23 + jsonColumn.GetHashCode();
            }
            h = h * 23 + forJsonPaths.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(onName is null)) {
                h = h * 23 + onName.GetHashCode();
            }
            h = h * 23 + indexOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateJsonIndexStatement);
        } 
        
        public bool Equals(CreateJsonIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.JsonColumn, jsonColumn)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<StringLiteral>>.Default.Equals(other.ForJsonPaths, forJsonPaths)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.OnName, onName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IndexOption>>.Default.Equals(other.IndexOptions, indexOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateJsonIndexStatement left, CreateJsonIndexStatement right) {
            return EqualityComparer<CreateJsonIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateJsonIndexStatement left, CreateJsonIndexStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateJsonIndexStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.jsonColumn, othr.jsonColumn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forJsonPaths, othr.forJsonPaths);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.onName, othr.onName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.indexOptions, othr.indexOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateJsonIndexStatement left, CreateJsonIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateJsonIndexStatement left, CreateJsonIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateJsonIndexStatement left, CreateJsonIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateJsonIndexStatement left, CreateJsonIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateJsonIndexStatement FromMutable(ScriptDom.CreateJsonIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateJsonIndexStatement)) { throw new NotImplementedException("Unexpected subtype of CreateJsonIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateJsonIndexStatement(
                jsonColumn: ImmutableDom.Identifier.FromMutable(fragment.JsonColumn),
                forJsonPaths: fragment.ForJsonPaths.ToImmArray(ImmutableDom.StringLiteral.FromMutable),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                onName: ImmutableDom.SchemaObjectName.FromMutable(fragment.OnName),
                indexOptions: fragment.IndexOptions.ToImmArray(ImmutableDom.IndexOption.FromMutable)
            );
        }
    
    }

}
