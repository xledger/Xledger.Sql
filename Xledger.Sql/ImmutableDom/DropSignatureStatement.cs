using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropSignatureStatement : SignatureStatementBase, IEquatable<DropSignatureStatement> {
        public DropSignatureStatement(bool isCounter = false, ScriptDom.SignableElementKind elementKind = ScriptDom.SignableElementKind.NotSpecified, SchemaObjectName element = null, IReadOnlyList<CryptoMechanism> cryptos = null) {
            this.isCounter = isCounter;
            this.elementKind = elementKind;
            this.element = element;
            this.cryptos = cryptos is null ? ImmList<CryptoMechanism>.Empty : ImmList<CryptoMechanism>.FromList(cryptos);
        }
    
        public ScriptDom.DropSignatureStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropSignatureStatement();
            ret.IsCounter = isCounter;
            ret.ElementKind = elementKind;
            ret.Element = (ScriptDom.SchemaObjectName)element.ToMutable();
            ret.Cryptos.AddRange(cryptos.SelectList(c => (ScriptDom.CryptoMechanism)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isCounter.GetHashCode();
            h = h * 23 + elementKind.GetHashCode();
            if (!(element is null)) {
                h = h * 23 + element.GetHashCode();
            }
            h = h * 23 + cryptos.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropSignatureStatement);
        } 
        
        public bool Equals(DropSignatureStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsCounter, isCounter)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SignableElementKind>.Default.Equals(other.ElementKind, elementKind)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Element, element)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<CryptoMechanism>>.Default.Equals(other.Cryptos, cryptos)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropSignatureStatement left, DropSignatureStatement right) {
            return EqualityComparer<DropSignatureStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropSignatureStatement left, DropSignatureStatement right) {
            return !(left == right);
        }
    
    }

}
