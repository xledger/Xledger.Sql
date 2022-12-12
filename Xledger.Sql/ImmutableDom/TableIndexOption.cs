using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TableIndexOption : TableOption, IEquatable<TableIndexOption> {
        protected TableIndexType @value;
    
        public TableIndexType Value => @value;
    
        public TableIndexOption(TableIndexType @value = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.TableIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.TableIndexOption();
            ret.Value = (ScriptDom.TableIndexType)@value.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TableIndexOption);
        } 
        
        public bool Equals(TableIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<TableIndexType>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TableIndexOption left, TableIndexOption right) {
            return EqualityComparer<TableIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TableIndexOption left, TableIndexOption right) {
            return !(left == right);
        }
    
    }

}
