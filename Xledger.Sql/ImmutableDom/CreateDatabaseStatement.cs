using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateDatabaseStatement : TSqlStatement, IEquatable<CreateDatabaseStatement> {
        protected Identifier databaseName;
        protected ContainmentDatabaseOption containment;
        protected IReadOnlyList<FileGroupDefinition> fileGroups;
        protected IReadOnlyList<FileDeclaration> logOn;
        protected IReadOnlyList<DatabaseOption> options;
        protected ScriptDom.AttachMode attachMode = ScriptDom.AttachMode.None;
        protected Identifier databaseSnapshot;
        protected MultiPartIdentifier copyOf;
        protected Identifier collation;
    
        public Identifier DatabaseName => databaseName;
        public ContainmentDatabaseOption Containment => containment;
        public IReadOnlyList<FileGroupDefinition> FileGroups => fileGroups;
        public IReadOnlyList<FileDeclaration> LogOn => logOn;
        public IReadOnlyList<DatabaseOption> Options => options;
        public ScriptDom.AttachMode AttachMode => attachMode;
        public Identifier DatabaseSnapshot => databaseSnapshot;
        public MultiPartIdentifier CopyOf => copyOf;
        public Identifier Collation => collation;
    
        public CreateDatabaseStatement(Identifier databaseName = null, ContainmentDatabaseOption containment = null, IReadOnlyList<FileGroupDefinition> fileGroups = null, IReadOnlyList<FileDeclaration> logOn = null, IReadOnlyList<DatabaseOption> options = null, ScriptDom.AttachMode attachMode = ScriptDom.AttachMode.None, Identifier databaseSnapshot = null, MultiPartIdentifier copyOf = null, Identifier collation = null) {
            this.databaseName = databaseName;
            this.containment = containment;
            this.fileGroups = fileGroups.ToImmArray<FileGroupDefinition>();
            this.logOn = logOn.ToImmArray<FileDeclaration>();
            this.options = options.ToImmArray<DatabaseOption>();
            this.attachMode = attachMode;
            this.databaseSnapshot = databaseSnapshot;
            this.copyOf = copyOf;
            this.collation = collation;
        }
    
        public ScriptDom.CreateDatabaseStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateDatabaseStatement();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName?.ToMutable();
            ret.Containment = (ScriptDom.ContainmentDatabaseOption)containment?.ToMutable();
            ret.FileGroups.AddRange(fileGroups.Select(c => (ScriptDom.FileGroupDefinition)c?.ToMutable()));
            ret.LogOn.AddRange(logOn.Select(c => (ScriptDom.FileDeclaration)c?.ToMutable()));
            ret.Options.AddRange(options.Select(c => (ScriptDom.DatabaseOption)c?.ToMutable()));
            ret.AttachMode = attachMode;
            ret.DatabaseSnapshot = (ScriptDom.Identifier)databaseSnapshot?.ToMutable();
            ret.CopyOf = (ScriptDom.MultiPartIdentifier)copyOf?.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            if (!(containment is null)) {
                h = h * 23 + containment.GetHashCode();
            }
            h = h * 23 + fileGroups.GetHashCode();
            h = h * 23 + logOn.GetHashCode();
            h = h * 23 + options.GetHashCode();
            h = h * 23 + attachMode.GetHashCode();
            if (!(databaseSnapshot is null)) {
                h = h * 23 + databaseSnapshot.GetHashCode();
            }
            if (!(copyOf is null)) {
                h = h * 23 + copyOf.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateDatabaseStatement);
        } 
        
        public bool Equals(CreateDatabaseStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DatabaseName, databaseName)) {
                return false;
            }
            if (!EqualityComparer<ContainmentDatabaseOption>.Default.Equals(other.Containment, containment)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<FileGroupDefinition>>.Default.Equals(other.FileGroups, fileGroups)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<FileDeclaration>>.Default.Equals(other.LogOn, logOn)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<DatabaseOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AttachMode>.Default.Equals(other.AttachMode, attachMode)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DatabaseSnapshot, databaseSnapshot)) {
                return false;
            }
            if (!EqualityComparer<MultiPartIdentifier>.Default.Equals(other.CopyOf, copyOf)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateDatabaseStatement left, CreateDatabaseStatement right) {
            return EqualityComparer<CreateDatabaseStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateDatabaseStatement left, CreateDatabaseStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateDatabaseStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.databaseName, othr.databaseName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.containment, othr.containment);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fileGroups, othr.fileGroups);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.logOn, othr.logOn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.attachMode, othr.attachMode);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.databaseSnapshot, othr.databaseSnapshot);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.copyOf, othr.copyOf);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateDatabaseStatement left, CreateDatabaseStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateDatabaseStatement left, CreateDatabaseStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateDatabaseStatement left, CreateDatabaseStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateDatabaseStatement left, CreateDatabaseStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateDatabaseStatement FromMutable(ScriptDom.CreateDatabaseStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateDatabaseStatement)) { throw new NotImplementedException("Unexpected subtype of CreateDatabaseStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateDatabaseStatement(
                databaseName: ImmutableDom.Identifier.FromMutable(fragment.DatabaseName),
                containment: ImmutableDom.ContainmentDatabaseOption.FromMutable(fragment.Containment),
                fileGroups: fragment.FileGroups.ToImmArray(ImmutableDom.FileGroupDefinition.FromMutable),
                logOn: fragment.LogOn.ToImmArray(ImmutableDom.FileDeclaration.FromMutable),
                options: fragment.Options.ToImmArray(ImmutableDom.DatabaseOption.FromMutable),
                attachMode: fragment.AttachMode,
                databaseSnapshot: ImmutableDom.Identifier.FromMutable(fragment.DatabaseSnapshot),
                copyOf: ImmutableDom.MultiPartIdentifier.FromMutable(fragment.CopyOf),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
