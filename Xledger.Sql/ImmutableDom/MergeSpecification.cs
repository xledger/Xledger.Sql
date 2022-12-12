using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MergeSpecification : DataModificationSpecification, IEquatable<MergeSpecification> {
        Identifier tableAlias;
        TableReference tableReference;
        BooleanExpression searchCondition;
        IReadOnlyList<MergeActionClause> actionClauses;
    
        public Identifier TableAlias => tableAlias;
        public TableReference TableReference => tableReference;
        public BooleanExpression SearchCondition => searchCondition;
        public IReadOnlyList<MergeActionClause> ActionClauses => actionClauses;
    
        public MergeSpecification(Identifier tableAlias = null, TableReference tableReference = null, BooleanExpression searchCondition = null, IReadOnlyList<MergeActionClause> actionClauses = null, TableReference target = null, TopRowFilter topRowFilter = null, OutputIntoClause outputIntoClause = null, OutputClause outputClause = null) {
            this.tableAlias = tableAlias;
            this.tableReference = tableReference;
            this.searchCondition = searchCondition;
            this.actionClauses = actionClauses is null ? ImmList<MergeActionClause>.Empty : ImmList<MergeActionClause>.FromList(actionClauses);
            this.target = target;
            this.topRowFilter = topRowFilter;
            this.outputIntoClause = outputIntoClause;
            this.outputClause = outputClause;
        }
    
        public ScriptDom.MergeSpecification ToMutableConcrete() {
            var ret = new ScriptDom.MergeSpecification();
            ret.TableAlias = (ScriptDom.Identifier)tableAlias.ToMutable();
            ret.TableReference = (ScriptDom.TableReference)tableReference.ToMutable();
            ret.SearchCondition = (ScriptDom.BooleanExpression)searchCondition.ToMutable();
            ret.ActionClauses.AddRange(actionClauses.Select(c => (ScriptDom.MergeActionClause)c.ToMutable()));
            ret.Target = (ScriptDom.TableReference)target.ToMutable();
            ret.TopRowFilter = (ScriptDom.TopRowFilter)topRowFilter.ToMutable();
            ret.OutputIntoClause = (ScriptDom.OutputIntoClause)outputIntoClause.ToMutable();
            ret.OutputClause = (ScriptDom.OutputClause)outputClause.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(tableAlias is null)) {
                h = h * 23 + tableAlias.GetHashCode();
            }
            if (!(tableReference is null)) {
                h = h * 23 + tableReference.GetHashCode();
            }
            if (!(searchCondition is null)) {
                h = h * 23 + searchCondition.GetHashCode();
            }
            h = h * 23 + actionClauses.GetHashCode();
            if (!(target is null)) {
                h = h * 23 + target.GetHashCode();
            }
            if (!(topRowFilter is null)) {
                h = h * 23 + topRowFilter.GetHashCode();
            }
            if (!(outputIntoClause is null)) {
                h = h * 23 + outputIntoClause.GetHashCode();
            }
            if (!(outputClause is null)) {
                h = h * 23 + outputClause.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MergeSpecification);
        } 
        
        public bool Equals(MergeSpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.TableAlias, tableAlias)) {
                return false;
            }
            if (!EqualityComparer<TableReference>.Default.Equals(other.TableReference, tableReference)) {
                return false;
            }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.SearchCondition, searchCondition)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<MergeActionClause>>.Default.Equals(other.ActionClauses, actionClauses)) {
                return false;
            }
            if (!EqualityComparer<TableReference>.Default.Equals(other.Target, target)) {
                return false;
            }
            if (!EqualityComparer<TopRowFilter>.Default.Equals(other.TopRowFilter, topRowFilter)) {
                return false;
            }
            if (!EqualityComparer<OutputIntoClause>.Default.Equals(other.OutputIntoClause, outputIntoClause)) {
                return false;
            }
            if (!EqualityComparer<OutputClause>.Default.Equals(other.OutputClause, outputClause)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MergeSpecification left, MergeSpecification right) {
            return EqualityComparer<MergeSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MergeSpecification left, MergeSpecification right) {
            return !(left == right);
        }
    
    }

}
