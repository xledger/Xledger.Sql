using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreatePartitionSchemeStatement : TSqlStatement, IEquatable<CreatePartitionSchemeStatement> {
        protected Identifier name;
        protected Identifier partitionFunction;
        protected bool isAll = false;
        protected IReadOnlyList<IdentifierOrValueExpression> fileGroups;
    
        public Identifier Name => name;
        public Identifier PartitionFunction => partitionFunction;
        public bool IsAll => isAll;
        public IReadOnlyList<IdentifierOrValueExpression> FileGroups => fileGroups;
    
        public CreatePartitionSchemeStatement(Identifier name = null, Identifier partitionFunction = null, bool isAll = false, IReadOnlyList<IdentifierOrValueExpression> fileGroups = null) {
            this.name = name;
            this.partitionFunction = partitionFunction;
            this.isAll = isAll;
            this.fileGroups = fileGroups is null ? ImmList<IdentifierOrValueExpression>.Empty : ImmList<IdentifierOrValueExpression>.FromList(fileGroups);
        }
    
        public ScriptDom.CreatePartitionSchemeStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreatePartitionSchemeStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.PartitionFunction = (ScriptDom.Identifier)partitionFunction.ToMutable();
            ret.IsAll = isAll;
            ret.FileGroups.AddRange(fileGroups.SelectList(c => (ScriptDom.IdentifierOrValueExpression)c.ToMutable()));
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
            if (!(partitionFunction is null)) {
                h = h * 23 + partitionFunction.GetHashCode();
            }
            h = h * 23 + isAll.GetHashCode();
            h = h * 23 + fileGroups.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreatePartitionSchemeStatement);
        } 
        
        public bool Equals(CreatePartitionSchemeStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.PartitionFunction, partitionFunction)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsAll, isAll)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IdentifierOrValueExpression>>.Default.Equals(other.FileGroups, fileGroups)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreatePartitionSchemeStatement left, CreatePartitionSchemeStatement right) {
            return EqualityComparer<CreatePartitionSchemeStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreatePartitionSchemeStatement left, CreatePartitionSchemeStatement right) {
            return !(left == right);
        }
    
        public static CreatePartitionSchemeStatement FromMutable(ScriptDom.CreatePartitionSchemeStatement fragment) {
            return (CreatePartitionSchemeStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
