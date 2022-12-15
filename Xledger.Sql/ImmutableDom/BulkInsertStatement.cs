using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BulkInsertStatement : BulkInsertBase, IEquatable<BulkInsertStatement> {
        protected IdentifierOrValueExpression from;
    
        public IdentifierOrValueExpression From => from;
    
        public BulkInsertStatement(IdentifierOrValueExpression from = null, SchemaObjectName to = null, IReadOnlyList<BulkInsertOption> options = null) {
            this.from = from;
            this.to = to;
            this.options = ImmList<BulkInsertOption>.FromList(options);
        }
    
        public ScriptDom.BulkInsertStatement ToMutableConcrete() {
            var ret = new ScriptDom.BulkInsertStatement();
            ret.From = (ScriptDom.IdentifierOrValueExpression)from.ToMutable();
            ret.To = (ScriptDom.SchemaObjectName)to.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.BulkInsertOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(from is null)) {
                h = h * 23 + from.GetHashCode();
            }
            if (!(to is null)) {
                h = h * 23 + to.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BulkInsertStatement);
        } 
        
        public bool Equals(BulkInsertStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.From, from)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.To, to)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<BulkInsertOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BulkInsertStatement left, BulkInsertStatement right) {
            return EqualityComparer<BulkInsertStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BulkInsertStatement left, BulkInsertStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BulkInsertStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.from, othr.from);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.to, othr.to);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (BulkInsertStatement left, BulkInsertStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BulkInsertStatement left, BulkInsertStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BulkInsertStatement left, BulkInsertStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BulkInsertStatement left, BulkInsertStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
