using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OpenQueryTableReference : TableReferenceWithAlias, IEquatable<OpenQueryTableReference> {
        protected Identifier linkedServer;
        protected StringLiteral query;
    
        public Identifier LinkedServer => linkedServer;
        public StringLiteral Query => query;
    
        public OpenQueryTableReference(Identifier linkedServer = null, StringLiteral query = null, Identifier alias = null, bool forPath = false) {
            this.linkedServer = linkedServer;
            this.query = query;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.OpenQueryTableReference ToMutableConcrete() {
            var ret = new ScriptDom.OpenQueryTableReference();
            ret.LinkedServer = (ScriptDom.Identifier)linkedServer.ToMutable();
            ret.Query = (ScriptDom.StringLiteral)query.ToMutable();
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(linkedServer is null)) {
                h = h * 23 + linkedServer.GetHashCode();
            }
            if (!(query is null)) {
                h = h * 23 + query.GetHashCode();
            }
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OpenQueryTableReference);
        } 
        
        public bool Equals(OpenQueryTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.LinkedServer, linkedServer)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Query, query)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Alias, alias)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForPath, forPath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OpenQueryTableReference left, OpenQueryTableReference right) {
            return EqualityComparer<OpenQueryTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OpenQueryTableReference left, OpenQueryTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OpenQueryTableReference)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.linkedServer, othr.linkedServer);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.query, othr.query);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static OpenQueryTableReference FromMutable(ScriptDom.OpenQueryTableReference fragment) {
            return (OpenQueryTableReference)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
