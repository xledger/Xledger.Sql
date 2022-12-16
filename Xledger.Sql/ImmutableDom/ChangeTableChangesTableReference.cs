using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ChangeTableChangesTableReference : TableReferenceWithAliasAndColumns, IEquatable<ChangeTableChangesTableReference> {
        protected SchemaObjectName target;
        protected ValueExpression sinceVersion;
    
        public SchemaObjectName Target => target;
        public ValueExpression SinceVersion => sinceVersion;
    
        public ChangeTableChangesTableReference(SchemaObjectName target = null, ValueExpression sinceVersion = null, IReadOnlyList<Identifier> columns = null, Identifier alias = null, bool forPath = false) {
            this.target = target;
            this.sinceVersion = sinceVersion;
            this.columns = ImmList<Identifier>.FromList(columns);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.ChangeTableChangesTableReference ToMutableConcrete() {
            var ret = new ScriptDom.ChangeTableChangesTableReference();
            ret.Target = (ScriptDom.SchemaObjectName)target?.ToMutable();
            ret.SinceVersion = (ScriptDom.ValueExpression)sinceVersion?.ToMutable();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias?.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(target is null)) {
                h = h * 23 + target.GetHashCode();
            }
            if (!(sinceVersion is null)) {
                h = h * 23 + sinceVersion.GetHashCode();
            }
            h = h * 23 + columns.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ChangeTableChangesTableReference);
        } 
        
        public bool Equals(ChangeTableChangesTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Target, target)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.SinceVersion, sinceVersion)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Alias, alias)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForPath, forPath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ChangeTableChangesTableReference left, ChangeTableChangesTableReference right) {
            return EqualityComparer<ChangeTableChangesTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ChangeTableChangesTableReference left, ChangeTableChangesTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ChangeTableChangesTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.target, othr.target);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sinceVersion, othr.sinceVersion);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ChangeTableChangesTableReference left, ChangeTableChangesTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ChangeTableChangesTableReference left, ChangeTableChangesTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ChangeTableChangesTableReference left, ChangeTableChangesTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ChangeTableChangesTableReference left, ChangeTableChangesTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
