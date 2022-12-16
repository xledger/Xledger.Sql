using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableDropTableElementStatement : AlterTableStatement, IEquatable<AlterTableDropTableElementStatement> {
        protected IReadOnlyList<AlterTableDropTableElement> alterTableDropTableElements;
    
        public IReadOnlyList<AlterTableDropTableElement> AlterTableDropTableElements => alterTableDropTableElements;
    
        public AlterTableDropTableElementStatement(IReadOnlyList<AlterTableDropTableElement> alterTableDropTableElements = null, SchemaObjectName schemaObjectName = null) {
            this.alterTableDropTableElements = ImmList<AlterTableDropTableElement>.FromList(alterTableDropTableElements);
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableDropTableElementStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableDropTableElementStatement();
            ret.AlterTableDropTableElements.AddRange(alterTableDropTableElements.SelectList(c => (ScriptDom.AlterTableDropTableElement)c?.ToMutable()));
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + alterTableDropTableElements.GetHashCode();
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableDropTableElementStatement);
        } 
        
        public bool Equals(AlterTableDropTableElementStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<AlterTableDropTableElement>>.Default.Equals(other.AlterTableDropTableElements, alterTableDropTableElements)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableDropTableElementStatement left, AlterTableDropTableElementStatement right) {
            return EqualityComparer<AlterTableDropTableElementStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableDropTableElementStatement left, AlterTableDropTableElementStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterTableDropTableElementStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.alterTableDropTableElements, othr.alterTableDropTableElements);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterTableDropTableElementStatement left, AlterTableDropTableElementStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterTableDropTableElementStatement left, AlterTableDropTableElementStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterTableDropTableElementStatement left, AlterTableDropTableElementStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterTableDropTableElementStatement left, AlterTableDropTableElementStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
