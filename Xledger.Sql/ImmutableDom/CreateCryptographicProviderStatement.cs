using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateCryptographicProviderStatement : TSqlStatement, IEquatable<CreateCryptographicProviderStatement> {
        protected Identifier name;
        protected Literal file;
    
        public Identifier Name => name;
        public Literal File => file;
    
        public CreateCryptographicProviderStatement(Identifier name = null, Literal file = null) {
            this.name = name;
            this.file = file;
        }
    
        public ScriptDom.CreateCryptographicProviderStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateCryptographicProviderStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.File = (ScriptDom.Literal)file?.ToMutable();
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
            if (!(file is null)) {
                h = h * 23 + file.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateCryptographicProviderStatement);
        } 
        
        public bool Equals(CreateCryptographicProviderStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.File, file)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateCryptographicProviderStatement left, CreateCryptographicProviderStatement right) {
            return EqualityComparer<CreateCryptographicProviderStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateCryptographicProviderStatement left, CreateCryptographicProviderStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateCryptographicProviderStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.file, othr.file);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateCryptographicProviderStatement left, CreateCryptographicProviderStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateCryptographicProviderStatement left, CreateCryptographicProviderStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateCryptographicProviderStatement left, CreateCryptographicProviderStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateCryptographicProviderStatement left, CreateCryptographicProviderStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
