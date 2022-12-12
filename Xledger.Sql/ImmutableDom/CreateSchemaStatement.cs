using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateSchemaStatement : TSqlStatement, IEquatable<CreateSchemaStatement> {
        Identifier name;
        StatementList statementList;
        Identifier owner;
    
        public Identifier Name => name;
        public StatementList StatementList => statementList;
        public Identifier Owner => owner;
    
        public CreateSchemaStatement(Identifier name = null, StatementList statementList = null, Identifier owner = null) {
            this.name = name;
            this.statementList = statementList;
            this.owner = owner;
        }
    
        public ScriptDom.CreateSchemaStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateSchemaStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.StatementList = (ScriptDom.StatementList)statementList.ToMutable();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
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
            if (!(statementList is null)) {
                h = h * 23 + statementList.GetHashCode();
            }
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateSchemaStatement);
        } 
        
        public bool Equals(CreateSchemaStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<StatementList>.Default.Equals(other.StatementList, statementList)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateSchemaStatement left, CreateSchemaStatement right) {
            return EqualityComparer<CreateSchemaStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateSchemaStatement left, CreateSchemaStatement right) {
            return !(left == right);
        }
    
    }

}