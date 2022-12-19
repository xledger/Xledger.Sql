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
            this.options = ImmList<TableOption>.FromList(options);
            this.name = name;
        }
    
        public ScriptDom.CreateTypeTableStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateTypeTableStatement();
            ret.Definition = (ScriptDom.TableDefinition)definition?.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.TableOption)c?.ToMutable()));
            ret.Name = (ScriptDom.SchemaObjectName)name?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateTypeTableStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.definition, othr.definition);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateTypeTableStatement left, CreateTypeTableStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateTypeTableStatement left, CreateTypeTableStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateTypeTableStatement left, CreateTypeTableStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateTypeTableStatement left, CreateTypeTableStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateTypeTableStatement FromMutable(ScriptDom.CreateTypeTableStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateTypeTableStatement)) { throw new NotImplementedException("Unexpected subtype of CreateTypeTableStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateTypeTableStatement(
                definition: ImmutableDom.TableDefinition.FromMutable(fragment.Definition),
                options: fragment.Options.SelectList(ImmutableDom.TableOption.FromMutable),
                name: ImmutableDom.SchemaObjectName.FromMutable(fragment.Name)
            );
        }
    
    }

}
