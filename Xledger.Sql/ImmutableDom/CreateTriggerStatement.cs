using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateTriggerStatement : TriggerStatementBody, IEquatable<CreateTriggerStatement> {
        public CreateTriggerStatement(SchemaObjectName name = null, TriggerObject triggerObject = null, IReadOnlyList<TriggerOption> options = null, ScriptDom.TriggerType triggerType = ScriptDom.TriggerType.Unknown, IReadOnlyList<TriggerAction> triggerActions = null, bool withAppend = false, bool isNotForReplication = false, StatementList statementList = null, MethodSpecifier methodSpecifier = null) {
            this.name = name;
            this.triggerObject = triggerObject;
            this.options = options is null ? ImmList<TriggerOption>.Empty : ImmList<TriggerOption>.FromList(options);
            this.triggerType = triggerType;
            this.triggerActions = triggerActions is null ? ImmList<TriggerAction>.Empty : ImmList<TriggerAction>.FromList(triggerActions);
            this.withAppend = withAppend;
            this.isNotForReplication = isNotForReplication;
            this.statementList = statementList;
            this.methodSpecifier = methodSpecifier;
        }
    
        public ScriptDom.CreateTriggerStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateTriggerStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            ret.TriggerObject = (ScriptDom.TriggerObject)triggerObject.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.TriggerOption)c.ToMutable()));
            ret.TriggerType = triggerType;
            ret.TriggerActions.AddRange(triggerActions.SelectList(c => (ScriptDom.TriggerAction)c.ToMutable()));
            ret.WithAppend = withAppend;
            ret.IsNotForReplication = isNotForReplication;
            ret.StatementList = (ScriptDom.StatementList)statementList.ToMutable();
            ret.MethodSpecifier = (ScriptDom.MethodSpecifier)methodSpecifier.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(triggerObject is null)) {
                h = h * 23 + triggerObject.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            h = h * 23 + triggerType.GetHashCode();
            h = h * 23 + triggerActions.GetHashCode();
            h = h * 23 + withAppend.GetHashCode();
            h = h * 23 + isNotForReplication.GetHashCode();
            if (!(statementList is null)) {
                h = h * 23 + statementList.GetHashCode();
            }
            if (!(methodSpecifier is null)) {
                h = h * 23 + methodSpecifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateTriggerStatement);
        } 
        
        public bool Equals(CreateTriggerStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<TriggerObject>.Default.Equals(other.TriggerObject, triggerObject)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<TriggerOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TriggerType>.Default.Equals(other.TriggerType, triggerType)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<TriggerAction>>.Default.Equals(other.TriggerActions, triggerActions)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithAppend, withAppend)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsNotForReplication, isNotForReplication)) {
                return false;
            }
            if (!EqualityComparer<StatementList>.Default.Equals(other.StatementList, statementList)) {
                return false;
            }
            if (!EqualityComparer<MethodSpecifier>.Default.Equals(other.MethodSpecifier, methodSpecifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateTriggerStatement left, CreateTriggerStatement right) {
            return EqualityComparer<CreateTriggerStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateTriggerStatement left, CreateTriggerStatement right) {
            return !(left == right);
        }
    
        public static CreateTriggerStatement FromMutable(ScriptDom.CreateTriggerStatement fragment) {
            return (CreateTriggerStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
