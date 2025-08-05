using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TableHintsOptimizerHint : OptimizerHint, IEquatable<TableHintsOptimizerHint> {
        protected SchemaObjectName objectName;
        protected IReadOnlyList<TableHint> tableHints;
    
        public SchemaObjectName ObjectName => objectName;
        public IReadOnlyList<TableHint> TableHints => tableHints;
    
        public TableHintsOptimizerHint(SchemaObjectName objectName = null, IReadOnlyList<TableHint> tableHints = null, ScriptDom.OptimizerHintKind hintKind = ScriptDom.OptimizerHintKind.Unspecified) {
            this.objectName = objectName;
            this.tableHints = tableHints.ToImmArray<TableHint>();
            this.hintKind = hintKind;
        }
    
        public new ScriptDom.TableHintsOptimizerHint ToMutableConcrete() {
            var ret = new ScriptDom.TableHintsOptimizerHint();
            ret.ObjectName = (ScriptDom.SchemaObjectName)objectName?.ToMutable();
            ret.TableHints.AddRange(tableHints.Select(c => (ScriptDom.TableHint)c?.ToMutable()));
            ret.HintKind = hintKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(objectName is null)) {
                h = h * 23 + objectName.GetHashCode();
            }
            h = h * 23 + tableHints.GetHashCode();
            h = h * 23 + hintKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TableHintsOptimizerHint);
        } 
        
        public bool Equals(TableHintsOptimizerHint other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.ObjectName, objectName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<TableHint>>.Default.Equals(other.TableHints, tableHints)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptimizerHintKind>.Default.Equals(other.HintKind, hintKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TableHintsOptimizerHint left, TableHintsOptimizerHint right) {
            return EqualityComparer<TableHintsOptimizerHint>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TableHintsOptimizerHint left, TableHintsOptimizerHint right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TableHintsOptimizerHint)that;
            compare = Comparer.DefaultInvariant.Compare(this.objectName, othr.objectName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.tableHints, othr.tableHints);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.hintKind, othr.hintKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (TableHintsOptimizerHint left, TableHintsOptimizerHint right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TableHintsOptimizerHint left, TableHintsOptimizerHint right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TableHintsOptimizerHint left, TableHintsOptimizerHint right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TableHintsOptimizerHint left, TableHintsOptimizerHint right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TableHintsOptimizerHint FromMutable(ScriptDom.TableHintsOptimizerHint fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.TableHintsOptimizerHint)) { throw new NotImplementedException("Unexpected subtype of TableHintsOptimizerHint not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableHintsOptimizerHint(
                objectName: ImmutableDom.SchemaObjectName.FromMutable(fragment.ObjectName),
                tableHints: fragment.TableHints.ToImmArray(ImmutableDom.TableHint.FromMutable),
                hintKind: fragment.HintKind
            );
        }
    
    }

}
