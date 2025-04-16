using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
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
            ["AlgorithmKeyOption"] = 10,
            ["AlterApplicationRoleStatement"] = 11,
            ["AlterAssemblyStatement"] = 12,
            ["AlterAsymmetricKeyStatement"] = 13,
            ["AlterAuthorizationStatement"] = 14,
            ["AlterAvailabilityGroupAction"] = 15,
            ["AlterAvailabilityGroupFailoverAction"] = 16,
            ["AlterAvailabilityGroupFailoverOption"] = 17,
            ["AlterAvailabilityGroupStatement"] = 18,
            ["AlterBrokerPriorityStatement"] = 19,
            ["AlterCertificateStatement"] = 20,
            ["AlterColumnAlterFullTextIndexAction"] = 21,
            ["AlterColumnEncryptionKeyStatement"] = 22,
            ["AlterCredentialStatement"] = 23,
            ["AlterCryptographicProviderStatement"] = 24,
            ["AlterDatabaseAddFileGroupStatement"] = 25,
            ["AlterDatabaseAddFileStatement"] = 26,
            ["AlterDatabaseAuditSpecificationStatement"] = 27,
            ["AlterDatabaseCollateStatement"] = 28,
            ["AlterDatabaseEncryptionKeyStatement"] = 29,
            ["AlterDatabaseModifyFileGroupStatement"] = 30,
            ["AlterDatabaseModifyFileStatement"] = 31,
            ["AlterDatabaseModifyNameStatement"] = 32,
            ["AlterDatabaseRebuildLogStatement"] = 33,
            ["AlterDatabaseRemoveFileGroupStatement"] = 34,
            ["AlterDatabaseRemoveFileStatement"] = 35,
            ["AlterDatabaseScopedConfigurationClearStatement"] = 36,
            ["AlterDatabaseScopedConfigurationSetStatement"] = 37,
            ["AlterDatabaseSetStatement"] = 38,
            ["AlterDatabaseTermination"] = 39,
            ["AlterEndpointStatement"] = 40,
            ["AlterEventSessionStatement"] = 41,
            ["AlterExternalDataSourceStatement"] = 42,
            ["AlterExternalLanguageStatement"] = 43,
            ["AlterExternalLibraryStatement"] = 44,
            ["AlterExternalResourcePoolStatement"] = 45,
            ["AlterFederationStatement"] = 46,
            ["AlterFullTextCatalogStatement"] = 47,
            ["AlterFullTextIndexStatement"] = 48,
            ["AlterFullTextStopListStatement"] = 49,
            ["AlterFunctionStatement"] = 50,
            ["AlterIndexStatement"] = 51,
            ["AlterLoginAddDropCredentialStatement"] = 52,
            ["AlterLoginEnableDisableStatement"] = 53,
            ["AlterLoginOptionsStatement"] = 54,
            ["AlterMasterKeyStatement"] = 55,
            ["AlterMessageTypeStatement"] = 56,
            ["AlterPartitionFunctionStatement"] = 57,
            ["AlterPartitionSchemeStatement"] = 58,
            ["AlterProcedureStatement"] = 59,
            ["AlterQueueStatement"] = 60,
            ["AlterRemoteServiceBindingStatement"] = 61,
            ["AlterResourceGovernorStatement"] = 62,
            ["AlterResourcePoolStatement"] = 63,
            ["AlterRoleStatement"] = 64,
            ["AlterRouteStatement"] = 65,
            ["AlterSchemaStatement"] = 66,
            ["AlterSearchPropertyListStatement"] = 67,
            ["AlterSecurityPolicyStatement"] = 68,
            ["AlterSequenceStatement"] = 69,
            ["AlterServerAuditSpecificationStatement"] = 70,
            ["AlterServerAuditStatement"] = 71,
            ["AlterServerConfigurationBufferPoolExtensionContainerOption"] = 72,
            ["AlterServerConfigurationBufferPoolExtensionOption"] = 73,
            ["AlterServerConfigurationBufferPoolExtensionSizeOption"] = 74,
            ["AlterServerConfigurationDiagnosticsLogMaxSizeOption"] = 75,
            ["AlterServerConfigurationDiagnosticsLogOption"] = 76,
            ["AlterServerConfigurationExternalAuthenticationContainerOption"] = 77,
            ["AlterServerConfigurationExternalAuthenticationOption"] = 78,
            ["AlterServerConfigurationFailoverClusterPropertyOption"] = 79,
            ["AlterServerConfigurationHadrClusterOption"] = 80,
            ["AlterServerConfigurationSetBufferPoolExtensionStatement"] = 81,
            ["AlterServerConfigurationSetDiagnosticsLogStatement"] = 82,
            ["AlterServerConfigurationSetExternalAuthenticationStatement"] = 83,
            ["AlterServerConfigurationSetFailoverClusterPropertyStatement"] = 84,
            ["AlterServerConfigurationSetHadrClusterStatement"] = 85,
            ["AlterServerConfigurationSetSoftNumaStatement"] = 86,
            ["AlterServerConfigurationSoftNumaOption"] = 87,
            ["AlterServerConfigurationStatement"] = 88,
            ["AlterServerRoleStatement"] = 89,
            ["AlterServiceMasterKeyStatement"] = 90,
            ["AlterServiceStatement"] = 91,
            ["AlterSymmetricKeyStatement"] = 92,
            ["AlterTableAddTableElementStatement"] = 93,
            ["AlterTableAlterColumnStatement"] = 94,
            ["AlterTableAlterIndexStatement"] = 95,
            ["AlterTableAlterPartitionStatement"] = 96,
            ["AlterTableChangeTrackingModificationStatement"] = 97,
            ["AlterTableConstraintModificationStatement"] = 98,
            ["AlterTableDropTableElement"] = 99,
            ["AlterTableDropTableElementStatement"] = 100,
            ["AlterTableFileTableNamespaceStatement"] = 101,
            ["AlterTableRebuildStatement"] = 102,
            ["AlterTableSetStatement"] = 103,
            ["AlterTableSwitchStatement"] = 104,
            ["AlterTableTriggerModificationStatement"] = 105,
            ["AlterTriggerStatement"] = 106,
            ["AlterUserStatement"] = 107,
            ["AlterViewStatement"] = 108,
            ["AlterWorkloadGroupStatement"] = 109,
            ["AlterXmlSchemaCollectionStatement"] = 110,
            ["ApplicationRoleOption"] = 111,
            ["AssemblyEncryptionSource"] = 112,
            ["AssemblyName"] = 113,
            ["AssemblyOption"] = 114,
            ["AssignmentSetClause"] = 115,
            ["AsymmetricKeyCreateLoginSource"] = 116,
            ["AtTimeZoneCall"] = 117,
            ["AuditActionGroupReference"] = 118,
            ["AuditActionSpecification"] = 119,
            ["AuditGuidAuditOption"] = 120,
            ["AuditSpecificationPart"] = 121,
            ["AuditTarget"] = 122,
            ["AuthenticationEndpointProtocolOption"] = 123,
            ["AuthenticationPayloadOption"] = 124,
            ["AutoCleanupChangeTrackingOptionDetail"] = 125,
            ["AutoCreateStatisticsDatabaseOption"] = 126,
            ["AutomaticTuningCreateIndexOption"] = 127,
            ["AutomaticTuningDatabaseOption"] = 128,
            ["AutomaticTuningDropIndexOption"] = 129,
            ["AutomaticTuningForceLastGoodPlanOption"] = 130,
            ["AutomaticTuningMaintainIndexOption"] = 131,
            ["AutomaticTuningOption"] = 132,
            ["AvailabilityModeReplicaOption"] = 133,
            ["AvailabilityReplica"] = 134,
            ["BackupCertificateStatement"] = 135,
            ["BackupDatabaseStatement"] = 136,
            ["BackupEncryptionOption"] = 137,
            ["BackupMasterKeyStatement"] = 138,
            ["BackupOption"] = 139,
            ["BackupRestoreFileInfo"] = 140,
            ["BackupServiceMasterKeyStatement"] = 141,
            ["BackupTransactionLogStatement"] = 142,
            ["BackwardsCompatibleDropIndexClause"] = 143,
            ["BeginConversationTimerStatement"] = 144,
            ["BeginDialogStatement"] = 145,
            ["BeginEndAtomicBlockStatement"] = 146,
            ["BeginEndBlockStatement"] = 147,
            ["BeginTransactionStatement"] = 148,
            ["BinaryExpression"] = 149,
            ["BinaryLiteral"] = 150,
            ["BinaryQueryExpression"] = 151,
            ["BooleanBinaryExpression"] = 152,
            ["BooleanComparisonExpression"] = 153,
            ["BooleanExpressionSnippet"] = 154,
            ["BooleanIsNullExpression"] = 155,
            ["BooleanNotExpression"] = 156,
            ["BooleanParenthesisExpression"] = 157,
            ["BooleanTernaryExpression"] = 158,
            ["BoundingBoxParameter"] = 159,
            ["BoundingBoxSpatialIndexOption"] = 160,
            ["BreakStatement"] = 161,
            ["BrokerPriorityParameter"] = 162,
            ["BrowseForClause"] = 163,
            ["BuiltInFunctionTableReference"] = 164,
            ["BulkInsertOption"] = 165,
            ["BulkInsertStatement"] = 166,
            ["BulkOpenRowset"] = 167,
            ["CastCall"] = 168,
            ["CatalogCollationOption"] = 169,
            ["CellsPerObjectSpatialIndexOption"] = 170,
            ["CertificateCreateLoginSource"] = 171,
            ["CertificateOption"] = 172,
            ["ChangeRetentionChangeTrackingOptionDetail"] = 173,
            ["ChangeTableChangesTableReference"] = 174,
            ["ChangeTableVersionTableReference"] = 175,
            ["ChangeTrackingDatabaseOption"] = 176,
            ["ChangeTrackingFullTextIndexOption"] = 177,
            ["CharacterSetPayloadOption"] = 178,
            ["CheckConstraintDefinition"] = 179,
            ["CheckpointStatement"] = 180,
            ["ChildObjectName"] = 181,
            ["ClassifierEndTimeOption"] = 182,
            ["ClassifierImportanceOption"] = 183,
            ["ClassifierMemberNameOption"] = 184,
            ["ClassifierStartTimeOption"] = 185,
            ["ClassifierWlmContextOption"] = 186,
            ["ClassifierWlmLabelOption"] = 187,
            ["ClassifierWorkloadGroupOption"] = 188,
            ["CloseCursorStatement"] = 189,
            ["CloseMasterKeyStatement"] = 190,
            ["CloseSymmetricKeyStatement"] = 191,
            ["CoalesceExpression"] = 192,
            ["ColumnDefinition"] = 193,
            ["ColumnDefinitionBase"] = 194,
            ["ColumnEncryptionAlgorithmNameParameter"] = 195,
            ["ColumnEncryptionAlgorithmParameter"] = 196,
            ["ColumnEncryptionDefinition"] = 197,
            ["ColumnEncryptionKeyNameParameter"] = 198,
            ["ColumnEncryptionKeyValue"] = 199,
            ["ColumnEncryptionTypeParameter"] = 200,
            ["ColumnMasterKeyEnclaveComputationsParameter"] = 201,
            ["ColumnMasterKeyNameParameter"] = 202,
            ["ColumnMasterKeyPathParameter"] = 203,
            ["ColumnMasterKeyStoreProviderNameParameter"] = 204,
            ["ColumnReferenceExpression"] = 205,
            ["ColumnStorageOptions"] = 206,
            ["ColumnWithSortOrder"] = 207,
            ["CommandSecurityElement80"] = 208,
            ["CommitTransactionStatement"] = 209,
            ["CommonTableExpression"] = 210,
            ["CompositeGroupingSpecification"] = 211,
            ["CompressionDelayIndexOption"] = 212,
            ["CompressionEndpointProtocolOption"] = 213,
            ["CompressionPartitionRange"] = 214,
            ["ComputeClause"] = 215,
            ["ComputeFunction"] = 216,
            ["ContainmentDatabaseOption"] = 217,
            ["ContinueStatement"] = 218,
            ["ContractMessage"] = 219,
            ["ConvertCall"] = 220,
            ["CopyColumnOption"] = 221,
            ["CopyCredentialOption"] = 222,
            ["CopyOption"] = 223,
            ["CopyStatement"] = 224,
            ["CreateAggregateStatement"] = 225,
            ["CreateApplicationRoleStatement"] = 226,
            ["CreateAssemblyStatement"] = 227,
            ["CreateAsymmetricKeyStatement"] = 228,
            ["CreateAvailabilityGroupStatement"] = 229,
            ["CreateBrokerPriorityStatement"] = 230,
            ["CreateCertificateStatement"] = 231,
            ["CreateColumnEncryptionKeyStatement"] = 232,
            ["CreateColumnMasterKeyStatement"] = 233,
            ["CreateColumnStoreIndexStatement"] = 234,
            ["CreateContractStatement"] = 235,
            ["CreateCredentialStatement"] = 236,
            ["CreateCryptographicProviderStatement"] = 237,
            ["CreateDatabaseAuditSpecificationStatement"] = 238,
            ["CreateDatabaseEncryptionKeyStatement"] = 239,
            ["CreateDatabaseStatement"] = 240,
            ["CreateDefaultStatement"] = 241,
            ["CreateEndpointStatement"] = 242,
            ["CreateEventNotificationStatement"] = 243,
            ["CreateEventSessionStatement"] = 244,
            ["CreateExternalDataSourceStatement"] = 245,
            ["CreateExternalFileFormatStatement"] = 246,
            ["CreateExternalLanguageStatement"] = 247,
            ["CreateExternalLibraryStatement"] = 248,
            ["CreateExternalResourcePoolStatement"] = 249,
            ["CreateExternalStreamingJobStatement"] = 250,
            ["CreateExternalStreamStatement"] = 251,
            ["CreateExternalTableStatement"] = 252,
            ["CreateFederationStatement"] = 253,
            ["CreateFullTextCatalogStatement"] = 254,
            ["CreateFullTextIndexStatement"] = 255,
            ["CreateFullTextStopListStatement"] = 256,
            ["CreateFunctionStatement"] = 257,
            ["CreateIndexStatement"] = 258,
            ["CreateLoginStatement"] = 259,
            ["CreateMasterKeyStatement"] = 260,
            ["CreateMessageTypeStatement"] = 261,
            ["CreateOrAlterFunctionStatement"] = 262,
            ["CreateOrAlterProcedureStatement"] = 263,
            ["CreateOrAlterTriggerStatement"] = 264,
            ["CreateOrAlterViewStatement"] = 265,
            ["CreatePartitionFunctionStatement"] = 266,
            ["CreatePartitionSchemeStatement"] = 267,
            ["CreateProcedureStatement"] = 268,
            ["CreateQueueStatement"] = 269,
            ["CreateRemoteServiceBindingStatement"] = 270,
            ["CreateResourcePoolStatement"] = 271,
            ["CreateRoleStatement"] = 272,
            ["CreateRouteStatement"] = 273,
            ["CreateRuleStatement"] = 274,
            ["CreateSchemaStatement"] = 275,
            ["CreateSearchPropertyListStatement"] = 276,
            ["CreateSecurityPolicyStatement"] = 277,
            ["CreateSelectiveXmlIndexStatement"] = 278,
            ["CreateSequenceStatement"] = 279,
            ["CreateServerAuditSpecificationStatement"] = 280,
            ["CreateServerAuditStatement"] = 281,
            ["CreateServerRoleStatement"] = 282,
            ["CreateServiceStatement"] = 283,
            ["CreateSpatialIndexStatement"] = 284,
            ["CreateStatisticsStatement"] = 285,
            ["CreateSymmetricKeyStatement"] = 286,
            ["CreateSynonymStatement"] = 287,
            ["CreateTableStatement"] = 288,
            ["CreateTriggerStatement"] = 289,
            ["CreateTypeTableStatement"] = 290,
            ["CreateTypeUddtStatement"] = 291,
            ["CreateTypeUdtStatement"] = 292,
            ["CreateUserStatement"] = 293,
            ["CreateViewStatement"] = 294,
            ["CreateWorkloadClassifierStatement"] = 295,
            ["CreateWorkloadGroupStatement"] = 296,
            ["CreateXmlIndexStatement"] = 297,
            ["CreateXmlSchemaCollectionStatement"] = 298,
            ["CreationDispositionKeyOption"] = 299,
            ["CryptoMechanism"] = 300,
            ["CubeGroupingSpecification"] = 301,
            ["CursorDefaultDatabaseOption"] = 302,
            ["CursorDefinition"] = 303,
            ["CursorId"] = 304,
            ["CursorOption"] = 305,
            ["DatabaseAuditAction"] = 306,
            ["DatabaseConfigurationClearOption"] = 307,
            ["DatabaseConfigurationSetOption"] = 308,
            ["DatabaseOption"] = 309,
            ["DataCompressionOption"] = 310,
            ["DataModificationTableReference"] = 311,
            ["DataRetentionTableOption"] = 312,
            ["DataTypeSequenceOption"] = 313,
            ["DbccNamedLiteral"] = 314,
            ["DbccOption"] = 315,
            ["DbccStatement"] = 316,
            ["DeallocateCursorStatement"] = 317,
            ["DeclareCursorStatement"] = 318,
            ["DeclareTableVariableBody"] = 319,
            ["DeclareTableVariableStatement"] = 320,
            ["DeclareVariableElement"] = 321,
            ["DeclareVariableStatement"] = 322,
            ["DefaultConstraintDefinition"] = 323,
            ["DefaultLiteral"] = 324,
            ["DelayedDurabilityDatabaseOption"] = 325,
            ["DeleteMergeAction"] = 326,
            ["DeleteSpecification"] = 327,
            ["DeleteStatement"] = 328,
            ["DenyStatement"] = 329,
            ["DenyStatement80"] = 330,
            ["DeviceInfo"] = 331,
            ["DiskStatement"] = 332,
            ["DiskStatementOption"] = 333,
            ["DistinctPredicate"] = 334,
            ["DropAggregateStatement"] = 335,
            ["DropAlterFullTextIndexAction"] = 336,
            ["DropApplicationRoleStatement"] = 337,
            ["DropAssemblyStatement"] = 338,
            ["DropAsymmetricKeyStatement"] = 339,
            ["DropAvailabilityGroupStatement"] = 340,
            ["DropBrokerPriorityStatement"] = 341,
            ["DropCertificateStatement"] = 342,
            ["DropClusteredConstraintMoveOption"] = 343,
            ["DropClusteredConstraintStateOption"] = 344,
            ["DropClusteredConstraintValueOption"] = 345,
            ["DropClusteredConstraintWaitAtLowPriorityLockOption"] = 346,
            ["DropColumnEncryptionKeyStatement"] = 347,
            ["DropColumnMasterKeyStatement"] = 348,
            ["DropContractStatement"] = 349,
            ["DropCredentialStatement"] = 350,
            ["DropCryptographicProviderStatement"] = 351,
            ["DropDatabaseAuditSpecificationStatement"] = 352,
            ["DropDatabaseEncryptionKeyStatement"] = 353,
            ["DropDatabaseStatement"] = 354,
            ["DropDefaultStatement"] = 355,
            ["DropEndpointStatement"] = 356,
            ["DropEventNotificationStatement"] = 357,
            ["DropEventSessionStatement"] = 358,
            ["DropExternalDataSourceStatement"] = 359,
            ["DropExternalFileFormatStatement"] = 360,
            ["DropExternalLanguageStatement"] = 361,
            ["DropExternalLibraryStatement"] = 362,
            ["DropExternalResourcePoolStatement"] = 363,
            ["DropExternalStreamingJobStatement"] = 364,
            ["DropExternalStreamStatement"] = 365,
            ["DropExternalTableStatement"] = 366,
            ["DropFederationStatement"] = 367,
            ["DropFullTextCatalogStatement"] = 368,
            ["DropFullTextIndexStatement"] = 369,
            ["DropFullTextStopListStatement"] = 370,
            ["DropFunctionStatement"] = 371,
            ["DropIndexClause"] = 372,
            ["DropIndexStatement"] = 373,
            ["DropLoginStatement"] = 374,
            ["DropMasterKeyStatement"] = 375,
            ["DropMemberAlterRoleAction"] = 376,
            ["DropMessageTypeStatement"] = 377,
            ["DropPartitionFunctionStatement"] = 378,
            ["DropPartitionSchemeStatement"] = 379,
            ["DropProcedureStatement"] = 380,
            ["DropQueueStatement"] = 381,
            ["DropRemoteServiceBindingStatement"] = 382,
            ["DropResourcePoolStatement"] = 383,
            ["DropRoleStatement"] = 384,
            ["DropRouteStatement"] = 385,
            ["DropRuleStatement"] = 386,
            ["DropSchemaStatement"] = 387,
            ["DropSearchPropertyListAction"] = 388,
            ["DropSearchPropertyListStatement"] = 389,
            ["DropSecurityPolicyStatement"] = 390,
            ["DropSensitivityClassificationStatement"] = 391,
            ["DropSequenceStatement"] = 392,
            ["DropServerAuditSpecificationStatement"] = 393,
            ["DropServerAuditStatement"] = 394,
            ["DropServerRoleStatement"] = 395,
            ["DropServiceStatement"] = 396,
            ["DropSignatureStatement"] = 397,
            ["DropStatisticsStatement"] = 398,
            ["DropSymmetricKeyStatement"] = 399,
            ["DropSynonymStatement"] = 400,
            ["DropTableStatement"] = 401,
            ["DropTriggerStatement"] = 402,
            ["DropTypeStatement"] = 403,
            ["DropUserStatement"] = 404,
            ["DropViewStatement"] = 405,
            ["DropWorkloadClassifierStatement"] = 406,
            ["DropWorkloadGroupStatement"] = 407,
            ["DropXmlSchemaCollectionStatement"] = 408,
            ["DurabilityTableOption"] = 409,
            ["DWCompatibilityLevelConfigurationOption"] = 410,
            ["ElasticPoolSpecification"] = 411,
            ["EnabledDisabledPayloadOption"] = 412,
            ["EnableDisableTriggerStatement"] = 413,
            ["EncryptedValueParameter"] = 414,
            ["EncryptionPayloadOption"] = 415,
            ["EndConversationStatement"] = 416,
            ["EndpointAffinity"] = 417,
            ["EventDeclaration"] = 418,
            ["EventDeclarationCompareFunctionParameter"] = 419,
            ["EventDeclarationSetParameter"] = 420,
            ["EventGroupContainer"] = 421,
            ["EventNotificationObjectScope"] = 422,
            ["EventRetentionSessionOption"] = 423,
            ["EventSessionObjectName"] = 424,
            ["EventSessionStatement"] = 425,
            ["EventTypeContainer"] = 426,
            ["ExecutableProcedureReference"] = 427,
            ["ExecutableStringList"] = 428,
            ["ExecuteAsClause"] = 429,
            ["ExecuteAsFunctionOption"] = 430,
            ["ExecuteAsProcedureOption"] = 431,
            ["ExecuteAsStatement"] = 432,
            ["ExecuteAsTriggerOption"] = 433,
            ["ExecuteContext"] = 434,
            ["ExecuteInsertSource"] = 435,
            ["ExecuteOption"] = 436,
            ["ExecuteParameter"] = 437,
            ["ExecuteSpecification"] = 438,
            ["ExecuteStatement"] = 439,
            ["ExistsPredicate"] = 440,
            ["ExpressionCallTarget"] = 441,
            ["ExpressionGroupingSpecification"] = 442,
            ["ExpressionWithSortOrder"] = 443,
            ["ExternalCreateLoginSource"] = 444,
            ["ExternalDataSourceLiteralOrIdentifierOption"] = 445,
            ["ExternalFileFormatContainerOption"] = 446,
            ["ExternalFileFormatLiteralOption"] = 447,
            ["ExternalFileFormatUseDefaultTypeOption"] = 448,
            ["ExternalLanguageFileOption"] = 449,
            ["ExternalLibraryFileOption"] = 450,
            ["ExternalResourcePoolAffinitySpecification"] = 451,
            ["ExternalResourcePoolParameter"] = 452,
            ["ExternalResourcePoolStatement"] = 453,
            ["ExternalStreamLiteralOrIdentifierOption"] = 454,
            ["ExternalTableColumnDefinition"] = 455,
            ["ExternalTableDistributionOption"] = 456,
            ["ExternalTableLiteralOrIdentifierOption"] = 457,
            ["ExternalTableRejectTypeOption"] = 458,
            ["ExternalTableReplicatedDistributionPolicy"] = 459,
            ["ExternalTableRoundRobinDistributionPolicy"] = 460,
            ["ExternalTableShardedDistributionPolicy"] = 461,
            ["ExtractFromExpression"] = 462,
            ["FailoverModeReplicaOption"] = 463,
            ["FederationScheme"] = 464,
            ["FetchCursorStatement"] = 465,
            ["FetchType"] = 466,
            ["FileDeclaration"] = 467,
            ["FileDeclarationOption"] = 468,
            ["FileEncryptionSource"] = 469,
            ["FileGroupDefinition"] = 470,
            ["FileGroupOrPartitionScheme"] = 471,
            ["FileGrowthFileDeclarationOption"] = 472,
            ["FileNameFileDeclarationOption"] = 473,
            ["FileStreamDatabaseOption"] = 474,
            ["FileStreamOnDropIndexOption"] = 475,
            ["FileStreamOnTableOption"] = 476,
            ["FileStreamRestoreOption"] = 477,
            ["FileTableCollateFileNameTableOption"] = 478,
            ["FileTableConstraintNameTableOption"] = 479,
            ["FileTableDirectoryTableOption"] = 480,
            ["ForceSeekTableHint"] = 481,
            ["ForeignKeyConstraintDefinition"] = 482,
            ["FromClause"] = 483,
            ["FullTextCatalogAndFileGroup"] = 484,
            ["FullTextIndexColumn"] = 485,
            ["FullTextPredicate"] = 486,
            ["FullTextStopListAction"] = 487,
            ["FullTextTableReference"] = 488,
            ["FunctionCall"] = 489,
            ["FunctionCallSetClause"] = 490,
            ["FunctionOption"] = 491,
            ["GeneralSetCommand"] = 492,
            ["GenericConfigurationOption"] = 493,
            ["GetConversationGroupStatement"] = 494,
            ["GlobalFunctionTableReference"] = 495,
            ["GlobalVariableExpression"] = 496,
            ["GoToStatement"] = 497,
            ["GrandTotalGroupingSpecification"] = 498,
            ["GrantStatement"] = 499,
            ["GrantStatement80"] = 500,
            ["GraphConnectionBetweenNodes"] = 501,
            ["GraphConnectionConstraintDefinition"] = 502,
            ["GraphMatchCompositeExpression"] = 503,
            ["GraphMatchExpression"] = 504,
            ["GraphMatchLastNodePredicate"] = 505,
            ["GraphMatchNodeExpression"] = 506,
            ["GraphMatchPredicate"] = 507,
            ["GraphMatchRecursivePredicate"] = 508,
            ["GraphRecursiveMatchQuantifier"] = 509,
            ["GridParameter"] = 510,
            ["GridsSpatialIndexOption"] = 511,
            ["GroupByClause"] = 512,
            ["GroupingSetsGroupingSpecification"] = 513,
            ["HadrAvailabilityGroupDatabaseOption"] = 514,
            ["HadrDatabaseOption"] = 515,
            ["HavingClause"] = 516,
            ["Identifier"] = 517,
            ["IdentifierAtomicBlockOption"] = 518,
            ["IdentifierDatabaseOption"] = 519,
            ["IdentifierLiteral"] = 520,
            ["IdentifierOrScalarExpression"] = 521,
            ["IdentifierOrValueExpression"] = 522,
            ["IdentifierPrincipalOption"] = 523,
            ["IdentifierSnippet"] = 524,
            ["IdentityFunctionCall"] = 525,
            ["IdentityOptions"] = 526,
            ["IdentityValueKeyOption"] = 527,
            ["IfStatement"] = 528,
            ["IgnoreDupKeyIndexOption"] = 529,
            ["IIfCall"] = 530,
            ["IndexDefinition"] = 531,
            ["IndexExpressionOption"] = 532,
            ["IndexStateOption"] = 533,
            ["IndexTableHint"] = 534,
            ["IndexType"] = 535,
            ["InlineDerivedTable"] = 536,
            ["InlineFunctionOption"] = 537,
            ["InlineResultSetDefinition"] = 538,
            ["InPredicate"] = 539,
            ["InsertBulkColumnDefinition"] = 540,
            ["InsertBulkStatement"] = 541,
            ["InsertMergeAction"] = 542,
            ["InsertSpecification"] = 543,
            ["InsertStatement"] = 544,
            ["IntegerLiteral"] = 545,
            ["InternalOpenRowset"] = 546,
            ["IPv4"] = 547,
            ["JoinParenthesisTableReference"] = 548,
            ["JsonForClause"] = 549,
            ["JsonForClauseOption"] = 550,
            ["JsonKeyValue"] = 551,
            ["KeySourceKeyOption"] = 552,
            ["KillQueryNotificationSubscriptionStatement"] = 553,
            ["KillStatement"] = 554,
            ["KillStatsJobStatement"] = 555,
            ["LabelStatement"] = 556,
            ["LedgerOption"] = 557,
            ["LedgerTableOption"] = 558,
            ["LedgerViewOption"] = 559,
            ["LeftFunctionCall"] = 560,
            ["LikePredicate"] = 561,
            ["LineNoStatement"] = 562,
            ["ListenerIPEndpointProtocolOption"] = 563,
            ["ListTypeCopyOption"] = 564,
            ["LiteralAtomicBlockOption"] = 565,
            ["LiteralAuditTargetOption"] = 566,
            ["LiteralAvailabilityGroupOption"] = 567,
            ["LiteralBulkInsertOption"] = 568,
            ["LiteralDatabaseOption"] = 569,
            ["LiteralEndpointProtocolOption"] = 570,
            ["LiteralOpenRowsetCosmosOption"] = 571,
            ["LiteralOptimizerHint"] = 572,
            ["LiteralOptionValue"] = 573,
            ["LiteralPayloadOption"] = 574,
            ["LiteralPrincipalOption"] = 575,
            ["LiteralRange"] = 576,
            ["LiteralReplicaOption"] = 577,
            ["LiteralSessionOption"] = 578,
            ["LiteralStatisticsOption"] = 579,
            ["LiteralTableHint"] = 580,
            ["LocationOption"] = 581,
            ["LockEscalationTableOption"] = 582,
            ["LoginTypePayloadOption"] = 583,
            ["LowPriorityLockWaitAbortAfterWaitOption"] = 584,
            ["LowPriorityLockWaitMaxDurationOption"] = 585,
            ["LowPriorityLockWaitTableSwitchOption"] = 586,
            ["MaxDispatchLatencySessionOption"] = 587,
            ["MaxDopConfigurationOption"] = 588,
            ["MaxDurationOption"] = 589,
            ["MaxLiteral"] = 590,
            ["MaxRolloverFilesAuditTargetOption"] = 591,
            ["MaxSizeAuditTargetOption"] = 592,
            ["MaxSizeDatabaseOption"] = 593,
            ["MaxSizeFileDeclarationOption"] = 594,
            ["MemoryOptimizedTableOption"] = 595,
            ["MemoryPartitionSessionOption"] = 596,
            ["MergeActionClause"] = 597,
            ["MergeSpecification"] = 598,
            ["MergeStatement"] = 599,
            ["MethodSpecifier"] = 600,
            ["MirrorToClause"] = 601,
            ["MoneyLiteral"] = 602,
            ["MoveConversationStatement"] = 603,
            ["MoveRestoreOption"] = 604,
            ["MoveToDropIndexOption"] = 605,
            ["MultiPartIdentifier"] = 606,
            ["MultiPartIdentifierCallTarget"] = 607,
            ["NamedTableReference"] = 608,
            ["NameFileDeclarationOption"] = 609,
            ["NextValueForExpression"] = 610,
            ["NullableConstraintDefinition"] = 611,
            ["NullIfExpression"] = 612,
            ["NullLiteral"] = 613,
            ["NumericLiteral"] = 614,
            ["OdbcConvertSpecification"] = 615,
            ["OdbcFunctionCall"] = 616,
            ["OdbcLiteral"] = 617,
            ["OdbcQualifiedJoinTableReference"] = 618,
            ["OffsetClause"] = 619,
            ["OnFailureAuditOption"] = 620,
            ["OnlineIndexLowPriorityLockWaitOption"] = 621,
            ["OnlineIndexOption"] = 622,
            ["OnOffAssemblyOption"] = 623,
            ["OnOffAtomicBlockOption"] = 624,
            ["OnOffAuditTargetOption"] = 625,
            ["OnOffDatabaseOption"] = 626,
            ["OnOffDialogOption"] = 627,
            ["OnOffFullTextCatalogOption"] = 628,
            ["OnOffOptionValue"] = 629,
            ["OnOffPrimaryConfigurationOption"] = 630,
            ["OnOffPrincipalOption"] = 631,
            ["OnOffRemoteServiceBindingOption"] = 632,
            ["OnOffSessionOption"] = 633,
            ["OnOffStatisticsOption"] = 634,
            ["OpenCursorStatement"] = 635,
            ["OpenJsonTableReference"] = 636,
            ["OpenMasterKeyStatement"] = 637,
            ["OpenQueryTableReference"] = 638,
            ["OpenRowsetColumnDefinition"] = 639,
            ["OpenRowsetCosmos"] = 640,
            ["OpenRowsetCosmosOption"] = 641,
            ["OpenRowsetTableReference"] = 642,
            ["OpenSymmetricKeyStatement"] = 643,
            ["OpenXmlTableReference"] = 644,
            ["OperatorAuditOption"] = 645,
            ["OptimizeForOptimizerHint"] = 646,
            ["OptimizerHint"] = 647,
            ["OrderBulkInsertOption"] = 648,
            ["OrderByClause"] = 649,
            ["OrderIndexOption"] = 650,
            ["OutputClause"] = 651,
            ["OutputIntoClause"] = 652,
            ["OverClause"] = 653,
            ["PageVerifyDatabaseOption"] = 654,
            ["ParameterizationDatabaseOption"] = 655,
            ["ParameterlessCall"] = 656,
            ["ParenthesisExpression"] = 657,
            ["ParseCall"] = 658,
            ["PartitionFunctionCall"] = 659,
            ["PartitionParameterType"] = 660,
            ["PartitionSpecifier"] = 661,
            ["PartnerDatabaseOption"] = 662,
            ["PasswordAlterPrincipalOption"] = 663,
            ["PasswordCreateLoginSource"] = 664,
            ["Permission"] = 665,
            ["PermissionSetAssemblyOption"] = 666,
            ["PivotedTableReference"] = 667,
            ["PortsEndpointProtocolOption"] = 668,
            ["PredicateSetStatement"] = 669,
            ["PredictTableReference"] = 670,
            ["PrimaryRoleReplicaOption"] = 671,
            ["PrincipalOption"] = 672,
            ["PrintStatement"] = 673,
            ["Privilege80"] = 674,
            ["PrivilegeSecurityElement80"] = 675,
            ["ProcedureOption"] = 676,
            ["ProcedureParameter"] = 677,
            ["ProcedureReference"] = 678,
            ["ProcedureReferenceName"] = 679,
            ["ProcessAffinityRange"] = 680,
            ["ProviderEncryptionSource"] = 681,
            ["ProviderKeyNameKeyOption"] = 682,
            ["QualifiedJoin"] = 683,
            ["QueryDerivedTable"] = 684,
            ["QueryParenthesisExpression"] = 685,
            ["QuerySpecification"] = 686,
            ["QueryStoreCapturePolicyOption"] = 687,
            ["QueryStoreDatabaseOption"] = 688,
            ["QueryStoreDataFlushIntervalOption"] = 689,
            ["QueryStoreDesiredStateOption"] = 690,
            ["QueryStoreIntervalLengthOption"] = 691,
            ["QueryStoreMaxPlansPerQueryOption"] = 692,
            ["QueryStoreMaxStorageSizeOption"] = 693,
            ["QueryStoreSizeCleanupPolicyOption"] = 694,
            ["QueryStoreTimeCleanupPolicyOption"] = 695,
            ["QueryStoreWaitStatsCaptureOption"] = 696,
            ["QueueDelayAuditOption"] = 697,
            ["QueueExecuteAsOption"] = 698,
            ["QueueOption"] = 699,
            ["QueueProcedureOption"] = 700,
            ["QueueStateOption"] = 701,
            ["QueueValueOption"] = 702,
            ["RaiseErrorLegacyStatement"] = 703,
            ["RaiseErrorStatement"] = 704,
            ["ReadOnlyForClause"] = 705,
            ["ReadTextStatement"] = 706,
            ["RealLiteral"] = 707,
            ["ReceiveStatement"] = 708,
            ["ReconfigureStatement"] = 709,
            ["RecoveryDatabaseOption"] = 710,
            ["RemoteDataArchiveAlterTableOption"] = 711,
            ["RemoteDataArchiveDatabaseOption"] = 712,
            ["RemoteDataArchiveDbCredentialSetting"] = 713,
            ["RemoteDataArchiveDbFederatedServiceAccountSetting"] = 714,
            ["RemoteDataArchiveDbServerSetting"] = 715,
            ["RemoteDataArchiveTableOption"] = 716,
            ["RenameAlterRoleAction"] = 717,
            ["RenameEntityStatement"] = 718,
            ["ResampleStatisticsOption"] = 719,
            ["ResourcePoolAffinitySpecification"] = 720,
            ["ResourcePoolParameter"] = 721,
            ["ResourcePoolStatement"] = 722,
            ["RestoreMasterKeyStatement"] = 723,
            ["RestoreOption"] = 724,
            ["RestoreServiceMasterKeyStatement"] = 725,
            ["RestoreStatement"] = 726,
            ["ResultColumnDefinition"] = 727,
            ["ResultSetDefinition"] = 728,
            ["ResultSetsExecuteOption"] = 729,
            ["RetentionDaysAuditTargetOption"] = 730,
            ["RetentionPeriodDefinition"] = 731,
            ["ReturnStatement"] = 732,
            ["RevertStatement"] = 733,
            ["RevokeStatement"] = 734,
            ["RevokeStatement80"] = 735,
            ["RightFunctionCall"] = 736,
            ["RolePayloadOption"] = 737,
            ["RollbackTransactionStatement"] = 738,
            ["RollupGroupingSpecification"] = 739,
            ["RouteOption"] = 740,
            ["RowValue"] = 741,
            ["SaveTransactionStatement"] = 742,
            ["ScalarExpressionDialogOption"] = 743,
            ["ScalarExpressionRestoreOption"] = 744,
            ["ScalarExpressionSequenceOption"] = 745,
            ["ScalarExpressionSnippet"] = 746,
            ["ScalarFunctionReturnType"] = 747,
            ["ScalarSubquery"] = 748,
            ["SchemaDeclarationItem"] = 749,
            ["SchemaDeclarationItemOpenjson"] = 750,
            ["SchemaObjectFunctionTableReference"] = 751,
            ["SchemaObjectName"] = 752,
            ["SchemaObjectNameOrValueExpression"] = 753,
            ["SchemaObjectNameSnippet"] = 754,
            ["SchemaObjectResultSetDefinition"] = 755,
            ["SchemaPayloadOption"] = 756,
            ["SearchedCaseExpression"] = 757,
            ["SearchedWhenClause"] = 758,
            ["SearchPropertyListFullTextIndexOption"] = 759,
            ["SecondaryRoleReplicaOption"] = 760,
            ["SecurityPolicyOption"] = 761,
            ["SecurityPredicateAction"] = 762,
            ["SecurityPrincipal"] = 763,
            ["SecurityTargetObject"] = 764,
            ["SecurityTargetObjectName"] = 765,
            ["SecurityUserClause80"] = 766,
            ["SelectFunctionReturnType"] = 767,
            ["SelectInsertSource"] = 768,
            ["SelectiveXmlIndexPromotedPath"] = 769,
            ["SelectScalarExpression"] = 770,
            ["SelectSetVariable"] = 771,
            ["SelectStarExpression"] = 772,
            ["SelectStatement"] = 773,
            ["SelectStatementSnippet"] = 774,
            ["SemanticTableReference"] = 775,
            ["SendStatement"] = 776,
            ["SensitivityClassificationOption"] = 777,
            ["SequenceOption"] = 778,
            ["ServiceContract"] = 779,
            ["SessionTimeoutPayloadOption"] = 780,
            ["SetCommandStatement"] = 781,
            ["SetErrorLevelStatement"] = 782,
            ["SetFipsFlaggerCommand"] = 783,
            ["SetIdentityInsertStatement"] = 784,
            ["SetOffsetsStatement"] = 785,
            ["SetRowCountStatement"] = 786,
            ["SetSearchPropertyListAlterFullTextIndexAction"] = 787,
            ["SetStatisticsStatement"] = 788,
            ["SetStopListAlterFullTextIndexAction"] = 789,
            ["SetTextSizeStatement"] = 790,
            ["SetTransactionIsolationLevelStatement"] = 791,
            ["SetUserStatement"] = 792,
            ["SetVariableStatement"] = 793,
            ["ShutdownStatement"] = 794,
            ["SimpleAlterFullTextIndexAction"] = 795,
            ["SimpleCaseExpression"] = 796,
            ["SimpleWhenClause"] = 797,
            ["SingleValueTypeCopyOption"] = 798,
            ["SizeFileDeclarationOption"] = 799,
            ["SoapMethod"] = 800,
            ["SourceDeclaration"] = 801,
            ["SpatialIndexRegularOption"] = 802,
            ["SqlCommandIdentifier"] = 803,
            ["SqlDataTypeReference"] = 804,
            ["StateAuditOption"] = 805,
            ["StatementList"] = 806,
            ["StatementListSnippet"] = 807,
            ["StatisticsOption"] = 808,
            ["StatisticsPartitionRange"] = 809,
            ["StopListFullTextIndexOption"] = 810,
            ["StopRestoreOption"] = 811,
            ["StringLiteral"] = 812,
            ["SubqueryComparisonPredicate"] = 813,
            ["SystemTimePeriodDefinition"] = 814,
            ["SystemVersioningTableOption"] = 815,
            ["TableClusteredIndexType"] = 816,
            ["TableDataCompressionOption"] = 817,
            ["TableDefinition"] = 818,
            ["TableDistributionOption"] = 819,
            ["TableHashDistributionPolicy"] = 820,
            ["TableHint"] = 821,
            ["TableHintsOptimizerHint"] = 822,
            ["TableIndexOption"] = 823,
            ["TableNonClusteredIndexType"] = 824,
            ["TablePartitionOption"] = 825,
            ["TablePartitionOptionSpecifications"] = 826,
            ["TableReplicateDistributionPolicy"] = 827,
            ["TableRoundRobinDistributionPolicy"] = 828,
            ["TableSampleClause"] = 829,
            ["TableValuedFunctionReturnType"] = 830,
            ["TableXmlCompressionOption"] = 831,
            ["TargetDeclaration"] = 832,
            ["TargetRecoveryTimeDatabaseOption"] = 833,
            ["TemporalClause"] = 834,
            ["ThrowStatement"] = 835,
            ["TopRowFilter"] = 836,
            ["TriggerAction"] = 837,
            ["TriggerObject"] = 838,
            ["TriggerOption"] = 839,
            ["TruncateTableStatement"] = 840,
            ["TruncateTargetTableSwitchOption"] = 841,
            ["TryCastCall"] = 842,
            ["TryCatchStatement"] = 843,
            ["TryConvertCall"] = 844,
            ["TryParseCall"] = 845,
            ["TSEqualCall"] = 846,
            ["TSqlBatch"] = 847,
            ["TSqlFragmentSnippet"] = 848,
            ["TSqlScript"] = 849,
            ["TSqlStatementSnippet"] = 850,
            ["UnaryExpression"] = 851,
            ["UniqueConstraintDefinition"] = 852,
            ["UnpivotedTableReference"] = 853,
            ["UnqualifiedJoin"] = 854,
            ["UpdateCall"] = 855,
            ["UpdateForClause"] = 856,
            ["UpdateMergeAction"] = 857,
            ["UpdateSpecification"] = 858,
            ["UpdateStatement"] = 859,
            ["UpdateStatisticsStatement"] = 860,
            ["UpdateTextStatement"] = 861,
            ["UseFederationStatement"] = 862,
            ["UseHintList"] = 863,
            ["UserDataTypeReference"] = 864,
            ["UserDefinedTypeCallTarget"] = 865,
            ["UserDefinedTypePropertyAccess"] = 866,
            ["UserLoginOption"] = 867,
            ["UserRemoteServiceBindingOption"] = 868,
            ["UseStatement"] = 869,
            ["ValuesInsertSource"] = 870,
            ["VariableMethodCallTableReference"] = 871,
            ["VariableReference"] = 872,
            ["VariableTableReference"] = 873,
            ["VariableValuePair"] = 874,
            ["ViewDistributionOption"] = 875,
            ["ViewForAppendOption"] = 876,
            ["ViewHashDistributionPolicy"] = 877,
            ["ViewOption"] = 878,
            ["ViewRoundRobinDistributionPolicy"] = 879,
            ["WaitAtLowPriorityOption"] = 880,
            ["WaitForStatement"] = 881,
            ["WhereClause"] = 882,
            ["WhileStatement"] = 883,
            ["WindowClause"] = 884,
            ["WindowDefinition"] = 885,
            ["WindowDelimiter"] = 886,
            ["WindowFrameClause"] = 887,
            ["WindowsCreateLoginSource"] = 888,
            ["WithCtesAndXmlNamespaces"] = 889,
            ["WithinGroupClause"] = 890,
            ["WitnessDatabaseOption"] = 891,
            ["WlmTimeLiteral"] = 892,
            ["WorkloadGroupImportanceParameter"] = 893,
            ["WorkloadGroupResourceParameter"] = 894,
            ["WriteTextStatement"] = 895,
            ["WsdlPayloadOption"] = 896,
            ["XmlCompressionOption"] = 897,
            ["XmlDataTypeReference"] = 898,
            ["XmlForClause"] = 899,
            ["XmlForClauseOption"] = 900,
            ["XmlNamespaces"] = 901,
            ["XmlNamespacesAliasElement"] = 902,
            ["XmlNamespacesDefaultElement"] = 903,
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
                case 10: return AlgorithmKeyOption.FromMutable(fragment as ScriptDom.AlgorithmKeyOption);
                case 11: return AlterApplicationRoleStatement.FromMutable(fragment as ScriptDom.AlterApplicationRoleStatement);
                case 12: return AlterAssemblyStatement.FromMutable(fragment as ScriptDom.AlterAssemblyStatement);
                case 13: return AlterAsymmetricKeyStatement.FromMutable(fragment as ScriptDom.AlterAsymmetricKeyStatement);
                case 14: return AlterAuthorizationStatement.FromMutable(fragment as ScriptDom.AlterAuthorizationStatement);
                case 15: return AlterAvailabilityGroupAction.FromMutable(fragment as ScriptDom.AlterAvailabilityGroupAction);
                case 16: return AlterAvailabilityGroupFailoverAction.FromMutable(fragment as ScriptDom.AlterAvailabilityGroupFailoverAction);
                case 17: return AlterAvailabilityGroupFailoverOption.FromMutable(fragment as ScriptDom.AlterAvailabilityGroupFailoverOption);
                case 18: return AlterAvailabilityGroupStatement.FromMutable(fragment as ScriptDom.AlterAvailabilityGroupStatement);
                case 19: return AlterBrokerPriorityStatement.FromMutable(fragment as ScriptDom.AlterBrokerPriorityStatement);
                case 20: return AlterCertificateStatement.FromMutable(fragment as ScriptDom.AlterCertificateStatement);
                case 21: return AlterColumnAlterFullTextIndexAction.FromMutable(fragment as ScriptDom.AlterColumnAlterFullTextIndexAction);
                case 22: return AlterColumnEncryptionKeyStatement.FromMutable(fragment as ScriptDom.AlterColumnEncryptionKeyStatement);
                case 23: return AlterCredentialStatement.FromMutable(fragment as ScriptDom.AlterCredentialStatement);
                case 24: return AlterCryptographicProviderStatement.FromMutable(fragment as ScriptDom.AlterCryptographicProviderStatement);
                case 25: return AlterDatabaseAddFileGroupStatement.FromMutable(fragment as ScriptDom.AlterDatabaseAddFileGroupStatement);
                case 26: return AlterDatabaseAddFileStatement.FromMutable(fragment as ScriptDom.AlterDatabaseAddFileStatement);
                case 27: return AlterDatabaseAuditSpecificationStatement.FromMutable(fragment as ScriptDom.AlterDatabaseAuditSpecificationStatement);
                case 28: return AlterDatabaseCollateStatement.FromMutable(fragment as ScriptDom.AlterDatabaseCollateStatement);
                case 29: return AlterDatabaseEncryptionKeyStatement.FromMutable(fragment as ScriptDom.AlterDatabaseEncryptionKeyStatement);
                case 30: return AlterDatabaseModifyFileGroupStatement.FromMutable(fragment as ScriptDom.AlterDatabaseModifyFileGroupStatement);
                case 31: return AlterDatabaseModifyFileStatement.FromMutable(fragment as ScriptDom.AlterDatabaseModifyFileStatement);
                case 32: return AlterDatabaseModifyNameStatement.FromMutable(fragment as ScriptDom.AlterDatabaseModifyNameStatement);
                case 33: return AlterDatabaseRebuildLogStatement.FromMutable(fragment as ScriptDom.AlterDatabaseRebuildLogStatement);
                case 34: return AlterDatabaseRemoveFileGroupStatement.FromMutable(fragment as ScriptDom.AlterDatabaseRemoveFileGroupStatement);
                case 35: return AlterDatabaseRemoveFileStatement.FromMutable(fragment as ScriptDom.AlterDatabaseRemoveFileStatement);
                case 36: return AlterDatabaseScopedConfigurationClearStatement.FromMutable(fragment as ScriptDom.AlterDatabaseScopedConfigurationClearStatement);
                case 37: return AlterDatabaseScopedConfigurationSetStatement.FromMutable(fragment as ScriptDom.AlterDatabaseScopedConfigurationSetStatement);
                case 38: return AlterDatabaseSetStatement.FromMutable(fragment as ScriptDom.AlterDatabaseSetStatement);
                case 39: return AlterDatabaseTermination.FromMutable(fragment as ScriptDom.AlterDatabaseTermination);
                case 40: return AlterEndpointStatement.FromMutable(fragment as ScriptDom.AlterEndpointStatement);
                case 41: return AlterEventSessionStatement.FromMutable(fragment as ScriptDom.AlterEventSessionStatement);
                case 42: return AlterExternalDataSourceStatement.FromMutable(fragment as ScriptDom.AlterExternalDataSourceStatement);
                case 43: return AlterExternalLanguageStatement.FromMutable(fragment as ScriptDom.AlterExternalLanguageStatement);
                case 44: return AlterExternalLibraryStatement.FromMutable(fragment as ScriptDom.AlterExternalLibraryStatement);
                case 45: return AlterExternalResourcePoolStatement.FromMutable(fragment as ScriptDom.AlterExternalResourcePoolStatement);
                case 46: return AlterFederationStatement.FromMutable(fragment as ScriptDom.AlterFederationStatement);
                case 47: return AlterFullTextCatalogStatement.FromMutable(fragment as ScriptDom.AlterFullTextCatalogStatement);
                case 48: return AlterFullTextIndexStatement.FromMutable(fragment as ScriptDom.AlterFullTextIndexStatement);
                case 49: return AlterFullTextStopListStatement.FromMutable(fragment as ScriptDom.AlterFullTextStopListStatement);
                case 50: return AlterFunctionStatement.FromMutable(fragment as ScriptDom.AlterFunctionStatement);
                case 51: return AlterIndexStatement.FromMutable(fragment as ScriptDom.AlterIndexStatement);
                case 52: return AlterLoginAddDropCredentialStatement.FromMutable(fragment as ScriptDom.AlterLoginAddDropCredentialStatement);
                case 53: return AlterLoginEnableDisableStatement.FromMutable(fragment as ScriptDom.AlterLoginEnableDisableStatement);
                case 54: return AlterLoginOptionsStatement.FromMutable(fragment as ScriptDom.AlterLoginOptionsStatement);
                case 55: return AlterMasterKeyStatement.FromMutable(fragment as ScriptDom.AlterMasterKeyStatement);
                case 56: return AlterMessageTypeStatement.FromMutable(fragment as ScriptDom.AlterMessageTypeStatement);
                case 57: return AlterPartitionFunctionStatement.FromMutable(fragment as ScriptDom.AlterPartitionFunctionStatement);
                case 58: return AlterPartitionSchemeStatement.FromMutable(fragment as ScriptDom.AlterPartitionSchemeStatement);
                case 59: return AlterProcedureStatement.FromMutable(fragment as ScriptDom.AlterProcedureStatement);
                case 60: return AlterQueueStatement.FromMutable(fragment as ScriptDom.AlterQueueStatement);
                case 61: return AlterRemoteServiceBindingStatement.FromMutable(fragment as ScriptDom.AlterRemoteServiceBindingStatement);
                case 62: return AlterResourceGovernorStatement.FromMutable(fragment as ScriptDom.AlterResourceGovernorStatement);
                case 63: return AlterResourcePoolStatement.FromMutable(fragment as ScriptDom.AlterResourcePoolStatement);
                case 64: return AlterRoleStatement.FromMutable(fragment as ScriptDom.AlterRoleStatement);
                case 65: return AlterRouteStatement.FromMutable(fragment as ScriptDom.AlterRouteStatement);
                case 66: return AlterSchemaStatement.FromMutable(fragment as ScriptDom.AlterSchemaStatement);
                case 67: return AlterSearchPropertyListStatement.FromMutable(fragment as ScriptDom.AlterSearchPropertyListStatement);
                case 68: return AlterSecurityPolicyStatement.FromMutable(fragment as ScriptDom.AlterSecurityPolicyStatement);
                case 69: return AlterSequenceStatement.FromMutable(fragment as ScriptDom.AlterSequenceStatement);
                case 70: return AlterServerAuditSpecificationStatement.FromMutable(fragment as ScriptDom.AlterServerAuditSpecificationStatement);
                case 71: return AlterServerAuditStatement.FromMutable(fragment as ScriptDom.AlterServerAuditStatement);
                case 72: return AlterServerConfigurationBufferPoolExtensionContainerOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption);
                case 73: return AlterServerConfigurationBufferPoolExtensionOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionOption);
                case 74: return AlterServerConfigurationBufferPoolExtensionSizeOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption);
                case 75: return AlterServerConfigurationDiagnosticsLogMaxSizeOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption);
                case 76: return AlterServerConfigurationDiagnosticsLogOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationDiagnosticsLogOption);
                case 77: return AlterServerConfigurationExternalAuthenticationContainerOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationExternalAuthenticationContainerOption);
                case 78: return AlterServerConfigurationExternalAuthenticationOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationExternalAuthenticationOption);
                case 79: return AlterServerConfigurationFailoverClusterPropertyOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption);
                case 80: return AlterServerConfigurationHadrClusterOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationHadrClusterOption);
                case 81: return AlterServerConfigurationSetBufferPoolExtensionStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement);
                case 82: return AlterServerConfigurationSetDiagnosticsLogStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement);
                case 83: return AlterServerConfigurationSetExternalAuthenticationStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationSetExternalAuthenticationStatement);
                case 84: return AlterServerConfigurationSetFailoverClusterPropertyStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationSetFailoverClusterPropertyStatement);
                case 85: return AlterServerConfigurationSetHadrClusterStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationSetHadrClusterStatement);
                case 86: return AlterServerConfigurationSetSoftNumaStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationSetSoftNumaStatement);
                case 87: return AlterServerConfigurationSoftNumaOption.FromMutable(fragment as ScriptDom.AlterServerConfigurationSoftNumaOption);
                case 88: return AlterServerConfigurationStatement.FromMutable(fragment as ScriptDom.AlterServerConfigurationStatement);
                case 89: return AlterServerRoleStatement.FromMutable(fragment as ScriptDom.AlterServerRoleStatement);
                case 90: return AlterServiceMasterKeyStatement.FromMutable(fragment as ScriptDom.AlterServiceMasterKeyStatement);
                case 91: return AlterServiceStatement.FromMutable(fragment as ScriptDom.AlterServiceStatement);
                case 92: return AlterSymmetricKeyStatement.FromMutable(fragment as ScriptDom.AlterSymmetricKeyStatement);
                case 93: return AlterTableAddTableElementStatement.FromMutable(fragment as ScriptDom.AlterTableAddTableElementStatement);
                case 94: return AlterTableAlterColumnStatement.FromMutable(fragment as ScriptDom.AlterTableAlterColumnStatement);
                case 95: return AlterTableAlterIndexStatement.FromMutable(fragment as ScriptDom.AlterTableAlterIndexStatement);
                case 96: return AlterTableAlterPartitionStatement.FromMutable(fragment as ScriptDom.AlterTableAlterPartitionStatement);
                case 97: return AlterTableChangeTrackingModificationStatement.FromMutable(fragment as ScriptDom.AlterTableChangeTrackingModificationStatement);
                case 98: return AlterTableConstraintModificationStatement.FromMutable(fragment as ScriptDom.AlterTableConstraintModificationStatement);
                case 99: return AlterTableDropTableElement.FromMutable(fragment as ScriptDom.AlterTableDropTableElement);
                case 100: return AlterTableDropTableElementStatement.FromMutable(fragment as ScriptDom.AlterTableDropTableElementStatement);
                case 101: return AlterTableFileTableNamespaceStatement.FromMutable(fragment as ScriptDom.AlterTableFileTableNamespaceStatement);
                case 102: return AlterTableRebuildStatement.FromMutable(fragment as ScriptDom.AlterTableRebuildStatement);
                case 103: return AlterTableSetStatement.FromMutable(fragment as ScriptDom.AlterTableSetStatement);
                case 104: return AlterTableSwitchStatement.FromMutable(fragment as ScriptDom.AlterTableSwitchStatement);
                case 105: return AlterTableTriggerModificationStatement.FromMutable(fragment as ScriptDom.AlterTableTriggerModificationStatement);
                case 106: return AlterTriggerStatement.FromMutable(fragment as ScriptDom.AlterTriggerStatement);
                case 107: return AlterUserStatement.FromMutable(fragment as ScriptDom.AlterUserStatement);
                case 108: return AlterViewStatement.FromMutable(fragment as ScriptDom.AlterViewStatement);
                case 109: return AlterWorkloadGroupStatement.FromMutable(fragment as ScriptDom.AlterWorkloadGroupStatement);
                case 110: return AlterXmlSchemaCollectionStatement.FromMutable(fragment as ScriptDom.AlterXmlSchemaCollectionStatement);
                case 111: return ApplicationRoleOption.FromMutable(fragment as ScriptDom.ApplicationRoleOption);
                case 112: return AssemblyEncryptionSource.FromMutable(fragment as ScriptDom.AssemblyEncryptionSource);
                case 113: return AssemblyName.FromMutable(fragment as ScriptDom.AssemblyName);
                case 114: return AssemblyOption.FromMutable(fragment as ScriptDom.AssemblyOption);
                case 115: return AssignmentSetClause.FromMutable(fragment as ScriptDom.AssignmentSetClause);
                case 116: return AsymmetricKeyCreateLoginSource.FromMutable(fragment as ScriptDom.AsymmetricKeyCreateLoginSource);
                case 117: return AtTimeZoneCall.FromMutable(fragment as ScriptDom.AtTimeZoneCall);
                case 118: return AuditActionGroupReference.FromMutable(fragment as ScriptDom.AuditActionGroupReference);
                case 119: return AuditActionSpecification.FromMutable(fragment as ScriptDom.AuditActionSpecification);
                case 120: return AuditGuidAuditOption.FromMutable(fragment as ScriptDom.AuditGuidAuditOption);
                case 121: return AuditSpecificationPart.FromMutable(fragment as ScriptDom.AuditSpecificationPart);
                case 122: return AuditTarget.FromMutable(fragment as ScriptDom.AuditTarget);
                case 123: return AuthenticationEndpointProtocolOption.FromMutable(fragment as ScriptDom.AuthenticationEndpointProtocolOption);
                case 124: return AuthenticationPayloadOption.FromMutable(fragment as ScriptDom.AuthenticationPayloadOption);
                case 125: return AutoCleanupChangeTrackingOptionDetail.FromMutable(fragment as ScriptDom.AutoCleanupChangeTrackingOptionDetail);
                case 126: return AutoCreateStatisticsDatabaseOption.FromMutable(fragment as ScriptDom.AutoCreateStatisticsDatabaseOption);
                case 127: return AutomaticTuningCreateIndexOption.FromMutable(fragment as ScriptDom.AutomaticTuningCreateIndexOption);
                case 128: return AutomaticTuningDatabaseOption.FromMutable(fragment as ScriptDom.AutomaticTuningDatabaseOption);
                case 129: return AutomaticTuningDropIndexOption.FromMutable(fragment as ScriptDom.AutomaticTuningDropIndexOption);
                case 130: return AutomaticTuningForceLastGoodPlanOption.FromMutable(fragment as ScriptDom.AutomaticTuningForceLastGoodPlanOption);
                case 131: return AutomaticTuningMaintainIndexOption.FromMutable(fragment as ScriptDom.AutomaticTuningMaintainIndexOption);
                case 132: return AutomaticTuningOption.FromMutable(fragment as ScriptDom.AutomaticTuningOption);
                case 133: return AvailabilityModeReplicaOption.FromMutable(fragment as ScriptDom.AvailabilityModeReplicaOption);
                case 134: return AvailabilityReplica.FromMutable(fragment as ScriptDom.AvailabilityReplica);
                case 135: return BackupCertificateStatement.FromMutable(fragment as ScriptDom.BackupCertificateStatement);
                case 136: return BackupDatabaseStatement.FromMutable(fragment as ScriptDom.BackupDatabaseStatement);
                case 137: return BackupEncryptionOption.FromMutable(fragment as ScriptDom.BackupEncryptionOption);
                case 138: return BackupMasterKeyStatement.FromMutable(fragment as ScriptDom.BackupMasterKeyStatement);
                case 139: return BackupOption.FromMutable(fragment as ScriptDom.BackupOption);
                case 140: return BackupRestoreFileInfo.FromMutable(fragment as ScriptDom.BackupRestoreFileInfo);
                case 141: return BackupServiceMasterKeyStatement.FromMutable(fragment as ScriptDom.BackupServiceMasterKeyStatement);
                case 142: return BackupTransactionLogStatement.FromMutable(fragment as ScriptDom.BackupTransactionLogStatement);
                case 143: return BackwardsCompatibleDropIndexClause.FromMutable(fragment as ScriptDom.BackwardsCompatibleDropIndexClause);
                case 144: return BeginConversationTimerStatement.FromMutable(fragment as ScriptDom.BeginConversationTimerStatement);
                case 145: return BeginDialogStatement.FromMutable(fragment as ScriptDom.BeginDialogStatement);
                case 146: return BeginEndAtomicBlockStatement.FromMutable(fragment as ScriptDom.BeginEndAtomicBlockStatement);
                case 147: return BeginEndBlockStatement.FromMutable(fragment as ScriptDom.BeginEndBlockStatement);
                case 148: return BeginTransactionStatement.FromMutable(fragment as ScriptDom.BeginTransactionStatement);
                case 149: return BinaryExpression.FromMutable(fragment as ScriptDom.BinaryExpression);
                case 150: return BinaryLiteral.FromMutable(fragment as ScriptDom.BinaryLiteral);
                case 151: return BinaryQueryExpression.FromMutable(fragment as ScriptDom.BinaryQueryExpression);
                case 152: return BooleanBinaryExpression.FromMutable(fragment as ScriptDom.BooleanBinaryExpression);
                case 153: return BooleanComparisonExpression.FromMutable(fragment as ScriptDom.BooleanComparisonExpression);
                case 154: return BooleanExpressionSnippet.FromMutable(fragment as ScriptDom.BooleanExpressionSnippet);
                case 155: return BooleanIsNullExpression.FromMutable(fragment as ScriptDom.BooleanIsNullExpression);
                case 156: return BooleanNotExpression.FromMutable(fragment as ScriptDom.BooleanNotExpression);
                case 157: return BooleanParenthesisExpression.FromMutable(fragment as ScriptDom.BooleanParenthesisExpression);
                case 158: return BooleanTernaryExpression.FromMutable(fragment as ScriptDom.BooleanTernaryExpression);
                case 159: return BoundingBoxParameter.FromMutable(fragment as ScriptDom.BoundingBoxParameter);
                case 160: return BoundingBoxSpatialIndexOption.FromMutable(fragment as ScriptDom.BoundingBoxSpatialIndexOption);
                case 161: return BreakStatement.FromMutable(fragment as ScriptDom.BreakStatement);
                case 162: return BrokerPriorityParameter.FromMutable(fragment as ScriptDom.BrokerPriorityParameter);
                case 163: return BrowseForClause.FromMutable(fragment as ScriptDom.BrowseForClause);
                case 164: return BuiltInFunctionTableReference.FromMutable(fragment as ScriptDom.BuiltInFunctionTableReference);
                case 165: return BulkInsertOption.FromMutable(fragment as ScriptDom.BulkInsertOption);
                case 166: return BulkInsertStatement.FromMutable(fragment as ScriptDom.BulkInsertStatement);
                case 167: return BulkOpenRowset.FromMutable(fragment as ScriptDom.BulkOpenRowset);
                case 168: return CastCall.FromMutable(fragment as ScriptDom.CastCall);
                case 169: return CatalogCollationOption.FromMutable(fragment as ScriptDom.CatalogCollationOption);
                case 170: return CellsPerObjectSpatialIndexOption.FromMutable(fragment as ScriptDom.CellsPerObjectSpatialIndexOption);
                case 171: return CertificateCreateLoginSource.FromMutable(fragment as ScriptDom.CertificateCreateLoginSource);
                case 172: return CertificateOption.FromMutable(fragment as ScriptDom.CertificateOption);
                case 173: return ChangeRetentionChangeTrackingOptionDetail.FromMutable(fragment as ScriptDom.ChangeRetentionChangeTrackingOptionDetail);
                case 174: return ChangeTableChangesTableReference.FromMutable(fragment as ScriptDom.ChangeTableChangesTableReference);
                case 175: return ChangeTableVersionTableReference.FromMutable(fragment as ScriptDom.ChangeTableVersionTableReference);
                case 176: return ChangeTrackingDatabaseOption.FromMutable(fragment as ScriptDom.ChangeTrackingDatabaseOption);
                case 177: return ChangeTrackingFullTextIndexOption.FromMutable(fragment as ScriptDom.ChangeTrackingFullTextIndexOption);
                case 178: return CharacterSetPayloadOption.FromMutable(fragment as ScriptDom.CharacterSetPayloadOption);
                case 179: return CheckConstraintDefinition.FromMutable(fragment as ScriptDom.CheckConstraintDefinition);
                case 180: return CheckpointStatement.FromMutable(fragment as ScriptDom.CheckpointStatement);
                case 181: return ChildObjectName.FromMutable(fragment as ScriptDom.ChildObjectName);
                case 182: return ClassifierEndTimeOption.FromMutable(fragment as ScriptDom.ClassifierEndTimeOption);
                case 183: return ClassifierImportanceOption.FromMutable(fragment as ScriptDom.ClassifierImportanceOption);
                case 184: return ClassifierMemberNameOption.FromMutable(fragment as ScriptDom.ClassifierMemberNameOption);
                case 185: return ClassifierStartTimeOption.FromMutable(fragment as ScriptDom.ClassifierStartTimeOption);
                case 186: return ClassifierWlmContextOption.FromMutable(fragment as ScriptDom.ClassifierWlmContextOption);
                case 187: return ClassifierWlmLabelOption.FromMutable(fragment as ScriptDom.ClassifierWlmLabelOption);
                case 188: return ClassifierWorkloadGroupOption.FromMutable(fragment as ScriptDom.ClassifierWorkloadGroupOption);
                case 189: return CloseCursorStatement.FromMutable(fragment as ScriptDom.CloseCursorStatement);
                case 190: return CloseMasterKeyStatement.FromMutable(fragment as ScriptDom.CloseMasterKeyStatement);
                case 191: return CloseSymmetricKeyStatement.FromMutable(fragment as ScriptDom.CloseSymmetricKeyStatement);
                case 192: return CoalesceExpression.FromMutable(fragment as ScriptDom.CoalesceExpression);
                case 193: return ColumnDefinition.FromMutable(fragment as ScriptDom.ColumnDefinition);
                case 194: return ColumnDefinitionBase.FromMutable(fragment as ScriptDom.ColumnDefinitionBase);
                case 195: return ColumnEncryptionAlgorithmNameParameter.FromMutable(fragment as ScriptDom.ColumnEncryptionAlgorithmNameParameter);
                case 196: return ColumnEncryptionAlgorithmParameter.FromMutable(fragment as ScriptDom.ColumnEncryptionAlgorithmParameter);
                case 197: return ColumnEncryptionDefinition.FromMutable(fragment as ScriptDom.ColumnEncryptionDefinition);
                case 198: return ColumnEncryptionKeyNameParameter.FromMutable(fragment as ScriptDom.ColumnEncryptionKeyNameParameter);
                case 199: return ColumnEncryptionKeyValue.FromMutable(fragment as ScriptDom.ColumnEncryptionKeyValue);
                case 200: return ColumnEncryptionTypeParameter.FromMutable(fragment as ScriptDom.ColumnEncryptionTypeParameter);
                case 201: return ColumnMasterKeyEnclaveComputationsParameter.FromMutable(fragment as ScriptDom.ColumnMasterKeyEnclaveComputationsParameter);
                case 202: return ColumnMasterKeyNameParameter.FromMutable(fragment as ScriptDom.ColumnMasterKeyNameParameter);
                case 203: return ColumnMasterKeyPathParameter.FromMutable(fragment as ScriptDom.ColumnMasterKeyPathParameter);
                case 204: return ColumnMasterKeyStoreProviderNameParameter.FromMutable(fragment as ScriptDom.ColumnMasterKeyStoreProviderNameParameter);
                case 205: return ColumnReferenceExpression.FromMutable(fragment as ScriptDom.ColumnReferenceExpression);
                case 206: return ColumnStorageOptions.FromMutable(fragment as ScriptDom.ColumnStorageOptions);
                case 207: return ColumnWithSortOrder.FromMutable(fragment as ScriptDom.ColumnWithSortOrder);
                case 208: return CommandSecurityElement80.FromMutable(fragment as ScriptDom.CommandSecurityElement80);
                case 209: return CommitTransactionStatement.FromMutable(fragment as ScriptDom.CommitTransactionStatement);
                case 210: return CommonTableExpression.FromMutable(fragment as ScriptDom.CommonTableExpression);
                case 211: return CompositeGroupingSpecification.FromMutable(fragment as ScriptDom.CompositeGroupingSpecification);
                case 212: return CompressionDelayIndexOption.FromMutable(fragment as ScriptDom.CompressionDelayIndexOption);
                case 213: return CompressionEndpointProtocolOption.FromMutable(fragment as ScriptDom.CompressionEndpointProtocolOption);
                case 214: return CompressionPartitionRange.FromMutable(fragment as ScriptDom.CompressionPartitionRange);
                case 215: return ComputeClause.FromMutable(fragment as ScriptDom.ComputeClause);
                case 216: return ComputeFunction.FromMutable(fragment as ScriptDom.ComputeFunction);
                case 217: return ContainmentDatabaseOption.FromMutable(fragment as ScriptDom.ContainmentDatabaseOption);
                case 218: return ContinueStatement.FromMutable(fragment as ScriptDom.ContinueStatement);
                case 219: return ContractMessage.FromMutable(fragment as ScriptDom.ContractMessage);
                case 220: return ConvertCall.FromMutable(fragment as ScriptDom.ConvertCall);
                case 221: return CopyColumnOption.FromMutable(fragment as ScriptDom.CopyColumnOption);
                case 222: return CopyCredentialOption.FromMutable(fragment as ScriptDom.CopyCredentialOption);
                case 223: return CopyOption.FromMutable(fragment as ScriptDom.CopyOption);
                case 224: return CopyStatement.FromMutable(fragment as ScriptDom.CopyStatement);
                case 225: return CreateAggregateStatement.FromMutable(fragment as ScriptDom.CreateAggregateStatement);
                case 226: return CreateApplicationRoleStatement.FromMutable(fragment as ScriptDom.CreateApplicationRoleStatement);
                case 227: return CreateAssemblyStatement.FromMutable(fragment as ScriptDom.CreateAssemblyStatement);
                case 228: return CreateAsymmetricKeyStatement.FromMutable(fragment as ScriptDom.CreateAsymmetricKeyStatement);
                case 229: return CreateAvailabilityGroupStatement.FromMutable(fragment as ScriptDom.CreateAvailabilityGroupStatement);
                case 230: return CreateBrokerPriorityStatement.FromMutable(fragment as ScriptDom.CreateBrokerPriorityStatement);
                case 231: return CreateCertificateStatement.FromMutable(fragment as ScriptDom.CreateCertificateStatement);
                case 232: return CreateColumnEncryptionKeyStatement.FromMutable(fragment as ScriptDom.CreateColumnEncryptionKeyStatement);
                case 233: return CreateColumnMasterKeyStatement.FromMutable(fragment as ScriptDom.CreateColumnMasterKeyStatement);
                case 234: return CreateColumnStoreIndexStatement.FromMutable(fragment as ScriptDom.CreateColumnStoreIndexStatement);
                case 235: return CreateContractStatement.FromMutable(fragment as ScriptDom.CreateContractStatement);
                case 236: return CreateCredentialStatement.FromMutable(fragment as ScriptDom.CreateCredentialStatement);
                case 237: return CreateCryptographicProviderStatement.FromMutable(fragment as ScriptDom.CreateCryptographicProviderStatement);
                case 238: return CreateDatabaseAuditSpecificationStatement.FromMutable(fragment as ScriptDom.CreateDatabaseAuditSpecificationStatement);
                case 239: return CreateDatabaseEncryptionKeyStatement.FromMutable(fragment as ScriptDom.CreateDatabaseEncryptionKeyStatement);
                case 240: return CreateDatabaseStatement.FromMutable(fragment as ScriptDom.CreateDatabaseStatement);
                case 241: return CreateDefaultStatement.FromMutable(fragment as ScriptDom.CreateDefaultStatement);
                case 242: return CreateEndpointStatement.FromMutable(fragment as ScriptDom.CreateEndpointStatement);
                case 243: return CreateEventNotificationStatement.FromMutable(fragment as ScriptDom.CreateEventNotificationStatement);
                case 244: return CreateEventSessionStatement.FromMutable(fragment as ScriptDom.CreateEventSessionStatement);
                case 245: return CreateExternalDataSourceStatement.FromMutable(fragment as ScriptDom.CreateExternalDataSourceStatement);
                case 246: return CreateExternalFileFormatStatement.FromMutable(fragment as ScriptDom.CreateExternalFileFormatStatement);
                case 247: return CreateExternalLanguageStatement.FromMutable(fragment as ScriptDom.CreateExternalLanguageStatement);
                case 248: return CreateExternalLibraryStatement.FromMutable(fragment as ScriptDom.CreateExternalLibraryStatement);
                case 249: return CreateExternalResourcePoolStatement.FromMutable(fragment as ScriptDom.CreateExternalResourcePoolStatement);
                case 250: return CreateExternalStreamingJobStatement.FromMutable(fragment as ScriptDom.CreateExternalStreamingJobStatement);
                case 251: return CreateExternalStreamStatement.FromMutable(fragment as ScriptDom.CreateExternalStreamStatement);
                case 252: return CreateExternalTableStatement.FromMutable(fragment as ScriptDom.CreateExternalTableStatement);
                case 253: return CreateFederationStatement.FromMutable(fragment as ScriptDom.CreateFederationStatement);
                case 254: return CreateFullTextCatalogStatement.FromMutable(fragment as ScriptDom.CreateFullTextCatalogStatement);
                case 255: return CreateFullTextIndexStatement.FromMutable(fragment as ScriptDom.CreateFullTextIndexStatement);
                case 256: return CreateFullTextStopListStatement.FromMutable(fragment as ScriptDom.CreateFullTextStopListStatement);
                case 257: return CreateFunctionStatement.FromMutable(fragment as ScriptDom.CreateFunctionStatement);
                case 258: return CreateIndexStatement.FromMutable(fragment as ScriptDom.CreateIndexStatement);
                case 259: return CreateLoginStatement.FromMutable(fragment as ScriptDom.CreateLoginStatement);
                case 260: return CreateMasterKeyStatement.FromMutable(fragment as ScriptDom.CreateMasterKeyStatement);
                case 261: return CreateMessageTypeStatement.FromMutable(fragment as ScriptDom.CreateMessageTypeStatement);
                case 262: return CreateOrAlterFunctionStatement.FromMutable(fragment as ScriptDom.CreateOrAlterFunctionStatement);
                case 263: return CreateOrAlterProcedureStatement.FromMutable(fragment as ScriptDom.CreateOrAlterProcedureStatement);
                case 264: return CreateOrAlterTriggerStatement.FromMutable(fragment as ScriptDom.CreateOrAlterTriggerStatement);
                case 265: return CreateOrAlterViewStatement.FromMutable(fragment as ScriptDom.CreateOrAlterViewStatement);
                case 266: return CreatePartitionFunctionStatement.FromMutable(fragment as ScriptDom.CreatePartitionFunctionStatement);
                case 267: return CreatePartitionSchemeStatement.FromMutable(fragment as ScriptDom.CreatePartitionSchemeStatement);
                case 268: return CreateProcedureStatement.FromMutable(fragment as ScriptDom.CreateProcedureStatement);
                case 269: return CreateQueueStatement.FromMutable(fragment as ScriptDom.CreateQueueStatement);
                case 270: return CreateRemoteServiceBindingStatement.FromMutable(fragment as ScriptDom.CreateRemoteServiceBindingStatement);
                case 271: return CreateResourcePoolStatement.FromMutable(fragment as ScriptDom.CreateResourcePoolStatement);
                case 272: return CreateRoleStatement.FromMutable(fragment as ScriptDom.CreateRoleStatement);
                case 273: return CreateRouteStatement.FromMutable(fragment as ScriptDom.CreateRouteStatement);
                case 274: return CreateRuleStatement.FromMutable(fragment as ScriptDom.CreateRuleStatement);
                case 275: return CreateSchemaStatement.FromMutable(fragment as ScriptDom.CreateSchemaStatement);
                case 276: return CreateSearchPropertyListStatement.FromMutable(fragment as ScriptDom.CreateSearchPropertyListStatement);
                case 277: return CreateSecurityPolicyStatement.FromMutable(fragment as ScriptDom.CreateSecurityPolicyStatement);
                case 278: return CreateSelectiveXmlIndexStatement.FromMutable(fragment as ScriptDom.CreateSelectiveXmlIndexStatement);
                case 279: return CreateSequenceStatement.FromMutable(fragment as ScriptDom.CreateSequenceStatement);
                case 280: return CreateServerAuditSpecificationStatement.FromMutable(fragment as ScriptDom.CreateServerAuditSpecificationStatement);
                case 281: return CreateServerAuditStatement.FromMutable(fragment as ScriptDom.CreateServerAuditStatement);
                case 282: return CreateServerRoleStatement.FromMutable(fragment as ScriptDom.CreateServerRoleStatement);
                case 283: return CreateServiceStatement.FromMutable(fragment as ScriptDom.CreateServiceStatement);
                case 284: return CreateSpatialIndexStatement.FromMutable(fragment as ScriptDom.CreateSpatialIndexStatement);
                case 285: return CreateStatisticsStatement.FromMutable(fragment as ScriptDom.CreateStatisticsStatement);
                case 286: return CreateSymmetricKeyStatement.FromMutable(fragment as ScriptDom.CreateSymmetricKeyStatement);
                case 287: return CreateSynonymStatement.FromMutable(fragment as ScriptDom.CreateSynonymStatement);
                case 288: return CreateTableStatement.FromMutable(fragment as ScriptDom.CreateTableStatement);
                case 289: return CreateTriggerStatement.FromMutable(fragment as ScriptDom.CreateTriggerStatement);
                case 290: return CreateTypeTableStatement.FromMutable(fragment as ScriptDom.CreateTypeTableStatement);
                case 291: return CreateTypeUddtStatement.FromMutable(fragment as ScriptDom.CreateTypeUddtStatement);
                case 292: return CreateTypeUdtStatement.FromMutable(fragment as ScriptDom.CreateTypeUdtStatement);
                case 293: return CreateUserStatement.FromMutable(fragment as ScriptDom.CreateUserStatement);
                case 294: return CreateViewStatement.FromMutable(fragment as ScriptDom.CreateViewStatement);
                case 295: return CreateWorkloadClassifierStatement.FromMutable(fragment as ScriptDom.CreateWorkloadClassifierStatement);
                case 296: return CreateWorkloadGroupStatement.FromMutable(fragment as ScriptDom.CreateWorkloadGroupStatement);
                case 297: return CreateXmlIndexStatement.FromMutable(fragment as ScriptDom.CreateXmlIndexStatement);
                case 298: return CreateXmlSchemaCollectionStatement.FromMutable(fragment as ScriptDom.CreateXmlSchemaCollectionStatement);
                case 299: return CreationDispositionKeyOption.FromMutable(fragment as ScriptDom.CreationDispositionKeyOption);
                case 300: return CryptoMechanism.FromMutable(fragment as ScriptDom.CryptoMechanism);
                case 301: return CubeGroupingSpecification.FromMutable(fragment as ScriptDom.CubeGroupingSpecification);
                case 302: return CursorDefaultDatabaseOption.FromMutable(fragment as ScriptDom.CursorDefaultDatabaseOption);
                case 303: return CursorDefinition.FromMutable(fragment as ScriptDom.CursorDefinition);
                case 304: return CursorId.FromMutable(fragment as ScriptDom.CursorId);
                case 305: return CursorOption.FromMutable(fragment as ScriptDom.CursorOption);
                case 306: return DatabaseAuditAction.FromMutable(fragment as ScriptDom.DatabaseAuditAction);
                case 307: return DatabaseConfigurationClearOption.FromMutable(fragment as ScriptDom.DatabaseConfigurationClearOption);
                case 308: return DatabaseConfigurationSetOption.FromMutable(fragment as ScriptDom.DatabaseConfigurationSetOption);
                case 309: return DatabaseOption.FromMutable(fragment as ScriptDom.DatabaseOption);
                case 310: return DataCompressionOption.FromMutable(fragment as ScriptDom.DataCompressionOption);
                case 311: return DataModificationTableReference.FromMutable(fragment as ScriptDom.DataModificationTableReference);
                case 312: return DataRetentionTableOption.FromMutable(fragment as ScriptDom.DataRetentionTableOption);
                case 313: return DataTypeSequenceOption.FromMutable(fragment as ScriptDom.DataTypeSequenceOption);
                case 314: return DbccNamedLiteral.FromMutable(fragment as ScriptDom.DbccNamedLiteral);
                case 315: return DbccOption.FromMutable(fragment as ScriptDom.DbccOption);
                case 316: return DbccStatement.FromMutable(fragment as ScriptDom.DbccStatement);
                case 317: return DeallocateCursorStatement.FromMutable(fragment as ScriptDom.DeallocateCursorStatement);
                case 318: return DeclareCursorStatement.FromMutable(fragment as ScriptDom.DeclareCursorStatement);
                case 319: return DeclareTableVariableBody.FromMutable(fragment as ScriptDom.DeclareTableVariableBody);
                case 320: return DeclareTableVariableStatement.FromMutable(fragment as ScriptDom.DeclareTableVariableStatement);
                case 321: return DeclareVariableElement.FromMutable(fragment as ScriptDom.DeclareVariableElement);
                case 322: return DeclareVariableStatement.FromMutable(fragment as ScriptDom.DeclareVariableStatement);
                case 323: return DefaultConstraintDefinition.FromMutable(fragment as ScriptDom.DefaultConstraintDefinition);
                case 324: return DefaultLiteral.FromMutable(fragment as ScriptDom.DefaultLiteral);
                case 325: return DelayedDurabilityDatabaseOption.FromMutable(fragment as ScriptDom.DelayedDurabilityDatabaseOption);
                case 326: return DeleteMergeAction.FromMutable(fragment as ScriptDom.DeleteMergeAction);
                case 327: return DeleteSpecification.FromMutable(fragment as ScriptDom.DeleteSpecification);
                case 328: return DeleteStatement.FromMutable(fragment as ScriptDom.DeleteStatement);
                case 329: return DenyStatement.FromMutable(fragment as ScriptDom.DenyStatement);
                case 330: return DenyStatement80.FromMutable(fragment as ScriptDom.DenyStatement80);
                case 331: return DeviceInfo.FromMutable(fragment as ScriptDom.DeviceInfo);
                case 332: return DiskStatement.FromMutable(fragment as ScriptDom.DiskStatement);
                case 333: return DiskStatementOption.FromMutable(fragment as ScriptDom.DiskStatementOption);
                case 334: return DistinctPredicate.FromMutable(fragment as ScriptDom.DistinctPredicate);
                case 335: return DropAggregateStatement.FromMutable(fragment as ScriptDom.DropAggregateStatement);
                case 336: return DropAlterFullTextIndexAction.FromMutable(fragment as ScriptDom.DropAlterFullTextIndexAction);
                case 337: return DropApplicationRoleStatement.FromMutable(fragment as ScriptDom.DropApplicationRoleStatement);
                case 338: return DropAssemblyStatement.FromMutable(fragment as ScriptDom.DropAssemblyStatement);
                case 339: return DropAsymmetricKeyStatement.FromMutable(fragment as ScriptDom.DropAsymmetricKeyStatement);
                case 340: return DropAvailabilityGroupStatement.FromMutable(fragment as ScriptDom.DropAvailabilityGroupStatement);
                case 341: return DropBrokerPriorityStatement.FromMutable(fragment as ScriptDom.DropBrokerPriorityStatement);
                case 342: return DropCertificateStatement.FromMutable(fragment as ScriptDom.DropCertificateStatement);
                case 343: return DropClusteredConstraintMoveOption.FromMutable(fragment as ScriptDom.DropClusteredConstraintMoveOption);
                case 344: return DropClusteredConstraintStateOption.FromMutable(fragment as ScriptDom.DropClusteredConstraintStateOption);
                case 345: return DropClusteredConstraintValueOption.FromMutable(fragment as ScriptDom.DropClusteredConstraintValueOption);
                case 346: return DropClusteredConstraintWaitAtLowPriorityLockOption.FromMutable(fragment as ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption);
                case 347: return DropColumnEncryptionKeyStatement.FromMutable(fragment as ScriptDom.DropColumnEncryptionKeyStatement);
                case 348: return DropColumnMasterKeyStatement.FromMutable(fragment as ScriptDom.DropColumnMasterKeyStatement);
                case 349: return DropContractStatement.FromMutable(fragment as ScriptDom.DropContractStatement);
                case 350: return DropCredentialStatement.FromMutable(fragment as ScriptDom.DropCredentialStatement);
                case 351: return DropCryptographicProviderStatement.FromMutable(fragment as ScriptDom.DropCryptographicProviderStatement);
                case 352: return DropDatabaseAuditSpecificationStatement.FromMutable(fragment as ScriptDom.DropDatabaseAuditSpecificationStatement);
                case 353: return DropDatabaseEncryptionKeyStatement.FromMutable(fragment as ScriptDom.DropDatabaseEncryptionKeyStatement);
                case 354: return DropDatabaseStatement.FromMutable(fragment as ScriptDom.DropDatabaseStatement);
                case 355: return DropDefaultStatement.FromMutable(fragment as ScriptDom.DropDefaultStatement);
                case 356: return DropEndpointStatement.FromMutable(fragment as ScriptDom.DropEndpointStatement);
                case 357: return DropEventNotificationStatement.FromMutable(fragment as ScriptDom.DropEventNotificationStatement);
                case 358: return DropEventSessionStatement.FromMutable(fragment as ScriptDom.DropEventSessionStatement);
                case 359: return DropExternalDataSourceStatement.FromMutable(fragment as ScriptDom.DropExternalDataSourceStatement);
                case 360: return DropExternalFileFormatStatement.FromMutable(fragment as ScriptDom.DropExternalFileFormatStatement);
                case 361: return DropExternalLanguageStatement.FromMutable(fragment as ScriptDom.DropExternalLanguageStatement);
                case 362: return DropExternalLibraryStatement.FromMutable(fragment as ScriptDom.DropExternalLibraryStatement);
                case 363: return DropExternalResourcePoolStatement.FromMutable(fragment as ScriptDom.DropExternalResourcePoolStatement);
                case 364: return DropExternalStreamingJobStatement.FromMutable(fragment as ScriptDom.DropExternalStreamingJobStatement);
                case 365: return DropExternalStreamStatement.FromMutable(fragment as ScriptDom.DropExternalStreamStatement);
                case 366: return DropExternalTableStatement.FromMutable(fragment as ScriptDom.DropExternalTableStatement);
                case 367: return DropFederationStatement.FromMutable(fragment as ScriptDom.DropFederationStatement);
                case 368: return DropFullTextCatalogStatement.FromMutable(fragment as ScriptDom.DropFullTextCatalogStatement);
                case 369: return DropFullTextIndexStatement.FromMutable(fragment as ScriptDom.DropFullTextIndexStatement);
                case 370: return DropFullTextStopListStatement.FromMutable(fragment as ScriptDom.DropFullTextStopListStatement);
                case 371: return DropFunctionStatement.FromMutable(fragment as ScriptDom.DropFunctionStatement);
                case 372: return DropIndexClause.FromMutable(fragment as ScriptDom.DropIndexClause);
                case 373: return DropIndexStatement.FromMutable(fragment as ScriptDom.DropIndexStatement);
                case 374: return DropLoginStatement.FromMutable(fragment as ScriptDom.DropLoginStatement);
                case 375: return DropMasterKeyStatement.FromMutable(fragment as ScriptDom.DropMasterKeyStatement);
                case 376: return DropMemberAlterRoleAction.FromMutable(fragment as ScriptDom.DropMemberAlterRoleAction);
                case 377: return DropMessageTypeStatement.FromMutable(fragment as ScriptDom.DropMessageTypeStatement);
                case 378: return DropPartitionFunctionStatement.FromMutable(fragment as ScriptDom.DropPartitionFunctionStatement);
                case 379: return DropPartitionSchemeStatement.FromMutable(fragment as ScriptDom.DropPartitionSchemeStatement);
                case 380: return DropProcedureStatement.FromMutable(fragment as ScriptDom.DropProcedureStatement);
                case 381: return DropQueueStatement.FromMutable(fragment as ScriptDom.DropQueueStatement);
                case 382: return DropRemoteServiceBindingStatement.FromMutable(fragment as ScriptDom.DropRemoteServiceBindingStatement);
                case 383: return DropResourcePoolStatement.FromMutable(fragment as ScriptDom.DropResourcePoolStatement);
                case 384: return DropRoleStatement.FromMutable(fragment as ScriptDom.DropRoleStatement);
                case 385: return DropRouteStatement.FromMutable(fragment as ScriptDom.DropRouteStatement);
                case 386: return DropRuleStatement.FromMutable(fragment as ScriptDom.DropRuleStatement);
                case 387: return DropSchemaStatement.FromMutable(fragment as ScriptDom.DropSchemaStatement);
                case 388: return DropSearchPropertyListAction.FromMutable(fragment as ScriptDom.DropSearchPropertyListAction);
                case 389: return DropSearchPropertyListStatement.FromMutable(fragment as ScriptDom.DropSearchPropertyListStatement);
                case 390: return DropSecurityPolicyStatement.FromMutable(fragment as ScriptDom.DropSecurityPolicyStatement);
                case 391: return DropSensitivityClassificationStatement.FromMutable(fragment as ScriptDom.DropSensitivityClassificationStatement);
                case 392: return DropSequenceStatement.FromMutable(fragment as ScriptDom.DropSequenceStatement);
                case 393: return DropServerAuditSpecificationStatement.FromMutable(fragment as ScriptDom.DropServerAuditSpecificationStatement);
                case 394: return DropServerAuditStatement.FromMutable(fragment as ScriptDom.DropServerAuditStatement);
                case 395: return DropServerRoleStatement.FromMutable(fragment as ScriptDom.DropServerRoleStatement);
                case 396: return DropServiceStatement.FromMutable(fragment as ScriptDom.DropServiceStatement);
                case 397: return DropSignatureStatement.FromMutable(fragment as ScriptDom.DropSignatureStatement);
                case 398: return DropStatisticsStatement.FromMutable(fragment as ScriptDom.DropStatisticsStatement);
                case 399: return DropSymmetricKeyStatement.FromMutable(fragment as ScriptDom.DropSymmetricKeyStatement);
                case 400: return DropSynonymStatement.FromMutable(fragment as ScriptDom.DropSynonymStatement);
                case 401: return DropTableStatement.FromMutable(fragment as ScriptDom.DropTableStatement);
                case 402: return DropTriggerStatement.FromMutable(fragment as ScriptDom.DropTriggerStatement);
                case 403: return DropTypeStatement.FromMutable(fragment as ScriptDom.DropTypeStatement);
                case 404: return DropUserStatement.FromMutable(fragment as ScriptDom.DropUserStatement);
                case 405: return DropViewStatement.FromMutable(fragment as ScriptDom.DropViewStatement);
                case 406: return DropWorkloadClassifierStatement.FromMutable(fragment as ScriptDom.DropWorkloadClassifierStatement);
                case 407: return DropWorkloadGroupStatement.FromMutable(fragment as ScriptDom.DropWorkloadGroupStatement);
                case 408: return DropXmlSchemaCollectionStatement.FromMutable(fragment as ScriptDom.DropXmlSchemaCollectionStatement);
                case 409: return DurabilityTableOption.FromMutable(fragment as ScriptDom.DurabilityTableOption);
                case 410: return DWCompatibilityLevelConfigurationOption.FromMutable(fragment as ScriptDom.DWCompatibilityLevelConfigurationOption);
                case 411: return ElasticPoolSpecification.FromMutable(fragment as ScriptDom.ElasticPoolSpecification);
                case 412: return EnabledDisabledPayloadOption.FromMutable(fragment as ScriptDom.EnabledDisabledPayloadOption);
                case 413: return EnableDisableTriggerStatement.FromMutable(fragment as ScriptDom.EnableDisableTriggerStatement);
                case 414: return EncryptedValueParameter.FromMutable(fragment as ScriptDom.EncryptedValueParameter);
                case 415: return EncryptionPayloadOption.FromMutable(fragment as ScriptDom.EncryptionPayloadOption);
                case 416: return EndConversationStatement.FromMutable(fragment as ScriptDom.EndConversationStatement);
                case 417: return EndpointAffinity.FromMutable(fragment as ScriptDom.EndpointAffinity);
                case 418: return EventDeclaration.FromMutable(fragment as ScriptDom.EventDeclaration);
                case 419: return EventDeclarationCompareFunctionParameter.FromMutable(fragment as ScriptDom.EventDeclarationCompareFunctionParameter);
                case 420: return EventDeclarationSetParameter.FromMutable(fragment as ScriptDom.EventDeclarationSetParameter);
                case 421: return EventGroupContainer.FromMutable(fragment as ScriptDom.EventGroupContainer);
                case 422: return EventNotificationObjectScope.FromMutable(fragment as ScriptDom.EventNotificationObjectScope);
                case 423: return EventRetentionSessionOption.FromMutable(fragment as ScriptDom.EventRetentionSessionOption);
                case 424: return EventSessionObjectName.FromMutable(fragment as ScriptDom.EventSessionObjectName);
                case 425: return EventSessionStatement.FromMutable(fragment as ScriptDom.EventSessionStatement);
                case 426: return EventTypeContainer.FromMutable(fragment as ScriptDom.EventTypeContainer);
                case 427: return ExecutableProcedureReference.FromMutable(fragment as ScriptDom.ExecutableProcedureReference);
                case 428: return ExecutableStringList.FromMutable(fragment as ScriptDom.ExecutableStringList);
                case 429: return ExecuteAsClause.FromMutable(fragment as ScriptDom.ExecuteAsClause);
                case 430: return ExecuteAsFunctionOption.FromMutable(fragment as ScriptDom.ExecuteAsFunctionOption);
                case 431: return ExecuteAsProcedureOption.FromMutable(fragment as ScriptDom.ExecuteAsProcedureOption);
                case 432: return ExecuteAsStatement.FromMutable(fragment as ScriptDom.ExecuteAsStatement);
                case 433: return ExecuteAsTriggerOption.FromMutable(fragment as ScriptDom.ExecuteAsTriggerOption);
                case 434: return ExecuteContext.FromMutable(fragment as ScriptDom.ExecuteContext);
                case 435: return ExecuteInsertSource.FromMutable(fragment as ScriptDom.ExecuteInsertSource);
                case 436: return ExecuteOption.FromMutable(fragment as ScriptDom.ExecuteOption);
                case 437: return ExecuteParameter.FromMutable(fragment as ScriptDom.ExecuteParameter);
                case 438: return ExecuteSpecification.FromMutable(fragment as ScriptDom.ExecuteSpecification);
                case 439: return ExecuteStatement.FromMutable(fragment as ScriptDom.ExecuteStatement);
                case 440: return ExistsPredicate.FromMutable(fragment as ScriptDom.ExistsPredicate);
                case 441: return ExpressionCallTarget.FromMutable(fragment as ScriptDom.ExpressionCallTarget);
                case 442: return ExpressionGroupingSpecification.FromMutable(fragment as ScriptDom.ExpressionGroupingSpecification);
                case 443: return ExpressionWithSortOrder.FromMutable(fragment as ScriptDom.ExpressionWithSortOrder);
                case 444: return ExternalCreateLoginSource.FromMutable(fragment as ScriptDom.ExternalCreateLoginSource);
                case 445: return ExternalDataSourceLiteralOrIdentifierOption.FromMutable(fragment as ScriptDom.ExternalDataSourceLiteralOrIdentifierOption);
                case 446: return ExternalFileFormatContainerOption.FromMutable(fragment as ScriptDom.ExternalFileFormatContainerOption);
                case 447: return ExternalFileFormatLiteralOption.FromMutable(fragment as ScriptDom.ExternalFileFormatLiteralOption);
                case 448: return ExternalFileFormatUseDefaultTypeOption.FromMutable(fragment as ScriptDom.ExternalFileFormatUseDefaultTypeOption);
                case 449: return ExternalLanguageFileOption.FromMutable(fragment as ScriptDom.ExternalLanguageFileOption);
                case 450: return ExternalLibraryFileOption.FromMutable(fragment as ScriptDom.ExternalLibraryFileOption);
                case 451: return ExternalResourcePoolAffinitySpecification.FromMutable(fragment as ScriptDom.ExternalResourcePoolAffinitySpecification);
                case 452: return ExternalResourcePoolParameter.FromMutable(fragment as ScriptDom.ExternalResourcePoolParameter);
                case 453: return ExternalResourcePoolStatement.FromMutable(fragment as ScriptDom.ExternalResourcePoolStatement);
                case 454: return ExternalStreamLiteralOrIdentifierOption.FromMutable(fragment as ScriptDom.ExternalStreamLiteralOrIdentifierOption);
                case 455: return ExternalTableColumnDefinition.FromMutable(fragment as ScriptDom.ExternalTableColumnDefinition);
                case 456: return ExternalTableDistributionOption.FromMutable(fragment as ScriptDom.ExternalTableDistributionOption);
                case 457: return ExternalTableLiteralOrIdentifierOption.FromMutable(fragment as ScriptDom.ExternalTableLiteralOrIdentifierOption);
                case 458: return ExternalTableRejectTypeOption.FromMutable(fragment as ScriptDom.ExternalTableRejectTypeOption);
                case 459: return ExternalTableReplicatedDistributionPolicy.FromMutable(fragment as ScriptDom.ExternalTableReplicatedDistributionPolicy);
                case 460: return ExternalTableRoundRobinDistributionPolicy.FromMutable(fragment as ScriptDom.ExternalTableRoundRobinDistributionPolicy);
                case 461: return ExternalTableShardedDistributionPolicy.FromMutable(fragment as ScriptDom.ExternalTableShardedDistributionPolicy);
                case 462: return ExtractFromExpression.FromMutable(fragment as ScriptDom.ExtractFromExpression);
                case 463: return FailoverModeReplicaOption.FromMutable(fragment as ScriptDom.FailoverModeReplicaOption);
                case 464: return FederationScheme.FromMutable(fragment as ScriptDom.FederationScheme);
                case 465: return FetchCursorStatement.FromMutable(fragment as ScriptDom.FetchCursorStatement);
                case 466: return FetchType.FromMutable(fragment as ScriptDom.FetchType);
                case 467: return FileDeclaration.FromMutable(fragment as ScriptDom.FileDeclaration);
                case 468: return FileDeclarationOption.FromMutable(fragment as ScriptDom.FileDeclarationOption);
                case 469: return FileEncryptionSource.FromMutable(fragment as ScriptDom.FileEncryptionSource);
                case 470: return FileGroupDefinition.FromMutable(fragment as ScriptDom.FileGroupDefinition);
                case 471: return FileGroupOrPartitionScheme.FromMutable(fragment as ScriptDom.FileGroupOrPartitionScheme);
                case 472: return FileGrowthFileDeclarationOption.FromMutable(fragment as ScriptDom.FileGrowthFileDeclarationOption);
                case 473: return FileNameFileDeclarationOption.FromMutable(fragment as ScriptDom.FileNameFileDeclarationOption);
                case 474: return FileStreamDatabaseOption.FromMutable(fragment as ScriptDom.FileStreamDatabaseOption);
                case 475: return FileStreamOnDropIndexOption.FromMutable(fragment as ScriptDom.FileStreamOnDropIndexOption);
                case 476: return FileStreamOnTableOption.FromMutable(fragment as ScriptDom.FileStreamOnTableOption);
                case 477: return FileStreamRestoreOption.FromMutable(fragment as ScriptDom.FileStreamRestoreOption);
                case 478: return FileTableCollateFileNameTableOption.FromMutable(fragment as ScriptDom.FileTableCollateFileNameTableOption);
                case 479: return FileTableConstraintNameTableOption.FromMutable(fragment as ScriptDom.FileTableConstraintNameTableOption);
                case 480: return FileTableDirectoryTableOption.FromMutable(fragment as ScriptDom.FileTableDirectoryTableOption);
                case 481: return ForceSeekTableHint.FromMutable(fragment as ScriptDom.ForceSeekTableHint);
                case 482: return ForeignKeyConstraintDefinition.FromMutable(fragment as ScriptDom.ForeignKeyConstraintDefinition);
                case 483: return FromClause.FromMutable(fragment as ScriptDom.FromClause);
                case 484: return FullTextCatalogAndFileGroup.FromMutable(fragment as ScriptDom.FullTextCatalogAndFileGroup);
                case 485: return FullTextIndexColumn.FromMutable(fragment as ScriptDom.FullTextIndexColumn);
                case 486: return FullTextPredicate.FromMutable(fragment as ScriptDom.FullTextPredicate);
                case 487: return FullTextStopListAction.FromMutable(fragment as ScriptDom.FullTextStopListAction);
                case 488: return FullTextTableReference.FromMutable(fragment as ScriptDom.FullTextTableReference);
                case 489: return FunctionCall.FromMutable(fragment as ScriptDom.FunctionCall);
                case 490: return FunctionCallSetClause.FromMutable(fragment as ScriptDom.FunctionCallSetClause);
                case 491: return FunctionOption.FromMutable(fragment as ScriptDom.FunctionOption);
                case 492: return GeneralSetCommand.FromMutable(fragment as ScriptDom.GeneralSetCommand);
                case 493: return GenericConfigurationOption.FromMutable(fragment as ScriptDom.GenericConfigurationOption);
                case 494: return GetConversationGroupStatement.FromMutable(fragment as ScriptDom.GetConversationGroupStatement);
                case 495: return GlobalFunctionTableReference.FromMutable(fragment as ScriptDom.GlobalFunctionTableReference);
                case 496: return GlobalVariableExpression.FromMutable(fragment as ScriptDom.GlobalVariableExpression);
                case 497: return GoToStatement.FromMutable(fragment as ScriptDom.GoToStatement);
                case 498: return GrandTotalGroupingSpecification.FromMutable(fragment as ScriptDom.GrandTotalGroupingSpecification);
                case 499: return GrantStatement.FromMutable(fragment as ScriptDom.GrantStatement);
                case 500: return GrantStatement80.FromMutable(fragment as ScriptDom.GrantStatement80);
                case 501: return GraphConnectionBetweenNodes.FromMutable(fragment as ScriptDom.GraphConnectionBetweenNodes);
                case 502: return GraphConnectionConstraintDefinition.FromMutable(fragment as ScriptDom.GraphConnectionConstraintDefinition);
                case 503: return GraphMatchCompositeExpression.FromMutable(fragment as ScriptDom.GraphMatchCompositeExpression);
                case 504: return GraphMatchExpression.FromMutable(fragment as ScriptDom.GraphMatchExpression);
                case 505: return GraphMatchLastNodePredicate.FromMutable(fragment as ScriptDom.GraphMatchLastNodePredicate);
                case 506: return GraphMatchNodeExpression.FromMutable(fragment as ScriptDom.GraphMatchNodeExpression);
                case 507: return GraphMatchPredicate.FromMutable(fragment as ScriptDom.GraphMatchPredicate);
                case 508: return GraphMatchRecursivePredicate.FromMutable(fragment as ScriptDom.GraphMatchRecursivePredicate);
                case 509: return GraphRecursiveMatchQuantifier.FromMutable(fragment as ScriptDom.GraphRecursiveMatchQuantifier);
                case 510: return GridParameter.FromMutable(fragment as ScriptDom.GridParameter);
                case 511: return GridsSpatialIndexOption.FromMutable(fragment as ScriptDom.GridsSpatialIndexOption);
                case 512: return GroupByClause.FromMutable(fragment as ScriptDom.GroupByClause);
                case 513: return GroupingSetsGroupingSpecification.FromMutable(fragment as ScriptDom.GroupingSetsGroupingSpecification);
                case 514: return HadrAvailabilityGroupDatabaseOption.FromMutable(fragment as ScriptDom.HadrAvailabilityGroupDatabaseOption);
                case 515: return HadrDatabaseOption.FromMutable(fragment as ScriptDom.HadrDatabaseOption);
                case 516: return HavingClause.FromMutable(fragment as ScriptDom.HavingClause);
                case 517: return Identifier.FromMutable(fragment as ScriptDom.Identifier);
                case 518: return IdentifierAtomicBlockOption.FromMutable(fragment as ScriptDom.IdentifierAtomicBlockOption);
                case 519: return IdentifierDatabaseOption.FromMutable(fragment as ScriptDom.IdentifierDatabaseOption);
                case 520: return IdentifierLiteral.FromMutable(fragment as ScriptDom.IdentifierLiteral);
                case 521: return IdentifierOrScalarExpression.FromMutable(fragment as ScriptDom.IdentifierOrScalarExpression);
                case 522: return IdentifierOrValueExpression.FromMutable(fragment as ScriptDom.IdentifierOrValueExpression);
                case 523: return IdentifierPrincipalOption.FromMutable(fragment as ScriptDom.IdentifierPrincipalOption);
                case 524: return IdentifierSnippet.FromMutable(fragment as ScriptDom.IdentifierSnippet);
                case 525: return IdentityFunctionCall.FromMutable(fragment as ScriptDom.IdentityFunctionCall);
                case 526: return IdentityOptions.FromMutable(fragment as ScriptDom.IdentityOptions);
                case 527: return IdentityValueKeyOption.FromMutable(fragment as ScriptDom.IdentityValueKeyOption);
                case 528: return IfStatement.FromMutable(fragment as ScriptDom.IfStatement);
                case 529: return IgnoreDupKeyIndexOption.FromMutable(fragment as ScriptDom.IgnoreDupKeyIndexOption);
                case 530: return IIfCall.FromMutable(fragment as ScriptDom.IIfCall);
                case 531: return IndexDefinition.FromMutable(fragment as ScriptDom.IndexDefinition);
                case 532: return IndexExpressionOption.FromMutable(fragment as ScriptDom.IndexExpressionOption);
                case 533: return IndexStateOption.FromMutable(fragment as ScriptDom.IndexStateOption);
                case 534: return IndexTableHint.FromMutable(fragment as ScriptDom.IndexTableHint);
                case 535: return IndexType.FromMutable(fragment as ScriptDom.IndexType);
                case 536: return InlineDerivedTable.FromMutable(fragment as ScriptDom.InlineDerivedTable);
                case 537: return InlineFunctionOption.FromMutable(fragment as ScriptDom.InlineFunctionOption);
                case 538: return InlineResultSetDefinition.FromMutable(fragment as ScriptDom.InlineResultSetDefinition);
                case 539: return InPredicate.FromMutable(fragment as ScriptDom.InPredicate);
                case 540: return InsertBulkColumnDefinition.FromMutable(fragment as ScriptDom.InsertBulkColumnDefinition);
                case 541: return InsertBulkStatement.FromMutable(fragment as ScriptDom.InsertBulkStatement);
                case 542: return InsertMergeAction.FromMutable(fragment as ScriptDom.InsertMergeAction);
                case 543: return InsertSpecification.FromMutable(fragment as ScriptDom.InsertSpecification);
                case 544: return InsertStatement.FromMutable(fragment as ScriptDom.InsertStatement);
                case 545: return IntegerLiteral.FromMutable(fragment as ScriptDom.IntegerLiteral);
                case 546: return InternalOpenRowset.FromMutable(fragment as ScriptDom.InternalOpenRowset);
                case 547: return IPv4.FromMutable(fragment as ScriptDom.IPv4);
                case 548: return JoinParenthesisTableReference.FromMutable(fragment as ScriptDom.JoinParenthesisTableReference);
                case 549: return JsonForClause.FromMutable(fragment as ScriptDom.JsonForClause);
                case 550: return JsonForClauseOption.FromMutable(fragment as ScriptDom.JsonForClauseOption);
                case 551: return JsonKeyValue.FromMutable(fragment as ScriptDom.JsonKeyValue);
                case 552: return KeySourceKeyOption.FromMutable(fragment as ScriptDom.KeySourceKeyOption);
                case 553: return KillQueryNotificationSubscriptionStatement.FromMutable(fragment as ScriptDom.KillQueryNotificationSubscriptionStatement);
                case 554: return KillStatement.FromMutable(fragment as ScriptDom.KillStatement);
                case 555: return KillStatsJobStatement.FromMutable(fragment as ScriptDom.KillStatsJobStatement);
                case 556: return LabelStatement.FromMutable(fragment as ScriptDom.LabelStatement);
                case 557: return LedgerOption.FromMutable(fragment as ScriptDom.LedgerOption);
                case 558: return LedgerTableOption.FromMutable(fragment as ScriptDom.LedgerTableOption);
                case 559: return LedgerViewOption.FromMutable(fragment as ScriptDom.LedgerViewOption);
                case 560: return LeftFunctionCall.FromMutable(fragment as ScriptDom.LeftFunctionCall);
                case 561: return LikePredicate.FromMutable(fragment as ScriptDom.LikePredicate);
                case 562: return LineNoStatement.FromMutable(fragment as ScriptDom.LineNoStatement);
                case 563: return ListenerIPEndpointProtocolOption.FromMutable(fragment as ScriptDom.ListenerIPEndpointProtocolOption);
                case 564: return ListTypeCopyOption.FromMutable(fragment as ScriptDom.ListTypeCopyOption);
                case 565: return LiteralAtomicBlockOption.FromMutable(fragment as ScriptDom.LiteralAtomicBlockOption);
                case 566: return LiteralAuditTargetOption.FromMutable(fragment as ScriptDom.LiteralAuditTargetOption);
                case 567: return LiteralAvailabilityGroupOption.FromMutable(fragment as ScriptDom.LiteralAvailabilityGroupOption);
                case 568: return LiteralBulkInsertOption.FromMutable(fragment as ScriptDom.LiteralBulkInsertOption);
                case 569: return LiteralDatabaseOption.FromMutable(fragment as ScriptDom.LiteralDatabaseOption);
                case 570: return LiteralEndpointProtocolOption.FromMutable(fragment as ScriptDom.LiteralEndpointProtocolOption);
                case 571: return LiteralOpenRowsetCosmosOption.FromMutable(fragment as ScriptDom.LiteralOpenRowsetCosmosOption);
                case 572: return LiteralOptimizerHint.FromMutable(fragment as ScriptDom.LiteralOptimizerHint);
                case 573: return LiteralOptionValue.FromMutable(fragment as ScriptDom.LiteralOptionValue);
                case 574: return LiteralPayloadOption.FromMutable(fragment as ScriptDom.LiteralPayloadOption);
                case 575: return LiteralPrincipalOption.FromMutable(fragment as ScriptDom.LiteralPrincipalOption);
                case 576: return LiteralRange.FromMutable(fragment as ScriptDom.LiteralRange);
                case 577: return LiteralReplicaOption.FromMutable(fragment as ScriptDom.LiteralReplicaOption);
                case 578: return LiteralSessionOption.FromMutable(fragment as ScriptDom.LiteralSessionOption);
                case 579: return LiteralStatisticsOption.FromMutable(fragment as ScriptDom.LiteralStatisticsOption);
                case 580: return LiteralTableHint.FromMutable(fragment as ScriptDom.LiteralTableHint);
                case 581: return LocationOption.FromMutable(fragment as ScriptDom.LocationOption);
                case 582: return LockEscalationTableOption.FromMutable(fragment as ScriptDom.LockEscalationTableOption);
                case 583: return LoginTypePayloadOption.FromMutable(fragment as ScriptDom.LoginTypePayloadOption);
                case 584: return LowPriorityLockWaitAbortAfterWaitOption.FromMutable(fragment as ScriptDom.LowPriorityLockWaitAbortAfterWaitOption);
                case 585: return LowPriorityLockWaitMaxDurationOption.FromMutable(fragment as ScriptDom.LowPriorityLockWaitMaxDurationOption);
                case 586: return LowPriorityLockWaitTableSwitchOption.FromMutable(fragment as ScriptDom.LowPriorityLockWaitTableSwitchOption);
                case 587: return MaxDispatchLatencySessionOption.FromMutable(fragment as ScriptDom.MaxDispatchLatencySessionOption);
                case 588: return MaxDopConfigurationOption.FromMutable(fragment as ScriptDom.MaxDopConfigurationOption);
                case 589: return MaxDurationOption.FromMutable(fragment as ScriptDom.MaxDurationOption);
                case 590: return MaxLiteral.FromMutable(fragment as ScriptDom.MaxLiteral);
                case 591: return MaxRolloverFilesAuditTargetOption.FromMutable(fragment as ScriptDom.MaxRolloverFilesAuditTargetOption);
                case 592: return MaxSizeAuditTargetOption.FromMutable(fragment as ScriptDom.MaxSizeAuditTargetOption);
                case 593: return MaxSizeDatabaseOption.FromMutable(fragment as ScriptDom.MaxSizeDatabaseOption);
                case 594: return MaxSizeFileDeclarationOption.FromMutable(fragment as ScriptDom.MaxSizeFileDeclarationOption);
                case 595: return MemoryOptimizedTableOption.FromMutable(fragment as ScriptDom.MemoryOptimizedTableOption);
                case 596: return MemoryPartitionSessionOption.FromMutable(fragment as ScriptDom.MemoryPartitionSessionOption);
                case 597: return MergeActionClause.FromMutable(fragment as ScriptDom.MergeActionClause);
                case 598: return MergeSpecification.FromMutable(fragment as ScriptDom.MergeSpecification);
                case 599: return MergeStatement.FromMutable(fragment as ScriptDom.MergeStatement);
                case 600: return MethodSpecifier.FromMutable(fragment as ScriptDom.MethodSpecifier);
                case 601: return MirrorToClause.FromMutable(fragment as ScriptDom.MirrorToClause);
                case 602: return MoneyLiteral.FromMutable(fragment as ScriptDom.MoneyLiteral);
                case 603: return MoveConversationStatement.FromMutable(fragment as ScriptDom.MoveConversationStatement);
                case 604: return MoveRestoreOption.FromMutable(fragment as ScriptDom.MoveRestoreOption);
                case 605: return MoveToDropIndexOption.FromMutable(fragment as ScriptDom.MoveToDropIndexOption);
                case 606: return MultiPartIdentifier.FromMutable(fragment as ScriptDom.MultiPartIdentifier);
                case 607: return MultiPartIdentifierCallTarget.FromMutable(fragment as ScriptDom.MultiPartIdentifierCallTarget);
                case 608: return NamedTableReference.FromMutable(fragment as ScriptDom.NamedTableReference);
                case 609: return NameFileDeclarationOption.FromMutable(fragment as ScriptDom.NameFileDeclarationOption);
                case 610: return NextValueForExpression.FromMutable(fragment as ScriptDom.NextValueForExpression);
                case 611: return NullableConstraintDefinition.FromMutable(fragment as ScriptDom.NullableConstraintDefinition);
                case 612: return NullIfExpression.FromMutable(fragment as ScriptDom.NullIfExpression);
                case 613: return NullLiteral.FromMutable(fragment as ScriptDom.NullLiteral);
                case 614: return NumericLiteral.FromMutable(fragment as ScriptDom.NumericLiteral);
                case 615: return OdbcConvertSpecification.FromMutable(fragment as ScriptDom.OdbcConvertSpecification);
                case 616: return OdbcFunctionCall.FromMutable(fragment as ScriptDom.OdbcFunctionCall);
                case 617: return OdbcLiteral.FromMutable(fragment as ScriptDom.OdbcLiteral);
                case 618: return OdbcQualifiedJoinTableReference.FromMutable(fragment as ScriptDom.OdbcQualifiedJoinTableReference);
                case 619: return OffsetClause.FromMutable(fragment as ScriptDom.OffsetClause);
                case 620: return OnFailureAuditOption.FromMutable(fragment as ScriptDom.OnFailureAuditOption);
                case 621: return OnlineIndexLowPriorityLockWaitOption.FromMutable(fragment as ScriptDom.OnlineIndexLowPriorityLockWaitOption);
                case 622: return OnlineIndexOption.FromMutable(fragment as ScriptDom.OnlineIndexOption);
                case 623: return OnOffAssemblyOption.FromMutable(fragment as ScriptDom.OnOffAssemblyOption);
                case 624: return OnOffAtomicBlockOption.FromMutable(fragment as ScriptDom.OnOffAtomicBlockOption);
                case 625: return OnOffAuditTargetOption.FromMutable(fragment as ScriptDom.OnOffAuditTargetOption);
                case 626: return OnOffDatabaseOption.FromMutable(fragment as ScriptDom.OnOffDatabaseOption);
                case 627: return OnOffDialogOption.FromMutable(fragment as ScriptDom.OnOffDialogOption);
                case 628: return OnOffFullTextCatalogOption.FromMutable(fragment as ScriptDom.OnOffFullTextCatalogOption);
                case 629: return OnOffOptionValue.FromMutable(fragment as ScriptDom.OnOffOptionValue);
                case 630: return OnOffPrimaryConfigurationOption.FromMutable(fragment as ScriptDom.OnOffPrimaryConfigurationOption);
                case 631: return OnOffPrincipalOption.FromMutable(fragment as ScriptDom.OnOffPrincipalOption);
                case 632: return OnOffRemoteServiceBindingOption.FromMutable(fragment as ScriptDom.OnOffRemoteServiceBindingOption);
                case 633: return OnOffSessionOption.FromMutable(fragment as ScriptDom.OnOffSessionOption);
                case 634: return OnOffStatisticsOption.FromMutable(fragment as ScriptDom.OnOffStatisticsOption);
                case 635: return OpenCursorStatement.FromMutable(fragment as ScriptDom.OpenCursorStatement);
                case 636: return OpenJsonTableReference.FromMutable(fragment as ScriptDom.OpenJsonTableReference);
                case 637: return OpenMasterKeyStatement.FromMutable(fragment as ScriptDom.OpenMasterKeyStatement);
                case 638: return OpenQueryTableReference.FromMutable(fragment as ScriptDom.OpenQueryTableReference);
                case 639: return OpenRowsetColumnDefinition.FromMutable(fragment as ScriptDom.OpenRowsetColumnDefinition);
                case 640: return OpenRowsetCosmos.FromMutable(fragment as ScriptDom.OpenRowsetCosmos);
                case 641: return OpenRowsetCosmosOption.FromMutable(fragment as ScriptDom.OpenRowsetCosmosOption);
                case 642: return OpenRowsetTableReference.FromMutable(fragment as ScriptDom.OpenRowsetTableReference);
                case 643: return OpenSymmetricKeyStatement.FromMutable(fragment as ScriptDom.OpenSymmetricKeyStatement);
                case 644: return OpenXmlTableReference.FromMutable(fragment as ScriptDom.OpenXmlTableReference);
                case 645: return OperatorAuditOption.FromMutable(fragment as ScriptDom.OperatorAuditOption);
                case 646: return OptimizeForOptimizerHint.FromMutable(fragment as ScriptDom.OptimizeForOptimizerHint);
                case 647: return OptimizerHint.FromMutable(fragment as ScriptDom.OptimizerHint);
                case 648: return OrderBulkInsertOption.FromMutable(fragment as ScriptDom.OrderBulkInsertOption);
                case 649: return OrderByClause.FromMutable(fragment as ScriptDom.OrderByClause);
                case 650: return OrderIndexOption.FromMutable(fragment as ScriptDom.OrderIndexOption);
                case 651: return OutputClause.FromMutable(fragment as ScriptDom.OutputClause);
                case 652: return OutputIntoClause.FromMutable(fragment as ScriptDom.OutputIntoClause);
                case 653: return OverClause.FromMutable(fragment as ScriptDom.OverClause);
                case 654: return PageVerifyDatabaseOption.FromMutable(fragment as ScriptDom.PageVerifyDatabaseOption);
                case 655: return ParameterizationDatabaseOption.FromMutable(fragment as ScriptDom.ParameterizationDatabaseOption);
                case 656: return ParameterlessCall.FromMutable(fragment as ScriptDom.ParameterlessCall);
                case 657: return ParenthesisExpression.FromMutable(fragment as ScriptDom.ParenthesisExpression);
                case 658: return ParseCall.FromMutable(fragment as ScriptDom.ParseCall);
                case 659: return PartitionFunctionCall.FromMutable(fragment as ScriptDom.PartitionFunctionCall);
                case 660: return PartitionParameterType.FromMutable(fragment as ScriptDom.PartitionParameterType);
                case 661: return PartitionSpecifier.FromMutable(fragment as ScriptDom.PartitionSpecifier);
                case 662: return PartnerDatabaseOption.FromMutable(fragment as ScriptDom.PartnerDatabaseOption);
                case 663: return PasswordAlterPrincipalOption.FromMutable(fragment as ScriptDom.PasswordAlterPrincipalOption);
                case 664: return PasswordCreateLoginSource.FromMutable(fragment as ScriptDom.PasswordCreateLoginSource);
                case 665: return Permission.FromMutable(fragment as ScriptDom.Permission);
                case 666: return PermissionSetAssemblyOption.FromMutable(fragment as ScriptDom.PermissionSetAssemblyOption);
                case 667: return PivotedTableReference.FromMutable(fragment as ScriptDom.PivotedTableReference);
                case 668: return PortsEndpointProtocolOption.FromMutable(fragment as ScriptDom.PortsEndpointProtocolOption);
                case 669: return PredicateSetStatement.FromMutable(fragment as ScriptDom.PredicateSetStatement);
                case 670: return PredictTableReference.FromMutable(fragment as ScriptDom.PredictTableReference);
                case 671: return PrimaryRoleReplicaOption.FromMutable(fragment as ScriptDom.PrimaryRoleReplicaOption);
                case 672: return PrincipalOption.FromMutable(fragment as ScriptDom.PrincipalOption);
                case 673: return PrintStatement.FromMutable(fragment as ScriptDom.PrintStatement);
                case 674: return Privilege80.FromMutable(fragment as ScriptDom.Privilege80);
                case 675: return PrivilegeSecurityElement80.FromMutable(fragment as ScriptDom.PrivilegeSecurityElement80);
                case 676: return ProcedureOption.FromMutable(fragment as ScriptDom.ProcedureOption);
                case 677: return ProcedureParameter.FromMutable(fragment as ScriptDom.ProcedureParameter);
                case 678: return ProcedureReference.FromMutable(fragment as ScriptDom.ProcedureReference);
                case 679: return ProcedureReferenceName.FromMutable(fragment as ScriptDom.ProcedureReferenceName);
                case 680: return ProcessAffinityRange.FromMutable(fragment as ScriptDom.ProcessAffinityRange);
                case 681: return ProviderEncryptionSource.FromMutable(fragment as ScriptDom.ProviderEncryptionSource);
                case 682: return ProviderKeyNameKeyOption.FromMutable(fragment as ScriptDom.ProviderKeyNameKeyOption);
                case 683: return QualifiedJoin.FromMutable(fragment as ScriptDom.QualifiedJoin);
                case 684: return QueryDerivedTable.FromMutable(fragment as ScriptDom.QueryDerivedTable);
                case 685: return QueryParenthesisExpression.FromMutable(fragment as ScriptDom.QueryParenthesisExpression);
                case 686: return QuerySpecification.FromMutable(fragment as ScriptDom.QuerySpecification);
                case 687: return QueryStoreCapturePolicyOption.FromMutable(fragment as ScriptDom.QueryStoreCapturePolicyOption);
                case 688: return QueryStoreDatabaseOption.FromMutable(fragment as ScriptDom.QueryStoreDatabaseOption);
                case 689: return QueryStoreDataFlushIntervalOption.FromMutable(fragment as ScriptDom.QueryStoreDataFlushIntervalOption);
                case 690: return QueryStoreDesiredStateOption.FromMutable(fragment as ScriptDom.QueryStoreDesiredStateOption);
                case 691: return QueryStoreIntervalLengthOption.FromMutable(fragment as ScriptDom.QueryStoreIntervalLengthOption);
                case 692: return QueryStoreMaxPlansPerQueryOption.FromMutable(fragment as ScriptDom.QueryStoreMaxPlansPerQueryOption);
                case 693: return QueryStoreMaxStorageSizeOption.FromMutable(fragment as ScriptDom.QueryStoreMaxStorageSizeOption);
                case 694: return QueryStoreSizeCleanupPolicyOption.FromMutable(fragment as ScriptDom.QueryStoreSizeCleanupPolicyOption);
                case 695: return QueryStoreTimeCleanupPolicyOption.FromMutable(fragment as ScriptDom.QueryStoreTimeCleanupPolicyOption);
                case 696: return QueryStoreWaitStatsCaptureOption.FromMutable(fragment as ScriptDom.QueryStoreWaitStatsCaptureOption);
                case 697: return QueueDelayAuditOption.FromMutable(fragment as ScriptDom.QueueDelayAuditOption);
                case 698: return QueueExecuteAsOption.FromMutable(fragment as ScriptDom.QueueExecuteAsOption);
                case 699: return QueueOption.FromMutable(fragment as ScriptDom.QueueOption);
                case 700: return QueueProcedureOption.FromMutable(fragment as ScriptDom.QueueProcedureOption);
                case 701: return QueueStateOption.FromMutable(fragment as ScriptDom.QueueStateOption);
                case 702: return QueueValueOption.FromMutable(fragment as ScriptDom.QueueValueOption);
                case 703: return RaiseErrorLegacyStatement.FromMutable(fragment as ScriptDom.RaiseErrorLegacyStatement);
                case 704: return RaiseErrorStatement.FromMutable(fragment as ScriptDom.RaiseErrorStatement);
                case 705: return ReadOnlyForClause.FromMutable(fragment as ScriptDom.ReadOnlyForClause);
                case 706: return ReadTextStatement.FromMutable(fragment as ScriptDom.ReadTextStatement);
                case 707: return RealLiteral.FromMutable(fragment as ScriptDom.RealLiteral);
                case 708: return ReceiveStatement.FromMutable(fragment as ScriptDom.ReceiveStatement);
                case 709: return ReconfigureStatement.FromMutable(fragment as ScriptDom.ReconfigureStatement);
                case 710: return RecoveryDatabaseOption.FromMutable(fragment as ScriptDom.RecoveryDatabaseOption);
                case 711: return RemoteDataArchiveAlterTableOption.FromMutable(fragment as ScriptDom.RemoteDataArchiveAlterTableOption);
                case 712: return RemoteDataArchiveDatabaseOption.FromMutable(fragment as ScriptDom.RemoteDataArchiveDatabaseOption);
                case 713: return RemoteDataArchiveDbCredentialSetting.FromMutable(fragment as ScriptDom.RemoteDataArchiveDbCredentialSetting);
                case 714: return RemoteDataArchiveDbFederatedServiceAccountSetting.FromMutable(fragment as ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting);
                case 715: return RemoteDataArchiveDbServerSetting.FromMutable(fragment as ScriptDom.RemoteDataArchiveDbServerSetting);
                case 716: return RemoteDataArchiveTableOption.FromMutable(fragment as ScriptDom.RemoteDataArchiveTableOption);
                case 717: return RenameAlterRoleAction.FromMutable(fragment as ScriptDom.RenameAlterRoleAction);
                case 718: return RenameEntityStatement.FromMutable(fragment as ScriptDom.RenameEntityStatement);
                case 719: return ResampleStatisticsOption.FromMutable(fragment as ScriptDom.ResampleStatisticsOption);
                case 720: return ResourcePoolAffinitySpecification.FromMutable(fragment as ScriptDom.ResourcePoolAffinitySpecification);
                case 721: return ResourcePoolParameter.FromMutable(fragment as ScriptDom.ResourcePoolParameter);
                case 722: return ResourcePoolStatement.FromMutable(fragment as ScriptDom.ResourcePoolStatement);
                case 723: return RestoreMasterKeyStatement.FromMutable(fragment as ScriptDom.RestoreMasterKeyStatement);
                case 724: return RestoreOption.FromMutable(fragment as ScriptDom.RestoreOption);
                case 725: return RestoreServiceMasterKeyStatement.FromMutable(fragment as ScriptDom.RestoreServiceMasterKeyStatement);
                case 726: return RestoreStatement.FromMutable(fragment as ScriptDom.RestoreStatement);
                case 727: return ResultColumnDefinition.FromMutable(fragment as ScriptDom.ResultColumnDefinition);
                case 728: return ResultSetDefinition.FromMutable(fragment as ScriptDom.ResultSetDefinition);
                case 729: return ResultSetsExecuteOption.FromMutable(fragment as ScriptDom.ResultSetsExecuteOption);
                case 730: return RetentionDaysAuditTargetOption.FromMutable(fragment as ScriptDom.RetentionDaysAuditTargetOption);
                case 731: return RetentionPeriodDefinition.FromMutable(fragment as ScriptDom.RetentionPeriodDefinition);
                case 732: return ReturnStatement.FromMutable(fragment as ScriptDom.ReturnStatement);
                case 733: return RevertStatement.FromMutable(fragment as ScriptDom.RevertStatement);
                case 734: return RevokeStatement.FromMutable(fragment as ScriptDom.RevokeStatement);
                case 735: return RevokeStatement80.FromMutable(fragment as ScriptDom.RevokeStatement80);
                case 736: return RightFunctionCall.FromMutable(fragment as ScriptDom.RightFunctionCall);
                case 737: return RolePayloadOption.FromMutable(fragment as ScriptDom.RolePayloadOption);
                case 738: return RollbackTransactionStatement.FromMutable(fragment as ScriptDom.RollbackTransactionStatement);
                case 739: return RollupGroupingSpecification.FromMutable(fragment as ScriptDom.RollupGroupingSpecification);
                case 740: return RouteOption.FromMutable(fragment as ScriptDom.RouteOption);
                case 741: return RowValue.FromMutable(fragment as ScriptDom.RowValue);
                case 742: return SaveTransactionStatement.FromMutable(fragment as ScriptDom.SaveTransactionStatement);
                case 743: return ScalarExpressionDialogOption.FromMutable(fragment as ScriptDom.ScalarExpressionDialogOption);
                case 744: return ScalarExpressionRestoreOption.FromMutable(fragment as ScriptDom.ScalarExpressionRestoreOption);
                case 745: return ScalarExpressionSequenceOption.FromMutable(fragment as ScriptDom.ScalarExpressionSequenceOption);
                case 746: return ScalarExpressionSnippet.FromMutable(fragment as ScriptDom.ScalarExpressionSnippet);
                case 747: return ScalarFunctionReturnType.FromMutable(fragment as ScriptDom.ScalarFunctionReturnType);
                case 748: return ScalarSubquery.FromMutable(fragment as ScriptDom.ScalarSubquery);
                case 749: return SchemaDeclarationItem.FromMutable(fragment as ScriptDom.SchemaDeclarationItem);
                case 750: return SchemaDeclarationItemOpenjson.FromMutable(fragment as ScriptDom.SchemaDeclarationItemOpenjson);
                case 751: return SchemaObjectFunctionTableReference.FromMutable(fragment as ScriptDom.SchemaObjectFunctionTableReference);
                case 752: return SchemaObjectName.FromMutable(fragment as ScriptDom.SchemaObjectName);
                case 753: return SchemaObjectNameOrValueExpression.FromMutable(fragment as ScriptDom.SchemaObjectNameOrValueExpression);
                case 754: return SchemaObjectNameSnippet.FromMutable(fragment as ScriptDom.SchemaObjectNameSnippet);
                case 755: return SchemaObjectResultSetDefinition.FromMutable(fragment as ScriptDom.SchemaObjectResultSetDefinition);
                case 756: return SchemaPayloadOption.FromMutable(fragment as ScriptDom.SchemaPayloadOption);
                case 757: return SearchedCaseExpression.FromMutable(fragment as ScriptDom.SearchedCaseExpression);
                case 758: return SearchedWhenClause.FromMutable(fragment as ScriptDom.SearchedWhenClause);
                case 759: return SearchPropertyListFullTextIndexOption.FromMutable(fragment as ScriptDom.SearchPropertyListFullTextIndexOption);
                case 760: return SecondaryRoleReplicaOption.FromMutable(fragment as ScriptDom.SecondaryRoleReplicaOption);
                case 761: return SecurityPolicyOption.FromMutable(fragment as ScriptDom.SecurityPolicyOption);
                case 762: return SecurityPredicateAction.FromMutable(fragment as ScriptDom.SecurityPredicateAction);
                case 763: return SecurityPrincipal.FromMutable(fragment as ScriptDom.SecurityPrincipal);
                case 764: return SecurityTargetObject.FromMutable(fragment as ScriptDom.SecurityTargetObject);
                case 765: return SecurityTargetObjectName.FromMutable(fragment as ScriptDom.SecurityTargetObjectName);
                case 766: return SecurityUserClause80.FromMutable(fragment as ScriptDom.SecurityUserClause80);
                case 767: return SelectFunctionReturnType.FromMutable(fragment as ScriptDom.SelectFunctionReturnType);
                case 768: return SelectInsertSource.FromMutable(fragment as ScriptDom.SelectInsertSource);
                case 769: return SelectiveXmlIndexPromotedPath.FromMutable(fragment as ScriptDom.SelectiveXmlIndexPromotedPath);
                case 770: return SelectScalarExpression.FromMutable(fragment as ScriptDom.SelectScalarExpression);
                case 771: return SelectSetVariable.FromMutable(fragment as ScriptDom.SelectSetVariable);
                case 772: return SelectStarExpression.FromMutable(fragment as ScriptDom.SelectStarExpression);
                case 773: return SelectStatement.FromMutable(fragment as ScriptDom.SelectStatement);
                case 774: return SelectStatementSnippet.FromMutable(fragment as ScriptDom.SelectStatementSnippet);
                case 775: return SemanticTableReference.FromMutable(fragment as ScriptDom.SemanticTableReference);
                case 776: return SendStatement.FromMutable(fragment as ScriptDom.SendStatement);
                case 777: return SensitivityClassificationOption.FromMutable(fragment as ScriptDom.SensitivityClassificationOption);
                case 778: return SequenceOption.FromMutable(fragment as ScriptDom.SequenceOption);
                case 779: return ServiceContract.FromMutable(fragment as ScriptDom.ServiceContract);
                case 780: return SessionTimeoutPayloadOption.FromMutable(fragment as ScriptDom.SessionTimeoutPayloadOption);
                case 781: return SetCommandStatement.FromMutable(fragment as ScriptDom.SetCommandStatement);
                case 782: return SetErrorLevelStatement.FromMutable(fragment as ScriptDom.SetErrorLevelStatement);
                case 783: return SetFipsFlaggerCommand.FromMutable(fragment as ScriptDom.SetFipsFlaggerCommand);
                case 784: return SetIdentityInsertStatement.FromMutable(fragment as ScriptDom.SetIdentityInsertStatement);
                case 785: return SetOffsetsStatement.FromMutable(fragment as ScriptDom.SetOffsetsStatement);
                case 786: return SetRowCountStatement.FromMutable(fragment as ScriptDom.SetRowCountStatement);
                case 787: return SetSearchPropertyListAlterFullTextIndexAction.FromMutable(fragment as ScriptDom.SetSearchPropertyListAlterFullTextIndexAction);
                case 788: return SetStatisticsStatement.FromMutable(fragment as ScriptDom.SetStatisticsStatement);
                case 789: return SetStopListAlterFullTextIndexAction.FromMutable(fragment as ScriptDom.SetStopListAlterFullTextIndexAction);
                case 790: return SetTextSizeStatement.FromMutable(fragment as ScriptDom.SetTextSizeStatement);
                case 791: return SetTransactionIsolationLevelStatement.FromMutable(fragment as ScriptDom.SetTransactionIsolationLevelStatement);
                case 792: return SetUserStatement.FromMutable(fragment as ScriptDom.SetUserStatement);
                case 793: return SetVariableStatement.FromMutable(fragment as ScriptDom.SetVariableStatement);
                case 794: return ShutdownStatement.FromMutable(fragment as ScriptDom.ShutdownStatement);
                case 795: return SimpleAlterFullTextIndexAction.FromMutable(fragment as ScriptDom.SimpleAlterFullTextIndexAction);
                case 796: return SimpleCaseExpression.FromMutable(fragment as ScriptDom.SimpleCaseExpression);
                case 797: return SimpleWhenClause.FromMutable(fragment as ScriptDom.SimpleWhenClause);
                case 798: return SingleValueTypeCopyOption.FromMutable(fragment as ScriptDom.SingleValueTypeCopyOption);
                case 799: return SizeFileDeclarationOption.FromMutable(fragment as ScriptDom.SizeFileDeclarationOption);
                case 800: return SoapMethod.FromMutable(fragment as ScriptDom.SoapMethod);
                case 801: return SourceDeclaration.FromMutable(fragment as ScriptDom.SourceDeclaration);
                case 802: return SpatialIndexRegularOption.FromMutable(fragment as ScriptDom.SpatialIndexRegularOption);
                case 803: return SqlCommandIdentifier.FromMutable(fragment as ScriptDom.SqlCommandIdentifier);
                case 804: return SqlDataTypeReference.FromMutable(fragment as ScriptDom.SqlDataTypeReference);
                case 805: return StateAuditOption.FromMutable(fragment as ScriptDom.StateAuditOption);
                case 806: return StatementList.FromMutable(fragment as ScriptDom.StatementList);
                case 807: return StatementListSnippet.FromMutable(fragment as ScriptDom.StatementListSnippet);
                case 808: return StatisticsOption.FromMutable(fragment as ScriptDom.StatisticsOption);
                case 809: return StatisticsPartitionRange.FromMutable(fragment as ScriptDom.StatisticsPartitionRange);
                case 810: return StopListFullTextIndexOption.FromMutable(fragment as ScriptDom.StopListFullTextIndexOption);
                case 811: return StopRestoreOption.FromMutable(fragment as ScriptDom.StopRestoreOption);
                case 812: return StringLiteral.FromMutable(fragment as ScriptDom.StringLiteral);
                case 813: return SubqueryComparisonPredicate.FromMutable(fragment as ScriptDom.SubqueryComparisonPredicate);
                case 814: return SystemTimePeriodDefinition.FromMutable(fragment as ScriptDom.SystemTimePeriodDefinition);
                case 815: return SystemVersioningTableOption.FromMutable(fragment as ScriptDom.SystemVersioningTableOption);
                case 816: return TableClusteredIndexType.FromMutable(fragment as ScriptDom.TableClusteredIndexType);
                case 817: return TableDataCompressionOption.FromMutable(fragment as ScriptDom.TableDataCompressionOption);
                case 818: return TableDefinition.FromMutable(fragment as ScriptDom.TableDefinition);
                case 819: return TableDistributionOption.FromMutable(fragment as ScriptDom.TableDistributionOption);
                case 820: return TableHashDistributionPolicy.FromMutable(fragment as ScriptDom.TableHashDistributionPolicy);
                case 821: return TableHint.FromMutable(fragment as ScriptDom.TableHint);
                case 822: return TableHintsOptimizerHint.FromMutable(fragment as ScriptDom.TableHintsOptimizerHint);
                case 823: return TableIndexOption.FromMutable(fragment as ScriptDom.TableIndexOption);
                case 824: return TableNonClusteredIndexType.FromMutable(fragment as ScriptDom.TableNonClusteredIndexType);
                case 825: return TablePartitionOption.FromMutable(fragment as ScriptDom.TablePartitionOption);
                case 826: return TablePartitionOptionSpecifications.FromMutable(fragment as ScriptDom.TablePartitionOptionSpecifications);
                case 827: return TableReplicateDistributionPolicy.FromMutable(fragment as ScriptDom.TableReplicateDistributionPolicy);
                case 828: return TableRoundRobinDistributionPolicy.FromMutable(fragment as ScriptDom.TableRoundRobinDistributionPolicy);
                case 829: return TableSampleClause.FromMutable(fragment as ScriptDom.TableSampleClause);
                case 830: return TableValuedFunctionReturnType.FromMutable(fragment as ScriptDom.TableValuedFunctionReturnType);
                case 831: return TableXmlCompressionOption.FromMutable(fragment as ScriptDom.TableXmlCompressionOption);
                case 832: return TargetDeclaration.FromMutable(fragment as ScriptDom.TargetDeclaration);
                case 833: return TargetRecoveryTimeDatabaseOption.FromMutable(fragment as ScriptDom.TargetRecoveryTimeDatabaseOption);
                case 834: return TemporalClause.FromMutable(fragment as ScriptDom.TemporalClause);
                case 835: return ThrowStatement.FromMutable(fragment as ScriptDom.ThrowStatement);
                case 836: return TopRowFilter.FromMutable(fragment as ScriptDom.TopRowFilter);
                case 837: return TriggerAction.FromMutable(fragment as ScriptDom.TriggerAction);
                case 838: return TriggerObject.FromMutable(fragment as ScriptDom.TriggerObject);
                case 839: return TriggerOption.FromMutable(fragment as ScriptDom.TriggerOption);
                case 840: return TruncateTableStatement.FromMutable(fragment as ScriptDom.TruncateTableStatement);
                case 841: return TruncateTargetTableSwitchOption.FromMutable(fragment as ScriptDom.TruncateTargetTableSwitchOption);
                case 842: return TryCastCall.FromMutable(fragment as ScriptDom.TryCastCall);
                case 843: return TryCatchStatement.FromMutable(fragment as ScriptDom.TryCatchStatement);
                case 844: return TryConvertCall.FromMutable(fragment as ScriptDom.TryConvertCall);
                case 845: return TryParseCall.FromMutable(fragment as ScriptDom.TryParseCall);
                case 846: return TSEqualCall.FromMutable(fragment as ScriptDom.TSEqualCall);
                case 847: return TSqlBatch.FromMutable(fragment as ScriptDom.TSqlBatch);
                case 848: return TSqlFragmentSnippet.FromMutable(fragment as ScriptDom.TSqlFragmentSnippet);
                case 849: return TSqlScript.FromMutable(fragment as ScriptDom.TSqlScript);
                case 850: return TSqlStatementSnippet.FromMutable(fragment as ScriptDom.TSqlStatementSnippet);
                case 851: return UnaryExpression.FromMutable(fragment as ScriptDom.UnaryExpression);
                case 852: return UniqueConstraintDefinition.FromMutable(fragment as ScriptDom.UniqueConstraintDefinition);
                case 853: return UnpivotedTableReference.FromMutable(fragment as ScriptDom.UnpivotedTableReference);
                case 854: return UnqualifiedJoin.FromMutable(fragment as ScriptDom.UnqualifiedJoin);
                case 855: return UpdateCall.FromMutable(fragment as ScriptDom.UpdateCall);
                case 856: return UpdateForClause.FromMutable(fragment as ScriptDom.UpdateForClause);
                case 857: return UpdateMergeAction.FromMutable(fragment as ScriptDom.UpdateMergeAction);
                case 858: return UpdateSpecification.FromMutable(fragment as ScriptDom.UpdateSpecification);
                case 859: return UpdateStatement.FromMutable(fragment as ScriptDom.UpdateStatement);
                case 860: return UpdateStatisticsStatement.FromMutable(fragment as ScriptDom.UpdateStatisticsStatement);
                case 861: return UpdateTextStatement.FromMutable(fragment as ScriptDom.UpdateTextStatement);
                case 862: return UseFederationStatement.FromMutable(fragment as ScriptDom.UseFederationStatement);
                case 863: return UseHintList.FromMutable(fragment as ScriptDom.UseHintList);
                case 864: return UserDataTypeReference.FromMutable(fragment as ScriptDom.UserDataTypeReference);
                case 865: return UserDefinedTypeCallTarget.FromMutable(fragment as ScriptDom.UserDefinedTypeCallTarget);
                case 866: return UserDefinedTypePropertyAccess.FromMutable(fragment as ScriptDom.UserDefinedTypePropertyAccess);
                case 867: return UserLoginOption.FromMutable(fragment as ScriptDom.UserLoginOption);
                case 868: return UserRemoteServiceBindingOption.FromMutable(fragment as ScriptDom.UserRemoteServiceBindingOption);
                case 869: return UseStatement.FromMutable(fragment as ScriptDom.UseStatement);
                case 870: return ValuesInsertSource.FromMutable(fragment as ScriptDom.ValuesInsertSource);
                case 871: return VariableMethodCallTableReference.FromMutable(fragment as ScriptDom.VariableMethodCallTableReference);
                case 872: return VariableReference.FromMutable(fragment as ScriptDom.VariableReference);
                case 873: return VariableTableReference.FromMutable(fragment as ScriptDom.VariableTableReference);
                case 874: return VariableValuePair.FromMutable(fragment as ScriptDom.VariableValuePair);
                case 875: return ViewDistributionOption.FromMutable(fragment as ScriptDom.ViewDistributionOption);
                case 876: return ViewForAppendOption.FromMutable(fragment as ScriptDom.ViewForAppendOption);
                case 877: return ViewHashDistributionPolicy.FromMutable(fragment as ScriptDom.ViewHashDistributionPolicy);
                case 878: return ViewOption.FromMutable(fragment as ScriptDom.ViewOption);
                case 879: return ViewRoundRobinDistributionPolicy.FromMutable(fragment as ScriptDom.ViewRoundRobinDistributionPolicy);
                case 880: return WaitAtLowPriorityOption.FromMutable(fragment as ScriptDom.WaitAtLowPriorityOption);
                case 881: return WaitForStatement.FromMutable(fragment as ScriptDom.WaitForStatement);
                case 882: return WhereClause.FromMutable(fragment as ScriptDom.WhereClause);
                case 883: return WhileStatement.FromMutable(fragment as ScriptDom.WhileStatement);
                case 884: return WindowClause.FromMutable(fragment as ScriptDom.WindowClause);
                case 885: return WindowDefinition.FromMutable(fragment as ScriptDom.WindowDefinition);
                case 886: return WindowDelimiter.FromMutable(fragment as ScriptDom.WindowDelimiter);
                case 887: return WindowFrameClause.FromMutable(fragment as ScriptDom.WindowFrameClause);
                case 888: return WindowsCreateLoginSource.FromMutable(fragment as ScriptDom.WindowsCreateLoginSource);
                case 889: return WithCtesAndXmlNamespaces.FromMutable(fragment as ScriptDom.WithCtesAndXmlNamespaces);
                case 890: return WithinGroupClause.FromMutable(fragment as ScriptDom.WithinGroupClause);
                case 891: return WitnessDatabaseOption.FromMutable(fragment as ScriptDom.WitnessDatabaseOption);
                case 892: return WlmTimeLiteral.FromMutable(fragment as ScriptDom.WlmTimeLiteral);
                case 893: return WorkloadGroupImportanceParameter.FromMutable(fragment as ScriptDom.WorkloadGroupImportanceParameter);
                case 894: return WorkloadGroupResourceParameter.FromMutable(fragment as ScriptDom.WorkloadGroupResourceParameter);
                case 895: return WriteTextStatement.FromMutable(fragment as ScriptDom.WriteTextStatement);
                case 896: return WsdlPayloadOption.FromMutable(fragment as ScriptDom.WsdlPayloadOption);
                case 897: return XmlCompressionOption.FromMutable(fragment as ScriptDom.XmlCompressionOption);
                case 898: return XmlDataTypeReference.FromMutable(fragment as ScriptDom.XmlDataTypeReference);
                case 899: return XmlForClause.FromMutable(fragment as ScriptDom.XmlForClause);
                case 900: return XmlForClauseOption.FromMutable(fragment as ScriptDom.XmlForClauseOption);
                case 901: return XmlNamespaces.FromMutable(fragment as ScriptDom.XmlNamespaces);
                case 902: return XmlNamespacesAliasElement.FromMutable(fragment as ScriptDom.XmlNamespacesAliasElement);
                case 903: return XmlNamespacesDefaultElement.FromMutable(fragment as ScriptDom.XmlNamespacesDefaultElement);
                default: throw new NotImplementedException("Type not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library.");
            }
        }
    
    }

}
