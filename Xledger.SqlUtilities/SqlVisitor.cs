using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Reflection;
using System.Security;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace X.Data.DB
{
    // GENERATED via script (Generate_SqlRawVisitorWithContext.linq)
    // DO NOT EDIT DIRECTLY.
    public class SqlRawVisitorWithContext : TSqlConcreteFragmentVisitor
    {
        public bool ShouldStop { get; set; }
        public Stack<TSqlFragment> Parents { get; set; } = new Stack<TSqlFragment>(30);
        public HashSet<TSqlFragment> SkipList { get; } = new HashSet<TSqlFragment>();
        ///<summary>Actions to perform when leaving a node.</summary>
        public Dictionary<TSqlFragment, Queue<Action<TSqlFragment>>> PendingOnLeaveActionsByFragment { get; set; } = new Dictionary<TSqlFragment, Queue<Action<TSqlFragment>>>();

        public Action<SqlRawVisitorWithContext, CreateExternalLanguageStatement> VisForCreateExternalLanguageStatement;
        public Action<SqlRawVisitorWithContext, AlterExternalLanguageStatement> VisForAlterExternalLanguageStatement;
        public Action<SqlRawVisitorWithContext, ExternalLanguageFileOption> VisForExternalLanguageFileOption;
        public Action<SqlRawVisitorWithContext, DropExternalLanguageStatement> VisForDropExternalLanguageStatement;
        public Action<SqlRawVisitorWithContext, AlterEventSessionStatement> VisForAlterEventSessionStatement;
        public Action<SqlRawVisitorWithContext, DropEventSessionStatement> VisForDropEventSessionStatement;
        public Action<SqlRawVisitorWithContext, AlterResourceGovernorStatement> VisForAlterResourceGovernorStatement;
        public Action<SqlRawVisitorWithContext, CreateSpatialIndexStatement> VisForCreateSpatialIndexStatement;
        public Action<SqlRawVisitorWithContext, SpatialIndexRegularOption> VisForSpatialIndexRegularOption;
        public Action<SqlRawVisitorWithContext, BoundingBoxSpatialIndexOption> VisForBoundingBoxSpatialIndexOption;
        public Action<SqlRawVisitorWithContext, BoundingBoxParameter> VisForBoundingBoxParameter;
        public Action<SqlRawVisitorWithContext, GridsSpatialIndexOption> VisForGridsSpatialIndexOption;
        public Action<SqlRawVisitorWithContext, GridParameter> VisForGridParameter;
        public Action<SqlRawVisitorWithContext, CellsPerObjectSpatialIndexOption> VisForCellsPerObjectSpatialIndexOption;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationStatement> VisForAlterServerConfigurationStatement;
        public Action<SqlRawVisitorWithContext, ProcessAffinityRange> VisForProcessAffinityRange;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationSetExternalAuthenticationStatement> VisForAlterServerConfigurationSetExternalAuthenticationStatement;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationExternalAuthenticationOption> VisForAlterServerConfigurationExternalAuthenticationOption;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationExternalAuthenticationContainerOption> VisForAlterServerConfigurationExternalAuthenticationContainerOption;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationSetBufferPoolExtensionStatement> VisForAlterServerConfigurationSetBufferPoolExtensionStatement;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationBufferPoolExtensionOption> VisForAlterServerConfigurationBufferPoolExtensionOption;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationBufferPoolExtensionContainerOption> VisForAlterServerConfigurationBufferPoolExtensionContainerOption;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationBufferPoolExtensionSizeOption> VisForAlterServerConfigurationBufferPoolExtensionSizeOption;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationSetDiagnosticsLogStatement> VisForAlterServerConfigurationSetDiagnosticsLogStatement;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationDiagnosticsLogOption> VisForAlterServerConfigurationDiagnosticsLogOption;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationDiagnosticsLogMaxSizeOption> VisForAlterServerConfigurationDiagnosticsLogMaxSizeOption;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationSetFailoverClusterPropertyStatement> VisForAlterServerConfigurationSetFailoverClusterPropertyStatement;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationFailoverClusterPropertyOption> VisForAlterServerConfigurationFailoverClusterPropertyOption;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationSetHadrClusterStatement> VisForAlterServerConfigurationSetHadrClusterStatement;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationHadrClusterOption> VisForAlterServerConfigurationHadrClusterOption;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationSetSoftNumaStatement> VisForAlterServerConfigurationSetSoftNumaStatement;
        public Action<SqlRawVisitorWithContext, AlterServerConfigurationSoftNumaOption> VisForAlterServerConfigurationSoftNumaOption;
        public Action<SqlRawVisitorWithContext, CreateAvailabilityGroupStatement> VisForCreateAvailabilityGroupStatement;
        public Action<SqlRawVisitorWithContext, AlterAvailabilityGroupStatement> VisForAlterAvailabilityGroupStatement;
        public Action<SqlRawVisitorWithContext, AvailabilityReplica> VisForAvailabilityReplica;
        public Action<SqlRawVisitorWithContext, LiteralReplicaOption> VisForLiteralReplicaOption;
        public Action<SqlRawVisitorWithContext, AvailabilityModeReplicaOption> VisForAvailabilityModeReplicaOption;
        public Action<SqlRawVisitorWithContext, FailoverModeReplicaOption> VisForFailoverModeReplicaOption;
        public Action<SqlRawVisitorWithContext, PrimaryRoleReplicaOption> VisForPrimaryRoleReplicaOption;
        public Action<SqlRawVisitorWithContext, SecondaryRoleReplicaOption> VisForSecondaryRoleReplicaOption;
        public Action<SqlRawVisitorWithContext, LiteralAvailabilityGroupOption> VisForLiteralAvailabilityGroupOption;
        public Action<SqlRawVisitorWithContext, AlterAvailabilityGroupAction> VisForAlterAvailabilityGroupAction;
        public Action<SqlRawVisitorWithContext, AlterAvailabilityGroupFailoverAction> VisForAlterAvailabilityGroupFailoverAction;
        public Action<SqlRawVisitorWithContext, AlterAvailabilityGroupFailoverOption> VisForAlterAvailabilityGroupFailoverOption;
        public Action<SqlRawVisitorWithContext, DropAvailabilityGroupStatement> VisForDropAvailabilityGroupStatement;
        public Action<SqlRawVisitorWithContext, CreateFederationStatement> VisForCreateFederationStatement;
        public Action<SqlRawVisitorWithContext, AlterFederationStatement> VisForAlterFederationStatement;
        public Action<SqlRawVisitorWithContext, DropFederationStatement> VisForDropFederationStatement;
        public Action<SqlRawVisitorWithContext, UseFederationStatement> VisForUseFederationStatement;
        public Action<SqlRawVisitorWithContext, DiskStatement> VisForDiskStatement;
        public Action<SqlRawVisitorWithContext, DiskStatementOption> VisForDiskStatementOption;
        public Action<SqlRawVisitorWithContext, CreateColumnStoreIndexStatement> VisForCreateColumnStoreIndexStatement;
        public Action<SqlRawVisitorWithContext, WindowFrameClause> VisForWindowFrameClause;
        public Action<SqlRawVisitorWithContext, WindowDelimiter> VisForWindowDelimiter;
        public Action<SqlRawVisitorWithContext, WithinGroupClause> VisForWithinGroupClause;
        public Action<SqlRawVisitorWithContext, SelectiveXmlIndexPromotedPath> VisForSelectiveXmlIndexPromotedPath;
        public Action<SqlRawVisitorWithContext, TemporalClause> VisForTemporalClause;
        public Action<SqlRawVisitorWithContext, CompressionDelayIndexOption> VisForCompressionDelayIndexOption;
        public Action<SqlRawVisitorWithContext, CreateExternalLibraryStatement> VisForCreateExternalLibraryStatement;
        public Action<SqlRawVisitorWithContext, AlterExternalLibraryStatement> VisForAlterExternalLibraryStatement;
        public Action<SqlRawVisitorWithContext, ExternalLibraryFileOption> VisForExternalLibraryFileOption;
        public Action<SqlRawVisitorWithContext, DropExternalLibraryStatement> VisForDropExternalLibraryStatement;
        public Action<SqlRawVisitorWithContext, MaxRolloverFilesAuditTargetOption> VisForMaxRolloverFilesAuditTargetOption;
        public Action<SqlRawVisitorWithContext, LiteralAuditTargetOption> VisForLiteralAuditTargetOption;
        public Action<SqlRawVisitorWithContext, OnOffAuditTargetOption> VisForOnOffAuditTargetOption;
        public Action<SqlRawVisitorWithContext, CreateDatabaseEncryptionKeyStatement> VisForCreateDatabaseEncryptionKeyStatement;
        public Action<SqlRawVisitorWithContext, AlterDatabaseEncryptionKeyStatement> VisForAlterDatabaseEncryptionKeyStatement;
        public Action<SqlRawVisitorWithContext, DropDatabaseEncryptionKeyStatement> VisForDropDatabaseEncryptionKeyStatement;
        public Action<SqlRawVisitorWithContext, ResourcePoolStatement> VisForResourcePoolStatement;
        public Action<SqlRawVisitorWithContext, ResourcePoolParameter> VisForResourcePoolParameter;
        public Action<SqlRawVisitorWithContext, ResourcePoolAffinitySpecification> VisForResourcePoolAffinitySpecification;
        public Action<SqlRawVisitorWithContext, CreateResourcePoolStatement> VisForCreateResourcePoolStatement;
        public Action<SqlRawVisitorWithContext, AlterResourcePoolStatement> VisForAlterResourcePoolStatement;
        public Action<SqlRawVisitorWithContext, DropResourcePoolStatement> VisForDropResourcePoolStatement;
        public Action<SqlRawVisitorWithContext, ExternalResourcePoolStatement> VisForExternalResourcePoolStatement;
        public Action<SqlRawVisitorWithContext, ExternalResourcePoolParameter> VisForExternalResourcePoolParameter;
        public Action<SqlRawVisitorWithContext, ExternalResourcePoolAffinitySpecification> VisForExternalResourcePoolAffinitySpecification;
        public Action<SqlRawVisitorWithContext, CreateExternalResourcePoolStatement> VisForCreateExternalResourcePoolStatement;
        public Action<SqlRawVisitorWithContext, AlterExternalResourcePoolStatement> VisForAlterExternalResourcePoolStatement;
        public Action<SqlRawVisitorWithContext, DropExternalResourcePoolStatement> VisForDropExternalResourcePoolStatement;
        public Action<SqlRawVisitorWithContext, WorkloadGroupResourceParameter> VisForWorkloadGroupResourceParameter;
        public Action<SqlRawVisitorWithContext, WorkloadGroupImportanceParameter> VisForWorkloadGroupImportanceParameter;
        public Action<SqlRawVisitorWithContext, CreateWorkloadGroupStatement> VisForCreateWorkloadGroupStatement;
        public Action<SqlRawVisitorWithContext, AlterWorkloadGroupStatement> VisForAlterWorkloadGroupStatement;
        public Action<SqlRawVisitorWithContext, DropWorkloadGroupStatement> VisForDropWorkloadGroupStatement;
        public Action<SqlRawVisitorWithContext, ClassifierWorkloadGroupOption> VisForClassifierWorkloadGroupOption;
        public Action<SqlRawVisitorWithContext, ClassifierMemberNameOption> VisForClassifierMemberNameOption;
        public Action<SqlRawVisitorWithContext, ClassifierWlmLabelOption> VisForClassifierWlmLabelOption;
        public Action<SqlRawVisitorWithContext, ClassifierImportanceOption> VisForClassifierImportanceOption;
        public Action<SqlRawVisitorWithContext, ClassifierWlmContextOption> VisForClassifierWlmContextOption;
        public Action<SqlRawVisitorWithContext, ClassifierStartTimeOption> VisForClassifierStartTimeOption;
        public Action<SqlRawVisitorWithContext, ClassifierEndTimeOption> VisForClassifierEndTimeOption;
        public Action<SqlRawVisitorWithContext, WlmTimeLiteral> VisForWlmTimeLiteral;
        public Action<SqlRawVisitorWithContext, CreateWorkloadClassifierStatement> VisForCreateWorkloadClassifierStatement;
        public Action<SqlRawVisitorWithContext, DropWorkloadClassifierStatement> VisForDropWorkloadClassifierStatement;
        public Action<SqlRawVisitorWithContext, BrokerPriorityParameter> VisForBrokerPriorityParameter;
        public Action<SqlRawVisitorWithContext, CreateBrokerPriorityStatement> VisForCreateBrokerPriorityStatement;
        public Action<SqlRawVisitorWithContext, AlterBrokerPriorityStatement> VisForAlterBrokerPriorityStatement;
        public Action<SqlRawVisitorWithContext, DropBrokerPriorityStatement> VisForDropBrokerPriorityStatement;
        public Action<SqlRawVisitorWithContext, CreateFullTextStopListStatement> VisForCreateFullTextStopListStatement;
        public Action<SqlRawVisitorWithContext, AlterFullTextStopListStatement> VisForAlterFullTextStopListStatement;
        public Action<SqlRawVisitorWithContext, FullTextStopListAction> VisForFullTextStopListAction;
        public Action<SqlRawVisitorWithContext, DropFullTextStopListStatement> VisForDropFullTextStopListStatement;
        public Action<SqlRawVisitorWithContext, CreateCryptographicProviderStatement> VisForCreateCryptographicProviderStatement;
        public Action<SqlRawVisitorWithContext, AlterCryptographicProviderStatement> VisForAlterCryptographicProviderStatement;
        public Action<SqlRawVisitorWithContext, DropCryptographicProviderStatement> VisForDropCryptographicProviderStatement;
        public Action<SqlRawVisitorWithContext, EventSessionObjectName> VisForEventSessionObjectName;
        public Action<SqlRawVisitorWithContext, EventSessionStatement> VisForEventSessionStatement;
        public Action<SqlRawVisitorWithContext, CreateEventSessionStatement> VisForCreateEventSessionStatement;
        public Action<SqlRawVisitorWithContext, EventDeclaration> VisForEventDeclaration;
        public Action<SqlRawVisitorWithContext, EventDeclarationSetParameter> VisForEventDeclarationSetParameter;
        public Action<SqlRawVisitorWithContext, SourceDeclaration> VisForSourceDeclaration;
        public Action<SqlRawVisitorWithContext, EventDeclarationCompareFunctionParameter> VisForEventDeclarationCompareFunctionParameter;
        public Action<SqlRawVisitorWithContext, TargetDeclaration> VisForTargetDeclaration;
        public Action<SqlRawVisitorWithContext, EventRetentionSessionOption> VisForEventRetentionSessionOption;
        public Action<SqlRawVisitorWithContext, MemoryPartitionSessionOption> VisForMemoryPartitionSessionOption;
        public Action<SqlRawVisitorWithContext, LiteralSessionOption> VisForLiteralSessionOption;
        public Action<SqlRawVisitorWithContext, MaxDispatchLatencySessionOption> VisForMaxDispatchLatencySessionOption;
        public Action<SqlRawVisitorWithContext, OnOffSessionOption> VisForOnOffSessionOption;
        public Action<SqlRawVisitorWithContext, AlterSchemaStatement> VisForAlterSchemaStatement;
        public Action<SqlRawVisitorWithContext, AlterAsymmetricKeyStatement> VisForAlterAsymmetricKeyStatement;
        public Action<SqlRawVisitorWithContext, AlterServiceMasterKeyStatement> VisForAlterServiceMasterKeyStatement;
        public Action<SqlRawVisitorWithContext, BeginConversationTimerStatement> VisForBeginConversationTimerStatement;
        public Action<SqlRawVisitorWithContext, BeginDialogStatement> VisForBeginDialogStatement;
        public Action<SqlRawVisitorWithContext, ScalarExpressionDialogOption> VisForScalarExpressionDialogOption;
        public Action<SqlRawVisitorWithContext, OnOffDialogOption> VisForOnOffDialogOption;
        public Action<SqlRawVisitorWithContext, BackupCertificateStatement> VisForBackupCertificateStatement;
        public Action<SqlRawVisitorWithContext, BackupServiceMasterKeyStatement> VisForBackupServiceMasterKeyStatement;
        public Action<SqlRawVisitorWithContext, RestoreServiceMasterKeyStatement> VisForRestoreServiceMasterKeyStatement;
        public Action<SqlRawVisitorWithContext, BackupMasterKeyStatement> VisForBackupMasterKeyStatement;
        public Action<SqlRawVisitorWithContext, RestoreMasterKeyStatement> VisForRestoreMasterKeyStatement;
        public Action<SqlRawVisitorWithContext, ScalarExpressionSnippet> VisForScalarExpressionSnippet;
        public Action<SqlRawVisitorWithContext, BooleanExpressionSnippet> VisForBooleanExpressionSnippet;
        public Action<SqlRawVisitorWithContext, StatementListSnippet> VisForStatementListSnippet;
        public Action<SqlRawVisitorWithContext, SelectStatementSnippet> VisForSelectStatementSnippet;
        public Action<SqlRawVisitorWithContext, SchemaObjectNameSnippet> VisForSchemaObjectNameSnippet;
        public Action<SqlRawVisitorWithContext, TSqlFragmentSnippet> VisForTSqlFragmentSnippet;
        public Action<SqlRawVisitorWithContext, TSqlStatementSnippet> VisForTSqlStatementSnippet;
        public Action<SqlRawVisitorWithContext, IdentifierSnippet> VisForIdentifierSnippet;
        public Action<SqlRawVisitorWithContext, TSqlScript> VisForTSqlScript;
        public Action<SqlRawVisitorWithContext, TSqlBatch> VisForTSqlBatch;
        public Action<SqlRawVisitorWithContext, MergeStatement> VisForMergeStatement;
        public Action<SqlRawVisitorWithContext, MergeSpecification> VisForMergeSpecification;
        public Action<SqlRawVisitorWithContext, MergeActionClause> VisForMergeActionClause;
        public Action<SqlRawVisitorWithContext, UpdateMergeAction> VisForUpdateMergeAction;
        public Action<SqlRawVisitorWithContext, DeleteMergeAction> VisForDeleteMergeAction;
        public Action<SqlRawVisitorWithContext, InsertMergeAction> VisForInsertMergeAction;
        public Action<SqlRawVisitorWithContext, CreateTypeTableStatement> VisForCreateTypeTableStatement;
        public Action<SqlRawVisitorWithContext, SensitivityClassificationOption> VisForSensitivityClassificationOption;
        public Action<SqlRawVisitorWithContext, AddSensitivityClassificationStatement> VisForAddSensitivityClassificationStatement;
        public Action<SqlRawVisitorWithContext, DropSensitivityClassificationStatement> VisForDropSensitivityClassificationStatement;
        public Action<SqlRawVisitorWithContext, AuditSpecificationPart> VisForAuditSpecificationPart;
        public Action<SqlRawVisitorWithContext, AuditActionSpecification> VisForAuditActionSpecification;
        public Action<SqlRawVisitorWithContext, DatabaseAuditAction> VisForDatabaseAuditAction;
        public Action<SqlRawVisitorWithContext, AuditActionGroupReference> VisForAuditActionGroupReference;
        public Action<SqlRawVisitorWithContext, CreateDatabaseAuditSpecificationStatement> VisForCreateDatabaseAuditSpecificationStatement;
        public Action<SqlRawVisitorWithContext, AlterDatabaseAuditSpecificationStatement> VisForAlterDatabaseAuditSpecificationStatement;
        public Action<SqlRawVisitorWithContext, DropDatabaseAuditSpecificationStatement> VisForDropDatabaseAuditSpecificationStatement;
        public Action<SqlRawVisitorWithContext, CreateServerAuditSpecificationStatement> VisForCreateServerAuditSpecificationStatement;
        public Action<SqlRawVisitorWithContext, AlterServerAuditSpecificationStatement> VisForAlterServerAuditSpecificationStatement;
        public Action<SqlRawVisitorWithContext, DropServerAuditSpecificationStatement> VisForDropServerAuditSpecificationStatement;
        public Action<SqlRawVisitorWithContext, CreateServerAuditStatement> VisForCreateServerAuditStatement;
        public Action<SqlRawVisitorWithContext, AlterServerAuditStatement> VisForAlterServerAuditStatement;
        public Action<SqlRawVisitorWithContext, DropServerAuditStatement> VisForDropServerAuditStatement;
        public Action<SqlRawVisitorWithContext, AuditTarget> VisForAuditTarget;
        public Action<SqlRawVisitorWithContext, QueueDelayAuditOption> VisForQueueDelayAuditOption;
        public Action<SqlRawVisitorWithContext, AuditGuidAuditOption> VisForAuditGuidAuditOption;
        public Action<SqlRawVisitorWithContext, OnFailureAuditOption> VisForOnFailureAuditOption;
        public Action<SqlRawVisitorWithContext, StateAuditOption> VisForStateAuditOption;
        public Action<SqlRawVisitorWithContext, MaxSizeAuditTargetOption> VisForMaxSizeAuditTargetOption;
        public Action<SqlRawVisitorWithContext, RetentionDaysAuditTargetOption> VisForRetentionDaysAuditTargetOption;
        public Action<SqlRawVisitorWithContext, DropAssemblyStatement> VisForDropAssemblyStatement;
        public Action<SqlRawVisitorWithContext, DropApplicationRoleStatement> VisForDropApplicationRoleStatement;
        public Action<SqlRawVisitorWithContext, DropFullTextCatalogStatement> VisForDropFullTextCatalogStatement;
        public Action<SqlRawVisitorWithContext, DropFullTextIndexStatement> VisForDropFullTextIndexStatement;
        public Action<SqlRawVisitorWithContext, DropLoginStatement> VisForDropLoginStatement;
        public Action<SqlRawVisitorWithContext, DropRoleStatement> VisForDropRoleStatement;
        public Action<SqlRawVisitorWithContext, DropTypeStatement> VisForDropTypeStatement;
        public Action<SqlRawVisitorWithContext, DropUserStatement> VisForDropUserStatement;
        public Action<SqlRawVisitorWithContext, DropMasterKeyStatement> VisForDropMasterKeyStatement;
        public Action<SqlRawVisitorWithContext, DropSymmetricKeyStatement> VisForDropSymmetricKeyStatement;
        public Action<SqlRawVisitorWithContext, DropAsymmetricKeyStatement> VisForDropAsymmetricKeyStatement;
        public Action<SqlRawVisitorWithContext, DropCertificateStatement> VisForDropCertificateStatement;
        public Action<SqlRawVisitorWithContext, DropCredentialStatement> VisForDropCredentialStatement;
        public Action<SqlRawVisitorWithContext, AlterPartitionFunctionStatement> VisForAlterPartitionFunctionStatement;
        public Action<SqlRawVisitorWithContext, AlterPartitionSchemeStatement> VisForAlterPartitionSchemeStatement;
        public Action<SqlRawVisitorWithContext, AlterFullTextIndexStatement> VisForAlterFullTextIndexStatement;
        public Action<SqlRawVisitorWithContext, SimpleAlterFullTextIndexAction> VisForSimpleAlterFullTextIndexAction;
        public Action<SqlRawVisitorWithContext, SetStopListAlterFullTextIndexAction> VisForSetStopListAlterFullTextIndexAction;
        public Action<SqlRawVisitorWithContext, SetSearchPropertyListAlterFullTextIndexAction> VisForSetSearchPropertyListAlterFullTextIndexAction;
        public Action<SqlRawVisitorWithContext, DropAlterFullTextIndexAction> VisForDropAlterFullTextIndexAction;
        public Action<SqlRawVisitorWithContext, AddAlterFullTextIndexAction> VisForAddAlterFullTextIndexAction;
        public Action<SqlRawVisitorWithContext, AlterColumnAlterFullTextIndexAction> VisForAlterColumnAlterFullTextIndexAction;
        public Action<SqlRawVisitorWithContext, CreateSearchPropertyListStatement> VisForCreateSearchPropertyListStatement;
        public Action<SqlRawVisitorWithContext, AlterSearchPropertyListStatement> VisForAlterSearchPropertyListStatement;
        public Action<SqlRawVisitorWithContext, AddSearchPropertyListAction> VisForAddSearchPropertyListAction;
        public Action<SqlRawVisitorWithContext, DropSearchPropertyListAction> VisForDropSearchPropertyListAction;
        public Action<SqlRawVisitorWithContext, DropSearchPropertyListStatement> VisForDropSearchPropertyListStatement;
        public Action<SqlRawVisitorWithContext, CreateLoginStatement> VisForCreateLoginStatement;
        public Action<SqlRawVisitorWithContext, PasswordCreateLoginSource> VisForPasswordCreateLoginSource;
        public Action<SqlRawVisitorWithContext, PrincipalOption> VisForPrincipalOption;
        public Action<SqlRawVisitorWithContext, OnOffPrincipalOption> VisForOnOffPrincipalOption;
        public Action<SqlRawVisitorWithContext, LiteralPrincipalOption> VisForLiteralPrincipalOption;
        public Action<SqlRawVisitorWithContext, IdentifierPrincipalOption> VisForIdentifierPrincipalOption;
        public Action<SqlRawVisitorWithContext, WindowsCreateLoginSource> VisForWindowsCreateLoginSource;
        public Action<SqlRawVisitorWithContext, ExternalCreateLoginSource> VisForExternalCreateLoginSource;
        public Action<SqlRawVisitorWithContext, CertificateCreateLoginSource> VisForCertificateCreateLoginSource;
        public Action<SqlRawVisitorWithContext, AsymmetricKeyCreateLoginSource> VisForAsymmetricKeyCreateLoginSource;
        public Action<SqlRawVisitorWithContext, PasswordAlterPrincipalOption> VisForPasswordAlterPrincipalOption;
        public Action<SqlRawVisitorWithContext, AlterLoginOptionsStatement> VisForAlterLoginOptionsStatement;
        public Action<SqlRawVisitorWithContext, AlterLoginEnableDisableStatement> VisForAlterLoginEnableDisableStatement;
        public Action<SqlRawVisitorWithContext, AlterLoginAddDropCredentialStatement> VisForAlterLoginAddDropCredentialStatement;
        public Action<SqlRawVisitorWithContext, RevertStatement> VisForRevertStatement;
        public Action<SqlRawVisitorWithContext, DropContractStatement> VisForDropContractStatement;
        public Action<SqlRawVisitorWithContext, DropEndpointStatement> VisForDropEndpointStatement;
        public Action<SqlRawVisitorWithContext, DropMessageTypeStatement> VisForDropMessageTypeStatement;
        public Action<SqlRawVisitorWithContext, DropQueueStatement> VisForDropQueueStatement;
        public Action<SqlRawVisitorWithContext, DropRemoteServiceBindingStatement> VisForDropRemoteServiceBindingStatement;
        public Action<SqlRawVisitorWithContext, DropRouteStatement> VisForDropRouteStatement;
        public Action<SqlRawVisitorWithContext, DropServiceStatement> VisForDropServiceStatement;
        public Action<SqlRawVisitorWithContext, AddSignatureStatement> VisForAddSignatureStatement;
        public Action<SqlRawVisitorWithContext, DropSignatureStatement> VisForDropSignatureStatement;
        public Action<SqlRawVisitorWithContext, DropEventNotificationStatement> VisForDropEventNotificationStatement;
        public Action<SqlRawVisitorWithContext, ExecuteAsStatement> VisForExecuteAsStatement;
        public Action<SqlRawVisitorWithContext, EndConversationStatement> VisForEndConversationStatement;
        public Action<SqlRawVisitorWithContext, MoveConversationStatement> VisForMoveConversationStatement;
        public Action<SqlRawVisitorWithContext, GetConversationGroupStatement> VisForGetConversationGroupStatement;
        public Action<SqlRawVisitorWithContext, ReceiveStatement> VisForReceiveStatement;
        public Action<SqlRawVisitorWithContext, SendStatement> VisForSendStatement;
        public Action<SqlRawVisitorWithContext, ComputeClause> VisForComputeClause;
        public Action<SqlRawVisitorWithContext, ComputeFunction> VisForComputeFunction;
        public Action<SqlRawVisitorWithContext, PivotedTableReference> VisForPivotedTableReference;
        public Action<SqlRawVisitorWithContext, UnpivotedTableReference> VisForUnpivotedTableReference;
        public Action<SqlRawVisitorWithContext, UnqualifiedJoin> VisForUnqualifiedJoin;
        public Action<SqlRawVisitorWithContext, TableSampleClause> VisForTableSampleClause;
        public Action<SqlRawVisitorWithContext, BooleanNotExpression> VisForBooleanNotExpression;
        public Action<SqlRawVisitorWithContext, BooleanParenthesisExpression> VisForBooleanParenthesisExpression;
        public Action<SqlRawVisitorWithContext, BooleanComparisonExpression> VisForBooleanComparisonExpression;
        public Action<SqlRawVisitorWithContext, BooleanBinaryExpression> VisForBooleanBinaryExpression;
        public Action<SqlRawVisitorWithContext, BooleanIsNullExpression> VisForBooleanIsNullExpression;
        public Action<SqlRawVisitorWithContext, GraphMatchPredicate> VisForGraphMatchPredicate;
        public Action<SqlRawVisitorWithContext, GraphMatchLastNodePredicate> VisForGraphMatchLastNodePredicate;
        public Action<SqlRawVisitorWithContext, GraphMatchNodeExpression> VisForGraphMatchNodeExpression;
        public Action<SqlRawVisitorWithContext, GraphMatchRecursivePredicate> VisForGraphMatchRecursivePredicate;
        public Action<SqlRawVisitorWithContext, GraphMatchExpression> VisForGraphMatchExpression;
        public Action<SqlRawVisitorWithContext, GraphMatchCompositeExpression> VisForGraphMatchCompositeExpression;
        public Action<SqlRawVisitorWithContext, GraphRecursiveMatchQuantifier> VisForGraphRecursiveMatchQuantifier;
        public Action<SqlRawVisitorWithContext, ExpressionWithSortOrder> VisForExpressionWithSortOrder;
        public Action<SqlRawVisitorWithContext, GroupByClause> VisForGroupByClause;
        public Action<SqlRawVisitorWithContext, ExpressionGroupingSpecification> VisForExpressionGroupingSpecification;
        public Action<SqlRawVisitorWithContext, CompositeGroupingSpecification> VisForCompositeGroupingSpecification;
        public Action<SqlRawVisitorWithContext, CubeGroupingSpecification> VisForCubeGroupingSpecification;
        public Action<SqlRawVisitorWithContext, RollupGroupingSpecification> VisForRollupGroupingSpecification;
        public Action<SqlRawVisitorWithContext, GrandTotalGroupingSpecification> VisForGrandTotalGroupingSpecification;
        public Action<SqlRawVisitorWithContext, GroupingSetsGroupingSpecification> VisForGroupingSetsGroupingSpecification;
        public Action<SqlRawVisitorWithContext, OutputClause> VisForOutputClause;
        public Action<SqlRawVisitorWithContext, OutputIntoClause> VisForOutputIntoClause;
        public Action<SqlRawVisitorWithContext, HavingClause> VisForHavingClause;
        public Action<SqlRawVisitorWithContext, IdentityFunctionCall> VisForIdentityFunctionCall;
        public Action<SqlRawVisitorWithContext, JoinParenthesisTableReference> VisForJoinParenthesisTableReference;
        public Action<SqlRawVisitorWithContext, OrderByClause> VisForOrderByClause;
        public Action<SqlRawVisitorWithContext, QualifiedJoin> VisForQualifiedJoin;
        public Action<SqlRawVisitorWithContext, OdbcQualifiedJoinTableReference> VisForOdbcQualifiedJoinTableReference;
        public Action<SqlRawVisitorWithContext, QueryParenthesisExpression> VisForQueryParenthesisExpression;
        public Action<SqlRawVisitorWithContext, QuerySpecification> VisForQuerySpecification;
        public Action<SqlRawVisitorWithContext, FromClause> VisForFromClause;
        public Action<SqlRawVisitorWithContext, PredictTableReference> VisForPredictTableReference;
        public Action<SqlRawVisitorWithContext, SelectScalarExpression> VisForSelectScalarExpression;
        public Action<SqlRawVisitorWithContext, SelectStarExpression> VisForSelectStarExpression;
        public Action<SqlRawVisitorWithContext, SelectSetVariable> VisForSelectSetVariable;
        public Action<SqlRawVisitorWithContext, DataModificationTableReference> VisForDataModificationTableReference;
        public Action<SqlRawVisitorWithContext, ChangeTableChangesTableReference> VisForChangeTableChangesTableReference;
        public Action<SqlRawVisitorWithContext, ChangeTableVersionTableReference> VisForChangeTableVersionTableReference;
        public Action<SqlRawVisitorWithContext, BooleanTernaryExpression> VisForBooleanTernaryExpression;
        public Action<SqlRawVisitorWithContext, TopRowFilter> VisForTopRowFilter;
        public Action<SqlRawVisitorWithContext, OffsetClause> VisForOffsetClause;
        public Action<SqlRawVisitorWithContext, UnaryExpression> VisForUnaryExpression;
        public Action<SqlRawVisitorWithContext, BinaryQueryExpression> VisForBinaryQueryExpression;
        public Action<SqlRawVisitorWithContext, VariableTableReference> VisForVariableTableReference;
        public Action<SqlRawVisitorWithContext, VariableMethodCallTableReference> VisForVariableMethodCallTableReference;
        public Action<SqlRawVisitorWithContext, DropPartitionFunctionStatement> VisForDropPartitionFunctionStatement;
        public Action<SqlRawVisitorWithContext, DropPartitionSchemeStatement> VisForDropPartitionSchemeStatement;
        public Action<SqlRawVisitorWithContext, DropSynonymStatement> VisForDropSynonymStatement;
        public Action<SqlRawVisitorWithContext, DropAggregateStatement> VisForDropAggregateStatement;
        public Action<SqlRawVisitorWithContext, UserRemoteServiceBindingOption> VisForUserRemoteServiceBindingOption;
        public Action<SqlRawVisitorWithContext, CreateRemoteServiceBindingStatement> VisForCreateRemoteServiceBindingStatement;
        public Action<SqlRawVisitorWithContext, AlterRemoteServiceBindingStatement> VisForAlterRemoteServiceBindingStatement;
        public Action<SqlRawVisitorWithContext, AssemblyEncryptionSource> VisForAssemblyEncryptionSource;
        public Action<SqlRawVisitorWithContext, FileEncryptionSource> VisForFileEncryptionSource;
        public Action<SqlRawVisitorWithContext, ProviderEncryptionSource> VisForProviderEncryptionSource;
        public Action<SqlRawVisitorWithContext, AlterCertificateStatement> VisForAlterCertificateStatement;
        public Action<SqlRawVisitorWithContext, CreateCertificateStatement> VisForCreateCertificateStatement;
        public Action<SqlRawVisitorWithContext, CertificateOption> VisForCertificateOption;
        public Action<SqlRawVisitorWithContext, CreateContractStatement> VisForCreateContractStatement;
        public Action<SqlRawVisitorWithContext, ContractMessage> VisForContractMessage;
        public Action<SqlRawVisitorWithContext, CreateCredentialStatement> VisForCreateCredentialStatement;
        public Action<SqlRawVisitorWithContext, AlterCredentialStatement> VisForAlterCredentialStatement;
        public Action<SqlRawVisitorWithContext, CreateMessageTypeStatement> VisForCreateMessageTypeStatement;
        public Action<SqlRawVisitorWithContext, AlterMessageTypeStatement> VisForAlterMessageTypeStatement;
        public Action<SqlRawVisitorWithContext, CreateAggregateStatement> VisForCreateAggregateStatement;
        public Action<SqlRawVisitorWithContext, CreateEndpointStatement> VisForCreateEndpointStatement;
        public Action<SqlRawVisitorWithContext, AlterEndpointStatement> VisForAlterEndpointStatement;
        public Action<SqlRawVisitorWithContext, EndpointAffinity> VisForEndpointAffinity;
        public Action<SqlRawVisitorWithContext, LiteralEndpointProtocolOption> VisForLiteralEndpointProtocolOption;
        public Action<SqlRawVisitorWithContext, AuthenticationEndpointProtocolOption> VisForAuthenticationEndpointProtocolOption;
        public Action<SqlRawVisitorWithContext, PortsEndpointProtocolOption> VisForPortsEndpointProtocolOption;
        public Action<SqlRawVisitorWithContext, CompressionEndpointProtocolOption> VisForCompressionEndpointProtocolOption;
        public Action<SqlRawVisitorWithContext, ListenerIPEndpointProtocolOption> VisForListenerIPEndpointProtocolOption;
        public Action<SqlRawVisitorWithContext, IPv4> VisForIPv4;
        public Action<SqlRawVisitorWithContext, SoapMethod> VisForSoapMethod;
        public Action<SqlRawVisitorWithContext, EnabledDisabledPayloadOption> VisForEnabledDisabledPayloadOption;
        public Action<SqlRawVisitorWithContext, WsdlPayloadOption> VisForWsdlPayloadOption;
        public Action<SqlRawVisitorWithContext, LoginTypePayloadOption> VisForLoginTypePayloadOption;
        public Action<SqlRawVisitorWithContext, LiteralPayloadOption> VisForLiteralPayloadOption;
        public Action<SqlRawVisitorWithContext, SessionTimeoutPayloadOption> VisForSessionTimeoutPayloadOption;
        public Action<SqlRawVisitorWithContext, SchemaPayloadOption> VisForSchemaPayloadOption;
        public Action<SqlRawVisitorWithContext, CharacterSetPayloadOption> VisForCharacterSetPayloadOption;
        public Action<SqlRawVisitorWithContext, RolePayloadOption> VisForRolePayloadOption;
        public Action<SqlRawVisitorWithContext, AuthenticationPayloadOption> VisForAuthenticationPayloadOption;
        public Action<SqlRawVisitorWithContext, EncryptionPayloadOption> VisForEncryptionPayloadOption;
        public Action<SqlRawVisitorWithContext, CreateSymmetricKeyStatement> VisForCreateSymmetricKeyStatement;
        public Action<SqlRawVisitorWithContext, KeySourceKeyOption> VisForKeySourceKeyOption;
        public Action<SqlRawVisitorWithContext, AlgorithmKeyOption> VisForAlgorithmKeyOption;
        public Action<SqlRawVisitorWithContext, IdentityValueKeyOption> VisForIdentityValueKeyOption;
        public Action<SqlRawVisitorWithContext, ProviderKeyNameKeyOption> VisForProviderKeyNameKeyOption;
        public Action<SqlRawVisitorWithContext, CreationDispositionKeyOption> VisForCreationDispositionKeyOption;
        public Action<SqlRawVisitorWithContext, AlterSymmetricKeyStatement> VisForAlterSymmetricKeyStatement;
        public Action<SqlRawVisitorWithContext, OnOffFullTextCatalogOption> VisForOnOffFullTextCatalogOption;
        public Action<SqlRawVisitorWithContext, CreateFullTextCatalogStatement> VisForCreateFullTextCatalogStatement;
        public Action<SqlRawVisitorWithContext, AlterFullTextCatalogStatement> VisForAlterFullTextCatalogStatement;
        public Action<SqlRawVisitorWithContext, CreateServiceStatement> VisForCreateServiceStatement;
        public Action<SqlRawVisitorWithContext, AlterServiceStatement> VisForAlterServiceStatement;
        public Action<SqlRawVisitorWithContext, ServiceContract> VisForServiceContract;
        public Action<SqlRawVisitorWithContext, BinaryExpression> VisForBinaryExpression;
        public Action<SqlRawVisitorWithContext, BuiltInFunctionTableReference> VisForBuiltInFunctionTableReference;
        public Action<SqlRawVisitorWithContext, GlobalFunctionTableReference> VisForGlobalFunctionTableReference;
        public Action<SqlRawVisitorWithContext, TableDataCompressionOption> VisForTableDataCompressionOption;
        public Action<SqlRawVisitorWithContext, TableDistributionOption> VisForTableDistributionOption;
        public Action<SqlRawVisitorWithContext, TableReplicateDistributionPolicy> VisForTableReplicateDistributionPolicy;
        public Action<SqlRawVisitorWithContext, TableRoundRobinDistributionPolicy> VisForTableRoundRobinDistributionPolicy;
        public Action<SqlRawVisitorWithContext, TableHashDistributionPolicy> VisForTableHashDistributionPolicy;
        public Action<SqlRawVisitorWithContext, TableIndexOption> VisForTableIndexOption;
        public Action<SqlRawVisitorWithContext, TableClusteredIndexType> VisForTableClusteredIndexType;
        public Action<SqlRawVisitorWithContext, TableNonClusteredIndexType> VisForTableNonClusteredIndexType;
        public Action<SqlRawVisitorWithContext, TablePartitionOption> VisForTablePartitionOption;
        public Action<SqlRawVisitorWithContext, TablePartitionOptionSpecifications> VisForTablePartitionOptionSpecifications;
        public Action<SqlRawVisitorWithContext, LocationOption> VisForLocationOption;
        public Action<SqlRawVisitorWithContext, RenameEntityStatement> VisForRenameEntityStatement;
        public Action<SqlRawVisitorWithContext, CopyStatement> VisForCopyStatement;
        public Action<SqlRawVisitorWithContext, CopyOption> VisForCopyOption;
        public Action<SqlRawVisitorWithContext, CopyCredentialOption> VisForCopyCredentialOption;
        public Action<SqlRawVisitorWithContext, SingleValueTypeCopyOption> VisForSingleValueTypeCopyOption;
        public Action<SqlRawVisitorWithContext, ListTypeCopyOption> VisForListTypeCopyOption;
        public Action<SqlRawVisitorWithContext, CopyColumnOption> VisForCopyColumnOption;
        public Action<SqlRawVisitorWithContext, DataCompressionOption> VisForDataCompressionOption;
        public Action<SqlRawVisitorWithContext, CompressionPartitionRange> VisForCompressionPartitionRange;
        public Action<SqlRawVisitorWithContext, CheckConstraintDefinition> VisForCheckConstraintDefinition;
        public Action<SqlRawVisitorWithContext, DefaultConstraintDefinition> VisForDefaultConstraintDefinition;
        public Action<SqlRawVisitorWithContext, ForeignKeyConstraintDefinition> VisForForeignKeyConstraintDefinition;
        public Action<SqlRawVisitorWithContext, NullableConstraintDefinition> VisForNullableConstraintDefinition;
        public Action<SqlRawVisitorWithContext, GraphConnectionBetweenNodes> VisForGraphConnectionBetweenNodes;
        public Action<SqlRawVisitorWithContext, GraphConnectionConstraintDefinition> VisForGraphConnectionConstraintDefinition;
        public Action<SqlRawVisitorWithContext, UniqueConstraintDefinition> VisForUniqueConstraintDefinition;
        public Action<SqlRawVisitorWithContext, BackupDatabaseStatement> VisForBackupDatabaseStatement;
        public Action<SqlRawVisitorWithContext, BackupTransactionLogStatement> VisForBackupTransactionLogStatement;
        public Action<SqlRawVisitorWithContext, RestoreStatement> VisForRestoreStatement;
        public Action<SqlRawVisitorWithContext, RestoreOption> VisForRestoreOption;
        public Action<SqlRawVisitorWithContext, ScalarExpressionRestoreOption> VisForScalarExpressionRestoreOption;
        public Action<SqlRawVisitorWithContext, MoveRestoreOption> VisForMoveRestoreOption;
        public Action<SqlRawVisitorWithContext, StopRestoreOption> VisForStopRestoreOption;
        public Action<SqlRawVisitorWithContext, FileStreamRestoreOption> VisForFileStreamRestoreOption;
        public Action<SqlRawVisitorWithContext, BackupOption> VisForBackupOption;
        public Action<SqlRawVisitorWithContext, BackupEncryptionOption> VisForBackupEncryptionOption;
        public Action<SqlRawVisitorWithContext, DeviceInfo> VisForDeviceInfo;
        public Action<SqlRawVisitorWithContext, MirrorToClause> VisForMirrorToClause;
        public Action<SqlRawVisitorWithContext, BackupRestoreFileInfo> VisForBackupRestoreFileInfo;
        public Action<SqlRawVisitorWithContext, BulkInsertStatement> VisForBulkInsertStatement;
        public Action<SqlRawVisitorWithContext, InsertBulkStatement> VisForInsertBulkStatement;
        public Action<SqlRawVisitorWithContext, BulkInsertOption> VisForBulkInsertOption;
        public Action<SqlRawVisitorWithContext, LiteralBulkInsertOption> VisForLiteralBulkInsertOption;
        public Action<SqlRawVisitorWithContext, OrderBulkInsertOption> VisForOrderBulkInsertOption;
        public Action<SqlRawVisitorWithContext, ColumnDefinitionBase> VisForColumnDefinitionBase;
        public Action<SqlRawVisitorWithContext, ExternalTableColumnDefinition> VisForExternalTableColumnDefinition;
        public Action<SqlRawVisitorWithContext, InsertBulkColumnDefinition> VisForInsertBulkColumnDefinition;
        public Action<SqlRawVisitorWithContext, DbccStatement> VisForDbccStatement;
        public Action<SqlRawVisitorWithContext, DbccOption> VisForDbccOption;
        public Action<SqlRawVisitorWithContext, DbccNamedLiteral> VisForDbccNamedLiteral;
        public Action<SqlRawVisitorWithContext, CreateAsymmetricKeyStatement> VisForCreateAsymmetricKeyStatement;
        public Action<SqlRawVisitorWithContext, CreatePartitionFunctionStatement> VisForCreatePartitionFunctionStatement;
        public Action<SqlRawVisitorWithContext, PartitionParameterType> VisForPartitionParameterType;
        public Action<SqlRawVisitorWithContext, CreatePartitionSchemeStatement> VisForCreatePartitionSchemeStatement;
        public Action<SqlRawVisitorWithContext, OnOffRemoteServiceBindingOption> VisForOnOffRemoteServiceBindingOption;
        public Action<SqlRawVisitorWithContext, AlterDatabaseRebuildLogStatement> VisForAlterDatabaseRebuildLogStatement;
        public Action<SqlRawVisitorWithContext, AlterDatabaseAddFileStatement> VisForAlterDatabaseAddFileStatement;
        public Action<SqlRawVisitorWithContext, AlterDatabaseAddFileGroupStatement> VisForAlterDatabaseAddFileGroupStatement;
        public Action<SqlRawVisitorWithContext, AlterDatabaseRemoveFileGroupStatement> VisForAlterDatabaseRemoveFileGroupStatement;
        public Action<SqlRawVisitorWithContext, AlterDatabaseRemoveFileStatement> VisForAlterDatabaseRemoveFileStatement;
        public Action<SqlRawVisitorWithContext, AlterDatabaseModifyNameStatement> VisForAlterDatabaseModifyNameStatement;
        public Action<SqlRawVisitorWithContext, AlterDatabaseModifyFileStatement> VisForAlterDatabaseModifyFileStatement;
        public Action<SqlRawVisitorWithContext, AlterDatabaseModifyFileGroupStatement> VisForAlterDatabaseModifyFileGroupStatement;
        public Action<SqlRawVisitorWithContext, AlterDatabaseTermination> VisForAlterDatabaseTermination;
        public Action<SqlRawVisitorWithContext, AlterDatabaseSetStatement> VisForAlterDatabaseSetStatement;
        public Action<SqlRawVisitorWithContext, DatabaseOption> VisForDatabaseOption;
        public Action<SqlRawVisitorWithContext, OnOffDatabaseOption> VisForOnOffDatabaseOption;
        public Action<SqlRawVisitorWithContext, AutoCreateStatisticsDatabaseOption> VisForAutoCreateStatisticsDatabaseOption;
        public Action<SqlRawVisitorWithContext, ContainmentDatabaseOption> VisForContainmentDatabaseOption;
        public Action<SqlRawVisitorWithContext, HadrDatabaseOption> VisForHadrDatabaseOption;
        public Action<SqlRawVisitorWithContext, HadrAvailabilityGroupDatabaseOption> VisForHadrAvailabilityGroupDatabaseOption;
        public Action<SqlRawVisitorWithContext, DelayedDurabilityDatabaseOption> VisForDelayedDurabilityDatabaseOption;
        public Action<SqlRawVisitorWithContext, CursorDefaultDatabaseOption> VisForCursorDefaultDatabaseOption;
        public Action<SqlRawVisitorWithContext, RecoveryDatabaseOption> VisForRecoveryDatabaseOption;
        public Action<SqlRawVisitorWithContext, TargetRecoveryTimeDatabaseOption> VisForTargetRecoveryTimeDatabaseOption;
        public Action<SqlRawVisitorWithContext, PageVerifyDatabaseOption> VisForPageVerifyDatabaseOption;
        public Action<SqlRawVisitorWithContext, PartnerDatabaseOption> VisForPartnerDatabaseOption;
        public Action<SqlRawVisitorWithContext, WitnessDatabaseOption> VisForWitnessDatabaseOption;
        public Action<SqlRawVisitorWithContext, ParameterizationDatabaseOption> VisForParameterizationDatabaseOption;
        public Action<SqlRawVisitorWithContext, LiteralDatabaseOption> VisForLiteralDatabaseOption;
        public Action<SqlRawVisitorWithContext, IdentifierDatabaseOption> VisForIdentifierDatabaseOption;
        public Action<SqlRawVisitorWithContext, ChangeTrackingDatabaseOption> VisForChangeTrackingDatabaseOption;
        public Action<SqlRawVisitorWithContext, AutoCleanupChangeTrackingOptionDetail> VisForAutoCleanupChangeTrackingOptionDetail;
        public Action<SqlRawVisitorWithContext, ChangeRetentionChangeTrackingOptionDetail> VisForChangeRetentionChangeTrackingOptionDetail;
        public Action<SqlRawVisitorWithContext, AcceleratedDatabaseRecoveryDatabaseOption> VisForAcceleratedDatabaseRecoveryDatabaseOption;
        public Action<SqlRawVisitorWithContext, QueryStoreDatabaseOption> VisForQueryStoreDatabaseOption;
        public Action<SqlRawVisitorWithContext, QueryStoreDesiredStateOption> VisForQueryStoreDesiredStateOption;
        public Action<SqlRawVisitorWithContext, QueryStoreCapturePolicyOption> VisForQueryStoreCapturePolicyOption;
        public Action<SqlRawVisitorWithContext, QueryStoreSizeCleanupPolicyOption> VisForQueryStoreSizeCleanupPolicyOption;
        public Action<SqlRawVisitorWithContext, QueryStoreDataFlushIntervalOption> VisForQueryStoreDataFlushIntervalOption;
        public Action<SqlRawVisitorWithContext, QueryStoreIntervalLengthOption> VisForQueryStoreIntervalLengthOption;
        public Action<SqlRawVisitorWithContext, QueryStoreMaxStorageSizeOption> VisForQueryStoreMaxStorageSizeOption;
        public Action<SqlRawVisitorWithContext, QueryStoreMaxPlansPerQueryOption> VisForQueryStoreMaxPlansPerQueryOption;
        public Action<SqlRawVisitorWithContext, QueryStoreTimeCleanupPolicyOption> VisForQueryStoreTimeCleanupPolicyOption;
        public Action<SqlRawVisitorWithContext, AutomaticTuningDatabaseOption> VisForAutomaticTuningDatabaseOption;
        public Action<SqlRawVisitorWithContext, AutomaticTuningOption> VisForAutomaticTuningOption;
        public Action<SqlRawVisitorWithContext, AutomaticTuningForceLastGoodPlanOption> VisForAutomaticTuningForceLastGoodPlanOption;
        public Action<SqlRawVisitorWithContext, AutomaticTuningCreateIndexOption> VisForAutomaticTuningCreateIndexOption;
        public Action<SqlRawVisitorWithContext, AutomaticTuningDropIndexOption> VisForAutomaticTuningDropIndexOption;
        public Action<SqlRawVisitorWithContext, AutomaticTuningMaintainIndexOption> VisForAutomaticTuningMaintainIndexOption;
        public Action<SqlRawVisitorWithContext, FileStreamDatabaseOption> VisForFileStreamDatabaseOption;
        public Action<SqlRawVisitorWithContext, CatalogCollationOption> VisForCatalogCollationOption;
        public Action<SqlRawVisitorWithContext, LedgerOption> VisForLedgerOption;
        public Action<SqlRawVisitorWithContext, MaxSizeDatabaseOption> VisForMaxSizeDatabaseOption;
        public Action<SqlRawVisitorWithContext, AlterTableAlterIndexStatement> VisForAlterTableAlterIndexStatement;
        public Action<SqlRawVisitorWithContext, AlterTableAlterColumnStatement> VisForAlterTableAlterColumnStatement;
        public Action<SqlRawVisitorWithContext, ColumnDefinition> VisForColumnDefinition;
        public Action<SqlRawVisitorWithContext, ColumnEncryptionDefinition> VisForColumnEncryptionDefinition;
        public Action<SqlRawVisitorWithContext, ColumnEncryptionKeyNameParameter> VisForColumnEncryptionKeyNameParameter;
        public Action<SqlRawVisitorWithContext, ColumnEncryptionTypeParameter> VisForColumnEncryptionTypeParameter;
        public Action<SqlRawVisitorWithContext, ColumnEncryptionAlgorithmParameter> VisForColumnEncryptionAlgorithmParameter;
        public Action<SqlRawVisitorWithContext, IdentityOptions> VisForIdentityOptions;
        public Action<SqlRawVisitorWithContext, ColumnStorageOptions> VisForColumnStorageOptions;
        public Action<SqlRawVisitorWithContext, CreateTableStatement> VisForCreateTableStatement;
        public Action<SqlRawVisitorWithContext, FederationScheme> VisForFederationScheme;
        public Action<SqlRawVisitorWithContext, WhereClause> VisForWhereClause;
        public Action<SqlRawVisitorWithContext, DropDatabaseStatement> VisForDropDatabaseStatement;
        public Action<SqlRawVisitorWithContext, DropIndexStatement> VisForDropIndexStatement;
        public Action<SqlRawVisitorWithContext, BackwardsCompatibleDropIndexClause> VisForBackwardsCompatibleDropIndexClause;
        public Action<SqlRawVisitorWithContext, DropIndexClause> VisForDropIndexClause;
        public Action<SqlRawVisitorWithContext, MoveToDropIndexOption> VisForMoveToDropIndexOption;
        public Action<SqlRawVisitorWithContext, FileStreamOnDropIndexOption> VisForFileStreamOnDropIndexOption;
        public Action<SqlRawVisitorWithContext, DropStatisticsStatement> VisForDropStatisticsStatement;
        public Action<SqlRawVisitorWithContext, DropTableStatement> VisForDropTableStatement;
        public Action<SqlRawVisitorWithContext, DropProcedureStatement> VisForDropProcedureStatement;
        public Action<SqlRawVisitorWithContext, DropFunctionStatement> VisForDropFunctionStatement;
        public Action<SqlRawVisitorWithContext, DropViewStatement> VisForDropViewStatement;
        public Action<SqlRawVisitorWithContext, DropDefaultStatement> VisForDropDefaultStatement;
        public Action<SqlRawVisitorWithContext, DropRuleStatement> VisForDropRuleStatement;
        public Action<SqlRawVisitorWithContext, DropTriggerStatement> VisForDropTriggerStatement;
        public Action<SqlRawVisitorWithContext, DropSchemaStatement> VisForDropSchemaStatement;
        public Action<SqlRawVisitorWithContext, RaiseErrorLegacyStatement> VisForRaiseErrorLegacyStatement;
        public Action<SqlRawVisitorWithContext, RaiseErrorStatement> VisForRaiseErrorStatement;
        public Action<SqlRawVisitorWithContext, ThrowStatement> VisForThrowStatement;
        public Action<SqlRawVisitorWithContext, UseStatement> VisForUseStatement;
        public Action<SqlRawVisitorWithContext, KillStatement> VisForKillStatement;
        public Action<SqlRawVisitorWithContext, KillQueryNotificationSubscriptionStatement> VisForKillQueryNotificationSubscriptionStatement;
        public Action<SqlRawVisitorWithContext, KillStatsJobStatement> VisForKillStatsJobStatement;
        public Action<SqlRawVisitorWithContext, CheckpointStatement> VisForCheckpointStatement;
        public Action<SqlRawVisitorWithContext, ReconfigureStatement> VisForReconfigureStatement;
        public Action<SqlRawVisitorWithContext, ShutdownStatement> VisForShutdownStatement;
        public Action<SqlRawVisitorWithContext, SetUserStatement> VisForSetUserStatement;
        public Action<SqlRawVisitorWithContext, TruncateTableStatement> VisForTruncateTableStatement;
        public Action<SqlRawVisitorWithContext, PredicateSetStatement> VisForPredicateSetStatement;
        public Action<SqlRawVisitorWithContext, SetStatisticsStatement> VisForSetStatisticsStatement;
        public Action<SqlRawVisitorWithContext, SetRowCountStatement> VisForSetRowCountStatement;
        public Action<SqlRawVisitorWithContext, SetOffsetsStatement> VisForSetOffsetsStatement;
        public Action<SqlRawVisitorWithContext, GeneralSetCommand> VisForGeneralSetCommand;
        public Action<SqlRawVisitorWithContext, SetFipsFlaggerCommand> VisForSetFipsFlaggerCommand;
        public Action<SqlRawVisitorWithContext, SetCommandStatement> VisForSetCommandStatement;
        public Action<SqlRawVisitorWithContext, SetTransactionIsolationLevelStatement> VisForSetTransactionIsolationLevelStatement;
        public Action<SqlRawVisitorWithContext, SetTextSizeStatement> VisForSetTextSizeStatement;
        public Action<SqlRawVisitorWithContext, SetIdentityInsertStatement> VisForSetIdentityInsertStatement;
        public Action<SqlRawVisitorWithContext, SetErrorLevelStatement> VisForSetErrorLevelStatement;
        public Action<SqlRawVisitorWithContext, CreateDatabaseStatement> VisForCreateDatabaseStatement;
        public Action<SqlRawVisitorWithContext, FileDeclaration> VisForFileDeclaration;
        public Action<SqlRawVisitorWithContext, FileDeclarationOption> VisForFileDeclarationOption;
        public Action<SqlRawVisitorWithContext, NameFileDeclarationOption> VisForNameFileDeclarationOption;
        public Action<SqlRawVisitorWithContext, FileNameFileDeclarationOption> VisForFileNameFileDeclarationOption;
        public Action<SqlRawVisitorWithContext, SizeFileDeclarationOption> VisForSizeFileDeclarationOption;
        public Action<SqlRawVisitorWithContext, MaxSizeFileDeclarationOption> VisForMaxSizeFileDeclarationOption;
        public Action<SqlRawVisitorWithContext, FileGrowthFileDeclarationOption> VisForFileGrowthFileDeclarationOption;
        public Action<SqlRawVisitorWithContext, FileGroupDefinition> VisForFileGroupDefinition;
        public Action<SqlRawVisitorWithContext, AlterDatabaseScopedConfigurationSetStatement> VisForAlterDatabaseScopedConfigurationSetStatement;
        public Action<SqlRawVisitorWithContext, AlterDatabaseScopedConfigurationClearStatement> VisForAlterDatabaseScopedConfigurationClearStatement;
        public Action<SqlRawVisitorWithContext, DatabaseConfigurationClearOption> VisForDatabaseConfigurationClearOption;
        public Action<SqlRawVisitorWithContext, DatabaseConfigurationSetOption> VisForDatabaseConfigurationSetOption;
        public Action<SqlRawVisitorWithContext, OnOffPrimaryConfigurationOption> VisForOnOffPrimaryConfigurationOption;
        public Action<SqlRawVisitorWithContext, MaxDopConfigurationOption> VisForMaxDopConfigurationOption;
        public Action<SqlRawVisitorWithContext, GenericConfigurationOption> VisForGenericConfigurationOption;
        public Action<SqlRawVisitorWithContext, AlterDatabaseCollateStatement> VisForAlterDatabaseCollateStatement;
        public Action<SqlRawVisitorWithContext, OnlineIndexOption> VisForOnlineIndexOption;
        public Action<SqlRawVisitorWithContext, IgnoreDupKeyIndexOption> VisForIgnoreDupKeyIndexOption;
        public Action<SqlRawVisitorWithContext, OrderIndexOption> VisForOrderIndexOption;
        public Action<SqlRawVisitorWithContext, OnlineIndexLowPriorityLockWaitOption> VisForOnlineIndexLowPriorityLockWaitOption;
        public Action<SqlRawVisitorWithContext, LowPriorityLockWaitMaxDurationOption> VisForLowPriorityLockWaitMaxDurationOption;
        public Action<SqlRawVisitorWithContext, LowPriorityLockWaitAbortAfterWaitOption> VisForLowPriorityLockWaitAbortAfterWaitOption;
        public Action<SqlRawVisitorWithContext, FullTextIndexColumn> VisForFullTextIndexColumn;
        public Action<SqlRawVisitorWithContext, CreateFullTextIndexStatement> VisForCreateFullTextIndexStatement;
        public Action<SqlRawVisitorWithContext, ChangeTrackingFullTextIndexOption> VisForChangeTrackingFullTextIndexOption;
        public Action<SqlRawVisitorWithContext, StopListFullTextIndexOption> VisForStopListFullTextIndexOption;
        public Action<SqlRawVisitorWithContext, SearchPropertyListFullTextIndexOption> VisForSearchPropertyListFullTextIndexOption;
        public Action<SqlRawVisitorWithContext, FullTextCatalogAndFileGroup> VisForFullTextCatalogAndFileGroup;
        public Action<SqlRawVisitorWithContext, EventTypeContainer> VisForEventTypeContainer;
        public Action<SqlRawVisitorWithContext, EventGroupContainer> VisForEventGroupContainer;
        public Action<SqlRawVisitorWithContext, CreateEventNotificationStatement> VisForCreateEventNotificationStatement;
        public Action<SqlRawVisitorWithContext, EventNotificationObjectScope> VisForEventNotificationObjectScope;
        public Action<SqlRawVisitorWithContext, CreateMasterKeyStatement> VisForCreateMasterKeyStatement;
        public Action<SqlRawVisitorWithContext, AlterMasterKeyStatement> VisForAlterMasterKeyStatement;
        public Action<SqlRawVisitorWithContext, ApplicationRoleOption> VisForApplicationRoleOption;
        public Action<SqlRawVisitorWithContext, CreateApplicationRoleStatement> VisForCreateApplicationRoleStatement;
        public Action<SqlRawVisitorWithContext, AlterApplicationRoleStatement> VisForAlterApplicationRoleStatement;
        public Action<SqlRawVisitorWithContext, CreateRoleStatement> VisForCreateRoleStatement;
        public Action<SqlRawVisitorWithContext, AlterRoleStatement> VisForAlterRoleStatement;
        public Action<SqlRawVisitorWithContext, RenameAlterRoleAction> VisForRenameAlterRoleAction;
        public Action<SqlRawVisitorWithContext, AddMemberAlterRoleAction> VisForAddMemberAlterRoleAction;
        public Action<SqlRawVisitorWithContext, DropMemberAlterRoleAction> VisForDropMemberAlterRoleAction;
        public Action<SqlRawVisitorWithContext, CreateServerRoleStatement> VisForCreateServerRoleStatement;
        public Action<SqlRawVisitorWithContext, AlterServerRoleStatement> VisForAlterServerRoleStatement;
        public Action<SqlRawVisitorWithContext, DropServerRoleStatement> VisForDropServerRoleStatement;
        public Action<SqlRawVisitorWithContext, UserLoginOption> VisForUserLoginOption;
        public Action<SqlRawVisitorWithContext, CreateUserStatement> VisForCreateUserStatement;
        public Action<SqlRawVisitorWithContext, AlterUserStatement> VisForAlterUserStatement;
        public Action<SqlRawVisitorWithContext, StatisticsOption> VisForStatisticsOption;
        public Action<SqlRawVisitorWithContext, ResampleStatisticsOption> VisForResampleStatisticsOption;
        public Action<SqlRawVisitorWithContext, StatisticsPartitionRange> VisForStatisticsPartitionRange;
        public Action<SqlRawVisitorWithContext, OnOffStatisticsOption> VisForOnOffStatisticsOption;
        public Action<SqlRawVisitorWithContext, LiteralStatisticsOption> VisForLiteralStatisticsOption;
        public Action<SqlRawVisitorWithContext, CreateStatisticsStatement> VisForCreateStatisticsStatement;
        public Action<SqlRawVisitorWithContext, UpdateStatisticsStatement> VisForUpdateStatisticsStatement;
        public Action<SqlRawVisitorWithContext, ReturnStatement> VisForReturnStatement;
        public Action<SqlRawVisitorWithContext, DeclareCursorStatement> VisForDeclareCursorStatement;
        public Action<SqlRawVisitorWithContext, CursorDefinition> VisForCursorDefinition;
        public Action<SqlRawVisitorWithContext, CursorOption> VisForCursorOption;
        public Action<SqlRawVisitorWithContext, SetVariableStatement> VisForSetVariableStatement;
        public Action<SqlRawVisitorWithContext, CursorId> VisForCursorId;
        public Action<SqlRawVisitorWithContext, OpenCursorStatement> VisForOpenCursorStatement;
        public Action<SqlRawVisitorWithContext, CloseCursorStatement> VisForCloseCursorStatement;
        public Action<SqlRawVisitorWithContext, CryptoMechanism> VisForCryptoMechanism;
        public Action<SqlRawVisitorWithContext, OpenSymmetricKeyStatement> VisForOpenSymmetricKeyStatement;
        public Action<SqlRawVisitorWithContext, CloseSymmetricKeyStatement> VisForCloseSymmetricKeyStatement;
        public Action<SqlRawVisitorWithContext, OpenMasterKeyStatement> VisForOpenMasterKeyStatement;
        public Action<SqlRawVisitorWithContext, CloseMasterKeyStatement> VisForCloseMasterKeyStatement;
        public Action<SqlRawVisitorWithContext, DeallocateCursorStatement> VisForDeallocateCursorStatement;
        public Action<SqlRawVisitorWithContext, FetchType> VisForFetchType;
        public Action<SqlRawVisitorWithContext, FetchCursorStatement> VisForFetchCursorStatement;
        public Action<SqlRawVisitorWithContext, FileTableCollateFileNameTableOption> VisForFileTableCollateFileNameTableOption;
        public Action<SqlRawVisitorWithContext, FileTableConstraintNameTableOption> VisForFileTableConstraintNameTableOption;
        public Action<SqlRawVisitorWithContext, MemoryOptimizedTableOption> VisForMemoryOptimizedTableOption;
        public Action<SqlRawVisitorWithContext, DurabilityTableOption> VisForDurabilityTableOption;
        public Action<SqlRawVisitorWithContext, RemoteDataArchiveTableOption> VisForRemoteDataArchiveTableOption;
        public Action<SqlRawVisitorWithContext, RemoteDataArchiveAlterTableOption> VisForRemoteDataArchiveAlterTableOption;
        public Action<SqlRawVisitorWithContext, RemoteDataArchiveDatabaseOption> VisForRemoteDataArchiveDatabaseOption;
        public Action<SqlRawVisitorWithContext, RemoteDataArchiveDbServerSetting> VisForRemoteDataArchiveDbServerSetting;
        public Action<SqlRawVisitorWithContext, RemoteDataArchiveDbCredentialSetting> VisForRemoteDataArchiveDbCredentialSetting;
        public Action<SqlRawVisitorWithContext, RemoteDataArchiveDbFederatedServiceAccountSetting> VisForRemoteDataArchiveDbFederatedServiceAccountSetting;
        public Action<SqlRawVisitorWithContext, RetentionPeriodDefinition> VisForRetentionPeriodDefinition;
        public Action<SqlRawVisitorWithContext, SystemVersioningTableOption> VisForSystemVersioningTableOption;
        public Action<SqlRawVisitorWithContext, LedgerTableOption> VisForLedgerTableOption;
        public Action<SqlRawVisitorWithContext, LedgerViewOption> VisForLedgerViewOption;
        public Action<SqlRawVisitorWithContext, DataRetentionTableOption> VisForDataRetentionTableOption;
        public Action<SqlRawVisitorWithContext, AlterTableAddTableElementStatement> VisForAlterTableAddTableElementStatement;
        public Action<SqlRawVisitorWithContext, AlterTableConstraintModificationStatement> VisForAlterTableConstraintModificationStatement;
        public Action<SqlRawVisitorWithContext, AlterTableSwitchStatement> VisForAlterTableSwitchStatement;
        public Action<SqlRawVisitorWithContext, LowPriorityLockWaitTableSwitchOption> VisForLowPriorityLockWaitTableSwitchOption;
        public Action<SqlRawVisitorWithContext, TruncateTargetTableSwitchOption> VisForTruncateTargetTableSwitchOption;
        public Action<SqlRawVisitorWithContext, DropClusteredConstraintStateOption> VisForDropClusteredConstraintStateOption;
        public Action<SqlRawVisitorWithContext, DropClusteredConstraintValueOption> VisForDropClusteredConstraintValueOption;
        public Action<SqlRawVisitorWithContext, DropClusteredConstraintMoveOption> VisForDropClusteredConstraintMoveOption;
        public Action<SqlRawVisitorWithContext, DropClusteredConstraintWaitAtLowPriorityLockOption> VisForDropClusteredConstraintWaitAtLowPriorityLockOption;
        public Action<SqlRawVisitorWithContext, AlterTableDropTableElement> VisForAlterTableDropTableElement;
        public Action<SqlRawVisitorWithContext, AlterTableDropTableElementStatement> VisForAlterTableDropTableElementStatement;
        public Action<SqlRawVisitorWithContext, AlterTableTriggerModificationStatement> VisForAlterTableTriggerModificationStatement;
        public Action<SqlRawVisitorWithContext, EnableDisableTriggerStatement> VisForEnableDisableTriggerStatement;
        public Action<SqlRawVisitorWithContext, TryCatchStatement> VisForTryCatchStatement;
        public Action<SqlRawVisitorWithContext, CreateTypeUdtStatement> VisForCreateTypeUdtStatement;
        public Action<SqlRawVisitorWithContext, CreateTypeUddtStatement> VisForCreateTypeUddtStatement;
        public Action<SqlRawVisitorWithContext, CreateSynonymStatement> VisForCreateSynonymStatement;
        public Action<SqlRawVisitorWithContext, ExecuteAsClause> VisForExecuteAsClause;
        public Action<SqlRawVisitorWithContext, QueueOption> VisForQueueOption;
        public Action<SqlRawVisitorWithContext, QueueStateOption> VisForQueueStateOption;
        public Action<SqlRawVisitorWithContext, QueueProcedureOption> VisForQueueProcedureOption;
        public Action<SqlRawVisitorWithContext, QueueValueOption> VisForQueueValueOption;
        public Action<SqlRawVisitorWithContext, QueueExecuteAsOption> VisForQueueExecuteAsOption;
        public Action<SqlRawVisitorWithContext, RouteOption> VisForRouteOption;
        public Action<SqlRawVisitorWithContext, AlterRouteStatement> VisForAlterRouteStatement;
        public Action<SqlRawVisitorWithContext, CreateRouteStatement> VisForCreateRouteStatement;
        public Action<SqlRawVisitorWithContext, AlterQueueStatement> VisForAlterQueueStatement;
        public Action<SqlRawVisitorWithContext, CreateQueueStatement> VisForCreateQueueStatement;
        public Action<SqlRawVisitorWithContext, IndexDefinition> VisForIndexDefinition;
        public Action<SqlRawVisitorWithContext, SystemTimePeriodDefinition> VisForSystemTimePeriodDefinition;
        public Action<SqlRawVisitorWithContext, IndexType> VisForIndexType;
        public Action<SqlRawVisitorWithContext, PartitionSpecifier> VisForPartitionSpecifier;
        public Action<SqlRawVisitorWithContext, AlterIndexStatement> VisForAlterIndexStatement;
        public Action<SqlRawVisitorWithContext, CreateXmlIndexStatement> VisForCreateXmlIndexStatement;
        public Action<SqlRawVisitorWithContext, CreateSelectiveXmlIndexStatement> VisForCreateSelectiveXmlIndexStatement;
        public Action<SqlRawVisitorWithContext, FileGroupOrPartitionScheme> VisForFileGroupOrPartitionScheme;
        public Action<SqlRawVisitorWithContext, CreateIndexStatement> VisForCreateIndexStatement;
        public Action<SqlRawVisitorWithContext, IndexStateOption> VisForIndexStateOption;
        public Action<SqlRawVisitorWithContext, IndexExpressionOption> VisForIndexExpressionOption;
        public Action<SqlRawVisitorWithContext, MaxDurationOption> VisForMaxDurationOption;
        public Action<SqlRawVisitorWithContext, WaitAtLowPriorityOption> VisForWaitAtLowPriorityOption;
        public Action<SqlRawVisitorWithContext, ColumnMasterKeyEnclaveComputationsParameter> VisForColumnMasterKeyEnclaveComputationsParameter;
        public Action<SqlRawVisitorWithContext, DropColumnMasterKeyStatement> VisForDropColumnMasterKeyStatement;
        public Action<SqlRawVisitorWithContext, CreateColumnEncryptionKeyStatement> VisForCreateColumnEncryptionKeyStatement;
        public Action<SqlRawVisitorWithContext, AlterColumnEncryptionKeyStatement> VisForAlterColumnEncryptionKeyStatement;
        public Action<SqlRawVisitorWithContext, DropColumnEncryptionKeyStatement> VisForDropColumnEncryptionKeyStatement;
        public Action<SqlRawVisitorWithContext, ColumnEncryptionKeyValue> VisForColumnEncryptionKeyValue;
        public Action<SqlRawVisitorWithContext, ColumnMasterKeyNameParameter> VisForColumnMasterKeyNameParameter;
        public Action<SqlRawVisitorWithContext, ColumnEncryptionAlgorithmNameParameter> VisForColumnEncryptionAlgorithmNameParameter;
        public Action<SqlRawVisitorWithContext, EncryptedValueParameter> VisForEncryptedValueParameter;
        public Action<SqlRawVisitorWithContext, ExternalTableLiteralOrIdentifierOption> VisForExternalTableLiteralOrIdentifierOption;
        public Action<SqlRawVisitorWithContext, ExternalTableDistributionOption> VisForExternalTableDistributionOption;
        public Action<SqlRawVisitorWithContext, ExternalTableRejectTypeOption> VisForExternalTableRejectTypeOption;
        public Action<SqlRawVisitorWithContext, ExternalTableReplicatedDistributionPolicy> VisForExternalTableReplicatedDistributionPolicy;
        public Action<SqlRawVisitorWithContext, ExternalTableRoundRobinDistributionPolicy> VisForExternalTableRoundRobinDistributionPolicy;
        public Action<SqlRawVisitorWithContext, ExternalTableShardedDistributionPolicy> VisForExternalTableShardedDistributionPolicy;
        public Action<SqlRawVisitorWithContext, CreateExternalTableStatement> VisForCreateExternalTableStatement;
        public Action<SqlRawVisitorWithContext, DropExternalTableStatement> VisForDropExternalTableStatement;
        public Action<SqlRawVisitorWithContext, ExternalDataSourceLiteralOrIdentifierOption> VisForExternalDataSourceLiteralOrIdentifierOption;
        public Action<SqlRawVisitorWithContext, CreateExternalDataSourceStatement> VisForCreateExternalDataSourceStatement;
        public Action<SqlRawVisitorWithContext, AlterExternalDataSourceStatement> VisForAlterExternalDataSourceStatement;
        public Action<SqlRawVisitorWithContext, DropExternalDataSourceStatement> VisForDropExternalDataSourceStatement;
        public Action<SqlRawVisitorWithContext, ExternalStreamLiteralOrIdentifierOption> VisForExternalStreamLiteralOrIdentifierOption;
        public Action<SqlRawVisitorWithContext, CreateExternalStreamStatement> VisForCreateExternalStreamStatement;
        public Action<SqlRawVisitorWithContext, DropExternalStreamStatement> VisForDropExternalStreamStatement;
        public Action<SqlRawVisitorWithContext, ExternalFileFormatLiteralOption> VisForExternalFileFormatLiteralOption;
        public Action<SqlRawVisitorWithContext, ExternalFileFormatUseDefaultTypeOption> VisForExternalFileFormatUseDefaultTypeOption;
        public Action<SqlRawVisitorWithContext, ExternalFileFormatContainerOption> VisForExternalFileFormatContainerOption;
        public Action<SqlRawVisitorWithContext, CreateExternalFileFormatStatement> VisForCreateExternalFileFormatStatement;
        public Action<SqlRawVisitorWithContext, DropExternalFileFormatStatement> VisForDropExternalFileFormatStatement;
        public Action<SqlRawVisitorWithContext, CreateExternalStreamingJobStatement> VisForCreateExternalStreamingJobStatement;
        public Action<SqlRawVisitorWithContext, DropExternalStreamingJobStatement> VisForDropExternalStreamingJobStatement;
        public Action<SqlRawVisitorWithContext, CreateAssemblyStatement> VisForCreateAssemblyStatement;
        public Action<SqlRawVisitorWithContext, AlterAssemblyStatement> VisForAlterAssemblyStatement;
        public Action<SqlRawVisitorWithContext, AssemblyOption> VisForAssemblyOption;
        public Action<SqlRawVisitorWithContext, OnOffAssemblyOption> VisForOnOffAssemblyOption;
        public Action<SqlRawVisitorWithContext, PermissionSetAssemblyOption> VisForPermissionSetAssemblyOption;
        public Action<SqlRawVisitorWithContext, AddFileSpec> VisForAddFileSpec;
        public Action<SqlRawVisitorWithContext, CreateXmlSchemaCollectionStatement> VisForCreateXmlSchemaCollectionStatement;
        public Action<SqlRawVisitorWithContext, AlterXmlSchemaCollectionStatement> VisForAlterXmlSchemaCollectionStatement;
        public Action<SqlRawVisitorWithContext, DropXmlSchemaCollectionStatement> VisForDropXmlSchemaCollectionStatement;
        public Action<SqlRawVisitorWithContext, AssemblyName> VisForAssemblyName;
        public Action<SqlRawVisitorWithContext, AlterTableAlterPartitionStatement> VisForAlterTableAlterPartitionStatement;
        public Action<SqlRawVisitorWithContext, AlterTableRebuildStatement> VisForAlterTableRebuildStatement;
        public Action<SqlRawVisitorWithContext, AlterTableChangeTrackingModificationStatement> VisForAlterTableChangeTrackingModificationStatement;
        public Action<SqlRawVisitorWithContext, AlterTableFileTableNamespaceStatement> VisForAlterTableFileTableNamespaceStatement;
        public Action<SqlRawVisitorWithContext, AlterTableSetStatement> VisForAlterTableSetStatement;
        public Action<SqlRawVisitorWithContext, LockEscalationTableOption> VisForLockEscalationTableOption;
        public Action<SqlRawVisitorWithContext, FileStreamOnTableOption> VisForFileStreamOnTableOption;
        public Action<SqlRawVisitorWithContext, FileTableDirectoryTableOption> VisForFileTableDirectoryTableOption;
        public Action<SqlRawVisitorWithContext, GrantStatement80> VisForGrantStatement80;
        public Action<SqlRawVisitorWithContext, DenyStatement80> VisForDenyStatement80;
        public Action<SqlRawVisitorWithContext, RevokeStatement80> VisForRevokeStatement80;
        public Action<SqlRawVisitorWithContext, CommandSecurityElement80> VisForCommandSecurityElement80;
        public Action<SqlRawVisitorWithContext, PrivilegeSecurityElement80> VisForPrivilegeSecurityElement80;
        public Action<SqlRawVisitorWithContext, Privilege80> VisForPrivilege80;
        public Action<SqlRawVisitorWithContext, SecurityUserClause80> VisForSecurityUserClause80;
        public Action<SqlRawVisitorWithContext, SqlCommandIdentifier> VisForSqlCommandIdentifier;
        public Action<SqlRawVisitorWithContext, AssignmentSetClause> VisForAssignmentSetClause;
        public Action<SqlRawVisitorWithContext, FunctionCallSetClause> VisForFunctionCallSetClause;
        public Action<SqlRawVisitorWithContext, ValuesInsertSource> VisForValuesInsertSource;
        public Action<SqlRawVisitorWithContext, SelectInsertSource> VisForSelectInsertSource;
        public Action<SqlRawVisitorWithContext, ExecuteInsertSource> VisForExecuteInsertSource;
        public Action<SqlRawVisitorWithContext, RowValue> VisForRowValue;
        public Action<SqlRawVisitorWithContext, PrintStatement> VisForPrintStatement;
        public Action<SqlRawVisitorWithContext, UpdateCall> VisForUpdateCall;
        public Action<SqlRawVisitorWithContext, TSEqualCall> VisForTSEqualCall;
        public Action<SqlRawVisitorWithContext, IntegerLiteral> VisForIntegerLiteral;
        public Action<SqlRawVisitorWithContext, NumericLiteral> VisForNumericLiteral;
        public Action<SqlRawVisitorWithContext, RealLiteral> VisForRealLiteral;
        public Action<SqlRawVisitorWithContext, MoneyLiteral> VisForMoneyLiteral;
        public Action<SqlRawVisitorWithContext, BinaryLiteral> VisForBinaryLiteral;
        public Action<SqlRawVisitorWithContext, StringLiteral> VisForStringLiteral;
        public Action<SqlRawVisitorWithContext, NullLiteral> VisForNullLiteral;
        public Action<SqlRawVisitorWithContext, IdentifierLiteral> VisForIdentifierLiteral;
        public Action<SqlRawVisitorWithContext, DefaultLiteral> VisForDefaultLiteral;
        public Action<SqlRawVisitorWithContext, MaxLiteral> VisForMaxLiteral;
        public Action<SqlRawVisitorWithContext, OdbcLiteral> VisForOdbcLiteral;
        public Action<SqlRawVisitorWithContext, LiteralRange> VisForLiteralRange;
        public Action<SqlRawVisitorWithContext, VariableReference> VisForVariableReference;
        public Action<SqlRawVisitorWithContext, OnOffOptionValue> VisForOnOffOptionValue;
        public Action<SqlRawVisitorWithContext, LiteralOptionValue> VisForLiteralOptionValue;
        public Action<SqlRawVisitorWithContext, GlobalVariableExpression> VisForGlobalVariableExpression;
        public Action<SqlRawVisitorWithContext, IdentifierOrValueExpression> VisForIdentifierOrValueExpression;
        public Action<SqlRawVisitorWithContext, IdentifierOrScalarExpression> VisForIdentifierOrScalarExpression;
        public Action<SqlRawVisitorWithContext, SchemaObjectNameOrValueExpression> VisForSchemaObjectNameOrValueExpression;
        public Action<SqlRawVisitorWithContext, ParenthesisExpression> VisForParenthesisExpression;
        public Action<SqlRawVisitorWithContext, ColumnReferenceExpression> VisForColumnReferenceExpression;
        public Action<SqlRawVisitorWithContext, NextValueForExpression> VisForNextValueForExpression;
        public Action<SqlRawVisitorWithContext, SequenceOption> VisForSequenceOption;
        public Action<SqlRawVisitorWithContext, DataTypeSequenceOption> VisForDataTypeSequenceOption;
        public Action<SqlRawVisitorWithContext, ScalarExpressionSequenceOption> VisForScalarExpressionSequenceOption;
        public Action<SqlRawVisitorWithContext, CreateSequenceStatement> VisForCreateSequenceStatement;
        public Action<SqlRawVisitorWithContext, AlterSequenceStatement> VisForAlterSequenceStatement;
        public Action<SqlRawVisitorWithContext, DropSequenceStatement> VisForDropSequenceStatement;
        public Action<SqlRawVisitorWithContext, SecurityPredicateAction> VisForSecurityPredicateAction;
        public Action<SqlRawVisitorWithContext, SecurityPolicyOption> VisForSecurityPolicyOption;
        public Action<SqlRawVisitorWithContext, CreateSecurityPolicyStatement> VisForCreateSecurityPolicyStatement;
        public Action<SqlRawVisitorWithContext, AlterSecurityPolicyStatement> VisForAlterSecurityPolicyStatement;
        public Action<SqlRawVisitorWithContext, DropSecurityPolicyStatement> VisForDropSecurityPolicyStatement;
        public Action<SqlRawVisitorWithContext, CreateColumnMasterKeyStatement> VisForCreateColumnMasterKeyStatement;
        public Action<SqlRawVisitorWithContext, ColumnMasterKeyStoreProviderNameParameter> VisForColumnMasterKeyStoreProviderNameParameter;
        public Action<SqlRawVisitorWithContext, ColumnMasterKeyPathParameter> VisForColumnMasterKeyPathParameter;
        public Action<SqlRawVisitorWithContext, ExpressionCallTarget> VisForExpressionCallTarget;
        public Action<SqlRawVisitorWithContext, MultiPartIdentifierCallTarget> VisForMultiPartIdentifierCallTarget;
        public Action<SqlRawVisitorWithContext, UserDefinedTypeCallTarget> VisForUserDefinedTypeCallTarget;
        public Action<SqlRawVisitorWithContext, LeftFunctionCall> VisForLeftFunctionCall;
        public Action<SqlRawVisitorWithContext, RightFunctionCall> VisForRightFunctionCall;
        public Action<SqlRawVisitorWithContext, PartitionFunctionCall> VisForPartitionFunctionCall;
        public Action<SqlRawVisitorWithContext, OverClause> VisForOverClause;
        public Action<SqlRawVisitorWithContext, ParameterlessCall> VisForParameterlessCall;
        public Action<SqlRawVisitorWithContext, ScalarSubquery> VisForScalarSubquery;
        public Action<SqlRawVisitorWithContext, OdbcFunctionCall> VisForOdbcFunctionCall;
        public Action<SqlRawVisitorWithContext, ExtractFromExpression> VisForExtractFromExpression;
        public Action<SqlRawVisitorWithContext, OdbcConvertSpecification> VisForOdbcConvertSpecification;
        public Action<SqlRawVisitorWithContext, AlterFunctionStatement> VisForAlterFunctionStatement;
        public Action<SqlRawVisitorWithContext, BeginEndBlockStatement> VisForBeginEndBlockStatement;
        public Action<SqlRawVisitorWithContext, BeginEndAtomicBlockStatement> VisForBeginEndAtomicBlockStatement;
        public Action<SqlRawVisitorWithContext, LiteralAtomicBlockOption> VisForLiteralAtomicBlockOption;
        public Action<SqlRawVisitorWithContext, IdentifierAtomicBlockOption> VisForIdentifierAtomicBlockOption;
        public Action<SqlRawVisitorWithContext, OnOffAtomicBlockOption> VisForOnOffAtomicBlockOption;
        public Action<SqlRawVisitorWithContext, BeginTransactionStatement> VisForBeginTransactionStatement;
        public Action<SqlRawVisitorWithContext, BreakStatement> VisForBreakStatement;
        public Action<SqlRawVisitorWithContext, ColumnWithSortOrder> VisForColumnWithSortOrder;
        public Action<SqlRawVisitorWithContext, CommitTransactionStatement> VisForCommitTransactionStatement;
        public Action<SqlRawVisitorWithContext, RollbackTransactionStatement> VisForRollbackTransactionStatement;
        public Action<SqlRawVisitorWithContext, SaveTransactionStatement> VisForSaveTransactionStatement;
        public Action<SqlRawVisitorWithContext, ContinueStatement> VisForContinueStatement;
        public Action<SqlRawVisitorWithContext, CreateDefaultStatement> VisForCreateDefaultStatement;
        public Action<SqlRawVisitorWithContext, CreateFunctionStatement> VisForCreateFunctionStatement;
        public Action<SqlRawVisitorWithContext, CreateOrAlterFunctionStatement> VisForCreateOrAlterFunctionStatement;
        public Action<SqlRawVisitorWithContext, CreateRuleStatement> VisForCreateRuleStatement;
        public Action<SqlRawVisitorWithContext, DeclareVariableElement> VisForDeclareVariableElement;
        public Action<SqlRawVisitorWithContext, DeclareVariableStatement> VisForDeclareVariableStatement;
        public Action<SqlRawVisitorWithContext, GoToStatement> VisForGoToStatement;
        public Action<SqlRawVisitorWithContext, IfStatement> VisForIfStatement;
        public Action<SqlRawVisitorWithContext, LabelStatement> VisForLabelStatement;
        public Action<SqlRawVisitorWithContext, MultiPartIdentifier> VisForMultiPartIdentifier;
        public Action<SqlRawVisitorWithContext, SchemaObjectName> VisForSchemaObjectName;
        public Action<SqlRawVisitorWithContext, ChildObjectName> VisForChildObjectName;
        public Action<SqlRawVisitorWithContext, ProcedureParameter> VisForProcedureParameter;
        public Action<SqlRawVisitorWithContext, WhileStatement> VisForWhileStatement;
        public Action<SqlRawVisitorWithContext, DeleteStatement> VisForDeleteStatement;
        public Action<SqlRawVisitorWithContext, DeleteSpecification> VisForDeleteSpecification;
        public Action<SqlRawVisitorWithContext, InsertStatement> VisForInsertStatement;
        public Action<SqlRawVisitorWithContext, InsertSpecification> VisForInsertSpecification;
        public Action<SqlRawVisitorWithContext, UpdateStatement> VisForUpdateStatement;
        public Action<SqlRawVisitorWithContext, UpdateSpecification> VisForUpdateSpecification;
        public Action<SqlRawVisitorWithContext, CreateSchemaStatement> VisForCreateSchemaStatement;
        public Action<SqlRawVisitorWithContext, WaitForStatement> VisForWaitForStatement;
        public Action<SqlRawVisitorWithContext, ReadTextStatement> VisForReadTextStatement;
        public Action<SqlRawVisitorWithContext, UpdateTextStatement> VisForUpdateTextStatement;
        public Action<SqlRawVisitorWithContext, WriteTextStatement> VisForWriteTextStatement;
        public Action<SqlRawVisitorWithContext, LineNoStatement> VisForLineNoStatement;
        public Action<SqlRawVisitorWithContext, GrantStatement> VisForGrantStatement;
        public Action<SqlRawVisitorWithContext, DenyStatement> VisForDenyStatement;
        public Action<SqlRawVisitorWithContext, RevokeStatement> VisForRevokeStatement;
        public Action<SqlRawVisitorWithContext, AlterAuthorizationStatement> VisForAlterAuthorizationStatement;
        public Action<SqlRawVisitorWithContext, Permission> VisForPermission;
        public Action<SqlRawVisitorWithContext, SecurityTargetObject> VisForSecurityTargetObject;
        public Action<SqlRawVisitorWithContext, SecurityTargetObjectName> VisForSecurityTargetObjectName;
        public Action<SqlRawVisitorWithContext, SecurityPrincipal> VisForSecurityPrincipal;
        public Action<SqlRawVisitorWithContext, ScalarFunctionReturnType> VisForScalarFunctionReturnType;
        public Action<SqlRawVisitorWithContext, SelectFunctionReturnType> VisForSelectFunctionReturnType;
        public Action<SqlRawVisitorWithContext, TableDefinition> VisForTableDefinition;
        public Action<SqlRawVisitorWithContext, DeclareTableVariableBody> VisForDeclareTableVariableBody;
        public Action<SqlRawVisitorWithContext, DeclareTableVariableStatement> VisForDeclareTableVariableStatement;
        public Action<SqlRawVisitorWithContext, NamedTableReference> VisForNamedTableReference;
        public Action<SqlRawVisitorWithContext, SchemaObjectFunctionTableReference> VisForSchemaObjectFunctionTableReference;
        public Action<SqlRawVisitorWithContext, TableHint> VisForTableHint;
        public Action<SqlRawVisitorWithContext, IndexTableHint> VisForIndexTableHint;
        public Action<SqlRawVisitorWithContext, LiteralTableHint> VisForLiteralTableHint;
        public Action<SqlRawVisitorWithContext, QueryDerivedTable> VisForQueryDerivedTable;
        public Action<SqlRawVisitorWithContext, InlineDerivedTable> VisForInlineDerivedTable;
        public Action<SqlRawVisitorWithContext, SubqueryComparisonPredicate> VisForSubqueryComparisonPredicate;
        public Action<SqlRawVisitorWithContext, ExistsPredicate> VisForExistsPredicate;
        public Action<SqlRawVisitorWithContext, LikePredicate> VisForLikePredicate;
        public Action<SqlRawVisitorWithContext, InPredicate> VisForInPredicate;
        public Action<SqlRawVisitorWithContext, FullTextPredicate> VisForFullTextPredicate;
        public Action<SqlRawVisitorWithContext, UserDefinedTypePropertyAccess> VisForUserDefinedTypePropertyAccess;
        public Action<SqlRawVisitorWithContext, SelectStatement> VisForSelectStatement;
        public Action<SqlRawVisitorWithContext, BrowseForClause> VisForBrowseForClause;
        public Action<SqlRawVisitorWithContext, ReadOnlyForClause> VisForReadOnlyForClause;
        public Action<SqlRawVisitorWithContext, XmlForClause> VisForXmlForClause;
        public Action<SqlRawVisitorWithContext, XmlForClauseOption> VisForXmlForClauseOption;
        public Action<SqlRawVisitorWithContext, JsonForClause> VisForJsonForClause;
        public Action<SqlRawVisitorWithContext, JsonForClauseOption> VisForJsonForClauseOption;
        public Action<SqlRawVisitorWithContext, UpdateForClause> VisForUpdateForClause;
        public Action<SqlRawVisitorWithContext, OptimizerHint> VisForOptimizerHint;
        public Action<SqlRawVisitorWithContext, LiteralOptimizerHint> VisForLiteralOptimizerHint;
        public Action<SqlRawVisitorWithContext, TableHintsOptimizerHint> VisForTableHintsOptimizerHint;
        public Action<SqlRawVisitorWithContext, ForceSeekTableHint> VisForForceSeekTableHint;
        public Action<SqlRawVisitorWithContext, OptimizeForOptimizerHint> VisForOptimizeForOptimizerHint;
        public Action<SqlRawVisitorWithContext, UseHintList> VisForUseHintList;
        public Action<SqlRawVisitorWithContext, VariableValuePair> VisForVariableValuePair;
        public Action<SqlRawVisitorWithContext, SimpleWhenClause> VisForSimpleWhenClause;
        public Action<SqlRawVisitorWithContext, SearchedWhenClause> VisForSearchedWhenClause;
        public Action<SqlRawVisitorWithContext, SimpleCaseExpression> VisForSimpleCaseExpression;
        public Action<SqlRawVisitorWithContext, SearchedCaseExpression> VisForSearchedCaseExpression;
        public Action<SqlRawVisitorWithContext, NullIfExpression> VisForNullIfExpression;
        public Action<SqlRawVisitorWithContext, CoalesceExpression> VisForCoalesceExpression;
        public Action<SqlRawVisitorWithContext, IIfCall> VisForIIfCall;
        public Action<SqlRawVisitorWithContext, FullTextTableReference> VisForFullTextTableReference;
        public Action<SqlRawVisitorWithContext, SemanticTableReference> VisForSemanticTableReference;
        public Action<SqlRawVisitorWithContext, OpenXmlTableReference> VisForOpenXmlTableReference;
        public Action<SqlRawVisitorWithContext, OpenJsonTableReference> VisForOpenJsonTableReference;
        public Action<SqlRawVisitorWithContext, OpenRowsetTableReference> VisForOpenRowsetTableReference;
        public Action<SqlRawVisitorWithContext, InternalOpenRowset> VisForInternalOpenRowset;
        public Action<SqlRawVisitorWithContext, BulkOpenRowset> VisForBulkOpenRowset;
        public Action<SqlRawVisitorWithContext, OpenQueryTableReference> VisForOpenQueryTableReference;
        public Action<SqlRawVisitorWithContext, AdHocTableReference> VisForAdHocTableReference;
        public Action<SqlRawVisitorWithContext, SchemaDeclarationItem> VisForSchemaDeclarationItem;
        public Action<SqlRawVisitorWithContext, SchemaDeclarationItemOpenjson> VisForSchemaDeclarationItemOpenjson;
        public Action<SqlRawVisitorWithContext, ConvertCall> VisForConvertCall;
        public Action<SqlRawVisitorWithContext, TryConvertCall> VisForTryConvertCall;
        public Action<SqlRawVisitorWithContext, ParseCall> VisForParseCall;
        public Action<SqlRawVisitorWithContext, TryParseCall> VisForTryParseCall;
        public Action<SqlRawVisitorWithContext, CastCall> VisForCastCall;
        public Action<SqlRawVisitorWithContext, TryCastCall> VisForTryCastCall;
        public Action<SqlRawVisitorWithContext, AtTimeZoneCall> VisForAtTimeZoneCall;
        public Action<SqlRawVisitorWithContext, FunctionCall> VisForFunctionCall;
        public Action<SqlRawVisitorWithContext, StatementList> VisForStatementList;
        public Action<SqlRawVisitorWithContext, ExecuteStatement> VisForExecuteStatement;
        public Action<SqlRawVisitorWithContext, ExecuteOption> VisForExecuteOption;
        public Action<SqlRawVisitorWithContext, ResultSetsExecuteOption> VisForResultSetsExecuteOption;
        public Action<SqlRawVisitorWithContext, ResultSetDefinition> VisForResultSetDefinition;
        public Action<SqlRawVisitorWithContext, InlineResultSetDefinition> VisForInlineResultSetDefinition;
        public Action<SqlRawVisitorWithContext, ResultColumnDefinition> VisForResultColumnDefinition;
        public Action<SqlRawVisitorWithContext, SchemaObjectResultSetDefinition> VisForSchemaObjectResultSetDefinition;
        public Action<SqlRawVisitorWithContext, ExecuteSpecification> VisForExecuteSpecification;
        public Action<SqlRawVisitorWithContext, ExecuteContext> VisForExecuteContext;
        public Action<SqlRawVisitorWithContext, ExecuteParameter> VisForExecuteParameter;
        public Action<SqlRawVisitorWithContext, ProcedureReferenceName> VisForProcedureReferenceName;
        public Action<SqlRawVisitorWithContext, ExecutableProcedureReference> VisForExecutableProcedureReference;
        public Action<SqlRawVisitorWithContext, ExecutableStringList> VisForExecutableStringList;
        public Action<SqlRawVisitorWithContext, AdHocDataSource> VisForAdHocDataSource;
        public Action<SqlRawVisitorWithContext, ViewOption> VisForViewOption;
        public Action<SqlRawVisitorWithContext, AlterViewStatement> VisForAlterViewStatement;
        public Action<SqlRawVisitorWithContext, CreateViewStatement> VisForCreateViewStatement;
        public Action<SqlRawVisitorWithContext, CreateOrAlterViewStatement> VisForCreateOrAlterViewStatement;
        public Action<SqlRawVisitorWithContext, ViewForAppendOption> VisForViewForAppendOption;
        public Action<SqlRawVisitorWithContext, ViewDistributionOption> VisForViewDistributionOption;
        public Action<SqlRawVisitorWithContext, ViewRoundRobinDistributionPolicy> VisForViewRoundRobinDistributionPolicy;
        public Action<SqlRawVisitorWithContext, ViewHashDistributionPolicy> VisForViewHashDistributionPolicy;
        public Action<SqlRawVisitorWithContext, TriggerObject> VisForTriggerObject;
        public Action<SqlRawVisitorWithContext, TriggerOption> VisForTriggerOption;
        public Action<SqlRawVisitorWithContext, ExecuteAsTriggerOption> VisForExecuteAsTriggerOption;
        public Action<SqlRawVisitorWithContext, TriggerAction> VisForTriggerAction;
        public Action<SqlRawVisitorWithContext, AlterTriggerStatement> VisForAlterTriggerStatement;
        public Action<SqlRawVisitorWithContext, CreateTriggerStatement> VisForCreateTriggerStatement;
        public Action<SqlRawVisitorWithContext, CreateOrAlterTriggerStatement> VisForCreateOrAlterTriggerStatement;
        public Action<SqlRawVisitorWithContext, Identifier> VisForIdentifier;
        public Action<SqlRawVisitorWithContext, AlterProcedureStatement> VisForAlterProcedureStatement;
        public Action<SqlRawVisitorWithContext, CreateProcedureStatement> VisForCreateProcedureStatement;
        public Action<SqlRawVisitorWithContext, CreateOrAlterProcedureStatement> VisForCreateOrAlterProcedureStatement;
        public Action<SqlRawVisitorWithContext, ProcedureReference> VisForProcedureReference;
        public Action<SqlRawVisitorWithContext, MethodSpecifier> VisForMethodSpecifier;
        public Action<SqlRawVisitorWithContext, ProcedureOption> VisForProcedureOption;
        public Action<SqlRawVisitorWithContext, ExecuteAsProcedureOption> VisForExecuteAsProcedureOption;
        public Action<SqlRawVisitorWithContext, FunctionOption> VisForFunctionOption;
        public Action<SqlRawVisitorWithContext, InlineFunctionOption> VisForInlineFunctionOption;
        public Action<SqlRawVisitorWithContext, ExecuteAsFunctionOption> VisForExecuteAsFunctionOption;
        public Action<SqlRawVisitorWithContext, XmlNamespaces> VisForXmlNamespaces;
        public Action<SqlRawVisitorWithContext, XmlNamespacesDefaultElement> VisForXmlNamespacesDefaultElement;
        public Action<SqlRawVisitorWithContext, XmlNamespacesAliasElement> VisForXmlNamespacesAliasElement;
        public Action<SqlRawVisitorWithContext, CommonTableExpression> VisForCommonTableExpression;
        public Action<SqlRawVisitorWithContext, WithCtesAndXmlNamespaces> VisForWithCtesAndXmlNamespaces;
        public Action<SqlRawVisitorWithContext, TableValuedFunctionReturnType> VisForTableValuedFunctionReturnType;
        public Action<SqlRawVisitorWithContext, SqlDataTypeReference> VisForSqlDataTypeReference;
        public Action<SqlRawVisitorWithContext, UserDataTypeReference> VisForUserDataTypeReference;
        public Action<SqlRawVisitorWithContext, XmlDataTypeReference> VisForXmlDataTypeReference;

        public SqlRawVisitorWithContext() : base() { }

        void PushContext(TSqlFragment node)
        {
            Parents.Push(node);
        }

        void PopContext(TSqlFragment node)
        {
            Parents.Pop();
        }

        public void EnqueueOnLeave(TSqlFragment node, Action<TSqlFragment> edit)
        {
            if (!PendingOnLeaveActionsByFragment.TryGetValue(node, out var edits))
            {
                edits = PendingOnLeaveActionsByFragment[node] = new Queue<Action<TSqlFragment>>();
            }
            edits.Enqueue(edit);
        }

        public void HandleOnLeave(TSqlFragment node)
        {
            if (!PendingOnLeaveActionsByFragment.TryGetValue(node, out var actions))
            {
                return;
            }
            while (actions.Count > 0)
            {
                actions.Dequeue().Invoke(node);
            }

            PendingOnLeaveActionsByFragment.Remove(node);
        }

        public override void ExplicitVisit(CreateExternalLanguageStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalLanguageStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterExternalLanguageStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterExternalLanguageStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalLanguageFileOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalLanguageFileOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalLanguageStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalLanguageStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterEventSessionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterEventSessionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropEventSessionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropEventSessionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterResourceGovernorStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterResourceGovernorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSpatialIndexStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSpatialIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SpatialIndexRegularOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSpatialIndexRegularOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BoundingBoxSpatialIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBoundingBoxSpatialIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BoundingBoxParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBoundingBoxParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GridsSpatialIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGridsSpatialIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GridParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGridParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CellsPerObjectSpatialIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCellsPerObjectSpatialIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProcessAffinityRange node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProcessAffinityRange?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetExternalAuthenticationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSetExternalAuthenticationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationExternalAuthenticationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationExternalAuthenticationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationExternalAuthenticationContainerOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationExternalAuthenticationContainerOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetBufferPoolExtensionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSetBufferPoolExtensionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationBufferPoolExtensionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionContainerOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationBufferPoolExtensionContainerOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionSizeOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationBufferPoolExtensionSizeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetDiagnosticsLogStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSetDiagnosticsLogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationDiagnosticsLogOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogMaxSizeOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationDiagnosticsLogMaxSizeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetFailoverClusterPropertyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSetFailoverClusterPropertyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationFailoverClusterPropertyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationFailoverClusterPropertyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetHadrClusterStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSetHadrClusterStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationHadrClusterOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationHadrClusterOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetSoftNumaStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSetSoftNumaStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSoftNumaOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSoftNumaOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateAvailabilityGroupStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateAvailabilityGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAvailabilityGroupStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAvailabilityGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AvailabilityReplica node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAvailabilityReplica?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralReplicaOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralReplicaOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AvailabilityModeReplicaOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAvailabilityModeReplicaOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FailoverModeReplicaOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFailoverModeReplicaOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PrimaryRoleReplicaOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPrimaryRoleReplicaOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecondaryRoleReplicaOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecondaryRoleReplicaOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralAvailabilityGroupOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralAvailabilityGroupOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAvailabilityGroupAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAvailabilityGroupAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAvailabilityGroupFailoverAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAvailabilityGroupFailoverAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAvailabilityGroupFailoverOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAvailabilityGroupFailoverOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropAvailabilityGroupStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropAvailabilityGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateFederationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateFederationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterFederationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterFederationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropFederationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropFederationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UseFederationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUseFederationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DiskStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDiskStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DiskStatementOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDiskStatementOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateColumnStoreIndexStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateColumnStoreIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WindowFrameClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWindowFrameClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WindowDelimiter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWindowDelimiter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WithinGroupClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWithinGroupClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectiveXmlIndexPromotedPath node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectiveXmlIndexPromotedPath?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TemporalClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTemporalClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CompressionDelayIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCompressionDelayIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalLibraryStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalLibraryStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterExternalLibraryStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterExternalLibraryStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalLibraryFileOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalLibraryFileOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalLibraryStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalLibraryStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxRolloverFilesAuditTargetOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxRolloverFilesAuditTargetOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralAuditTargetOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralAuditTargetOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffAuditTargetOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffAuditTargetOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateDatabaseEncryptionKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateDatabaseEncryptionKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseEncryptionKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseEncryptionKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropDatabaseEncryptionKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropDatabaseEncryptionKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResourcePoolStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResourcePoolParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResourcePoolParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResourcePoolAffinitySpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResourcePoolAffinitySpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateResourcePoolStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterResourcePoolStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropResourcePoolStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalResourcePoolStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalResourcePoolParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalResourcePoolParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalResourcePoolAffinitySpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalResourcePoolAffinitySpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalResourcePoolStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterExternalResourcePoolStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterExternalResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalResourcePoolStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WorkloadGroupResourceParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWorkloadGroupResourceParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WorkloadGroupImportanceParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWorkloadGroupImportanceParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateWorkloadGroupStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateWorkloadGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterWorkloadGroupStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterWorkloadGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropWorkloadGroupStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropWorkloadGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierWorkloadGroupOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierWorkloadGroupOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierMemberNameOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierMemberNameOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierWlmLabelOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierWlmLabelOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierImportanceOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierImportanceOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierWlmContextOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierWlmContextOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierStartTimeOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierStartTimeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierEndTimeOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierEndTimeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WlmTimeLiteral node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWlmTimeLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateWorkloadClassifierStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateWorkloadClassifierStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropWorkloadClassifierStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropWorkloadClassifierStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BrokerPriorityParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBrokerPriorityParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateBrokerPriorityStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateBrokerPriorityStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterBrokerPriorityStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterBrokerPriorityStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropBrokerPriorityStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropBrokerPriorityStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateFullTextStopListStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateFullTextStopListStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterFullTextStopListStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterFullTextStopListStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FullTextStopListAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFullTextStopListAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropFullTextStopListStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropFullTextStopListStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateCryptographicProviderStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateCryptographicProviderStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterCryptographicProviderStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterCryptographicProviderStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropCryptographicProviderStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropCryptographicProviderStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventSessionObjectName node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventSessionObjectName?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventSessionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventSessionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateEventSessionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateEventSessionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventDeclaration node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventDeclaration?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventDeclarationSetParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventDeclarationSetParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SourceDeclaration node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSourceDeclaration?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventDeclarationCompareFunctionParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventDeclarationCompareFunctionParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TargetDeclaration node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTargetDeclaration?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventRetentionSessionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventRetentionSessionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MemoryPartitionSessionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMemoryPartitionSessionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralSessionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralSessionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxDispatchLatencySessionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxDispatchLatencySessionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffSessionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffSessionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterSchemaStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterSchemaStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAsymmetricKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAsymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServiceMasterKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServiceMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BeginConversationTimerStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBeginConversationTimerStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BeginDialogStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBeginDialogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ScalarExpressionDialogOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForScalarExpressionDialogOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffDialogOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffDialogOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupCertificateStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupCertificateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupServiceMasterKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupServiceMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RestoreServiceMasterKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRestoreServiceMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupMasterKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RestoreMasterKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRestoreMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ScalarExpressionSnippet node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForScalarExpressionSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanExpressionSnippet node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanExpressionSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StatementListSnippet node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStatementListSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectStatementSnippet node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectStatementSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaObjectNameSnippet node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaObjectNameSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TSqlFragmentSnippet node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTSqlFragmentSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TSqlStatementSnippet node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTSqlStatementSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierSnippet node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TSqlScript node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTSqlScript?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TSqlBatch node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTSqlBatch?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MergeStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMergeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MergeSpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMergeSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MergeActionClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMergeActionClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateMergeAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateMergeAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeleteMergeAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeleteMergeAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InsertMergeAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInsertMergeAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateTypeTableStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateTypeTableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SensitivityClassificationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSensitivityClassificationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AddSensitivityClassificationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAddSensitivityClassificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSensitivityClassificationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSensitivityClassificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuditSpecificationPart node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuditSpecificationPart?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuditActionSpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuditActionSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DatabaseAuditAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDatabaseAuditAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuditActionGroupReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuditActionGroupReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateDatabaseAuditSpecificationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateDatabaseAuditSpecificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseAuditSpecificationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseAuditSpecificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropDatabaseAuditSpecificationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropDatabaseAuditSpecificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateServerAuditSpecificationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateServerAuditSpecificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerAuditSpecificationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerAuditSpecificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropServerAuditSpecificationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropServerAuditSpecificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateServerAuditStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateServerAuditStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerAuditStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerAuditStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropServerAuditStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropServerAuditStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuditTarget node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuditTarget?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueueDelayAuditOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueueDelayAuditOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuditGuidAuditOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuditGuidAuditOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnFailureAuditOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnFailureAuditOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StateAuditOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStateAuditOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxSizeAuditTargetOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxSizeAuditTargetOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RetentionDaysAuditTargetOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRetentionDaysAuditTargetOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropAssemblyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropAssemblyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropApplicationRoleStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropApplicationRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropFullTextCatalogStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropFullTextCatalogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropFullTextIndexStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropFullTextIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropLoginStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropLoginStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropRoleStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropTypeStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropTypeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropUserStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropUserStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropMasterKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSymmetricKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropAsymmetricKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropAsymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropCertificateStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropCertificateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropCredentialStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropCredentialStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterPartitionFunctionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterPartitionFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterPartitionSchemeStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterPartitionSchemeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterFullTextIndexStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterFullTextIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SimpleAlterFullTextIndexAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSimpleAlterFullTextIndexAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetStopListAlterFullTextIndexAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetStopListAlterFullTextIndexAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetSearchPropertyListAlterFullTextIndexAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetSearchPropertyListAlterFullTextIndexAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropAlterFullTextIndexAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropAlterFullTextIndexAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AddAlterFullTextIndexAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAddAlterFullTextIndexAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterColumnAlterFullTextIndexAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterColumnAlterFullTextIndexAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSearchPropertyListStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSearchPropertyListStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterSearchPropertyListStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterSearchPropertyListStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AddSearchPropertyListAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAddSearchPropertyListAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSearchPropertyListAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSearchPropertyListAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSearchPropertyListStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSearchPropertyListStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateLoginStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateLoginStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PasswordCreateLoginSource node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPasswordCreateLoginSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PrincipalOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPrincipalOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffPrincipalOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffPrincipalOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralPrincipalOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralPrincipalOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierPrincipalOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierPrincipalOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WindowsCreateLoginSource node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWindowsCreateLoginSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalCreateLoginSource node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalCreateLoginSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CertificateCreateLoginSource node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCertificateCreateLoginSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AsymmetricKeyCreateLoginSource node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAsymmetricKeyCreateLoginSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PasswordAlterPrincipalOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPasswordAlterPrincipalOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterLoginOptionsStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterLoginOptionsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterLoginEnableDisableStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterLoginEnableDisableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterLoginAddDropCredentialStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterLoginAddDropCredentialStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RevertStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRevertStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropContractStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropContractStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropEndpointStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropEndpointStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropMessageTypeStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropMessageTypeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropQueueStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropQueueStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropRemoteServiceBindingStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropRemoteServiceBindingStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropRouteStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropRouteStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropServiceStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropServiceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AddSignatureStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAddSignatureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSignatureStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSignatureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropEventNotificationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropEventNotificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteAsStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteAsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EndConversationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEndConversationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MoveConversationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMoveConversationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GetConversationGroupStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGetConversationGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ReceiveStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForReceiveStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SendStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSendStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ComputeClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForComputeClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ComputeFunction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForComputeFunction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PivotedTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPivotedTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UnpivotedTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUnpivotedTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UnqualifiedJoin node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUnqualifiedJoin?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableSampleClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableSampleClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanNotExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanNotExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanParenthesisExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanParenthesisExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanComparisonExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanComparisonExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanBinaryExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanBinaryExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanIsNullExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanIsNullExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphMatchPredicate node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphMatchPredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphMatchLastNodePredicate node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphMatchLastNodePredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphMatchNodeExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphMatchNodeExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphMatchRecursivePredicate node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphMatchRecursivePredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphMatchExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphMatchExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphMatchCompositeExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphMatchCompositeExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphRecursiveMatchQuantifier node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphRecursiveMatchQuantifier?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExpressionWithSortOrder node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExpressionWithSortOrder?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GroupByClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGroupByClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExpressionGroupingSpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExpressionGroupingSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CompositeGroupingSpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCompositeGroupingSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CubeGroupingSpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCubeGroupingSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RollupGroupingSpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRollupGroupingSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GrandTotalGroupingSpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGrandTotalGroupingSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GroupingSetsGroupingSpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGroupingSetsGroupingSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OutputClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOutputClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OutputIntoClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOutputIntoClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(HavingClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForHavingClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentityFunctionCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentityFunctionCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(JoinParenthesisTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForJoinParenthesisTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OrderByClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOrderByClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QualifiedJoin node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQualifiedJoin?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OdbcQualifiedJoinTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOdbcQualifiedJoinTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryParenthesisExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryParenthesisExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QuerySpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQuerySpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FromClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFromClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PredictTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPredictTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectScalarExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectScalarExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectStarExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectStarExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectSetVariable node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectSetVariable?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DataModificationTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDataModificationTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ChangeTableChangesTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForChangeTableChangesTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ChangeTableVersionTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForChangeTableVersionTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanTernaryExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanTernaryExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TopRowFilter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTopRowFilter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OffsetClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOffsetClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UnaryExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUnaryExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BinaryQueryExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBinaryQueryExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(VariableTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForVariableTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(VariableMethodCallTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForVariableMethodCallTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropPartitionFunctionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropPartitionFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropPartitionSchemeStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropPartitionSchemeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSynonymStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSynonymStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropAggregateStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropAggregateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UserRemoteServiceBindingOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUserRemoteServiceBindingOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateRemoteServiceBindingStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateRemoteServiceBindingStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterRemoteServiceBindingStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterRemoteServiceBindingStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AssemblyEncryptionSource node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAssemblyEncryptionSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileEncryptionSource node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileEncryptionSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProviderEncryptionSource node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProviderEncryptionSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterCertificateStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterCertificateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateCertificateStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateCertificateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CertificateOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCertificateOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateContractStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateContractStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ContractMessage node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForContractMessage?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateCredentialStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateCredentialStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterCredentialStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterCredentialStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateMessageTypeStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateMessageTypeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterMessageTypeStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterMessageTypeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateAggregateStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateAggregateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateEndpointStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateEndpointStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterEndpointStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterEndpointStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EndpointAffinity node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEndpointAffinity?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralEndpointProtocolOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralEndpointProtocolOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuthenticationEndpointProtocolOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuthenticationEndpointProtocolOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PortsEndpointProtocolOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPortsEndpointProtocolOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CompressionEndpointProtocolOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCompressionEndpointProtocolOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ListenerIPEndpointProtocolOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForListenerIPEndpointProtocolOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IPv4 node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIPv4?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SoapMethod node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSoapMethod?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EnabledDisabledPayloadOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEnabledDisabledPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WsdlPayloadOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWsdlPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LoginTypePayloadOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLoginTypePayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralPayloadOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SessionTimeoutPayloadOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSessionTimeoutPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaPayloadOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CharacterSetPayloadOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCharacterSetPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RolePayloadOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRolePayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuthenticationPayloadOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuthenticationPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EncryptionPayloadOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEncryptionPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSymmetricKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(KeySourceKeyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForKeySourceKeyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlgorithmKeyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlgorithmKeyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentityValueKeyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentityValueKeyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProviderKeyNameKeyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProviderKeyNameKeyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreationDispositionKeyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreationDispositionKeyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterSymmetricKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterSymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffFullTextCatalogOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffFullTextCatalogOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateFullTextCatalogStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateFullTextCatalogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterFullTextCatalogStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterFullTextCatalogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateServiceStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateServiceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServiceStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServiceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ServiceContract node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForServiceContract?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BinaryExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBinaryExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BuiltInFunctionTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBuiltInFunctionTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GlobalFunctionTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGlobalFunctionTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableDataCompressionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableDataCompressionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableDistributionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableDistributionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableReplicateDistributionPolicy node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableReplicateDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableRoundRobinDistributionPolicy node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableRoundRobinDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableHashDistributionPolicy node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableHashDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableClusteredIndexType node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableClusteredIndexType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableNonClusteredIndexType node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableNonClusteredIndexType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TablePartitionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTablePartitionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TablePartitionOptionSpecifications node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTablePartitionOptionSpecifications?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LocationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLocationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RenameEntityStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRenameEntityStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CopyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCopyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CopyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCopyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CopyCredentialOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCopyCredentialOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SingleValueTypeCopyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSingleValueTypeCopyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ListTypeCopyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForListTypeCopyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CopyColumnOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCopyColumnOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DataCompressionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDataCompressionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CompressionPartitionRange node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCompressionPartitionRange?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CheckConstraintDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCheckConstraintDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DefaultConstraintDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDefaultConstraintDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ForeignKeyConstraintDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForForeignKeyConstraintDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NullableConstraintDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNullableConstraintDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphConnectionBetweenNodes node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphConnectionBetweenNodes?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphConnectionConstraintDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphConnectionConstraintDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UniqueConstraintDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUniqueConstraintDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupDatabaseStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupDatabaseStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupTransactionLogStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupTransactionLogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RestoreStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRestoreStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RestoreOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRestoreOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ScalarExpressionRestoreOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForScalarExpressionRestoreOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MoveRestoreOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMoveRestoreOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StopRestoreOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStopRestoreOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileStreamRestoreOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileStreamRestoreOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupEncryptionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupEncryptionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeviceInfo node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeviceInfo?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MirrorToClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMirrorToClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupRestoreFileInfo node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupRestoreFileInfo?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BulkInsertStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBulkInsertStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InsertBulkStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInsertBulkStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BulkInsertOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBulkInsertOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralBulkInsertOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralBulkInsertOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OrderBulkInsertOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOrderBulkInsertOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnDefinitionBase node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnDefinitionBase?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableColumnDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableColumnDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InsertBulkColumnDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInsertBulkColumnDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DbccStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDbccStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DbccOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDbccOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DbccNamedLiteral node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDbccNamedLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateAsymmetricKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateAsymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreatePartitionFunctionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreatePartitionFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PartitionParameterType node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPartitionParameterType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreatePartitionSchemeStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreatePartitionSchemeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffRemoteServiceBindingOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffRemoteServiceBindingOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseRebuildLogStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseRebuildLogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseAddFileStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseAddFileStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseAddFileGroupStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseAddFileGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseRemoveFileGroupStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseRemoveFileGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseRemoveFileStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseRemoveFileStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseModifyNameStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseModifyNameStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseModifyFileStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseModifyFileStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseModifyFileGroupStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseModifyFileGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseTermination node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseTermination?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseSetStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseSetStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutoCreateStatisticsDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutoCreateStatisticsDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ContainmentDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForContainmentDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(HadrDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForHadrDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(HadrAvailabilityGroupDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForHadrAvailabilityGroupDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DelayedDurabilityDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDelayedDurabilityDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CursorDefaultDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCursorDefaultDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RecoveryDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRecoveryDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TargetRecoveryTimeDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTargetRecoveryTimeDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PageVerifyDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPageVerifyDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PartnerDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPartnerDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WitnessDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWitnessDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ParameterizationDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForParameterizationDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ChangeTrackingDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForChangeTrackingDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutoCleanupChangeTrackingOptionDetail node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutoCleanupChangeTrackingOptionDetail?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ChangeRetentionChangeTrackingOptionDetail node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForChangeRetentionChangeTrackingOptionDetail?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AcceleratedDatabaseRecoveryDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAcceleratedDatabaseRecoveryDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreDesiredStateOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreDesiredStateOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreCapturePolicyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreCapturePolicyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreSizeCleanupPolicyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreSizeCleanupPolicyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreDataFlushIntervalOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreDataFlushIntervalOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreIntervalLengthOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreIntervalLengthOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreMaxStorageSizeOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreMaxStorageSizeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreMaxPlansPerQueryOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreMaxPlansPerQueryOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreTimeCleanupPolicyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreTimeCleanupPolicyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutomaticTuningDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutomaticTuningDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutomaticTuningOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutomaticTuningOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutomaticTuningForceLastGoodPlanOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutomaticTuningForceLastGoodPlanOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutomaticTuningCreateIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutomaticTuningCreateIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutomaticTuningDropIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutomaticTuningDropIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutomaticTuningMaintainIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutomaticTuningMaintainIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileStreamDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileStreamDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CatalogCollationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCatalogCollationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LedgerOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLedgerOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxSizeDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxSizeDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableAlterIndexStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableAlterIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableAlterColumnStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableAlterColumnStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnEncryptionDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnEncryptionDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnEncryptionKeyNameParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnEncryptionKeyNameParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnEncryptionTypeParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnEncryptionTypeParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnEncryptionAlgorithmParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnEncryptionAlgorithmParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentityOptions node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentityOptions?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnStorageOptions node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnStorageOptions?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateTableStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateTableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FederationScheme node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFederationScheme?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WhereClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWhereClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropDatabaseStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropDatabaseStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropIndexStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackwardsCompatibleDropIndexClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackwardsCompatibleDropIndexClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropIndexClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropIndexClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MoveToDropIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMoveToDropIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileStreamOnDropIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileStreamOnDropIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropStatisticsStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropStatisticsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropTableStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropTableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropProcedureStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropProcedureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropFunctionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropViewStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropViewStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropDefaultStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropDefaultStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropRuleStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropRuleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropTriggerStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropTriggerStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSchemaStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSchemaStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RaiseErrorLegacyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRaiseErrorLegacyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RaiseErrorStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRaiseErrorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ThrowStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForThrowStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UseStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUseStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(KillStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForKillStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(KillQueryNotificationSubscriptionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForKillQueryNotificationSubscriptionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(KillStatsJobStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForKillStatsJobStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CheckpointStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCheckpointStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ReconfigureStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForReconfigureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ShutdownStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForShutdownStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetUserStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetUserStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TruncateTableStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTruncateTableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PredicateSetStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPredicateSetStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetStatisticsStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetStatisticsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetRowCountStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetRowCountStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetOffsetsStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetOffsetsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GeneralSetCommand node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGeneralSetCommand?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetFipsFlaggerCommand node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetFipsFlaggerCommand?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetCommandStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetCommandStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetTransactionIsolationLevelStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetTransactionIsolationLevelStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetTextSizeStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetTextSizeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetIdentityInsertStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetIdentityInsertStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetErrorLevelStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetErrorLevelStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateDatabaseStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateDatabaseStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileDeclaration node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileDeclaration?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileDeclarationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileDeclarationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NameFileDeclarationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNameFileDeclarationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileNameFileDeclarationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileNameFileDeclarationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SizeFileDeclarationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSizeFileDeclarationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxSizeFileDeclarationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxSizeFileDeclarationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileGrowthFileDeclarationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileGrowthFileDeclarationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileGroupDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileGroupDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseScopedConfigurationSetStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseScopedConfigurationSetStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseScopedConfigurationClearStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseScopedConfigurationClearStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DatabaseConfigurationClearOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDatabaseConfigurationClearOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DatabaseConfigurationSetOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDatabaseConfigurationSetOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffPrimaryConfigurationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffPrimaryConfigurationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxDopConfigurationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxDopConfigurationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GenericConfigurationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGenericConfigurationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseCollateStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseCollateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnlineIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnlineIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IgnoreDupKeyIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIgnoreDupKeyIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OrderIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOrderIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnlineIndexLowPriorityLockWaitOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnlineIndexLowPriorityLockWaitOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LowPriorityLockWaitMaxDurationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLowPriorityLockWaitMaxDurationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LowPriorityLockWaitAbortAfterWaitOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLowPriorityLockWaitAbortAfterWaitOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FullTextIndexColumn node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFullTextIndexColumn?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateFullTextIndexStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateFullTextIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ChangeTrackingFullTextIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForChangeTrackingFullTextIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StopListFullTextIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStopListFullTextIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SearchPropertyListFullTextIndexOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSearchPropertyListFullTextIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FullTextCatalogAndFileGroup node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFullTextCatalogAndFileGroup?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventTypeContainer node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventTypeContainer?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventGroupContainer node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventGroupContainer?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateEventNotificationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateEventNotificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventNotificationObjectScope node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventNotificationObjectScope?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateMasterKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterMasterKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ApplicationRoleOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForApplicationRoleOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateApplicationRoleStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateApplicationRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterApplicationRoleStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterApplicationRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateRoleStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterRoleStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RenameAlterRoleAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRenameAlterRoleAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AddMemberAlterRoleAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAddMemberAlterRoleAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropMemberAlterRoleAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropMemberAlterRoleAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateServerRoleStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateServerRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerRoleStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropServerRoleStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropServerRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UserLoginOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUserLoginOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateUserStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateUserStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterUserStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterUserStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StatisticsOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStatisticsOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResampleStatisticsOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResampleStatisticsOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StatisticsPartitionRange node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStatisticsPartitionRange?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffStatisticsOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffStatisticsOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralStatisticsOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralStatisticsOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateStatisticsStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateStatisticsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateStatisticsStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateStatisticsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ReturnStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForReturnStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeclareCursorStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeclareCursorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CursorDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCursorDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CursorOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCursorOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetVariableStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetVariableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CursorId node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCursorId?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenCursorStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenCursorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CloseCursorStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCloseCursorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CryptoMechanism node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCryptoMechanism?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenSymmetricKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenSymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CloseSymmetricKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCloseSymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenMasterKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CloseMasterKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCloseMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeallocateCursorStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeallocateCursorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FetchType node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFetchType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FetchCursorStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFetchCursorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileTableCollateFileNameTableOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileTableCollateFileNameTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileTableConstraintNameTableOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileTableConstraintNameTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MemoryOptimizedTableOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMemoryOptimizedTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DurabilityTableOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDurabilityTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RemoteDataArchiveTableOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRemoteDataArchiveTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RemoteDataArchiveAlterTableOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRemoteDataArchiveAlterTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RemoteDataArchiveDatabaseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRemoteDataArchiveDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RemoteDataArchiveDbServerSetting node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRemoteDataArchiveDbServerSetting?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RemoteDataArchiveDbCredentialSetting node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRemoteDataArchiveDbCredentialSetting?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RemoteDataArchiveDbFederatedServiceAccountSetting node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRemoteDataArchiveDbFederatedServiceAccountSetting?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RetentionPeriodDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRetentionPeriodDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SystemVersioningTableOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSystemVersioningTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LedgerTableOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLedgerTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LedgerViewOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLedgerViewOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DataRetentionTableOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDataRetentionTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableAddTableElementStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableAddTableElementStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableConstraintModificationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableConstraintModificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableSwitchStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableSwitchStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LowPriorityLockWaitTableSwitchOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLowPriorityLockWaitTableSwitchOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TruncateTargetTableSwitchOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTruncateTargetTableSwitchOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropClusteredConstraintStateOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropClusteredConstraintStateOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropClusteredConstraintValueOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropClusteredConstraintValueOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropClusteredConstraintMoveOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropClusteredConstraintMoveOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropClusteredConstraintWaitAtLowPriorityLockOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropClusteredConstraintWaitAtLowPriorityLockOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableDropTableElement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableDropTableElement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableDropTableElementStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableDropTableElementStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableTriggerModificationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableTriggerModificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EnableDisableTriggerStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEnableDisableTriggerStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TryCatchStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTryCatchStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateTypeUdtStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateTypeUdtStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateTypeUddtStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateTypeUddtStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSynonymStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSynonymStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteAsClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteAsClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueueOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueueOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueueStateOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueueStateOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueueProcedureOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueueProcedureOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueueValueOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueueValueOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueueExecuteAsOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueueExecuteAsOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RouteOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRouteOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterRouteStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterRouteStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateRouteStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateRouteStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterQueueStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterQueueStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateQueueStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateQueueStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IndexDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIndexDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SystemTimePeriodDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSystemTimePeriodDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IndexType node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIndexType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PartitionSpecifier node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPartitionSpecifier?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterIndexStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateXmlIndexStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateXmlIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSelectiveXmlIndexStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSelectiveXmlIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileGroupOrPartitionScheme node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileGroupOrPartitionScheme?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateIndexStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IndexStateOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIndexStateOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IndexExpressionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIndexExpressionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxDurationOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxDurationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WaitAtLowPriorityOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWaitAtLowPriorityOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnMasterKeyEnclaveComputationsParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnMasterKeyEnclaveComputationsParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropColumnMasterKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropColumnMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateColumnEncryptionKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateColumnEncryptionKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterColumnEncryptionKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterColumnEncryptionKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropColumnEncryptionKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropColumnEncryptionKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnEncryptionKeyValue node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnEncryptionKeyValue?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnMasterKeyNameParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnMasterKeyNameParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnEncryptionAlgorithmNameParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnEncryptionAlgorithmNameParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EncryptedValueParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEncryptedValueParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableLiteralOrIdentifierOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableLiteralOrIdentifierOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableDistributionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableDistributionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableRejectTypeOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableRejectTypeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableReplicatedDistributionPolicy node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableReplicatedDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableRoundRobinDistributionPolicy node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableRoundRobinDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableShardedDistributionPolicy node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableShardedDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalTableStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalTableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalTableStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalTableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalDataSourceLiteralOrIdentifierOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalDataSourceLiteralOrIdentifierOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalDataSourceStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalDataSourceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterExternalDataSourceStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterExternalDataSourceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalDataSourceStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalDataSourceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalStreamLiteralOrIdentifierOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalStreamLiteralOrIdentifierOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalStreamStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalStreamStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalStreamStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalStreamStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalFileFormatLiteralOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalFileFormatLiteralOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalFileFormatUseDefaultTypeOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalFileFormatUseDefaultTypeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalFileFormatContainerOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalFileFormatContainerOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalFileFormatStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalFileFormatStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalFileFormatStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalFileFormatStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalStreamingJobStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalStreamingJobStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalStreamingJobStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalStreamingJobStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateAssemblyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateAssemblyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAssemblyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAssemblyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AssemblyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAssemblyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffAssemblyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffAssemblyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PermissionSetAssemblyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPermissionSetAssemblyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AddFileSpec node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAddFileSpec?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateXmlSchemaCollectionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateXmlSchemaCollectionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterXmlSchemaCollectionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterXmlSchemaCollectionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropXmlSchemaCollectionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropXmlSchemaCollectionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AssemblyName node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAssemblyName?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableAlterPartitionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableAlterPartitionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableRebuildStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableRebuildStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableChangeTrackingModificationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableChangeTrackingModificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableFileTableNamespaceStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableFileTableNamespaceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableSetStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableSetStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LockEscalationTableOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLockEscalationTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileStreamOnTableOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileStreamOnTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileTableDirectoryTableOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileTableDirectoryTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GrantStatement80 node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGrantStatement80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DenyStatement80 node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDenyStatement80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RevokeStatement80 node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRevokeStatement80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CommandSecurityElement80 node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCommandSecurityElement80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PrivilegeSecurityElement80 node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPrivilegeSecurityElement80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(Privilege80 node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPrivilege80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecurityUserClause80 node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecurityUserClause80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SqlCommandIdentifier node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSqlCommandIdentifier?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AssignmentSetClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAssignmentSetClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FunctionCallSetClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFunctionCallSetClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ValuesInsertSource node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForValuesInsertSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectInsertSource node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectInsertSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteInsertSource node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteInsertSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RowValue node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRowValue?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PrintStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPrintStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TSEqualCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTSEqualCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IntegerLiteral node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIntegerLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NumericLiteral node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNumericLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RealLiteral node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRealLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MoneyLiteral node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMoneyLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BinaryLiteral node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBinaryLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StringLiteral node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStringLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NullLiteral node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNullLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierLiteral node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DefaultLiteral node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDefaultLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxLiteral node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OdbcLiteral node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOdbcLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralRange node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralRange?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(VariableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForVariableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffOptionValue node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffOptionValue?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralOptionValue node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralOptionValue?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GlobalVariableExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGlobalVariableExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierOrValueExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierOrValueExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierOrScalarExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierOrScalarExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaObjectNameOrValueExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaObjectNameOrValueExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ParenthesisExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForParenthesisExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnReferenceExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnReferenceExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NextValueForExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNextValueForExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SequenceOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSequenceOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DataTypeSequenceOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDataTypeSequenceOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ScalarExpressionSequenceOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForScalarExpressionSequenceOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSequenceStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSequenceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterSequenceStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterSequenceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSequenceStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSequenceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecurityPredicateAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecurityPredicateAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecurityPolicyOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecurityPolicyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSecurityPolicyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSecurityPolicyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterSecurityPolicyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterSecurityPolicyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSecurityPolicyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSecurityPolicyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateColumnMasterKeyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateColumnMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnMasterKeyStoreProviderNameParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnMasterKeyStoreProviderNameParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnMasterKeyPathParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnMasterKeyPathParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExpressionCallTarget node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExpressionCallTarget?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MultiPartIdentifierCallTarget node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMultiPartIdentifierCallTarget?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UserDefinedTypeCallTarget node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUserDefinedTypeCallTarget?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LeftFunctionCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLeftFunctionCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RightFunctionCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRightFunctionCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PartitionFunctionCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPartitionFunctionCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OverClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOverClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ParameterlessCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForParameterlessCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ScalarSubquery node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForScalarSubquery?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OdbcFunctionCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOdbcFunctionCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExtractFromExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExtractFromExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OdbcConvertSpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOdbcConvertSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterFunctionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BeginEndBlockStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBeginEndBlockStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BeginEndAtomicBlockStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBeginEndAtomicBlockStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralAtomicBlockOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralAtomicBlockOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierAtomicBlockOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierAtomicBlockOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffAtomicBlockOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffAtomicBlockOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BeginTransactionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBeginTransactionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BreakStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBreakStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnWithSortOrder node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnWithSortOrder?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CommitTransactionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCommitTransactionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RollbackTransactionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRollbackTransactionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SaveTransactionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSaveTransactionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ContinueStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForContinueStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateDefaultStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateDefaultStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateFunctionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateOrAlterFunctionStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateOrAlterFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateRuleStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateRuleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeclareVariableElement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeclareVariableElement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeclareVariableStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeclareVariableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GoToStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGoToStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IfStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIfStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LabelStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLabelStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MultiPartIdentifier node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMultiPartIdentifier?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaObjectName node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaObjectName?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ChildObjectName node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForChildObjectName?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProcedureParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProcedureParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WhileStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWhileStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeleteStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeleteStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeleteSpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeleteSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InsertStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInsertStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InsertSpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInsertSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateSpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSchemaStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSchemaStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WaitForStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWaitForStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ReadTextStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForReadTextStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateTextStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateTextStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WriteTextStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWriteTextStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LineNoStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLineNoStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GrantStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGrantStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DenyStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDenyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RevokeStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRevokeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAuthorizationStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAuthorizationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(Permission node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPermission?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecurityTargetObject node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecurityTargetObject?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecurityTargetObjectName node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecurityTargetObjectName?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecurityPrincipal node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecurityPrincipal?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ScalarFunctionReturnType node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForScalarFunctionReturnType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectFunctionReturnType node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectFunctionReturnType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeclareTableVariableBody node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeclareTableVariableBody?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeclareTableVariableStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeclareTableVariableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NamedTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNamedTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaObjectFunctionTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaObjectFunctionTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableHint node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IndexTableHint node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIndexTableHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralTableHint node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralTableHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryDerivedTable node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryDerivedTable?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InlineDerivedTable node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInlineDerivedTable?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SubqueryComparisonPredicate node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSubqueryComparisonPredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExistsPredicate node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExistsPredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LikePredicate node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLikePredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InPredicate node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInPredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FullTextPredicate node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFullTextPredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UserDefinedTypePropertyAccess node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUserDefinedTypePropertyAccess?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BrowseForClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBrowseForClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ReadOnlyForClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForReadOnlyForClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(XmlForClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForXmlForClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(XmlForClauseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForXmlForClauseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(JsonForClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForJsonForClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(JsonForClauseOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForJsonForClauseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateForClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateForClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OptimizerHint node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOptimizerHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralOptimizerHint node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralOptimizerHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableHintsOptimizerHint node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableHintsOptimizerHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ForceSeekTableHint node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForForceSeekTableHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OptimizeForOptimizerHint node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOptimizeForOptimizerHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UseHintList node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUseHintList?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(VariableValuePair node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForVariableValuePair?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SimpleWhenClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSimpleWhenClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SearchedWhenClause node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSearchedWhenClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SimpleCaseExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSimpleCaseExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SearchedCaseExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSearchedCaseExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NullIfExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNullIfExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CoalesceExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCoalesceExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IIfCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIIfCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FullTextTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFullTextTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SemanticTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSemanticTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenXmlTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenXmlTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenJsonTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenJsonTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenRowsetTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenRowsetTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InternalOpenRowset node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInternalOpenRowset?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BulkOpenRowset node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBulkOpenRowset?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenQueryTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenQueryTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AdHocTableReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAdHocTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaDeclarationItem node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaDeclarationItem?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaDeclarationItemOpenjson node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaDeclarationItemOpenjson?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ConvertCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForConvertCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TryConvertCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTryConvertCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ParseCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForParseCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TryParseCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTryParseCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CastCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCastCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TryCastCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTryCastCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AtTimeZoneCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAtTimeZoneCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FunctionCall node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFunctionCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StatementList node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStatementList?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResultSetsExecuteOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResultSetsExecuteOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResultSetDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResultSetDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InlineResultSetDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInlineResultSetDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResultColumnDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResultColumnDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaObjectResultSetDefinition node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaObjectResultSetDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteSpecification node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteContext node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteContext?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteParameter node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProcedureReferenceName node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProcedureReferenceName?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecutableProcedureReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecutableProcedureReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecutableStringList node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecutableStringList?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AdHocDataSource node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAdHocDataSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ViewOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForViewOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterViewStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterViewStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateViewStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateViewStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateOrAlterViewStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateOrAlterViewStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ViewForAppendOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForViewForAppendOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ViewDistributionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForViewDistributionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ViewRoundRobinDistributionPolicy node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForViewRoundRobinDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ViewHashDistributionPolicy node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForViewHashDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TriggerObject node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTriggerObject?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TriggerOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTriggerOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteAsTriggerOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteAsTriggerOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TriggerAction node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTriggerAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTriggerStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTriggerStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateTriggerStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateTriggerStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateOrAlterTriggerStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateOrAlterTriggerStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(Identifier node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifier?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterProcedureStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterProcedureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateProcedureStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateProcedureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateOrAlterProcedureStatement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateOrAlterProcedureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProcedureReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProcedureReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MethodSpecifier node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMethodSpecifier?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProcedureOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProcedureOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteAsProcedureOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteAsProcedureOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FunctionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFunctionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InlineFunctionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInlineFunctionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteAsFunctionOption node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteAsFunctionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(XmlNamespaces node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForXmlNamespaces?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(XmlNamespacesDefaultElement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForXmlNamespacesDefaultElement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(XmlNamespacesAliasElement node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForXmlNamespacesAliasElement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CommonTableExpression node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCommonTableExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WithCtesAndXmlNamespaces node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWithCtesAndXmlNamespaces?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableValuedFunctionReturnType node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableValuedFunctionReturnType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SqlDataTypeReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSqlDataTypeReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UserDataTypeReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUserDataTypeReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(XmlDataTypeReference node)
        {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForXmlDataTypeReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext(node);

            HandleOnLeave(node);
        }

        static readonly IReadOnlyDictionary<string, int> ReplaceCaseNumberByType =
            new Dictionary<string, int>
            {
                [nameof(ExternalLanguageFileOption)] = 1,
                [nameof(BoundingBoxParameter)] = 2,
                [nameof(AlterFederationStatement)] = 3,
                [nameof(UseFederationStatement)] = 4,
                [nameof(WindowDelimiter)] = 5,
                [nameof(TemporalClause)] = 6,
                [nameof(CompressionDelayIndexOption)] = 7,
                [nameof(ExternalLibraryFileOption)] = 8,
                [nameof(EventDeclarationSetParameter)] = 9,
                [nameof(EventDeclarationCompareFunctionParameter)] = 10,
                [nameof(BeginConversationTimerStatement)] = 11,
                [nameof(ScalarExpressionDialogOption)] = 12,
                [nameof(AlterPartitionFunctionStatement)] = 13,
                [nameof(RevertStatement)] = 14,
                [nameof(EndConversationStatement)] = 15,
                [nameof(MoveConversationStatement)] = 16,
                [nameof(ReceiveStatement)] = 17,
                [nameof(SendStatement)] = 18,
                [nameof(ComputeClause)] = 19,
                [nameof(ComputeFunction)] = 20,
                [nameof(TableSampleClause)] = 21,
                [nameof(BooleanComparisonExpression)] = 22,
                [nameof(BooleanIsNullExpression)] = 23,
                [nameof(ExpressionWithSortOrder)] = 24,
                [nameof(ExpressionGroupingSpecification)] = 25,
                [nameof(IdentityFunctionCall)] = 26,
                [nameof(PredictTableReference)] = 27,
                [nameof(SelectScalarExpression)] = 28,
                [nameof(SelectSetVariable)] = 29,
                [nameof(ChangeTableVersionTableReference)] = 30,
                [nameof(BooleanTernaryExpression)] = 31,
                [nameof(TopRowFilter)] = 32,
                [nameof(OffsetClause)] = 33,
                [nameof(UnaryExpression)] = 34,
                [nameof(VariableMethodCallTableReference)] = 35,
                [nameof(BinaryExpression)] = 36,
                [nameof(BuiltInFunctionTableReference)] = 37,
                [nameof(GlobalFunctionTableReference)] = 38,
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
                [nameof(RaiseErrorLegacyStatement)] = 50,
                [nameof(RaiseErrorStatement)] = 51,
                [nameof(KillStatement)] = 52,
                [nameof(KillStatsJobStatement)] = 53,
                [nameof(GeneralSetCommand)] = 54,
                [nameof(SetTextSizeStatement)] = 55,
                [nameof(SetErrorLevelStatement)] = 56,
                [nameof(ReturnStatement)] = 57,
                [nameof(SetVariableStatement)] = 58,
                [nameof(FetchType)] = 59,
                [nameof(AlterTableSwitchStatement)] = 60,
                [nameof(PartitionSpecifier)] = 61,
                [nameof(IndexExpressionOption)] = 62,
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
                [nameof(ExpressionCallTarget)] = 76,
                [nameof(LeftFunctionCall)] = 77,
                [nameof(RightFunctionCall)] = 78,
                [nameof(PartitionFunctionCall)] = 79,
                [nameof(OverClause)] = 80,
                [nameof(OdbcFunctionCall)] = 81,
                [nameof(ExtractFromExpression)] = 82,
                [nameof(CreateDefaultStatement)] = 83,
                [nameof(DeclareVariableElement)] = 84,
                [nameof(ProcedureParameter)] = 85,
                [nameof(WaitForStatement)] = 86,
                [nameof(UpdateTextStatement)] = 87,
                [nameof(SchemaObjectFunctionTableReference)] = 88,
                [nameof(SubqueryComparisonPredicate)] = 89,
                [nameof(LikePredicate)] = 90,
                [nameof(InPredicate)] = 91,
                [nameof(VariableValuePair)] = 92,
                [nameof(SimpleWhenClause)] = 93,
                [nameof(SearchedWhenClause)] = 94,
                [nameof(SimpleCaseExpression)] = 95,
                [nameof(SearchedCaseExpression)] = 96,
                [nameof(NullIfExpression)] = 97,
                [nameof(CoalesceExpression)] = 98,
                [nameof(IIfCall)] = 99,
                [nameof(SemanticTableReference)] = 100,
                [nameof(OpenJsonTableReference)] = 101,
                [nameof(InternalOpenRowset)] = 102,
                [nameof(ConvertCall)] = 103,
                [nameof(TryConvertCall)] = 104,
                [nameof(ParseCall)] = 105,
                [nameof(TryParseCall)] = 106,
                [nameof(CastCall)] = 107,
                [nameof(TryCastCall)] = 108,
                [nameof(AtTimeZoneCall)] = 109,
                [nameof(FunctionCall)] = 110,
                [nameof(ExecuteContext)] = 111,
                [nameof(ExecuteParameter)] = 112
            };

        public static bool ReplaceScalarInParent(TSqlFragment parent, ScalarExpression toReplace, ScalarExpression replacement)
        {
            var success = false;
            _ = ReplaceCaseNumberByType.TryGetValue(parent.GetType().Name, out var caseNum);
            switch (caseNum)
            {
                case 1:
                    {
                        var parent2 = (ExternalLanguageFileOption)parent;
                        if (Equals(parent2.Content, toReplace))
                        {
                            parent2.Content = replacement;
                            success = true;
                        }
                        break;
                    }
                case 2:
                    {
                        var parent2 = (BoundingBoxParameter)parent;
                        if (Equals(parent2.Value, toReplace))
                        {
                            parent2.Value = replacement;
                            success = true;
                        }
                        break;
                    }
                case 3:
                    {
                        var parent2 = (AlterFederationStatement)parent;
                        if (Equals(parent2.Boundary, toReplace))
                        {
                            parent2.Boundary = replacement;
                            success = true;
                        }
                        break;
                    }
                case 4:
                    {
                        var parent2 = (UseFederationStatement)parent;
                        if (Equals(parent2.Value, toReplace))
                        {
                            parent2.Value = replacement;
                            success = true;
                        }
                        break;
                    }
                case 5:
                    {
                        var parent2 = (WindowDelimiter)parent;
                        if (Equals(parent2.OffsetValue, toReplace))
                        {
                            parent2.OffsetValue = replacement;
                            success = true;
                        }
                        break;
                    }
                case 6:
                    {
                        var parent2 = (TemporalClause)parent;
                        if (Equals(parent2.StartTime, toReplace))
                        {
                            parent2.StartTime = replacement;
                            success = true;
                        }
                        if (Equals(parent2.EndTime, toReplace))
                        {
                            parent2.EndTime = replacement;
                            success = true;
                        }
                        break;
                    }
                case 7:
                    {
                        var parent2 = (CompressionDelayIndexOption)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 8:
                    {
                        var parent2 = (ExternalLibraryFileOption)parent;
                        if (Equals(parent2.Content, toReplace))
                        {
                            parent2.Content = replacement;
                            success = true;
                        }
                        break;
                    }
                case 9:
                    {
                        var parent2 = (EventDeclarationSetParameter)parent;
                        if (Equals(parent2.EventValue, toReplace))
                        {
                            parent2.EventValue = replacement;
                            success = true;
                        }
                        break;
                    }
                case 10:
                    {
                        var parent2 = (EventDeclarationCompareFunctionParameter)parent;
                        if (Equals(parent2.EventValue, toReplace))
                        {
                            parent2.EventValue = replacement;
                            success = true;
                        }
                        break;
                    }
                case 11:
                    {
                        var parent2 = (BeginConversationTimerStatement)parent;
                        if (Equals(parent2.Handle, toReplace))
                        {
                            parent2.Handle = replacement;
                            success = true;
                        }
                        if (Equals(parent2.Timeout, toReplace))
                        {
                            parent2.Timeout = replacement;
                            success = true;
                        }
                        break;
                    }
                case 12:
                    {
                        var parent2 = (ScalarExpressionDialogOption)parent;
                        if (Equals(parent2.Value, toReplace))
                        {
                            parent2.Value = replacement;
                            success = true;
                        }
                        break;
                    }
                case 13:
                    {
                        var parent2 = (AlterPartitionFunctionStatement)parent;
                        if (Equals(parent2.Boundary, toReplace))
                        {
                            parent2.Boundary = replacement;
                            success = true;
                        }
                        break;
                    }
                case 14:
                    {
                        var parent2 = (RevertStatement)parent;
                        if (Equals(parent2.Cookie, toReplace))
                        {
                            parent2.Cookie = replacement;
                            success = true;
                        }
                        break;
                    }
                case 15:
                    {
                        var parent2 = (EndConversationStatement)parent;
                        if (Equals(parent2.Conversation, toReplace))
                        {
                            parent2.Conversation = replacement;
                            success = true;
                        }
                        break;
                    }
                case 16:
                    {
                        var parent2 = (MoveConversationStatement)parent;
                        if (Equals(parent2.Conversation, toReplace))
                        {
                            parent2.Conversation = replacement;
                            success = true;
                        }
                        if (Equals(parent2.Group, toReplace))
                        {
                            parent2.Group = replacement;
                            success = true;
                        }
                        break;
                    }
                case 17:
                    {
                        var parent2 = (ReceiveStatement)parent;
                        if (Equals(parent2.Top, toReplace))
                        {
                            parent2.Top = replacement;
                            success = true;
                        }
                        break;
                    }
                case 18:
                    {
                        var parent2 = (SendStatement)parent;
                        for (int i = 0; i < parent2.ConversationHandles.Count; i++)
                        {
                            if (Equals(parent2.ConversationHandles[i], toReplace))
                            {
                                parent2.ConversationHandles[i] = replacement;
                                success = true;
                            }
                        }
                        if (Equals(parent2.MessageBody, toReplace))
                        {
                            parent2.MessageBody = replacement;
                            success = true;
                        }
                        break;
                    }
                case 19:
                    {
                        var parent2 = (ComputeClause)parent;
                        for (int i = 0; i < parent2.ByExpressions.Count; i++)
                        {
                            if (Equals(parent2.ByExpressions[i], toReplace))
                            {
                                parent2.ByExpressions[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 20:
                    {
                        var parent2 = (ComputeFunction)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 21:
                    {
                        var parent2 = (TableSampleClause)parent;
                        if (Equals(parent2.SampleNumber, toReplace))
                        {
                            parent2.SampleNumber = replacement;
                            success = true;
                        }
                        if (Equals(parent2.RepeatSeed, toReplace))
                        {
                            parent2.RepeatSeed = replacement;
                            success = true;
                        }
                        break;
                    }
                case 22:
                    {
                        var parent2 = (BooleanComparisonExpression)parent;
                        if (Equals(parent2.FirstExpression, toReplace))
                        {
                            parent2.FirstExpression = replacement;
                            success = true;
                        }
                        if (Equals(parent2.SecondExpression, toReplace))
                        {
                            parent2.SecondExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 23:
                    {
                        var parent2 = (BooleanIsNullExpression)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 24:
                    {
                        var parent2 = (ExpressionWithSortOrder)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 25:
                    {
                        var parent2 = (ExpressionGroupingSpecification)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 26:
                    {
                        var parent2 = (IdentityFunctionCall)parent;
                        if (Equals(parent2.Seed, toReplace))
                        {
                            parent2.Seed = replacement;
                            success = true;
                        }
                        if (Equals(parent2.Increment, toReplace))
                        {
                            parent2.Increment = replacement;
                            success = true;
                        }
                        break;
                    }
                case 27:
                    {
                        var parent2 = (PredictTableReference)parent;
                        if (Equals(parent2.ModelVariable, toReplace))
                        {
                            parent2.ModelVariable = replacement;
                            success = true;
                        }
                        break;
                    }
                case 28:
                    {
                        var parent2 = (SelectScalarExpression)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 29:
                    {
                        var parent2 = (SelectSetVariable)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 30:
                    {
                        var parent2 = (ChangeTableVersionTableReference)parent;
                        for (int i = 0; i < parent2.PrimaryKeyValues.Count; i++)
                        {
                            if (Equals(parent2.PrimaryKeyValues[i], toReplace))
                            {
                                parent2.PrimaryKeyValues[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 31:
                    {
                        var parent2 = (BooleanTernaryExpression)parent;
                        if (Equals(parent2.FirstExpression, toReplace))
                        {
                            parent2.FirstExpression = replacement;
                            success = true;
                        }
                        if (Equals(parent2.SecondExpression, toReplace))
                        {
                            parent2.SecondExpression = replacement;
                            success = true;
                        }
                        if (Equals(parent2.ThirdExpression, toReplace))
                        {
                            parent2.ThirdExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 32:
                    {
                        var parent2 = (TopRowFilter)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 33:
                    {
                        var parent2 = (OffsetClause)parent;
                        if (Equals(parent2.OffsetExpression, toReplace))
                        {
                            parent2.OffsetExpression = replacement;
                            success = true;
                        }
                        if (Equals(parent2.FetchExpression, toReplace))
                        {
                            parent2.FetchExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 34:
                    {
                        var parent2 = (UnaryExpression)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 35:
                    {
                        var parent2 = (VariableMethodCallTableReference)parent;
                        for (int i = 0; i < parent2.Parameters.Count; i++)
                        {
                            if (Equals(parent2.Parameters[i], toReplace))
                            {
                                parent2.Parameters[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 36:
                    {
                        var parent2 = (BinaryExpression)parent;
                        if (Equals(parent2.FirstExpression, toReplace))
                        {
                            parent2.FirstExpression = replacement;
                            success = true;
                        }
                        if (Equals(parent2.SecondExpression, toReplace))
                        {
                            parent2.SecondExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 37:
                    {
                        var parent2 = (BuiltInFunctionTableReference)parent;
                        for (int i = 0; i < parent2.Parameters.Count; i++)
                        {
                            if (Equals(parent2.Parameters[i], toReplace))
                            {
                                parent2.Parameters[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 38:
                    {
                        var parent2 = (GlobalFunctionTableReference)parent;
                        for (int i = 0; i < parent2.Parameters.Count; i++)
                        {
                            if (Equals(parent2.Parameters[i], toReplace))
                            {
                                parent2.Parameters[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 39:
                    {
                        var parent2 = (TablePartitionOptionSpecifications)parent;
                        for (int i = 0; i < parent2.BoundaryValues.Count; i++)
                        {
                            if (Equals(parent2.BoundaryValues[i], toReplace))
                            {
                                parent2.BoundaryValues[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 40:
                    {
                        var parent2 = (CopyColumnOption)parent;
                        if (Equals(parent2.DefaultValue, toReplace))
                        {
                            parent2.DefaultValue = replacement;
                            success = true;
                        }
                        break;
                    }
                case 41:
                    {
                        var parent2 = (CompressionPartitionRange)parent;
                        if (Equals(parent2.From, toReplace))
                        {
                            parent2.From = replacement;
                            success = true;
                        }
                        if (Equals(parent2.To, toReplace))
                        {
                            parent2.To = replacement;
                            success = true;
                        }
                        break;
                    }
                case 42:
                    {
                        var parent2 = (DefaultConstraintDefinition)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 43:
                    {
                        var parent2 = (ScalarExpressionRestoreOption)parent;
                        if (Equals(parent2.Value, toReplace))
                        {
                            parent2.Value = replacement;
                            success = true;
                        }
                        break;
                    }
                case 44:
                    {
                        var parent2 = (BackupOption)parent;
                        if (Equals(parent2.Value, toReplace))
                        {
                            parent2.Value = replacement;
                            success = true;
                        }
                        break;
                    }
                case 45:
                    {
                        var parent2 = (BackupEncryptionOption)parent;
                        if (Equals(parent2.Value, toReplace))
                        {
                            parent2.Value = replacement;
                            success = true;
                        }
                        break;
                    }
                case 46:
                    {
                        var parent2 = (DbccNamedLiteral)parent;
                        if (Equals(parent2.Value, toReplace))
                        {
                            parent2.Value = replacement;
                            success = true;
                        }
                        break;
                    }
                case 47:
                    {
                        var parent2 = (CreatePartitionFunctionStatement)parent;
                        for (int i = 0; i < parent2.BoundaryValues.Count; i++)
                        {
                            if (Equals(parent2.BoundaryValues[i], toReplace))
                            {
                                parent2.BoundaryValues[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 48:
                    {
                        var parent2 = (ColumnDefinition)parent;
                        if (Equals(parent2.ComputedColumnExpression, toReplace))
                        {
                            parent2.ComputedColumnExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 49:
                    {
                        var parent2 = (IdentityOptions)parent;
                        if (Equals(parent2.IdentitySeed, toReplace))
                        {
                            parent2.IdentitySeed = replacement;
                            success = true;
                        }
                        if (Equals(parent2.IdentityIncrement, toReplace))
                        {
                            parent2.IdentityIncrement = replacement;
                            success = true;
                        }
                        break;
                    }
                case 50:
                    {
                        var parent2 = (RaiseErrorLegacyStatement)parent;
                        if (Equals(parent2.FirstParameter, toReplace))
                        {
                            parent2.FirstParameter = replacement;
                            success = true;
                        }
                        break;
                    }
                case 51:
                    {
                        var parent2 = (RaiseErrorStatement)parent;
                        if (Equals(parent2.FirstParameter, toReplace))
                        {
                            parent2.FirstParameter = replacement;
                            success = true;
                        }
                        if (Equals(parent2.SecondParameter, toReplace))
                        {
                            parent2.SecondParameter = replacement;
                            success = true;
                        }
                        if (Equals(parent2.ThirdParameter, toReplace))
                        {
                            parent2.ThirdParameter = replacement;
                            success = true;
                        }
                        for (int i = 0; i < parent2.OptionalParameters.Count; i++)
                        {
                            if (Equals(parent2.OptionalParameters[i], toReplace))
                            {
                                parent2.OptionalParameters[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 52:
                    {
                        var parent2 = (KillStatement)parent;
                        if (Equals(parent2.Parameter, toReplace))
                        {
                            parent2.Parameter = replacement;
                            success = true;
                        }
                        break;
                    }
                case 53:
                    {
                        var parent2 = (KillStatsJobStatement)parent;
                        if (Equals(parent2.JobId, toReplace))
                        {
                            parent2.JobId = replacement;
                            success = true;
                        }
                        break;
                    }
                case 54:
                    {
                        var parent2 = (GeneralSetCommand)parent;
                        if (Equals(parent2.Parameter, toReplace))
                        {
                            parent2.Parameter = replacement;
                            success = true;
                        }
                        break;
                    }
                case 55:
                    {
                        var parent2 = (SetTextSizeStatement)parent;
                        if (Equals(parent2.TextSize, toReplace))
                        {
                            parent2.TextSize = replacement;
                            success = true;
                        }
                        break;
                    }
                case 56:
                    {
                        var parent2 = (SetErrorLevelStatement)parent;
                        if (Equals(parent2.Level, toReplace))
                        {
                            parent2.Level = replacement;
                            success = true;
                        }
                        break;
                    }
                case 57:
                    {
                        var parent2 = (ReturnStatement)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 58:
                    {
                        var parent2 = (SetVariableStatement)parent;
                        for (int i = 0; i < parent2.Parameters.Count; i++)
                        {
                            if (Equals(parent2.Parameters[i], toReplace))
                            {
                                parent2.Parameters[i] = replacement;
                                success = true;
                            }
                        }
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 59:
                    {
                        var parent2 = (FetchType)parent;
                        if (Equals(parent2.RowOffset, toReplace))
                        {
                            parent2.RowOffset = replacement;
                            success = true;
                        }
                        break;
                    }
                case 60:
                    {
                        var parent2 = (AlterTableSwitchStatement)parent;
                        if (Equals(parent2.SourcePartitionNumber, toReplace))
                        {
                            parent2.SourcePartitionNumber = replacement;
                            success = true;
                        }
                        if (Equals(parent2.TargetPartitionNumber, toReplace))
                        {
                            parent2.TargetPartitionNumber = replacement;
                            success = true;
                        }
                        break;
                    }
                case 61:
                    {
                        var parent2 = (PartitionSpecifier)parent;
                        if (Equals(parent2.Number, toReplace))
                        {
                            parent2.Number = replacement;
                            success = true;
                        }
                        break;
                    }
                case 62:
                    {
                        var parent2 = (IndexExpressionOption)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 63:
                    {
                        var parent2 = (CreateAssemblyStatement)parent;
                        for (int i = 0; i < parent2.Parameters.Count; i++)
                        {
                            if (Equals(parent2.Parameters[i], toReplace))
                            {
                                parent2.Parameters[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 64:
                    {
                        var parent2 = (AlterAssemblyStatement)parent;
                        for (int i = 0; i < parent2.Parameters.Count; i++)
                        {
                            if (Equals(parent2.Parameters[i], toReplace))
                            {
                                parent2.Parameters[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 65:
                    {
                        var parent2 = (AddFileSpec)parent;
                        if (Equals(parent2.File, toReplace))
                        {
                            parent2.File = replacement;
                            success = true;
                        }
                        break;
                    }
                case 66:
                    {
                        var parent2 = (CreateXmlSchemaCollectionStatement)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 67:
                    {
                        var parent2 = (AlterXmlSchemaCollectionStatement)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 68:
                    {
                        var parent2 = (AlterTableAlterPartitionStatement)parent;
                        if (Equals(parent2.BoundaryValue, toReplace))
                        {
                            parent2.BoundaryValue = replacement;
                            success = true;
                        }
                        break;
                    }
                case 69:
                    {
                        var parent2 = (AssignmentSetClause)parent;
                        if (Equals(parent2.NewValue, toReplace))
                        {
                            parent2.NewValue = replacement;
                            success = true;
                        }
                        break;
                    }
                case 70:
                    {
                        var parent2 = (RowValue)parent;
                        for (int i = 0; i < parent2.ColumnValues.Count; i++)
                        {
                            if (Equals(parent2.ColumnValues[i], toReplace))
                            {
                                parent2.ColumnValues[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 71:
                    {
                        var parent2 = (PrintStatement)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 72:
                    {
                        var parent2 = (TSEqualCall)parent;
                        if (Equals(parent2.FirstExpression, toReplace))
                        {
                            parent2.FirstExpression = replacement;
                            success = true;
                        }
                        if (Equals(parent2.SecondExpression, toReplace))
                        {
                            parent2.SecondExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 73:
                    {
                        var parent2 = (IdentifierOrScalarExpression)parent;
                        if (Equals(parent2.ScalarExpression, toReplace))
                        {
                            parent2.ScalarExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 74:
                    {
                        var parent2 = (ParenthesisExpression)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 75:
                    {
                        var parent2 = (ScalarExpressionSequenceOption)parent;
                        if (Equals(parent2.OptionValue, toReplace))
                        {
                            parent2.OptionValue = replacement;
                            success = true;
                        }
                        break;
                    }
                case 76:
                    {
                        var parent2 = (ExpressionCallTarget)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 77:
                    {
                        var parent2 = (LeftFunctionCall)parent;
                        for (int i = 0; i < parent2.Parameters.Count; i++)
                        {
                            if (Equals(parent2.Parameters[i], toReplace))
                            {
                                parent2.Parameters[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 78:
                    {
                        var parent2 = (RightFunctionCall)parent;
                        for (int i = 0; i < parent2.Parameters.Count; i++)
                        {
                            if (Equals(parent2.Parameters[i], toReplace))
                            {
                                parent2.Parameters[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 79:
                    {
                        var parent2 = (PartitionFunctionCall)parent;
                        for (int i = 0; i < parent2.Parameters.Count; i++)
                        {
                            if (Equals(parent2.Parameters[i], toReplace))
                            {
                                parent2.Parameters[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 80:
                    {
                        var parent2 = (OverClause)parent;
                        for (int i = 0; i < parent2.Partitions.Count; i++)
                        {
                            if (Equals(parent2.Partitions[i], toReplace))
                            {
                                parent2.Partitions[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 81:
                    {
                        var parent2 = (OdbcFunctionCall)parent;
                        for (int i = 0; i < parent2.Parameters.Count; i++)
                        {
                            if (Equals(parent2.Parameters[i], toReplace))
                            {
                                parent2.Parameters[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 82:
                    {
                        var parent2 = (ExtractFromExpression)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 83:
                    {
                        var parent2 = (CreateDefaultStatement)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 84:
                    {
                        var parent2 = (DeclareVariableElement)parent;
                        if (Equals(parent2.Value, toReplace))
                        {
                            parent2.Value = replacement;
                            success = true;
                        }
                        break;
                    }
                case 85:
                    {
                        var parent2 = (ProcedureParameter)parent;
                        if (Equals(parent2.Value, toReplace))
                        {
                            parent2.Value = replacement;
                            success = true;
                        }
                        break;
                    }
                case 86:
                    {
                        var parent2 = (WaitForStatement)parent;
                        if (Equals(parent2.Timeout, toReplace))
                        {
                            parent2.Timeout = replacement;
                            success = true;
                        }
                        break;
                    }
                case 87:
                    {
                        var parent2 = (UpdateTextStatement)parent;
                        if (Equals(parent2.InsertOffset, toReplace))
                        {
                            parent2.InsertOffset = replacement;
                            success = true;
                        }
                        if (Equals(parent2.DeleteLength, toReplace))
                        {
                            parent2.DeleteLength = replacement;
                            success = true;
                        }
                        break;
                    }
                case 88:
                    {
                        var parent2 = (SchemaObjectFunctionTableReference)parent;
                        for (int i = 0; i < parent2.Parameters.Count; i++)
                        {
                            if (Equals(parent2.Parameters[i], toReplace))
                            {
                                parent2.Parameters[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 89:
                    {
                        var parent2 = (SubqueryComparisonPredicate)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 90:
                    {
                        var parent2 = (LikePredicate)parent;
                        if (Equals(parent2.FirstExpression, toReplace))
                        {
                            parent2.FirstExpression = replacement;
                            success = true;
                        }
                        if (Equals(parent2.SecondExpression, toReplace))
                        {
                            parent2.SecondExpression = replacement;
                            success = true;
                        }
                        if (Equals(parent2.EscapeExpression, toReplace))
                        {
                            parent2.EscapeExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 91:
                    {
                        var parent2 = (InPredicate)parent;
                        if (Equals(parent2.Expression, toReplace))
                        {
                            parent2.Expression = replacement;
                            success = true;
                        }
                        for (int i = 0; i < parent2.Values.Count; i++)
                        {
                            if (Equals(parent2.Values[i], toReplace))
                            {
                                parent2.Values[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 92:
                    {
                        var parent2 = (VariableValuePair)parent;
                        if (Equals(parent2.Value, toReplace))
                        {
                            parent2.Value = replacement;
                            success = true;
                        }
                        break;
                    }
                case 93:
                    {
                        var parent2 = (SimpleWhenClause)parent;
                        if (Equals(parent2.WhenExpression, toReplace))
                        {
                            parent2.WhenExpression = replacement;
                            success = true;
                        }
                        if (Equals(parent2.ThenExpression, toReplace))
                        {
                            parent2.ThenExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 94:
                    {
                        var parent2 = (SearchedWhenClause)parent;
                        if (Equals(parent2.ThenExpression, toReplace))
                        {
                            parent2.ThenExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 95:
                    {
                        var parent2 = (SimpleCaseExpression)parent;
                        if (Equals(parent2.InputExpression, toReplace))
                        {
                            parent2.InputExpression = replacement;
                            success = true;
                        }
                        if (Equals(parent2.ElseExpression, toReplace))
                        {
                            parent2.ElseExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 96:
                    {
                        var parent2 = (SearchedCaseExpression)parent;
                        if (Equals(parent2.ElseExpression, toReplace))
                        {
                            parent2.ElseExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 97:
                    {
                        var parent2 = (NullIfExpression)parent;
                        if (Equals(parent2.FirstExpression, toReplace))
                        {
                            parent2.FirstExpression = replacement;
                            success = true;
                        }
                        if (Equals(parent2.SecondExpression, toReplace))
                        {
                            parent2.SecondExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 98:
                    {
                        var parent2 = (CoalesceExpression)parent;
                        for (int i = 0; i < parent2.Expressions.Count; i++)
                        {
                            if (Equals(parent2.Expressions[i], toReplace))
                            {
                                parent2.Expressions[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 99:
                    {
                        var parent2 = (IIfCall)parent;
                        if (Equals(parent2.ThenExpression, toReplace))
                        {
                            parent2.ThenExpression = replacement;
                            success = true;
                        }
                        if (Equals(parent2.ElseExpression, toReplace))
                        {
                            parent2.ElseExpression = replacement;
                            success = true;
                        }
                        break;
                    }
                case 100:
                    {
                        var parent2 = (SemanticTableReference)parent;
                        if (Equals(parent2.SourceKey, toReplace))
                        {
                            parent2.SourceKey = replacement;
                            success = true;
                        }
                        if (Equals(parent2.MatchedKey, toReplace))
                        {
                            parent2.MatchedKey = replacement;
                            success = true;
                        }
                        break;
                    }
                case 101:
                    {
                        var parent2 = (OpenJsonTableReference)parent;
                        if (Equals(parent2.Variable, toReplace))
                        {
                            parent2.Variable = replacement;
                            success = true;
                        }
                        if (Equals(parent2.RowPattern, toReplace))
                        {
                            parent2.RowPattern = replacement;
                            success = true;
                        }
                        break;
                    }
                case 102:
                    {
                        var parent2 = (InternalOpenRowset)parent;
                        for (int i = 0; i < parent2.VarArgs.Count; i++)
                        {
                            if (Equals(parent2.VarArgs[i], toReplace))
                            {
                                parent2.VarArgs[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 103:
                    {
                        var parent2 = (ConvertCall)parent;
                        if (Equals(parent2.Parameter, toReplace))
                        {
                            parent2.Parameter = replacement;
                            success = true;
                        }
                        if (Equals(parent2.Style, toReplace))
                        {
                            parent2.Style = replacement;
                            success = true;
                        }
                        break;
                    }
                case 104:
                    {
                        var parent2 = (TryConvertCall)parent;
                        if (Equals(parent2.Parameter, toReplace))
                        {
                            parent2.Parameter = replacement;
                            success = true;
                        }
                        if (Equals(parent2.Style, toReplace))
                        {
                            parent2.Style = replacement;
                            success = true;
                        }
                        break;
                    }
                case 105:
                    {
                        var parent2 = (ParseCall)parent;
                        if (Equals(parent2.StringValue, toReplace))
                        {
                            parent2.StringValue = replacement;
                            success = true;
                        }
                        if (Equals(parent2.Culture, toReplace))
                        {
                            parent2.Culture = replacement;
                            success = true;
                        }
                        break;
                    }
                case 106:
                    {
                        var parent2 = (TryParseCall)parent;
                        if (Equals(parent2.StringValue, toReplace))
                        {
                            parent2.StringValue = replacement;
                            success = true;
                        }
                        if (Equals(parent2.Culture, toReplace))
                        {
                            parent2.Culture = replacement;
                            success = true;
                        }
                        break;
                    }
                case 107:
                    {
                        var parent2 = (CastCall)parent;
                        if (Equals(parent2.Parameter, toReplace))
                        {
                            parent2.Parameter = replacement;
                            success = true;
                        }
                        break;
                    }
                case 108:
                    {
                        var parent2 = (TryCastCall)parent;
                        if (Equals(parent2.Parameter, toReplace))
                        {
                            parent2.Parameter = replacement;
                            success = true;
                        }
                        break;
                    }
                case 109:
                    {
                        var parent2 = (AtTimeZoneCall)parent;
                        if (Equals(parent2.DateValue, toReplace))
                        {
                            parent2.DateValue = replacement;
                            success = true;
                        }
                        if (Equals(parent2.TimeZone, toReplace))
                        {
                            parent2.TimeZone = replacement;
                            success = true;
                        }
                        break;
                    }
                case 110:
                    {
                        var parent2 = (FunctionCall)parent;
                        for (int i = 0; i < parent2.Parameters.Count; i++)
                        {
                            if (Equals(parent2.Parameters[i], toReplace))
                            {
                                parent2.Parameters[i] = replacement;
                                success = true;
                            }
                        }
                        break;
                    }
                case 111:
                    {
                        var parent2 = (ExecuteContext)parent;
                        if (Equals(parent2.Principal, toReplace))
                        {
                            parent2.Principal = replacement;
                            success = true;
                        }
                        break;
                    }
                case 112:
                    {
                        var parent2 = (ExecuteParameter)parent;
                        if (Equals(parent2.ParameterValue, toReplace))
                        {
                            parent2.ParameterValue = replacement;
                            success = true;
                        }
                        break;
                    }
                default: throw new NotImplementedException($"Type {parent.GetType().FullName} not implemented.");
            }
            return success;
        }
    }
}