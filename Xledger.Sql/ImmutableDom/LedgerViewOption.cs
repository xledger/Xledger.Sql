using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LedgerViewOption : TableOption, IEquatable<LedgerViewOption> {
        protected SchemaObjectName viewName;
        protected Identifier transactionIdColumnName;
        protected Identifier sequenceNumberColumnName;
        protected Identifier operationTypeColumnName;
        protected Identifier operationTypeDescColumnName;
    
        public SchemaObjectName ViewName => viewName;
        public Identifier TransactionIdColumnName => transactionIdColumnName;
        public Identifier SequenceNumberColumnName => sequenceNumberColumnName;
        public Identifier OperationTypeColumnName => operationTypeColumnName;
        public Identifier OperationTypeDescColumnName => operationTypeDescColumnName;
    
        public LedgerViewOption(SchemaObjectName viewName = null, Identifier transactionIdColumnName = null, Identifier sequenceNumberColumnName = null, Identifier operationTypeColumnName = null, Identifier operationTypeDescColumnName = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.viewName = viewName;
            this.transactionIdColumnName = transactionIdColumnName;
            this.sequenceNumberColumnName = sequenceNumberColumnName;
            this.operationTypeColumnName = operationTypeColumnName;
            this.operationTypeDescColumnName = operationTypeDescColumnName;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LedgerViewOption ToMutableConcrete() {
            var ret = new ScriptDom.LedgerViewOption();
            ret.ViewName = (ScriptDom.SchemaObjectName)viewName?.ToMutable();
            ret.TransactionIdColumnName = (ScriptDom.Identifier)transactionIdColumnName?.ToMutable();
            ret.SequenceNumberColumnName = (ScriptDom.Identifier)sequenceNumberColumnName?.ToMutable();
            ret.OperationTypeColumnName = (ScriptDom.Identifier)operationTypeColumnName?.ToMutable();
            ret.OperationTypeDescColumnName = (ScriptDom.Identifier)operationTypeDescColumnName?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(viewName is null)) {
                h = h * 23 + viewName.GetHashCode();
            }
            if (!(transactionIdColumnName is null)) {
                h = h * 23 + transactionIdColumnName.GetHashCode();
            }
            if (!(sequenceNumberColumnName is null)) {
                h = h * 23 + sequenceNumberColumnName.GetHashCode();
            }
            if (!(operationTypeColumnName is null)) {
                h = h * 23 + operationTypeColumnName.GetHashCode();
            }
            if (!(operationTypeDescColumnName is null)) {
                h = h * 23 + operationTypeDescColumnName.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LedgerViewOption);
        } 
        
        public bool Equals(LedgerViewOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.ViewName, viewName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.TransactionIdColumnName, transactionIdColumnName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.SequenceNumberColumnName, sequenceNumberColumnName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.OperationTypeColumnName, operationTypeColumnName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.OperationTypeDescColumnName, operationTypeDescColumnName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LedgerViewOption left, LedgerViewOption right) {
            return EqualityComparer<LedgerViewOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LedgerViewOption left, LedgerViewOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LedgerViewOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.viewName, othr.viewName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.transactionIdColumnName, othr.transactionIdColumnName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sequenceNumberColumnName, othr.sequenceNumberColumnName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.operationTypeColumnName, othr.operationTypeColumnName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.operationTypeDescColumnName, othr.operationTypeDescColumnName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (LedgerViewOption left, LedgerViewOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(LedgerViewOption left, LedgerViewOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (LedgerViewOption left, LedgerViewOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(LedgerViewOption left, LedgerViewOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
