using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class TSqlFragment : IComparable, IComparable<TSqlFragment> {
        public abstract ScriptDom.TSqlFragment ToMutable();
        
        public T ToMutable<T>() where T : ScriptDom.TSqlFragment {
            return (T)ToMutable();
        }
    
        public abstract int CompareTo(object that);
        public abstract int CompareTo(TSqlFragment that);
    
        static readonly IReadOnlyDictionary<string, int> TagNumberByTypeName = new Dictionary<string, int> {
            ["AcceleratedDatabaseRecoveryDatabaseOption"] = 1,
            ["AddAlterFullTextIndexAction"] = 2,
            ["AddFileSpec"] = 3,
            ["AddMemberAlterRoleAction"] = 4,
            ["AddSearchPropertyListAction"] = 5,
            ["AddSensitivityClassificationStatement"] = 6,
            ["AddSignatureStatement"] = 7,
            ["AdHocDataSource"] = 8,
            ["AdHocTableReference"] = 9,
            ["AIAnalyzeSentimentFunctionCall"] = 10,
            ["AIClassifyFunctionCall"] = 11,
            ["AIExtractFunctionCall"] = 12,
            ["AIFixGrammarFunctionCall"] = 13,
            ["AIGenerateChunksTableReference"] = 14,
            ["AIGenerateEmbeddingsFunctionCall"] = 15,
            ["AIGenerateFixedChunksTableReference"] = 16,
            ["AIGenerateResponseFunctionCall"] = 17,
            ["AISummarizeFunctionCall"] = 18,
            ["AITranslateFunctionCall"] = 19,
            ["AlgorithmKeyOption"] = 20,
            ["AlterApplicationRoleStatement"] = 21,
            ["AlterAssemblyStatement"] = 22,
            ["AlterAsymmetricKeyStatement"] = 23,
            ["AlterAuthorizationStatement"] = 24,
            ["AlterAvailabilityGroupAction"] = 25,
            ["AlterAvailabilityGroupFailoverAction"] = 26,
            ["AlterAvailabilityGroupFailoverOption"] = 27,
            ["AlterAvailabilityGroupStatement"] = 28,
            ["AlterBrokerPriorityStatement"] = 29,
            ["AlterCertificateStatement"] = 30,
            ["AlterColumnAlterFullTextIndexAction"] = 31,
            ["AlterColumnEncryptionKeyStatement"] = 32,
            ["AlterCredentialStatement"] = 33,
            ["AlterCryptographicProviderStatement"] = 34,
            ["AlterDatabaseAddFileGroupStatement"] = 35,
            ["AlterDatabaseAddFileStatement"] = 36,
            ["AlterDatabaseAuditSpecificationStatement"] = 37,
            ["AlterDatabaseCollateStatement"] = 38,
            ["AlterDatabaseEncryptionKeyStatement"] = 39,
            ["AlterDatabaseModifyFileGroupStatement"] = 40,
            ["AlterDatabaseModifyFileStatement"] = 41,
            ["AlterDatabaseModifyNameStatement"] = 42,
            ["AlterDatabasePerformCutoverStatement"] = 43,
            ["AlterDatabaseRebuildLogStatement"] = 44,
            ["AlterDatabaseRemoveFileGroupStatement"] = 45,
            ["AlterDatabaseRemoveFileStatement"] = 46,
            ["AlterDatabaseScopedConfigurationClearStatement"] = 47,
            ["AlterDatabaseScopedConfigurationSetStatement"] = 48,
            ["AlterDatabaseSetStatement"] = 49,
            ["AlterDatabaseTermination"] = 50,
            ["AlterEndpointStatement"] = 51,
            ["AlterEventSessionStatement"] = 52,
            ["AlterExternalDataSourceStatement"] = 53,
            ["AlterExternalFunctionStatement"] = 54,
            ["AlterExternalLanguageStatement"] = 55,
            ["AlterExternalLibraryStatement"] = 56,
            ["AlterExternalModelStatement"] = 57,
            ["AlterExternalResourcePoolStatement"] = 58,
            ["AlterFederationStatement"] = 59,
            ["AlterFullTextCatalogStatement"] = 60,
            ["AlterFullTextIndexStatement"] = 61,
            ["AlterFullTextStopListStatement"] = 62,
            ["AlterFunctionStatement"] = 63,
            ["AlterIndexStatement"] = 64,
            ["AlterLoginAddDropCredentialStatement"] = 65,
            ["AlterLoginEnableDisableStatement"] = 66,
            ["AlterLoginOptionsStatement"] = 67,
            ["AlterMasterKeyStatement"] = 68,
            ["AlterMessageTypeStatement"] = 69,
            ["AlterPartitionFunctionStatement"] = 70,
            ["AlterPartitionSchemeStatement"] = 71,
            ["AlterProcedureStatement"] = 72,
            ["AlterQueueStatement"] = 73,
            ["AlterRemoteServiceBindingStatement"] = 74,
            ["AlterResourceGovernorStatement"] = 75,
            ["AlterResourcePoolStatement"] = 76,
            ["AlterRoleStatement"] = 77,
            ["AlterRouteStatement"] = 78,
            ["AlterSchemaStatement"] = 79,
            ["AlterSearchPropertyListStatement"] = 80,
            ["AlterSecurityPolicyStatement"] = 81,
            ["AlterSequenceStatement"] = 82,
            ["AlterServerAuditSpecificationStatement"] = 83,
            ["AlterServerAuditStatement"] = 84,
            ["AlterServerConfigurationBufferPoolExtensionContainerOption"] = 85,
            ["AlterServerConfigurationBufferPoolExtensionOption"] = 86,
            ["AlterServerConfigurationBufferPoolExtensionSizeOption"] = 87,
            ["AlterServerConfigurationDiagnosticsLogMaxSizeOption"] = 88,
            ["AlterServerConfigurationDiagnosticsLogOption"] = 89,
            ["AlterServerConfigurationExternalAuthenticationContainerOption"] = 90,
            ["AlterServerConfigurationExternalAuthenticationOption"] = 91,
            ["AlterServerConfigurationFailoverClusterPropertyOption"] = 92,
            ["AlterServerConfigurationHadrClusterOption"] = 93,
            ["AlterServerConfigurationSetBufferPoolExtensionStatement"] = 94,
            ["AlterServerConfigurationSetDiagnosticsLogStatement"] = 95,
            ["AlterServerConfigurationSetExternalAuthenticationStatement"] = 96,
            ["AlterServerConfigurationSetFailoverClusterPropertyStatement"] = 97,
            ["AlterServerConfigurationSetHadrClusterStatement"] = 98,
            ["AlterServerConfigurationSetSoftNumaStatement"] = 99,
            ["AlterServerConfigurationSoftNumaOption"] = 100,
            ["AlterServerConfigurationStatement"] = 101,
            ["AlterServerRoleStatement"] = 102,
            ["AlterServiceMasterKeyStatement"] = 103,
            ["AlterServiceStatement"] = 104,
            ["AlterSymmetricKeyStatement"] = 105,
            ["AlterTableAddClusterByStatement"] = 106,
            ["AlterTableAddTableElementStatement"] = 107,
            ["AlterTableAlterColumnStatement"] = 108,
            ["AlterTableAlterIndexStatement"] = 109,
            ["AlterTableAlterPartitionStatement"] = 110,
            ["AlterTableChangeTrackingModificationStatement"] = 111,
            ["AlterTableConstraintModificationStatement"] = 112,
            ["AlterTableDropTableElement"] = 113,
            ["AlterTableDropTableElementStatement"] = 114,
            ["AlterTableFileTableNamespaceStatement"] = 115,
            ["AlterTableRebuildStatement"] = 116,
            ["AlterTableSetStatement"] = 117,
            ["AlterTableSwitchStatement"] = 118,
            ["AlterTableTriggerModificationStatement"] = 119,
            ["AlterTriggerStatement"] = 120,
            ["AlterUserStatement"] = 121,
            ["AlterViewStatement"] = 122,
            ["AlterWorkloadGroupStatement"] = 123,
            ["AlterXmlSchemaCollectionStatement"] = 124,
            ["ApplicationRoleOption"] = 125,
            ["AssemblyEncryptionSource"] = 126,
            ["AssemblyName"] = 127,
            ["AssemblyOption"] = 128,
            ["AssignmentSetClause"] = 129,
            ["AsymmetricKeyCreateLoginSource"] = 130,
            ["AtTimeZoneCall"] = 131,
            ["AuditActionGroupReference"] = 132,
            ["AuditActionSpecification"] = 133,
            ["AuditGuidAuditOption"] = 134,
            ["AuditSpecificationPart"] = 135,
            ["AuditTarget"] = 136,
            ["AuthenticationEndpointProtocolOption"] = 137,
            ["AuthenticationPayloadOption"] = 138,
            ["AutoCleanupChangeTrackingOptionDetail"] = 139,
            ["AutoCreateStatisticsDatabaseOption"] = 140,
            ["AutomaticTuningCreateIndexOption"] = 141,
            ["AutomaticTuningDatabaseOption"] = 142,
            ["AutomaticTuningDropIndexOption"] = 143,
            ["AutomaticTuningForceLastGoodPlanOption"] = 144,
            ["AutomaticTuningMaintainIndexOption"] = 145,
            ["AutomaticTuningOption"] = 146,
            ["AvailabilityModeReplicaOption"] = 147,
            ["AvailabilityReplica"] = 148,
            ["BackupCertificateStatement"] = 149,
            ["BackupDatabaseStatement"] = 150,
            ["BackupEncryptionOption"] = 151,
            ["BackupMasterKeyStatement"] = 152,
            ["BackupOption"] = 153,
            ["BackupRestoreFileInfo"] = 154,
            ["BackupServiceMasterKeyStatement"] = 155,
            ["BackupTransactionLogStatement"] = 156,
            ["BackwardsCompatibleDropIndexClause"] = 157,
            ["BeginConversationTimerStatement"] = 158,
            ["BeginDialogStatement"] = 159,
            ["BeginEndAtomicBlockStatement"] = 160,
            ["BeginEndBlockStatement"] = 161,
            ["BeginTransactionStatement"] = 162,
            ["BinaryExpression"] = 163,
            ["BinaryLiteral"] = 164,
            ["BinaryQueryExpression"] = 165,
            ["BooleanBinaryExpression"] = 166,
            ["BooleanComparisonExpression"] = 167,
            ["BooleanExpressionSnippet"] = 168,
            ["BooleanIsNullExpression"] = 169,
            ["BooleanNotExpression"] = 170,
            ["BooleanParenthesisExpression"] = 171,
            ["BooleanTernaryExpression"] = 172,
            ["BoundingBoxParameter"] = 173,
            ["BoundingBoxSpatialIndexOption"] = 174,
            ["BreakStatement"] = 175,
            ["BrokerPriorityParameter"] = 176,
            ["BrowseForClause"] = 177,
            ["BuiltInFunctionTableReference"] = 178,
            ["BulkInsertOption"] = 179,
            ["BulkInsertStatement"] = 180,
            ["BulkOpenRowset"] = 181,
            ["CastCall"] = 182,
            ["CatalogCollationOption"] = 183,
            ["CellsPerObjectSpatialIndexOption"] = 184,
            ["CertificateCreateLoginSource"] = 185,
            ["CertificateOption"] = 186,
            ["ChangeRetentionChangeTrackingOptionDetail"] = 187,
            ["ChangeTableChangesTableReference"] = 188,
            ["ChangeTableVersionTableReference"] = 189,
            ["ChangeTrackingDatabaseOption"] = 190,
            ["ChangeTrackingFullTextIndexOption"] = 191,
            ["CharacterSetPayloadOption"] = 192,
            ["CheckConstraintDefinition"] = 193,
            ["CheckpointStatement"] = 194,
            ["ChildObjectName"] = 195,
            ["ClassifierEndTimeOption"] = 196,
            ["ClassifierImportanceOption"] = 197,
            ["ClassifierMemberNameOption"] = 198,
            ["ClassifierStartTimeOption"] = 199,
            ["ClassifierWlmContextOption"] = 200,
            ["ClassifierWlmLabelOption"] = 201,
            ["ClassifierWorkloadGroupOption"] = 202,
            ["CloseCursorStatement"] = 203,
            ["CloseMasterKeyStatement"] = 204,
            ["CloseSymmetricKeyStatement"] = 205,
            ["ClusterByTableOption"] = 206,
            ["CoalesceExpression"] = 207,
            ["ColumnDefinition"] = 208,
            ["ColumnDefinitionBase"] = 209,
            ["ColumnEncryptionAlgorithmNameParameter"] = 210,
            ["ColumnEncryptionAlgorithmParameter"] = 211,
            ["ColumnEncryptionDefinition"] = 212,
            ["ColumnEncryptionKeyNameParameter"] = 213,
            ["ColumnEncryptionKeyValue"] = 214,
            ["ColumnEncryptionTypeParameter"] = 215,
            ["ColumnMasterKeyEnclaveComputationsParameter"] = 216,
            ["ColumnMasterKeyNameParameter"] = 217,
            ["ColumnMasterKeyPathParameter"] = 218,
            ["ColumnMasterKeyStoreProviderNameParameter"] = 219,
            ["ColumnReferenceExpression"] = 220,
            ["ColumnStorageOptions"] = 221,
            ["ColumnWithSortOrder"] = 222,
            ["CommandSecurityElement80"] = 223,
            ["CommitTransactionStatement"] = 224,
            ["CommonTableExpression"] = 225,
            ["CompositeGroupingSpecification"] = 226,
            ["CompressionDelayIndexOption"] = 227,
            ["CompressionEndpointProtocolOption"] = 228,
            ["CompressionPartitionRange"] = 229,
            ["ComputeClause"] = 230,
            ["ComputeFunction"] = 231,
            ["ContainmentDatabaseOption"] = 232,
            ["ContinueStatement"] = 233,
            ["ContractMessage"] = 234,
            ["ConvertCall"] = 235,
            ["CopyColumnOption"] = 236,
            ["CopyCredentialOption"] = 237,
            ["CopyOption"] = 238,
            ["CopyStatement"] = 239,
            ["CreateAggregateStatement"] = 240,
            ["CreateApplicationRoleStatement"] = 241,
            ["CreateAssemblyStatement"] = 242,
            ["CreateAsymmetricKeyStatement"] = 243,
            ["CreateAvailabilityGroupStatement"] = 244,
            ["CreateBrokerPriorityStatement"] = 245,
            ["CreateCertificateStatement"] = 246,
            ["CreateColumnEncryptionKeyStatement"] = 247,
            ["CreateColumnMasterKeyStatement"] = 248,
            ["CreateColumnStoreIndexStatement"] = 249,
            ["CreateContractStatement"] = 250,
            ["CreateCredentialStatement"] = 251,
            ["CreateCryptographicProviderStatement"] = 252,
            ["CreateDatabaseAuditSpecificationStatement"] = 253,
            ["CreateDatabaseEncryptionKeyStatement"] = 254,
            ["CreateDatabaseStatement"] = 255,
            ["CreateDefaultStatement"] = 256,
            ["CreateEndpointStatement"] = 257,
            ["CreateEventNotificationStatement"] = 258,
            ["CreateEventSessionStatement"] = 259,
            ["CreateExternalDataSourceStatement"] = 260,
            ["CreateExternalFileFormatStatement"] = 261,
            ["CreateExternalFunctionStatement"] = 262,
            ["CreateExternalLanguageStatement"] = 263,
            ["CreateExternalLibraryStatement"] = 264,
            ["CreateExternalModelStatement"] = 265,
            ["CreateExternalResourcePoolStatement"] = 266,
            ["CreateExternalStreamingJobStatement"] = 267,
            ["CreateExternalStreamStatement"] = 268,
            ["CreateExternalTableStatement"] = 269,
            ["CreateFederationStatement"] = 270,
            ["CreateFullTextCatalogStatement"] = 271,
            ["CreateFullTextIndexStatement"] = 272,
            ["CreateFullTextStopListStatement"] = 273,
            ["CreateFunctionStatement"] = 274,
            ["CreateIndexStatement"] = 275,
            ["CreateJsonIndexStatement"] = 276,
            ["CreateLoginStatement"] = 277,
            ["CreateMasterKeyStatement"] = 278,
            ["CreateMessageTypeStatement"] = 279,
            ["CreateOrAlterExternalFunctionStatement"] = 280,
            ["CreateOrAlterFunctionStatement"] = 281,
            ["CreateOrAlterProcedureStatement"] = 282,
            ["CreateOrAlterTriggerStatement"] = 283,
            ["CreateOrAlterViewStatement"] = 284,
            ["CreatePartitionFunctionStatement"] = 285,
            ["CreatePartitionSchemeStatement"] = 286,
            ["CreateProcedureStatement"] = 287,
            ["CreateQueueStatement"] = 288,
            ["CreateRemoteServiceBindingStatement"] = 289,
            ["CreateResourcePoolStatement"] = 290,
            ["CreateRoleStatement"] = 291,
            ["CreateRouteStatement"] = 292,
            ["CreateRuleStatement"] = 293,
            ["CreateSchemaStatement"] = 294,
            ["CreateSearchPropertyListStatement"] = 295,
            ["CreateSecurityPolicyStatement"] = 296,
            ["CreateSelectiveXmlIndexStatement"] = 297,
            ["CreateSemanticIndexStatement"] = 298,
            ["CreateSequenceStatement"] = 299,
            ["CreateServerAuditSpecificationStatement"] = 300,
            ["CreateServerAuditStatement"] = 301,
            ["CreateServerRoleStatement"] = 302,
            ["CreateServiceStatement"] = 303,
            ["CreateSpatialIndexStatement"] = 304,
            ["CreateStatisticsStatement"] = 305,
            ["CreateSymmetricKeyStatement"] = 306,
            ["CreateSynonymStatement"] = 307,
            ["CreateTableStatement"] = 308,
            ["CreateTriggerStatement"] = 309,
            ["CreateTypeTableStatement"] = 310,
            ["CreateTypeUddtStatement"] = 311,
            ["CreateTypeUdtStatement"] = 312,
            ["CreateUserStatement"] = 313,
            ["CreateVectorIndexStatement"] = 314,
            ["CreateViewStatement"] = 315,
            ["CreateWorkloadClassifierStatement"] = 316,
            ["CreateWorkloadGroupStatement"] = 317,
            ["CreateXmlIndexStatement"] = 318,
            ["CreateXmlSchemaCollectionStatement"] = 319,
            ["CreationDispositionKeyOption"] = 320,
            ["CryptoMechanism"] = 321,
            ["CubeGroupingSpecification"] = 322,
            ["CursorDefaultDatabaseOption"] = 323,
            ["CursorDefinition"] = 324,
            ["CursorId"] = 325,
            ["CursorOption"] = 326,
            ["DatabaseAuditAction"] = 327,
            ["DatabaseConfigurationClearOption"] = 328,
            ["DatabaseConfigurationSetOption"] = 329,
            ["DatabaseOption"] = 330,
            ["DataCompressionOption"] = 331,
            ["DataModificationTableReference"] = 332,
            ["DataRetentionTableOption"] = 333,
            ["DataTypeSequenceOption"] = 334,
            ["DbccNamedLiteral"] = 335,
            ["DbccOption"] = 336,
            ["DbccStatement"] = 337,
            ["DeallocateCursorStatement"] = 338,
            ["DeclareCursorStatement"] = 339,
            ["DeclareTableVariableBody"] = 340,
            ["DeclareTableVariableStatement"] = 341,
            ["DeclareVariableElement"] = 342,
            ["DeclareVariableStatement"] = 343,
            ["DefaultConstraintDefinition"] = 344,
            ["DefaultLiteral"] = 345,
            ["DelayedDurabilityDatabaseOption"] = 346,
            ["DeleteMergeAction"] = 347,
            ["DeleteSpecification"] = 348,
            ["DeleteStatement"] = 349,
            ["DenyStatement"] = 350,
            ["DenyStatement80"] = 351,
            ["DeviceInfo"] = 352,
            ["DiskStatement"] = 353,
            ["DiskStatementOption"] = 354,
            ["DistinctPredicate"] = 355,
            ["DropAggregateStatement"] = 356,
            ["DropAlterFullTextIndexAction"] = 357,
            ["DropApplicationRoleStatement"] = 358,
            ["DropAssemblyStatement"] = 359,
            ["DropAsymmetricKeyStatement"] = 360,
            ["DropAvailabilityGroupStatement"] = 361,
            ["DropBrokerPriorityStatement"] = 362,
            ["DropCertificateStatement"] = 363,
            ["DropClusteredConstraintMoveOption"] = 364,
            ["DropClusteredConstraintStateOption"] = 365,
            ["DropClusteredConstraintValueOption"] = 366,
            ["DropClusteredConstraintWaitAtLowPriorityLockOption"] = 367,
            ["DropColumnEncryptionKeyStatement"] = 368,
            ["DropColumnMasterKeyStatement"] = 369,
            ["DropContractStatement"] = 370,
            ["DropCredentialStatement"] = 371,
            ["DropCryptographicProviderStatement"] = 372,
            ["DropDatabaseAuditSpecificationStatement"] = 373,
            ["DropDatabaseEncryptionKeyStatement"] = 374,
            ["DropDatabaseStatement"] = 375,
            ["DropDefaultStatement"] = 376,
            ["DropEndpointStatement"] = 377,
            ["DropEventNotificationStatement"] = 378,
            ["DropEventSessionStatement"] = 379,
            ["DropExternalDataSourceStatement"] = 380,
            ["DropExternalFileFormatStatement"] = 381,
            ["DropExternalLanguageStatement"] = 382,
            ["DropExternalLibraryStatement"] = 383,
            ["DropExternalModelStatement"] = 384,
            ["DropExternalResourcePoolStatement"] = 385,
            ["DropExternalStreamingJobStatement"] = 386,
            ["DropExternalStreamStatement"] = 387,
            ["DropExternalTableStatement"] = 388,
            ["DropFederationStatement"] = 389,
            ["DropFullTextCatalogStatement"] = 390,
            ["DropFullTextIndexStatement"] = 391,
            ["DropFullTextStopListStatement"] = 392,
            ["DropFunctionStatement"] = 393,
            ["DropIndexClause"] = 394,
            ["DropIndexStatement"] = 395,
            ["DropLoginStatement"] = 396,
            ["DropMasterKeyStatement"] = 397,
            ["DropMemberAlterRoleAction"] = 398,
            ["DropMessageTypeStatement"] = 399,
            ["DropPartitionFunctionStatement"] = 400,
            ["DropPartitionSchemeStatement"] = 401,
            ["DropProcedureStatement"] = 402,
            ["DropQueueStatement"] = 403,
            ["DropRemoteServiceBindingStatement"] = 404,
            ["DropResourcePoolStatement"] = 405,
            ["DropRoleStatement"] = 406,
            ["DropRouteStatement"] = 407,
            ["DropRuleStatement"] = 408,
            ["DropSchemaStatement"] = 409,
            ["DropSearchPropertyListAction"] = 410,
            ["DropSearchPropertyListStatement"] = 411,
            ["DropSecurityPolicyStatement"] = 412,
            ["DropSensitivityClassificationStatement"] = 413,
            ["DropSequenceStatement"] = 414,
            ["DropServerAuditSpecificationStatement"] = 415,
            ["DropServerAuditStatement"] = 416,
            ["DropServerRoleStatement"] = 417,
            ["DropServiceStatement"] = 418,
            ["DropSignatureStatement"] = 419,
            ["DropStatisticsStatement"] = 420,
            ["DropSymmetricKeyStatement"] = 421,
            ["DropSynonymStatement"] = 422,
            ["DropTableStatement"] = 423,
            ["DropTriggerStatement"] = 424,
            ["DropTypeStatement"] = 425,
            ["DropUserStatement"] = 426,
            ["DropViewStatement"] = 427,
            ["DropWorkloadClassifierStatement"] = 428,
            ["DropWorkloadGroupStatement"] = 429,
            ["DropXmlSchemaCollectionStatement"] = 430,
            ["DurabilityTableOption"] = 431,
            ["DWCompatibilityLevelConfigurationOption"] = 432,
            ["ElasticPoolSpecification"] = 433,
            ["EnabledDisabledPayloadOption"] = 434,
            ["EnableDisableTriggerStatement"] = 435,
            ["EncryptedValueParameter"] = 436,
            ["EncryptionPayloadOption"] = 437,
            ["EndConversationStatement"] = 438,
            ["EndpointAffinity"] = 439,
            ["EventDeclaration"] = 440,
            ["EventDeclarationCompareFunctionParameter"] = 441,
            ["EventDeclarationSetParameter"] = 442,
            ["EventGroupContainer"] = 443,
            ["EventNotificationObjectScope"] = 444,
            ["EventRetentionSessionOption"] = 445,
            ["EventSessionObjectName"] = 446,
            ["EventSessionStatement"] = 447,
            ["EventTypeContainer"] = 448,
            ["ExecutableProcedureReference"] = 449,
            ["ExecutableStringList"] = 450,
            ["ExecuteAsClause"] = 451,
            ["ExecuteAsFunctionOption"] = 452,
            ["ExecuteAsProcedureOption"] = 453,
            ["ExecuteAsStatement"] = 454,
            ["ExecuteAsTriggerOption"] = 455,
            ["ExecuteContext"] = 456,
            ["ExecuteInsertSource"] = 457,
            ["ExecuteOption"] = 458,
            ["ExecuteParameter"] = 459,
            ["ExecuteSpecification"] = 460,
            ["ExecuteStatement"] = 461,
            ["ExistsPredicate"] = 462,
            ["ExpressionCallTarget"] = 463,
            ["ExpressionGroupingSpecification"] = 464,
            ["ExpressionWithSortOrder"] = 465,
            ["ExternalCreateLoginSource"] = 466,
            ["ExternalDataSourceLiteralOrIdentifierOption"] = 467,
            ["ExternalFileFormatContainerOption"] = 468,
            ["ExternalFileFormatLiteralOption"] = 469,
            ["ExternalFileFormatUseDefaultTypeOption"] = 470,
            ["ExternalLanguageFileOption"] = 471,
            ["ExternalLibraryFileOption"] = 472,
            ["ExternalModelTypeSpecification"] = 473,
            ["ExternalResourcePoolAffinitySpecification"] = 474,
            ["ExternalResourcePoolParameter"] = 475,
            ["ExternalResourcePoolStatement"] = 476,
            ["ExternalStreamLiteralOrIdentifierOption"] = 477,
            ["ExternalTableColumnDefinition"] = 478,
            ["ExternalTableDistributionOption"] = 479,
            ["ExternalTableLiteralOrIdentifierOption"] = 480,
            ["ExternalTableRejectTypeOption"] = 481,
            ["ExternalTableReplicatedDistributionPolicy"] = 482,
            ["ExternalTableRoundRobinDistributionPolicy"] = 483,
            ["ExternalTableShardedDistributionPolicy"] = 484,
            ["ExtractFromExpression"] = 485,
            ["FailoverModeReplicaOption"] = 486,
            ["FederationScheme"] = 487,
            ["FetchCursorStatement"] = 488,
            ["FetchType"] = 489,
            ["FileDeclaration"] = 490,
            ["FileDeclarationOption"] = 491,
            ["FileEncryptionSource"] = 492,
            ["FileGroupDefinition"] = 493,
            ["FileGroupOrPartitionScheme"] = 494,
            ["FileGrowthFileDeclarationOption"] = 495,
            ["FileNameFileDeclarationOption"] = 496,
            ["FileStreamDatabaseOption"] = 497,
            ["FileStreamOnDropIndexOption"] = 498,
            ["FileStreamOnTableOption"] = 499,
            ["FileStreamRestoreOption"] = 500,
            ["FileTableCollateFileNameTableOption"] = 501,
            ["FileTableConstraintNameTableOption"] = 502,
            ["FileTableDirectoryTableOption"] = 503,
            ["ForceSeekTableHint"] = 504,
            ["ForeignKeyConstraintDefinition"] = 505,
            ["FromClause"] = 506,
            ["FullTextCatalogAndFileGroup"] = 507,
            ["FullTextIndexColumn"] = 508,
            ["FullTextPredicate"] = 509,
            ["FullTextStopListAction"] = 510,
            ["FullTextTableReference"] = 511,
            ["FunctionCall"] = 512,
            ["FunctionCallSetClause"] = 513,
            ["FunctionOption"] = 514,
            ["GeneralSetCommand"] = 515,
            ["GenericConfigurationOption"] = 516,
            ["GetConversationGroupStatement"] = 517,
            ["GlobalFunctionTableReference"] = 518,
            ["GlobalVariableExpression"] = 519,
            ["GoToStatement"] = 520,
            ["GrandTotalGroupingSpecification"] = 521,
            ["GrantStatement"] = 522,
            ["GrantStatement80"] = 523,
            ["GraphConnectionBetweenNodes"] = 524,
            ["GraphConnectionConstraintDefinition"] = 525,
            ["GraphMatchCompositeExpression"] = 526,
            ["GraphMatchExpression"] = 527,
            ["GraphMatchLastNodePredicate"] = 528,
            ["GraphMatchNodeExpression"] = 529,
            ["GraphMatchPredicate"] = 530,
            ["GraphMatchRecursivePredicate"] = 531,
            ["GraphRecursiveMatchQuantifier"] = 532,
            ["GridParameter"] = 533,
            ["GridsSpatialIndexOption"] = 534,
            ["GroupByClause"] = 535,
            ["GroupingSetsGroupingSpecification"] = 536,
            ["HadrAvailabilityGroupDatabaseOption"] = 537,
            ["HadrDatabaseOption"] = 538,
            ["HavingClause"] = 539,
            ["Identifier"] = 540,
            ["IdentifierAtomicBlockOption"] = 541,
            ["IdentifierDatabaseOption"] = 542,
            ["IdentifierLiteral"] = 543,
            ["IdentifierOrScalarExpression"] = 544,
            ["IdentifierOrValueExpression"] = 545,
            ["IdentifierPrincipalOption"] = 546,
            ["IdentifierSnippet"] = 547,
            ["IdentityFunctionCall"] = 548,
            ["IdentityOptions"] = 549,
            ["IdentityValueKeyOption"] = 550,
            ["IfStatement"] = 551,
            ["IgnoreDupKeyIndexOption"] = 552,
            ["IIfCall"] = 553,
            ["IndexDefinition"] = 554,
            ["IndexExpressionOption"] = 555,
            ["IndexStateOption"] = 556,
            ["IndexTableHint"] = 557,
            ["IndexType"] = 558,
            ["InlineDerivedTable"] = 559,
            ["InlineFunctionOption"] = 560,
            ["InlineResultSetDefinition"] = 561,
            ["InPredicate"] = 562,
            ["InsertBulkColumnDefinition"] = 563,
            ["InsertBulkStatement"] = 564,
            ["InsertMergeAction"] = 565,
            ["InsertSpecification"] = 566,
            ["InsertStatement"] = 567,
            ["IntegerLiteral"] = 568,
            ["InternalOpenRowset"] = 569,
            ["InvokeExternalApiFunctionCall"] = 570,
            ["IPv4"] = 571,
            ["JoinParenthesisTableReference"] = 572,
            ["JsonForClause"] = 573,
            ["JsonForClauseOption"] = 574,
            ["JsonKeyValue"] = 575,
            ["KeySourceKeyOption"] = 576,
            ["KillQueryNotificationSubscriptionStatement"] = 577,
            ["KillStatement"] = 578,
            ["KillStatsJobStatement"] = 579,
            ["LabelStatement"] = 580,
            ["LedgerOption"] = 581,
            ["LedgerTableOption"] = 582,
            ["LedgerViewOption"] = 583,
            ["LeftFunctionCall"] = 584,
            ["LikePredicate"] = 585,
            ["LineNoStatement"] = 586,
            ["ListenerIPEndpointProtocolOption"] = 587,
            ["ListTypeCopyOption"] = 588,
            ["LiteralAtomicBlockOption"] = 589,
            ["LiteralAuditTargetOption"] = 590,
            ["LiteralAvailabilityGroupOption"] = 591,
            ["LiteralBulkInsertOption"] = 592,
            ["LiteralDatabaseOption"] = 593,
            ["LiteralEndpointProtocolOption"] = 594,
            ["LiteralOpenRowsetCosmosOption"] = 595,
            ["LiteralOptimizerHint"] = 596,
            ["LiteralOptionValue"] = 597,
            ["LiteralPayloadOption"] = 598,
            ["LiteralPrincipalOption"] = 599,
            ["LiteralRange"] = 600,
            ["LiteralReplicaOption"] = 601,
            ["LiteralSessionOption"] = 602,
            ["LiteralStatisticsOption"] = 603,
            ["LiteralTableHint"] = 604,
            ["LocationOption"] = 605,
            ["LockEscalationTableOption"] = 606,
            ["LoginTypePayloadOption"] = 607,
            ["LowPriorityLockWaitAbortAfterWaitOption"] = 608,
            ["LowPriorityLockWaitMaxDurationOption"] = 609,
            ["LowPriorityLockWaitTableSwitchOption"] = 610,
            ["MaxDispatchLatencySessionOption"] = 611,
            ["MaxDopConfigurationOption"] = 612,
            ["MaxDurationOption"] = 613,
            ["MaxLiteral"] = 614,
            ["MaxRolloverFilesAuditTargetOption"] = 615,
            ["MaxSizeAuditTargetOption"] = 616,
            ["MaxSizeDatabaseOption"] = 617,
            ["MaxSizeFileDeclarationOption"] = 618,
            ["MemoryOptimizedTableOption"] = 619,
            ["MemoryPartitionSessionOption"] = 620,
            ["MergeActionClause"] = 621,
            ["MergeSpecification"] = 622,
            ["MergeStatement"] = 623,
            ["MethodSpecifier"] = 624,
            ["MirrorToClause"] = 625,
            ["MoneyLiteral"] = 626,
            ["MoveConversationStatement"] = 627,
            ["MoveRestoreOption"] = 628,
            ["MoveToDropIndexOption"] = 629,
            ["MultiPartIdentifier"] = 630,
            ["MultiPartIdentifierCallTarget"] = 631,
            ["NamedTableReference"] = 632,
            ["NameFileDeclarationOption"] = 633,
            ["NextValueForExpression"] = 634,
            ["NullableConstraintDefinition"] = 635,
            ["NullIfExpression"] = 636,
            ["NullLiteral"] = 637,
            ["NumericLiteral"] = 638,
            ["OdbcConvertSpecification"] = 639,
            ["OdbcFunctionCall"] = 640,
            ["OdbcLiteral"] = 641,
            ["OdbcQualifiedJoinTableReference"] = 642,
            ["OffsetClause"] = 643,
            ["OnFailureAuditOption"] = 644,
            ["OnlineIndexLowPriorityLockWaitOption"] = 645,
            ["OnlineIndexOption"] = 646,
            ["OnOffAssemblyOption"] = 647,
            ["OnOffAtomicBlockOption"] = 648,
            ["OnOffAuditTargetOption"] = 649,
            ["OnOffDatabaseOption"] = 650,
            ["OnOffDialogOption"] = 651,
            ["OnOffFullTextCatalogOption"] = 652,
            ["OnOffOptionValue"] = 653,
            ["OnOffPrimaryConfigurationOption"] = 654,
            ["OnOffPrincipalOption"] = 655,
            ["OnOffRemoteServiceBindingOption"] = 656,
            ["OnOffSessionOption"] = 657,
            ["OnOffStatisticsOption"] = 658,
            ["OpenCursorStatement"] = 659,
            ["OpenJsonTableReference"] = 660,
            ["OpenMasterKeyStatement"] = 661,
            ["OpenQueryTableReference"] = 662,
            ["OpenRowsetColumnDefinition"] = 663,
            ["OpenRowsetCosmos"] = 664,
            ["OpenRowsetCosmosOption"] = 665,
            ["OpenRowsetTableReference"] = 666,
            ["OpenSymmetricKeyStatement"] = 667,
            ["OpenXmlTableReference"] = 668,
            ["OperatorAuditOption"] = 669,
            ["OptimizedLockingDatabaseOption"] = 670,
            ["OptimizeForOptimizerHint"] = 671,
            ["OptimizerHint"] = 672,
            ["OrderBulkInsertOption"] = 673,
            ["OrderByClause"] = 674,
            ["OrderIndexOption"] = 675,
            ["OutputClause"] = 676,
            ["OutputIntoClause"] = 677,
            ["OverClause"] = 678,
            ["PageVerifyDatabaseOption"] = 679,
            ["ParameterizationDatabaseOption"] = 680,
            ["ParameterlessCall"] = 681,
            ["ParenthesisExpression"] = 682,
            ["ParseCall"] = 683,
            ["PartitionFunctionCall"] = 684,
            ["PartitionParameterType"] = 685,
            ["PartitionSpecifier"] = 686,
            ["PartnerDatabaseOption"] = 687,
            ["PasswordAlterPrincipalOption"] = 688,
            ["PasswordCreateLoginSource"] = 689,
            ["Permission"] = 690,
            ["PermissionSetAssemblyOption"] = 691,
            ["PivotedTableReference"] = 692,
            ["PortsEndpointProtocolOption"] = 693,
            ["PredicateSetStatement"] = 694,
            ["PredictTableReference"] = 695,
            ["PrimaryRoleReplicaOption"] = 696,
            ["PrincipalOption"] = 697,
            ["PrintStatement"] = 698,
            ["Privilege80"] = 699,
            ["PrivilegeSecurityElement80"] = 700,
            ["ProcedureOption"] = 701,
            ["ProcedureParameter"] = 702,
            ["ProcedureReference"] = 703,
            ["ProcedureReferenceName"] = 704,
            ["ProcessAffinityRange"] = 705,
            ["ProviderEncryptionSource"] = 706,
            ["ProviderKeyNameKeyOption"] = 707,
            ["QualifiedJoin"] = 708,
            ["QueryDerivedTable"] = 709,
            ["QueryParenthesisExpression"] = 710,
            ["QuerySpecification"] = 711,
            ["QueryStoreCapturePolicyOption"] = 712,
            ["QueryStoreDatabaseOption"] = 713,
            ["QueryStoreDataFlushIntervalOption"] = 714,
            ["QueryStoreDesiredStateOption"] = 715,
            ["QueryStoreIntervalLengthOption"] = 716,
            ["QueryStoreMaxPlansPerQueryOption"] = 717,
            ["QueryStoreMaxStorageSizeOption"] = 718,
            ["QueryStoreSizeCleanupPolicyOption"] = 719,
            ["QueryStoreTimeCleanupPolicyOption"] = 720,
            ["QueryStoreWaitStatsCaptureOption"] = 721,
            ["QueueDelayAuditOption"] = 722,
            ["QueueExecuteAsOption"] = 723,
            ["QueueOption"] = 724,
            ["QueueProcedureOption"] = 725,
            ["QueueStateOption"] = 726,
            ["QueueValueOption"] = 727,
            ["RaiseErrorLegacyStatement"] = 728,
            ["RaiseErrorStatement"] = 729,
            ["ReadOnlyForClause"] = 730,
            ["ReadTextStatement"] = 731,
            ["RealLiteral"] = 732,
            ["ReceiveStatement"] = 733,
            ["ReconfigureStatement"] = 734,
            ["RecoveryDatabaseOption"] = 735,
            ["RegexpLikePredicate"] = 736,
            ["RemoteDataArchiveAlterTableOption"] = 737,
            ["RemoteDataArchiveDatabaseOption"] = 738,
            ["RemoteDataArchiveDbCredentialSetting"] = 739,
            ["RemoteDataArchiveDbFederatedServiceAccountSetting"] = 740,
            ["RemoteDataArchiveDbServerSetting"] = 741,
            ["RemoteDataArchiveTableOption"] = 742,
            ["RenameAlterRoleAction"] = 743,
            ["RenameEntityStatement"] = 744,
            ["ResampleStatisticsOption"] = 745,
            ["ResourcePoolAffinitySpecification"] = 746,
            ["ResourcePoolParameter"] = 747,
            ["ResourcePoolStatement"] = 748,
            ["RestoreMasterKeyStatement"] = 749,
            ["RestoreOption"] = 750,
            ["RestoreServiceMasterKeyStatement"] = 751,
            ["RestoreStatement"] = 752,
            ["ResultColumnDefinition"] = 753,
            ["ResultSetDefinition"] = 754,
            ["ResultSetsExecuteOption"] = 755,
            ["RetentionDaysAuditTargetOption"] = 756,
            ["RetentionPeriodDefinition"] = 757,
            ["ReturnStatement"] = 758,
            ["RevertStatement"] = 759,
            ["RevokeStatement"] = 760,
            ["RevokeStatement80"] = 761,
            ["RightFunctionCall"] = 762,
            ["RolePayloadOption"] = 763,
            ["RollbackTransactionStatement"] = 764,
            ["RollupGroupingSpecification"] = 765,
            ["RouteOption"] = 766,
            ["RowValue"] = 767,
            ["SaveTransactionStatement"] = 768,
            ["ScalarExpressionDialogOption"] = 769,
            ["ScalarExpressionRestoreOption"] = 770,
            ["ScalarExpressionSequenceOption"] = 771,
            ["ScalarExpressionSnippet"] = 772,
            ["ScalarFunctionReturnType"] = 773,
            ["ScalarSubquery"] = 774,
            ["SchemaDeclarationItem"] = 775,
            ["SchemaDeclarationItemOpenjson"] = 776,
            ["SchemaObjectFunctionTableReference"] = 777,
            ["SchemaObjectName"] = 778,
            ["SchemaObjectNameOrValueExpression"] = 779,
            ["SchemaObjectNameSnippet"] = 780,
            ["SchemaObjectResultSetDefinition"] = 781,
            ["SchemaPayloadOption"] = 782,
            ["SearchedCaseExpression"] = 783,
            ["SearchedWhenClause"] = 784,
            ["SearchPropertyListFullTextIndexOption"] = 785,
            ["SecondaryRoleReplicaOption"] = 786,
            ["SecurityPolicyOption"] = 787,
            ["SecurityPredicateAction"] = 788,
            ["SecurityPrincipal"] = 789,
            ["SecurityTargetObject"] = 790,
            ["SecurityTargetObjectName"] = 791,
            ["SecurityUserClause80"] = 792,
            ["SelectFunctionReturnType"] = 793,
            ["SelectInsertSource"] = 794,
            ["SelectiveXmlIndexPromotedPath"] = 795,
            ["SelectScalarExpression"] = 796,
            ["SelectSetVariable"] = 797,
            ["SelectStarExpression"] = 798,
            ["SelectStatement"] = 799,
            ["SelectStatementSnippet"] = 800,
            ["SemanticIndexChunkOption"] = 801,
            ["SemanticIndexColumn"] = 802,
            ["SemanticTableReference"] = 803,
            ["SendStatement"] = 804,
            ["SensitivityClassificationOption"] = 805,
            ["SequenceOption"] = 806,
            ["ServiceContract"] = 807,
            ["SessionTimeoutPayloadOption"] = 808,
            ["SetCommandStatement"] = 809,
            ["SetErrorLevelStatement"] = 810,
            ["SetFipsFlaggerCommand"] = 811,
            ["SetIdentityInsertStatement"] = 812,
            ["SetOffsetsStatement"] = 813,
            ["SetRowCountStatement"] = 814,
            ["SetSearchPropertyListAlterFullTextIndexAction"] = 815,
            ["SetStatisticsStatement"] = 816,
            ["SetStopListAlterFullTextIndexAction"] = 817,
            ["SetTextSizeStatement"] = 818,
            ["SetTransactionIsolationLevelStatement"] = 819,
            ["SetUserStatement"] = 820,
            ["SetVariableStatement"] = 821,
            ["ShutdownStatement"] = 822,
            ["SimpleAlterFullTextIndexAction"] = 823,
            ["SimpleCaseExpression"] = 824,
            ["SimpleWhenClause"] = 825,
            ["SingleValueTypeCopyOption"] = 826,
            ["SizeFileDeclarationOption"] = 827,
            ["SoapMethod"] = 828,
            ["SourceDeclaration"] = 829,
            ["SpatialIndexRegularOption"] = 830,
            ["SqlCommandIdentifier"] = 831,
            ["SqlDataTypeReference"] = 832,
            ["StateAuditOption"] = 833,
            ["StatementList"] = 834,
            ["StatementListSnippet"] = 835,
            ["StatisticsOption"] = 836,
            ["StatisticsPartitionRange"] = 837,
            ["StopListFullTextIndexOption"] = 838,
            ["StopRestoreOption"] = 839,
            ["StringLiteral"] = 840,
            ["SubqueryComparisonPredicate"] = 841,
            ["SystemTimePeriodDefinition"] = 842,
            ["SystemVersioningTableOption"] = 843,
            ["TableClusteredIndexType"] = 844,
            ["TableDataCompressionOption"] = 845,
            ["TableDefinition"] = 846,
            ["TableDistributionOption"] = 847,
            ["TableHashDistributionPolicy"] = 848,
            ["TableHint"] = 849,
            ["TableHintsOptimizerHint"] = 850,
            ["TableIndexOption"] = 851,
            ["TableNonClusteredIndexType"] = 852,
            ["TablePartitionOption"] = 853,
            ["TablePartitionOptionSpecifications"] = 854,
            ["TableReplicateDistributionPolicy"] = 855,
            ["TableRoundRobinDistributionPolicy"] = 856,
            ["TableSampleClause"] = 857,
            ["TableValuedFunctionReturnType"] = 858,
            ["TableXmlCompressionOption"] = 859,
            ["TargetDeclaration"] = 860,
            ["TargetRecoveryTimeDatabaseOption"] = 861,
            ["TemporalClause"] = 862,
            ["ThrowStatement"] = 863,
            ["TopRowFilter"] = 864,
            ["TriggerAction"] = 865,
            ["TriggerObject"] = 866,
            ["TriggerOption"] = 867,
            ["TruncateTableStatement"] = 868,
            ["TruncateTargetTableSwitchOption"] = 869,
            ["TryCastCall"] = 870,
            ["TryCatchStatement"] = 871,
            ["TryConvertCall"] = 872,
            ["TryParseCall"] = 873,
            ["TSEqualCall"] = 874,
            ["TSqlBatch"] = 875,
            ["TSqlFragmentSnippet"] = 876,
            ["TSqlScript"] = 877,
            ["TSqlStatementSnippet"] = 878,
            ["UnaryExpression"] = 879,
            ["UniqueConstraintDefinition"] = 880,
            ["UnpivotedTableReference"] = 881,
            ["UnqualifiedJoin"] = 882,
            ["UpdateCall"] = 883,
            ["UpdateForClause"] = 884,
            ["UpdateMergeAction"] = 885,
            ["UpdateSpecification"] = 886,
            ["UpdateStatement"] = 887,
            ["UpdateStatisticsStatement"] = 888,
            ["UpdateTextStatement"] = 889,
            ["UseFederationStatement"] = 890,
            ["UseHintList"] = 891,
            ["UserDataTypeReference"] = 892,
            ["UserDefinedTypeCallTarget"] = 893,
            ["UserDefinedTypePropertyAccess"] = 894,
            ["UserLoginOption"] = 895,
            ["UserRemoteServiceBindingOption"] = 896,
            ["UseStatement"] = 897,
            ["ValuesInsertSource"] = 898,
            ["VariableMethodCallTableReference"] = 899,
            ["VariableReference"] = 900,
            ["VariableTableReference"] = 901,
            ["VariableValuePair"] = 902,
            ["VectorDataTypeReference"] = 903,
            ["VectorMetricIndexOption"] = 904,
            ["VectorSearchTableReference"] = 905,
            ["VectorTypeIndexOption"] = 906,
            ["ViewDistributionOption"] = 907,
            ["ViewForAppendOption"] = 908,
            ["ViewHashDistributionPolicy"] = 909,
            ["ViewOption"] = 910,
            ["ViewRoundRobinDistributionPolicy"] = 911,
            ["WaitAtLowPriorityOption"] = 912,
            ["WaitForStatement"] = 913,
            ["WhereClause"] = 914,
            ["WhileStatement"] = 915,
            ["WindowClause"] = 916,
            ["WindowDefinition"] = 917,
            ["WindowDelimiter"] = 918,
            ["WindowFrameClause"] = 919,
            ["WindowsCreateLoginSource"] = 920,
            ["WithCtesAndXmlNamespaces"] = 921,
            ["WithinGroupClause"] = 922,
            ["WitnessDatabaseOption"] = 923,
            ["WlmTimeLiteral"] = 924,
            ["WorkloadGroupImportanceParameter"] = 925,
            ["WorkloadGroupResourceParameter"] = 926,
            ["WriteTextStatement"] = 927,
            ["WsdlPayloadOption"] = 928,
            ["XmlCompressionOption"] = 929,
            ["XmlDataTypeReference"] = 930,
            ["XmlForClause"] = 931,
            ["XmlForClauseOption"] = 932,
            ["XmlNamespaces"] = 933,
            ["XmlNamespacesAliasElement"] = 934,
            ["XmlNamespacesDefaultElement"] = 935,
        };
    
        public static TSqlFragment FromMutable(ScriptDom.TSqlFragment fragment) {
            if (fragment is null) { return null; }
            if (!TagNumberByTypeName.TryGetValue(fragment.GetType().Name, out var tag)) {
                throw new NotImplementedException("Type not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library.");
            }
        
            switch (tag) {
                case 1: return AcceleratedDatabaseRecoveryDatabaseOption.FromMutable(fragment as ScriptDom.AcceleratedDatabaseRecoveryDatabaseOption);
                case 2: return AddAlterFullTextIndexAction.FromMutable(fragment as ScriptDom.AddAlterFullTextIndexAction);
                case 3: return AddFileSpec.FromMutable(fragment as ScriptDom.AddFileSpec);
                case 4: return AddMemberAlterRoleAction.FromMutable(fragment as ScriptDom.AddMemberAlterRoleAction);
                case 5: return AddSearchPropertyListAction.FromMutable(fragment as ScriptDom.AddSearchPropertyListAction);
                case 6: return AddSensitivityClassificationStatement.FromMutable(fragment as ScriptDom.AddSensitivityClassificationStatement);
                case 7: return AddSignatureStatement.FromMutable(fragment as ScriptDom.AddSignatureStatement);
                case 8: return AdHocDataSource.FromMutable(fragment as ScriptDom.AdHocDataSource);
                case 9: return AdHocTableReference.FromMutable(fragment as ScriptDom.AdHocTableReference);
                case 10: return AIAnalyzeSentimentFunctionCall.FromMutable(fragment as ScriptDom.AIAnalyzeSentimentFunctionCall);
                case 11: return AIClassifyFunctionCall.FromMutable(fragment as ScriptDom.AIClassifyFunctionCall);
                case 12: return AIExtractFunctionCall.FromMutable(fragment as ScriptDom.AIExtractFunctionCall);
                case 13: return AIFixGrammarFunctionCall.FromMutable(fragment as ScriptDom.AIFixGrammarFunctionCall);
                case 14: return AIGenerateChunksTableReference.FromMutable(fragment as ScriptDom.AIGenerateChunksTableReference);
                case 15: return AIGenerateEmbeddingsFunctionCall.FromMutable(fragment as ScriptDom.AIGenerateEmbeddingsFunctionCall);
                case 16: return AIGenerateFixedChunksTableReference.FromMutable(fragment as ScriptDom.AIGenerateFixedChunksTableReference);
                case 17: return AIGenerateResponseFunctionCall.FromMutable(fragment as ScriptDom.AIGenerateResponseFunctionCall);
                case 18: return AISummarizeFunctionCall.FromMutable(fragment as ScriptDom.AISummarizeFunctionCall);
                case 19: return AITranslateFunctionCall.FromMutable(fragment as ScriptDom.AITranslateFunctionCall);
                case 20: return AlgorithmKeyOption.FromMutable(fragment as ScriptDom.AlgorithmKeyOption);
                case 21: return AlterApplicationRoleStatement.FromMutable(fragment as ScriptDom.AlterApplicationRoleStatement);
                case 22: return AlterAssemblyStatement.FromMutable(fragment as ScriptDom.AlterAssemblyStatement);
                case 23: return AlterAsymmetricKeyStatement.FromMutable(fragment as ScriptDom.AlterAsymmetricKeyStatement);
                case 24: return AlterAuthorizationStatement.FromMutable(fragment as ScriptDom.AlterAuthorizationStatement);
                case 25: return AlterAvailabilityGroupAction.FromMutable(fragment as ScriptDom.AlterAvailabilityGroupAction);
                case 26: return AlterAvailabilityGroupFailoverAction.FromMutable(fragment as ScriptDom.AlterAvailabilityGroupFailoverAction);
                case 27: return AlterAvailabilityGroupFailoverOption.FromMutable(fragment as ScriptDom.AlterAvailabilityGroupFailoverOption);
                case 28: return AlterAvailabilityGroupStatement.FromMutable(fragment as ScriptDom.AlterAvailabilityGroupStatement);
                case 29: return AlterBrokerPriorityStatement.FromMutable(fragment as ScriptDom.AlterBrokerPriorityStatement);
                case 30: return AlterCertificateStatement.FromMutable(fragment as ScriptDom.AlterCertificateStatement);
                case 31: return AlterColumnAlterFullTextIndexAction.FromMutable(fragment as ScriptDom.AlterColumnAlterFullTextIndexAction);
                case 32: return AlterColumnEncryptionKeyStatement.FromMutable(fragment as ScriptDom.AlterColumnEncryptionKeyStatement);
                case 33: return AlterCredentialStatement.FromMutable(fragment as ScriptDom.AlterCredentialStatement);
                case 34: return AlterCryptographicProviderStatement.FromMutable(fragment as ScriptDom.AlterCryptographicProviderStatement);
                case 35: return AlterDatabaseAddFileGroupStatement.FromMutable(fragment as ScriptDom.AlterDatabaseAddFileGroupStatement);
                case 36: return AlterDatabaseAddFileStatement.FromMutable(fragment as ScriptDom.AlterDatabaseAddFileStatement);
                case 37: return AlterDatabaseAuditSpecificationStatement.FromMutable(fragment as ScriptDom.AlterDatabaseAuditSpecificationStatement);
                case 38: return AlterDatabaseCollateStatement.FromMutable(fragment as ScriptDom.AlterDatabaseCollateStatement);
                case 39: return AlterDatabaseEncryptionKeyStatement.FromMutable(fragment as ScriptDom.AlterDatabaseEncryptionKeyStatement);
                case 40: return AlterDatabaseModifyFileGroupStatement.FromMutable(fragment as ScriptDom.AlterDatabaseModifyFileGroupStatement);
                case 41: return AlterDatabaseModifyFileStatement.FromMutable(fragment as ScriptDom.AlterDatabaseModifyFileStatement);
                case 42: return AlterDatabaseModifyNameStatement.FromMutable(fragment as ScriptDom.AlterDatabaseModifyNameStatement);
                case 43: return AlterDatabasePerformCutoverStatement.FromMutable(fragment as ScriptDom.AlterDatabasePerformCutoverStatement);
                case 44: return AlterDatabaseRebuildLogStatement.FromMutable(fragment as ScriptDom.AlterDatabaseRebuildLogStatement);
                case 45: return AlterDatabaseRemoveFileGroupStatement.FromMutable(fragment as ScriptDom.AlterDatabaseRemoveFileGroupStatement);
                case 46: return AlterDatabaseRemoveFileStatement.FromMutable(fragment as ScriptDom.AlterDatabaseRemoveFileStatement);
                case 47: return AlterDatabaseScopedConfigurationClearStatement.FromMutable(fragment as ScriptDom.AlterDatabaseScopedConfigurationClearStatement);
                case 48: return AlterDatabaseScopedConfigurationSetStatement.FromMutable(fragment as ScriptDom.AlterDatabaseScopedConfigurationSetStatement);
                case 49: return AlterDatabaseSetStatement.FromMutable(fragment as ScriptDom.AlterDatabaseSetStatement);
                case 50: return AlterDatabaseTermination.FromMutable(fragment as ScriptDom.AlterDatabaseTermination);
                case 51: return AlterEndpointStatement.FromMutable(fragment as ScriptDom.AlterEndpointStatement);
                case 52: return AlterEventSessionStatement.FromMutable(fragment as ScriptDom.AlterEventSessionStatement);
                case 53: return AlterExternalDataSourceStatement.FromMutable(fragment as ScriptDom.AlterExternalDataSourceStatement);
                case 54: return AlterExternalFunctionStatement.FromMutable(fragment as ScriptDom.AlterExternalFunctionStatement);
                case 55: return AlterExternalLanguageStatement.FromMutable(fragment as ScriptDom.AlterExternalLanguageStatement);
                case 56: return AlterExternalLibraryStatement.FromMutable(fragment as ScriptDom.AlterExternalLibraryStatement);
                case 57: return AlterExternalModelStatement.FromMutable(fragment as ScriptDom.AlterExternalModelStatement);
                case 58: return AlterExternalResourcePoolStatement.FromMutable(fragment as ScriptDom.AlterExternalResourcePoolStatement);
                case 59: return AlterFederationStatement.FromMutable(fragment as ScriptDom.AlterFederationStatement);
                case 60: return AlterFullTextCatalogStatement.FromMutable(fragment as ScriptDom.AlterFullTextCatalogStatement);
                case 61: return AlterFullTextIndexStatement.FromMutable(fragment as ScriptDom.AlterFullTextIndexStatement);
                case 62: return AlterFullTextStopListStatement.FromMutable(fragment as ScriptDom.AlterFullTextStopListStatement);
                case 63: return AlterFunctionStatement.FromMutable(fragment as ScriptDom.AlterFunctionStatement);
                case 64: return AlterIndexStatement.FromMutable(fragment as ScriptDom.AlterIndexStatement);
                case 65: return AlterLoginAddDropCredentialStatement.FromMutable(fragment as ScriptDom.AlterLoginAddDropCredentialStatement);
                case 66: return AlterLoginEnableDisableStatement.FromMutable(fragment as ScriptDom.AlterLoginEnableDisableStatement);
                case 67: return AlterLoginOptionsStatement.FromMutable(fragment as ScriptDom.AlterLoginOptionsStatement);
                case 68: return AlterMasterKeyStatement.FromMutable(fragment as ScriptDom.AlterMasterKeyStatement);
                case 69: return AlterMessageTypeStatement.FromMutable(fragment as ScriptDom.AlterMessageTypeStatement);
                case 70: return AlterPartitionFunctionStatement.FromMutable(fragment as ScriptDom.AlterPartitionFunctionStatement);
                case 71: return AlterPartitionSchemeStatement.FromMutable(fragment as ScriptDom.AlterPartitionSchemeStatement);
                case 72: return AlterProcedureStatement.FromMutable(fragment as ScriptDom.AlterProcedureStatement);
                case 73: return AlterQueueStatement.FromMutable(fragment as ScriptDom.AlterQueueStatement);
                case 74: return AlterRemoteServiceBindingStatement.FromMutable(fragment as ScriptDom.AlterRemoteServiceBindingStatement);
                case 75: return AlterResourceGovernorStatement.FromMutable(fragment as ScriptDom.AlterResourceGovernorStatement);
                case 76: return AlterResourcePoolStatement.FromMutable(fragment as ScriptDom.AlterResourcePoolStatement);
                case 77: return AlterRoleStatement.FromMutable(fragment as ScriptDom.AlterRoleStatement);
                case 78: return AlterRouteStatement.FromMutable(fragment as ScriptDom.AlterRouteStatement);
                case 79: return AlterSchemaStatement.FromMutable(fragment as ScriptDom.AlterSchemaStatement);
                case 80: return AlterSearchPropertyListStatement.FromMutable(fragment as ScriptDom.AlterSearchPropertyListStatement);
                case 81: return AlterSecurityPolicyStatement.FromMutable(fragment as ScriptDom.AlterSecurityPolicyStatement);
                case 82: return AlterSequenceStatement.FromMutable(fragment as ScriptDom.AlterSequenceStatement);
                case 83: return AlterServerAuditSpecificationStatement.FromMutable(fragment as ScriptDom.AlterServerAuditSpecificationStatement);
                case 84: return AlterServerAuditStatement.FromMutable(fragment as ScriptDom.AlterServerAuditStatement);
                case 85: return AlterServerConfigurationBufferPoolExtensionContainerOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption);
                case 86: return AlterServerConfigurationBufferPoolExtensionOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionOption);
                case 87: return AlterServerConfigurationBufferPoolExtensionSizeOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption);
                case 88: return AlterServerConfigurationDiagnosticsLogMaxSizeOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption);
                case 89: return AlterServerConfigurationDiagnosticsLogOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationDiagnosticsLogOption);
                case 90: return AlterServerConfigurationExternalAuthenticationContainerOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationExternalAuthenticationContainerOption);
                case 91: return AlterServerConfigurationExternalAuthenticationOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationExternalAuthenticationOption);
                case 92: return AlterServerConfigurationFailoverClusterPropertyOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption);
                case 93: return AlterServerConfigurationHadrClusterOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationHadrClusterOption);
                case 94: return AlterServerConfigurationSetBufferPoolExtensionStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement);
                case 95: return AlterServerConfigurationSetDiagnosticsLogStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement);
                case 96: return AlterServerConfigurationSetExternalAuthenticationStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationSetExternalAuthenticationStatement);
                case 97: return AlterServerConfigurationSetFailoverClusterPropertyStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationSetFailoverClusterPropertyStatement);
                case 98: return AlterServerConfigurationSetHadrClusterStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationSetHadrClusterStatement);
                case 99: return AlterServerConfigurationSetSoftNumaStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationSetSoftNumaStatement);
                case 100: return AlterServerConfigurationSoftNumaOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationSoftNumaOption);
                case 101: return AlterServerConfigurationStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationStatement);
                case 102: return AlterServerRoleStatement.FromMutable(fragment as ScriptDom.AlterServerRoleStatement);
                case 103: return AlterServiceMasterKeyStatement.FromMutable(fragment as ScriptDom.AlterServiceMasterKeyStatement);
                case 104: return AlterServiceStatement.FromMutable(fragment as ScriptDom.AlterServiceStatement);
                case 105: return AlterSymmetricKeyStatement.FromMutable(fragment as ScriptDom.AlterSymmetricKeyStatement);
                case 106: return AlterTableAddClusterByStatement.FromMutable(fragment as ScriptDom.AlterTableAddClusterByStatement);
                case 107: return AlterTableAddTableElementStatement.FromMutable(fragment as ScriptDom.AlterTableAddTableElementStatement);
                case 108: return AlterTableAlterColumnStatement.FromMutable(fragment as ScriptDom.AlterTableAlterColumnStatement);
                case 109: return AlterTableAlterIndexStatement.FromMutable(fragment as ScriptDom.AlterTableAlterIndexStatement);
                case 110: return AlterTableAlterPartitionStatement.FromMutable(fragment as ScriptDom.AlterTableAlterPartitionStatement);
                case 111: return AlterTableChangeTrackingModificationStatement.FromMutable(fragment as ScriptDom.AlterTableChangeTrackingModificationStatement);
                case 112: return AlterTableConstraintModificationStatement.FromMutable(fragment as ScriptDom.AlterTableConstraintModificationStatement);
                case 113: return AlterTableDropTableElement.FromMutable(fragment as ScriptDom.AlterTableDropTableElement);
                case 114: return AlterTableDropTableElementStatement.FromMutable(fragment as ScriptDom.AlterTableDropTableElementStatement);
                case 115: return AlterTableFileTableNamespaceStatement.FromMutable(fragment as ScriptDom.AlterTableFileTableNamespaceStatement);
                case 116: return AlterTableRebuildStatement.FromMutable(fragment as ScriptDom.AlterTableRebuildStatement);
                case 117: return AlterTableSetStatement.FromMutable(fragment as ScriptDom.AlterTableSetStatement);
                case 118: return AlterTableSwitchStatement.FromMutable(fragment as ScriptDom.AlterTableSwitchStatement);
                case 119: return AlterTableTriggerModificationStatement.FromMutable(fragment as ScriptDom.AlterTableTriggerModificationStatement);
                case 120: return AlterTriggerStatement.FromMutable(fragment as ScriptDom.AlterTriggerStatement);
                case 121: return AlterUserStatement.FromMutable(fragment as ScriptDom.AlterUserStatement);
                case 122: return AlterViewStatement.FromMutable(fragment as ScriptDom.AlterViewStatement);
                case 123: return AlterWorkloadGroupStatement.FromMutable(fragment as ScriptDom.AlterWorkloadGroupStatement);
                case 124: return AlterXmlSchemaCollectionStatement.FromMutable(fragment as ScriptDom.AlterXmlSchemaCollectionStatement);
                case 125: return ApplicationRoleOption.FromMutable(fragment as ScriptDom.ApplicationRoleOption);
                case 126: return AssemblyEncryptionSource.FromMutable(fragment as ScriptDom.AssemblyEncryptionSource);
                case 127: return AssemblyName.FromMutable(fragment as ScriptDom.AssemblyName);
                case 128: return AssemblyOption.FromMutable(fragment as ScriptDom.AssemblyOption);
                case 129: return AssignmentSetClause.FromMutable(fragment as ScriptDom.AssignmentSetClause);
                case 130: return AsymmetricKeyCreateLoginSource.FromMutable(fragment as ScriptDom.AsymmetricKeyCreateLoginSource);
                case 131: return AtTimeZoneCall.FromMutable(fragment as ScriptDom.AtTimeZoneCall);
                case 132: return AuditActionGroupReference.FromMutable(fragment as ScriptDom.AuditActionGroupReference);
                case 133: return AuditActionSpecification.FromMutable(fragment as ScriptDom.AuditActionSpecification);
                case 134: return AuditGuidAuditOption.FromMutable(fragment as ScriptDom.AuditGuidAuditOption);
                case 135: return AuditSpecificationPart.FromMutable(fragment as ScriptDom.AuditSpecificationPart);
                case 136: return AuditTarget.FromMutable(fragment as ScriptDom.AuditTarget);
                case 137: return AuthenticationEndpointProtocolOption.FromMutable(fragment as ScriptDom.AuthenticationEndpointProtocolOption);
                case 138: return AuthenticationPayloadOption.FromMutable(fragment as ScriptDom.AuthenticationPayloadOption);
                case 139: return AutoCleanupChangeTrackingOptionDetail.FromMutable(fragment as ScriptDom.AutoCleanupChangeTrackingOptionDetail);
                case 140: return AutoCreateStatisticsDatabaseOption.FromMutable(fragment as ScriptDom.AutoCreateStatisticsDatabaseOption);
                case 141: return AutomaticTuningCreateIndexOption.FromMutable(fragment as ScriptDom.AutomaticTuningCreateIndexOption);
                case 142: return AutomaticTuningDatabaseOption.FromMutable(fragment as ScriptDom.AutomaticTuningDatabaseOption);
                case 143: return AutomaticTuningDropIndexOption.FromMutable(fragment as ScriptDom.AutomaticTuningDropIndexOption);
                case 144: return AutomaticTuningForceLastGoodPlanOption.FromMutable(fragment as ScriptDom.AutomaticTuningForceLastGoodPlanOption);
                case 145: return AutomaticTuningMaintainIndexOption.FromMutable(fragment as ScriptDom.AutomaticTuningMaintainIndexOption);
                case 146: return AutomaticTuningOption.FromMutable(fragment as ScriptDom.AutomaticTuningOption);
                case 147: return AvailabilityModeReplicaOption.FromMutable(fragment as ScriptDom.AvailabilityModeReplicaOption);
                case 148: return AvailabilityReplica.FromMutable(fragment as ScriptDom.AvailabilityReplica);
                case 149: return BackupCertificateStatement.FromMutable(fragment as ScriptDom.BackupCertificateStatement);
                case 150: return BackupDatabaseStatement.FromMutable(fragment as ScriptDom.BackupDatabaseStatement);
                case 151: return BackupEncryptionOption.FromMutable(fragment as ScriptDom.BackupEncryptionOption);
                case 152: return BackupMasterKeyStatement.FromMutable(fragment as ScriptDom.BackupMasterKeyStatement);
                case 153: return BackupOption.FromMutable(fragment as ScriptDom.BackupOption);
                case 154: return BackupRestoreFileInfo.FromMutable(fragment as ScriptDom.BackupRestoreFileInfo);
                case 155: return BackupServiceMasterKeyStatement.FromMutable(fragment as ScriptDom.BackupServiceMasterKeyStatement);
                case 156: return BackupTransactionLogStatement.FromMutable(fragment as ScriptDom.BackupTransactionLogStatement);
                case 157: return BackwardsCompatibleDropIndexClause.FromMutable(fragment as ScriptDom.BackwardsCompatibleDropIndexClause);
                case 158: return BeginConversationTimerStatement.FromMutable(fragment as ScriptDom.BeginConversationTimerStatement);
                case 159: return BeginDialogStatement.FromMutable(fragment as ScriptDom.BeginDialogStatement);
                case 160: return BeginEndAtomicBlockStatement.FromMutable(fragment as ScriptDom.BeginEndAtomicBlockStatement);
                case 161: return BeginEndBlockStatement.FromMutable(fragment as ScriptDom.BeginEndBlockStatement);
                case 162: return BeginTransactionStatement.FromMutable(fragment as ScriptDom.BeginTransactionStatement);
                case 163: return BinaryExpression.FromMutable(fragment as ScriptDom.BinaryExpression);
                case 164: return BinaryLiteral.FromMutable(fragment as ScriptDom.BinaryLiteral);
                case 165: return BinaryQueryExpression.FromMutable(fragment as ScriptDom.BinaryQueryExpression);
                case 166: return BooleanBinaryExpression.FromMutable(fragment as ScriptDom.BooleanBinaryExpression);
                case 167: return BooleanComparisonExpression.FromMutable(fragment as ScriptDom.BooleanComparisonExpression);
                case 168: return BooleanExpressionSnippet.FromMutable(fragment as ScriptDom.BooleanExpressionSnippet);
                case 169: return BooleanIsNullExpression.FromMutable(fragment as ScriptDom.BooleanIsNullExpression);
                case 170: return BooleanNotExpression.FromMutable(fragment as ScriptDom.BooleanNotExpression);
                case 171: return BooleanParenthesisExpression.FromMutable(fragment as ScriptDom.BooleanParenthesisExpression);
                case 172: return BooleanTernaryExpression.FromMutable(fragment as ScriptDom.BooleanTernaryExpression);
                case 173: return BoundingBoxParameter.FromMutable(fragment as ScriptDom.BoundingBoxParameter);
                case 174: return BoundingBoxSpatialIndexOption.FromMutable(fragment as ScriptDom.BoundingBoxSpatialIndexOption);
                case 175: return BreakStatement.FromMutable(fragment as ScriptDom.BreakStatement);
                case 176: return BrokerPriorityParameter.FromMutable(fragment as ScriptDom.BrokerPriorityParameter);
                case 177: return BrowseForClause.FromMutable(fragment as ScriptDom.BrowseForClause);
                case 178: return BuiltInFunctionTableReference.FromMutable(fragment as ScriptDom.BuiltInFunctionTableReference);
                case 179: return BulkInsertOption.FromMutable(fragment as ScriptDom.BulkInsertOption);
                case 180: return BulkInsertStatement.FromMutable(fragment as ScriptDom.BulkInsertStatement);
                case 181: return BulkOpenRowset.FromMutable(fragment as ScriptDom.BulkOpenRowset);
                case 182: return CastCall.FromMutable(fragment as ScriptDom.CastCall);
                case 183: return CatalogCollationOption.FromMutable(fragment as ScriptDom.CatalogCollationOption);
                case 184: return CellsPerObjectSpatialIndexOption.FromMutable(fragment as ScriptDom.CellsPerObjectSpatialIndexOption);
                case 185: return CertificateCreateLoginSource.FromMutable(fragment as ScriptDom.CertificateCreateLoginSource);
                case 186: return CertificateOption.FromMutable(fragment as ScriptDom.CertificateOption);
                case 187: return ChangeRetentionChangeTrackingOptionDetail.FromMutable(fragment as ScriptDom.ChangeRetentionChangeTrackingOptionDetail);
                case 188: return ChangeTableChangesTableReference.FromMutable(fragment as ScriptDom.ChangeTableChangesTableReference);
                case 189: return ChangeTableVersionTableReference.FromMutable(fragment as ScriptDom.ChangeTableVersionTableReference);
                case 190: return ChangeTrackingDatabaseOption.FromMutable(fragment as ScriptDom.ChangeTrackingDatabaseOption);
                case 191: return ChangeTrackingFullTextIndexOption.FromMutable(fragment as ScriptDom.ChangeTrackingFullTextIndexOption);
                case 192: return CharacterSetPayloadOption.FromMutable(fragment as ScriptDom.CharacterSetPayloadOption);
                case 193: return CheckConstraintDefinition.FromMutable(fragment as ScriptDom.CheckConstraintDefinition);
                case 194: return CheckpointStatement.FromMutable(fragment as ScriptDom.CheckpointStatement);
                case 195: return ChildObjectName.FromMutable(fragment as ScriptDom.ChildObjectName);
                case 196: return ClassifierEndTimeOption.FromMutable(fragment as ScriptDom.ClassifierEndTimeOption);
                case 197: return ClassifierImportanceOption.FromMutable(fragment as ScriptDom.ClassifierImportanceOption);
                case 198: return ClassifierMemberNameOption.FromMutable(fragment as ScriptDom.ClassifierMemberNameOption);
                case 199: return ClassifierStartTimeOption.FromMutable(fragment as ScriptDom.ClassifierStartTimeOption);
                case 200: return ClassifierWlmContextOption.FromMutable(fragment as ScriptDom.ClassifierWlmContextOption);
                case 201: return ClassifierWlmLabelOption.FromMutable(fragment as ScriptDom.ClassifierWlmLabelOption);
                case 202: return ClassifierWorkloadGroupOption.FromMutable(fragment as ScriptDom.ClassifierWorkloadGroupOption);
                case 203: return CloseCursorStatement.FromMutable(fragment as ScriptDom.CloseCursorStatement);
                case 204: return CloseMasterKeyStatement.FromMutable(fragment as ScriptDom.CloseMasterKeyStatement);
                case 205: return CloseSymmetricKeyStatement.FromMutable(fragment as ScriptDom.CloseSymmetricKeyStatement);
                case 206: return ClusterByTableOption.FromMutable(fragment as ScriptDom.ClusterByTableOption);
                case 207: return CoalesceExpression.FromMutable(fragment as ScriptDom.CoalesceExpression);
                case 208: return ColumnDefinition.FromMutable(fragment as ScriptDom.ColumnDefinition);
                case 209: return ColumnDefinitionBase.FromMutable(fragment as ScriptDom.ColumnDefinitionBase);
                case 210: return ColumnEncryptionAlgorithmNameParameter.FromMutable(fragment as ScriptDom.ColumnEncryptionAlgorithmNameParameter);
                case 211: return ColumnEncryptionAlgorithmParameter.FromMutable(fragment as ScriptDom.ColumnEncryptionAlgorithmParameter);
                case 212: return ColumnEncryptionDefinition.FromMutable(fragment as ScriptDom.ColumnEncryptionDefinition);
                case 213: return ColumnEncryptionKeyNameParameter.FromMutable(fragment as ScriptDom.ColumnEncryptionKeyNameParameter);
                case 214: return ColumnEncryptionKeyValue.FromMutable(fragment as ScriptDom.ColumnEncryptionKeyValue);
                case 215: return ColumnEncryptionTypeParameter.FromMutable(fragment as ScriptDom.ColumnEncryptionTypeParameter);
                case 216: return ColumnMasterKeyEnclaveComputationsParameter.FromMutable(fragment as ScriptDom.ColumnMasterKeyEnclaveComputationsParameter);
                case 217: return ColumnMasterKeyNameParameter.FromMutable(fragment as ScriptDom.ColumnMasterKeyNameParameter);
                case 218: return ColumnMasterKeyPathParameter.FromMutable(fragment as ScriptDom.ColumnMasterKeyPathParameter);
                case 219: return ColumnMasterKeyStoreProviderNameParameter.FromMutable(fragment as ScriptDom.ColumnMasterKeyStoreProviderNameParameter);
                case 220: return ColumnReferenceExpression.FromMutable(fragment as ScriptDom.ColumnReferenceExpression);
                case 221: return ColumnStorageOptions.FromMutable(fragment as ScriptDom.ColumnStorageOptions);
                case 222: return ColumnWithSortOrder.FromMutable(fragment as ScriptDom.ColumnWithSortOrder);
                case 223: return CommandSecurityElement80.FromMutable(fragment as ScriptDom.CommandSecurityElement80);
                case 224: return CommitTransactionStatement.FromMutable(fragment as ScriptDom.CommitTransactionStatement);
                case 225: return CommonTableExpression.FromMutable(fragment as ScriptDom.CommonTableExpression);
                case 226: return CompositeGroupingSpecification.FromMutable(fragment as ScriptDom.CompositeGroupingSpecification);
                case 227: return CompressionDelayIndexOption.FromMutable(fragment as ScriptDom.CompressionDelayIndexOption);
                case 228: return CompressionEndpointProtocolOption.FromMutable(fragment as ScriptDom.CompressionEndpointProtocolOption);
                case 229: return CompressionPartitionRange.FromMutable(fragment as ScriptDom.CompressionPartitionRange);
                case 230: return ComputeClause.FromMutable(fragment as ScriptDom.ComputeClause);
                case 231: return ComputeFunction.FromMutable(fragment as ScriptDom.ComputeFunction);
                case 232: return ContainmentDatabaseOption.FromMutable(fragment as ScriptDom.ContainmentDatabaseOption);
                case 233: return ContinueStatement.FromMutable(fragment as ScriptDom.ContinueStatement);
                case 234: return ContractMessage.FromMutable(fragment as ScriptDom.ContractMessage);
                case 235: return ConvertCall.FromMutable(fragment as ScriptDom.ConvertCall);
                case 236: return CopyColumnOption.FromMutable(fragment as ScriptDom.CopyColumnOption);
                case 237: return CopyCredentialOption.FromMutable(fragment as ScriptDom.CopyCredentialOption);
                case 238: return CopyOption.FromMutable(fragment as ScriptDom.CopyOption);
                case 239: return CopyStatement.FromMutable(fragment as ScriptDom.CopyStatement);
                case 240: return CreateAggregateStatement.FromMutable(fragment as ScriptDom.CreateAggregateStatement);
                case 241: return CreateApplicationRoleStatement.FromMutable(fragment as ScriptDom.CreateApplicationRoleStatement);
                case 242: return CreateAssemblyStatement.FromMutable(fragment as ScriptDom.CreateAssemblyStatement);
                case 243: return CreateAsymmetricKeyStatement.FromMutable(fragment as ScriptDom.CreateAsymmetricKeyStatement);
                case 244: return CreateAvailabilityGroupStatement.FromMutable(fragment as ScriptDom.CreateAvailabilityGroupStatement);
                case 245: return CreateBrokerPriorityStatement.FromMutable(fragment as ScriptDom.CreateBrokerPriorityStatement);
                case 246: return CreateCertificateStatement.FromMutable(fragment as ScriptDom.CreateCertificateStatement);
                case 247: return CreateColumnEncryptionKeyStatement.FromMutable(fragment as ScriptDom.CreateColumnEncryptionKeyStatement);
                case 248: return CreateColumnMasterKeyStatement.FromMutable(fragment as ScriptDom.CreateColumnMasterKeyStatement);
                case 249: return CreateColumnStoreIndexStatement.FromMutable(fragment as ScriptDom.CreateColumnStoreIndexStatement);
                case 250: return CreateContractStatement.FromMutable(fragment as ScriptDom.CreateContractStatement);
                case 251: return CreateCredentialStatement.FromMutable(fragment as ScriptDom.CreateCredentialStatement);
                case 252: return CreateCryptographicProviderStatement.FromMutable(fragment as ScriptDom.CreateCryptographicProviderStatement);
                case 253: return CreateDatabaseAuditSpecificationStatement.FromMutable(fragment as ScriptDom.CreateDatabaseAuditSpecificationStatement);
                case 254: return CreateDatabaseEncryptionKeyStatement.FromMutable(fragment as ScriptDom.CreateDatabaseEncryptionKeyStatement);
                case 255: return CreateDatabaseStatement.FromMutable(fragment as ScriptDom.CreateDatabaseStatement);
                case 256: return CreateDefaultStatement.FromMutable(fragment as ScriptDom.CreateDefaultStatement);
                case 257: return CreateEndpointStatement.FromMutable(fragment as ScriptDom.CreateEndpointStatement);
                case 258: return CreateEventNotificationStatement.FromMutable(fragment as ScriptDom.CreateEventNotificationStatement);
                case 259: return CreateEventSessionStatement.FromMutable(fragment as ScriptDom.CreateEventSessionStatement);
                case 260: return CreateExternalDataSourceStatement.FromMutable(fragment as ScriptDom.CreateExternalDataSourceStatement);
                case 261: return CreateExternalFileFormatStatement.FromMutable(fragment as ScriptDom.CreateExternalFileFormatStatement);
                case 262: return CreateExternalFunctionStatement.FromMutable(fragment as ScriptDom.CreateExternalFunctionStatement);
                case 263: return CreateExternalLanguageStatement.FromMutable(fragment as ScriptDom.CreateExternalLanguageStatement);
                case 264: return CreateExternalLibraryStatement.FromMutable(fragment as ScriptDom.CreateExternalLibraryStatement);
                case 265: return CreateExternalModelStatement.FromMutable(fragment as ScriptDom.CreateExternalModelStatement);
                case 266: return CreateExternalResourcePoolStatement.FromMutable(fragment as ScriptDom.CreateExternalResourcePoolStatement);
                case 267: return CreateExternalStreamingJobStatement.FromMutable(fragment as ScriptDom.CreateExternalStreamingJobStatement);
                case 268: return CreateExternalStreamStatement.FromMutable(fragment as ScriptDom.CreateExternalStreamStatement);
                case 269: return CreateExternalTableStatement.FromMutable(fragment as ScriptDom.CreateExternalTableStatement);
                case 270: return CreateFederationStatement.FromMutable(fragment as ScriptDom.CreateFederationStatement);
                case 271: return CreateFullTextCatalogStatement.FromMutable(fragment as ScriptDom.CreateFullTextCatalogStatement);
                case 272: return CreateFullTextIndexStatement.FromMutable(fragment as ScriptDom.CreateFullTextIndexStatement);
                case 273: return CreateFullTextStopListStatement.FromMutable(fragment as ScriptDom.CreateFullTextStopListStatement);
                case 274: return CreateFunctionStatement.FromMutable(fragment as ScriptDom.CreateFunctionStatement);
                case 275: return CreateIndexStatement.FromMutable(fragment as ScriptDom.CreateIndexStatement);
                case 276: return CreateJsonIndexStatement.FromMutable(fragment as ScriptDom.CreateJsonIndexStatement);
                case 277: return CreateLoginStatement.FromMutable(fragment as ScriptDom.CreateLoginStatement);
                case 278: return CreateMasterKeyStatement.FromMutable(fragment as ScriptDom.CreateMasterKeyStatement);
                case 279: return CreateMessageTypeStatement.FromMutable(fragment as ScriptDom.CreateMessageTypeStatement);
                case 280: return CreateOrAlterExternalFunctionStatement.FromMutable(fragment as ScriptDom.CreateOrAlterExternalFunctionStatement);
                case 281: return CreateOrAlterFunctionStatement.FromMutable(fragment as ScriptDom.CreateOrAlterFunctionStatement);
                case 282: return CreateOrAlterProcedureStatement.FromMutable(fragment as ScriptDom.CreateOrAlterProcedureStatement);
                case 283: return CreateOrAlterTriggerStatement.FromMutable(fragment as ScriptDom.CreateOrAlterTriggerStatement);
                case 284: return CreateOrAlterViewStatement.FromMutable(fragment as ScriptDom.CreateOrAlterViewStatement);
                case 285: return CreatePartitionFunctionStatement.FromMutable(fragment as ScriptDom.CreatePartitionFunctionStatement);
                case 286: return CreatePartitionSchemeStatement.FromMutable(fragment as ScriptDom.CreatePartitionSchemeStatement);
                case 287: return CreateProcedureStatement.FromMutable(fragment as ScriptDom.CreateProcedureStatement);
                case 288: return CreateQueueStatement.FromMutable(fragment as ScriptDom.CreateQueueStatement);
                case 289: return CreateRemoteServiceBindingStatement.FromMutable(fragment as ScriptDom.CreateRemoteServiceBindingStatement);
                case 290: return CreateResourcePoolStatement.FromMutable(fragment as ScriptDom.CreateResourcePoolStatement);
                case 291: return CreateRoleStatement.FromMutable(fragment as ScriptDom.CreateRoleStatement);
                case 292: return CreateRouteStatement.FromMutable(fragment as ScriptDom.CreateRouteStatement);
                case 293: return CreateRuleStatement.FromMutable(fragment as ScriptDom.CreateRuleStatement);
                case 294: return CreateSchemaStatement.FromMutable(fragment as ScriptDom.CreateSchemaStatement);
                case 295: return CreateSearchPropertyListStatement.FromMutable(fragment as ScriptDom.CreateSearchPropertyListStatement);
                case 296: return CreateSecurityPolicyStatement.FromMutable(fragment as ScriptDom.CreateSecurityPolicyStatement);
                case 297: return CreateSelectiveXmlIndexStatement.FromMutable(fragment as ScriptDom.CreateSelectiveXmlIndexStatement);
                case 298: return CreateSemanticIndexStatement.FromMutable(fragment as ScriptDom.CreateSemanticIndexStatement);
                case 299: return CreateSequenceStatement.FromMutable(fragment as ScriptDom.CreateSequenceStatement);
                case 300: return CreateServerAuditSpecificationStatement.FromMutable(fragment as ScriptDom.CreateServerAuditSpecificationStatement);
                case 301: return CreateServerAuditStatement.FromMutable(fragment as ScriptDom.CreateServerAuditStatement);
                case 302: return CreateServerRoleStatement.FromMutable(fragment as ScriptDom.CreateServerRoleStatement);
                case 303: return CreateServiceStatement.FromMutable(fragment as ScriptDom.CreateServiceStatement);
                case 304: return CreateSpatialIndexStatement.FromMutable(fragment as ScriptDom.CreateSpatialIndexStatement);
                case 305: return CreateStatisticsStatement.FromMutable(fragment as ScriptDom.CreateStatisticsStatement);
                case 306: return CreateSymmetricKeyStatement.FromMutable(fragment as ScriptDom.CreateSymmetricKeyStatement);
                case 307: return CreateSynonymStatement.FromMutable(fragment as ScriptDom.CreateSynonymStatement);
                case 308: return CreateTableStatement.FromMutable(fragment as ScriptDom.CreateTableStatement);
                case 309: return CreateTriggerStatement.FromMutable(fragment as ScriptDom.CreateTriggerStatement);
                case 310: return CreateTypeTableStatement.FromMutable(fragment as ScriptDom.CreateTypeTableStatement);
                case 311: return CreateTypeUddtStatement.FromMutable(fragment as ScriptDom.CreateTypeUddtStatement);
                case 312: return CreateTypeUdtStatement.FromMutable(fragment as ScriptDom.CreateTypeUdtStatement);
                case 313: return CreateUserStatement.FromMutable(fragment as ScriptDom.CreateUserStatement);
                case 314: return CreateVectorIndexStatement.FromMutable(fragment as ScriptDom.CreateVectorIndexStatement);
                case 315: return CreateViewStatement.FromMutable(fragment as ScriptDom.CreateViewStatement);
                case 316: return CreateWorkloadClassifierStatement.FromMutable(fragment as ScriptDom.CreateWorkloadClassifierStatement);
                case 317: return CreateWorkloadGroupStatement.FromMutable(fragment as ScriptDom.CreateWorkloadGroupStatement);
                case 318: return CreateXmlIndexStatement.FromMutable(fragment as ScriptDom.CreateXmlIndexStatement);
                case 319: return CreateXmlSchemaCollectionStatement.FromMutable(fragment as ScriptDom.CreateXmlSchemaCollectionStatement);
                case 320: return CreationDispositionKeyOption.FromMutable(fragment as ScriptDom.CreationDispositionKeyOption);
                case 321: return CryptoMechanism.FromMutable(fragment as ScriptDom.CryptoMechanism);
                case 322: return CubeGroupingSpecification.FromMutable(fragment as ScriptDom.CubeGroupingSpecification);
                case 323: return CursorDefaultDatabaseOption.FromMutable(fragment as ScriptDom.CursorDefaultDatabaseOption);
                case 324: return CursorDefinition.FromMutable(fragment as ScriptDom.CursorDefinition);
                case 325: return CursorId.FromMutable(fragment as ScriptDom.CursorId);
                case 326: return CursorOption.FromMutable(fragment as ScriptDom.CursorOption);
                case 327: return DatabaseAuditAction.FromMutable(fragment as ScriptDom.DatabaseAuditAction);
                case 328: return DatabaseConfigurationClearOption.FromMutable(fragment as ScriptDom.DatabaseConfigurationClearOption);
                case 329: return DatabaseConfigurationSetOption.FromMutable(fragment as ScriptDom.DatabaseConfigurationSetOption);
                case 330: return DatabaseOption.FromMutable(fragment as ScriptDom.DatabaseOption);
                case 331: return DataCompressionOption.FromMutable(fragment as ScriptDom.DataCompressionOption);
                case 332: return DataModificationTableReference.FromMutable(fragment as ScriptDom.DataModificationTableReference);
                case 333: return DataRetentionTableOption.FromMutable(fragment as ScriptDom.DataRetentionTableOption);
                case 334: return DataTypeSequenceOption.FromMutable(fragment as ScriptDom.DataTypeSequenceOption);
                case 335: return DbccNamedLiteral.FromMutable(fragment as ScriptDom.DbccNamedLiteral);
                case 336: return DbccOption.FromMutable(fragment as ScriptDom.DbccOption);
                case 337: return DbccStatement.FromMutable(fragment as ScriptDom.DbccStatement);
                case 338: return DeallocateCursorStatement.FromMutable(fragment as ScriptDom.DeallocateCursorStatement);
                case 339: return DeclareCursorStatement.FromMutable(fragment as ScriptDom.DeclareCursorStatement);
                case 340: return DeclareTableVariableBody.FromMutable(fragment as ScriptDom.DeclareTableVariableBody);
                case 341: return DeclareTableVariableStatement.FromMutable(fragment as ScriptDom.DeclareTableVariableStatement);
                case 342: return DeclareVariableElement.FromMutable(fragment as ScriptDom.DeclareVariableElement);
                case 343: return DeclareVariableStatement.FromMutable(fragment as ScriptDom.DeclareVariableStatement);
                case 344: return DefaultConstraintDefinition.FromMutable(fragment as ScriptDom.DefaultConstraintDefinition);
                case 345: return DefaultLiteral.FromMutable(fragment as ScriptDom.DefaultLiteral);
                case 346: return DelayedDurabilityDatabaseOption.FromMutable(fragment as ScriptDom.DelayedDurabilityDatabaseOption);
                case 347: return DeleteMergeAction.FromMutable(fragment as ScriptDom.DeleteMergeAction);
                case 348: return DeleteSpecification.FromMutable(fragment as ScriptDom.DeleteSpecification);
                case 349: return DeleteStatement.FromMutable(fragment as ScriptDom.DeleteStatement);
                case 350: return DenyStatement.FromMutable(fragment as ScriptDom.DenyStatement);
                case 351: return DenyStatement80.FromMutable(fragment as ScriptDom.DenyStatement80);
                case 352: return DeviceInfo.FromMutable(fragment as ScriptDom.DeviceInfo);
                case 353: return DiskStatement.FromMutable(fragment as ScriptDom.DiskStatement);
                case 354: return DiskStatementOption.FromMutable(fragment as ScriptDom.DiskStatementOption);
                case 355: return DistinctPredicate.FromMutable(fragment as ScriptDom.DistinctPredicate);
                case 356: return DropAggregateStatement.FromMutable(fragment as ScriptDom.DropAggregateStatement);
                case 357: return DropAlterFullTextIndexAction.FromMutable(fragment as ScriptDom.DropAlterFullTextIndexAction);
                case 358: return DropApplicationRoleStatement.FromMutable(fragment as ScriptDom.DropApplicationRoleStatement);
                case 359: return DropAssemblyStatement.FromMutable(fragment as ScriptDom.DropAssemblyStatement);
                case 360: return DropAsymmetricKeyStatement.FromMutable(fragment as ScriptDom.DropAsymmetricKeyStatement);
                case 361: return DropAvailabilityGroupStatement.FromMutable(fragment as ScriptDom.DropAvailabilityGroupStatement);
                case 362: return DropBrokerPriorityStatement.FromMutable(fragment as ScriptDom.DropBrokerPriorityStatement);
                case 363: return DropCertificateStatement.FromMutable(fragment as ScriptDom.DropCertificateStatement);
                case 364: return DropClusteredConstraintMoveOption.FromMutable(fragment as ScriptDom.DropClusteredConstraintMoveOption);
                case 365: return DropClusteredConstraintStateOption.FromMutable(fragment as ScriptDom.DropClusteredConstraintStateOption);
                case 366: return DropClusteredConstraintValueOption.FromMutable(fragment as ScriptDom.DropClusteredConstraintValueOption);
                case 367: return DropClusteredConstraintWaitAtLowPriorityLockOption.FromMutable(fragment as ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption);
                case 368: return DropColumnEncryptionKeyStatement.FromMutable(fragment as ScriptDom.DropColumnEncryptionKeyStatement);
                case 369: return DropColumnMasterKeyStatement.FromMutable(fragment as ScriptDom.DropColumnMasterKeyStatement);
                case 370: return DropContractStatement.FromMutable(fragment as ScriptDom.DropContractStatement);
                case 371: return DropCredentialStatement.FromMutable(fragment as ScriptDom.DropCredentialStatement);
                case 372: return DropCryptographicProviderStatement.FromMutable(fragment as ScriptDom.DropCryptographicProviderStatement);
                case 373: return DropDatabaseAuditSpecificationStatement.FromMutable(fragment as ScriptDom.DropDatabaseAuditSpecificationStatement);
                case 374: return DropDatabaseEncryptionKeyStatement.FromMutable(fragment as ScriptDom.DropDatabaseEncryptionKeyStatement);
                case 375: return DropDatabaseStatement.FromMutable(fragment as ScriptDom.DropDatabaseStatement);
                case 376: return DropDefaultStatement.FromMutable(fragment as ScriptDom.DropDefaultStatement);
                case 377: return DropEndpointStatement.FromMutable(fragment as ScriptDom.DropEndpointStatement);
                case 378: return DropEventNotificationStatement.FromMutable(fragment as ScriptDom.DropEventNotificationStatement);
                case 379: return DropEventSessionStatement.FromMutable(fragment as ScriptDom.DropEventSessionStatement);
                case 380: return DropExternalDataSourceStatement.FromMutable(fragment as ScriptDom.DropExternalDataSourceStatement);
                case 381: return DropExternalFileFormatStatement.FromMutable(fragment as ScriptDom.DropExternalFileFormatStatement);
                case 382: return DropExternalLanguageStatement.FromMutable(fragment as ScriptDom.DropExternalLanguageStatement);
                case 383: return DropExternalLibraryStatement.FromMutable(fragment as ScriptDom.DropExternalLibraryStatement);
                case 384: return DropExternalModelStatement.FromMutable(fragment as ScriptDom.DropExternalModelStatement);
                case 385: return DropExternalResourcePoolStatement.FromMutable(fragment as ScriptDom.DropExternalResourcePoolStatement);
                case 386: return DropExternalStreamingJobStatement.FromMutable(fragment as ScriptDom.DropExternalStreamingJobStatement);
                case 387: return DropExternalStreamStatement.FromMutable(fragment as ScriptDom.DropExternalStreamStatement);
                case 388: return DropExternalTableStatement.FromMutable(fragment as ScriptDom.DropExternalTableStatement);
                case 389: return DropFederationStatement.FromMutable(fragment as ScriptDom.DropFederationStatement);
                case 390: return DropFullTextCatalogStatement.FromMutable(fragment as ScriptDom.DropFullTextCatalogStatement);
                case 391: return DropFullTextIndexStatement.FromMutable(fragment as ScriptDom.DropFullTextIndexStatement);
                case 392: return DropFullTextStopListStatement.FromMutable(fragment as ScriptDom.DropFullTextStopListStatement);
                case 393: return DropFunctionStatement.FromMutable(fragment as ScriptDom.DropFunctionStatement);
                case 394: return DropIndexClause.FromMutable(fragment as ScriptDom.DropIndexClause);
                case 395: return DropIndexStatement.FromMutable(fragment as ScriptDom.DropIndexStatement);
                case 396: return DropLoginStatement.FromMutable(fragment as ScriptDom.DropLoginStatement);
                case 397: return DropMasterKeyStatement.FromMutable(fragment as ScriptDom.DropMasterKeyStatement);
                case 398: return DropMemberAlterRoleAction.FromMutable(fragment as ScriptDom.DropMemberAlterRoleAction);
                case 399: return DropMessageTypeStatement.FromMutable(fragment as ScriptDom.DropMessageTypeStatement);
                case 400: return DropPartitionFunctionStatement.FromMutable(fragment as ScriptDom.DropPartitionFunctionStatement);
                case 401: return DropPartitionSchemeStatement.FromMutable(fragment as ScriptDom.DropPartitionSchemeStatement);
                case 402: return DropProcedureStatement.FromMutable(fragment as ScriptDom.DropProcedureStatement);
                case 403: return DropQueueStatement.FromMutable(fragment as ScriptDom.DropQueueStatement);
                case 404: return DropRemoteServiceBindingStatement.FromMutable(fragment as ScriptDom.DropRemoteServiceBindingStatement);
                case 405: return DropResourcePoolStatement.FromMutable(fragment as ScriptDom.DropResourcePoolStatement);
                case 406: return DropRoleStatement.FromMutable(fragment as ScriptDom.DropRoleStatement);
                case 407: return DropRouteStatement.FromMutable(fragment as ScriptDom.DropRouteStatement);
                case 408: return DropRuleStatement.FromMutable(fragment as ScriptDom.DropRuleStatement);
                case 409: return DropSchemaStatement.FromMutable(fragment as ScriptDom.DropSchemaStatement);
                case 410: return DropSearchPropertyListAction.FromMutable(fragment as ScriptDom.DropSearchPropertyListAction);
                case 411: return DropSearchPropertyListStatement.FromMutable(fragment as ScriptDom.DropSearchPropertyListStatement);
                case 412: return DropSecurityPolicyStatement.FromMutable(fragment as ScriptDom.DropSecurityPolicyStatement);
                case 413: return DropSensitivityClassificationStatement.FromMutable(fragment as ScriptDom.DropSensitivityClassificationStatement);
                case 414: return DropSequenceStatement.FromMutable(fragment as ScriptDom.DropSequenceStatement);
                case 415: return DropServerAuditSpecificationStatement.FromMutable(fragment as ScriptDom.DropServerAuditSpecificationStatement);
                case 416: return DropServerAuditStatement.FromMutable(fragment as ScriptDom.DropServerAuditStatement);
                case 417: return DropServerRoleStatement.FromMutable(fragment as ScriptDom.DropServerRoleStatement);
                case 418: return DropServiceStatement.FromMutable(fragment as ScriptDom.DropServiceStatement);
                case 419: return DropSignatureStatement.FromMutable(fragment as ScriptDom.DropSignatureStatement);
                case 420: return DropStatisticsStatement.FromMutable(fragment as ScriptDom.DropStatisticsStatement);
                case 421: return DropSymmetricKeyStatement.FromMutable(fragment as ScriptDom.DropSymmetricKeyStatement);
                case 422: return DropSynonymStatement.FromMutable(fragment as ScriptDom.DropSynonymStatement);
                case 423: return DropTableStatement.FromMutable(fragment as ScriptDom.DropTableStatement);
                case 424: return DropTriggerStatement.FromMutable(fragment as ScriptDom.DropTriggerStatement);
                case 425: return DropTypeStatement.FromMutable(fragment as ScriptDom.DropTypeStatement);
                case 426: return DropUserStatement.FromMutable(fragment as ScriptDom.DropUserStatement);
                case 427: return DropViewStatement.FromMutable(fragment as ScriptDom.DropViewStatement);
                case 428: return DropWorkloadClassifierStatement.FromMutable(fragment as ScriptDom.DropWorkloadClassifierStatement);
                case 429: return DropWorkloadGroupStatement.FromMutable(fragment as ScriptDom.DropWorkloadGroupStatement);
                case 430: return DropXmlSchemaCollectionStatement.FromMutable(fragment as ScriptDom.DropXmlSchemaCollectionStatement);
                case 431: return DurabilityTableOption.FromMutable(fragment as ScriptDom.DurabilityTableOption);
                case 432: return DWCompatibilityLevelConfigurationOption.FromMutable(fragment as ScriptDom.DWCompatibilityLevelConfigurationOption);
                case 433: return ElasticPoolSpecification.FromMutable(fragment as ScriptDom.ElasticPoolSpecification);
                case 434: return EnabledDisabledPayloadOption.FromMutable(fragment as ScriptDom.EnabledDisabledPayloadOption);
                case 435: return EnableDisableTriggerStatement.FromMutable(fragment as ScriptDom.EnableDisableTriggerStatement);
                case 436: return EncryptedValueParameter.FromMutable(fragment as ScriptDom.EncryptedValueParameter);
                case 437: return EncryptionPayloadOption.FromMutable(fragment as ScriptDom.EncryptionPayloadOption);
                case 438: return EndConversationStatement.FromMutable(fragment as ScriptDom.EndConversationStatement);
                case 439: return EndpointAffinity.FromMutable(fragment as ScriptDom.EndpointAffinity);
                case 440: return EventDeclaration.FromMutable(fragment as ScriptDom.EventDeclaration);
                case 441: return EventDeclarationCompareFunctionParameter.FromMutable(fragment as ScriptDom.EventDeclarationCompareFunctionParameter);
                case 442: return EventDeclarationSetParameter.FromMutable(fragment as ScriptDom.EventDeclarationSetParameter);
                case 443: return EventGroupContainer.FromMutable(fragment as ScriptDom.EventGroupContainer);
                case 444: return EventNotificationObjectScope.FromMutable(fragment as ScriptDom.EventNotificationObjectScope);
                case 445: return EventRetentionSessionOption.FromMutable(fragment as ScriptDom.EventRetentionSessionOption);
                case 446: return EventSessionObjectName.FromMutable(fragment as ScriptDom.EventSessionObjectName);
                case 447: return EventSessionStatement.FromMutable(fragment as ScriptDom.EventSessionStatement);
                case 448: return EventTypeContainer.FromMutable(fragment as ScriptDom.EventTypeContainer);
                case 449: return ExecutableProcedureReference.FromMutable(fragment as ScriptDom.ExecutableProcedureReference);
                case 450: return ExecutableStringList.FromMutable(fragment as ScriptDom.ExecutableStringList);
                case 451: return ExecuteAsClause.FromMutable(fragment as ScriptDom.ExecuteAsClause);
                case 452: return ExecuteAsFunctionOption.FromMutable(fragment as ScriptDom.ExecuteAsFunctionOption);
                case 453: return ExecuteAsProcedureOption.FromMutable(fragment as ScriptDom.ExecuteAsProcedureOption);
                case 454: return ExecuteAsStatement.FromMutable(fragment as ScriptDom.ExecuteAsStatement);
                case 455: return ExecuteAsTriggerOption.FromMutable(fragment as ScriptDom.ExecuteAsTriggerOption);
                case 456: return ExecuteContext.FromMutable(fragment as ScriptDom.ExecuteContext);
                case 457: return ExecuteInsertSource.FromMutable(fragment as ScriptDom.ExecuteInsertSource);
                case 458: return ExecuteOption.FromMutable(fragment as ScriptDom.ExecuteOption);
                case 459: return ExecuteParameter.FromMutable(fragment as ScriptDom.ExecuteParameter);
                case 460: return ExecuteSpecification.FromMutable(fragment as ScriptDom.ExecuteSpecification);
                case 461: return ExecuteStatement.FromMutable(fragment as ScriptDom.ExecuteStatement);
                case 462: return ExistsPredicate.FromMutable(fragment as ScriptDom.ExistsPredicate);
                case 463: return ExpressionCallTarget.FromMutable(fragment as ScriptDom.ExpressionCallTarget);
                case 464: return ExpressionGroupingSpecification.FromMutable(fragment as ScriptDom.ExpressionGroupingSpecification);
                case 465: return ExpressionWithSortOrder.FromMutable(fragment as ScriptDom.ExpressionWithSortOrder);
                case 466: return ExternalCreateLoginSource.FromMutable(fragment as ScriptDom.ExternalCreateLoginSource);
                case 467: return ExternalDataSourceLiteralOrIdentifierOption.FromMutable(fragment as ScriptDom.ExternalDataSourceLiteralOrIdentifierOption);
                case 468: return ExternalFileFormatContainerOption.FromMutable(fragment as ScriptDom.ExternalFileFormatContainerOption);
                case 469: return ExternalFileFormatLiteralOption.FromMutable(fragment as ScriptDom.ExternalFileFormatLiteralOption);
                case 470: return ExternalFileFormatUseDefaultTypeOption.FromMutable(fragment as ScriptDom.ExternalFileFormatUseDefaultTypeOption);
                case 471: return ExternalLanguageFileOption.FromMutable(fragment as ScriptDom.ExternalLanguageFileOption);
                case 472: return ExternalLibraryFileOption.FromMutable(fragment as ScriptDom.ExternalLibraryFileOption);
                case 473: return ExternalModelTypeSpecification.FromMutable(fragment as ScriptDom.ExternalModelTypeSpecification);
                case 474: return ExternalResourcePoolAffinitySpecification.FromMutable(fragment as ScriptDom.ExternalResourcePoolAffinitySpecification);
                case 475: return ExternalResourcePoolParameter.FromMutable(fragment as ScriptDom.ExternalResourcePoolParameter);
                case 476: return ExternalResourcePoolStatement.FromMutable(fragment as ScriptDom.ExternalResourcePoolStatement);
                case 477: return ExternalStreamLiteralOrIdentifierOption.FromMutable(fragment as ScriptDom.ExternalStreamLiteralOrIdentifierOption);
                case 478: return ExternalTableColumnDefinition.FromMutable(fragment as ScriptDom.ExternalTableColumnDefinition);
                case 479: return ExternalTableDistributionOption.FromMutable(fragment as ScriptDom.ExternalTableDistributionOption);
                case 480: return ExternalTableLiteralOrIdentifierOption.FromMutable(fragment as ScriptDom.ExternalTableLiteralOrIdentifierOption);
                case 481: return ExternalTableRejectTypeOption.FromMutable(fragment as ScriptDom.ExternalTableRejectTypeOption);
                case 482: return ExternalTableReplicatedDistributionPolicy.FromMutable(fragment as ScriptDom.ExternalTableReplicatedDistributionPolicy);
                case 483: return ExternalTableRoundRobinDistributionPolicy.FromMutable(fragment as ScriptDom.ExternalTableRoundRobinDistributionPolicy);
                case 484: return ExternalTableShardedDistributionPolicy.FromMutable(fragment as ScriptDom.ExternalTableShardedDistributionPolicy);
                case 485: return ExtractFromExpression.FromMutable(fragment as ScriptDom.ExtractFromExpression);
                case 486: return FailoverModeReplicaOption.FromMutable(fragment as ScriptDom.FailoverModeReplicaOption);
                case 487: return FederationScheme.FromMutable(fragment as ScriptDom.FederationScheme);
                case 488: return FetchCursorStatement.FromMutable(fragment as ScriptDom.FetchCursorStatement);
                case 489: return FetchType.FromMutable(fragment as ScriptDom.FetchType);
                case 490: return FileDeclaration.FromMutable(fragment as ScriptDom.FileDeclaration);
                case 491: return FileDeclarationOption.FromMutable(fragment as ScriptDom.FileDeclarationOption);
                case 492: return FileEncryptionSource.FromMutable(fragment as ScriptDom.FileEncryptionSource);
                case 493: return FileGroupDefinition.FromMutable(fragment as ScriptDom.FileGroupDefinition);
                case 494: return FileGroupOrPartitionScheme.FromMutable(fragment as ScriptDom.FileGroupOrPartitionScheme);
                case 495: return FileGrowthFileDeclarationOption.FromMutable(fragment as ScriptDom.FileGrowthFileDeclarationOption);
                case 496: return FileNameFileDeclarationOption.FromMutable(fragment as ScriptDom.FileNameFileDeclarationOption);
                case 497: return FileStreamDatabaseOption.FromMutable(fragment as ScriptDom.FileStreamDatabaseOption);
                case 498: return FileStreamOnDropIndexOption.FromMutable(fragment as ScriptDom.FileStreamOnDropIndexOption);
                case 499: return FileStreamOnTableOption.FromMutable(fragment as ScriptDom.FileStreamOnTableOption);
                case 500: return FileStreamRestoreOption.FromMutable(fragment as ScriptDom.FileStreamRestoreOption);
                case 501: return FileTableCollateFileNameTableOption.FromMutable(fragment as ScriptDom.FileTableCollateFileNameTableOption);
                case 502: return FileTableConstraintNameTableOption.FromMutable(fragment as ScriptDom.FileTableConstraintNameTableOption);
                case 503: return FileTableDirectoryTableOption.FromMutable(fragment as ScriptDom.FileTableDirectoryTableOption);
                case 504: return ForceSeekTableHint.FromMutable(fragment as ScriptDom.ForceSeekTableHint);
                case 505: return ForeignKeyConstraintDefinition.FromMutable(fragment as ScriptDom.ForeignKeyConstraintDefinition);
                case 506: return FromClause.FromMutable(fragment as ScriptDom.FromClause);
                case 507: return FullTextCatalogAndFileGroup.FromMutable(fragment as ScriptDom.FullTextCatalogAndFileGroup);
                case 508: return FullTextIndexColumn.FromMutable(fragment as ScriptDom.FullTextIndexColumn);
                case 509: return FullTextPredicate.FromMutable(fragment as ScriptDom.FullTextPredicate);
                case 510: return FullTextStopListAction.FromMutable(fragment as ScriptDom.FullTextStopListAction);
                case 511: return FullTextTableReference.FromMutable(fragment as ScriptDom.FullTextTableReference);
                case 512: return FunctionCall.FromMutable(fragment as ScriptDom.FunctionCall);
                case 513: return FunctionCallSetClause.FromMutable(fragment as ScriptDom.FunctionCallSetClause);
                case 514: return FunctionOption.FromMutable(fragment as ScriptDom.FunctionOption);
                case 515: return GeneralSetCommand.FromMutable(fragment as ScriptDom.GeneralSetCommand);
                case 516: return GenericConfigurationOption.FromMutable(fragment as ScriptDom.GenericConfigurationOption);
                case 517: return GetConversationGroupStatement.FromMutable(fragment as ScriptDom.GetConversationGroupStatement);
                case 518: return GlobalFunctionTableReference.FromMutable(fragment as ScriptDom.GlobalFunctionTableReference);
                case 519: return GlobalVariableExpression.FromMutable(fragment as ScriptDom.GlobalVariableExpression);
                case 520: return GoToStatement.FromMutable(fragment as ScriptDom.GoToStatement);
                case 521: return GrandTotalGroupingSpecification.FromMutable(fragment as ScriptDom.GrandTotalGroupingSpecification);
                case 522: return GrantStatement.FromMutable(fragment as ScriptDom.GrantStatement);
                case 523: return GrantStatement80.FromMutable(fragment as ScriptDom.GrantStatement80);
                case 524: return GraphConnectionBetweenNodes.FromMutable(fragment as ScriptDom.GraphConnectionBetweenNodes);
                case 525: return GraphConnectionConstraintDefinition.FromMutable(fragment as ScriptDom.GraphConnectionConstraintDefinition);
                case 526: return GraphMatchCompositeExpression.FromMutable(fragment as ScriptDom.GraphMatchCompositeExpression);
                case 527: return GraphMatchExpression.FromMutable(fragment as ScriptDom.GraphMatchExpression);
                case 528: return GraphMatchLastNodePredicate.FromMutable(fragment as ScriptDom.GraphMatchLastNodePredicate);
                case 529: return GraphMatchNodeExpression.FromMutable(fragment as ScriptDom.GraphMatchNodeExpression);
                case 530: return GraphMatchPredicate.FromMutable(fragment as ScriptDom.GraphMatchPredicate);
                case 531: return GraphMatchRecursivePredicate.FromMutable(fragment as ScriptDom.GraphMatchRecursivePredicate);
                case 532: return GraphRecursiveMatchQuantifier.FromMutable(fragment as ScriptDom.GraphRecursiveMatchQuantifier);
                case 533: return GridParameter.FromMutable(fragment as ScriptDom.GridParameter);
                case 534: return GridsSpatialIndexOption.FromMutable(fragment as ScriptDom.GridsSpatialIndexOption);
                case 535: return GroupByClause.FromMutable(fragment as ScriptDom.GroupByClause);
                case 536: return GroupingSetsGroupingSpecification.FromMutable(fragment as ScriptDom.GroupingSetsGroupingSpecification);
                case 537: return HadrAvailabilityGroupDatabaseOption.FromMutable(fragment as ScriptDom.HadrAvailabilityGroupDatabaseOption);
                case 538: return HadrDatabaseOption.FromMutable(fragment as ScriptDom.HadrDatabaseOption);
                case 539: return HavingClause.FromMutable(fragment as ScriptDom.HavingClause);
                case 540: return Identifier.FromMutable(fragment as ScriptDom.Identifier);
                case 541: return IdentifierAtomicBlockOption.FromMutable(fragment as ScriptDom.IdentifierAtomicBlockOption);
                case 542: return IdentifierDatabaseOption.FromMutable(fragment as ScriptDom.IdentifierDatabaseOption);
                case 543: return IdentifierLiteral.FromMutable(fragment as ScriptDom.IdentifierLiteral);
                case 544: return IdentifierOrScalarExpression.FromMutable(fragment as ScriptDom.IdentifierOrScalarExpression);
                case 545: return IdentifierOrValueExpression.FromMutable(fragment as ScriptDom.IdentifierOrValueExpression);
                case 546: return IdentifierPrincipalOption.FromMutable(fragment as ScriptDom.IdentifierPrincipalOption);
                case 547: return IdentifierSnippet.FromMutable(fragment as ScriptDom.IdentifierSnippet);
                case 548: return IdentityFunctionCall.FromMutable(fragment as ScriptDom.IdentityFunctionCall);
                case 549: return IdentityOptions.FromMutable(fragment as ScriptDom.IdentityOptions);
                case 550: return IdentityValueKeyOption.FromMutable(fragment as ScriptDom.IdentityValueKeyOption);
                case 551: return IfStatement.FromMutable(fragment as ScriptDom.IfStatement);
                case 552: return IgnoreDupKeyIndexOption.FromMutable(fragment as ScriptDom.IgnoreDupKeyIndexOption);
                case 553: return IIfCall.FromMutable(fragment as ScriptDom.IIfCall);
                case 554: return IndexDefinition.FromMutable(fragment as ScriptDom.IndexDefinition);
                case 555: return IndexExpressionOption.FromMutable(fragment as ScriptDom.IndexExpressionOption);
                case 556: return IndexStateOption.FromMutable(fragment as ScriptDom.IndexStateOption);
                case 557: return IndexTableHint.FromMutable(fragment as ScriptDom.IndexTableHint);
                case 558: return IndexType.FromMutable(fragment as ScriptDom.IndexType);
                case 559: return InlineDerivedTable.FromMutable(fragment as ScriptDom.InlineDerivedTable);
                case 560: return InlineFunctionOption.FromMutable(fragment as ScriptDom.InlineFunctionOption);
                case 561: return InlineResultSetDefinition.FromMutable(fragment as ScriptDom.InlineResultSetDefinition);
                case 562: return InPredicate.FromMutable(fragment as ScriptDom.InPredicate);
                case 563: return InsertBulkColumnDefinition.FromMutable(fragment as ScriptDom.InsertBulkColumnDefinition);
                case 564: return InsertBulkStatement.FromMutable(fragment as ScriptDom.InsertBulkStatement);
                case 565: return InsertMergeAction.FromMutable(fragment as ScriptDom.InsertMergeAction);
                case 566: return InsertSpecification.FromMutable(fragment as ScriptDom.InsertSpecification);
                case 567: return InsertStatement.FromMutable(fragment as ScriptDom.InsertStatement);
                case 568: return IntegerLiteral.FromMutable(fragment as ScriptDom.IntegerLiteral);
                case 569: return InternalOpenRowset.FromMutable(fragment as ScriptDom.InternalOpenRowset);
                case 570: return InvokeExternalApiFunctionCall.FromMutable(fragment as ScriptDom.InvokeExternalApiFunctionCall);
                case 571: return IPv4.FromMutable(fragment as ScriptDom.IPv4);
                case 572: return JoinParenthesisTableReference.FromMutable(fragment as ScriptDom.JoinParenthesisTableReference);
                case 573: return JsonForClause.FromMutable(fragment as ScriptDom.JsonForClause);
                case 574: return JsonForClauseOption.FromMutable(fragment as ScriptDom.JsonForClauseOption);
                case 575: return JsonKeyValue.FromMutable(fragment as ScriptDom.JsonKeyValue);
                case 576: return KeySourceKeyOption.FromMutable(fragment as ScriptDom.KeySourceKeyOption);
                case 577: return KillQueryNotificationSubscriptionStatement.FromMutable(fragment as ScriptDom.KillQueryNotificationSubscriptionStatement);
                case 578: return KillStatement.FromMutable(fragment as ScriptDom.KillStatement);
                case 579: return KillStatsJobStatement.FromMutable(fragment as ScriptDom.KillStatsJobStatement);
                case 580: return LabelStatement.FromMutable(fragment as ScriptDom.LabelStatement);
                case 581: return LedgerOption.FromMutable(fragment as ScriptDom.LedgerOption);
                case 582: return LedgerTableOption.FromMutable(fragment as ScriptDom.LedgerTableOption);
                case 583: return LedgerViewOption.FromMutable(fragment as ScriptDom.LedgerViewOption);
                case 584: return LeftFunctionCall.FromMutable(fragment as ScriptDom.LeftFunctionCall);
                case 585: return LikePredicate.FromMutable(fragment as ScriptDom.LikePredicate);
                case 586: return LineNoStatement.FromMutable(fragment as ScriptDom.LineNoStatement);
                case 587: return ListenerIPEndpointProtocolOption.FromMutable(fragment as ScriptDom.ListenerIPEndpointProtocolOption);
                case 588: return ListTypeCopyOption.FromMutable(fragment as ScriptDom.ListTypeCopyOption);
                case 589: return LiteralAtomicBlockOption.FromMutable(fragment as ScriptDom.LiteralAtomicBlockOption);
                case 590: return LiteralAuditTargetOption.FromMutable(fragment as ScriptDom.LiteralAuditTargetOption);
                case 591: return LiteralAvailabilityGroupOption.FromMutable(fragment as ScriptDom.LiteralAvailabilityGroupOption);
                case 592: return LiteralBulkInsertOption.FromMutable(fragment as ScriptDom.LiteralBulkInsertOption);
                case 593: return LiteralDatabaseOption.FromMutable(fragment as ScriptDom.LiteralDatabaseOption);
                case 594: return LiteralEndpointProtocolOption.FromMutable(fragment as ScriptDom.LiteralEndpointProtocolOption);
                case 595: return LiteralOpenRowsetCosmosOption.FromMutable(fragment as ScriptDom.LiteralOpenRowsetCosmosOption);
                case 596: return LiteralOptimizerHint.FromMutable(fragment as ScriptDom.LiteralOptimizerHint);
                case 597: return LiteralOptionValue.FromMutable(fragment as ScriptDom.LiteralOptionValue);
                case 598: return LiteralPayloadOption.FromMutable(fragment as ScriptDom.LiteralPayloadOption);
                case 599: return LiteralPrincipalOption.FromMutable(fragment as ScriptDom.LiteralPrincipalOption);
                case 600: return LiteralRange.FromMutable(fragment as ScriptDom.LiteralRange);
                case 601: return LiteralReplicaOption.FromMutable(fragment as ScriptDom.LiteralReplicaOption);
                case 602: return LiteralSessionOption.FromMutable(fragment as ScriptDom.LiteralSessionOption);
                case 603: return LiteralStatisticsOption.FromMutable(fragment as ScriptDom.LiteralStatisticsOption);
                case 604: return LiteralTableHint.FromMutable(fragment as ScriptDom.LiteralTableHint);
                case 605: return LocationOption.FromMutable(fragment as ScriptDom.LocationOption);
                case 606: return LockEscalationTableOption.FromMutable(fragment as ScriptDom.LockEscalationTableOption);
                case 607: return LoginTypePayloadOption.FromMutable(fragment as ScriptDom.LoginTypePayloadOption);
                case 608: return LowPriorityLockWaitAbortAfterWaitOption.FromMutable(fragment as ScriptDom.LowPriorityLockWaitAbortAfterWaitOption);
                case 609: return LowPriorityLockWaitMaxDurationOption.FromMutable(fragment as ScriptDom.LowPriorityLockWaitMaxDurationOption);
                case 610: return LowPriorityLockWaitTableSwitchOption.FromMutable(fragment as ScriptDom.LowPriorityLockWaitTableSwitchOption);
                case 611: return MaxDispatchLatencySessionOption.FromMutable(fragment as ScriptDom.MaxDispatchLatencySessionOption);
                case 612: return MaxDopConfigurationOption.FromMutable(fragment as ScriptDom.MaxDopConfigurationOption);
                case 613: return MaxDurationOption.FromMutable(fragment as ScriptDom.MaxDurationOption);
                case 614: return MaxLiteral.FromMutable(fragment as ScriptDom.MaxLiteral);
                case 615: return MaxRolloverFilesAuditTargetOption.FromMutable(fragment as ScriptDom.MaxRolloverFilesAuditTargetOption);
                case 616: return MaxSizeAuditTargetOption.FromMutable(fragment as ScriptDom.MaxSizeAuditTargetOption);
                case 617: return MaxSizeDatabaseOption.FromMutable(fragment as ScriptDom.MaxSizeDatabaseOption);
                case 618: return MaxSizeFileDeclarationOption.FromMutable(fragment as ScriptDom.MaxSizeFileDeclarationOption);
                case 619: return MemoryOptimizedTableOption.FromMutable(fragment as ScriptDom.MemoryOptimizedTableOption);
                case 620: return MemoryPartitionSessionOption.FromMutable(fragment as ScriptDom.MemoryPartitionSessionOption);
                case 621: return MergeActionClause.FromMutable(fragment as ScriptDom.MergeActionClause);
                case 622: return MergeSpecification.FromMutable(fragment as ScriptDom.MergeSpecification);
                case 623: return MergeStatement.FromMutable(fragment as ScriptDom.MergeStatement);
                case 624: return MethodSpecifier.FromMutable(fragment as ScriptDom.MethodSpecifier);
                case 625: return MirrorToClause.FromMutable(fragment as ScriptDom.MirrorToClause);
                case 626: return MoneyLiteral.FromMutable(fragment as ScriptDom.MoneyLiteral);
                case 627: return MoveConversationStatement.FromMutable(fragment as ScriptDom.MoveConversationStatement);
                case 628: return MoveRestoreOption.FromMutable(fragment as ScriptDom.MoveRestoreOption);
                case 629: return MoveToDropIndexOption.FromMutable(fragment as ScriptDom.MoveToDropIndexOption);
                case 630: return MultiPartIdentifier.FromMutable(fragment as ScriptDom.MultiPartIdentifier);
                case 631: return MultiPartIdentifierCallTarget.FromMutable(fragment as ScriptDom.MultiPartIdentifierCallTarget);
                case 632: return NamedTableReference.FromMutable(fragment as ScriptDom.NamedTableReference);
                case 633: return NameFileDeclarationOption.FromMutable(fragment as ScriptDom.NameFileDeclarationOption);
                case 634: return NextValueForExpression.FromMutable(fragment as ScriptDom.NextValueForExpression);
                case 635: return NullableConstraintDefinition.FromMutable(fragment as ScriptDom.NullableConstraintDefinition);
                case 636: return NullIfExpression.FromMutable(fragment as ScriptDom.NullIfExpression);
                case 637: return NullLiteral.FromMutable(fragment as ScriptDom.NullLiteral);
                case 638: return NumericLiteral.FromMutable(fragment as ScriptDom.NumericLiteral);
                case 639: return OdbcConvertSpecification.FromMutable(fragment as ScriptDom.OdbcConvertSpecification);
                case 640: return OdbcFunctionCall.FromMutable(fragment as ScriptDom.OdbcFunctionCall);
                case 641: return OdbcLiteral.FromMutable(fragment as ScriptDom.OdbcLiteral);
                case 642: return OdbcQualifiedJoinTableReference.FromMutable(fragment as ScriptDom.OdbcQualifiedJoinTableReference);
                case 643: return OffsetClause.FromMutable(fragment as ScriptDom.OffsetClause);
                case 644: return OnFailureAuditOption.FromMutable(fragment as ScriptDom.OnFailureAuditOption);
                case 645: return OnlineIndexLowPriorityLockWaitOption.FromMutable(fragment as ScriptDom.OnlineIndexLowPriorityLockWaitOption);
                case 646: return OnlineIndexOption.FromMutable(fragment as ScriptDom.OnlineIndexOption);
                case 647: return OnOffAssemblyOption.FromMutable(fragment as ScriptDom.OnOffAssemblyOption);
                case 648: return OnOffAtomicBlockOption.FromMutable(fragment as ScriptDom.OnOffAtomicBlockOption);
                case 649: return OnOffAuditTargetOption.FromMutable(fragment as ScriptDom.OnOffAuditTargetOption);
                case 650: return OnOffDatabaseOption.FromMutable(fragment as ScriptDom.OnOffDatabaseOption);
                case 651: return OnOffDialogOption.FromMutable(fragment as ScriptDom.OnOffDialogOption);
                case 652: return OnOffFullTextCatalogOption.FromMutable(fragment as ScriptDom.OnOffFullTextCatalogOption);
                case 653: return OnOffOptionValue.FromMutable(fragment as ScriptDom.OnOffOptionValue);
                case 654: return OnOffPrimaryConfigurationOption.FromMutable(fragment as ScriptDom.OnOffPrimaryConfigurationOption);
                case 655: return OnOffPrincipalOption.FromMutable(fragment as ScriptDom.OnOffPrincipalOption);
                case 656: return OnOffRemoteServiceBindingOption.FromMutable(fragment as ScriptDom.OnOffRemoteServiceBindingOption);
                case 657: return OnOffSessionOption.FromMutable(fragment as ScriptDom.OnOffSessionOption);
                case 658: return OnOffStatisticsOption.FromMutable(fragment as ScriptDom.OnOffStatisticsOption);
                case 659: return OpenCursorStatement.FromMutable(fragment as ScriptDom.OpenCursorStatement);
                case 660: return OpenJsonTableReference.FromMutable(fragment as ScriptDom.OpenJsonTableReference);
                case 661: return OpenMasterKeyStatement.FromMutable(fragment as ScriptDom.OpenMasterKeyStatement);
                case 662: return OpenQueryTableReference.FromMutable(fragment as ScriptDom.OpenQueryTableReference);
                case 663: return OpenRowsetColumnDefinition.FromMutable(fragment as ScriptDom.OpenRowsetColumnDefinition);
                case 664: return OpenRowsetCosmos.FromMutable(fragment as ScriptDom.OpenRowsetCosmos);
                case 665: return OpenRowsetCosmosOption.FromMutable(fragment as ScriptDom.OpenRowsetCosmosOption);
                case 666: return OpenRowsetTableReference.FromMutable(fragment as ScriptDom.OpenRowsetTableReference);
                case 667: return OpenSymmetricKeyStatement.FromMutable(fragment as ScriptDom.OpenSymmetricKeyStatement);
                case 668: return OpenXmlTableReference.FromMutable(fragment as ScriptDom.OpenXmlTableReference);
                case 669: return OperatorAuditOption.FromMutable(fragment as ScriptDom.OperatorAuditOption);
                case 670: return OptimizedLockingDatabaseOption.FromMutable(fragment as ScriptDom.OptimizedLockingDatabaseOption);
                case 671: return OptimizeForOptimizerHint.FromMutable(fragment as ScriptDom.OptimizeForOptimizerHint);
                case 672: return OptimizerHint.FromMutable(fragment as ScriptDom.OptimizerHint);
                case 673: return OrderBulkInsertOption.FromMutable(fragment as ScriptDom.OrderBulkInsertOption);
                case 674: return OrderByClause.FromMutable(fragment as ScriptDom.OrderByClause);
                case 675: return OrderIndexOption.FromMutable(fragment as ScriptDom.OrderIndexOption);
                case 676: return OutputClause.FromMutable(fragment as ScriptDom.OutputClause);
                case 677: return OutputIntoClause.FromMutable(fragment as ScriptDom.OutputIntoClause);
                case 678: return OverClause.FromMutable(fragment as ScriptDom.OverClause);
                case 679: return PageVerifyDatabaseOption.FromMutable(fragment as ScriptDom.PageVerifyDatabaseOption);
                case 680: return ParameterizationDatabaseOption.FromMutable(fragment as ScriptDom.ParameterizationDatabaseOption);
                case 681: return ParameterlessCall.FromMutable(fragment as ScriptDom.ParameterlessCall);
                case 682: return ParenthesisExpression.FromMutable(fragment as ScriptDom.ParenthesisExpression);
                case 683: return ParseCall.FromMutable(fragment as ScriptDom.ParseCall);
                case 684: return PartitionFunctionCall.FromMutable(fragment as ScriptDom.PartitionFunctionCall);
                case 685: return PartitionParameterType.FromMutable(fragment as ScriptDom.PartitionParameterType);
                case 686: return PartitionSpecifier.FromMutable(fragment as ScriptDom.PartitionSpecifier);
                case 687: return PartnerDatabaseOption.FromMutable(fragment as ScriptDom.PartnerDatabaseOption);
                case 688: return PasswordAlterPrincipalOption.FromMutable(fragment as ScriptDom.PasswordAlterPrincipalOption);
                case 689: return PasswordCreateLoginSource.FromMutable(fragment as ScriptDom.PasswordCreateLoginSource);
                case 690: return Permission.FromMutable(fragment as ScriptDom.Permission);
                case 691: return PermissionSetAssemblyOption.FromMutable(fragment as ScriptDom.PermissionSetAssemblyOption);
                case 692: return PivotedTableReference.FromMutable(fragment as ScriptDom.PivotedTableReference);
                case 693: return PortsEndpointProtocolOption.FromMutable(fragment as ScriptDom.PortsEndpointProtocolOption);
                case 694: return PredicateSetStatement.FromMutable(fragment as ScriptDom.PredicateSetStatement);
                case 695: return PredictTableReference.FromMutable(fragment as ScriptDom.PredictTableReference);
                case 696: return PrimaryRoleReplicaOption.FromMutable(fragment as ScriptDom.PrimaryRoleReplicaOption);
                case 697: return PrincipalOption.FromMutable(fragment as ScriptDom.PrincipalOption);
                case 698: return PrintStatement.FromMutable(fragment as ScriptDom.PrintStatement);
                case 699: return Privilege80.FromMutable(fragment as ScriptDom.Privilege80);
                case 700: return PrivilegeSecurityElement80.FromMutable(fragment as ScriptDom.PrivilegeSecurityElement80);
                case 701: return ProcedureOption.FromMutable(fragment as ScriptDom.ProcedureOption);
                case 702: return ProcedureParameter.FromMutable(fragment as ScriptDom.ProcedureParameter);
                case 703: return ProcedureReference.FromMutable(fragment as ScriptDom.ProcedureReference);
                case 704: return ProcedureReferenceName.FromMutable(fragment as ScriptDom.ProcedureReferenceName);
                case 705: return ProcessAffinityRange.FromMutable(fragment as ScriptDom.ProcessAffinityRange);
                case 706: return ProviderEncryptionSource.FromMutable(fragment as ScriptDom.ProviderEncryptionSource);
                case 707: return ProviderKeyNameKeyOption.FromMutable(fragment as ScriptDom.ProviderKeyNameKeyOption);
                case 708: return QualifiedJoin.FromMutable(fragment as ScriptDom.QualifiedJoin);
                case 709: return QueryDerivedTable.FromMutable(fragment as ScriptDom.QueryDerivedTable);
                case 710: return QueryParenthesisExpression.FromMutable(fragment as ScriptDom.QueryParenthesisExpression);
                case 711: return QuerySpecification.FromMutable(fragment as ScriptDom.QuerySpecification);
                case 712: return QueryStoreCapturePolicyOption.FromMutable(fragment as ScriptDom.QueryStoreCapturePolicyOption);
                case 713: return QueryStoreDatabaseOption.FromMutable(fragment as ScriptDom.QueryStoreDatabaseOption);
                case 714: return QueryStoreDataFlushIntervalOption.FromMutable(fragment as ScriptDom.QueryStoreDataFlushIntervalOption);
                case 715: return QueryStoreDesiredStateOption.FromMutable(fragment as ScriptDom.QueryStoreDesiredStateOption);
                case 716: return QueryStoreIntervalLengthOption.FromMutable(fragment as ScriptDom.QueryStoreIntervalLengthOption);
                case 717: return QueryStoreMaxPlansPerQueryOption.FromMutable(fragment as ScriptDom.QueryStoreMaxPlansPerQueryOption);
                case 718: return QueryStoreMaxStorageSizeOption.FromMutable(fragment as ScriptDom.QueryStoreMaxStorageSizeOption);
                case 719: return QueryStoreSizeCleanupPolicyOption.FromMutable(fragment as ScriptDom.QueryStoreSizeCleanupPolicyOption);
                case 720: return QueryStoreTimeCleanupPolicyOption.FromMutable(fragment as ScriptDom.QueryStoreTimeCleanupPolicyOption);
                case 721: return QueryStoreWaitStatsCaptureOption.FromMutable(fragment as ScriptDom.QueryStoreWaitStatsCaptureOption);
                case 722: return QueueDelayAuditOption.FromMutable(fragment as ScriptDom.QueueDelayAuditOption);
                case 723: return QueueExecuteAsOption.FromMutable(fragment as ScriptDom.QueueExecuteAsOption);
                case 724: return QueueOption.FromMutable(fragment as ScriptDom.QueueOption);
                case 725: return QueueProcedureOption.FromMutable(fragment as ScriptDom.QueueProcedureOption);
                case 726: return QueueStateOption.FromMutable(fragment as ScriptDom.QueueStateOption);
                case 727: return QueueValueOption.FromMutable(fragment as ScriptDom.QueueValueOption);
                case 728: return RaiseErrorLegacyStatement.FromMutable(fragment as ScriptDom.RaiseErrorLegacyStatement);
                case 729: return RaiseErrorStatement.FromMutable(fragment as ScriptDom.RaiseErrorStatement);
                case 730: return ReadOnlyForClause.FromMutable(fragment as ScriptDom.ReadOnlyForClause);
                case 731: return ReadTextStatement.FromMutable(fragment as ScriptDom.ReadTextStatement);
                case 732: return RealLiteral.FromMutable(fragment as ScriptDom.RealLiteral);
                case 733: return ReceiveStatement.FromMutable(fragment as ScriptDom.ReceiveStatement);
                case 734: return ReconfigureStatement.FromMutable(fragment as ScriptDom.ReconfigureStatement);
                case 735: return RecoveryDatabaseOption.FromMutable(fragment as ScriptDom.RecoveryDatabaseOption);
                case 736: return RegexpLikePredicate.FromMutable(fragment as ScriptDom.RegexpLikePredicate);
                case 737: return RemoteDataArchiveAlterTableOption.FromMutable(fragment as ScriptDom.RemoteDataArchiveAlterTableOption);
                case 738: return RemoteDataArchiveDatabaseOption.FromMutable(fragment as ScriptDom.RemoteDataArchiveDatabaseOption);
                case 739: return RemoteDataArchiveDbCredentialSetting.FromMutable(fragment as ScriptDom.RemoteDataArchiveDbCredentialSetting);
                case 740: return RemoteDataArchiveDbFederatedServiceAccountSetting.FromMutable(fragment as ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting);
                case 741: return RemoteDataArchiveDbServerSetting.FromMutable(fragment as ScriptDom.RemoteDataArchiveDbServerSetting);
                case 742: return RemoteDataArchiveTableOption.FromMutable(fragment as ScriptDom.RemoteDataArchiveTableOption);
                case 743: return RenameAlterRoleAction.FromMutable(fragment as ScriptDom.RenameAlterRoleAction);
                case 744: return RenameEntityStatement.FromMutable(fragment as ScriptDom.RenameEntityStatement);
                case 745: return ResampleStatisticsOption.FromMutable(fragment as ScriptDom.ResampleStatisticsOption);
                case 746: return ResourcePoolAffinitySpecification.FromMutable(fragment as ScriptDom.ResourcePoolAffinitySpecification);
                case 747: return ResourcePoolParameter.FromMutable(fragment as ScriptDom.ResourcePoolParameter);
                case 748: return ResourcePoolStatement.FromMutable(fragment as ScriptDom.ResourcePoolStatement);
                case 749: return RestoreMasterKeyStatement.FromMutable(fragment as ScriptDom.RestoreMasterKeyStatement);
                case 750: return RestoreOption.FromMutable(fragment as ScriptDom.RestoreOption);
                case 751: return RestoreServiceMasterKeyStatement.FromMutable(fragment as ScriptDom.RestoreServiceMasterKeyStatement);
                case 752: return RestoreStatement.FromMutable(fragment as ScriptDom.RestoreStatement);
                case 753: return ResultColumnDefinition.FromMutable(fragment as ScriptDom.ResultColumnDefinition);
                case 754: return ResultSetDefinition.FromMutable(fragment as ScriptDom.ResultSetDefinition);
                case 755: return ResultSetsExecuteOption.FromMutable(fragment as ScriptDom.ResultSetsExecuteOption);
                case 756: return RetentionDaysAuditTargetOption.FromMutable(fragment as ScriptDom.RetentionDaysAuditTargetOption);
                case 757: return RetentionPeriodDefinition.FromMutable(fragment as ScriptDom.RetentionPeriodDefinition);
                case 758: return ReturnStatement.FromMutable(fragment as ScriptDom.ReturnStatement);
                case 759: return RevertStatement.FromMutable(fragment as ScriptDom.RevertStatement);
                case 760: return RevokeStatement.FromMutable(fragment as ScriptDom.RevokeStatement);
                case 761: return RevokeStatement80.FromMutable(fragment as ScriptDom.RevokeStatement80);
                case 762: return RightFunctionCall.FromMutable(fragment as ScriptDom.RightFunctionCall);
                case 763: return RolePayloadOption.FromMutable(fragment as ScriptDom.RolePayloadOption);
                case 764: return RollbackTransactionStatement.FromMutable(fragment as ScriptDom.RollbackTransactionStatement);
                case 765: return RollupGroupingSpecification.FromMutable(fragment as ScriptDom.RollupGroupingSpecification);
                case 766: return RouteOption.FromMutable(fragment as ScriptDom.RouteOption);
                case 767: return RowValue.FromMutable(fragment as ScriptDom.RowValue);
                case 768: return SaveTransactionStatement.FromMutable(fragment as ScriptDom.SaveTransactionStatement);
                case 769: return ScalarExpressionDialogOption.FromMutable(fragment as ScriptDom.ScalarExpressionDialogOption);
                case 770: return ScalarExpressionRestoreOption.FromMutable(fragment as ScriptDom.ScalarExpressionRestoreOption);
                case 771: return ScalarExpressionSequenceOption.FromMutable(fragment as ScriptDom.ScalarExpressionSequenceOption);
                case 772: return ScalarExpressionSnippet.FromMutable(fragment as ScriptDom.ScalarExpressionSnippet);
                case 773: return ScalarFunctionReturnType.FromMutable(fragment as ScriptDom.ScalarFunctionReturnType);
                case 774: return ScalarSubquery.FromMutable(fragment as ScriptDom.ScalarSubquery);
                case 775: return SchemaDeclarationItem.FromMutable(fragment as ScriptDom.SchemaDeclarationItem);
                case 776: return SchemaDeclarationItemOpenjson.FromMutable(fragment as ScriptDom.SchemaDeclarationItemOpenjson);
                case 777: return SchemaObjectFunctionTableReference.FromMutable(fragment as ScriptDom.SchemaObjectFunctionTableReference);
                case 778: return SchemaObjectName.FromMutable(fragment as ScriptDom.SchemaObjectName);
                case 779: return SchemaObjectNameOrValueExpression.FromMutable(fragment as ScriptDom.SchemaObjectNameOrValueExpression);
                case 780: return SchemaObjectNameSnippet.FromMutable(fragment as ScriptDom.SchemaObjectNameSnippet);
                case 781: return SchemaObjectResultSetDefinition.FromMutable(fragment as ScriptDom.SchemaObjectResultSetDefinition);
                case 782: return SchemaPayloadOption.FromMutable(fragment as ScriptDom.SchemaPayloadOption);
                case 783: return SearchedCaseExpression.FromMutable(fragment as ScriptDom.SearchedCaseExpression);
                case 784: return SearchedWhenClause.FromMutable(fragment as ScriptDom.SearchedWhenClause);
                case 785: return SearchPropertyListFullTextIndexOption.FromMutable(fragment as ScriptDom.SearchPropertyListFullTextIndexOption);
                case 786: return SecondaryRoleReplicaOption.FromMutable(fragment as ScriptDom.SecondaryRoleReplicaOption);
                case 787: return SecurityPolicyOption.FromMutable(fragment as ScriptDom.SecurityPolicyOption);
                case 788: return SecurityPredicateAction.FromMutable(fragment as ScriptDom.SecurityPredicateAction);
                case 789: return SecurityPrincipal.FromMutable(fragment as ScriptDom.SecurityPrincipal);
                case 790: return SecurityTargetObject.FromMutable(fragment as ScriptDom.SecurityTargetObject);
                case 791: return SecurityTargetObjectName.FromMutable(fragment as ScriptDom.SecurityTargetObjectName);
                case 792: return SecurityUserClause80.FromMutable(fragment as ScriptDom.SecurityUserClause80);
                case 793: return SelectFunctionReturnType.FromMutable(fragment as ScriptDom.SelectFunctionReturnType);
                case 794: return SelectInsertSource.FromMutable(fragment as ScriptDom.SelectInsertSource);
                case 795: return SelectiveXmlIndexPromotedPath.FromMutable(fragment as ScriptDom.SelectiveXmlIndexPromotedPath);
                case 796: return SelectScalarExpression.FromMutable(fragment as ScriptDom.SelectScalarExpression);
                case 797: return SelectSetVariable.FromMutable(fragment as ScriptDom.SelectSetVariable);
                case 798: return SelectStarExpression.FromMutable(fragment as ScriptDom.SelectStarExpression);
                case 799: return SelectStatement.FromMutable(fragment as ScriptDom.SelectStatement);
                case 800: return SelectStatementSnippet.FromMutable(fragment as ScriptDom.SelectStatementSnippet);
                case 801: return SemanticIndexChunkOption.FromMutable(fragment as ScriptDom.SemanticIndexChunkOption);
                case 802: return SemanticIndexColumn.FromMutable(fragment as ScriptDom.SemanticIndexColumn);
                case 803: return SemanticTableReference.FromMutable(fragment as ScriptDom.SemanticTableReference);
                case 804: return SendStatement.FromMutable(fragment as ScriptDom.SendStatement);
                case 805: return SensitivityClassificationOption.FromMutable(fragment as ScriptDom.SensitivityClassificationOption);
                case 806: return SequenceOption.FromMutable(fragment as ScriptDom.SequenceOption);
                case 807: return ServiceContract.FromMutable(fragment as ScriptDom.ServiceContract);
                case 808: return SessionTimeoutPayloadOption.FromMutable(fragment as ScriptDom.SessionTimeoutPayloadOption);
                case 809: return SetCommandStatement.FromMutable(fragment as ScriptDom.SetCommandStatement);
                case 810: return SetErrorLevelStatement.FromMutable(fragment as ScriptDom.SetErrorLevelStatement);
                case 811: return SetFipsFlaggerCommand.FromMutable(fragment as ScriptDom.SetFipsFlaggerCommand);
                case 812: return SetIdentityInsertStatement.FromMutable(fragment as ScriptDom.SetIdentityInsertStatement);
                case 813: return SetOffsetsStatement.FromMutable(fragment as ScriptDom.SetOffsetsStatement);
                case 814: return SetRowCountStatement.FromMutable(fragment as ScriptDom.SetRowCountStatement);
                case 815: return SetSearchPropertyListAlterFullTextIndexAction.FromMutable(fragment as ScriptDom.SetSearchPropertyListAlterFullTextIndexAction);
                case 816: return SetStatisticsStatement.FromMutable(fragment as ScriptDom.SetStatisticsStatement);
                case 817: return SetStopListAlterFullTextIndexAction.FromMutable(fragment as ScriptDom.SetStopListAlterFullTextIndexAction);
                case 818: return SetTextSizeStatement.FromMutable(fragment as ScriptDom.SetTextSizeStatement);
                case 819: return SetTransactionIsolationLevelStatement.FromMutable(fragment as ScriptDom.SetTransactionIsolationLevelStatement);
                case 820: return SetUserStatement.FromMutable(fragment as ScriptDom.SetUserStatement);
                case 821: return SetVariableStatement.FromMutable(fragment as ScriptDom.SetVariableStatement);
                case 822: return ShutdownStatement.FromMutable(fragment as ScriptDom.ShutdownStatement);
                case 823: return SimpleAlterFullTextIndexAction.FromMutable(fragment as ScriptDom.SimpleAlterFullTextIndexAction);
                case 824: return SimpleCaseExpression.FromMutable(fragment as ScriptDom.SimpleCaseExpression);
                case 825: return SimpleWhenClause.FromMutable(fragment as ScriptDom.SimpleWhenClause);
                case 826: return SingleValueTypeCopyOption.FromMutable(fragment as ScriptDom.SingleValueTypeCopyOption);
                case 827: return SizeFileDeclarationOption.FromMutable(fragment as ScriptDom.SizeFileDeclarationOption);
                case 828: return SoapMethod.FromMutable(fragment as ScriptDom.SoapMethod);
                case 829: return SourceDeclaration.FromMutable(fragment as ScriptDom.SourceDeclaration);
                case 830: return SpatialIndexRegularOption.FromMutable(fragment as ScriptDom.SpatialIndexRegularOption);
                case 831: return SqlCommandIdentifier.FromMutable(fragment as ScriptDom.SqlCommandIdentifier);
                case 832: return SqlDataTypeReference.FromMutable(fragment as ScriptDom.SqlDataTypeReference);
                case 833: return StateAuditOption.FromMutable(fragment as ScriptDom.StateAuditOption);
                case 834: return StatementList.FromMutable(fragment as ScriptDom.StatementList);
                case 835: return StatementListSnippet.FromMutable(fragment as ScriptDom.StatementListSnippet);
                case 836: return StatisticsOption.FromMutable(fragment as ScriptDom.StatisticsOption);
                case 837: return StatisticsPartitionRange.FromMutable(fragment as ScriptDom.StatisticsPartitionRange);
                case 838: return StopListFullTextIndexOption.FromMutable(fragment as ScriptDom.StopListFullTextIndexOption);
                case 839: return StopRestoreOption.FromMutable(fragment as ScriptDom.StopRestoreOption);
                case 840: return StringLiteral.FromMutable(fragment as ScriptDom.StringLiteral);
                case 841: return SubqueryComparisonPredicate.FromMutable(fragment as ScriptDom.SubqueryComparisonPredicate);
                case 842: return SystemTimePeriodDefinition.FromMutable(fragment as ScriptDom.SystemTimePeriodDefinition);
                case 843: return SystemVersioningTableOption.FromMutable(fragment as ScriptDom.SystemVersioningTableOption);
                case 844: return TableClusteredIndexType.FromMutable(fragment as ScriptDom.TableClusteredIndexType);
                case 845: return TableDataCompressionOption.FromMutable(fragment as ScriptDom.TableDataCompressionOption);
                case 846: return TableDefinition.FromMutable(fragment as ScriptDom.TableDefinition);
                case 847: return TableDistributionOption.FromMutable(fragment as ScriptDom.TableDistributionOption);
                case 848: return TableHashDistributionPolicy.FromMutable(fragment as ScriptDom.TableHashDistributionPolicy);
                case 849: return TableHint.FromMutable(fragment as ScriptDom.TableHint);
                case 850: return TableHintsOptimizerHint.FromMutable(fragment as ScriptDom.TableHintsOptimizerHint);
                case 851: return TableIndexOption.FromMutable(fragment as ScriptDom.TableIndexOption);
                case 852: return TableNonClusteredIndexType.FromMutable(fragment as ScriptDom.TableNonClusteredIndexType);
                case 853: return TablePartitionOption.FromMutable(fragment as ScriptDom.TablePartitionOption);
                case 854: return TablePartitionOptionSpecifications.FromMutable(fragment as ScriptDom.TablePartitionOptionSpecifications);
                case 855: return TableReplicateDistributionPolicy.FromMutable(fragment as ScriptDom.TableReplicateDistributionPolicy);
                case 856: return TableRoundRobinDistributionPolicy.FromMutable(fragment as ScriptDom.TableRoundRobinDistributionPolicy);
                case 857: return TableSampleClause.FromMutable(fragment as ScriptDom.TableSampleClause);
                case 858: return TableValuedFunctionReturnType.FromMutable(fragment as ScriptDom.TableValuedFunctionReturnType);
                case 859: return TableXmlCompressionOption.FromMutable(fragment as ScriptDom.TableXmlCompressionOption);
                case 860: return TargetDeclaration.FromMutable(fragment as ScriptDom.TargetDeclaration);
                case 861: return TargetRecoveryTimeDatabaseOption.FromMutable(fragment as ScriptDom.TargetRecoveryTimeDatabaseOption);
                case 862: return TemporalClause.FromMutable(fragment as ScriptDom.TemporalClause);
                case 863: return ThrowStatement.FromMutable(fragment as ScriptDom.ThrowStatement);
                case 864: return TopRowFilter.FromMutable(fragment as ScriptDom.TopRowFilter);
                case 865: return TriggerAction.FromMutable(fragment as ScriptDom.TriggerAction);
                case 866: return TriggerObject.FromMutable(fragment as ScriptDom.TriggerObject);
                case 867: return TriggerOption.FromMutable(fragment as ScriptDom.TriggerOption);
                case 868: return TruncateTableStatement.FromMutable(fragment as ScriptDom.TruncateTableStatement);
                case 869: return TruncateTargetTableSwitchOption.FromMutable(fragment as ScriptDom.TruncateTargetTableSwitchOption);
                case 870: return TryCastCall.FromMutable(fragment as ScriptDom.TryCastCall);
                case 871: return TryCatchStatement.FromMutable(fragment as ScriptDom.TryCatchStatement);
                case 872: return TryConvertCall.FromMutable(fragment as ScriptDom.TryConvertCall);
                case 873: return TryParseCall.FromMutable(fragment as ScriptDom.TryParseCall);
                case 874: return TSEqualCall.FromMutable(fragment as ScriptDom.TSEqualCall);
                case 875: return TSqlBatch.FromMutable(fragment as ScriptDom.TSqlBatch);
                case 876: return TSqlFragmentSnippet.FromMutable(fragment as ScriptDom.TSqlFragmentSnippet);
                case 877: return TSqlScript.FromMutable(fragment as ScriptDom.TSqlScript);
                case 878: return TSqlStatementSnippet.FromMutable(fragment as ScriptDom.TSqlStatementSnippet);
                case 879: return UnaryExpression.FromMutable(fragment as ScriptDom.UnaryExpression);
                case 880: return UniqueConstraintDefinition.FromMutable(fragment as ScriptDom.UniqueConstraintDefinition);
                case 881: return UnpivotedTableReference.FromMutable(fragment as ScriptDom.UnpivotedTableReference);
                case 882: return UnqualifiedJoin.FromMutable(fragment as ScriptDom.UnqualifiedJoin);
                case 883: return UpdateCall.FromMutable(fragment as ScriptDom.UpdateCall);
                case 884: return UpdateForClause.FromMutable(fragment as ScriptDom.UpdateForClause);
                case 885: return UpdateMergeAction.FromMutable(fragment as ScriptDom.UpdateMergeAction);
                case 886: return UpdateSpecification.FromMutable(fragment as ScriptDom.UpdateSpecification);
                case 887: return UpdateStatement.FromMutable(fragment as ScriptDom.UpdateStatement);
                case 888: return UpdateStatisticsStatement.FromMutable(fragment as ScriptDom.UpdateStatisticsStatement);
                case 889: return UpdateTextStatement.FromMutable(fragment as ScriptDom.UpdateTextStatement);
                case 890: return UseFederationStatement.FromMutable(fragment as ScriptDom.UseFederationStatement);
                case 891: return UseHintList.FromMutable(fragment as ScriptDom.UseHintList);
                case 892: return UserDataTypeReference.FromMutable(fragment as ScriptDom.UserDataTypeReference);
                case 893: return UserDefinedTypeCallTarget.FromMutable(fragment as ScriptDom.UserDefinedTypeCallTarget);
                case 894: return UserDefinedTypePropertyAccess.FromMutable(fragment as ScriptDom.UserDefinedTypePropertyAccess);
                case 895: return UserLoginOption.FromMutable(fragment as ScriptDom.UserLoginOption);
                case 896: return UserRemoteServiceBindingOption.FromMutable(fragment as ScriptDom.UserRemoteServiceBindingOption);
                case 897: return UseStatement.FromMutable(fragment as ScriptDom.UseStatement);
                case 898: return ValuesInsertSource.FromMutable(fragment as ScriptDom.ValuesInsertSource);
                case 899: return VariableMethodCallTableReference.FromMutable(fragment as ScriptDom.VariableMethodCallTableReference);
                case 900: return VariableReference.FromMutable(fragment as ScriptDom.VariableReference);
                case 901: return VariableTableReference.FromMutable(fragment as ScriptDom.VariableTableReference);
                case 902: return VariableValuePair.FromMutable(fragment as ScriptDom.VariableValuePair);
                case 903: return VectorDataTypeReference.FromMutable(fragment as ScriptDom.VectorDataTypeReference);
                case 904: return VectorMetricIndexOption.FromMutable(fragment as ScriptDom.VectorMetricIndexOption);
                case 905: return VectorSearchTableReference.FromMutable(fragment as ScriptDom.VectorSearchTableReference);
                case 906: return VectorTypeIndexOption.FromMutable(fragment as ScriptDom.VectorTypeIndexOption);
                case 907: return ViewDistributionOption.FromMutable(fragment as ScriptDom.ViewDistributionOption);
                case 908: return ViewForAppendOption.FromMutable(fragment as ScriptDom.ViewForAppendOption);
                case 909: return ViewHashDistributionPolicy.FromMutable(fragment as ScriptDom.ViewHashDistributionPolicy);
                case 910: return ViewOption.FromMutable(fragment as ScriptDom.ViewOption);
                case 911: return ViewRoundRobinDistributionPolicy.FromMutable(fragment as ScriptDom.ViewRoundRobinDistributionPolicy);
                case 912: return WaitAtLowPriorityOption.FromMutable(fragment as ScriptDom.WaitAtLowPriorityOption);
                case 913: return WaitForStatement.FromMutable(fragment as ScriptDom.WaitForStatement);
                case 914: return WhereClause.FromMutable(fragment as ScriptDom.WhereClause);
                case 915: return WhileStatement.FromMutable(fragment as ScriptDom.WhileStatement);
                case 916: return WindowClause.FromMutable(fragment as ScriptDom.WindowClause);
                case 917: return WindowDefinition.FromMutable(fragment as ScriptDom.WindowDefinition);
                case 918: return WindowDelimiter.FromMutable(fragment as ScriptDom.WindowDelimiter);
                case 919: return WindowFrameClause.FromMutable(fragment as ScriptDom.WindowFrameClause);
                case 920: return WindowsCreateLoginSource.FromMutable(fragment as ScriptDom.WindowsCreateLoginSource);
                case 921: return WithCtesAndXmlNamespaces.FromMutable(fragment as ScriptDom.WithCtesAndXmlNamespaces);
                case 922: return WithinGroupClause.FromMutable(fragment as ScriptDom.WithinGroupClause);
                case 923: return WitnessDatabaseOption.FromMutable(fragment as ScriptDom.WitnessDatabaseOption);
                case 924: return WlmTimeLiteral.FromMutable(fragment as ScriptDom.WlmTimeLiteral);
                case 925: return WorkloadGroupImportanceParameter.FromMutable(fragment as ScriptDom.WorkloadGroupImportanceParameter);
                case 926: return WorkloadGroupResourceParameter.FromMutable(fragment as ScriptDom.WorkloadGroupResourceParameter);
                case 927: return WriteTextStatement.FromMutable(fragment as ScriptDom.WriteTextStatement);
                case 928: return WsdlPayloadOption.FromMutable(fragment as ScriptDom.WsdlPayloadOption);
                case 929: return XmlCompressionOption.FromMutable(fragment as ScriptDom.XmlCompressionOption);
                case 930: return XmlDataTypeReference.FromMutable(fragment as ScriptDom.XmlDataTypeReference);
                case 931: return XmlForClause.FromMutable(fragment as ScriptDom.XmlForClause);
                case 932: return XmlForClauseOption.FromMutable(fragment as ScriptDom.XmlForClauseOption);
                case 933: return XmlNamespaces.FromMutable(fragment as ScriptDom.XmlNamespaces);
                case 934: return XmlNamespacesAliasElement.FromMutable(fragment as ScriptDom.XmlNamespacesAliasElement);
                case 935: return XmlNamespacesDefaultElement.FromMutable(fragment as ScriptDom.XmlNamespacesDefaultElement);
                default: throw new NotImplementedException("Type not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library.");
            }
        }
    
    }

}
