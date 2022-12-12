using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlgorithmKeyOption : KeyOption, IEquatable<AlgorithmKeyOption> {
        ScriptDom.EncryptionAlgorithm algorithm = ScriptDom.EncryptionAlgorithm.None;
    
        public ScriptDom.EncryptionAlgorithm Algorithm => algorithm;
    
        public AlgorithmKeyOption(ScriptDom.EncryptionAlgorithm algorithm = ScriptDom.EncryptionAlgorithm.None, ScriptDom.KeyOptionKind optionKind = ScriptDom.KeyOptionKind.KeySource) {
            this.algorithm = algorithm;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.AlgorithmKeyOption ToMutableConcrete() {
            var ret = new ScriptDom.AlgorithmKeyOption();
            ret.Algorithm = algorithm;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + algorithm.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlgorithmKeyOption);
        } 
        
        public bool Equals(AlgorithmKeyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.EncryptionAlgorithm>.Default.Equals(other.Algorithm, algorithm)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.KeyOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlgorithmKeyOption left, AlgorithmKeyOption right) {
            return EqualityComparer<AlgorithmKeyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlgorithmKeyOption left, AlgorithmKeyOption right) {
            return !(left == right);
        }
    
    }

}
