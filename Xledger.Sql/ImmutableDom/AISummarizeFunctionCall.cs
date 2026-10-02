using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AISummarizeFunctionCall : PrimaryExpression, IEquatable<AISummarizeFunctionCall> {
        protected ScalarExpression input;
    
        public ScalarExpression Input => input;
    
        public AISummarizeFunctionCall(ScalarExpression input = null, Identifier collation = null) {
            this.input = input;
            this.collation = collation;
        }
    
        public ScriptDom.AISummarizeFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.AISummarizeFunctionCall();
            ret.Input = (ScriptDom.ScalarExpression)input?.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(input is null)) {
                h = h * 23 + input.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AISummarizeFunctionCall);
        } 
        
        public bool Equals(AISummarizeFunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Input, input)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AISummarizeFunctionCall left, AISummarizeFunctionCall right) {
            return EqualityComparer<AISummarizeFunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AISummarizeFunctionCall left, AISummarizeFunctionCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AISummarizeFunctionCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.input, othr.input);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AISummarizeFunctionCall left, AISummarizeFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AISummarizeFunctionCall left, AISummarizeFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AISummarizeFunctionCall left, AISummarizeFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AISummarizeFunctionCall left, AISummarizeFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AISummarizeFunctionCall FromMutable(ScriptDom.AISummarizeFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AISummarizeFunctionCall)) { throw new NotImplementedException("Unexpected subtype of AISummarizeFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AISummarizeFunctionCall(
                input: ImmutableDom.ScalarExpression.FromMutable(fragment.Input),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
