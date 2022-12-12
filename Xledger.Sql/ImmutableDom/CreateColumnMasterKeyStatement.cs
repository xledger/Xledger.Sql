using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateColumnMasterKeyStatement : TSqlStatement, IEquatable<CreateColumnMasterKeyStatement> {
        Identifier name;
        IReadOnlyList<ColumnMasterKeyParameter> parameters;
    
        public Identifier Name => name;
        public IReadOnlyList<ColumnMasterKeyParameter> Parameters => parameters;
    
        public CreateColumnMasterKeyStatement(Identifier name = null, IReadOnlyList<ColumnMasterKeyParameter> parameters = null) {
            this.name = name;
            this.parameters = parameters is null ? ImmList<ColumnMasterKeyParameter>.Empty : ImmList<ColumnMasterKeyParameter>.FromList(parameters);
        }
    
        public ScriptDom.CreateColumnMasterKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateColumnMasterKeyStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Parameters.AddRange(parameters.Select(c => (ScriptDom.ColumnMasterKeyParameter)c.ToMutable()));
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
            h = h * 23 + parameters.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateColumnMasterKeyStatement);
        } 
        
        public bool Equals(CreateColumnMasterKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnMasterKeyParameter>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateColumnMasterKeyStatement left, CreateColumnMasterKeyStatement right) {
            return EqualityComparer<CreateColumnMasterKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateColumnMasterKeyStatement left, CreateColumnMasterKeyStatement right) {
            return !(left == right);
        }
    
    }

}