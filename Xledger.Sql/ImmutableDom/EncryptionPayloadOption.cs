using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EncryptionPayloadOption : PayloadOption, IEquatable<EncryptionPayloadOption> {
        ScriptDom.EndpointEncryptionSupport encryptionSupport = ScriptDom.EndpointEncryptionSupport.NotSpecified;
        ScriptDom.EncryptionAlgorithmPreference algorithmPartOne = ScriptDom.EncryptionAlgorithmPreference.NotSpecified;
        ScriptDom.EncryptionAlgorithmPreference algorithmPartTwo = ScriptDom.EncryptionAlgorithmPreference.NotSpecified;
    
        public ScriptDom.EndpointEncryptionSupport EncryptionSupport => encryptionSupport;
        public ScriptDom.EncryptionAlgorithmPreference AlgorithmPartOne => algorithmPartOne;
        public ScriptDom.EncryptionAlgorithmPreference AlgorithmPartTwo => algorithmPartTwo;
    
        public EncryptionPayloadOption(ScriptDom.EndpointEncryptionSupport encryptionSupport = ScriptDom.EndpointEncryptionSupport.NotSpecified, ScriptDom.EncryptionAlgorithmPreference algorithmPartOne = ScriptDom.EncryptionAlgorithmPreference.NotSpecified, ScriptDom.EncryptionAlgorithmPreference algorithmPartTwo = ScriptDom.EncryptionAlgorithmPreference.NotSpecified, ScriptDom.PayloadOptionKinds kind = ScriptDom.PayloadOptionKinds.None) {
            this.encryptionSupport = encryptionSupport;
            this.algorithmPartOne = algorithmPartOne;
            this.algorithmPartTwo = algorithmPartTwo;
            this.kind = kind;
        }
    
        public ScriptDom.EncryptionPayloadOption ToMutableConcrete() {
            var ret = new ScriptDom.EncryptionPayloadOption();
            ret.EncryptionSupport = encryptionSupport;
            ret.AlgorithmPartOne = algorithmPartOne;
            ret.AlgorithmPartTwo = algorithmPartTwo;
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + encryptionSupport.GetHashCode();
            h = h * 23 + algorithmPartOne.GetHashCode();
            h = h * 23 + algorithmPartTwo.GetHashCode();
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EncryptionPayloadOption);
        } 
        
        public bool Equals(EncryptionPayloadOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.EndpointEncryptionSupport>.Default.Equals(other.EncryptionSupport, encryptionSupport)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.EncryptionAlgorithmPreference>.Default.Equals(other.AlgorithmPartOne, algorithmPartOne)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.EncryptionAlgorithmPreference>.Default.Equals(other.AlgorithmPartTwo, algorithmPartTwo)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PayloadOptionKinds>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EncryptionPayloadOption left, EncryptionPayloadOption right) {
            return EqualityComparer<EncryptionPayloadOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EncryptionPayloadOption left, EncryptionPayloadOption right) {
            return !(left == right);
        }
    
    }

}
