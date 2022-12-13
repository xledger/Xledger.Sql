using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateTypeTableStatement : CreateTypeStatement, IEquatable<CreateTypeTableStatement> {
        protected TableDefinition definition;
        protected IReadOnlyList<TableOption> options;
    
        public TableDefinition Definition => definition;
        public IReadOnlyList<TableOption> Options => options;
    
        public CreateTypeTableStatement(TableDefinition definition = null, IReadOnlyList<TableOption> options = null, SchemaObjectName name = null) {
            this.definition = definition;
            this.options = options is null ? ImmList<TableOption>.Empty : ImmList<TableOption>.FromList(options);
            this.name = name;
        }
    
        public ScriptDom.CreateTypeTableStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateTypeTableStatement();
            ret.Definition = (ScriptDom.TableDefinition)definition.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.TableOption)c.ToMutable()));
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(definition is null)) {
                h = h * 23 + definition.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateTypeTableStatement);
        } 
        
        public bool Equals(CreateTypeTableStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<TableDefinition>.Default.Equals(other.Definition, definition)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<TableOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateTypeTableStatement left, CreateTypeTableStatement right) {
            return EqualityComparer<CreateTypeTableStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateTypeTableStatement left, CreateTypeTableStatement right) {
            return !(left == right);
        }
    
        public static CreateTypeTableStatement FromMutable(ScriptDom.CreateTypeTableStatement fragment) {
            return (CreateTypeTableStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
