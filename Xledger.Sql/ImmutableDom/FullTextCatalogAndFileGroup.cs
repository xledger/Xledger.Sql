using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FullTextCatalogAndFileGroup : TSqlFragment, IEquatable<FullTextCatalogAndFileGroup> {
        protected Identifier catalogName;
        protected Identifier fileGroupName;
        protected bool fileGroupIsFirst = false;
    
        public Identifier CatalogName => catalogName;
        public Identifier FileGroupName => fileGroupName;
        public bool FileGroupIsFirst => fileGroupIsFirst;
    
        public FullTextCatalogAndFileGroup(Identifier catalogName = null, Identifier fileGroupName = null, bool fileGroupIsFirst = false) {
            this.catalogName = catalogName;
            this.fileGroupName = fileGroupName;
            this.fileGroupIsFirst = fileGroupIsFirst;
        }
    
        public ScriptDom.FullTextCatalogAndFileGroup ToMutableConcrete() {
            var ret = new ScriptDom.FullTextCatalogAndFileGroup();
            ret.CatalogName = (ScriptDom.Identifier)catalogName?.ToMutable();
            ret.FileGroupName = (ScriptDom.Identifier)fileGroupName?.ToMutable();
            ret.FileGroupIsFirst = fileGroupIsFirst;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(catalogName is null)) {
                h = h * 23 + catalogName.GetHashCode();
            }
            if (!(fileGroupName is null)) {
                h = h * 23 + fileGroupName.GetHashCode();
            }
            h = h * 23 + fileGroupIsFirst.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FullTextCatalogAndFileGroup);
        } 
        
        public bool Equals(FullTextCatalogAndFileGroup other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.CatalogName, catalogName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.FileGroupName, fileGroupName)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.FileGroupIsFirst, fileGroupIsFirst)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FullTextCatalogAndFileGroup left, FullTextCatalogAndFileGroup right) {
            return EqualityComparer<FullTextCatalogAndFileGroup>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FullTextCatalogAndFileGroup left, FullTextCatalogAndFileGroup right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FullTextCatalogAndFileGroup)that;
            compare = Comparer.DefaultInvariant.Compare(this.catalogName, othr.catalogName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fileGroupName, othr.fileGroupName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fileGroupIsFirst, othr.fileGroupIsFirst);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (FullTextCatalogAndFileGroup left, FullTextCatalogAndFileGroup right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FullTextCatalogAndFileGroup left, FullTextCatalogAndFileGroup right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FullTextCatalogAndFileGroup left, FullTextCatalogAndFileGroup right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FullTextCatalogAndFileGroup left, FullTextCatalogAndFileGroup right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
