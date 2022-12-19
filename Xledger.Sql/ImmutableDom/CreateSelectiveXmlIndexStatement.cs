using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateSelectiveXmlIndexStatement : IndexStatement, IEquatable<CreateSelectiveXmlIndexStatement> {
        protected bool isSecondary = false;
        protected Identifier xmlColumn;
        protected IReadOnlyList<SelectiveXmlIndexPromotedPath> promotedPaths;
        protected XmlNamespaces xmlNamespaces;
        protected Identifier usingXmlIndexName;
        protected Identifier pathName;
    
        public bool IsSecondary => isSecondary;
        public Identifier XmlColumn => xmlColumn;
        public IReadOnlyList<SelectiveXmlIndexPromotedPath> PromotedPaths => promotedPaths;
        public XmlNamespaces XmlNamespaces => xmlNamespaces;
        public Identifier UsingXmlIndexName => usingXmlIndexName;
        public Identifier PathName => pathName;
    
        public CreateSelectiveXmlIndexStatement(bool isSecondary = false, Identifier xmlColumn = null, IReadOnlyList<SelectiveXmlIndexPromotedPath> promotedPaths = null, XmlNamespaces xmlNamespaces = null, Identifier usingXmlIndexName = null, Identifier pathName = null, Identifier name = null, SchemaObjectName onName = null, IReadOnlyList<IndexOption> indexOptions = null) {
            this.isSecondary = isSecondary;
            this.xmlColumn = xmlColumn;
            this.promotedPaths = ImmList<SelectiveXmlIndexPromotedPath>.FromList(promotedPaths);
            this.xmlNamespaces = xmlNamespaces;
            this.usingXmlIndexName = usingXmlIndexName;
            this.pathName = pathName;
            this.name = name;
            this.onName = onName;
            this.indexOptions = ImmList<IndexOption>.FromList(indexOptions);
        }
    
        public ScriptDom.CreateSelectiveXmlIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateSelectiveXmlIndexStatement();
            ret.IsSecondary = isSecondary;
            ret.XmlColumn = (ScriptDom.Identifier)xmlColumn?.ToMutable();
            ret.PromotedPaths.AddRange(promotedPaths.SelectList(c => (ScriptDom.SelectiveXmlIndexPromotedPath)c?.ToMutable()));
            ret.XmlNamespaces = (ScriptDom.XmlNamespaces)xmlNamespaces?.ToMutable();
            ret.UsingXmlIndexName = (ScriptDom.Identifier)usingXmlIndexName?.ToMutable();
            ret.PathName = (ScriptDom.Identifier)pathName?.ToMutable();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.OnName = (ScriptDom.SchemaObjectName)onName?.ToMutable();
            ret.IndexOptions.AddRange(indexOptions.SelectList(c => (ScriptDom.IndexOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isSecondary.GetHashCode();
            if (!(xmlColumn is null)) {
                h = h * 23 + xmlColumn.GetHashCode();
            }
            h = h * 23 + promotedPaths.GetHashCode();
            if (!(xmlNamespaces is null)) {
                h = h * 23 + xmlNamespaces.GetHashCode();
            }
            if (!(usingXmlIndexName is null)) {
                h = h * 23 + usingXmlIndexName.GetHashCode();
            }
            if (!(pathName is null)) {
                h = h * 23 + pathName.GetHashCode();
            }
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
            return Equals(obj as CreateSelectiveXmlIndexStatement);
        } 
        
        public bool Equals(CreateSelectiveXmlIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsSecondary, isSecondary)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.XmlColumn, xmlColumn)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SelectiveXmlIndexPromotedPath>>.Default.Equals(other.PromotedPaths, promotedPaths)) {
                return false;
            }
            if (!EqualityComparer<XmlNamespaces>.Default.Equals(other.XmlNamespaces, xmlNamespaces)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.UsingXmlIndexName, usingXmlIndexName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.PathName, pathName)) {
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
        
        public static bool operator ==(CreateSelectiveXmlIndexStatement left, CreateSelectiveXmlIndexStatement right) {
            return EqualityComparer<CreateSelectiveXmlIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateSelectiveXmlIndexStatement left, CreateSelectiveXmlIndexStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateSelectiveXmlIndexStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.isSecondary, othr.isSecondary);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.xmlColumn, othr.xmlColumn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.promotedPaths, othr.promotedPaths);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.xmlNamespaces, othr.xmlNamespaces);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.usingXmlIndexName, othr.usingXmlIndexName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.pathName, othr.pathName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.onName, othr.onName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.indexOptions, othr.indexOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateSelectiveXmlIndexStatement left, CreateSelectiveXmlIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateSelectiveXmlIndexStatement left, CreateSelectiveXmlIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateSelectiveXmlIndexStatement left, CreateSelectiveXmlIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateSelectiveXmlIndexStatement left, CreateSelectiveXmlIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateSelectiveXmlIndexStatement FromMutable(ScriptDom.CreateSelectiveXmlIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateSelectiveXmlIndexStatement)) { throw new NotImplementedException("Unexpected subtype of CreateSelectiveXmlIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSelectiveXmlIndexStatement(
                isSecondary: fragment.IsSecondary,
                xmlColumn: ImmutableDom.Identifier.FromMutable(fragment.XmlColumn),
                promotedPaths: fragment.PromotedPaths.SelectList(ImmutableDom.SelectiveXmlIndexPromotedPath.FromMutable),
                xmlNamespaces: ImmutableDom.XmlNamespaces.FromMutable(fragment.XmlNamespaces),
                usingXmlIndexName: ImmutableDom.Identifier.FromMutable(fragment.UsingXmlIndexName),
                pathName: ImmutableDom.Identifier.FromMutable(fragment.PathName),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                onName: ImmutableDom.SchemaObjectName.FromMutable(fragment.OnName),
                indexOptions: fragment.IndexOptions.SelectList(ImmutableDom.IndexOption.FromMutable)
            );
        }
    
    }

}
