using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BeginEndBlockStatement : TSqlStatement, IEquatable<BeginEndBlockStatement> {
        protected StatementList statementList;
    
        public StatementList StatementList => statementList;
    
        public BeginEndBlockStatement(StatementList statementList = null) {
            this.statementList = statementList;
        }
    
        public ScriptDom.BeginEndBlockStatement ToMutableConcrete() {
            var ret = new ScriptDom.BeginEndBlockStatement();
            ret.StatementList = (ScriptDom.StatementList)statementList?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(statementList is null)) {
                h = h * 23 + statementList.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BeginEndBlockStatement);
        } 
        
        public bool Equals(BeginEndBlockStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StatementList>.Default.Equals(other.StatementList, statementList)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BeginEndBlockStatement left, BeginEndBlockStatement right) {
            return EqualityComparer<BeginEndBlockStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BeginEndBlockStatement left, BeginEndBlockStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BeginEndBlockStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.statementList, othr.statementList);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (BeginEndBlockStatement left, BeginEndBlockStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BeginEndBlockStatement left, BeginEndBlockStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BeginEndBlockStatement left, BeginEndBlockStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BeginEndBlockStatement left, BeginEndBlockStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static BeginEndBlockStatement FromMutable(ScriptDom.BeginEndBlockStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.BeginEndBlockStatement)) { return TSqlFragment.FromMutable(fragment) as BeginEndBlockStatement; }
            return new BeginEndBlockStatement(
                statementList: ImmutableDom.StatementList.FromMutable(fragment.StatementList)
            );
        }
    
    }

}
