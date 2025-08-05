using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TryCatchStatement : TSqlStatement, IEquatable<TryCatchStatement> {
        protected StatementList tryStatements;
        protected StatementList catchStatements;
    
        public StatementList TryStatements => tryStatements;
        public StatementList CatchStatements => catchStatements;
    
        public TryCatchStatement(StatementList tryStatements = null, StatementList catchStatements = null) {
            this.tryStatements = tryStatements;
            this.catchStatements = catchStatements;
        }
    
        public ScriptDom.TryCatchStatement ToMutableConcrete() {
            var ret = new ScriptDom.TryCatchStatement();
            ret.TryStatements = (ScriptDom.StatementList)tryStatements?.ToMutable();
            ret.CatchStatements = (ScriptDom.StatementList)catchStatements?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(tryStatements is null)) {
                h = h * 23 + tryStatements.GetHashCode();
            }
            if (!(catchStatements is null)) {
                h = h * 23 + catchStatements.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TryCatchStatement);
        } 
        
        public bool Equals(TryCatchStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StatementList>.Default.Equals(other.TryStatements, tryStatements)) {
                return false;
            }
            if (!EqualityComparer<StatementList>.Default.Equals(other.CatchStatements, catchStatements)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TryCatchStatement left, TryCatchStatement right) {
            return EqualityComparer<TryCatchStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TryCatchStatement left, TryCatchStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TryCatchStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.tryStatements, othr.tryStatements);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.catchStatements, othr.catchStatements);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (TryCatchStatement left, TryCatchStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TryCatchStatement left, TryCatchStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TryCatchStatement left, TryCatchStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TryCatchStatement left, TryCatchStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TryCatchStatement FromMutable(ScriptDom.TryCatchStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.TryCatchStatement)) { throw new NotImplementedException("Unexpected subtype of TryCatchStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TryCatchStatement(
                tryStatements: ImmutableDom.StatementList.FromMutable(fragment.TryStatements),
                catchStatements: ImmutableDom.StatementList.FromMutable(fragment.CatchStatements)
            );
        }
    
    }

}
