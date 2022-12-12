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
                    var parent2 = (ExternalLibraryFileOption)parent;
                    if (Equals(parent2.Content, toReplace)) {
                        parent2.Content = replacement;
                        success = true;
                    }
                    break;
                }
                case 2: {
                    var parent2 = (ExternalLanguageFileOption)parent;
                    if (Equals(parent2.Content, toReplace)) {
                        parent2.Content = replacement;
                        success = true;
                    }
                    break;
                }
                case 3: {
                    var parent2 = (BoundingBoxParameter)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 4: {
                    var parent2 = (AlterFederationStatement)parent;
                    if (Equals(parent2.Boundary, toReplace)) {
                        parent2.Boundary = replacement;
                        success = true;
                    }
                    break;
                }
                case 5: {
                    var parent2 = (UseFederationStatement)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 6: {
                    var parent2 = (WindowDelimiter)parent;
                    if (Equals(parent2.OffsetValue, toReplace)) {
                        parent2.OffsetValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 7: {
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
                case 8: {
                    var parent2 = (CompressionDelayIndexOption)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 9: {
                    var parent2 = (EventDeclarationSetParameter)parent;
                    if (Equals(parent2.EventValue, toReplace)) {
                        parent2.EventValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 10: {
                    var parent2 = (EventDeclarationCompareFunctionParameter)parent;
                    if (Equals(parent2.EventValue, toReplace)) {
                        parent2.EventValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 11: {
                    var parent2 = (ReceiveStatement)parent;
                    if (Equals(parent2.Top, toReplace)) {
                        parent2.Top = replacement;
                        success = true;
                    }
                    break;
                }
                case 12: {
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
                case 13: {
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
                case 14: {
                    var parent2 = (ScalarExpressionDialogOption)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 15: {
                    var parent2 = (AlterPartitionFunctionStatement)parent;
                    if (Equals(parent2.Boundary, toReplace)) {
                        parent2.Boundary = replacement;
                        success = true;
                    }
                    break;
                }
                case 16: {
                    var parent2 = (RevertStatement)parent;
                    if (Equals(parent2.Cookie, toReplace)) {
                        parent2.Cookie = replacement;
                        success = true;
                    }
                    break;
                }
                case 17: {
                    var parent2 = (EndConversationStatement)parent;
                    if (Equals(parent2.Conversation, toReplace)) {
                        parent2.Conversation = replacement;
                        success = true;
                    }
                    break;
                }
                case 18: {
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
                case 19: {
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
                case 20: {
                    var parent2 = (BuiltInFunctionTableReference)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 21: {
                    var parent2 = (GlobalFunctionTableReference)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 22: {
                    var parent2 = (ComputeClause)parent;
                    for (var i = 0; i < parent2.ByExpressions.Count; i++) {
                        if (Equals(parent2.ByExpressions[i], toReplace)) {
                            parent2.ByExpressions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 23: {
                    var parent2 = (ComputeFunction)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 24: {
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
                case 25: {
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
                case 26: {
                    var parent2 = (BooleanIsNullExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 27: {
                    var parent2 = (ExpressionWithSortOrder)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 28: {
                    var parent2 = (ExpressionGroupingSpecification)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 29: {
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
                case 30: {
                    var parent2 = (PredictTableReference)parent;
                    if (Equals(parent2.ModelVariable, toReplace)) {
                        parent2.ModelVariable = replacement;
                        success = true;
                    }
                    break;
                }
                case 31: {
                    var parent2 = (SelectScalarExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 32: {
                    var parent2 = (SelectSetVariable)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 33: {
                    var parent2 = (ChangeTableVersionTableReference)parent;
                    for (var i = 0; i < parent2.PrimaryKeyValues.Count; i++) {
                        if (Equals(parent2.PrimaryKeyValues[i], toReplace)) {
                            parent2.PrimaryKeyValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 34: {
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
                case 35: {
                    var parent2 = (TopRowFilter)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 36: {
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
                case 37: {
                    var parent2 = (UnaryExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 38: {
                    var parent2 = (VariableMethodCallTableReference)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 39: {
                    var parent2 = (TablePartitionOptionSpecifications)parent;
                    for (var i = 0; i < parent2.BoundaryValues.Count; i++) {
                        if (Equals(parent2.BoundaryValues[i], toReplace)) {
                            parent2.BoundaryValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 40: {
                    var parent2 = (CopyColumnOption)parent;
                    if (Equals(parent2.DefaultValue, toReplace)) {
                        parent2.DefaultValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 41: {
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
                case 42: {
                    var parent2 = (DefaultConstraintDefinition)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 43: {
                    var parent2 = (ScalarExpressionRestoreOption)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 44: {
                    var parent2 = (BackupOption)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 45: {
                    var parent2 = (BackupEncryptionOption)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 46: {
                    var parent2 = (DbccNamedLiteral)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 47: {
                    var parent2 = (CreatePartitionFunctionStatement)parent;
                    for (var i = 0; i < parent2.BoundaryValues.Count; i++) {
                        if (Equals(parent2.BoundaryValues[i], toReplace)) {
                            parent2.BoundaryValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 48: {
                    var parent2 = (ColumnDefinition)parent;
                    if (Equals(parent2.ComputedColumnExpression, toReplace)) {
                        parent2.ComputedColumnExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 49: {
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
                case 50: {
                    var parent2 = (FetchType)parent;
                    if (Equals(parent2.RowOffset, toReplace)) {
                        parent2.RowOffset = replacement;
                        success = true;
                    }
                    break;
                }
                case 51: {
                    var parent2 = (RaiseErrorLegacyStatement)parent;
                    if (Equals(parent2.FirstParameter, toReplace)) {
                        parent2.FirstParameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 52: {
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
                case 53: {
                    var parent2 = (KillStatement)parent;
                    if (Equals(parent2.Parameter, toReplace)) {
                        parent2.Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 54: {
                    var parent2 = (KillStatsJobStatement)parent;
                    if (Equals(parent2.JobId, toReplace)) {
                        parent2.JobId = replacement;
                        success = true;
                    }
                    break;
                }
                case 55: {
                    var parent2 = (GeneralSetCommand)parent;
                    if (Equals(parent2.Parameter, toReplace)) {
                        parent2.Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 56: {
                    var parent2 = (SetTextSizeStatement)parent;
                    if (Equals(parent2.TextSize, toReplace)) {
                        parent2.TextSize = replacement;
                        success = true;
                    }
                    break;
                }
                case 57: {
                    var parent2 = (SetErrorLevelStatement)parent;
                    if (Equals(parent2.Level, toReplace)) {
                        parent2.Level = replacement;
                        success = true;
                    }
                    break;
                }
                case 58: {
                    var parent2 = (IndexExpressionOption)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 59: {
                    var parent2 = (ReturnStatement)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 60: {
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
                case 61: {
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
                case 62: {
                    var parent2 = (PartitionSpecifier)parent;
                    if (Equals(parent2.Number, toReplace)) {
                        parent2.Number = replacement;
                        success = true;
                    }
                    break;
                }
                case 63: {
                    var parent2 = (CreateAssemblyStatement)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 64: {
                    var parent2 = (AlterAssemblyStatement)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 65: {
                    var parent2 = (AddFileSpec)parent;
                    if (Equals(parent2.File, toReplace)) {
                        parent2.File = replacement;
                        success = true;
                    }
                    break;
                }
                case 66: {
                    var parent2 = (CreateXmlSchemaCollectionStatement)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 67: {
                    var parent2 = (AlterXmlSchemaCollectionStatement)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 68: {
                    var parent2 = (AlterTableAlterPartitionStatement)parent;
                    if (Equals(parent2.BoundaryValue, toReplace)) {
                        parent2.BoundaryValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 69: {
                    var parent2 = (AssignmentSetClause)parent;
                    if (Equals(parent2.NewValue, toReplace)) {
                        parent2.NewValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 70: {
                    var parent2 = (RowValue)parent;
                    for (var i = 0; i < parent2.ColumnValues.Count; i++) {
                        if (Equals(parent2.ColumnValues[i], toReplace)) {
                            parent2.ColumnValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 71: {
                    var parent2 = (PrintStatement)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 72: {
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
                case 73: {
                    var parent2 = (IdentifierOrScalarExpression)parent;
                    if (Equals(parent2.ScalarExpression, toReplace)) {
                        parent2.ScalarExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 74: {
                    var parent2 = (ParenthesisExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 75: {
                    var parent2 = (ScalarExpressionSequenceOption)parent;
                    if (Equals(parent2.OptionValue, toReplace)) {
                        parent2.OptionValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 76: {
                    var parent2 = (FunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 77: {
                    var parent2 = (ExpressionCallTarget)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 78: {
                    var parent2 = (LeftFunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 79: {
                    var parent2 = (RightFunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 80: {
                    var parent2 = (PartitionFunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 81: {
                    var parent2 = (OverClause)parent;
                    for (var i = 0; i < parent2.Partitions.Count; i++) {
                        if (Equals(parent2.Partitions[i], toReplace)) {
                            parent2.Partitions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 82: {
                    var parent2 = (WindowDefinition)parent;
                    for (var i = 0; i < parent2.Partitions.Count; i++) {
                        if (Equals(parent2.Partitions[i], toReplace)) {
                            parent2.Partitions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 83: {
                    var parent2 = (OdbcFunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 84: {
                    var parent2 = (ExtractFromExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 85: {
                    var parent2 = (CreateDefaultStatement)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 86: {
                    var parent2 = (DeclareVariableElement)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 87: {
                    var parent2 = (ProcedureParameter)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 88: {
                    var parent2 = (WaitForStatement)parent;
                    if (Equals(parent2.Timeout, toReplace)) {
                        parent2.Timeout = replacement;
                        success = true;
                    }
                    break;
                }
                case 89: {
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
                case 90: {
                    var parent2 = (SchemaObjectFunctionTableReference)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 91: {
                    var parent2 = (SubqueryComparisonPredicate)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 92: {
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
                case 93: {
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
                case 94: {
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
                case 95: {
                    var parent2 = (VariableValuePair)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 96: {
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
                case 97: {
                    var parent2 = (SearchedWhenClause)parent;
                    if (Equals(parent2.ThenExpression, toReplace)) {
                        parent2.ThenExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 98: {
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
                case 99: {
                    var parent2 = (SearchedCaseExpression)parent;
                    if (Equals(parent2.ElseExpression, toReplace)) {
                        parent2.ElseExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 100: {
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
                case 101: {
                    var parent2 = (CoalesceExpression)parent;
                    for (var i = 0; i < parent2.Expressions.Count; i++) {
                        if (Equals(parent2.Expressions[i], toReplace)) {
                            parent2.Expressions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 102: {
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
                case 103: {
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
                case 104: {
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
                case 105: {
                    var parent2 = (InternalOpenRowset)parent;
                    for (var i = 0; i < parent2.VarArgs.Count; i++) {
                        if (Equals(parent2.VarArgs[i], toReplace)) {
                            parent2.VarArgs[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 106: {
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
                case 107: {
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
                case 108: {
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
                case 109: {
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
                case 110: {
                    var parent2 = (CastCall)parent;
                    if (Equals(parent2.Parameter, toReplace)) {
                        parent2.Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 111: {
                    var parent2 = (TryCastCall)parent;
                    if (Equals(parent2.Parameter, toReplace)) {
                        parent2.Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 112: {
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
                case 113: {
                    var parent2 = (ExecuteContext)parent;
                    if (Equals(parent2.Principal, toReplace)) {
                        parent2.Principal = replacement;
                        success = true;
                    }
                    break;
                }
                case 114: {
                    var parent2 = (ExecuteParameter)parent;
                    if (Equals(parent2.ParameterValue, toReplace)) {
                        parent2.ParameterValue = replacement;
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
                [nameof(ExternalLibraryFileOption)] = 1,
                [nameof(ExternalLanguageFileOption)] = 2,
                [nameof(BoundingBoxParameter)] = 3,
                [nameof(AlterFederationStatement)] = 4,
                [nameof(UseFederationStatement)] = 5,
                [nameof(WindowDelimiter)] = 6,
                [nameof(TemporalClause)] = 7,
                [nameof(CompressionDelayIndexOption)] = 8,
                [nameof(EventDeclarationSetParameter)] = 9,
                [nameof(EventDeclarationCompareFunctionParameter)] = 10,
                [nameof(ReceiveStatement)] = 11,
                [nameof(SendStatement)] = 12,
                [nameof(BeginConversationTimerStatement)] = 13,
                [nameof(ScalarExpressionDialogOption)] = 14,
                [nameof(AlterPartitionFunctionStatement)] = 15,
                [nameof(RevertStatement)] = 16,
                [nameof(EndConversationStatement)] = 17,
                [nameof(MoveConversationStatement)] = 18,
                [nameof(BinaryExpression)] = 19,
                [nameof(BuiltInFunctionTableReference)] = 20,
                [nameof(GlobalFunctionTableReference)] = 21,
                [nameof(ComputeClause)] = 22,
                [nameof(ComputeFunction)] = 23,
                [nameof(TableSampleClause)] = 24,
                [nameof(BooleanComparisonExpression)] = 25,
                [nameof(BooleanIsNullExpression)] = 26,
                [nameof(ExpressionWithSortOrder)] = 27,
                [nameof(ExpressionGroupingSpecification)] = 28,
                [nameof(IdentityFunctionCall)] = 29,
                [nameof(PredictTableReference)] = 30,
                [nameof(SelectScalarExpression)] = 31,
                [nameof(SelectSetVariable)] = 32,
                [nameof(ChangeTableVersionTableReference)] = 33,
                [nameof(BooleanTernaryExpression)] = 34,
                [nameof(TopRowFilter)] = 35,
                [nameof(OffsetClause)] = 36,
                [nameof(UnaryExpression)] = 37,
                [nameof(VariableMethodCallTableReference)] = 38,
                [nameof(TablePartitionOptionSpecifications)] = 39,
                [nameof(CopyColumnOption)] = 40,
                [nameof(CompressionPartitionRange)] = 41,
                [nameof(DefaultConstraintDefinition)] = 42,
                [nameof(ScalarExpressionRestoreOption)] = 43,
                [nameof(BackupOption)] = 44,
                [nameof(BackupEncryptionOption)] = 45,
                [nameof(DbccNamedLiteral)] = 46,
                [nameof(CreatePartitionFunctionStatement)] = 47,
                [nameof(ColumnDefinition)] = 48,
                [nameof(IdentityOptions)] = 49,
                [nameof(FetchType)] = 50,
                [nameof(RaiseErrorLegacyStatement)] = 51,
                [nameof(RaiseErrorStatement)] = 52,
                [nameof(KillStatement)] = 53,
                [nameof(KillStatsJobStatement)] = 54,
                [nameof(GeneralSetCommand)] = 55,
                [nameof(SetTextSizeStatement)] = 56,
                [nameof(SetErrorLevelStatement)] = 57,
                [nameof(IndexExpressionOption)] = 58,
                [nameof(ReturnStatement)] = 59,
                [nameof(SetVariableStatement)] = 60,
                [nameof(AlterTableSwitchStatement)] = 61,
                [nameof(PartitionSpecifier)] = 62,
                [nameof(CreateAssemblyStatement)] = 63,
                [nameof(AlterAssemblyStatement)] = 64,
                [nameof(AddFileSpec)] = 65,
                [nameof(CreateXmlSchemaCollectionStatement)] = 66,
                [nameof(AlterXmlSchemaCollectionStatement)] = 67,
                [nameof(AlterTableAlterPartitionStatement)] = 68,
                [nameof(AssignmentSetClause)] = 69,
                [nameof(RowValue)] = 70,
                [nameof(PrintStatement)] = 71,
                [nameof(TSEqualCall)] = 72,
                [nameof(IdentifierOrScalarExpression)] = 73,
                [nameof(ParenthesisExpression)] = 74,
                [nameof(ScalarExpressionSequenceOption)] = 75,
                [nameof(FunctionCall)] = 76,
                [nameof(ExpressionCallTarget)] = 77,
                [nameof(LeftFunctionCall)] = 78,
                [nameof(RightFunctionCall)] = 79,
                [nameof(PartitionFunctionCall)] = 80,
                [nameof(OverClause)] = 81,
                [nameof(WindowDefinition)] = 82,
                [nameof(OdbcFunctionCall)] = 83,
                [nameof(ExtractFromExpression)] = 84,
                [nameof(CreateDefaultStatement)] = 85,
                [nameof(DeclareVariableElement)] = 86,
                [nameof(ProcedureParameter)] = 87,
                [nameof(WaitForStatement)] = 88,
                [nameof(UpdateTextStatement)] = 89,
                [nameof(SchemaObjectFunctionTableReference)] = 90,
                [nameof(SubqueryComparisonPredicate)] = 91,
                [nameof(LikePredicate)] = 92,
                [nameof(DistinctPredicate)] = 93,
                [nameof(InPredicate)] = 94,
                [nameof(VariableValuePair)] = 95,
                [nameof(SimpleWhenClause)] = 96,
                [nameof(SearchedWhenClause)] = 97,
                [nameof(SimpleCaseExpression)] = 98,
                [nameof(SearchedCaseExpression)] = 99,
                [nameof(NullIfExpression)] = 100,
                [nameof(CoalesceExpression)] = 101,
                [nameof(IIfCall)] = 102,
                [nameof(SemanticTableReference)] = 103,
                [nameof(OpenJsonTableReference)] = 104,
                [nameof(InternalOpenRowset)] = 105,
                [nameof(ConvertCall)] = 106,
                [nameof(TryConvertCall)] = 107,
                [nameof(ParseCall)] = 108,
                [nameof(TryParseCall)] = 109,
                [nameof(CastCall)] = 110,
                [nameof(TryCastCall)] = 111,
                [nameof(AtTimeZoneCall)] = 112,
                [nameof(ExecuteContext)] = 113,
                [nameof(ExecuteParameter)] = 114
            };

        internal static void AddRange<T>(this IList<T> @this, IEnumerable<T> xs) {
            foreach (var x in xs) { @this.Add(x); }
        }
    }
}