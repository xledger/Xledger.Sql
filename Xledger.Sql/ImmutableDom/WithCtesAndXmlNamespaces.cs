using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WithCtesAndXmlNamespaces : TSqlFragment, IEquatable<WithCtesAndXmlNamespaces> {
        XmlNamespaces xmlNamespaces;
        IReadOnlyList<CommonTableExpression> commonTableExpressions;
        ValueExpression changeTrackingContext;
    
        public XmlNamespaces XmlNamespaces => xmlNamespaces;
        public IReadOnlyList<CommonTableExpression> CommonTableExpressions => commonTableExpressions;
        public ValueExpression ChangeTrackingContext => changeTrackingContext;
    
        public WithCtesAndXmlNamespaces(XmlNamespaces xmlNamespaces = null, IReadOnlyList<CommonTableExpression> commonTableExpressions = null, ValueExpression changeTrackingContext = null) {
            this.xmlNamespaces = xmlNamespaces;
            this.commonTableExpressions = commonTableExpressions is null ? ImmList<CommonTableExpression>.Empty : ImmList<CommonTableExpression>.FromList(commonTableExpressions);
            this.changeTrackingContext = changeTrackingContext;
        }
    
        public ScriptDom.WithCtesAndXmlNamespaces ToMutableConcrete() {
            var ret = new ScriptDom.WithCtesAndXmlNamespaces();
            ret.XmlNamespaces = (ScriptDom.XmlNamespaces)xmlNamespaces.ToMutable();
            ret.CommonTableExpressions.AddRange(commonTableExpressions.Select(c => (ScriptDom.CommonTableExpression)c.ToMutable()));
            ret.ChangeTrackingContext = (ScriptDom.ValueExpression)changeTrackingContext.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(xmlNamespaces is null)) {
                h = h * 23 + xmlNamespaces.GetHashCode();
            }
            h = h * 23 + commonTableExpressions.GetHashCode();
            if (!(changeTrackingContext is null)) {
                h = h * 23 + changeTrackingContext.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WithCtesAndXmlNamespaces);
        } 
        
        public bool Equals(WithCtesAndXmlNamespaces other) {
            if (other is null) { return false; }
            if (!EqualityComparer<XmlNamespaces>.Default.Equals(other.XmlNamespaces, xmlNamespaces)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<CommonTableExpression>>.Default.Equals(other.CommonTableExpressions, commonTableExpressions)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.ChangeTrackingContext, changeTrackingContext)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WithCtesAndXmlNamespaces left, WithCtesAndXmlNamespaces right) {
            return EqualityComparer<WithCtesAndXmlNamespaces>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WithCtesAndXmlNamespaces left, WithCtesAndXmlNamespaces right) {
            return !(left == right);
        }
    
    }

}