using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateFullTextStopListStatement : TSqlStatement, IEquatable<CreateFullTextStopListStatement> {
        protected Identifier name;
        protected bool isSystemStopList = false;
        protected Identifier databaseName;
        protected Identifier sourceStopListName;
        protected Identifier owner;
    
        public Identifier Name => name;
        public bool IsSystemStopList => isSystemStopList;
        public Identifier DatabaseName => databaseName;
        public Identifier SourceStopListName => sourceStopListName;
        public Identifier Owner => owner;
    
        public CreateFullTextStopListStatement(Identifier name = null, bool isSystemStopList = false, Identifier databaseName = null, Identifier sourceStopListName = null, Identifier owner = null) {
            this.name = name;
            this.isSystemStopList = isSystemStopList;
            this.databaseName = databaseName;
            this.sourceStopListName = sourceStopListName;
            this.owner = owner;
        }
    
        public ScriptDom.CreateFullTextStopListStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateFullTextStopListStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.IsSystemStopList = isSystemStopList;
            ret.DatabaseName = (ScriptDom.Identifier)databaseName.ToMutable();
            ret.SourceStopListName = (ScriptDom.Identifier)sourceStopListName.ToMutable();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
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
            h = h * 23 + isSystemStopList.GetHashCode();
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            if (!(sourceStopListName is null)) {
                h = h * 23 + sourceStopListName.GetHashCode();
            }
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateFullTextStopListStatement);
        } 
        
        public bool Equals(CreateFullTextStopListStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsSystemStopList, isSystemStopList)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DatabaseName, databaseName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.SourceStopListName, sourceStopListName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateFullTextStopListStatement left, CreateFullTextStopListStatement right) {
            return EqualityComparer<CreateFullTextStopListStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateFullTextStopListStatement left, CreateFullTextStopListStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateFullTextStopListStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isSystemStopList, othr.isSystemStopList);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.databaseName, othr.databaseName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sourceStopListName, othr.sourceStopListName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateFullTextStopListStatement left, CreateFullTextStopListStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateFullTextStopListStatement left, CreateFullTextStopListStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateFullTextStopListStatement left, CreateFullTextStopListStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateFullTextStopListStatement left, CreateFullTextStopListStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateFullTextStopListStatement FromMutable(ScriptDom.CreateFullTextStopListStatement fragment) {
            return (CreateFullTextStopListStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
