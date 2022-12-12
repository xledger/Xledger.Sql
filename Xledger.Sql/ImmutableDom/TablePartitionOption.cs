using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TablePartitionOption : TableOption, IEquatable<TablePartitionOption> {
        Identifier partitionColumn;
        TablePartitionOptionSpecifications partitionOptionSpecs;
    
        public Identifier PartitionColumn => partitionColumn;
        public TablePartitionOptionSpecifications PartitionOptionSpecs => partitionOptionSpecs;
    
        public TablePartitionOption(Identifier partitionColumn = null, TablePartitionOptionSpecifications partitionOptionSpecs = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.partitionColumn = partitionColumn;
            this.partitionOptionSpecs = partitionOptionSpecs;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.TablePartitionOption ToMutableConcrete() {
            var ret = new ScriptDom.TablePartitionOption();
            ret.PartitionColumn = (ScriptDom.Identifier)partitionColumn.ToMutable();
            ret.PartitionOptionSpecs = (ScriptDom.TablePartitionOptionSpecifications)partitionOptionSpecs.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(partitionColumn is null)) {
                h = h * 23 + partitionColumn.GetHashCode();
            }
            if (!(partitionOptionSpecs is null)) {
                h = h * 23 + partitionOptionSpecs.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TablePartitionOption);
        } 
        
        public bool Equals(TablePartitionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.PartitionColumn, partitionColumn)) {
                return false;
            }
            if (!EqualityComparer<TablePartitionOptionSpecifications>.Default.Equals(other.PartitionOptionSpecs, partitionOptionSpecs)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TablePartitionOption left, TablePartitionOption right) {
            return EqualityComparer<TablePartitionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TablePartitionOption left, TablePartitionOption right) {
            return !(left == right);
        }
    
    }

}