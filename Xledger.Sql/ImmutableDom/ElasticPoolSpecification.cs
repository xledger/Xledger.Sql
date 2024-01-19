using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ElasticPoolSpecification : DatabaseOption, IEquatable<ElasticPoolSpecification> {
        protected Identifier elasticPoolName;
    
        public Identifier ElasticPoolName => elasticPoolName;
    
        public ElasticPoolSpecification(Identifier elasticPoolName = null, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.elasticPoolName = elasticPoolName;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.ElasticPoolSpecification ToMutableConcrete() {
            var ret = new ScriptDom.ElasticPoolSpecification();
            ret.ElasticPoolName = (ScriptDom.Identifier)elasticPoolName?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(elasticPoolName is null)) {
                h = h * 23 + elasticPoolName.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ElasticPoolSpecification);
        } 
        
        public bool Equals(ElasticPoolSpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ElasticPoolName, elasticPoolName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ElasticPoolSpecification left, ElasticPoolSpecification right) {
            return EqualityComparer<ElasticPoolSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ElasticPoolSpecification left, ElasticPoolSpecification right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ElasticPoolSpecification)that;
            compare = Comparer.DefaultInvariant.Compare(this.elasticPoolName, othr.elasticPoolName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ElasticPoolSpecification left, ElasticPoolSpecification right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ElasticPoolSpecification left, ElasticPoolSpecification right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ElasticPoolSpecification left, ElasticPoolSpecification right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ElasticPoolSpecification left, ElasticPoolSpecification right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ElasticPoolSpecification FromMutable(ScriptDom.ElasticPoolSpecification fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ElasticPoolSpecification)) { throw new NotImplementedException("Unexpected subtype of ElasticPoolSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ElasticPoolSpecification(
                elasticPoolName: ImmutableDom.Identifier.FromMutable(fragment.ElasticPoolName),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
