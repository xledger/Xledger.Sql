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
            ["EnabledDisabledPayloadOption"] = 410,
            ["EnableDisableTriggerStatement"] = 411,
            ["EncryptedValueParameter"] = 412,
            ["EncryptionPayloadOption"] = 413,
            ["EndConversationStatement"] = 414,
            ["EndpointAffinity"] = 415,
            ["EventDeclaration"] = 416,
            ["EventDeclarationCompareFunctionParameter"] = 417,
            ["EventDeclarationSetParameter"] = 418,
            ["EventGroupContainer"] = 419,
            ["EventNotificationObjectScope"] = 420,
            ["EventRetentionSessionOption"] = 421,
            ["EventSessionObjectName"] = 422,
            ["EventSessionStatement"] = 423,
            ["EventTypeContainer"] = 424,
            ["ExecutableProcedureReference"] = 425,
            ["ExecutableStringList"] = 426,
            ["ExecuteAsClause"] = 427,
            ["ExecuteAsFunctionOption"] = 428,
            ["ExecuteAsProcedureOption"] = 429,
            ["ExecuteAsStatement"] = 430,
            ["ExecuteAsTriggerOption"] = 431,
            ["ExecuteContext"] = 432,
            ["ExecuteInsertSource"] = 433,
            ["ExecuteOption"] = 434,
            ["ExecuteParameter"] = 435,
            ["ExecuteSpecification"] = 436,
            ["ExecuteStatement"] = 437,
            ["ExistsPredicate"] = 438,
            ["ExpressionCallTarget"] = 439,
            ["ExpressionGroupingSpecification"] = 440,
            ["ExpressionWithSortOrder"] = 441,
            ["ExternalCreateLoginSource"] = 442,
            ["ExternalDataSourceLiteralOrIdentifierOption"] = 443,
            ["ExternalFileFormatContainerOption"] = 444,
            ["ExternalFileFormatLiteralOption"] = 445,
            ["ExternalFileFormatUseDefaultTypeOption"] = 446,
            ["ExternalLanguageFileOption"] = 447,
            ["ExternalLibraryFileOption"] = 448,
            ["ExternalResourcePoolAffinitySpecification"] = 449,
            ["ExternalResourcePoolParameter"] = 450,
            ["ExternalResourcePoolStatement"] = 451,
            ["ExternalStreamLiteralOrIdentifierOption"] = 452,
            ["ExternalTableColumnDefinition"] = 453,
            ["ExternalTableDistributionOption"] = 454,
            ["ExternalTableLiteralOrIdentifierOption"] = 455,
            ["ExternalTableRejectTypeOption"] = 456,
            ["ExternalTableReplicatedDistributionPolicy"] = 457,
            ["ExternalTableRoundRobinDistributionPolicy"] = 458,
            ["ExternalTableShardedDistributionPolicy"] = 459,
            ["ExtractFromExpression"] = 460,
            ["FailoverModeReplicaOption"] = 461,
            ["FederationScheme"] = 462,
            ["FetchCursorStatement"] = 463,
            ["FetchType"] = 464,
            ["FileDeclaration"] = 465,
            ["FileDeclarationOption"] = 466,
            ["FileEncryptionSource"] = 467,
            ["FileGroupDefinition"] = 468,
            ["FileGroupOrPartitionScheme"] = 469,
            ["FileGrowthFileDeclarationOption"] = 470,
            ["FileNameFileDeclarationOption"] = 471,
            ["FileStreamDatabaseOption"] = 472,
            ["FileStreamOnDropIndexOption"] = 473,
            ["FileStreamOnTableOption"] = 474,
            ["FileStreamRestoreOption"] = 475,
            ["FileTableCollateFileNameTableOption"] = 476,
            ["FileTableConstraintNameTableOption"] = 477,
            ["FileTableDirectoryTableOption"] = 478,
            ["ForceSeekTableHint"] = 479,
            ["ForeignKeyConstraintDefinition"] = 480,
            ["FromClause"] = 481,
            ["FullTextCatalogAndFileGroup"] = 482,
            ["FullTextIndexColumn"] = 483,
            ["FullTextPredicate"] = 484,
            ["FullTextStopListAction"] = 485,
            ["FullTextTableReference"] = 486,
            ["FunctionCall"] = 487,
            ["FunctionCallSetClause"] = 488,
            ["FunctionOption"] = 489,
            ["GeneralSetCommand"] = 490,
            ["GenericConfigurationOption"] = 491,
            ["GetConversationGroupStatement"] = 492,
            ["GlobalFunctionTableReference"] = 493,
            ["GlobalVariableExpression"] = 494,
            ["GoToStatement"] = 495,
            ["GrandTotalGroupingSpecification"] = 496,
            ["GrantStatement"] = 497,
            ["GrantStatement80"] = 498,
            ["GraphConnectionBetweenNodes"] = 499,
            ["GraphConnectionConstraintDefinition"] = 500,
            ["GraphMatchCompositeExpression"] = 501,
            ["GraphMatchExpression"] = 502,
            ["GraphMatchLastNodePredicate"] = 503,
            ["GraphMatchNodeExpression"] = 504,
            ["GraphMatchPredicate"] = 505,
            ["GraphMatchRecursivePredicate"] = 506,
            ["GraphRecursiveMatchQuantifier"] = 507,
            ["GridParameter"] = 508,
            ["GridsSpatialIndexOption"] = 509,
            ["GroupByClause"] = 510,
            ["GroupingSetsGroupingSpecification"] = 511,
            ["HadrAvailabilityGroupDatabaseOption"] = 512,
            ["HadrDatabaseOption"] = 513,
            ["HavingClause"] = 514,
            ["Identifier"] = 515,
            ["IdentifierAtomicBlockOption"] = 516,
            ["IdentifierDatabaseOption"] = 517,
            ["IdentifierLiteral"] = 518,
            ["IdentifierOrScalarExpression"] = 519,
            ["IdentifierOrValueExpression"] = 520,
            ["IdentifierPrincipalOption"] = 521,
            ["IdentifierSnippet"] = 522,
            ["IdentityFunctionCall"] = 523,
            ["IdentityOptions"] = 524,
            ["IdentityValueKeyOption"] = 525,
            ["IfStatement"] = 526,
            ["IgnoreDupKeyIndexOption"] = 527,
            ["IIfCall"] = 528,
            ["IndexDefinition"] = 529,
            ["IndexExpressionOption"] = 530,
            ["IndexStateOption"] = 531,
            ["IndexTableHint"] = 532,
            ["IndexType"] = 533,
            ["InlineDerivedTable"] = 534,
            ["InlineFunctionOption"] = 535,
            ["InlineResultSetDefinition"] = 536,
            ["InPredicate"] = 537,
            ["InsertBulkColumnDefinition"] = 538,
            ["InsertBulkStatement"] = 539,
            ["InsertMergeAction"] = 540,
            ["InsertSpecification"] = 541,
            ["InsertStatement"] = 542,
            ["IntegerLiteral"] = 543,
            ["InternalOpenRowset"] = 544,
            ["IPv4"] = 545,
            ["JoinParenthesisTableReference"] = 546,
            ["JsonForClause"] = 547,
            ["JsonForClauseOption"] = 548,
            ["JsonKeyValue"] = 549,
            ["KeySourceKeyOption"] = 550,
            ["KillQueryNotificationSubscriptionStatement"] = 551,
            ["KillStatement"] = 552,
            ["KillStatsJobStatement"] = 553,
            ["LabelStatement"] = 554,
            ["LedgerOption"] = 555,
            ["LedgerTableOption"] = 556,
            ["LedgerViewOption"] = 557,
            ["LeftFunctionCall"] = 558,
            ["LikePredicate"] = 559,
            ["LineNoStatement"] = 560,
            ["ListenerIPEndpointProtocolOption"] = 561,
            ["ListTypeCopyOption"] = 562,
            ["LiteralAtomicBlockOption"] = 563,
            ["LiteralAuditTargetOption"] = 564,
            ["LiteralAvailabilityGroupOption"] = 565,
            ["LiteralBulkInsertOption"] = 566,
            ["LiteralDatabaseOption"] = 567,
            ["LiteralEndpointProtocolOption"] = 568,
            ["LiteralOpenRowsetCosmosOption"] = 569,
            ["LiteralOptimizerHint"] = 570,
            ["LiteralOptionValue"] = 571,
            ["LiteralPayloadOption"] = 572,
            ["LiteralPrincipalOption"] = 573,
            ["LiteralRange"] = 574,
            ["LiteralReplicaOption"] = 575,
            ["LiteralSessionOption"] = 576,
            ["LiteralStatisticsOption"] = 577,
            ["LiteralTableHint"] = 578,
            ["LocationOption"] = 579,
            ["LockEscalationTableOption"] = 580,
            ["LoginTypePayloadOption"] = 581,
            ["LowPriorityLockWaitAbortAfterWaitOption"] = 582,
            ["LowPriorityLockWaitMaxDurationOption"] = 583,
            ["LowPriorityLockWaitTableSwitchOption"] = 584,
            ["MaxDispatchLatencySessionOption"] = 585,
            ["MaxDopConfigurationOption"] = 586,
            ["MaxDurationOption"] = 587,
            ["MaxLiteral"] = 588,
            ["MaxRolloverFilesAuditTargetOption"] = 589,
            ["MaxSizeAuditTargetOption"] = 590,
            ["MaxSizeDatabaseOption"] = 591,
            ["MaxSizeFileDeclarationOption"] = 592,
            ["MemoryOptimizedTableOption"] = 593,
            ["MemoryPartitionSessionOption"] = 594,
            ["MergeActionClause"] = 595,
            ["MergeSpecification"] = 596,
            ["MergeStatement"] = 597,
            ["MethodSpecifier"] = 598,
            ["MirrorToClause"] = 599,
            ["MoneyLiteral"] = 600,
            ["MoveConversationStatement"] = 601,
            ["MoveRestoreOption"] = 602,
            ["MoveToDropIndexOption"] = 603,
            ["MultiPartIdentifier"] = 604,
            ["MultiPartIdentifierCallTarget"] = 605,
            ["NamedTableReference"] = 606,
            ["NameFileDeclarationOption"] = 607,
            ["NextValueForExpression"] = 608,
            ["NullableConstraintDefinition"] = 609,
            ["NullIfExpression"] = 610,
            ["NullLiteral"] = 611,
            ["NumericLiteral"] = 612,
            ["OdbcConvertSpecification"] = 613,
            ["OdbcFunctionCall"] = 614,
            ["OdbcLiteral"] = 615,
            ["OdbcQualifiedJoinTableReference"] = 616,
            ["OffsetClause"] = 617,
            ["OnFailureAuditOption"] = 618,
            ["OnlineIndexLowPriorityLockWaitOption"] = 619,
            ["OnlineIndexOption"] = 620,
            ["OnOffAssemblyOption"] = 621,
            ["OnOffAtomicBlockOption"] = 622,
            ["OnOffAuditTargetOption"] = 623,
            ["OnOffDatabaseOption"] = 624,
            ["OnOffDialogOption"] = 625,
            ["OnOffFullTextCatalogOption"] = 626,
            ["OnOffOptionValue"] = 627,
            ["OnOffPrimaryConfigurationOption"] = 628,
            ["OnOffPrincipalOption"] = 629,
            ["OnOffRemoteServiceBindingOption"] = 630,
            ["OnOffSessionOption"] = 631,
            ["OnOffStatisticsOption"] = 632,
            ["OpenCursorStatement"] = 633,
            ["OpenJsonTableReference"] = 634,
            ["OpenMasterKeyStatement"] = 635,
            ["OpenQueryTableReference"] = 636,
            ["OpenRowsetColumnDefinition"] = 637,
            ["OpenRowsetCosmos"] = 638,
            ["OpenRowsetCosmosOption"] = 639,
            ["OpenRowsetTableReference"] = 640,
            ["OpenSymmetricKeyStatement"] = 641,
            ["OpenXmlTableReference"] = 642,
            ["OperatorAuditOption"] = 643,
            ["OptimizeForOptimizerHint"] = 644,
            ["OptimizerHint"] = 645,
            ["OrderBulkInsertOption"] = 646,
            ["OrderByClause"] = 647,
            ["OrderIndexOption"] = 648,
            ["OutputClause"] = 649,
            ["OutputIntoClause"] = 650,
            ["OverClause"] = 651,
            ["PageVerifyDatabaseOption"] = 652,
            ["ParameterizationDatabaseOption"] = 653,
            ["ParameterlessCall"] = 654,
            ["ParenthesisExpression"] = 655,
            ["ParseCall"] = 656,
            ["PartitionFunctionCall"] = 657,
            ["PartitionParameterType"] = 658,
            ["PartitionSpecifier"] = 659,
            ["PartnerDatabaseOption"] = 660,
            ["PasswordAlterPrincipalOption"] = 661,
            ["PasswordCreateLoginSource"] = 662,
            ["Permission"] = 663,
            ["PermissionSetAssemblyOption"] = 664,
            ["PivotedTableReference"] = 665,
            ["PortsEndpointProtocolOption"] = 666,
            ["PredicateSetStatement"] = 667,
            ["PredictTableReference"] = 668,
            ["PrimaryRoleReplicaOption"] = 669,
            ["PrincipalOption"] = 670,
            ["PrintStatement"] = 671,
            ["Privilege80"] = 672,
            ["PrivilegeSecurityElement80"] = 673,
            ["ProcedureOption"] = 674,
            ["ProcedureParameter"] = 675,
            ["ProcedureReference"] = 676,
            ["ProcedureReferenceName"] = 677,
            ["ProcessAffinityRange"] = 678,
            ["ProviderEncryptionSource"] = 679,
            ["ProviderKeyNameKeyOption"] = 680,
            ["QualifiedJoin"] = 681,
            ["QueryDerivedTable"] = 682,
            ["QueryParenthesisExpression"] = 683,
            ["QuerySpecification"] = 684,
            ["QueryStoreCapturePolicyOption"] = 685,
            ["QueryStoreDatabaseOption"] = 686,
            ["QueryStoreDataFlushIntervalOption"] = 687,
            ["QueryStoreDesiredStateOption"] = 688,
            ["QueryStoreIntervalLengthOption"] = 689,
            ["QueryStoreMaxPlansPerQueryOption"] = 690,
            ["QueryStoreMaxStorageSizeOption"] = 691,
            ["QueryStoreSizeCleanupPolicyOption"] = 692,
            ["QueryStoreTimeCleanupPolicyOption"] = 693,
            ["QueueDelayAuditOption"] = 694,
            ["QueueExecuteAsOption"] = 695,
            ["QueueOption"] = 696,
            ["QueueProcedureOption"] = 697,
            ["QueueStateOption"] = 698,
            ["QueueValueOption"] = 699,
            ["RaiseErrorLegacyStatement"] = 700,
            ["RaiseErrorStatement"] = 701,
            ["ReadOnlyForClause"] = 702,
            ["ReadTextStatement"] = 703,
            ["RealLiteral"] = 704,
            ["ReceiveStatement"] = 705,
            ["ReconfigureStatement"] = 706,
            ["RecoveryDatabaseOption"] = 707,
            ["RemoteDataArchiveAlterTableOption"] = 708,
            ["RemoteDataArchiveDatabaseOption"] = 709,
            ["RemoteDataArchiveDbCredentialSetting"] = 710,
            ["RemoteDataArchiveDbFederatedServiceAccountSetting"] = 711,
            ["RemoteDataArchiveDbServerSetting"] = 712,
            ["RemoteDataArchiveTableOption"] = 713,
            ["RenameAlterRoleAction"] = 714,
            ["RenameEntityStatement"] = 715,
            ["ResampleStatisticsOption"] = 716,
            ["ResourcePoolAffinitySpecification"] = 717,
            ["ResourcePoolParameter"] = 718,
            ["ResourcePoolStatement"] = 719,
            ["RestoreMasterKeyStatement"] = 720,
            ["RestoreOption"] = 721,
            ["RestoreServiceMasterKeyStatement"] = 722,
            ["RestoreStatement"] = 723,
            ["ResultColumnDefinition"] = 724,
            ["ResultSetDefinition"] = 725,
            ["ResultSetsExecuteOption"] = 726,
            ["RetentionDaysAuditTargetOption"] = 727,
            ["RetentionPeriodDefinition"] = 728,
            ["ReturnStatement"] = 729,
            ["RevertStatement"] = 730,
            ["RevokeStatement"] = 731,
            ["RevokeStatement80"] = 732,
            ["RightFunctionCall"] = 733,
            ["RolePayloadOption"] = 734,
            ["RollbackTransactionStatement"] = 735,
            ["RollupGroupingSpecification"] = 736,
            ["RouteOption"] = 737,
            ["RowValue"] = 738,
            ["SaveTransactionStatement"] = 739,
            ["ScalarExpressionDialogOption"] = 740,
            ["ScalarExpressionRestoreOption"] = 741,
            ["ScalarExpressionSequenceOption"] = 742,
            ["ScalarExpressionSnippet"] = 743,
            ["ScalarFunctionReturnType"] = 744,
            ["ScalarSubquery"] = 745,
            ["SchemaDeclarationItem"] = 746,
            ["SchemaDeclarationItemOpenjson"] = 747,
            ["SchemaObjectFunctionTableReference"] = 748,
            ["SchemaObjectName"] = 749,
            ["SchemaObjectNameOrValueExpression"] = 750,
            ["SchemaObjectNameSnippet"] = 751,
            ["SchemaObjectResultSetDefinition"] = 752,
            ["SchemaPayloadOption"] = 753,
            ["SearchedCaseExpression"] = 754,
            ["SearchedWhenClause"] = 755,
            ["SearchPropertyListFullTextIndexOption"] = 756,
            ["SecondaryRoleReplicaOption"] = 757,
            ["SecurityPolicyOption"] = 758,
            ["SecurityPredicateAction"] = 759,
            ["SecurityPrincipal"] = 760,
            ["SecurityTargetObject"] = 761,
            ["SecurityTargetObjectName"] = 762,
            ["SecurityUserClause80"] = 763,
            ["SelectFunctionReturnType"] = 764,
            ["SelectInsertSource"] = 765,
            ["SelectiveXmlIndexPromotedPath"] = 766,
            ["SelectScalarExpression"] = 767,
            ["SelectSetVariable"] = 768,
            ["SelectStarExpression"] = 769,
            ["SelectStatement"] = 770,
            ["SelectStatementSnippet"] = 771,
            ["SemanticTableReference"] = 772,
            ["SendStatement"] = 773,
            ["SensitivityClassificationOption"] = 774,
            ["SequenceOption"] = 775,
            ["ServiceContract"] = 776,
            ["SessionTimeoutPayloadOption"] = 777,
            ["SetCommandStatement"] = 778,
            ["SetErrorLevelStatement"] = 779,
            ["SetFipsFlaggerCommand"] = 780,
            ["SetIdentityInsertStatement"] = 781,
            ["SetOffsetsStatement"] = 782,
            ["SetRowCountStatement"] = 783,
            ["SetSearchPropertyListAlterFullTextIndexAction"] = 784,
            ["SetStatisticsStatement"] = 785,
            ["SetStopListAlterFullTextIndexAction"] = 786,
            ["SetTextSizeStatement"] = 787,
            ["SetTransactionIsolationLevelStatement"] = 788,
            ["SetUserStatement"] = 789,
            ["SetVariableStatement"] = 790,
            ["ShutdownStatement"] = 791,
            ["SimpleAlterFullTextIndexAction"] = 792,
            ["SimpleCaseExpression"] = 793,
            ["SimpleWhenClause"] = 794,
            ["SingleValueTypeCopyOption"] = 795,
            ["SizeFileDeclarationOption"] = 796,
            ["SoapMethod"] = 797,
            ["SourceDeclaration"] = 798,
            ["SpatialIndexRegularOption"] = 799,
            ["SqlCommandIdentifier"] = 800,
            ["SqlDataTypeReference"] = 801,
            ["StateAuditOption"] = 802,
            ["StatementList"] = 803,
            ["StatementListSnippet"] = 804,
            ["StatisticsOption"] = 805,
            ["StatisticsPartitionRange"] = 806,
            ["StopListFullTextIndexOption"] = 807,
            ["StopRestoreOption"] = 808,
            ["StringLiteral"] = 809,
            ["SubqueryComparisonPredicate"] = 810,
            ["SystemTimePeriodDefinition"] = 811,
            ["SystemVersioningTableOption"] = 812,
            ["TableClusteredIndexType"] = 813,
            ["TableDataCompressionOption"] = 814,
            ["TableDefinition"] = 815,
            ["TableDistributionOption"] = 816,
            ["TableHashDistributionPolicy"] = 817,
            ["TableHint"] = 818,
            ["TableHintsOptimizerHint"] = 819,
            ["TableIndexOption"] = 820,
            ["TableNonClusteredIndexType"] = 821,
            ["TablePartitionOption"] = 822,
            ["TablePartitionOptionSpecifications"] = 823,
            ["TableReplicateDistributionPolicy"] = 824,
            ["TableRoundRobinDistributionPolicy"] = 825,
            ["TableSampleClause"] = 826,
            ["TableValuedFunctionReturnType"] = 827,
            ["TableXmlCompressionOption"] = 828,
            ["TargetDeclaration"] = 829,
            ["TargetRecoveryTimeDatabaseOption"] = 830,
            ["TemporalClause"] = 831,
            ["ThrowStatement"] = 832,
            ["TopRowFilter"] = 833,
            ["TriggerAction"] = 834,
            ["TriggerObject"] = 835,
            ["TriggerOption"] = 836,
            ["TruncateTableStatement"] = 837,
            ["TruncateTargetTableSwitchOption"] = 838,
            ["TryCastCall"] = 839,
            ["TryCatchStatement"] = 840,
            ["TryConvertCall"] = 841,
            ["TryParseCall"] = 842,
            ["TSEqualCall"] = 843,
            ["TSqlBatch"] = 844,
            ["TSqlFragmentSnippet"] = 845,
            ["TSqlScript"] = 846,
            ["TSqlStatementSnippet"] = 847,
            ["UnaryExpression"] = 848,
            ["UniqueConstraintDefinition"] = 849,
            ["UnpivotedTableReference"] = 850,
            ["UnqualifiedJoin"] = 851,
            ["UpdateCall"] = 852,
            ["UpdateForClause"] = 853,
            ["UpdateMergeAction"] = 854,
            ["UpdateSpecification"] = 855,
            ["UpdateStatement"] = 856,
            ["UpdateStatisticsStatement"] = 857,
            ["UpdateTextStatement"] = 858,
            ["UseFederationStatement"] = 859,
            ["UseHintList"] = 860,
            ["UserDataTypeReference"] = 861,
            ["UserDefinedTypeCallTarget"] = 862,
            ["UserDefinedTypePropertyAccess"] = 863,
            ["UserLoginOption"] = 864,
            ["UserRemoteServiceBindingOption"] = 865,
            ["UseStatement"] = 866,
            ["ValuesInsertSource"] = 867,
            ["VariableMethodCallTableReference"] = 868,
            ["VariableReference"] = 869,
            ["VariableTableReference"] = 870,
            ["VariableValuePair"] = 871,
            ["ViewDistributionOption"] = 872,
            ["ViewForAppendOption"] = 873,
            ["ViewHashDistributionPolicy"] = 874,
            ["ViewOption"] = 875,
            ["ViewRoundRobinDistributionPolicy"] = 876,
            ["WaitAtLowPriorityOption"] = 877,
            ["WaitForStatement"] = 878,
            ["WhereClause"] = 879,
            ["WhileStatement"] = 880,
            ["WindowClause"] = 881,
            ["WindowDefinition"] = 882,
            ["WindowDelimiter"] = 883,
            ["WindowFrameClause"] = 884,
            ["WindowsCreateLoginSource"] = 885,
            ["WithCtesAndXmlNamespaces"] = 886,
            ["WithinGroupClause"] = 887,
            ["WitnessDatabaseOption"] = 888,
            ["WlmTimeLiteral"] = 889,
            ["WorkloadGroupImportanceParameter"] = 890,
            ["WorkloadGroupResourceParameter"] = 891,
            ["WriteTextStatement"] = 892,
            ["WsdlPayloadOption"] = 893,
            ["XmlCompressionOption"] = 894,
            ["XmlDataTypeReference"] = 895,
            ["XmlForClause"] = 896,
            ["XmlForClauseOption"] = 897,
            ["XmlNamespaces"] = 898,
            ["XmlNamespacesAliasElement"] = 899,
            ["XmlNamespacesDefaultElement"] = 900,
        };
    
    
        public static TSqlFragment FromMutable(ScriptDom.TSqlFragment fragment) {
            var st = new System.Diagnostics.StackTrace();
            if (fragment is null) { return null; }
            if (!TagNumberByTypeName.TryGetValue(fragment.GetType().Name, out var tag)) {
                throw new NotImplementedException("Type not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library.");
            }
        
            switch (tag) {
                case 1: {
                    return new AcceleratedDatabaseRecoveryDatabaseOption(
                        optionState: (fragment as ScriptDom.AcceleratedDatabaseRecoveryDatabaseOption).OptionState,
                        optionKind: (fragment as ScriptDom.AcceleratedDatabaseRecoveryDatabaseOption).OptionKind
                    );
                }
                case 2: {
                    return new AddAlterFullTextIndexAction(
                        columns: (fragment as ScriptDom.AddAlterFullTextIndexAction).Columns.SelectList(c => (FullTextIndexColumn)FromMutable(c)),
                        withNoPopulation: (fragment as ScriptDom.AddAlterFullTextIndexAction).WithNoPopulation
                    );
                }
                case 3: {
                    return new AddFileSpec(
                        file: (ScalarExpression)FromMutable((fragment as ScriptDom.AddFileSpec).File),
                        fileName: (Literal)FromMutable((fragment as ScriptDom.AddFileSpec).FileName)
                    );
                }
                case 4: {
                    return new AddMemberAlterRoleAction(
                        member: (Identifier)FromMutable((fragment as ScriptDom.AddMemberAlterRoleAction).Member)
                    );
                }
                case 5: {
                    return new AddSearchPropertyListAction(
                        propertyName: (StringLiteral)FromMutable((fragment as ScriptDom.AddSearchPropertyListAction).PropertyName),
                        guid: (StringLiteral)FromMutable((fragment as ScriptDom.AddSearchPropertyListAction).Guid),
                        id: (IntegerLiteral)FromMutable((fragment as ScriptDom.AddSearchPropertyListAction).Id),
                        description: (StringLiteral)FromMutable((fragment as ScriptDom.AddSearchPropertyListAction).Description)
                    );
                }
                case 6: {
                    return new AddSensitivityClassificationStatement(
                        options: (fragment as ScriptDom.AddSensitivityClassificationStatement).Options.SelectList(c => (SensitivityClassificationOption)FromMutable(c)),
                        columns: (fragment as ScriptDom.AddSensitivityClassificationStatement).Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
                    );
                }
                case 7: {
                    return new AddSignatureStatement(
                        isCounter: (fragment as ScriptDom.AddSignatureStatement).IsCounter,
                        elementKind: (fragment as ScriptDom.AddSignatureStatement).ElementKind,
                        element: (SchemaObjectName)FromMutable((fragment as ScriptDom.AddSignatureStatement).Element),
                        cryptos: (fragment as ScriptDom.AddSignatureStatement).Cryptos.SelectList(c => (CryptoMechanism)FromMutable(c))
                    );
                }
                case 8: {
                    return new AdHocDataSource(
                        providerName: (StringLiteral)FromMutable((fragment as ScriptDom.AdHocDataSource).ProviderName),
                        initString: (StringLiteral)FromMutable((fragment as ScriptDom.AdHocDataSource).InitString)
                    );
                }
                case 9: {
                    return new AdHocTableReference(
                        dataSource: (AdHocDataSource)FromMutable((fragment as ScriptDom.AdHocTableReference).DataSource),
                        @object: (SchemaObjectNameOrValueExpression)FromMutable((fragment as ScriptDom.AdHocTableReference).Object),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.AdHocTableReference).Alias),
                        forPath: (fragment as ScriptDom.AdHocTableReference).ForPath
                    );
                }
                case 10: {
                    return new AlgorithmKeyOption(
                        algorithm: (fragment as ScriptDom.AlgorithmKeyOption).Algorithm,
                        optionKind: (fragment as ScriptDom.AlgorithmKeyOption).OptionKind
                    );
                }
                case 11: {
                    return new AlterApplicationRoleStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterApplicationRoleStatement).Name),
                        applicationRoleOptions: (fragment as ScriptDom.AlterApplicationRoleStatement).ApplicationRoleOptions.SelectList(c => (ApplicationRoleOption)FromMutable(c))
                    );
                }
                case 12: {
                    return new AlterAssemblyStatement(
                        dropFiles: (fragment as ScriptDom.AlterAssemblyStatement).DropFiles.SelectList(c => (Literal)FromMutable(c)),
                        isDropAll: (fragment as ScriptDom.AlterAssemblyStatement).IsDropAll,
                        addFiles: (fragment as ScriptDom.AlterAssemblyStatement).AddFiles.SelectList(c => (AddFileSpec)FromMutable(c)),
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterAssemblyStatement).Name),
                        parameters: (fragment as ScriptDom.AlterAssemblyStatement).Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        options: (fragment as ScriptDom.AlterAssemblyStatement).Options.SelectList(c => (AssemblyOption)FromMutable(c))
                    );
                }
                case 13: {
                    return new AlterAsymmetricKeyStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterAsymmetricKeyStatement).Name),
                        attestedBy: (Literal)FromMutable((fragment as ScriptDom.AlterAsymmetricKeyStatement).AttestedBy),
                        kind: (fragment as ScriptDom.AlterAsymmetricKeyStatement).Kind,
                        encryptionPassword: (Literal)FromMutable((fragment as ScriptDom.AlterAsymmetricKeyStatement).EncryptionPassword),
                        decryptionPassword: (Literal)FromMutable((fragment as ScriptDom.AlterAsymmetricKeyStatement).DecryptionPassword)
                    );
                }
                case 14: {
                    return new AlterAuthorizationStatement(
                        securityTargetObject: (SecurityTargetObject)FromMutable((fragment as ScriptDom.AlterAuthorizationStatement).SecurityTargetObject),
                        toSchemaOwner: (fragment as ScriptDom.AlterAuthorizationStatement).ToSchemaOwner,
                        principalName: (Identifier)FromMutable((fragment as ScriptDom.AlterAuthorizationStatement).PrincipalName)
                    );
                }
                case 15: {
                    return new AlterAvailabilityGroupAction(
                        actionType: (fragment as ScriptDom.AlterAvailabilityGroupAction).ActionType
                    );
                }
                case 16: {
                    return new AlterAvailabilityGroupFailoverAction(
                        options: (fragment as ScriptDom.AlterAvailabilityGroupFailoverAction).Options.SelectList(c => (AlterAvailabilityGroupFailoverOption)FromMutable(c)),
                        actionType: (fragment as ScriptDom.AlterAvailabilityGroupFailoverAction).ActionType
                    );
                }
                case 17: {
                    return new AlterAvailabilityGroupFailoverOption(
                        optionKind: (fragment as ScriptDom.AlterAvailabilityGroupFailoverOption).OptionKind,
                        @value: (Literal)FromMutable((fragment as ScriptDom.AlterAvailabilityGroupFailoverOption).Value)
                    );
                }
                case 18: {
                    return new AlterAvailabilityGroupStatement(
                        alterAvailabilityGroupStatementType: (fragment as ScriptDom.AlterAvailabilityGroupStatement).AlterAvailabilityGroupStatementType,
                        action: (AlterAvailabilityGroupAction)FromMutable((fragment as ScriptDom.AlterAvailabilityGroupStatement).Action),
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterAvailabilityGroupStatement).Name),
                        options: (fragment as ScriptDom.AlterAvailabilityGroupStatement).Options.SelectList(c => (AvailabilityGroupOption)FromMutable(c)),
                        databases: (fragment as ScriptDom.AlterAvailabilityGroupStatement).Databases.SelectList(c => (Identifier)FromMutable(c)),
                        replicas: (fragment as ScriptDom.AlterAvailabilityGroupStatement).Replicas.SelectList(c => (AvailabilityReplica)FromMutable(c))
                    );
                }
                case 19: {
                    return new AlterBrokerPriorityStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterBrokerPriorityStatement).Name),
                        brokerPriorityParameters: (fragment as ScriptDom.AlterBrokerPriorityStatement).BrokerPriorityParameters.SelectList(c => (BrokerPriorityParameter)FromMutable(c))
                    );
                }
                case 20: {
                    return new AlterCertificateStatement(
                        kind: (fragment as ScriptDom.AlterCertificateStatement).Kind,
                        attestedBy: (Literal)FromMutable((fragment as ScriptDom.AlterCertificateStatement).AttestedBy),
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterCertificateStatement).Name),
                        activeForBeginDialog: (fragment as ScriptDom.AlterCertificateStatement).ActiveForBeginDialog,
                        privateKeyPath: (Literal)FromMutable((fragment as ScriptDom.AlterCertificateStatement).PrivateKeyPath),
                        encryptionPassword: (Literal)FromMutable((fragment as ScriptDom.AlterCertificateStatement).EncryptionPassword),
                        decryptionPassword: (Literal)FromMutable((fragment as ScriptDom.AlterCertificateStatement).DecryptionPassword)
                    );
                }
                case 21: {
                    return new AlterColumnAlterFullTextIndexAction(
                        column: (FullTextIndexColumn)FromMutable((fragment as ScriptDom.AlterColumnAlterFullTextIndexAction).Column),
                        withNoPopulation: (fragment as ScriptDom.AlterColumnAlterFullTextIndexAction).WithNoPopulation
                    );
                }
                case 22: {
                    return new AlterColumnEncryptionKeyStatement(
                        alterType: (fragment as ScriptDom.AlterColumnEncryptionKeyStatement).AlterType,
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterColumnEncryptionKeyStatement).Name),
                        columnEncryptionKeyValues: (fragment as ScriptDom.AlterColumnEncryptionKeyStatement).ColumnEncryptionKeyValues.SelectList(c => (ColumnEncryptionKeyValue)FromMutable(c))
                    );
                }
                case 23: {
                    return new AlterCredentialStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterCredentialStatement).Name),
                        identity: (Literal)FromMutable((fragment as ScriptDom.AlterCredentialStatement).Identity),
                        secret: (Literal)FromMutable((fragment as ScriptDom.AlterCredentialStatement).Secret),
                        isDatabaseScoped: (fragment as ScriptDom.AlterCredentialStatement).IsDatabaseScoped
                    );
                }
                case 24: {
                    return new AlterCryptographicProviderStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterCryptographicProviderStatement).Name),
                        option: (fragment as ScriptDom.AlterCryptographicProviderStatement).Option,
                        file: (Literal)FromMutable((fragment as ScriptDom.AlterCryptographicProviderStatement).File)
                    );
                }
                case 25: {
                    return new AlterDatabaseAddFileGroupStatement(
                        fileGroup: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseAddFileGroupStatement).FileGroup),
                        containsFileStream: (fragment as ScriptDom.AlterDatabaseAddFileGroupStatement).ContainsFileStream,
                        containsMemoryOptimizedData: (fragment as ScriptDom.AlterDatabaseAddFileGroupStatement).ContainsMemoryOptimizedData,
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseAddFileGroupStatement).DatabaseName),
                        useCurrent: (fragment as ScriptDom.AlterDatabaseAddFileGroupStatement).UseCurrent
                    );
                }
                case 26: {
                    return new AlterDatabaseAddFileStatement(
                        fileDeclarations: (fragment as ScriptDom.AlterDatabaseAddFileStatement).FileDeclarations.SelectList(c => (FileDeclaration)FromMutable(c)),
                        fileGroup: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseAddFileStatement).FileGroup),
                        isLog: (fragment as ScriptDom.AlterDatabaseAddFileStatement).IsLog,
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseAddFileStatement).DatabaseName),
                        useCurrent: (fragment as ScriptDom.AlterDatabaseAddFileStatement).UseCurrent
                    );
                }
                case 27: {
                    return new AlterDatabaseAuditSpecificationStatement(
                        auditState: (fragment as ScriptDom.AlterDatabaseAuditSpecificationStatement).AuditState,
                        parts: (fragment as ScriptDom.AlterDatabaseAuditSpecificationStatement).Parts.SelectList(c => (AuditSpecificationPart)FromMutable(c)),
                        specificationName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseAuditSpecificationStatement).SpecificationName),
                        auditName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseAuditSpecificationStatement).AuditName)
                    );
                }
                case 28: {
                    return new AlterDatabaseCollateStatement(
                        collation: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseCollateStatement).Collation),
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseCollateStatement).DatabaseName),
                        useCurrent: (fragment as ScriptDom.AlterDatabaseCollateStatement).UseCurrent
                    );
                }
                case 29: {
                    return new AlterDatabaseEncryptionKeyStatement(
                        regenerate: (fragment as ScriptDom.AlterDatabaseEncryptionKeyStatement).Regenerate,
                        encryptor: (CryptoMechanism)FromMutable((fragment as ScriptDom.AlterDatabaseEncryptionKeyStatement).Encryptor),
                        algorithm: (fragment as ScriptDom.AlterDatabaseEncryptionKeyStatement).Algorithm
                    );
                }
                case 30: {
                    return new AlterDatabaseModifyFileGroupStatement(
                        fileGroup: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseModifyFileGroupStatement).FileGroup),
                        newFileGroupName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseModifyFileGroupStatement).NewFileGroupName),
                        makeDefault: (fragment as ScriptDom.AlterDatabaseModifyFileGroupStatement).MakeDefault,
                        updatabilityOption: (fragment as ScriptDom.AlterDatabaseModifyFileGroupStatement).UpdatabilityOption,
                        termination: (AlterDatabaseTermination)FromMutable((fragment as ScriptDom.AlterDatabaseModifyFileGroupStatement).Termination),
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseModifyFileGroupStatement).DatabaseName),
                        useCurrent: (fragment as ScriptDom.AlterDatabaseModifyFileGroupStatement).UseCurrent
                    );
                }
                case 31: {
                    return new AlterDatabaseModifyFileStatement(
                        fileDeclaration: (FileDeclaration)FromMutable((fragment as ScriptDom.AlterDatabaseModifyFileStatement).FileDeclaration),
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseModifyFileStatement).DatabaseName),
                        useCurrent: (fragment as ScriptDom.AlterDatabaseModifyFileStatement).UseCurrent
                    );
                }
                case 32: {
                    return new AlterDatabaseModifyNameStatement(
                        newDatabaseName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseModifyNameStatement).NewDatabaseName),
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseModifyNameStatement).DatabaseName),
                        useCurrent: (fragment as ScriptDom.AlterDatabaseModifyNameStatement).UseCurrent
                    );
                }
                case 33: {
                    return new AlterDatabaseRebuildLogStatement(
                        fileDeclaration: (FileDeclaration)FromMutable((fragment as ScriptDom.AlterDatabaseRebuildLogStatement).FileDeclaration),
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseRebuildLogStatement).DatabaseName),
                        useCurrent: (fragment as ScriptDom.AlterDatabaseRebuildLogStatement).UseCurrent
                    );
                }
                case 34: {
                    return new AlterDatabaseRemoveFileGroupStatement(
                        fileGroup: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseRemoveFileGroupStatement).FileGroup),
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseRemoveFileGroupStatement).DatabaseName),
                        useCurrent: (fragment as ScriptDom.AlterDatabaseRemoveFileGroupStatement).UseCurrent
                    );
                }
                case 35: {
                    return new AlterDatabaseRemoveFileStatement(
                        file: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseRemoveFileStatement).File),
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseRemoveFileStatement).DatabaseName),
                        useCurrent: (fragment as ScriptDom.AlterDatabaseRemoveFileStatement).UseCurrent
                    );
                }
                case 36: {
                    return new AlterDatabaseScopedConfigurationClearStatement(
                        option: (DatabaseConfigurationClearOption)FromMutable((fragment as ScriptDom.AlterDatabaseScopedConfigurationClearStatement).Option),
                        secondary: (fragment as ScriptDom.AlterDatabaseScopedConfigurationClearStatement).Secondary
                    );
                }
                case 37: {
                    return new AlterDatabaseScopedConfigurationSetStatement(
                        option: (DatabaseConfigurationSetOption)FromMutable((fragment as ScriptDom.AlterDatabaseScopedConfigurationSetStatement).Option),
                        secondary: (fragment as ScriptDom.AlterDatabaseScopedConfigurationSetStatement).Secondary
                    );
                }
                case 38: {
                    return new AlterDatabaseSetStatement(
                        termination: (AlterDatabaseTermination)FromMutable((fragment as ScriptDom.AlterDatabaseSetStatement).Termination),
                        options: (fragment as ScriptDom.AlterDatabaseSetStatement).Options.SelectList(c => (DatabaseOption)FromMutable(c)),
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.AlterDatabaseSetStatement).DatabaseName),
                        useCurrent: (fragment as ScriptDom.AlterDatabaseSetStatement).UseCurrent
                    );
                }
                case 39: {
                    return new AlterDatabaseTermination(
                        immediateRollback: (fragment as ScriptDom.AlterDatabaseTermination).ImmediateRollback,
                        rollbackAfter: (Literal)FromMutable((fragment as ScriptDom.AlterDatabaseTermination).RollbackAfter),
                        noWait: (fragment as ScriptDom.AlterDatabaseTermination).NoWait
                    );
                }
                case 40: {
                    return new AlterEndpointStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterEndpointStatement).Name),
                        state: (fragment as ScriptDom.AlterEndpointStatement).State,
                        affinity: (EndpointAffinity)FromMutable((fragment as ScriptDom.AlterEndpointStatement).Affinity),
                        protocol: (fragment as ScriptDom.AlterEndpointStatement).Protocol,
                        protocolOptions: (fragment as ScriptDom.AlterEndpointStatement).ProtocolOptions.SelectList(c => (EndpointProtocolOption)FromMutable(c)),
                        endpointType: (fragment as ScriptDom.AlterEndpointStatement).EndpointType,
                        payloadOptions: (fragment as ScriptDom.AlterEndpointStatement).PayloadOptions.SelectList(c => (PayloadOption)FromMutable(c))
                    );
                }
                case 41: {
                    return new AlterEventSessionStatement(
                        statementType: (fragment as ScriptDom.AlterEventSessionStatement).StatementType,
                        dropEventDeclarations: (fragment as ScriptDom.AlterEventSessionStatement).DropEventDeclarations.SelectList(c => (EventSessionObjectName)FromMutable(c)),
                        dropTargetDeclarations: (fragment as ScriptDom.AlterEventSessionStatement).DropTargetDeclarations.SelectList(c => (EventSessionObjectName)FromMutable(c)),
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterEventSessionStatement).Name),
                        sessionScope: (fragment as ScriptDom.AlterEventSessionStatement).SessionScope,
                        eventDeclarations: (fragment as ScriptDom.AlterEventSessionStatement).EventDeclarations.SelectList(c => (EventDeclaration)FromMutable(c)),
                        targetDeclarations: (fragment as ScriptDom.AlterEventSessionStatement).TargetDeclarations.SelectList(c => (TargetDeclaration)FromMutable(c)),
                        sessionOptions: (fragment as ScriptDom.AlterEventSessionStatement).SessionOptions.SelectList(c => (SessionOption)FromMutable(c))
                    );
                }
                case 42: {
                    return new AlterExternalDataSourceStatement(
                        previousPushDownOption: (fragment as ScriptDom.AlterExternalDataSourceStatement).PreviousPushDownOption,
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterExternalDataSourceStatement).Name),
                        dataSourceType: (fragment as ScriptDom.AlterExternalDataSourceStatement).DataSourceType,
                        location: (Literal)FromMutable((fragment as ScriptDom.AlterExternalDataSourceStatement).Location),
                        pushdownOption: (fragment as ScriptDom.AlterExternalDataSourceStatement).PushdownOption,
                        externalDataSourceOptions: (fragment as ScriptDom.AlterExternalDataSourceStatement).ExternalDataSourceOptions.SelectList(c => (ExternalDataSourceOption)FromMutable(c))
                    );
                }
                case 43: {
                    return new AlterExternalLanguageStatement(
                        platform: (Identifier)FromMutable((fragment as ScriptDom.AlterExternalLanguageStatement).Platform),
                        operation: (Identifier)FromMutable((fragment as ScriptDom.AlterExternalLanguageStatement).Operation),
                        owner: (Identifier)FromMutable((fragment as ScriptDom.AlterExternalLanguageStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterExternalLanguageStatement).Name),
                        externalLanguageFiles: (fragment as ScriptDom.AlterExternalLanguageStatement).ExternalLanguageFiles.SelectList(c => (ExternalLanguageFileOption)FromMutable(c))
                    );
                }
                case 44: {
                    return new AlterExternalLibraryStatement(
                        owner: (Identifier)FromMutable((fragment as ScriptDom.AlterExternalLibraryStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterExternalLibraryStatement).Name),
                        language: (StringLiteral)FromMutable((fragment as ScriptDom.AlterExternalLibraryStatement).Language),
                        externalLibraryFiles: (fragment as ScriptDom.AlterExternalLibraryStatement).ExternalLibraryFiles.SelectList(c => (ExternalLibraryFileOption)FromMutable(c))
                    );
                }
                case 45: {
                    return new AlterExternalResourcePoolStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterExternalResourcePoolStatement).Name),
                        externalResourcePoolParameters: (fragment as ScriptDom.AlterExternalResourcePoolStatement).ExternalResourcePoolParameters.SelectList(c => (ExternalResourcePoolParameter)FromMutable(c))
                    );
                }
                case 46: {
                    return new AlterFederationStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterFederationStatement).Name),
                        kind: (fragment as ScriptDom.AlterFederationStatement).Kind,
                        distributionName: (Identifier)FromMutable((fragment as ScriptDom.AlterFederationStatement).DistributionName),
                        boundary: (ScalarExpression)FromMutable((fragment as ScriptDom.AlterFederationStatement).Boundary)
                    );
                }
                case 47: {
                    return new AlterFullTextCatalogStatement(
                        action: (fragment as ScriptDom.AlterFullTextCatalogStatement).Action,
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterFullTextCatalogStatement).Name),
                        options: (fragment as ScriptDom.AlterFullTextCatalogStatement).Options.SelectList(c => (FullTextCatalogOption)FromMutable(c))
                    );
                }
                case 48: {
                    return new AlterFullTextIndexStatement(
                        onName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterFullTextIndexStatement).OnName),
                        action: (AlterFullTextIndexAction)FromMutable((fragment as ScriptDom.AlterFullTextIndexStatement).Action)
                    );
                }
                case 49: {
                    return new AlterFullTextStopListStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterFullTextStopListStatement).Name),
                        action: (FullTextStopListAction)FromMutable((fragment as ScriptDom.AlterFullTextStopListStatement).Action)
                    );
                }
                case 50: {
                    return new AlterFunctionStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterFunctionStatement).Name),
                        returnType: (FunctionReturnType)FromMutable((fragment as ScriptDom.AlterFunctionStatement).ReturnType),
                        options: (fragment as ScriptDom.AlterFunctionStatement).Options.SelectList(c => (FunctionOption)FromMutable(c)),
                        orderHint: (OrderBulkInsertOption)FromMutable((fragment as ScriptDom.AlterFunctionStatement).OrderHint),
                        parameters: (fragment as ScriptDom.AlterFunctionStatement).Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        statementList: (StatementList)FromMutable((fragment as ScriptDom.AlterFunctionStatement).StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable((fragment as ScriptDom.AlterFunctionStatement).MethodSpecifier)
                    );
                }
                case 51: {
                    return new AlterIndexStatement(
                        all: (fragment as ScriptDom.AlterIndexStatement).All,
                        alterIndexType: (fragment as ScriptDom.AlterIndexStatement).AlterIndexType,
                        partition: (PartitionSpecifier)FromMutable((fragment as ScriptDom.AlterIndexStatement).Partition),
                        promotedPaths: (fragment as ScriptDom.AlterIndexStatement).PromotedPaths.SelectList(c => (SelectiveXmlIndexPromotedPath)FromMutable(c)),
                        xmlNamespaces: (XmlNamespaces)FromMutable((fragment as ScriptDom.AlterIndexStatement).XmlNamespaces),
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterIndexStatement).Name),
                        onName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterIndexStatement).OnName),
                        indexOptions: (fragment as ScriptDom.AlterIndexStatement).IndexOptions.SelectList(c => (IndexOption)FromMutable(c))
                    );
                }
                case 52: {
                    return new AlterLoginAddDropCredentialStatement(
                        isAdd: (fragment as ScriptDom.AlterLoginAddDropCredentialStatement).IsAdd,
                        credentialName: (Identifier)FromMutable((fragment as ScriptDom.AlterLoginAddDropCredentialStatement).CredentialName),
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterLoginAddDropCredentialStatement).Name)
                    );
                }
                case 53: {
                    return new AlterLoginEnableDisableStatement(
                        isEnable: (fragment as ScriptDom.AlterLoginEnableDisableStatement).IsEnable,
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterLoginEnableDisableStatement).Name)
                    );
                }
                case 54: {
                    return new AlterLoginOptionsStatement(
                        options: (fragment as ScriptDom.AlterLoginOptionsStatement).Options.SelectList(c => (PrincipalOption)FromMutable(c)),
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterLoginOptionsStatement).Name)
                    );
                }
                case 55: {
                    return new AlterMasterKeyStatement(
                        option: (fragment as ScriptDom.AlterMasterKeyStatement).Option,
                        password: (Literal)FromMutable((fragment as ScriptDom.AlterMasterKeyStatement).Password)
                    );
                }
                case 56: {
                    return new AlterMessageTypeStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterMessageTypeStatement).Name),
                        validationMethod: (fragment as ScriptDom.AlterMessageTypeStatement).ValidationMethod,
                        xmlSchemaCollectionName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterMessageTypeStatement).XmlSchemaCollectionName)
                    );
                }
                case 57: {
                    return new AlterPartitionFunctionStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterPartitionFunctionStatement).Name),
                        isSplit: (fragment as ScriptDom.AlterPartitionFunctionStatement).IsSplit,
                        boundary: (ScalarExpression)FromMutable((fragment as ScriptDom.AlterPartitionFunctionStatement).Boundary)
                    );
                }
                case 58: {
                    return new AlterPartitionSchemeStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterPartitionSchemeStatement).Name),
                        fileGroup: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.AlterPartitionSchemeStatement).FileGroup)
                    );
                }
                case 59: {
                    return new AlterProcedureStatement(
                        procedureReference: (ProcedureReference)FromMutable((fragment as ScriptDom.AlterProcedureStatement).ProcedureReference),
                        isForReplication: (fragment as ScriptDom.AlterProcedureStatement).IsForReplication,
                        options: (fragment as ScriptDom.AlterProcedureStatement).Options.SelectList(c => (ProcedureOption)FromMutable(c)),
                        parameters: (fragment as ScriptDom.AlterProcedureStatement).Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        statementList: (StatementList)FromMutable((fragment as ScriptDom.AlterProcedureStatement).StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable((fragment as ScriptDom.AlterProcedureStatement).MethodSpecifier)
                    );
                }
                case 60: {
                    return new AlterQueueStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterQueueStatement).Name),
                        queueOptions: (fragment as ScriptDom.AlterQueueStatement).QueueOptions.SelectList(c => (QueueOption)FromMutable(c))
                    );
                }
                case 61: {
                    return new AlterRemoteServiceBindingStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterRemoteServiceBindingStatement).Name),
                        options: (fragment as ScriptDom.AlterRemoteServiceBindingStatement).Options.SelectList(c => (RemoteServiceBindingOption)FromMutable(c))
                    );
                }
                case 62: {
                    return new AlterResourceGovernorStatement(
                        command: (fragment as ScriptDom.AlterResourceGovernorStatement).Command,
                        classifierFunction: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterResourceGovernorStatement).ClassifierFunction)
                    );
                }
                case 63: {
                    return new AlterResourcePoolStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterResourcePoolStatement).Name),
                        resourcePoolParameters: (fragment as ScriptDom.AlterResourcePoolStatement).ResourcePoolParameters.SelectList(c => (ResourcePoolParameter)FromMutable(c))
                    );
                }
                case 64: {
                    return new AlterRoleStatement(
                        action: (AlterRoleAction)FromMutable((fragment as ScriptDom.AlterRoleStatement).Action),
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterRoleStatement).Name)
                    );
                }
                case 65: {
                    return new AlterRouteStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterRouteStatement).Name),
                        routeOptions: (fragment as ScriptDom.AlterRouteStatement).RouteOptions.SelectList(c => (RouteOption)FromMutable(c))
                    );
                }
                case 66: {
                    return new AlterSchemaStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterSchemaStatement).Name),
                        objectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterSchemaStatement).ObjectName),
                        objectKind: (fragment as ScriptDom.AlterSchemaStatement).ObjectKind
                    );
                }
                case 67: {
                    return new AlterSearchPropertyListStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterSearchPropertyListStatement).Name),
                        action: (SearchPropertyListAction)FromMutable((fragment as ScriptDom.AlterSearchPropertyListStatement).Action)
                    );
                }
                case 68: {
                    return new AlterSecurityPolicyStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterSecurityPolicyStatement).Name),
                        notForReplication: (fragment as ScriptDom.AlterSecurityPolicyStatement).NotForReplication,
                        securityPolicyOptions: (fragment as ScriptDom.AlterSecurityPolicyStatement).SecurityPolicyOptions.SelectList(c => (SecurityPolicyOption)FromMutable(c)),
                        securityPredicateActions: (fragment as ScriptDom.AlterSecurityPolicyStatement).SecurityPredicateActions.SelectList(c => (SecurityPredicateAction)FromMutable(c)),
                        actionType: (fragment as ScriptDom.AlterSecurityPolicyStatement).ActionType
                    );
                }
                case 69: {
                    return new AlterSequenceStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterSequenceStatement).Name),
                        sequenceOptions: (fragment as ScriptDom.AlterSequenceStatement).SequenceOptions.SelectList(c => (SequenceOption)FromMutable(c))
                    );
                }
                case 70: {
                    return new AlterServerAuditSpecificationStatement(
                        auditState: (fragment as ScriptDom.AlterServerAuditSpecificationStatement).AuditState,
                        parts: (fragment as ScriptDom.AlterServerAuditSpecificationStatement).Parts.SelectList(c => (AuditSpecificationPart)FromMutable(c)),
                        specificationName: (Identifier)FromMutable((fragment as ScriptDom.AlterServerAuditSpecificationStatement).SpecificationName),
                        auditName: (Identifier)FromMutable((fragment as ScriptDom.AlterServerAuditSpecificationStatement).AuditName)
                    );
                }
                case 71: {
                    return new AlterServerAuditStatement(
                        newName: (Identifier)FromMutable((fragment as ScriptDom.AlterServerAuditStatement).NewName),
                        removeWhere: (fragment as ScriptDom.AlterServerAuditStatement).RemoveWhere,
                        auditName: (Identifier)FromMutable((fragment as ScriptDom.AlterServerAuditStatement).AuditName),
                        auditTarget: (AuditTarget)FromMutable((fragment as ScriptDom.AlterServerAuditStatement).AuditTarget),
                        options: (fragment as ScriptDom.AlterServerAuditStatement).Options.SelectList(c => (AuditOption)FromMutable(c)),
                        predicateExpression: (BooleanExpression)FromMutable((fragment as ScriptDom.AlterServerAuditStatement).PredicateExpression)
                    );
                }
                case 72: {
                    return new AlterServerConfigurationBufferPoolExtensionContainerOption(
                        suboptions: (fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption).Suboptions.SelectList(c => (AlterServerConfigurationBufferPoolExtensionOption)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption).OptionKind,
                        optionValue: (OptionValue)FromMutable((fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption).OptionValue)
                    );
                }
                case 73: {
                    return new AlterServerConfigurationBufferPoolExtensionOption(
                        optionKind: (fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionOption).OptionKind,
                        optionValue: (OptionValue)FromMutable((fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionOption).OptionValue)
                    );
                }
                case 74: {
                    return new AlterServerConfigurationBufferPoolExtensionSizeOption(
                        sizeUnit: (fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption).SizeUnit,
                        optionKind: (fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption).OptionKind,
                        optionValue: (OptionValue)FromMutable((fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption).OptionValue)
                    );
                }
                case 75: {
                    return new AlterServerConfigurationDiagnosticsLogMaxSizeOption(
                        sizeUnit: (fragment as ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption).SizeUnit,
                        optionKind: (fragment as ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption).OptionKind,
                        optionValue: (OptionValue)FromMutable((fragment as ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption).OptionValue)
                    );
                }
                case 76: {
                    return new AlterServerConfigurationDiagnosticsLogOption(
                        optionKind: (fragment as ScriptDom.AlterServerConfigurationDiagnosticsLogOption).OptionKind,
                        optionValue: (OptionValue)FromMutable((fragment as ScriptDom.AlterServerConfigurationDiagnosticsLogOption).OptionValue)
                    );
                }
                case 77: {
                    return new AlterServerConfigurationExternalAuthenticationContainerOption(
                        suboptions: (fragment as ScriptDom.AlterServerConfigurationExternalAuthenticationContainerOption).Suboptions.SelectList(c => (AlterServerConfigurationExternalAuthenticationOption)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.AlterServerConfigurationExternalAuthenticationContainerOption).OptionKind,
                        optionValue: (OptionValue)FromMutable((fragment as ScriptDom.AlterServerConfigurationExternalAuthenticationContainerOption).OptionValue)
                    );
                }
                case 78: {
                    return new AlterServerConfigurationExternalAuthenticationOption(
                        optionKind: (fragment as ScriptDom.AlterServerConfigurationExternalAuthenticationOption).OptionKind,
                        optionValue: (OptionValue)FromMutable((fragment as ScriptDom.AlterServerConfigurationExternalAuthenticationOption).OptionValue)
                    );
                }
                case 79: {
                    return new AlterServerConfigurationFailoverClusterPropertyOption(
                        optionKind: (fragment as ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption).OptionKind,
                        optionValue: (OptionValue)FromMutable((fragment as ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption).OptionValue)
                    );
                }
                case 80: {
                    return new AlterServerConfigurationHadrClusterOption(
                        optionKind: (fragment as ScriptDom.AlterServerConfigurationHadrClusterOption).OptionKind,
                        optionValue: (OptionValue)FromMutable((fragment as ScriptDom.AlterServerConfigurationHadrClusterOption).OptionValue),
                        isLocal: (fragment as ScriptDom.AlterServerConfigurationHadrClusterOption).IsLocal
                    );
                }
                case 81: {
                    return new AlterServerConfigurationSetBufferPoolExtensionStatement(
                        options: (fragment as ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement).Options.SelectList(c => (AlterServerConfigurationBufferPoolExtensionOption)FromMutable(c))
                    );
                }
                case 82: {
                    return new AlterServerConfigurationSetDiagnosticsLogStatement(
                        options: (fragment as ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement).Options.SelectList(c => (AlterServerConfigurationDiagnosticsLogOption)FromMutable(c))
                    );
                }
                case 83: {
                    return new AlterServerConfigurationSetExternalAuthenticationStatement(
                        options: (fragment as ScriptDom.AlterServerConfigurationSetExternalAuthenticationStatement).Options.SelectList(c => (AlterServerConfigurationExternalAuthenticationOption)FromMutable(c))
                    );
                }
                case 84: {
                    return new AlterServerConfigurationSetFailoverClusterPropertyStatement(
                        options: (fragment as ScriptDom.AlterServerConfigurationSetFailoverClusterPropertyStatement).Options.SelectList(c => (AlterServerConfigurationFailoverClusterPropertyOption)FromMutable(c))
                    );
                }
                case 85: {
                    return new AlterServerConfigurationSetHadrClusterStatement(
                        options: (fragment as ScriptDom.AlterServerConfigurationSetHadrClusterStatement).Options.SelectList(c => (AlterServerConfigurationHadrClusterOption)FromMutable(c))
                    );
                }
                case 86: {
                    return new AlterServerConfigurationSetSoftNumaStatement(
                        options: (fragment as ScriptDom.AlterServerConfigurationSetSoftNumaStatement).Options.SelectList(c => (AlterServerConfigurationSoftNumaOption)FromMutable(c))
                    );
                }
                case 87: {
                    return new AlterServerConfigurationSoftNumaOption(
                        optionKind: (fragment as ScriptDom.AlterServerConfigurationSoftNumaOption).OptionKind,
                        optionValue: (OptionValue)FromMutable((fragment as ScriptDom.AlterServerConfigurationSoftNumaOption).OptionValue)
                    );
                }
                case 88: {
                    return new AlterServerConfigurationStatement(
                        processAffinity: (fragment as ScriptDom.AlterServerConfigurationStatement).ProcessAffinity,
                        processAffinityRanges: (fragment as ScriptDom.AlterServerConfigurationStatement).ProcessAffinityRanges.SelectList(c => (ProcessAffinityRange)FromMutable(c))
                    );
                }
                case 89: {
                    return new AlterServerRoleStatement(
                        action: (AlterRoleAction)FromMutable((fragment as ScriptDom.AlterServerRoleStatement).Action),
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterServerRoleStatement).Name)
                    );
                }
                case 90: {
                    return new AlterServiceMasterKeyStatement(
                        account: (Literal)FromMutable((fragment as ScriptDom.AlterServiceMasterKeyStatement).Account),
                        password: (Literal)FromMutable((fragment as ScriptDom.AlterServiceMasterKeyStatement).Password),
                        kind: (fragment as ScriptDom.AlterServiceMasterKeyStatement).Kind
                    );
                }
                case 91: {
                    return new AlterServiceStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterServiceStatement).Name),
                        queueName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterServiceStatement).QueueName),
                        serviceContracts: (fragment as ScriptDom.AlterServiceStatement).ServiceContracts.SelectList(c => (ServiceContract)FromMutable(c))
                    );
                }
                case 92: {
                    return new AlterSymmetricKeyStatement(
                        isAdd: (fragment as ScriptDom.AlterSymmetricKeyStatement).IsAdd,
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterSymmetricKeyStatement).Name),
                        encryptingMechanisms: (fragment as ScriptDom.AlterSymmetricKeyStatement).EncryptingMechanisms.SelectList(c => (CryptoMechanism)FromMutable(c))
                    );
                }
                case 93: {
                    return new AlterTableAddTableElementStatement(
                        existingRowsCheckEnforcement: (fragment as ScriptDom.AlterTableAddTableElementStatement).ExistingRowsCheckEnforcement,
                        definition: (TableDefinition)FromMutable((fragment as ScriptDom.AlterTableAddTableElementStatement).Definition),
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTableAddTableElementStatement).SchemaObjectName)
                    );
                }
                case 94: {
                    return new AlterTableAlterColumnStatement(
                        columnIdentifier: (Identifier)FromMutable((fragment as ScriptDom.AlterTableAlterColumnStatement).ColumnIdentifier),
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.AlterTableAlterColumnStatement).DataType),
                        alterTableAlterColumnOption: (fragment as ScriptDom.AlterTableAlterColumnStatement).AlterTableAlterColumnOption,
                        storageOptions: (ColumnStorageOptions)FromMutable((fragment as ScriptDom.AlterTableAlterColumnStatement).StorageOptions),
                        options: (fragment as ScriptDom.AlterTableAlterColumnStatement).Options.SelectList(c => (IndexOption)FromMutable(c)),
                        generatedAlways: (fragment as ScriptDom.AlterTableAlterColumnStatement).GeneratedAlways,
                        isHidden: (fragment as ScriptDom.AlterTableAlterColumnStatement).IsHidden,
                        encryption: (ColumnEncryptionDefinition)FromMutable((fragment as ScriptDom.AlterTableAlterColumnStatement).Encryption),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.AlterTableAlterColumnStatement).Collation),
                        isMasked: (fragment as ScriptDom.AlterTableAlterColumnStatement).IsMasked,
                        maskingFunction: (StringLiteral)FromMutable((fragment as ScriptDom.AlterTableAlterColumnStatement).MaskingFunction),
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTableAlterColumnStatement).SchemaObjectName)
                    );
                }
                case 95: {
                    return new AlterTableAlterIndexStatement(
                        indexIdentifier: (Identifier)FromMutable((fragment as ScriptDom.AlterTableAlterIndexStatement).IndexIdentifier),
                        alterIndexType: (fragment as ScriptDom.AlterTableAlterIndexStatement).AlterIndexType,
                        indexOptions: (fragment as ScriptDom.AlterTableAlterIndexStatement).IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTableAlterIndexStatement).SchemaObjectName)
                    );
                }
                case 96: {
                    return new AlterTableAlterPartitionStatement(
                        boundaryValue: (ScalarExpression)FromMutable((fragment as ScriptDom.AlterTableAlterPartitionStatement).BoundaryValue),
                        isSplit: (fragment as ScriptDom.AlterTableAlterPartitionStatement).IsSplit,
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTableAlterPartitionStatement).SchemaObjectName)
                    );
                }
                case 97: {
                    return new AlterTableChangeTrackingModificationStatement(
                        isEnable: (fragment as ScriptDom.AlterTableChangeTrackingModificationStatement).IsEnable,
                        trackColumnsUpdated: (fragment as ScriptDom.AlterTableChangeTrackingModificationStatement).TrackColumnsUpdated,
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTableChangeTrackingModificationStatement).SchemaObjectName)
                    );
                }
                case 98: {
                    return new AlterTableConstraintModificationStatement(
                        existingRowsCheckEnforcement: (fragment as ScriptDom.AlterTableConstraintModificationStatement).ExistingRowsCheckEnforcement,
                        constraintEnforcement: (fragment as ScriptDom.AlterTableConstraintModificationStatement).ConstraintEnforcement,
                        all: (fragment as ScriptDom.AlterTableConstraintModificationStatement).All,
                        constraintNames: (fragment as ScriptDom.AlterTableConstraintModificationStatement).ConstraintNames.SelectList(c => (Identifier)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTableConstraintModificationStatement).SchemaObjectName)
                    );
                }
                case 99: {
                    return new AlterTableDropTableElement(
                        tableElementType: (fragment as ScriptDom.AlterTableDropTableElement).TableElementType,
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterTableDropTableElement).Name),
                        dropClusteredConstraintOptions: (fragment as ScriptDom.AlterTableDropTableElement).DropClusteredConstraintOptions.SelectList(c => (DropClusteredConstraintOption)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.AlterTableDropTableElement).IsIfExists
                    );
                }
                case 100: {
                    return new AlterTableDropTableElementStatement(
                        alterTableDropTableElements: (fragment as ScriptDom.AlterTableDropTableElementStatement).AlterTableDropTableElements.SelectList(c => (AlterTableDropTableElement)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTableDropTableElementStatement).SchemaObjectName)
                    );
                }
                case 101: {
                    return new AlterTableFileTableNamespaceStatement(
                        isEnable: (fragment as ScriptDom.AlterTableFileTableNamespaceStatement).IsEnable,
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTableFileTableNamespaceStatement).SchemaObjectName)
                    );
                }
                case 102: {
                    return new AlterTableRebuildStatement(
                        partition: (PartitionSpecifier)FromMutable((fragment as ScriptDom.AlterTableRebuildStatement).Partition),
                        indexOptions: (fragment as ScriptDom.AlterTableRebuildStatement).IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTableRebuildStatement).SchemaObjectName)
                    );
                }
                case 103: {
                    return new AlterTableSetStatement(
                        options: (fragment as ScriptDom.AlterTableSetStatement).Options.SelectList(c => (TableOption)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTableSetStatement).SchemaObjectName)
                    );
                }
                case 104: {
                    return new AlterTableSwitchStatement(
                        sourcePartitionNumber: (ScalarExpression)FromMutable((fragment as ScriptDom.AlterTableSwitchStatement).SourcePartitionNumber),
                        targetPartitionNumber: (ScalarExpression)FromMutable((fragment as ScriptDom.AlterTableSwitchStatement).TargetPartitionNumber),
                        targetTable: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTableSwitchStatement).TargetTable),
                        options: (fragment as ScriptDom.AlterTableSwitchStatement).Options.SelectList(c => (TableSwitchOption)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTableSwitchStatement).SchemaObjectName)
                    );
                }
                case 105: {
                    return new AlterTableTriggerModificationStatement(
                        triggerEnforcement: (fragment as ScriptDom.AlterTableTriggerModificationStatement).TriggerEnforcement,
                        all: (fragment as ScriptDom.AlterTableTriggerModificationStatement).All,
                        triggerNames: (fragment as ScriptDom.AlterTableTriggerModificationStatement).TriggerNames.SelectList(c => (Identifier)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTableTriggerModificationStatement).SchemaObjectName)
                    );
                }
                case 106: {
                    return new AlterTriggerStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterTriggerStatement).Name),
                        triggerObject: (TriggerObject)FromMutable((fragment as ScriptDom.AlterTriggerStatement).TriggerObject),
                        options: (fragment as ScriptDom.AlterTriggerStatement).Options.SelectList(c => (TriggerOption)FromMutable(c)),
                        triggerType: (fragment as ScriptDom.AlterTriggerStatement).TriggerType,
                        triggerActions: (fragment as ScriptDom.AlterTriggerStatement).TriggerActions.SelectList(c => (TriggerAction)FromMutable(c)),
                        withAppend: (fragment as ScriptDom.AlterTriggerStatement).WithAppend,
                        isNotForReplication: (fragment as ScriptDom.AlterTriggerStatement).IsNotForReplication,
                        statementList: (StatementList)FromMutable((fragment as ScriptDom.AlterTriggerStatement).StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable((fragment as ScriptDom.AlterTriggerStatement).MethodSpecifier)
                    );
                }
                case 107: {
                    return new AlterUserStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterUserStatement).Name),
                        userOptions: (fragment as ScriptDom.AlterUserStatement).UserOptions.SelectList(c => (PrincipalOption)FromMutable(c))
                    );
                }
                case 108: {
                    return new AlterViewStatement(
                        isRebuild: (fragment as ScriptDom.AlterViewStatement).IsRebuild,
                        isDisable: (fragment as ScriptDom.AlterViewStatement).IsDisable,
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterViewStatement).SchemaObjectName),
                        columns: (fragment as ScriptDom.AlterViewStatement).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        viewOptions: (fragment as ScriptDom.AlterViewStatement).ViewOptions.SelectList(c => (ViewOption)FromMutable(c)),
                        selectStatement: (SelectStatement)FromMutable((fragment as ScriptDom.AlterViewStatement).SelectStatement),
                        withCheckOption: (fragment as ScriptDom.AlterViewStatement).WithCheckOption,
                        isMaterialized: (fragment as ScriptDom.AlterViewStatement).IsMaterialized
                    );
                }
                case 109: {
                    return new AlterWorkloadGroupStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AlterWorkloadGroupStatement).Name),
                        workloadGroupParameters: (fragment as ScriptDom.AlterWorkloadGroupStatement).WorkloadGroupParameters.SelectList(c => (WorkloadGroupParameter)FromMutable(c)),
                        poolName: (Identifier)FromMutable((fragment as ScriptDom.AlterWorkloadGroupStatement).PoolName),
                        externalPoolName: (Identifier)FromMutable((fragment as ScriptDom.AlterWorkloadGroupStatement).ExternalPoolName)
                    );
                }
                case 110: {
                    return new AlterXmlSchemaCollectionStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.AlterXmlSchemaCollectionStatement).Name),
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.AlterXmlSchemaCollectionStatement).Expression)
                    );
                }
                case 111: {
                    return new ApplicationRoleOption(
                        optionKind: (fragment as ScriptDom.ApplicationRoleOption).OptionKind,
                        @value: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.ApplicationRoleOption).Value)
                    );
                }
                case 112: {
                    return new AssemblyEncryptionSource(
                        assembly: (Identifier)FromMutable((fragment as ScriptDom.AssemblyEncryptionSource).Assembly)
                    );
                }
                case 113: {
                    return new AssemblyName(
                        name: (Identifier)FromMutable((fragment as ScriptDom.AssemblyName).Name),
                        className: (Identifier)FromMutable((fragment as ScriptDom.AssemblyName).ClassName)
                    );
                }
                case 114: {
                    return new AssemblyOption(
                        optionKind: (fragment as ScriptDom.AssemblyOption).OptionKind
                    );
                }
                case 115: {
                    return new AssignmentSetClause(
                        variable: (VariableReference)FromMutable((fragment as ScriptDom.AssignmentSetClause).Variable),
                        column: (ColumnReferenceExpression)FromMutable((fragment as ScriptDom.AssignmentSetClause).Column),
                        newValue: (ScalarExpression)FromMutable((fragment as ScriptDom.AssignmentSetClause).NewValue),
                        assignmentKind: (fragment as ScriptDom.AssignmentSetClause).AssignmentKind
                    );
                }
                case 116: {
                    return new AsymmetricKeyCreateLoginSource(
                        key: (Identifier)FromMutable((fragment as ScriptDom.AsymmetricKeyCreateLoginSource).Key),
                        credential: (Identifier)FromMutable((fragment as ScriptDom.AsymmetricKeyCreateLoginSource).Credential)
                    );
                }
                case 117: {
                    return new AtTimeZoneCall(
                        dateValue: (ScalarExpression)FromMutable((fragment as ScriptDom.AtTimeZoneCall).DateValue),
                        timeZone: (ScalarExpression)FromMutable((fragment as ScriptDom.AtTimeZoneCall).TimeZone),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.AtTimeZoneCall).Collation)
                    );
                }
                case 118: {
                    return new AuditActionGroupReference(
                        group: (fragment as ScriptDom.AuditActionGroupReference).Group
                    );
                }
                case 119: {
                    return new AuditActionSpecification(
                        actions: (fragment as ScriptDom.AuditActionSpecification).Actions.SelectList(c => (DatabaseAuditAction)FromMutable(c)),
                        principals: (fragment as ScriptDom.AuditActionSpecification).Principals.SelectList(c => (SecurityPrincipal)FromMutable(c)),
                        targetObject: (SecurityTargetObject)FromMutable((fragment as ScriptDom.AuditActionSpecification).TargetObject)
                    );
                }
                case 120: {
                    return new AuditGuidAuditOption(
                        guid: (Literal)FromMutable((fragment as ScriptDom.AuditGuidAuditOption).Guid),
                        optionKind: (fragment as ScriptDom.AuditGuidAuditOption).OptionKind
                    );
                }
                case 121: {
                    return new AuditSpecificationPart(
                        isDrop: (fragment as ScriptDom.AuditSpecificationPart).IsDrop,
                        details: (AuditSpecificationDetail)FromMutable((fragment as ScriptDom.AuditSpecificationPart).Details)
                    );
                }
                case 122: {
                    return new AuditTarget(
                        targetKind: (fragment as ScriptDom.AuditTarget).TargetKind,
                        targetOptions: (fragment as ScriptDom.AuditTarget).TargetOptions.SelectList(c => (AuditTargetOption)FromMutable(c))
                    );
                }
                case 123: {
                    return new AuthenticationEndpointProtocolOption(
                        authenticationTypes: (fragment as ScriptDom.AuthenticationEndpointProtocolOption).AuthenticationTypes,
                        kind: (fragment as ScriptDom.AuthenticationEndpointProtocolOption).Kind
                    );
                }
                case 124: {
                    return new AuthenticationPayloadOption(
                        protocol: (fragment as ScriptDom.AuthenticationPayloadOption).Protocol,
                        certificate: (Identifier)FromMutable((fragment as ScriptDom.AuthenticationPayloadOption).Certificate),
                        tryCertificateFirst: (fragment as ScriptDom.AuthenticationPayloadOption).TryCertificateFirst,
                        kind: (fragment as ScriptDom.AuthenticationPayloadOption).Kind
                    );
                }
                case 125: {
                    return new AutoCleanupChangeTrackingOptionDetail(
                        isOn: (fragment as ScriptDom.AutoCleanupChangeTrackingOptionDetail).IsOn
                    );
                }
                case 126: {
                    return new AutoCreateStatisticsDatabaseOption(
                        hasIncremental: (fragment as ScriptDom.AutoCreateStatisticsDatabaseOption).HasIncremental,
                        incrementalState: (fragment as ScriptDom.AutoCreateStatisticsDatabaseOption).IncrementalState,
                        optionState: (fragment as ScriptDom.AutoCreateStatisticsDatabaseOption).OptionState,
                        optionKind: (fragment as ScriptDom.AutoCreateStatisticsDatabaseOption).OptionKind
                    );
                }
                case 127: {
                    return new AutomaticTuningCreateIndexOption(
                        optionKind: (fragment as ScriptDom.AutomaticTuningCreateIndexOption).OptionKind,
                        @value: (fragment as ScriptDom.AutomaticTuningCreateIndexOption).Value
                    );
                }
                case 128: {
                    return new AutomaticTuningDatabaseOption(
                        automaticTuningState: (fragment as ScriptDom.AutomaticTuningDatabaseOption).AutomaticTuningState,
                        options: (fragment as ScriptDom.AutomaticTuningDatabaseOption).Options.SelectList(c => (AutomaticTuningOption)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.AutomaticTuningDatabaseOption).OptionKind
                    );
                }
                case 129: {
                    return new AutomaticTuningDropIndexOption(
                        optionKind: (fragment as ScriptDom.AutomaticTuningDropIndexOption).OptionKind,
                        @value: (fragment as ScriptDom.AutomaticTuningDropIndexOption).Value
                    );
                }
                case 130: {
                    return new AutomaticTuningForceLastGoodPlanOption(
                        optionKind: (fragment as ScriptDom.AutomaticTuningForceLastGoodPlanOption).OptionKind,
                        @value: (fragment as ScriptDom.AutomaticTuningForceLastGoodPlanOption).Value
                    );
                }
                case 131: {
                    return new AutomaticTuningMaintainIndexOption(
                        optionKind: (fragment as ScriptDom.AutomaticTuningMaintainIndexOption).OptionKind,
                        @value: (fragment as ScriptDom.AutomaticTuningMaintainIndexOption).Value
                    );
                }
                case 132: {
                    return new AutomaticTuningOption(
                        optionKind: (fragment as ScriptDom.AutomaticTuningOption).OptionKind,
                        @value: (fragment as ScriptDom.AutomaticTuningOption).Value
                    );
                }
                case 133: {
                    return new AvailabilityModeReplicaOption(
                        @value: (fragment as ScriptDom.AvailabilityModeReplicaOption).Value,
                        optionKind: (fragment as ScriptDom.AvailabilityModeReplicaOption).OptionKind
                    );
                }
                case 134: {
                    return new AvailabilityReplica(
                        serverName: (StringLiteral)FromMutable((fragment as ScriptDom.AvailabilityReplica).ServerName),
                        options: (fragment as ScriptDom.AvailabilityReplica).Options.SelectList(c => (AvailabilityReplicaOption)FromMutable(c))
                    );
                }
                case 135: {
                    return new BackupCertificateStatement(
                        file: (Literal)FromMutable((fragment as ScriptDom.BackupCertificateStatement).File),
                        name: (Identifier)FromMutable((fragment as ScriptDom.BackupCertificateStatement).Name),
                        activeForBeginDialog: (fragment as ScriptDom.BackupCertificateStatement).ActiveForBeginDialog,
                        privateKeyPath: (Literal)FromMutable((fragment as ScriptDom.BackupCertificateStatement).PrivateKeyPath),
                        encryptionPassword: (Literal)FromMutable((fragment as ScriptDom.BackupCertificateStatement).EncryptionPassword),
                        decryptionPassword: (Literal)FromMutable((fragment as ScriptDom.BackupCertificateStatement).DecryptionPassword)
                    );
                }
                case 136: {
                    return new BackupDatabaseStatement(
                        files: (fragment as ScriptDom.BackupDatabaseStatement).Files.SelectList(c => (BackupRestoreFileInfo)FromMutable(c)),
                        databaseName: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.BackupDatabaseStatement).DatabaseName),
                        options: (fragment as ScriptDom.BackupDatabaseStatement).Options.SelectList(c => (BackupOption)FromMutable(c)),
                        mirrorToClauses: (fragment as ScriptDom.BackupDatabaseStatement).MirrorToClauses.SelectList(c => (MirrorToClause)FromMutable(c)),
                        devices: (fragment as ScriptDom.BackupDatabaseStatement).Devices.SelectList(c => (DeviceInfo)FromMutable(c))
                    );
                }
                case 137: {
                    return new BackupEncryptionOption(
                        algorithm: (fragment as ScriptDom.BackupEncryptionOption).Algorithm,
                        encryptor: (CryptoMechanism)FromMutable((fragment as ScriptDom.BackupEncryptionOption).Encryptor),
                        optionKind: (fragment as ScriptDom.BackupEncryptionOption).OptionKind,
                        @value: (ScalarExpression)FromMutable((fragment as ScriptDom.BackupEncryptionOption).Value)
                    );
                }
                case 138: {
                    return new BackupMasterKeyStatement(
                        file: (Literal)FromMutable((fragment as ScriptDom.BackupMasterKeyStatement).File),
                        password: (Literal)FromMutable((fragment as ScriptDom.BackupMasterKeyStatement).Password)
                    );
                }
                case 139: {
                    return new BackupOption(
                        optionKind: (fragment as ScriptDom.BackupOption).OptionKind,
                        @value: (ScalarExpression)FromMutable((fragment as ScriptDom.BackupOption).Value)
                    );
                }
                case 140: {
                    return new BackupRestoreFileInfo(
                        items: (fragment as ScriptDom.BackupRestoreFileInfo).Items.SelectList(c => (ValueExpression)FromMutable(c)),
                        itemKind: (fragment as ScriptDom.BackupRestoreFileInfo).ItemKind
                    );
                }
                case 141: {
                    return new BackupServiceMasterKeyStatement(
                        file: (Literal)FromMutable((fragment as ScriptDom.BackupServiceMasterKeyStatement).File),
                        password: (Literal)FromMutable((fragment as ScriptDom.BackupServiceMasterKeyStatement).Password)
                    );
                }
                case 142: {
                    return new BackupTransactionLogStatement(
                        databaseName: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.BackupTransactionLogStatement).DatabaseName),
                        options: (fragment as ScriptDom.BackupTransactionLogStatement).Options.SelectList(c => (BackupOption)FromMutable(c)),
                        mirrorToClauses: (fragment as ScriptDom.BackupTransactionLogStatement).MirrorToClauses.SelectList(c => (MirrorToClause)FromMutable(c)),
                        devices: (fragment as ScriptDom.BackupTransactionLogStatement).Devices.SelectList(c => (DeviceInfo)FromMutable(c))
                    );
                }
                case 143: {
                    return new BackwardsCompatibleDropIndexClause(
                        index: (ChildObjectName)FromMutable((fragment as ScriptDom.BackwardsCompatibleDropIndexClause).Index)
                    );
                }
                case 144: {
                    return new BeginConversationTimerStatement(
                        handle: (ScalarExpression)FromMutable((fragment as ScriptDom.BeginConversationTimerStatement).Handle),
                        timeout: (ScalarExpression)FromMutable((fragment as ScriptDom.BeginConversationTimerStatement).Timeout)
                    );
                }
                case 145: {
                    return new BeginDialogStatement(
                        isConversation: (fragment as ScriptDom.BeginDialogStatement).IsConversation,
                        handle: (VariableReference)FromMutable((fragment as ScriptDom.BeginDialogStatement).Handle),
                        initiatorServiceName: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.BeginDialogStatement).InitiatorServiceName),
                        targetServiceName: (ValueExpression)FromMutable((fragment as ScriptDom.BeginDialogStatement).TargetServiceName),
                        instanceSpec: (ValueExpression)FromMutable((fragment as ScriptDom.BeginDialogStatement).InstanceSpec),
                        contractName: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.BeginDialogStatement).ContractName),
                        options: (fragment as ScriptDom.BeginDialogStatement).Options.SelectList(c => (DialogOption)FromMutable(c))
                    );
                }
                case 146: {
                    return new BeginEndAtomicBlockStatement(
                        options: (fragment as ScriptDom.BeginEndAtomicBlockStatement).Options.SelectList(c => (AtomicBlockOption)FromMutable(c)),
                        statementList: (StatementList)FromMutable((fragment as ScriptDom.BeginEndAtomicBlockStatement).StatementList)
                    );
                }
                case 147: {
                    return new BeginEndBlockStatement(
                        statementList: (StatementList)FromMutable((fragment as ScriptDom.BeginEndBlockStatement).StatementList)
                    );
                }
                case 148: {
                    return new BeginTransactionStatement(
                        distributed: (fragment as ScriptDom.BeginTransactionStatement).Distributed,
                        markDefined: (fragment as ScriptDom.BeginTransactionStatement).MarkDefined,
                        markDescription: (ValueExpression)FromMutable((fragment as ScriptDom.BeginTransactionStatement).MarkDescription),
                        name: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.BeginTransactionStatement).Name)
                    );
                }
                case 149: {
                    return new BinaryExpression(
                        binaryExpressionType: (fragment as ScriptDom.BinaryExpression).BinaryExpressionType,
                        firstExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.BinaryExpression).FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.BinaryExpression).SecondExpression)
                    );
                }
                case 150: {
                    return new BinaryLiteral(
                        isLargeObject: (fragment as ScriptDom.BinaryLiteral).IsLargeObject,
                        @value: (fragment as ScriptDom.BinaryLiteral).Value,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.BinaryLiteral).Collation)
                    );
                }
                case 151: {
                    return new BinaryQueryExpression(
                        binaryQueryExpressionType: (fragment as ScriptDom.BinaryQueryExpression).BinaryQueryExpressionType,
                        all: (fragment as ScriptDom.BinaryQueryExpression).All,
                        firstQueryExpression: (QueryExpression)FromMutable((fragment as ScriptDom.BinaryQueryExpression).FirstQueryExpression),
                        secondQueryExpression: (QueryExpression)FromMutable((fragment as ScriptDom.BinaryQueryExpression).SecondQueryExpression),
                        orderByClause: (OrderByClause)FromMutable((fragment as ScriptDom.BinaryQueryExpression).OrderByClause),
                        offsetClause: (OffsetClause)FromMutable((fragment as ScriptDom.BinaryQueryExpression).OffsetClause),
                        forClause: (ForClause)FromMutable((fragment as ScriptDom.BinaryQueryExpression).ForClause)
                    );
                }
                case 152: {
                    return new BooleanBinaryExpression(
                        binaryExpressionType: (fragment as ScriptDom.BooleanBinaryExpression).BinaryExpressionType,
                        firstExpression: (BooleanExpression)FromMutable((fragment as ScriptDom.BooleanBinaryExpression).FirstExpression),
                        secondExpression: (BooleanExpression)FromMutable((fragment as ScriptDom.BooleanBinaryExpression).SecondExpression)
                    );
                }
                case 153: {
                    return new BooleanComparisonExpression(
                        comparisonType: (fragment as ScriptDom.BooleanComparisonExpression).ComparisonType,
                        firstExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.BooleanComparisonExpression).FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.BooleanComparisonExpression).SecondExpression)
                    );
                }
                case 154: {
                    return new BooleanExpressionSnippet(
                        script: (fragment as ScriptDom.BooleanExpressionSnippet).Script
                    );
                }
                case 155: {
                    return new BooleanIsNullExpression(
                        isNot: (fragment as ScriptDom.BooleanIsNullExpression).IsNot,
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.BooleanIsNullExpression).Expression)
                    );
                }
                case 156: {
                    return new BooleanNotExpression(
                        expression: (BooleanExpression)FromMutable((fragment as ScriptDom.BooleanNotExpression).Expression)
                    );
                }
                case 157: {
                    return new BooleanParenthesisExpression(
                        expression: (BooleanExpression)FromMutable((fragment as ScriptDom.BooleanParenthesisExpression).Expression)
                    );
                }
                case 158: {
                    return new BooleanTernaryExpression(
                        ternaryExpressionType: (fragment as ScriptDom.BooleanTernaryExpression).TernaryExpressionType,
                        firstExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.BooleanTernaryExpression).FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.BooleanTernaryExpression).SecondExpression),
                        thirdExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.BooleanTernaryExpression).ThirdExpression)
                    );
                }
                case 159: {
                    return new BoundingBoxParameter(
                        parameter: (fragment as ScriptDom.BoundingBoxParameter).Parameter,
                        @value: (ScalarExpression)FromMutable((fragment as ScriptDom.BoundingBoxParameter).Value)
                    );
                }
                case 160: {
                    return new BoundingBoxSpatialIndexOption(
                        boundingBoxParameters: (fragment as ScriptDom.BoundingBoxSpatialIndexOption).BoundingBoxParameters.SelectList(c => (BoundingBoxParameter)FromMutable(c))
                    );
                }
                case 161: {
                    return new BreakStatement(
                        
                    );
                }
                case 162: {
                    return new BrokerPriorityParameter(
                        isDefaultOrAny: (fragment as ScriptDom.BrokerPriorityParameter).IsDefaultOrAny,
                        parameterType: (fragment as ScriptDom.BrokerPriorityParameter).ParameterType,
                        parameterValue: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.BrokerPriorityParameter).ParameterValue)
                    );
                }
                case 163: {
                    return new BrowseForClause(
                        
                    );
                }
                case 164: {
                    return new BuiltInFunctionTableReference(
                        name: (Identifier)FromMutable((fragment as ScriptDom.BuiltInFunctionTableReference).Name),
                        parameters: (fragment as ScriptDom.BuiltInFunctionTableReference).Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.BuiltInFunctionTableReference).Alias),
                        forPath: (fragment as ScriptDom.BuiltInFunctionTableReference).ForPath
                    );
                }
                case 165: {
                    return new BulkInsertOption(
                        optionKind: (fragment as ScriptDom.BulkInsertOption).OptionKind
                    );
                }
                case 166: {
                    return new BulkInsertStatement(
                        from: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.BulkInsertStatement).From),
                        to: (SchemaObjectName)FromMutable((fragment as ScriptDom.BulkInsertStatement).To),
                        options: (fragment as ScriptDom.BulkInsertStatement).Options.SelectList(c => (BulkInsertOption)FromMutable(c))
                    );
                }
                case 167: {
                    return new BulkOpenRowset(
                        dataFiles: (fragment as ScriptDom.BulkOpenRowset).DataFiles.SelectList(c => (StringLiteral)FromMutable(c)),
                        options: (fragment as ScriptDom.BulkOpenRowset).Options.SelectList(c => (BulkInsertOption)FromMutable(c)),
                        withColumns: (fragment as ScriptDom.BulkOpenRowset).WithColumns.SelectList(c => (OpenRowsetColumnDefinition)FromMutable(c)),
                        columns: (fragment as ScriptDom.BulkOpenRowset).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.BulkOpenRowset).Alias),
                        forPath: (fragment as ScriptDom.BulkOpenRowset).ForPath
                    );
                }
                case 168: {
                    return new CastCall(
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.CastCall).DataType),
                        parameter: (ScalarExpression)FromMutable((fragment as ScriptDom.CastCall).Parameter),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.CastCall).Collation)
                    );
                }
                case 169: {
                    return new CatalogCollationOption(
                        catalogCollation: (fragment as ScriptDom.CatalogCollationOption).CatalogCollation,
                        optionKind: (fragment as ScriptDom.CatalogCollationOption).OptionKind
                    );
                }
                case 170: {
                    return new CellsPerObjectSpatialIndexOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.CellsPerObjectSpatialIndexOption).Value)
                    );
                }
                case 171: {
                    return new CertificateCreateLoginSource(
                        certificate: (Identifier)FromMutable((fragment as ScriptDom.CertificateCreateLoginSource).Certificate),
                        credential: (Identifier)FromMutable((fragment as ScriptDom.CertificateCreateLoginSource).Credential)
                    );
                }
                case 172: {
                    return new CertificateOption(
                        kind: (fragment as ScriptDom.CertificateOption).Kind,
                        @value: (Literal)FromMutable((fragment as ScriptDom.CertificateOption).Value)
                    );
                }
                case 173: {
                    return new ChangeRetentionChangeTrackingOptionDetail(
                        retentionPeriod: (Literal)FromMutable((fragment as ScriptDom.ChangeRetentionChangeTrackingOptionDetail).RetentionPeriod),
                        unit: (fragment as ScriptDom.ChangeRetentionChangeTrackingOptionDetail).Unit
                    );
                }
                case 174: {
                    return new ChangeTableChangesTableReference(
                        target: (SchemaObjectName)FromMutable((fragment as ScriptDom.ChangeTableChangesTableReference).Target),
                        sinceVersion: (ValueExpression)FromMutable((fragment as ScriptDom.ChangeTableChangesTableReference).SinceVersion),
                        columns: (fragment as ScriptDom.ChangeTableChangesTableReference).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.ChangeTableChangesTableReference).Alias),
                        forPath: (fragment as ScriptDom.ChangeTableChangesTableReference).ForPath
                    );
                }
                case 175: {
                    return new ChangeTableVersionTableReference(
                        target: (SchemaObjectName)FromMutable((fragment as ScriptDom.ChangeTableVersionTableReference).Target),
                        primaryKeyColumns: (fragment as ScriptDom.ChangeTableVersionTableReference).PrimaryKeyColumns.SelectList(c => (Identifier)FromMutable(c)),
                        primaryKeyValues: (fragment as ScriptDom.ChangeTableVersionTableReference).PrimaryKeyValues.SelectList(c => (ScalarExpression)FromMutable(c)),
                        columns: (fragment as ScriptDom.ChangeTableVersionTableReference).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.ChangeTableVersionTableReference).Alias),
                        forPath: (fragment as ScriptDom.ChangeTableVersionTableReference).ForPath
                    );
                }
                case 176: {
                    return new ChangeTrackingDatabaseOption(
                        optionState: (fragment as ScriptDom.ChangeTrackingDatabaseOption).OptionState,
                        details: (fragment as ScriptDom.ChangeTrackingDatabaseOption).Details.SelectList(c => (ChangeTrackingOptionDetail)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.ChangeTrackingDatabaseOption).OptionKind
                    );
                }
                case 177: {
                    return new ChangeTrackingFullTextIndexOption(
                        @value: (fragment as ScriptDom.ChangeTrackingFullTextIndexOption).Value,
                        optionKind: (fragment as ScriptDom.ChangeTrackingFullTextIndexOption).OptionKind
                    );
                }
                case 178: {
                    return new CharacterSetPayloadOption(
                        isSql: (fragment as ScriptDom.CharacterSetPayloadOption).IsSql,
                        kind: (fragment as ScriptDom.CharacterSetPayloadOption).Kind
                    );
                }
                case 179: {
                    return new CheckConstraintDefinition(
                        checkCondition: (BooleanExpression)FromMutable((fragment as ScriptDom.CheckConstraintDefinition).CheckCondition),
                        notForReplication: (fragment as ScriptDom.CheckConstraintDefinition).NotForReplication,
                        constraintIdentifier: (Identifier)FromMutable((fragment as ScriptDom.CheckConstraintDefinition).ConstraintIdentifier)
                    );
                }
                case 180: {
                    return new CheckpointStatement(
                        duration: (Literal)FromMutable((fragment as ScriptDom.CheckpointStatement).Duration)
                    );
                }
                case 181: {
                    return new ChildObjectName(
                        identifiers: (fragment as ScriptDom.ChildObjectName).Identifiers.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 182: {
                    return new ClassifierEndTimeOption(
                        time: (WlmTimeLiteral)FromMutable((fragment as ScriptDom.ClassifierEndTimeOption).Time),
                        optionType: (fragment as ScriptDom.ClassifierEndTimeOption).OptionType
                    );
                }
                case 183: {
                    return new ClassifierImportanceOption(
                        importance: (fragment as ScriptDom.ClassifierImportanceOption).Importance,
                        optionType: (fragment as ScriptDom.ClassifierImportanceOption).OptionType
                    );
                }
                case 184: {
                    return new ClassifierMemberNameOption(
                        memberName: (StringLiteral)FromMutable((fragment as ScriptDom.ClassifierMemberNameOption).MemberName),
                        optionType: (fragment as ScriptDom.ClassifierMemberNameOption).OptionType
                    );
                }
                case 185: {
                    return new ClassifierStartTimeOption(
                        time: (WlmTimeLiteral)FromMutable((fragment as ScriptDom.ClassifierStartTimeOption).Time),
                        optionType: (fragment as ScriptDom.ClassifierStartTimeOption).OptionType
                    );
                }
                case 186: {
                    return new ClassifierWlmContextOption(
                        wlmContext: (StringLiteral)FromMutable((fragment as ScriptDom.ClassifierWlmContextOption).WlmContext),
                        optionType: (fragment as ScriptDom.ClassifierWlmContextOption).OptionType
                    );
                }
                case 187: {
                    return new ClassifierWlmLabelOption(
                        wlmLabel: (StringLiteral)FromMutable((fragment as ScriptDom.ClassifierWlmLabelOption).WlmLabel),
                        optionType: (fragment as ScriptDom.ClassifierWlmLabelOption).OptionType
                    );
                }
                case 188: {
                    return new ClassifierWorkloadGroupOption(
                        workloadGroupName: (StringLiteral)FromMutable((fragment as ScriptDom.ClassifierWorkloadGroupOption).WorkloadGroupName),
                        optionType: (fragment as ScriptDom.ClassifierWorkloadGroupOption).OptionType
                    );
                }
                case 189: {
                    return new CloseCursorStatement(
                        cursor: (CursorId)FromMutable((fragment as ScriptDom.CloseCursorStatement).Cursor)
                    );
                }
                case 190: {
                    return new CloseMasterKeyStatement(
                        
                    );
                }
                case 191: {
                    return new CloseSymmetricKeyStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CloseSymmetricKeyStatement).Name),
                        all: (fragment as ScriptDom.CloseSymmetricKeyStatement).All
                    );
                }
                case 192: {
                    return new CoalesceExpression(
                        expressions: (fragment as ScriptDom.CoalesceExpression).Expressions.SelectList(c => (ScalarExpression)FromMutable(c)),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.CoalesceExpression).Collation)
                    );
                }
                case 193: {
                    return new ColumnDefinition(
                        computedColumnExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.ColumnDefinition).ComputedColumnExpression),
                        isPersisted: (fragment as ScriptDom.ColumnDefinition).IsPersisted,
                        defaultConstraint: (DefaultConstraintDefinition)FromMutable((fragment as ScriptDom.ColumnDefinition).DefaultConstraint),
                        identityOptions: (IdentityOptions)FromMutable((fragment as ScriptDom.ColumnDefinition).IdentityOptions),
                        isRowGuidCol: (fragment as ScriptDom.ColumnDefinition).IsRowGuidCol,
                        constraints: (fragment as ScriptDom.ColumnDefinition).Constraints.SelectList(c => (ConstraintDefinition)FromMutable(c)),
                        storageOptions: (ColumnStorageOptions)FromMutable((fragment as ScriptDom.ColumnDefinition).StorageOptions),
                        index: (IndexDefinition)FromMutable((fragment as ScriptDom.ColumnDefinition).Index),
                        generatedAlways: (fragment as ScriptDom.ColumnDefinition).GeneratedAlways,
                        isHidden: (fragment as ScriptDom.ColumnDefinition).IsHidden,
                        encryption: (ColumnEncryptionDefinition)FromMutable((fragment as ScriptDom.ColumnDefinition).Encryption),
                        isMasked: (fragment as ScriptDom.ColumnDefinition).IsMasked,
                        maskingFunction: (StringLiteral)FromMutable((fragment as ScriptDom.ColumnDefinition).MaskingFunction),
                        columnIdentifier: (Identifier)FromMutable((fragment as ScriptDom.ColumnDefinition).ColumnIdentifier),
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.ColumnDefinition).DataType),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.ColumnDefinition).Collation)
                    );
                }
                case 194: {
                    return new ColumnDefinitionBase(
                        columnIdentifier: (Identifier)FromMutable((fragment as ScriptDom.ColumnDefinitionBase).ColumnIdentifier),
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.ColumnDefinitionBase).DataType),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.ColumnDefinitionBase).Collation)
                    );
                }
                case 195: {
                    return new ColumnEncryptionAlgorithmNameParameter(
                        algorithm: (StringLiteral)FromMutable((fragment as ScriptDom.ColumnEncryptionAlgorithmNameParameter).Algorithm),
                        parameterKind: (fragment as ScriptDom.ColumnEncryptionAlgorithmNameParameter).ParameterKind
                    );
                }
                case 196: {
                    return new ColumnEncryptionAlgorithmParameter(
                        encryptionAlgorithm: (StringLiteral)FromMutable((fragment as ScriptDom.ColumnEncryptionAlgorithmParameter).EncryptionAlgorithm),
                        parameterKind: (fragment as ScriptDom.ColumnEncryptionAlgorithmParameter).ParameterKind
                    );
                }
                case 197: {
                    return new ColumnEncryptionDefinition(
                        parameters: (fragment as ScriptDom.ColumnEncryptionDefinition).Parameters.SelectList(c => (ColumnEncryptionDefinitionParameter)FromMutable(c))
                    );
                }
                case 198: {
                    return new ColumnEncryptionKeyNameParameter(
                        name: (Identifier)FromMutable((fragment as ScriptDom.ColumnEncryptionKeyNameParameter).Name),
                        parameterKind: (fragment as ScriptDom.ColumnEncryptionKeyNameParameter).ParameterKind
                    );
                }
                case 199: {
                    return new ColumnEncryptionKeyValue(
                        parameters: (fragment as ScriptDom.ColumnEncryptionKeyValue).Parameters.SelectList(c => (ColumnEncryptionKeyValueParameter)FromMutable(c))
                    );
                }
                case 200: {
                    return new ColumnEncryptionTypeParameter(
                        encryptionType: (fragment as ScriptDom.ColumnEncryptionTypeParameter).EncryptionType,
                        parameterKind: (fragment as ScriptDom.ColumnEncryptionTypeParameter).ParameterKind
                    );
                }
                case 201: {
                    return new ColumnMasterKeyEnclaveComputationsParameter(
                        signature: (BinaryLiteral)FromMutable((fragment as ScriptDom.ColumnMasterKeyEnclaveComputationsParameter).Signature),
                        parameterKind: (fragment as ScriptDom.ColumnMasterKeyEnclaveComputationsParameter).ParameterKind
                    );
                }
                case 202: {
                    return new ColumnMasterKeyNameParameter(
                        name: (Identifier)FromMutable((fragment as ScriptDom.ColumnMasterKeyNameParameter).Name),
                        parameterKind: (fragment as ScriptDom.ColumnMasterKeyNameParameter).ParameterKind
                    );
                }
                case 203: {
                    return new ColumnMasterKeyPathParameter(
                        path: (StringLiteral)FromMutable((fragment as ScriptDom.ColumnMasterKeyPathParameter).Path),
                        parameterKind: (fragment as ScriptDom.ColumnMasterKeyPathParameter).ParameterKind
                    );
                }
                case 204: {
                    return new ColumnMasterKeyStoreProviderNameParameter(
                        name: (StringLiteral)FromMutable((fragment as ScriptDom.ColumnMasterKeyStoreProviderNameParameter).Name),
                        parameterKind: (fragment as ScriptDom.ColumnMasterKeyStoreProviderNameParameter).ParameterKind
                    );
                }
                case 205: {
                    return new ColumnReferenceExpression(
                        columnType: (fragment as ScriptDom.ColumnReferenceExpression).ColumnType,
                        multiPartIdentifier: (MultiPartIdentifier)FromMutable((fragment as ScriptDom.ColumnReferenceExpression).MultiPartIdentifier),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.ColumnReferenceExpression).Collation)
                    );
                }
                case 206: {
                    return new ColumnStorageOptions(
                        isFileStream: (fragment as ScriptDom.ColumnStorageOptions).IsFileStream,
                        sparseOption: (fragment as ScriptDom.ColumnStorageOptions).SparseOption
                    );
                }
                case 207: {
                    return new ColumnWithSortOrder(
                        column: (ColumnReferenceExpression)FromMutable((fragment as ScriptDom.ColumnWithSortOrder).Column),
                        sortOrder: (fragment as ScriptDom.ColumnWithSortOrder).SortOrder
                    );
                }
                case 208: {
                    return new CommandSecurityElement80(
                        all: (fragment as ScriptDom.CommandSecurityElement80).All,
                        commandOptions: (fragment as ScriptDom.CommandSecurityElement80).CommandOptions
                    );
                }
                case 209: {
                    return new CommitTransactionStatement(
                        delayedDurabilityOption: (fragment as ScriptDom.CommitTransactionStatement).DelayedDurabilityOption,
                        name: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.CommitTransactionStatement).Name)
                    );
                }
                case 210: {
                    return new CommonTableExpression(
                        expressionName: (Identifier)FromMutable((fragment as ScriptDom.CommonTableExpression).ExpressionName),
                        columns: (fragment as ScriptDom.CommonTableExpression).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        queryExpression: (QueryExpression)FromMutable((fragment as ScriptDom.CommonTableExpression).QueryExpression)
                    );
                }
                case 211: {
                    return new CompositeGroupingSpecification(
                        items: (fragment as ScriptDom.CompositeGroupingSpecification).Items.SelectList(c => (GroupingSpecification)FromMutable(c))
                    );
                }
                case 212: {
                    return new CompressionDelayIndexOption(
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.CompressionDelayIndexOption).Expression),
                        timeUnit: (fragment as ScriptDom.CompressionDelayIndexOption).TimeUnit,
                        optionKind: (fragment as ScriptDom.CompressionDelayIndexOption).OptionKind
                    );
                }
                case 213: {
                    return new CompressionEndpointProtocolOption(
                        isEnabled: (fragment as ScriptDom.CompressionEndpointProtocolOption).IsEnabled,
                        kind: (fragment as ScriptDom.CompressionEndpointProtocolOption).Kind
                    );
                }
                case 214: {
                    return new CompressionPartitionRange(
                        from: (ScalarExpression)FromMutable((fragment as ScriptDom.CompressionPartitionRange).From),
                        to: (ScalarExpression)FromMutable((fragment as ScriptDom.CompressionPartitionRange).To)
                    );
                }
                case 215: {
                    return new ComputeClause(
                        computeFunctions: (fragment as ScriptDom.ComputeClause).ComputeFunctions.SelectList(c => (ComputeFunction)FromMutable(c)),
                        byExpressions: (fragment as ScriptDom.ComputeClause).ByExpressions.SelectList(c => (ScalarExpression)FromMutable(c))
                    );
                }
                case 216: {
                    return new ComputeFunction(
                        computeFunctionType: (fragment as ScriptDom.ComputeFunction).ComputeFunctionType,
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.ComputeFunction).Expression)
                    );
                }
                case 217: {
                    return new ContainmentDatabaseOption(
                        @value: (fragment as ScriptDom.ContainmentDatabaseOption).Value,
                        optionKind: (fragment as ScriptDom.ContainmentDatabaseOption).OptionKind
                    );
                }
                case 218: {
                    return new ContinueStatement(
                        
                    );
                }
                case 219: {
                    return new ContractMessage(
                        name: (Identifier)FromMutable((fragment as ScriptDom.ContractMessage).Name),
                        sentBy: (fragment as ScriptDom.ContractMessage).SentBy
                    );
                }
                case 220: {
                    return new ConvertCall(
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.ConvertCall).DataType),
                        parameter: (ScalarExpression)FromMutable((fragment as ScriptDom.ConvertCall).Parameter),
                        style: (ScalarExpression)FromMutable((fragment as ScriptDom.ConvertCall).Style),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.ConvertCall).Collation)
                    );
                }
                case 221: {
                    return new CopyColumnOption(
                        columnName: (Identifier)FromMutable((fragment as ScriptDom.CopyColumnOption).ColumnName),
                        defaultValue: (ScalarExpression)FromMutable((fragment as ScriptDom.CopyColumnOption).DefaultValue),
                        fieldNumber: (IntegerLiteral)FromMutable((fragment as ScriptDom.CopyColumnOption).FieldNumber)
                    );
                }
                case 222: {
                    return new CopyCredentialOption(
                        identity: (StringLiteral)FromMutable((fragment as ScriptDom.CopyCredentialOption).Identity),
                        secret: (StringLiteral)FromMutable((fragment as ScriptDom.CopyCredentialOption).Secret)
                    );
                }
                case 223: {
                    return new CopyOption(
                        kind: (fragment as ScriptDom.CopyOption).Kind,
                        @value: (CopyStatementOptionBase)FromMutable((fragment as ScriptDom.CopyOption).Value)
                    );
                }
                case 224: {
                    return new CopyStatement(
                        from: (fragment as ScriptDom.CopyStatement).From.SelectList(c => (StringLiteral)FromMutable(c)),
                        into: (SchemaObjectName)FromMutable((fragment as ScriptDom.CopyStatement).Into),
                        options: (fragment as ScriptDom.CopyStatement).Options.SelectList(c => (CopyOption)FromMutable(c)),
                        optimizerHints: (fragment as ScriptDom.CopyStatement).OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 225: {
                    return new CreateAggregateStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateAggregateStatement).Name),
                        assemblyName: (AssemblyName)FromMutable((fragment as ScriptDom.CreateAggregateStatement).AssemblyName),
                        parameters: (fragment as ScriptDom.CreateAggregateStatement).Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        returnType: (DataTypeReference)FromMutable((fragment as ScriptDom.CreateAggregateStatement).ReturnType)
                    );
                }
                case 226: {
                    return new CreateApplicationRoleStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateApplicationRoleStatement).Name),
                        applicationRoleOptions: (fragment as ScriptDom.CreateApplicationRoleStatement).ApplicationRoleOptions.SelectList(c => (ApplicationRoleOption)FromMutable(c))
                    );
                }
                case 227: {
                    return new CreateAssemblyStatement(
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateAssemblyStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateAssemblyStatement).Name),
                        parameters: (fragment as ScriptDom.CreateAssemblyStatement).Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        options: (fragment as ScriptDom.CreateAssemblyStatement).Options.SelectList(c => (AssemblyOption)FromMutable(c))
                    );
                }
                case 228: {
                    return new CreateAsymmetricKeyStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateAsymmetricKeyStatement).Name),
                        keySource: (EncryptionSource)FromMutable((fragment as ScriptDom.CreateAsymmetricKeyStatement).KeySource),
                        encryptionAlgorithm: (fragment as ScriptDom.CreateAsymmetricKeyStatement).EncryptionAlgorithm,
                        password: (Literal)FromMutable((fragment as ScriptDom.CreateAsymmetricKeyStatement).Password),
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateAsymmetricKeyStatement).Owner)
                    );
                }
                case 229: {
                    return new CreateAvailabilityGroupStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateAvailabilityGroupStatement).Name),
                        options: (fragment as ScriptDom.CreateAvailabilityGroupStatement).Options.SelectList(c => (AvailabilityGroupOption)FromMutable(c)),
                        databases: (fragment as ScriptDom.CreateAvailabilityGroupStatement).Databases.SelectList(c => (Identifier)FromMutable(c)),
                        replicas: (fragment as ScriptDom.CreateAvailabilityGroupStatement).Replicas.SelectList(c => (AvailabilityReplica)FromMutable(c))
                    );
                }
                case 230: {
                    return new CreateBrokerPriorityStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateBrokerPriorityStatement).Name),
                        brokerPriorityParameters: (fragment as ScriptDom.CreateBrokerPriorityStatement).BrokerPriorityParameters.SelectList(c => (BrokerPriorityParameter)FromMutable(c))
                    );
                }
                case 231: {
                    return new CreateCertificateStatement(
                        certificateSource: (EncryptionSource)FromMutable((fragment as ScriptDom.CreateCertificateStatement).CertificateSource),
                        certificateOptions: (fragment as ScriptDom.CreateCertificateStatement).CertificateOptions.SelectList(c => (CertificateOption)FromMutable(c)),
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateCertificateStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateCertificateStatement).Name),
                        activeForBeginDialog: (fragment as ScriptDom.CreateCertificateStatement).ActiveForBeginDialog,
                        privateKeyPath: (Literal)FromMutable((fragment as ScriptDom.CreateCertificateStatement).PrivateKeyPath),
                        encryptionPassword: (Literal)FromMutable((fragment as ScriptDom.CreateCertificateStatement).EncryptionPassword),
                        decryptionPassword: (Literal)FromMutable((fragment as ScriptDom.CreateCertificateStatement).DecryptionPassword)
                    );
                }
                case 232: {
                    return new CreateColumnEncryptionKeyStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateColumnEncryptionKeyStatement).Name),
                        columnEncryptionKeyValues: (fragment as ScriptDom.CreateColumnEncryptionKeyStatement).ColumnEncryptionKeyValues.SelectList(c => (ColumnEncryptionKeyValue)FromMutable(c))
                    );
                }
                case 233: {
                    return new CreateColumnMasterKeyStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateColumnMasterKeyStatement).Name),
                        parameters: (fragment as ScriptDom.CreateColumnMasterKeyStatement).Parameters.SelectList(c => (ColumnMasterKeyParameter)FromMutable(c))
                    );
                }
                case 234: {
                    return new CreateColumnStoreIndexStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateColumnStoreIndexStatement).Name),
                        clustered: (fragment as ScriptDom.CreateColumnStoreIndexStatement).Clustered,
                        onName: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateColumnStoreIndexStatement).OnName),
                        columns: (fragment as ScriptDom.CreateColumnStoreIndexStatement).Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        filterPredicate: (BooleanExpression)FromMutable((fragment as ScriptDom.CreateColumnStoreIndexStatement).FilterPredicate),
                        indexOptions: (fragment as ScriptDom.CreateColumnStoreIndexStatement).IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                        onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable((fragment as ScriptDom.CreateColumnStoreIndexStatement).OnFileGroupOrPartitionScheme),
                        orderedColumns: (fragment as ScriptDom.CreateColumnStoreIndexStatement).OrderedColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
                    );
                }
                case 235: {
                    return new CreateContractStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateContractStatement).Name),
                        messages: (fragment as ScriptDom.CreateContractStatement).Messages.SelectList(c => (ContractMessage)FromMutable(c)),
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateContractStatement).Owner)
                    );
                }
                case 236: {
                    return new CreateCredentialStatement(
                        cryptographicProviderName: (Identifier)FromMutable((fragment as ScriptDom.CreateCredentialStatement).CryptographicProviderName),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateCredentialStatement).Name),
                        identity: (Literal)FromMutable((fragment as ScriptDom.CreateCredentialStatement).Identity),
                        secret: (Literal)FromMutable((fragment as ScriptDom.CreateCredentialStatement).Secret),
                        isDatabaseScoped: (fragment as ScriptDom.CreateCredentialStatement).IsDatabaseScoped
                    );
                }
                case 237: {
                    return new CreateCryptographicProviderStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateCryptographicProviderStatement).Name),
                        file: (Literal)FromMutable((fragment as ScriptDom.CreateCryptographicProviderStatement).File)
                    );
                }
                case 238: {
                    return new CreateDatabaseAuditSpecificationStatement(
                        auditState: (fragment as ScriptDom.CreateDatabaseAuditSpecificationStatement).AuditState,
                        parts: (fragment as ScriptDom.CreateDatabaseAuditSpecificationStatement).Parts.SelectList(c => (AuditSpecificationPart)FromMutable(c)),
                        specificationName: (Identifier)FromMutable((fragment as ScriptDom.CreateDatabaseAuditSpecificationStatement).SpecificationName),
                        auditName: (Identifier)FromMutable((fragment as ScriptDom.CreateDatabaseAuditSpecificationStatement).AuditName)
                    );
                }
                case 239: {
                    return new CreateDatabaseEncryptionKeyStatement(
                        encryptor: (CryptoMechanism)FromMutable((fragment as ScriptDom.CreateDatabaseEncryptionKeyStatement).Encryptor),
                        algorithm: (fragment as ScriptDom.CreateDatabaseEncryptionKeyStatement).Algorithm
                    );
                }
                case 240: {
                    return new CreateDatabaseStatement(
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.CreateDatabaseStatement).DatabaseName),
                        containment: (ContainmentDatabaseOption)FromMutable((fragment as ScriptDom.CreateDatabaseStatement).Containment),
                        fileGroups: (fragment as ScriptDom.CreateDatabaseStatement).FileGroups.SelectList(c => (FileGroupDefinition)FromMutable(c)),
                        logOn: (fragment as ScriptDom.CreateDatabaseStatement).LogOn.SelectList(c => (FileDeclaration)FromMutable(c)),
                        options: (fragment as ScriptDom.CreateDatabaseStatement).Options.SelectList(c => (DatabaseOption)FromMutable(c)),
                        attachMode: (fragment as ScriptDom.CreateDatabaseStatement).AttachMode,
                        databaseSnapshot: (Identifier)FromMutable((fragment as ScriptDom.CreateDatabaseStatement).DatabaseSnapshot),
                        copyOf: (MultiPartIdentifier)FromMutable((fragment as ScriptDom.CreateDatabaseStatement).CopyOf),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.CreateDatabaseStatement).Collation)
                    );
                }
                case 241: {
                    return new CreateDefaultStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateDefaultStatement).Name),
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.CreateDefaultStatement).Expression)
                    );
                }
                case 242: {
                    return new CreateEndpointStatement(
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateEndpointStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateEndpointStatement).Name),
                        state: (fragment as ScriptDom.CreateEndpointStatement).State,
                        affinity: (EndpointAffinity)FromMutable((fragment as ScriptDom.CreateEndpointStatement).Affinity),
                        protocol: (fragment as ScriptDom.CreateEndpointStatement).Protocol,
                        protocolOptions: (fragment as ScriptDom.CreateEndpointStatement).ProtocolOptions.SelectList(c => (EndpointProtocolOption)FromMutable(c)),
                        endpointType: (fragment as ScriptDom.CreateEndpointStatement).EndpointType,
                        payloadOptions: (fragment as ScriptDom.CreateEndpointStatement).PayloadOptions.SelectList(c => (PayloadOption)FromMutable(c))
                    );
                }
                case 243: {
                    return new CreateEventNotificationStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateEventNotificationStatement).Name),
                        scope: (EventNotificationObjectScope)FromMutable((fragment as ScriptDom.CreateEventNotificationStatement).Scope),
                        withFanIn: (fragment as ScriptDom.CreateEventNotificationStatement).WithFanIn,
                        eventTypeGroups: (fragment as ScriptDom.CreateEventNotificationStatement).EventTypeGroups.SelectList(c => (EventTypeGroupContainer)FromMutable(c)),
                        brokerService: (Literal)FromMutable((fragment as ScriptDom.CreateEventNotificationStatement).BrokerService),
                        brokerInstanceSpecifier: (Literal)FromMutable((fragment as ScriptDom.CreateEventNotificationStatement).BrokerInstanceSpecifier)
                    );
                }
                case 244: {
                    return new CreateEventSessionStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateEventSessionStatement).Name),
                        sessionScope: (fragment as ScriptDom.CreateEventSessionStatement).SessionScope,
                        eventDeclarations: (fragment as ScriptDom.CreateEventSessionStatement).EventDeclarations.SelectList(c => (EventDeclaration)FromMutable(c)),
                        targetDeclarations: (fragment as ScriptDom.CreateEventSessionStatement).TargetDeclarations.SelectList(c => (TargetDeclaration)FromMutable(c)),
                        sessionOptions: (fragment as ScriptDom.CreateEventSessionStatement).SessionOptions.SelectList(c => (SessionOption)FromMutable(c))
                    );
                }
                case 245: {
                    return new CreateExternalDataSourceStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateExternalDataSourceStatement).Name),
                        dataSourceType: (fragment as ScriptDom.CreateExternalDataSourceStatement).DataSourceType,
                        location: (Literal)FromMutable((fragment as ScriptDom.CreateExternalDataSourceStatement).Location),
                        pushdownOption: (fragment as ScriptDom.CreateExternalDataSourceStatement).PushdownOption,
                        externalDataSourceOptions: (fragment as ScriptDom.CreateExternalDataSourceStatement).ExternalDataSourceOptions.SelectList(c => (ExternalDataSourceOption)FromMutable(c))
                    );
                }
                case 246: {
                    return new CreateExternalFileFormatStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateExternalFileFormatStatement).Name),
                        formatType: (fragment as ScriptDom.CreateExternalFileFormatStatement).FormatType,
                        externalFileFormatOptions: (fragment as ScriptDom.CreateExternalFileFormatStatement).ExternalFileFormatOptions.SelectList(c => (ExternalFileFormatOption)FromMutable(c))
                    );
                }
                case 247: {
                    return new CreateExternalLanguageStatement(
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateExternalLanguageStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateExternalLanguageStatement).Name),
                        externalLanguageFiles: (fragment as ScriptDom.CreateExternalLanguageStatement).ExternalLanguageFiles.SelectList(c => (ExternalLanguageFileOption)FromMutable(c))
                    );
                }
                case 248: {
                    return new CreateExternalLibraryStatement(
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateExternalLibraryStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateExternalLibraryStatement).Name),
                        language: (StringLiteral)FromMutable((fragment as ScriptDom.CreateExternalLibraryStatement).Language),
                        externalLibraryFiles: (fragment as ScriptDom.CreateExternalLibraryStatement).ExternalLibraryFiles.SelectList(c => (ExternalLibraryFileOption)FromMutable(c))
                    );
                }
                case 249: {
                    return new CreateExternalResourcePoolStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateExternalResourcePoolStatement).Name),
                        externalResourcePoolParameters: (fragment as ScriptDom.CreateExternalResourcePoolStatement).ExternalResourcePoolParameters.SelectList(c => (ExternalResourcePoolParameter)FromMutable(c))
                    );
                }
                case 250: {
                    return new CreateExternalStreamingJobStatement(
                        name: (StringLiteral)FromMutable((fragment as ScriptDom.CreateExternalStreamingJobStatement).Name),
                        statement: (StringLiteral)FromMutable((fragment as ScriptDom.CreateExternalStreamingJobStatement).Statement)
                    );
                }
                case 251: {
                    return new CreateExternalStreamStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateExternalStreamStatement).Name),
                        location: (Literal)FromMutable((fragment as ScriptDom.CreateExternalStreamStatement).Location),
                        inputOptions: (Literal)FromMutable((fragment as ScriptDom.CreateExternalStreamStatement).InputOptions),
                        outputOptions: (Literal)FromMutable((fragment as ScriptDom.CreateExternalStreamStatement).OutputOptions),
                        externalStreamOptions: (fragment as ScriptDom.CreateExternalStreamStatement).ExternalStreamOptions.SelectList(c => (ExternalStreamOption)FromMutable(c))
                    );
                }
                case 252: {
                    return new CreateExternalTableStatement(
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateExternalTableStatement).SchemaObjectName),
                        columnDefinitions: (fragment as ScriptDom.CreateExternalTableStatement).ColumnDefinitions.SelectList(c => (ExternalTableColumnDefinition)FromMutable(c)),
                        dataSource: (Identifier)FromMutable((fragment as ScriptDom.CreateExternalTableStatement).DataSource),
                        externalTableOptions: (fragment as ScriptDom.CreateExternalTableStatement).ExternalTableOptions.SelectList(c => (ExternalTableOption)FromMutable(c)),
                        selectStatement: (SelectStatement)FromMutable((fragment as ScriptDom.CreateExternalTableStatement).SelectStatement)
                    );
                }
                case 253: {
                    return new CreateFederationStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateFederationStatement).Name),
                        distributionName: (Identifier)FromMutable((fragment as ScriptDom.CreateFederationStatement).DistributionName),
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.CreateFederationStatement).DataType)
                    );
                }
                case 254: {
                    return new CreateFullTextCatalogStatement(
                        fileGroup: (Identifier)FromMutable((fragment as ScriptDom.CreateFullTextCatalogStatement).FileGroup),
                        path: (Literal)FromMutable((fragment as ScriptDom.CreateFullTextCatalogStatement).Path),
                        isDefault: (fragment as ScriptDom.CreateFullTextCatalogStatement).IsDefault,
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateFullTextCatalogStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateFullTextCatalogStatement).Name),
                        options: (fragment as ScriptDom.CreateFullTextCatalogStatement).Options.SelectList(c => (FullTextCatalogOption)FromMutable(c))
                    );
                }
                case 255: {
                    return new CreateFullTextIndexStatement(
                        onName: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateFullTextIndexStatement).OnName),
                        fullTextIndexColumns: (fragment as ScriptDom.CreateFullTextIndexStatement).FullTextIndexColumns.SelectList(c => (FullTextIndexColumn)FromMutable(c)),
                        keyIndexName: (Identifier)FromMutable((fragment as ScriptDom.CreateFullTextIndexStatement).KeyIndexName),
                        catalogAndFileGroup: (FullTextCatalogAndFileGroup)FromMutable((fragment as ScriptDom.CreateFullTextIndexStatement).CatalogAndFileGroup),
                        options: (fragment as ScriptDom.CreateFullTextIndexStatement).Options.SelectList(c => (FullTextIndexOption)FromMutable(c))
                    );
                }
                case 256: {
                    return new CreateFullTextStopListStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateFullTextStopListStatement).Name),
                        isSystemStopList: (fragment as ScriptDom.CreateFullTextStopListStatement).IsSystemStopList,
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.CreateFullTextStopListStatement).DatabaseName),
                        sourceStopListName: (Identifier)FromMutable((fragment as ScriptDom.CreateFullTextStopListStatement).SourceStopListName),
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateFullTextStopListStatement).Owner)
                    );
                }
                case 257: {
                    return new CreateFunctionStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateFunctionStatement).Name),
                        returnType: (FunctionReturnType)FromMutable((fragment as ScriptDom.CreateFunctionStatement).ReturnType),
                        options: (fragment as ScriptDom.CreateFunctionStatement).Options.SelectList(c => (FunctionOption)FromMutable(c)),
                        orderHint: (OrderBulkInsertOption)FromMutable((fragment as ScriptDom.CreateFunctionStatement).OrderHint),
                        parameters: (fragment as ScriptDom.CreateFunctionStatement).Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        statementList: (StatementList)FromMutable((fragment as ScriptDom.CreateFunctionStatement).StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable((fragment as ScriptDom.CreateFunctionStatement).MethodSpecifier)
                    );
                }
                case 258: {
                    return new CreateIndexStatement(
                        translated80SyntaxTo90: (fragment as ScriptDom.CreateIndexStatement).Translated80SyntaxTo90,
                        unique: (fragment as ScriptDom.CreateIndexStatement).Unique,
                        clustered: (fragment as ScriptDom.CreateIndexStatement).Clustered,
                        columns: (fragment as ScriptDom.CreateIndexStatement).Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                        includeColumns: (fragment as ScriptDom.CreateIndexStatement).IncludeColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable((fragment as ScriptDom.CreateIndexStatement).OnFileGroupOrPartitionScheme),
                        filterPredicate: (BooleanExpression)FromMutable((fragment as ScriptDom.CreateIndexStatement).FilterPredicate),
                        fileStreamOn: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.CreateIndexStatement).FileStreamOn),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateIndexStatement).Name),
                        onName: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateIndexStatement).OnName),
                        indexOptions: (fragment as ScriptDom.CreateIndexStatement).IndexOptions.SelectList(c => (IndexOption)FromMutable(c))
                    );
                }
                case 259: {
                    return new CreateLoginStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateLoginStatement).Name),
                        source: (CreateLoginSource)FromMutable((fragment as ScriptDom.CreateLoginStatement).Source)
                    );
                }
                case 260: {
                    return new CreateMasterKeyStatement(
                        password: (Literal)FromMutable((fragment as ScriptDom.CreateMasterKeyStatement).Password)
                    );
                }
                case 261: {
                    return new CreateMessageTypeStatement(
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateMessageTypeStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateMessageTypeStatement).Name),
                        validationMethod: (fragment as ScriptDom.CreateMessageTypeStatement).ValidationMethod,
                        xmlSchemaCollectionName: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateMessageTypeStatement).XmlSchemaCollectionName)
                    );
                }
                case 262: {
                    return new CreateOrAlterFunctionStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateOrAlterFunctionStatement).Name),
                        returnType: (FunctionReturnType)FromMutable((fragment as ScriptDom.CreateOrAlterFunctionStatement).ReturnType),
                        options: (fragment as ScriptDom.CreateOrAlterFunctionStatement).Options.SelectList(c => (FunctionOption)FromMutable(c)),
                        orderHint: (OrderBulkInsertOption)FromMutable((fragment as ScriptDom.CreateOrAlterFunctionStatement).OrderHint),
                        parameters: (fragment as ScriptDom.CreateOrAlterFunctionStatement).Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        statementList: (StatementList)FromMutable((fragment as ScriptDom.CreateOrAlterFunctionStatement).StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable((fragment as ScriptDom.CreateOrAlterFunctionStatement).MethodSpecifier)
                    );
                }
                case 263: {
                    return new CreateOrAlterProcedureStatement(
                        procedureReference: (ProcedureReference)FromMutable((fragment as ScriptDom.CreateOrAlterProcedureStatement).ProcedureReference),
                        isForReplication: (fragment as ScriptDom.CreateOrAlterProcedureStatement).IsForReplication,
                        options: (fragment as ScriptDom.CreateOrAlterProcedureStatement).Options.SelectList(c => (ProcedureOption)FromMutable(c)),
                        parameters: (fragment as ScriptDom.CreateOrAlterProcedureStatement).Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        statementList: (StatementList)FromMutable((fragment as ScriptDom.CreateOrAlterProcedureStatement).StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable((fragment as ScriptDom.CreateOrAlterProcedureStatement).MethodSpecifier)
                    );
                }
                case 264: {
                    return new CreateOrAlterTriggerStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateOrAlterTriggerStatement).Name),
                        triggerObject: (TriggerObject)FromMutable((fragment as ScriptDom.CreateOrAlterTriggerStatement).TriggerObject),
                        options: (fragment as ScriptDom.CreateOrAlterTriggerStatement).Options.SelectList(c => (TriggerOption)FromMutable(c)),
                        triggerType: (fragment as ScriptDom.CreateOrAlterTriggerStatement).TriggerType,
                        triggerActions: (fragment as ScriptDom.CreateOrAlterTriggerStatement).TriggerActions.SelectList(c => (TriggerAction)FromMutable(c)),
                        withAppend: (fragment as ScriptDom.CreateOrAlterTriggerStatement).WithAppend,
                        isNotForReplication: (fragment as ScriptDom.CreateOrAlterTriggerStatement).IsNotForReplication,
                        statementList: (StatementList)FromMutable((fragment as ScriptDom.CreateOrAlterTriggerStatement).StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable((fragment as ScriptDom.CreateOrAlterTriggerStatement).MethodSpecifier)
                    );
                }
                case 265: {
                    return new CreateOrAlterViewStatement(
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateOrAlterViewStatement).SchemaObjectName),
                        columns: (fragment as ScriptDom.CreateOrAlterViewStatement).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        viewOptions: (fragment as ScriptDom.CreateOrAlterViewStatement).ViewOptions.SelectList(c => (ViewOption)FromMutable(c)),
                        selectStatement: (SelectStatement)FromMutable((fragment as ScriptDom.CreateOrAlterViewStatement).SelectStatement),
                        withCheckOption: (fragment as ScriptDom.CreateOrAlterViewStatement).WithCheckOption,
                        isMaterialized: (fragment as ScriptDom.CreateOrAlterViewStatement).IsMaterialized
                    );
                }
                case 266: {
                    return new CreatePartitionFunctionStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreatePartitionFunctionStatement).Name),
                        parameterType: (PartitionParameterType)FromMutable((fragment as ScriptDom.CreatePartitionFunctionStatement).ParameterType),
                        range: (fragment as ScriptDom.CreatePartitionFunctionStatement).Range,
                        boundaryValues: (fragment as ScriptDom.CreatePartitionFunctionStatement).BoundaryValues.SelectList(c => (ScalarExpression)FromMutable(c))
                    );
                }
                case 267: {
                    return new CreatePartitionSchemeStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreatePartitionSchemeStatement).Name),
                        partitionFunction: (Identifier)FromMutable((fragment as ScriptDom.CreatePartitionSchemeStatement).PartitionFunction),
                        isAll: (fragment as ScriptDom.CreatePartitionSchemeStatement).IsAll,
                        fileGroups: (fragment as ScriptDom.CreatePartitionSchemeStatement).FileGroups.SelectList(c => (IdentifierOrValueExpression)FromMutable(c))
                    );
                }
                case 268: {
                    return new CreateProcedureStatement(
                        procedureReference: (ProcedureReference)FromMutable((fragment as ScriptDom.CreateProcedureStatement).ProcedureReference),
                        isForReplication: (fragment as ScriptDom.CreateProcedureStatement).IsForReplication,
                        options: (fragment as ScriptDom.CreateProcedureStatement).Options.SelectList(c => (ProcedureOption)FromMutable(c)),
                        parameters: (fragment as ScriptDom.CreateProcedureStatement).Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        statementList: (StatementList)FromMutable((fragment as ScriptDom.CreateProcedureStatement).StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable((fragment as ScriptDom.CreateProcedureStatement).MethodSpecifier)
                    );
                }
                case 269: {
                    return new CreateQueueStatement(
                        onFileGroup: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.CreateQueueStatement).OnFileGroup),
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateQueueStatement).Name),
                        queueOptions: (fragment as ScriptDom.CreateQueueStatement).QueueOptions.SelectList(c => (QueueOption)FromMutable(c))
                    );
                }
                case 270: {
                    return new CreateRemoteServiceBindingStatement(
                        service: (Literal)FromMutable((fragment as ScriptDom.CreateRemoteServiceBindingStatement).Service),
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateRemoteServiceBindingStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateRemoteServiceBindingStatement).Name),
                        options: (fragment as ScriptDom.CreateRemoteServiceBindingStatement).Options.SelectList(c => (RemoteServiceBindingOption)FromMutable(c))
                    );
                }
                case 271: {
                    return new CreateResourcePoolStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateResourcePoolStatement).Name),
                        resourcePoolParameters: (fragment as ScriptDom.CreateResourcePoolStatement).ResourcePoolParameters.SelectList(c => (ResourcePoolParameter)FromMutable(c))
                    );
                }
                case 272: {
                    return new CreateRoleStatement(
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateRoleStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateRoleStatement).Name)
                    );
                }
                case 273: {
                    return new CreateRouteStatement(
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateRouteStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateRouteStatement).Name),
                        routeOptions: (fragment as ScriptDom.CreateRouteStatement).RouteOptions.SelectList(c => (RouteOption)FromMutable(c))
                    );
                }
                case 274: {
                    return new CreateRuleStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateRuleStatement).Name),
                        expression: (BooleanExpression)FromMutable((fragment as ScriptDom.CreateRuleStatement).Expression)
                    );
                }
                case 275: {
                    return new CreateSchemaStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateSchemaStatement).Name),
                        statementList: (StatementList)FromMutable((fragment as ScriptDom.CreateSchemaStatement).StatementList),
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateSchemaStatement).Owner)
                    );
                }
                case 276: {
                    return new CreateSearchPropertyListStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateSearchPropertyListStatement).Name),
                        sourceSearchPropertyList: (MultiPartIdentifier)FromMutable((fragment as ScriptDom.CreateSearchPropertyListStatement).SourceSearchPropertyList),
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateSearchPropertyListStatement).Owner)
                    );
                }
                case 277: {
                    return new CreateSecurityPolicyStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateSecurityPolicyStatement).Name),
                        notForReplication: (fragment as ScriptDom.CreateSecurityPolicyStatement).NotForReplication,
                        securityPolicyOptions: (fragment as ScriptDom.CreateSecurityPolicyStatement).SecurityPolicyOptions.SelectList(c => (SecurityPolicyOption)FromMutable(c)),
                        securityPredicateActions: (fragment as ScriptDom.CreateSecurityPolicyStatement).SecurityPredicateActions.SelectList(c => (SecurityPredicateAction)FromMutable(c)),
                        actionType: (fragment as ScriptDom.CreateSecurityPolicyStatement).ActionType
                    );
                }
                case 278: {
                    return new CreateSelectiveXmlIndexStatement(
                        isSecondary: (fragment as ScriptDom.CreateSelectiveXmlIndexStatement).IsSecondary,
                        xmlColumn: (Identifier)FromMutable((fragment as ScriptDom.CreateSelectiveXmlIndexStatement).XmlColumn),
                        promotedPaths: (fragment as ScriptDom.CreateSelectiveXmlIndexStatement).PromotedPaths.SelectList(c => (SelectiveXmlIndexPromotedPath)FromMutable(c)),
                        xmlNamespaces: (XmlNamespaces)FromMutable((fragment as ScriptDom.CreateSelectiveXmlIndexStatement).XmlNamespaces),
                        usingXmlIndexName: (Identifier)FromMutable((fragment as ScriptDom.CreateSelectiveXmlIndexStatement).UsingXmlIndexName),
                        pathName: (Identifier)FromMutable((fragment as ScriptDom.CreateSelectiveXmlIndexStatement).PathName),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateSelectiveXmlIndexStatement).Name),
                        onName: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateSelectiveXmlIndexStatement).OnName),
                        indexOptions: (fragment as ScriptDom.CreateSelectiveXmlIndexStatement).IndexOptions.SelectList(c => (IndexOption)FromMutable(c))
                    );
                }
                case 279: {
                    return new CreateSequenceStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateSequenceStatement).Name),
                        sequenceOptions: (fragment as ScriptDom.CreateSequenceStatement).SequenceOptions.SelectList(c => (SequenceOption)FromMutable(c))
                    );
                }
                case 280: {
                    return new CreateServerAuditSpecificationStatement(
                        auditState: (fragment as ScriptDom.CreateServerAuditSpecificationStatement).AuditState,
                        parts: (fragment as ScriptDom.CreateServerAuditSpecificationStatement).Parts.SelectList(c => (AuditSpecificationPart)FromMutable(c)),
                        specificationName: (Identifier)FromMutable((fragment as ScriptDom.CreateServerAuditSpecificationStatement).SpecificationName),
                        auditName: (Identifier)FromMutable((fragment as ScriptDom.CreateServerAuditSpecificationStatement).AuditName)
                    );
                }
                case 281: {
                    return new CreateServerAuditStatement(
                        auditName: (Identifier)FromMutable((fragment as ScriptDom.CreateServerAuditStatement).AuditName),
                        auditTarget: (AuditTarget)FromMutable((fragment as ScriptDom.CreateServerAuditStatement).AuditTarget),
                        options: (fragment as ScriptDom.CreateServerAuditStatement).Options.SelectList(c => (AuditOption)FromMutable(c)),
                        predicateExpression: (BooleanExpression)FromMutable((fragment as ScriptDom.CreateServerAuditStatement).PredicateExpression)
                    );
                }
                case 282: {
                    return new CreateServerRoleStatement(
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateServerRoleStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateServerRoleStatement).Name)
                    );
                }
                case 283: {
                    return new CreateServiceStatement(
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateServiceStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateServiceStatement).Name),
                        queueName: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateServiceStatement).QueueName),
                        serviceContracts: (fragment as ScriptDom.CreateServiceStatement).ServiceContracts.SelectList(c => (ServiceContract)FromMutable(c))
                    );
                }
                case 284: {
                    return new CreateSpatialIndexStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateSpatialIndexStatement).Name),
                        @object: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateSpatialIndexStatement).Object),
                        spatialColumnName: (Identifier)FromMutable((fragment as ScriptDom.CreateSpatialIndexStatement).SpatialColumnName),
                        spatialIndexingScheme: (fragment as ScriptDom.CreateSpatialIndexStatement).SpatialIndexingScheme,
                        spatialIndexOptions: (fragment as ScriptDom.CreateSpatialIndexStatement).SpatialIndexOptions.SelectList(c => (SpatialIndexOption)FromMutable(c)),
                        onFileGroup: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.CreateSpatialIndexStatement).OnFileGroup)
                    );
                }
                case 285: {
                    return new CreateStatisticsStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateStatisticsStatement).Name),
                        onName: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateStatisticsStatement).OnName),
                        columns: (fragment as ScriptDom.CreateStatisticsStatement).Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        statisticsOptions: (fragment as ScriptDom.CreateStatisticsStatement).StatisticsOptions.SelectList(c => (StatisticsOption)FromMutable(c)),
                        filterPredicate: (BooleanExpression)FromMutable((fragment as ScriptDom.CreateStatisticsStatement).FilterPredicate)
                    );
                }
                case 286: {
                    return new CreateSymmetricKeyStatement(
                        keyOptions: (fragment as ScriptDom.CreateSymmetricKeyStatement).KeyOptions.SelectList(c => (KeyOption)FromMutable(c)),
                        provider: (Identifier)FromMutable((fragment as ScriptDom.CreateSymmetricKeyStatement).Provider),
                        owner: (Identifier)FromMutable((fragment as ScriptDom.CreateSymmetricKeyStatement).Owner),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateSymmetricKeyStatement).Name),
                        encryptingMechanisms: (fragment as ScriptDom.CreateSymmetricKeyStatement).EncryptingMechanisms.SelectList(c => (CryptoMechanism)FromMutable(c))
                    );
                }
                case 287: {
                    return new CreateSynonymStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateSynonymStatement).Name),
                        forName: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateSynonymStatement).ForName)
                    );
                }
                case 288: {
                    return new CreateTableStatement(
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateTableStatement).SchemaObjectName),
                        asEdge: (fragment as ScriptDom.CreateTableStatement).AsEdge,
                        asFileTable: (fragment as ScriptDom.CreateTableStatement).AsFileTable,
                        asNode: (fragment as ScriptDom.CreateTableStatement).AsNode,
                        definition: (TableDefinition)FromMutable((fragment as ScriptDom.CreateTableStatement).Definition),
                        onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable((fragment as ScriptDom.CreateTableStatement).OnFileGroupOrPartitionScheme),
                        federationScheme: (FederationScheme)FromMutable((fragment as ScriptDom.CreateTableStatement).FederationScheme),
                        textImageOn: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.CreateTableStatement).TextImageOn),
                        options: (fragment as ScriptDom.CreateTableStatement).Options.SelectList(c => (TableOption)FromMutable(c)),
                        selectStatement: (SelectStatement)FromMutable((fragment as ScriptDom.CreateTableStatement).SelectStatement),
                        ctasColumns: (fragment as ScriptDom.CreateTableStatement).CtasColumns.SelectList(c => (Identifier)FromMutable(c)),
                        fileStreamOn: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.CreateTableStatement).FileStreamOn)
                    );
                }
                case 289: {
                    return new CreateTriggerStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateTriggerStatement).Name),
                        triggerObject: (TriggerObject)FromMutable((fragment as ScriptDom.CreateTriggerStatement).TriggerObject),
                        options: (fragment as ScriptDom.CreateTriggerStatement).Options.SelectList(c => (TriggerOption)FromMutable(c)),
                        triggerType: (fragment as ScriptDom.CreateTriggerStatement).TriggerType,
                        triggerActions: (fragment as ScriptDom.CreateTriggerStatement).TriggerActions.SelectList(c => (TriggerAction)FromMutable(c)),
                        withAppend: (fragment as ScriptDom.CreateTriggerStatement).WithAppend,
                        isNotForReplication: (fragment as ScriptDom.CreateTriggerStatement).IsNotForReplication,
                        statementList: (StatementList)FromMutable((fragment as ScriptDom.CreateTriggerStatement).StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable((fragment as ScriptDom.CreateTriggerStatement).MethodSpecifier)
                    );
                }
                case 290: {
                    return new CreateTypeTableStatement(
                        definition: (TableDefinition)FromMutable((fragment as ScriptDom.CreateTypeTableStatement).Definition),
                        options: (fragment as ScriptDom.CreateTypeTableStatement).Options.SelectList(c => (TableOption)FromMutable(c)),
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateTypeTableStatement).Name)
                    );
                }
                case 291: {
                    return new CreateTypeUddtStatement(
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.CreateTypeUddtStatement).DataType),
                        nullableConstraint: (NullableConstraintDefinition)FromMutable((fragment as ScriptDom.CreateTypeUddtStatement).NullableConstraint),
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateTypeUddtStatement).Name)
                    );
                }
                case 292: {
                    return new CreateTypeUdtStatement(
                        assemblyName: (AssemblyName)FromMutable((fragment as ScriptDom.CreateTypeUdtStatement).AssemblyName),
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateTypeUdtStatement).Name)
                    );
                }
                case 293: {
                    return new CreateUserStatement(
                        userLoginOption: (UserLoginOption)FromMutable((fragment as ScriptDom.CreateUserStatement).UserLoginOption),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateUserStatement).Name),
                        userOptions: (fragment as ScriptDom.CreateUserStatement).UserOptions.SelectList(c => (PrincipalOption)FromMutable(c))
                    );
                }
                case 294: {
                    return new CreateViewStatement(
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateViewStatement).SchemaObjectName),
                        columns: (fragment as ScriptDom.CreateViewStatement).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        viewOptions: (fragment as ScriptDom.CreateViewStatement).ViewOptions.SelectList(c => (ViewOption)FromMutable(c)),
                        selectStatement: (SelectStatement)FromMutable((fragment as ScriptDom.CreateViewStatement).SelectStatement),
                        withCheckOption: (fragment as ScriptDom.CreateViewStatement).WithCheckOption,
                        isMaterialized: (fragment as ScriptDom.CreateViewStatement).IsMaterialized
                    );
                }
                case 295: {
                    return new CreateWorkloadClassifierStatement(
                        classifierName: (Identifier)FromMutable((fragment as ScriptDom.CreateWorkloadClassifierStatement).ClassifierName),
                        options: (fragment as ScriptDom.CreateWorkloadClassifierStatement).Options.SelectList(c => (WorkloadClassifierOption)FromMutable(c))
                    );
                }
                case 296: {
                    return new CreateWorkloadGroupStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateWorkloadGroupStatement).Name),
                        workloadGroupParameters: (fragment as ScriptDom.CreateWorkloadGroupStatement).WorkloadGroupParameters.SelectList(c => (WorkloadGroupParameter)FromMutable(c)),
                        poolName: (Identifier)FromMutable((fragment as ScriptDom.CreateWorkloadGroupStatement).PoolName),
                        externalPoolName: (Identifier)FromMutable((fragment as ScriptDom.CreateWorkloadGroupStatement).ExternalPoolName)
                    );
                }
                case 297: {
                    return new CreateXmlIndexStatement(
                        primary: (fragment as ScriptDom.CreateXmlIndexStatement).Primary,
                        xmlColumn: (Identifier)FromMutable((fragment as ScriptDom.CreateXmlIndexStatement).XmlColumn),
                        secondaryXmlIndexName: (Identifier)FromMutable((fragment as ScriptDom.CreateXmlIndexStatement).SecondaryXmlIndexName),
                        secondaryXmlIndexType: (fragment as ScriptDom.CreateXmlIndexStatement).SecondaryXmlIndexType,
                        onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable((fragment as ScriptDom.CreateXmlIndexStatement).OnFileGroupOrPartitionScheme),
                        name: (Identifier)FromMutable((fragment as ScriptDom.CreateXmlIndexStatement).Name),
                        onName: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateXmlIndexStatement).OnName),
                        indexOptions: (fragment as ScriptDom.CreateXmlIndexStatement).IndexOptions.SelectList(c => (IndexOption)FromMutable(c))
                    );
                }
                case 298: {
                    return new CreateXmlSchemaCollectionStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.CreateXmlSchemaCollectionStatement).Name),
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.CreateXmlSchemaCollectionStatement).Expression)
                    );
                }
                case 299: {
                    return new CreationDispositionKeyOption(
                        isCreateNew: (fragment as ScriptDom.CreationDispositionKeyOption).IsCreateNew,
                        optionKind: (fragment as ScriptDom.CreationDispositionKeyOption).OptionKind
                    );
                }
                case 300: {
                    return new CryptoMechanism(
                        cryptoMechanismType: (fragment as ScriptDom.CryptoMechanism).CryptoMechanismType,
                        identifier: (Identifier)FromMutable((fragment as ScriptDom.CryptoMechanism).Identifier),
                        passwordOrSignature: (Literal)FromMutable((fragment as ScriptDom.CryptoMechanism).PasswordOrSignature)
                    );
                }
                case 301: {
                    return new CubeGroupingSpecification(
                        arguments: (fragment as ScriptDom.CubeGroupingSpecification).Arguments.SelectList(c => (GroupingSpecification)FromMutable(c))
                    );
                }
                case 302: {
                    return new CursorDefaultDatabaseOption(
                        isLocal: (fragment as ScriptDom.CursorDefaultDatabaseOption).IsLocal,
                        optionKind: (fragment as ScriptDom.CursorDefaultDatabaseOption).OptionKind
                    );
                }
                case 303: {
                    return new CursorDefinition(
                        options: (fragment as ScriptDom.CursorDefinition).Options.SelectList(c => (CursorOption)FromMutable(c)),
                        select: (SelectStatement)FromMutable((fragment as ScriptDom.CursorDefinition).Select)
                    );
                }
                case 304: {
                    return new CursorId(
                        isGlobal: (fragment as ScriptDom.CursorId).IsGlobal,
                        name: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.CursorId).Name)
                    );
                }
                case 305: {
                    return new CursorOption(
                        optionKind: (fragment as ScriptDom.CursorOption).OptionKind
                    );
                }
                case 306: {
                    return new DatabaseAuditAction(
                        actionKind: (fragment as ScriptDom.DatabaseAuditAction).ActionKind
                    );
                }
                case 307: {
                    return new DatabaseConfigurationClearOption(
                        optionKind: (fragment as ScriptDom.DatabaseConfigurationClearOption).OptionKind,
                        planHandle: (BinaryLiteral)FromMutable((fragment as ScriptDom.DatabaseConfigurationClearOption).PlanHandle)
                    );
                }
                case 308: {
                    return new DatabaseConfigurationSetOption(
                        optionKind: (fragment as ScriptDom.DatabaseConfigurationSetOption).OptionKind,
                        genericOptionKind: (Identifier)FromMutable((fragment as ScriptDom.DatabaseConfigurationSetOption).GenericOptionKind)
                    );
                }
                case 309: {
                    return new DatabaseOption(
                        optionKind: (fragment as ScriptDom.DatabaseOption).OptionKind
                    );
                }
                case 310: {
                    return new DataCompressionOption(
                        compressionLevel: (fragment as ScriptDom.DataCompressionOption).CompressionLevel,
                        partitionRanges: (fragment as ScriptDom.DataCompressionOption).PartitionRanges.SelectList(c => (CompressionPartitionRange)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.DataCompressionOption).OptionKind
                    );
                }
                case 311: {
                    return new DataModificationTableReference(
                        dataModificationSpecification: (DataModificationSpecification)FromMutable((fragment as ScriptDom.DataModificationTableReference).DataModificationSpecification),
                        columns: (fragment as ScriptDom.DataModificationTableReference).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.DataModificationTableReference).Alias),
                        forPath: (fragment as ScriptDom.DataModificationTableReference).ForPath
                    );
                }
                case 312: {
                    return new DataRetentionTableOption(
                        optionState: (fragment as ScriptDom.DataRetentionTableOption).OptionState,
                        filterColumn: (Identifier)FromMutable((fragment as ScriptDom.DataRetentionTableOption).FilterColumn),
                        retentionPeriod: (RetentionPeriodDefinition)FromMutable((fragment as ScriptDom.DataRetentionTableOption).RetentionPeriod),
                        optionKind: (fragment as ScriptDom.DataRetentionTableOption).OptionKind
                    );
                }
                case 313: {
                    return new DataTypeSequenceOption(
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.DataTypeSequenceOption).DataType),
                        optionKind: (fragment as ScriptDom.DataTypeSequenceOption).OptionKind,
                        noValue: (fragment as ScriptDom.DataTypeSequenceOption).NoValue
                    );
                }
                case 314: {
                    return new DbccNamedLiteral(
                        name: (fragment as ScriptDom.DbccNamedLiteral).Name,
                        @value: (ScalarExpression)FromMutable((fragment as ScriptDom.DbccNamedLiteral).Value)
                    );
                }
                case 315: {
                    return new DbccOption(
                        optionKind: (fragment as ScriptDom.DbccOption).OptionKind
                    );
                }
                case 316: {
                    return new DbccStatement(
                        dllName: (fragment as ScriptDom.DbccStatement).DllName,
                        command: (fragment as ScriptDom.DbccStatement).Command,
                        parenthesisRequired: (fragment as ScriptDom.DbccStatement).ParenthesisRequired,
                        literals: (fragment as ScriptDom.DbccStatement).Literals.SelectList(c => (DbccNamedLiteral)FromMutable(c)),
                        options: (fragment as ScriptDom.DbccStatement).Options.SelectList(c => (DbccOption)FromMutable(c)),
                        optionsUseJoin: (fragment as ScriptDom.DbccStatement).OptionsUseJoin
                    );
                }
                case 317: {
                    return new DeallocateCursorStatement(
                        cursor: (CursorId)FromMutable((fragment as ScriptDom.DeallocateCursorStatement).Cursor)
                    );
                }
                case 318: {
                    return new DeclareCursorStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DeclareCursorStatement).Name),
                        cursorDefinition: (CursorDefinition)FromMutable((fragment as ScriptDom.DeclareCursorStatement).CursorDefinition)
                    );
                }
                case 319: {
                    return new DeclareTableVariableBody(
                        variableName: (Identifier)FromMutable((fragment as ScriptDom.DeclareTableVariableBody).VariableName),
                        asDefined: (fragment as ScriptDom.DeclareTableVariableBody).AsDefined,
                        definition: (TableDefinition)FromMutable((fragment as ScriptDom.DeclareTableVariableBody).Definition)
                    );
                }
                case 320: {
                    return new DeclareTableVariableStatement(
                        body: (DeclareTableVariableBody)FromMutable((fragment as ScriptDom.DeclareTableVariableStatement).Body)
                    );
                }
                case 321: {
                    return new DeclareVariableElement(
                        variableName: (Identifier)FromMutable((fragment as ScriptDom.DeclareVariableElement).VariableName),
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.DeclareVariableElement).DataType),
                        nullable: (NullableConstraintDefinition)FromMutable((fragment as ScriptDom.DeclareVariableElement).Nullable),
                        @value: (ScalarExpression)FromMutable((fragment as ScriptDom.DeclareVariableElement).Value)
                    );
                }
                case 322: {
                    return new DeclareVariableStatement(
                        declarations: (fragment as ScriptDom.DeclareVariableStatement).Declarations.SelectList(c => (DeclareVariableElement)FromMutable(c))
                    );
                }
                case 323: {
                    return new DefaultConstraintDefinition(
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.DefaultConstraintDefinition).Expression),
                        withValues: (fragment as ScriptDom.DefaultConstraintDefinition).WithValues,
                        column: (Identifier)FromMutable((fragment as ScriptDom.DefaultConstraintDefinition).Column),
                        constraintIdentifier: (Identifier)FromMutable((fragment as ScriptDom.DefaultConstraintDefinition).ConstraintIdentifier)
                    );
                }
                case 324: {
                    return new DefaultLiteral(
                        @value: (fragment as ScriptDom.DefaultLiteral).Value,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.DefaultLiteral).Collation)
                    );
                }
                case 325: {
                    return new DelayedDurabilityDatabaseOption(
                        @value: (fragment as ScriptDom.DelayedDurabilityDatabaseOption).Value,
                        optionKind: (fragment as ScriptDom.DelayedDurabilityDatabaseOption).OptionKind
                    );
                }
                case 326: {
                    return new DeleteMergeAction(
                        
                    );
                }
                case 327: {
                    return new DeleteSpecification(
                        fromClause: (FromClause)FromMutable((fragment as ScriptDom.DeleteSpecification).FromClause),
                        whereClause: (WhereClause)FromMutable((fragment as ScriptDom.DeleteSpecification).WhereClause),
                        target: (TableReference)FromMutable((fragment as ScriptDom.DeleteSpecification).Target),
                        topRowFilter: (TopRowFilter)FromMutable((fragment as ScriptDom.DeleteSpecification).TopRowFilter),
                        outputIntoClause: (OutputIntoClause)FromMutable((fragment as ScriptDom.DeleteSpecification).OutputIntoClause),
                        outputClause: (OutputClause)FromMutable((fragment as ScriptDom.DeleteSpecification).OutputClause)
                    );
                }
                case 328: {
                    return new DeleteStatement(
                        deleteSpecification: (DeleteSpecification)FromMutable((fragment as ScriptDom.DeleteStatement).DeleteSpecification),
                        withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable((fragment as ScriptDom.DeleteStatement).WithCtesAndXmlNamespaces),
                        optimizerHints: (fragment as ScriptDom.DeleteStatement).OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 329: {
                    return new DenyStatement(
                        cascadeOption: (fragment as ScriptDom.DenyStatement).CascadeOption,
                        permissions: (fragment as ScriptDom.DenyStatement).Permissions.SelectList(c => (Permission)FromMutable(c)),
                        securityTargetObject: (SecurityTargetObject)FromMutable((fragment as ScriptDom.DenyStatement).SecurityTargetObject),
                        principals: (fragment as ScriptDom.DenyStatement).Principals.SelectList(c => (SecurityPrincipal)FromMutable(c)),
                        asClause: (Identifier)FromMutable((fragment as ScriptDom.DenyStatement).AsClause)
                    );
                }
                case 330: {
                    return new DenyStatement80(
                        cascadeOption: (fragment as ScriptDom.DenyStatement80).CascadeOption,
                        securityElement80: (SecurityElement80)FromMutable((fragment as ScriptDom.DenyStatement80).SecurityElement80),
                        securityUserClause80: (SecurityUserClause80)FromMutable((fragment as ScriptDom.DenyStatement80).SecurityUserClause80)
                    );
                }
                case 331: {
                    return new DeviceInfo(
                        logicalDevice: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.DeviceInfo).LogicalDevice),
                        physicalDevice: (ValueExpression)FromMutable((fragment as ScriptDom.DeviceInfo).PhysicalDevice),
                        deviceType: (fragment as ScriptDom.DeviceInfo).DeviceType
                    );
                }
                case 332: {
                    return new DiskStatement(
                        diskStatementType: (fragment as ScriptDom.DiskStatement).DiskStatementType,
                        options: (fragment as ScriptDom.DiskStatement).Options.SelectList(c => (DiskStatementOption)FromMutable(c))
                    );
                }
                case 333: {
                    return new DiskStatementOption(
                        optionKind: (fragment as ScriptDom.DiskStatementOption).OptionKind,
                        @value: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.DiskStatementOption).Value)
                    );
                }
                case 334: {
                    return new DistinctPredicate(
                        firstExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.DistinctPredicate).FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.DistinctPredicate).SecondExpression),
                        isNot: (fragment as ScriptDom.DistinctPredicate).IsNot
                    );
                }
                case 335: {
                    return new DropAggregateStatement(
                        objects: (fragment as ScriptDom.DropAggregateStatement).Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropAggregateStatement).IsIfExists
                    );
                }
                case 336: {
                    return new DropAlterFullTextIndexAction(
                        columns: (fragment as ScriptDom.DropAlterFullTextIndexAction).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        withNoPopulation: (fragment as ScriptDom.DropAlterFullTextIndexAction).WithNoPopulation
                    );
                }
                case 337: {
                    return new DropApplicationRoleStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropApplicationRoleStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropApplicationRoleStatement).IsIfExists
                    );
                }
                case 338: {
                    return new DropAssemblyStatement(
                        withNoDependents: (fragment as ScriptDom.DropAssemblyStatement).WithNoDependents,
                        objects: (fragment as ScriptDom.DropAssemblyStatement).Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropAssemblyStatement).IsIfExists
                    );
                }
                case 339: {
                    return new DropAsymmetricKeyStatement(
                        removeProviderKey: (fragment as ScriptDom.DropAsymmetricKeyStatement).RemoveProviderKey,
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropAsymmetricKeyStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropAsymmetricKeyStatement).IsIfExists
                    );
                }
                case 340: {
                    return new DropAvailabilityGroupStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropAvailabilityGroupStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropAvailabilityGroupStatement).IsIfExists
                    );
                }
                case 341: {
                    return new DropBrokerPriorityStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropBrokerPriorityStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropBrokerPriorityStatement).IsIfExists
                    );
                }
                case 342: {
                    return new DropCertificateStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropCertificateStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropCertificateStatement).IsIfExists
                    );
                }
                case 343: {
                    return new DropClusteredConstraintMoveOption(
                        optionValue: (FileGroupOrPartitionScheme)FromMutable((fragment as ScriptDom.DropClusteredConstraintMoveOption).OptionValue),
                        optionKind: (fragment as ScriptDom.DropClusteredConstraintMoveOption).OptionKind
                    );
                }
                case 344: {
                    return new DropClusteredConstraintStateOption(
                        optionState: (fragment as ScriptDom.DropClusteredConstraintStateOption).OptionState,
                        optionKind: (fragment as ScriptDom.DropClusteredConstraintStateOption).OptionKind
                    );
                }
                case 345: {
                    return new DropClusteredConstraintValueOption(
                        optionValue: (Literal)FromMutable((fragment as ScriptDom.DropClusteredConstraintValueOption).OptionValue),
                        optionKind: (fragment as ScriptDom.DropClusteredConstraintValueOption).OptionKind
                    );
                }
                case 346: {
                    return new DropClusteredConstraintWaitAtLowPriorityLockOption(
                        options: (fragment as ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption).Options.SelectList(c => (LowPriorityLockWaitOption)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption).OptionKind
                    );
                }
                case 347: {
                    return new DropColumnEncryptionKeyStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropColumnEncryptionKeyStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropColumnEncryptionKeyStatement).IsIfExists
                    );
                }
                case 348: {
                    return new DropColumnMasterKeyStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropColumnMasterKeyStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropColumnMasterKeyStatement).IsIfExists
                    );
                }
                case 349: {
                    return new DropContractStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropContractStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropContractStatement).IsIfExists
                    );
                }
                case 350: {
                    return new DropCredentialStatement(
                        isDatabaseScoped: (fragment as ScriptDom.DropCredentialStatement).IsDatabaseScoped,
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropCredentialStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropCredentialStatement).IsIfExists
                    );
                }
                case 351: {
                    return new DropCryptographicProviderStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropCryptographicProviderStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropCryptographicProviderStatement).IsIfExists
                    );
                }
                case 352: {
                    return new DropDatabaseAuditSpecificationStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropDatabaseAuditSpecificationStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropDatabaseAuditSpecificationStatement).IsIfExists
                    );
                }
                case 353: {
                    return new DropDatabaseEncryptionKeyStatement(
                        
                    );
                }
                case 354: {
                    return new DropDatabaseStatement(
                        databases: (fragment as ScriptDom.DropDatabaseStatement).Databases.SelectList(c => (Identifier)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropDatabaseStatement).IsIfExists
                    );
                }
                case 355: {
                    return new DropDefaultStatement(
                        objects: (fragment as ScriptDom.DropDefaultStatement).Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropDefaultStatement).IsIfExists
                    );
                }
                case 356: {
                    return new DropEndpointStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropEndpointStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropEndpointStatement).IsIfExists
                    );
                }
                case 357: {
                    return new DropEventNotificationStatement(
                        notifications: (fragment as ScriptDom.DropEventNotificationStatement).Notifications.SelectList(c => (Identifier)FromMutable(c)),
                        scope: (EventNotificationObjectScope)FromMutable((fragment as ScriptDom.DropEventNotificationStatement).Scope)
                    );
                }
                case 358: {
                    return new DropEventSessionStatement(
                        sessionScope: (fragment as ScriptDom.DropEventSessionStatement).SessionScope,
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropEventSessionStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropEventSessionStatement).IsIfExists
                    );
                }
                case 359: {
                    return new DropExternalDataSourceStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropExternalDataSourceStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropExternalDataSourceStatement).IsIfExists
                    );
                }
                case 360: {
                    return new DropExternalFileFormatStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropExternalFileFormatStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropExternalFileFormatStatement).IsIfExists
                    );
                }
                case 361: {
                    return new DropExternalLanguageStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropExternalLanguageStatement).Name),
                        owner: (Identifier)FromMutable((fragment as ScriptDom.DropExternalLanguageStatement).Owner)
                    );
                }
                case 362: {
                    return new DropExternalLibraryStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropExternalLibraryStatement).Name),
                        owner: (Identifier)FromMutable((fragment as ScriptDom.DropExternalLibraryStatement).Owner)
                    );
                }
                case 363: {
                    return new DropExternalResourcePoolStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropExternalResourcePoolStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropExternalResourcePoolStatement).IsIfExists
                    );
                }
                case 364: {
                    return new DropExternalStreamingJobStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropExternalStreamingJobStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropExternalStreamingJobStatement).IsIfExists
                    );
                }
                case 365: {
                    return new DropExternalStreamStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropExternalStreamStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropExternalStreamStatement).IsIfExists
                    );
                }
                case 366: {
                    return new DropExternalTableStatement(
                        objects: (fragment as ScriptDom.DropExternalTableStatement).Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropExternalTableStatement).IsIfExists
                    );
                }
                case 367: {
                    return new DropFederationStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropFederationStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropFederationStatement).IsIfExists
                    );
                }
                case 368: {
                    return new DropFullTextCatalogStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropFullTextCatalogStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropFullTextCatalogStatement).IsIfExists
                    );
                }
                case 369: {
                    return new DropFullTextIndexStatement(
                        tableName: (SchemaObjectName)FromMutable((fragment as ScriptDom.DropFullTextIndexStatement).TableName)
                    );
                }
                case 370: {
                    return new DropFullTextStopListStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropFullTextStopListStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropFullTextStopListStatement).IsIfExists
                    );
                }
                case 371: {
                    return new DropFunctionStatement(
                        objects: (fragment as ScriptDom.DropFunctionStatement).Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropFunctionStatement).IsIfExists
                    );
                }
                case 372: {
                    return new DropIndexClause(
                        index: (Identifier)FromMutable((fragment as ScriptDom.DropIndexClause).Index),
                        @object: (SchemaObjectName)FromMutable((fragment as ScriptDom.DropIndexClause).Object),
                        options: (fragment as ScriptDom.DropIndexClause).Options.SelectList(c => (IndexOption)FromMutable(c))
                    );
                }
                case 373: {
                    return new DropIndexStatement(
                        dropIndexClauses: (fragment as ScriptDom.DropIndexStatement).DropIndexClauses.SelectList(c => (DropIndexClauseBase)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropIndexStatement).IsIfExists
                    );
                }
                case 374: {
                    return new DropLoginStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropLoginStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropLoginStatement).IsIfExists
                    );
                }
                case 375: {
                    return new DropMasterKeyStatement(
                        
                    );
                }
                case 376: {
                    return new DropMemberAlterRoleAction(
                        member: (Identifier)FromMutable((fragment as ScriptDom.DropMemberAlterRoleAction).Member)
                    );
                }
                case 377: {
                    return new DropMessageTypeStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropMessageTypeStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropMessageTypeStatement).IsIfExists
                    );
                }
                case 378: {
                    return new DropPartitionFunctionStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropPartitionFunctionStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropPartitionFunctionStatement).IsIfExists
                    );
                }
                case 379: {
                    return new DropPartitionSchemeStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropPartitionSchemeStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropPartitionSchemeStatement).IsIfExists
                    );
                }
                case 380: {
                    return new DropProcedureStatement(
                        objects: (fragment as ScriptDom.DropProcedureStatement).Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropProcedureStatement).IsIfExists
                    );
                }
                case 381: {
                    return new DropQueueStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.DropQueueStatement).Name)
                    );
                }
                case 382: {
                    return new DropRemoteServiceBindingStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropRemoteServiceBindingStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropRemoteServiceBindingStatement).IsIfExists
                    );
                }
                case 383: {
                    return new DropResourcePoolStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropResourcePoolStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropResourcePoolStatement).IsIfExists
                    );
                }
                case 384: {
                    return new DropRoleStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropRoleStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropRoleStatement).IsIfExists
                    );
                }
                case 385: {
                    return new DropRouteStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropRouteStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropRouteStatement).IsIfExists
                    );
                }
                case 386: {
                    return new DropRuleStatement(
                        objects: (fragment as ScriptDom.DropRuleStatement).Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropRuleStatement).IsIfExists
                    );
                }
                case 387: {
                    return new DropSchemaStatement(
                        schema: (SchemaObjectName)FromMutable((fragment as ScriptDom.DropSchemaStatement).Schema),
                        dropBehavior: (fragment as ScriptDom.DropSchemaStatement).DropBehavior,
                        isIfExists: (fragment as ScriptDom.DropSchemaStatement).IsIfExists
                    );
                }
                case 388: {
                    return new DropSearchPropertyListAction(
                        propertyName: (StringLiteral)FromMutable((fragment as ScriptDom.DropSearchPropertyListAction).PropertyName)
                    );
                }
                case 389: {
                    return new DropSearchPropertyListStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropSearchPropertyListStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropSearchPropertyListStatement).IsIfExists
                    );
                }
                case 390: {
                    return new DropSecurityPolicyStatement(
                        objects: (fragment as ScriptDom.DropSecurityPolicyStatement).Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropSecurityPolicyStatement).IsIfExists
                    );
                }
                case 391: {
                    return new DropSensitivityClassificationStatement(
                        columns: (fragment as ScriptDom.DropSensitivityClassificationStatement).Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
                    );
                }
                case 392: {
                    return new DropSequenceStatement(
                        objects: (fragment as ScriptDom.DropSequenceStatement).Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropSequenceStatement).IsIfExists
                    );
                }
                case 393: {
                    return new DropServerAuditSpecificationStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropServerAuditSpecificationStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropServerAuditSpecificationStatement).IsIfExists
                    );
                }
                case 394: {
                    return new DropServerAuditStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropServerAuditStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropServerAuditStatement).IsIfExists
                    );
                }
                case 395: {
                    return new DropServerRoleStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropServerRoleStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropServerRoleStatement).IsIfExists
                    );
                }
                case 396: {
                    return new DropServiceStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropServiceStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropServiceStatement).IsIfExists
                    );
                }
                case 397: {
                    return new DropSignatureStatement(
                        isCounter: (fragment as ScriptDom.DropSignatureStatement).IsCounter,
                        elementKind: (fragment as ScriptDom.DropSignatureStatement).ElementKind,
                        element: (SchemaObjectName)FromMutable((fragment as ScriptDom.DropSignatureStatement).Element),
                        cryptos: (fragment as ScriptDom.DropSignatureStatement).Cryptos.SelectList(c => (CryptoMechanism)FromMutable(c))
                    );
                }
                case 398: {
                    return new DropStatisticsStatement(
                        objects: (fragment as ScriptDom.DropStatisticsStatement).Objects.SelectList(c => (ChildObjectName)FromMutable(c))
                    );
                }
                case 399: {
                    return new DropSymmetricKeyStatement(
                        removeProviderKey: (fragment as ScriptDom.DropSymmetricKeyStatement).RemoveProviderKey,
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropSymmetricKeyStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropSymmetricKeyStatement).IsIfExists
                    );
                }
                case 400: {
                    return new DropSynonymStatement(
                        objects: (fragment as ScriptDom.DropSynonymStatement).Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropSynonymStatement).IsIfExists
                    );
                }
                case 401: {
                    return new DropTableStatement(
                        objects: (fragment as ScriptDom.DropTableStatement).Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropTableStatement).IsIfExists
                    );
                }
                case 402: {
                    return new DropTriggerStatement(
                        triggerScope: (fragment as ScriptDom.DropTriggerStatement).TriggerScope,
                        objects: (fragment as ScriptDom.DropTriggerStatement).Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropTriggerStatement).IsIfExists
                    );
                }
                case 403: {
                    return new DropTypeStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.DropTypeStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropTypeStatement).IsIfExists
                    );
                }
                case 404: {
                    return new DropUserStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropUserStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropUserStatement).IsIfExists
                    );
                }
                case 405: {
                    return new DropViewStatement(
                        objects: (fragment as ScriptDom.DropViewStatement).Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: (fragment as ScriptDom.DropViewStatement).IsIfExists
                    );
                }
                case 406: {
                    return new DropWorkloadClassifierStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropWorkloadClassifierStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropWorkloadClassifierStatement).IsIfExists
                    );
                }
                case 407: {
                    return new DropWorkloadGroupStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.DropWorkloadGroupStatement).Name),
                        isIfExists: (fragment as ScriptDom.DropWorkloadGroupStatement).IsIfExists
                    );
                }
                case 408: {
                    return new DropXmlSchemaCollectionStatement(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.DropXmlSchemaCollectionStatement).Name)
                    );
                }
                case 409: {
                    return new DurabilityTableOption(
                        durabilityTableOptionKind: (fragment as ScriptDom.DurabilityTableOption).DurabilityTableOptionKind,
                        optionKind: (fragment as ScriptDom.DurabilityTableOption).OptionKind
                    );
                }
                case 410: {
                    return new EnabledDisabledPayloadOption(
                        isEnabled: (fragment as ScriptDom.EnabledDisabledPayloadOption).IsEnabled,
                        kind: (fragment as ScriptDom.EnabledDisabledPayloadOption).Kind
                    );
                }
                case 411: {
                    return new EnableDisableTriggerStatement(
                        triggerEnforcement: (fragment as ScriptDom.EnableDisableTriggerStatement).TriggerEnforcement,
                        all: (fragment as ScriptDom.EnableDisableTriggerStatement).All,
                        triggerNames: (fragment as ScriptDom.EnableDisableTriggerStatement).TriggerNames.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        triggerObject: (TriggerObject)FromMutable((fragment as ScriptDom.EnableDisableTriggerStatement).TriggerObject)
                    );
                }
                case 412: {
                    return new EncryptedValueParameter(
                        @value: (BinaryLiteral)FromMutable((fragment as ScriptDom.EncryptedValueParameter).Value),
                        parameterKind: (fragment as ScriptDom.EncryptedValueParameter).ParameterKind
                    );
                }
                case 413: {
                    return new EncryptionPayloadOption(
                        encryptionSupport: (fragment as ScriptDom.EncryptionPayloadOption).EncryptionSupport,
                        algorithmPartOne: (fragment as ScriptDom.EncryptionPayloadOption).AlgorithmPartOne,
                        algorithmPartTwo: (fragment as ScriptDom.EncryptionPayloadOption).AlgorithmPartTwo,
                        kind: (fragment as ScriptDom.EncryptionPayloadOption).Kind
                    );
                }
                case 414: {
                    return new EndConversationStatement(
                        conversation: (ScalarExpression)FromMutable((fragment as ScriptDom.EndConversationStatement).Conversation),
                        withCleanup: (fragment as ScriptDom.EndConversationStatement).WithCleanup,
                        errorCode: (ValueExpression)FromMutable((fragment as ScriptDom.EndConversationStatement).ErrorCode),
                        errorDescription: (ValueExpression)FromMutable((fragment as ScriptDom.EndConversationStatement).ErrorDescription)
                    );
                }
                case 415: {
                    return new EndpointAffinity(
                        kind: (fragment as ScriptDom.EndpointAffinity).Kind,
                        @value: (Literal)FromMutable((fragment as ScriptDom.EndpointAffinity).Value)
                    );
                }
                case 416: {
                    return new EventDeclaration(
                        objectName: (EventSessionObjectName)FromMutable((fragment as ScriptDom.EventDeclaration).ObjectName),
                        eventDeclarationSetParameters: (fragment as ScriptDom.EventDeclaration).EventDeclarationSetParameters.SelectList(c => (EventDeclarationSetParameter)FromMutable(c)),
                        eventDeclarationActionParameters: (fragment as ScriptDom.EventDeclaration).EventDeclarationActionParameters.SelectList(c => (EventSessionObjectName)FromMutable(c)),
                        eventDeclarationPredicateParameter: (BooleanExpression)FromMutable((fragment as ScriptDom.EventDeclaration).EventDeclarationPredicateParameter)
                    );
                }
                case 417: {
                    return new EventDeclarationCompareFunctionParameter(
                        name: (EventSessionObjectName)FromMutable((fragment as ScriptDom.EventDeclarationCompareFunctionParameter).Name),
                        sourceDeclaration: (SourceDeclaration)FromMutable((fragment as ScriptDom.EventDeclarationCompareFunctionParameter).SourceDeclaration),
                        eventValue: (ScalarExpression)FromMutable((fragment as ScriptDom.EventDeclarationCompareFunctionParameter).EventValue)
                    );
                }
                case 418: {
                    return new EventDeclarationSetParameter(
                        eventField: (Identifier)FromMutable((fragment as ScriptDom.EventDeclarationSetParameter).EventField),
                        eventValue: (ScalarExpression)FromMutable((fragment as ScriptDom.EventDeclarationSetParameter).EventValue)
                    );
                }
                case 419: {
                    return new EventGroupContainer(
                        eventGroup: (fragment as ScriptDom.EventGroupContainer).EventGroup
                    );
                }
                case 420: {
                    return new EventNotificationObjectScope(
                        target: (fragment as ScriptDom.EventNotificationObjectScope).Target,
                        queueName: (SchemaObjectName)FromMutable((fragment as ScriptDom.EventNotificationObjectScope).QueueName)
                    );
                }
                case 421: {
                    return new EventRetentionSessionOption(
                        @value: (fragment as ScriptDom.EventRetentionSessionOption).Value,
                        optionKind: (fragment as ScriptDom.EventRetentionSessionOption).OptionKind
                    );
                }
                case 422: {
                    return new EventSessionObjectName(
                        multiPartIdentifier: (MultiPartIdentifier)FromMutable((fragment as ScriptDom.EventSessionObjectName).MultiPartIdentifier)
                    );
                }
                case 423: {
                    return new EventSessionStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.EventSessionStatement).Name),
                        sessionScope: (fragment as ScriptDom.EventSessionStatement).SessionScope,
                        eventDeclarations: (fragment as ScriptDom.EventSessionStatement).EventDeclarations.SelectList(c => (EventDeclaration)FromMutable(c)),
                        targetDeclarations: (fragment as ScriptDom.EventSessionStatement).TargetDeclarations.SelectList(c => (TargetDeclaration)FromMutable(c)),
                        sessionOptions: (fragment as ScriptDom.EventSessionStatement).SessionOptions.SelectList(c => (SessionOption)FromMutable(c))
                    );
                }
                case 424: {
                    return new EventTypeContainer(
                        eventType: (fragment as ScriptDom.EventTypeContainer).EventType
                    );
                }
                case 425: {
                    return new ExecutableProcedureReference(
                        procedureReference: (ProcedureReferenceName)FromMutable((fragment as ScriptDom.ExecutableProcedureReference).ProcedureReference),
                        adHocDataSource: (AdHocDataSource)FromMutable((fragment as ScriptDom.ExecutableProcedureReference).AdHocDataSource),
                        parameters: (fragment as ScriptDom.ExecutableProcedureReference).Parameters.SelectList(c => (ExecuteParameter)FromMutable(c))
                    );
                }
                case 426: {
                    return new ExecutableStringList(
                        strings: (fragment as ScriptDom.ExecutableStringList).Strings.SelectList(c => (ValueExpression)FromMutable(c)),
                        parameters: (fragment as ScriptDom.ExecutableStringList).Parameters.SelectList(c => (ExecuteParameter)FromMutable(c))
                    );
                }
                case 427: {
                    return new ExecuteAsClause(
                        executeAsOption: (fragment as ScriptDom.ExecuteAsClause).ExecuteAsOption,
                        literal: (Literal)FromMutable((fragment as ScriptDom.ExecuteAsClause).Literal)
                    );
                }
                case 428: {
                    return new ExecuteAsFunctionOption(
                        executeAs: (ExecuteAsClause)FromMutable((fragment as ScriptDom.ExecuteAsFunctionOption).ExecuteAs),
                        optionKind: (fragment as ScriptDom.ExecuteAsFunctionOption).OptionKind
                    );
                }
                case 429: {
                    return new ExecuteAsProcedureOption(
                        executeAs: (ExecuteAsClause)FromMutable((fragment as ScriptDom.ExecuteAsProcedureOption).ExecuteAs),
                        optionKind: (fragment as ScriptDom.ExecuteAsProcedureOption).OptionKind
                    );
                }
                case 430: {
                    return new ExecuteAsStatement(
                        withNoRevert: (fragment as ScriptDom.ExecuteAsStatement).WithNoRevert,
                        cookie: (VariableReference)FromMutable((fragment as ScriptDom.ExecuteAsStatement).Cookie),
                        executeContext: (ExecuteContext)FromMutable((fragment as ScriptDom.ExecuteAsStatement).ExecuteContext)
                    );
                }
                case 431: {
                    return new ExecuteAsTriggerOption(
                        executeAsClause: (ExecuteAsClause)FromMutable((fragment as ScriptDom.ExecuteAsTriggerOption).ExecuteAsClause),
                        optionKind: (fragment as ScriptDom.ExecuteAsTriggerOption).OptionKind
                    );
                }
                case 432: {
                    return new ExecuteContext(
                        principal: (ScalarExpression)FromMutable((fragment as ScriptDom.ExecuteContext).Principal),
                        kind: (fragment as ScriptDom.ExecuteContext).Kind
                    );
                }
                case 433: {
                    return new ExecuteInsertSource(
                        execute: (ExecuteSpecification)FromMutable((fragment as ScriptDom.ExecuteInsertSource).Execute)
                    );
                }
                case 434: {
                    return new ExecuteOption(
                        optionKind: (fragment as ScriptDom.ExecuteOption).OptionKind
                    );
                }
                case 435: {
                    return new ExecuteParameter(
                        variable: (VariableReference)FromMutable((fragment as ScriptDom.ExecuteParameter).Variable),
                        parameterValue: (ScalarExpression)FromMutable((fragment as ScriptDom.ExecuteParameter).ParameterValue),
                        isOutput: (fragment as ScriptDom.ExecuteParameter).IsOutput
                    );
                }
                case 436: {
                    return new ExecuteSpecification(
                        variable: (VariableReference)FromMutable((fragment as ScriptDom.ExecuteSpecification).Variable),
                        linkedServer: (Identifier)FromMutable((fragment as ScriptDom.ExecuteSpecification).LinkedServer),
                        executeContext: (ExecuteContext)FromMutable((fragment as ScriptDom.ExecuteSpecification).ExecuteContext),
                        executableEntity: (ExecutableEntity)FromMutable((fragment as ScriptDom.ExecuteSpecification).ExecutableEntity)
                    );
                }
                case 437: {
                    return new ExecuteStatement(
                        executeSpecification: (ExecuteSpecification)FromMutable((fragment as ScriptDom.ExecuteStatement).ExecuteSpecification),
                        options: (fragment as ScriptDom.ExecuteStatement).Options.SelectList(c => (ExecuteOption)FromMutable(c))
                    );
                }
                case 438: {
                    return new ExistsPredicate(
                        subquery: (ScalarSubquery)FromMutable((fragment as ScriptDom.ExistsPredicate).Subquery)
                    );
                }
                case 439: {
                    return new ExpressionCallTarget(
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.ExpressionCallTarget).Expression)
                    );
                }
                case 440: {
                    return new ExpressionGroupingSpecification(
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.ExpressionGroupingSpecification).Expression),
                        distributedAggregation: (fragment as ScriptDom.ExpressionGroupingSpecification).DistributedAggregation
                    );
                }
                case 441: {
                    return new ExpressionWithSortOrder(
                        sortOrder: (fragment as ScriptDom.ExpressionWithSortOrder).SortOrder,
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.ExpressionWithSortOrder).Expression)
                    );
                }
                case 442: {
                    return new ExternalCreateLoginSource(
                        options: (fragment as ScriptDom.ExternalCreateLoginSource).Options.SelectList(c => (PrincipalOption)FromMutable(c))
                    );
                }
                case 443: {
                    return new ExternalDataSourceLiteralOrIdentifierOption(
                        @value: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.ExternalDataSourceLiteralOrIdentifierOption).Value),
                        optionKind: (fragment as ScriptDom.ExternalDataSourceLiteralOrIdentifierOption).OptionKind
                    );
                }
                case 444: {
                    return new ExternalFileFormatContainerOption(
                        suboptions: (fragment as ScriptDom.ExternalFileFormatContainerOption).Suboptions.SelectList(c => (ExternalFileFormatOption)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.ExternalFileFormatContainerOption).OptionKind
                    );
                }
                case 445: {
                    return new ExternalFileFormatLiteralOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.ExternalFileFormatLiteralOption).Value),
                        optionKind: (fragment as ScriptDom.ExternalFileFormatLiteralOption).OptionKind
                    );
                }
                case 446: {
                    return new ExternalFileFormatUseDefaultTypeOption(
                        externalFileFormatUseDefaultType: (fragment as ScriptDom.ExternalFileFormatUseDefaultTypeOption).ExternalFileFormatUseDefaultType,
                        optionKind: (fragment as ScriptDom.ExternalFileFormatUseDefaultTypeOption).OptionKind
                    );
                }
                case 447: {
                    return new ExternalLanguageFileOption(
                        content: (ScalarExpression)FromMutable((fragment as ScriptDom.ExternalLanguageFileOption).Content),
                        fileName: (StringLiteral)FromMutable((fragment as ScriptDom.ExternalLanguageFileOption).FileName),
                        path: (StringLiteral)FromMutable((fragment as ScriptDom.ExternalLanguageFileOption).Path),
                        platform: (Identifier)FromMutable((fragment as ScriptDom.ExternalLanguageFileOption).Platform),
                        parameters: (StringLiteral)FromMutable((fragment as ScriptDom.ExternalLanguageFileOption).Parameters),
                        environmentVariables: (StringLiteral)FromMutable((fragment as ScriptDom.ExternalLanguageFileOption).EnvironmentVariables)
                    );
                }
                case 448: {
                    return new ExternalLibraryFileOption(
                        content: (ScalarExpression)FromMutable((fragment as ScriptDom.ExternalLibraryFileOption).Content),
                        path: (StringLiteral)FromMutable((fragment as ScriptDom.ExternalLibraryFileOption).Path),
                        platform: (Identifier)FromMutable((fragment as ScriptDom.ExternalLibraryFileOption).Platform)
                    );
                }
                case 449: {
                    return new ExternalResourcePoolAffinitySpecification(
                        affinityType: (fragment as ScriptDom.ExternalResourcePoolAffinitySpecification).AffinityType,
                        parameterValue: (Literal)FromMutable((fragment as ScriptDom.ExternalResourcePoolAffinitySpecification).ParameterValue),
                        isAuto: (fragment as ScriptDom.ExternalResourcePoolAffinitySpecification).IsAuto,
                        poolAffinityRanges: (fragment as ScriptDom.ExternalResourcePoolAffinitySpecification).PoolAffinityRanges.SelectList(c => (LiteralRange)FromMutable(c))
                    );
                }
                case 450: {
                    return new ExternalResourcePoolParameter(
                        parameterType: (fragment as ScriptDom.ExternalResourcePoolParameter).ParameterType,
                        parameterValue: (Literal)FromMutable((fragment as ScriptDom.ExternalResourcePoolParameter).ParameterValue),
                        affinitySpecification: (ExternalResourcePoolAffinitySpecification)FromMutable((fragment as ScriptDom.ExternalResourcePoolParameter).AffinitySpecification)
                    );
                }
                case 451: {
                    return new ExternalResourcePoolStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.ExternalResourcePoolStatement).Name),
                        externalResourcePoolParameters: (fragment as ScriptDom.ExternalResourcePoolStatement).ExternalResourcePoolParameters.SelectList(c => (ExternalResourcePoolParameter)FromMutable(c))
                    );
                }
                case 452: {
                    return new ExternalStreamLiteralOrIdentifierOption(
                        @value: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.ExternalStreamLiteralOrIdentifierOption).Value),
                        optionKind: (fragment as ScriptDom.ExternalStreamLiteralOrIdentifierOption).OptionKind
                    );
                }
                case 453: {
                    return new ExternalTableColumnDefinition(
                        columnDefinition: (ColumnDefinitionBase)FromMutable((fragment as ScriptDom.ExternalTableColumnDefinition).ColumnDefinition),
                        nullableConstraint: (NullableConstraintDefinition)FromMutable((fragment as ScriptDom.ExternalTableColumnDefinition).NullableConstraint)
                    );
                }
                case 454: {
                    return new ExternalTableDistributionOption(
                        @value: (ExternalTableDistributionPolicy)FromMutable((fragment as ScriptDom.ExternalTableDistributionOption).Value),
                        optionKind: (fragment as ScriptDom.ExternalTableDistributionOption).OptionKind
                    );
                }
                case 455: {
                    return new ExternalTableLiteralOrIdentifierOption(
                        @value: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.ExternalTableLiteralOrIdentifierOption).Value),
                        optionKind: (fragment as ScriptDom.ExternalTableLiteralOrIdentifierOption).OptionKind
                    );
                }
                case 456: {
                    return new ExternalTableRejectTypeOption(
                        @value: (fragment as ScriptDom.ExternalTableRejectTypeOption).Value,
                        optionKind: (fragment as ScriptDom.ExternalTableRejectTypeOption).OptionKind
                    );
                }
                case 457: {
                    return new ExternalTableReplicatedDistributionPolicy(
                        
                    );
                }
                case 458: {
                    return new ExternalTableRoundRobinDistributionPolicy(
                        
                    );
                }
                case 459: {
                    return new ExternalTableShardedDistributionPolicy(
                        shardingColumn: (Identifier)FromMutable((fragment as ScriptDom.ExternalTableShardedDistributionPolicy).ShardingColumn)
                    );
                }
                case 460: {
                    return new ExtractFromExpression(
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.ExtractFromExpression).Expression),
                        extractedElement: (Identifier)FromMutable((fragment as ScriptDom.ExtractFromExpression).ExtractedElement)
                    );
                }
                case 461: {
                    return new FailoverModeReplicaOption(
                        @value: (fragment as ScriptDom.FailoverModeReplicaOption).Value,
                        optionKind: (fragment as ScriptDom.FailoverModeReplicaOption).OptionKind
                    );
                }
                case 462: {
                    return new FederationScheme(
                        distributionName: (Identifier)FromMutable((fragment as ScriptDom.FederationScheme).DistributionName),
                        columnName: (Identifier)FromMutable((fragment as ScriptDom.FederationScheme).ColumnName)
                    );
                }
                case 463: {
                    return new FetchCursorStatement(
                        fetchType: (FetchType)FromMutable((fragment as ScriptDom.FetchCursorStatement).FetchType),
                        intoVariables: (fragment as ScriptDom.FetchCursorStatement).IntoVariables.SelectList(c => (VariableReference)FromMutable(c)),
                        cursor: (CursorId)FromMutable((fragment as ScriptDom.FetchCursorStatement).Cursor)
                    );
                }
                case 464: {
                    return new FetchType(
                        orientation: (fragment as ScriptDom.FetchType).Orientation,
                        rowOffset: (ScalarExpression)FromMutable((fragment as ScriptDom.FetchType).RowOffset)
                    );
                }
                case 465: {
                    return new FileDeclaration(
                        options: (fragment as ScriptDom.FileDeclaration).Options.SelectList(c => (FileDeclarationOption)FromMutable(c)),
                        isPrimary: (fragment as ScriptDom.FileDeclaration).IsPrimary
                    );
                }
                case 466: {
                    return new FileDeclarationOption(
                        optionKind: (fragment as ScriptDom.FileDeclarationOption).OptionKind
                    );
                }
                case 467: {
                    return new FileEncryptionSource(
                        isExecutable: (fragment as ScriptDom.FileEncryptionSource).IsExecutable,
                        file: (Literal)FromMutable((fragment as ScriptDom.FileEncryptionSource).File)
                    );
                }
                case 468: {
                    return new FileGroupDefinition(
                        name: (Identifier)FromMutable((fragment as ScriptDom.FileGroupDefinition).Name),
                        fileDeclarations: (fragment as ScriptDom.FileGroupDefinition).FileDeclarations.SelectList(c => (FileDeclaration)FromMutable(c)),
                        isDefault: (fragment as ScriptDom.FileGroupDefinition).IsDefault,
                        containsFileStream: (fragment as ScriptDom.FileGroupDefinition).ContainsFileStream,
                        containsMemoryOptimizedData: (fragment as ScriptDom.FileGroupDefinition).ContainsMemoryOptimizedData
                    );
                }
                case 469: {
                    return new FileGroupOrPartitionScheme(
                        name: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.FileGroupOrPartitionScheme).Name),
                        partitionSchemeColumns: (fragment as ScriptDom.FileGroupOrPartitionScheme).PartitionSchemeColumns.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 470: {
                    return new FileGrowthFileDeclarationOption(
                        growthIncrement: (Literal)FromMutable((fragment as ScriptDom.FileGrowthFileDeclarationOption).GrowthIncrement),
                        units: (fragment as ScriptDom.FileGrowthFileDeclarationOption).Units,
                        optionKind: (fragment as ScriptDom.FileGrowthFileDeclarationOption).OptionKind
                    );
                }
                case 471: {
                    return new FileNameFileDeclarationOption(
                        oSFileName: (Literal)FromMutable((fragment as ScriptDom.FileNameFileDeclarationOption).OSFileName),
                        optionKind: (fragment as ScriptDom.FileNameFileDeclarationOption).OptionKind
                    );
                }
                case 472: {
                    return new FileStreamDatabaseOption(
                        nonTransactedAccess: (fragment as ScriptDom.FileStreamDatabaseOption).NonTransactedAccess,
                        directoryName: (Literal)FromMutable((fragment as ScriptDom.FileStreamDatabaseOption).DirectoryName),
                        optionKind: (fragment as ScriptDom.FileStreamDatabaseOption).OptionKind
                    );
                }
                case 473: {
                    return new FileStreamOnDropIndexOption(
                        fileStreamOn: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.FileStreamOnDropIndexOption).FileStreamOn),
                        optionKind: (fragment as ScriptDom.FileStreamOnDropIndexOption).OptionKind
                    );
                }
                case 474: {
                    return new FileStreamOnTableOption(
                        @value: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.FileStreamOnTableOption).Value),
                        optionKind: (fragment as ScriptDom.FileStreamOnTableOption).OptionKind
                    );
                }
                case 475: {
                    return new FileStreamRestoreOption(
                        fileStreamOption: (FileStreamDatabaseOption)FromMutable((fragment as ScriptDom.FileStreamRestoreOption).FileStreamOption),
                        optionKind: (fragment as ScriptDom.FileStreamRestoreOption).OptionKind
                    );
                }
                case 476: {
                    return new FileTableCollateFileNameTableOption(
                        @value: (Identifier)FromMutable((fragment as ScriptDom.FileTableCollateFileNameTableOption).Value),
                        optionKind: (fragment as ScriptDom.FileTableCollateFileNameTableOption).OptionKind
                    );
                }
                case 477: {
                    return new FileTableConstraintNameTableOption(
                        @value: (Identifier)FromMutable((fragment as ScriptDom.FileTableConstraintNameTableOption).Value),
                        optionKind: (fragment as ScriptDom.FileTableConstraintNameTableOption).OptionKind
                    );
                }
                case 478: {
                    return new FileTableDirectoryTableOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.FileTableDirectoryTableOption).Value),
                        optionKind: (fragment as ScriptDom.FileTableDirectoryTableOption).OptionKind
                    );
                }
                case 479: {
                    return new ForceSeekTableHint(
                        indexValue: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.ForceSeekTableHint).IndexValue),
                        columnValues: (fragment as ScriptDom.ForceSeekTableHint).ColumnValues.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        hintKind: (fragment as ScriptDom.ForceSeekTableHint).HintKind
                    );
                }
                case 480: {
                    return new ForeignKeyConstraintDefinition(
                        columns: (fragment as ScriptDom.ForeignKeyConstraintDefinition).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        referenceTableName: (SchemaObjectName)FromMutable((fragment as ScriptDom.ForeignKeyConstraintDefinition).ReferenceTableName),
                        referencedTableColumns: (fragment as ScriptDom.ForeignKeyConstraintDefinition).ReferencedTableColumns.SelectList(c => (Identifier)FromMutable(c)),
                        deleteAction: (fragment as ScriptDom.ForeignKeyConstraintDefinition).DeleteAction,
                        updateAction: (fragment as ScriptDom.ForeignKeyConstraintDefinition).UpdateAction,
                        notForReplication: (fragment as ScriptDom.ForeignKeyConstraintDefinition).NotForReplication,
                        constraintIdentifier: (Identifier)FromMutable((fragment as ScriptDom.ForeignKeyConstraintDefinition).ConstraintIdentifier)
                    );
                }
                case 481: {
                    return new FromClause(
                        tableReferences: (fragment as ScriptDom.FromClause).TableReferences.SelectList(c => (TableReference)FromMutable(c)),
                        predictTableReference: (fragment as ScriptDom.FromClause).PredictTableReference.SelectList(c => (PredictTableReference)FromMutable(c))
                    );
                }
                case 482: {
                    return new FullTextCatalogAndFileGroup(
                        catalogName: (Identifier)FromMutable((fragment as ScriptDom.FullTextCatalogAndFileGroup).CatalogName),
                        fileGroupName: (Identifier)FromMutable((fragment as ScriptDom.FullTextCatalogAndFileGroup).FileGroupName),
                        fileGroupIsFirst: (fragment as ScriptDom.FullTextCatalogAndFileGroup).FileGroupIsFirst
                    );
                }
                case 483: {
                    return new FullTextIndexColumn(
                        name: (Identifier)FromMutable((fragment as ScriptDom.FullTextIndexColumn).Name),
                        typeColumn: (Identifier)FromMutable((fragment as ScriptDom.FullTextIndexColumn).TypeColumn),
                        languageTerm: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.FullTextIndexColumn).LanguageTerm),
                        statisticalSemantics: (fragment as ScriptDom.FullTextIndexColumn).StatisticalSemantics
                    );
                }
                case 484: {
                    return new FullTextPredicate(
                        fullTextFunctionType: (fragment as ScriptDom.FullTextPredicate).FullTextFunctionType,
                        columns: (fragment as ScriptDom.FullTextPredicate).Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        @value: (ValueExpression)FromMutable((fragment as ScriptDom.FullTextPredicate).Value),
                        languageTerm: (ValueExpression)FromMutable((fragment as ScriptDom.FullTextPredicate).LanguageTerm),
                        propertyName: (StringLiteral)FromMutable((fragment as ScriptDom.FullTextPredicate).PropertyName)
                    );
                }
                case 485: {
                    return new FullTextStopListAction(
                        isAdd: (fragment as ScriptDom.FullTextStopListAction).IsAdd,
                        isAll: (fragment as ScriptDom.FullTextStopListAction).IsAll,
                        stopWord: (Literal)FromMutable((fragment as ScriptDom.FullTextStopListAction).StopWord),
                        languageTerm: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.FullTextStopListAction).LanguageTerm)
                    );
                }
                case 486: {
                    return new FullTextTableReference(
                        fullTextFunctionType: (fragment as ScriptDom.FullTextTableReference).FullTextFunctionType,
                        tableName: (SchemaObjectName)FromMutable((fragment as ScriptDom.FullTextTableReference).TableName),
                        columns: (fragment as ScriptDom.FullTextTableReference).Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        searchCondition: (ValueExpression)FromMutable((fragment as ScriptDom.FullTextTableReference).SearchCondition),
                        topN: (ValueExpression)FromMutable((fragment as ScriptDom.FullTextTableReference).TopN),
                        language: (ValueExpression)FromMutable((fragment as ScriptDom.FullTextTableReference).Language),
                        propertyName: (StringLiteral)FromMutable((fragment as ScriptDom.FullTextTableReference).PropertyName),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.FullTextTableReference).Alias),
                        forPath: (fragment as ScriptDom.FullTextTableReference).ForPath
                    );
                }
                case 487: {
                    return new FunctionCall(
                        callTarget: (CallTarget)FromMutable((fragment as ScriptDom.FunctionCall).CallTarget),
                        functionName: (Identifier)FromMutable((fragment as ScriptDom.FunctionCall).FunctionName),
                        parameters: (fragment as ScriptDom.FunctionCall).Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        uniqueRowFilter: (fragment as ScriptDom.FunctionCall).UniqueRowFilter,
                        overClause: (OverClause)FromMutable((fragment as ScriptDom.FunctionCall).OverClause),
                        withinGroupClause: (WithinGroupClause)FromMutable((fragment as ScriptDom.FunctionCall).WithinGroupClause),
                        ignoreRespectNulls: (fragment as ScriptDom.FunctionCall).IgnoreRespectNulls.SelectList(c => (Identifier)FromMutable(c)),
                        trimOptions: (Identifier)FromMutable((fragment as ScriptDom.FunctionCall).TrimOptions),
                        jsonParameters: (fragment as ScriptDom.FunctionCall).JsonParameters.SelectList(c => (JsonKeyValue)FromMutable(c)),
                        absentOrNullOnNull: (fragment as ScriptDom.FunctionCall).AbsentOrNullOnNull.SelectList(c => (Identifier)FromMutable(c)),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.FunctionCall).Collation)
                    );
                }
                case 488: {
                    return new FunctionCallSetClause(
                        mutatorFunction: (FunctionCall)FromMutable((fragment as ScriptDom.FunctionCallSetClause).MutatorFunction)
                    );
                }
                case 489: {
                    return new FunctionOption(
                        optionKind: (fragment as ScriptDom.FunctionOption).OptionKind
                    );
                }
                case 490: {
                    return new GeneralSetCommand(
                        commandType: (fragment as ScriptDom.GeneralSetCommand).CommandType,
                        parameter: (ScalarExpression)FromMutable((fragment as ScriptDom.GeneralSetCommand).Parameter)
                    );
                }
                case 491: {
                    return new GenericConfigurationOption(
                        genericOptionState: (IdentifierOrScalarExpression)FromMutable((fragment as ScriptDom.GenericConfigurationOption).GenericOptionState),
                        optionKind: (fragment as ScriptDom.GenericConfigurationOption).OptionKind,
                        genericOptionKind: (Identifier)FromMutable((fragment as ScriptDom.GenericConfigurationOption).GenericOptionKind)
                    );
                }
                case 492: {
                    return new GetConversationGroupStatement(
                        groupId: (VariableReference)FromMutable((fragment as ScriptDom.GetConversationGroupStatement).GroupId),
                        queue: (SchemaObjectName)FromMutable((fragment as ScriptDom.GetConversationGroupStatement).Queue)
                    );
                }
                case 493: {
                    return new GlobalFunctionTableReference(
                        name: (Identifier)FromMutable((fragment as ScriptDom.GlobalFunctionTableReference).Name),
                        parameters: (fragment as ScriptDom.GlobalFunctionTableReference).Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.GlobalFunctionTableReference).Alias),
                        forPath: (fragment as ScriptDom.GlobalFunctionTableReference).ForPath
                    );
                }
                case 494: {
                    return new GlobalVariableExpression(
                        name: (fragment as ScriptDom.GlobalVariableExpression).Name,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.GlobalVariableExpression).Collation)
                    );
                }
                case 495: {
                    return new GoToStatement(
                        labelName: (Identifier)FromMutable((fragment as ScriptDom.GoToStatement).LabelName)
                    );
                }
                case 496: {
                    return new GrandTotalGroupingSpecification(
                        
                    );
                }
                case 497: {
                    return new GrantStatement(
                        withGrantOption: (fragment as ScriptDom.GrantStatement).WithGrantOption,
                        permissions: (fragment as ScriptDom.GrantStatement).Permissions.SelectList(c => (Permission)FromMutable(c)),
                        securityTargetObject: (SecurityTargetObject)FromMutable((fragment as ScriptDom.GrantStatement).SecurityTargetObject),
                        principals: (fragment as ScriptDom.GrantStatement).Principals.SelectList(c => (SecurityPrincipal)FromMutable(c)),
                        asClause: (Identifier)FromMutable((fragment as ScriptDom.GrantStatement).AsClause)
                    );
                }
                case 498: {
                    return new GrantStatement80(
                        withGrantOption: (fragment as ScriptDom.GrantStatement80).WithGrantOption,
                        asClause: (Identifier)FromMutable((fragment as ScriptDom.GrantStatement80).AsClause),
                        securityElement80: (SecurityElement80)FromMutable((fragment as ScriptDom.GrantStatement80).SecurityElement80),
                        securityUserClause80: (SecurityUserClause80)FromMutable((fragment as ScriptDom.GrantStatement80).SecurityUserClause80)
                    );
                }
                case 499: {
                    return new GraphConnectionBetweenNodes(
                        fromNode: (SchemaObjectName)FromMutable((fragment as ScriptDom.GraphConnectionBetweenNodes).FromNode),
                        toNode: (SchemaObjectName)FromMutable((fragment as ScriptDom.GraphConnectionBetweenNodes).ToNode)
                    );
                }
                case 500: {
                    return new GraphConnectionConstraintDefinition(
                        fromNodeToNodeList: (fragment as ScriptDom.GraphConnectionConstraintDefinition).FromNodeToNodeList.SelectList(c => (GraphConnectionBetweenNodes)FromMutable(c)),
                        deleteAction: (fragment as ScriptDom.GraphConnectionConstraintDefinition).DeleteAction,
                        constraintIdentifier: (Identifier)FromMutable((fragment as ScriptDom.GraphConnectionConstraintDefinition).ConstraintIdentifier)
                    );
                }
                case 501: {
                    return new GraphMatchCompositeExpression(
                        leftNode: (GraphMatchNodeExpression)FromMutable((fragment as ScriptDom.GraphMatchCompositeExpression).LeftNode),
                        edge: (Identifier)FromMutable((fragment as ScriptDom.GraphMatchCompositeExpression).Edge),
                        rightNode: (GraphMatchNodeExpression)FromMutable((fragment as ScriptDom.GraphMatchCompositeExpression).RightNode),
                        arrowOnRight: (fragment as ScriptDom.GraphMatchCompositeExpression).ArrowOnRight
                    );
                }
                case 502: {
                    return new GraphMatchExpression(
                        leftNode: (Identifier)FromMutable((fragment as ScriptDom.GraphMatchExpression).LeftNode),
                        edge: (Identifier)FromMutable((fragment as ScriptDom.GraphMatchExpression).Edge),
                        rightNode: (Identifier)FromMutable((fragment as ScriptDom.GraphMatchExpression).RightNode),
                        arrowOnRight: (fragment as ScriptDom.GraphMatchExpression).ArrowOnRight
                    );
                }
                case 503: {
                    return new GraphMatchLastNodePredicate(
                        leftExpression: (GraphMatchNodeExpression)FromMutable((fragment as ScriptDom.GraphMatchLastNodePredicate).LeftExpression),
                        rightExpression: (GraphMatchNodeExpression)FromMutable((fragment as ScriptDom.GraphMatchLastNodePredicate).RightExpression)
                    );
                }
                case 504: {
                    return new GraphMatchNodeExpression(
                        node: (Identifier)FromMutable((fragment as ScriptDom.GraphMatchNodeExpression).Node),
                        usesLastNode: (fragment as ScriptDom.GraphMatchNodeExpression).UsesLastNode
                    );
                }
                case 505: {
                    return new GraphMatchPredicate(
                        expression: (BooleanExpression)FromMutable((fragment as ScriptDom.GraphMatchPredicate).Expression)
                    );
                }
                case 506: {
                    return new GraphMatchRecursivePredicate(
                        function: (fragment as ScriptDom.GraphMatchRecursivePredicate).Function,
                        outerNodeExpression: (GraphMatchNodeExpression)FromMutable((fragment as ScriptDom.GraphMatchRecursivePredicate).OuterNodeExpression),
                        expression: (fragment as ScriptDom.GraphMatchRecursivePredicate).Expression.SelectList(c => (BooleanExpression)FromMutable(c)),
                        recursiveQuantifier: (GraphRecursiveMatchQuantifier)FromMutable((fragment as ScriptDom.GraphMatchRecursivePredicate).RecursiveQuantifier),
                        anchorOnLeft: (fragment as ScriptDom.GraphMatchRecursivePredicate).AnchorOnLeft
                    );
                }
                case 507: {
                    return new GraphRecursiveMatchQuantifier(
                        isPlusSign: (fragment as ScriptDom.GraphRecursiveMatchQuantifier).IsPlusSign,
                        lowerLimit: (Literal)FromMutable((fragment as ScriptDom.GraphRecursiveMatchQuantifier).LowerLimit),
                        upperLimit: (Literal)FromMutable((fragment as ScriptDom.GraphRecursiveMatchQuantifier).UpperLimit)
                    );
                }
                case 508: {
                    return new GridParameter(
                        parameter: (fragment as ScriptDom.GridParameter).Parameter,
                        @value: (fragment as ScriptDom.GridParameter).Value
                    );
                }
                case 509: {
                    return new GridsSpatialIndexOption(
                        gridParameters: (fragment as ScriptDom.GridsSpatialIndexOption).GridParameters.SelectList(c => (GridParameter)FromMutable(c))
                    );
                }
                case 510: {
                    return new GroupByClause(
                        groupByOption: (fragment as ScriptDom.GroupByClause).GroupByOption,
                        all: (fragment as ScriptDom.GroupByClause).All,
                        groupingSpecifications: (fragment as ScriptDom.GroupByClause).GroupingSpecifications.SelectList(c => (GroupingSpecification)FromMutable(c))
                    );
                }
                case 511: {
                    return new GroupingSetsGroupingSpecification(
                        sets: (fragment as ScriptDom.GroupingSetsGroupingSpecification).Sets.SelectList(c => (GroupingSpecification)FromMutable(c))
                    );
                }
                case 512: {
                    return new HadrAvailabilityGroupDatabaseOption(
                        groupName: (Identifier)FromMutable((fragment as ScriptDom.HadrAvailabilityGroupDatabaseOption).GroupName),
                        hadrOption: (fragment as ScriptDom.HadrAvailabilityGroupDatabaseOption).HadrOption,
                        optionKind: (fragment as ScriptDom.HadrAvailabilityGroupDatabaseOption).OptionKind
                    );
                }
                case 513: {
                    return new HadrDatabaseOption(
                        hadrOption: (fragment as ScriptDom.HadrDatabaseOption).HadrOption,
                        optionKind: (fragment as ScriptDom.HadrDatabaseOption).OptionKind
                    );
                }
                case 514: {
                    return new HavingClause(
                        searchCondition: (BooleanExpression)FromMutable((fragment as ScriptDom.HavingClause).SearchCondition)
                    );
                }
                case 515: {
                    return new Identifier(
                        @value: (fragment as ScriptDom.Identifier).Value,
                        quoteType: (fragment as ScriptDom.Identifier).QuoteType
                    );
                }
                case 516: {
                    return new IdentifierAtomicBlockOption(
                        @value: (Identifier)FromMutable((fragment as ScriptDom.IdentifierAtomicBlockOption).Value),
                        optionKind: (fragment as ScriptDom.IdentifierAtomicBlockOption).OptionKind
                    );
                }
                case 517: {
                    return new IdentifierDatabaseOption(
                        @value: (Identifier)FromMutable((fragment as ScriptDom.IdentifierDatabaseOption).Value),
                        optionKind: (fragment as ScriptDom.IdentifierDatabaseOption).OptionKind
                    );
                }
                case 518: {
                    return new IdentifierLiteral(
                        quoteType: (fragment as ScriptDom.IdentifierLiteral).QuoteType,
                        @value: (fragment as ScriptDom.IdentifierLiteral).Value,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.IdentifierLiteral).Collation)
                    );
                }
                case 519: {
                    return new IdentifierOrScalarExpression(
                        identifier: (Identifier)FromMutable((fragment as ScriptDom.IdentifierOrScalarExpression).Identifier),
                        scalarExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.IdentifierOrScalarExpression).ScalarExpression)
                    );
                }
                case 520: {
                    return new IdentifierOrValueExpression(
                        identifier: (Identifier)FromMutable((fragment as ScriptDom.IdentifierOrValueExpression).Identifier),
                        valueExpression: (ValueExpression)FromMutable((fragment as ScriptDom.IdentifierOrValueExpression).ValueExpression)
                    );
                }
                case 521: {
                    return new IdentifierPrincipalOption(
                        identifier: (Identifier)FromMutable((fragment as ScriptDom.IdentifierPrincipalOption).Identifier),
                        optionKind: (fragment as ScriptDom.IdentifierPrincipalOption).OptionKind
                    );
                }
                case 522: {
                    return new IdentifierSnippet(
                        script: (fragment as ScriptDom.IdentifierSnippet).Script,
                        @value: (fragment as ScriptDom.IdentifierSnippet).Value,
                        quoteType: (fragment as ScriptDom.IdentifierSnippet).QuoteType
                    );
                }
                case 523: {
                    return new IdentityFunctionCall(
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.IdentityFunctionCall).DataType),
                        seed: (ScalarExpression)FromMutable((fragment as ScriptDom.IdentityFunctionCall).Seed),
                        increment: (ScalarExpression)FromMutable((fragment as ScriptDom.IdentityFunctionCall).Increment)
                    );
                }
                case 524: {
                    return new IdentityOptions(
                        identitySeed: (ScalarExpression)FromMutable((fragment as ScriptDom.IdentityOptions).IdentitySeed),
                        identityIncrement: (ScalarExpression)FromMutable((fragment as ScriptDom.IdentityOptions).IdentityIncrement),
                        isIdentityNotForReplication: (fragment as ScriptDom.IdentityOptions).IsIdentityNotForReplication
                    );
                }
                case 525: {
                    return new IdentityValueKeyOption(
                        identityPhrase: (Literal)FromMutable((fragment as ScriptDom.IdentityValueKeyOption).IdentityPhrase),
                        optionKind: (fragment as ScriptDom.IdentityValueKeyOption).OptionKind
                    );
                }
                case 526: {
                    return new IfStatement(
                        predicate: (BooleanExpression)FromMutable((fragment as ScriptDom.IfStatement).Predicate),
                        thenStatement: (TSqlStatement)FromMutable((fragment as ScriptDom.IfStatement).ThenStatement),
                        elseStatement: (TSqlStatement)FromMutable((fragment as ScriptDom.IfStatement).ElseStatement)
                    );
                }
                case 527: {
                    return new IgnoreDupKeyIndexOption(
                        suppressMessagesOption: (fragment as ScriptDom.IgnoreDupKeyIndexOption).SuppressMessagesOption,
                        optionState: (fragment as ScriptDom.IgnoreDupKeyIndexOption).OptionState,
                        optionKind: (fragment as ScriptDom.IgnoreDupKeyIndexOption).OptionKind
                    );
                }
                case 528: {
                    return new IIfCall(
                        predicate: (BooleanExpression)FromMutable((fragment as ScriptDom.IIfCall).Predicate),
                        thenExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.IIfCall).ThenExpression),
                        elseExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.IIfCall).ElseExpression),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.IIfCall).Collation)
                    );
                }
                case 529: {
                    return new IndexDefinition(
                        name: (Identifier)FromMutable((fragment as ScriptDom.IndexDefinition).Name),
                        unique: (fragment as ScriptDom.IndexDefinition).Unique,
                        indexType: (IndexType)FromMutable((fragment as ScriptDom.IndexDefinition).IndexType),
                        indexOptions: (fragment as ScriptDom.IndexDefinition).IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                        columns: (fragment as ScriptDom.IndexDefinition).Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                        includeColumns: (fragment as ScriptDom.IndexDefinition).IncludeColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable((fragment as ScriptDom.IndexDefinition).OnFileGroupOrPartitionScheme),
                        filterPredicate: (BooleanExpression)FromMutable((fragment as ScriptDom.IndexDefinition).FilterPredicate),
                        fileStreamOn: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.IndexDefinition).FileStreamOn)
                    );
                }
                case 530: {
                    return new IndexExpressionOption(
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.IndexExpressionOption).Expression),
                        optionKind: (fragment as ScriptDom.IndexExpressionOption).OptionKind
                    );
                }
                case 531: {
                    return new IndexStateOption(
                        optionState: (fragment as ScriptDom.IndexStateOption).OptionState,
                        optionKind: (fragment as ScriptDom.IndexStateOption).OptionKind
                    );
                }
                case 532: {
                    return new IndexTableHint(
                        indexValues: (fragment as ScriptDom.IndexTableHint).IndexValues.SelectList(c => (IdentifierOrValueExpression)FromMutable(c)),
                        hintKind: (fragment as ScriptDom.IndexTableHint).HintKind
                    );
                }
                case 533: {
                    return new IndexType(
                        indexTypeKind: (fragment as ScriptDom.IndexType).IndexTypeKind
                    );
                }
                case 534: {
                    return new InlineDerivedTable(
                        rowValues: (fragment as ScriptDom.InlineDerivedTable).RowValues.SelectList(c => (RowValue)FromMutable(c)),
                        columns: (fragment as ScriptDom.InlineDerivedTable).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.InlineDerivedTable).Alias),
                        forPath: (fragment as ScriptDom.InlineDerivedTable).ForPath
                    );
                }
                case 535: {
                    return new InlineFunctionOption(
                        optionState: (fragment as ScriptDom.InlineFunctionOption).OptionState,
                        optionKind: (fragment as ScriptDom.InlineFunctionOption).OptionKind
                    );
                }
                case 536: {
                    return new InlineResultSetDefinition(
                        resultColumnDefinitions: (fragment as ScriptDom.InlineResultSetDefinition).ResultColumnDefinitions.SelectList(c => (ResultColumnDefinition)FromMutable(c)),
                        resultSetType: (fragment as ScriptDom.InlineResultSetDefinition).ResultSetType
                    );
                }
                case 537: {
                    return new InPredicate(
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.InPredicate).Expression),
                        subquery: (ScalarSubquery)FromMutable((fragment as ScriptDom.InPredicate).Subquery),
                        notDefined: (fragment as ScriptDom.InPredicate).NotDefined,
                        values: (fragment as ScriptDom.InPredicate).Values.SelectList(c => (ScalarExpression)FromMutable(c))
                    );
                }
                case 538: {
                    return new InsertBulkColumnDefinition(
                        column: (ColumnDefinitionBase)FromMutable((fragment as ScriptDom.InsertBulkColumnDefinition).Column),
                        nullNotNull: (fragment as ScriptDom.InsertBulkColumnDefinition).NullNotNull
                    );
                }
                case 539: {
                    return new InsertBulkStatement(
                        columnDefinitions: (fragment as ScriptDom.InsertBulkStatement).ColumnDefinitions.SelectList(c => (InsertBulkColumnDefinition)FromMutable(c)),
                        to: (SchemaObjectName)FromMutable((fragment as ScriptDom.InsertBulkStatement).To),
                        options: (fragment as ScriptDom.InsertBulkStatement).Options.SelectList(c => (BulkInsertOption)FromMutable(c))
                    );
                }
                case 540: {
                    return new InsertMergeAction(
                        columns: (fragment as ScriptDom.InsertMergeAction).Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        source: (ValuesInsertSource)FromMutable((fragment as ScriptDom.InsertMergeAction).Source)
                    );
                }
                case 541: {
                    return new InsertSpecification(
                        insertOption: (fragment as ScriptDom.InsertSpecification).InsertOption,
                        insertSource: (InsertSource)FromMutable((fragment as ScriptDom.InsertSpecification).InsertSource),
                        columns: (fragment as ScriptDom.InsertSpecification).Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        target: (TableReference)FromMutable((fragment as ScriptDom.InsertSpecification).Target),
                        topRowFilter: (TopRowFilter)FromMutable((fragment as ScriptDom.InsertSpecification).TopRowFilter),
                        outputIntoClause: (OutputIntoClause)FromMutable((fragment as ScriptDom.InsertSpecification).OutputIntoClause),
                        outputClause: (OutputClause)FromMutable((fragment as ScriptDom.InsertSpecification).OutputClause)
                    );
                }
                case 542: {
                    return new InsertStatement(
                        insertSpecification: (InsertSpecification)FromMutable((fragment as ScriptDom.InsertStatement).InsertSpecification),
                        withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable((fragment as ScriptDom.InsertStatement).WithCtesAndXmlNamespaces),
                        optimizerHints: (fragment as ScriptDom.InsertStatement).OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 543: {
                    return new IntegerLiteral(
                        @value: (fragment as ScriptDom.IntegerLiteral).Value,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.IntegerLiteral).Collation)
                    );
                }
                case 544: {
                    return new InternalOpenRowset(
                        identifier: (Identifier)FromMutable((fragment as ScriptDom.InternalOpenRowset).Identifier),
                        varArgs: (fragment as ScriptDom.InternalOpenRowset).VarArgs.SelectList(c => (ScalarExpression)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.InternalOpenRowset).Alias),
                        forPath: (fragment as ScriptDom.InternalOpenRowset).ForPath
                    );
                }
                case 545: {
                    return new IPv4(
                        octetOne: (Literal)FromMutable((fragment as ScriptDom.IPv4).OctetOne),
                        octetTwo: (Literal)FromMutable((fragment as ScriptDom.IPv4).OctetTwo),
                        octetThree: (Literal)FromMutable((fragment as ScriptDom.IPv4).OctetThree),
                        octetFour: (Literal)FromMutable((fragment as ScriptDom.IPv4).OctetFour)
                    );
                }
                case 546: {
                    return new JoinParenthesisTableReference(
                        join: (TableReference)FromMutable((fragment as ScriptDom.JoinParenthesisTableReference).Join)
                    );
                }
                case 547: {
                    return new JsonForClause(
                        options: (fragment as ScriptDom.JsonForClause).Options.SelectList(c => (JsonForClauseOption)FromMutable(c))
                    );
                }
                case 548: {
                    return new JsonForClauseOption(
                        optionKind: (fragment as ScriptDom.JsonForClauseOption).OptionKind,
                        @value: (Literal)FromMutable((fragment as ScriptDom.JsonForClauseOption).Value)
                    );
                }
                case 549: {
                    return new JsonKeyValue(
                        jsonKeyName: (ScalarExpression)FromMutable((fragment as ScriptDom.JsonKeyValue).JsonKeyName),
                        jsonValue: (ScalarExpression)FromMutable((fragment as ScriptDom.JsonKeyValue).JsonValue)
                    );
                }
                case 550: {
                    return new KeySourceKeyOption(
                        passPhrase: (Literal)FromMutable((fragment as ScriptDom.KeySourceKeyOption).PassPhrase),
                        optionKind: (fragment as ScriptDom.KeySourceKeyOption).OptionKind
                    );
                }
                case 551: {
                    return new KillQueryNotificationSubscriptionStatement(
                        subscriptionId: (Literal)FromMutable((fragment as ScriptDom.KillQueryNotificationSubscriptionStatement).SubscriptionId),
                        all: (fragment as ScriptDom.KillQueryNotificationSubscriptionStatement).All
                    );
                }
                case 552: {
                    return new KillStatement(
                        parameter: (ScalarExpression)FromMutable((fragment as ScriptDom.KillStatement).Parameter),
                        withStatusOnly: (fragment as ScriptDom.KillStatement).WithStatusOnly
                    );
                }
                case 553: {
                    return new KillStatsJobStatement(
                        jobId: (ScalarExpression)FromMutable((fragment as ScriptDom.KillStatsJobStatement).JobId)
                    );
                }
                case 554: {
                    return new LabelStatement(
                        @value: (fragment as ScriptDom.LabelStatement).Value
                    );
                }
                case 555: {
                    return new LedgerOption(
                        optionState: (fragment as ScriptDom.LedgerOption).OptionState,
                        optionKind: (fragment as ScriptDom.LedgerOption).OptionKind
                    );
                }
                case 556: {
                    return new LedgerTableOption(
                        optionState: (fragment as ScriptDom.LedgerTableOption).OptionState,
                        appendOnly: (fragment as ScriptDom.LedgerTableOption).AppendOnly,
                        ledgerViewOption: (LedgerViewOption)FromMutable((fragment as ScriptDom.LedgerTableOption).LedgerViewOption),
                        optionKind: (fragment as ScriptDom.LedgerTableOption).OptionKind
                    );
                }
                case 557: {
                    return new LedgerViewOption(
                        viewName: (SchemaObjectName)FromMutable((fragment as ScriptDom.LedgerViewOption).ViewName),
                        transactionIdColumnName: (Identifier)FromMutable((fragment as ScriptDom.LedgerViewOption).TransactionIdColumnName),
                        sequenceNumberColumnName: (Identifier)FromMutable((fragment as ScriptDom.LedgerViewOption).SequenceNumberColumnName),
                        operationTypeColumnName: (Identifier)FromMutable((fragment as ScriptDom.LedgerViewOption).OperationTypeColumnName),
                        operationTypeDescColumnName: (Identifier)FromMutable((fragment as ScriptDom.LedgerViewOption).OperationTypeDescColumnName),
                        optionKind: (fragment as ScriptDom.LedgerViewOption).OptionKind
                    );
                }
                case 558: {
                    return new LeftFunctionCall(
                        parameters: (fragment as ScriptDom.LeftFunctionCall).Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.LeftFunctionCall).Collation)
                    );
                }
                case 559: {
                    return new LikePredicate(
                        firstExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.LikePredicate).FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.LikePredicate).SecondExpression),
                        notDefined: (fragment as ScriptDom.LikePredicate).NotDefined,
                        odbcEscape: (fragment as ScriptDom.LikePredicate).OdbcEscape,
                        escapeExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.LikePredicate).EscapeExpression)
                    );
                }
                case 560: {
                    return new LineNoStatement(
                        lineNo: (IntegerLiteral)FromMutable((fragment as ScriptDom.LineNoStatement).LineNo)
                    );
                }
                case 561: {
                    return new ListenerIPEndpointProtocolOption(
                        isAll: (fragment as ScriptDom.ListenerIPEndpointProtocolOption).IsAll,
                        iPv6: (Literal)FromMutable((fragment as ScriptDom.ListenerIPEndpointProtocolOption).IPv6),
                        iPv4PartOne: (IPv4)FromMutable((fragment as ScriptDom.ListenerIPEndpointProtocolOption).IPv4PartOne),
                        iPv4PartTwo: (IPv4)FromMutable((fragment as ScriptDom.ListenerIPEndpointProtocolOption).IPv4PartTwo),
                        kind: (fragment as ScriptDom.ListenerIPEndpointProtocolOption).Kind
                    );
                }
                case 562: {
                    return new ListTypeCopyOption(
                        options: (fragment as ScriptDom.ListTypeCopyOption).Options.SelectList(c => (CopyStatementOptionBase)FromMutable(c))
                    );
                }
                case 563: {
                    return new LiteralAtomicBlockOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralAtomicBlockOption).Value),
                        optionKind: (fragment as ScriptDom.LiteralAtomicBlockOption).OptionKind
                    );
                }
                case 564: {
                    return new LiteralAuditTargetOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralAuditTargetOption).Value),
                        optionKind: (fragment as ScriptDom.LiteralAuditTargetOption).OptionKind
                    );
                }
                case 565: {
                    return new LiteralAvailabilityGroupOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralAvailabilityGroupOption).Value),
                        optionKind: (fragment as ScriptDom.LiteralAvailabilityGroupOption).OptionKind
                    );
                }
                case 566: {
                    return new LiteralBulkInsertOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralBulkInsertOption).Value),
                        optionKind: (fragment as ScriptDom.LiteralBulkInsertOption).OptionKind
                    );
                }
                case 567: {
                    return new LiteralDatabaseOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralDatabaseOption).Value),
                        optionKind: (fragment as ScriptDom.LiteralDatabaseOption).OptionKind
                    );
                }
                case 568: {
                    return new LiteralEndpointProtocolOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralEndpointProtocolOption).Value),
                        kind: (fragment as ScriptDom.LiteralEndpointProtocolOption).Kind
                    );
                }
                case 569: {
                    return new LiteralOpenRowsetCosmosOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralOpenRowsetCosmosOption).Value),
                        optionKind: (fragment as ScriptDom.LiteralOpenRowsetCosmosOption).OptionKind
                    );
                }
                case 570: {
                    return new LiteralOptimizerHint(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralOptimizerHint).Value),
                        hintKind: (fragment as ScriptDom.LiteralOptimizerHint).HintKind
                    );
                }
                case 571: {
                    return new LiteralOptionValue(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralOptionValue).Value)
                    );
                }
                case 572: {
                    return new LiteralPayloadOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralPayloadOption).Value),
                        kind: (fragment as ScriptDom.LiteralPayloadOption).Kind
                    );
                }
                case 573: {
                    return new LiteralPrincipalOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralPrincipalOption).Value),
                        optionKind: (fragment as ScriptDom.LiteralPrincipalOption).OptionKind
                    );
                }
                case 574: {
                    return new LiteralRange(
                        from: (Literal)FromMutable((fragment as ScriptDom.LiteralRange).From),
                        to: (Literal)FromMutable((fragment as ScriptDom.LiteralRange).To)
                    );
                }
                case 575: {
                    return new LiteralReplicaOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralReplicaOption).Value),
                        optionKind: (fragment as ScriptDom.LiteralReplicaOption).OptionKind
                    );
                }
                case 576: {
                    return new LiteralSessionOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralSessionOption).Value),
                        unit: (fragment as ScriptDom.LiteralSessionOption).Unit,
                        optionKind: (fragment as ScriptDom.LiteralSessionOption).OptionKind
                    );
                }
                case 577: {
                    return new LiteralStatisticsOption(
                        literal: (Literal)FromMutable((fragment as ScriptDom.LiteralStatisticsOption).Literal),
                        optionKind: (fragment as ScriptDom.LiteralStatisticsOption).OptionKind
                    );
                }
                case 578: {
                    return new LiteralTableHint(
                        @value: (Literal)FromMutable((fragment as ScriptDom.LiteralTableHint).Value),
                        hintKind: (fragment as ScriptDom.LiteralTableHint).HintKind
                    );
                }
                case 579: {
                    return new LocationOption(
                        locationValue: (Identifier)FromMutable((fragment as ScriptDom.LocationOption).LocationValue),
                        optionKind: (fragment as ScriptDom.LocationOption).OptionKind
                    );
                }
                case 580: {
                    return new LockEscalationTableOption(
                        @value: (fragment as ScriptDom.LockEscalationTableOption).Value,
                        optionKind: (fragment as ScriptDom.LockEscalationTableOption).OptionKind
                    );
                }
                case 581: {
                    return new LoginTypePayloadOption(
                        isWindows: (fragment as ScriptDom.LoginTypePayloadOption).IsWindows,
                        kind: (fragment as ScriptDom.LoginTypePayloadOption).Kind
                    );
                }
                case 582: {
                    return new LowPriorityLockWaitAbortAfterWaitOption(
                        abortAfterWait: (fragment as ScriptDom.LowPriorityLockWaitAbortAfterWaitOption).AbortAfterWait,
                        optionKind: (fragment as ScriptDom.LowPriorityLockWaitAbortAfterWaitOption).OptionKind
                    );
                }
                case 583: {
                    return new LowPriorityLockWaitMaxDurationOption(
                        maxDuration: (Literal)FromMutable((fragment as ScriptDom.LowPriorityLockWaitMaxDurationOption).MaxDuration),
                        unit: (fragment as ScriptDom.LowPriorityLockWaitMaxDurationOption).Unit,
                        optionKind: (fragment as ScriptDom.LowPriorityLockWaitMaxDurationOption).OptionKind
                    );
                }
                case 584: {
                    return new LowPriorityLockWaitTableSwitchOption(
                        options: (fragment as ScriptDom.LowPriorityLockWaitTableSwitchOption).Options.SelectList(c => (LowPriorityLockWaitOption)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.LowPriorityLockWaitTableSwitchOption).OptionKind
                    );
                }
                case 585: {
                    return new MaxDispatchLatencySessionOption(
                        isInfinite: (fragment as ScriptDom.MaxDispatchLatencySessionOption).IsInfinite,
                        @value: (Literal)FromMutable((fragment as ScriptDom.MaxDispatchLatencySessionOption).Value),
                        optionKind: (fragment as ScriptDom.MaxDispatchLatencySessionOption).OptionKind
                    );
                }
                case 586: {
                    return new MaxDopConfigurationOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.MaxDopConfigurationOption).Value),
                        primary: (fragment as ScriptDom.MaxDopConfigurationOption).Primary,
                        optionKind: (fragment as ScriptDom.MaxDopConfigurationOption).OptionKind,
                        genericOptionKind: (Identifier)FromMutable((fragment as ScriptDom.MaxDopConfigurationOption).GenericOptionKind)
                    );
                }
                case 587: {
                    return new MaxDurationOption(
                        maxDuration: (Literal)FromMutable((fragment as ScriptDom.MaxDurationOption).MaxDuration),
                        unit: (fragment as ScriptDom.MaxDurationOption).Unit,
                        optionKind: (fragment as ScriptDom.MaxDurationOption).OptionKind
                    );
                }
                case 588: {
                    return new MaxLiteral(
                        @value: (fragment as ScriptDom.MaxLiteral).Value,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.MaxLiteral).Collation)
                    );
                }
                case 589: {
                    return new MaxRolloverFilesAuditTargetOption(
                        @value: (Literal)FromMutable((fragment as ScriptDom.MaxRolloverFilesAuditTargetOption).Value),
                        isUnlimited: (fragment as ScriptDom.MaxRolloverFilesAuditTargetOption).IsUnlimited,
                        optionKind: (fragment as ScriptDom.MaxRolloverFilesAuditTargetOption).OptionKind
                    );
                }
                case 590: {
                    return new MaxSizeAuditTargetOption(
                        isUnlimited: (fragment as ScriptDom.MaxSizeAuditTargetOption).IsUnlimited,
                        size: (Literal)FromMutable((fragment as ScriptDom.MaxSizeAuditTargetOption).Size),
                        unit: (fragment as ScriptDom.MaxSizeAuditTargetOption).Unit,
                        optionKind: (fragment as ScriptDom.MaxSizeAuditTargetOption).OptionKind
                    );
                }
                case 591: {
                    return new MaxSizeDatabaseOption(
                        maxSize: (Literal)FromMutable((fragment as ScriptDom.MaxSizeDatabaseOption).MaxSize),
                        units: (fragment as ScriptDom.MaxSizeDatabaseOption).Units,
                        optionKind: (fragment as ScriptDom.MaxSizeDatabaseOption).OptionKind
                    );
                }
                case 592: {
                    return new MaxSizeFileDeclarationOption(
                        maxSize: (Literal)FromMutable((fragment as ScriptDom.MaxSizeFileDeclarationOption).MaxSize),
                        units: (fragment as ScriptDom.MaxSizeFileDeclarationOption).Units,
                        unlimited: (fragment as ScriptDom.MaxSizeFileDeclarationOption).Unlimited,
                        optionKind: (fragment as ScriptDom.MaxSizeFileDeclarationOption).OptionKind
                    );
                }
                case 593: {
                    return new MemoryOptimizedTableOption(
                        optionState: (fragment as ScriptDom.MemoryOptimizedTableOption).OptionState,
                        optionKind: (fragment as ScriptDom.MemoryOptimizedTableOption).OptionKind
                    );
                }
                case 594: {
                    return new MemoryPartitionSessionOption(
                        @value: (fragment as ScriptDom.MemoryPartitionSessionOption).Value,
                        optionKind: (fragment as ScriptDom.MemoryPartitionSessionOption).OptionKind
                    );
                }
                case 595: {
                    return new MergeActionClause(
                        condition: (fragment as ScriptDom.MergeActionClause).Condition,
                        searchCondition: (BooleanExpression)FromMutable((fragment as ScriptDom.MergeActionClause).SearchCondition),
                        action: (MergeAction)FromMutable((fragment as ScriptDom.MergeActionClause).Action)
                    );
                }
                case 596: {
                    return new MergeSpecification(
                        tableAlias: (Identifier)FromMutable((fragment as ScriptDom.MergeSpecification).TableAlias),
                        tableReference: (TableReference)FromMutable((fragment as ScriptDom.MergeSpecification).TableReference),
                        searchCondition: (BooleanExpression)FromMutable((fragment as ScriptDom.MergeSpecification).SearchCondition),
                        actionClauses: (fragment as ScriptDom.MergeSpecification).ActionClauses.SelectList(c => (MergeActionClause)FromMutable(c)),
                        target: (TableReference)FromMutable((fragment as ScriptDom.MergeSpecification).Target),
                        topRowFilter: (TopRowFilter)FromMutable((fragment as ScriptDom.MergeSpecification).TopRowFilter),
                        outputIntoClause: (OutputIntoClause)FromMutable((fragment as ScriptDom.MergeSpecification).OutputIntoClause),
                        outputClause: (OutputClause)FromMutable((fragment as ScriptDom.MergeSpecification).OutputClause)
                    );
                }
                case 597: {
                    return new MergeStatement(
                        mergeSpecification: (MergeSpecification)FromMutable((fragment as ScriptDom.MergeStatement).MergeSpecification),
                        withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable((fragment as ScriptDom.MergeStatement).WithCtesAndXmlNamespaces),
                        optimizerHints: (fragment as ScriptDom.MergeStatement).OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 598: {
                    return new MethodSpecifier(
                        assemblyName: (Identifier)FromMutable((fragment as ScriptDom.MethodSpecifier).AssemblyName),
                        className: (Identifier)FromMutable((fragment as ScriptDom.MethodSpecifier).ClassName),
                        methodName: (Identifier)FromMutable((fragment as ScriptDom.MethodSpecifier).MethodName)
                    );
                }
                case 599: {
                    return new MirrorToClause(
                        devices: (fragment as ScriptDom.MirrorToClause).Devices.SelectList(c => (DeviceInfo)FromMutable(c))
                    );
                }
                case 600: {
                    return new MoneyLiteral(
                        @value: (fragment as ScriptDom.MoneyLiteral).Value,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.MoneyLiteral).Collation)
                    );
                }
                case 601: {
                    return new MoveConversationStatement(
                        conversation: (ScalarExpression)FromMutable((fragment as ScriptDom.MoveConversationStatement).Conversation),
                        group: (ScalarExpression)FromMutable((fragment as ScriptDom.MoveConversationStatement).Group)
                    );
                }
                case 602: {
                    return new MoveRestoreOption(
                        logicalFileName: (ValueExpression)FromMutable((fragment as ScriptDom.MoveRestoreOption).LogicalFileName),
                        oSFileName: (ValueExpression)FromMutable((fragment as ScriptDom.MoveRestoreOption).OSFileName),
                        optionKind: (fragment as ScriptDom.MoveRestoreOption).OptionKind
                    );
                }
                case 603: {
                    return new MoveToDropIndexOption(
                        moveTo: (FileGroupOrPartitionScheme)FromMutable((fragment as ScriptDom.MoveToDropIndexOption).MoveTo),
                        optionKind: (fragment as ScriptDom.MoveToDropIndexOption).OptionKind
                    );
                }
                case 604: {
                    return new MultiPartIdentifier(
                        identifiers: (fragment as ScriptDom.MultiPartIdentifier).Identifiers.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 605: {
                    return new MultiPartIdentifierCallTarget(
                        multiPartIdentifier: (MultiPartIdentifier)FromMutable((fragment as ScriptDom.MultiPartIdentifierCallTarget).MultiPartIdentifier)
                    );
                }
                case 606: {
                    return new NamedTableReference(
                        schemaObject: (SchemaObjectName)FromMutable((fragment as ScriptDom.NamedTableReference).SchemaObject),
                        tableHints: (fragment as ScriptDom.NamedTableReference).TableHints.SelectList(c => (TableHint)FromMutable(c)),
                        tableSampleClause: (TableSampleClause)FromMutable((fragment as ScriptDom.NamedTableReference).TableSampleClause),
                        temporalClause: (TemporalClause)FromMutable((fragment as ScriptDom.NamedTableReference).TemporalClause),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.NamedTableReference).Alias),
                        forPath: (fragment as ScriptDom.NamedTableReference).ForPath
                    );
                }
                case 607: {
                    return new NameFileDeclarationOption(
                        logicalFileName: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.NameFileDeclarationOption).LogicalFileName),
                        isNewName: (fragment as ScriptDom.NameFileDeclarationOption).IsNewName,
                        optionKind: (fragment as ScriptDom.NameFileDeclarationOption).OptionKind
                    );
                }
                case 608: {
                    return new NextValueForExpression(
                        sequenceName: (SchemaObjectName)FromMutable((fragment as ScriptDom.NextValueForExpression).SequenceName),
                        overClause: (OverClause)FromMutable((fragment as ScriptDom.NextValueForExpression).OverClause),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.NextValueForExpression).Collation)
                    );
                }
                case 609: {
                    return new NullableConstraintDefinition(
                        nullable: (fragment as ScriptDom.NullableConstraintDefinition).Nullable,
                        constraintIdentifier: (Identifier)FromMutable((fragment as ScriptDom.NullableConstraintDefinition).ConstraintIdentifier)
                    );
                }
                case 610: {
                    return new NullIfExpression(
                        firstExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.NullIfExpression).FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.NullIfExpression).SecondExpression),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.NullIfExpression).Collation)
                    );
                }
                case 611: {
                    return new NullLiteral(
                        @value: (fragment as ScriptDom.NullLiteral).Value,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.NullLiteral).Collation)
                    );
                }
                case 612: {
                    return new NumericLiteral(
                        @value: (fragment as ScriptDom.NumericLiteral).Value,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.NumericLiteral).Collation)
                    );
                }
                case 613: {
                    return new OdbcConvertSpecification(
                        identifier: (Identifier)FromMutable((fragment as ScriptDom.OdbcConvertSpecification).Identifier)
                    );
                }
                case 614: {
                    return new OdbcFunctionCall(
                        name: (Identifier)FromMutable((fragment as ScriptDom.OdbcFunctionCall).Name),
                        parametersUsed: (fragment as ScriptDom.OdbcFunctionCall).ParametersUsed,
                        parameters: (fragment as ScriptDom.OdbcFunctionCall).Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.OdbcFunctionCall).Collation)
                    );
                }
                case 615: {
                    return new OdbcLiteral(
                        odbcLiteralType: (fragment as ScriptDom.OdbcLiteral).OdbcLiteralType,
                        isNational: (fragment as ScriptDom.OdbcLiteral).IsNational,
                        @value: (fragment as ScriptDom.OdbcLiteral).Value,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.OdbcLiteral).Collation)
                    );
                }
                case 616: {
                    return new OdbcQualifiedJoinTableReference(
                        tableReference: (TableReference)FromMutable((fragment as ScriptDom.OdbcQualifiedJoinTableReference).TableReference)
                    );
                }
                case 617: {
                    return new OffsetClause(
                        offsetExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.OffsetClause).OffsetExpression),
                        fetchExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.OffsetClause).FetchExpression)
                    );
                }
                case 618: {
                    return new OnFailureAuditOption(
                        onFailureAction: (fragment as ScriptDom.OnFailureAuditOption).OnFailureAction,
                        optionKind: (fragment as ScriptDom.OnFailureAuditOption).OptionKind
                    );
                }
                case 619: {
                    return new OnlineIndexLowPriorityLockWaitOption(
                        options: (fragment as ScriptDom.OnlineIndexLowPriorityLockWaitOption).Options.SelectList(c => (LowPriorityLockWaitOption)FromMutable(c))
                    );
                }
                case 620: {
                    return new OnlineIndexOption(
                        lowPriorityLockWaitOption: (OnlineIndexLowPriorityLockWaitOption)FromMutable((fragment as ScriptDom.OnlineIndexOption).LowPriorityLockWaitOption),
                        optionState: (fragment as ScriptDom.OnlineIndexOption).OptionState,
                        optionKind: (fragment as ScriptDom.OnlineIndexOption).OptionKind
                    );
                }
                case 621: {
                    return new OnOffAssemblyOption(
                        optionState: (fragment as ScriptDom.OnOffAssemblyOption).OptionState,
                        optionKind: (fragment as ScriptDom.OnOffAssemblyOption).OptionKind
                    );
                }
                case 622: {
                    return new OnOffAtomicBlockOption(
                        optionState: (fragment as ScriptDom.OnOffAtomicBlockOption).OptionState,
                        optionKind: (fragment as ScriptDom.OnOffAtomicBlockOption).OptionKind
                    );
                }
                case 623: {
                    return new OnOffAuditTargetOption(
                        @value: (fragment as ScriptDom.OnOffAuditTargetOption).Value,
                        optionKind: (fragment as ScriptDom.OnOffAuditTargetOption).OptionKind
                    );
                }
                case 624: {
                    return new OnOffDatabaseOption(
                        optionState: (fragment as ScriptDom.OnOffDatabaseOption).OptionState,
                        optionKind: (fragment as ScriptDom.OnOffDatabaseOption).OptionKind
                    );
                }
                case 625: {
                    return new OnOffDialogOption(
                        optionState: (fragment as ScriptDom.OnOffDialogOption).OptionState,
                        optionKind: (fragment as ScriptDom.OnOffDialogOption).OptionKind
                    );
                }
                case 626: {
                    return new OnOffFullTextCatalogOption(
                        optionState: (fragment as ScriptDom.OnOffFullTextCatalogOption).OptionState,
                        optionKind: (fragment as ScriptDom.OnOffFullTextCatalogOption).OptionKind
                    );
                }
                case 627: {
                    return new OnOffOptionValue(
                        optionState: (fragment as ScriptDom.OnOffOptionValue).OptionState
                    );
                }
                case 628: {
                    return new OnOffPrimaryConfigurationOption(
                        optionState: (fragment as ScriptDom.OnOffPrimaryConfigurationOption).OptionState,
                        optionKind: (fragment as ScriptDom.OnOffPrimaryConfigurationOption).OptionKind,
                        genericOptionKind: (Identifier)FromMutable((fragment as ScriptDom.OnOffPrimaryConfigurationOption).GenericOptionKind)
                    );
                }
                case 629: {
                    return new OnOffPrincipalOption(
                        optionState: (fragment as ScriptDom.OnOffPrincipalOption).OptionState,
                        optionKind: (fragment as ScriptDom.OnOffPrincipalOption).OptionKind
                    );
                }
                case 630: {
                    return new OnOffRemoteServiceBindingOption(
                        optionState: (fragment as ScriptDom.OnOffRemoteServiceBindingOption).OptionState,
                        optionKind: (fragment as ScriptDom.OnOffRemoteServiceBindingOption).OptionKind
                    );
                }
                case 631: {
                    return new OnOffSessionOption(
                        optionState: (fragment as ScriptDom.OnOffSessionOption).OptionState,
                        optionKind: (fragment as ScriptDom.OnOffSessionOption).OptionKind
                    );
                }
                case 632: {
                    return new OnOffStatisticsOption(
                        optionState: (fragment as ScriptDom.OnOffStatisticsOption).OptionState,
                        optionKind: (fragment as ScriptDom.OnOffStatisticsOption).OptionKind
                    );
                }
                case 633: {
                    return new OpenCursorStatement(
                        cursor: (CursorId)FromMutable((fragment as ScriptDom.OpenCursorStatement).Cursor)
                    );
                }
                case 634: {
                    return new OpenJsonTableReference(
                        variable: (ScalarExpression)FromMutable((fragment as ScriptDom.OpenJsonTableReference).Variable),
                        rowPattern: (ScalarExpression)FromMutable((fragment as ScriptDom.OpenJsonTableReference).RowPattern),
                        schemaDeclarationItems: (fragment as ScriptDom.OpenJsonTableReference).SchemaDeclarationItems.SelectList(c => (SchemaDeclarationItemOpenjson)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.OpenJsonTableReference).Alias),
                        forPath: (fragment as ScriptDom.OpenJsonTableReference).ForPath
                    );
                }
                case 635: {
                    return new OpenMasterKeyStatement(
                        password: (Literal)FromMutable((fragment as ScriptDom.OpenMasterKeyStatement).Password)
                    );
                }
                case 636: {
                    return new OpenQueryTableReference(
                        linkedServer: (Identifier)FromMutable((fragment as ScriptDom.OpenQueryTableReference).LinkedServer),
                        query: (StringLiteral)FromMutable((fragment as ScriptDom.OpenQueryTableReference).Query),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.OpenQueryTableReference).Alias),
                        forPath: (fragment as ScriptDom.OpenQueryTableReference).ForPath
                    );
                }
                case 637: {
                    return new OpenRowsetColumnDefinition(
                        columnOrdinal: (IntegerLiteral)FromMutable((fragment as ScriptDom.OpenRowsetColumnDefinition).ColumnOrdinal),
                        jsonPath: (StringLiteral)FromMutable((fragment as ScriptDom.OpenRowsetColumnDefinition).JsonPath),
                        columnIdentifier: (Identifier)FromMutable((fragment as ScriptDom.OpenRowsetColumnDefinition).ColumnIdentifier),
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.OpenRowsetColumnDefinition).DataType),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.OpenRowsetColumnDefinition).Collation)
                    );
                }
                case 638: {
                    return new OpenRowsetCosmos(
                        options: (fragment as ScriptDom.OpenRowsetCosmos).Options.SelectList(c => (OpenRowsetCosmosOption)FromMutable(c)),
                        withColumns: (fragment as ScriptDom.OpenRowsetCosmos).WithColumns.SelectList(c => (OpenRowsetColumnDefinition)FromMutable(c)),
                        columns: (fragment as ScriptDom.OpenRowsetCosmos).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.OpenRowsetCosmos).Alias),
                        forPath: (fragment as ScriptDom.OpenRowsetCosmos).ForPath
                    );
                }
                case 639: {
                    return new OpenRowsetCosmosOption(
                        optionKind: (fragment as ScriptDom.OpenRowsetCosmosOption).OptionKind
                    );
                }
                case 640: {
                    return new OpenRowsetTableReference(
                        providerName: (StringLiteral)FromMutable((fragment as ScriptDom.OpenRowsetTableReference).ProviderName),
                        dataSource: (StringLiteral)FromMutable((fragment as ScriptDom.OpenRowsetTableReference).DataSource),
                        userId: (StringLiteral)FromMutable((fragment as ScriptDom.OpenRowsetTableReference).UserId),
                        password: (StringLiteral)FromMutable((fragment as ScriptDom.OpenRowsetTableReference).Password),
                        providerString: (StringLiteral)FromMutable((fragment as ScriptDom.OpenRowsetTableReference).ProviderString),
                        query: (StringLiteral)FromMutable((fragment as ScriptDom.OpenRowsetTableReference).Query),
                        @object: (SchemaObjectName)FromMutable((fragment as ScriptDom.OpenRowsetTableReference).Object),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.OpenRowsetTableReference).Alias),
                        forPath: (fragment as ScriptDom.OpenRowsetTableReference).ForPath
                    );
                }
                case 641: {
                    return new OpenSymmetricKeyStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.OpenSymmetricKeyStatement).Name),
                        decryptionMechanism: (CryptoMechanism)FromMutable((fragment as ScriptDom.OpenSymmetricKeyStatement).DecryptionMechanism)
                    );
                }
                case 642: {
                    return new OpenXmlTableReference(
                        variable: (VariableReference)FromMutable((fragment as ScriptDom.OpenXmlTableReference).Variable),
                        rowPattern: (ValueExpression)FromMutable((fragment as ScriptDom.OpenXmlTableReference).RowPattern),
                        flags: (ValueExpression)FromMutable((fragment as ScriptDom.OpenXmlTableReference).Flags),
                        schemaDeclarationItems: (fragment as ScriptDom.OpenXmlTableReference).SchemaDeclarationItems.SelectList(c => (SchemaDeclarationItem)FromMutable(c)),
                        tableName: (SchemaObjectName)FromMutable((fragment as ScriptDom.OpenXmlTableReference).TableName),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.OpenXmlTableReference).Alias),
                        forPath: (fragment as ScriptDom.OpenXmlTableReference).ForPath
                    );
                }
                case 643: {
                    return new OperatorAuditOption(
                        @value: (fragment as ScriptDom.OperatorAuditOption).Value,
                        optionKind: (fragment as ScriptDom.OperatorAuditOption).OptionKind
                    );
                }
                case 644: {
                    return new OptimizeForOptimizerHint(
                        pairs: (fragment as ScriptDom.OptimizeForOptimizerHint).Pairs.SelectList(c => (VariableValuePair)FromMutable(c)),
                        isForUnknown: (fragment as ScriptDom.OptimizeForOptimizerHint).IsForUnknown,
                        hintKind: (fragment as ScriptDom.OptimizeForOptimizerHint).HintKind
                    );
                }
                case 645: {
                    return new OptimizerHint(
                        hintKind: (fragment as ScriptDom.OptimizerHint).HintKind
                    );
                }
                case 646: {
                    return new OrderBulkInsertOption(
                        columns: (fragment as ScriptDom.OrderBulkInsertOption).Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                        isUnique: (fragment as ScriptDom.OrderBulkInsertOption).IsUnique,
                        optionKind: (fragment as ScriptDom.OrderBulkInsertOption).OptionKind
                    );
                }
                case 647: {
                    return new OrderByClause(
                        orderByElements: (fragment as ScriptDom.OrderByClause).OrderByElements.SelectList(c => (ExpressionWithSortOrder)FromMutable(c))
                    );
                }
                case 648: {
                    return new OrderIndexOption(
                        columns: (fragment as ScriptDom.OrderIndexOption).Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.OrderIndexOption).OptionKind
                    );
                }
                case 649: {
                    return new OutputClause(
                        selectColumns: (fragment as ScriptDom.OutputClause).SelectColumns.SelectList(c => (SelectElement)FromMutable(c))
                    );
                }
                case 650: {
                    return new OutputIntoClause(
                        selectColumns: (fragment as ScriptDom.OutputIntoClause).SelectColumns.SelectList(c => (SelectElement)FromMutable(c)),
                        intoTable: (TableReference)FromMutable((fragment as ScriptDom.OutputIntoClause).IntoTable),
                        intoTableColumns: (fragment as ScriptDom.OutputIntoClause).IntoTableColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
                    );
                }
                case 651: {
                    return new OverClause(
                        windowName: (Identifier)FromMutable((fragment as ScriptDom.OverClause).WindowName),
                        partitions: (fragment as ScriptDom.OverClause).Partitions.SelectList(c => (ScalarExpression)FromMutable(c)),
                        orderByClause: (OrderByClause)FromMutable((fragment as ScriptDom.OverClause).OrderByClause),
                        windowFrameClause: (WindowFrameClause)FromMutable((fragment as ScriptDom.OverClause).WindowFrameClause)
                    );
                }
                case 652: {
                    return new PageVerifyDatabaseOption(
                        @value: (fragment as ScriptDom.PageVerifyDatabaseOption).Value,
                        optionKind: (fragment as ScriptDom.PageVerifyDatabaseOption).OptionKind
                    );
                }
                case 653: {
                    return new ParameterizationDatabaseOption(
                        isSimple: (fragment as ScriptDom.ParameterizationDatabaseOption).IsSimple,
                        optionKind: (fragment as ScriptDom.ParameterizationDatabaseOption).OptionKind
                    );
                }
                case 654: {
                    return new ParameterlessCall(
                        parameterlessCallType: (fragment as ScriptDom.ParameterlessCall).ParameterlessCallType,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.ParameterlessCall).Collation)
                    );
                }
                case 655: {
                    return new ParenthesisExpression(
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.ParenthesisExpression).Expression),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.ParenthesisExpression).Collation)
                    );
                }
                case 656: {
                    return new ParseCall(
                        stringValue: (ScalarExpression)FromMutable((fragment as ScriptDom.ParseCall).StringValue),
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.ParseCall).DataType),
                        culture: (ScalarExpression)FromMutable((fragment as ScriptDom.ParseCall).Culture),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.ParseCall).Collation)
                    );
                }
                case 657: {
                    return new PartitionFunctionCall(
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.PartitionFunctionCall).DatabaseName),
                        functionName: (Identifier)FromMutable((fragment as ScriptDom.PartitionFunctionCall).FunctionName),
                        parameters: (fragment as ScriptDom.PartitionFunctionCall).Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.PartitionFunctionCall).Collation)
                    );
                }
                case 658: {
                    return new PartitionParameterType(
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.PartitionParameterType).DataType),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.PartitionParameterType).Collation)
                    );
                }
                case 659: {
                    return new PartitionSpecifier(
                        number: (ScalarExpression)FromMutable((fragment as ScriptDom.PartitionSpecifier).Number),
                        all: (fragment as ScriptDom.PartitionSpecifier).All
                    );
                }
                case 660: {
                    return new PartnerDatabaseOption(
                        partnerServer: (Literal)FromMutable((fragment as ScriptDom.PartnerDatabaseOption).PartnerServer),
                        partnerOption: (fragment as ScriptDom.PartnerDatabaseOption).PartnerOption,
                        timeout: (Literal)FromMutable((fragment as ScriptDom.PartnerDatabaseOption).Timeout),
                        optionKind: (fragment as ScriptDom.PartnerDatabaseOption).OptionKind
                    );
                }
                case 661: {
                    return new PasswordAlterPrincipalOption(
                        password: (Literal)FromMutable((fragment as ScriptDom.PasswordAlterPrincipalOption).Password),
                        oldPassword: (Literal)FromMutable((fragment as ScriptDom.PasswordAlterPrincipalOption).OldPassword),
                        mustChange: (fragment as ScriptDom.PasswordAlterPrincipalOption).MustChange,
                        unlock: (fragment as ScriptDom.PasswordAlterPrincipalOption).Unlock,
                        hashed: (fragment as ScriptDom.PasswordAlterPrincipalOption).Hashed,
                        optionKind: (fragment as ScriptDom.PasswordAlterPrincipalOption).OptionKind
                    );
                }
                case 662: {
                    return new PasswordCreateLoginSource(
                        password: (Literal)FromMutable((fragment as ScriptDom.PasswordCreateLoginSource).Password),
                        hashed: (fragment as ScriptDom.PasswordCreateLoginSource).Hashed,
                        mustChange: (fragment as ScriptDom.PasswordCreateLoginSource).MustChange,
                        options: (fragment as ScriptDom.PasswordCreateLoginSource).Options.SelectList(c => (PrincipalOption)FromMutable(c))
                    );
                }
                case 663: {
                    return new Permission(
                        identifiers: (fragment as ScriptDom.Permission).Identifiers.SelectList(c => (Identifier)FromMutable(c)),
                        columns: (fragment as ScriptDom.Permission).Columns.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 664: {
                    return new PermissionSetAssemblyOption(
                        permissionSetOption: (fragment as ScriptDom.PermissionSetAssemblyOption).PermissionSetOption,
                        optionKind: (fragment as ScriptDom.PermissionSetAssemblyOption).OptionKind
                    );
                }
                case 665: {
                    return new PivotedTableReference(
                        tableReference: (TableReference)FromMutable((fragment as ScriptDom.PivotedTableReference).TableReference),
                        inColumns: (fragment as ScriptDom.PivotedTableReference).InColumns.SelectList(c => (Identifier)FromMutable(c)),
                        pivotColumn: (ColumnReferenceExpression)FromMutable((fragment as ScriptDom.PivotedTableReference).PivotColumn),
                        valueColumns: (fragment as ScriptDom.PivotedTableReference).ValueColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        aggregateFunctionIdentifier: (MultiPartIdentifier)FromMutable((fragment as ScriptDom.PivotedTableReference).AggregateFunctionIdentifier),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.PivotedTableReference).Alias),
                        forPath: (fragment as ScriptDom.PivotedTableReference).ForPath
                    );
                }
                case 666: {
                    return new PortsEndpointProtocolOption(
                        portTypes: (fragment as ScriptDom.PortsEndpointProtocolOption).PortTypes,
                        kind: (fragment as ScriptDom.PortsEndpointProtocolOption).Kind
                    );
                }
                case 667: {
                    return new PredicateSetStatement(
                        options: (fragment as ScriptDom.PredicateSetStatement).Options,
                        isOn: (fragment as ScriptDom.PredicateSetStatement).IsOn
                    );
                }
                case 668: {
                    return new PredictTableReference(
                        modelVariable: (ScalarExpression)FromMutable((fragment as ScriptDom.PredictTableReference).ModelVariable),
                        modelSubquery: (ScalarSubquery)FromMutable((fragment as ScriptDom.PredictTableReference).ModelSubquery),
                        dataSource: (TableReferenceWithAlias)FromMutable((fragment as ScriptDom.PredictTableReference).DataSource),
                        runTime: (Identifier)FromMutable((fragment as ScriptDom.PredictTableReference).RunTime),
                        schemaDeclarationItems: (fragment as ScriptDom.PredictTableReference).SchemaDeclarationItems.SelectList(c => (SchemaDeclarationItem)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.PredictTableReference).Alias),
                        forPath: (fragment as ScriptDom.PredictTableReference).ForPath
                    );
                }
                case 669: {
                    return new PrimaryRoleReplicaOption(
                        allowConnections: (fragment as ScriptDom.PrimaryRoleReplicaOption).AllowConnections,
                        optionKind: (fragment as ScriptDom.PrimaryRoleReplicaOption).OptionKind
                    );
                }
                case 670: {
                    return new PrincipalOption(
                        optionKind: (fragment as ScriptDom.PrincipalOption).OptionKind
                    );
                }
                case 671: {
                    return new PrintStatement(
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.PrintStatement).Expression)
                    );
                }
                case 672: {
                    return new Privilege80(
                        columns: (fragment as ScriptDom.Privilege80).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        privilegeType80: (fragment as ScriptDom.Privilege80).PrivilegeType80
                    );
                }
                case 673: {
                    return new PrivilegeSecurityElement80(
                        privileges: (fragment as ScriptDom.PrivilegeSecurityElement80).Privileges.SelectList(c => (Privilege80)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.PrivilegeSecurityElement80).SchemaObjectName),
                        columns: (fragment as ScriptDom.PrivilegeSecurityElement80).Columns.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 674: {
                    return new ProcedureOption(
                        optionKind: (fragment as ScriptDom.ProcedureOption).OptionKind
                    );
                }
                case 675: {
                    return new ProcedureParameter(
                        isVarying: (fragment as ScriptDom.ProcedureParameter).IsVarying,
                        modifier: (fragment as ScriptDom.ProcedureParameter).Modifier,
                        variableName: (Identifier)FromMutable((fragment as ScriptDom.ProcedureParameter).VariableName),
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.ProcedureParameter).DataType),
                        nullable: (NullableConstraintDefinition)FromMutable((fragment as ScriptDom.ProcedureParameter).Nullable),
                        @value: (ScalarExpression)FromMutable((fragment as ScriptDom.ProcedureParameter).Value)
                    );
                }
                case 676: {
                    return new ProcedureReference(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.ProcedureReference).Name),
                        number: (Literal)FromMutable((fragment as ScriptDom.ProcedureReference).Number)
                    );
                }
                case 677: {
                    return new ProcedureReferenceName(
                        procedureReference: (ProcedureReference)FromMutable((fragment as ScriptDom.ProcedureReferenceName).ProcedureReference),
                        procedureVariable: (VariableReference)FromMutable((fragment as ScriptDom.ProcedureReferenceName).ProcedureVariable)
                    );
                }
                case 678: {
                    return new ProcessAffinityRange(
                        from: (Literal)FromMutable((fragment as ScriptDom.ProcessAffinityRange).From),
                        to: (Literal)FromMutable((fragment as ScriptDom.ProcessAffinityRange).To)
                    );
                }
                case 679: {
                    return new ProviderEncryptionSource(
                        name: (Identifier)FromMutable((fragment as ScriptDom.ProviderEncryptionSource).Name),
                        keyOptions: (fragment as ScriptDom.ProviderEncryptionSource).KeyOptions.SelectList(c => (KeyOption)FromMutable(c))
                    );
                }
                case 680: {
                    return new ProviderKeyNameKeyOption(
                        keyName: (Literal)FromMutable((fragment as ScriptDom.ProviderKeyNameKeyOption).KeyName),
                        optionKind: (fragment as ScriptDom.ProviderKeyNameKeyOption).OptionKind
                    );
                }
                case 681: {
                    return new QualifiedJoin(
                        searchCondition: (BooleanExpression)FromMutable((fragment as ScriptDom.QualifiedJoin).SearchCondition),
                        qualifiedJoinType: (fragment as ScriptDom.QualifiedJoin).QualifiedJoinType,
                        joinHint: (fragment as ScriptDom.QualifiedJoin).JoinHint,
                        firstTableReference: (TableReference)FromMutable((fragment as ScriptDom.QualifiedJoin).FirstTableReference),
                        secondTableReference: (TableReference)FromMutable((fragment as ScriptDom.QualifiedJoin).SecondTableReference)
                    );
                }
                case 682: {
                    return new QueryDerivedTable(
                        queryExpression: (QueryExpression)FromMutable((fragment as ScriptDom.QueryDerivedTable).QueryExpression),
                        columns: (fragment as ScriptDom.QueryDerivedTable).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.QueryDerivedTable).Alias),
                        forPath: (fragment as ScriptDom.QueryDerivedTable).ForPath
                    );
                }
                case 683: {
                    return new QueryParenthesisExpression(
                        queryExpression: (QueryExpression)FromMutable((fragment as ScriptDom.QueryParenthesisExpression).QueryExpression),
                        orderByClause: (OrderByClause)FromMutable((fragment as ScriptDom.QueryParenthesisExpression).OrderByClause),
                        offsetClause: (OffsetClause)FromMutable((fragment as ScriptDom.QueryParenthesisExpression).OffsetClause),
                        forClause: (ForClause)FromMutable((fragment as ScriptDom.QueryParenthesisExpression).ForClause)
                    );
                }
                case 684: {
                    return new QuerySpecification(
                        uniqueRowFilter: (fragment as ScriptDom.QuerySpecification).UniqueRowFilter,
                        topRowFilter: (TopRowFilter)FromMutable((fragment as ScriptDom.QuerySpecification).TopRowFilter),
                        selectElements: (fragment as ScriptDom.QuerySpecification).SelectElements.SelectList(c => (SelectElement)FromMutable(c)),
                        fromClause: (FromClause)FromMutable((fragment as ScriptDom.QuerySpecification).FromClause),
                        whereClause: (WhereClause)FromMutable((fragment as ScriptDom.QuerySpecification).WhereClause),
                        groupByClause: (GroupByClause)FromMutable((fragment as ScriptDom.QuerySpecification).GroupByClause),
                        havingClause: (HavingClause)FromMutable((fragment as ScriptDom.QuerySpecification).HavingClause),
                        windowClause: (WindowClause)FromMutable((fragment as ScriptDom.QuerySpecification).WindowClause),
                        orderByClause: (OrderByClause)FromMutable((fragment as ScriptDom.QuerySpecification).OrderByClause),
                        offsetClause: (OffsetClause)FromMutable((fragment as ScriptDom.QuerySpecification).OffsetClause),
                        forClause: (ForClause)FromMutable((fragment as ScriptDom.QuerySpecification).ForClause)
                    );
                }
                case 685: {
                    return new QueryStoreCapturePolicyOption(
                        @value: (fragment as ScriptDom.QueryStoreCapturePolicyOption).Value,
                        optionKind: (fragment as ScriptDom.QueryStoreCapturePolicyOption).OptionKind
                    );
                }
                case 686: {
                    return new QueryStoreDatabaseOption(
                        clear: (fragment as ScriptDom.QueryStoreDatabaseOption).Clear,
                        clearAll: (fragment as ScriptDom.QueryStoreDatabaseOption).ClearAll,
                        optionState: (fragment as ScriptDom.QueryStoreDatabaseOption).OptionState,
                        options: (fragment as ScriptDom.QueryStoreDatabaseOption).Options.SelectList(c => (QueryStoreOption)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.QueryStoreDatabaseOption).OptionKind
                    );
                }
                case 687: {
                    return new QueryStoreDataFlushIntervalOption(
                        flushInterval: (Literal)FromMutable((fragment as ScriptDom.QueryStoreDataFlushIntervalOption).FlushInterval),
                        optionKind: (fragment as ScriptDom.QueryStoreDataFlushIntervalOption).OptionKind
                    );
                }
                case 688: {
                    return new QueryStoreDesiredStateOption(
                        @value: (fragment as ScriptDom.QueryStoreDesiredStateOption).Value,
                        operationModeSpecified: (fragment as ScriptDom.QueryStoreDesiredStateOption).OperationModeSpecified,
                        optionKind: (fragment as ScriptDom.QueryStoreDesiredStateOption).OptionKind
                    );
                }
                case 689: {
                    return new QueryStoreIntervalLengthOption(
                        statsIntervalLength: (Literal)FromMutable((fragment as ScriptDom.QueryStoreIntervalLengthOption).StatsIntervalLength),
                        optionKind: (fragment as ScriptDom.QueryStoreIntervalLengthOption).OptionKind
                    );
                }
                case 690: {
                    return new QueryStoreMaxPlansPerQueryOption(
                        maxPlansPerQuery: (Literal)FromMutable((fragment as ScriptDom.QueryStoreMaxPlansPerQueryOption).MaxPlansPerQuery),
                        optionKind: (fragment as ScriptDom.QueryStoreMaxPlansPerQueryOption).OptionKind
                    );
                }
                case 691: {
                    return new QueryStoreMaxStorageSizeOption(
                        maxQdsSize: (Literal)FromMutable((fragment as ScriptDom.QueryStoreMaxStorageSizeOption).MaxQdsSize),
                        optionKind: (fragment as ScriptDom.QueryStoreMaxStorageSizeOption).OptionKind
                    );
                }
                case 692: {
                    return new QueryStoreSizeCleanupPolicyOption(
                        @value: (fragment as ScriptDom.QueryStoreSizeCleanupPolicyOption).Value,
                        optionKind: (fragment as ScriptDom.QueryStoreSizeCleanupPolicyOption).OptionKind
                    );
                }
                case 693: {
                    return new QueryStoreTimeCleanupPolicyOption(
                        staleQueryThreshold: (Literal)FromMutable((fragment as ScriptDom.QueryStoreTimeCleanupPolicyOption).StaleQueryThreshold),
                        optionKind: (fragment as ScriptDom.QueryStoreTimeCleanupPolicyOption).OptionKind
                    );
                }
                case 694: {
                    return new QueueDelayAuditOption(
                        delay: (Literal)FromMutable((fragment as ScriptDom.QueueDelayAuditOption).Delay),
                        optionKind: (fragment as ScriptDom.QueueDelayAuditOption).OptionKind
                    );
                }
                case 695: {
                    return new QueueExecuteAsOption(
                        optionValue: (ExecuteAsClause)FromMutable((fragment as ScriptDom.QueueExecuteAsOption).OptionValue),
                        optionKind: (fragment as ScriptDom.QueueExecuteAsOption).OptionKind
                    );
                }
                case 696: {
                    return new QueueOption(
                        optionKind: (fragment as ScriptDom.QueueOption).OptionKind
                    );
                }
                case 697: {
                    return new QueueProcedureOption(
                        optionValue: (SchemaObjectName)FromMutable((fragment as ScriptDom.QueueProcedureOption).OptionValue),
                        optionKind: (fragment as ScriptDom.QueueProcedureOption).OptionKind
                    );
                }
                case 698: {
                    return new QueueStateOption(
                        optionState: (fragment as ScriptDom.QueueStateOption).OptionState,
                        optionKind: (fragment as ScriptDom.QueueStateOption).OptionKind
                    );
                }
                case 699: {
                    return new QueueValueOption(
                        optionValue: (ValueExpression)FromMutable((fragment as ScriptDom.QueueValueOption).OptionValue),
                        optionKind: (fragment as ScriptDom.QueueValueOption).OptionKind
                    );
                }
                case 700: {
                    return new RaiseErrorLegacyStatement(
                        firstParameter: (ScalarExpression)FromMutable((fragment as ScriptDom.RaiseErrorLegacyStatement).FirstParameter),
                        secondParameter: (ValueExpression)FromMutable((fragment as ScriptDom.RaiseErrorLegacyStatement).SecondParameter)
                    );
                }
                case 701: {
                    return new RaiseErrorStatement(
                        firstParameter: (ScalarExpression)FromMutable((fragment as ScriptDom.RaiseErrorStatement).FirstParameter),
                        secondParameter: (ScalarExpression)FromMutable((fragment as ScriptDom.RaiseErrorStatement).SecondParameter),
                        thirdParameter: (ScalarExpression)FromMutable((fragment as ScriptDom.RaiseErrorStatement).ThirdParameter),
                        optionalParameters: (fragment as ScriptDom.RaiseErrorStatement).OptionalParameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        raiseErrorOptions: (fragment as ScriptDom.RaiseErrorStatement).RaiseErrorOptions
                    );
                }
                case 702: {
                    return new ReadOnlyForClause(
                        
                    );
                }
                case 703: {
                    return new ReadTextStatement(
                        column: (ColumnReferenceExpression)FromMutable((fragment as ScriptDom.ReadTextStatement).Column),
                        textPointer: (ValueExpression)FromMutable((fragment as ScriptDom.ReadTextStatement).TextPointer),
                        offset: (ValueExpression)FromMutable((fragment as ScriptDom.ReadTextStatement).Offset),
                        size: (ValueExpression)FromMutable((fragment as ScriptDom.ReadTextStatement).Size),
                        holdLock: (fragment as ScriptDom.ReadTextStatement).HoldLock
                    );
                }
                case 704: {
                    return new RealLiteral(
                        @value: (fragment as ScriptDom.RealLiteral).Value,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.RealLiteral).Collation)
                    );
                }
                case 705: {
                    return new ReceiveStatement(
                        top: (ScalarExpression)FromMutable((fragment as ScriptDom.ReceiveStatement).Top),
                        selectElements: (fragment as ScriptDom.ReceiveStatement).SelectElements.SelectList(c => (SelectElement)FromMutable(c)),
                        queue: (SchemaObjectName)FromMutable((fragment as ScriptDom.ReceiveStatement).Queue),
                        into: (VariableTableReference)FromMutable((fragment as ScriptDom.ReceiveStatement).Into),
                        where: (ValueExpression)FromMutable((fragment as ScriptDom.ReceiveStatement).Where),
                        isConversationGroupIdWhere: (fragment as ScriptDom.ReceiveStatement).IsConversationGroupIdWhere
                    );
                }
                case 706: {
                    return new ReconfigureStatement(
                        withOverride: (fragment as ScriptDom.ReconfigureStatement).WithOverride
                    );
                }
                case 707: {
                    return new RecoveryDatabaseOption(
                        @value: (fragment as ScriptDom.RecoveryDatabaseOption).Value,
                        optionKind: (fragment as ScriptDom.RecoveryDatabaseOption).OptionKind
                    );
                }
                case 708: {
                    return new RemoteDataArchiveAlterTableOption(
                        rdaTableOption: (fragment as ScriptDom.RemoteDataArchiveAlterTableOption).RdaTableOption,
                        migrationState: (fragment as ScriptDom.RemoteDataArchiveAlterTableOption).MigrationState,
                        isMigrationStateSpecified: (fragment as ScriptDom.RemoteDataArchiveAlterTableOption).IsMigrationStateSpecified,
                        isFilterPredicateSpecified: (fragment as ScriptDom.RemoteDataArchiveAlterTableOption).IsFilterPredicateSpecified,
                        filterPredicate: (FunctionCall)FromMutable((fragment as ScriptDom.RemoteDataArchiveAlterTableOption).FilterPredicate),
                        optionKind: (fragment as ScriptDom.RemoteDataArchiveAlterTableOption).OptionKind
                    );
                }
                case 709: {
                    return new RemoteDataArchiveDatabaseOption(
                        optionState: (fragment as ScriptDom.RemoteDataArchiveDatabaseOption).OptionState,
                        settings: (fragment as ScriptDom.RemoteDataArchiveDatabaseOption).Settings.SelectList(c => (RemoteDataArchiveDatabaseSetting)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.RemoteDataArchiveDatabaseOption).OptionKind
                    );
                }
                case 710: {
                    return new RemoteDataArchiveDbCredentialSetting(
                        credential: (Identifier)FromMutable((fragment as ScriptDom.RemoteDataArchiveDbCredentialSetting).Credential),
                        settingKind: (fragment as ScriptDom.RemoteDataArchiveDbCredentialSetting).SettingKind
                    );
                }
                case 711: {
                    return new RemoteDataArchiveDbFederatedServiceAccountSetting(
                        isOn: (fragment as ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting).IsOn,
                        settingKind: (fragment as ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting).SettingKind
                    );
                }
                case 712: {
                    return new RemoteDataArchiveDbServerSetting(
                        server: (StringLiteral)FromMutable((fragment as ScriptDom.RemoteDataArchiveDbServerSetting).Server),
                        settingKind: (fragment as ScriptDom.RemoteDataArchiveDbServerSetting).SettingKind
                    );
                }
                case 713: {
                    return new RemoteDataArchiveTableOption(
                        rdaTableOption: (fragment as ScriptDom.RemoteDataArchiveTableOption).RdaTableOption,
                        migrationState: (fragment as ScriptDom.RemoteDataArchiveTableOption).MigrationState,
                        optionKind: (fragment as ScriptDom.RemoteDataArchiveTableOption).OptionKind
                    );
                }
                case 714: {
                    return new RenameAlterRoleAction(
                        newName: (Identifier)FromMutable((fragment as ScriptDom.RenameAlterRoleAction).NewName)
                    );
                }
                case 715: {
                    return new RenameEntityStatement(
                        renameEntityType: (fragment as ScriptDom.RenameEntityStatement).RenameEntityType,
                        separatorType: (fragment as ScriptDom.RenameEntityStatement).SeparatorType,
                        oldName: (SchemaObjectName)FromMutable((fragment as ScriptDom.RenameEntityStatement).OldName),
                        newName: (Identifier)FromMutable((fragment as ScriptDom.RenameEntityStatement).NewName)
                    );
                }
                case 716: {
                    return new ResampleStatisticsOption(
                        partitions: (fragment as ScriptDom.ResampleStatisticsOption).Partitions.SelectList(c => (StatisticsPartitionRange)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.ResampleStatisticsOption).OptionKind
                    );
                }
                case 717: {
                    return new ResourcePoolAffinitySpecification(
                        affinityType: (fragment as ScriptDom.ResourcePoolAffinitySpecification).AffinityType,
                        parameterValue: (Literal)FromMutable((fragment as ScriptDom.ResourcePoolAffinitySpecification).ParameterValue),
                        isAuto: (fragment as ScriptDom.ResourcePoolAffinitySpecification).IsAuto,
                        poolAffinityRanges: (fragment as ScriptDom.ResourcePoolAffinitySpecification).PoolAffinityRanges.SelectList(c => (LiteralRange)FromMutable(c))
                    );
                }
                case 718: {
                    return new ResourcePoolParameter(
                        parameterType: (fragment as ScriptDom.ResourcePoolParameter).ParameterType,
                        parameterValue: (Literal)FromMutable((fragment as ScriptDom.ResourcePoolParameter).ParameterValue),
                        affinitySpecification: (ResourcePoolAffinitySpecification)FromMutable((fragment as ScriptDom.ResourcePoolParameter).AffinitySpecification)
                    );
                }
                case 719: {
                    return new ResourcePoolStatement(
                        name: (Identifier)FromMutable((fragment as ScriptDom.ResourcePoolStatement).Name),
                        resourcePoolParameters: (fragment as ScriptDom.ResourcePoolStatement).ResourcePoolParameters.SelectList(c => (ResourcePoolParameter)FromMutable(c))
                    );
                }
                case 720: {
                    return new RestoreMasterKeyStatement(
                        isForce: (fragment as ScriptDom.RestoreMasterKeyStatement).IsForce,
                        encryptionPassword: (Literal)FromMutable((fragment as ScriptDom.RestoreMasterKeyStatement).EncryptionPassword),
                        file: (Literal)FromMutable((fragment as ScriptDom.RestoreMasterKeyStatement).File),
                        password: (Literal)FromMutable((fragment as ScriptDom.RestoreMasterKeyStatement).Password)
                    );
                }
                case 721: {
                    return new RestoreOption(
                        optionKind: (fragment as ScriptDom.RestoreOption).OptionKind
                    );
                }
                case 722: {
                    return new RestoreServiceMasterKeyStatement(
                        isForce: (fragment as ScriptDom.RestoreServiceMasterKeyStatement).IsForce,
                        file: (Literal)FromMutable((fragment as ScriptDom.RestoreServiceMasterKeyStatement).File),
                        password: (Literal)FromMutable((fragment as ScriptDom.RestoreServiceMasterKeyStatement).Password)
                    );
                }
                case 723: {
                    return new RestoreStatement(
                        databaseName: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.RestoreStatement).DatabaseName),
                        devices: (fragment as ScriptDom.RestoreStatement).Devices.SelectList(c => (DeviceInfo)FromMutable(c)),
                        files: (fragment as ScriptDom.RestoreStatement).Files.SelectList(c => (BackupRestoreFileInfo)FromMutable(c)),
                        options: (fragment as ScriptDom.RestoreStatement).Options.SelectList(c => (RestoreOption)FromMutable(c)),
                        kind: (fragment as ScriptDom.RestoreStatement).Kind
                    );
                }
                case 724: {
                    return new ResultColumnDefinition(
                        columnDefinition: (ColumnDefinitionBase)FromMutable((fragment as ScriptDom.ResultColumnDefinition).ColumnDefinition),
                        nullable: (NullableConstraintDefinition)FromMutable((fragment as ScriptDom.ResultColumnDefinition).Nullable)
                    );
                }
                case 725: {
                    return new ResultSetDefinition(
                        resultSetType: (fragment as ScriptDom.ResultSetDefinition).ResultSetType
                    );
                }
                case 726: {
                    return new ResultSetsExecuteOption(
                        resultSetsOptionKind: (fragment as ScriptDom.ResultSetsExecuteOption).ResultSetsOptionKind,
                        definitions: (fragment as ScriptDom.ResultSetsExecuteOption).Definitions.SelectList(c => (ResultSetDefinition)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.ResultSetsExecuteOption).OptionKind
                    );
                }
                case 727: {
                    return new RetentionDaysAuditTargetOption(
                        days: (Literal)FromMutable((fragment as ScriptDom.RetentionDaysAuditTargetOption).Days),
                        optionKind: (fragment as ScriptDom.RetentionDaysAuditTargetOption).OptionKind
                    );
                }
                case 728: {
                    return new RetentionPeriodDefinition(
                        duration: (IntegerLiteral)FromMutable((fragment as ScriptDom.RetentionPeriodDefinition).Duration),
                        units: (fragment as ScriptDom.RetentionPeriodDefinition).Units,
                        isInfinity: (fragment as ScriptDom.RetentionPeriodDefinition).IsInfinity
                    );
                }
                case 729: {
                    return new ReturnStatement(
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.ReturnStatement).Expression)
                    );
                }
                case 730: {
                    return new RevertStatement(
                        cookie: (ScalarExpression)FromMutable((fragment as ScriptDom.RevertStatement).Cookie)
                    );
                }
                case 731: {
                    return new RevokeStatement(
                        grantOptionFor: (fragment as ScriptDom.RevokeStatement).GrantOptionFor,
                        cascadeOption: (fragment as ScriptDom.RevokeStatement).CascadeOption,
                        permissions: (fragment as ScriptDom.RevokeStatement).Permissions.SelectList(c => (Permission)FromMutable(c)),
                        securityTargetObject: (SecurityTargetObject)FromMutable((fragment as ScriptDom.RevokeStatement).SecurityTargetObject),
                        principals: (fragment as ScriptDom.RevokeStatement).Principals.SelectList(c => (SecurityPrincipal)FromMutable(c)),
                        asClause: (Identifier)FromMutable((fragment as ScriptDom.RevokeStatement).AsClause)
                    );
                }
                case 732: {
                    return new RevokeStatement80(
                        grantOptionFor: (fragment as ScriptDom.RevokeStatement80).GrantOptionFor,
                        cascadeOption: (fragment as ScriptDom.RevokeStatement80).CascadeOption,
                        asClause: (Identifier)FromMutable((fragment as ScriptDom.RevokeStatement80).AsClause),
                        securityElement80: (SecurityElement80)FromMutable((fragment as ScriptDom.RevokeStatement80).SecurityElement80),
                        securityUserClause80: (SecurityUserClause80)FromMutable((fragment as ScriptDom.RevokeStatement80).SecurityUserClause80)
                    );
                }
                case 733: {
                    return new RightFunctionCall(
                        parameters: (fragment as ScriptDom.RightFunctionCall).Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.RightFunctionCall).Collation)
                    );
                }
                case 734: {
                    return new RolePayloadOption(
                        role: (fragment as ScriptDom.RolePayloadOption).Role,
                        kind: (fragment as ScriptDom.RolePayloadOption).Kind
                    );
                }
                case 735: {
                    return new RollbackTransactionStatement(
                        name: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.RollbackTransactionStatement).Name)
                    );
                }
                case 736: {
                    return new RollupGroupingSpecification(
                        arguments: (fragment as ScriptDom.RollupGroupingSpecification).Arguments.SelectList(c => (GroupingSpecification)FromMutable(c))
                    );
                }
                case 737: {
                    return new RouteOption(
                        optionKind: (fragment as ScriptDom.RouteOption).OptionKind,
                        literal: (Literal)FromMutable((fragment as ScriptDom.RouteOption).Literal)
                    );
                }
                case 738: {
                    return new RowValue(
                        columnValues: (fragment as ScriptDom.RowValue).ColumnValues.SelectList(c => (ScalarExpression)FromMutable(c))
                    );
                }
                case 739: {
                    return new SaveTransactionStatement(
                        name: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.SaveTransactionStatement).Name)
                    );
                }
                case 740: {
                    return new ScalarExpressionDialogOption(
                        @value: (ScalarExpression)FromMutable((fragment as ScriptDom.ScalarExpressionDialogOption).Value),
                        optionKind: (fragment as ScriptDom.ScalarExpressionDialogOption).OptionKind
                    );
                }
                case 741: {
                    return new ScalarExpressionRestoreOption(
                        @value: (ScalarExpression)FromMutable((fragment as ScriptDom.ScalarExpressionRestoreOption).Value),
                        optionKind: (fragment as ScriptDom.ScalarExpressionRestoreOption).OptionKind
                    );
                }
                case 742: {
                    return new ScalarExpressionSequenceOption(
                        optionValue: (ScalarExpression)FromMutable((fragment as ScriptDom.ScalarExpressionSequenceOption).OptionValue),
                        optionKind: (fragment as ScriptDom.ScalarExpressionSequenceOption).OptionKind,
                        noValue: (fragment as ScriptDom.ScalarExpressionSequenceOption).NoValue
                    );
                }
                case 743: {
                    return new ScalarExpressionSnippet(
                        script: (fragment as ScriptDom.ScalarExpressionSnippet).Script
                    );
                }
                case 744: {
                    return new ScalarFunctionReturnType(
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.ScalarFunctionReturnType).DataType)
                    );
                }
                case 745: {
                    return new ScalarSubquery(
                        queryExpression: (QueryExpression)FromMutable((fragment as ScriptDom.ScalarSubquery).QueryExpression),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.ScalarSubquery).Collation)
                    );
                }
                case 746: {
                    return new SchemaDeclarationItem(
                        columnDefinition: (ColumnDefinitionBase)FromMutable((fragment as ScriptDom.SchemaDeclarationItem).ColumnDefinition),
                        mapping: (ValueExpression)FromMutable((fragment as ScriptDom.SchemaDeclarationItem).Mapping)
                    );
                }
                case 747: {
                    return new SchemaDeclarationItemOpenjson(
                        asJson: (fragment as ScriptDom.SchemaDeclarationItemOpenjson).AsJson,
                        columnDefinition: (ColumnDefinitionBase)FromMutable((fragment as ScriptDom.SchemaDeclarationItemOpenjson).ColumnDefinition),
                        mapping: (ValueExpression)FromMutable((fragment as ScriptDom.SchemaDeclarationItemOpenjson).Mapping)
                    );
                }
                case 748: {
                    return new SchemaObjectFunctionTableReference(
                        schemaObject: (SchemaObjectName)FromMutable((fragment as ScriptDom.SchemaObjectFunctionTableReference).SchemaObject),
                        parameters: (fragment as ScriptDom.SchemaObjectFunctionTableReference).Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        columns: (fragment as ScriptDom.SchemaObjectFunctionTableReference).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.SchemaObjectFunctionTableReference).Alias),
                        forPath: (fragment as ScriptDom.SchemaObjectFunctionTableReference).ForPath
                    );
                }
                case 749: {
                    return new SchemaObjectName(
                        identifiers: (fragment as ScriptDom.SchemaObjectName).Identifiers.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 750: {
                    return new SchemaObjectNameOrValueExpression(
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.SchemaObjectNameOrValueExpression).SchemaObjectName),
                        valueExpression: (ValueExpression)FromMutable((fragment as ScriptDom.SchemaObjectNameOrValueExpression).ValueExpression)
                    );
                }
                case 751: {
                    return new SchemaObjectNameSnippet(
                        script: (fragment as ScriptDom.SchemaObjectNameSnippet).Script,
                        identifiers: (fragment as ScriptDom.SchemaObjectNameSnippet).Identifiers.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 752: {
                    return new SchemaObjectResultSetDefinition(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.SchemaObjectResultSetDefinition).Name),
                        resultSetType: (fragment as ScriptDom.SchemaObjectResultSetDefinition).ResultSetType
                    );
                }
                case 753: {
                    return new SchemaPayloadOption(
                        isStandard: (fragment as ScriptDom.SchemaPayloadOption).IsStandard,
                        kind: (fragment as ScriptDom.SchemaPayloadOption).Kind
                    );
                }
                case 754: {
                    return new SearchedCaseExpression(
                        whenClauses: (fragment as ScriptDom.SearchedCaseExpression).WhenClauses.SelectList(c => (SearchedWhenClause)FromMutable(c)),
                        elseExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.SearchedCaseExpression).ElseExpression),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.SearchedCaseExpression).Collation)
                    );
                }
                case 755: {
                    return new SearchedWhenClause(
                        whenExpression: (BooleanExpression)FromMutable((fragment as ScriptDom.SearchedWhenClause).WhenExpression),
                        thenExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.SearchedWhenClause).ThenExpression)
                    );
                }
                case 756: {
                    return new SearchPropertyListFullTextIndexOption(
                        isOff: (fragment as ScriptDom.SearchPropertyListFullTextIndexOption).IsOff,
                        propertyListName: (Identifier)FromMutable((fragment as ScriptDom.SearchPropertyListFullTextIndexOption).PropertyListName),
                        optionKind: (fragment as ScriptDom.SearchPropertyListFullTextIndexOption).OptionKind
                    );
                }
                case 757: {
                    return new SecondaryRoleReplicaOption(
                        allowConnections: (fragment as ScriptDom.SecondaryRoleReplicaOption).AllowConnections,
                        optionKind: (fragment as ScriptDom.SecondaryRoleReplicaOption).OptionKind
                    );
                }
                case 758: {
                    return new SecurityPolicyOption(
                        optionKind: (fragment as ScriptDom.SecurityPolicyOption).OptionKind,
                        optionState: (fragment as ScriptDom.SecurityPolicyOption).OptionState
                    );
                }
                case 759: {
                    return new SecurityPredicateAction(
                        actionType: (fragment as ScriptDom.SecurityPredicateAction).ActionType,
                        securityPredicateType: (fragment as ScriptDom.SecurityPredicateAction).SecurityPredicateType,
                        functionCall: (FunctionCall)FromMutable((fragment as ScriptDom.SecurityPredicateAction).FunctionCall),
                        targetObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.SecurityPredicateAction).TargetObjectName),
                        securityPredicateOperation: (fragment as ScriptDom.SecurityPredicateAction).SecurityPredicateOperation
                    );
                }
                case 760: {
                    return new SecurityPrincipal(
                        principalType: (fragment as ScriptDom.SecurityPrincipal).PrincipalType,
                        identifier: (Identifier)FromMutable((fragment as ScriptDom.SecurityPrincipal).Identifier)
                    );
                }
                case 761: {
                    return new SecurityTargetObject(
                        objectKind: (fragment as ScriptDom.SecurityTargetObject).ObjectKind,
                        objectName: (SecurityTargetObjectName)FromMutable((fragment as ScriptDom.SecurityTargetObject).ObjectName),
                        columns: (fragment as ScriptDom.SecurityTargetObject).Columns.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 762: {
                    return new SecurityTargetObjectName(
                        multiPartIdentifier: (MultiPartIdentifier)FromMutable((fragment as ScriptDom.SecurityTargetObjectName).MultiPartIdentifier)
                    );
                }
                case 763: {
                    return new SecurityUserClause80(
                        users: (fragment as ScriptDom.SecurityUserClause80).Users.SelectList(c => (Identifier)FromMutable(c)),
                        userType80: (fragment as ScriptDom.SecurityUserClause80).UserType80
                    );
                }
                case 764: {
                    return new SelectFunctionReturnType(
                        selectStatement: (SelectStatement)FromMutable((fragment as ScriptDom.SelectFunctionReturnType).SelectStatement)
                    );
                }
                case 765: {
                    return new SelectInsertSource(
                        select: (QueryExpression)FromMutable((fragment as ScriptDom.SelectInsertSource).Select)
                    );
                }
                case 766: {
                    return new SelectiveXmlIndexPromotedPath(
                        name: (Identifier)FromMutable((fragment as ScriptDom.SelectiveXmlIndexPromotedPath).Name),
                        path: (Literal)FromMutable((fragment as ScriptDom.SelectiveXmlIndexPromotedPath).Path),
                        sQLDataType: (DataTypeReference)FromMutable((fragment as ScriptDom.SelectiveXmlIndexPromotedPath).SQLDataType),
                        xQueryDataType: (Literal)FromMutable((fragment as ScriptDom.SelectiveXmlIndexPromotedPath).XQueryDataType),
                        maxLength: (IntegerLiteral)FromMutable((fragment as ScriptDom.SelectiveXmlIndexPromotedPath).MaxLength),
                        isSingleton: (fragment as ScriptDom.SelectiveXmlIndexPromotedPath).IsSingleton
                    );
                }
                case 767: {
                    return new SelectScalarExpression(
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.SelectScalarExpression).Expression),
                        columnName: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.SelectScalarExpression).ColumnName)
                    );
                }
                case 768: {
                    return new SelectSetVariable(
                        variable: (VariableReference)FromMutable((fragment as ScriptDom.SelectSetVariable).Variable),
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.SelectSetVariable).Expression),
                        assignmentKind: (fragment as ScriptDom.SelectSetVariable).AssignmentKind
                    );
                }
                case 769: {
                    return new SelectStarExpression(
                        qualifier: (MultiPartIdentifier)FromMutable((fragment as ScriptDom.SelectStarExpression).Qualifier)
                    );
                }
                case 770: {
                    return new SelectStatement(
                        queryExpression: (QueryExpression)FromMutable((fragment as ScriptDom.SelectStatement).QueryExpression),
                        into: (SchemaObjectName)FromMutable((fragment as ScriptDom.SelectStatement).Into),
                        on: (Identifier)FromMutable((fragment as ScriptDom.SelectStatement).On),
                        computeClauses: (fragment as ScriptDom.SelectStatement).ComputeClauses.SelectList(c => (ComputeClause)FromMutable(c)),
                        withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable((fragment as ScriptDom.SelectStatement).WithCtesAndXmlNamespaces),
                        optimizerHints: (fragment as ScriptDom.SelectStatement).OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 771: {
                    return new SelectStatementSnippet(
                        script: (fragment as ScriptDom.SelectStatementSnippet).Script,
                        queryExpression: (QueryExpression)FromMutable((fragment as ScriptDom.SelectStatementSnippet).QueryExpression),
                        into: (SchemaObjectName)FromMutable((fragment as ScriptDom.SelectStatementSnippet).Into),
                        on: (Identifier)FromMutable((fragment as ScriptDom.SelectStatementSnippet).On),
                        computeClauses: (fragment as ScriptDom.SelectStatementSnippet).ComputeClauses.SelectList(c => (ComputeClause)FromMutable(c)),
                        withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable((fragment as ScriptDom.SelectStatementSnippet).WithCtesAndXmlNamespaces),
                        optimizerHints: (fragment as ScriptDom.SelectStatementSnippet).OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 772: {
                    return new SemanticTableReference(
                        semanticFunctionType: (fragment as ScriptDom.SemanticTableReference).SemanticFunctionType,
                        tableName: (SchemaObjectName)FromMutable((fragment as ScriptDom.SemanticTableReference).TableName),
                        columns: (fragment as ScriptDom.SemanticTableReference).Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        sourceKey: (ScalarExpression)FromMutable((fragment as ScriptDom.SemanticTableReference).SourceKey),
                        matchedColumn: (ColumnReferenceExpression)FromMutable((fragment as ScriptDom.SemanticTableReference).MatchedColumn),
                        matchedKey: (ScalarExpression)FromMutable((fragment as ScriptDom.SemanticTableReference).MatchedKey),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.SemanticTableReference).Alias),
                        forPath: (fragment as ScriptDom.SemanticTableReference).ForPath
                    );
                }
                case 773: {
                    return new SendStatement(
                        conversationHandles: (fragment as ScriptDom.SendStatement).ConversationHandles.SelectList(c => (ScalarExpression)FromMutable(c)),
                        messageTypeName: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.SendStatement).MessageTypeName),
                        messageBody: (ScalarExpression)FromMutable((fragment as ScriptDom.SendStatement).MessageBody)
                    );
                }
                case 774: {
                    return new SensitivityClassificationOption(
                        type: (fragment as ScriptDom.SensitivityClassificationOption).Type,
                        @value: (Literal)FromMutable((fragment as ScriptDom.SensitivityClassificationOption).Value)
                    );
                }
                case 775: {
                    return new SequenceOption(
                        optionKind: (fragment as ScriptDom.SequenceOption).OptionKind,
                        noValue: (fragment as ScriptDom.SequenceOption).NoValue
                    );
                }
                case 776: {
                    return new ServiceContract(
                        name: (Identifier)FromMutable((fragment as ScriptDom.ServiceContract).Name),
                        action: (fragment as ScriptDom.ServiceContract).Action
                    );
                }
                case 777: {
                    return new SessionTimeoutPayloadOption(
                        isNever: (fragment as ScriptDom.SessionTimeoutPayloadOption).IsNever,
                        timeout: (Literal)FromMutable((fragment as ScriptDom.SessionTimeoutPayloadOption).Timeout),
                        kind: (fragment as ScriptDom.SessionTimeoutPayloadOption).Kind
                    );
                }
                case 778: {
                    return new SetCommandStatement(
                        commands: (fragment as ScriptDom.SetCommandStatement).Commands.SelectList(c => (SetCommand)FromMutable(c))
                    );
                }
                case 779: {
                    return new SetErrorLevelStatement(
                        level: (ScalarExpression)FromMutable((fragment as ScriptDom.SetErrorLevelStatement).Level)
                    );
                }
                case 780: {
                    return new SetFipsFlaggerCommand(
                        complianceLevel: (fragment as ScriptDom.SetFipsFlaggerCommand).ComplianceLevel
                    );
                }
                case 781: {
                    return new SetIdentityInsertStatement(
                        table: (SchemaObjectName)FromMutable((fragment as ScriptDom.SetIdentityInsertStatement).Table),
                        isOn: (fragment as ScriptDom.SetIdentityInsertStatement).IsOn
                    );
                }
                case 782: {
                    return new SetOffsetsStatement(
                        options: (fragment as ScriptDom.SetOffsetsStatement).Options,
                        isOn: (fragment as ScriptDom.SetOffsetsStatement).IsOn
                    );
                }
                case 783: {
                    return new SetRowCountStatement(
                        numberRows: (ValueExpression)FromMutable((fragment as ScriptDom.SetRowCountStatement).NumberRows)
                    );
                }
                case 784: {
                    return new SetSearchPropertyListAlterFullTextIndexAction(
                        searchPropertyListOption: (SearchPropertyListFullTextIndexOption)FromMutable((fragment as ScriptDom.SetSearchPropertyListAlterFullTextIndexAction).SearchPropertyListOption),
                        withNoPopulation: (fragment as ScriptDom.SetSearchPropertyListAlterFullTextIndexAction).WithNoPopulation
                    );
                }
                case 785: {
                    return new SetStatisticsStatement(
                        options: (fragment as ScriptDom.SetStatisticsStatement).Options,
                        isOn: (fragment as ScriptDom.SetStatisticsStatement).IsOn
                    );
                }
                case 786: {
                    return new SetStopListAlterFullTextIndexAction(
                        stopListOption: (StopListFullTextIndexOption)FromMutable((fragment as ScriptDom.SetStopListAlterFullTextIndexAction).StopListOption),
                        withNoPopulation: (fragment as ScriptDom.SetStopListAlterFullTextIndexAction).WithNoPopulation
                    );
                }
                case 787: {
                    return new SetTextSizeStatement(
                        textSize: (ScalarExpression)FromMutable((fragment as ScriptDom.SetTextSizeStatement).TextSize)
                    );
                }
                case 788: {
                    return new SetTransactionIsolationLevelStatement(
                        level: (fragment as ScriptDom.SetTransactionIsolationLevelStatement).Level
                    );
                }
                case 789: {
                    return new SetUserStatement(
                        userName: (ValueExpression)FromMutable((fragment as ScriptDom.SetUserStatement).UserName),
                        withNoReset: (fragment as ScriptDom.SetUserStatement).WithNoReset
                    );
                }
                case 790: {
                    return new SetVariableStatement(
                        variable: (VariableReference)FromMutable((fragment as ScriptDom.SetVariableStatement).Variable),
                        separatorType: (fragment as ScriptDom.SetVariableStatement).SeparatorType,
                        identifier: (Identifier)FromMutable((fragment as ScriptDom.SetVariableStatement).Identifier),
                        functionCallExists: (fragment as ScriptDom.SetVariableStatement).FunctionCallExists,
                        parameters: (fragment as ScriptDom.SetVariableStatement).Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.SetVariableStatement).Expression),
                        cursorDefinition: (CursorDefinition)FromMutable((fragment as ScriptDom.SetVariableStatement).CursorDefinition),
                        assignmentKind: (fragment as ScriptDom.SetVariableStatement).AssignmentKind
                    );
                }
                case 791: {
                    return new ShutdownStatement(
                        withNoWait: (fragment as ScriptDom.ShutdownStatement).WithNoWait
                    );
                }
                case 792: {
                    return new SimpleAlterFullTextIndexAction(
                        actionKind: (fragment as ScriptDom.SimpleAlterFullTextIndexAction).ActionKind
                    );
                }
                case 793: {
                    return new SimpleCaseExpression(
                        inputExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.SimpleCaseExpression).InputExpression),
                        whenClauses: (fragment as ScriptDom.SimpleCaseExpression).WhenClauses.SelectList(c => (SimpleWhenClause)FromMutable(c)),
                        elseExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.SimpleCaseExpression).ElseExpression),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.SimpleCaseExpression).Collation)
                    );
                }
                case 794: {
                    return new SimpleWhenClause(
                        whenExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.SimpleWhenClause).WhenExpression),
                        thenExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.SimpleWhenClause).ThenExpression)
                    );
                }
                case 795: {
                    return new SingleValueTypeCopyOption(
                        singleValue: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.SingleValueTypeCopyOption).SingleValue)
                    );
                }
                case 796: {
                    return new SizeFileDeclarationOption(
                        size: (Literal)FromMutable((fragment as ScriptDom.SizeFileDeclarationOption).Size),
                        units: (fragment as ScriptDom.SizeFileDeclarationOption).Units,
                        optionKind: (fragment as ScriptDom.SizeFileDeclarationOption).OptionKind
                    );
                }
                case 797: {
                    return new SoapMethod(
                        alias: (Literal)FromMutable((fragment as ScriptDom.SoapMethod).Alias),
                        @namespace: (Literal)FromMutable((fragment as ScriptDom.SoapMethod).Namespace),
                        action: (fragment as ScriptDom.SoapMethod).Action,
                        name: (Literal)FromMutable((fragment as ScriptDom.SoapMethod).Name),
                        format: (fragment as ScriptDom.SoapMethod).Format,
                        schema: (fragment as ScriptDom.SoapMethod).Schema,
                        kind: (fragment as ScriptDom.SoapMethod).Kind
                    );
                }
                case 798: {
                    return new SourceDeclaration(
                        @value: (EventSessionObjectName)FromMutable((fragment as ScriptDom.SourceDeclaration).Value)
                    );
                }
                case 799: {
                    return new SpatialIndexRegularOption(
                        option: (IndexOption)FromMutable((fragment as ScriptDom.SpatialIndexRegularOption).Option)
                    );
                }
                case 800: {
                    return new SqlCommandIdentifier(
                        @value: (fragment as ScriptDom.SqlCommandIdentifier).Value,
                        quoteType: (fragment as ScriptDom.SqlCommandIdentifier).QuoteType
                    );
                }
                case 801: {
                    return new SqlDataTypeReference(
                        sqlDataTypeOption: (fragment as ScriptDom.SqlDataTypeReference).SqlDataTypeOption,
                        parameters: (fragment as ScriptDom.SqlDataTypeReference).Parameters.SelectList(c => (Literal)FromMutable(c)),
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.SqlDataTypeReference).Name)
                    );
                }
                case 802: {
                    return new StateAuditOption(
                        @value: (fragment as ScriptDom.StateAuditOption).Value,
                        optionKind: (fragment as ScriptDom.StateAuditOption).OptionKind
                    );
                }
                case 803: {
                    return new StatementList(
                        statements: (fragment as ScriptDom.StatementList).Statements.SelectList(c => (TSqlStatement)FromMutable(c))
                    );
                }
                case 804: {
                    return new StatementListSnippet(
                        script: (fragment as ScriptDom.StatementListSnippet).Script,
                        statements: (fragment as ScriptDom.StatementListSnippet).Statements.SelectList(c => (TSqlStatement)FromMutable(c))
                    );
                }
                case 805: {
                    return new StatisticsOption(
                        optionKind: (fragment as ScriptDom.StatisticsOption).OptionKind
                    );
                }
                case 806: {
                    return new StatisticsPartitionRange(
                        from: (IntegerLiteral)FromMutable((fragment as ScriptDom.StatisticsPartitionRange).From),
                        to: (IntegerLiteral)FromMutable((fragment as ScriptDom.StatisticsPartitionRange).To)
                    );
                }
                case 807: {
                    return new StopListFullTextIndexOption(
                        isOff: (fragment as ScriptDom.StopListFullTextIndexOption).IsOff,
                        stopListName: (Identifier)FromMutable((fragment as ScriptDom.StopListFullTextIndexOption).StopListName),
                        optionKind: (fragment as ScriptDom.StopListFullTextIndexOption).OptionKind
                    );
                }
                case 808: {
                    return new StopRestoreOption(
                        mark: (ValueExpression)FromMutable((fragment as ScriptDom.StopRestoreOption).Mark),
                        after: (ValueExpression)FromMutable((fragment as ScriptDom.StopRestoreOption).After),
                        isStopAt: (fragment as ScriptDom.StopRestoreOption).IsStopAt,
                        optionKind: (fragment as ScriptDom.StopRestoreOption).OptionKind
                    );
                }
                case 809: {
                    return new StringLiteral(
                        isNational: (fragment as ScriptDom.StringLiteral).IsNational,
                        isLargeObject: (fragment as ScriptDom.StringLiteral).IsLargeObject,
                        @value: (fragment as ScriptDom.StringLiteral).Value,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.StringLiteral).Collation)
                    );
                }
                case 810: {
                    return new SubqueryComparisonPredicate(
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.SubqueryComparisonPredicate).Expression),
                        comparisonType: (fragment as ScriptDom.SubqueryComparisonPredicate).ComparisonType,
                        subquery: (ScalarSubquery)FromMutable((fragment as ScriptDom.SubqueryComparisonPredicate).Subquery),
                        subqueryComparisonPredicateType: (fragment as ScriptDom.SubqueryComparisonPredicate).SubqueryComparisonPredicateType
                    );
                }
                case 811: {
                    return new SystemTimePeriodDefinition(
                        startTimeColumn: (Identifier)FromMutable((fragment as ScriptDom.SystemTimePeriodDefinition).StartTimeColumn),
                        endTimeColumn: (Identifier)FromMutable((fragment as ScriptDom.SystemTimePeriodDefinition).EndTimeColumn)
                    );
                }
                case 812: {
                    return new SystemVersioningTableOption(
                        optionState: (fragment as ScriptDom.SystemVersioningTableOption).OptionState,
                        consistencyCheckEnabled: (fragment as ScriptDom.SystemVersioningTableOption).ConsistencyCheckEnabled,
                        historyTable: (SchemaObjectName)FromMutable((fragment as ScriptDom.SystemVersioningTableOption).HistoryTable),
                        retentionPeriod: (RetentionPeriodDefinition)FromMutable((fragment as ScriptDom.SystemVersioningTableOption).RetentionPeriod),
                        optionKind: (fragment as ScriptDom.SystemVersioningTableOption).OptionKind
                    );
                }
                case 813: {
                    return new TableClusteredIndexType(
                        columns: (fragment as ScriptDom.TableClusteredIndexType).Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                        columnStore: (fragment as ScriptDom.TableClusteredIndexType).ColumnStore,
                        orderedColumns: (fragment as ScriptDom.TableClusteredIndexType).OrderedColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
                    );
                }
                case 814: {
                    return new TableDataCompressionOption(
                        dataCompressionOption: (DataCompressionOption)FromMutable((fragment as ScriptDom.TableDataCompressionOption).DataCompressionOption),
                        optionKind: (fragment as ScriptDom.TableDataCompressionOption).OptionKind
                    );
                }
                case 815: {
                    return new TableDefinition(
                        columnDefinitions: (fragment as ScriptDom.TableDefinition).ColumnDefinitions.SelectList(c => (ColumnDefinition)FromMutable(c)),
                        tableConstraints: (fragment as ScriptDom.TableDefinition).TableConstraints.SelectList(c => (ConstraintDefinition)FromMutable(c)),
                        indexes: (fragment as ScriptDom.TableDefinition).Indexes.SelectList(c => (IndexDefinition)FromMutable(c)),
                        systemTimePeriod: (SystemTimePeriodDefinition)FromMutable((fragment as ScriptDom.TableDefinition).SystemTimePeriod)
                    );
                }
                case 816: {
                    return new TableDistributionOption(
                        @value: (TableDistributionPolicy)FromMutable((fragment as ScriptDom.TableDistributionOption).Value),
                        optionKind: (fragment as ScriptDom.TableDistributionOption).OptionKind
                    );
                }
                case 817: {
                    return new TableHashDistributionPolicy(
                        distributionColumn: (Identifier)FromMutable((fragment as ScriptDom.TableHashDistributionPolicy).DistributionColumn)
                    );
                }
                case 818: {
                    return new TableHint(
                        hintKind: (fragment as ScriptDom.TableHint).HintKind
                    );
                }
                case 819: {
                    return new TableHintsOptimizerHint(
                        objectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.TableHintsOptimizerHint).ObjectName),
                        tableHints: (fragment as ScriptDom.TableHintsOptimizerHint).TableHints.SelectList(c => (TableHint)FromMutable(c)),
                        hintKind: (fragment as ScriptDom.TableHintsOptimizerHint).HintKind
                    );
                }
                case 820: {
                    return new TableIndexOption(
                        @value: (TableIndexType)FromMutable((fragment as ScriptDom.TableIndexOption).Value),
                        optionKind: (fragment as ScriptDom.TableIndexOption).OptionKind
                    );
                }
                case 821: {
                    return new TableNonClusteredIndexType(
                        
                    );
                }
                case 822: {
                    return new TablePartitionOption(
                        partitionColumn: (Identifier)FromMutable((fragment as ScriptDom.TablePartitionOption).PartitionColumn),
                        partitionOptionSpecs: (TablePartitionOptionSpecifications)FromMutable((fragment as ScriptDom.TablePartitionOption).PartitionOptionSpecs),
                        optionKind: (fragment as ScriptDom.TablePartitionOption).OptionKind
                    );
                }
                case 823: {
                    return new TablePartitionOptionSpecifications(
                        range: (fragment as ScriptDom.TablePartitionOptionSpecifications).Range,
                        boundaryValues: (fragment as ScriptDom.TablePartitionOptionSpecifications).BoundaryValues.SelectList(c => (ScalarExpression)FromMutable(c))
                    );
                }
                case 824: {
                    return new TableReplicateDistributionPolicy(
                        
                    );
                }
                case 825: {
                    return new TableRoundRobinDistributionPolicy(
                        
                    );
                }
                case 826: {
                    return new TableSampleClause(
                        system: (fragment as ScriptDom.TableSampleClause).System,
                        sampleNumber: (ScalarExpression)FromMutable((fragment as ScriptDom.TableSampleClause).SampleNumber),
                        tableSampleClauseOption: (fragment as ScriptDom.TableSampleClause).TableSampleClauseOption,
                        repeatSeed: (ScalarExpression)FromMutable((fragment as ScriptDom.TableSampleClause).RepeatSeed)
                    );
                }
                case 827: {
                    return new TableValuedFunctionReturnType(
                        declareTableVariableBody: (DeclareTableVariableBody)FromMutable((fragment as ScriptDom.TableValuedFunctionReturnType).DeclareTableVariableBody)
                    );
                }
                case 828: {
                    return new TableXmlCompressionOption(
                        xmlCompressionOption: (XmlCompressionOption)FromMutable((fragment as ScriptDom.TableXmlCompressionOption).XmlCompressionOption),
                        optionKind: (fragment as ScriptDom.TableXmlCompressionOption).OptionKind
                    );
                }
                case 829: {
                    return new TargetDeclaration(
                        objectName: (EventSessionObjectName)FromMutable((fragment as ScriptDom.TargetDeclaration).ObjectName),
                        targetDeclarationParameters: (fragment as ScriptDom.TargetDeclaration).TargetDeclarationParameters.SelectList(c => (EventDeclarationSetParameter)FromMutable(c))
                    );
                }
                case 830: {
                    return new TargetRecoveryTimeDatabaseOption(
                        recoveryTime: (Literal)FromMutable((fragment as ScriptDom.TargetRecoveryTimeDatabaseOption).RecoveryTime),
                        unit: (fragment as ScriptDom.TargetRecoveryTimeDatabaseOption).Unit,
                        optionKind: (fragment as ScriptDom.TargetRecoveryTimeDatabaseOption).OptionKind
                    );
                }
                case 831: {
                    return new TemporalClause(
                        temporalClauseType: (fragment as ScriptDom.TemporalClause).TemporalClauseType,
                        startTime: (ScalarExpression)FromMutable((fragment as ScriptDom.TemporalClause).StartTime),
                        endTime: (ScalarExpression)FromMutable((fragment as ScriptDom.TemporalClause).EndTime)
                    );
                }
                case 832: {
                    return new ThrowStatement(
                        errorNumber: (ValueExpression)FromMutable((fragment as ScriptDom.ThrowStatement).ErrorNumber),
                        message: (ValueExpression)FromMutable((fragment as ScriptDom.ThrowStatement).Message),
                        state: (ValueExpression)FromMutable((fragment as ScriptDom.ThrowStatement).State)
                    );
                }
                case 833: {
                    return new TopRowFilter(
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.TopRowFilter).Expression),
                        percent: (fragment as ScriptDom.TopRowFilter).Percent,
                        withTies: (fragment as ScriptDom.TopRowFilter).WithTies
                    );
                }
                case 834: {
                    return new TriggerAction(
                        triggerActionType: (fragment as ScriptDom.TriggerAction).TriggerActionType,
                        eventTypeGroup: (EventTypeGroupContainer)FromMutable((fragment as ScriptDom.TriggerAction).EventTypeGroup)
                    );
                }
                case 835: {
                    return new TriggerObject(
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.TriggerObject).Name),
                        triggerScope: (fragment as ScriptDom.TriggerObject).TriggerScope
                    );
                }
                case 836: {
                    return new TriggerOption(
                        optionKind: (fragment as ScriptDom.TriggerOption).OptionKind
                    );
                }
                case 837: {
                    return new TruncateTableStatement(
                        tableName: (SchemaObjectName)FromMutable((fragment as ScriptDom.TruncateTableStatement).TableName),
                        partitionRanges: (fragment as ScriptDom.TruncateTableStatement).PartitionRanges.SelectList(c => (CompressionPartitionRange)FromMutable(c))
                    );
                }
                case 838: {
                    return new TruncateTargetTableSwitchOption(
                        truncateTarget: (fragment as ScriptDom.TruncateTargetTableSwitchOption).TruncateTarget,
                        optionKind: (fragment as ScriptDom.TruncateTargetTableSwitchOption).OptionKind
                    );
                }
                case 839: {
                    return new TryCastCall(
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.TryCastCall).DataType),
                        parameter: (ScalarExpression)FromMutable((fragment as ScriptDom.TryCastCall).Parameter),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.TryCastCall).Collation)
                    );
                }
                case 840: {
                    return new TryCatchStatement(
                        tryStatements: (StatementList)FromMutable((fragment as ScriptDom.TryCatchStatement).TryStatements),
                        catchStatements: (StatementList)FromMutable((fragment as ScriptDom.TryCatchStatement).CatchStatements)
                    );
                }
                case 841: {
                    return new TryConvertCall(
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.TryConvertCall).DataType),
                        parameter: (ScalarExpression)FromMutable((fragment as ScriptDom.TryConvertCall).Parameter),
                        style: (ScalarExpression)FromMutable((fragment as ScriptDom.TryConvertCall).Style),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.TryConvertCall).Collation)
                    );
                }
                case 842: {
                    return new TryParseCall(
                        stringValue: (ScalarExpression)FromMutable((fragment as ScriptDom.TryParseCall).StringValue),
                        dataType: (DataTypeReference)FromMutable((fragment as ScriptDom.TryParseCall).DataType),
                        culture: (ScalarExpression)FromMutable((fragment as ScriptDom.TryParseCall).Culture),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.TryParseCall).Collation)
                    );
                }
                case 843: {
                    return new TSEqualCall(
                        firstExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.TSEqualCall).FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable((fragment as ScriptDom.TSEqualCall).SecondExpression)
                    );
                }
                case 844: {
                    return new TSqlBatch(
                        statements: (fragment as ScriptDom.TSqlBatch).Statements.SelectList(c => (TSqlStatement)FromMutable(c))
                    );
                }
                case 845: {
                    return new TSqlFragmentSnippet(
                        script: (fragment as ScriptDom.TSqlFragmentSnippet).Script
                    );
                }
                case 846: {
                    return new TSqlScript(
                        batches: (fragment as ScriptDom.TSqlScript).Batches.SelectList(c => (TSqlBatch)FromMutable(c))
                    );
                }
                case 847: {
                    return new TSqlStatementSnippet(
                        script: (fragment as ScriptDom.TSqlStatementSnippet).Script
                    );
                }
                case 848: {
                    return new UnaryExpression(
                        unaryExpressionType: (fragment as ScriptDom.UnaryExpression).UnaryExpressionType,
                        expression: (ScalarExpression)FromMutable((fragment as ScriptDom.UnaryExpression).Expression)
                    );
                }
                case 849: {
                    return new UniqueConstraintDefinition(
                        clustered: (fragment as ScriptDom.UniqueConstraintDefinition).Clustered,
                        isPrimaryKey: (fragment as ScriptDom.UniqueConstraintDefinition).IsPrimaryKey,
                        isEnforced: (fragment as ScriptDom.UniqueConstraintDefinition).IsEnforced,
                        columns: (fragment as ScriptDom.UniqueConstraintDefinition).Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                        indexOptions: (fragment as ScriptDom.UniqueConstraintDefinition).IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                        onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable((fragment as ScriptDom.UniqueConstraintDefinition).OnFileGroupOrPartitionScheme),
                        indexType: (IndexType)FromMutable((fragment as ScriptDom.UniqueConstraintDefinition).IndexType),
                        fileStreamOn: (IdentifierOrValueExpression)FromMutable((fragment as ScriptDom.UniqueConstraintDefinition).FileStreamOn),
                        constraintIdentifier: (Identifier)FromMutable((fragment as ScriptDom.UniqueConstraintDefinition).ConstraintIdentifier)
                    );
                }
                case 850: {
                    return new UnpivotedTableReference(
                        tableReference: (TableReference)FromMutable((fragment as ScriptDom.UnpivotedTableReference).TableReference),
                        inColumns: (fragment as ScriptDom.UnpivotedTableReference).InColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        pivotColumn: (Identifier)FromMutable((fragment as ScriptDom.UnpivotedTableReference).PivotColumn),
                        valueColumn: (Identifier)FromMutable((fragment as ScriptDom.UnpivotedTableReference).ValueColumn),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.UnpivotedTableReference).Alias),
                        forPath: (fragment as ScriptDom.UnpivotedTableReference).ForPath
                    );
                }
                case 851: {
                    return new UnqualifiedJoin(
                        unqualifiedJoinType: (fragment as ScriptDom.UnqualifiedJoin).UnqualifiedJoinType,
                        firstTableReference: (TableReference)FromMutable((fragment as ScriptDom.UnqualifiedJoin).FirstTableReference),
                        secondTableReference: (TableReference)FromMutable((fragment as ScriptDom.UnqualifiedJoin).SecondTableReference)
                    );
                }
                case 852: {
                    return new UpdateCall(
                        identifier: (Identifier)FromMutable((fragment as ScriptDom.UpdateCall).Identifier)
                    );
                }
                case 853: {
                    return new UpdateForClause(
                        columns: (fragment as ScriptDom.UpdateForClause).Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
                    );
                }
                case 854: {
                    return new UpdateMergeAction(
                        setClauses: (fragment as ScriptDom.UpdateMergeAction).SetClauses.SelectList(c => (SetClause)FromMutable(c))
                    );
                }
                case 855: {
                    return new UpdateSpecification(
                        setClauses: (fragment as ScriptDom.UpdateSpecification).SetClauses.SelectList(c => (SetClause)FromMutable(c)),
                        fromClause: (FromClause)FromMutable((fragment as ScriptDom.UpdateSpecification).FromClause),
                        whereClause: (WhereClause)FromMutable((fragment as ScriptDom.UpdateSpecification).WhereClause),
                        target: (TableReference)FromMutable((fragment as ScriptDom.UpdateSpecification).Target),
                        topRowFilter: (TopRowFilter)FromMutable((fragment as ScriptDom.UpdateSpecification).TopRowFilter),
                        outputIntoClause: (OutputIntoClause)FromMutable((fragment as ScriptDom.UpdateSpecification).OutputIntoClause),
                        outputClause: (OutputClause)FromMutable((fragment as ScriptDom.UpdateSpecification).OutputClause)
                    );
                }
                case 856: {
                    return new UpdateStatement(
                        updateSpecification: (UpdateSpecification)FromMutable((fragment as ScriptDom.UpdateStatement).UpdateSpecification),
                        withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable((fragment as ScriptDom.UpdateStatement).WithCtesAndXmlNamespaces),
                        optimizerHints: (fragment as ScriptDom.UpdateStatement).OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 857: {
                    return new UpdateStatisticsStatement(
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.UpdateStatisticsStatement).SchemaObjectName),
                        subElements: (fragment as ScriptDom.UpdateStatisticsStatement).SubElements.SelectList(c => (Identifier)FromMutable(c)),
                        statisticsOptions: (fragment as ScriptDom.UpdateStatisticsStatement).StatisticsOptions.SelectList(c => (StatisticsOption)FromMutable(c))
                    );
                }
                case 858: {
                    return new UpdateTextStatement(
                        insertOffset: (ScalarExpression)FromMutable((fragment as ScriptDom.UpdateTextStatement).InsertOffset),
                        deleteLength: (ScalarExpression)FromMutable((fragment as ScriptDom.UpdateTextStatement).DeleteLength),
                        sourceColumn: (ColumnReferenceExpression)FromMutable((fragment as ScriptDom.UpdateTextStatement).SourceColumn),
                        sourceParameter: (ValueExpression)FromMutable((fragment as ScriptDom.UpdateTextStatement).SourceParameter),
                        bulk: (fragment as ScriptDom.UpdateTextStatement).Bulk,
                        column: (ColumnReferenceExpression)FromMutable((fragment as ScriptDom.UpdateTextStatement).Column),
                        textId: (ValueExpression)FromMutable((fragment as ScriptDom.UpdateTextStatement).TextId),
                        timestamp: (Literal)FromMutable((fragment as ScriptDom.UpdateTextStatement).Timestamp),
                        withLog: (fragment as ScriptDom.UpdateTextStatement).WithLog
                    );
                }
                case 859: {
                    return new UseFederationStatement(
                        federationName: (Identifier)FromMutable((fragment as ScriptDom.UseFederationStatement).FederationName),
                        distributionName: (Identifier)FromMutable((fragment as ScriptDom.UseFederationStatement).DistributionName),
                        @value: (ScalarExpression)FromMutable((fragment as ScriptDom.UseFederationStatement).Value),
                        filtering: (fragment as ScriptDom.UseFederationStatement).Filtering
                    );
                }
                case 860: {
                    return new UseHintList(
                        hints: (fragment as ScriptDom.UseHintList).Hints.SelectList(c => (StringLiteral)FromMutable(c)),
                        hintKind: (fragment as ScriptDom.UseHintList).HintKind
                    );
                }
                case 861: {
                    return new UserDataTypeReference(
                        parameters: (fragment as ScriptDom.UserDataTypeReference).Parameters.SelectList(c => (Literal)FromMutable(c)),
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.UserDataTypeReference).Name)
                    );
                }
                case 862: {
                    return new UserDefinedTypeCallTarget(
                        schemaObjectName: (SchemaObjectName)FromMutable((fragment as ScriptDom.UserDefinedTypeCallTarget).SchemaObjectName)
                    );
                }
                case 863: {
                    return new UserDefinedTypePropertyAccess(
                        callTarget: (CallTarget)FromMutable((fragment as ScriptDom.UserDefinedTypePropertyAccess).CallTarget),
                        propertyName: (Identifier)FromMutable((fragment as ScriptDom.UserDefinedTypePropertyAccess).PropertyName),
                        collation: (Identifier)FromMutable((fragment as ScriptDom.UserDefinedTypePropertyAccess).Collation)
                    );
                }
                case 864: {
                    return new UserLoginOption(
                        userLoginOptionType: (fragment as ScriptDom.UserLoginOption).UserLoginOptionType,
                        identifier: (Identifier)FromMutable((fragment as ScriptDom.UserLoginOption).Identifier)
                    );
                }
                case 865: {
                    return new UserRemoteServiceBindingOption(
                        user: (Identifier)FromMutable((fragment as ScriptDom.UserRemoteServiceBindingOption).User),
                        optionKind: (fragment as ScriptDom.UserRemoteServiceBindingOption).OptionKind
                    );
                }
                case 866: {
                    return new UseStatement(
                        databaseName: (Identifier)FromMutable((fragment as ScriptDom.UseStatement).DatabaseName)
                    );
                }
                case 867: {
                    return new ValuesInsertSource(
                        isDefaultValues: (fragment as ScriptDom.ValuesInsertSource).IsDefaultValues,
                        rowValues: (fragment as ScriptDom.ValuesInsertSource).RowValues.SelectList(c => (RowValue)FromMutable(c))
                    );
                }
                case 868: {
                    return new VariableMethodCallTableReference(
                        variable: (VariableReference)FromMutable((fragment as ScriptDom.VariableMethodCallTableReference).Variable),
                        methodName: (Identifier)FromMutable((fragment as ScriptDom.VariableMethodCallTableReference).MethodName),
                        parameters: (fragment as ScriptDom.VariableMethodCallTableReference).Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        columns: (fragment as ScriptDom.VariableMethodCallTableReference).Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.VariableMethodCallTableReference).Alias),
                        forPath: (fragment as ScriptDom.VariableMethodCallTableReference).ForPath
                    );
                }
                case 869: {
                    return new VariableReference(
                        name: (fragment as ScriptDom.VariableReference).Name,
                        collation: (Identifier)FromMutable((fragment as ScriptDom.VariableReference).Collation)
                    );
                }
                case 870: {
                    return new VariableTableReference(
                        variable: (VariableReference)FromMutable((fragment as ScriptDom.VariableTableReference).Variable),
                        alias: (Identifier)FromMutable((fragment as ScriptDom.VariableTableReference).Alias),
                        forPath: (fragment as ScriptDom.VariableTableReference).ForPath
                    );
                }
                case 871: {
                    return new VariableValuePair(
                        variable: (VariableReference)FromMutable((fragment as ScriptDom.VariableValuePair).Variable),
                        @value: (ScalarExpression)FromMutable((fragment as ScriptDom.VariableValuePair).Value),
                        isForUnknown: (fragment as ScriptDom.VariableValuePair).IsForUnknown
                    );
                }
                case 872: {
                    return new ViewDistributionOption(
                        @value: (ViewDistributionPolicy)FromMutable((fragment as ScriptDom.ViewDistributionOption).Value),
                        optionKind: (fragment as ScriptDom.ViewDistributionOption).OptionKind
                    );
                }
                case 873: {
                    return new ViewForAppendOption(
                        optionKind: (fragment as ScriptDom.ViewForAppendOption).OptionKind
                    );
                }
                case 874: {
                    return new ViewHashDistributionPolicy(
                        distributionColumn: (Identifier)FromMutable((fragment as ScriptDom.ViewHashDistributionPolicy).DistributionColumn)
                    );
                }
                case 875: {
                    return new ViewOption(
                        optionKind: (fragment as ScriptDom.ViewOption).OptionKind
                    );
                }
                case 876: {
                    return new ViewRoundRobinDistributionPolicy(
                        
                    );
                }
                case 877: {
                    return new WaitAtLowPriorityOption(
                        options: (fragment as ScriptDom.WaitAtLowPriorityOption).Options.SelectList(c => (LowPriorityLockWaitOption)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.WaitAtLowPriorityOption).OptionKind
                    );
                }
                case 878: {
                    return new WaitForStatement(
                        waitForOption: (fragment as ScriptDom.WaitForStatement).WaitForOption,
                        parameter: (ValueExpression)FromMutable((fragment as ScriptDom.WaitForStatement).Parameter),
                        timeout: (ScalarExpression)FromMutable((fragment as ScriptDom.WaitForStatement).Timeout),
                        statement: (WaitForSupportedStatement)FromMutable((fragment as ScriptDom.WaitForStatement).Statement)
                    );
                }
                case 879: {
                    return new WhereClause(
                        searchCondition: (BooleanExpression)FromMutable((fragment as ScriptDom.WhereClause).SearchCondition),
                        cursor: (CursorId)FromMutable((fragment as ScriptDom.WhereClause).Cursor)
                    );
                }
                case 880: {
                    return new WhileStatement(
                        predicate: (BooleanExpression)FromMutable((fragment as ScriptDom.WhileStatement).Predicate),
                        statement: (TSqlStatement)FromMutable((fragment as ScriptDom.WhileStatement).Statement)
                    );
                }
                case 881: {
                    return new WindowClause(
                        windowDefinition: (fragment as ScriptDom.WindowClause).WindowDefinition.SelectList(c => (WindowDefinition)FromMutable(c))
                    );
                }
                case 882: {
                    return new WindowDefinition(
                        windowName: (Identifier)FromMutable((fragment as ScriptDom.WindowDefinition).WindowName),
                        refWindowName: (Identifier)FromMutable((fragment as ScriptDom.WindowDefinition).RefWindowName),
                        partitions: (fragment as ScriptDom.WindowDefinition).Partitions.SelectList(c => (ScalarExpression)FromMutable(c)),
                        orderByClause: (OrderByClause)FromMutable((fragment as ScriptDom.WindowDefinition).OrderByClause),
                        windowFrameClause: (WindowFrameClause)FromMutable((fragment as ScriptDom.WindowDefinition).WindowFrameClause)
                    );
                }
                case 883: {
                    return new WindowDelimiter(
                        windowDelimiterType: (fragment as ScriptDom.WindowDelimiter).WindowDelimiterType,
                        offsetValue: (ScalarExpression)FromMutable((fragment as ScriptDom.WindowDelimiter).OffsetValue)
                    );
                }
                case 884: {
                    return new WindowFrameClause(
                        top: (WindowDelimiter)FromMutable((fragment as ScriptDom.WindowFrameClause).Top),
                        bottom: (WindowDelimiter)FromMutable((fragment as ScriptDom.WindowFrameClause).Bottom),
                        windowFrameType: (fragment as ScriptDom.WindowFrameClause).WindowFrameType
                    );
                }
                case 885: {
                    return new WindowsCreateLoginSource(
                        options: (fragment as ScriptDom.WindowsCreateLoginSource).Options.SelectList(c => (PrincipalOption)FromMutable(c))
                    );
                }
                case 886: {
                    return new WithCtesAndXmlNamespaces(
                        xmlNamespaces: (XmlNamespaces)FromMutable((fragment as ScriptDom.WithCtesAndXmlNamespaces).XmlNamespaces),
                        commonTableExpressions: (fragment as ScriptDom.WithCtesAndXmlNamespaces).CommonTableExpressions.SelectList(c => (CommonTableExpression)FromMutable(c)),
                        changeTrackingContext: (ValueExpression)FromMutable((fragment as ScriptDom.WithCtesAndXmlNamespaces).ChangeTrackingContext)
                    );
                }
                case 887: {
                    return new WithinGroupClause(
                        orderByClause: (OrderByClause)FromMutable((fragment as ScriptDom.WithinGroupClause).OrderByClause),
                        hasGraphPath: (fragment as ScriptDom.WithinGroupClause).HasGraphPath
                    );
                }
                case 888: {
                    return new WitnessDatabaseOption(
                        witnessServer: (Literal)FromMutable((fragment as ScriptDom.WitnessDatabaseOption).WitnessServer),
                        isOff: (fragment as ScriptDom.WitnessDatabaseOption).IsOff,
                        optionKind: (fragment as ScriptDom.WitnessDatabaseOption).OptionKind
                    );
                }
                case 889: {
                    return new WlmTimeLiteral(
                        timeString: (StringLiteral)FromMutable((fragment as ScriptDom.WlmTimeLiteral).TimeString)
                    );
                }
                case 890: {
                    return new WorkloadGroupImportanceParameter(
                        parameterValue: (fragment as ScriptDom.WorkloadGroupImportanceParameter).ParameterValue,
                        parameterType: (fragment as ScriptDom.WorkloadGroupImportanceParameter).ParameterType
                    );
                }
                case 891: {
                    return new WorkloadGroupResourceParameter(
                        parameterValue: (Literal)FromMutable((fragment as ScriptDom.WorkloadGroupResourceParameter).ParameterValue),
                        parameterType: (fragment as ScriptDom.WorkloadGroupResourceParameter).ParameterType
                    );
                }
                case 892: {
                    return new WriteTextStatement(
                        sourceParameter: (ValueExpression)FromMutable((fragment as ScriptDom.WriteTextStatement).SourceParameter),
                        bulk: (fragment as ScriptDom.WriteTextStatement).Bulk,
                        column: (ColumnReferenceExpression)FromMutable((fragment as ScriptDom.WriteTextStatement).Column),
                        textId: (ValueExpression)FromMutable((fragment as ScriptDom.WriteTextStatement).TextId),
                        timestamp: (Literal)FromMutable((fragment as ScriptDom.WriteTextStatement).Timestamp),
                        withLog: (fragment as ScriptDom.WriteTextStatement).WithLog
                    );
                }
                case 893: {
                    return new WsdlPayloadOption(
                        isNone: (fragment as ScriptDom.WsdlPayloadOption).IsNone,
                        @value: (Literal)FromMutable((fragment as ScriptDom.WsdlPayloadOption).Value),
                        kind: (fragment as ScriptDom.WsdlPayloadOption).Kind
                    );
                }
                case 894: {
                    return new XmlCompressionOption(
                        isCompressed: (fragment as ScriptDom.XmlCompressionOption).IsCompressed,
                        partitionRanges: (fragment as ScriptDom.XmlCompressionOption).PartitionRanges.SelectList(c => (CompressionPartitionRange)FromMutable(c)),
                        optionKind: (fragment as ScriptDom.XmlCompressionOption).OptionKind
                    );
                }
                case 895: {
                    return new XmlDataTypeReference(
                        xmlDataTypeOption: (fragment as ScriptDom.XmlDataTypeReference).XmlDataTypeOption,
                        xmlSchemaCollection: (SchemaObjectName)FromMutable((fragment as ScriptDom.XmlDataTypeReference).XmlSchemaCollection),
                        name: (SchemaObjectName)FromMutable((fragment as ScriptDom.XmlDataTypeReference).Name)
                    );
                }
                case 896: {
                    return new XmlForClause(
                        options: (fragment as ScriptDom.XmlForClause).Options.SelectList(c => (XmlForClauseOption)FromMutable(c))
                    );
                }
                case 897: {
                    return new XmlForClauseOption(
                        optionKind: (fragment as ScriptDom.XmlForClauseOption).OptionKind,
                        @value: (Literal)FromMutable((fragment as ScriptDom.XmlForClauseOption).Value)
                    );
                }
                case 898: {
                    return new XmlNamespaces(
                        xmlNamespacesElements: (fragment as ScriptDom.XmlNamespaces).XmlNamespacesElements.SelectList(c => (XmlNamespacesElement)FromMutable(c))
                    );
                }
                case 899: {
                    return new XmlNamespacesAliasElement(
                        identifier: (Identifier)FromMutable((fragment as ScriptDom.XmlNamespacesAliasElement).Identifier),
                        @string: (StringLiteral)FromMutable((fragment as ScriptDom.XmlNamespacesAliasElement).String)
                    );
                }
                case 900: {
                    return new XmlNamespacesDefaultElement(
                        @string: (StringLiteral)FromMutable((fragment as ScriptDom.XmlNamespacesDefaultElement).String)
                    );
                }
                default: throw new NotImplementedException("Type not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library.");
            }
        }
    
    }

}
