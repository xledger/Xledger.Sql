using System;
using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Xledger.Sql {
    // GENERATED via script (Generate_ScopedFragmentTransformer.linq)
    // DO NOT EDIT DIRECTLY.
    public class ScopedFragmentTransformer : TSqlConcreteFragmentVisitor {
        public bool ShouldStop { get; set; }
        public Stack<TSqlFragment> Parents { get; set; } = new Stack<TSqlFragment>(30);
        public HashSet<TSqlFragment> SkipList { get; } = new HashSet<TSqlFragment>();
        ///<summary>Actions to perform when leaving a node.</summary>
        public Dictionary<TSqlFragment, Queue<Action<TSqlFragment>>> PendingOnLeaveActionsByFragment { get; set; } = new Dictionary<TSqlFragment, Queue<Action<TSqlFragment>>>();

        public Action<ScopedFragmentTransformer, WindowDelimiter> VisForWindowDelimiter;
        public Action<ScopedFragmentTransformer, WithinGroupClause> VisForWithinGroupClause;
        public Action<ScopedFragmentTransformer, SelectiveXmlIndexPromotedPath> VisForSelectiveXmlIndexPromotedPath;
        public Action<ScopedFragmentTransformer, TemporalClause> VisForTemporalClause;
        public Action<ScopedFragmentTransformer, CompressionDelayIndexOption> VisForCompressionDelayIndexOption;
        public Action<ScopedFragmentTransformer, CreateExternalLibraryStatement> VisForCreateExternalLibraryStatement;
        public Action<ScopedFragmentTransformer, AlterExternalLibraryStatement> VisForAlterExternalLibraryStatement;
        public Action<ScopedFragmentTransformer, ExternalLibraryFileOption> VisForExternalLibraryFileOption;
        public Action<ScopedFragmentTransformer, DropExternalLibraryStatement> VisForDropExternalLibraryStatement;
        public Action<ScopedFragmentTransformer, CreateExternalLanguageStatement> VisForCreateExternalLanguageStatement;
        public Action<ScopedFragmentTransformer, AlterExternalLanguageStatement> VisForAlterExternalLanguageStatement;
        public Action<ScopedFragmentTransformer, ExternalLanguageFileOption> VisForExternalLanguageFileOption;
        public Action<ScopedFragmentTransformer, DropExternalLanguageStatement> VisForDropExternalLanguageStatement;
        public Action<ScopedFragmentTransformer, EventDeclaration> VisForEventDeclaration;
        public Action<ScopedFragmentTransformer, EventDeclarationSetParameter> VisForEventDeclarationSetParameter;
        public Action<ScopedFragmentTransformer, SourceDeclaration> VisForSourceDeclaration;
        public Action<ScopedFragmentTransformer, EventDeclarationCompareFunctionParameter> VisForEventDeclarationCompareFunctionParameter;
        public Action<ScopedFragmentTransformer, TargetDeclaration> VisForTargetDeclaration;
        public Action<ScopedFragmentTransformer, EventRetentionSessionOption> VisForEventRetentionSessionOption;
        public Action<ScopedFragmentTransformer, MemoryPartitionSessionOption> VisForMemoryPartitionSessionOption;
        public Action<ScopedFragmentTransformer, LiteralSessionOption> VisForLiteralSessionOption;
        public Action<ScopedFragmentTransformer, MaxDispatchLatencySessionOption> VisForMaxDispatchLatencySessionOption;
        public Action<ScopedFragmentTransformer, OnOffSessionOption> VisForOnOffSessionOption;
        public Action<ScopedFragmentTransformer, AlterEventSessionStatement> VisForAlterEventSessionStatement;
        public Action<ScopedFragmentTransformer, DropEventSessionStatement> VisForDropEventSessionStatement;
        public Action<ScopedFragmentTransformer, AlterResourceGovernorStatement> VisForAlterResourceGovernorStatement;
        public Action<ScopedFragmentTransformer, CreateSpatialIndexStatement> VisForCreateSpatialIndexStatement;
        public Action<ScopedFragmentTransformer, SpatialIndexRegularOption> VisForSpatialIndexRegularOption;
        public Action<ScopedFragmentTransformer, BoundingBoxSpatialIndexOption> VisForBoundingBoxSpatialIndexOption;
        public Action<ScopedFragmentTransformer, BoundingBoxParameter> VisForBoundingBoxParameter;
        public Action<ScopedFragmentTransformer, GridsSpatialIndexOption> VisForGridsSpatialIndexOption;
        public Action<ScopedFragmentTransformer, GridParameter> VisForGridParameter;
        public Action<ScopedFragmentTransformer, CellsPerObjectSpatialIndexOption> VisForCellsPerObjectSpatialIndexOption;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationStatement> VisForAlterServerConfigurationStatement;
        public Action<ScopedFragmentTransformer, ProcessAffinityRange> VisForProcessAffinityRange;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationSetExternalAuthenticationStatement> VisForAlterServerConfigurationSetExternalAuthenticationStatement;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationExternalAuthenticationOption> VisForAlterServerConfigurationExternalAuthenticationOption;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationExternalAuthenticationContainerOption> VisForAlterServerConfigurationExternalAuthenticationContainerOption;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationSetBufferPoolExtensionStatement> VisForAlterServerConfigurationSetBufferPoolExtensionStatement;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationBufferPoolExtensionOption> VisForAlterServerConfigurationBufferPoolExtensionOption;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationBufferPoolExtensionContainerOption> VisForAlterServerConfigurationBufferPoolExtensionContainerOption;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationBufferPoolExtensionSizeOption> VisForAlterServerConfigurationBufferPoolExtensionSizeOption;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationSetDiagnosticsLogStatement> VisForAlterServerConfigurationSetDiagnosticsLogStatement;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationDiagnosticsLogOption> VisForAlterServerConfigurationDiagnosticsLogOption;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationDiagnosticsLogMaxSizeOption> VisForAlterServerConfigurationDiagnosticsLogMaxSizeOption;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationSetFailoverClusterPropertyStatement> VisForAlterServerConfigurationSetFailoverClusterPropertyStatement;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationFailoverClusterPropertyOption> VisForAlterServerConfigurationFailoverClusterPropertyOption;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationSetHadrClusterStatement> VisForAlterServerConfigurationSetHadrClusterStatement;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationHadrClusterOption> VisForAlterServerConfigurationHadrClusterOption;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationSetSoftNumaStatement> VisForAlterServerConfigurationSetSoftNumaStatement;
        public Action<ScopedFragmentTransformer, AlterServerConfigurationSoftNumaOption> VisForAlterServerConfigurationSoftNumaOption;
        public Action<ScopedFragmentTransformer, CreateAvailabilityGroupStatement> VisForCreateAvailabilityGroupStatement;
        public Action<ScopedFragmentTransformer, AlterAvailabilityGroupStatement> VisForAlterAvailabilityGroupStatement;
        public Action<ScopedFragmentTransformer, AvailabilityReplica> VisForAvailabilityReplica;
        public Action<ScopedFragmentTransformer, LiteralReplicaOption> VisForLiteralReplicaOption;
        public Action<ScopedFragmentTransformer, AvailabilityModeReplicaOption> VisForAvailabilityModeReplicaOption;
        public Action<ScopedFragmentTransformer, FailoverModeReplicaOption> VisForFailoverModeReplicaOption;
        public Action<ScopedFragmentTransformer, PrimaryRoleReplicaOption> VisForPrimaryRoleReplicaOption;
        public Action<ScopedFragmentTransformer, SecondaryRoleReplicaOption> VisForSecondaryRoleReplicaOption;
        public Action<ScopedFragmentTransformer, LiteralAvailabilityGroupOption> VisForLiteralAvailabilityGroupOption;
        public Action<ScopedFragmentTransformer, AlterAvailabilityGroupAction> VisForAlterAvailabilityGroupAction;
        public Action<ScopedFragmentTransformer, AlterAvailabilityGroupFailoverAction> VisForAlterAvailabilityGroupFailoverAction;
        public Action<ScopedFragmentTransformer, AlterAvailabilityGroupFailoverOption> VisForAlterAvailabilityGroupFailoverOption;
        public Action<ScopedFragmentTransformer, DropAvailabilityGroupStatement> VisForDropAvailabilityGroupStatement;
        public Action<ScopedFragmentTransformer, CreateFederationStatement> VisForCreateFederationStatement;
        public Action<ScopedFragmentTransformer, AlterFederationStatement> VisForAlterFederationStatement;
        public Action<ScopedFragmentTransformer, DropFederationStatement> VisForDropFederationStatement;
        public Action<ScopedFragmentTransformer, UseFederationStatement> VisForUseFederationStatement;
        public Action<ScopedFragmentTransformer, DiskStatement> VisForDiskStatement;
        public Action<ScopedFragmentTransformer, DiskStatementOption> VisForDiskStatementOption;
        public Action<ScopedFragmentTransformer, CreateColumnStoreIndexStatement> VisForCreateColumnStoreIndexStatement;
        public Action<ScopedFragmentTransformer, WindowFrameClause> VisForWindowFrameClause;
        public Action<ScopedFragmentTransformer, DropServerAuditStatement> VisForDropServerAuditStatement;
        public Action<ScopedFragmentTransformer, AuditTarget> VisForAuditTarget;
        public Action<ScopedFragmentTransformer, QueueDelayAuditOption> VisForQueueDelayAuditOption;
        public Action<ScopedFragmentTransformer, AuditGuidAuditOption> VisForAuditGuidAuditOption;
        public Action<ScopedFragmentTransformer, OnFailureAuditOption> VisForOnFailureAuditOption;
        public Action<ScopedFragmentTransformer, OperatorAuditOption> VisForOperatorAuditOption;
        public Action<ScopedFragmentTransformer, StateAuditOption> VisForStateAuditOption;
        public Action<ScopedFragmentTransformer, MaxSizeAuditTargetOption> VisForMaxSizeAuditTargetOption;
        public Action<ScopedFragmentTransformer, RetentionDaysAuditTargetOption> VisForRetentionDaysAuditTargetOption;
        public Action<ScopedFragmentTransformer, MaxRolloverFilesAuditTargetOption> VisForMaxRolloverFilesAuditTargetOption;
        public Action<ScopedFragmentTransformer, LiteralAuditTargetOption> VisForLiteralAuditTargetOption;
        public Action<ScopedFragmentTransformer, OnOffAuditTargetOption> VisForOnOffAuditTargetOption;
        public Action<ScopedFragmentTransformer, CreateDatabaseEncryptionKeyStatement> VisForCreateDatabaseEncryptionKeyStatement;
        public Action<ScopedFragmentTransformer, AlterDatabaseEncryptionKeyStatement> VisForAlterDatabaseEncryptionKeyStatement;
        public Action<ScopedFragmentTransformer, DropDatabaseEncryptionKeyStatement> VisForDropDatabaseEncryptionKeyStatement;
        public Action<ScopedFragmentTransformer, ResourcePoolStatement> VisForResourcePoolStatement;
        public Action<ScopedFragmentTransformer, ResourcePoolParameter> VisForResourcePoolParameter;
        public Action<ScopedFragmentTransformer, ResourcePoolAffinitySpecification> VisForResourcePoolAffinitySpecification;
        public Action<ScopedFragmentTransformer, CreateResourcePoolStatement> VisForCreateResourcePoolStatement;
        public Action<ScopedFragmentTransformer, AlterResourcePoolStatement> VisForAlterResourcePoolStatement;
        public Action<ScopedFragmentTransformer, DropResourcePoolStatement> VisForDropResourcePoolStatement;
        public Action<ScopedFragmentTransformer, ExternalResourcePoolStatement> VisForExternalResourcePoolStatement;
        public Action<ScopedFragmentTransformer, ExternalResourcePoolParameter> VisForExternalResourcePoolParameter;
        public Action<ScopedFragmentTransformer, ExternalResourcePoolAffinitySpecification> VisForExternalResourcePoolAffinitySpecification;
        public Action<ScopedFragmentTransformer, CreateExternalResourcePoolStatement> VisForCreateExternalResourcePoolStatement;
        public Action<ScopedFragmentTransformer, AlterExternalResourcePoolStatement> VisForAlterExternalResourcePoolStatement;
        public Action<ScopedFragmentTransformer, DropExternalResourcePoolStatement> VisForDropExternalResourcePoolStatement;
        public Action<ScopedFragmentTransformer, WorkloadGroupResourceParameter> VisForWorkloadGroupResourceParameter;
        public Action<ScopedFragmentTransformer, WorkloadGroupImportanceParameter> VisForWorkloadGroupImportanceParameter;
        public Action<ScopedFragmentTransformer, CreateWorkloadGroupStatement> VisForCreateWorkloadGroupStatement;
        public Action<ScopedFragmentTransformer, AlterWorkloadGroupStatement> VisForAlterWorkloadGroupStatement;
        public Action<ScopedFragmentTransformer, DropWorkloadGroupStatement> VisForDropWorkloadGroupStatement;
        public Action<ScopedFragmentTransformer, ClassifierWorkloadGroupOption> VisForClassifierWorkloadGroupOption;
        public Action<ScopedFragmentTransformer, ClassifierMemberNameOption> VisForClassifierMemberNameOption;
        public Action<ScopedFragmentTransformer, ClassifierWlmLabelOption> VisForClassifierWlmLabelOption;
        public Action<ScopedFragmentTransformer, ClassifierImportanceOption> VisForClassifierImportanceOption;
        public Action<ScopedFragmentTransformer, ClassifierWlmContextOption> VisForClassifierWlmContextOption;
        public Action<ScopedFragmentTransformer, ClassifierStartTimeOption> VisForClassifierStartTimeOption;
        public Action<ScopedFragmentTransformer, ClassifierEndTimeOption> VisForClassifierEndTimeOption;
        public Action<ScopedFragmentTransformer, WlmTimeLiteral> VisForWlmTimeLiteral;
        public Action<ScopedFragmentTransformer, CreateWorkloadClassifierStatement> VisForCreateWorkloadClassifierStatement;
        public Action<ScopedFragmentTransformer, DropWorkloadClassifierStatement> VisForDropWorkloadClassifierStatement;
        public Action<ScopedFragmentTransformer, BrokerPriorityParameter> VisForBrokerPriorityParameter;
        public Action<ScopedFragmentTransformer, CreateBrokerPriorityStatement> VisForCreateBrokerPriorityStatement;
        public Action<ScopedFragmentTransformer, AlterBrokerPriorityStatement> VisForAlterBrokerPriorityStatement;
        public Action<ScopedFragmentTransformer, DropBrokerPriorityStatement> VisForDropBrokerPriorityStatement;
        public Action<ScopedFragmentTransformer, CreateFullTextStopListStatement> VisForCreateFullTextStopListStatement;
        public Action<ScopedFragmentTransformer, AlterFullTextStopListStatement> VisForAlterFullTextStopListStatement;
        public Action<ScopedFragmentTransformer, FullTextStopListAction> VisForFullTextStopListAction;
        public Action<ScopedFragmentTransformer, DropFullTextStopListStatement> VisForDropFullTextStopListStatement;
        public Action<ScopedFragmentTransformer, CreateCryptographicProviderStatement> VisForCreateCryptographicProviderStatement;
        public Action<ScopedFragmentTransformer, AlterCryptographicProviderStatement> VisForAlterCryptographicProviderStatement;
        public Action<ScopedFragmentTransformer, DropCryptographicProviderStatement> VisForDropCryptographicProviderStatement;
        public Action<ScopedFragmentTransformer, EventSessionObjectName> VisForEventSessionObjectName;
        public Action<ScopedFragmentTransformer, EventSessionStatement> VisForEventSessionStatement;
        public Action<ScopedFragmentTransformer, CreateEventSessionStatement> VisForCreateEventSessionStatement;
        public Action<ScopedFragmentTransformer, AddSignatureStatement> VisForAddSignatureStatement;
        public Action<ScopedFragmentTransformer, DropSignatureStatement> VisForDropSignatureStatement;
        public Action<ScopedFragmentTransformer, DropEventNotificationStatement> VisForDropEventNotificationStatement;
        public Action<ScopedFragmentTransformer, ExecuteAsStatement> VisForExecuteAsStatement;
        public Action<ScopedFragmentTransformer, EndConversationStatement> VisForEndConversationStatement;
        public Action<ScopedFragmentTransformer, MoveConversationStatement> VisForMoveConversationStatement;
        public Action<ScopedFragmentTransformer, GetConversationGroupStatement> VisForGetConversationGroupStatement;
        public Action<ScopedFragmentTransformer, ReceiveStatement> VisForReceiveStatement;
        public Action<ScopedFragmentTransformer, SendStatement> VisForSendStatement;
        public Action<ScopedFragmentTransformer, AlterSchemaStatement> VisForAlterSchemaStatement;
        public Action<ScopedFragmentTransformer, AlterAsymmetricKeyStatement> VisForAlterAsymmetricKeyStatement;
        public Action<ScopedFragmentTransformer, AlterServiceMasterKeyStatement> VisForAlterServiceMasterKeyStatement;
        public Action<ScopedFragmentTransformer, BeginConversationTimerStatement> VisForBeginConversationTimerStatement;
        public Action<ScopedFragmentTransformer, BeginDialogStatement> VisForBeginDialogStatement;
        public Action<ScopedFragmentTransformer, ScalarExpressionDialogOption> VisForScalarExpressionDialogOption;
        public Action<ScopedFragmentTransformer, OnOffDialogOption> VisForOnOffDialogOption;
        public Action<ScopedFragmentTransformer, BackupCertificateStatement> VisForBackupCertificateStatement;
        public Action<ScopedFragmentTransformer, BackupServiceMasterKeyStatement> VisForBackupServiceMasterKeyStatement;
        public Action<ScopedFragmentTransformer, RestoreServiceMasterKeyStatement> VisForRestoreServiceMasterKeyStatement;
        public Action<ScopedFragmentTransformer, BackupMasterKeyStatement> VisForBackupMasterKeyStatement;
        public Action<ScopedFragmentTransformer, RestoreMasterKeyStatement> VisForRestoreMasterKeyStatement;
        public Action<ScopedFragmentTransformer, ScalarExpressionSnippet> VisForScalarExpressionSnippet;
        public Action<ScopedFragmentTransformer, BooleanExpressionSnippet> VisForBooleanExpressionSnippet;
        public Action<ScopedFragmentTransformer, StatementListSnippet> VisForStatementListSnippet;
        public Action<ScopedFragmentTransformer, SelectStatementSnippet> VisForSelectStatementSnippet;
        public Action<ScopedFragmentTransformer, SchemaObjectNameSnippet> VisForSchemaObjectNameSnippet;
        public Action<ScopedFragmentTransformer, TSqlFragmentSnippet> VisForTSqlFragmentSnippet;
        public Action<ScopedFragmentTransformer, TSqlStatementSnippet> VisForTSqlStatementSnippet;
        public Action<ScopedFragmentTransformer, IdentifierSnippet> VisForIdentifierSnippet;
        public Action<ScopedFragmentTransformer, TSqlScript> VisForTSqlScript;
        public Action<ScopedFragmentTransformer, TSqlBatch> VisForTSqlBatch;
        public Action<ScopedFragmentTransformer, MergeStatement> VisForMergeStatement;
        public Action<ScopedFragmentTransformer, MergeSpecification> VisForMergeSpecification;
        public Action<ScopedFragmentTransformer, MergeActionClause> VisForMergeActionClause;
        public Action<ScopedFragmentTransformer, UpdateMergeAction> VisForUpdateMergeAction;
        public Action<ScopedFragmentTransformer, DeleteMergeAction> VisForDeleteMergeAction;
        public Action<ScopedFragmentTransformer, InsertMergeAction> VisForInsertMergeAction;
        public Action<ScopedFragmentTransformer, CreateTypeTableStatement> VisForCreateTypeTableStatement;
        public Action<ScopedFragmentTransformer, SensitivityClassificationOption> VisForSensitivityClassificationOption;
        public Action<ScopedFragmentTransformer, AddSensitivityClassificationStatement> VisForAddSensitivityClassificationStatement;
        public Action<ScopedFragmentTransformer, DropSensitivityClassificationStatement> VisForDropSensitivityClassificationStatement;
        public Action<ScopedFragmentTransformer, AuditSpecificationPart> VisForAuditSpecificationPart;
        public Action<ScopedFragmentTransformer, AuditActionSpecification> VisForAuditActionSpecification;
        public Action<ScopedFragmentTransformer, DatabaseAuditAction> VisForDatabaseAuditAction;
        public Action<ScopedFragmentTransformer, AuditActionGroupReference> VisForAuditActionGroupReference;
        public Action<ScopedFragmentTransformer, CreateDatabaseAuditSpecificationStatement> VisForCreateDatabaseAuditSpecificationStatement;
        public Action<ScopedFragmentTransformer, AlterDatabaseAuditSpecificationStatement> VisForAlterDatabaseAuditSpecificationStatement;
        public Action<ScopedFragmentTransformer, DropDatabaseAuditSpecificationStatement> VisForDropDatabaseAuditSpecificationStatement;
        public Action<ScopedFragmentTransformer, CreateServerAuditSpecificationStatement> VisForCreateServerAuditSpecificationStatement;
        public Action<ScopedFragmentTransformer, AlterServerAuditSpecificationStatement> VisForAlterServerAuditSpecificationStatement;
        public Action<ScopedFragmentTransformer, DropServerAuditSpecificationStatement> VisForDropServerAuditSpecificationStatement;
        public Action<ScopedFragmentTransformer, CreateServerAuditStatement> VisForCreateServerAuditStatement;
        public Action<ScopedFragmentTransformer, AlterServerAuditStatement> VisForAlterServerAuditStatement;
        public Action<ScopedFragmentTransformer, TopRowFilter> VisForTopRowFilter;
        public Action<ScopedFragmentTransformer, OffsetClause> VisForOffsetClause;
        public Action<ScopedFragmentTransformer, UnaryExpression> VisForUnaryExpression;
        public Action<ScopedFragmentTransformer, BinaryQueryExpression> VisForBinaryQueryExpression;
        public Action<ScopedFragmentTransformer, VariableTableReference> VisForVariableTableReference;
        public Action<ScopedFragmentTransformer, VariableMethodCallTableReference> VisForVariableMethodCallTableReference;
        public Action<ScopedFragmentTransformer, DropPartitionFunctionStatement> VisForDropPartitionFunctionStatement;
        public Action<ScopedFragmentTransformer, DropPartitionSchemeStatement> VisForDropPartitionSchemeStatement;
        public Action<ScopedFragmentTransformer, DropSynonymStatement> VisForDropSynonymStatement;
        public Action<ScopedFragmentTransformer, DropAggregateStatement> VisForDropAggregateStatement;
        public Action<ScopedFragmentTransformer, DropAssemblyStatement> VisForDropAssemblyStatement;
        public Action<ScopedFragmentTransformer, DropApplicationRoleStatement> VisForDropApplicationRoleStatement;
        public Action<ScopedFragmentTransformer, DropFullTextCatalogStatement> VisForDropFullTextCatalogStatement;
        public Action<ScopedFragmentTransformer, DropFullTextIndexStatement> VisForDropFullTextIndexStatement;
        public Action<ScopedFragmentTransformer, DropLoginStatement> VisForDropLoginStatement;
        public Action<ScopedFragmentTransformer, DropRoleStatement> VisForDropRoleStatement;
        public Action<ScopedFragmentTransformer, DropTypeStatement> VisForDropTypeStatement;
        public Action<ScopedFragmentTransformer, DropUserStatement> VisForDropUserStatement;
        public Action<ScopedFragmentTransformer, DropMasterKeyStatement> VisForDropMasterKeyStatement;
        public Action<ScopedFragmentTransformer, DropSymmetricKeyStatement> VisForDropSymmetricKeyStatement;
        public Action<ScopedFragmentTransformer, DropAsymmetricKeyStatement> VisForDropAsymmetricKeyStatement;
        public Action<ScopedFragmentTransformer, DropCertificateStatement> VisForDropCertificateStatement;
        public Action<ScopedFragmentTransformer, DropCredentialStatement> VisForDropCredentialStatement;
        public Action<ScopedFragmentTransformer, AlterPartitionFunctionStatement> VisForAlterPartitionFunctionStatement;
        public Action<ScopedFragmentTransformer, AlterPartitionSchemeStatement> VisForAlterPartitionSchemeStatement;
        public Action<ScopedFragmentTransformer, AlterFullTextIndexStatement> VisForAlterFullTextIndexStatement;
        public Action<ScopedFragmentTransformer, SimpleAlterFullTextIndexAction> VisForSimpleAlterFullTextIndexAction;
        public Action<ScopedFragmentTransformer, SetStopListAlterFullTextIndexAction> VisForSetStopListAlterFullTextIndexAction;
        public Action<ScopedFragmentTransformer, SetSearchPropertyListAlterFullTextIndexAction> VisForSetSearchPropertyListAlterFullTextIndexAction;
        public Action<ScopedFragmentTransformer, DropAlterFullTextIndexAction> VisForDropAlterFullTextIndexAction;
        public Action<ScopedFragmentTransformer, AddAlterFullTextIndexAction> VisForAddAlterFullTextIndexAction;
        public Action<ScopedFragmentTransformer, AlterColumnAlterFullTextIndexAction> VisForAlterColumnAlterFullTextIndexAction;
        public Action<ScopedFragmentTransformer, CreateSearchPropertyListStatement> VisForCreateSearchPropertyListStatement;
        public Action<ScopedFragmentTransformer, AlterSearchPropertyListStatement> VisForAlterSearchPropertyListStatement;
        public Action<ScopedFragmentTransformer, AddSearchPropertyListAction> VisForAddSearchPropertyListAction;
        public Action<ScopedFragmentTransformer, DropSearchPropertyListAction> VisForDropSearchPropertyListAction;
        public Action<ScopedFragmentTransformer, DropSearchPropertyListStatement> VisForDropSearchPropertyListStatement;
        public Action<ScopedFragmentTransformer, CreateLoginStatement> VisForCreateLoginStatement;
        public Action<ScopedFragmentTransformer, PasswordCreateLoginSource> VisForPasswordCreateLoginSource;
        public Action<ScopedFragmentTransformer, PrincipalOption> VisForPrincipalOption;
        public Action<ScopedFragmentTransformer, OnOffPrincipalOption> VisForOnOffPrincipalOption;
        public Action<ScopedFragmentTransformer, LiteralPrincipalOption> VisForLiteralPrincipalOption;
        public Action<ScopedFragmentTransformer, IdentifierPrincipalOption> VisForIdentifierPrincipalOption;
        public Action<ScopedFragmentTransformer, WindowsCreateLoginSource> VisForWindowsCreateLoginSource;
        public Action<ScopedFragmentTransformer, ExternalCreateLoginSource> VisForExternalCreateLoginSource;
        public Action<ScopedFragmentTransformer, CertificateCreateLoginSource> VisForCertificateCreateLoginSource;
        public Action<ScopedFragmentTransformer, AsymmetricKeyCreateLoginSource> VisForAsymmetricKeyCreateLoginSource;
        public Action<ScopedFragmentTransformer, PasswordAlterPrincipalOption> VisForPasswordAlterPrincipalOption;
        public Action<ScopedFragmentTransformer, AlterLoginOptionsStatement> VisForAlterLoginOptionsStatement;
        public Action<ScopedFragmentTransformer, AlterLoginEnableDisableStatement> VisForAlterLoginEnableDisableStatement;
        public Action<ScopedFragmentTransformer, AlterLoginAddDropCredentialStatement> VisForAlterLoginAddDropCredentialStatement;
        public Action<ScopedFragmentTransformer, RevertStatement> VisForRevertStatement;
        public Action<ScopedFragmentTransformer, DropContractStatement> VisForDropContractStatement;
        public Action<ScopedFragmentTransformer, DropEndpointStatement> VisForDropEndpointStatement;
        public Action<ScopedFragmentTransformer, DropMessageTypeStatement> VisForDropMessageTypeStatement;
        public Action<ScopedFragmentTransformer, DropQueueStatement> VisForDropQueueStatement;
        public Action<ScopedFragmentTransformer, DropRemoteServiceBindingStatement> VisForDropRemoteServiceBindingStatement;
        public Action<ScopedFragmentTransformer, DropRouteStatement> VisForDropRouteStatement;
        public Action<ScopedFragmentTransformer, DropServiceStatement> VisForDropServiceStatement;
        public Action<ScopedFragmentTransformer, OnOffFullTextCatalogOption> VisForOnOffFullTextCatalogOption;
        public Action<ScopedFragmentTransformer, CreateFullTextCatalogStatement> VisForCreateFullTextCatalogStatement;
        public Action<ScopedFragmentTransformer, AlterFullTextCatalogStatement> VisForAlterFullTextCatalogStatement;
        public Action<ScopedFragmentTransformer, CreateServiceStatement> VisForCreateServiceStatement;
        public Action<ScopedFragmentTransformer, AlterServiceStatement> VisForAlterServiceStatement;
        public Action<ScopedFragmentTransformer, ServiceContract> VisForServiceContract;
        public Action<ScopedFragmentTransformer, BinaryExpression> VisForBinaryExpression;
        public Action<ScopedFragmentTransformer, BuiltInFunctionTableReference> VisForBuiltInFunctionTableReference;
        public Action<ScopedFragmentTransformer, GlobalFunctionTableReference> VisForGlobalFunctionTableReference;
        public Action<ScopedFragmentTransformer, ComputeClause> VisForComputeClause;
        public Action<ScopedFragmentTransformer, ComputeFunction> VisForComputeFunction;
        public Action<ScopedFragmentTransformer, PivotedTableReference> VisForPivotedTableReference;
        public Action<ScopedFragmentTransformer, UnpivotedTableReference> VisForUnpivotedTableReference;
        public Action<ScopedFragmentTransformer, UnqualifiedJoin> VisForUnqualifiedJoin;
        public Action<ScopedFragmentTransformer, TableSampleClause> VisForTableSampleClause;
        public Action<ScopedFragmentTransformer, BooleanNotExpression> VisForBooleanNotExpression;
        public Action<ScopedFragmentTransformer, BooleanParenthesisExpression> VisForBooleanParenthesisExpression;
        public Action<ScopedFragmentTransformer, BooleanComparisonExpression> VisForBooleanComparisonExpression;
        public Action<ScopedFragmentTransformer, BooleanBinaryExpression> VisForBooleanBinaryExpression;
        public Action<ScopedFragmentTransformer, BooleanIsNullExpression> VisForBooleanIsNullExpression;
        public Action<ScopedFragmentTransformer, GraphMatchPredicate> VisForGraphMatchPredicate;
        public Action<ScopedFragmentTransformer, GraphMatchLastNodePredicate> VisForGraphMatchLastNodePredicate;
        public Action<ScopedFragmentTransformer, GraphMatchNodeExpression> VisForGraphMatchNodeExpression;
        public Action<ScopedFragmentTransformer, GraphMatchRecursivePredicate> VisForGraphMatchRecursivePredicate;
        public Action<ScopedFragmentTransformer, GraphMatchExpression> VisForGraphMatchExpression;
        public Action<ScopedFragmentTransformer, GraphMatchCompositeExpression> VisForGraphMatchCompositeExpression;
        public Action<ScopedFragmentTransformer, GraphRecursiveMatchQuantifier> VisForGraphRecursiveMatchQuantifier;
        public Action<ScopedFragmentTransformer, ExpressionWithSortOrder> VisForExpressionWithSortOrder;
        public Action<ScopedFragmentTransformer, GroupByClause> VisForGroupByClause;
        public Action<ScopedFragmentTransformer, ExpressionGroupingSpecification> VisForExpressionGroupingSpecification;
        public Action<ScopedFragmentTransformer, CompositeGroupingSpecification> VisForCompositeGroupingSpecification;
        public Action<ScopedFragmentTransformer, CubeGroupingSpecification> VisForCubeGroupingSpecification;
        public Action<ScopedFragmentTransformer, RollupGroupingSpecification> VisForRollupGroupingSpecification;
        public Action<ScopedFragmentTransformer, GrandTotalGroupingSpecification> VisForGrandTotalGroupingSpecification;
        public Action<ScopedFragmentTransformer, GroupingSetsGroupingSpecification> VisForGroupingSetsGroupingSpecification;
        public Action<ScopedFragmentTransformer, OutputClause> VisForOutputClause;
        public Action<ScopedFragmentTransformer, OutputIntoClause> VisForOutputIntoClause;
        public Action<ScopedFragmentTransformer, HavingClause> VisForHavingClause;
        public Action<ScopedFragmentTransformer, IdentityFunctionCall> VisForIdentityFunctionCall;
        public Action<ScopedFragmentTransformer, JoinParenthesisTableReference> VisForJoinParenthesisTableReference;
        public Action<ScopedFragmentTransformer, OrderByClause> VisForOrderByClause;
        public Action<ScopedFragmentTransformer, QualifiedJoin> VisForQualifiedJoin;
        public Action<ScopedFragmentTransformer, OdbcQualifiedJoinTableReference> VisForOdbcQualifiedJoinTableReference;
        public Action<ScopedFragmentTransformer, QueryParenthesisExpression> VisForQueryParenthesisExpression;
        public Action<ScopedFragmentTransformer, QuerySpecification> VisForQuerySpecification;
        public Action<ScopedFragmentTransformer, FromClause> VisForFromClause;
        public Action<ScopedFragmentTransformer, PredictTableReference> VisForPredictTableReference;
        public Action<ScopedFragmentTransformer, SelectScalarExpression> VisForSelectScalarExpression;
        public Action<ScopedFragmentTransformer, SelectStarExpression> VisForSelectStarExpression;
        public Action<ScopedFragmentTransformer, SelectSetVariable> VisForSelectSetVariable;
        public Action<ScopedFragmentTransformer, DataModificationTableReference> VisForDataModificationTableReference;
        public Action<ScopedFragmentTransformer, ChangeTableChangesTableReference> VisForChangeTableChangesTableReference;
        public Action<ScopedFragmentTransformer, ChangeTableVersionTableReference> VisForChangeTableVersionTableReference;
        public Action<ScopedFragmentTransformer, BooleanTernaryExpression> VisForBooleanTernaryExpression;
        public Action<ScopedFragmentTransformer, DbccStatement> VisForDbccStatement;
        public Action<ScopedFragmentTransformer, DbccOption> VisForDbccOption;
        public Action<ScopedFragmentTransformer, DbccNamedLiteral> VisForDbccNamedLiteral;
        public Action<ScopedFragmentTransformer, CreateAsymmetricKeyStatement> VisForCreateAsymmetricKeyStatement;
        public Action<ScopedFragmentTransformer, CreatePartitionFunctionStatement> VisForCreatePartitionFunctionStatement;
        public Action<ScopedFragmentTransformer, PartitionParameterType> VisForPartitionParameterType;
        public Action<ScopedFragmentTransformer, CreatePartitionSchemeStatement> VisForCreatePartitionSchemeStatement;
        public Action<ScopedFragmentTransformer, OnOffRemoteServiceBindingOption> VisForOnOffRemoteServiceBindingOption;
        public Action<ScopedFragmentTransformer, UserRemoteServiceBindingOption> VisForUserRemoteServiceBindingOption;
        public Action<ScopedFragmentTransformer, CreateRemoteServiceBindingStatement> VisForCreateRemoteServiceBindingStatement;
        public Action<ScopedFragmentTransformer, AlterRemoteServiceBindingStatement> VisForAlterRemoteServiceBindingStatement;
        public Action<ScopedFragmentTransformer, AssemblyEncryptionSource> VisForAssemblyEncryptionSource;
        public Action<ScopedFragmentTransformer, FileEncryptionSource> VisForFileEncryptionSource;
        public Action<ScopedFragmentTransformer, ProviderEncryptionSource> VisForProviderEncryptionSource;
        public Action<ScopedFragmentTransformer, AlterCertificateStatement> VisForAlterCertificateStatement;
        public Action<ScopedFragmentTransformer, CreateCertificateStatement> VisForCreateCertificateStatement;
        public Action<ScopedFragmentTransformer, CertificateOption> VisForCertificateOption;
        public Action<ScopedFragmentTransformer, CreateContractStatement> VisForCreateContractStatement;
        public Action<ScopedFragmentTransformer, ContractMessage> VisForContractMessage;
        public Action<ScopedFragmentTransformer, CreateCredentialStatement> VisForCreateCredentialStatement;
        public Action<ScopedFragmentTransformer, AlterCredentialStatement> VisForAlterCredentialStatement;
        public Action<ScopedFragmentTransformer, CreateMessageTypeStatement> VisForCreateMessageTypeStatement;
        public Action<ScopedFragmentTransformer, AlterMessageTypeStatement> VisForAlterMessageTypeStatement;
        public Action<ScopedFragmentTransformer, CreateAggregateStatement> VisForCreateAggregateStatement;
        public Action<ScopedFragmentTransformer, CreateEndpointStatement> VisForCreateEndpointStatement;
        public Action<ScopedFragmentTransformer, AlterEndpointStatement> VisForAlterEndpointStatement;
        public Action<ScopedFragmentTransformer, EndpointAffinity> VisForEndpointAffinity;
        public Action<ScopedFragmentTransformer, LiteralEndpointProtocolOption> VisForLiteralEndpointProtocolOption;
        public Action<ScopedFragmentTransformer, AuthenticationEndpointProtocolOption> VisForAuthenticationEndpointProtocolOption;
        public Action<ScopedFragmentTransformer, PortsEndpointProtocolOption> VisForPortsEndpointProtocolOption;
        public Action<ScopedFragmentTransformer, CompressionEndpointProtocolOption> VisForCompressionEndpointProtocolOption;
        public Action<ScopedFragmentTransformer, ListenerIPEndpointProtocolOption> VisForListenerIPEndpointProtocolOption;
        public Action<ScopedFragmentTransformer, IPv4> VisForIPv4;
        public Action<ScopedFragmentTransformer, SoapMethod> VisForSoapMethod;
        public Action<ScopedFragmentTransformer, EnabledDisabledPayloadOption> VisForEnabledDisabledPayloadOption;
        public Action<ScopedFragmentTransformer, WsdlPayloadOption> VisForWsdlPayloadOption;
        public Action<ScopedFragmentTransformer, LoginTypePayloadOption> VisForLoginTypePayloadOption;
        public Action<ScopedFragmentTransformer, LiteralPayloadOption> VisForLiteralPayloadOption;
        public Action<ScopedFragmentTransformer, SessionTimeoutPayloadOption> VisForSessionTimeoutPayloadOption;
        public Action<ScopedFragmentTransformer, SchemaPayloadOption> VisForSchemaPayloadOption;
        public Action<ScopedFragmentTransformer, CharacterSetPayloadOption> VisForCharacterSetPayloadOption;
        public Action<ScopedFragmentTransformer, RolePayloadOption> VisForRolePayloadOption;
        public Action<ScopedFragmentTransformer, AuthenticationPayloadOption> VisForAuthenticationPayloadOption;
        public Action<ScopedFragmentTransformer, EncryptionPayloadOption> VisForEncryptionPayloadOption;
        public Action<ScopedFragmentTransformer, CreateSymmetricKeyStatement> VisForCreateSymmetricKeyStatement;
        public Action<ScopedFragmentTransformer, KeySourceKeyOption> VisForKeySourceKeyOption;
        public Action<ScopedFragmentTransformer, AlgorithmKeyOption> VisForAlgorithmKeyOption;
        public Action<ScopedFragmentTransformer, IdentityValueKeyOption> VisForIdentityValueKeyOption;
        public Action<ScopedFragmentTransformer, ProviderKeyNameKeyOption> VisForProviderKeyNameKeyOption;
        public Action<ScopedFragmentTransformer, CreationDispositionKeyOption> VisForCreationDispositionKeyOption;
        public Action<ScopedFragmentTransformer, AlterSymmetricKeyStatement> VisForAlterSymmetricKeyStatement;
        public Action<ScopedFragmentTransformer, ColumnEncryptionAlgorithmParameter> VisForColumnEncryptionAlgorithmParameter;
        public Action<ScopedFragmentTransformer, IdentityOptions> VisForIdentityOptions;
        public Action<ScopedFragmentTransformer, ColumnStorageOptions> VisForColumnStorageOptions;
        public Action<ScopedFragmentTransformer, CreateTableStatement> VisForCreateTableStatement;
        public Action<ScopedFragmentTransformer, FederationScheme> VisForFederationScheme;
        public Action<ScopedFragmentTransformer, TableDataCompressionOption> VisForTableDataCompressionOption;
        public Action<ScopedFragmentTransformer, TableXmlCompressionOption> VisForTableXmlCompressionOption;
        public Action<ScopedFragmentTransformer, TableDistributionOption> VisForTableDistributionOption;
        public Action<ScopedFragmentTransformer, TableReplicateDistributionPolicy> VisForTableReplicateDistributionPolicy;
        public Action<ScopedFragmentTransformer, TableRoundRobinDistributionPolicy> VisForTableRoundRobinDistributionPolicy;
        public Action<ScopedFragmentTransformer, TableHashDistributionPolicy> VisForTableHashDistributionPolicy;
        public Action<ScopedFragmentTransformer, TableIndexOption> VisForTableIndexOption;
        public Action<ScopedFragmentTransformer, TableClusteredIndexType> VisForTableClusteredIndexType;
        public Action<ScopedFragmentTransformer, TableNonClusteredIndexType> VisForTableNonClusteredIndexType;
        public Action<ScopedFragmentTransformer, TablePartitionOption> VisForTablePartitionOption;
        public Action<ScopedFragmentTransformer, TablePartitionOptionSpecifications> VisForTablePartitionOptionSpecifications;
        public Action<ScopedFragmentTransformer, LocationOption> VisForLocationOption;
        public Action<ScopedFragmentTransformer, RenameEntityStatement> VisForRenameEntityStatement;
        public Action<ScopedFragmentTransformer, CopyStatement> VisForCopyStatement;
        public Action<ScopedFragmentTransformer, CopyOption> VisForCopyOption;
        public Action<ScopedFragmentTransformer, CopyCredentialOption> VisForCopyCredentialOption;
        public Action<ScopedFragmentTransformer, SingleValueTypeCopyOption> VisForSingleValueTypeCopyOption;
        public Action<ScopedFragmentTransformer, ListTypeCopyOption> VisForListTypeCopyOption;
        public Action<ScopedFragmentTransformer, CopyColumnOption> VisForCopyColumnOption;
        public Action<ScopedFragmentTransformer, DataCompressionOption> VisForDataCompressionOption;
        public Action<ScopedFragmentTransformer, XmlCompressionOption> VisForXmlCompressionOption;
        public Action<ScopedFragmentTransformer, CompressionPartitionRange> VisForCompressionPartitionRange;
        public Action<ScopedFragmentTransformer, CheckConstraintDefinition> VisForCheckConstraintDefinition;
        public Action<ScopedFragmentTransformer, DefaultConstraintDefinition> VisForDefaultConstraintDefinition;
        public Action<ScopedFragmentTransformer, ForeignKeyConstraintDefinition> VisForForeignKeyConstraintDefinition;
        public Action<ScopedFragmentTransformer, NullableConstraintDefinition> VisForNullableConstraintDefinition;
        public Action<ScopedFragmentTransformer, GraphConnectionBetweenNodes> VisForGraphConnectionBetweenNodes;
        public Action<ScopedFragmentTransformer, GraphConnectionConstraintDefinition> VisForGraphConnectionConstraintDefinition;
        public Action<ScopedFragmentTransformer, UniqueConstraintDefinition> VisForUniqueConstraintDefinition;
        public Action<ScopedFragmentTransformer, BackupDatabaseStatement> VisForBackupDatabaseStatement;
        public Action<ScopedFragmentTransformer, BackupTransactionLogStatement> VisForBackupTransactionLogStatement;
        public Action<ScopedFragmentTransformer, RestoreStatement> VisForRestoreStatement;
        public Action<ScopedFragmentTransformer, RestoreOption> VisForRestoreOption;
        public Action<ScopedFragmentTransformer, ScalarExpressionRestoreOption> VisForScalarExpressionRestoreOption;
        public Action<ScopedFragmentTransformer, MoveRestoreOption> VisForMoveRestoreOption;
        public Action<ScopedFragmentTransformer, StopRestoreOption> VisForStopRestoreOption;
        public Action<ScopedFragmentTransformer, FileStreamRestoreOption> VisForFileStreamRestoreOption;
        public Action<ScopedFragmentTransformer, BackupOption> VisForBackupOption;
        public Action<ScopedFragmentTransformer, BackupEncryptionOption> VisForBackupEncryptionOption;
        public Action<ScopedFragmentTransformer, DeviceInfo> VisForDeviceInfo;
        public Action<ScopedFragmentTransformer, MirrorToClause> VisForMirrorToClause;
        public Action<ScopedFragmentTransformer, BackupRestoreFileInfo> VisForBackupRestoreFileInfo;
        public Action<ScopedFragmentTransformer, BulkInsertStatement> VisForBulkInsertStatement;
        public Action<ScopedFragmentTransformer, InsertBulkStatement> VisForInsertBulkStatement;
        public Action<ScopedFragmentTransformer, BulkInsertOption> VisForBulkInsertOption;
        public Action<ScopedFragmentTransformer, OpenRowsetCosmosOption> VisForOpenRowsetCosmosOption;
        public Action<ScopedFragmentTransformer, LiteralOpenRowsetCosmosOption> VisForLiteralOpenRowsetCosmosOption;
        public Action<ScopedFragmentTransformer, LiteralBulkInsertOption> VisForLiteralBulkInsertOption;
        public Action<ScopedFragmentTransformer, OrderBulkInsertOption> VisForOrderBulkInsertOption;
        public Action<ScopedFragmentTransformer, ColumnDefinitionBase> VisForColumnDefinitionBase;
        public Action<ScopedFragmentTransformer, ExternalTableColumnDefinition> VisForExternalTableColumnDefinition;
        public Action<ScopedFragmentTransformer, InsertBulkColumnDefinition> VisForInsertBulkColumnDefinition;
        public Action<ScopedFragmentTransformer, DatabaseConfigurationClearOption> VisForDatabaseConfigurationClearOption;
        public Action<ScopedFragmentTransformer, DatabaseConfigurationSetOption> VisForDatabaseConfigurationSetOption;
        public Action<ScopedFragmentTransformer, OnOffPrimaryConfigurationOption> VisForOnOffPrimaryConfigurationOption;
        public Action<ScopedFragmentTransformer, MaxDopConfigurationOption> VisForMaxDopConfigurationOption;
        public Action<ScopedFragmentTransformer, GenericConfigurationOption> VisForGenericConfigurationOption;
        public Action<ScopedFragmentTransformer, AlterDatabaseCollateStatement> VisForAlterDatabaseCollateStatement;
        public Action<ScopedFragmentTransformer, AlterDatabaseRebuildLogStatement> VisForAlterDatabaseRebuildLogStatement;
        public Action<ScopedFragmentTransformer, AlterDatabaseAddFileStatement> VisForAlterDatabaseAddFileStatement;
        public Action<ScopedFragmentTransformer, AlterDatabaseAddFileGroupStatement> VisForAlterDatabaseAddFileGroupStatement;
        public Action<ScopedFragmentTransformer, AlterDatabaseRemoveFileGroupStatement> VisForAlterDatabaseRemoveFileGroupStatement;
        public Action<ScopedFragmentTransformer, AlterDatabaseRemoveFileStatement> VisForAlterDatabaseRemoveFileStatement;
        public Action<ScopedFragmentTransformer, AlterDatabaseModifyNameStatement> VisForAlterDatabaseModifyNameStatement;
        public Action<ScopedFragmentTransformer, AlterDatabaseModifyFileStatement> VisForAlterDatabaseModifyFileStatement;
        public Action<ScopedFragmentTransformer, AlterDatabaseModifyFileGroupStatement> VisForAlterDatabaseModifyFileGroupStatement;
        public Action<ScopedFragmentTransformer, AlterDatabaseTermination> VisForAlterDatabaseTermination;
        public Action<ScopedFragmentTransformer, AlterDatabaseSetStatement> VisForAlterDatabaseSetStatement;
        public Action<ScopedFragmentTransformer, DatabaseOption> VisForDatabaseOption;
        public Action<ScopedFragmentTransformer, OnOffDatabaseOption> VisForOnOffDatabaseOption;
        public Action<ScopedFragmentTransformer, AutoCreateStatisticsDatabaseOption> VisForAutoCreateStatisticsDatabaseOption;
        public Action<ScopedFragmentTransformer, ContainmentDatabaseOption> VisForContainmentDatabaseOption;
        public Action<ScopedFragmentTransformer, HadrDatabaseOption> VisForHadrDatabaseOption;
        public Action<ScopedFragmentTransformer, HadrAvailabilityGroupDatabaseOption> VisForHadrAvailabilityGroupDatabaseOption;
        public Action<ScopedFragmentTransformer, DelayedDurabilityDatabaseOption> VisForDelayedDurabilityDatabaseOption;
        public Action<ScopedFragmentTransformer, CursorDefaultDatabaseOption> VisForCursorDefaultDatabaseOption;
        public Action<ScopedFragmentTransformer, RecoveryDatabaseOption> VisForRecoveryDatabaseOption;
        public Action<ScopedFragmentTransformer, TargetRecoveryTimeDatabaseOption> VisForTargetRecoveryTimeDatabaseOption;
        public Action<ScopedFragmentTransformer, PageVerifyDatabaseOption> VisForPageVerifyDatabaseOption;
        public Action<ScopedFragmentTransformer, PartnerDatabaseOption> VisForPartnerDatabaseOption;
        public Action<ScopedFragmentTransformer, WitnessDatabaseOption> VisForWitnessDatabaseOption;
        public Action<ScopedFragmentTransformer, ParameterizationDatabaseOption> VisForParameterizationDatabaseOption;
        public Action<ScopedFragmentTransformer, LiteralDatabaseOption> VisForLiteralDatabaseOption;
        public Action<ScopedFragmentTransformer, IdentifierDatabaseOption> VisForIdentifierDatabaseOption;
        public Action<ScopedFragmentTransformer, ChangeTrackingDatabaseOption> VisForChangeTrackingDatabaseOption;
        public Action<ScopedFragmentTransformer, AutoCleanupChangeTrackingOptionDetail> VisForAutoCleanupChangeTrackingOptionDetail;
        public Action<ScopedFragmentTransformer, ChangeRetentionChangeTrackingOptionDetail> VisForChangeRetentionChangeTrackingOptionDetail;
        public Action<ScopedFragmentTransformer, AcceleratedDatabaseRecoveryDatabaseOption> VisForAcceleratedDatabaseRecoveryDatabaseOption;
        public Action<ScopedFragmentTransformer, QueryStoreDatabaseOption> VisForQueryStoreDatabaseOption;
        public Action<ScopedFragmentTransformer, QueryStoreDesiredStateOption> VisForQueryStoreDesiredStateOption;
        public Action<ScopedFragmentTransformer, QueryStoreCapturePolicyOption> VisForQueryStoreCapturePolicyOption;
        public Action<ScopedFragmentTransformer, QueryStoreSizeCleanupPolicyOption> VisForQueryStoreSizeCleanupPolicyOption;
        public Action<ScopedFragmentTransformer, QueryStoreDataFlushIntervalOption> VisForQueryStoreDataFlushIntervalOption;
        public Action<ScopedFragmentTransformer, QueryStoreIntervalLengthOption> VisForQueryStoreIntervalLengthOption;
        public Action<ScopedFragmentTransformer, QueryStoreMaxStorageSizeOption> VisForQueryStoreMaxStorageSizeOption;
        public Action<ScopedFragmentTransformer, QueryStoreMaxPlansPerQueryOption> VisForQueryStoreMaxPlansPerQueryOption;
        public Action<ScopedFragmentTransformer, QueryStoreTimeCleanupPolicyOption> VisForQueryStoreTimeCleanupPolicyOption;
        public Action<ScopedFragmentTransformer, AutomaticTuningDatabaseOption> VisForAutomaticTuningDatabaseOption;
        public Action<ScopedFragmentTransformer, AutomaticTuningOption> VisForAutomaticTuningOption;
        public Action<ScopedFragmentTransformer, AutomaticTuningForceLastGoodPlanOption> VisForAutomaticTuningForceLastGoodPlanOption;
        public Action<ScopedFragmentTransformer, AutomaticTuningCreateIndexOption> VisForAutomaticTuningCreateIndexOption;
        public Action<ScopedFragmentTransformer, AutomaticTuningDropIndexOption> VisForAutomaticTuningDropIndexOption;
        public Action<ScopedFragmentTransformer, AutomaticTuningMaintainIndexOption> VisForAutomaticTuningMaintainIndexOption;
        public Action<ScopedFragmentTransformer, FileStreamDatabaseOption> VisForFileStreamDatabaseOption;
        public Action<ScopedFragmentTransformer, CatalogCollationOption> VisForCatalogCollationOption;
        public Action<ScopedFragmentTransformer, LedgerOption> VisForLedgerOption;
        public Action<ScopedFragmentTransformer, MaxSizeDatabaseOption> VisForMaxSizeDatabaseOption;
        public Action<ScopedFragmentTransformer, AlterTableAlterIndexStatement> VisForAlterTableAlterIndexStatement;
        public Action<ScopedFragmentTransformer, AlterTableAlterColumnStatement> VisForAlterTableAlterColumnStatement;
        public Action<ScopedFragmentTransformer, ColumnDefinition> VisForColumnDefinition;
        public Action<ScopedFragmentTransformer, ColumnEncryptionDefinition> VisForColumnEncryptionDefinition;
        public Action<ScopedFragmentTransformer, ColumnEncryptionKeyNameParameter> VisForColumnEncryptionKeyNameParameter;
        public Action<ScopedFragmentTransformer, ColumnEncryptionTypeParameter> VisForColumnEncryptionTypeParameter;
        public Action<ScopedFragmentTransformer, CloseSymmetricKeyStatement> VisForCloseSymmetricKeyStatement;
        public Action<ScopedFragmentTransformer, OpenMasterKeyStatement> VisForOpenMasterKeyStatement;
        public Action<ScopedFragmentTransformer, CloseMasterKeyStatement> VisForCloseMasterKeyStatement;
        public Action<ScopedFragmentTransformer, DeallocateCursorStatement> VisForDeallocateCursorStatement;
        public Action<ScopedFragmentTransformer, FetchType> VisForFetchType;
        public Action<ScopedFragmentTransformer, FetchCursorStatement> VisForFetchCursorStatement;
        public Action<ScopedFragmentTransformer, WhereClause> VisForWhereClause;
        public Action<ScopedFragmentTransformer, DropDatabaseStatement> VisForDropDatabaseStatement;
        public Action<ScopedFragmentTransformer, DropIndexStatement> VisForDropIndexStatement;
        public Action<ScopedFragmentTransformer, BackwardsCompatibleDropIndexClause> VisForBackwardsCompatibleDropIndexClause;
        public Action<ScopedFragmentTransformer, DropIndexClause> VisForDropIndexClause;
        public Action<ScopedFragmentTransformer, MoveToDropIndexOption> VisForMoveToDropIndexOption;
        public Action<ScopedFragmentTransformer, FileStreamOnDropIndexOption> VisForFileStreamOnDropIndexOption;
        public Action<ScopedFragmentTransformer, DropStatisticsStatement> VisForDropStatisticsStatement;
        public Action<ScopedFragmentTransformer, DropTableStatement> VisForDropTableStatement;
        public Action<ScopedFragmentTransformer, DropProcedureStatement> VisForDropProcedureStatement;
        public Action<ScopedFragmentTransformer, DropFunctionStatement> VisForDropFunctionStatement;
        public Action<ScopedFragmentTransformer, DropViewStatement> VisForDropViewStatement;
        public Action<ScopedFragmentTransformer, DropDefaultStatement> VisForDropDefaultStatement;
        public Action<ScopedFragmentTransformer, DropRuleStatement> VisForDropRuleStatement;
        public Action<ScopedFragmentTransformer, DropTriggerStatement> VisForDropTriggerStatement;
        public Action<ScopedFragmentTransformer, DropSchemaStatement> VisForDropSchemaStatement;
        public Action<ScopedFragmentTransformer, RaiseErrorLegacyStatement> VisForRaiseErrorLegacyStatement;
        public Action<ScopedFragmentTransformer, RaiseErrorStatement> VisForRaiseErrorStatement;
        public Action<ScopedFragmentTransformer, ThrowStatement> VisForThrowStatement;
        public Action<ScopedFragmentTransformer, UseStatement> VisForUseStatement;
        public Action<ScopedFragmentTransformer, KillStatement> VisForKillStatement;
        public Action<ScopedFragmentTransformer, KillQueryNotificationSubscriptionStatement> VisForKillQueryNotificationSubscriptionStatement;
        public Action<ScopedFragmentTransformer, KillStatsJobStatement> VisForKillStatsJobStatement;
        public Action<ScopedFragmentTransformer, CheckpointStatement> VisForCheckpointStatement;
        public Action<ScopedFragmentTransformer, ReconfigureStatement> VisForReconfigureStatement;
        public Action<ScopedFragmentTransformer, ShutdownStatement> VisForShutdownStatement;
        public Action<ScopedFragmentTransformer, SetUserStatement> VisForSetUserStatement;
        public Action<ScopedFragmentTransformer, TruncateTableStatement> VisForTruncateTableStatement;
        public Action<ScopedFragmentTransformer, PredicateSetStatement> VisForPredicateSetStatement;
        public Action<ScopedFragmentTransformer, SetStatisticsStatement> VisForSetStatisticsStatement;
        public Action<ScopedFragmentTransformer, SetRowCountStatement> VisForSetRowCountStatement;
        public Action<ScopedFragmentTransformer, SetOffsetsStatement> VisForSetOffsetsStatement;
        public Action<ScopedFragmentTransformer, GeneralSetCommand> VisForGeneralSetCommand;
        public Action<ScopedFragmentTransformer, SetFipsFlaggerCommand> VisForSetFipsFlaggerCommand;
        public Action<ScopedFragmentTransformer, SetCommandStatement> VisForSetCommandStatement;
        public Action<ScopedFragmentTransformer, SetTransactionIsolationLevelStatement> VisForSetTransactionIsolationLevelStatement;
        public Action<ScopedFragmentTransformer, SetTextSizeStatement> VisForSetTextSizeStatement;
        public Action<ScopedFragmentTransformer, SetIdentityInsertStatement> VisForSetIdentityInsertStatement;
        public Action<ScopedFragmentTransformer, SetErrorLevelStatement> VisForSetErrorLevelStatement;
        public Action<ScopedFragmentTransformer, CreateDatabaseStatement> VisForCreateDatabaseStatement;
        public Action<ScopedFragmentTransformer, FileDeclaration> VisForFileDeclaration;
        public Action<ScopedFragmentTransformer, FileDeclarationOption> VisForFileDeclarationOption;
        public Action<ScopedFragmentTransformer, NameFileDeclarationOption> VisForNameFileDeclarationOption;
        public Action<ScopedFragmentTransformer, FileNameFileDeclarationOption> VisForFileNameFileDeclarationOption;
        public Action<ScopedFragmentTransformer, SizeFileDeclarationOption> VisForSizeFileDeclarationOption;
        public Action<ScopedFragmentTransformer, MaxSizeFileDeclarationOption> VisForMaxSizeFileDeclarationOption;
        public Action<ScopedFragmentTransformer, FileGrowthFileDeclarationOption> VisForFileGrowthFileDeclarationOption;
        public Action<ScopedFragmentTransformer, FileGroupDefinition> VisForFileGroupDefinition;
        public Action<ScopedFragmentTransformer, AlterDatabaseScopedConfigurationSetStatement> VisForAlterDatabaseScopedConfigurationSetStatement;
        public Action<ScopedFragmentTransformer, AlterDatabaseScopedConfigurationClearStatement> VisForAlterDatabaseScopedConfigurationClearStatement;
        public Action<ScopedFragmentTransformer, CreateIndexStatement> VisForCreateIndexStatement;
        public Action<ScopedFragmentTransformer, IndexStateOption> VisForIndexStateOption;
        public Action<ScopedFragmentTransformer, IndexExpressionOption> VisForIndexExpressionOption;
        public Action<ScopedFragmentTransformer, MaxDurationOption> VisForMaxDurationOption;
        public Action<ScopedFragmentTransformer, WaitAtLowPriorityOption> VisForWaitAtLowPriorityOption;
        public Action<ScopedFragmentTransformer, OnlineIndexOption> VisForOnlineIndexOption;
        public Action<ScopedFragmentTransformer, IgnoreDupKeyIndexOption> VisForIgnoreDupKeyIndexOption;
        public Action<ScopedFragmentTransformer, OrderIndexOption> VisForOrderIndexOption;
        public Action<ScopedFragmentTransformer, OnlineIndexLowPriorityLockWaitOption> VisForOnlineIndexLowPriorityLockWaitOption;
        public Action<ScopedFragmentTransformer, LowPriorityLockWaitMaxDurationOption> VisForLowPriorityLockWaitMaxDurationOption;
        public Action<ScopedFragmentTransformer, LowPriorityLockWaitAbortAfterWaitOption> VisForLowPriorityLockWaitAbortAfterWaitOption;
        public Action<ScopedFragmentTransformer, FullTextIndexColumn> VisForFullTextIndexColumn;
        public Action<ScopedFragmentTransformer, CreateFullTextIndexStatement> VisForCreateFullTextIndexStatement;
        public Action<ScopedFragmentTransformer, ChangeTrackingFullTextIndexOption> VisForChangeTrackingFullTextIndexOption;
        public Action<ScopedFragmentTransformer, StopListFullTextIndexOption> VisForStopListFullTextIndexOption;
        public Action<ScopedFragmentTransformer, SearchPropertyListFullTextIndexOption> VisForSearchPropertyListFullTextIndexOption;
        public Action<ScopedFragmentTransformer, FullTextCatalogAndFileGroup> VisForFullTextCatalogAndFileGroup;
        public Action<ScopedFragmentTransformer, EventTypeContainer> VisForEventTypeContainer;
        public Action<ScopedFragmentTransformer, EventGroupContainer> VisForEventGroupContainer;
        public Action<ScopedFragmentTransformer, CreateEventNotificationStatement> VisForCreateEventNotificationStatement;
        public Action<ScopedFragmentTransformer, EventNotificationObjectScope> VisForEventNotificationObjectScope;
        public Action<ScopedFragmentTransformer, CreateMasterKeyStatement> VisForCreateMasterKeyStatement;
        public Action<ScopedFragmentTransformer, AlterMasterKeyStatement> VisForAlterMasterKeyStatement;
        public Action<ScopedFragmentTransformer, ApplicationRoleOption> VisForApplicationRoleOption;
        public Action<ScopedFragmentTransformer, CreateApplicationRoleStatement> VisForCreateApplicationRoleStatement;
        public Action<ScopedFragmentTransformer, AlterApplicationRoleStatement> VisForAlterApplicationRoleStatement;
        public Action<ScopedFragmentTransformer, CreateRoleStatement> VisForCreateRoleStatement;
        public Action<ScopedFragmentTransformer, AlterRoleStatement> VisForAlterRoleStatement;
        public Action<ScopedFragmentTransformer, RenameAlterRoleAction> VisForRenameAlterRoleAction;
        public Action<ScopedFragmentTransformer, AddMemberAlterRoleAction> VisForAddMemberAlterRoleAction;
        public Action<ScopedFragmentTransformer, DropMemberAlterRoleAction> VisForDropMemberAlterRoleAction;
        public Action<ScopedFragmentTransformer, CreateServerRoleStatement> VisForCreateServerRoleStatement;
        public Action<ScopedFragmentTransformer, AlterServerRoleStatement> VisForAlterServerRoleStatement;
        public Action<ScopedFragmentTransformer, DropServerRoleStatement> VisForDropServerRoleStatement;
        public Action<ScopedFragmentTransformer, UserLoginOption> VisForUserLoginOption;
        public Action<ScopedFragmentTransformer, CreateUserStatement> VisForCreateUserStatement;
        public Action<ScopedFragmentTransformer, AlterUserStatement> VisForAlterUserStatement;
        public Action<ScopedFragmentTransformer, StatisticsOption> VisForStatisticsOption;
        public Action<ScopedFragmentTransformer, ResampleStatisticsOption> VisForResampleStatisticsOption;
        public Action<ScopedFragmentTransformer, StatisticsPartitionRange> VisForStatisticsPartitionRange;
        public Action<ScopedFragmentTransformer, OnOffStatisticsOption> VisForOnOffStatisticsOption;
        public Action<ScopedFragmentTransformer, LiteralStatisticsOption> VisForLiteralStatisticsOption;
        public Action<ScopedFragmentTransformer, CreateStatisticsStatement> VisForCreateStatisticsStatement;
        public Action<ScopedFragmentTransformer, UpdateStatisticsStatement> VisForUpdateStatisticsStatement;
        public Action<ScopedFragmentTransformer, ReturnStatement> VisForReturnStatement;
        public Action<ScopedFragmentTransformer, DeclareCursorStatement> VisForDeclareCursorStatement;
        public Action<ScopedFragmentTransformer, CursorDefinition> VisForCursorDefinition;
        public Action<ScopedFragmentTransformer, CursorOption> VisForCursorOption;
        public Action<ScopedFragmentTransformer, SetVariableStatement> VisForSetVariableStatement;
        public Action<ScopedFragmentTransformer, CursorId> VisForCursorId;
        public Action<ScopedFragmentTransformer, OpenCursorStatement> VisForOpenCursorStatement;
        public Action<ScopedFragmentTransformer, CloseCursorStatement> VisForCloseCursorStatement;
        public Action<ScopedFragmentTransformer, CryptoMechanism> VisForCryptoMechanism;
        public Action<ScopedFragmentTransformer, OpenSymmetricKeyStatement> VisForOpenSymmetricKeyStatement;
        public Action<ScopedFragmentTransformer, AlterTableFileTableNamespaceStatement> VisForAlterTableFileTableNamespaceStatement;
        public Action<ScopedFragmentTransformer, AlterTableSetStatement> VisForAlterTableSetStatement;
        public Action<ScopedFragmentTransformer, LockEscalationTableOption> VisForLockEscalationTableOption;
        public Action<ScopedFragmentTransformer, FileStreamOnTableOption> VisForFileStreamOnTableOption;
        public Action<ScopedFragmentTransformer, FileTableDirectoryTableOption> VisForFileTableDirectoryTableOption;
        public Action<ScopedFragmentTransformer, FileTableCollateFileNameTableOption> VisForFileTableCollateFileNameTableOption;
        public Action<ScopedFragmentTransformer, FileTableConstraintNameTableOption> VisForFileTableConstraintNameTableOption;
        public Action<ScopedFragmentTransformer, MemoryOptimizedTableOption> VisForMemoryOptimizedTableOption;
        public Action<ScopedFragmentTransformer, DurabilityTableOption> VisForDurabilityTableOption;
        public Action<ScopedFragmentTransformer, RemoteDataArchiveTableOption> VisForRemoteDataArchiveTableOption;
        public Action<ScopedFragmentTransformer, RemoteDataArchiveAlterTableOption> VisForRemoteDataArchiveAlterTableOption;
        public Action<ScopedFragmentTransformer, RemoteDataArchiveDatabaseOption> VisForRemoteDataArchiveDatabaseOption;
        public Action<ScopedFragmentTransformer, RemoteDataArchiveDbServerSetting> VisForRemoteDataArchiveDbServerSetting;
        public Action<ScopedFragmentTransformer, RemoteDataArchiveDbCredentialSetting> VisForRemoteDataArchiveDbCredentialSetting;
        public Action<ScopedFragmentTransformer, RemoteDataArchiveDbFederatedServiceAccountSetting> VisForRemoteDataArchiveDbFederatedServiceAccountSetting;
        public Action<ScopedFragmentTransformer, RetentionPeriodDefinition> VisForRetentionPeriodDefinition;
        public Action<ScopedFragmentTransformer, SystemVersioningTableOption> VisForSystemVersioningTableOption;
        public Action<ScopedFragmentTransformer, LedgerTableOption> VisForLedgerTableOption;
        public Action<ScopedFragmentTransformer, LedgerViewOption> VisForLedgerViewOption;
        public Action<ScopedFragmentTransformer, DataRetentionTableOption> VisForDataRetentionTableOption;
        public Action<ScopedFragmentTransformer, AlterTableAddTableElementStatement> VisForAlterTableAddTableElementStatement;
        public Action<ScopedFragmentTransformer, AlterTableConstraintModificationStatement> VisForAlterTableConstraintModificationStatement;
        public Action<ScopedFragmentTransformer, AlterTableSwitchStatement> VisForAlterTableSwitchStatement;
        public Action<ScopedFragmentTransformer, LowPriorityLockWaitTableSwitchOption> VisForLowPriorityLockWaitTableSwitchOption;
        public Action<ScopedFragmentTransformer, TruncateTargetTableSwitchOption> VisForTruncateTargetTableSwitchOption;
        public Action<ScopedFragmentTransformer, DropClusteredConstraintStateOption> VisForDropClusteredConstraintStateOption;
        public Action<ScopedFragmentTransformer, DropClusteredConstraintValueOption> VisForDropClusteredConstraintValueOption;
        public Action<ScopedFragmentTransformer, DropClusteredConstraintMoveOption> VisForDropClusteredConstraintMoveOption;
        public Action<ScopedFragmentTransformer, DropClusteredConstraintWaitAtLowPriorityLockOption> VisForDropClusteredConstraintWaitAtLowPriorityLockOption;
        public Action<ScopedFragmentTransformer, AlterTableDropTableElement> VisForAlterTableDropTableElement;
        public Action<ScopedFragmentTransformer, AlterTableDropTableElementStatement> VisForAlterTableDropTableElementStatement;
        public Action<ScopedFragmentTransformer, AlterTableTriggerModificationStatement> VisForAlterTableTriggerModificationStatement;
        public Action<ScopedFragmentTransformer, EnableDisableTriggerStatement> VisForEnableDisableTriggerStatement;
        public Action<ScopedFragmentTransformer, TryCatchStatement> VisForTryCatchStatement;
        public Action<ScopedFragmentTransformer, CreateTypeUdtStatement> VisForCreateTypeUdtStatement;
        public Action<ScopedFragmentTransformer, CreateTypeUddtStatement> VisForCreateTypeUddtStatement;
        public Action<ScopedFragmentTransformer, CreateSynonymStatement> VisForCreateSynonymStatement;
        public Action<ScopedFragmentTransformer, ExecuteAsClause> VisForExecuteAsClause;
        public Action<ScopedFragmentTransformer, QueueOption> VisForQueueOption;
        public Action<ScopedFragmentTransformer, QueueStateOption> VisForQueueStateOption;
        public Action<ScopedFragmentTransformer, QueueProcedureOption> VisForQueueProcedureOption;
        public Action<ScopedFragmentTransformer, QueueValueOption> VisForQueueValueOption;
        public Action<ScopedFragmentTransformer, QueueExecuteAsOption> VisForQueueExecuteAsOption;
        public Action<ScopedFragmentTransformer, RouteOption> VisForRouteOption;
        public Action<ScopedFragmentTransformer, AlterRouteStatement> VisForAlterRouteStatement;
        public Action<ScopedFragmentTransformer, CreateRouteStatement> VisForCreateRouteStatement;
        public Action<ScopedFragmentTransformer, AlterQueueStatement> VisForAlterQueueStatement;
        public Action<ScopedFragmentTransformer, CreateQueueStatement> VisForCreateQueueStatement;
        public Action<ScopedFragmentTransformer, IndexDefinition> VisForIndexDefinition;
        public Action<ScopedFragmentTransformer, SystemTimePeriodDefinition> VisForSystemTimePeriodDefinition;
        public Action<ScopedFragmentTransformer, IndexType> VisForIndexType;
        public Action<ScopedFragmentTransformer, PartitionSpecifier> VisForPartitionSpecifier;
        public Action<ScopedFragmentTransformer, AlterIndexStatement> VisForAlterIndexStatement;
        public Action<ScopedFragmentTransformer, CreateXmlIndexStatement> VisForCreateXmlIndexStatement;
        public Action<ScopedFragmentTransformer, CreateSelectiveXmlIndexStatement> VisForCreateSelectiveXmlIndexStatement;
        public Action<ScopedFragmentTransformer, FileGroupOrPartitionScheme> VisForFileGroupOrPartitionScheme;
        public Action<ScopedFragmentTransformer, AlterSecurityPolicyStatement> VisForAlterSecurityPolicyStatement;
        public Action<ScopedFragmentTransformer, DropSecurityPolicyStatement> VisForDropSecurityPolicyStatement;
        public Action<ScopedFragmentTransformer, CreateColumnMasterKeyStatement> VisForCreateColumnMasterKeyStatement;
        public Action<ScopedFragmentTransformer, ColumnMasterKeyStoreProviderNameParameter> VisForColumnMasterKeyStoreProviderNameParameter;
        public Action<ScopedFragmentTransformer, ColumnMasterKeyPathParameter> VisForColumnMasterKeyPathParameter;
        public Action<ScopedFragmentTransformer, ColumnMasterKeyEnclaveComputationsParameter> VisForColumnMasterKeyEnclaveComputationsParameter;
        public Action<ScopedFragmentTransformer, DropColumnMasterKeyStatement> VisForDropColumnMasterKeyStatement;
        public Action<ScopedFragmentTransformer, CreateColumnEncryptionKeyStatement> VisForCreateColumnEncryptionKeyStatement;
        public Action<ScopedFragmentTransformer, AlterColumnEncryptionKeyStatement> VisForAlterColumnEncryptionKeyStatement;
        public Action<ScopedFragmentTransformer, DropColumnEncryptionKeyStatement> VisForDropColumnEncryptionKeyStatement;
        public Action<ScopedFragmentTransformer, ColumnEncryptionKeyValue> VisForColumnEncryptionKeyValue;
        public Action<ScopedFragmentTransformer, ColumnMasterKeyNameParameter> VisForColumnMasterKeyNameParameter;
        public Action<ScopedFragmentTransformer, ColumnEncryptionAlgorithmNameParameter> VisForColumnEncryptionAlgorithmNameParameter;
        public Action<ScopedFragmentTransformer, EncryptedValueParameter> VisForEncryptedValueParameter;
        public Action<ScopedFragmentTransformer, ExternalTableLiteralOrIdentifierOption> VisForExternalTableLiteralOrIdentifierOption;
        public Action<ScopedFragmentTransformer, ExternalTableDistributionOption> VisForExternalTableDistributionOption;
        public Action<ScopedFragmentTransformer, ExternalTableRejectTypeOption> VisForExternalTableRejectTypeOption;
        public Action<ScopedFragmentTransformer, ExternalTableReplicatedDistributionPolicy> VisForExternalTableReplicatedDistributionPolicy;
        public Action<ScopedFragmentTransformer, ExternalTableRoundRobinDistributionPolicy> VisForExternalTableRoundRobinDistributionPolicy;
        public Action<ScopedFragmentTransformer, ExternalTableShardedDistributionPolicy> VisForExternalTableShardedDistributionPolicy;
        public Action<ScopedFragmentTransformer, CreateExternalTableStatement> VisForCreateExternalTableStatement;
        public Action<ScopedFragmentTransformer, DropExternalTableStatement> VisForDropExternalTableStatement;
        public Action<ScopedFragmentTransformer, ExternalDataSourceLiteralOrIdentifierOption> VisForExternalDataSourceLiteralOrIdentifierOption;
        public Action<ScopedFragmentTransformer, CreateExternalDataSourceStatement> VisForCreateExternalDataSourceStatement;
        public Action<ScopedFragmentTransformer, AlterExternalDataSourceStatement> VisForAlterExternalDataSourceStatement;
        public Action<ScopedFragmentTransformer, DropExternalDataSourceStatement> VisForDropExternalDataSourceStatement;
        public Action<ScopedFragmentTransformer, ExternalStreamLiteralOrIdentifierOption> VisForExternalStreamLiteralOrIdentifierOption;
        public Action<ScopedFragmentTransformer, CreateExternalStreamStatement> VisForCreateExternalStreamStatement;
        public Action<ScopedFragmentTransformer, DropExternalStreamStatement> VisForDropExternalStreamStatement;
        public Action<ScopedFragmentTransformer, ExternalFileFormatLiteralOption> VisForExternalFileFormatLiteralOption;
        public Action<ScopedFragmentTransformer, ExternalFileFormatUseDefaultTypeOption> VisForExternalFileFormatUseDefaultTypeOption;
        public Action<ScopedFragmentTransformer, ExternalFileFormatContainerOption> VisForExternalFileFormatContainerOption;
        public Action<ScopedFragmentTransformer, CreateExternalFileFormatStatement> VisForCreateExternalFileFormatStatement;
        public Action<ScopedFragmentTransformer, DropExternalFileFormatStatement> VisForDropExternalFileFormatStatement;
        public Action<ScopedFragmentTransformer, CreateExternalStreamingJobStatement> VisForCreateExternalStreamingJobStatement;
        public Action<ScopedFragmentTransformer, DropExternalStreamingJobStatement> VisForDropExternalStreamingJobStatement;
        public Action<ScopedFragmentTransformer, CreateAssemblyStatement> VisForCreateAssemblyStatement;
        public Action<ScopedFragmentTransformer, AlterAssemblyStatement> VisForAlterAssemblyStatement;
        public Action<ScopedFragmentTransformer, AssemblyOption> VisForAssemblyOption;
        public Action<ScopedFragmentTransformer, OnOffAssemblyOption> VisForOnOffAssemblyOption;
        public Action<ScopedFragmentTransformer, PermissionSetAssemblyOption> VisForPermissionSetAssemblyOption;
        public Action<ScopedFragmentTransformer, AddFileSpec> VisForAddFileSpec;
        public Action<ScopedFragmentTransformer, CreateXmlSchemaCollectionStatement> VisForCreateXmlSchemaCollectionStatement;
        public Action<ScopedFragmentTransformer, AlterXmlSchemaCollectionStatement> VisForAlterXmlSchemaCollectionStatement;
        public Action<ScopedFragmentTransformer, DropXmlSchemaCollectionStatement> VisForDropXmlSchemaCollectionStatement;
        public Action<ScopedFragmentTransformer, AssemblyName> VisForAssemblyName;
        public Action<ScopedFragmentTransformer, AlterTableAlterPartitionStatement> VisForAlterTableAlterPartitionStatement;
        public Action<ScopedFragmentTransformer, AlterTableRebuildStatement> VisForAlterTableRebuildStatement;
        public Action<ScopedFragmentTransformer, AlterTableChangeTrackingModificationStatement> VisForAlterTableChangeTrackingModificationStatement;
        public Action<ScopedFragmentTransformer, RevokeStatement> VisForRevokeStatement;
        public Action<ScopedFragmentTransformer, AlterAuthorizationStatement> VisForAlterAuthorizationStatement;
        public Action<ScopedFragmentTransformer, Permission> VisForPermission;
        public Action<ScopedFragmentTransformer, SecurityTargetObject> VisForSecurityTargetObject;
        public Action<ScopedFragmentTransformer, SecurityTargetObjectName> VisForSecurityTargetObjectName;
        public Action<ScopedFragmentTransformer, SecurityPrincipal> VisForSecurityPrincipal;
        public Action<ScopedFragmentTransformer, GrantStatement80> VisForGrantStatement80;
        public Action<ScopedFragmentTransformer, DenyStatement80> VisForDenyStatement80;
        public Action<ScopedFragmentTransformer, RevokeStatement80> VisForRevokeStatement80;
        public Action<ScopedFragmentTransformer, CommandSecurityElement80> VisForCommandSecurityElement80;
        public Action<ScopedFragmentTransformer, PrivilegeSecurityElement80> VisForPrivilegeSecurityElement80;
        public Action<ScopedFragmentTransformer, Privilege80> VisForPrivilege80;
        public Action<ScopedFragmentTransformer, SecurityUserClause80> VisForSecurityUserClause80;
        public Action<ScopedFragmentTransformer, SqlCommandIdentifier> VisForSqlCommandIdentifier;
        public Action<ScopedFragmentTransformer, AssignmentSetClause> VisForAssignmentSetClause;
        public Action<ScopedFragmentTransformer, FunctionCallSetClause> VisForFunctionCallSetClause;
        public Action<ScopedFragmentTransformer, ValuesInsertSource> VisForValuesInsertSource;
        public Action<ScopedFragmentTransformer, SelectInsertSource> VisForSelectInsertSource;
        public Action<ScopedFragmentTransformer, ExecuteInsertSource> VisForExecuteInsertSource;
        public Action<ScopedFragmentTransformer, RowValue> VisForRowValue;
        public Action<ScopedFragmentTransformer, PrintStatement> VisForPrintStatement;
        public Action<ScopedFragmentTransformer, UpdateCall> VisForUpdateCall;
        public Action<ScopedFragmentTransformer, TSEqualCall> VisForTSEqualCall;
        public Action<ScopedFragmentTransformer, IntegerLiteral> VisForIntegerLiteral;
        public Action<ScopedFragmentTransformer, NumericLiteral> VisForNumericLiteral;
        public Action<ScopedFragmentTransformer, RealLiteral> VisForRealLiteral;
        public Action<ScopedFragmentTransformer, MoneyLiteral> VisForMoneyLiteral;
        public Action<ScopedFragmentTransformer, BinaryLiteral> VisForBinaryLiteral;
        public Action<ScopedFragmentTransformer, StringLiteral> VisForStringLiteral;
        public Action<ScopedFragmentTransformer, NullLiteral> VisForNullLiteral;
        public Action<ScopedFragmentTransformer, IdentifierLiteral> VisForIdentifierLiteral;
        public Action<ScopedFragmentTransformer, DefaultLiteral> VisForDefaultLiteral;
        public Action<ScopedFragmentTransformer, MaxLiteral> VisForMaxLiteral;
        public Action<ScopedFragmentTransformer, OdbcLiteral> VisForOdbcLiteral;
        public Action<ScopedFragmentTransformer, LiteralRange> VisForLiteralRange;
        public Action<ScopedFragmentTransformer, VariableReference> VisForVariableReference;
        public Action<ScopedFragmentTransformer, OnOffOptionValue> VisForOnOffOptionValue;
        public Action<ScopedFragmentTransformer, LiteralOptionValue> VisForLiteralOptionValue;
        public Action<ScopedFragmentTransformer, GlobalVariableExpression> VisForGlobalVariableExpression;
        public Action<ScopedFragmentTransformer, IdentifierOrValueExpression> VisForIdentifierOrValueExpression;
        public Action<ScopedFragmentTransformer, IdentifierOrScalarExpression> VisForIdentifierOrScalarExpression;
        public Action<ScopedFragmentTransformer, SchemaObjectNameOrValueExpression> VisForSchemaObjectNameOrValueExpression;
        public Action<ScopedFragmentTransformer, ParenthesisExpression> VisForParenthesisExpression;
        public Action<ScopedFragmentTransformer, ColumnReferenceExpression> VisForColumnReferenceExpression;
        public Action<ScopedFragmentTransformer, NextValueForExpression> VisForNextValueForExpression;
        public Action<ScopedFragmentTransformer, SequenceOption> VisForSequenceOption;
        public Action<ScopedFragmentTransformer, DataTypeSequenceOption> VisForDataTypeSequenceOption;
        public Action<ScopedFragmentTransformer, ScalarExpressionSequenceOption> VisForScalarExpressionSequenceOption;
        public Action<ScopedFragmentTransformer, CreateSequenceStatement> VisForCreateSequenceStatement;
        public Action<ScopedFragmentTransformer, AlterSequenceStatement> VisForAlterSequenceStatement;
        public Action<ScopedFragmentTransformer, DropSequenceStatement> VisForDropSequenceStatement;
        public Action<ScopedFragmentTransformer, SecurityPredicateAction> VisForSecurityPredicateAction;
        public Action<ScopedFragmentTransformer, SecurityPolicyOption> VisForSecurityPolicyOption;
        public Action<ScopedFragmentTransformer, CreateSecurityPolicyStatement> VisForCreateSecurityPolicyStatement;
        public Action<ScopedFragmentTransformer, TryCastCall> VisForTryCastCall;
        public Action<ScopedFragmentTransformer, AtTimeZoneCall> VisForAtTimeZoneCall;
        public Action<ScopedFragmentTransformer, FunctionCall> VisForFunctionCall;
        public Action<ScopedFragmentTransformer, ExpressionCallTarget> VisForExpressionCallTarget;
        public Action<ScopedFragmentTransformer, MultiPartIdentifierCallTarget> VisForMultiPartIdentifierCallTarget;
        public Action<ScopedFragmentTransformer, UserDefinedTypeCallTarget> VisForUserDefinedTypeCallTarget;
        public Action<ScopedFragmentTransformer, LeftFunctionCall> VisForLeftFunctionCall;
        public Action<ScopedFragmentTransformer, RightFunctionCall> VisForRightFunctionCall;
        public Action<ScopedFragmentTransformer, PartitionFunctionCall> VisForPartitionFunctionCall;
        public Action<ScopedFragmentTransformer, OverClause> VisForOverClause;
        public Action<ScopedFragmentTransformer, WindowClause> VisForWindowClause;
        public Action<ScopedFragmentTransformer, WindowDefinition> VisForWindowDefinition;
        public Action<ScopedFragmentTransformer, ParameterlessCall> VisForParameterlessCall;
        public Action<ScopedFragmentTransformer, ScalarSubquery> VisForScalarSubquery;
        public Action<ScopedFragmentTransformer, OdbcFunctionCall> VisForOdbcFunctionCall;
        public Action<ScopedFragmentTransformer, ExtractFromExpression> VisForExtractFromExpression;
        public Action<ScopedFragmentTransformer, OdbcConvertSpecification> VisForOdbcConvertSpecification;
        public Action<ScopedFragmentTransformer, AlterFunctionStatement> VisForAlterFunctionStatement;
        public Action<ScopedFragmentTransformer, BeginEndBlockStatement> VisForBeginEndBlockStatement;
        public Action<ScopedFragmentTransformer, BeginEndAtomicBlockStatement> VisForBeginEndAtomicBlockStatement;
        public Action<ScopedFragmentTransformer, LiteralAtomicBlockOption> VisForLiteralAtomicBlockOption;
        public Action<ScopedFragmentTransformer, IdentifierAtomicBlockOption> VisForIdentifierAtomicBlockOption;
        public Action<ScopedFragmentTransformer, OnOffAtomicBlockOption> VisForOnOffAtomicBlockOption;
        public Action<ScopedFragmentTransformer, BeginTransactionStatement> VisForBeginTransactionStatement;
        public Action<ScopedFragmentTransformer, BreakStatement> VisForBreakStatement;
        public Action<ScopedFragmentTransformer, ColumnWithSortOrder> VisForColumnWithSortOrder;
        public Action<ScopedFragmentTransformer, CommitTransactionStatement> VisForCommitTransactionStatement;
        public Action<ScopedFragmentTransformer, RollbackTransactionStatement> VisForRollbackTransactionStatement;
        public Action<ScopedFragmentTransformer, SaveTransactionStatement> VisForSaveTransactionStatement;
        public Action<ScopedFragmentTransformer, ContinueStatement> VisForContinueStatement;
        public Action<ScopedFragmentTransformer, CreateDefaultStatement> VisForCreateDefaultStatement;
        public Action<ScopedFragmentTransformer, CreateFunctionStatement> VisForCreateFunctionStatement;
        public Action<ScopedFragmentTransformer, CreateOrAlterFunctionStatement> VisForCreateOrAlterFunctionStatement;
        public Action<ScopedFragmentTransformer, CreateRuleStatement> VisForCreateRuleStatement;
        public Action<ScopedFragmentTransformer, DeclareVariableElement> VisForDeclareVariableElement;
        public Action<ScopedFragmentTransformer, DeclareVariableStatement> VisForDeclareVariableStatement;
        public Action<ScopedFragmentTransformer, GoToStatement> VisForGoToStatement;
        public Action<ScopedFragmentTransformer, IfStatement> VisForIfStatement;
        public Action<ScopedFragmentTransformer, LabelStatement> VisForLabelStatement;
        public Action<ScopedFragmentTransformer, MultiPartIdentifier> VisForMultiPartIdentifier;
        public Action<ScopedFragmentTransformer, SchemaObjectName> VisForSchemaObjectName;
        public Action<ScopedFragmentTransformer, ChildObjectName> VisForChildObjectName;
        public Action<ScopedFragmentTransformer, ProcedureParameter> VisForProcedureParameter;
        public Action<ScopedFragmentTransformer, WhileStatement> VisForWhileStatement;
        public Action<ScopedFragmentTransformer, DeleteStatement> VisForDeleteStatement;
        public Action<ScopedFragmentTransformer, DeleteSpecification> VisForDeleteSpecification;
        public Action<ScopedFragmentTransformer, InsertStatement> VisForInsertStatement;
        public Action<ScopedFragmentTransformer, InsertSpecification> VisForInsertSpecification;
        public Action<ScopedFragmentTransformer, UpdateStatement> VisForUpdateStatement;
        public Action<ScopedFragmentTransformer, UpdateSpecification> VisForUpdateSpecification;
        public Action<ScopedFragmentTransformer, CreateSchemaStatement> VisForCreateSchemaStatement;
        public Action<ScopedFragmentTransformer, WaitForStatement> VisForWaitForStatement;
        public Action<ScopedFragmentTransformer, ReadTextStatement> VisForReadTextStatement;
        public Action<ScopedFragmentTransformer, UpdateTextStatement> VisForUpdateTextStatement;
        public Action<ScopedFragmentTransformer, WriteTextStatement> VisForWriteTextStatement;
        public Action<ScopedFragmentTransformer, LineNoStatement> VisForLineNoStatement;
        public Action<ScopedFragmentTransformer, GrantStatement> VisForGrantStatement;
        public Action<ScopedFragmentTransformer, DenyStatement> VisForDenyStatement;
        public Action<ScopedFragmentTransformer, ScalarFunctionReturnType> VisForScalarFunctionReturnType;
        public Action<ScopedFragmentTransformer, SelectFunctionReturnType> VisForSelectFunctionReturnType;
        public Action<ScopedFragmentTransformer, TableDefinition> VisForTableDefinition;
        public Action<ScopedFragmentTransformer, DeclareTableVariableBody> VisForDeclareTableVariableBody;
        public Action<ScopedFragmentTransformer, DeclareTableVariableStatement> VisForDeclareTableVariableStatement;
        public Action<ScopedFragmentTransformer, NamedTableReference> VisForNamedTableReference;
        public Action<ScopedFragmentTransformer, SchemaObjectFunctionTableReference> VisForSchemaObjectFunctionTableReference;
        public Action<ScopedFragmentTransformer, TableHint> VisForTableHint;
        public Action<ScopedFragmentTransformer, IndexTableHint> VisForIndexTableHint;
        public Action<ScopedFragmentTransformer, LiteralTableHint> VisForLiteralTableHint;
        public Action<ScopedFragmentTransformer, QueryDerivedTable> VisForQueryDerivedTable;
        public Action<ScopedFragmentTransformer, InlineDerivedTable> VisForInlineDerivedTable;
        public Action<ScopedFragmentTransformer, SubqueryComparisonPredicate> VisForSubqueryComparisonPredicate;
        public Action<ScopedFragmentTransformer, ExistsPredicate> VisForExistsPredicate;
        public Action<ScopedFragmentTransformer, LikePredicate> VisForLikePredicate;
        public Action<ScopedFragmentTransformer, DistinctPredicate> VisForDistinctPredicate;
        public Action<ScopedFragmentTransformer, InPredicate> VisForInPredicate;
        public Action<ScopedFragmentTransformer, FullTextPredicate> VisForFullTextPredicate;
        public Action<ScopedFragmentTransformer, UserDefinedTypePropertyAccess> VisForUserDefinedTypePropertyAccess;
        public Action<ScopedFragmentTransformer, SelectStatement> VisForSelectStatement;
        public Action<ScopedFragmentTransformer, BrowseForClause> VisForBrowseForClause;
        public Action<ScopedFragmentTransformer, ReadOnlyForClause> VisForReadOnlyForClause;
        public Action<ScopedFragmentTransformer, XmlForClause> VisForXmlForClause;
        public Action<ScopedFragmentTransformer, XmlForClauseOption> VisForXmlForClauseOption;
        public Action<ScopedFragmentTransformer, JsonForClause> VisForJsonForClause;
        public Action<ScopedFragmentTransformer, JsonKeyValue> VisForJsonKeyValue;
        public Action<ScopedFragmentTransformer, JsonForClauseOption> VisForJsonForClauseOption;
        public Action<ScopedFragmentTransformer, UpdateForClause> VisForUpdateForClause;
        public Action<ScopedFragmentTransformer, OptimizerHint> VisForOptimizerHint;
        public Action<ScopedFragmentTransformer, LiteralOptimizerHint> VisForLiteralOptimizerHint;
        public Action<ScopedFragmentTransformer, TableHintsOptimizerHint> VisForTableHintsOptimizerHint;
        public Action<ScopedFragmentTransformer, ForceSeekTableHint> VisForForceSeekTableHint;
        public Action<ScopedFragmentTransformer, OptimizeForOptimizerHint> VisForOptimizeForOptimizerHint;
        public Action<ScopedFragmentTransformer, UseHintList> VisForUseHintList;
        public Action<ScopedFragmentTransformer, VariableValuePair> VisForVariableValuePair;
        public Action<ScopedFragmentTransformer, SimpleWhenClause> VisForSimpleWhenClause;
        public Action<ScopedFragmentTransformer, SearchedWhenClause> VisForSearchedWhenClause;
        public Action<ScopedFragmentTransformer, SimpleCaseExpression> VisForSimpleCaseExpression;
        public Action<ScopedFragmentTransformer, SearchedCaseExpression> VisForSearchedCaseExpression;
        public Action<ScopedFragmentTransformer, NullIfExpression> VisForNullIfExpression;
        public Action<ScopedFragmentTransformer, CoalesceExpression> VisForCoalesceExpression;
        public Action<ScopedFragmentTransformer, IIfCall> VisForIIfCall;
        public Action<ScopedFragmentTransformer, FullTextTableReference> VisForFullTextTableReference;
        public Action<ScopedFragmentTransformer, SemanticTableReference> VisForSemanticTableReference;
        public Action<ScopedFragmentTransformer, OpenXmlTableReference> VisForOpenXmlTableReference;
        public Action<ScopedFragmentTransformer, OpenJsonTableReference> VisForOpenJsonTableReference;
        public Action<ScopedFragmentTransformer, OpenRowsetTableReference> VisForOpenRowsetTableReference;
        public Action<ScopedFragmentTransformer, InternalOpenRowset> VisForInternalOpenRowset;
        public Action<ScopedFragmentTransformer, OpenRowsetCosmos> VisForOpenRowsetCosmos;
        public Action<ScopedFragmentTransformer, BulkOpenRowset> VisForBulkOpenRowset;
        public Action<ScopedFragmentTransformer, OpenRowsetColumnDefinition> VisForOpenRowsetColumnDefinition;
        public Action<ScopedFragmentTransformer, OpenQueryTableReference> VisForOpenQueryTableReference;
        public Action<ScopedFragmentTransformer, AdHocTableReference> VisForAdHocTableReference;
        public Action<ScopedFragmentTransformer, SchemaDeclarationItem> VisForSchemaDeclarationItem;
        public Action<ScopedFragmentTransformer, SchemaDeclarationItemOpenjson> VisForSchemaDeclarationItemOpenjson;
        public Action<ScopedFragmentTransformer, ConvertCall> VisForConvertCall;
        public Action<ScopedFragmentTransformer, TryConvertCall> VisForTryConvertCall;
        public Action<ScopedFragmentTransformer, ParseCall> VisForParseCall;
        public Action<ScopedFragmentTransformer, TryParseCall> VisForTryParseCall;
        public Action<ScopedFragmentTransformer, CastCall> VisForCastCall;
        public Action<ScopedFragmentTransformer, StatementList> VisForStatementList;
        public Action<ScopedFragmentTransformer, ExecuteStatement> VisForExecuteStatement;
        public Action<ScopedFragmentTransformer, ExecuteOption> VisForExecuteOption;
        public Action<ScopedFragmentTransformer, ResultSetsExecuteOption> VisForResultSetsExecuteOption;
        public Action<ScopedFragmentTransformer, ResultSetDefinition> VisForResultSetDefinition;
        public Action<ScopedFragmentTransformer, InlineResultSetDefinition> VisForInlineResultSetDefinition;
        public Action<ScopedFragmentTransformer, ResultColumnDefinition> VisForResultColumnDefinition;
        public Action<ScopedFragmentTransformer, SchemaObjectResultSetDefinition> VisForSchemaObjectResultSetDefinition;
        public Action<ScopedFragmentTransformer, ExecuteSpecification> VisForExecuteSpecification;
        public Action<ScopedFragmentTransformer, ExecuteContext> VisForExecuteContext;
        public Action<ScopedFragmentTransformer, ExecuteParameter> VisForExecuteParameter;
        public Action<ScopedFragmentTransformer, ProcedureReferenceName> VisForProcedureReferenceName;
        public Action<ScopedFragmentTransformer, ExecutableProcedureReference> VisForExecutableProcedureReference;
        public Action<ScopedFragmentTransformer, ExecutableStringList> VisForExecutableStringList;
        public Action<ScopedFragmentTransformer, AdHocDataSource> VisForAdHocDataSource;
        public Action<ScopedFragmentTransformer, ViewOption> VisForViewOption;
        public Action<ScopedFragmentTransformer, AlterViewStatement> VisForAlterViewStatement;
        public Action<ScopedFragmentTransformer, CreateViewStatement> VisForCreateViewStatement;
        public Action<ScopedFragmentTransformer, CreateOrAlterViewStatement> VisForCreateOrAlterViewStatement;
        public Action<ScopedFragmentTransformer, ViewForAppendOption> VisForViewForAppendOption;
        public Action<ScopedFragmentTransformer, ViewDistributionOption> VisForViewDistributionOption;
        public Action<ScopedFragmentTransformer, ViewRoundRobinDistributionPolicy> VisForViewRoundRobinDistributionPolicy;
        public Action<ScopedFragmentTransformer, ViewHashDistributionPolicy> VisForViewHashDistributionPolicy;
        public Action<ScopedFragmentTransformer, TriggerObject> VisForTriggerObject;
        public Action<ScopedFragmentTransformer, TriggerOption> VisForTriggerOption;
        public Action<ScopedFragmentTransformer, ExecuteAsTriggerOption> VisForExecuteAsTriggerOption;
        public Action<ScopedFragmentTransformer, TriggerAction> VisForTriggerAction;
        public Action<ScopedFragmentTransformer, AlterTriggerStatement> VisForAlterTriggerStatement;
        public Action<ScopedFragmentTransformer, CreateTriggerStatement> VisForCreateTriggerStatement;
        public Action<ScopedFragmentTransformer, CreateOrAlterTriggerStatement> VisForCreateOrAlterTriggerStatement;
        public Action<ScopedFragmentTransformer, Identifier> VisForIdentifier;
        public Action<ScopedFragmentTransformer, AlterProcedureStatement> VisForAlterProcedureStatement;
        public Action<ScopedFragmentTransformer, CreateProcedureStatement> VisForCreateProcedureStatement;
        public Action<ScopedFragmentTransformer, CreateOrAlterProcedureStatement> VisForCreateOrAlterProcedureStatement;
        public Action<ScopedFragmentTransformer, ProcedureReference> VisForProcedureReference;
        public Action<ScopedFragmentTransformer, MethodSpecifier> VisForMethodSpecifier;
        public Action<ScopedFragmentTransformer, ProcedureOption> VisForProcedureOption;
        public Action<ScopedFragmentTransformer, ExecuteAsProcedureOption> VisForExecuteAsProcedureOption;
        public Action<ScopedFragmentTransformer, FunctionOption> VisForFunctionOption;
        public Action<ScopedFragmentTransformer, InlineFunctionOption> VisForInlineFunctionOption;
        public Action<ScopedFragmentTransformer, ExecuteAsFunctionOption> VisForExecuteAsFunctionOption;
        public Action<ScopedFragmentTransformer, XmlNamespaces> VisForXmlNamespaces;
        public Action<ScopedFragmentTransformer, XmlNamespacesDefaultElement> VisForXmlNamespacesDefaultElement;
        public Action<ScopedFragmentTransformer, XmlNamespacesAliasElement> VisForXmlNamespacesAliasElement;
        public Action<ScopedFragmentTransformer, CommonTableExpression> VisForCommonTableExpression;
        public Action<ScopedFragmentTransformer, WithCtesAndXmlNamespaces> VisForWithCtesAndXmlNamespaces;
        public Action<ScopedFragmentTransformer, TableValuedFunctionReturnType> VisForTableValuedFunctionReturnType;
        public Action<ScopedFragmentTransformer, SqlDataTypeReference> VisForSqlDataTypeReference;
        public Action<ScopedFragmentTransformer, UserDataTypeReference> VisForUserDataTypeReference;
        public Action<ScopedFragmentTransformer, XmlDataTypeReference> VisForXmlDataTypeReference;

        public ScopedFragmentTransformer() : base() {}

        void PushContext(TSqlFragment node) {
            Parents.Push(node);
        }

        void PopContext() {
            Parents.Pop();
        }

        public void EnqueueOnLeave(TSqlFragment node, Action<TSqlFragment> edit) {
            if (!PendingOnLeaveActionsByFragment.TryGetValue(node, out var edits)) {
                edits = PendingOnLeaveActionsByFragment[node] = new Queue<Action<TSqlFragment>>();
            }
            edits.Enqueue(edit);
        }

        public void HandleOnLeave(TSqlFragment node) {
            if (!PendingOnLeaveActionsByFragment.TryGetValue(node, out var actions)) {
                return;
            }
            while (actions.Count > 0) {
                actions.Dequeue().Invoke(node);
            }

            PendingOnLeaveActionsByFragment.Remove(node);
        }

        public override void ExplicitVisit(WindowDelimiter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWindowDelimiter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WithinGroupClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWithinGroupClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectiveXmlIndexPromotedPath node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectiveXmlIndexPromotedPath?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TemporalClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTemporalClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CompressionDelayIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCompressionDelayIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalLibraryStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalLibraryStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterExternalLibraryStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterExternalLibraryStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalLibraryFileOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalLibraryFileOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalLibraryStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalLibraryStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalLanguageStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalLanguageStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterExternalLanguageStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterExternalLanguageStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalLanguageFileOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalLanguageFileOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalLanguageStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalLanguageStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventDeclaration node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventDeclaration?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventDeclarationSetParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventDeclarationSetParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SourceDeclaration node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSourceDeclaration?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventDeclarationCompareFunctionParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventDeclarationCompareFunctionParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TargetDeclaration node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTargetDeclaration?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventRetentionSessionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventRetentionSessionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MemoryPartitionSessionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMemoryPartitionSessionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralSessionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralSessionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxDispatchLatencySessionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxDispatchLatencySessionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffSessionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffSessionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterEventSessionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterEventSessionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropEventSessionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropEventSessionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterResourceGovernorStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterResourceGovernorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSpatialIndexStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSpatialIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SpatialIndexRegularOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSpatialIndexRegularOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BoundingBoxSpatialIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBoundingBoxSpatialIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BoundingBoxParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBoundingBoxParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GridsSpatialIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGridsSpatialIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GridParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGridParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CellsPerObjectSpatialIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCellsPerObjectSpatialIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProcessAffinityRange node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProcessAffinityRange?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetExternalAuthenticationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSetExternalAuthenticationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationExternalAuthenticationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationExternalAuthenticationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationExternalAuthenticationContainerOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationExternalAuthenticationContainerOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetBufferPoolExtensionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSetBufferPoolExtensionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationBufferPoolExtensionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionContainerOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationBufferPoolExtensionContainerOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionSizeOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationBufferPoolExtensionSizeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetDiagnosticsLogStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSetDiagnosticsLogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationDiagnosticsLogOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogMaxSizeOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationDiagnosticsLogMaxSizeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetFailoverClusterPropertyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSetFailoverClusterPropertyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationFailoverClusterPropertyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationFailoverClusterPropertyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetHadrClusterStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSetHadrClusterStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationHadrClusterOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationHadrClusterOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSetSoftNumaStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSetSoftNumaStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerConfigurationSoftNumaOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerConfigurationSoftNumaOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateAvailabilityGroupStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateAvailabilityGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAvailabilityGroupStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAvailabilityGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AvailabilityReplica node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAvailabilityReplica?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralReplicaOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralReplicaOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AvailabilityModeReplicaOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAvailabilityModeReplicaOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FailoverModeReplicaOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFailoverModeReplicaOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PrimaryRoleReplicaOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPrimaryRoleReplicaOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecondaryRoleReplicaOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecondaryRoleReplicaOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralAvailabilityGroupOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralAvailabilityGroupOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAvailabilityGroupAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAvailabilityGroupAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAvailabilityGroupFailoverAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAvailabilityGroupFailoverAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAvailabilityGroupFailoverOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAvailabilityGroupFailoverOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropAvailabilityGroupStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropAvailabilityGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateFederationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateFederationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterFederationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterFederationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropFederationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropFederationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UseFederationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUseFederationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DiskStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDiskStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DiskStatementOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDiskStatementOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateColumnStoreIndexStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateColumnStoreIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WindowFrameClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWindowFrameClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropServerAuditStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropServerAuditStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuditTarget node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuditTarget?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueueDelayAuditOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueueDelayAuditOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuditGuidAuditOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuditGuidAuditOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnFailureAuditOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnFailureAuditOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OperatorAuditOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOperatorAuditOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StateAuditOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStateAuditOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxSizeAuditTargetOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxSizeAuditTargetOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RetentionDaysAuditTargetOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRetentionDaysAuditTargetOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxRolloverFilesAuditTargetOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxRolloverFilesAuditTargetOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralAuditTargetOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralAuditTargetOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffAuditTargetOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffAuditTargetOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateDatabaseEncryptionKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateDatabaseEncryptionKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseEncryptionKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseEncryptionKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropDatabaseEncryptionKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropDatabaseEncryptionKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResourcePoolStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResourcePoolParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResourcePoolParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResourcePoolAffinitySpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResourcePoolAffinitySpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateResourcePoolStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterResourcePoolStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropResourcePoolStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalResourcePoolStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalResourcePoolParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalResourcePoolParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalResourcePoolAffinitySpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalResourcePoolAffinitySpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalResourcePoolStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterExternalResourcePoolStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterExternalResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalResourcePoolStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalResourcePoolStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WorkloadGroupResourceParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWorkloadGroupResourceParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WorkloadGroupImportanceParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWorkloadGroupImportanceParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateWorkloadGroupStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateWorkloadGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterWorkloadGroupStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterWorkloadGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropWorkloadGroupStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropWorkloadGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierWorkloadGroupOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierWorkloadGroupOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierMemberNameOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierMemberNameOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierWlmLabelOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierWlmLabelOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierImportanceOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierImportanceOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierWlmContextOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierWlmContextOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierStartTimeOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierStartTimeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ClassifierEndTimeOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForClassifierEndTimeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WlmTimeLiteral node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWlmTimeLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateWorkloadClassifierStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateWorkloadClassifierStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropWorkloadClassifierStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropWorkloadClassifierStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BrokerPriorityParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBrokerPriorityParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateBrokerPriorityStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateBrokerPriorityStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterBrokerPriorityStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterBrokerPriorityStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropBrokerPriorityStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropBrokerPriorityStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateFullTextStopListStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateFullTextStopListStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterFullTextStopListStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterFullTextStopListStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FullTextStopListAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFullTextStopListAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropFullTextStopListStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropFullTextStopListStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateCryptographicProviderStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateCryptographicProviderStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterCryptographicProviderStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterCryptographicProviderStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropCryptographicProviderStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropCryptographicProviderStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventSessionObjectName node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventSessionObjectName?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventSessionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventSessionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateEventSessionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateEventSessionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AddSignatureStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAddSignatureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSignatureStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSignatureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropEventNotificationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropEventNotificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteAsStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteAsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EndConversationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEndConversationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MoveConversationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMoveConversationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GetConversationGroupStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGetConversationGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ReceiveStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForReceiveStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SendStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSendStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterSchemaStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterSchemaStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAsymmetricKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAsymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServiceMasterKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServiceMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BeginConversationTimerStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBeginConversationTimerStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BeginDialogStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBeginDialogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ScalarExpressionDialogOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForScalarExpressionDialogOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffDialogOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffDialogOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupCertificateStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupCertificateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupServiceMasterKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupServiceMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RestoreServiceMasterKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRestoreServiceMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupMasterKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RestoreMasterKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRestoreMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ScalarExpressionSnippet node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForScalarExpressionSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanExpressionSnippet node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanExpressionSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StatementListSnippet node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStatementListSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectStatementSnippet node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectStatementSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaObjectNameSnippet node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaObjectNameSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TSqlFragmentSnippet node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTSqlFragmentSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TSqlStatementSnippet node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTSqlStatementSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierSnippet node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierSnippet?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TSqlScript node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTSqlScript?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TSqlBatch node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTSqlBatch?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MergeStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMergeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MergeSpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMergeSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MergeActionClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMergeActionClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateMergeAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateMergeAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeleteMergeAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeleteMergeAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InsertMergeAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInsertMergeAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateTypeTableStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateTypeTableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SensitivityClassificationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSensitivityClassificationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AddSensitivityClassificationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAddSensitivityClassificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSensitivityClassificationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSensitivityClassificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuditSpecificationPart node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuditSpecificationPart?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuditActionSpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuditActionSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DatabaseAuditAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDatabaseAuditAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuditActionGroupReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuditActionGroupReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateDatabaseAuditSpecificationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateDatabaseAuditSpecificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseAuditSpecificationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseAuditSpecificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropDatabaseAuditSpecificationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropDatabaseAuditSpecificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateServerAuditSpecificationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateServerAuditSpecificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerAuditSpecificationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerAuditSpecificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropServerAuditSpecificationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropServerAuditSpecificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateServerAuditStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateServerAuditStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerAuditStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerAuditStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TopRowFilter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTopRowFilter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OffsetClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOffsetClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UnaryExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUnaryExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BinaryQueryExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBinaryQueryExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(VariableTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForVariableTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(VariableMethodCallTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForVariableMethodCallTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropPartitionFunctionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropPartitionFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropPartitionSchemeStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropPartitionSchemeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSynonymStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSynonymStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropAggregateStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropAggregateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropAssemblyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropAssemblyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropApplicationRoleStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropApplicationRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropFullTextCatalogStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropFullTextCatalogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropFullTextIndexStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropFullTextIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropLoginStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropLoginStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropRoleStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropTypeStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropTypeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropUserStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropUserStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropMasterKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSymmetricKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropAsymmetricKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropAsymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropCertificateStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropCertificateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropCredentialStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropCredentialStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterPartitionFunctionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterPartitionFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterPartitionSchemeStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterPartitionSchemeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterFullTextIndexStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterFullTextIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SimpleAlterFullTextIndexAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSimpleAlterFullTextIndexAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetStopListAlterFullTextIndexAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetStopListAlterFullTextIndexAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetSearchPropertyListAlterFullTextIndexAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetSearchPropertyListAlterFullTextIndexAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropAlterFullTextIndexAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropAlterFullTextIndexAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AddAlterFullTextIndexAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAddAlterFullTextIndexAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterColumnAlterFullTextIndexAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterColumnAlterFullTextIndexAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSearchPropertyListStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSearchPropertyListStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterSearchPropertyListStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterSearchPropertyListStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AddSearchPropertyListAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAddSearchPropertyListAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSearchPropertyListAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSearchPropertyListAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSearchPropertyListStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSearchPropertyListStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateLoginStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateLoginStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PasswordCreateLoginSource node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPasswordCreateLoginSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PrincipalOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPrincipalOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffPrincipalOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffPrincipalOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralPrincipalOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralPrincipalOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierPrincipalOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierPrincipalOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WindowsCreateLoginSource node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWindowsCreateLoginSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalCreateLoginSource node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalCreateLoginSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CertificateCreateLoginSource node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCertificateCreateLoginSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AsymmetricKeyCreateLoginSource node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAsymmetricKeyCreateLoginSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PasswordAlterPrincipalOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPasswordAlterPrincipalOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterLoginOptionsStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterLoginOptionsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterLoginEnableDisableStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterLoginEnableDisableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterLoginAddDropCredentialStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterLoginAddDropCredentialStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RevertStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRevertStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropContractStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropContractStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropEndpointStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropEndpointStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropMessageTypeStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropMessageTypeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropQueueStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropQueueStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropRemoteServiceBindingStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropRemoteServiceBindingStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropRouteStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropRouteStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropServiceStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropServiceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffFullTextCatalogOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffFullTextCatalogOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateFullTextCatalogStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateFullTextCatalogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterFullTextCatalogStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterFullTextCatalogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateServiceStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateServiceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServiceStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServiceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ServiceContract node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForServiceContract?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BinaryExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBinaryExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BuiltInFunctionTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBuiltInFunctionTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GlobalFunctionTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGlobalFunctionTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ComputeClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForComputeClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ComputeFunction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForComputeFunction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PivotedTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPivotedTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UnpivotedTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUnpivotedTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UnqualifiedJoin node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUnqualifiedJoin?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableSampleClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableSampleClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanNotExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanNotExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanParenthesisExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanParenthesisExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanComparisonExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanComparisonExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanBinaryExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanBinaryExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanIsNullExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanIsNullExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphMatchPredicate node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphMatchPredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphMatchLastNodePredicate node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphMatchLastNodePredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphMatchNodeExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphMatchNodeExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphMatchRecursivePredicate node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphMatchRecursivePredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphMatchExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphMatchExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphMatchCompositeExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphMatchCompositeExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphRecursiveMatchQuantifier node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphRecursiveMatchQuantifier?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExpressionWithSortOrder node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExpressionWithSortOrder?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GroupByClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGroupByClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExpressionGroupingSpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExpressionGroupingSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CompositeGroupingSpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCompositeGroupingSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CubeGroupingSpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCubeGroupingSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RollupGroupingSpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRollupGroupingSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GrandTotalGroupingSpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGrandTotalGroupingSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GroupingSetsGroupingSpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGroupingSetsGroupingSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OutputClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOutputClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OutputIntoClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOutputIntoClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(HavingClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForHavingClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentityFunctionCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentityFunctionCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(JoinParenthesisTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForJoinParenthesisTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OrderByClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOrderByClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QualifiedJoin node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQualifiedJoin?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OdbcQualifiedJoinTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOdbcQualifiedJoinTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryParenthesisExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryParenthesisExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QuerySpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQuerySpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FromClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFromClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PredictTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPredictTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectScalarExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectScalarExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectStarExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectStarExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectSetVariable node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectSetVariable?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DataModificationTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDataModificationTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ChangeTableChangesTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForChangeTableChangesTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ChangeTableVersionTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForChangeTableVersionTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BooleanTernaryExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBooleanTernaryExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DbccStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDbccStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DbccOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDbccOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DbccNamedLiteral node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDbccNamedLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateAsymmetricKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateAsymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreatePartitionFunctionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreatePartitionFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PartitionParameterType node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPartitionParameterType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreatePartitionSchemeStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreatePartitionSchemeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffRemoteServiceBindingOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffRemoteServiceBindingOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UserRemoteServiceBindingOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUserRemoteServiceBindingOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateRemoteServiceBindingStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateRemoteServiceBindingStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterRemoteServiceBindingStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterRemoteServiceBindingStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AssemblyEncryptionSource node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAssemblyEncryptionSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileEncryptionSource node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileEncryptionSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProviderEncryptionSource node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProviderEncryptionSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterCertificateStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterCertificateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateCertificateStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateCertificateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CertificateOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCertificateOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateContractStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateContractStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ContractMessage node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForContractMessage?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateCredentialStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateCredentialStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterCredentialStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterCredentialStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateMessageTypeStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateMessageTypeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterMessageTypeStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterMessageTypeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateAggregateStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateAggregateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateEndpointStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateEndpointStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterEndpointStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterEndpointStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EndpointAffinity node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEndpointAffinity?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralEndpointProtocolOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralEndpointProtocolOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuthenticationEndpointProtocolOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuthenticationEndpointProtocolOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PortsEndpointProtocolOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPortsEndpointProtocolOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CompressionEndpointProtocolOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCompressionEndpointProtocolOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ListenerIPEndpointProtocolOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForListenerIPEndpointProtocolOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IPv4 node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIPv4?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SoapMethod node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSoapMethod?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EnabledDisabledPayloadOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEnabledDisabledPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WsdlPayloadOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWsdlPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LoginTypePayloadOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLoginTypePayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralPayloadOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SessionTimeoutPayloadOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSessionTimeoutPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaPayloadOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CharacterSetPayloadOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCharacterSetPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RolePayloadOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRolePayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AuthenticationPayloadOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAuthenticationPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EncryptionPayloadOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEncryptionPayloadOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSymmetricKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(KeySourceKeyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForKeySourceKeyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlgorithmKeyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlgorithmKeyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentityValueKeyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentityValueKeyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProviderKeyNameKeyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProviderKeyNameKeyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreationDispositionKeyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreationDispositionKeyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterSymmetricKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterSymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnEncryptionAlgorithmParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnEncryptionAlgorithmParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentityOptions node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentityOptions?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnStorageOptions node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnStorageOptions?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateTableStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateTableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FederationScheme node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFederationScheme?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableDataCompressionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableDataCompressionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableXmlCompressionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableXmlCompressionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableDistributionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableDistributionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableReplicateDistributionPolicy node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableReplicateDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableRoundRobinDistributionPolicy node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableRoundRobinDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableHashDistributionPolicy node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableHashDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableClusteredIndexType node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableClusteredIndexType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableNonClusteredIndexType node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableNonClusteredIndexType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TablePartitionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTablePartitionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TablePartitionOptionSpecifications node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTablePartitionOptionSpecifications?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LocationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLocationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RenameEntityStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRenameEntityStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CopyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCopyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CopyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCopyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CopyCredentialOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCopyCredentialOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SingleValueTypeCopyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSingleValueTypeCopyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ListTypeCopyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForListTypeCopyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CopyColumnOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCopyColumnOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DataCompressionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDataCompressionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(XmlCompressionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForXmlCompressionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CompressionPartitionRange node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCompressionPartitionRange?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CheckConstraintDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCheckConstraintDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DefaultConstraintDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDefaultConstraintDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ForeignKeyConstraintDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForForeignKeyConstraintDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NullableConstraintDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNullableConstraintDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphConnectionBetweenNodes node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphConnectionBetweenNodes?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GraphConnectionConstraintDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGraphConnectionConstraintDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UniqueConstraintDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUniqueConstraintDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupDatabaseStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupDatabaseStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupTransactionLogStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupTransactionLogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RestoreStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRestoreStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RestoreOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRestoreOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ScalarExpressionRestoreOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForScalarExpressionRestoreOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MoveRestoreOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMoveRestoreOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StopRestoreOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStopRestoreOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileStreamRestoreOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileStreamRestoreOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupEncryptionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupEncryptionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeviceInfo node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeviceInfo?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MirrorToClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMirrorToClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackupRestoreFileInfo node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackupRestoreFileInfo?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BulkInsertStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBulkInsertStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InsertBulkStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInsertBulkStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BulkInsertOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBulkInsertOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenRowsetCosmosOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenRowsetCosmosOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralOpenRowsetCosmosOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralOpenRowsetCosmosOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralBulkInsertOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralBulkInsertOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OrderBulkInsertOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOrderBulkInsertOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnDefinitionBase node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnDefinitionBase?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableColumnDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableColumnDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InsertBulkColumnDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInsertBulkColumnDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DatabaseConfigurationClearOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDatabaseConfigurationClearOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DatabaseConfigurationSetOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDatabaseConfigurationSetOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffPrimaryConfigurationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffPrimaryConfigurationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxDopConfigurationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxDopConfigurationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GenericConfigurationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGenericConfigurationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseCollateStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseCollateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseRebuildLogStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseRebuildLogStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseAddFileStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseAddFileStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseAddFileGroupStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseAddFileGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseRemoveFileGroupStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseRemoveFileGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseRemoveFileStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseRemoveFileStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseModifyNameStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseModifyNameStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseModifyFileStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseModifyFileStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseModifyFileGroupStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseModifyFileGroupStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseTermination node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseTermination?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseSetStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseSetStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutoCreateStatisticsDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutoCreateStatisticsDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ContainmentDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForContainmentDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(HadrDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForHadrDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(HadrAvailabilityGroupDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForHadrAvailabilityGroupDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DelayedDurabilityDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDelayedDurabilityDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CursorDefaultDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCursorDefaultDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RecoveryDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRecoveryDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TargetRecoveryTimeDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTargetRecoveryTimeDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PageVerifyDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPageVerifyDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PartnerDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPartnerDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WitnessDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWitnessDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ParameterizationDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForParameterizationDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ChangeTrackingDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForChangeTrackingDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutoCleanupChangeTrackingOptionDetail node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutoCleanupChangeTrackingOptionDetail?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ChangeRetentionChangeTrackingOptionDetail node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForChangeRetentionChangeTrackingOptionDetail?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AcceleratedDatabaseRecoveryDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAcceleratedDatabaseRecoveryDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreDesiredStateOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreDesiredStateOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreCapturePolicyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreCapturePolicyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreSizeCleanupPolicyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreSizeCleanupPolicyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreDataFlushIntervalOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreDataFlushIntervalOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreIntervalLengthOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreIntervalLengthOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreMaxStorageSizeOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreMaxStorageSizeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreMaxPlansPerQueryOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreMaxPlansPerQueryOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryStoreTimeCleanupPolicyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryStoreTimeCleanupPolicyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutomaticTuningDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutomaticTuningDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutomaticTuningOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutomaticTuningOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutomaticTuningForceLastGoodPlanOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutomaticTuningForceLastGoodPlanOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutomaticTuningCreateIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutomaticTuningCreateIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutomaticTuningDropIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutomaticTuningDropIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AutomaticTuningMaintainIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAutomaticTuningMaintainIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileStreamDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileStreamDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CatalogCollationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCatalogCollationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LedgerOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLedgerOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxSizeDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxSizeDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableAlterIndexStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableAlterIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableAlterColumnStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableAlterColumnStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnEncryptionDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnEncryptionDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnEncryptionKeyNameParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnEncryptionKeyNameParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnEncryptionTypeParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnEncryptionTypeParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CloseSymmetricKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCloseSymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenMasterKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CloseMasterKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCloseMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeallocateCursorStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeallocateCursorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FetchType node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFetchType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FetchCursorStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFetchCursorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WhereClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWhereClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropDatabaseStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropDatabaseStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropIndexStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BackwardsCompatibleDropIndexClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBackwardsCompatibleDropIndexClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropIndexClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropIndexClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MoveToDropIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMoveToDropIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileStreamOnDropIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileStreamOnDropIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropStatisticsStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropStatisticsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropTableStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropTableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropProcedureStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropProcedureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropFunctionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropViewStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropViewStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropDefaultStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropDefaultStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropRuleStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropRuleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropTriggerStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropTriggerStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSchemaStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSchemaStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RaiseErrorLegacyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRaiseErrorLegacyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RaiseErrorStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRaiseErrorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ThrowStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForThrowStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UseStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUseStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(KillStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForKillStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(KillQueryNotificationSubscriptionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForKillQueryNotificationSubscriptionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(KillStatsJobStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForKillStatsJobStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CheckpointStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCheckpointStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ReconfigureStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForReconfigureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ShutdownStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForShutdownStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetUserStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetUserStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TruncateTableStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTruncateTableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PredicateSetStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPredicateSetStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetStatisticsStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetStatisticsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetRowCountStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetRowCountStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetOffsetsStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetOffsetsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GeneralSetCommand node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGeneralSetCommand?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetFipsFlaggerCommand node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetFipsFlaggerCommand?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetCommandStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetCommandStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetTransactionIsolationLevelStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetTransactionIsolationLevelStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetTextSizeStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetTextSizeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetIdentityInsertStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetIdentityInsertStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetErrorLevelStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetErrorLevelStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateDatabaseStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateDatabaseStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileDeclaration node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileDeclaration?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileDeclarationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileDeclarationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NameFileDeclarationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNameFileDeclarationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileNameFileDeclarationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileNameFileDeclarationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SizeFileDeclarationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSizeFileDeclarationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxSizeFileDeclarationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxSizeFileDeclarationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileGrowthFileDeclarationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileGrowthFileDeclarationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileGroupDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileGroupDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseScopedConfigurationSetStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseScopedConfigurationSetStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterDatabaseScopedConfigurationClearStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterDatabaseScopedConfigurationClearStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateIndexStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IndexStateOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIndexStateOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IndexExpressionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIndexExpressionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxDurationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxDurationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WaitAtLowPriorityOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWaitAtLowPriorityOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnlineIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnlineIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IgnoreDupKeyIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIgnoreDupKeyIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OrderIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOrderIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnlineIndexLowPriorityLockWaitOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnlineIndexLowPriorityLockWaitOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LowPriorityLockWaitMaxDurationOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLowPriorityLockWaitMaxDurationOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LowPriorityLockWaitAbortAfterWaitOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLowPriorityLockWaitAbortAfterWaitOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FullTextIndexColumn node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFullTextIndexColumn?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateFullTextIndexStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateFullTextIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ChangeTrackingFullTextIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForChangeTrackingFullTextIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StopListFullTextIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStopListFullTextIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SearchPropertyListFullTextIndexOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSearchPropertyListFullTextIndexOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FullTextCatalogAndFileGroup node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFullTextCatalogAndFileGroup?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventTypeContainer node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventTypeContainer?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventGroupContainer node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventGroupContainer?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateEventNotificationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateEventNotificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EventNotificationObjectScope node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEventNotificationObjectScope?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateMasterKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterMasterKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ApplicationRoleOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForApplicationRoleOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateApplicationRoleStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateApplicationRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterApplicationRoleStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterApplicationRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateRoleStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterRoleStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RenameAlterRoleAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRenameAlterRoleAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AddMemberAlterRoleAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAddMemberAlterRoleAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropMemberAlterRoleAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropMemberAlterRoleAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateServerRoleStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateServerRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterServerRoleStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterServerRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropServerRoleStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropServerRoleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UserLoginOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUserLoginOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateUserStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateUserStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterUserStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterUserStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StatisticsOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStatisticsOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResampleStatisticsOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResampleStatisticsOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StatisticsPartitionRange node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStatisticsPartitionRange?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffStatisticsOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffStatisticsOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralStatisticsOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralStatisticsOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateStatisticsStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateStatisticsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateStatisticsStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateStatisticsStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ReturnStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForReturnStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeclareCursorStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeclareCursorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CursorDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCursorDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CursorOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCursorOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SetVariableStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSetVariableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CursorId node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCursorId?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenCursorStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenCursorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CloseCursorStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCloseCursorStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CryptoMechanism node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCryptoMechanism?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenSymmetricKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenSymmetricKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableFileTableNamespaceStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableFileTableNamespaceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableSetStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableSetStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LockEscalationTableOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLockEscalationTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileStreamOnTableOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileStreamOnTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileTableDirectoryTableOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileTableDirectoryTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileTableCollateFileNameTableOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileTableCollateFileNameTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileTableConstraintNameTableOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileTableConstraintNameTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MemoryOptimizedTableOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMemoryOptimizedTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DurabilityTableOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDurabilityTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RemoteDataArchiveTableOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRemoteDataArchiveTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RemoteDataArchiveAlterTableOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRemoteDataArchiveAlterTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RemoteDataArchiveDatabaseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRemoteDataArchiveDatabaseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RemoteDataArchiveDbServerSetting node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRemoteDataArchiveDbServerSetting?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RemoteDataArchiveDbCredentialSetting node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRemoteDataArchiveDbCredentialSetting?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RemoteDataArchiveDbFederatedServiceAccountSetting node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRemoteDataArchiveDbFederatedServiceAccountSetting?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RetentionPeriodDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRetentionPeriodDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SystemVersioningTableOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSystemVersioningTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LedgerTableOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLedgerTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LedgerViewOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLedgerViewOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DataRetentionTableOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDataRetentionTableOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableAddTableElementStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableAddTableElementStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableConstraintModificationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableConstraintModificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableSwitchStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableSwitchStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LowPriorityLockWaitTableSwitchOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLowPriorityLockWaitTableSwitchOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TruncateTargetTableSwitchOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTruncateTargetTableSwitchOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropClusteredConstraintStateOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropClusteredConstraintStateOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropClusteredConstraintValueOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropClusteredConstraintValueOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropClusteredConstraintMoveOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropClusteredConstraintMoveOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropClusteredConstraintWaitAtLowPriorityLockOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropClusteredConstraintWaitAtLowPriorityLockOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableDropTableElement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableDropTableElement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableDropTableElementStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableDropTableElementStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableTriggerModificationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableTriggerModificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EnableDisableTriggerStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEnableDisableTriggerStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TryCatchStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTryCatchStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateTypeUdtStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateTypeUdtStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateTypeUddtStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateTypeUddtStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSynonymStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSynonymStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteAsClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteAsClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueueOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueueOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueueStateOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueueStateOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueueProcedureOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueueProcedureOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueueValueOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueueValueOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueueExecuteAsOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueueExecuteAsOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RouteOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRouteOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterRouteStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterRouteStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateRouteStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateRouteStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterQueueStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterQueueStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateQueueStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateQueueStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IndexDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIndexDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SystemTimePeriodDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSystemTimePeriodDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IndexType node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIndexType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PartitionSpecifier node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPartitionSpecifier?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterIndexStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateXmlIndexStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateXmlIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSelectiveXmlIndexStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSelectiveXmlIndexStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FileGroupOrPartitionScheme node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFileGroupOrPartitionScheme?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterSecurityPolicyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterSecurityPolicyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSecurityPolicyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSecurityPolicyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateColumnMasterKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateColumnMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnMasterKeyStoreProviderNameParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnMasterKeyStoreProviderNameParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnMasterKeyPathParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnMasterKeyPathParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnMasterKeyEnclaveComputationsParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnMasterKeyEnclaveComputationsParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropColumnMasterKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropColumnMasterKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateColumnEncryptionKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateColumnEncryptionKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterColumnEncryptionKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterColumnEncryptionKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropColumnEncryptionKeyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropColumnEncryptionKeyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnEncryptionKeyValue node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnEncryptionKeyValue?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnMasterKeyNameParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnMasterKeyNameParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnEncryptionAlgorithmNameParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnEncryptionAlgorithmNameParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(EncryptedValueParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForEncryptedValueParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableLiteralOrIdentifierOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableLiteralOrIdentifierOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableDistributionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableDistributionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableRejectTypeOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableRejectTypeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableReplicatedDistributionPolicy node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableReplicatedDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableRoundRobinDistributionPolicy node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableRoundRobinDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalTableShardedDistributionPolicy node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalTableShardedDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalTableStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalTableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalTableStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalTableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalDataSourceLiteralOrIdentifierOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalDataSourceLiteralOrIdentifierOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalDataSourceStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalDataSourceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterExternalDataSourceStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterExternalDataSourceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalDataSourceStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalDataSourceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalStreamLiteralOrIdentifierOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalStreamLiteralOrIdentifierOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalStreamStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalStreamStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalStreamStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalStreamStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalFileFormatLiteralOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalFileFormatLiteralOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalFileFormatUseDefaultTypeOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalFileFormatUseDefaultTypeOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExternalFileFormatContainerOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExternalFileFormatContainerOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalFileFormatStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalFileFormatStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalFileFormatStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalFileFormatStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateExternalStreamingJobStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateExternalStreamingJobStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropExternalStreamingJobStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropExternalStreamingJobStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateAssemblyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateAssemblyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAssemblyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAssemblyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AssemblyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAssemblyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffAssemblyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffAssemblyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PermissionSetAssemblyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPermissionSetAssemblyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AddFileSpec node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAddFileSpec?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateXmlSchemaCollectionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateXmlSchemaCollectionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterXmlSchemaCollectionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterXmlSchemaCollectionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropXmlSchemaCollectionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropXmlSchemaCollectionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AssemblyName node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAssemblyName?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableAlterPartitionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableAlterPartitionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableRebuildStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableRebuildStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTableChangeTrackingModificationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTableChangeTrackingModificationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RevokeStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRevokeStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterAuthorizationStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterAuthorizationStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(Permission node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPermission?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecurityTargetObject node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecurityTargetObject?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecurityTargetObjectName node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecurityTargetObjectName?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecurityPrincipal node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecurityPrincipal?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GrantStatement80 node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGrantStatement80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DenyStatement80 node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDenyStatement80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RevokeStatement80 node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRevokeStatement80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CommandSecurityElement80 node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCommandSecurityElement80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PrivilegeSecurityElement80 node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPrivilegeSecurityElement80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(Privilege80 node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPrivilege80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecurityUserClause80 node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecurityUserClause80?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SqlCommandIdentifier node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSqlCommandIdentifier?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AssignmentSetClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAssignmentSetClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FunctionCallSetClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFunctionCallSetClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ValuesInsertSource node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForValuesInsertSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectInsertSource node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectInsertSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteInsertSource node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteInsertSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RowValue node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRowValue?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PrintStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPrintStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TSEqualCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTSEqualCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IntegerLiteral node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIntegerLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NumericLiteral node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNumericLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RealLiteral node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRealLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MoneyLiteral node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMoneyLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BinaryLiteral node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBinaryLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StringLiteral node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStringLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NullLiteral node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNullLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierLiteral node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DefaultLiteral node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDefaultLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MaxLiteral node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMaxLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OdbcLiteral node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOdbcLiteral?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralRange node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralRange?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(VariableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForVariableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffOptionValue node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffOptionValue?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralOptionValue node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralOptionValue?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GlobalVariableExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGlobalVariableExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierOrValueExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierOrValueExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierOrScalarExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierOrScalarExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaObjectNameOrValueExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaObjectNameOrValueExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ParenthesisExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForParenthesisExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnReferenceExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnReferenceExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NextValueForExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNextValueForExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SequenceOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSequenceOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DataTypeSequenceOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDataTypeSequenceOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ScalarExpressionSequenceOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForScalarExpressionSequenceOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSequenceStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSequenceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterSequenceStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterSequenceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DropSequenceStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDropSequenceStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecurityPredicateAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecurityPredicateAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SecurityPolicyOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSecurityPolicyOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSecurityPolicyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSecurityPolicyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TryCastCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTryCastCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AtTimeZoneCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAtTimeZoneCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FunctionCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFunctionCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExpressionCallTarget node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExpressionCallTarget?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MultiPartIdentifierCallTarget node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMultiPartIdentifierCallTarget?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UserDefinedTypeCallTarget node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUserDefinedTypeCallTarget?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LeftFunctionCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLeftFunctionCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RightFunctionCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRightFunctionCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(PartitionFunctionCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForPartitionFunctionCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OverClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOverClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WindowClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWindowClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WindowDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWindowDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ParameterlessCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForParameterlessCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ScalarSubquery node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForScalarSubquery?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OdbcFunctionCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOdbcFunctionCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExtractFromExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExtractFromExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OdbcConvertSpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOdbcConvertSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterFunctionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BeginEndBlockStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBeginEndBlockStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BeginEndAtomicBlockStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBeginEndAtomicBlockStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralAtomicBlockOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralAtomicBlockOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IdentifierAtomicBlockOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifierAtomicBlockOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OnOffAtomicBlockOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOnOffAtomicBlockOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BeginTransactionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBeginTransactionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BreakStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBreakStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ColumnWithSortOrder node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForColumnWithSortOrder?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CommitTransactionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCommitTransactionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(RollbackTransactionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForRollbackTransactionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SaveTransactionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSaveTransactionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ContinueStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForContinueStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateDefaultStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateDefaultStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateFunctionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateOrAlterFunctionStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateOrAlterFunctionStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateRuleStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateRuleStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeclareVariableElement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeclareVariableElement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeclareVariableStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeclareVariableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GoToStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGoToStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IfStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIfStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LabelStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLabelStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MultiPartIdentifier node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMultiPartIdentifier?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaObjectName node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaObjectName?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ChildObjectName node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForChildObjectName?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProcedureParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProcedureParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WhileStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWhileStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeleteStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeleteStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeleteSpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeleteSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InsertStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInsertStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InsertSpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInsertSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateSpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateSchemaStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateSchemaStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WaitForStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWaitForStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ReadTextStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForReadTextStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateTextStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateTextStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WriteTextStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWriteTextStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LineNoStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLineNoStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(GrantStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForGrantStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DenyStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDenyStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ScalarFunctionReturnType node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForScalarFunctionReturnType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectFunctionReturnType node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectFunctionReturnType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeclareTableVariableBody node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeclareTableVariableBody?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DeclareTableVariableStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDeclareTableVariableStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NamedTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNamedTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaObjectFunctionTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaObjectFunctionTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableHint node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IndexTableHint node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIndexTableHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralTableHint node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralTableHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(QueryDerivedTable node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForQueryDerivedTable?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InlineDerivedTable node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInlineDerivedTable?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SubqueryComparisonPredicate node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSubqueryComparisonPredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExistsPredicate node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExistsPredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LikePredicate node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLikePredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(DistinctPredicate node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForDistinctPredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InPredicate node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInPredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FullTextPredicate node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFullTextPredicate?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UserDefinedTypePropertyAccess node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUserDefinedTypePropertyAccess?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SelectStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSelectStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BrowseForClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBrowseForClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ReadOnlyForClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForReadOnlyForClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(XmlForClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForXmlForClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(XmlForClauseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForXmlForClauseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(JsonForClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForJsonForClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(JsonKeyValue node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForJsonKeyValue?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(JsonForClauseOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForJsonForClauseOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UpdateForClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUpdateForClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OptimizerHint node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOptimizerHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(LiteralOptimizerHint node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForLiteralOptimizerHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableHintsOptimizerHint node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableHintsOptimizerHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ForceSeekTableHint node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForForceSeekTableHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OptimizeForOptimizerHint node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOptimizeForOptimizerHint?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UseHintList node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUseHintList?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(VariableValuePair node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForVariableValuePair?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SimpleWhenClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSimpleWhenClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SearchedWhenClause node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSearchedWhenClause?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SimpleCaseExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSimpleCaseExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SearchedCaseExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSearchedCaseExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(NullIfExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForNullIfExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CoalesceExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCoalesceExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(IIfCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIIfCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FullTextTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFullTextTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SemanticTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSemanticTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenXmlTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenXmlTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenJsonTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenJsonTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenRowsetTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenRowsetTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InternalOpenRowset node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInternalOpenRowset?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenRowsetCosmos node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenRowsetCosmos?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(BulkOpenRowset node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForBulkOpenRowset?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenRowsetColumnDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenRowsetColumnDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(OpenQueryTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForOpenQueryTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AdHocTableReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAdHocTableReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaDeclarationItem node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaDeclarationItem?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaDeclarationItemOpenjson node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaDeclarationItemOpenjson?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ConvertCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForConvertCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TryConvertCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTryConvertCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ParseCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForParseCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TryParseCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTryParseCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CastCall node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCastCall?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(StatementList node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForStatementList?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResultSetsExecuteOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResultSetsExecuteOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResultSetDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResultSetDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InlineResultSetDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInlineResultSetDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ResultColumnDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForResultColumnDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SchemaObjectResultSetDefinition node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSchemaObjectResultSetDefinition?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteSpecification node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteSpecification?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteContext node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteContext?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteParameter node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteParameter?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProcedureReferenceName node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProcedureReferenceName?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecutableProcedureReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecutableProcedureReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecutableStringList node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecutableStringList?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AdHocDataSource node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAdHocDataSource?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ViewOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForViewOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterViewStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterViewStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateViewStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateViewStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateOrAlterViewStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateOrAlterViewStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ViewForAppendOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForViewForAppendOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ViewDistributionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForViewDistributionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ViewRoundRobinDistributionPolicy node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForViewRoundRobinDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ViewHashDistributionPolicy node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForViewHashDistributionPolicy?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TriggerObject node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTriggerObject?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TriggerOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTriggerOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteAsTriggerOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteAsTriggerOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TriggerAction node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTriggerAction?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterTriggerStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterTriggerStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateTriggerStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateTriggerStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateOrAlterTriggerStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateOrAlterTriggerStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(Identifier node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForIdentifier?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(AlterProcedureStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForAlterProcedureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateProcedureStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateProcedureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CreateOrAlterProcedureStatement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCreateOrAlterProcedureStatement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProcedureReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProcedureReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(MethodSpecifier node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForMethodSpecifier?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ProcedureOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForProcedureOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteAsProcedureOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteAsProcedureOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(FunctionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForFunctionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(InlineFunctionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForInlineFunctionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(ExecuteAsFunctionOption node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForExecuteAsFunctionOption?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(XmlNamespaces node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForXmlNamespaces?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(XmlNamespacesDefaultElement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForXmlNamespacesDefaultElement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(XmlNamespacesAliasElement node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForXmlNamespacesAliasElement?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(CommonTableExpression node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForCommonTableExpression?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(WithCtesAndXmlNamespaces node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForWithCtesAndXmlNamespaces?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(TableValuedFunctionReturnType node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForTableValuedFunctionReturnType?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(SqlDataTypeReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForSqlDataTypeReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(UserDataTypeReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForUserDataTypeReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        public override void ExplicitVisit(XmlDataTypeReference node) {
            if (SkipList.Contains(node)) { return; }
            if (ShouldStop) { return; }
            VisForXmlDataTypeReference?.Invoke(this, node);
            if (ShouldStop) { return; }

            PushContext(node);
            base.ExplicitVisit(node);
            PopContext();

            HandleOnLeave(node);
        }

        static readonly IReadOnlyDictionary<string, int> ReplaceCaseNumberByType =
            new Dictionary<string, int> {
                [nameof(WindowDelimiter)] = 1,
                [nameof(TemporalClause)] = 2,
                [nameof(CompressionDelayIndexOption)] = 3,
                [nameof(ExternalLibraryFileOption)] = 4,
                [nameof(ExternalLanguageFileOption)] = 5,
                [nameof(EventDeclarationSetParameter)] = 6,
                [nameof(EventDeclarationCompareFunctionParameter)] = 7,
                [nameof(BoundingBoxParameter)] = 8,
                [nameof(AlterFederationStatement)] = 9,
                [nameof(UseFederationStatement)] = 10,
                [nameof(EndConversationStatement)] = 11,
                [nameof(MoveConversationStatement)] = 12,
                [nameof(ReceiveStatement)] = 13,
                [nameof(SendStatement)] = 14,
                [nameof(BeginConversationTimerStatement)] = 15,
                [nameof(ScalarExpressionDialogOption)] = 16,
                [nameof(TopRowFilter)] = 17,
                [nameof(OffsetClause)] = 18,
                [nameof(UnaryExpression)] = 19,
                [nameof(VariableMethodCallTableReference)] = 20,
                [nameof(AlterPartitionFunctionStatement)] = 21,
                [nameof(RevertStatement)] = 22,
                [nameof(BinaryExpression)] = 23,
                [nameof(BuiltInFunctionTableReference)] = 24,
                [nameof(GlobalFunctionTableReference)] = 25,
                [nameof(ComputeClause)] = 26,
                [nameof(ComputeFunction)] = 27,
                [nameof(TableSampleClause)] = 28,
                [nameof(BooleanComparisonExpression)] = 29,
                [nameof(BooleanIsNullExpression)] = 30,
                [nameof(ExpressionWithSortOrder)] = 31,
                [nameof(ExpressionGroupingSpecification)] = 32,
                [nameof(IdentityFunctionCall)] = 33,
                [nameof(PredictTableReference)] = 34,
                [nameof(SelectScalarExpression)] = 35,
                [nameof(SelectSetVariable)] = 36,
                [nameof(ChangeTableVersionTableReference)] = 37,
                [nameof(BooleanTernaryExpression)] = 38,
                [nameof(DbccNamedLiteral)] = 39,
                [nameof(CreatePartitionFunctionStatement)] = 40,
                [nameof(IdentityOptions)] = 41,
                [nameof(TablePartitionOptionSpecifications)] = 42,
                [nameof(CopyColumnOption)] = 43,
                [nameof(CompressionPartitionRange)] = 44,
                [nameof(DefaultConstraintDefinition)] = 45,
                [nameof(ScalarExpressionRestoreOption)] = 46,
                [nameof(BackupOption)] = 47,
                [nameof(BackupEncryptionOption)] = 48,
                [nameof(ColumnDefinition)] = 49,
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
                [nameof(TryCastCall)] = 76,
                [nameof(AtTimeZoneCall)] = 77,
                [nameof(FunctionCall)] = 78,
                [nameof(ExpressionCallTarget)] = 79,
                [nameof(LeftFunctionCall)] = 80,
                [nameof(RightFunctionCall)] = 81,
                [nameof(PartitionFunctionCall)] = 82,
                [nameof(OverClause)] = 83,
                [nameof(WindowDefinition)] = 84,
                [nameof(OdbcFunctionCall)] = 85,
                [nameof(ExtractFromExpression)] = 86,
                [nameof(CreateDefaultStatement)] = 87,
                [nameof(DeclareVariableElement)] = 88,
                [nameof(ProcedureParameter)] = 89,
                [nameof(WaitForStatement)] = 90,
                [nameof(UpdateTextStatement)] = 91,
                [nameof(SchemaObjectFunctionTableReference)] = 92,
                [nameof(SubqueryComparisonPredicate)] = 93,
                [nameof(LikePredicate)] = 94,
                [nameof(DistinctPredicate)] = 95,
                [nameof(InPredicate)] = 96,
                [nameof(JsonKeyValue)] = 97,
                [nameof(VariableValuePair)] = 98,
                [nameof(SimpleWhenClause)] = 99,
                [nameof(SearchedWhenClause)] = 100,
                [nameof(SimpleCaseExpression)] = 101,
                [nameof(SearchedCaseExpression)] = 102,
                [nameof(NullIfExpression)] = 103,
                [nameof(CoalesceExpression)] = 104,
                [nameof(IIfCall)] = 105,
                [nameof(SemanticTableReference)] = 106,
                [nameof(OpenJsonTableReference)] = 107,
                [nameof(InternalOpenRowset)] = 108,
                [nameof(ConvertCall)] = 109,
                [nameof(TryConvertCall)] = 110,
                [nameof(ParseCall)] = 111,
                [nameof(TryParseCall)] = 112,
                [nameof(CastCall)] = 113,
                [nameof(ExecuteContext)] = 114,
                [nameof(ExecuteParameter)] = 115
            };

        public static bool ReplaceScalarInParent(TSqlFragment parent, ScalarExpression toReplace, ScalarExpression replacement) {
            var success = false;
            _ = ReplaceCaseNumberByType.TryGetValue(parent.GetType().Name, out var caseNum);
            switch (caseNum) {
                case 1: {
                    var parent2 = (WindowDelimiter)parent;
                    if (Equals(parent2.OffsetValue, toReplace)) {
                        parent2.OffsetValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 2: {
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
                case 3: {
                    var parent2 = (CompressionDelayIndexOption)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 4: {
                    var parent2 = (ExternalLibraryFileOption)parent;
                    if (Equals(parent2.Content, toReplace)) {
                        parent2.Content = replacement;
                        success = true;
                    }
                    break;
                }
                case 5: {
                    var parent2 = (ExternalLanguageFileOption)parent;
                    if (Equals(parent2.Content, toReplace)) {
                        parent2.Content = replacement;
                        success = true;
                    }
                    break;
                }
                case 6: {
                    var parent2 = (EventDeclarationSetParameter)parent;
                    if (Equals(parent2.EventValue, toReplace)) {
                        parent2.EventValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 7: {
                    var parent2 = (EventDeclarationCompareFunctionParameter)parent;
                    if (Equals(parent2.EventValue, toReplace)) {
                        parent2.EventValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 8: {
                    var parent2 = (BoundingBoxParameter)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 9: {
                    var parent2 = (AlterFederationStatement)parent;
                    if (Equals(parent2.Boundary, toReplace)) {
                        parent2.Boundary = replacement;
                        success = true;
                    }
                    break;
                }
                case 10: {
                    var parent2 = (UseFederationStatement)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 11: {
                    var parent2 = (EndConversationStatement)parent;
                    if (Equals(parent2.Conversation, toReplace)) {
                        parent2.Conversation = replacement;
                        success = true;
                    }
                    break;
                }
                case 12: {
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
                case 13: {
                    var parent2 = (ReceiveStatement)parent;
                    if (Equals(parent2.Top, toReplace)) {
                        parent2.Top = replacement;
                        success = true;
                    }
                    break;
                }
                case 14: {
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
                case 15: {
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
                case 16: {
                    var parent2 = (ScalarExpressionDialogOption)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 17: {
                    var parent2 = (TopRowFilter)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 18: {
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
                case 19: {
                    var parent2 = (UnaryExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 20: {
                    var parent2 = (VariableMethodCallTableReference)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 21: {
                    var parent2 = (AlterPartitionFunctionStatement)parent;
                    if (Equals(parent2.Boundary, toReplace)) {
                        parent2.Boundary = replacement;
                        success = true;
                    }
                    break;
                }
                case 22: {
                    var parent2 = (RevertStatement)parent;
                    if (Equals(parent2.Cookie, toReplace)) {
                        parent2.Cookie = replacement;
                        success = true;
                    }
                    break;
                }
                case 23: {
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
                case 24: {
                    var parent2 = (BuiltInFunctionTableReference)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 25: {
                    var parent2 = (GlobalFunctionTableReference)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 26: {
                    var parent2 = (ComputeClause)parent;
                    for (var i = 0; i < parent2.ByExpressions.Count; i++) {
                        if (Equals(parent2.ByExpressions[i], toReplace)) {
                            parent2.ByExpressions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 27: {
                    var parent2 = (ComputeFunction)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 28: {
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
                case 29: {
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
                case 30: {
                    var parent2 = (BooleanIsNullExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 31: {
                    var parent2 = (ExpressionWithSortOrder)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 32: {
                    var parent2 = (ExpressionGroupingSpecification)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 33: {
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
                case 34: {
                    var parent2 = (PredictTableReference)parent;
                    if (Equals(parent2.ModelVariable, toReplace)) {
                        parent2.ModelVariable = replacement;
                        success = true;
                    }
                    break;
                }
                case 35: {
                    var parent2 = (SelectScalarExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 36: {
                    var parent2 = (SelectSetVariable)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 37: {
                    var parent2 = (ChangeTableVersionTableReference)parent;
                    for (var i = 0; i < parent2.PrimaryKeyValues.Count; i++) {
                        if (Equals(parent2.PrimaryKeyValues[i], toReplace)) {
                            parent2.PrimaryKeyValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 38: {
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
                case 39: {
                    var parent2 = (DbccNamedLiteral)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 40: {
                    var parent2 = (CreatePartitionFunctionStatement)parent;
                    for (var i = 0; i < parent2.BoundaryValues.Count; i++) {
                        if (Equals(parent2.BoundaryValues[i], toReplace)) {
                            parent2.BoundaryValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 41: {
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
                case 42: {
                    var parent2 = (TablePartitionOptionSpecifications)parent;
                    for (var i = 0; i < parent2.BoundaryValues.Count; i++) {
                        if (Equals(parent2.BoundaryValues[i], toReplace)) {
                            parent2.BoundaryValues[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 43: {
                    var parent2 = (CopyColumnOption)parent;
                    if (Equals(parent2.DefaultValue, toReplace)) {
                        parent2.DefaultValue = replacement;
                        success = true;
                    }
                    break;
                }
                case 44: {
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
                case 45: {
                    var parent2 = (DefaultConstraintDefinition)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 46: {
                    var parent2 = (ScalarExpressionRestoreOption)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 47: {
                    var parent2 = (BackupOption)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 48: {
                    var parent2 = (BackupEncryptionOption)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 49: {
                    var parent2 = (ColumnDefinition)parent;
                    if (Equals(parent2.ComputedColumnExpression, toReplace)) {
                        parent2.ComputedColumnExpression = replacement;
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
                    var parent2 = (TryCastCall)parent;
                    if (Equals(parent2.Parameter, toReplace)) {
                        parent2.Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 77: {
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
                case 78: {
                    var parent2 = (FunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 79: {
                    var parent2 = (ExpressionCallTarget)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 80: {
                    var parent2 = (LeftFunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 81: {
                    var parent2 = (RightFunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 82: {
                    var parent2 = (PartitionFunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 83: {
                    var parent2 = (OverClause)parent;
                    for (var i = 0; i < parent2.Partitions.Count; i++) {
                        if (Equals(parent2.Partitions[i], toReplace)) {
                            parent2.Partitions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 84: {
                    var parent2 = (WindowDefinition)parent;
                    for (var i = 0; i < parent2.Partitions.Count; i++) {
                        if (Equals(parent2.Partitions[i], toReplace)) {
                            parent2.Partitions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 85: {
                    var parent2 = (OdbcFunctionCall)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 86: {
                    var parent2 = (ExtractFromExpression)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 87: {
                    var parent2 = (CreateDefaultStatement)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 88: {
                    var parent2 = (DeclareVariableElement)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 89: {
                    var parent2 = (ProcedureParameter)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 90: {
                    var parent2 = (WaitForStatement)parent;
                    if (Equals(parent2.Timeout, toReplace)) {
                        parent2.Timeout = replacement;
                        success = true;
                    }
                    break;
                }
                case 91: {
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
                case 92: {
                    var parent2 = (SchemaObjectFunctionTableReference)parent;
                    for (var i = 0; i < parent2.Parameters.Count; i++) {
                        if (Equals(parent2.Parameters[i], toReplace)) {
                            parent2.Parameters[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 93: {
                    var parent2 = (SubqueryComparisonPredicate)parent;
                    if (Equals(parent2.Expression, toReplace)) {
                        parent2.Expression = replacement;
                        success = true;
                    }
                    break;
                }
                case 94: {
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
                case 95: {
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
                case 96: {
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
                case 97: {
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
                case 98: {
                    var parent2 = (VariableValuePair)parent;
                    if (Equals(parent2.Value, toReplace)) {
                        parent2.Value = replacement;
                        success = true;
                    }
                    break;
                }
                case 99: {
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
                case 100: {
                    var parent2 = (SearchedWhenClause)parent;
                    if (Equals(parent2.ThenExpression, toReplace)) {
                        parent2.ThenExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 101: {
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
                case 102: {
                    var parent2 = (SearchedCaseExpression)parent;
                    if (Equals(parent2.ElseExpression, toReplace)) {
                        parent2.ElseExpression = replacement;
                        success = true;
                    }
                    break;
                }
                case 103: {
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
                case 104: {
                    var parent2 = (CoalesceExpression)parent;
                    for (var i = 0; i < parent2.Expressions.Count; i++) {
                        if (Equals(parent2.Expressions[i], toReplace)) {
                            parent2.Expressions[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 105: {
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
                case 106: {
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
                case 107: {
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
                case 108: {
                    var parent2 = (InternalOpenRowset)parent;
                    for (var i = 0; i < parent2.VarArgs.Count; i++) {
                        if (Equals(parent2.VarArgs[i], toReplace)) {
                            parent2.VarArgs[i] = replacement;
                            success = true;
                        }
                    }
                    break;
                }
                case 109: {
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
                case 110: {
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
                case 111: {
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
                case 112: {
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
                case 113: {
                    var parent2 = (CastCall)parent;
                    if (Equals(parent2.Parameter, toReplace)) {
                        parent2.Parameter = replacement;
                        success = true;
                    }
                    break;
                }
                case 114: {
                    var parent2 = (ExecuteContext)parent;
                    if (Equals(parent2.Principal, toReplace)) {
                        parent2.Principal = replacement;
                        success = true;
                    }
                    break;
                }
                case 115: {
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
    }
}