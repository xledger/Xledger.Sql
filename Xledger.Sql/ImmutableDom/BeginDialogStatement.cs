using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BeginDialogStatement : TSqlStatement, IEquatable<BeginDialogStatement> {
        protected bool isConversation = false;
        protected VariableReference handle;
        protected IdentifierOrValueExpression initiatorServiceName;
        protected ValueExpression targetServiceName;
        protected ValueExpression instanceSpec;
        protected IdentifierOrValueExpression contractName;
        protected IReadOnlyList<DialogOption> options;
    
        public bool IsConversation => isConversation;
        public VariableReference Handle => handle;
        public IdentifierOrValueExpression InitiatorServiceName => initiatorServiceName;
        public ValueExpression TargetServiceName => targetServiceName;
        public ValueExpression InstanceSpec => instanceSpec;
        public IdentifierOrValueExpression ContractName => contractName;
        public IReadOnlyList<DialogOption> Options => options;
    
        public BeginDialogStatement(bool isConversation = false, VariableReference handle = null, IdentifierOrValueExpression initiatorServiceName = null, ValueExpression targetServiceName = null, ValueExpression instanceSpec = null, IdentifierOrValueExpression contractName = null, IReadOnlyList<DialogOption> options = null) {
            this.isConversation = isConversation;
            this.handle = handle;
            this.initiatorServiceName = initiatorServiceName;
            this.targetServiceName = targetServiceName;
            this.instanceSpec = instanceSpec;
            this.contractName = contractName;
            this.options = ImmList<DialogOption>.FromList(options);
        }
    
        public ScriptDom.BeginDialogStatement ToMutableConcrete() {
            var ret = new ScriptDom.BeginDialogStatement();
            ret.IsConversation = isConversation;
            ret.Handle = (ScriptDom.VariableReference)handle.ToMutable();
            ret.InitiatorServiceName = (ScriptDom.IdentifierOrValueExpression)initiatorServiceName.ToMutable();
            ret.TargetServiceName = (ScriptDom.ValueExpression)targetServiceName.ToMutable();
            ret.InstanceSpec = (ScriptDom.ValueExpression)instanceSpec.ToMutable();
            ret.ContractName = (ScriptDom.IdentifierOrValueExpression)contractName.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.DialogOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isConversation.GetHashCode();
            if (!(handle is null)) {
                h = h * 23 + handle.GetHashCode();
            }
            if (!(initiatorServiceName is null)) {
                h = h * 23 + initiatorServiceName.GetHashCode();
            }
            if (!(targetServiceName is null)) {
                h = h * 23 + targetServiceName.GetHashCode();
            }
            if (!(instanceSpec is null)) {
                h = h * 23 + instanceSpec.GetHashCode();
            }
            if (!(contractName is null)) {
                h = h * 23 + contractName.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BeginDialogStatement);
        } 
        
        public bool Equals(BeginDialogStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsConversation, isConversation)) {
                return false;
            }
            if (!EqualityComparer<VariableReference>.Default.Equals(other.Handle, handle)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.InitiatorServiceName, initiatorServiceName)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.TargetServiceName, targetServiceName)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.InstanceSpec, instanceSpec)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.ContractName, contractName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<DialogOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BeginDialogStatement left, BeginDialogStatement right) {
            return EqualityComparer<BeginDialogStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BeginDialogStatement left, BeginDialogStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BeginDialogStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.isConversation, othr.isConversation);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.handle, othr.handle);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.initiatorServiceName, othr.initiatorServiceName);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.targetServiceName, othr.targetServiceName);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.instanceSpec, othr.instanceSpec);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.contractName, othr.contractName);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static BeginDialogStatement FromMutable(ScriptDom.BeginDialogStatement fragment) {
            return (BeginDialogStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
