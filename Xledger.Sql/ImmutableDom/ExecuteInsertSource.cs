using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteInsertSource : InsertSource, IEquatable<ExecuteInsertSource> {
        protected ExecuteSpecification execute;
    
        public ExecuteSpecification Execute => execute;
    
        public ExecuteInsertSource(ExecuteSpecification execute = null) {
            this.execute = execute;
        }
    
        public ScriptDom.ExecuteInsertSource ToMutableConcrete() {
            var ret = new ScriptDom.ExecuteInsertSource();
            ret.Execute = (ScriptDom.ExecuteSpecification)execute.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(execute is null)) {
                h = h * 23 + execute.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecuteInsertSource);
        } 
        
        public bool Equals(ExecuteInsertSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ExecuteSpecification>.Default.Equals(other.Execute, execute)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecuteInsertSource left, ExecuteInsertSource right) {
            return EqualityComparer<ExecuteInsertSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecuteInsertSource left, ExecuteInsertSource right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExecuteInsertSource)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.execute, othr.execute);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static ExecuteInsertSource FromMutable(ScriptDom.ExecuteInsertSource fragment) {
            return (ExecuteInsertSource)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
