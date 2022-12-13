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
    
        public static CreateExternalStreamingJobStatement FromMutable(ScriptDom.CreateExternalStreamingJobStatement fragment) {
            return (CreateExternalStreamingJobStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
