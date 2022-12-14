using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableSetStatement : AlterTableStatement, IEquatable<AlterTableSetStatement> {
        protected IReadOnlyList<TableOption> options;
    
        public IReadOnlyList<TableOption> Options => options;
    
        public AlterTableSetStatement(IReadOnlyList<TableOption> options = null, SchemaObjectName schemaObjectName = null) {
            this.options = ImmList<TableOption>.FromList(options);
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableSetStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableSetStatement();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.TableOption)c?.ToMutable()));
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableSetStatement);
        } 
        
        public bool Equals(AlterTableSetStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<TableOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableSetStatement left, AlterTableSetStatement right) {
            return EqualityComparer<AlterTableSetStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableSetStatement left, AlterTableSetStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterTableSetStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterTableSetStatement left, AlterTableSetStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterTableSetStatement left, AlterTableSetStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterTableSetStatement left, AlterTableSetStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterTableSetStatement left, AlterTableSetStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterTableSetStatement FromMutable(ScriptDom.AlterTableSetStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterTableSetStatement)) { throw new NotImplementedException("Unexpected subtype of AlterTableSetStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableSetStatement(
                options: fragment.Options.SelectList(ImmutableDom.TableOption.FromMutable),
                schemaObjectName: ImmutableDom.SchemaObjectName.FromMutable(fragment.SchemaObjectName)
            );
        }
    
    }

}
