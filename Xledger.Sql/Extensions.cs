using System;
using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;
namespace Xledger.Sql {
    // GENERATED via script (Generate_ScopedFragmentTransformer.linq)
    // DO NOT EDIT DIRECTLY.
    public static class Extensions {
        public static bool ReplaceScalar(this TSqlFragment parent, ScalarExpression toReplace, ScalarExpression replacement) {
            var success = false;
            _ = ReplaceCaseNumberByType.TryGetValue(parent.GetType().Name, out var caseNum);
            switch (caseNum) {
                case 1: {
                    var parent2 = (AddFileSpec)parent;
                    if (Equals(parent2.File, toReplace)) {
                        parent2.File = replacement;
                        success = true;
                    }
                    break;
                }
                case 2: {
                    var parent2 = (AlterAssemblyStatement)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 3: {
                    var parent2 = (AlterFederationStatement)parent;
                    if (Equals(parent2.Boundary, toReplace)) {
                        parent2.Boundary = replacement;
                        success = true;
                    }
                    break;
                }
                case 4: {
                    var parent2 = (AlterPartitionFunctionStatement)parent;
                    if (Equals(parent2.Boundary, toReplace)) {
                        parent2.Boundary = replacement;
                        success = true;
                    }
                    break;
                }
                case 5: {
                    var parent2 = (AlterTableAlterPartitionStatement)parent;
                    if (Equals(parent2.BoundaryValue, toReplace)) {
                        parent2.BoundaryValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 6: {
                    var parent2 = (AlterTableSwitchStatement)parent;
                    if (Equals(parent2.SourcePartitionNumber, toReplace)) {
                        parent2.SourcePartitionNumber = replacement;
                        success = true;
                    }
                    if (Equals(parent2.TargetPartitionNumber, toReplace)) {
                        parent2.TargetPartitionNumber = replacement;
                        success = true;
                    }
                    break;
                }
                case 7: {
                    var parent2 = (AlterXmlSchemaCollectionStatement)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 8: {
                    var parent2 = (AssignmentSetClause)parent;
                    if (Equals(parent2.NewValue, toReplace)) {
                        parent2.NewValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 9: {
                    var parent2 = (AtTimeZoneCall)parent;
                    if (Equals(parent2.DateValue, toReplace)) {
                        parent2.DateValue = replacement;
                        success = true;
                    }
                    if (Equals(parent2.TimeZone, toReplace)) {
                        parent2.TimeZone = replacement;
                        success = true;
                    }
                    break;
                }
                case 10: {
                    var parent2 = (BackupEncryptionOption)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 11: {
                    var parent2 = (BackupOption)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 12: {
                    var parent2 = (BeginConversationTimerStatement)parent;
                    if (Equals(parent2.Handle, toReplace)) {
                        parent2.Handle = replacement;
                        success = true;
                    }
                    if (Equals(parent2.Timeout, toReplace)) {
                        parent2.Timeout = replacement;
                        success = true;
                    }
                    break;
                }
                case 13: {
                    var parent2 = (BinaryExpression)parent;
                    if (Equals(parent2.FirstExpression, toReplace)) {
                        parent2.FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals(parent2.SecondExpression, toReplace)) {
                        parent2.SecondExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 14: {
                    var parent2 = (BooleanComparisonExpression)parent;
                    if (Equals(parent2.FirstExpression, toReplace)) {
                        parent2.FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals(parent2.SecondExpression, toReplace)) {
                        parent2.SecondExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 15: {
                    var parent2 = (BooleanIsNullExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 16: {
                    var parent2 = (BooleanTernaryExpression)parent;
                    if (Equals(parent2.FirstExpression, toReplace)) {
                        parent2.FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals(parent2.SecondExpression, toReplace)) {
                        parent2.SecondExpression = replacement;
                        success = true;
                    }
                    if (Equals(parent2.ThirdExpression, toReplace)) {
                        parent2.ThirdExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 17: {
                    var parent2 = (BoundingBoxParameter)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 18: {
                    var parent2 = (BuiltInFunctionTableReference)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 19: {
                    var parent2 = (CastCall)parent;
                    if (Equals(parent2.Parameter, toReplace)) {
                        parent2.Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 20: {
                    var parent2 = (ChangeTableVersionTableReference)parent;
                    for (var i = 0; i < parent2.PrimaryKeyValues.Count; i++) {
                        if (Equals(parent2.PrimaryKeyValues[i], toReplace)) {
                            parent2.PrimaryKeyValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 21: {
                    var parent2 = (CoalesceExpression)parent;
                    for (var i = 0; i < parent2.Expressions.Count; i++) {
                        if (Equals(parent2.Expressions[i], toReplace)) {
                            parent2.Expressions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 22: {
                    var parent2 = (ColumnDefinition)parent;
                    if (Equals(parent2.ComputedColumnExpression, toReplace)) {
                        parent2.ComputedColumnExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 23: {
                    var parent2 = (CompressionDelayIndexOption)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 24: {
                    var parent2 = (CompressionPartitionRange)parent;
                    if (Equals(parent2.From, toReplace)) {
                        parent2.From = replacement;
                        success = true;
                    }
                    if (Equals(parent2.To, toReplace)) {
                        parent2.To = replacement;
                        success = true;
                    }
                    break;
                }
                case 25: {
                    var parent2 = (ComputeClause)parent;
                    for (var i = 0; i < parent2.ByExpressions.Count; i++) {
                        if (Equals(parent2.ByExpressions[i], toReplace)) {
                            parent2.ByExpressions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 26: {
                    var parent2 = (ComputeFunction)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 27: {
                    var parent2 = (ConvertCall)parent;
                    if (Equals(parent2.Parameter, toReplace)) {
                        parent2.Parameter = replacement;
                        success = true;
                    }
                    if (Equals(parent2.Style, toReplace)) {
                        parent2.Style = replacement;
                        success = true;
                    }
                    break;
                }
                case 28: {
                    var parent2 = (CopyColumnOption)parent;
                    if (Equals(parent2.DefaultValue, toReplace)) {
                        parent2.DefaultValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 29: {
                    var parent2 = (CreateAssemblyStatement)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 30: {
                    var parent2 = (CreateDefaultStatement)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 31: {
                    var parent2 = (CreatePartitionFunctionStatement)parent;
                    for (var i = 0; i < parent2.BoundaryValues.Count; i++) {
                        if (Equals(parent2.BoundaryValues[i], toReplace)) {
                            parent2.BoundaryValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 32: {
                    var parent2 = (CreateXmlSchemaCollectionStatement)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 33: {
                    var parent2 = (DbccNamedLiteral)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 34: {
                    var parent2 = (DeclareVariableElement)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 35: {
                    var parent2 = (DefaultConstraintDefinition)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 36: {
                    var parent2 = (DistinctPredicate)parent;
                    if (Equals(parent2.FirstExpression, toReplace)) {
                        parent2.FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals(parent2.SecondExpression, toReplace)) {
                        parent2.SecondExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 37: {
                    var parent2 = (EndConversationStatement)parent;
                    if (Equals(parent2.Conversation, toReplace)) {
                        parent2.Conversation = replacement;
                        success = true;
                    }
                    break;
                }
                case 38: {
                    var parent2 = (EventDeclarationCompareFunctionParameter)parent;
                    if (Equals(parent2.EventValue, toReplace)) {
                        parent2.EventValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 39: {
                    var parent2 = (EventDeclarationSetParameter)parent;
                    if (Equals(parent2.EventValue, toReplace)) {
                        parent2.EventValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 40: {
                    var parent2 = (ExecuteContext)parent;
                    if (Equals(parent2.Principal, toReplace)) {
                        parent2.Principal = replacement;
                        success = true;
                    }
                    break;
                }
                case 41: {
                    var parent2 = (ExecuteParameter)parent;
                    if (Equals(parent2.ParameterValue, toReplace)) {
                        parent2.ParameterValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 42: {
                    var parent2 = (ExpressionCallTarget)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 43: {
                    var parent2 = (ExpressionGroupingSpecification)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 44: {
                    var parent2 = (ExpressionWithSortOrder)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 45: {
                    var parent2 = (ExternalLanguageFileOption)parent;
                    if (Equals(parent2.Content, toReplace)) {
                        parent2.Content = replacement;
                        success = true;
                    }
                    break;
                }
                case 46: {
                    var parent2 = (ExternalLibraryFileOption)parent;
                    if (Equals(parent2.Content, toReplace)) {
                        parent2.Content = replacement;
                        success = true;
                    }
                    break;
                }
                case 47: {
                    var parent2 = (ExtractFromExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 48: {
                    var parent2 = (FetchType)parent;
                    if (Equals(parent2.RowOffset, toReplace)) {
                        parent2.RowOffset = replacement;
                        success = true;
                    }
                    break;
                }
                case 49: {
                    var parent2 = (FunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 50: {
                    var parent2 = (GeneralSetCommand)parent;
                    if (Equals(parent2.Parameter, toReplace)) {
                        parent2.Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 51: {
                    var parent2 = (GlobalFunctionTableReference)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 52: {
                    var parent2 = (IdentifierOrScalarExpression)parent;
                    if (Equals(parent2.ScalarExpression, toReplace)) {
                        parent2.ScalarExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 53: {
                    var parent2 = (IdentityFunctionCall)parent;
                    if (Equals(parent2.Seed, toReplace)) {
                        parent2.Seed = replacement;
                        success = true;
                    }
                    if (Equals(parent2.Increment, toReplace)) {
                        parent2.Increment = replacement;
                        success = true;
                    }
                    break;
                }
                case 54: {
                    var parent2 = (IdentityOptions)parent;
                    if (Equals(parent2.IdentitySeed, toReplace)) {
                        parent2.IdentitySeed = replacement;
                        success = true;
                    }
                    if (Equals(parent2.IdentityIncrement, toReplace)) {
                        parent2.IdentityIncrement = replacement;
                        success = true;
                    }
                    break;
                }
                case 55: {
                    var parent2 = (IIfCall)parent;
                    if (Equals(parent2.ThenExpression, toReplace)) {
                        parent2.ThenExpression = replacement;
                        success = true;
                    }
                    if (Equals(parent2.ElseExpression, toReplace)) {
                        parent2.ElseExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 56: {
                    var parent2 = (IndexExpressionOption)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 57: {
                    var parent2 = (InPredicate)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    for (var i = 0; i < parent2.Values.Count; i++) {
                        if (Equals(parent2.Values[i], toReplace)) {
                            parent2.Values[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 58: {
                    var parent2 = (InternalOpenRowset)parent;
                    for (var i = 0; i < parent2.VarArgs.Count; i++) {
                        if (Equals(parent2.VarArgs[i], toReplace)) {
                            parent2.VarArgs[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 59: {
                    var parent2 = (JsonKeyValue)parent;
                    if (Equals(parent2.JsonKeyName, toReplace)) {
                        parent2.JsonKeyName = replacement;
                        success = true;
                    }
                    if (Equals(parent2.JsonValue, toReplace)) {
                        parent2.JsonValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 60: {
                    var parent2 = (KillStatement)parent;
                    if (Equals(parent2.Parameter, toReplace)) {
                        parent2.Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 61: {
                    var parent2 = (KillStatsJobStatement)parent;
                    if (Equals(parent2.JobId, toReplace)) {
                        parent2.JobId = replacement;
                        success = true;
                    }
                    break;
                }
                case 62: {
                    var parent2 = (LeftFunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 63: {
                    var parent2 = (LikePredicate)parent;
                    if (Equals(parent2.FirstExpression, toReplace)) {
                        parent2.FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals(parent2.SecondExpression, toReplace)) {
                        parent2.SecondExpression = replacement;
                        success = true;
                    }
                    if (Equals(parent2.EscapeExpression, toReplace)) {
                        parent2.EscapeExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 64: {
                    var parent2 = (MoveConversationStatement)parent;
                    if (Equals(parent2.Conversation, toReplace)) {
                        parent2.Conversation = replacement;
                        success = true;
                    }
                    if (Equals(parent2.Group, toReplace)) {
                        parent2.Group = replacement;
                        success = true;
                    }
                    break;
                }
                case 65: {
                    var parent2 = (NullIfExpression)parent;
                    if (Equals(parent2.FirstExpression, toReplace)) {
                        parent2.FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals(parent2.SecondExpression, toReplace)) {
                        parent2.SecondExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 66: {
                    var parent2 = (OdbcFunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 67: {
                    var parent2 = (OffsetClause)parent;
                    if (Equals(parent2.OffsetExpression, toReplace)) {
                        parent2.OffsetExpression = replacement;
                        success = true;
                    }
                    if (Equals(parent2.FetchExpression, toReplace)) {
                        parent2.FetchExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 68: {
                    var parent2 = (OpenJsonTableReference)parent;
                    if (Equals(parent2.Variable, toReplace)) {
                        parent2.Variable = replacement;
                        success = true;
                    }
                    if (Equals(parent2.RowPattern, toReplace)) {
                        parent2.RowPattern = replacement;
                        success = true;
                    }
                    break;
                }
                case 69: {
                    var parent2 = (OverClause)parent;
                    for (var i = 0; i < parent2.Partitions.Count; i++) {
                        if (Equals(parent2.Partitions[i], toReplace)) {
                            parent2.Partitions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 70: {
                    var parent2 = (ParenthesisExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 71: {
                    var parent2 = (ParseCall)parent;
                    if (Equals(parent2.StringValue, toReplace)) {
                        parent2.StringValue = replacement;
                        success = true;
                    }
                    if (Equals(parent2.Culture, toReplace)) {
                        parent2.Culture = replacement;
                        success = true;
                    }
                    break;
                }
                case 72: {
                    var parent2 = (PartitionFunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 73: {
                    var parent2 = (PartitionSpecifier)parent;
                    if (Equals(parent2.Number, toReplace)) {
                        parent2.Number = replacement;
                        success = true;
                    }
                    break;
                }
                case 74: {
                    var parent2 = (PredictTableReference)parent;
                    if (Equals(parent2.ModelVariable, toReplace)) {
                        parent2.ModelVariable = replacement;
                        success = true;
                    }
                    break;
                }
                case 75: {
                    var parent2 = (PrintStatement)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 76: {
                    var parent2 = (ProcedureParameter)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 77: {
                    var parent2 = (RaiseErrorLegacyStatement)parent;
                    if (Equals(parent2.FirstParameter, toReplace)) {
                        parent2.FirstParameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 78: {
                    var parent2 = (RaiseErrorStatement)parent;
                    if (Equals(parent2.FirstParameter, toReplace)) {
                        parent2.FirstParameter = replacement;
                        success = true;
                    }
                    if (Equals(parent2.SecondParameter, toReplace)) {
                        parent2.SecondParameter = replacement;
                        success = true;
                    }
                    if (Equals(parent2.ThirdParameter, toReplace)) {
                        parent2.ThirdParameter = replacement;
                        success = true;
                    }
                    for (var i = 0; i < parent2.OptionalParameters.Count; i++) {
                        if (Equals(parent2.OptionalParameters[i], toReplace)) {
                            parent2.OptionalParameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 79: {
                    var parent2 = (ReceiveStatement)parent;
                    if (Equals(parent2.Top, toReplace)) {
                        parent2.Top = replacement;
                        success = true;
                    }
                    break;
                }
                case 80: {
                    var parent2 = (ReturnStatement)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 81: {
                    var parent2 = (RevertStatement)parent;
                    if (Equals(parent2.Cookie, toReplace)) {
                        parent2.Cookie = replacement;
                        success = true;
                    }
                    break;
                }
                case 82: {
                    var parent2 = (RightFunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 83: {
                    var parent2 = (RowValue)parent;
                    for (var i = 0; i < parent2.ColumnValues.Count; i++) {
                        if (Equals(parent2.ColumnValues[i], toReplace)) {
                            parent2.ColumnValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 84: {
                    var parent2 = (ScalarExpressionDialogOption)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 85: {
                    var parent2 = (ScalarExpressionRestoreOption)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 86: {
                    var parent2 = (ScalarExpressionSequenceOption)parent;
                    if (Equals(parent2.OptionValue, toReplace)) {
                        parent2.OptionValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 87: {
                    var parent2 = (SchemaObjectFunctionTableReference)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 88: {
                    var parent2 = (SearchedCaseExpression)parent;
                    if (Equals(parent2.ElseExpression, toReplace)) {
                        parent2.ElseExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 89: {
                    var parent2 = (SearchedWhenClause)parent;
                    if (Equals(parent2.ThenExpression, toReplace)) {
                        parent2.ThenExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 90: {
                    var parent2 = (SelectScalarExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 91: {
                    var parent2 = (SelectSetVariable)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 92: {
                    var parent2 = (SemanticTableReference)parent;
                    if (Equals(parent2.SourceKey, toReplace)) {
                        parent2.SourceKey = replacement;
                        success = true;
                    }
                    if (Equals(parent2.MatchedKey, toReplace)) {
                        parent2.MatchedKey = replacement;
                        success = true;
                    }
                    break;
                }
                case 93: {
                    var parent2 = (SendStatement)parent;
                    for (var i = 0; i < parent2.ConversationHandles.Count; i++) {
                        if (Equals(parent2.ConversationHandles[i], toReplace)) {
                            parent2.ConversationHandles[i] = replacement;
                            success = true;
                        }
                    }
                    if (Equals(parent2.MessageBody, toReplace)) {
                        parent2.MessageBody = replacement;
                        success = true;
                    }
                    break;
                }
                case 94: {
                    var parent2 = (SetErrorLevelStatement)parent;
                    if (Equals(parent2.Level, toReplace)) {
                        parent2.Level = replacement;
                        success = true;
                    }
                    break;
                }
                case 95: {
                    var parent2 = (SetTextSizeStatement)parent;
                    if (Equals(parent2.TextSize, toReplace)) {
                        parent2.TextSize = replacement;
                        success = true;
                    }
                    break;
                }
                case 96: {
                    var parent2 = (SetVariableStatement)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 97: {
                    var parent2 = (SimpleCaseExpression)parent;
                    if (Equals(parent2.InputExpression, toReplace)) {
                        parent2.InputExpression = replacement;
                        success = true;
                    }
                    if (Equals(parent2.ElseExpression, toReplace)) {
                        parent2.ElseExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 98: {
                    var parent2 = (SimpleWhenClause)parent;
                    if (Equals(parent2.WhenExpression, toReplace)) {
                        parent2.WhenExpression = replacement;
                        success = true;
                    }
                    if (Equals(parent2.ThenExpression, toReplace)) {
                        parent2.ThenExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 99: {
                    var parent2 = (SubqueryComparisonPredicate)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 100: {
                    var parent2 = (TablePartitionOptionSpecifications)parent;
                    for (var i = 0; i < parent2.BoundaryValues.Count; i++) {
                        if (Equals(parent2.BoundaryValues[i], toReplace)) {
                            parent2.BoundaryValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 101: {
                    var parent2 = (TableSampleClause)parent;
                    if (Equals(parent2.SampleNumber, toReplace)) {
                        parent2.SampleNumber = replacement;
                        success = true;
                    }
                    if (Equals(parent2.RepeatSeed, toReplace)) {
                        parent2.RepeatSeed = replacement;
                        success = true;
                    }
                    break;
                }
                case 102: {
                    var parent2 = (TemporalClause)parent;
                    if (Equals(parent2.StartTime, toReplace)) {
                        parent2.StartTime = replacement;
                        success = true;
                    }
                    if (Equals(parent2.EndTime, toReplace)) {
                        parent2.EndTime = replacement;
                        success = true;
                    }
                    break;
                }
                case 103: {
                    var parent2 = (TopRowFilter)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 104: {
                    var parent2 = (TryCastCall)parent;
                    if (Equals(parent2.Parameter, toReplace)) {
                        parent2.Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 105: {
                    var parent2 = (TryConvertCall)parent;
                    if (Equals(parent2.Parameter, toReplace)) {
                        parent2.Parameter = replacement;
                        success = true;
                    }
                    if (Equals(parent2.Style, toReplace)) {
                        parent2.Style = replacement;
                        success = true;
                    }
                    break;
                }
                case 106: {
                    var parent2 = (TryParseCall)parent;
                    if (Equals(parent2.StringValue, toReplace)) {
                        parent2.StringValue = replacement;
                        success = true;
                    }
                    if (Equals(parent2.Culture, toReplace)) {
                        parent2.Culture = replacement;
                        success = true;
                    }
                    break;
                }
                case 107: {
                    var parent2 = (TSEqualCall)parent;
                    if (Equals(parent2.FirstExpression, toReplace)) {
                        parent2.FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals(parent2.SecondExpression, toReplace)) {
                        parent2.SecondExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 108: {
                    var parent2 = (UnaryExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 109: {
                    var parent2 = (UpdateTextStatement)parent;
                    if (Equals(parent2.InsertOffset, toReplace)) {
                        parent2.InsertOffset = replacement;
                        success = true;
                    }
                    if (Equals(parent2.DeleteLength, toReplace)) {
                        parent2.DeleteLength = replacement;
                        success = true;
                    }
                    break;
                }
                case 110: {
                    var parent2 = (UseFederationStatement)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 111: {
                    var parent2 = (VariableMethodCallTableReference)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 112: {
                    var parent2 = (VariableValuePair)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 113: {
                    var parent2 = (WaitForStatement)parent;
                    if (Equals(parent2.Timeout, toReplace)) {
                        parent2.Timeout = replacement;
                        success = true;
                    }
                    break;
                }
                case 114: {
                    var parent2 = (WindowDefinition)parent;
                    for (var i = 0; i < parent2.Partitions.Count; i++) {
                        if (Equals(parent2.Partitions[i], toReplace)) {
                            parent2.Partitions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 115: {
                    var parent2 = (WindowDelimiter)parent;
                    if (Equals(parent2.OffsetValue, toReplace)) {
                        parent2.OffsetValue = replacement;
                        success = true;
                    }
                    break;
                }
                default: throw new NotImplementedException($"Type {parent.GetType().FullName} not implemented.");
            }
            return success;
        }

        static readonly IReadOnlyDictionary<string, int> ReplaceCaseNumberByType =
            new Dictionary<string, int> {
                [nameof(AddFileSpec)] = 1,
                [nameof(AlterAssemblyStatement)] = 2,
                [nameof(AlterFederationStatement)] = 3,
                [nameof(AlterPartitionFunctionStatement)] = 4,
                [nameof(AlterTableAlterPartitionStatement)] = 5,
                [nameof(AlterTableSwitchStatement)] = 6,
                [nameof(AlterXmlSchemaCollectionStatement)] = 7,
                [nameof(AssignmentSetClause)] = 8,
                [nameof(AtTimeZoneCall)] = 9,
                [nameof(BackupEncryptionOption)] = 10,
                [nameof(BackupOption)] = 11,
                [nameof(BeginConversationTimerStatement)] = 12,
                [nameof(BinaryExpression)] = 13,
                [nameof(BooleanComparisonExpression)] = 14,
                [nameof(BooleanIsNullExpression)] = 15,
                [nameof(BooleanTernaryExpression)] = 16,
                [nameof(BoundingBoxParameter)] = 17,
                [nameof(BuiltInFunctionTableReference)] = 18,
                [nameof(CastCall)] = 19,
                [nameof(ChangeTableVersionTableReference)] = 20,
                [nameof(CoalesceExpression)] = 21,
                [nameof(ColumnDefinition)] = 22,
                [nameof(CompressionDelayIndexOption)] = 23,
                [nameof(CompressionPartitionRange)] = 24,
                [nameof(ComputeClause)] = 25,
                [nameof(ComputeFunction)] = 26,
                [nameof(ConvertCall)] = 27,
                [nameof(CopyColumnOption)] = 28,
                [nameof(CreateAssemblyStatement)] = 29,
                [nameof(CreateDefaultStatement)] = 30,
                [nameof(CreatePartitionFunctionStatement)] = 31,
                [nameof(CreateXmlSchemaCollectionStatement)] = 32,
                [nameof(DbccNamedLiteral)] = 33,
                [nameof(DeclareVariableElement)] = 34,
                [nameof(DefaultConstraintDefinition)] = 35,
                [nameof(DistinctPredicate)] = 36,
                [nameof(EndConversationStatement)] = 37,
                [nameof(EventDeclarationCompareFunctionParameter)] = 38,
                [nameof(EventDeclarationSetParameter)] = 39,
                [nameof(ExecuteContext)] = 40,
                [nameof(ExecuteParameter)] = 41,
                [nameof(ExpressionCallTarget)] = 42,
                [nameof(ExpressionGroupingSpecification)] = 43,
                [nameof(ExpressionWithSortOrder)] = 44,
                [nameof(ExternalLanguageFileOption)] = 45,
                [nameof(ExternalLibraryFileOption)] = 46,
                [nameof(ExtractFromExpression)] = 47,
                [nameof(FetchType)] = 48,
                [nameof(FunctionCall)] = 49,
                [nameof(GeneralSetCommand)] = 50,
                [nameof(GlobalFunctionTableReference)] = 51,
                [nameof(IdentifierOrScalarExpression)] = 52,
                [nameof(IdentityFunctionCall)] = 53,
                [nameof(IdentityOptions)] = 54,
                [nameof(IIfCall)] = 55,
                [nameof(IndexExpressionOption)] = 56,
                [nameof(InPredicate)] = 57,
                [nameof(InternalOpenRowset)] = 58,
                [nameof(JsonKeyValue)] = 59,
                [nameof(KillStatement)] = 60,
                [nameof(KillStatsJobStatement)] = 61,
                [nameof(LeftFunctionCall)] = 62,
                [nameof(LikePredicate)] = 63,
                [nameof(MoveConversationStatement)] = 64,
                [nameof(NullIfExpression)] = 65,
                [nameof(OdbcFunctionCall)] = 66,
                [nameof(OffsetClause)] = 67,
                [nameof(OpenJsonTableReference)] = 68,
                [nameof(OverClause)] = 69,
                [nameof(ParenthesisExpression)] = 70,
                [nameof(ParseCall)] = 71,
                [nameof(PartitionFunctionCall)] = 72,
                [nameof(PartitionSpecifier)] = 73,
                [nameof(PredictTableReference)] = 74,
                [nameof(PrintStatement)] = 75,
                [nameof(ProcedureParameter)] = 76,
                [nameof(RaiseErrorLegacyStatement)] = 77,
                [nameof(RaiseErrorStatement)] = 78,
                [nameof(ReceiveStatement)] = 79,
                [nameof(ReturnStatement)] = 80,
                [nameof(RevertStatement)] = 81,
                [nameof(RightFunctionCall)] = 82,
                [nameof(RowValue)] = 83,
                [nameof(ScalarExpressionDialogOption)] = 84,
                [nameof(ScalarExpressionRestoreOption)] = 85,
                [nameof(ScalarExpressionSequenceOption)] = 86,
                [nameof(SchemaObjectFunctionTableReference)] = 87,
                [nameof(SearchedCaseExpression)] = 88,
                [nameof(SearchedWhenClause)] = 89,
                [nameof(SelectScalarExpression)] = 90,
                [nameof(SelectSetVariable)] = 91,
                [nameof(SemanticTableReference)] = 92,
                [nameof(SendStatement)] = 93,
                [nameof(SetErrorLevelStatement)] = 94,
                [nameof(SetTextSizeStatement)] = 95,
                [nameof(SetVariableStatement)] = 96,
                [nameof(SimpleCaseExpression)] = 97,
                [nameof(SimpleWhenClause)] = 98,
                [nameof(SubqueryComparisonPredicate)] = 99,
                [nameof(TablePartitionOptionSpecifications)] = 100,
                [nameof(TableSampleClause)] = 101,
                [nameof(TemporalClause)] = 102,
                [nameof(TopRowFilter)] = 103,
                [nameof(TryCastCall)] = 104,
                [nameof(TryConvertCall)] = 105,
                [nameof(TryParseCall)] = 106,
                [nameof(TSEqualCall)] = 107,
                [nameof(UnaryExpression)] = 108,
                [nameof(UpdateTextStatement)] = 109,
                [nameof(UseFederationStatement)] = 110,
                [nameof(VariableMethodCallTableReference)] = 111,
                [nameof(VariableValuePair)] = 112,
                [nameof(WaitForStatement)] = 113,
                [nameof(WindowDefinition)] = 114,
                [nameof(WindowDelimiter)] = 115
            };
    }
}