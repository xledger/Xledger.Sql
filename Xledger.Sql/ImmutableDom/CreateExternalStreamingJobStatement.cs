using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateExternalStreamingJobStatement : ExternalStreamingJobStatement, IEquatable<CreateExternalStreamingJobStatement> {
        public CreateExternalStreamingJobStatement(StringLiteral name = null, StringLiteral statement = null) {
            this.name = name;
            this.statement = statement;
        }
    
        public ScriptDom.CreateExternalStreamingJobStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateExternalStreamingJobStatement();
            ret.Name = (ScriptDom.StringLiteral)name.ToMutable();
            ret.Statement = (ScriptDom.StringLiteral)statement.ToMutable();
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
            if (!(statement is null)) {
                h = h * 23 + statement.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateExternalStreamingJobStatement);
        } 
        
        public bool Equals(CreateExternalStreamingJobStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Statement, statement)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateExternalStreamingJobStatement left, CreateExternalStreamingJobStatement right) {
            return EqualityComparer<CreateExternalStreamingJobStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateExternalStreamingJobStatement left, CreateExternalStreamingJobStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateExternalStreamingJobStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.statement, othr.statement);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateExternalStreamingJobStatement left, CreateExternalStreamingJobStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateExternalStreamingJobStatement left, CreateExternalStreamingJobStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateExternalStreamingJobStatement left, CreateExternalStreamingJobStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateExternalStreamingJobStatement left, CreateExternalStreamingJobStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateExternalStreamingJobStatement FromMutable(ScriptDom.CreateExternalStreamingJobStatement fragment) {
            return (CreateExternalStreamingJobStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
