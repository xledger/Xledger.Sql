using System;
using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;
namespace Xledger.Sql {
    // GENERATED via script (Generate_ReplaceScalar.linq)
    // DO NOT EDIT DIRECTLY.
    public static class Extensions {
        public static bool ReplaceScalar(this TSqlFragment parent, ScalarExpression toReplace, ScalarExpression replacement) {
            var success = false;
            _ = ReplaceCaseNumberByType.TryGetValue(parent.GetType().Name, out var caseNum);
            switch (caseNum) {
                case 1: {
                    if (Equals((parent as AddFileSpec).File, toReplace)) {
                        (parent as AddFileSpec).File = replacement;
                        success = true;
                    }
                    break;
                }
                case 2: {
                    for (var i = 0; i < (parent as AlterAssemblyStatement).Parameters.Count; i++) {
                        if (Equals((parent as AlterAssemblyStatement).Parameters[i], toReplace)) {
                            (parent as AlterAssemblyStatement).Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 3: {
                    if (Equals((parent as AlterFederationStatement).Boundary, toReplace)) {
                        (parent as AlterFederationStatement).Boundary = replacement;
                        success = true;
                    }
                    break;
                }
                case 4: {
                    if (Equals((parent as AlterPartitionFunctionStatement).Boundary, toReplace)) {
                        (parent as AlterPartitionFunctionStatement).Boundary = replacement;
                        success = true;
                    }
                    break;
                }
                case 5: {
                    if (Equals((parent as AlterTableAlterPartitionStatement).BoundaryValue, toReplace)) {
                        (parent as AlterTableAlterPartitionStatement).BoundaryValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 6: {
                    if (Equals((parent as AlterTableSwitchStatement).SourcePartitionNumber, toReplace)) {
                        (parent as AlterTableSwitchStatement).SourcePartitionNumber = replacement;
                        success = true;
                    }
                    if (Equals((parent as AlterTableSwitchStatement).TargetPartitionNumber, toReplace)) {
                        (parent as AlterTableSwitchStatement).TargetPartitionNumber = replacement;
                        success = true;
                    }
                    break;
                }
                case 7: {
                    if (Equals((parent as AlterXmlSchemaCollectionStatement).Expression, toReplace)) {
                        (parent as AlterXmlSchemaCollectionStatement).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 8: {
                    if (Equals((parent as AssignmentSetClause).NewValue, toReplace)) {
                        (parent as AssignmentSetClause).NewValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 9: {
                    if (Equals((parent as AtTimeZoneCall).DateValue, toReplace)) {
                        (parent as AtTimeZoneCall).DateValue = replacement;
                        success = true;
                    }
                    if (Equals((parent as AtTimeZoneCall).TimeZone, toReplace)) {
                        (parent as AtTimeZoneCall).TimeZone = replacement;
                        success = true;
                    }
                    break;
                }
                case 10: {
                    if (Equals((parent as BackupEncryptionOption).Value, toReplace)) {
                        (parent as BackupEncryptionOption).Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 11: {
                    if (Equals((parent as BackupOption).Value, toReplace)) {
                        (parent as BackupOption).Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 12: {
                    if (Equals((parent as BeginConversationTimerStatement).Handle, toReplace)) {
                        (parent as BeginConversationTimerStatement).Handle = replacement;
                        success = true;
                    }
                    if (Equals((parent as BeginConversationTimerStatement).Timeout, toReplace)) {
                        (parent as BeginConversationTimerStatement).Timeout = replacement;
                        success = true;
                    }
                    break;
                }
                case 13: {
                    if (Equals((parent as BinaryExpression).FirstExpression, toReplace)) {
                        (parent as BinaryExpression).FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals((parent as BinaryExpression).SecondExpression, toReplace)) {
                        (parent as BinaryExpression).SecondExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 14: {
                    if (Equals((parent as BooleanComparisonExpression).FirstExpression, toReplace)) {
                        (parent as BooleanComparisonExpression).FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals((parent as BooleanComparisonExpression).SecondExpression, toReplace)) {
                        (parent as BooleanComparisonExpression).SecondExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 15: {
                    if (Equals((parent as BooleanIsNullExpression).Expression, toReplace)) {
                        (parent as BooleanIsNullExpression).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 16: {
                    if (Equals((parent as BooleanTernaryExpression).FirstExpression, toReplace)) {
                        (parent as BooleanTernaryExpression).FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals((parent as BooleanTernaryExpression).SecondExpression, toReplace)) {
                        (parent as BooleanTernaryExpression).SecondExpression = replacement;
                        success = true;
                    }
                    if (Equals((parent as BooleanTernaryExpression).ThirdExpression, toReplace)) {
                        (parent as BooleanTernaryExpression).ThirdExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 17: {
                    if (Equals((parent as BoundingBoxParameter).Value, toReplace)) {
                        (parent as BoundingBoxParameter).Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 18: {
                    for (var i = 0; i < (parent as BuiltInFunctionTableReference).Parameters.Count; i++) {
                        if (Equals((parent as BuiltInFunctionTableReference).Parameters[i], toReplace)) {
                            (parent as BuiltInFunctionTableReference).Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 19: {
                    if (Equals((parent as CastCall).Parameter, toReplace)) {
                        (parent as CastCall).Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 20: {
                    for (var i = 0; i < (parent as ChangeTableVersionTableReference).PrimaryKeyValues.Count; i++) {
                        if (Equals((parent as ChangeTableVersionTableReference).PrimaryKeyValues[i], toReplace)) {
                            (parent as ChangeTableVersionTableReference).PrimaryKeyValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 21: {
                    for (var i = 0; i < (parent as CoalesceExpression).Expressions.Count; i++) {
                        if (Equals((parent as CoalesceExpression).Expressions[i], toReplace)) {
                            (parent as CoalesceExpression).Expressions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 22: {
                    if (Equals((parent as ColumnDefinition).ComputedColumnExpression, toReplace)) {
                        (parent as ColumnDefinition).ComputedColumnExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 23: {
                    if (Equals((parent as CompressionDelayIndexOption).Expression, toReplace)) {
                        (parent as CompressionDelayIndexOption).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 24: {
                    if (Equals((parent as CompressionPartitionRange).From, toReplace)) {
                        (parent as CompressionPartitionRange).From = replacement;
                        success = true;
                    }
                    if (Equals((parent as CompressionPartitionRange).To, toReplace)) {
                        (parent as CompressionPartitionRange).To = replacement;
                        success = true;
                    }
                    break;
                }
                case 25: {
                    for (var i = 0; i < (parent as ComputeClause).ByExpressions.Count; i++) {
                        if (Equals((parent as ComputeClause).ByExpressions[i], toReplace)) {
                            (parent as ComputeClause).ByExpressions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 26: {
                    if (Equals((parent as ComputeFunction).Expression, toReplace)) {
                        (parent as ComputeFunction).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 27: {
                    if (Equals((parent as ConvertCall).Parameter, toReplace)) {
                        (parent as ConvertCall).Parameter = replacement;
                        success = true;
                    }
                    if (Equals((parent as ConvertCall).Style, toReplace)) {
                        (parent as ConvertCall).Style = replacement;
                        success = true;
                    }
                    break;
                }
                case 28: {
                    if (Equals((parent as CopyColumnOption).DefaultValue, toReplace)) {
                        (parent as CopyColumnOption).DefaultValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 29: {
                    for (var i = 0; i < (parent as CreateAssemblyStatement).Parameters.Count; i++) {
                        if (Equals((parent as CreateAssemblyStatement).Parameters[i], toReplace)) {
                            (parent as CreateAssemblyStatement).Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 30: {
                    if (Equals((parent as CreateDefaultStatement).Expression, toReplace)) {
                        (parent as CreateDefaultStatement).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 31: {
                    for (var i = 0; i < (parent as CreatePartitionFunctionStatement).BoundaryValues.Count; i++) {
                        if (Equals((parent as CreatePartitionFunctionStatement).BoundaryValues[i], toReplace)) {
                            (parent as CreatePartitionFunctionStatement).BoundaryValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 32: {
                    if (Equals((parent as CreateXmlSchemaCollectionStatement).Expression, toReplace)) {
                        (parent as CreateXmlSchemaCollectionStatement).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 33: {
                    if (Equals((parent as DbccNamedLiteral).Value, toReplace)) {
                        (parent as DbccNamedLiteral).Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 34: {
                    if (Equals((parent as DeclareVariableElement).Value, toReplace)) {
                        (parent as DeclareVariableElement).Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 35: {
                    if (Equals((parent as DefaultConstraintDefinition).Expression, toReplace)) {
                        (parent as DefaultConstraintDefinition).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 36: {
                    if (Equals((parent as DistinctPredicate).FirstExpression, toReplace)) {
                        (parent as DistinctPredicate).FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals((parent as DistinctPredicate).SecondExpression, toReplace)) {
                        (parent as DistinctPredicate).SecondExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 37: {
                    if (Equals((parent as EndConversationStatement).Conversation, toReplace)) {
                        (parent as EndConversationStatement).Conversation = replacement;
                        success = true;
                    }
                    break;
                }
                case 38: {
                    if (Equals((parent as EventDeclarationCompareFunctionParameter).EventValue, toReplace)) {
                        (parent as EventDeclarationCompareFunctionParameter).EventValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 39: {
                    if (Equals((parent as EventDeclarationSetParameter).EventValue, toReplace)) {
                        (parent as EventDeclarationSetParameter).EventValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 40: {
                    if (Equals((parent as ExecuteContext).Principal, toReplace)) {
                        (parent as ExecuteContext).Principal = replacement;
                        success = true;
                    }
                    break;
                }
                case 41: {
                    if (Equals((parent as ExecuteParameter).ParameterValue, toReplace)) {
                        (parent as ExecuteParameter).ParameterValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 42: {
                    if (Equals((parent as ExpressionCallTarget).Expression, toReplace)) {
                        (parent as ExpressionCallTarget).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 43: {
                    if (Equals((parent as ExpressionGroupingSpecification).Expression, toReplace)) {
                        (parent as ExpressionGroupingSpecification).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 44: {
                    if (Equals((parent as ExpressionWithSortOrder).Expression, toReplace)) {
                        (parent as ExpressionWithSortOrder).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 45: {
                    if (Equals((parent as ExternalLanguageFileOption).Content, toReplace)) {
                        (parent as ExternalLanguageFileOption).Content = replacement;
                        success = true;
                    }
                    break;
                }
                case 46: {
                    if (Equals((parent as ExternalLibraryFileOption).Content, toReplace)) {
                        (parent as ExternalLibraryFileOption).Content = replacement;
                        success = true;
                    }
                    break;
                }
                case 47: {
                    if (Equals((parent as ExtractFromExpression).Expression, toReplace)) {
                        (parent as ExtractFromExpression).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 48: {
                    if (Equals((parent as FetchType).RowOffset, toReplace)) {
                        (parent as FetchType).RowOffset = replacement;
                        success = true;
                    }
                    break;
                }
                case 49: {
                    for (var i = 0; i < (parent as FunctionCall).Parameters.Count; i++) {
                        if (Equals((parent as FunctionCall).Parameters[i], toReplace)) {
                            (parent as FunctionCall).Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 50: {
                    if (Equals((parent as GeneralSetCommand).Parameter, toReplace)) {
                        (parent as GeneralSetCommand).Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 51: {
                    for (var i = 0; i < (parent as GlobalFunctionTableReference).Parameters.Count; i++) {
                        if (Equals((parent as GlobalFunctionTableReference).Parameters[i], toReplace)) {
                            (parent as GlobalFunctionTableReference).Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 52: {
                    if (Equals((parent as IdentifierOrScalarExpression).ScalarExpression, toReplace)) {
                        (parent as IdentifierOrScalarExpression).ScalarExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 53: {
                    if (Equals((parent as IdentityFunctionCall).Seed, toReplace)) {
                        (parent as IdentityFunctionCall).Seed = replacement;
                        success = true;
                    }
                    if (Equals((parent as IdentityFunctionCall).Increment, toReplace)) {
                        (parent as IdentityFunctionCall).Increment = replacement;
                        success = true;
                    }
                    break;
                }
                case 54: {
                    if (Equals((parent as IdentityOptions).IdentitySeed, toReplace)) {
                        (parent as IdentityOptions).IdentitySeed = replacement;
                        success = true;
                    }
                    if (Equals((parent as IdentityOptions).IdentityIncrement, toReplace)) {
                        (parent as IdentityOptions).IdentityIncrement = replacement;
                        success = true;
                    }
                    break;
                }
                case 55: {
                    if (Equals((parent as IIfCall).ThenExpression, toReplace)) {
                        (parent as IIfCall).ThenExpression = replacement;
                        success = true;
                    }
                    if (Equals((parent as IIfCall).ElseExpression, toReplace)) {
                        (parent as IIfCall).ElseExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 56: {
                    if (Equals((parent as IndexExpressionOption).Expression, toReplace)) {
                        (parent as IndexExpressionOption).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 57: {
                    if (Equals((parent as InPredicate).Expression, toReplace)) {
                        (parent as InPredicate).Expression = replacement;
                        success = true;
                    }
                    for (var i = 0; i < (parent as InPredicate).Values.Count; i++) {
                        if (Equals((parent as InPredicate).Values[i], toReplace)) {
                            (parent as InPredicate).Values[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 58: {
                    for (var i = 0; i < (parent as InternalOpenRowset).VarArgs.Count; i++) {
                        if (Equals((parent as InternalOpenRowset).VarArgs[i], toReplace)) {
                            (parent as InternalOpenRowset).VarArgs[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 59: {
                    if (Equals((parent as JsonKeyValue).JsonKeyName, toReplace)) {
                        (parent as JsonKeyValue).JsonKeyName = replacement;
                        success = true;
                    }
                    if (Equals((parent as JsonKeyValue).JsonValue, toReplace)) {
                        (parent as JsonKeyValue).JsonValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 60: {
                    if (Equals((parent as KillStatement).Parameter, toReplace)) {
                        (parent as KillStatement).Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 61: {
                    if (Equals((parent as KillStatsJobStatement).JobId, toReplace)) {
                        (parent as KillStatsJobStatement).JobId = replacement;
                        success = true;
                    }
                    break;
                }
                case 62: {
                    for (var i = 0; i < (parent as LeftFunctionCall).Parameters.Count; i++) {
                        if (Equals((parent as LeftFunctionCall).Parameters[i], toReplace)) {
                            (parent as LeftFunctionCall).Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 63: {
                    if (Equals((parent as LikePredicate).FirstExpression, toReplace)) {
                        (parent as LikePredicate).FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals((parent as LikePredicate).SecondExpression, toReplace)) {
                        (parent as LikePredicate).SecondExpression = replacement;
                        success = true;
                    }
                    if (Equals((parent as LikePredicate).EscapeExpression, toReplace)) {
                        (parent as LikePredicate).EscapeExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 64: {
                    if (Equals((parent as MoveConversationStatement).Conversation, toReplace)) {
                        (parent as MoveConversationStatement).Conversation = replacement;
                        success = true;
                    }
                    if (Equals((parent as MoveConversationStatement).Group, toReplace)) {
                        (parent as MoveConversationStatement).Group = replacement;
                        success = true;
                    }
                    break;
                }
                case 65: {
                    if (Equals((parent as NullIfExpression).FirstExpression, toReplace)) {
                        (parent as NullIfExpression).FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals((parent as NullIfExpression).SecondExpression, toReplace)) {
                        (parent as NullIfExpression).SecondExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 66: {
                    for (var i = 0; i < (parent as OdbcFunctionCall).Parameters.Count; i++) {
                        if (Equals((parent as OdbcFunctionCall).Parameters[i], toReplace)) {
                            (parent as OdbcFunctionCall).Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 67: {
                    if (Equals((parent as OffsetClause).OffsetExpression, toReplace)) {
                        (parent as OffsetClause).OffsetExpression = replacement;
                        success = true;
                    }
                    if (Equals((parent as OffsetClause).FetchExpression, toReplace)) {
                        (parent as OffsetClause).FetchExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 68: {
                    if (Equals((parent as OpenJsonTableReference).Variable, toReplace)) {
                        (parent as OpenJsonTableReference).Variable = replacement;
                        success = true;
                    }
                    if (Equals((parent as OpenJsonTableReference).RowPattern, toReplace)) {
                        (parent as OpenJsonTableReference).RowPattern = replacement;
                        success = true;
                    }
                    break;
                }
                case 69: {
                    for (var i = 0; i < (parent as OverClause).Partitions.Count; i++) {
                        if (Equals((parent as OverClause).Partitions[i], toReplace)) {
                            (parent as OverClause).Partitions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 70: {
                    if (Equals((parent as ParenthesisExpression).Expression, toReplace)) {
                        (parent as ParenthesisExpression).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 71: {
                    if (Equals((parent as ParseCall).StringValue, toReplace)) {
                        (parent as ParseCall).StringValue = replacement;
                        success = true;
                    }
                    if (Equals((parent as ParseCall).Culture, toReplace)) {
                        (parent as ParseCall).Culture = replacement;
                        success = true;
                    }
                    break;
                }
                case 72: {
                    for (var i = 0; i < (parent as PartitionFunctionCall).Parameters.Count; i++) {
                        if (Equals((parent as PartitionFunctionCall).Parameters[i], toReplace)) {
                            (parent as PartitionFunctionCall).Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 73: {
                    if (Equals((parent as PartitionSpecifier).Number, toReplace)) {
                        (parent as PartitionSpecifier).Number = replacement;
                        success = true;
                    }
                    break;
                }
                case 74: {
                    if (Equals((parent as PredictTableReference).ModelVariable, toReplace)) {
                        (parent as PredictTableReference).ModelVariable = replacement;
                        success = true;
                    }
                    break;
                }
                case 75: {
                    if (Equals((parent as PrintStatement).Expression, toReplace)) {
                        (parent as PrintStatement).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 76: {
                    if (Equals((parent as ProcedureParameter).Value, toReplace)) {
                        (parent as ProcedureParameter).Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 77: {
                    if (Equals((parent as RaiseErrorLegacyStatement).FirstParameter, toReplace)) {
                        (parent as RaiseErrorLegacyStatement).FirstParameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 78: {
                    if (Equals((parent as RaiseErrorStatement).FirstParameter, toReplace)) {
                        (parent as RaiseErrorStatement).FirstParameter = replacement;
                        success = true;
                    }
                    if (Equals((parent as RaiseErrorStatement).SecondParameter, toReplace)) {
                        (parent as RaiseErrorStatement).SecondParameter = replacement;
                        success = true;
                    }
                    if (Equals((parent as RaiseErrorStatement).ThirdParameter, toReplace)) {
                        (parent as RaiseErrorStatement).ThirdParameter = replacement;
                        success = true;
                    }
                    for (var i = 0; i < (parent as RaiseErrorStatement).OptionalParameters.Count; i++) {
                        if (Equals((parent as RaiseErrorStatement).OptionalParameters[i], toReplace)) {
                            (parent as RaiseErrorStatement).OptionalParameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 79: {
                    if (Equals((parent as ReceiveStatement).Top, toReplace)) {
                        (parent as ReceiveStatement).Top = replacement;
                        success = true;
                    }
                    break;
                }
                case 80: {
                    if (Equals((parent as ReturnStatement).Expression, toReplace)) {
                        (parent as ReturnStatement).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 81: {
                    if (Equals((parent as RevertStatement).Cookie, toReplace)) {
                        (parent as RevertStatement).Cookie = replacement;
                        success = true;
                    }
                    break;
                }
                case 82: {
                    for (var i = 0; i < (parent as RightFunctionCall).Parameters.Count; i++) {
                        if (Equals((parent as RightFunctionCall).Parameters[i], toReplace)) {
                            (parent as RightFunctionCall).Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 83: {
                    for (var i = 0; i < (parent as RowValue).ColumnValues.Count; i++) {
                        if (Equals((parent as RowValue).ColumnValues[i], toReplace)) {
                            (parent as RowValue).ColumnValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 84: {
                    if (Equals((parent as ScalarExpressionDialogOption).Value, toReplace)) {
                        (parent as ScalarExpressionDialogOption).Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 85: {
                    if (Equals((parent as ScalarExpressionRestoreOption).Value, toReplace)) {
                        (parent as ScalarExpressionRestoreOption).Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 86: {
                    if (Equals((parent as ScalarExpressionSequenceOption).OptionValue, toReplace)) {
                        (parent as ScalarExpressionSequenceOption).OptionValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 87: {
                    for (var i = 0; i < (parent as SchemaObjectFunctionTableReference).Parameters.Count; i++) {
                        if (Equals((parent as SchemaObjectFunctionTableReference).Parameters[i], toReplace)) {
                            (parent as SchemaObjectFunctionTableReference).Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 88: {
                    if (Equals((parent as SearchedCaseExpression).ElseExpression, toReplace)) {
                        (parent as SearchedCaseExpression).ElseExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 89: {
                    if (Equals((parent as SearchedWhenClause).ThenExpression, toReplace)) {
                        (parent as SearchedWhenClause).ThenExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 90: {
                    if (Equals((parent as SelectScalarExpression).Expression, toReplace)) {
                        (parent as SelectScalarExpression).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 91: {
                    if (Equals((parent as SelectSetVariable).Expression, toReplace)) {
                        (parent as SelectSetVariable).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 92: {
                    if (Equals((parent as SemanticTableReference).SourceKey, toReplace)) {
                        (parent as SemanticTableReference).SourceKey = replacement;
                        success = true;
                    }
                    if (Equals((parent as SemanticTableReference).MatchedKey, toReplace)) {
                        (parent as SemanticTableReference).MatchedKey = replacement;
                        success = true;
                    }
                    break;
                }
                case 93: {
                    for (var i = 0; i < (parent as SendStatement).ConversationHandles.Count; i++) {
                        if (Equals((parent as SendStatement).ConversationHandles[i], toReplace)) {
                            (parent as SendStatement).ConversationHandles[i] = replacement;
                            success = true;
                        }
                    }
                    if (Equals((parent as SendStatement).MessageBody, toReplace)) {
                        (parent as SendStatement).MessageBody = replacement;
                        success = true;
                    }
                    break;
                }
                case 94: {
                    if (Equals((parent as SetErrorLevelStatement).Level, toReplace)) {
                        (parent as SetErrorLevelStatement).Level = replacement;
                        success = true;
                    }
                    break;
                }
                case 95: {
                    if (Equals((parent as SetTextSizeStatement).TextSize, toReplace)) {
                        (parent as SetTextSizeStatement).TextSize = replacement;
                        success = true;
                    }
                    break;
                }
                case 96: {
                    for (var i = 0; i < (parent as SetVariableStatement).Parameters.Count; i++) {
                        if (Equals((parent as SetVariableStatement).Parameters[i], toReplace)) {
                            (parent as SetVariableStatement).Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    if (Equals((parent as SetVariableStatement).Expression, toReplace)) {
                        (parent as SetVariableStatement).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 97: {
                    if (Equals((parent as SimpleCaseExpression).InputExpression, toReplace)) {
                        (parent as SimpleCaseExpression).InputExpression = replacement;
                        success = true;
                    }
                    if (Equals((parent as SimpleCaseExpression).ElseExpression, toReplace)) {
                        (parent as SimpleCaseExpression).ElseExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 98: {
                    if (Equals((parent as SimpleWhenClause).WhenExpression, toReplace)) {
                        (parent as SimpleWhenClause).WhenExpression = replacement;
                        success = true;
                    }
                    if (Equals((parent as SimpleWhenClause).ThenExpression, toReplace)) {
                        (parent as SimpleWhenClause).ThenExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 99: {
                    if (Equals((parent as SubqueryComparisonPredicate).Expression, toReplace)) {
                        (parent as SubqueryComparisonPredicate).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 100: {
                    for (var i = 0; i < (parent as TablePartitionOptionSpecifications).BoundaryValues.Count; i++) {
                        if (Equals((parent as TablePartitionOptionSpecifications).BoundaryValues[i], toReplace)) {
                            (parent as TablePartitionOptionSpecifications).BoundaryValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 101: {
                    if (Equals((parent as TableSampleClause).SampleNumber, toReplace)) {
                        (parent as TableSampleClause).SampleNumber = replacement;
                        success = true;
                    }
                    if (Equals((parent as TableSampleClause).RepeatSeed, toReplace)) {
                        (parent as TableSampleClause).RepeatSeed = replacement;
                        success = true;
                    }
                    break;
                }
                case 102: {
                    if (Equals((parent as TemporalClause).StartTime, toReplace)) {
                        (parent as TemporalClause).StartTime = replacement;
                        success = true;
                    }
                    if (Equals((parent as TemporalClause).EndTime, toReplace)) {
                        (parent as TemporalClause).EndTime = replacement;
                        success = true;
                    }
                    break;
                }
                case 103: {
                    if (Equals((parent as TopRowFilter).Expression, toReplace)) {
                        (parent as TopRowFilter).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 104: {
                    if (Equals((parent as TryCastCall).Parameter, toReplace)) {
                        (parent as TryCastCall).Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 105: {
                    if (Equals((parent as TryConvertCall).Parameter, toReplace)) {
                        (parent as TryConvertCall).Parameter = replacement;
                        success = true;
                    }
                    if (Equals((parent as TryConvertCall).Style, toReplace)) {
                        (parent as TryConvertCall).Style = replacement;
                        success = true;
                    }
                    break;
                }
                case 106: {
                    if (Equals((parent as TryParseCall).StringValue, toReplace)) {
                        (parent as TryParseCall).StringValue = replacement;
                        success = true;
                    }
                    if (Equals((parent as TryParseCall).Culture, toReplace)) {
                        (parent as TryParseCall).Culture = replacement;
                        success = true;
                    }
                    break;
                }
                case 107: {
                    if (Equals((parent as TSEqualCall).FirstExpression, toReplace)) {
                        (parent as TSEqualCall).FirstExpression = replacement;
                        success = true;
                    }
                    if (Equals((parent as TSEqualCall).SecondExpression, toReplace)) {
                        (parent as TSEqualCall).SecondExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 108: {
                    if (Equals((parent as UnaryExpression).Expression, toReplace)) {
                        (parent as UnaryExpression).Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 109: {
                    if (Equals((parent as UpdateTextStatement).InsertOffset, toReplace)) {
                        (parent as UpdateTextStatement).InsertOffset = replacement;
                        success = true;
                    }
                    if (Equals((parent as UpdateTextStatement).DeleteLength, toReplace)) {
                        (parent as UpdateTextStatement).DeleteLength = replacement;
                        success = true;
                    }
                    break;
                }
                case 110: {
                    if (Equals((parent as UseFederationStatement).Value, toReplace)) {
                        (parent as UseFederationStatement).Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 111: {
                    for (var i = 0; i < (parent as VariableMethodCallTableReference).Parameters.Count; i++) {
                        if (Equals((parent as VariableMethodCallTableReference).Parameters[i], toReplace)) {
                            (parent as VariableMethodCallTableReference).Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 112: {
                    if (Equals((parent as VariableValuePair).Value, toReplace)) {
                        (parent as VariableValuePair).Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 113: {
                    if (Equals((parent as WaitForStatement).Timeout, toReplace)) {
                        (parent as WaitForStatement).Timeout = replacement;
                        success = true;
                    }
                    break;
                }
                case 114: {
                    for (var i = 0; i < (parent as WindowDefinition).Partitions.Count; i++) {
                        if (Equals((parent as WindowDefinition).Partitions[i], toReplace)) {
                            (parent as WindowDefinition).Partitions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 115: {
                    if (Equals((parent as WindowDelimiter).OffsetValue, toReplace)) {
                        (parent as WindowDelimiter).OffsetValue = replacement;
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