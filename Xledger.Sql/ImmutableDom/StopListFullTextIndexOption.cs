using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class StopListFullTextIndexOption : FullTextIndexOption, IEquatable<StopListFullTextIndexOption> {
        bool isOff = false;
        Identifier stopListName;
    
        public bool IsOff => isOff;
        public Identifier StopListName => stopListName;
    
        public StopListFullTextIndexOption(bool isOff = false, Identifier stopListName = null, ScriptDom.FullTextIndexOptionKind optionKind = ScriptDom.FullTextIndexOptionKind.ChangeTracking) {
            this.isOff = isOff;
            this.stopListName = stopListName;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.StopListFullTextIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.StopListFullTextIndexOption();
            ret.IsOff = isOff;
            ret.StopListName = (ScriptDom.Identifier)stopListName.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isOff.GetHashCode();
            if (!(stopListName is null)) {
                h = h * 23 + stopListName.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as StopListFullTextIndexOption);
        } 
        
        public bool Equals(StopListFullTextIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsOff, isOff)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.StopListName, stopListName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.FullTextIndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(StopListFullTextIndexOption left, StopListFullTextIndexOption right) {
            return EqualityComparer<StopListFullTextIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(StopListFullTextIndexOption left, StopListFullTextIndexOption right) {
            return !(left == right);
        }
    
    }

}
