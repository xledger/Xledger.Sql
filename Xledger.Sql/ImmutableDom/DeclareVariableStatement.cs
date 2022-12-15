using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DeclareVariableStatement : TSqlStatement, IEquatable<DeclareVariableStatement> {
        protected IReadOnlyList<DeclareVariableElement> declarations;
    
        public IReadOnlyList<DeclareVariableElement> Declarations => declarations;
    
        public DeclareVariableStatement(IReadOnlyList<DeclareVariableElement> declarations = null) {
            this.declarations = ImmList<DeclareVariableElement>.FromList(declarations);
        }
    
        public ScriptDom.DeclareVariableStatement ToMutableConcrete() {
            var ret = new ScriptDom.DeclareVariableStatement();
            ret.Declarations.AddRange(declarations.SelectList(c => (ScriptDom.DeclareVariableElement)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + declarations.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DeclareVariableStatement);
        } 
        
        public bool Equals(DeclareVariableStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<DeclareVariableElement>>.Default.Equals(other.Declarations, declarations)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DeclareVariableStatement left, DeclareVariableStatement right) {
            return EqualityComparer<DeclareVariableStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DeclareVariableStatement left, DeclareVariableStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DeclareVariableStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.declarations, othr.declarations);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (DeclareVariableStatement left, DeclareVariableStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DeclareVariableStatement left, DeclareVariableStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DeclareVariableStatement left, DeclareVariableStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DeclareVariableStatement left, DeclareVariableStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
