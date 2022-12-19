using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateSynonymStatement : TSqlStatement, IEquatable<CreateSynonymStatement> {
        protected SchemaObjectName name;
        protected SchemaObjectName forName;
    
        public SchemaObjectName Name => name;
        public SchemaObjectName ForName => forName;
    
        public CreateSynonymStatement(SchemaObjectName name = null, SchemaObjectName forName = null) {
            this.name = name;
            this.forName = forName;
        }
    
        public ScriptDom.CreateSynonymStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateSynonymStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name?.ToMutable();
            ret.ForName = (ScriptDom.SchemaObjectName)forName?.ToMutable();
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
            if (!(forName is null)) {
                h = h * 23 + forName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateSynonymStatement);
        } 
        
        public bool Equals(CreateSynonymStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.ForName, forName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateSynonymStatement left, CreateSynonymStatement right) {
            return EqualityComparer<CreateSynonymStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateSynonymStatement left, CreateSynonymStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateSynonymStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forName, othr.forName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateSynonymStatement left, CreateSynonymStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateSynonymStatement left, CreateSynonymStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateSynonymStatement left, CreateSynonymStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateSynonymStatement left, CreateSynonymStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateSynonymStatement FromMutable(ScriptDom.CreateSynonymStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateSynonymStatement)) { throw new NotImplementedException("Unexpected subtype of CreateSynonymStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSynonymStatement(
                name: ImmutableDom.SchemaObjectName.FromMutable(fragment.Name),
                forName: ImmutableDom.SchemaObjectName.FromMutable(fragment.ForName)
            );
        }
    
    }

}
