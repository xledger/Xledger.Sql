using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateAssemblyStatement : AssemblyStatement, IEquatable<CreateAssemblyStatement> {
        protected Identifier owner;
    
        public Identifier Owner => owner;
    
        public CreateAssemblyStatement(Identifier owner = null, Identifier name = null, IReadOnlyList<ScalarExpression> parameters = null, IReadOnlyList<AssemblyOption> options = null) {
            this.owner = owner;
            this.name = name;
            this.parameters = parameters is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(parameters);
            this.options = options is null ? ImmList<AssemblyOption>.Empty : ImmList<AssemblyOption>.FromList(options);
        }
    
        public ScriptDom.CreateAssemblyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateAssemblyStatement();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AssemblyOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + parameters.GetHashCode();
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateAssemblyStatement);
        } 
        
        public bool Equals(CreateAssemblyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<AssemblyOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateAssemblyStatement left, CreateAssemblyStatement right) {
            return EqualityComparer<CreateAssemblyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateAssemblyStatement left, CreateAssemblyStatement right) {
            return !(left == right);
        }
    
    }

}
