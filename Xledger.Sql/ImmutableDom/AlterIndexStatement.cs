using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterIndexStatement : IndexStatement, IEquatable<AlterIndexStatement> {
        bool all = false;
        ScriptDom.AlterIndexType alterIndexType = ScriptDom.AlterIndexType.Rebuild;
        PartitionSpecifier partition;
        IReadOnlyList<SelectiveXmlIndexPromotedPath> promotedPaths;
        XmlNamespaces xmlNamespaces;
    
        public bool All => all;
        public ScriptDom.AlterIndexType AlterIndexType => alterIndexType;
        public PartitionSpecifier Partition => partition;
        public IReadOnlyList<SelectiveXmlIndexPromotedPath> PromotedPaths => promotedPaths;
        public XmlNamespaces XmlNamespaces => xmlNamespaces;
    
        public AlterIndexStatement(bool all = false, ScriptDom.AlterIndexType alterIndexType = ScriptDom.AlterIndexType.Rebuild, PartitionSpecifier partition = null, IReadOnlyList<SelectiveXmlIndexPromotedPath> promotedPaths = null, XmlNamespaces xmlNamespaces = null, Identifier name = null, SchemaObjectName onName = null, IReadOnlyList<IndexOption> indexOptions = null) {
            this.all = all;
            this.alterIndexType = alterIndexType;
            this.partition = partition;
            this.promotedPaths = promotedPaths is null ? ImmList<SelectiveXmlIndexPromotedPath>.Empty : ImmList<SelectiveXmlIndexPromotedPath>.FromList(promotedPaths);
            this.xmlNamespaces = xmlNamespaces;
            this.name = name;
            this.onName = onName;
            this.indexOptions = indexOptions is null ? ImmList<IndexOption>.Empty : ImmList<IndexOption>.FromList(indexOptions);
        }
    
        public ScriptDom.AlterIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterIndexStatement();
            ret.All = all;
            ret.AlterIndexType = alterIndexType;
            ret.Partition = (ScriptDom.PartitionSpecifier)partition.ToMutable();
            ret.PromotedPaths.AddRange(promotedPaths.Select(c => (ScriptDom.SelectiveXmlIndexPromotedPath)c.ToMutable()));
            ret.XmlNamespaces = (ScriptDom.XmlNamespaces)xmlNamespaces.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.OnName = (ScriptDom.SchemaObjectName)onName.ToMutable();
            ret.IndexOptions.AddRange(indexOptions.Select(c => (ScriptDom.IndexOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + all.GetHashCode();
            h = h * 23 + alterIndexType.GetHashCode();
            if (!(partition is null)) {
                h = h * 23 + partition.GetHashCode();
            }
            h = h * 23 + promotedPaths.GetHashCode();
            if (!(xmlNamespaces is null)) {
                h = h * 23 + xmlNamespaces.GetHashCode();
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
            return Equals(obj as AlterIndexStatement);
        } 
        
        public bool Equals(AlterIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.All, all)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AlterIndexType>.Default.Equals(other.AlterIndexType, alterIndexType)) {
                return false;
            }
            if (!EqualityComparer<PartitionSpecifier>.Default.Equals(other.Partition, partition)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SelectiveXmlIndexPromotedPath>>.Default.Equals(other.PromotedPaths, promotedPaths)) {
                return false;
            }
            if (!EqualityComparer<XmlNamespaces>.Default.Equals(other.XmlNamespaces, xmlNamespaces)) {
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
        
        public static bool operator ==(AlterIndexStatement left, AlterIndexStatement right) {
            return EqualityComparer<AlterIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterIndexStatement left, AlterIndexStatement right) {
            return !(left == right);
        }
    
    }

}
