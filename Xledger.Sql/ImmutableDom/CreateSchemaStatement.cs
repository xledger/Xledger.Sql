using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateSchemaStatement : TSqlStatement, IEquatable<CreateSchemaStatement> {
        protected Identifier name;
        protected StatementList statementList;
        protected Identifier owner;
    
        public Identifier Name => name;
        public StatementList StatementList => statementList;
        public Identifier Owner => owner;
    
        public CreateSchemaStatement(Identifier name = null, StatementList statementList = null, Identifier owner = null) {
            this.name = name;
            this.statementList = statementList;
            this.owner = owner;
        }
    
        public ScriptDom.CreateSchemaStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateSchemaStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.StatementList = (ScriptDom.StatementList)statementList.ToMutable();
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
            if (!(statementList is null)) {
                h = h * 23 + statementList.GetHashCode();
            }
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateSchemaStatement);
        } 
        
        public bool Equals(CreateSchemaStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<StatementList>.Default.Equals(other.StatementList, statementList)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateSchemaStatement left, CreateSchemaStatement right) {
            return EqualityComparer<CreateSchemaStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateSchemaStatement left, CreateSchemaStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateSchemaStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.statementList, othr.statementList);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.owner, othr.owner);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateSchemaStatement left, CreateSchemaStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateSchemaStatement left, CreateSchemaStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateSchemaStatement left, CreateSchemaStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateSchemaStatement left, CreateSchemaStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateSchemaStatement FromMutable(ScriptDom.CreateSchemaStatement fragment) {
            return (CreateSchemaStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
