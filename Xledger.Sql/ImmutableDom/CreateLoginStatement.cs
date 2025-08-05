using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateLoginStatement : TSqlStatement, IEquatable<CreateLoginStatement> {
        protected Identifier name;
        protected CreateLoginSource source;
    
        public Identifier Name => name;
        public CreateLoginSource Source => source;
    
        public CreateLoginStatement(Identifier name = null, CreateLoginSource source = null) {
            this.name = name;
            this.source = source;
        }
    
        public ScriptDom.CreateLoginStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateLoginStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Source = (ScriptDom.CreateLoginSource)source?.ToMutable();
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
            if (!(source is null)) {
                h = h * 23 + source.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateLoginStatement);
        } 
        
        public bool Equals(CreateLoginStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<CreateLoginSource>.Default.Equals(other.Source, source)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateLoginStatement left, CreateLoginStatement right) {
            return EqualityComparer<CreateLoginStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateLoginStatement left, CreateLoginStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateLoginStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.source, othr.source);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateLoginStatement left, CreateLoginStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateLoginStatement left, CreateLoginStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateLoginStatement left, CreateLoginStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateLoginStatement left, CreateLoginStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateLoginStatement FromMutable(ScriptDom.CreateLoginStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateLoginStatement)) { throw new NotImplementedException("Unexpected subtype of CreateLoginStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateLoginStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                source: ImmutableDom.CreateLoginSource.FromMutable(fragment.Source)
            );
        }
    
    }

}
