using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateSpatialIndexStatement : TSqlStatement, IEquatable<CreateSpatialIndexStatement> {
        protected Identifier name;
        protected SchemaObjectName @object;
        protected Identifier spatialColumnName;
        protected ScriptDom.SpatialIndexingSchemeType spatialIndexingScheme = ScriptDom.SpatialIndexingSchemeType.None;
        protected IReadOnlyList<SpatialIndexOption> spatialIndexOptions;
        protected IdentifierOrValueExpression onFileGroup;
    
        public Identifier Name => name;
        public SchemaObjectName Object => @object;
        public Identifier SpatialColumnName => spatialColumnName;
        public ScriptDom.SpatialIndexingSchemeType SpatialIndexingScheme => spatialIndexingScheme;
        public IReadOnlyList<SpatialIndexOption> SpatialIndexOptions => spatialIndexOptions;
        public IdentifierOrValueExpression OnFileGroup => onFileGroup;
    
        public CreateSpatialIndexStatement(Identifier name = null, SchemaObjectName @object = null, Identifier spatialColumnName = null, ScriptDom.SpatialIndexingSchemeType spatialIndexingScheme = ScriptDom.SpatialIndexingSchemeType.None, IReadOnlyList<SpatialIndexOption> spatialIndexOptions = null, IdentifierOrValueExpression onFileGroup = null) {
            this.name = name;
            this.@object = @object;
            this.spatialColumnName = spatialColumnName;
            this.spatialIndexingScheme = spatialIndexingScheme;
            this.spatialIndexOptions = ImmList<SpatialIndexOption>.FromList(spatialIndexOptions);
            this.onFileGroup = onFileGroup;
        }
    
        public ScriptDom.CreateSpatialIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateSpatialIndexStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Object = (ScriptDom.SchemaObjectName)@object.ToMutable();
            ret.SpatialColumnName = (ScriptDom.Identifier)spatialColumnName.ToMutable();
            ret.SpatialIndexingScheme = spatialIndexingScheme;
            ret.SpatialIndexOptions.AddRange(spatialIndexOptions.SelectList(c => (ScriptDom.SpatialIndexOption)c.ToMutable()));
            ret.OnFileGroup = (ScriptDom.IdentifierOrValueExpression)onFileGroup.ToMutable();
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
            if (!(@object is null)) {
                h = h * 23 + @object.GetHashCode();
            }
            if (!(spatialColumnName is null)) {
                h = h * 23 + spatialColumnName.GetHashCode();
            }
            h = h * 23 + spatialIndexingScheme.GetHashCode();
            h = h * 23 + spatialIndexOptions.GetHashCode();
            if (!(onFileGroup is null)) {
                h = h * 23 + onFileGroup.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateSpatialIndexStatement);
        } 
        
        public bool Equals(CreateSpatialIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Object, @object)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.SpatialColumnName, spatialColumnName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SpatialIndexingSchemeType>.Default.Equals(other.SpatialIndexingScheme, spatialIndexingScheme)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SpatialIndexOption>>.Default.Equals(other.SpatialIndexOptions, spatialIndexOptions)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.OnFileGroup, onFileGroup)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateSpatialIndexStatement left, CreateSpatialIndexStatement right) {
            return EqualityComparer<CreateSpatialIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateSpatialIndexStatement left, CreateSpatialIndexStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateSpatialIndexStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@object, othr.@object);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.spatialColumnName, othr.spatialColumnName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.spatialIndexingScheme, othr.spatialIndexingScheme);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.spatialIndexOptions, othr.spatialIndexOptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.onFileGroup, othr.onFileGroup);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateSpatialIndexStatement left, CreateSpatialIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateSpatialIndexStatement left, CreateSpatialIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateSpatialIndexStatement left, CreateSpatialIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateSpatialIndexStatement left, CreateSpatialIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
