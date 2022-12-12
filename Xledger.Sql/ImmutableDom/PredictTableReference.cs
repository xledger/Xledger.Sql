using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PredictTableReference : TableReferenceWithAlias, IEquatable<PredictTableReference> {
        ScalarExpression modelVariable;
        ScalarSubquery modelSubquery;
        TableReferenceWithAlias dataSource;
        Identifier runTime;
        IReadOnlyList<SchemaDeclarationItem> schemaDeclarationItems;
    
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
            this.schemaDeclarationItems = schemaDeclarationItems is null ? ImmList<SchemaDeclarationItem>.Empty : ImmList<SchemaDeclarationItem>.FromList(schemaDeclarationItems);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.PredictTableReference ToMutableConcrete() {
            var ret = new ScriptDom.PredictTableReference();
            ret.ModelVariable = (ScriptDom.ScalarExpression)modelVariable.ToMutable();
            ret.ModelSubquery = (ScriptDom.ScalarSubquery)modelSubquery.ToMutable();
            ret.DataSource = (ScriptDom.TableReferenceWithAlias)dataSource.ToMutable();
            ret.RunTime = (ScriptDom.Identifier)runTime.ToMutable();
            ret.SchemaDeclarationItems.AddRange(schemaDeclarationItems.Select(c => (ScriptDom.SchemaDeclarationItem)c.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
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
    
    }

}