using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PredictTableReference : TableReferenceWithAlias, IEquatable<PredictTableReference> {
        protected ScalarExpression modelVariable;
        protected ScalarSubquery modelSubquery;
        protected TableReferenceWithAlias dataSource;
        protected Identifier runTime;
        protected IReadOnlyList<SchemaDeclarationItem> schemaDeclarationItems;
    
        public ScalarExpression ModelVariable => modelVariable;
        public ScalarSubquery ModelSubquery => modelSubquery;
        public TableReferenceWithAlias DataSource => dataSource;
        public Identifier RunTime => runTime;
        public IReadOnlyList<SchemaDeclarationItem> SchemaDeclarationItems => schemaDeclarationItems;
    
        public PredictTableReference(ScalarExpression modelVariable = null, ScalarSubquery modelSubquery = null, TableReferenceWithAlias dataSource = null, Identifier runTime = null, IReadOnlyList<SchemaDeclarationItem> schemaDeclarationItems = null, Identifier alias = null, bool forPath = false) {
            this.modelVariable = modelVariable;
            this.modelSubquery = modelSubquery;
            this.dataSource = dataSource;
            this.runTime = runTime;
            this.schemaDeclarationItems = ImmList<SchemaDeclarationItem>.FromList(schemaDeclarationItems);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.PredictTableReference ToMutableConcrete() {
            var ret = new ScriptDom.PredictTableReference();
            ret.ModelVariable = (ScriptDom.ScalarExpression)modelVariable?.ToMutable();
            ret.ModelSubquery = (ScriptDom.ScalarSubquery)modelSubquery?.ToMutable();
            ret.DataSource = (ScriptDom.TableReferenceWithAlias)dataSource?.ToMutable();
            ret.RunTime = (ScriptDom.Identifier)runTime?.ToMutable();
            ret.SchemaDeclarationItems.AddRange(schemaDeclarationItems.SelectList(c => (ScriptDom.SchemaDeclarationItem)c?.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias?.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(modelVariable is null)) {
                h = h * 23 + modelVariable.GetHashCode();
            }
            if (!(modelSubquery is null)) {
                h = h * 23 + modelSubquery.GetHashCode();
            }
            if (!(dataSource is null)) {
                h = h * 23 + dataSource.GetHashCode();
            }
            if (!(runTime is null)) {
                h = h * 23 + runTime.GetHashCode();
            }
            h = h * 23 + schemaDeclarationItems.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PredictTableReference);
        } 
        
        public bool Equals(PredictTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.ModelVariable, modelVariable)) {
                return false;
            }
            if (!EqualityComparer<ScalarSubquery>.Default.Equals(other.ModelSubquery, modelSubquery)) {
                return false;
            }
            if (!EqualityComparer<TableReferenceWithAlias>.Default.Equals(other.DataSource, dataSource)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.RunTime, runTime)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SchemaDeclarationItem>>.Default.Equals(other.SchemaDeclarationItems, schemaDeclarationItems)) {
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
        
        public static bool operator ==(PredictTableReference left, PredictTableReference right) {
            return EqualityComparer<PredictTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PredictTableReference left, PredictTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (PredictTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.modelVariable, othr.modelVariable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.modelSubquery, othr.modelSubquery);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.dataSource, othr.dataSource);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.runTime, othr.runTime);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.schemaDeclarationItems, othr.schemaDeclarationItems);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (PredictTableReference left, PredictTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(PredictTableReference left, PredictTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (PredictTableReference left, PredictTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(PredictTableReference left, PredictTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static PredictTableReference FromMutable(ScriptDom.PredictTableReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.PredictTableReference)) { throw new NotImplementedException("Unexpected subtype of PredictTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PredictTableReference(
                modelVariable: ImmutableDom.ScalarExpression.FromMutable(fragment.ModelVariable),
                modelSubquery: ImmutableDom.ScalarSubquery.FromMutable(fragment.ModelSubquery),
                dataSource: ImmutableDom.TableReferenceWithAlias.FromMutable(fragment.DataSource),
                runTime: ImmutableDom.Identifier.FromMutable(fragment.RunTime),
                schemaDeclarationItems: fragment.SchemaDeclarationItems.SelectList(ImmutableDom.SchemaDeclarationItem.FromMutable),
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
