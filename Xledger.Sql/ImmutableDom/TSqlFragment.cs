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
            if (fragment is null) { return null; }
            if (!TagNumberByTypeName.TryGetValue(fragment.GetType().Name, out var tag)) {
                throw new NotImplementedException("Type not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library.");
            }
        
            switch (tag) {
                case 1: return FromMutable(fragment as ScriptDom.AcceleratedDatabaseRecoveryDatabaseOption);
                case 2: return FromMutable(fragment as ScriptDom.AddAlterFullTextIndexAction);
                case 3: return FromMutable(fragment as ScriptDom.AddFileSpec);
                case 4: return FromMutable(fragment as ScriptDom.AddMemberAlterRoleAction);
                case 5: return FromMutable(fragment as ScriptDom.AddSearchPropertyListAction);
                case 6: return FromMutable(fragment as ScriptDom.AddSensitivityClassificationStatement);
                case 7: return FromMutable(fragment as ScriptDom.AddSignatureStatement);
                case 8: return FromMutable(fragment as ScriptDom.AdHocDataSource);
                case 9: return FromMutable(fragment as ScriptDom.AdHocTableReference);
                case 10: return FromMutable(fragment as ScriptDom.AlgorithmKeyOption);
                case 11: return FromMutable(fragment as ScriptDom.AlterApplicationRoleStatement);
                case 12: return FromMutable(fragment as ScriptDom.AlterAssemblyStatement);
                case 13: return FromMutable(fragment as ScriptDom.AlterAsymmetricKeyStatement);
                case 14: return FromMutable(fragment as ScriptDom.AlterAuthorizationStatement);
                case 15: return FromMutable(fragment as ScriptDom.AlterAvailabilityGroupAction);
                case 16: return FromMutable(fragment as ScriptDom.AlterAvailabilityGroupFailoverAction);
                case 17: return FromMutable(fragment as ScriptDom.AlterAvailabilityGroupFailoverOption);
                case 18: return FromMutable(fragment as ScriptDom.AlterAvailabilityGroupStatement);
                case 19: return FromMutable(fragment as ScriptDom.AlterBrokerPriorityStatement);
                case 20: return FromMutable(fragment as ScriptDom.AlterCertificateStatement);
                case 21: return FromMutable(fragment as ScriptDom.AlterColumnAlterFullTextIndexAction);
                case 22: return FromMutable(fragment as ScriptDom.AlterColumnEncryptionKeyStatement);
                case 23: return FromMutable(fragment as ScriptDom.AlterCredentialStatement);
                case 24: return FromMutable(fragment as ScriptDom.AlterCryptographicProviderStatement);
                case 25: return FromMutable(fragment as ScriptDom.AlterDatabaseAddFileGroupStatement);
                case 26: return FromMutable(fragment as ScriptDom.AlterDatabaseAddFileStatement);
                case 27: return FromMutable(fragment as ScriptDom.AlterDatabaseAuditSpecificationStatement);
                case 28: return FromMutable(fragment as ScriptDom.AlterDatabaseCollateStatement);
                case 29: return FromMutable(fragment as ScriptDom.AlterDatabaseEncryptionKeyStatement);
                case 30: return FromMutable(fragment as ScriptDom.AlterDatabaseModifyFileGroupStatement);
                case 31: return FromMutable(fragment as ScriptDom.AlterDatabaseModifyFileStatement);
                case 32: return FromMutable(fragment as ScriptDom.AlterDatabaseModifyNameStatement);
                case 33: return FromMutable(fragment as ScriptDom.AlterDatabaseRebuildLogStatement);
                case 34: return FromMutable(fragment as ScriptDom.AlterDatabaseRemoveFileGroupStatement);
                case 35: return FromMutable(fragment as ScriptDom.AlterDatabaseRemoveFileStatement);
                case 36: return FromMutable(fragment as ScriptDom.AlterDatabaseScopedConfigurationClearStatement);
                case 37: return FromMutable(fragment as ScriptDom.AlterDatabaseScopedConfigurationSetStatement);
                case 38: return FromMutable(fragment as ScriptDom.AlterDatabaseSetStatement);
                case 39: return FromMutable(fragment as ScriptDom.AlterDatabaseTermination);
                case 40: return FromMutable(fragment as ScriptDom.AlterEndpointStatement);
                case 41: return FromMutable(fragment as ScriptDom.AlterEventSessionStatement);
                case 42: return FromMutable(fragment as ScriptDom.AlterExternalDataSourceStatement);
                case 43: return FromMutable(fragment as ScriptDom.AlterExternalLanguageStatement);
                case 44: return FromMutable(fragment as ScriptDom.AlterExternalLibraryStatement);
                case 45: return FromMutable(fragment as ScriptDom.AlterExternalResourcePoolStatement);
                case 46: return FromMutable(fragment as ScriptDom.AlterFederationStatement);
                case 47: return FromMutable(fragment as ScriptDom.AlterFullTextCatalogStatement);
                case 48: return FromMutable(fragment as ScriptDom.AlterFullTextIndexStatement);
                case 49: return FromMutable(fragment as ScriptDom.AlterFullTextStopListStatement);
                case 50: return FromMutable(fragment as ScriptDom.AlterFunctionStatement);
                case 51: return FromMutable(fragment as ScriptDom.AlterIndexStatement);
                case 52: return FromMutable(fragment as ScriptDom.AlterLoginAddDropCredentialStatement);
                case 53: return FromMutable(fragment as ScriptDom.AlterLoginEnableDisableStatement);
                case 54: return FromMutable(fragment as ScriptDom.AlterLoginOptionsStatement);
                case 55: return FromMutable(fragment as ScriptDom.AlterMasterKeyStatement);
                case 56: return FromMutable(fragment as ScriptDom.AlterMessageTypeStatement);
                case 57: return FromMutable(fragment as ScriptDom.AlterPartitionFunctionStatement);
                case 58: return FromMutable(fragment as ScriptDom.AlterPartitionSchemeStatement);
                case 59: return FromMutable(fragment as ScriptDom.AlterProcedureStatement);
                case 60: return FromMutable(fragment as ScriptDom.AlterQueueStatement);
                case 61: return FromMutable(fragment as ScriptDom.AlterRemoteServiceBindingStatement);
                case 62: return FromMutable(fragment as ScriptDom.AlterResourceGovernorStatement);
                case 63: return FromMutable(fragment as ScriptDom.AlterResourcePoolStatement);
                case 64: return FromMutable(fragment as ScriptDom.AlterRoleStatement);
                case 65: return FromMutable(fragment as ScriptDom.AlterRouteStatement);
                case 66: return FromMutable(fragment as ScriptDom.AlterSchemaStatement);
                case 67: return FromMutable(fragment as ScriptDom.AlterSearchPropertyListStatement);
                case 68: return FromMutable(fragment as ScriptDom.AlterSecurityPolicyStatement);
                case 69: return FromMutable(fragment as ScriptDom.AlterSequenceStatement);
                case 70: return FromMutable(fragment as ScriptDom.AlterServerAuditSpecificationStatement);
                case 71: return FromMutable(fragment as ScriptDom.AlterServerAuditStatement);
                case 72: return FromMutable(fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption);
                case 73: return FromMutable(fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionOption);
                case 74: return FromMutable(fragment as ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption);
                case 75: return FromMutable(fragment as ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption);
                case 76: return FromMutable(fragment as ScriptDom.AlterServerConfigurationDiagnosticsLogOption);
                case 77: return FromMutable(fragment as ScriptDom.AlterServerConfigurationExternalAuthenticationContainerOption);
                case 78: return FromMutable(fragment as ScriptDom.AlterServerConfigurationExternalAuthenticationOption);
                case 79: return FromMutable(fragment as ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption);
                case 80: return FromMutable(fragment as ScriptDom.AlterServerConfigurationHadrClusterOption);
                case 81: return FromMutable(fragment as ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement);
                case 82: return FromMutable(fragment as ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement);
                case 83: return FromMutable(fragment as ScriptDom.AlterServerConfigurationSetExternalAuthenticationStatement);
                case 84: return FromMutable(fragment as ScriptDom.AlterServerConfigurationSetFailoverClusterPropertyStatement);
                case 85: return FromMutable(fragment as ScriptDom.AlterServerConfigurationSetHadrClusterStatement);
                case 86: return FromMutable(fragment as ScriptDom.AlterServerConfigurationSetSoftNumaStatement);
                case 87: return FromMutable(fragment as ScriptDom.AlterServerConfigurationSoftNumaOption);
                case 88: return FromMutable(fragment as ScriptDom.AlterServerConfigurationStatement);
                case 89: return FromMutable(fragment as ScriptDom.AlterServerRoleStatement);
                case 90: return FromMutable(fragment as ScriptDom.AlterServiceMasterKeyStatement);
                case 91: return FromMutable(fragment as ScriptDom.AlterServiceStatement);
                case 92: return FromMutable(fragment as ScriptDom.AlterSymmetricKeyStatement);
                case 93: return FromMutable(fragment as ScriptDom.AlterTableAddTableElementStatement);
                case 94: return FromMutable(fragment as ScriptDom.AlterTableAlterColumnStatement);
                case 95: return FromMutable(fragment as ScriptDom.AlterTableAlterIndexStatement);
                case 96: return FromMutable(fragment as ScriptDom.AlterTableAlterPartitionStatement);
                case 97: return FromMutable(fragment as ScriptDom.AlterTableChangeTrackingModificationStatement);
                case 98: return FromMutable(fragment as ScriptDom.AlterTableConstraintModificationStatement);
                case 99: return FromMutable(fragment as ScriptDom.AlterTableDropTableElement);
                case 100: return FromMutable(fragment as ScriptDom.AlterTableDropTableElementStatement);
                case 101: return FromMutable(fragment as ScriptDom.AlterTableFileTableNamespaceStatement);
                case 102: return FromMutable(fragment as ScriptDom.AlterTableRebuildStatement);
                case 103: return FromMutable(fragment as ScriptDom.AlterTableSetStatement);
                case 104: return FromMutable(fragment as ScriptDom.AlterTableSwitchStatement);
                case 105: return FromMutable(fragment as ScriptDom.AlterTableTriggerModificationStatement);
                case 106: return FromMutable(fragment as ScriptDom.AlterTriggerStatement);
                case 107: return FromMutable(fragment as ScriptDom.AlterUserStatement);
                case 108: return FromMutable(fragment as ScriptDom.AlterViewStatement);
                case 109: return FromMutable(fragment as ScriptDom.AlterWorkloadGroupStatement);
                case 110: return FromMutable(fragment as ScriptDom.AlterXmlSchemaCollectionStatement);
                case 111: return FromMutable(fragment as ScriptDom.ApplicationRoleOption);
                case 112: return FromMutable(fragment as ScriptDom.AssemblyEncryptionSource);
                case 113: return FromMutable(fragment as ScriptDom.AssemblyName);
                case 114: return FromMutable(fragment as ScriptDom.AssemblyOption);
                case 115: return FromMutable(fragment as ScriptDom.AssignmentSetClause);
                case 116: return FromMutable(fragment as ScriptDom.AsymmetricKeyCreateLoginSource);
                case 117: return FromMutable(fragment as ScriptDom.AtTimeZoneCall);
                case 118: return FromMutable(fragment as ScriptDom.AuditActionGroupReference);
                case 119: return FromMutable(fragment as ScriptDom.AuditActionSpecification);
                case 120: return FromMutable(fragment as ScriptDom.AuditGuidAuditOption);
                case 121: return FromMutable(fragment as ScriptDom.AuditSpecificationPart);
                case 122: return FromMutable(fragment as ScriptDom.AuditTarget);
                case 123: return FromMutable(fragment as ScriptDom.AuthenticationEndpointProtocolOption);
                case 124: return FromMutable(fragment as ScriptDom.AuthenticationPayloadOption);
                case 125: return FromMutable(fragment as ScriptDom.AutoCleanupChangeTrackingOptionDetail);
                case 126: return FromMutable(fragment as ScriptDom.AutoCreateStatisticsDatabaseOption);
                case 127: return FromMutable(fragment as ScriptDom.AutomaticTuningCreateIndexOption);
                case 128: return FromMutable(fragment as ScriptDom.AutomaticTuningDatabaseOption);
                case 129: return FromMutable(fragment as ScriptDom.AutomaticTuningDropIndexOption);
                case 130: return FromMutable(fragment as ScriptDom.AutomaticTuningForceLastGoodPlanOption);
                case 131: return FromMutable(fragment as ScriptDom.AutomaticTuningMaintainIndexOption);
                case 132: return FromMutable(fragment as ScriptDom.AutomaticTuningOption);
                case 133: return FromMutable(fragment as ScriptDom.AvailabilityModeReplicaOption);
                case 134: return FromMutable(fragment as ScriptDom.AvailabilityReplica);
                case 135: return FromMutable(fragment as ScriptDom.BackupCertificateStatement);
                case 136: return FromMutable(fragment as ScriptDom.BackupDatabaseStatement);
                case 137: return FromMutable(fragment as ScriptDom.BackupEncryptionOption);
                case 138: return FromMutable(fragment as ScriptDom.BackupMasterKeyStatement);
                case 139: return FromMutable(fragment as ScriptDom.BackupOption);
                case 140: return FromMutable(fragment as ScriptDom.BackupRestoreFileInfo);
                case 141: return FromMutable(fragment as ScriptDom.BackupServiceMasterKeyStatement);
                case 142: return FromMutable(fragment as ScriptDom.BackupTransactionLogStatement);
                case 143: return FromMutable(fragment as ScriptDom.BackwardsCompatibleDropIndexClause);
                case 144: return FromMutable(fragment as ScriptDom.BeginConversationTimerStatement);
                case 145: return FromMutable(fragment as ScriptDom.BeginDialogStatement);
                case 146: return FromMutable(fragment as ScriptDom.BeginEndAtomicBlockStatement);
                case 147: return FromMutable(fragment as ScriptDom.BeginEndBlockStatement);
                case 148: return FromMutable(fragment as ScriptDom.BeginTransactionStatement);
                case 149: return FromMutable(fragment as ScriptDom.BinaryExpression);
                case 150: return FromMutable(fragment as ScriptDom.BinaryLiteral);
                case 151: return FromMutable(fragment as ScriptDom.BinaryQueryExpression);
                case 152: return FromMutable(fragment as ScriptDom.BooleanBinaryExpression);
                case 153: return FromMutable(fragment as ScriptDom.BooleanComparisonExpression);
                case 154: return FromMutable(fragment as ScriptDom.BooleanExpressionSnippet);
                case 155: return FromMutable(fragment as ScriptDom.BooleanIsNullExpression);
                case 156: return FromMutable(fragment as ScriptDom.BooleanNotExpression);
                case 157: return FromMutable(fragment as ScriptDom.BooleanParenthesisExpression);
                case 158: return FromMutable(fragment as ScriptDom.BooleanTernaryExpression);
                case 159: return FromMutable(fragment as ScriptDom.BoundingBoxParameter);
                case 160: return FromMutable(fragment as ScriptDom.BoundingBoxSpatialIndexOption);
                case 161: return FromMutable(fragment as ScriptDom.BreakStatement);
                case 162: return FromMutable(fragment as ScriptDom.BrokerPriorityParameter);
                case 163: return FromMutable(fragment as ScriptDom.BrowseForClause);
                case 164: return FromMutable(fragment as ScriptDom.BuiltInFunctionTableReference);
                case 165: return FromMutable(fragment as ScriptDom.BulkInsertOption);
                case 166: return FromMutable(fragment as ScriptDom.BulkInsertStatement);
                case 167: return FromMutable(fragment as ScriptDom.BulkOpenRowset);
                case 168: return FromMutable(fragment as ScriptDom.CastCall);
                case 169: return FromMutable(fragment as ScriptDom.CatalogCollationOption);
                case 170: return FromMutable(fragment as ScriptDom.CellsPerObjectSpatialIndexOption);
                case 171: return FromMutable(fragment as ScriptDom.CertificateCreateLoginSource);
                case 172: return FromMutable(fragment as ScriptDom.CertificateOption);
                case 173: return FromMutable(fragment as ScriptDom.ChangeRetentionChangeTrackingOptionDetail);
                case 174: return FromMutable(fragment as ScriptDom.ChangeTableChangesTableReference);
                case 175: return FromMutable(fragment as ScriptDom.ChangeTableVersionTableReference);
                case 176: return FromMutable(fragment as ScriptDom.ChangeTrackingDatabaseOption);
                case 177: return FromMutable(fragment as ScriptDom.ChangeTrackingFullTextIndexOption);
                case 178: return FromMutable(fragment as ScriptDom.CharacterSetPayloadOption);
                case 179: return FromMutable(fragment as ScriptDom.CheckConstraintDefinition);
                case 180: return FromMutable(fragment as ScriptDom.CheckpointStatement);
                case 181: return FromMutable(fragment as ScriptDom.ChildObjectName);
                case 182: return FromMutable(fragment as ScriptDom.ClassifierEndTimeOption);
                case 183: return FromMutable(fragment as ScriptDom.ClassifierImportanceOption);
                case 184: return FromMutable(fragment as ScriptDom.ClassifierMemberNameOption);
                case 185: return FromMutable(fragment as ScriptDom.ClassifierStartTimeOption);
                case 186: return FromMutable(fragment as ScriptDom.ClassifierWlmContextOption);
                case 187: return FromMutable(fragment as ScriptDom.ClassifierWlmLabelOption);
                case 188: return FromMutable(fragment as ScriptDom.ClassifierWorkloadGroupOption);
                case 189: return FromMutable(fragment as ScriptDom.CloseCursorStatement);
                case 190: return FromMutable(fragment as ScriptDom.CloseMasterKeyStatement);
                case 191: return FromMutable(fragment as ScriptDom.CloseSymmetricKeyStatement);
                case 192: return FromMutable(fragment as ScriptDom.CoalesceExpression);
                case 193: return FromMutable(fragment as ScriptDom.ColumnDefinition);
                case 194: return FromMutable(fragment as ScriptDom.ColumnDefinitionBase);
                case 195: return FromMutable(fragment as ScriptDom.ColumnEncryptionAlgorithmNameParameter);
                case 196: return FromMutable(fragment as ScriptDom.ColumnEncryptionAlgorithmParameter);
                case 197: return FromMutable(fragment as ScriptDom.ColumnEncryptionDefinition);
                case 198: return FromMutable(fragment as ScriptDom.ColumnEncryptionKeyNameParameter);
                case 199: return FromMutable(fragment as ScriptDom.ColumnEncryptionKeyValue);
                case 200: return FromMutable(fragment as ScriptDom.ColumnEncryptionTypeParameter);
                case 201: return FromMutable(fragment as ScriptDom.ColumnMasterKeyEnclaveComputationsParameter);
                case 202: return FromMutable(fragment as ScriptDom.ColumnMasterKeyNameParameter);
                case 203: return FromMutable(fragment as ScriptDom.ColumnMasterKeyPathParameter);
                case 204: return FromMutable(fragment as ScriptDom.ColumnMasterKeyStoreProviderNameParameter);
                case 205: return FromMutable(fragment as ScriptDom.ColumnReferenceExpression);
                case 206: return FromMutable(fragment as ScriptDom.ColumnStorageOptions);
                case 207: return FromMutable(fragment as ScriptDom.ColumnWithSortOrder);
                case 208: return FromMutable(fragment as ScriptDom.CommandSecurityElement80);
                case 209: return FromMutable(fragment as ScriptDom.CommitTransactionStatement);
                case 210: return FromMutable(fragment as ScriptDom.CommonTableExpression);
                case 211: return FromMutable(fragment as ScriptDom.CompositeGroupingSpecification);
                case 212: return FromMutable(fragment as ScriptDom.CompressionDelayIndexOption);
                case 213: return FromMutable(fragment as ScriptDom.CompressionEndpointProtocolOption);
                case 214: return FromMutable(fragment as ScriptDom.CompressionPartitionRange);
                case 215: return FromMutable(fragment as ScriptDom.ComputeClause);
                case 216: return FromMutable(fragment as ScriptDom.ComputeFunction);
                case 217: return FromMutable(fragment as ScriptDom.ContainmentDatabaseOption);
                case 218: return FromMutable(fragment as ScriptDom.ContinueStatement);
                case 219: return FromMutable(fragment as ScriptDom.ContractMessage);
                case 220: return FromMutable(fragment as ScriptDom.ConvertCall);
                case 221: return FromMutable(fragment as ScriptDom.CopyColumnOption);
                case 222: return FromMutable(fragment as ScriptDom.CopyCredentialOption);
                case 223: return FromMutable(fragment as ScriptDom.CopyOption);
                case 224: return FromMutable(fragment as ScriptDom.CopyStatement);
                case 225: return FromMutable(fragment as ScriptDom.CreateAggregateStatement);
                case 226: return FromMutable(fragment as ScriptDom.CreateApplicationRoleStatement);
                case 227: return FromMutable(fragment as ScriptDom.CreateAssemblyStatement);
                case 228: return FromMutable(fragment as ScriptDom.CreateAsymmetricKeyStatement);
                case 229: return FromMutable(fragment as ScriptDom.CreateAvailabilityGroupStatement);
                case 230: return FromMutable(fragment as ScriptDom.CreateBrokerPriorityStatement);
                case 231: return FromMutable(fragment as ScriptDom.CreateCertificateStatement);
                case 232: return FromMutable(fragment as ScriptDom.CreateColumnEncryptionKeyStatement);
                case 233: return FromMutable(fragment as ScriptDom.CreateColumnMasterKeyStatement);
                case 234: return FromMutable(fragment as ScriptDom.CreateColumnStoreIndexStatement);
                case 235: return FromMutable(fragment as ScriptDom.CreateContractStatement);
                case 236: return FromMutable(fragment as ScriptDom.CreateCredentialStatement);
                case 237: return FromMutable(fragment as ScriptDom.CreateCryptographicProviderStatement);
                case 238: return FromMutable(fragment as ScriptDom.CreateDatabaseAuditSpecificationStatement);
                case 239: return FromMutable(fragment as ScriptDom.CreateDatabaseEncryptionKeyStatement);
                case 240: return FromMutable(fragment as ScriptDom.CreateDatabaseStatement);
                case 241: return FromMutable(fragment as ScriptDom.CreateDefaultStatement);
                case 242: return FromMutable(fragment as ScriptDom.CreateEndpointStatement);
                case 243: return FromMutable(fragment as ScriptDom.CreateEventNotificationStatement);
                case 244: return FromMutable(fragment as ScriptDom.CreateEventSessionStatement);
                case 245: return FromMutable(fragment as ScriptDom.CreateExternalDataSourceStatement);
                case 246: return FromMutable(fragment as ScriptDom.CreateExternalFileFormatStatement);
                case 247: return FromMutable(fragment as ScriptDom.CreateExternalLanguageStatement);
                case 248: return FromMutable(fragment as ScriptDom.CreateExternalLibraryStatement);
                case 249: return FromMutable(fragment as ScriptDom.CreateExternalResourcePoolStatement);
                case 250: return FromMutable(fragment as ScriptDom.CreateExternalStreamingJobStatement);
                case 251: return FromMutable(fragment as ScriptDom.CreateExternalStreamStatement);
                case 252: return FromMutable(fragment as ScriptDom.CreateExternalTableStatement);
                case 253: return FromMutable(fragment as ScriptDom.CreateFederationStatement);
                case 254: return FromMutable(fragment as ScriptDom.CreateFullTextCatalogStatement);
                case 255: return FromMutable(fragment as ScriptDom.CreateFullTextIndexStatement);
                case 256: return FromMutable(fragment as ScriptDom.CreateFullTextStopListStatement);
                case 257: return FromMutable(fragment as ScriptDom.CreateFunctionStatement);
                case 258: return FromMutable(fragment as ScriptDom.CreateIndexStatement);
                case 259: return FromMutable(fragment as ScriptDom.CreateLoginStatement);
                case 260: return FromMutable(fragment as ScriptDom.CreateMasterKeyStatement);
                case 261: return FromMutable(fragment as ScriptDom.CreateMessageTypeStatement);
                case 262: return FromMutable(fragment as ScriptDom.CreateOrAlterFunctionStatement);
                case 263: return FromMutable(fragment as ScriptDom.CreateOrAlterProcedureStatement);
                case 264: return FromMutable(fragment as ScriptDom.CreateOrAlterTriggerStatement);
                case 265: return FromMutable(fragment as ScriptDom.CreateOrAlterViewStatement);
                case 266: return FromMutable(fragment as ScriptDom.CreatePartitionFunctionStatement);
                case 267: return FromMutable(fragment as ScriptDom.CreatePartitionSchemeStatement);
                case 268: return FromMutable(fragment as ScriptDom.CreateProcedureStatement);
                case 269: return FromMutable(fragment as ScriptDom.CreateQueueStatement);
                case 270: return FromMutable(fragment as ScriptDom.CreateRemoteServiceBindingStatement);
                case 271: return FromMutable(fragment as ScriptDom.CreateResourcePoolStatement);
                case 272: return FromMutable(fragment as ScriptDom.CreateRoleStatement);
                case 273: return FromMutable(fragment as ScriptDom.CreateRouteStatement);
                case 274: return FromMutable(fragment as ScriptDom.CreateRuleStatement);
                case 275: return FromMutable(fragment as ScriptDom.CreateSchemaStatement);
                case 276: return FromMutable(fragment as ScriptDom.CreateSearchPropertyListStatement);
                case 277: return FromMutable(fragment as ScriptDom.CreateSecurityPolicyStatement);
                case 278: return FromMutable(fragment as ScriptDom.CreateSelectiveXmlIndexStatement);
                case 279: return FromMutable(fragment as ScriptDom.CreateSequenceStatement);
                case 280: return FromMutable(fragment as ScriptDom.CreateServerAuditSpecificationStatement);
                case 281: return FromMutable(fragment as ScriptDom.CreateServerAuditStatement);
                case 282: return FromMutable(fragment as ScriptDom.CreateServerRoleStatement);
                case 283: return FromMutable(fragment as ScriptDom.CreateServiceStatement);
                case 284: return FromMutable(fragment as ScriptDom.CreateSpatialIndexStatement);
                case 285: return FromMutable(fragment as ScriptDom.CreateStatisticsStatement);
                case 286: return FromMutable(fragment as ScriptDom.CreateSymmetricKeyStatement);
                case 287: return FromMutable(fragment as ScriptDom.CreateSynonymStatement);
                case 288: return FromMutable(fragment as ScriptDom.CreateTableStatement);
                case 289: return FromMutable(fragment as ScriptDom.CreateTriggerStatement);
                case 290: return FromMutable(fragment as ScriptDom.CreateTypeTableStatement);
                case 291: return FromMutable(fragment as ScriptDom.CreateTypeUddtStatement);
                case 292: return FromMutable(fragment as ScriptDom.CreateTypeUdtStatement);
                case 293: return FromMutable(fragment as ScriptDom.CreateUserStatement);
                case 294: return FromMutable(fragment as ScriptDom.CreateViewStatement);
                case 295: return FromMutable(fragment as ScriptDom.CreateWorkloadClassifierStatement);
                case 296: return FromMutable(fragment as ScriptDom.CreateWorkloadGroupStatement);
                case 297: return FromMutable(fragment as ScriptDom.CreateXmlIndexStatement);
                case 298: return FromMutable(fragment as ScriptDom.CreateXmlSchemaCollectionStatement);
                case 299: return FromMutable(fragment as ScriptDom.CreationDispositionKeyOption);
                case 300: return FromMutable(fragment as ScriptDom.CryptoMechanism);
                case 301: return FromMutable(fragment as ScriptDom.CubeGroupingSpecification);
                case 302: return FromMutable(fragment as ScriptDom.CursorDefaultDatabaseOption);
                case 303: return FromMutable(fragment as ScriptDom.CursorDefinition);
                case 304: return FromMutable(fragment as ScriptDom.CursorId);
                case 305: return FromMutable(fragment as ScriptDom.CursorOption);
                case 306: return FromMutable(fragment as ScriptDom.DatabaseAuditAction);
                case 307: return FromMutable(fragment as ScriptDom.DatabaseConfigurationClearOption);
                case 308: return FromMutable(fragment as ScriptDom.DatabaseConfigurationSetOption);
                case 309: return FromMutable(fragment as ScriptDom.DatabaseOption);
                case 310: return FromMutable(fragment as ScriptDom.DataCompressionOption);
                case 311: return FromMutable(fragment as ScriptDom.DataModificationTableReference);
                case 312: return FromMutable(fragment as ScriptDom.DataRetentionTableOption);
                case 313: return FromMutable(fragment as ScriptDom.DataTypeSequenceOption);
                case 314: return FromMutable(fragment as ScriptDom.DbccNamedLiteral);
                case 315: return FromMutable(fragment as ScriptDom.DbccOption);
                case 316: return FromMutable(fragment as ScriptDom.DbccStatement);
                case 317: return FromMutable(fragment as ScriptDom.DeallocateCursorStatement);
                case 318: return FromMutable(fragment as ScriptDom.DeclareCursorStatement);
                case 319: return FromMutable(fragment as ScriptDom.DeclareTableVariableBody);
                case 320: return FromMutable(fragment as ScriptDom.DeclareTableVariableStatement);
                case 321: return FromMutable(fragment as ScriptDom.DeclareVariableElement);
                case 322: return FromMutable(fragment as ScriptDom.DeclareVariableStatement);
                case 323: return FromMutable(fragment as ScriptDom.DefaultConstraintDefinition);
                case 324: return FromMutable(fragment as ScriptDom.DefaultLiteral);
                case 325: return FromMutable(fragment as ScriptDom.DelayedDurabilityDatabaseOption);
                case 326: return FromMutable(fragment as ScriptDom.DeleteMergeAction);
                case 327: return FromMutable(fragment as ScriptDom.DeleteSpecification);
                case 328: return FromMutable(fragment as ScriptDom.DeleteStatement);
                case 329: return FromMutable(fragment as ScriptDom.DenyStatement);
                case 330: return FromMutable(fragment as ScriptDom.DenyStatement80);
                case 331: return FromMutable(fragment as ScriptDom.DeviceInfo);
                case 332: return FromMutable(fragment as ScriptDom.DiskStatement);
                case 333: return FromMutable(fragment as ScriptDom.DiskStatementOption);
                case 334: return FromMutable(fragment as ScriptDom.DistinctPredicate);
                case 335: return FromMutable(fragment as ScriptDom.DropAggregateStatement);
                case 336: return FromMutable(fragment as ScriptDom.DropAlterFullTextIndexAction);
                case 337: return FromMutable(fragment as ScriptDom.DropApplicationRoleStatement);
                case 338: return FromMutable(fragment as ScriptDom.DropAssemblyStatement);
                case 339: return FromMutable(fragment as ScriptDom.DropAsymmetricKeyStatement);
                case 340: return FromMutable(fragment as ScriptDom.DropAvailabilityGroupStatement);
                case 341: return FromMutable(fragment as ScriptDom.DropBrokerPriorityStatement);
                case 342: return FromMutable(fragment as ScriptDom.DropCertificateStatement);
                case 343: return FromMutable(fragment as ScriptDom.DropClusteredConstraintMoveOption);
                case 344: return FromMutable(fragment as ScriptDom.DropClusteredConstraintStateOption);
                case 345: return FromMutable(fragment as ScriptDom.DropClusteredConstraintValueOption);
                case 346: return FromMutable(fragment as ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption);
                case 347: return FromMutable(fragment as ScriptDom.DropColumnEncryptionKeyStatement);
                case 348: return FromMutable(fragment as ScriptDom.DropColumnMasterKeyStatement);
                case 349: return FromMutable(fragment as ScriptDom.DropContractStatement);
                case 350: return FromMutable(fragment as ScriptDom.DropCredentialStatement);
                case 351: return FromMutable(fragment as ScriptDom.DropCryptographicProviderStatement);
                case 352: return FromMutable(fragment as ScriptDom.DropDatabaseAuditSpecificationStatement);
                case 353: return FromMutable(fragment as ScriptDom.DropDatabaseEncryptionKeyStatement);
                case 354: return FromMutable(fragment as ScriptDom.DropDatabaseStatement);
                case 355: return FromMutable(fragment as ScriptDom.DropDefaultStatement);
                case 356: return FromMutable(fragment as ScriptDom.DropEndpointStatement);
                case 357: return FromMutable(fragment as ScriptDom.DropEventNotificationStatement);
                case 358: return FromMutable(fragment as ScriptDom.DropEventSessionStatement);
                case 359: return FromMutable(fragment as ScriptDom.DropExternalDataSourceStatement);
                case 360: return FromMutable(fragment as ScriptDom.DropExternalFileFormatStatement);
                case 361: return FromMutable(fragment as ScriptDom.DropExternalLanguageStatement);
                case 362: return FromMutable(fragment as ScriptDom.DropExternalLibraryStatement);
                case 363: return FromMutable(fragment as ScriptDom.DropExternalResourcePoolStatement);
                case 364: return FromMutable(fragment as ScriptDom.DropExternalStreamingJobStatement);
                case 365: return FromMutable(fragment as ScriptDom.DropExternalStreamStatement);
                case 366: return FromMutable(fragment as ScriptDom.DropExternalTableStatement);
                case 367: return FromMutable(fragment as ScriptDom.DropFederationStatement);
                case 368: return FromMutable(fragment as ScriptDom.DropFullTextCatalogStatement);
                case 369: return FromMutable(fragment as ScriptDom.DropFullTextIndexStatement);
                case 370: return FromMutable(fragment as ScriptDom.DropFullTextStopListStatement);
                case 371: return FromMutable(fragment as ScriptDom.DropFunctionStatement);
                case 372: return FromMutable(fragment as ScriptDom.DropIndexClause);
                case 373: return FromMutable(fragment as ScriptDom.DropIndexStatement);
                case 374: return FromMutable(fragment as ScriptDom.DropLoginStatement);
                case 375: return FromMutable(fragment as ScriptDom.DropMasterKeyStatement);
                case 376: return FromMutable(fragment as ScriptDom.DropMemberAlterRoleAction);
                case 377: return FromMutable(fragment as ScriptDom.DropMessageTypeStatement);
                case 378: return FromMutable(fragment as ScriptDom.DropPartitionFunctionStatement);
                case 379: return FromMutable(fragment as ScriptDom.DropPartitionSchemeStatement);
                case 380: return FromMutable(fragment as ScriptDom.DropProcedureStatement);
                case 381: return FromMutable(fragment as ScriptDom.DropQueueStatement);
                case 382: return FromMutable(fragment as ScriptDom.DropRemoteServiceBindingStatement);
                case 383: return FromMutable(fragment as ScriptDom.DropResourcePoolStatement);
                case 384: return FromMutable(fragment as ScriptDom.DropRoleStatement);
                case 385: return FromMutable(fragment as ScriptDom.DropRouteStatement);
                case 386: return FromMutable(fragment as ScriptDom.DropRuleStatement);
                case 387: return FromMutable(fragment as ScriptDom.DropSchemaStatement);
                case 388: return FromMutable(fragment as ScriptDom.DropSearchPropertyListAction);
                case 389: return FromMutable(fragment as ScriptDom.DropSearchPropertyListStatement);
                case 390: return FromMutable(fragment as ScriptDom.DropSecurityPolicyStatement);
                case 391: return FromMutable(fragment as ScriptDom.DropSensitivityClassificationStatement);
                case 392: return FromMutable(fragment as ScriptDom.DropSequenceStatement);
                case 393: return FromMutable(fragment as ScriptDom.DropServerAuditSpecificationStatement);
                case 394: return FromMutable(fragment as ScriptDom.DropServerAuditStatement);
                case 395: return FromMutable(fragment as ScriptDom.DropServerRoleStatement);
                case 396: return FromMutable(fragment as ScriptDom.DropServiceStatement);
                case 397: return FromMutable(fragment as ScriptDom.DropSignatureStatement);
                case 398: return FromMutable(fragment as ScriptDom.DropStatisticsStatement);
                case 399: return FromMutable(fragment as ScriptDom.DropSymmetricKeyStatement);
                case 400: return FromMutable(fragment as ScriptDom.DropSynonymStatement);
                case 401: return FromMutable(fragment as ScriptDom.DropTableStatement);
                case 402: return FromMutable(fragment as ScriptDom.DropTriggerStatement);
                case 403: return FromMutable(fragment as ScriptDom.DropTypeStatement);
                case 404: return FromMutable(fragment as ScriptDom.DropUserStatement);
                case 405: return FromMutable(fragment as ScriptDom.DropViewStatement);
                case 406: return FromMutable(fragment as ScriptDom.DropWorkloadClassifierStatement);
                case 407: return FromMutable(fragment as ScriptDom.DropWorkloadGroupStatement);
                case 408: return FromMutable(fragment as ScriptDom.DropXmlSchemaCollectionStatement);
                case 409: return FromMutable(fragment as ScriptDom.DurabilityTableOption);
                case 410: return FromMutable(fragment as ScriptDom.EnabledDisabledPayloadOption);
                case 411: return FromMutable(fragment as ScriptDom.EnableDisableTriggerStatement);
                case 412: return FromMutable(fragment as ScriptDom.EncryptedValueParameter);
                case 413: return FromMutable(fragment as ScriptDom.EncryptionPayloadOption);
                case 414: return FromMutable(fragment as ScriptDom.EndConversationStatement);
                case 415: return FromMutable(fragment as ScriptDom.EndpointAffinity);
                case 416: return FromMutable(fragment as ScriptDom.EventDeclaration);
                case 417: return FromMutable(fragment as ScriptDom.EventDeclarationCompareFunctionParameter);
                case 418: return FromMutable(fragment as ScriptDom.EventDeclarationSetParameter);
                case 419: return FromMutable(fragment as ScriptDom.EventGroupContainer);
                case 420: return FromMutable(fragment as ScriptDom.EventNotificationObjectScope);
                case 421: return FromMutable(fragment as ScriptDom.EventRetentionSessionOption);
                case 422: return FromMutable(fragment as ScriptDom.EventSessionObjectName);
                case 423: return FromMutable(fragment as ScriptDom.EventSessionStatement);
                case 424: return FromMutable(fragment as ScriptDom.EventTypeContainer);
                case 425: return FromMutable(fragment as ScriptDom.ExecutableProcedureReference);
                case 426: return FromMutable(fragment as ScriptDom.ExecutableStringList);
                case 427: return FromMutable(fragment as ScriptDom.ExecuteAsClause);
                case 428: return FromMutable(fragment as ScriptDom.ExecuteAsFunctionOption);
                case 429: return FromMutable(fragment as ScriptDom.ExecuteAsProcedureOption);
                case 430: return FromMutable(fragment as ScriptDom.ExecuteAsStatement);
                case 431: return FromMutable(fragment as ScriptDom.ExecuteAsTriggerOption);
                case 432: return FromMutable(fragment as ScriptDom.ExecuteContext);
                case 433: return FromMutable(fragment as ScriptDom.ExecuteInsertSource);
                case 434: return FromMutable(fragment as ScriptDom.ExecuteOption);
                case 435: return FromMutable(fragment as ScriptDom.ExecuteParameter);
                case 436: return FromMutable(fragment as ScriptDom.ExecuteSpecification);
                case 437: return FromMutable(fragment as ScriptDom.ExecuteStatement);
                case 438: return FromMutable(fragment as ScriptDom.ExistsPredicate);
                case 439: return FromMutable(fragment as ScriptDom.ExpressionCallTarget);
                case 440: return FromMutable(fragment as ScriptDom.ExpressionGroupingSpecification);
                case 441: return FromMutable(fragment as ScriptDom.ExpressionWithSortOrder);
                case 442: return FromMutable(fragment as ScriptDom.ExternalCreateLoginSource);
                case 443: return FromMutable(fragment as ScriptDom.ExternalDataSourceLiteralOrIdentifierOption);
                case 444: return FromMutable(fragment as ScriptDom.ExternalFileFormatContainerOption);
                case 445: return FromMutable(fragment as ScriptDom.ExternalFileFormatLiteralOption);
                case 446: return FromMutable(fragment as ScriptDom.ExternalFileFormatUseDefaultTypeOption);
                case 447: return FromMutable(fragment as ScriptDom.ExternalLanguageFileOption);
                case 448: return FromMutable(fragment as ScriptDom.ExternalLibraryFileOption);
                case 449: return FromMutable(fragment as ScriptDom.ExternalResourcePoolAffinitySpecification);
                case 450: return FromMutable(fragment as ScriptDom.ExternalResourcePoolParameter);
                case 451: return FromMutable(fragment as ScriptDom.ExternalResourcePoolStatement);
                case 452: return FromMutable(fragment as ScriptDom.ExternalStreamLiteralOrIdentifierOption);
                case 453: return FromMutable(fragment as ScriptDom.ExternalTableColumnDefinition);
                case 454: return FromMutable(fragment as ScriptDom.ExternalTableDistributionOption);
                case 455: return FromMutable(fragment as ScriptDom.ExternalTableLiteralOrIdentifierOption);
                case 456: return FromMutable(fragment as ScriptDom.ExternalTableRejectTypeOption);
                case 457: return FromMutable(fragment as ScriptDom.ExternalTableReplicatedDistributionPolicy);
                case 458: return FromMutable(fragment as ScriptDom.ExternalTableRoundRobinDistributionPolicy);
                case 459: return FromMutable(fragment as ScriptDom.ExternalTableShardedDistributionPolicy);
                case 460: return FromMutable(fragment as ScriptDom.ExtractFromExpression);
                case 461: return FromMutable(fragment as ScriptDom.FailoverModeReplicaOption);
                case 462: return FromMutable(fragment as ScriptDom.FederationScheme);
                case 463: return FromMutable(fragment as ScriptDom.FetchCursorStatement);
                case 464: return FromMutable(fragment as ScriptDom.FetchType);
                case 465: return FromMutable(fragment as ScriptDom.FileDeclaration);
                case 466: return FromMutable(fragment as ScriptDom.FileDeclarationOption);
                case 467: return FromMutable(fragment as ScriptDom.FileEncryptionSource);
                case 468: return FromMutable(fragment as ScriptDom.FileGroupDefinition);
                case 469: return FromMutable(fragment as ScriptDom.FileGroupOrPartitionScheme);
                case 470: return FromMutable(fragment as ScriptDom.FileGrowthFileDeclarationOption);
                case 471: return FromMutable(fragment as ScriptDom.FileNameFileDeclarationOption);
                case 472: return FromMutable(fragment as ScriptDom.FileStreamDatabaseOption);
                case 473: return FromMutable(fragment as ScriptDom.FileStreamOnDropIndexOption);
                case 474: return FromMutable(fragment as ScriptDom.FileStreamOnTableOption);
                case 475: return FromMutable(fragment as ScriptDom.FileStreamRestoreOption);
                case 476: return FromMutable(fragment as ScriptDom.FileTableCollateFileNameTableOption);
                case 477: return FromMutable(fragment as ScriptDom.FileTableConstraintNameTableOption);
                case 478: return FromMutable(fragment as ScriptDom.FileTableDirectoryTableOption);
                case 479: return FromMutable(fragment as ScriptDom.ForceSeekTableHint);
                case 480: return FromMutable(fragment as ScriptDom.ForeignKeyConstraintDefinition);
                case 481: return FromMutable(fragment as ScriptDom.FromClause);
                case 482: return FromMutable(fragment as ScriptDom.FullTextCatalogAndFileGroup);
                case 483: return FromMutable(fragment as ScriptDom.FullTextIndexColumn);
                case 484: return FromMutable(fragment as ScriptDom.FullTextPredicate);
                case 485: return FromMutable(fragment as ScriptDom.FullTextStopListAction);
                case 486: return FromMutable(fragment as ScriptDom.FullTextTableReference);
                case 487: return FromMutable(fragment as ScriptDom.FunctionCall);
                case 488: return FromMutable(fragment as ScriptDom.FunctionCallSetClause);
                case 489: return FromMutable(fragment as ScriptDom.FunctionOption);
                case 490: return FromMutable(fragment as ScriptDom.GeneralSetCommand);
                case 491: return FromMutable(fragment as ScriptDom.GenericConfigurationOption);
                case 492: return FromMutable(fragment as ScriptDom.GetConversationGroupStatement);
                case 493: return FromMutable(fragment as ScriptDom.GlobalFunctionTableReference);
                case 494: return FromMutable(fragment as ScriptDom.GlobalVariableExpression);
                case 495: return FromMutable(fragment as ScriptDom.GoToStatement);
                case 496: return FromMutable(fragment as ScriptDom.GrandTotalGroupingSpecification);
                case 497: return FromMutable(fragment as ScriptDom.GrantStatement);
                case 498: return FromMutable(fragment as ScriptDom.GrantStatement80);
                case 499: return FromMutable(fragment as ScriptDom.GraphConnectionBetweenNodes);
                case 500: return FromMutable(fragment as ScriptDom.GraphConnectionConstraintDefinition);
                case 501: return FromMutable(fragment as ScriptDom.GraphMatchCompositeExpression);
                case 502: return FromMutable(fragment as ScriptDom.GraphMatchExpression);
                case 503: return FromMutable(fragment as ScriptDom.GraphMatchLastNodePredicate);
                case 504: return FromMutable(fragment as ScriptDom.GraphMatchNodeExpression);
                case 505: return FromMutable(fragment as ScriptDom.GraphMatchPredicate);
                case 506: return FromMutable(fragment as ScriptDom.GraphMatchRecursivePredicate);
                case 507: return FromMutable(fragment as ScriptDom.GraphRecursiveMatchQuantifier);
                case 508: return FromMutable(fragment as ScriptDom.GridParameter);
                case 509: return FromMutable(fragment as ScriptDom.GridsSpatialIndexOption);
                case 510: return FromMutable(fragment as ScriptDom.GroupByClause);
                case 511: return FromMutable(fragment as ScriptDom.GroupingSetsGroupingSpecification);
                case 512: return FromMutable(fragment as ScriptDom.HadrAvailabilityGroupDatabaseOption);
                case 513: return FromMutable(fragment as ScriptDom.HadrDatabaseOption);
                case 514: return FromMutable(fragment as ScriptDom.HavingClause);
                case 515: return FromMutable(fragment as ScriptDom.Identifier);
                case 516: return FromMutable(fragment as ScriptDom.IdentifierAtomicBlockOption);
                case 517: return FromMutable(fragment as ScriptDom.IdentifierDatabaseOption);
                case 518: return FromMutable(fragment as ScriptDom.IdentifierLiteral);
                case 519: return FromMutable(fragment as ScriptDom.IdentifierOrScalarExpression);
                case 520: return FromMutable(fragment as ScriptDom.IdentifierOrValueExpression);
                case 521: return FromMutable(fragment as ScriptDom.IdentifierPrincipalOption);
                case 522: return FromMutable(fragment as ScriptDom.IdentifierSnippet);
                case 523: return FromMutable(fragment as ScriptDom.IdentityFunctionCall);
                case 524: return FromMutable(fragment as ScriptDom.IdentityOptions);
                case 525: return FromMutable(fragment as ScriptDom.IdentityValueKeyOption);
                case 526: return FromMutable(fragment as ScriptDom.IfStatement);
                case 527: return FromMutable(fragment as ScriptDom.IgnoreDupKeyIndexOption);
                case 528: return FromMutable(fragment as ScriptDom.IIfCall);
                case 529: return FromMutable(fragment as ScriptDom.IndexDefinition);
                case 530: return FromMutable(fragment as ScriptDom.IndexExpressionOption);
                case 531: return FromMutable(fragment as ScriptDom.IndexStateOption);
                case 532: return FromMutable(fragment as ScriptDom.IndexTableHint);
                case 533: return FromMutable(fragment as ScriptDom.IndexType);
                case 534: return FromMutable(fragment as ScriptDom.InlineDerivedTable);
                case 535: return FromMutable(fragment as ScriptDom.InlineFunctionOption);
                case 536: return FromMutable(fragment as ScriptDom.InlineResultSetDefinition);
                case 537: return FromMutable(fragment as ScriptDom.InPredicate);
                case 538: return FromMutable(fragment as ScriptDom.InsertBulkColumnDefinition);
                case 539: return FromMutable(fragment as ScriptDom.InsertBulkStatement);
                case 540: return FromMutable(fragment as ScriptDom.InsertMergeAction);
                case 541: return FromMutable(fragment as ScriptDom.InsertSpecification);
                case 542: return FromMutable(fragment as ScriptDom.InsertStatement);
                case 543: return FromMutable(fragment as ScriptDom.IntegerLiteral);
                case 544: return FromMutable(fragment as ScriptDom.InternalOpenRowset);
                case 545: return FromMutable(fragment as ScriptDom.IPv4);
                case 546: return FromMutable(fragment as ScriptDom.JoinParenthesisTableReference);
                case 547: return FromMutable(fragment as ScriptDom.JsonForClause);
                case 548: return FromMutable(fragment as ScriptDom.JsonForClauseOption);
                case 549: return FromMutable(fragment as ScriptDom.JsonKeyValue);
                case 550: return FromMutable(fragment as ScriptDom.KeySourceKeyOption);
                case 551: return FromMutable(fragment as ScriptDom.KillQueryNotificationSubscriptionStatement);
                case 552: return FromMutable(fragment as ScriptDom.KillStatement);
                case 553: return FromMutable(fragment as ScriptDom.KillStatsJobStatement);
                case 554: return FromMutable(fragment as ScriptDom.LabelStatement);
                case 555: return FromMutable(fragment as ScriptDom.LedgerOption);
                case 556: return FromMutable(fragment as ScriptDom.LedgerTableOption);
                case 557: return FromMutable(fragment as ScriptDom.LedgerViewOption);
                case 558: return FromMutable(fragment as ScriptDom.LeftFunctionCall);
                case 559: return FromMutable(fragment as ScriptDom.LikePredicate);
                case 560: return FromMutable(fragment as ScriptDom.LineNoStatement);
                case 561: return FromMutable(fragment as ScriptDom.ListenerIPEndpointProtocolOption);
                case 562: return FromMutable(fragment as ScriptDom.ListTypeCopyOption);
                case 563: return FromMutable(fragment as ScriptDom.LiteralAtomicBlockOption);
                case 564: return FromMutable(fragment as ScriptDom.LiteralAuditTargetOption);
                case 565: return FromMutable(fragment as ScriptDom.LiteralAvailabilityGroupOption);
                case 566: return FromMutable(fragment as ScriptDom.LiteralBulkInsertOption);
                case 567: return FromMutable(fragment as ScriptDom.LiteralDatabaseOption);
                case 568: return FromMutable(fragment as ScriptDom.LiteralEndpointProtocolOption);
                case 569: return FromMutable(fragment as ScriptDom.LiteralOpenRowsetCosmosOption);
                case 570: return FromMutable(fragment as ScriptDom.LiteralOptimizerHint);
                case 571: return FromMutable(fragment as ScriptDom.LiteralOptionValue);
                case 572: return FromMutable(fragment as ScriptDom.LiteralPayloadOption);
                case 573: return FromMutable(fragment as ScriptDom.LiteralPrincipalOption);
                case 574: return FromMutable(fragment as ScriptDom.LiteralRange);
                case 575: return FromMutable(fragment as ScriptDom.LiteralReplicaOption);
                case 576: return FromMutable(fragment as ScriptDom.LiteralSessionOption);
                case 577: return FromMutable(fragment as ScriptDom.LiteralStatisticsOption);
                case 578: return FromMutable(fragment as ScriptDom.LiteralTableHint);
                case 579: return FromMutable(fragment as ScriptDom.LocationOption);
                case 580: return FromMutable(fragment as ScriptDom.LockEscalationTableOption);
                case 581: return FromMutable(fragment as ScriptDom.LoginTypePayloadOption);
                case 582: return FromMutable(fragment as ScriptDom.LowPriorityLockWaitAbortAfterWaitOption);
                case 583: return FromMutable(fragment as ScriptDom.LowPriorityLockWaitMaxDurationOption);
                case 584: return FromMutable(fragment as ScriptDom.LowPriorityLockWaitTableSwitchOption);
                case 585: return FromMutable(fragment as ScriptDom.MaxDispatchLatencySessionOption);
                case 586: return FromMutable(fragment as ScriptDom.MaxDopConfigurationOption);
                case 587: return FromMutable(fragment as ScriptDom.MaxDurationOption);
                case 588: return FromMutable(fragment as ScriptDom.MaxLiteral);
                case 589: return FromMutable(fragment as ScriptDom.MaxRolloverFilesAuditTargetOption);
                case 590: return FromMutable(fragment as ScriptDom.MaxSizeAuditTargetOption);
                case 591: return FromMutable(fragment as ScriptDom.MaxSizeDatabaseOption);
                case 592: return FromMutable(fragment as ScriptDom.MaxSizeFileDeclarationOption);
                case 593: return FromMutable(fragment as ScriptDom.MemoryOptimizedTableOption);
                case 594: return FromMutable(fragment as ScriptDom.MemoryPartitionSessionOption);
                case 595: return FromMutable(fragment as ScriptDom.MergeActionClause);
                case 596: return FromMutable(fragment as ScriptDom.MergeSpecification);
                case 597: return FromMutable(fragment as ScriptDom.MergeStatement);
                case 598: return FromMutable(fragment as ScriptDom.MethodSpecifier);
                case 599: return FromMutable(fragment as ScriptDom.MirrorToClause);
                case 600: return FromMutable(fragment as ScriptDom.MoneyLiteral);
                case 601: return FromMutable(fragment as ScriptDom.MoveConversationStatement);
                case 602: return FromMutable(fragment as ScriptDom.MoveRestoreOption);
                case 603: return FromMutable(fragment as ScriptDom.MoveToDropIndexOption);
                case 604: return FromMutable(fragment as ScriptDom.MultiPartIdentifier);
                case 605: return FromMutable(fragment as ScriptDom.MultiPartIdentifierCallTarget);
                case 606: return FromMutable(fragment as ScriptDom.NamedTableReference);
                case 607: return FromMutable(fragment as ScriptDom.NameFileDeclarationOption);
                case 608: return FromMutable(fragment as ScriptDom.NextValueForExpression);
                case 609: return FromMutable(fragment as ScriptDom.NullableConstraintDefinition);
                case 610: return FromMutable(fragment as ScriptDom.NullIfExpression);
                case 611: return FromMutable(fragment as ScriptDom.NullLiteral);
                case 612: return FromMutable(fragment as ScriptDom.NumericLiteral);
                case 613: return FromMutable(fragment as ScriptDom.OdbcConvertSpecification);
                case 614: return FromMutable(fragment as ScriptDom.OdbcFunctionCall);
                case 615: return FromMutable(fragment as ScriptDom.OdbcLiteral);
                case 616: return FromMutable(fragment as ScriptDom.OdbcQualifiedJoinTableReference);
                case 617: return FromMutable(fragment as ScriptDom.OffsetClause);
                case 618: return FromMutable(fragment as ScriptDom.OnFailureAuditOption);
                case 619: return FromMutable(fragment as ScriptDom.OnlineIndexLowPriorityLockWaitOption);
                case 620: return FromMutable(fragment as ScriptDom.OnlineIndexOption);
                case 621: return FromMutable(fragment as ScriptDom.OnOffAssemblyOption);
                case 622: return FromMutable(fragment as ScriptDom.OnOffAtomicBlockOption);
                case 623: return FromMutable(fragment as ScriptDom.OnOffAuditTargetOption);
                case 624: return FromMutable(fragment as ScriptDom.OnOffDatabaseOption);
                case 625: return FromMutable(fragment as ScriptDom.OnOffDialogOption);
                case 626: return FromMutable(fragment as ScriptDom.OnOffFullTextCatalogOption);
                case 627: return FromMutable(fragment as ScriptDom.OnOffOptionValue);
                case 628: return FromMutable(fragment as ScriptDom.OnOffPrimaryConfigurationOption);
                case 629: return FromMutable(fragment as ScriptDom.OnOffPrincipalOption);
                case 630: return FromMutable(fragment as ScriptDom.OnOffRemoteServiceBindingOption);
                case 631: return FromMutable(fragment as ScriptDom.OnOffSessionOption);
                case 632: return FromMutable(fragment as ScriptDom.OnOffStatisticsOption);
                case 633: return FromMutable(fragment as ScriptDom.OpenCursorStatement);
                case 634: return FromMutable(fragment as ScriptDom.OpenJsonTableReference);
                case 635: return FromMutable(fragment as ScriptDom.OpenMasterKeyStatement);
                case 636: return FromMutable(fragment as ScriptDom.OpenQueryTableReference);
                case 637: return FromMutable(fragment as ScriptDom.OpenRowsetColumnDefinition);
                case 638: return FromMutable(fragment as ScriptDom.OpenRowsetCosmos);
                case 639: return FromMutable(fragment as ScriptDom.OpenRowsetCosmosOption);
                case 640: return FromMutable(fragment as ScriptDom.OpenRowsetTableReference);
                case 641: return FromMutable(fragment as ScriptDom.OpenSymmetricKeyStatement);
                case 642: return FromMutable(fragment as ScriptDom.OpenXmlTableReference);
                case 643: return FromMutable(fragment as ScriptDom.OperatorAuditOption);
                case 644: return FromMutable(fragment as ScriptDom.OptimizeForOptimizerHint);
                case 645: return FromMutable(fragment as ScriptDom.OptimizerHint);
                case 646: return FromMutable(fragment as ScriptDom.OrderBulkInsertOption);
                case 647: return FromMutable(fragment as ScriptDom.OrderByClause);
                case 648: return FromMutable(fragment as ScriptDom.OrderIndexOption);
                case 649: return FromMutable(fragment as ScriptDom.OutputClause);
                case 650: return FromMutable(fragment as ScriptDom.OutputIntoClause);
                case 651: return FromMutable(fragment as ScriptDom.OverClause);
                case 652: return FromMutable(fragment as ScriptDom.PageVerifyDatabaseOption);
                case 653: return FromMutable(fragment as ScriptDom.ParameterizationDatabaseOption);
                case 654: return FromMutable(fragment as ScriptDom.ParameterlessCall);
                case 655: return FromMutable(fragment as ScriptDom.ParenthesisExpression);
                case 656: return FromMutable(fragment as ScriptDom.ParseCall);
                case 657: return FromMutable(fragment as ScriptDom.PartitionFunctionCall);
                case 658: return FromMutable(fragment as ScriptDom.PartitionParameterType);
                case 659: return FromMutable(fragment as ScriptDom.PartitionSpecifier);
                case 660: return FromMutable(fragment as ScriptDom.PartnerDatabaseOption);
                case 661: return FromMutable(fragment as ScriptDom.PasswordAlterPrincipalOption);
                case 662: return FromMutable(fragment as ScriptDom.PasswordCreateLoginSource);
                case 663: return FromMutable(fragment as ScriptDom.Permission);
                case 664: return FromMutable(fragment as ScriptDom.PermissionSetAssemblyOption);
                case 665: return FromMutable(fragment as ScriptDom.PivotedTableReference);
                case 666: return FromMutable(fragment as ScriptDom.PortsEndpointProtocolOption);
                case 667: return FromMutable(fragment as ScriptDom.PredicateSetStatement);
                case 668: return FromMutable(fragment as ScriptDom.PredictTableReference);
                case 669: return FromMutable(fragment as ScriptDom.PrimaryRoleReplicaOption);
                case 670: return FromMutable(fragment as ScriptDom.PrincipalOption);
                case 671: return FromMutable(fragment as ScriptDom.PrintStatement);
                case 672: return FromMutable(fragment as ScriptDom.Privilege80);
                case 673: return FromMutable(fragment as ScriptDom.PrivilegeSecurityElement80);
                case 674: return FromMutable(fragment as ScriptDom.ProcedureOption);
                case 675: return FromMutable(fragment as ScriptDom.ProcedureParameter);
                case 676: return FromMutable(fragment as ScriptDom.ProcedureReference);
                case 677: return FromMutable(fragment as ScriptDom.ProcedureReferenceName);
                case 678: return FromMutable(fragment as ScriptDom.ProcessAffinityRange);
                case 679: return FromMutable(fragment as ScriptDom.ProviderEncryptionSource);
                case 680: return FromMutable(fragment as ScriptDom.ProviderKeyNameKeyOption);
                case 681: return FromMutable(fragment as ScriptDom.QualifiedJoin);
                case 682: return FromMutable(fragment as ScriptDom.QueryDerivedTable);
                case 683: return FromMutable(fragment as ScriptDom.QueryParenthesisExpression);
                case 684: return FromMutable(fragment as ScriptDom.QuerySpecification);
                case 685: return FromMutable(fragment as ScriptDom.QueryStoreCapturePolicyOption);
                case 686: return FromMutable(fragment as ScriptDom.QueryStoreDatabaseOption);
                case 687: return FromMutable(fragment as ScriptDom.QueryStoreDataFlushIntervalOption);
                case 688: return FromMutable(fragment as ScriptDom.QueryStoreDesiredStateOption);
                case 689: return FromMutable(fragment as ScriptDom.QueryStoreIntervalLengthOption);
                case 690: return FromMutable(fragment as ScriptDom.QueryStoreMaxPlansPerQueryOption);
                case 691: return FromMutable(fragment as ScriptDom.QueryStoreMaxStorageSizeOption);
                case 692: return FromMutable(fragment as ScriptDom.QueryStoreSizeCleanupPolicyOption);
                case 693: return FromMutable(fragment as ScriptDom.QueryStoreTimeCleanupPolicyOption);
                case 694: return FromMutable(fragment as ScriptDom.QueueDelayAuditOption);
                case 695: return FromMutable(fragment as ScriptDom.QueueExecuteAsOption);
                case 696: return FromMutable(fragment as ScriptDom.QueueOption);
                case 697: return FromMutable(fragment as ScriptDom.QueueProcedureOption);
                case 698: return FromMutable(fragment as ScriptDom.QueueStateOption);
                case 699: return FromMutable(fragment as ScriptDom.QueueValueOption);
                case 700: return FromMutable(fragment as ScriptDom.RaiseErrorLegacyStatement);
                case 701: return FromMutable(fragment as ScriptDom.RaiseErrorStatement);
                case 702: return FromMutable(fragment as ScriptDom.ReadOnlyForClause);
                case 703: return FromMutable(fragment as ScriptDom.ReadTextStatement);
                case 704: return FromMutable(fragment as ScriptDom.RealLiteral);
                case 705: return FromMutable(fragment as ScriptDom.ReceiveStatement);
                case 706: return FromMutable(fragment as ScriptDom.ReconfigureStatement);
                case 707: return FromMutable(fragment as ScriptDom.RecoveryDatabaseOption);
                case 708: return FromMutable(fragment as ScriptDom.RemoteDataArchiveAlterTableOption);
                case 709: return FromMutable(fragment as ScriptDom.RemoteDataArchiveDatabaseOption);
                case 710: return FromMutable(fragment as ScriptDom.RemoteDataArchiveDbCredentialSetting);
                case 711: return FromMutable(fragment as ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting);
                case 712: return FromMutable(fragment as ScriptDom.RemoteDataArchiveDbServerSetting);
                case 713: return FromMutable(fragment as ScriptDom.RemoteDataArchiveTableOption);
                case 714: return FromMutable(fragment as ScriptDom.RenameAlterRoleAction);
                case 715: return FromMutable(fragment as ScriptDom.RenameEntityStatement);
                case 716: return FromMutable(fragment as ScriptDom.ResampleStatisticsOption);
                case 717: return FromMutable(fragment as ScriptDom.ResourcePoolAffinitySpecification);
                case 718: return FromMutable(fragment as ScriptDom.ResourcePoolParameter);
                case 719: return FromMutable(fragment as ScriptDom.ResourcePoolStatement);
                case 720: return FromMutable(fragment as ScriptDom.RestoreMasterKeyStatement);
                case 721: return FromMutable(fragment as ScriptDom.RestoreOption);
                case 722: return FromMutable(fragment as ScriptDom.RestoreServiceMasterKeyStatement);
                case 723: return FromMutable(fragment as ScriptDom.RestoreStatement);
                case 724: return FromMutable(fragment as ScriptDom.ResultColumnDefinition);
                case 725: return FromMutable(fragment as ScriptDom.ResultSetDefinition);
                case 726: return FromMutable(fragment as ScriptDom.ResultSetsExecuteOption);
                case 727: return FromMutable(fragment as ScriptDom.RetentionDaysAuditTargetOption);
                case 728: return FromMutable(fragment as ScriptDom.RetentionPeriodDefinition);
                case 729: return FromMutable(fragment as ScriptDom.ReturnStatement);
                case 730: return FromMutable(fragment as ScriptDom.RevertStatement);
                case 731: return FromMutable(fragment as ScriptDom.RevokeStatement);
                case 732: return FromMutable(fragment as ScriptDom.RevokeStatement80);
                case 733: return FromMutable(fragment as ScriptDom.RightFunctionCall);
                case 734: return FromMutable(fragment as ScriptDom.RolePayloadOption);
                case 735: return FromMutable(fragment as ScriptDom.RollbackTransactionStatement);
                case 736: return FromMutable(fragment as ScriptDom.RollupGroupingSpecification);
                case 737: return FromMutable(fragment as ScriptDom.RouteOption);
                case 738: return FromMutable(fragment as ScriptDom.RowValue);
                case 739: return FromMutable(fragment as ScriptDom.SaveTransactionStatement);
                case 740: return FromMutable(fragment as ScriptDom.ScalarExpressionDialogOption);
                case 741: return FromMutable(fragment as ScriptDom.ScalarExpressionRestoreOption);
                case 742: return FromMutable(fragment as ScriptDom.ScalarExpressionSequenceOption);
                case 743: return FromMutable(fragment as ScriptDom.ScalarExpressionSnippet);
                case 744: return FromMutable(fragment as ScriptDom.ScalarFunctionReturnType);
                case 745: return FromMutable(fragment as ScriptDom.ScalarSubquery);
                case 746: return FromMutable(fragment as ScriptDom.SchemaDeclarationItem);
                case 747: return FromMutable(fragment as ScriptDom.SchemaDeclarationItemOpenjson);
                case 748: return FromMutable(fragment as ScriptDom.SchemaObjectFunctionTableReference);
                case 749: return FromMutable(fragment as ScriptDom.SchemaObjectName);
                case 750: return FromMutable(fragment as ScriptDom.SchemaObjectNameOrValueExpression);
                case 751: return FromMutable(fragment as ScriptDom.SchemaObjectNameSnippet);
                case 752: return FromMutable(fragment as ScriptDom.SchemaObjectResultSetDefinition);
                case 753: return FromMutable(fragment as ScriptDom.SchemaPayloadOption);
                case 754: return FromMutable(fragment as ScriptDom.SearchedCaseExpression);
                case 755: return FromMutable(fragment as ScriptDom.SearchedWhenClause);
                case 756: return FromMutable(fragment as ScriptDom.SearchPropertyListFullTextIndexOption);
                case 757: return FromMutable(fragment as ScriptDom.SecondaryRoleReplicaOption);
                case 758: return FromMutable(fragment as ScriptDom.SecurityPolicyOption);
                case 759: return FromMutable(fragment as ScriptDom.SecurityPredicateAction);
                case 760: return FromMutable(fragment as ScriptDom.SecurityPrincipal);
                case 761: return FromMutable(fragment as ScriptDom.SecurityTargetObject);
                case 762: return FromMutable(fragment as ScriptDom.SecurityTargetObjectName);
                case 763: return FromMutable(fragment as ScriptDom.SecurityUserClause80);
                case 764: return FromMutable(fragment as ScriptDom.SelectFunctionReturnType);
                case 765: return FromMutable(fragment as ScriptDom.SelectInsertSource);
                case 766: return FromMutable(fragment as ScriptDom.SelectiveXmlIndexPromotedPath);
                case 767: return FromMutable(fragment as ScriptDom.SelectScalarExpression);
                case 768: return FromMutable(fragment as ScriptDom.SelectSetVariable);
                case 769: return FromMutable(fragment as ScriptDom.SelectStarExpression);
                case 770: return FromMutable(fragment as ScriptDom.SelectStatement);
                case 771: return FromMutable(fragment as ScriptDom.SelectStatementSnippet);
                case 772: return FromMutable(fragment as ScriptDom.SemanticTableReference);
                case 773: return FromMutable(fragment as ScriptDom.SendStatement);
                case 774: return FromMutable(fragment as ScriptDom.SensitivityClassificationOption);
                case 775: return FromMutable(fragment as ScriptDom.SequenceOption);
                case 776: return FromMutable(fragment as ScriptDom.ServiceContract);
                case 777: return FromMutable(fragment as ScriptDom.SessionTimeoutPayloadOption);
                case 778: return FromMutable(fragment as ScriptDom.SetCommandStatement);
                case 779: return FromMutable(fragment as ScriptDom.SetErrorLevelStatement);
                case 780: return FromMutable(fragment as ScriptDom.SetFipsFlaggerCommand);
                case 781: return FromMutable(fragment as ScriptDom.SetIdentityInsertStatement);
                case 782: return FromMutable(fragment as ScriptDom.SetOffsetsStatement);
                case 783: return FromMutable(fragment as ScriptDom.SetRowCountStatement);
                case 784: return FromMutable(fragment as ScriptDom.SetSearchPropertyListAlterFullTextIndexAction);
                case 785: return FromMutable(fragment as ScriptDom.SetStatisticsStatement);
                case 786: return FromMutable(fragment as ScriptDom.SetStopListAlterFullTextIndexAction);
                case 787: return FromMutable(fragment as ScriptDom.SetTextSizeStatement);
                case 788: return FromMutable(fragment as ScriptDom.SetTransactionIsolationLevelStatement);
                case 789: return FromMutable(fragment as ScriptDom.SetUserStatement);
                case 790: return FromMutable(fragment as ScriptDom.SetVariableStatement);
                case 791: return FromMutable(fragment as ScriptDom.ShutdownStatement);
                case 792: return FromMutable(fragment as ScriptDom.SimpleAlterFullTextIndexAction);
                case 793: return FromMutable(fragment as ScriptDom.SimpleCaseExpression);
                case 794: return FromMutable(fragment as ScriptDom.SimpleWhenClause);
                case 795: return FromMutable(fragment as ScriptDom.SingleValueTypeCopyOption);
                case 796: return FromMutable(fragment as ScriptDom.SizeFileDeclarationOption);
                case 797: return FromMutable(fragment as ScriptDom.SoapMethod);
                case 798: return FromMutable(fragment as ScriptDom.SourceDeclaration);
                case 799: return FromMutable(fragment as ScriptDom.SpatialIndexRegularOption);
                case 800: return FromMutable(fragment as ScriptDom.SqlCommandIdentifier);
                case 801: return FromMutable(fragment as ScriptDom.SqlDataTypeReference);
                case 802: return FromMutable(fragment as ScriptDom.StateAuditOption);
                case 803: return FromMutable(fragment as ScriptDom.StatementList);
                case 804: return FromMutable(fragment as ScriptDom.StatementListSnippet);
                case 805: return FromMutable(fragment as ScriptDom.StatisticsOption);
                case 806: return FromMutable(fragment as ScriptDom.StatisticsPartitionRange);
                case 807: return FromMutable(fragment as ScriptDom.StopListFullTextIndexOption);
                case 808: return FromMutable(fragment as ScriptDom.StopRestoreOption);
                case 809: return FromMutable(fragment as ScriptDom.StringLiteral);
                case 810: return FromMutable(fragment as ScriptDom.SubqueryComparisonPredicate);
                case 811: return FromMutable(fragment as ScriptDom.SystemTimePeriodDefinition);
                case 812: return FromMutable(fragment as ScriptDom.SystemVersioningTableOption);
                case 813: return FromMutable(fragment as ScriptDom.TableClusteredIndexType);
                case 814: return FromMutable(fragment as ScriptDom.TableDataCompressionOption);
                case 815: return FromMutable(fragment as ScriptDom.TableDefinition);
                case 816: return FromMutable(fragment as ScriptDom.TableDistributionOption);
                case 817: return FromMutable(fragment as ScriptDom.TableHashDistributionPolicy);
                case 818: return FromMutable(fragment as ScriptDom.TableHint);
                case 819: return FromMutable(fragment as ScriptDom.TableHintsOptimizerHint);
                case 820: return FromMutable(fragment as ScriptDom.TableIndexOption);
                case 821: return FromMutable(fragment as ScriptDom.TableNonClusteredIndexType);
                case 822: return FromMutable(fragment as ScriptDom.TablePartitionOption);
                case 823: return FromMutable(fragment as ScriptDom.TablePartitionOptionSpecifications);
                case 824: return FromMutable(fragment as ScriptDom.TableReplicateDistributionPolicy);
                case 825: return FromMutable(fragment as ScriptDom.TableRoundRobinDistributionPolicy);
                case 826: return FromMutable(fragment as ScriptDom.TableSampleClause);
                case 827: return FromMutable(fragment as ScriptDom.TableValuedFunctionReturnType);
                case 828: return FromMutable(fragment as ScriptDom.TableXmlCompressionOption);
                case 829: return FromMutable(fragment as ScriptDom.TargetDeclaration);
                case 830: return FromMutable(fragment as ScriptDom.TargetRecoveryTimeDatabaseOption);
                case 831: return FromMutable(fragment as ScriptDom.TemporalClause);
                case 832: return FromMutable(fragment as ScriptDom.ThrowStatement);
                case 833: return FromMutable(fragment as ScriptDom.TopRowFilter);
                case 834: return FromMutable(fragment as ScriptDom.TriggerAction);
                case 835: return FromMutable(fragment as ScriptDom.TriggerObject);
                case 836: return FromMutable(fragment as ScriptDom.TriggerOption);
                case 837: return FromMutable(fragment as ScriptDom.TruncateTableStatement);
                case 838: return FromMutable(fragment as ScriptDom.TruncateTargetTableSwitchOption);
                case 839: return FromMutable(fragment as ScriptDom.TryCastCall);
                case 840: return FromMutable(fragment as ScriptDom.TryCatchStatement);
                case 841: return FromMutable(fragment as ScriptDom.TryConvertCall);
                case 842: return FromMutable(fragment as ScriptDom.TryParseCall);
                case 843: return FromMutable(fragment as ScriptDom.TSEqualCall);
                case 844: return FromMutable(fragment as ScriptDom.TSqlBatch);
                case 845: return FromMutable(fragment as ScriptDom.TSqlFragmentSnippet);
                case 846: return FromMutable(fragment as ScriptDom.TSqlScript);
                case 847: return FromMutable(fragment as ScriptDom.TSqlStatementSnippet);
                case 848: return FromMutable(fragment as ScriptDom.UnaryExpression);
                case 849: return FromMutable(fragment as ScriptDom.UniqueConstraintDefinition);
                case 850: return FromMutable(fragment as ScriptDom.UnpivotedTableReference);
                case 851: return FromMutable(fragment as ScriptDom.UnqualifiedJoin);
                case 852: return FromMutable(fragment as ScriptDom.UpdateCall);
                case 853: return FromMutable(fragment as ScriptDom.UpdateForClause);
                case 854: return FromMutable(fragment as ScriptDom.UpdateMergeAction);
                case 855: return FromMutable(fragment as ScriptDom.UpdateSpecification);
                case 856: return FromMutable(fragment as ScriptDom.UpdateStatement);
                case 857: return FromMutable(fragment as ScriptDom.UpdateStatisticsStatement);
                case 858: return FromMutable(fragment as ScriptDom.UpdateTextStatement);
                case 859: return FromMutable(fragment as ScriptDom.UseFederationStatement);
                case 860: return FromMutable(fragment as ScriptDom.UseHintList);
                case 861: return FromMutable(fragment as ScriptDom.UserDataTypeReference);
                case 862: return FromMutable(fragment as ScriptDom.UserDefinedTypeCallTarget);
                case 863: return FromMutable(fragment as ScriptDom.UserDefinedTypePropertyAccess);
                case 864: return FromMutable(fragment as ScriptDom.UserLoginOption);
                case 865: return FromMutable(fragment as ScriptDom.UserRemoteServiceBindingOption);
                case 866: return FromMutable(fragment as ScriptDom.UseStatement);
                case 867: return FromMutable(fragment as ScriptDom.ValuesInsertSource);
                case 868: return FromMutable(fragment as ScriptDom.VariableMethodCallTableReference);
                case 869: return FromMutable(fragment as ScriptDom.VariableReference);
                case 870: return FromMutable(fragment as ScriptDom.VariableTableReference);
                case 871: return FromMutable(fragment as ScriptDom.VariableValuePair);
                case 872: return FromMutable(fragment as ScriptDom.ViewDistributionOption);
                case 873: return FromMutable(fragment as ScriptDom.ViewForAppendOption);
                case 874: return FromMutable(fragment as ScriptDom.ViewHashDistributionPolicy);
                case 875: return FromMutable(fragment as ScriptDom.ViewOption);
                case 876: return FromMutable(fragment as ScriptDom.ViewRoundRobinDistributionPolicy);
                case 877: return FromMutable(fragment as ScriptDom.WaitAtLowPriorityOption);
                case 878: return FromMutable(fragment as ScriptDom.WaitForStatement);
                case 879: return FromMutable(fragment as ScriptDom.WhereClause);
                case 880: return FromMutable(fragment as ScriptDom.WhileStatement);
                case 881: return FromMutable(fragment as ScriptDom.WindowClause);
                case 882: return FromMutable(fragment as ScriptDom.WindowDefinition);
                case 883: return FromMutable(fragment as ScriptDom.WindowDelimiter);
                case 884: return FromMutable(fragment as ScriptDom.WindowFrameClause);
                case 885: return FromMutable(fragment as ScriptDom.WindowsCreateLoginSource);
                case 886: return FromMutable(fragment as ScriptDom.WithCtesAndXmlNamespaces);
                case 887: return FromMutable(fragment as ScriptDom.WithinGroupClause);
                case 888: return FromMutable(fragment as ScriptDom.WitnessDatabaseOption);
                case 889: return FromMutable(fragment as ScriptDom.WlmTimeLiteral);
                case 890: return FromMutable(fragment as ScriptDom.WorkloadGroupImportanceParameter);
                case 891: return FromMutable(fragment as ScriptDom.WorkloadGroupResourceParameter);
                case 892: return FromMutable(fragment as ScriptDom.WriteTextStatement);
                case 893: return FromMutable(fragment as ScriptDom.WsdlPayloadOption);
                case 894: return FromMutable(fragment as ScriptDom.XmlCompressionOption);
                case 895: return FromMutable(fragment as ScriptDom.XmlDataTypeReference);
                case 896: return FromMutable(fragment as ScriptDom.XmlForClause);
                case 897: return FromMutable(fragment as ScriptDom.XmlForClauseOption);
                case 898: return FromMutable(fragment as ScriptDom.XmlNamespaces);
                case 899: return FromMutable(fragment as ScriptDom.XmlNamespacesAliasElement);
                case 900: return FromMutable(fragment as ScriptDom.XmlNamespacesDefaultElement);
                default: throw new NotImplementedException("Type not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library.");
            }
        }
        
        public static AlterCreateEndpointStatementBase FromMutable(ScriptDom.AlterCreateEndpointStatementBase fragment) => (AlterCreateEndpointStatementBase)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AlterCreateServiceStatementBase FromMutable(ScriptDom.AlterCreateServiceStatementBase fragment) => (AlterCreateServiceStatementBase)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AlterDatabaseScopedConfigurationStatement FromMutable(ScriptDom.AlterDatabaseScopedConfigurationStatement fragment) => (AlterDatabaseScopedConfigurationStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AlterDatabaseStatement FromMutable(ScriptDom.AlterDatabaseStatement fragment) => (AlterDatabaseStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AlterFullTextIndexAction FromMutable(ScriptDom.AlterFullTextIndexAction fragment) => (AlterFullTextIndexAction)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AlterLoginStatement FromMutable(ScriptDom.AlterLoginStatement fragment) => (AlterLoginStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AlterRoleAction FromMutable(ScriptDom.AlterRoleAction fragment) => (AlterRoleAction)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AlterTableStatement FromMutable(ScriptDom.AlterTableStatement fragment) => (AlterTableStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ApplicationRoleStatement FromMutable(ScriptDom.ApplicationRoleStatement fragment) => (ApplicationRoleStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AssemblyStatement FromMutable(ScriptDom.AssemblyStatement fragment) => (AssemblyStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AtomicBlockOption FromMutable(ScriptDom.AtomicBlockOption fragment) => (AtomicBlockOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AuditOption FromMutable(ScriptDom.AuditOption fragment) => (AuditOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AuditSpecificationDetail FromMutable(ScriptDom.AuditSpecificationDetail fragment) => (AuditSpecificationDetail)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AuditSpecificationStatement FromMutable(ScriptDom.AuditSpecificationStatement fragment) => (AuditSpecificationStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AuditTargetOption FromMutable(ScriptDom.AuditTargetOption fragment) => (AuditTargetOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AvailabilityGroupOption FromMutable(ScriptDom.AvailabilityGroupOption fragment) => (AvailabilityGroupOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AvailabilityGroupStatement FromMutable(ScriptDom.AvailabilityGroupStatement fragment) => (AvailabilityGroupStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static AvailabilityReplicaOption FromMutable(ScriptDom.AvailabilityReplicaOption fragment) => (AvailabilityReplicaOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static BackupRestoreMasterKeyStatementBase FromMutable(ScriptDom.BackupRestoreMasterKeyStatementBase fragment) => (BackupRestoreMasterKeyStatementBase)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static BackupStatement FromMutable(ScriptDom.BackupStatement fragment) => (BackupStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static BooleanExpression FromMutable(ScriptDom.BooleanExpression fragment) => (BooleanExpression)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static BrokerPriorityStatement FromMutable(ScriptDom.BrokerPriorityStatement fragment) => (BrokerPriorityStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static BulkInsertBase FromMutable(ScriptDom.BulkInsertBase fragment) => (BulkInsertBase)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static CallTarget FromMutable(ScriptDom.CallTarget fragment) => (CallTarget)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static CaseExpression FromMutable(ScriptDom.CaseExpression fragment) => (CaseExpression)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static CertificateStatementBase FromMutable(ScriptDom.CertificateStatementBase fragment) => (CertificateStatementBase)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ChangeTrackingOptionDetail FromMutable(ScriptDom.ChangeTrackingOptionDetail fragment) => (ChangeTrackingOptionDetail)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ColumnEncryptionDefinitionParameter FromMutable(ScriptDom.ColumnEncryptionDefinitionParameter fragment) => (ColumnEncryptionDefinitionParameter)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ColumnEncryptionKeyStatement FromMutable(ScriptDom.ColumnEncryptionKeyStatement fragment) => (ColumnEncryptionKeyStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ColumnEncryptionKeyValueParameter FromMutable(ScriptDom.ColumnEncryptionKeyValueParameter fragment) => (ColumnEncryptionKeyValueParameter)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ColumnMasterKeyParameter FromMutable(ScriptDom.ColumnMasterKeyParameter fragment) => (ColumnMasterKeyParameter)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ConstraintDefinition FromMutable(ScriptDom.ConstraintDefinition fragment) => (ConstraintDefinition)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static CopyStatementOptionBase FromMutable(ScriptDom.CopyStatementOptionBase fragment) => (CopyStatementOptionBase)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static CreateLoginSource FromMutable(ScriptDom.CreateLoginSource fragment) => (CreateLoginSource)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static CreateTypeStatement FromMutable(ScriptDom.CreateTypeStatement fragment) => (CreateTypeStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static CredentialStatement FromMutable(ScriptDom.CredentialStatement fragment) => (CredentialStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static CursorStatement FromMutable(ScriptDom.CursorStatement fragment) => (CursorStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static DatabaseEncryptionKeyStatement FromMutable(ScriptDom.DatabaseEncryptionKeyStatement fragment) => (DatabaseEncryptionKeyStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static DataModificationSpecification FromMutable(ScriptDom.DataModificationSpecification fragment) => (DataModificationSpecification)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static DataModificationStatement FromMutable(ScriptDom.DataModificationStatement fragment) => (DataModificationStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static DataTypeReference FromMutable(ScriptDom.DataTypeReference fragment) => (DataTypeReference)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static DialogOption FromMutable(ScriptDom.DialogOption fragment) => (DialogOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static DropChildObjectsStatement FromMutable(ScriptDom.DropChildObjectsStatement fragment) => (DropChildObjectsStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static DropClusteredConstraintOption FromMutable(ScriptDom.DropClusteredConstraintOption fragment) => (DropClusteredConstraintOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static DropIndexClauseBase FromMutable(ScriptDom.DropIndexClauseBase fragment) => (DropIndexClauseBase)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static DropObjectsStatement FromMutable(ScriptDom.DropObjectsStatement fragment) => (DropObjectsStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static DropUnownedObjectStatement FromMutable(ScriptDom.DropUnownedObjectStatement fragment) => (DropUnownedObjectStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static EncryptionSource FromMutable(ScriptDom.EncryptionSource fragment) => (EncryptionSource)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static EndpointProtocolOption FromMutable(ScriptDom.EndpointProtocolOption fragment) => (EndpointProtocolOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static EventTypeGroupContainer FromMutable(ScriptDom.EventTypeGroupContainer fragment) => (EventTypeGroupContainer)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ExecutableEntity FromMutable(ScriptDom.ExecutableEntity fragment) => (ExecutableEntity)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ExternalDataSourceOption FromMutable(ScriptDom.ExternalDataSourceOption fragment) => (ExternalDataSourceOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ExternalDataSourceStatement FromMutable(ScriptDom.ExternalDataSourceStatement fragment) => (ExternalDataSourceStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ExternalFileFormatOption FromMutable(ScriptDom.ExternalFileFormatOption fragment) => (ExternalFileFormatOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ExternalFileFormatStatement FromMutable(ScriptDom.ExternalFileFormatStatement fragment) => (ExternalFileFormatStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ExternalLanguageStatement FromMutable(ScriptDom.ExternalLanguageStatement fragment) => (ExternalLanguageStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ExternalLibraryStatement FromMutable(ScriptDom.ExternalLibraryStatement fragment) => (ExternalLibraryStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ExternalStreamingJobStatement FromMutable(ScriptDom.ExternalStreamingJobStatement fragment) => (ExternalStreamingJobStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ExternalStreamOption FromMutable(ScriptDom.ExternalStreamOption fragment) => (ExternalStreamOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ExternalStreamStatement FromMutable(ScriptDom.ExternalStreamStatement fragment) => (ExternalStreamStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ExternalTableDistributionPolicy FromMutable(ScriptDom.ExternalTableDistributionPolicy fragment) => (ExternalTableDistributionPolicy)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ExternalTableOption FromMutable(ScriptDom.ExternalTableOption fragment) => (ExternalTableOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ExternalTableStatement FromMutable(ScriptDom.ExternalTableStatement fragment) => (ExternalTableStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ForClause FromMutable(ScriptDom.ForClause fragment) => (ForClause)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static FullTextCatalogOption FromMutable(ScriptDom.FullTextCatalogOption fragment) => (FullTextCatalogOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static FullTextCatalogStatement FromMutable(ScriptDom.FullTextCatalogStatement fragment) => (FullTextCatalogStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static FullTextIndexOption FromMutable(ScriptDom.FullTextIndexOption fragment) => (FullTextIndexOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static FunctionReturnType FromMutable(ScriptDom.FunctionReturnType fragment) => (FunctionReturnType)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static FunctionStatementBody FromMutable(ScriptDom.FunctionStatementBody fragment) => (FunctionStatementBody)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static GroupingSpecification FromMutable(ScriptDom.GroupingSpecification fragment) => (GroupingSpecification)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static IndexOption FromMutable(ScriptDom.IndexOption fragment) => (IndexOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static IndexStatement FromMutable(ScriptDom.IndexStatement fragment) => (IndexStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static InsertSource FromMutable(ScriptDom.InsertSource fragment) => (InsertSource)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static JoinTableReference FromMutable(ScriptDom.JoinTableReference fragment) => (JoinTableReference)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static KeyOption FromMutable(ScriptDom.KeyOption fragment) => (KeyOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static Literal FromMutable(ScriptDom.Literal fragment) => (Literal)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static LowPriorityLockWaitOption FromMutable(ScriptDom.LowPriorityLockWaitOption fragment) => (LowPriorityLockWaitOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static MasterKeyStatement FromMutable(ScriptDom.MasterKeyStatement fragment) => (MasterKeyStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static MergeAction FromMutable(ScriptDom.MergeAction fragment) => (MergeAction)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static MessageTypeStatementBase FromMutable(ScriptDom.MessageTypeStatementBase fragment) => (MessageTypeStatementBase)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static OptionValue FromMutable(ScriptDom.OptionValue fragment) => (OptionValue)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ParameterizedDataTypeReference FromMutable(ScriptDom.ParameterizedDataTypeReference fragment) => (ParameterizedDataTypeReference)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static PartitionSpecifications FromMutable(ScriptDom.PartitionSpecifications fragment) => (PartitionSpecifications)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static PayloadOption FromMutable(ScriptDom.PayloadOption fragment) => (PayloadOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static PrimaryExpression FromMutable(ScriptDom.PrimaryExpression fragment) => (PrimaryExpression)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ProcedureStatementBody FromMutable(ScriptDom.ProcedureStatementBody fragment) => (ProcedureStatementBody)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ProcedureStatementBodyBase FromMutable(ScriptDom.ProcedureStatementBodyBase fragment) => (ProcedureStatementBodyBase)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static QueryExpression FromMutable(ScriptDom.QueryExpression fragment) => (QueryExpression)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static QueryStoreOption FromMutable(ScriptDom.QueryStoreOption fragment) => (QueryStoreOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static QueueStatement FromMutable(ScriptDom.QueueStatement fragment) => (QueueStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static RemoteDataArchiveDatabaseSetting FromMutable(ScriptDom.RemoteDataArchiveDatabaseSetting fragment) => (RemoteDataArchiveDatabaseSetting)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static RemoteServiceBindingOption FromMutable(ScriptDom.RemoteServiceBindingOption fragment) => (RemoteServiceBindingOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static RemoteServiceBindingStatementBase FromMutable(ScriptDom.RemoteServiceBindingStatementBase fragment) => (RemoteServiceBindingStatementBase)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static RoleStatement FromMutable(ScriptDom.RoleStatement fragment) => (RoleStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static RouteStatement FromMutable(ScriptDom.RouteStatement fragment) => (RouteStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ScalarExpression FromMutable(ScriptDom.ScalarExpression fragment) => (ScalarExpression)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SearchPropertyListAction FromMutable(ScriptDom.SearchPropertyListAction fragment) => (SearchPropertyListAction)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SecurityElement80 FromMutable(ScriptDom.SecurityElement80 fragment) => (SecurityElement80)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SecurityPolicyStatement FromMutable(ScriptDom.SecurityPolicyStatement fragment) => (SecurityPolicyStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SecurityStatement FromMutable(ScriptDom.SecurityStatement fragment) => (SecurityStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SecurityStatementBody80 FromMutable(ScriptDom.SecurityStatementBody80 fragment) => (SecurityStatementBody80)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SelectElement FromMutable(ScriptDom.SelectElement fragment) => (SelectElement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SensitivityClassificationStatement FromMutable(ScriptDom.SensitivityClassificationStatement fragment) => (SensitivityClassificationStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SequenceStatement FromMutable(ScriptDom.SequenceStatement fragment) => (SequenceStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ServerAuditStatement FromMutable(ScriptDom.ServerAuditStatement fragment) => (ServerAuditStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SessionOption FromMutable(ScriptDom.SessionOption fragment) => (SessionOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SetClause FromMutable(ScriptDom.SetClause fragment) => (SetClause)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SetCommand FromMutable(ScriptDom.SetCommand fragment) => (SetCommand)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SetOnOffStatement FromMutable(ScriptDom.SetOnOffStatement fragment) => (SetOnOffStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SignatureStatementBase FromMutable(ScriptDom.SignatureStatementBase fragment) => (SignatureStatementBase)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SpatialIndexOption FromMutable(ScriptDom.SpatialIndexOption fragment) => (SpatialIndexOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static StatementWithCtesAndXmlNamespaces FromMutable(ScriptDom.StatementWithCtesAndXmlNamespaces fragment) => (StatementWithCtesAndXmlNamespaces)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static SymmetricKeyStatement FromMutable(ScriptDom.SymmetricKeyStatement fragment) => (SymmetricKeyStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static TableDistributionPolicy FromMutable(ScriptDom.TableDistributionPolicy fragment) => (TableDistributionPolicy)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static TableIndexType FromMutable(ScriptDom.TableIndexType fragment) => (TableIndexType)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static TableOption FromMutable(ScriptDom.TableOption fragment) => (TableOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static TableReference FromMutable(ScriptDom.TableReference fragment) => (TableReference)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static TableReferenceWithAlias FromMutable(ScriptDom.TableReferenceWithAlias fragment) => (TableReferenceWithAlias)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static TableReferenceWithAliasAndColumns FromMutable(ScriptDom.TableReferenceWithAliasAndColumns fragment) => (TableReferenceWithAliasAndColumns)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static TableSwitchOption FromMutable(ScriptDom.TableSwitchOption fragment) => (TableSwitchOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static TextModificationStatement FromMutable(ScriptDom.TextModificationStatement fragment) => (TextModificationStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static TransactionStatement FromMutable(ScriptDom.TransactionStatement fragment) => (TransactionStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static TriggerStatementBody FromMutable(ScriptDom.TriggerStatementBody fragment) => (TriggerStatementBody)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static TSqlStatement FromMutable(ScriptDom.TSqlStatement fragment) => (TSqlStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static UpdateDeleteSpecificationBase FromMutable(ScriptDom.UpdateDeleteSpecificationBase fragment) => (UpdateDeleteSpecificationBase)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static UserStatement FromMutable(ScriptDom.UserStatement fragment) => (UserStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ValueExpression FromMutable(ScriptDom.ValueExpression fragment) => (ValueExpression)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ViewDistributionPolicy FromMutable(ScriptDom.ViewDistributionPolicy fragment) => (ViewDistributionPolicy)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static ViewStatementBody FromMutable(ScriptDom.ViewStatementBody fragment) => (ViewStatementBody)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static WaitForSupportedStatement FromMutable(ScriptDom.WaitForSupportedStatement fragment) => (WaitForSupportedStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static WhenClause FromMutable(ScriptDom.WhenClause fragment) => (WhenClause)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static WorkloadClassifierOption FromMutable(ScriptDom.WorkloadClassifierOption fragment) => (WorkloadClassifierOption)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static WorkloadClassifierStatement FromMutable(ScriptDom.WorkloadClassifierStatement fragment) => (WorkloadClassifierStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static WorkloadGroupParameter FromMutable(ScriptDom.WorkloadGroupParameter fragment) => (WorkloadGroupParameter)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static WorkloadGroupStatement FromMutable(ScriptDom.WorkloadGroupStatement fragment) => (WorkloadGroupStatement)FromMutable(fragment as ScriptDom.TSqlFragment);
        public static XmlNamespacesElement FromMutable(ScriptDom.XmlNamespacesElement fragment) => (XmlNamespacesElement)FromMutable(fragment as ScriptDom.TSqlFragment);
        
        public static AcceleratedDatabaseRecoveryDatabaseOption FromMutable(ScriptDom.AcceleratedDatabaseRecoveryDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AcceleratedDatabaseRecoveryDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of AcceleratedDatabaseRecoveryDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AcceleratedDatabaseRecoveryDatabaseOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static AddAlterFullTextIndexAction FromMutable(ScriptDom.AddAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AddAlterFullTextIndexAction))) { throw new NotImplementedException("Unexpected subtype of AddAlterFullTextIndexAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AddAlterFullTextIndexAction(
                columns: fragment.Columns.SelectList(FromMutable),
                withNoPopulation: fragment.WithNoPopulation
            );
        }
        
        public static AddFileSpec FromMutable(ScriptDom.AddFileSpec fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AddFileSpec))) { throw new NotImplementedException("Unexpected subtype of AddFileSpec not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AddFileSpec(
                file: FromMutable(fragment.File),
                fileName: FromMutable(fragment.FileName)
            );
        }
        
        public static AddMemberAlterRoleAction FromMutable(ScriptDom.AddMemberAlterRoleAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AddMemberAlterRoleAction))) { throw new NotImplementedException("Unexpected subtype of AddMemberAlterRoleAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AddMemberAlterRoleAction(
                member: FromMutable(fragment.Member)
            );
        }
        
        public static AddSearchPropertyListAction FromMutable(ScriptDom.AddSearchPropertyListAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AddSearchPropertyListAction))) { throw new NotImplementedException("Unexpected subtype of AddSearchPropertyListAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AddSearchPropertyListAction(
                propertyName: FromMutable(fragment.PropertyName),
                guid: FromMutable(fragment.Guid),
                id: FromMutable(fragment.Id),
                description: FromMutable(fragment.Description)
            );
        }
        
        public static AddSensitivityClassificationStatement FromMutable(ScriptDom.AddSensitivityClassificationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AddSensitivityClassificationStatement))) { throw new NotImplementedException("Unexpected subtype of AddSensitivityClassificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AddSensitivityClassificationStatement(
                options: fragment.Options.SelectList(FromMutable),
                columns: fragment.Columns.SelectList(FromMutable)
            );
        }
        
        public static AddSignatureStatement FromMutable(ScriptDom.AddSignatureStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AddSignatureStatement))) { throw new NotImplementedException("Unexpected subtype of AddSignatureStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AddSignatureStatement(
                isCounter: fragment.IsCounter,
                elementKind: fragment.ElementKind,
                element: FromMutable(fragment.Element),
                cryptos: fragment.Cryptos.SelectList(FromMutable)
            );
        }
        
        public static AdHocDataSource FromMutable(ScriptDom.AdHocDataSource fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AdHocDataSource))) { throw new NotImplementedException("Unexpected subtype of AdHocDataSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AdHocDataSource(
                providerName: FromMutable(fragment.ProviderName),
                initString: FromMutable(fragment.InitString)
            );
        }
        
        public static AdHocTableReference FromMutable(ScriptDom.AdHocTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AdHocTableReference))) { throw new NotImplementedException("Unexpected subtype of AdHocTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AdHocTableReference(
                dataSource: FromMutable(fragment.DataSource),
                @object: FromMutable(fragment.Object),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static AlgorithmKeyOption FromMutable(ScriptDom.AlgorithmKeyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlgorithmKeyOption))) { throw new NotImplementedException("Unexpected subtype of AlgorithmKeyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlgorithmKeyOption(
                algorithm: fragment.Algorithm,
                optionKind: fragment.OptionKind
            );
        }
        
        public static AlterApplicationRoleStatement FromMutable(ScriptDom.AlterApplicationRoleStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterApplicationRoleStatement))) { throw new NotImplementedException("Unexpected subtype of AlterApplicationRoleStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterApplicationRoleStatement(
                name: FromMutable(fragment.Name),
                applicationRoleOptions: fragment.ApplicationRoleOptions.SelectList(FromMutable)
            );
        }
        
        public static AlterAssemblyStatement FromMutable(ScriptDom.AlterAssemblyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterAssemblyStatement))) { throw new NotImplementedException("Unexpected subtype of AlterAssemblyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterAssemblyStatement(
                dropFiles: fragment.DropFiles.SelectList(FromMutable),
                isDropAll: fragment.IsDropAll,
                addFiles: fragment.AddFiles.SelectList(FromMutable),
                name: FromMutable(fragment.Name),
                parameters: fragment.Parameters.SelectList(FromMutable),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static AlterAsymmetricKeyStatement FromMutable(ScriptDom.AlterAsymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterAsymmetricKeyStatement))) { throw new NotImplementedException("Unexpected subtype of AlterAsymmetricKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterAsymmetricKeyStatement(
                name: FromMutable(fragment.Name),
                attestedBy: FromMutable(fragment.AttestedBy),
                kind: fragment.Kind,
                encryptionPassword: FromMutable(fragment.EncryptionPassword),
                decryptionPassword: FromMutable(fragment.DecryptionPassword)
            );
        }
        
        public static AlterAuthorizationStatement FromMutable(ScriptDom.AlterAuthorizationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterAuthorizationStatement))) { throw new NotImplementedException("Unexpected subtype of AlterAuthorizationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterAuthorizationStatement(
                securityTargetObject: FromMutable(fragment.SecurityTargetObject),
                toSchemaOwner: fragment.ToSchemaOwner,
                principalName: FromMutable(fragment.PrincipalName)
            );
        }
        
        public static AlterAvailabilityGroupAction FromMutable(ScriptDom.AlterAvailabilityGroupAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterAvailabilityGroupAction))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as AlterAvailabilityGroupAction; }
            return new AlterAvailabilityGroupAction(
                actionType: fragment.ActionType
            );
        }
        
        public static AlterAvailabilityGroupFailoverAction FromMutable(ScriptDom.AlterAvailabilityGroupFailoverAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterAvailabilityGroupFailoverAction))) { throw new NotImplementedException("Unexpected subtype of AlterAvailabilityGroupFailoverAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterAvailabilityGroupFailoverAction(
                options: fragment.Options.SelectList(FromMutable),
                actionType: fragment.ActionType
            );
        }
        
        public static AlterAvailabilityGroupFailoverOption FromMutable(ScriptDom.AlterAvailabilityGroupFailoverOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterAvailabilityGroupFailoverOption))) { throw new NotImplementedException("Unexpected subtype of AlterAvailabilityGroupFailoverOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterAvailabilityGroupFailoverOption(
                optionKind: fragment.OptionKind,
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static AlterAvailabilityGroupStatement FromMutable(ScriptDom.AlterAvailabilityGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterAvailabilityGroupStatement))) { throw new NotImplementedException("Unexpected subtype of AlterAvailabilityGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterAvailabilityGroupStatement(
                alterAvailabilityGroupStatementType: fragment.AlterAvailabilityGroupStatementType,
                action: FromMutable(fragment.Action),
                name: FromMutable(fragment.Name),
                options: fragment.Options.SelectList(FromMutable),
                databases: fragment.Databases.SelectList(FromMutable),
                replicas: fragment.Replicas.SelectList(FromMutable)
            );
        }
        
        public static AlterBrokerPriorityStatement FromMutable(ScriptDom.AlterBrokerPriorityStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterBrokerPriorityStatement))) { throw new NotImplementedException("Unexpected subtype of AlterBrokerPriorityStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterBrokerPriorityStatement(
                name: FromMutable(fragment.Name),
                brokerPriorityParameters: fragment.BrokerPriorityParameters.SelectList(FromMutable)
            );
        }
        
        public static AlterCertificateStatement FromMutable(ScriptDom.AlterCertificateStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterCertificateStatement))) { throw new NotImplementedException("Unexpected subtype of AlterCertificateStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterCertificateStatement(
                kind: fragment.Kind,
                attestedBy: FromMutable(fragment.AttestedBy),
                name: FromMutable(fragment.Name),
                activeForBeginDialog: fragment.ActiveForBeginDialog,
                privateKeyPath: FromMutable(fragment.PrivateKeyPath),
                encryptionPassword: FromMutable(fragment.EncryptionPassword),
                decryptionPassword: FromMutable(fragment.DecryptionPassword)
            );
        }
        
        public static AlterColumnAlterFullTextIndexAction FromMutable(ScriptDom.AlterColumnAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterColumnAlterFullTextIndexAction))) { throw new NotImplementedException("Unexpected subtype of AlterColumnAlterFullTextIndexAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterColumnAlterFullTextIndexAction(
                column: FromMutable(fragment.Column),
                withNoPopulation: fragment.WithNoPopulation
            );
        }
        
        public static AlterColumnEncryptionKeyStatement FromMutable(ScriptDom.AlterColumnEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterColumnEncryptionKeyStatement))) { throw new NotImplementedException("Unexpected subtype of AlterColumnEncryptionKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterColumnEncryptionKeyStatement(
                alterType: fragment.AlterType,
                name: FromMutable(fragment.Name),
                columnEncryptionKeyValues: fragment.ColumnEncryptionKeyValues.SelectList(FromMutable)
            );
        }
        
        public static AlterCredentialStatement FromMutable(ScriptDom.AlterCredentialStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterCredentialStatement))) { throw new NotImplementedException("Unexpected subtype of AlterCredentialStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterCredentialStatement(
                name: FromMutable(fragment.Name),
                identity: FromMutable(fragment.Identity),
                secret: FromMutable(fragment.Secret),
                isDatabaseScoped: fragment.IsDatabaseScoped
            );
        }
        
        public static AlterCryptographicProviderStatement FromMutable(ScriptDom.AlterCryptographicProviderStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterCryptographicProviderStatement))) { throw new NotImplementedException("Unexpected subtype of AlterCryptographicProviderStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterCryptographicProviderStatement(
                name: FromMutable(fragment.Name),
                option: fragment.Option,
                file: FromMutable(fragment.File)
            );
        }
        
        public static AlterDatabaseAddFileGroupStatement FromMutable(ScriptDom.AlterDatabaseAddFileGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseAddFileGroupStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseAddFileGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseAddFileGroupStatement(
                fileGroup: FromMutable(fragment.FileGroup),
                containsFileStream: fragment.ContainsFileStream,
                containsMemoryOptimizedData: fragment.ContainsMemoryOptimizedData,
                databaseName: FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseAddFileStatement FromMutable(ScriptDom.AlterDatabaseAddFileStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseAddFileStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseAddFileStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseAddFileStatement(
                fileDeclarations: fragment.FileDeclarations.SelectList(FromMutable),
                fileGroup: FromMutable(fragment.FileGroup),
                isLog: fragment.IsLog,
                databaseName: FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseAuditSpecificationStatement FromMutable(ScriptDom.AlterDatabaseAuditSpecificationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseAuditSpecificationStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseAuditSpecificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseAuditSpecificationStatement(
                auditState: fragment.AuditState,
                parts: fragment.Parts.SelectList(FromMutable),
                specificationName: FromMutable(fragment.SpecificationName),
                auditName: FromMutable(fragment.AuditName)
            );
        }
        
        public static AlterDatabaseCollateStatement FromMutable(ScriptDom.AlterDatabaseCollateStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseCollateStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseCollateStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseCollateStatement(
                collation: FromMutable(fragment.Collation),
                databaseName: FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseEncryptionKeyStatement FromMutable(ScriptDom.AlterDatabaseEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseEncryptionKeyStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseEncryptionKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseEncryptionKeyStatement(
                regenerate: fragment.Regenerate,
                encryptor: FromMutable(fragment.Encryptor),
                algorithm: fragment.Algorithm
            );
        }
        
        public static AlterDatabaseModifyFileGroupStatement FromMutable(ScriptDom.AlterDatabaseModifyFileGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseModifyFileGroupStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseModifyFileGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseModifyFileGroupStatement(
                fileGroup: FromMutable(fragment.FileGroup),
                newFileGroupName: FromMutable(fragment.NewFileGroupName),
                makeDefault: fragment.MakeDefault,
                updatabilityOption: fragment.UpdatabilityOption,
                termination: FromMutable(fragment.Termination),
                databaseName: FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseModifyFileStatement FromMutable(ScriptDom.AlterDatabaseModifyFileStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseModifyFileStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseModifyFileStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseModifyFileStatement(
                fileDeclaration: FromMutable(fragment.FileDeclaration),
                databaseName: FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseModifyNameStatement FromMutable(ScriptDom.AlterDatabaseModifyNameStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseModifyNameStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseModifyNameStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseModifyNameStatement(
                newDatabaseName: FromMutable(fragment.NewDatabaseName),
                databaseName: FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseRebuildLogStatement FromMutable(ScriptDom.AlterDatabaseRebuildLogStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseRebuildLogStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseRebuildLogStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseRebuildLogStatement(
                fileDeclaration: FromMutable(fragment.FileDeclaration),
                databaseName: FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseRemoveFileGroupStatement FromMutable(ScriptDom.AlterDatabaseRemoveFileGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseRemoveFileGroupStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseRemoveFileGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseRemoveFileGroupStatement(
                fileGroup: FromMutable(fragment.FileGroup),
                databaseName: FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseRemoveFileStatement FromMutable(ScriptDom.AlterDatabaseRemoveFileStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseRemoveFileStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseRemoveFileStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseRemoveFileStatement(
                file: FromMutable(fragment.File),
                databaseName: FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseScopedConfigurationClearStatement FromMutable(ScriptDom.AlterDatabaseScopedConfigurationClearStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseScopedConfigurationClearStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseScopedConfigurationClearStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseScopedConfigurationClearStatement(
                option: FromMutable(fragment.Option),
                secondary: fragment.Secondary
            );
        }
        
        public static AlterDatabaseScopedConfigurationSetStatement FromMutable(ScriptDom.AlterDatabaseScopedConfigurationSetStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseScopedConfigurationSetStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseScopedConfigurationSetStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseScopedConfigurationSetStatement(
                option: FromMutable(fragment.Option),
                secondary: fragment.Secondary
            );
        }
        
        public static AlterDatabaseSetStatement FromMutable(ScriptDom.AlterDatabaseSetStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseSetStatement))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseSetStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseSetStatement(
                termination: FromMutable(fragment.Termination),
                options: fragment.Options.SelectList(FromMutable),
                databaseName: FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseTermination FromMutable(ScriptDom.AlterDatabaseTermination fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterDatabaseTermination))) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseTermination not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseTermination(
                immediateRollback: fragment.ImmediateRollback,
                rollbackAfter: FromMutable(fragment.RollbackAfter),
                noWait: fragment.NoWait
            );
        }
        
        public static AlterEndpointStatement FromMutable(ScriptDom.AlterEndpointStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterEndpointStatement))) { throw new NotImplementedException("Unexpected subtype of AlterEndpointStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterEndpointStatement(
                name: FromMutable(fragment.Name),
                state: fragment.State,
                affinity: FromMutable(fragment.Affinity),
                protocol: fragment.Protocol,
                protocolOptions: fragment.ProtocolOptions.SelectList(FromMutable),
                endpointType: fragment.EndpointType,
                payloadOptions: fragment.PayloadOptions.SelectList(FromMutable)
            );
        }
        
        public static AlterEventSessionStatement FromMutable(ScriptDom.AlterEventSessionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterEventSessionStatement))) { throw new NotImplementedException("Unexpected subtype of AlterEventSessionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterEventSessionStatement(
                statementType: fragment.StatementType,
                dropEventDeclarations: fragment.DropEventDeclarations.SelectList(FromMutable),
                dropTargetDeclarations: fragment.DropTargetDeclarations.SelectList(FromMutable),
                name: FromMutable(fragment.Name),
                sessionScope: fragment.SessionScope,
                eventDeclarations: fragment.EventDeclarations.SelectList(FromMutable),
                targetDeclarations: fragment.TargetDeclarations.SelectList(FromMutable),
                sessionOptions: fragment.SessionOptions.SelectList(FromMutable)
            );
        }
        
        public static AlterExternalDataSourceStatement FromMutable(ScriptDom.AlterExternalDataSourceStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterExternalDataSourceStatement))) { throw new NotImplementedException("Unexpected subtype of AlterExternalDataSourceStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterExternalDataSourceStatement(
                previousPushDownOption: fragment.PreviousPushDownOption,
                name: FromMutable(fragment.Name),
                dataSourceType: fragment.DataSourceType,
                location: FromMutable(fragment.Location),
                pushdownOption: fragment.PushdownOption,
                externalDataSourceOptions: fragment.ExternalDataSourceOptions.SelectList(FromMutable)
            );
        }
        
        public static AlterExternalLanguageStatement FromMutable(ScriptDom.AlterExternalLanguageStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterExternalLanguageStatement))) { throw new NotImplementedException("Unexpected subtype of AlterExternalLanguageStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterExternalLanguageStatement(
                platform: FromMutable(fragment.Platform),
                operation: FromMutable(fragment.Operation),
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name),
                externalLanguageFiles: fragment.ExternalLanguageFiles.SelectList(FromMutable)
            );
        }
        
        public static AlterExternalLibraryStatement FromMutable(ScriptDom.AlterExternalLibraryStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterExternalLibraryStatement))) { throw new NotImplementedException("Unexpected subtype of AlterExternalLibraryStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterExternalLibraryStatement(
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name),
                language: FromMutable(fragment.Language),
                externalLibraryFiles: fragment.ExternalLibraryFiles.SelectList(FromMutable)
            );
        }
        
        public static AlterExternalResourcePoolStatement FromMutable(ScriptDom.AlterExternalResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterExternalResourcePoolStatement))) { throw new NotImplementedException("Unexpected subtype of AlterExternalResourcePoolStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterExternalResourcePoolStatement(
                name: FromMutable(fragment.Name),
                externalResourcePoolParameters: fragment.ExternalResourcePoolParameters.SelectList(FromMutable)
            );
        }
        
        public static AlterFederationStatement FromMutable(ScriptDom.AlterFederationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterFederationStatement))) { throw new NotImplementedException("Unexpected subtype of AlterFederationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterFederationStatement(
                name: FromMutable(fragment.Name),
                kind: fragment.Kind,
                distributionName: FromMutable(fragment.DistributionName),
                boundary: FromMutable(fragment.Boundary)
            );
        }
        
        public static AlterFullTextCatalogStatement FromMutable(ScriptDom.AlterFullTextCatalogStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterFullTextCatalogStatement))) { throw new NotImplementedException("Unexpected subtype of AlterFullTextCatalogStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterFullTextCatalogStatement(
                action: fragment.Action,
                name: FromMutable(fragment.Name),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static AlterFullTextIndexStatement FromMutable(ScriptDom.AlterFullTextIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterFullTextIndexStatement))) { throw new NotImplementedException("Unexpected subtype of AlterFullTextIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterFullTextIndexStatement(
                onName: FromMutable(fragment.OnName),
                action: FromMutable(fragment.Action)
            );
        }
        
        public static AlterFullTextStopListStatement FromMutable(ScriptDom.AlterFullTextStopListStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterFullTextStopListStatement))) { throw new NotImplementedException("Unexpected subtype of AlterFullTextStopListStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterFullTextStopListStatement(
                name: FromMutable(fragment.Name),
                action: FromMutable(fragment.Action)
            );
        }
        
        public static AlterFunctionStatement FromMutable(ScriptDom.AlterFunctionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterFunctionStatement))) { throw new NotImplementedException("Unexpected subtype of AlterFunctionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterFunctionStatement(
                name: FromMutable(fragment.Name),
                returnType: FromMutable(fragment.ReturnType),
                options: fragment.Options.SelectList(FromMutable),
                orderHint: FromMutable(fragment.OrderHint),
                parameters: fragment.Parameters.SelectList(FromMutable),
                statementList: FromMutable(fragment.StatementList),
                methodSpecifier: FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static AlterIndexStatement FromMutable(ScriptDom.AlterIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterIndexStatement))) { throw new NotImplementedException("Unexpected subtype of AlterIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterIndexStatement(
                all: fragment.All,
                alterIndexType: fragment.AlterIndexType,
                partition: FromMutable(fragment.Partition),
                promotedPaths: fragment.PromotedPaths.SelectList(FromMutable),
                xmlNamespaces: FromMutable(fragment.XmlNamespaces),
                name: FromMutable(fragment.Name),
                onName: FromMutable(fragment.OnName),
                indexOptions: fragment.IndexOptions.SelectList(FromMutable)
            );
        }
        
        public static AlterLoginAddDropCredentialStatement FromMutable(ScriptDom.AlterLoginAddDropCredentialStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterLoginAddDropCredentialStatement))) { throw new NotImplementedException("Unexpected subtype of AlterLoginAddDropCredentialStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterLoginAddDropCredentialStatement(
                isAdd: fragment.IsAdd,
                credentialName: FromMutable(fragment.CredentialName),
                name: FromMutable(fragment.Name)
            );
        }
        
        public static AlterLoginEnableDisableStatement FromMutable(ScriptDom.AlterLoginEnableDisableStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterLoginEnableDisableStatement))) { throw new NotImplementedException("Unexpected subtype of AlterLoginEnableDisableStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterLoginEnableDisableStatement(
                isEnable: fragment.IsEnable,
                name: FromMutable(fragment.Name)
            );
        }
        
        public static AlterLoginOptionsStatement FromMutable(ScriptDom.AlterLoginOptionsStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterLoginOptionsStatement))) { throw new NotImplementedException("Unexpected subtype of AlterLoginOptionsStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterLoginOptionsStatement(
                options: fragment.Options.SelectList(FromMutable),
                name: FromMutable(fragment.Name)
            );
        }
        
        public static AlterMasterKeyStatement FromMutable(ScriptDom.AlterMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterMasterKeyStatement))) { throw new NotImplementedException("Unexpected subtype of AlterMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterMasterKeyStatement(
                option: fragment.Option,
                password: FromMutable(fragment.Password)
            );
        }
        
        public static AlterMessageTypeStatement FromMutable(ScriptDom.AlterMessageTypeStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterMessageTypeStatement))) { throw new NotImplementedException("Unexpected subtype of AlterMessageTypeStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterMessageTypeStatement(
                name: FromMutable(fragment.Name),
                validationMethod: fragment.ValidationMethod,
                xmlSchemaCollectionName: FromMutable(fragment.XmlSchemaCollectionName)
            );
        }
        
        public static AlterPartitionFunctionStatement FromMutable(ScriptDom.AlterPartitionFunctionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterPartitionFunctionStatement))) { throw new NotImplementedException("Unexpected subtype of AlterPartitionFunctionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterPartitionFunctionStatement(
                name: FromMutable(fragment.Name),
                isSplit: fragment.IsSplit,
                boundary: FromMutable(fragment.Boundary)
            );
        }
        
        public static AlterPartitionSchemeStatement FromMutable(ScriptDom.AlterPartitionSchemeStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterPartitionSchemeStatement))) { throw new NotImplementedException("Unexpected subtype of AlterPartitionSchemeStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterPartitionSchemeStatement(
                name: FromMutable(fragment.Name),
                fileGroup: FromMutable(fragment.FileGroup)
            );
        }
        
        public static AlterProcedureStatement FromMutable(ScriptDom.AlterProcedureStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterProcedureStatement))) { throw new NotImplementedException("Unexpected subtype of AlterProcedureStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterProcedureStatement(
                procedureReference: FromMutable(fragment.ProcedureReference),
                isForReplication: fragment.IsForReplication,
                options: fragment.Options.SelectList(FromMutable),
                parameters: fragment.Parameters.SelectList(FromMutable),
                statementList: FromMutable(fragment.StatementList),
                methodSpecifier: FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static AlterQueueStatement FromMutable(ScriptDom.AlterQueueStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterQueueStatement))) { throw new NotImplementedException("Unexpected subtype of AlterQueueStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterQueueStatement(
                name: FromMutable(fragment.Name),
                queueOptions: fragment.QueueOptions.SelectList(FromMutable)
            );
        }
        
        public static AlterRemoteServiceBindingStatement FromMutable(ScriptDom.AlterRemoteServiceBindingStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterRemoteServiceBindingStatement))) { throw new NotImplementedException("Unexpected subtype of AlterRemoteServiceBindingStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterRemoteServiceBindingStatement(
                name: FromMutable(fragment.Name),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static AlterResourceGovernorStatement FromMutable(ScriptDom.AlterResourceGovernorStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterResourceGovernorStatement))) { throw new NotImplementedException("Unexpected subtype of AlterResourceGovernorStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterResourceGovernorStatement(
                command: fragment.Command,
                classifierFunction: FromMutable(fragment.ClassifierFunction)
            );
        }
        
        public static AlterResourcePoolStatement FromMutable(ScriptDom.AlterResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterResourcePoolStatement))) { throw new NotImplementedException("Unexpected subtype of AlterResourcePoolStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterResourcePoolStatement(
                name: FromMutable(fragment.Name),
                resourcePoolParameters: fragment.ResourcePoolParameters.SelectList(FromMutable)
            );
        }
        
        public static AlterRoleStatement FromMutable(ScriptDom.AlterRoleStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterRoleStatement))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as AlterRoleStatement; }
            return new AlterRoleStatement(
                action: FromMutable(fragment.Action),
                name: FromMutable(fragment.Name)
            );
        }
        
        public static AlterRouteStatement FromMutable(ScriptDom.AlterRouteStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterRouteStatement))) { throw new NotImplementedException("Unexpected subtype of AlterRouteStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterRouteStatement(
                name: FromMutable(fragment.Name),
                routeOptions: fragment.RouteOptions.SelectList(FromMutable)
            );
        }
        
        public static AlterSchemaStatement FromMutable(ScriptDom.AlterSchemaStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterSchemaStatement))) { throw new NotImplementedException("Unexpected subtype of AlterSchemaStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterSchemaStatement(
                name: FromMutable(fragment.Name),
                objectName: FromMutable(fragment.ObjectName),
                objectKind: fragment.ObjectKind
            );
        }
        
        public static AlterSearchPropertyListStatement FromMutable(ScriptDom.AlterSearchPropertyListStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterSearchPropertyListStatement))) { throw new NotImplementedException("Unexpected subtype of AlterSearchPropertyListStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterSearchPropertyListStatement(
                name: FromMutable(fragment.Name),
                action: FromMutable(fragment.Action)
            );
        }
        
        public static AlterSecurityPolicyStatement FromMutable(ScriptDom.AlterSecurityPolicyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterSecurityPolicyStatement))) { throw new NotImplementedException("Unexpected subtype of AlterSecurityPolicyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterSecurityPolicyStatement(
                name: FromMutable(fragment.Name),
                notForReplication: fragment.NotForReplication,
                securityPolicyOptions: fragment.SecurityPolicyOptions.SelectList(FromMutable),
                securityPredicateActions: fragment.SecurityPredicateActions.SelectList(FromMutable),
                actionType: fragment.ActionType
            );
        }
        
        public static AlterSequenceStatement FromMutable(ScriptDom.AlterSequenceStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterSequenceStatement))) { throw new NotImplementedException("Unexpected subtype of AlterSequenceStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterSequenceStatement(
                name: FromMutable(fragment.Name),
                sequenceOptions: fragment.SequenceOptions.SelectList(FromMutable)
            );
        }
        
        public static AlterServerAuditSpecificationStatement FromMutable(ScriptDom.AlterServerAuditSpecificationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerAuditSpecificationStatement))) { throw new NotImplementedException("Unexpected subtype of AlterServerAuditSpecificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerAuditSpecificationStatement(
                auditState: fragment.AuditState,
                parts: fragment.Parts.SelectList(FromMutable),
                specificationName: FromMutable(fragment.SpecificationName),
                auditName: FromMutable(fragment.AuditName)
            );
        }
        
        public static AlterServerAuditStatement FromMutable(ScriptDom.AlterServerAuditStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerAuditStatement))) { throw new NotImplementedException("Unexpected subtype of AlterServerAuditStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerAuditStatement(
                newName: FromMutable(fragment.NewName),
                removeWhere: fragment.RemoveWhere,
                auditName: FromMutable(fragment.AuditName),
                auditTarget: FromMutable(fragment.AuditTarget),
                options: fragment.Options.SelectList(FromMutable),
                predicateExpression: FromMutable(fragment.PredicateExpression)
            );
        }
        
        public static AlterServerConfigurationBufferPoolExtensionContainerOption FromMutable(ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationBufferPoolExtensionContainerOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationBufferPoolExtensionContainerOption(
                suboptions: fragment.Suboptions.SelectList(FromMutable),
                optionKind: fragment.OptionKind,
                optionValue: FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationBufferPoolExtensionOption FromMutable(ScriptDom.AlterServerConfigurationBufferPoolExtensionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationBufferPoolExtensionOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as AlterServerConfigurationBufferPoolExtensionOption; }
            return new AlterServerConfigurationBufferPoolExtensionOption(
                optionKind: fragment.OptionKind,
                optionValue: FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationBufferPoolExtensionSizeOption FromMutable(ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationBufferPoolExtensionSizeOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationBufferPoolExtensionSizeOption(
                sizeUnit: fragment.SizeUnit,
                optionKind: fragment.OptionKind,
                optionValue: FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationDiagnosticsLogMaxSizeOption FromMutable(ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationDiagnosticsLogMaxSizeOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationDiagnosticsLogMaxSizeOption(
                sizeUnit: fragment.SizeUnit,
                optionKind: fragment.OptionKind,
                optionValue: FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationDiagnosticsLogOption FromMutable(ScriptDom.AlterServerConfigurationDiagnosticsLogOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationDiagnosticsLogOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as AlterServerConfigurationDiagnosticsLogOption; }
            return new AlterServerConfigurationDiagnosticsLogOption(
                optionKind: fragment.OptionKind,
                optionValue: FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationExternalAuthenticationContainerOption FromMutable(ScriptDom.AlterServerConfigurationExternalAuthenticationContainerOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationExternalAuthenticationContainerOption))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationExternalAuthenticationContainerOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationExternalAuthenticationContainerOption(
                suboptions: fragment.Suboptions.SelectList(FromMutable),
                optionKind: fragment.OptionKind,
                optionValue: FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationExternalAuthenticationOption FromMutable(ScriptDom.AlterServerConfigurationExternalAuthenticationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationExternalAuthenticationOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as AlterServerConfigurationExternalAuthenticationOption; }
            return new AlterServerConfigurationExternalAuthenticationOption(
                optionKind: fragment.OptionKind,
                optionValue: FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationFailoverClusterPropertyOption FromMutable(ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationFailoverClusterPropertyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationFailoverClusterPropertyOption(
                optionKind: fragment.OptionKind,
                optionValue: FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationHadrClusterOption FromMutable(ScriptDom.AlterServerConfigurationHadrClusterOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationHadrClusterOption))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationHadrClusterOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationHadrClusterOption(
                optionKind: fragment.OptionKind,
                optionValue: FromMutable(fragment.OptionValue),
                isLocal: fragment.IsLocal
            );
        }
        
        public static AlterServerConfigurationSetBufferPoolExtensionStatement FromMutable(ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationSetBufferPoolExtensionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationSetBufferPoolExtensionStatement(
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static AlterServerConfigurationSetDiagnosticsLogStatement FromMutable(ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationSetDiagnosticsLogStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationSetDiagnosticsLogStatement(
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static AlterServerConfigurationSetExternalAuthenticationStatement FromMutable(ScriptDom.AlterServerConfigurationSetExternalAuthenticationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationSetExternalAuthenticationStatement))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationSetExternalAuthenticationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationSetExternalAuthenticationStatement(
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static AlterServerConfigurationSetFailoverClusterPropertyStatement FromMutable(ScriptDom.AlterServerConfigurationSetFailoverClusterPropertyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationSetFailoverClusterPropertyStatement))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationSetFailoverClusterPropertyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationSetFailoverClusterPropertyStatement(
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static AlterServerConfigurationSetHadrClusterStatement FromMutable(ScriptDom.AlterServerConfigurationSetHadrClusterStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationSetHadrClusterStatement))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationSetHadrClusterStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationSetHadrClusterStatement(
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static AlterServerConfigurationSetSoftNumaStatement FromMutable(ScriptDom.AlterServerConfigurationSetSoftNumaStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationSetSoftNumaStatement))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationSetSoftNumaStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationSetSoftNumaStatement(
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static AlterServerConfigurationSoftNumaOption FromMutable(ScriptDom.AlterServerConfigurationSoftNumaOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationSoftNumaOption))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationSoftNumaOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationSoftNumaOption(
                optionKind: fragment.OptionKind,
                optionValue: FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationStatement FromMutable(ScriptDom.AlterServerConfigurationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerConfigurationStatement))) { throw new NotImplementedException("Unexpected subtype of AlterServerConfigurationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerConfigurationStatement(
                processAffinity: fragment.ProcessAffinity,
                processAffinityRanges: fragment.ProcessAffinityRanges.SelectList(FromMutable)
            );
        }
        
        public static AlterServerRoleStatement FromMutable(ScriptDom.AlterServerRoleStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServerRoleStatement))) { throw new NotImplementedException("Unexpected subtype of AlterServerRoleStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServerRoleStatement(
                action: FromMutable(fragment.Action),
                name: FromMutable(fragment.Name)
            );
        }
        
        public static AlterServiceMasterKeyStatement FromMutable(ScriptDom.AlterServiceMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServiceMasterKeyStatement))) { throw new NotImplementedException("Unexpected subtype of AlterServiceMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServiceMasterKeyStatement(
                account: FromMutable(fragment.Account),
                password: FromMutable(fragment.Password),
                kind: fragment.Kind
            );
        }
        
        public static AlterServiceStatement FromMutable(ScriptDom.AlterServiceStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterServiceStatement))) { throw new NotImplementedException("Unexpected subtype of AlterServiceStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterServiceStatement(
                name: FromMutable(fragment.Name),
                queueName: FromMutable(fragment.QueueName),
                serviceContracts: fragment.ServiceContracts.SelectList(FromMutable)
            );
        }
        
        public static AlterSymmetricKeyStatement FromMutable(ScriptDom.AlterSymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterSymmetricKeyStatement))) { throw new NotImplementedException("Unexpected subtype of AlterSymmetricKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterSymmetricKeyStatement(
                isAdd: fragment.IsAdd,
                name: FromMutable(fragment.Name),
                encryptingMechanisms: fragment.EncryptingMechanisms.SelectList(FromMutable)
            );
        }
        
        public static AlterTableAddTableElementStatement FromMutable(ScriptDom.AlterTableAddTableElementStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTableAddTableElementStatement))) { throw new NotImplementedException("Unexpected subtype of AlterTableAddTableElementStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableAddTableElementStatement(
                existingRowsCheckEnforcement: fragment.ExistingRowsCheckEnforcement,
                definition: FromMutable(fragment.Definition),
                schemaObjectName: FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableAlterColumnStatement FromMutable(ScriptDom.AlterTableAlterColumnStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTableAlterColumnStatement))) { throw new NotImplementedException("Unexpected subtype of AlterTableAlterColumnStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableAlterColumnStatement(
                columnIdentifier: FromMutable(fragment.ColumnIdentifier),
                dataType: FromMutable(fragment.DataType),
                alterTableAlterColumnOption: fragment.AlterTableAlterColumnOption,
                storageOptions: FromMutable(fragment.StorageOptions),
                options: fragment.Options.SelectList(FromMutable),
                generatedAlways: fragment.GeneratedAlways,
                isHidden: fragment.IsHidden,
                encryption: FromMutable(fragment.Encryption),
                collation: FromMutable(fragment.Collation),
                isMasked: fragment.IsMasked,
                maskingFunction: FromMutable(fragment.MaskingFunction),
                schemaObjectName: FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableAlterIndexStatement FromMutable(ScriptDom.AlterTableAlterIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTableAlterIndexStatement))) { throw new NotImplementedException("Unexpected subtype of AlterTableAlterIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableAlterIndexStatement(
                indexIdentifier: FromMutable(fragment.IndexIdentifier),
                alterIndexType: fragment.AlterIndexType,
                indexOptions: fragment.IndexOptions.SelectList(FromMutable),
                schemaObjectName: FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableAlterPartitionStatement FromMutable(ScriptDom.AlterTableAlterPartitionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTableAlterPartitionStatement))) { throw new NotImplementedException("Unexpected subtype of AlterTableAlterPartitionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableAlterPartitionStatement(
                boundaryValue: FromMutable(fragment.BoundaryValue),
                isSplit: fragment.IsSplit,
                schemaObjectName: FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableChangeTrackingModificationStatement FromMutable(ScriptDom.AlterTableChangeTrackingModificationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTableChangeTrackingModificationStatement))) { throw new NotImplementedException("Unexpected subtype of AlterTableChangeTrackingModificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableChangeTrackingModificationStatement(
                isEnable: fragment.IsEnable,
                trackColumnsUpdated: fragment.TrackColumnsUpdated,
                schemaObjectName: FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableConstraintModificationStatement FromMutable(ScriptDom.AlterTableConstraintModificationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTableConstraintModificationStatement))) { throw new NotImplementedException("Unexpected subtype of AlterTableConstraintModificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableConstraintModificationStatement(
                existingRowsCheckEnforcement: fragment.ExistingRowsCheckEnforcement,
                constraintEnforcement: fragment.ConstraintEnforcement,
                all: fragment.All,
                constraintNames: fragment.ConstraintNames.SelectList(FromMutable),
                schemaObjectName: FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableDropTableElement FromMutable(ScriptDom.AlterTableDropTableElement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTableDropTableElement))) { throw new NotImplementedException("Unexpected subtype of AlterTableDropTableElement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableDropTableElement(
                tableElementType: fragment.TableElementType,
                name: FromMutable(fragment.Name),
                dropClusteredConstraintOptions: fragment.DropClusteredConstraintOptions.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static AlterTableDropTableElementStatement FromMutable(ScriptDom.AlterTableDropTableElementStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTableDropTableElementStatement))) { throw new NotImplementedException("Unexpected subtype of AlterTableDropTableElementStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableDropTableElementStatement(
                alterTableDropTableElements: fragment.AlterTableDropTableElements.SelectList(FromMutable),
                schemaObjectName: FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableFileTableNamespaceStatement FromMutable(ScriptDom.AlterTableFileTableNamespaceStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTableFileTableNamespaceStatement))) { throw new NotImplementedException("Unexpected subtype of AlterTableFileTableNamespaceStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableFileTableNamespaceStatement(
                isEnable: fragment.IsEnable,
                schemaObjectName: FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableRebuildStatement FromMutable(ScriptDom.AlterTableRebuildStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTableRebuildStatement))) { throw new NotImplementedException("Unexpected subtype of AlterTableRebuildStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableRebuildStatement(
                partition: FromMutable(fragment.Partition),
                indexOptions: fragment.IndexOptions.SelectList(FromMutable),
                schemaObjectName: FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableSetStatement FromMutable(ScriptDom.AlterTableSetStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTableSetStatement))) { throw new NotImplementedException("Unexpected subtype of AlterTableSetStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableSetStatement(
                options: fragment.Options.SelectList(FromMutable),
                schemaObjectName: FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableSwitchStatement FromMutable(ScriptDom.AlterTableSwitchStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTableSwitchStatement))) { throw new NotImplementedException("Unexpected subtype of AlterTableSwitchStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableSwitchStatement(
                sourcePartitionNumber: FromMutable(fragment.SourcePartitionNumber),
                targetPartitionNumber: FromMutable(fragment.TargetPartitionNumber),
                targetTable: FromMutable(fragment.TargetTable),
                options: fragment.Options.SelectList(FromMutable),
                schemaObjectName: FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableTriggerModificationStatement FromMutable(ScriptDom.AlterTableTriggerModificationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTableTriggerModificationStatement))) { throw new NotImplementedException("Unexpected subtype of AlterTableTriggerModificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTableTriggerModificationStatement(
                triggerEnforcement: fragment.TriggerEnforcement,
                all: fragment.All,
                triggerNames: fragment.TriggerNames.SelectList(FromMutable),
                schemaObjectName: FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTriggerStatement FromMutable(ScriptDom.AlterTriggerStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterTriggerStatement))) { throw new NotImplementedException("Unexpected subtype of AlterTriggerStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterTriggerStatement(
                name: FromMutable(fragment.Name),
                triggerObject: FromMutable(fragment.TriggerObject),
                options: fragment.Options.SelectList(FromMutable),
                triggerType: fragment.TriggerType,
                triggerActions: fragment.TriggerActions.SelectList(FromMutable),
                withAppend: fragment.WithAppend,
                isNotForReplication: fragment.IsNotForReplication,
                statementList: FromMutable(fragment.StatementList),
                methodSpecifier: FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static AlterUserStatement FromMutable(ScriptDom.AlterUserStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterUserStatement))) { throw new NotImplementedException("Unexpected subtype of AlterUserStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterUserStatement(
                name: FromMutable(fragment.Name),
                userOptions: fragment.UserOptions.SelectList(FromMutable)
            );
        }
        
        public static AlterViewStatement FromMutable(ScriptDom.AlterViewStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterViewStatement))) { throw new NotImplementedException("Unexpected subtype of AlterViewStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterViewStatement(
                isRebuild: fragment.IsRebuild,
                isDisable: fragment.IsDisable,
                schemaObjectName: FromMutable(fragment.SchemaObjectName),
                columns: fragment.Columns.SelectList(FromMutable),
                viewOptions: fragment.ViewOptions.SelectList(FromMutable),
                selectStatement: FromMutable(fragment.SelectStatement),
                withCheckOption: fragment.WithCheckOption,
                isMaterialized: fragment.IsMaterialized
            );
        }
        
        public static AlterWorkloadGroupStatement FromMutable(ScriptDom.AlterWorkloadGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterWorkloadGroupStatement))) { throw new NotImplementedException("Unexpected subtype of AlterWorkloadGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterWorkloadGroupStatement(
                name: FromMutable(fragment.Name),
                workloadGroupParameters: fragment.WorkloadGroupParameters.SelectList(FromMutable),
                poolName: FromMutable(fragment.PoolName),
                externalPoolName: FromMutable(fragment.ExternalPoolName)
            );
        }
        
        public static AlterXmlSchemaCollectionStatement FromMutable(ScriptDom.AlterXmlSchemaCollectionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AlterXmlSchemaCollectionStatement))) { throw new NotImplementedException("Unexpected subtype of AlterXmlSchemaCollectionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterXmlSchemaCollectionStatement(
                name: FromMutable(fragment.Name),
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static ApplicationRoleOption FromMutable(ScriptDom.ApplicationRoleOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ApplicationRoleOption))) { throw new NotImplementedException("Unexpected subtype of ApplicationRoleOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ApplicationRoleOption(
                optionKind: fragment.OptionKind,
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static AssemblyEncryptionSource FromMutable(ScriptDom.AssemblyEncryptionSource fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AssemblyEncryptionSource))) { throw new NotImplementedException("Unexpected subtype of AssemblyEncryptionSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AssemblyEncryptionSource(
                assembly: FromMutable(fragment.Assembly)
            );
        }
        
        public static AssemblyName FromMutable(ScriptDom.AssemblyName fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AssemblyName))) { throw new NotImplementedException("Unexpected subtype of AssemblyName not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AssemblyName(
                name: FromMutable(fragment.Name),
                className: FromMutable(fragment.ClassName)
            );
        }
        
        public static AssemblyOption FromMutable(ScriptDom.AssemblyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AssemblyOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as AssemblyOption; }
            return new AssemblyOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static AssignmentSetClause FromMutable(ScriptDom.AssignmentSetClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AssignmentSetClause))) { throw new NotImplementedException("Unexpected subtype of AssignmentSetClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AssignmentSetClause(
                variable: FromMutable(fragment.Variable),
                column: FromMutable(fragment.Column),
                newValue: FromMutable(fragment.NewValue),
                assignmentKind: fragment.AssignmentKind
            );
        }
        
        public static AsymmetricKeyCreateLoginSource FromMutable(ScriptDom.AsymmetricKeyCreateLoginSource fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AsymmetricKeyCreateLoginSource))) { throw new NotImplementedException("Unexpected subtype of AsymmetricKeyCreateLoginSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AsymmetricKeyCreateLoginSource(
                key: FromMutable(fragment.Key),
                credential: FromMutable(fragment.Credential)
            );
        }
        
        public static AtTimeZoneCall FromMutable(ScriptDom.AtTimeZoneCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AtTimeZoneCall))) { throw new NotImplementedException("Unexpected subtype of AtTimeZoneCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AtTimeZoneCall(
                dateValue: FromMutable(fragment.DateValue),
                timeZone: FromMutable(fragment.TimeZone),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static AuditActionGroupReference FromMutable(ScriptDom.AuditActionGroupReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AuditActionGroupReference))) { throw new NotImplementedException("Unexpected subtype of AuditActionGroupReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AuditActionGroupReference(
                group: fragment.Group
            );
        }
        
        public static AuditActionSpecification FromMutable(ScriptDom.AuditActionSpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AuditActionSpecification))) { throw new NotImplementedException("Unexpected subtype of AuditActionSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AuditActionSpecification(
                actions: fragment.Actions.SelectList(FromMutable),
                principals: fragment.Principals.SelectList(FromMutable),
                targetObject: FromMutable(fragment.TargetObject)
            );
        }
        
        public static AuditGuidAuditOption FromMutable(ScriptDom.AuditGuidAuditOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AuditGuidAuditOption))) { throw new NotImplementedException("Unexpected subtype of AuditGuidAuditOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AuditGuidAuditOption(
                guid: FromMutable(fragment.Guid),
                optionKind: fragment.OptionKind
            );
        }
        
        public static AuditSpecificationPart FromMutable(ScriptDom.AuditSpecificationPart fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AuditSpecificationPart))) { throw new NotImplementedException("Unexpected subtype of AuditSpecificationPart not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AuditSpecificationPart(
                isDrop: fragment.IsDrop,
                details: FromMutable(fragment.Details)
            );
        }
        
        public static AuditTarget FromMutable(ScriptDom.AuditTarget fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AuditTarget))) { throw new NotImplementedException("Unexpected subtype of AuditTarget not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AuditTarget(
                targetKind: fragment.TargetKind,
                targetOptions: fragment.TargetOptions.SelectList(FromMutable)
            );
        }
        
        public static AuthenticationEndpointProtocolOption FromMutable(ScriptDom.AuthenticationEndpointProtocolOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AuthenticationEndpointProtocolOption))) { throw new NotImplementedException("Unexpected subtype of AuthenticationEndpointProtocolOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AuthenticationEndpointProtocolOption(
                authenticationTypes: fragment.AuthenticationTypes,
                kind: fragment.Kind
            );
        }
        
        public static AuthenticationPayloadOption FromMutable(ScriptDom.AuthenticationPayloadOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AuthenticationPayloadOption))) { throw new NotImplementedException("Unexpected subtype of AuthenticationPayloadOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AuthenticationPayloadOption(
                protocol: fragment.Protocol,
                certificate: FromMutable(fragment.Certificate),
                tryCertificateFirst: fragment.TryCertificateFirst,
                kind: fragment.Kind
            );
        }
        
        public static AutoCleanupChangeTrackingOptionDetail FromMutable(ScriptDom.AutoCleanupChangeTrackingOptionDetail fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AutoCleanupChangeTrackingOptionDetail))) { throw new NotImplementedException("Unexpected subtype of AutoCleanupChangeTrackingOptionDetail not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AutoCleanupChangeTrackingOptionDetail(
                isOn: fragment.IsOn
            );
        }
        
        public static AutoCreateStatisticsDatabaseOption FromMutable(ScriptDom.AutoCreateStatisticsDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AutoCreateStatisticsDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of AutoCreateStatisticsDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AutoCreateStatisticsDatabaseOption(
                hasIncremental: fragment.HasIncremental,
                incrementalState: fragment.IncrementalState,
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static AutomaticTuningCreateIndexOption FromMutable(ScriptDom.AutomaticTuningCreateIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AutomaticTuningCreateIndexOption))) { throw new NotImplementedException("Unexpected subtype of AutomaticTuningCreateIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AutomaticTuningCreateIndexOption(
                optionKind: fragment.OptionKind,
                @value: fragment.Value
            );
        }
        
        public static AutomaticTuningDatabaseOption FromMutable(ScriptDom.AutomaticTuningDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AutomaticTuningDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of AutomaticTuningDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AutomaticTuningDatabaseOption(
                automaticTuningState: fragment.AutomaticTuningState,
                options: fragment.Options.SelectList(FromMutable),
                optionKind: fragment.OptionKind
            );
        }
        
        public static AutomaticTuningDropIndexOption FromMutable(ScriptDom.AutomaticTuningDropIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AutomaticTuningDropIndexOption))) { throw new NotImplementedException("Unexpected subtype of AutomaticTuningDropIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AutomaticTuningDropIndexOption(
                optionKind: fragment.OptionKind,
                @value: fragment.Value
            );
        }
        
        public static AutomaticTuningForceLastGoodPlanOption FromMutable(ScriptDom.AutomaticTuningForceLastGoodPlanOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AutomaticTuningForceLastGoodPlanOption))) { throw new NotImplementedException("Unexpected subtype of AutomaticTuningForceLastGoodPlanOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AutomaticTuningForceLastGoodPlanOption(
                optionKind: fragment.OptionKind,
                @value: fragment.Value
            );
        }
        
        public static AutomaticTuningMaintainIndexOption FromMutable(ScriptDom.AutomaticTuningMaintainIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AutomaticTuningMaintainIndexOption))) { throw new NotImplementedException("Unexpected subtype of AutomaticTuningMaintainIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AutomaticTuningMaintainIndexOption(
                optionKind: fragment.OptionKind,
                @value: fragment.Value
            );
        }
        
        public static AutomaticTuningOption FromMutable(ScriptDom.AutomaticTuningOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AutomaticTuningOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as AutomaticTuningOption; }
            return new AutomaticTuningOption(
                optionKind: fragment.OptionKind,
                @value: fragment.Value
            );
        }
        
        public static AvailabilityModeReplicaOption FromMutable(ScriptDom.AvailabilityModeReplicaOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AvailabilityModeReplicaOption))) { throw new NotImplementedException("Unexpected subtype of AvailabilityModeReplicaOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AvailabilityModeReplicaOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static AvailabilityReplica FromMutable(ScriptDom.AvailabilityReplica fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.AvailabilityReplica))) { throw new NotImplementedException("Unexpected subtype of AvailabilityReplica not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AvailabilityReplica(
                serverName: FromMutable(fragment.ServerName),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static BackupCertificateStatement FromMutable(ScriptDom.BackupCertificateStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BackupCertificateStatement))) { throw new NotImplementedException("Unexpected subtype of BackupCertificateStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BackupCertificateStatement(
                file: FromMutable(fragment.File),
                name: FromMutable(fragment.Name),
                activeForBeginDialog: fragment.ActiveForBeginDialog,
                privateKeyPath: FromMutable(fragment.PrivateKeyPath),
                encryptionPassword: FromMutable(fragment.EncryptionPassword),
                decryptionPassword: FromMutable(fragment.DecryptionPassword)
            );
        }
        
        public static BackupDatabaseStatement FromMutable(ScriptDom.BackupDatabaseStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BackupDatabaseStatement))) { throw new NotImplementedException("Unexpected subtype of BackupDatabaseStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BackupDatabaseStatement(
                files: fragment.Files.SelectList(FromMutable),
                databaseName: FromMutable(fragment.DatabaseName),
                options: fragment.Options.SelectList(FromMutable),
                mirrorToClauses: fragment.MirrorToClauses.SelectList(FromMutable),
                devices: fragment.Devices.SelectList(FromMutable)
            );
        }
        
        public static BackupEncryptionOption FromMutable(ScriptDom.BackupEncryptionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BackupEncryptionOption))) { throw new NotImplementedException("Unexpected subtype of BackupEncryptionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BackupEncryptionOption(
                algorithm: fragment.Algorithm,
                encryptor: FromMutable(fragment.Encryptor),
                optionKind: fragment.OptionKind,
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static BackupMasterKeyStatement FromMutable(ScriptDom.BackupMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BackupMasterKeyStatement))) { throw new NotImplementedException("Unexpected subtype of BackupMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BackupMasterKeyStatement(
                file: FromMutable(fragment.File),
                password: FromMutable(fragment.Password)
            );
        }
        
        public static BackupOption FromMutable(ScriptDom.BackupOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BackupOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as BackupOption; }
            return new BackupOption(
                optionKind: fragment.OptionKind,
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static BackupRestoreFileInfo FromMutable(ScriptDom.BackupRestoreFileInfo fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BackupRestoreFileInfo))) { throw new NotImplementedException("Unexpected subtype of BackupRestoreFileInfo not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BackupRestoreFileInfo(
                items: fragment.Items.SelectList(FromMutable),
                itemKind: fragment.ItemKind
            );
        }
        
        public static BackupServiceMasterKeyStatement FromMutable(ScriptDom.BackupServiceMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BackupServiceMasterKeyStatement))) { throw new NotImplementedException("Unexpected subtype of BackupServiceMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BackupServiceMasterKeyStatement(
                file: FromMutable(fragment.File),
                password: FromMutable(fragment.Password)
            );
        }
        
        public static BackupTransactionLogStatement FromMutable(ScriptDom.BackupTransactionLogStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BackupTransactionLogStatement))) { throw new NotImplementedException("Unexpected subtype of BackupTransactionLogStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BackupTransactionLogStatement(
                databaseName: FromMutable(fragment.DatabaseName),
                options: fragment.Options.SelectList(FromMutable),
                mirrorToClauses: fragment.MirrorToClauses.SelectList(FromMutable),
                devices: fragment.Devices.SelectList(FromMutable)
            );
        }
        
        public static BackwardsCompatibleDropIndexClause FromMutable(ScriptDom.BackwardsCompatibleDropIndexClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BackwardsCompatibleDropIndexClause))) { throw new NotImplementedException("Unexpected subtype of BackwardsCompatibleDropIndexClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BackwardsCompatibleDropIndexClause(
                index: FromMutable(fragment.Index)
            );
        }
        
        public static BeginConversationTimerStatement FromMutable(ScriptDom.BeginConversationTimerStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BeginConversationTimerStatement))) { throw new NotImplementedException("Unexpected subtype of BeginConversationTimerStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BeginConversationTimerStatement(
                handle: FromMutable(fragment.Handle),
                timeout: FromMutable(fragment.Timeout)
            );
        }
        
        public static BeginDialogStatement FromMutable(ScriptDom.BeginDialogStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BeginDialogStatement))) { throw new NotImplementedException("Unexpected subtype of BeginDialogStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BeginDialogStatement(
                isConversation: fragment.IsConversation,
                handle: FromMutable(fragment.Handle),
                initiatorServiceName: FromMutable(fragment.InitiatorServiceName),
                targetServiceName: FromMutable(fragment.TargetServiceName),
                instanceSpec: FromMutable(fragment.InstanceSpec),
                contractName: FromMutable(fragment.ContractName),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static BeginEndAtomicBlockStatement FromMutable(ScriptDom.BeginEndAtomicBlockStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BeginEndAtomicBlockStatement))) { throw new NotImplementedException("Unexpected subtype of BeginEndAtomicBlockStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BeginEndAtomicBlockStatement(
                options: fragment.Options.SelectList(FromMutable),
                statementList: FromMutable(fragment.StatementList)
            );
        }
        
        public static BeginEndBlockStatement FromMutable(ScriptDom.BeginEndBlockStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BeginEndBlockStatement))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as BeginEndBlockStatement; }
            return new BeginEndBlockStatement(
                statementList: FromMutable(fragment.StatementList)
            );
        }
        
        public static BeginTransactionStatement FromMutable(ScriptDom.BeginTransactionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BeginTransactionStatement))) { throw new NotImplementedException("Unexpected subtype of BeginTransactionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BeginTransactionStatement(
                distributed: fragment.Distributed,
                markDefined: fragment.MarkDefined,
                markDescription: FromMutable(fragment.MarkDescription),
                name: FromMutable(fragment.Name)
            );
        }
        
        public static BinaryExpression FromMutable(ScriptDom.BinaryExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BinaryExpression))) { throw new NotImplementedException("Unexpected subtype of BinaryExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BinaryExpression(
                binaryExpressionType: fragment.BinaryExpressionType,
                firstExpression: FromMutable(fragment.FirstExpression),
                secondExpression: FromMutable(fragment.SecondExpression)
            );
        }
        
        public static BinaryLiteral FromMutable(ScriptDom.BinaryLiteral fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BinaryLiteral))) { throw new NotImplementedException("Unexpected subtype of BinaryLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BinaryLiteral(
                isLargeObject: fragment.IsLargeObject,
                @value: fragment.Value,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static BinaryQueryExpression FromMutable(ScriptDom.BinaryQueryExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BinaryQueryExpression))) { throw new NotImplementedException("Unexpected subtype of BinaryQueryExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BinaryQueryExpression(
                binaryQueryExpressionType: fragment.BinaryQueryExpressionType,
                all: fragment.All,
                firstQueryExpression: FromMutable(fragment.FirstQueryExpression),
                secondQueryExpression: FromMutable(fragment.SecondQueryExpression),
                orderByClause: FromMutable(fragment.OrderByClause),
                offsetClause: FromMutable(fragment.OffsetClause),
                forClause: FromMutable(fragment.ForClause)
            );
        }
        
        public static BooleanBinaryExpression FromMutable(ScriptDom.BooleanBinaryExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BooleanBinaryExpression))) { throw new NotImplementedException("Unexpected subtype of BooleanBinaryExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BooleanBinaryExpression(
                binaryExpressionType: fragment.BinaryExpressionType,
                firstExpression: FromMutable(fragment.FirstExpression),
                secondExpression: FromMutable(fragment.SecondExpression)
            );
        }
        
        public static BooleanComparisonExpression FromMutable(ScriptDom.BooleanComparisonExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BooleanComparisonExpression))) { throw new NotImplementedException("Unexpected subtype of BooleanComparisonExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BooleanComparisonExpression(
                comparisonType: fragment.ComparisonType,
                firstExpression: FromMutable(fragment.FirstExpression),
                secondExpression: FromMutable(fragment.SecondExpression)
            );
        }
        
        public static BooleanExpressionSnippet FromMutable(ScriptDom.BooleanExpressionSnippet fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BooleanExpressionSnippet))) { throw new NotImplementedException("Unexpected subtype of BooleanExpressionSnippet not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BooleanExpressionSnippet(
                script: fragment.Script
            );
        }
        
        public static BooleanIsNullExpression FromMutable(ScriptDom.BooleanIsNullExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BooleanIsNullExpression))) { throw new NotImplementedException("Unexpected subtype of BooleanIsNullExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BooleanIsNullExpression(
                isNot: fragment.IsNot,
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static BooleanNotExpression FromMutable(ScriptDom.BooleanNotExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BooleanNotExpression))) { throw new NotImplementedException("Unexpected subtype of BooleanNotExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BooleanNotExpression(
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static BooleanParenthesisExpression FromMutable(ScriptDom.BooleanParenthesisExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BooleanParenthesisExpression))) { throw new NotImplementedException("Unexpected subtype of BooleanParenthesisExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BooleanParenthesisExpression(
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static BooleanTernaryExpression FromMutable(ScriptDom.BooleanTernaryExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BooleanTernaryExpression))) { throw new NotImplementedException("Unexpected subtype of BooleanTernaryExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BooleanTernaryExpression(
                ternaryExpressionType: fragment.TernaryExpressionType,
                firstExpression: FromMutable(fragment.FirstExpression),
                secondExpression: FromMutable(fragment.SecondExpression),
                thirdExpression: FromMutable(fragment.ThirdExpression)
            );
        }
        
        public static BoundingBoxParameter FromMutable(ScriptDom.BoundingBoxParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BoundingBoxParameter))) { throw new NotImplementedException("Unexpected subtype of BoundingBoxParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BoundingBoxParameter(
                parameter: fragment.Parameter,
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static BoundingBoxSpatialIndexOption FromMutable(ScriptDom.BoundingBoxSpatialIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BoundingBoxSpatialIndexOption))) { throw new NotImplementedException("Unexpected subtype of BoundingBoxSpatialIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BoundingBoxSpatialIndexOption(
                boundingBoxParameters: fragment.BoundingBoxParameters.SelectList(FromMutable)
            );
        }
        
        public static BreakStatement FromMutable(ScriptDom.BreakStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BreakStatement))) { throw new NotImplementedException("Unexpected subtype of BreakStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BreakStatement(
                
            );
        }
        
        public static BrokerPriorityParameter FromMutable(ScriptDom.BrokerPriorityParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BrokerPriorityParameter))) { throw new NotImplementedException("Unexpected subtype of BrokerPriorityParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BrokerPriorityParameter(
                isDefaultOrAny: fragment.IsDefaultOrAny,
                parameterType: fragment.ParameterType,
                parameterValue: FromMutable(fragment.ParameterValue)
            );
        }
        
        public static BrowseForClause FromMutable(ScriptDom.BrowseForClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BrowseForClause))) { throw new NotImplementedException("Unexpected subtype of BrowseForClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BrowseForClause(
                
            );
        }
        
        public static BuiltInFunctionTableReference FromMutable(ScriptDom.BuiltInFunctionTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BuiltInFunctionTableReference))) { throw new NotImplementedException("Unexpected subtype of BuiltInFunctionTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BuiltInFunctionTableReference(
                name: FromMutable(fragment.Name),
                parameters: fragment.Parameters.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static BulkInsertOption FromMutable(ScriptDom.BulkInsertOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BulkInsertOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as BulkInsertOption; }
            return new BulkInsertOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static BulkInsertStatement FromMutable(ScriptDom.BulkInsertStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BulkInsertStatement))) { throw new NotImplementedException("Unexpected subtype of BulkInsertStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BulkInsertStatement(
                from: FromMutable(fragment.From),
                to: FromMutable(fragment.To),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static BulkOpenRowset FromMutable(ScriptDom.BulkOpenRowset fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.BulkOpenRowset))) { throw new NotImplementedException("Unexpected subtype of BulkOpenRowset not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BulkOpenRowset(
                dataFiles: fragment.DataFiles.SelectList(FromMutable),
                options: fragment.Options.SelectList(FromMutable),
                withColumns: fragment.WithColumns.SelectList(FromMutable),
                columns: fragment.Columns.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static CastCall FromMutable(ScriptDom.CastCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CastCall))) { throw new NotImplementedException("Unexpected subtype of CastCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CastCall(
                dataType: FromMutable(fragment.DataType),
                parameter: FromMutable(fragment.Parameter),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static CatalogCollationOption FromMutable(ScriptDom.CatalogCollationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CatalogCollationOption))) { throw new NotImplementedException("Unexpected subtype of CatalogCollationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CatalogCollationOption(
                catalogCollation: fragment.CatalogCollation,
                optionKind: fragment.OptionKind
            );
        }
        
        public static CellsPerObjectSpatialIndexOption FromMutable(ScriptDom.CellsPerObjectSpatialIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CellsPerObjectSpatialIndexOption))) { throw new NotImplementedException("Unexpected subtype of CellsPerObjectSpatialIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CellsPerObjectSpatialIndexOption(
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static CertificateCreateLoginSource FromMutable(ScriptDom.CertificateCreateLoginSource fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CertificateCreateLoginSource))) { throw new NotImplementedException("Unexpected subtype of CertificateCreateLoginSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CertificateCreateLoginSource(
                certificate: FromMutable(fragment.Certificate),
                credential: FromMutable(fragment.Credential)
            );
        }
        
        public static CertificateOption FromMutable(ScriptDom.CertificateOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CertificateOption))) { throw new NotImplementedException("Unexpected subtype of CertificateOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CertificateOption(
                kind: fragment.Kind,
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static ChangeRetentionChangeTrackingOptionDetail FromMutable(ScriptDom.ChangeRetentionChangeTrackingOptionDetail fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ChangeRetentionChangeTrackingOptionDetail))) { throw new NotImplementedException("Unexpected subtype of ChangeRetentionChangeTrackingOptionDetail not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ChangeRetentionChangeTrackingOptionDetail(
                retentionPeriod: FromMutable(fragment.RetentionPeriod),
                unit: fragment.Unit
            );
        }
        
        public static ChangeTableChangesTableReference FromMutable(ScriptDom.ChangeTableChangesTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ChangeTableChangesTableReference))) { throw new NotImplementedException("Unexpected subtype of ChangeTableChangesTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ChangeTableChangesTableReference(
                target: FromMutable(fragment.Target),
                sinceVersion: FromMutable(fragment.SinceVersion),
                columns: fragment.Columns.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static ChangeTableVersionTableReference FromMutable(ScriptDom.ChangeTableVersionTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ChangeTableVersionTableReference))) { throw new NotImplementedException("Unexpected subtype of ChangeTableVersionTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ChangeTableVersionTableReference(
                target: FromMutable(fragment.Target),
                primaryKeyColumns: fragment.PrimaryKeyColumns.SelectList(FromMutable),
                primaryKeyValues: fragment.PrimaryKeyValues.SelectList(FromMutable),
                columns: fragment.Columns.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static ChangeTrackingDatabaseOption FromMutable(ScriptDom.ChangeTrackingDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ChangeTrackingDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of ChangeTrackingDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ChangeTrackingDatabaseOption(
                optionState: fragment.OptionState,
                details: fragment.Details.SelectList(FromMutable),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ChangeTrackingFullTextIndexOption FromMutable(ScriptDom.ChangeTrackingFullTextIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ChangeTrackingFullTextIndexOption))) { throw new NotImplementedException("Unexpected subtype of ChangeTrackingFullTextIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ChangeTrackingFullTextIndexOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static CharacterSetPayloadOption FromMutable(ScriptDom.CharacterSetPayloadOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CharacterSetPayloadOption))) { throw new NotImplementedException("Unexpected subtype of CharacterSetPayloadOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CharacterSetPayloadOption(
                isSql: fragment.IsSql,
                kind: fragment.Kind
            );
        }
        
        public static CheckConstraintDefinition FromMutable(ScriptDom.CheckConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CheckConstraintDefinition))) { throw new NotImplementedException("Unexpected subtype of CheckConstraintDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CheckConstraintDefinition(
                checkCondition: FromMutable(fragment.CheckCondition),
                notForReplication: fragment.NotForReplication,
                constraintIdentifier: FromMutable(fragment.ConstraintIdentifier)
            );
        }
        
        public static CheckpointStatement FromMutable(ScriptDom.CheckpointStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CheckpointStatement))) { throw new NotImplementedException("Unexpected subtype of CheckpointStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CheckpointStatement(
                duration: FromMutable(fragment.Duration)
            );
        }
        
        public static ChildObjectName FromMutable(ScriptDom.ChildObjectName fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ChildObjectName))) { throw new NotImplementedException("Unexpected subtype of ChildObjectName not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ChildObjectName(
                identifiers: fragment.Identifiers.SelectList(FromMutable)
            );
        }
        
        public static ClassifierEndTimeOption FromMutable(ScriptDom.ClassifierEndTimeOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ClassifierEndTimeOption))) { throw new NotImplementedException("Unexpected subtype of ClassifierEndTimeOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ClassifierEndTimeOption(
                time: FromMutable(fragment.Time),
                optionType: fragment.OptionType
            );
        }
        
        public static ClassifierImportanceOption FromMutable(ScriptDom.ClassifierImportanceOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ClassifierImportanceOption))) { throw new NotImplementedException("Unexpected subtype of ClassifierImportanceOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ClassifierImportanceOption(
                importance: fragment.Importance,
                optionType: fragment.OptionType
            );
        }
        
        public static ClassifierMemberNameOption FromMutable(ScriptDom.ClassifierMemberNameOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ClassifierMemberNameOption))) { throw new NotImplementedException("Unexpected subtype of ClassifierMemberNameOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ClassifierMemberNameOption(
                memberName: FromMutable(fragment.MemberName),
                optionType: fragment.OptionType
            );
        }
        
        public static ClassifierStartTimeOption FromMutable(ScriptDom.ClassifierStartTimeOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ClassifierStartTimeOption))) { throw new NotImplementedException("Unexpected subtype of ClassifierStartTimeOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ClassifierStartTimeOption(
                time: FromMutable(fragment.Time),
                optionType: fragment.OptionType
            );
        }
        
        public static ClassifierWlmContextOption FromMutable(ScriptDom.ClassifierWlmContextOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ClassifierWlmContextOption))) { throw new NotImplementedException("Unexpected subtype of ClassifierWlmContextOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ClassifierWlmContextOption(
                wlmContext: FromMutable(fragment.WlmContext),
                optionType: fragment.OptionType
            );
        }
        
        public static ClassifierWlmLabelOption FromMutable(ScriptDom.ClassifierWlmLabelOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ClassifierWlmLabelOption))) { throw new NotImplementedException("Unexpected subtype of ClassifierWlmLabelOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ClassifierWlmLabelOption(
                wlmLabel: FromMutable(fragment.WlmLabel),
                optionType: fragment.OptionType
            );
        }
        
        public static ClassifierWorkloadGroupOption FromMutable(ScriptDom.ClassifierWorkloadGroupOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ClassifierWorkloadGroupOption))) { throw new NotImplementedException("Unexpected subtype of ClassifierWorkloadGroupOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ClassifierWorkloadGroupOption(
                workloadGroupName: FromMutable(fragment.WorkloadGroupName),
                optionType: fragment.OptionType
            );
        }
        
        public static CloseCursorStatement FromMutable(ScriptDom.CloseCursorStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CloseCursorStatement))) { throw new NotImplementedException("Unexpected subtype of CloseCursorStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CloseCursorStatement(
                cursor: FromMutable(fragment.Cursor)
            );
        }
        
        public static CloseMasterKeyStatement FromMutable(ScriptDom.CloseMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CloseMasterKeyStatement))) { throw new NotImplementedException("Unexpected subtype of CloseMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CloseMasterKeyStatement(
                
            );
        }
        
        public static CloseSymmetricKeyStatement FromMutable(ScriptDom.CloseSymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CloseSymmetricKeyStatement))) { throw new NotImplementedException("Unexpected subtype of CloseSymmetricKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CloseSymmetricKeyStatement(
                name: FromMutable(fragment.Name),
                all: fragment.All
            );
        }
        
        public static CoalesceExpression FromMutable(ScriptDom.CoalesceExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CoalesceExpression))) { throw new NotImplementedException("Unexpected subtype of CoalesceExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CoalesceExpression(
                expressions: fragment.Expressions.SelectList(FromMutable),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static ColumnDefinition FromMutable(ScriptDom.ColumnDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnDefinition))) { throw new NotImplementedException("Unexpected subtype of ColumnDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnDefinition(
                computedColumnExpression: FromMutable(fragment.ComputedColumnExpression),
                isPersisted: fragment.IsPersisted,
                defaultConstraint: FromMutable(fragment.DefaultConstraint),
                identityOptions: FromMutable(fragment.IdentityOptions),
                isRowGuidCol: fragment.IsRowGuidCol,
                constraints: fragment.Constraints.SelectList(FromMutable),
                storageOptions: FromMutable(fragment.StorageOptions),
                index: FromMutable(fragment.Index),
                generatedAlways: fragment.GeneratedAlways,
                isHidden: fragment.IsHidden,
                encryption: FromMutable(fragment.Encryption),
                isMasked: fragment.IsMasked,
                maskingFunction: FromMutable(fragment.MaskingFunction),
                columnIdentifier: FromMutable(fragment.ColumnIdentifier),
                dataType: FromMutable(fragment.DataType),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static ColumnDefinitionBase FromMutable(ScriptDom.ColumnDefinitionBase fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnDefinitionBase))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as ColumnDefinitionBase; }
            return new ColumnDefinitionBase(
                columnIdentifier: FromMutable(fragment.ColumnIdentifier),
                dataType: FromMutable(fragment.DataType),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static ColumnEncryptionAlgorithmNameParameter FromMutable(ScriptDom.ColumnEncryptionAlgorithmNameParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnEncryptionAlgorithmNameParameter))) { throw new NotImplementedException("Unexpected subtype of ColumnEncryptionAlgorithmNameParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnEncryptionAlgorithmNameParameter(
                algorithm: FromMutable(fragment.Algorithm),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnEncryptionAlgorithmParameter FromMutable(ScriptDom.ColumnEncryptionAlgorithmParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnEncryptionAlgorithmParameter))) { throw new NotImplementedException("Unexpected subtype of ColumnEncryptionAlgorithmParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnEncryptionAlgorithmParameter(
                encryptionAlgorithm: FromMutable(fragment.EncryptionAlgorithm),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnEncryptionDefinition FromMutable(ScriptDom.ColumnEncryptionDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnEncryptionDefinition))) { throw new NotImplementedException("Unexpected subtype of ColumnEncryptionDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnEncryptionDefinition(
                parameters: fragment.Parameters.SelectList(FromMutable)
            );
        }
        
        public static ColumnEncryptionKeyNameParameter FromMutable(ScriptDom.ColumnEncryptionKeyNameParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnEncryptionKeyNameParameter))) { throw new NotImplementedException("Unexpected subtype of ColumnEncryptionKeyNameParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnEncryptionKeyNameParameter(
                name: FromMutable(fragment.Name),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnEncryptionKeyValue FromMutable(ScriptDom.ColumnEncryptionKeyValue fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnEncryptionKeyValue))) { throw new NotImplementedException("Unexpected subtype of ColumnEncryptionKeyValue not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnEncryptionKeyValue(
                parameters: fragment.Parameters.SelectList(FromMutable)
            );
        }
        
        public static ColumnEncryptionTypeParameter FromMutable(ScriptDom.ColumnEncryptionTypeParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnEncryptionTypeParameter))) { throw new NotImplementedException("Unexpected subtype of ColumnEncryptionTypeParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnEncryptionTypeParameter(
                encryptionType: fragment.EncryptionType,
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnMasterKeyEnclaveComputationsParameter FromMutable(ScriptDom.ColumnMasterKeyEnclaveComputationsParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnMasterKeyEnclaveComputationsParameter))) { throw new NotImplementedException("Unexpected subtype of ColumnMasterKeyEnclaveComputationsParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnMasterKeyEnclaveComputationsParameter(
                signature: FromMutable(fragment.Signature),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnMasterKeyNameParameter FromMutable(ScriptDom.ColumnMasterKeyNameParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnMasterKeyNameParameter))) { throw new NotImplementedException("Unexpected subtype of ColumnMasterKeyNameParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnMasterKeyNameParameter(
                name: FromMutable(fragment.Name),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnMasterKeyPathParameter FromMutable(ScriptDom.ColumnMasterKeyPathParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnMasterKeyPathParameter))) { throw new NotImplementedException("Unexpected subtype of ColumnMasterKeyPathParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnMasterKeyPathParameter(
                path: FromMutable(fragment.Path),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnMasterKeyStoreProviderNameParameter FromMutable(ScriptDom.ColumnMasterKeyStoreProviderNameParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnMasterKeyStoreProviderNameParameter))) { throw new NotImplementedException("Unexpected subtype of ColumnMasterKeyStoreProviderNameParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnMasterKeyStoreProviderNameParameter(
                name: FromMutable(fragment.Name),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnReferenceExpression FromMutable(ScriptDom.ColumnReferenceExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnReferenceExpression))) { throw new NotImplementedException("Unexpected subtype of ColumnReferenceExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnReferenceExpression(
                columnType: fragment.ColumnType,
                multiPartIdentifier: FromMutable(fragment.MultiPartIdentifier),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static ColumnStorageOptions FromMutable(ScriptDom.ColumnStorageOptions fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnStorageOptions))) { throw new NotImplementedException("Unexpected subtype of ColumnStorageOptions not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnStorageOptions(
                isFileStream: fragment.IsFileStream,
                sparseOption: fragment.SparseOption
            );
        }
        
        public static ColumnWithSortOrder FromMutable(ScriptDom.ColumnWithSortOrder fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ColumnWithSortOrder))) { throw new NotImplementedException("Unexpected subtype of ColumnWithSortOrder not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ColumnWithSortOrder(
                column: FromMutable(fragment.Column),
                sortOrder: fragment.SortOrder
            );
        }
        
        public static CommandSecurityElement80 FromMutable(ScriptDom.CommandSecurityElement80 fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CommandSecurityElement80))) { throw new NotImplementedException("Unexpected subtype of CommandSecurityElement80 not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CommandSecurityElement80(
                all: fragment.All,
                commandOptions: fragment.CommandOptions
            );
        }
        
        public static CommitTransactionStatement FromMutable(ScriptDom.CommitTransactionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CommitTransactionStatement))) { throw new NotImplementedException("Unexpected subtype of CommitTransactionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CommitTransactionStatement(
                delayedDurabilityOption: fragment.DelayedDurabilityOption,
                name: FromMutable(fragment.Name)
            );
        }
        
        public static CommonTableExpression FromMutable(ScriptDom.CommonTableExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CommonTableExpression))) { throw new NotImplementedException("Unexpected subtype of CommonTableExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CommonTableExpression(
                expressionName: FromMutable(fragment.ExpressionName),
                columns: fragment.Columns.SelectList(FromMutable),
                queryExpression: FromMutable(fragment.QueryExpression)
            );
        }
        
        public static CompositeGroupingSpecification FromMutable(ScriptDom.CompositeGroupingSpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CompositeGroupingSpecification))) { throw new NotImplementedException("Unexpected subtype of CompositeGroupingSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CompositeGroupingSpecification(
                items: fragment.Items.SelectList(FromMutable)
            );
        }
        
        public static CompressionDelayIndexOption FromMutable(ScriptDom.CompressionDelayIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CompressionDelayIndexOption))) { throw new NotImplementedException("Unexpected subtype of CompressionDelayIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CompressionDelayIndexOption(
                expression: FromMutable(fragment.Expression),
                timeUnit: fragment.TimeUnit,
                optionKind: fragment.OptionKind
            );
        }
        
        public static CompressionEndpointProtocolOption FromMutable(ScriptDom.CompressionEndpointProtocolOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CompressionEndpointProtocolOption))) { throw new NotImplementedException("Unexpected subtype of CompressionEndpointProtocolOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CompressionEndpointProtocolOption(
                isEnabled: fragment.IsEnabled,
                kind: fragment.Kind
            );
        }
        
        public static CompressionPartitionRange FromMutable(ScriptDom.CompressionPartitionRange fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CompressionPartitionRange))) { throw new NotImplementedException("Unexpected subtype of CompressionPartitionRange not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CompressionPartitionRange(
                from: FromMutable(fragment.From),
                to: FromMutable(fragment.To)
            );
        }
        
        public static ComputeClause FromMutable(ScriptDom.ComputeClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ComputeClause))) { throw new NotImplementedException("Unexpected subtype of ComputeClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ComputeClause(
                computeFunctions: fragment.ComputeFunctions.SelectList(FromMutable),
                byExpressions: fragment.ByExpressions.SelectList(FromMutable)
            );
        }
        
        public static ComputeFunction FromMutable(ScriptDom.ComputeFunction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ComputeFunction))) { throw new NotImplementedException("Unexpected subtype of ComputeFunction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ComputeFunction(
                computeFunctionType: fragment.ComputeFunctionType,
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static ContainmentDatabaseOption FromMutable(ScriptDom.ContainmentDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ContainmentDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of ContainmentDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ContainmentDatabaseOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static ContinueStatement FromMutable(ScriptDom.ContinueStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ContinueStatement))) { throw new NotImplementedException("Unexpected subtype of ContinueStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ContinueStatement(
                
            );
        }
        
        public static ContractMessage FromMutable(ScriptDom.ContractMessage fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ContractMessage))) { throw new NotImplementedException("Unexpected subtype of ContractMessage not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ContractMessage(
                name: FromMutable(fragment.Name),
                sentBy: fragment.SentBy
            );
        }
        
        public static ConvertCall FromMutable(ScriptDom.ConvertCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ConvertCall))) { throw new NotImplementedException("Unexpected subtype of ConvertCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ConvertCall(
                dataType: FromMutable(fragment.DataType),
                parameter: FromMutable(fragment.Parameter),
                style: FromMutable(fragment.Style),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static CopyColumnOption FromMutable(ScriptDom.CopyColumnOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CopyColumnOption))) { throw new NotImplementedException("Unexpected subtype of CopyColumnOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CopyColumnOption(
                columnName: FromMutable(fragment.ColumnName),
                defaultValue: FromMutable(fragment.DefaultValue),
                fieldNumber: FromMutable(fragment.FieldNumber)
            );
        }
        
        public static CopyCredentialOption FromMutable(ScriptDom.CopyCredentialOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CopyCredentialOption))) { throw new NotImplementedException("Unexpected subtype of CopyCredentialOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CopyCredentialOption(
                identity: FromMutable(fragment.Identity),
                secret: FromMutable(fragment.Secret)
            );
        }
        
        public static CopyOption FromMutable(ScriptDom.CopyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CopyOption))) { throw new NotImplementedException("Unexpected subtype of CopyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CopyOption(
                kind: fragment.Kind,
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static CopyStatement FromMutable(ScriptDom.CopyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CopyStatement))) { throw new NotImplementedException("Unexpected subtype of CopyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CopyStatement(
                from: fragment.From.SelectList(FromMutable),
                into: FromMutable(fragment.Into),
                options: fragment.Options.SelectList(FromMutable),
                optimizerHints: fragment.OptimizerHints.SelectList(FromMutable)
            );
        }
        
        public static CreateAggregateStatement FromMutable(ScriptDom.CreateAggregateStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateAggregateStatement))) { throw new NotImplementedException("Unexpected subtype of CreateAggregateStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateAggregateStatement(
                name: FromMutable(fragment.Name),
                assemblyName: FromMutable(fragment.AssemblyName),
                parameters: fragment.Parameters.SelectList(FromMutable),
                returnType: FromMutable(fragment.ReturnType)
            );
        }
        
        public static CreateApplicationRoleStatement FromMutable(ScriptDom.CreateApplicationRoleStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateApplicationRoleStatement))) { throw new NotImplementedException("Unexpected subtype of CreateApplicationRoleStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateApplicationRoleStatement(
                name: FromMutable(fragment.Name),
                applicationRoleOptions: fragment.ApplicationRoleOptions.SelectList(FromMutable)
            );
        }
        
        public static CreateAssemblyStatement FromMutable(ScriptDom.CreateAssemblyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateAssemblyStatement))) { throw new NotImplementedException("Unexpected subtype of CreateAssemblyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateAssemblyStatement(
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name),
                parameters: fragment.Parameters.SelectList(FromMutable),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static CreateAsymmetricKeyStatement FromMutable(ScriptDom.CreateAsymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateAsymmetricKeyStatement))) { throw new NotImplementedException("Unexpected subtype of CreateAsymmetricKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateAsymmetricKeyStatement(
                name: FromMutable(fragment.Name),
                keySource: FromMutable(fragment.KeySource),
                encryptionAlgorithm: fragment.EncryptionAlgorithm,
                password: FromMutable(fragment.Password),
                owner: FromMutable(fragment.Owner)
            );
        }
        
        public static CreateAvailabilityGroupStatement FromMutable(ScriptDom.CreateAvailabilityGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateAvailabilityGroupStatement))) { throw new NotImplementedException("Unexpected subtype of CreateAvailabilityGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateAvailabilityGroupStatement(
                name: FromMutable(fragment.Name),
                options: fragment.Options.SelectList(FromMutable),
                databases: fragment.Databases.SelectList(FromMutable),
                replicas: fragment.Replicas.SelectList(FromMutable)
            );
        }
        
        public static CreateBrokerPriorityStatement FromMutable(ScriptDom.CreateBrokerPriorityStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateBrokerPriorityStatement))) { throw new NotImplementedException("Unexpected subtype of CreateBrokerPriorityStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateBrokerPriorityStatement(
                name: FromMutable(fragment.Name),
                brokerPriorityParameters: fragment.BrokerPriorityParameters.SelectList(FromMutable)
            );
        }
        
        public static CreateCertificateStatement FromMutable(ScriptDom.CreateCertificateStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateCertificateStatement))) { throw new NotImplementedException("Unexpected subtype of CreateCertificateStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateCertificateStatement(
                certificateSource: FromMutable(fragment.CertificateSource),
                certificateOptions: fragment.CertificateOptions.SelectList(FromMutable),
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name),
                activeForBeginDialog: fragment.ActiveForBeginDialog,
                privateKeyPath: FromMutable(fragment.PrivateKeyPath),
                encryptionPassword: FromMutable(fragment.EncryptionPassword),
                decryptionPassword: FromMutable(fragment.DecryptionPassword)
            );
        }
        
        public static CreateColumnEncryptionKeyStatement FromMutable(ScriptDom.CreateColumnEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateColumnEncryptionKeyStatement))) { throw new NotImplementedException("Unexpected subtype of CreateColumnEncryptionKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateColumnEncryptionKeyStatement(
                name: FromMutable(fragment.Name),
                columnEncryptionKeyValues: fragment.ColumnEncryptionKeyValues.SelectList(FromMutable)
            );
        }
        
        public static CreateColumnMasterKeyStatement FromMutable(ScriptDom.CreateColumnMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateColumnMasterKeyStatement))) { throw new NotImplementedException("Unexpected subtype of CreateColumnMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateColumnMasterKeyStatement(
                name: FromMutable(fragment.Name),
                parameters: fragment.Parameters.SelectList(FromMutable)
            );
        }
        
        public static CreateColumnStoreIndexStatement FromMutable(ScriptDom.CreateColumnStoreIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateColumnStoreIndexStatement))) { throw new NotImplementedException("Unexpected subtype of CreateColumnStoreIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateColumnStoreIndexStatement(
                name: FromMutable(fragment.Name),
                clustered: fragment.Clustered,
                onName: FromMutable(fragment.OnName),
                columns: fragment.Columns.SelectList(FromMutable),
                filterPredicate: FromMutable(fragment.FilterPredicate),
                indexOptions: fragment.IndexOptions.SelectList(FromMutable),
                onFileGroupOrPartitionScheme: FromMutable(fragment.OnFileGroupOrPartitionScheme),
                orderedColumns: fragment.OrderedColumns.SelectList(FromMutable)
            );
        }
        
        public static CreateContractStatement FromMutable(ScriptDom.CreateContractStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateContractStatement))) { throw new NotImplementedException("Unexpected subtype of CreateContractStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateContractStatement(
                name: FromMutable(fragment.Name),
                messages: fragment.Messages.SelectList(FromMutable),
                owner: FromMutable(fragment.Owner)
            );
        }
        
        public static CreateCredentialStatement FromMutable(ScriptDom.CreateCredentialStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateCredentialStatement))) { throw new NotImplementedException("Unexpected subtype of CreateCredentialStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateCredentialStatement(
                cryptographicProviderName: FromMutable(fragment.CryptographicProviderName),
                name: FromMutable(fragment.Name),
                identity: FromMutable(fragment.Identity),
                secret: FromMutable(fragment.Secret),
                isDatabaseScoped: fragment.IsDatabaseScoped
            );
        }
        
        public static CreateCryptographicProviderStatement FromMutable(ScriptDom.CreateCryptographicProviderStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateCryptographicProviderStatement))) { throw new NotImplementedException("Unexpected subtype of CreateCryptographicProviderStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateCryptographicProviderStatement(
                name: FromMutable(fragment.Name),
                file: FromMutable(fragment.File)
            );
        }
        
        public static CreateDatabaseAuditSpecificationStatement FromMutable(ScriptDom.CreateDatabaseAuditSpecificationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateDatabaseAuditSpecificationStatement))) { throw new NotImplementedException("Unexpected subtype of CreateDatabaseAuditSpecificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateDatabaseAuditSpecificationStatement(
                auditState: fragment.AuditState,
                parts: fragment.Parts.SelectList(FromMutable),
                specificationName: FromMutable(fragment.SpecificationName),
                auditName: FromMutable(fragment.AuditName)
            );
        }
        
        public static CreateDatabaseEncryptionKeyStatement FromMutable(ScriptDom.CreateDatabaseEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateDatabaseEncryptionKeyStatement))) { throw new NotImplementedException("Unexpected subtype of CreateDatabaseEncryptionKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateDatabaseEncryptionKeyStatement(
                encryptor: FromMutable(fragment.Encryptor),
                algorithm: fragment.Algorithm
            );
        }
        
        public static CreateDatabaseStatement FromMutable(ScriptDom.CreateDatabaseStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateDatabaseStatement))) { throw new NotImplementedException("Unexpected subtype of CreateDatabaseStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateDatabaseStatement(
                databaseName: FromMutable(fragment.DatabaseName),
                containment: FromMutable(fragment.Containment),
                fileGroups: fragment.FileGroups.SelectList(FromMutable),
                logOn: fragment.LogOn.SelectList(FromMutable),
                options: fragment.Options.SelectList(FromMutable),
                attachMode: fragment.AttachMode,
                databaseSnapshot: FromMutable(fragment.DatabaseSnapshot),
                copyOf: FromMutable(fragment.CopyOf),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static CreateDefaultStatement FromMutable(ScriptDom.CreateDefaultStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateDefaultStatement))) { throw new NotImplementedException("Unexpected subtype of CreateDefaultStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateDefaultStatement(
                name: FromMutable(fragment.Name),
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static CreateEndpointStatement FromMutable(ScriptDom.CreateEndpointStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateEndpointStatement))) { throw new NotImplementedException("Unexpected subtype of CreateEndpointStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateEndpointStatement(
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name),
                state: fragment.State,
                affinity: FromMutable(fragment.Affinity),
                protocol: fragment.Protocol,
                protocolOptions: fragment.ProtocolOptions.SelectList(FromMutable),
                endpointType: fragment.EndpointType,
                payloadOptions: fragment.PayloadOptions.SelectList(FromMutable)
            );
        }
        
        public static CreateEventNotificationStatement FromMutable(ScriptDom.CreateEventNotificationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateEventNotificationStatement))) { throw new NotImplementedException("Unexpected subtype of CreateEventNotificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateEventNotificationStatement(
                name: FromMutable(fragment.Name),
                scope: FromMutable(fragment.Scope),
                withFanIn: fragment.WithFanIn,
                eventTypeGroups: fragment.EventTypeGroups.SelectList(FromMutable),
                brokerService: FromMutable(fragment.BrokerService),
                brokerInstanceSpecifier: FromMutable(fragment.BrokerInstanceSpecifier)
            );
        }
        
        public static CreateEventSessionStatement FromMutable(ScriptDom.CreateEventSessionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateEventSessionStatement))) { throw new NotImplementedException("Unexpected subtype of CreateEventSessionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateEventSessionStatement(
                name: FromMutable(fragment.Name),
                sessionScope: fragment.SessionScope,
                eventDeclarations: fragment.EventDeclarations.SelectList(FromMutable),
                targetDeclarations: fragment.TargetDeclarations.SelectList(FromMutable),
                sessionOptions: fragment.SessionOptions.SelectList(FromMutable)
            );
        }
        
        public static CreateExternalDataSourceStatement FromMutable(ScriptDom.CreateExternalDataSourceStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateExternalDataSourceStatement))) { throw new NotImplementedException("Unexpected subtype of CreateExternalDataSourceStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateExternalDataSourceStatement(
                name: FromMutable(fragment.Name),
                dataSourceType: fragment.DataSourceType,
                location: FromMutable(fragment.Location),
                pushdownOption: fragment.PushdownOption,
                externalDataSourceOptions: fragment.ExternalDataSourceOptions.SelectList(FromMutable)
            );
        }
        
        public static CreateExternalFileFormatStatement FromMutable(ScriptDom.CreateExternalFileFormatStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateExternalFileFormatStatement))) { throw new NotImplementedException("Unexpected subtype of CreateExternalFileFormatStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateExternalFileFormatStatement(
                name: FromMutable(fragment.Name),
                formatType: fragment.FormatType,
                externalFileFormatOptions: fragment.ExternalFileFormatOptions.SelectList(FromMutable)
            );
        }
        
        public static CreateExternalLanguageStatement FromMutable(ScriptDom.CreateExternalLanguageStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateExternalLanguageStatement))) { throw new NotImplementedException("Unexpected subtype of CreateExternalLanguageStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateExternalLanguageStatement(
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name),
                externalLanguageFiles: fragment.ExternalLanguageFiles.SelectList(FromMutable)
            );
        }
        
        public static CreateExternalLibraryStatement FromMutable(ScriptDom.CreateExternalLibraryStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateExternalLibraryStatement))) { throw new NotImplementedException("Unexpected subtype of CreateExternalLibraryStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateExternalLibraryStatement(
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name),
                language: FromMutable(fragment.Language),
                externalLibraryFiles: fragment.ExternalLibraryFiles.SelectList(FromMutable)
            );
        }
        
        public static CreateExternalResourcePoolStatement FromMutable(ScriptDom.CreateExternalResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateExternalResourcePoolStatement))) { throw new NotImplementedException("Unexpected subtype of CreateExternalResourcePoolStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateExternalResourcePoolStatement(
                name: FromMutable(fragment.Name),
                externalResourcePoolParameters: fragment.ExternalResourcePoolParameters.SelectList(FromMutable)
            );
        }
        
        public static CreateExternalStreamingJobStatement FromMutable(ScriptDom.CreateExternalStreamingJobStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateExternalStreamingJobStatement))) { throw new NotImplementedException("Unexpected subtype of CreateExternalStreamingJobStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateExternalStreamingJobStatement(
                name: FromMutable(fragment.Name),
                statement: FromMutable(fragment.Statement)
            );
        }
        
        public static CreateExternalStreamStatement FromMutable(ScriptDom.CreateExternalStreamStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateExternalStreamStatement))) { throw new NotImplementedException("Unexpected subtype of CreateExternalStreamStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateExternalStreamStatement(
                name: FromMutable(fragment.Name),
                location: FromMutable(fragment.Location),
                inputOptions: FromMutable(fragment.InputOptions),
                outputOptions: FromMutable(fragment.OutputOptions),
                externalStreamOptions: fragment.ExternalStreamOptions.SelectList(FromMutable)
            );
        }
        
        public static CreateExternalTableStatement FromMutable(ScriptDom.CreateExternalTableStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateExternalTableStatement))) { throw new NotImplementedException("Unexpected subtype of CreateExternalTableStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateExternalTableStatement(
                schemaObjectName: FromMutable(fragment.SchemaObjectName),
                columnDefinitions: fragment.ColumnDefinitions.SelectList(FromMutable),
                dataSource: FromMutable(fragment.DataSource),
                externalTableOptions: fragment.ExternalTableOptions.SelectList(FromMutable),
                selectStatement: FromMutable(fragment.SelectStatement)
            );
        }
        
        public static CreateFederationStatement FromMutable(ScriptDom.CreateFederationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateFederationStatement))) { throw new NotImplementedException("Unexpected subtype of CreateFederationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateFederationStatement(
                name: FromMutable(fragment.Name),
                distributionName: FromMutable(fragment.DistributionName),
                dataType: FromMutable(fragment.DataType)
            );
        }
        
        public static CreateFullTextCatalogStatement FromMutable(ScriptDom.CreateFullTextCatalogStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateFullTextCatalogStatement))) { throw new NotImplementedException("Unexpected subtype of CreateFullTextCatalogStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateFullTextCatalogStatement(
                fileGroup: FromMutable(fragment.FileGroup),
                path: FromMutable(fragment.Path),
                isDefault: fragment.IsDefault,
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static CreateFullTextIndexStatement FromMutable(ScriptDom.CreateFullTextIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateFullTextIndexStatement))) { throw new NotImplementedException("Unexpected subtype of CreateFullTextIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateFullTextIndexStatement(
                onName: FromMutable(fragment.OnName),
                fullTextIndexColumns: fragment.FullTextIndexColumns.SelectList(FromMutable),
                keyIndexName: FromMutable(fragment.KeyIndexName),
                catalogAndFileGroup: FromMutable(fragment.CatalogAndFileGroup),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static CreateFullTextStopListStatement FromMutable(ScriptDom.CreateFullTextStopListStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateFullTextStopListStatement))) { throw new NotImplementedException("Unexpected subtype of CreateFullTextStopListStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateFullTextStopListStatement(
                name: FromMutable(fragment.Name),
                isSystemStopList: fragment.IsSystemStopList,
                databaseName: FromMutable(fragment.DatabaseName),
                sourceStopListName: FromMutable(fragment.SourceStopListName),
                owner: FromMutable(fragment.Owner)
            );
        }
        
        public static CreateFunctionStatement FromMutable(ScriptDom.CreateFunctionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateFunctionStatement))) { throw new NotImplementedException("Unexpected subtype of CreateFunctionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateFunctionStatement(
                name: FromMutable(fragment.Name),
                returnType: FromMutable(fragment.ReturnType),
                options: fragment.Options.SelectList(FromMutable),
                orderHint: FromMutable(fragment.OrderHint),
                parameters: fragment.Parameters.SelectList(FromMutable),
                statementList: FromMutable(fragment.StatementList),
                methodSpecifier: FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static CreateIndexStatement FromMutable(ScriptDom.CreateIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateIndexStatement))) { throw new NotImplementedException("Unexpected subtype of CreateIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateIndexStatement(
                translated80SyntaxTo90: fragment.Translated80SyntaxTo90,
                unique: fragment.Unique,
                clustered: fragment.Clustered,
                columns: fragment.Columns.SelectList(FromMutable),
                includeColumns: fragment.IncludeColumns.SelectList(FromMutable),
                onFileGroupOrPartitionScheme: FromMutable(fragment.OnFileGroupOrPartitionScheme),
                filterPredicate: FromMutable(fragment.FilterPredicate),
                fileStreamOn: FromMutable(fragment.FileStreamOn),
                name: FromMutable(fragment.Name),
                onName: FromMutable(fragment.OnName),
                indexOptions: fragment.IndexOptions.SelectList(FromMutable)
            );
        }
        
        public static CreateLoginStatement FromMutable(ScriptDom.CreateLoginStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateLoginStatement))) { throw new NotImplementedException("Unexpected subtype of CreateLoginStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateLoginStatement(
                name: FromMutable(fragment.Name),
                source: FromMutable(fragment.Source)
            );
        }
        
        public static CreateMasterKeyStatement FromMutable(ScriptDom.CreateMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateMasterKeyStatement))) { throw new NotImplementedException("Unexpected subtype of CreateMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateMasterKeyStatement(
                password: FromMutable(fragment.Password)
            );
        }
        
        public static CreateMessageTypeStatement FromMutable(ScriptDom.CreateMessageTypeStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateMessageTypeStatement))) { throw new NotImplementedException("Unexpected subtype of CreateMessageTypeStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateMessageTypeStatement(
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name),
                validationMethod: fragment.ValidationMethod,
                xmlSchemaCollectionName: FromMutable(fragment.XmlSchemaCollectionName)
            );
        }
        
        public static CreateOrAlterFunctionStatement FromMutable(ScriptDom.CreateOrAlterFunctionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateOrAlterFunctionStatement))) { throw new NotImplementedException("Unexpected subtype of CreateOrAlterFunctionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateOrAlterFunctionStatement(
                name: FromMutable(fragment.Name),
                returnType: FromMutable(fragment.ReturnType),
                options: fragment.Options.SelectList(FromMutable),
                orderHint: FromMutable(fragment.OrderHint),
                parameters: fragment.Parameters.SelectList(FromMutable),
                statementList: FromMutable(fragment.StatementList),
                methodSpecifier: FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static CreateOrAlterProcedureStatement FromMutable(ScriptDom.CreateOrAlterProcedureStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateOrAlterProcedureStatement))) { throw new NotImplementedException("Unexpected subtype of CreateOrAlterProcedureStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateOrAlterProcedureStatement(
                procedureReference: FromMutable(fragment.ProcedureReference),
                isForReplication: fragment.IsForReplication,
                options: fragment.Options.SelectList(FromMutable),
                parameters: fragment.Parameters.SelectList(FromMutable),
                statementList: FromMutable(fragment.StatementList),
                methodSpecifier: FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static CreateOrAlterTriggerStatement FromMutable(ScriptDom.CreateOrAlterTriggerStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateOrAlterTriggerStatement))) { throw new NotImplementedException("Unexpected subtype of CreateOrAlterTriggerStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateOrAlterTriggerStatement(
                name: FromMutable(fragment.Name),
                triggerObject: FromMutable(fragment.TriggerObject),
                options: fragment.Options.SelectList(FromMutable),
                triggerType: fragment.TriggerType,
                triggerActions: fragment.TriggerActions.SelectList(FromMutable),
                withAppend: fragment.WithAppend,
                isNotForReplication: fragment.IsNotForReplication,
                statementList: FromMutable(fragment.StatementList),
                methodSpecifier: FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static CreateOrAlterViewStatement FromMutable(ScriptDom.CreateOrAlterViewStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateOrAlterViewStatement))) { throw new NotImplementedException("Unexpected subtype of CreateOrAlterViewStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateOrAlterViewStatement(
                schemaObjectName: FromMutable(fragment.SchemaObjectName),
                columns: fragment.Columns.SelectList(FromMutable),
                viewOptions: fragment.ViewOptions.SelectList(FromMutable),
                selectStatement: FromMutable(fragment.SelectStatement),
                withCheckOption: fragment.WithCheckOption,
                isMaterialized: fragment.IsMaterialized
            );
        }
        
        public static CreatePartitionFunctionStatement FromMutable(ScriptDom.CreatePartitionFunctionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreatePartitionFunctionStatement))) { throw new NotImplementedException("Unexpected subtype of CreatePartitionFunctionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreatePartitionFunctionStatement(
                name: FromMutable(fragment.Name),
                parameterType: FromMutable(fragment.ParameterType),
                range: fragment.Range,
                boundaryValues: fragment.BoundaryValues.SelectList(FromMutable)
            );
        }
        
        public static CreatePartitionSchemeStatement FromMutable(ScriptDom.CreatePartitionSchemeStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreatePartitionSchemeStatement))) { throw new NotImplementedException("Unexpected subtype of CreatePartitionSchemeStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreatePartitionSchemeStatement(
                name: FromMutable(fragment.Name),
                partitionFunction: FromMutable(fragment.PartitionFunction),
                isAll: fragment.IsAll,
                fileGroups: fragment.FileGroups.SelectList(FromMutable)
            );
        }
        
        public static CreateProcedureStatement FromMutable(ScriptDom.CreateProcedureStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateProcedureStatement))) { throw new NotImplementedException("Unexpected subtype of CreateProcedureStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateProcedureStatement(
                procedureReference: FromMutable(fragment.ProcedureReference),
                isForReplication: fragment.IsForReplication,
                options: fragment.Options.SelectList(FromMutable),
                parameters: fragment.Parameters.SelectList(FromMutable),
                statementList: FromMutable(fragment.StatementList),
                methodSpecifier: FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static CreateQueueStatement FromMutable(ScriptDom.CreateQueueStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateQueueStatement))) { throw new NotImplementedException("Unexpected subtype of CreateQueueStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateQueueStatement(
                onFileGroup: FromMutable(fragment.OnFileGroup),
                name: FromMutable(fragment.Name),
                queueOptions: fragment.QueueOptions.SelectList(FromMutable)
            );
        }
        
        public static CreateRemoteServiceBindingStatement FromMutable(ScriptDom.CreateRemoteServiceBindingStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateRemoteServiceBindingStatement))) { throw new NotImplementedException("Unexpected subtype of CreateRemoteServiceBindingStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateRemoteServiceBindingStatement(
                service: FromMutable(fragment.Service),
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static CreateResourcePoolStatement FromMutable(ScriptDom.CreateResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateResourcePoolStatement))) { throw new NotImplementedException("Unexpected subtype of CreateResourcePoolStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateResourcePoolStatement(
                name: FromMutable(fragment.Name),
                resourcePoolParameters: fragment.ResourcePoolParameters.SelectList(FromMutable)
            );
        }
        
        public static CreateRoleStatement FromMutable(ScriptDom.CreateRoleStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateRoleStatement))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as CreateRoleStatement; }
            return new CreateRoleStatement(
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name)
            );
        }
        
        public static CreateRouteStatement FromMutable(ScriptDom.CreateRouteStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateRouteStatement))) { throw new NotImplementedException("Unexpected subtype of CreateRouteStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateRouteStatement(
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name),
                routeOptions: fragment.RouteOptions.SelectList(FromMutable)
            );
        }
        
        public static CreateRuleStatement FromMutable(ScriptDom.CreateRuleStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateRuleStatement))) { throw new NotImplementedException("Unexpected subtype of CreateRuleStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateRuleStatement(
                name: FromMutable(fragment.Name),
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static CreateSchemaStatement FromMutable(ScriptDom.CreateSchemaStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateSchemaStatement))) { throw new NotImplementedException("Unexpected subtype of CreateSchemaStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSchemaStatement(
                name: FromMutable(fragment.Name),
                statementList: FromMutable(fragment.StatementList),
                owner: FromMutable(fragment.Owner)
            );
        }
        
        public static CreateSearchPropertyListStatement FromMutable(ScriptDom.CreateSearchPropertyListStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateSearchPropertyListStatement))) { throw new NotImplementedException("Unexpected subtype of CreateSearchPropertyListStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSearchPropertyListStatement(
                name: FromMutable(fragment.Name),
                sourceSearchPropertyList: FromMutable(fragment.SourceSearchPropertyList),
                owner: FromMutable(fragment.Owner)
            );
        }
        
        public static CreateSecurityPolicyStatement FromMutable(ScriptDom.CreateSecurityPolicyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateSecurityPolicyStatement))) { throw new NotImplementedException("Unexpected subtype of CreateSecurityPolicyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSecurityPolicyStatement(
                name: FromMutable(fragment.Name),
                notForReplication: fragment.NotForReplication,
                securityPolicyOptions: fragment.SecurityPolicyOptions.SelectList(FromMutable),
                securityPredicateActions: fragment.SecurityPredicateActions.SelectList(FromMutable),
                actionType: fragment.ActionType
            );
        }
        
        public static CreateSelectiveXmlIndexStatement FromMutable(ScriptDom.CreateSelectiveXmlIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateSelectiveXmlIndexStatement))) { throw new NotImplementedException("Unexpected subtype of CreateSelectiveXmlIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSelectiveXmlIndexStatement(
                isSecondary: fragment.IsSecondary,
                xmlColumn: FromMutable(fragment.XmlColumn),
                promotedPaths: fragment.PromotedPaths.SelectList(FromMutable),
                xmlNamespaces: FromMutable(fragment.XmlNamespaces),
                usingXmlIndexName: FromMutable(fragment.UsingXmlIndexName),
                pathName: FromMutable(fragment.PathName),
                name: FromMutable(fragment.Name),
                onName: FromMutable(fragment.OnName),
                indexOptions: fragment.IndexOptions.SelectList(FromMutable)
            );
        }
        
        public static CreateSequenceStatement FromMutable(ScriptDom.CreateSequenceStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateSequenceStatement))) { throw new NotImplementedException("Unexpected subtype of CreateSequenceStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSequenceStatement(
                name: FromMutable(fragment.Name),
                sequenceOptions: fragment.SequenceOptions.SelectList(FromMutable)
            );
        }
        
        public static CreateServerAuditSpecificationStatement FromMutable(ScriptDom.CreateServerAuditSpecificationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateServerAuditSpecificationStatement))) { throw new NotImplementedException("Unexpected subtype of CreateServerAuditSpecificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateServerAuditSpecificationStatement(
                auditState: fragment.AuditState,
                parts: fragment.Parts.SelectList(FromMutable),
                specificationName: FromMutable(fragment.SpecificationName),
                auditName: FromMutable(fragment.AuditName)
            );
        }
        
        public static CreateServerAuditStatement FromMutable(ScriptDom.CreateServerAuditStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateServerAuditStatement))) { throw new NotImplementedException("Unexpected subtype of CreateServerAuditStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateServerAuditStatement(
                auditName: FromMutable(fragment.AuditName),
                auditTarget: FromMutable(fragment.AuditTarget),
                options: fragment.Options.SelectList(FromMutable),
                predicateExpression: FromMutable(fragment.PredicateExpression)
            );
        }
        
        public static CreateServerRoleStatement FromMutable(ScriptDom.CreateServerRoleStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateServerRoleStatement))) { throw new NotImplementedException("Unexpected subtype of CreateServerRoleStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateServerRoleStatement(
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name)
            );
        }
        
        public static CreateServiceStatement FromMutable(ScriptDom.CreateServiceStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateServiceStatement))) { throw new NotImplementedException("Unexpected subtype of CreateServiceStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateServiceStatement(
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name),
                queueName: FromMutable(fragment.QueueName),
                serviceContracts: fragment.ServiceContracts.SelectList(FromMutable)
            );
        }
        
        public static CreateSpatialIndexStatement FromMutable(ScriptDom.CreateSpatialIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateSpatialIndexStatement))) { throw new NotImplementedException("Unexpected subtype of CreateSpatialIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSpatialIndexStatement(
                name: FromMutable(fragment.Name),
                @object: FromMutable(fragment.Object),
                spatialColumnName: FromMutable(fragment.SpatialColumnName),
                spatialIndexingScheme: fragment.SpatialIndexingScheme,
                spatialIndexOptions: fragment.SpatialIndexOptions.SelectList(FromMutable),
                onFileGroup: FromMutable(fragment.OnFileGroup)
            );
        }
        
        public static CreateStatisticsStatement FromMutable(ScriptDom.CreateStatisticsStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateStatisticsStatement))) { throw new NotImplementedException("Unexpected subtype of CreateStatisticsStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateStatisticsStatement(
                name: FromMutable(fragment.Name),
                onName: FromMutable(fragment.OnName),
                columns: fragment.Columns.SelectList(FromMutable),
                statisticsOptions: fragment.StatisticsOptions.SelectList(FromMutable),
                filterPredicate: FromMutable(fragment.FilterPredicate)
            );
        }
        
        public static CreateSymmetricKeyStatement FromMutable(ScriptDom.CreateSymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateSymmetricKeyStatement))) { throw new NotImplementedException("Unexpected subtype of CreateSymmetricKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSymmetricKeyStatement(
                keyOptions: fragment.KeyOptions.SelectList(FromMutable),
                provider: FromMutable(fragment.Provider),
                owner: FromMutable(fragment.Owner),
                name: FromMutable(fragment.Name),
                encryptingMechanisms: fragment.EncryptingMechanisms.SelectList(FromMutable)
            );
        }
        
        public static CreateSynonymStatement FromMutable(ScriptDom.CreateSynonymStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateSynonymStatement))) { throw new NotImplementedException("Unexpected subtype of CreateSynonymStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSynonymStatement(
                name: FromMutable(fragment.Name),
                forName: FromMutable(fragment.ForName)
            );
        }
        
        public static CreateTableStatement FromMutable(ScriptDom.CreateTableStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateTableStatement))) { throw new NotImplementedException("Unexpected subtype of CreateTableStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateTableStatement(
                schemaObjectName: FromMutable(fragment.SchemaObjectName),
                asEdge: fragment.AsEdge,
                asFileTable: fragment.AsFileTable,
                asNode: fragment.AsNode,
                definition: FromMutable(fragment.Definition),
                onFileGroupOrPartitionScheme: FromMutable(fragment.OnFileGroupOrPartitionScheme),
                federationScheme: FromMutable(fragment.FederationScheme),
                textImageOn: FromMutable(fragment.TextImageOn),
                options: fragment.Options.SelectList(FromMutable),
                selectStatement: FromMutable(fragment.SelectStatement),
                ctasColumns: fragment.CtasColumns.SelectList(FromMutable),
                fileStreamOn: FromMutable(fragment.FileStreamOn)
            );
        }
        
        public static CreateTriggerStatement FromMutable(ScriptDom.CreateTriggerStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateTriggerStatement))) { throw new NotImplementedException("Unexpected subtype of CreateTriggerStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateTriggerStatement(
                name: FromMutable(fragment.Name),
                triggerObject: FromMutable(fragment.TriggerObject),
                options: fragment.Options.SelectList(FromMutable),
                triggerType: fragment.TriggerType,
                triggerActions: fragment.TriggerActions.SelectList(FromMutable),
                withAppend: fragment.WithAppend,
                isNotForReplication: fragment.IsNotForReplication,
                statementList: FromMutable(fragment.StatementList),
                methodSpecifier: FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static CreateTypeTableStatement FromMutable(ScriptDom.CreateTypeTableStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateTypeTableStatement))) { throw new NotImplementedException("Unexpected subtype of CreateTypeTableStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateTypeTableStatement(
                definition: FromMutable(fragment.Definition),
                options: fragment.Options.SelectList(FromMutable),
                name: FromMutable(fragment.Name)
            );
        }
        
        public static CreateTypeUddtStatement FromMutable(ScriptDom.CreateTypeUddtStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateTypeUddtStatement))) { throw new NotImplementedException("Unexpected subtype of CreateTypeUddtStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateTypeUddtStatement(
                dataType: FromMutable(fragment.DataType),
                nullableConstraint: FromMutable(fragment.NullableConstraint),
                name: FromMutable(fragment.Name)
            );
        }
        
        public static CreateTypeUdtStatement FromMutable(ScriptDom.CreateTypeUdtStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateTypeUdtStatement))) { throw new NotImplementedException("Unexpected subtype of CreateTypeUdtStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateTypeUdtStatement(
                assemblyName: FromMutable(fragment.AssemblyName),
                name: FromMutable(fragment.Name)
            );
        }
        
        public static CreateUserStatement FromMutable(ScriptDom.CreateUserStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateUserStatement))) { throw new NotImplementedException("Unexpected subtype of CreateUserStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateUserStatement(
                userLoginOption: FromMutable(fragment.UserLoginOption),
                name: FromMutable(fragment.Name),
                userOptions: fragment.UserOptions.SelectList(FromMutable)
            );
        }
        
        public static CreateViewStatement FromMutable(ScriptDom.CreateViewStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateViewStatement))) { throw new NotImplementedException("Unexpected subtype of CreateViewStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateViewStatement(
                schemaObjectName: FromMutable(fragment.SchemaObjectName),
                columns: fragment.Columns.SelectList(FromMutable),
                viewOptions: fragment.ViewOptions.SelectList(FromMutable),
                selectStatement: FromMutable(fragment.SelectStatement),
                withCheckOption: fragment.WithCheckOption,
                isMaterialized: fragment.IsMaterialized
            );
        }
        
        public static CreateWorkloadClassifierStatement FromMutable(ScriptDom.CreateWorkloadClassifierStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateWorkloadClassifierStatement))) { throw new NotImplementedException("Unexpected subtype of CreateWorkloadClassifierStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateWorkloadClassifierStatement(
                classifierName: FromMutable(fragment.ClassifierName),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static CreateWorkloadGroupStatement FromMutable(ScriptDom.CreateWorkloadGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateWorkloadGroupStatement))) { throw new NotImplementedException("Unexpected subtype of CreateWorkloadGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateWorkloadGroupStatement(
                name: FromMutable(fragment.Name),
                workloadGroupParameters: fragment.WorkloadGroupParameters.SelectList(FromMutable),
                poolName: FromMutable(fragment.PoolName),
                externalPoolName: FromMutable(fragment.ExternalPoolName)
            );
        }
        
        public static CreateXmlIndexStatement FromMutable(ScriptDom.CreateXmlIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateXmlIndexStatement))) { throw new NotImplementedException("Unexpected subtype of CreateXmlIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateXmlIndexStatement(
                primary: fragment.Primary,
                xmlColumn: FromMutable(fragment.XmlColumn),
                secondaryXmlIndexName: FromMutable(fragment.SecondaryXmlIndexName),
                secondaryXmlIndexType: fragment.SecondaryXmlIndexType,
                onFileGroupOrPartitionScheme: FromMutable(fragment.OnFileGroupOrPartitionScheme),
                name: FromMutable(fragment.Name),
                onName: FromMutable(fragment.OnName),
                indexOptions: fragment.IndexOptions.SelectList(FromMutable)
            );
        }
        
        public static CreateXmlSchemaCollectionStatement FromMutable(ScriptDom.CreateXmlSchemaCollectionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreateXmlSchemaCollectionStatement))) { throw new NotImplementedException("Unexpected subtype of CreateXmlSchemaCollectionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateXmlSchemaCollectionStatement(
                name: FromMutable(fragment.Name),
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static CreationDispositionKeyOption FromMutable(ScriptDom.CreationDispositionKeyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CreationDispositionKeyOption))) { throw new NotImplementedException("Unexpected subtype of CreationDispositionKeyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreationDispositionKeyOption(
                isCreateNew: fragment.IsCreateNew,
                optionKind: fragment.OptionKind
            );
        }
        
        public static CryptoMechanism FromMutable(ScriptDom.CryptoMechanism fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CryptoMechanism))) { throw new NotImplementedException("Unexpected subtype of CryptoMechanism not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CryptoMechanism(
                cryptoMechanismType: fragment.CryptoMechanismType,
                identifier: FromMutable(fragment.Identifier),
                passwordOrSignature: FromMutable(fragment.PasswordOrSignature)
            );
        }
        
        public static CubeGroupingSpecification FromMutable(ScriptDom.CubeGroupingSpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CubeGroupingSpecification))) { throw new NotImplementedException("Unexpected subtype of CubeGroupingSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CubeGroupingSpecification(
                arguments: fragment.Arguments.SelectList(FromMutable)
            );
        }
        
        public static CursorDefaultDatabaseOption FromMutable(ScriptDom.CursorDefaultDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CursorDefaultDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of CursorDefaultDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CursorDefaultDatabaseOption(
                isLocal: fragment.IsLocal,
                optionKind: fragment.OptionKind
            );
        }
        
        public static CursorDefinition FromMutable(ScriptDom.CursorDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CursorDefinition))) { throw new NotImplementedException("Unexpected subtype of CursorDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CursorDefinition(
                options: fragment.Options.SelectList(FromMutable),
                select: FromMutable(fragment.Select)
            );
        }
        
        public static CursorId FromMutable(ScriptDom.CursorId fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CursorId))) { throw new NotImplementedException("Unexpected subtype of CursorId not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CursorId(
                isGlobal: fragment.IsGlobal,
                name: FromMutable(fragment.Name)
            );
        }
        
        public static CursorOption FromMutable(ScriptDom.CursorOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.CursorOption))) { throw new NotImplementedException("Unexpected subtype of CursorOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CursorOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static DatabaseAuditAction FromMutable(ScriptDom.DatabaseAuditAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DatabaseAuditAction))) { throw new NotImplementedException("Unexpected subtype of DatabaseAuditAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DatabaseAuditAction(
                actionKind: fragment.ActionKind
            );
        }
        
        public static DatabaseConfigurationClearOption FromMutable(ScriptDom.DatabaseConfigurationClearOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DatabaseConfigurationClearOption))) { throw new NotImplementedException("Unexpected subtype of DatabaseConfigurationClearOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DatabaseConfigurationClearOption(
                optionKind: fragment.OptionKind,
                planHandle: FromMutable(fragment.PlanHandle)
            );
        }
        
        public static DatabaseConfigurationSetOption FromMutable(ScriptDom.DatabaseConfigurationSetOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DatabaseConfigurationSetOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as DatabaseConfigurationSetOption; }
            return new DatabaseConfigurationSetOption(
                optionKind: fragment.OptionKind,
                genericOptionKind: FromMutable(fragment.GenericOptionKind)
            );
        }
        
        public static DatabaseOption FromMutable(ScriptDom.DatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DatabaseOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as DatabaseOption; }
            return new DatabaseOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static DataCompressionOption FromMutable(ScriptDom.DataCompressionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DataCompressionOption))) { throw new NotImplementedException("Unexpected subtype of DataCompressionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DataCompressionOption(
                compressionLevel: fragment.CompressionLevel,
                partitionRanges: fragment.PartitionRanges.SelectList(FromMutable),
                optionKind: fragment.OptionKind
            );
        }
        
        public static DataModificationTableReference FromMutable(ScriptDom.DataModificationTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DataModificationTableReference))) { throw new NotImplementedException("Unexpected subtype of DataModificationTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DataModificationTableReference(
                dataModificationSpecification: FromMutable(fragment.DataModificationSpecification),
                columns: fragment.Columns.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static DataRetentionTableOption FromMutable(ScriptDom.DataRetentionTableOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DataRetentionTableOption))) { throw new NotImplementedException("Unexpected subtype of DataRetentionTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DataRetentionTableOption(
                optionState: fragment.OptionState,
                filterColumn: FromMutable(fragment.FilterColumn),
                retentionPeriod: FromMutable(fragment.RetentionPeriod),
                optionKind: fragment.OptionKind
            );
        }
        
        public static DataTypeSequenceOption FromMutable(ScriptDom.DataTypeSequenceOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DataTypeSequenceOption))) { throw new NotImplementedException("Unexpected subtype of DataTypeSequenceOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DataTypeSequenceOption(
                dataType: FromMutable(fragment.DataType),
                optionKind: fragment.OptionKind,
                noValue: fragment.NoValue
            );
        }
        
        public static DbccNamedLiteral FromMutable(ScriptDom.DbccNamedLiteral fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DbccNamedLiteral))) { throw new NotImplementedException("Unexpected subtype of DbccNamedLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DbccNamedLiteral(
                name: fragment.Name,
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static DbccOption FromMutable(ScriptDom.DbccOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DbccOption))) { throw new NotImplementedException("Unexpected subtype of DbccOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DbccOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static DbccStatement FromMutable(ScriptDom.DbccStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DbccStatement))) { throw new NotImplementedException("Unexpected subtype of DbccStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DbccStatement(
                dllName: fragment.DllName,
                command: fragment.Command,
                parenthesisRequired: fragment.ParenthesisRequired,
                literals: fragment.Literals.SelectList(FromMutable),
                options: fragment.Options.SelectList(FromMutable),
                optionsUseJoin: fragment.OptionsUseJoin
            );
        }
        
        public static DeallocateCursorStatement FromMutable(ScriptDom.DeallocateCursorStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DeallocateCursorStatement))) { throw new NotImplementedException("Unexpected subtype of DeallocateCursorStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DeallocateCursorStatement(
                cursor: FromMutable(fragment.Cursor)
            );
        }
        
        public static DeclareCursorStatement FromMutable(ScriptDom.DeclareCursorStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DeclareCursorStatement))) { throw new NotImplementedException("Unexpected subtype of DeclareCursorStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DeclareCursorStatement(
                name: FromMutable(fragment.Name),
                cursorDefinition: FromMutable(fragment.CursorDefinition)
            );
        }
        
        public static DeclareTableVariableBody FromMutable(ScriptDom.DeclareTableVariableBody fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DeclareTableVariableBody))) { throw new NotImplementedException("Unexpected subtype of DeclareTableVariableBody not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DeclareTableVariableBody(
                variableName: FromMutable(fragment.VariableName),
                asDefined: fragment.AsDefined,
                definition: FromMutable(fragment.Definition)
            );
        }
        
        public static DeclareTableVariableStatement FromMutable(ScriptDom.DeclareTableVariableStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DeclareTableVariableStatement))) { throw new NotImplementedException("Unexpected subtype of DeclareTableVariableStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DeclareTableVariableStatement(
                body: FromMutable(fragment.Body)
            );
        }
        
        public static DeclareVariableElement FromMutable(ScriptDom.DeclareVariableElement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DeclareVariableElement))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as DeclareVariableElement; }
            return new DeclareVariableElement(
                variableName: FromMutable(fragment.VariableName),
                dataType: FromMutable(fragment.DataType),
                nullable: FromMutable(fragment.Nullable),
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static DeclareVariableStatement FromMutable(ScriptDom.DeclareVariableStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DeclareVariableStatement))) { throw new NotImplementedException("Unexpected subtype of DeclareVariableStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DeclareVariableStatement(
                declarations: fragment.Declarations.SelectList(FromMutable)
            );
        }
        
        public static DefaultConstraintDefinition FromMutable(ScriptDom.DefaultConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DefaultConstraintDefinition))) { throw new NotImplementedException("Unexpected subtype of DefaultConstraintDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DefaultConstraintDefinition(
                expression: FromMutable(fragment.Expression),
                withValues: fragment.WithValues,
                column: FromMutable(fragment.Column),
                constraintIdentifier: FromMutable(fragment.ConstraintIdentifier)
            );
        }
        
        public static DefaultLiteral FromMutable(ScriptDom.DefaultLiteral fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DefaultLiteral))) { throw new NotImplementedException("Unexpected subtype of DefaultLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DefaultLiteral(
                @value: fragment.Value,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static DelayedDurabilityDatabaseOption FromMutable(ScriptDom.DelayedDurabilityDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DelayedDurabilityDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of DelayedDurabilityDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DelayedDurabilityDatabaseOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static DeleteMergeAction FromMutable(ScriptDom.DeleteMergeAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DeleteMergeAction))) { throw new NotImplementedException("Unexpected subtype of DeleteMergeAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DeleteMergeAction(
                
            );
        }
        
        public static DeleteSpecification FromMutable(ScriptDom.DeleteSpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DeleteSpecification))) { throw new NotImplementedException("Unexpected subtype of DeleteSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DeleteSpecification(
                fromClause: FromMutable(fragment.FromClause),
                whereClause: FromMutable(fragment.WhereClause),
                target: FromMutable(fragment.Target),
                topRowFilter: FromMutable(fragment.TopRowFilter),
                outputIntoClause: FromMutable(fragment.OutputIntoClause),
                outputClause: FromMutable(fragment.OutputClause)
            );
        }
        
        public static DeleteStatement FromMutable(ScriptDom.DeleteStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DeleteStatement))) { throw new NotImplementedException("Unexpected subtype of DeleteStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DeleteStatement(
                deleteSpecification: FromMutable(fragment.DeleteSpecification),
                withCtesAndXmlNamespaces: FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.SelectList(FromMutable)
            );
        }
        
        public static DenyStatement FromMutable(ScriptDom.DenyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DenyStatement))) { throw new NotImplementedException("Unexpected subtype of DenyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DenyStatement(
                cascadeOption: fragment.CascadeOption,
                permissions: fragment.Permissions.SelectList(FromMutable),
                securityTargetObject: FromMutable(fragment.SecurityTargetObject),
                principals: fragment.Principals.SelectList(FromMutable),
                asClause: FromMutable(fragment.AsClause)
            );
        }
        
        public static DenyStatement80 FromMutable(ScriptDom.DenyStatement80 fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DenyStatement80))) { throw new NotImplementedException("Unexpected subtype of DenyStatement80 not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DenyStatement80(
                cascadeOption: fragment.CascadeOption,
                securityElement80: FromMutable(fragment.SecurityElement80),
                securityUserClause80: FromMutable(fragment.SecurityUserClause80)
            );
        }
        
        public static DeviceInfo FromMutable(ScriptDom.DeviceInfo fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DeviceInfo))) { throw new NotImplementedException("Unexpected subtype of DeviceInfo not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DeviceInfo(
                logicalDevice: FromMutable(fragment.LogicalDevice),
                physicalDevice: FromMutable(fragment.PhysicalDevice),
                deviceType: fragment.DeviceType
            );
        }
        
        public static DiskStatement FromMutable(ScriptDom.DiskStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DiskStatement))) { throw new NotImplementedException("Unexpected subtype of DiskStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DiskStatement(
                diskStatementType: fragment.DiskStatementType,
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static DiskStatementOption FromMutable(ScriptDom.DiskStatementOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DiskStatementOption))) { throw new NotImplementedException("Unexpected subtype of DiskStatementOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DiskStatementOption(
                optionKind: fragment.OptionKind,
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static DistinctPredicate FromMutable(ScriptDom.DistinctPredicate fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DistinctPredicate))) { throw new NotImplementedException("Unexpected subtype of DistinctPredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DistinctPredicate(
                firstExpression: FromMutable(fragment.FirstExpression),
                secondExpression: FromMutable(fragment.SecondExpression),
                isNot: fragment.IsNot
            );
        }
        
        public static DropAggregateStatement FromMutable(ScriptDom.DropAggregateStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropAggregateStatement))) { throw new NotImplementedException("Unexpected subtype of DropAggregateStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropAggregateStatement(
                objects: fragment.Objects.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropAlterFullTextIndexAction FromMutable(ScriptDom.DropAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropAlterFullTextIndexAction))) { throw new NotImplementedException("Unexpected subtype of DropAlterFullTextIndexAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropAlterFullTextIndexAction(
                columns: fragment.Columns.SelectList(FromMutable),
                withNoPopulation: fragment.WithNoPopulation
            );
        }
        
        public static DropApplicationRoleStatement FromMutable(ScriptDom.DropApplicationRoleStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropApplicationRoleStatement))) { throw new NotImplementedException("Unexpected subtype of DropApplicationRoleStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropApplicationRoleStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropAssemblyStatement FromMutable(ScriptDom.DropAssemblyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropAssemblyStatement))) { throw new NotImplementedException("Unexpected subtype of DropAssemblyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropAssemblyStatement(
                withNoDependents: fragment.WithNoDependents,
                objects: fragment.Objects.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropAsymmetricKeyStatement FromMutable(ScriptDom.DropAsymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropAsymmetricKeyStatement))) { throw new NotImplementedException("Unexpected subtype of DropAsymmetricKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropAsymmetricKeyStatement(
                removeProviderKey: fragment.RemoveProviderKey,
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropAvailabilityGroupStatement FromMutable(ScriptDom.DropAvailabilityGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropAvailabilityGroupStatement))) { throw new NotImplementedException("Unexpected subtype of DropAvailabilityGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropAvailabilityGroupStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropBrokerPriorityStatement FromMutable(ScriptDom.DropBrokerPriorityStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropBrokerPriorityStatement))) { throw new NotImplementedException("Unexpected subtype of DropBrokerPriorityStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropBrokerPriorityStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropCertificateStatement FromMutable(ScriptDom.DropCertificateStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropCertificateStatement))) { throw new NotImplementedException("Unexpected subtype of DropCertificateStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropCertificateStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropClusteredConstraintMoveOption FromMutable(ScriptDom.DropClusteredConstraintMoveOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropClusteredConstraintMoveOption))) { throw new NotImplementedException("Unexpected subtype of DropClusteredConstraintMoveOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropClusteredConstraintMoveOption(
                optionValue: FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind
            );
        }
        
        public static DropClusteredConstraintStateOption FromMutable(ScriptDom.DropClusteredConstraintStateOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropClusteredConstraintStateOption))) { throw new NotImplementedException("Unexpected subtype of DropClusteredConstraintStateOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropClusteredConstraintStateOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static DropClusteredConstraintValueOption FromMutable(ScriptDom.DropClusteredConstraintValueOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropClusteredConstraintValueOption))) { throw new NotImplementedException("Unexpected subtype of DropClusteredConstraintValueOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropClusteredConstraintValueOption(
                optionValue: FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind
            );
        }
        
        public static DropClusteredConstraintWaitAtLowPriorityLockOption FromMutable(ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption))) { throw new NotImplementedException("Unexpected subtype of DropClusteredConstraintWaitAtLowPriorityLockOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropClusteredConstraintWaitAtLowPriorityLockOption(
                options: fragment.Options.SelectList(FromMutable),
                optionKind: fragment.OptionKind
            );
        }
        
        public static DropColumnEncryptionKeyStatement FromMutable(ScriptDom.DropColumnEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropColumnEncryptionKeyStatement))) { throw new NotImplementedException("Unexpected subtype of DropColumnEncryptionKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropColumnEncryptionKeyStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropColumnMasterKeyStatement FromMutable(ScriptDom.DropColumnMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropColumnMasterKeyStatement))) { throw new NotImplementedException("Unexpected subtype of DropColumnMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropColumnMasterKeyStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropContractStatement FromMutable(ScriptDom.DropContractStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropContractStatement))) { throw new NotImplementedException("Unexpected subtype of DropContractStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropContractStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropCredentialStatement FromMutable(ScriptDom.DropCredentialStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropCredentialStatement))) { throw new NotImplementedException("Unexpected subtype of DropCredentialStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropCredentialStatement(
                isDatabaseScoped: fragment.IsDatabaseScoped,
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropCryptographicProviderStatement FromMutable(ScriptDom.DropCryptographicProviderStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropCryptographicProviderStatement))) { throw new NotImplementedException("Unexpected subtype of DropCryptographicProviderStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropCryptographicProviderStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropDatabaseAuditSpecificationStatement FromMutable(ScriptDom.DropDatabaseAuditSpecificationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropDatabaseAuditSpecificationStatement))) { throw new NotImplementedException("Unexpected subtype of DropDatabaseAuditSpecificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropDatabaseAuditSpecificationStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropDatabaseEncryptionKeyStatement FromMutable(ScriptDom.DropDatabaseEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropDatabaseEncryptionKeyStatement))) { throw new NotImplementedException("Unexpected subtype of DropDatabaseEncryptionKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropDatabaseEncryptionKeyStatement(
                
            );
        }
        
        public static DropDatabaseStatement FromMutable(ScriptDom.DropDatabaseStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropDatabaseStatement))) { throw new NotImplementedException("Unexpected subtype of DropDatabaseStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropDatabaseStatement(
                databases: fragment.Databases.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropDefaultStatement FromMutable(ScriptDom.DropDefaultStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropDefaultStatement))) { throw new NotImplementedException("Unexpected subtype of DropDefaultStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropDefaultStatement(
                objects: fragment.Objects.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropEndpointStatement FromMutable(ScriptDom.DropEndpointStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropEndpointStatement))) { throw new NotImplementedException("Unexpected subtype of DropEndpointStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropEndpointStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropEventNotificationStatement FromMutable(ScriptDom.DropEventNotificationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropEventNotificationStatement))) { throw new NotImplementedException("Unexpected subtype of DropEventNotificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropEventNotificationStatement(
                notifications: fragment.Notifications.SelectList(FromMutable),
                scope: FromMutable(fragment.Scope)
            );
        }
        
        public static DropEventSessionStatement FromMutable(ScriptDom.DropEventSessionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropEventSessionStatement))) { throw new NotImplementedException("Unexpected subtype of DropEventSessionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropEventSessionStatement(
                sessionScope: fragment.SessionScope,
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropExternalDataSourceStatement FromMutable(ScriptDom.DropExternalDataSourceStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropExternalDataSourceStatement))) { throw new NotImplementedException("Unexpected subtype of DropExternalDataSourceStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropExternalDataSourceStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropExternalFileFormatStatement FromMutable(ScriptDom.DropExternalFileFormatStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropExternalFileFormatStatement))) { throw new NotImplementedException("Unexpected subtype of DropExternalFileFormatStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropExternalFileFormatStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropExternalLanguageStatement FromMutable(ScriptDom.DropExternalLanguageStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropExternalLanguageStatement))) { throw new NotImplementedException("Unexpected subtype of DropExternalLanguageStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropExternalLanguageStatement(
                name: FromMutable(fragment.Name),
                owner: FromMutable(fragment.Owner)
            );
        }
        
        public static DropExternalLibraryStatement FromMutable(ScriptDom.DropExternalLibraryStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropExternalLibraryStatement))) { throw new NotImplementedException("Unexpected subtype of DropExternalLibraryStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropExternalLibraryStatement(
                name: FromMutable(fragment.Name),
                owner: FromMutable(fragment.Owner)
            );
        }
        
        public static DropExternalResourcePoolStatement FromMutable(ScriptDom.DropExternalResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropExternalResourcePoolStatement))) { throw new NotImplementedException("Unexpected subtype of DropExternalResourcePoolStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropExternalResourcePoolStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropExternalStreamingJobStatement FromMutable(ScriptDom.DropExternalStreamingJobStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropExternalStreamingJobStatement))) { throw new NotImplementedException("Unexpected subtype of DropExternalStreamingJobStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropExternalStreamingJobStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropExternalStreamStatement FromMutable(ScriptDom.DropExternalStreamStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropExternalStreamStatement))) { throw new NotImplementedException("Unexpected subtype of DropExternalStreamStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropExternalStreamStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropExternalTableStatement FromMutable(ScriptDom.DropExternalTableStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropExternalTableStatement))) { throw new NotImplementedException("Unexpected subtype of DropExternalTableStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropExternalTableStatement(
                objects: fragment.Objects.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropFederationStatement FromMutable(ScriptDom.DropFederationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropFederationStatement))) { throw new NotImplementedException("Unexpected subtype of DropFederationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropFederationStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropFullTextCatalogStatement FromMutable(ScriptDom.DropFullTextCatalogStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropFullTextCatalogStatement))) { throw new NotImplementedException("Unexpected subtype of DropFullTextCatalogStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropFullTextCatalogStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropFullTextIndexStatement FromMutable(ScriptDom.DropFullTextIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropFullTextIndexStatement))) { throw new NotImplementedException("Unexpected subtype of DropFullTextIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropFullTextIndexStatement(
                tableName: FromMutable(fragment.TableName)
            );
        }
        
        public static DropFullTextStopListStatement FromMutable(ScriptDom.DropFullTextStopListStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropFullTextStopListStatement))) { throw new NotImplementedException("Unexpected subtype of DropFullTextStopListStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropFullTextStopListStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropFunctionStatement FromMutable(ScriptDom.DropFunctionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropFunctionStatement))) { throw new NotImplementedException("Unexpected subtype of DropFunctionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropFunctionStatement(
                objects: fragment.Objects.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropIndexClause FromMutable(ScriptDom.DropIndexClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropIndexClause))) { throw new NotImplementedException("Unexpected subtype of DropIndexClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropIndexClause(
                index: FromMutable(fragment.Index),
                @object: FromMutable(fragment.Object),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static DropIndexStatement FromMutable(ScriptDom.DropIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropIndexStatement))) { throw new NotImplementedException("Unexpected subtype of DropIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropIndexStatement(
                dropIndexClauses: fragment.DropIndexClauses.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropLoginStatement FromMutable(ScriptDom.DropLoginStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropLoginStatement))) { throw new NotImplementedException("Unexpected subtype of DropLoginStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropLoginStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropMasterKeyStatement FromMutable(ScriptDom.DropMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropMasterKeyStatement))) { throw new NotImplementedException("Unexpected subtype of DropMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropMasterKeyStatement(
                
            );
        }
        
        public static DropMemberAlterRoleAction FromMutable(ScriptDom.DropMemberAlterRoleAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropMemberAlterRoleAction))) { throw new NotImplementedException("Unexpected subtype of DropMemberAlterRoleAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropMemberAlterRoleAction(
                member: FromMutable(fragment.Member)
            );
        }
        
        public static DropMessageTypeStatement FromMutable(ScriptDom.DropMessageTypeStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropMessageTypeStatement))) { throw new NotImplementedException("Unexpected subtype of DropMessageTypeStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropMessageTypeStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropPartitionFunctionStatement FromMutable(ScriptDom.DropPartitionFunctionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropPartitionFunctionStatement))) { throw new NotImplementedException("Unexpected subtype of DropPartitionFunctionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropPartitionFunctionStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropPartitionSchemeStatement FromMutable(ScriptDom.DropPartitionSchemeStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropPartitionSchemeStatement))) { throw new NotImplementedException("Unexpected subtype of DropPartitionSchemeStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropPartitionSchemeStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropProcedureStatement FromMutable(ScriptDom.DropProcedureStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropProcedureStatement))) { throw new NotImplementedException("Unexpected subtype of DropProcedureStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropProcedureStatement(
                objects: fragment.Objects.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropQueueStatement FromMutable(ScriptDom.DropQueueStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropQueueStatement))) { throw new NotImplementedException("Unexpected subtype of DropQueueStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropQueueStatement(
                name: FromMutable(fragment.Name)
            );
        }
        
        public static DropRemoteServiceBindingStatement FromMutable(ScriptDom.DropRemoteServiceBindingStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropRemoteServiceBindingStatement))) { throw new NotImplementedException("Unexpected subtype of DropRemoteServiceBindingStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropRemoteServiceBindingStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropResourcePoolStatement FromMutable(ScriptDom.DropResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropResourcePoolStatement))) { throw new NotImplementedException("Unexpected subtype of DropResourcePoolStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropResourcePoolStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropRoleStatement FromMutable(ScriptDom.DropRoleStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropRoleStatement))) { throw new NotImplementedException("Unexpected subtype of DropRoleStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropRoleStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropRouteStatement FromMutable(ScriptDom.DropRouteStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropRouteStatement))) { throw new NotImplementedException("Unexpected subtype of DropRouteStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropRouteStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropRuleStatement FromMutable(ScriptDom.DropRuleStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropRuleStatement))) { throw new NotImplementedException("Unexpected subtype of DropRuleStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropRuleStatement(
                objects: fragment.Objects.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropSchemaStatement FromMutable(ScriptDom.DropSchemaStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropSchemaStatement))) { throw new NotImplementedException("Unexpected subtype of DropSchemaStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSchemaStatement(
                schema: FromMutable(fragment.Schema),
                dropBehavior: fragment.DropBehavior,
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropSearchPropertyListAction FromMutable(ScriptDom.DropSearchPropertyListAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropSearchPropertyListAction))) { throw new NotImplementedException("Unexpected subtype of DropSearchPropertyListAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSearchPropertyListAction(
                propertyName: FromMutable(fragment.PropertyName)
            );
        }
        
        public static DropSearchPropertyListStatement FromMutable(ScriptDom.DropSearchPropertyListStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropSearchPropertyListStatement))) { throw new NotImplementedException("Unexpected subtype of DropSearchPropertyListStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSearchPropertyListStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropSecurityPolicyStatement FromMutable(ScriptDom.DropSecurityPolicyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropSecurityPolicyStatement))) { throw new NotImplementedException("Unexpected subtype of DropSecurityPolicyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSecurityPolicyStatement(
                objects: fragment.Objects.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropSensitivityClassificationStatement FromMutable(ScriptDom.DropSensitivityClassificationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropSensitivityClassificationStatement))) { throw new NotImplementedException("Unexpected subtype of DropSensitivityClassificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSensitivityClassificationStatement(
                columns: fragment.Columns.SelectList(FromMutable)
            );
        }
        
        public static DropSequenceStatement FromMutable(ScriptDom.DropSequenceStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropSequenceStatement))) { throw new NotImplementedException("Unexpected subtype of DropSequenceStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSequenceStatement(
                objects: fragment.Objects.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropServerAuditSpecificationStatement FromMutable(ScriptDom.DropServerAuditSpecificationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropServerAuditSpecificationStatement))) { throw new NotImplementedException("Unexpected subtype of DropServerAuditSpecificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropServerAuditSpecificationStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropServerAuditStatement FromMutable(ScriptDom.DropServerAuditStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropServerAuditStatement))) { throw new NotImplementedException("Unexpected subtype of DropServerAuditStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropServerAuditStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropServerRoleStatement FromMutable(ScriptDom.DropServerRoleStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropServerRoleStatement))) { throw new NotImplementedException("Unexpected subtype of DropServerRoleStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropServerRoleStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropServiceStatement FromMutable(ScriptDom.DropServiceStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropServiceStatement))) { throw new NotImplementedException("Unexpected subtype of DropServiceStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropServiceStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropSignatureStatement FromMutable(ScriptDom.DropSignatureStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropSignatureStatement))) { throw new NotImplementedException("Unexpected subtype of DropSignatureStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSignatureStatement(
                isCounter: fragment.IsCounter,
                elementKind: fragment.ElementKind,
                element: FromMutable(fragment.Element),
                cryptos: fragment.Cryptos.SelectList(FromMutable)
            );
        }
        
        public static DropStatisticsStatement FromMutable(ScriptDom.DropStatisticsStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropStatisticsStatement))) { throw new NotImplementedException("Unexpected subtype of DropStatisticsStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropStatisticsStatement(
                objects: fragment.Objects.SelectList(FromMutable)
            );
        }
        
        public static DropSymmetricKeyStatement FromMutable(ScriptDom.DropSymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropSymmetricKeyStatement))) { throw new NotImplementedException("Unexpected subtype of DropSymmetricKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSymmetricKeyStatement(
                removeProviderKey: fragment.RemoveProviderKey,
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropSynonymStatement FromMutable(ScriptDom.DropSynonymStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropSynonymStatement))) { throw new NotImplementedException("Unexpected subtype of DropSynonymStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSynonymStatement(
                objects: fragment.Objects.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropTableStatement FromMutable(ScriptDom.DropTableStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropTableStatement))) { throw new NotImplementedException("Unexpected subtype of DropTableStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropTableStatement(
                objects: fragment.Objects.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropTriggerStatement FromMutable(ScriptDom.DropTriggerStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropTriggerStatement))) { throw new NotImplementedException("Unexpected subtype of DropTriggerStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropTriggerStatement(
                triggerScope: fragment.TriggerScope,
                objects: fragment.Objects.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropTypeStatement FromMutable(ScriptDom.DropTypeStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropTypeStatement))) { throw new NotImplementedException("Unexpected subtype of DropTypeStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropTypeStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropUserStatement FromMutable(ScriptDom.DropUserStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropUserStatement))) { throw new NotImplementedException("Unexpected subtype of DropUserStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropUserStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropViewStatement FromMutable(ScriptDom.DropViewStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropViewStatement))) { throw new NotImplementedException("Unexpected subtype of DropViewStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropViewStatement(
                objects: fragment.Objects.SelectList(FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropWorkloadClassifierStatement FromMutable(ScriptDom.DropWorkloadClassifierStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropWorkloadClassifierStatement))) { throw new NotImplementedException("Unexpected subtype of DropWorkloadClassifierStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropWorkloadClassifierStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropWorkloadGroupStatement FromMutable(ScriptDom.DropWorkloadGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropWorkloadGroupStatement))) { throw new NotImplementedException("Unexpected subtype of DropWorkloadGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropWorkloadGroupStatement(
                name: FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropXmlSchemaCollectionStatement FromMutable(ScriptDom.DropXmlSchemaCollectionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DropXmlSchemaCollectionStatement))) { throw new NotImplementedException("Unexpected subtype of DropXmlSchemaCollectionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropXmlSchemaCollectionStatement(
                name: FromMutable(fragment.Name)
            );
        }
        
        public static DurabilityTableOption FromMutable(ScriptDom.DurabilityTableOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.DurabilityTableOption))) { throw new NotImplementedException("Unexpected subtype of DurabilityTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DurabilityTableOption(
                durabilityTableOptionKind: fragment.DurabilityTableOptionKind,
                optionKind: fragment.OptionKind
            );
        }
        
        public static EnabledDisabledPayloadOption FromMutable(ScriptDom.EnabledDisabledPayloadOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EnabledDisabledPayloadOption))) { throw new NotImplementedException("Unexpected subtype of EnabledDisabledPayloadOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EnabledDisabledPayloadOption(
                isEnabled: fragment.IsEnabled,
                kind: fragment.Kind
            );
        }
        
        public static EnableDisableTriggerStatement FromMutable(ScriptDom.EnableDisableTriggerStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EnableDisableTriggerStatement))) { throw new NotImplementedException("Unexpected subtype of EnableDisableTriggerStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EnableDisableTriggerStatement(
                triggerEnforcement: fragment.TriggerEnforcement,
                all: fragment.All,
                triggerNames: fragment.TriggerNames.SelectList(FromMutable),
                triggerObject: FromMutable(fragment.TriggerObject)
            );
        }
        
        public static EncryptedValueParameter FromMutable(ScriptDom.EncryptedValueParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EncryptedValueParameter))) { throw new NotImplementedException("Unexpected subtype of EncryptedValueParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EncryptedValueParameter(
                @value: FromMutable(fragment.Value),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static EncryptionPayloadOption FromMutable(ScriptDom.EncryptionPayloadOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EncryptionPayloadOption))) { throw new NotImplementedException("Unexpected subtype of EncryptionPayloadOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EncryptionPayloadOption(
                encryptionSupport: fragment.EncryptionSupport,
                algorithmPartOne: fragment.AlgorithmPartOne,
                algorithmPartTwo: fragment.AlgorithmPartTwo,
                kind: fragment.Kind
            );
        }
        
        public static EndConversationStatement FromMutable(ScriptDom.EndConversationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EndConversationStatement))) { throw new NotImplementedException("Unexpected subtype of EndConversationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EndConversationStatement(
                conversation: FromMutable(fragment.Conversation),
                withCleanup: fragment.WithCleanup,
                errorCode: FromMutable(fragment.ErrorCode),
                errorDescription: FromMutable(fragment.ErrorDescription)
            );
        }
        
        public static EndpointAffinity FromMutable(ScriptDom.EndpointAffinity fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EndpointAffinity))) { throw new NotImplementedException("Unexpected subtype of EndpointAffinity not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EndpointAffinity(
                kind: fragment.Kind,
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static EventDeclaration FromMutable(ScriptDom.EventDeclaration fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EventDeclaration))) { throw new NotImplementedException("Unexpected subtype of EventDeclaration not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EventDeclaration(
                objectName: FromMutable(fragment.ObjectName),
                eventDeclarationSetParameters: fragment.EventDeclarationSetParameters.SelectList(FromMutable),
                eventDeclarationActionParameters: fragment.EventDeclarationActionParameters.SelectList(FromMutable),
                eventDeclarationPredicateParameter: FromMutable(fragment.EventDeclarationPredicateParameter)
            );
        }
        
        public static EventDeclarationCompareFunctionParameter FromMutable(ScriptDom.EventDeclarationCompareFunctionParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EventDeclarationCompareFunctionParameter))) { throw new NotImplementedException("Unexpected subtype of EventDeclarationCompareFunctionParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EventDeclarationCompareFunctionParameter(
                name: FromMutable(fragment.Name),
                sourceDeclaration: FromMutable(fragment.SourceDeclaration),
                eventValue: FromMutable(fragment.EventValue)
            );
        }
        
        public static EventDeclarationSetParameter FromMutable(ScriptDom.EventDeclarationSetParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EventDeclarationSetParameter))) { throw new NotImplementedException("Unexpected subtype of EventDeclarationSetParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EventDeclarationSetParameter(
                eventField: FromMutable(fragment.EventField),
                eventValue: FromMutable(fragment.EventValue)
            );
        }
        
        public static EventGroupContainer FromMutable(ScriptDom.EventGroupContainer fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EventGroupContainer))) { throw new NotImplementedException("Unexpected subtype of EventGroupContainer not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EventGroupContainer(
                eventGroup: fragment.EventGroup
            );
        }
        
        public static EventNotificationObjectScope FromMutable(ScriptDom.EventNotificationObjectScope fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EventNotificationObjectScope))) { throw new NotImplementedException("Unexpected subtype of EventNotificationObjectScope not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EventNotificationObjectScope(
                target: fragment.Target,
                queueName: FromMutable(fragment.QueueName)
            );
        }
        
        public static EventRetentionSessionOption FromMutable(ScriptDom.EventRetentionSessionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EventRetentionSessionOption))) { throw new NotImplementedException("Unexpected subtype of EventRetentionSessionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EventRetentionSessionOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static EventSessionObjectName FromMutable(ScriptDom.EventSessionObjectName fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EventSessionObjectName))) { throw new NotImplementedException("Unexpected subtype of EventSessionObjectName not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EventSessionObjectName(
                multiPartIdentifier: FromMutable(fragment.MultiPartIdentifier)
            );
        }
        
        public static EventSessionStatement FromMutable(ScriptDom.EventSessionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EventSessionStatement))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as EventSessionStatement; }
            return new EventSessionStatement(
                name: FromMutable(fragment.Name),
                sessionScope: fragment.SessionScope,
                eventDeclarations: fragment.EventDeclarations.SelectList(FromMutable),
                targetDeclarations: fragment.TargetDeclarations.SelectList(FromMutable),
                sessionOptions: fragment.SessionOptions.SelectList(FromMutable)
            );
        }
        
        public static EventTypeContainer FromMutable(ScriptDom.EventTypeContainer fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.EventTypeContainer))) { throw new NotImplementedException("Unexpected subtype of EventTypeContainer not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new EventTypeContainer(
                eventType: fragment.EventType
            );
        }
        
        public static ExecutableProcedureReference FromMutable(ScriptDom.ExecutableProcedureReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExecutableProcedureReference))) { throw new NotImplementedException("Unexpected subtype of ExecutableProcedureReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecutableProcedureReference(
                procedureReference: FromMutable(fragment.ProcedureReference),
                adHocDataSource: FromMutable(fragment.AdHocDataSource),
                parameters: fragment.Parameters.SelectList(FromMutable)
            );
        }
        
        public static ExecutableStringList FromMutable(ScriptDom.ExecutableStringList fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExecutableStringList))) { throw new NotImplementedException("Unexpected subtype of ExecutableStringList not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecutableStringList(
                strings: fragment.Strings.SelectList(FromMutable),
                parameters: fragment.Parameters.SelectList(FromMutable)
            );
        }
        
        public static ExecuteAsClause FromMutable(ScriptDom.ExecuteAsClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExecuteAsClause))) { throw new NotImplementedException("Unexpected subtype of ExecuteAsClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteAsClause(
                executeAsOption: fragment.ExecuteAsOption,
                literal: FromMutable(fragment.Literal)
            );
        }
        
        public static ExecuteAsFunctionOption FromMutable(ScriptDom.ExecuteAsFunctionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExecuteAsFunctionOption))) { throw new NotImplementedException("Unexpected subtype of ExecuteAsFunctionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteAsFunctionOption(
                executeAs: FromMutable(fragment.ExecuteAs),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExecuteAsProcedureOption FromMutable(ScriptDom.ExecuteAsProcedureOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExecuteAsProcedureOption))) { throw new NotImplementedException("Unexpected subtype of ExecuteAsProcedureOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteAsProcedureOption(
                executeAs: FromMutable(fragment.ExecuteAs),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExecuteAsStatement FromMutable(ScriptDom.ExecuteAsStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExecuteAsStatement))) { throw new NotImplementedException("Unexpected subtype of ExecuteAsStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteAsStatement(
                withNoRevert: fragment.WithNoRevert,
                cookie: FromMutable(fragment.Cookie),
                executeContext: FromMutable(fragment.ExecuteContext)
            );
        }
        
        public static ExecuteAsTriggerOption FromMutable(ScriptDom.ExecuteAsTriggerOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExecuteAsTriggerOption))) { throw new NotImplementedException("Unexpected subtype of ExecuteAsTriggerOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteAsTriggerOption(
                executeAsClause: FromMutable(fragment.ExecuteAsClause),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExecuteContext FromMutable(ScriptDom.ExecuteContext fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExecuteContext))) { throw new NotImplementedException("Unexpected subtype of ExecuteContext not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteContext(
                principal: FromMutable(fragment.Principal),
                kind: fragment.Kind
            );
        }
        
        public static ExecuteInsertSource FromMutable(ScriptDom.ExecuteInsertSource fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExecuteInsertSource))) { throw new NotImplementedException("Unexpected subtype of ExecuteInsertSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteInsertSource(
                execute: FromMutable(fragment.Execute)
            );
        }
        
        public static ExecuteOption FromMutable(ScriptDom.ExecuteOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExecuteOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as ExecuteOption; }
            return new ExecuteOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExecuteParameter FromMutable(ScriptDom.ExecuteParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExecuteParameter))) { throw new NotImplementedException("Unexpected subtype of ExecuteParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteParameter(
                variable: FromMutable(fragment.Variable),
                parameterValue: FromMutable(fragment.ParameterValue),
                isOutput: fragment.IsOutput
            );
        }
        
        public static ExecuteSpecification FromMutable(ScriptDom.ExecuteSpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExecuteSpecification))) { throw new NotImplementedException("Unexpected subtype of ExecuteSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteSpecification(
                variable: FromMutable(fragment.Variable),
                linkedServer: FromMutable(fragment.LinkedServer),
                executeContext: FromMutable(fragment.ExecuteContext),
                executableEntity: FromMutable(fragment.ExecutableEntity)
            );
        }
        
        public static ExecuteStatement FromMutable(ScriptDom.ExecuteStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExecuteStatement))) { throw new NotImplementedException("Unexpected subtype of ExecuteStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteStatement(
                executeSpecification: FromMutable(fragment.ExecuteSpecification),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static ExistsPredicate FromMutable(ScriptDom.ExistsPredicate fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExistsPredicate))) { throw new NotImplementedException("Unexpected subtype of ExistsPredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExistsPredicate(
                subquery: FromMutable(fragment.Subquery)
            );
        }
        
        public static ExpressionCallTarget FromMutable(ScriptDom.ExpressionCallTarget fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExpressionCallTarget))) { throw new NotImplementedException("Unexpected subtype of ExpressionCallTarget not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExpressionCallTarget(
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static ExpressionGroupingSpecification FromMutable(ScriptDom.ExpressionGroupingSpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExpressionGroupingSpecification))) { throw new NotImplementedException("Unexpected subtype of ExpressionGroupingSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExpressionGroupingSpecification(
                expression: FromMutable(fragment.Expression),
                distributedAggregation: fragment.DistributedAggregation
            );
        }
        
        public static ExpressionWithSortOrder FromMutable(ScriptDom.ExpressionWithSortOrder fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExpressionWithSortOrder))) { throw new NotImplementedException("Unexpected subtype of ExpressionWithSortOrder not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExpressionWithSortOrder(
                sortOrder: fragment.SortOrder,
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static ExternalCreateLoginSource FromMutable(ScriptDom.ExternalCreateLoginSource fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalCreateLoginSource))) { throw new NotImplementedException("Unexpected subtype of ExternalCreateLoginSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalCreateLoginSource(
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static ExternalDataSourceLiteralOrIdentifierOption FromMutable(ScriptDom.ExternalDataSourceLiteralOrIdentifierOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalDataSourceLiteralOrIdentifierOption))) { throw new NotImplementedException("Unexpected subtype of ExternalDataSourceLiteralOrIdentifierOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalDataSourceLiteralOrIdentifierOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalFileFormatContainerOption FromMutable(ScriptDom.ExternalFileFormatContainerOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalFileFormatContainerOption))) { throw new NotImplementedException("Unexpected subtype of ExternalFileFormatContainerOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalFileFormatContainerOption(
                suboptions: fragment.Suboptions.SelectList(FromMutable),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalFileFormatLiteralOption FromMutable(ScriptDom.ExternalFileFormatLiteralOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalFileFormatLiteralOption))) { throw new NotImplementedException("Unexpected subtype of ExternalFileFormatLiteralOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalFileFormatLiteralOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalFileFormatUseDefaultTypeOption FromMutable(ScriptDom.ExternalFileFormatUseDefaultTypeOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalFileFormatUseDefaultTypeOption))) { throw new NotImplementedException("Unexpected subtype of ExternalFileFormatUseDefaultTypeOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalFileFormatUseDefaultTypeOption(
                externalFileFormatUseDefaultType: fragment.ExternalFileFormatUseDefaultType,
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalLanguageFileOption FromMutable(ScriptDom.ExternalLanguageFileOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalLanguageFileOption))) { throw new NotImplementedException("Unexpected subtype of ExternalLanguageFileOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalLanguageFileOption(
                content: FromMutable(fragment.Content),
                fileName: FromMutable(fragment.FileName),
                path: FromMutable(fragment.Path),
                platform: FromMutable(fragment.Platform),
                parameters: FromMutable(fragment.Parameters),
                environmentVariables: FromMutable(fragment.EnvironmentVariables)
            );
        }
        
        public static ExternalLibraryFileOption FromMutable(ScriptDom.ExternalLibraryFileOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalLibraryFileOption))) { throw new NotImplementedException("Unexpected subtype of ExternalLibraryFileOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalLibraryFileOption(
                content: FromMutable(fragment.Content),
                path: FromMutable(fragment.Path),
                platform: FromMutable(fragment.Platform)
            );
        }
        
        public static ExternalResourcePoolAffinitySpecification FromMutable(ScriptDom.ExternalResourcePoolAffinitySpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalResourcePoolAffinitySpecification))) { throw new NotImplementedException("Unexpected subtype of ExternalResourcePoolAffinitySpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalResourcePoolAffinitySpecification(
                affinityType: fragment.AffinityType,
                parameterValue: FromMutable(fragment.ParameterValue),
                isAuto: fragment.IsAuto,
                poolAffinityRanges: fragment.PoolAffinityRanges.SelectList(FromMutable)
            );
        }
        
        public static ExternalResourcePoolParameter FromMutable(ScriptDom.ExternalResourcePoolParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalResourcePoolParameter))) { throw new NotImplementedException("Unexpected subtype of ExternalResourcePoolParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalResourcePoolParameter(
                parameterType: fragment.ParameterType,
                parameterValue: FromMutable(fragment.ParameterValue),
                affinitySpecification: FromMutable(fragment.AffinitySpecification)
            );
        }
        
        public static ExternalResourcePoolStatement FromMutable(ScriptDom.ExternalResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalResourcePoolStatement))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as ExternalResourcePoolStatement; }
            return new ExternalResourcePoolStatement(
                name: FromMutable(fragment.Name),
                externalResourcePoolParameters: fragment.ExternalResourcePoolParameters.SelectList(FromMutable)
            );
        }
        
        public static ExternalStreamLiteralOrIdentifierOption FromMutable(ScriptDom.ExternalStreamLiteralOrIdentifierOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalStreamLiteralOrIdentifierOption))) { throw new NotImplementedException("Unexpected subtype of ExternalStreamLiteralOrIdentifierOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalStreamLiteralOrIdentifierOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalTableColumnDefinition FromMutable(ScriptDom.ExternalTableColumnDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalTableColumnDefinition))) { throw new NotImplementedException("Unexpected subtype of ExternalTableColumnDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalTableColumnDefinition(
                columnDefinition: FromMutable(fragment.ColumnDefinition),
                nullableConstraint: FromMutable(fragment.NullableConstraint)
            );
        }
        
        public static ExternalTableDistributionOption FromMutable(ScriptDom.ExternalTableDistributionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalTableDistributionOption))) { throw new NotImplementedException("Unexpected subtype of ExternalTableDistributionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalTableDistributionOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalTableLiteralOrIdentifierOption FromMutable(ScriptDom.ExternalTableLiteralOrIdentifierOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalTableLiteralOrIdentifierOption))) { throw new NotImplementedException("Unexpected subtype of ExternalTableLiteralOrIdentifierOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalTableLiteralOrIdentifierOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalTableRejectTypeOption FromMutable(ScriptDom.ExternalTableRejectTypeOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalTableRejectTypeOption))) { throw new NotImplementedException("Unexpected subtype of ExternalTableRejectTypeOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalTableRejectTypeOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalTableReplicatedDistributionPolicy FromMutable(ScriptDom.ExternalTableReplicatedDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalTableReplicatedDistributionPolicy))) { throw new NotImplementedException("Unexpected subtype of ExternalTableReplicatedDistributionPolicy not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalTableReplicatedDistributionPolicy(
                
            );
        }
        
        public static ExternalTableRoundRobinDistributionPolicy FromMutable(ScriptDom.ExternalTableRoundRobinDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalTableRoundRobinDistributionPolicy))) { throw new NotImplementedException("Unexpected subtype of ExternalTableRoundRobinDistributionPolicy not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalTableRoundRobinDistributionPolicy(
                
            );
        }
        
        public static ExternalTableShardedDistributionPolicy FromMutable(ScriptDom.ExternalTableShardedDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExternalTableShardedDistributionPolicy))) { throw new NotImplementedException("Unexpected subtype of ExternalTableShardedDistributionPolicy not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalTableShardedDistributionPolicy(
                shardingColumn: FromMutable(fragment.ShardingColumn)
            );
        }
        
        public static ExtractFromExpression FromMutable(ScriptDom.ExtractFromExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ExtractFromExpression))) { throw new NotImplementedException("Unexpected subtype of ExtractFromExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExtractFromExpression(
                expression: FromMutable(fragment.Expression),
                extractedElement: FromMutable(fragment.ExtractedElement)
            );
        }
        
        public static FailoverModeReplicaOption FromMutable(ScriptDom.FailoverModeReplicaOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FailoverModeReplicaOption))) { throw new NotImplementedException("Unexpected subtype of FailoverModeReplicaOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FailoverModeReplicaOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static FederationScheme FromMutable(ScriptDom.FederationScheme fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FederationScheme))) { throw new NotImplementedException("Unexpected subtype of FederationScheme not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FederationScheme(
                distributionName: FromMutable(fragment.DistributionName),
                columnName: FromMutable(fragment.ColumnName)
            );
        }
        
        public static FetchCursorStatement FromMutable(ScriptDom.FetchCursorStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FetchCursorStatement))) { throw new NotImplementedException("Unexpected subtype of FetchCursorStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FetchCursorStatement(
                fetchType: FromMutable(fragment.FetchType),
                intoVariables: fragment.IntoVariables.SelectList(FromMutable),
                cursor: FromMutable(fragment.Cursor)
            );
        }
        
        public static FetchType FromMutable(ScriptDom.FetchType fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FetchType))) { throw new NotImplementedException("Unexpected subtype of FetchType not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FetchType(
                orientation: fragment.Orientation,
                rowOffset: FromMutable(fragment.RowOffset)
            );
        }
        
        public static FileDeclaration FromMutable(ScriptDom.FileDeclaration fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileDeclaration))) { throw new NotImplementedException("Unexpected subtype of FileDeclaration not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileDeclaration(
                options: fragment.Options.SelectList(FromMutable),
                isPrimary: fragment.IsPrimary
            );
        }
        
        public static FileDeclarationOption FromMutable(ScriptDom.FileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileDeclarationOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as FileDeclarationOption; }
            return new FileDeclarationOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileEncryptionSource FromMutable(ScriptDom.FileEncryptionSource fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileEncryptionSource))) { throw new NotImplementedException("Unexpected subtype of FileEncryptionSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileEncryptionSource(
                isExecutable: fragment.IsExecutable,
                file: FromMutable(fragment.File)
            );
        }
        
        public static FileGroupDefinition FromMutable(ScriptDom.FileGroupDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileGroupDefinition))) { throw new NotImplementedException("Unexpected subtype of FileGroupDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileGroupDefinition(
                name: FromMutable(fragment.Name),
                fileDeclarations: fragment.FileDeclarations.SelectList(FromMutable),
                isDefault: fragment.IsDefault,
                containsFileStream: fragment.ContainsFileStream,
                containsMemoryOptimizedData: fragment.ContainsMemoryOptimizedData
            );
        }
        
        public static FileGroupOrPartitionScheme FromMutable(ScriptDom.FileGroupOrPartitionScheme fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileGroupOrPartitionScheme))) { throw new NotImplementedException("Unexpected subtype of FileGroupOrPartitionScheme not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileGroupOrPartitionScheme(
                name: FromMutable(fragment.Name),
                partitionSchemeColumns: fragment.PartitionSchemeColumns.SelectList(FromMutable)
            );
        }
        
        public static FileGrowthFileDeclarationOption FromMutable(ScriptDom.FileGrowthFileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileGrowthFileDeclarationOption))) { throw new NotImplementedException("Unexpected subtype of FileGrowthFileDeclarationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileGrowthFileDeclarationOption(
                growthIncrement: FromMutable(fragment.GrowthIncrement),
                units: fragment.Units,
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileNameFileDeclarationOption FromMutable(ScriptDom.FileNameFileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileNameFileDeclarationOption))) { throw new NotImplementedException("Unexpected subtype of FileNameFileDeclarationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileNameFileDeclarationOption(
                oSFileName: FromMutable(fragment.OSFileName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileStreamDatabaseOption FromMutable(ScriptDom.FileStreamDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileStreamDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of FileStreamDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileStreamDatabaseOption(
                nonTransactedAccess: fragment.NonTransactedAccess,
                directoryName: FromMutable(fragment.DirectoryName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileStreamOnDropIndexOption FromMutable(ScriptDom.FileStreamOnDropIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileStreamOnDropIndexOption))) { throw new NotImplementedException("Unexpected subtype of FileStreamOnDropIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileStreamOnDropIndexOption(
                fileStreamOn: FromMutable(fragment.FileStreamOn),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileStreamOnTableOption FromMutable(ScriptDom.FileStreamOnTableOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileStreamOnTableOption))) { throw new NotImplementedException("Unexpected subtype of FileStreamOnTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileStreamOnTableOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileStreamRestoreOption FromMutable(ScriptDom.FileStreamRestoreOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileStreamRestoreOption))) { throw new NotImplementedException("Unexpected subtype of FileStreamRestoreOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileStreamRestoreOption(
                fileStreamOption: FromMutable(fragment.FileStreamOption),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileTableCollateFileNameTableOption FromMutable(ScriptDom.FileTableCollateFileNameTableOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileTableCollateFileNameTableOption))) { throw new NotImplementedException("Unexpected subtype of FileTableCollateFileNameTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileTableCollateFileNameTableOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileTableConstraintNameTableOption FromMutable(ScriptDom.FileTableConstraintNameTableOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileTableConstraintNameTableOption))) { throw new NotImplementedException("Unexpected subtype of FileTableConstraintNameTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileTableConstraintNameTableOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileTableDirectoryTableOption FromMutable(ScriptDom.FileTableDirectoryTableOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FileTableDirectoryTableOption))) { throw new NotImplementedException("Unexpected subtype of FileTableDirectoryTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileTableDirectoryTableOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ForceSeekTableHint FromMutable(ScriptDom.ForceSeekTableHint fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ForceSeekTableHint))) { throw new NotImplementedException("Unexpected subtype of ForceSeekTableHint not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ForceSeekTableHint(
                indexValue: FromMutable(fragment.IndexValue),
                columnValues: fragment.ColumnValues.SelectList(FromMutable),
                hintKind: fragment.HintKind
            );
        }
        
        public static ForeignKeyConstraintDefinition FromMutable(ScriptDom.ForeignKeyConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ForeignKeyConstraintDefinition))) { throw new NotImplementedException("Unexpected subtype of ForeignKeyConstraintDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ForeignKeyConstraintDefinition(
                columns: fragment.Columns.SelectList(FromMutable),
                referenceTableName: FromMutable(fragment.ReferenceTableName),
                referencedTableColumns: fragment.ReferencedTableColumns.SelectList(FromMutable),
                deleteAction: fragment.DeleteAction,
                updateAction: fragment.UpdateAction,
                notForReplication: fragment.NotForReplication,
                constraintIdentifier: FromMutable(fragment.ConstraintIdentifier)
            );
        }
        
        public static FromClause FromMutable(ScriptDom.FromClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FromClause))) { throw new NotImplementedException("Unexpected subtype of FromClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FromClause(
                tableReferences: fragment.TableReferences.SelectList(FromMutable),
                predictTableReference: fragment.PredictTableReference.SelectList(FromMutable)
            );
        }
        
        public static FullTextCatalogAndFileGroup FromMutable(ScriptDom.FullTextCatalogAndFileGroup fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FullTextCatalogAndFileGroup))) { throw new NotImplementedException("Unexpected subtype of FullTextCatalogAndFileGroup not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FullTextCatalogAndFileGroup(
                catalogName: FromMutable(fragment.CatalogName),
                fileGroupName: FromMutable(fragment.FileGroupName),
                fileGroupIsFirst: fragment.FileGroupIsFirst
            );
        }
        
        public static FullTextIndexColumn FromMutable(ScriptDom.FullTextIndexColumn fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FullTextIndexColumn))) { throw new NotImplementedException("Unexpected subtype of FullTextIndexColumn not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FullTextIndexColumn(
                name: FromMutable(fragment.Name),
                typeColumn: FromMutable(fragment.TypeColumn),
                languageTerm: FromMutable(fragment.LanguageTerm),
                statisticalSemantics: fragment.StatisticalSemantics
            );
        }
        
        public static FullTextPredicate FromMutable(ScriptDom.FullTextPredicate fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FullTextPredicate))) { throw new NotImplementedException("Unexpected subtype of FullTextPredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FullTextPredicate(
                fullTextFunctionType: fragment.FullTextFunctionType,
                columns: fragment.Columns.SelectList(FromMutable),
                @value: FromMutable(fragment.Value),
                languageTerm: FromMutable(fragment.LanguageTerm),
                propertyName: FromMutable(fragment.PropertyName)
            );
        }
        
        public static FullTextStopListAction FromMutable(ScriptDom.FullTextStopListAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FullTextStopListAction))) { throw new NotImplementedException("Unexpected subtype of FullTextStopListAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FullTextStopListAction(
                isAdd: fragment.IsAdd,
                isAll: fragment.IsAll,
                stopWord: FromMutable(fragment.StopWord),
                languageTerm: FromMutable(fragment.LanguageTerm)
            );
        }
        
        public static FullTextTableReference FromMutable(ScriptDom.FullTextTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FullTextTableReference))) { throw new NotImplementedException("Unexpected subtype of FullTextTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FullTextTableReference(
                fullTextFunctionType: fragment.FullTextFunctionType,
                tableName: FromMutable(fragment.TableName),
                columns: fragment.Columns.SelectList(FromMutable),
                searchCondition: FromMutable(fragment.SearchCondition),
                topN: FromMutable(fragment.TopN),
                language: FromMutable(fragment.Language),
                propertyName: FromMutable(fragment.PropertyName),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static FunctionCall FromMutable(ScriptDom.FunctionCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FunctionCall))) { throw new NotImplementedException("Unexpected subtype of FunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FunctionCall(
                callTarget: FromMutable(fragment.CallTarget),
                functionName: FromMutable(fragment.FunctionName),
                parameters: fragment.Parameters.SelectList(FromMutable),
                uniqueRowFilter: fragment.UniqueRowFilter,
                overClause: FromMutable(fragment.OverClause),
                withinGroupClause: FromMutable(fragment.WithinGroupClause),
                ignoreRespectNulls: fragment.IgnoreRespectNulls.SelectList(FromMutable),
                trimOptions: FromMutable(fragment.TrimOptions),
                jsonParameters: fragment.JsonParameters.SelectList(FromMutable),
                absentOrNullOnNull: fragment.AbsentOrNullOnNull.SelectList(FromMutable),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static FunctionCallSetClause FromMutable(ScriptDom.FunctionCallSetClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FunctionCallSetClause))) { throw new NotImplementedException("Unexpected subtype of FunctionCallSetClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FunctionCallSetClause(
                mutatorFunction: FromMutable(fragment.MutatorFunction)
            );
        }
        
        public static FunctionOption FromMutable(ScriptDom.FunctionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.FunctionOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as FunctionOption; }
            return new FunctionOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static GeneralSetCommand FromMutable(ScriptDom.GeneralSetCommand fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GeneralSetCommand))) { throw new NotImplementedException("Unexpected subtype of GeneralSetCommand not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GeneralSetCommand(
                commandType: fragment.CommandType,
                parameter: FromMutable(fragment.Parameter)
            );
        }
        
        public static GenericConfigurationOption FromMutable(ScriptDom.GenericConfigurationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GenericConfigurationOption))) { throw new NotImplementedException("Unexpected subtype of GenericConfigurationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GenericConfigurationOption(
                genericOptionState: FromMutable(fragment.GenericOptionState),
                optionKind: fragment.OptionKind,
                genericOptionKind: FromMutable(fragment.GenericOptionKind)
            );
        }
        
        public static GetConversationGroupStatement FromMutable(ScriptDom.GetConversationGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GetConversationGroupStatement))) { throw new NotImplementedException("Unexpected subtype of GetConversationGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GetConversationGroupStatement(
                groupId: FromMutable(fragment.GroupId),
                queue: FromMutable(fragment.Queue)
            );
        }
        
        public static GlobalFunctionTableReference FromMutable(ScriptDom.GlobalFunctionTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GlobalFunctionTableReference))) { throw new NotImplementedException("Unexpected subtype of GlobalFunctionTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GlobalFunctionTableReference(
                name: FromMutable(fragment.Name),
                parameters: fragment.Parameters.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static GlobalVariableExpression FromMutable(ScriptDom.GlobalVariableExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GlobalVariableExpression))) { throw new NotImplementedException("Unexpected subtype of GlobalVariableExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GlobalVariableExpression(
                name: fragment.Name,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static GoToStatement FromMutable(ScriptDom.GoToStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GoToStatement))) { throw new NotImplementedException("Unexpected subtype of GoToStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GoToStatement(
                labelName: FromMutable(fragment.LabelName)
            );
        }
        
        public static GrandTotalGroupingSpecification FromMutable(ScriptDom.GrandTotalGroupingSpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GrandTotalGroupingSpecification))) { throw new NotImplementedException("Unexpected subtype of GrandTotalGroupingSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GrandTotalGroupingSpecification(
                
            );
        }
        
        public static GrantStatement FromMutable(ScriptDom.GrantStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GrantStatement))) { throw new NotImplementedException("Unexpected subtype of GrantStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GrantStatement(
                withGrantOption: fragment.WithGrantOption,
                permissions: fragment.Permissions.SelectList(FromMutable),
                securityTargetObject: FromMutable(fragment.SecurityTargetObject),
                principals: fragment.Principals.SelectList(FromMutable),
                asClause: FromMutable(fragment.AsClause)
            );
        }
        
        public static GrantStatement80 FromMutable(ScriptDom.GrantStatement80 fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GrantStatement80))) { throw new NotImplementedException("Unexpected subtype of GrantStatement80 not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GrantStatement80(
                withGrantOption: fragment.WithGrantOption,
                asClause: FromMutable(fragment.AsClause),
                securityElement80: FromMutable(fragment.SecurityElement80),
                securityUserClause80: FromMutable(fragment.SecurityUserClause80)
            );
        }
        
        public static GraphConnectionBetweenNodes FromMutable(ScriptDom.GraphConnectionBetweenNodes fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GraphConnectionBetweenNodes))) { throw new NotImplementedException("Unexpected subtype of GraphConnectionBetweenNodes not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GraphConnectionBetweenNodes(
                fromNode: FromMutable(fragment.FromNode),
                toNode: FromMutable(fragment.ToNode)
            );
        }
        
        public static GraphConnectionConstraintDefinition FromMutable(ScriptDom.GraphConnectionConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GraphConnectionConstraintDefinition))) { throw new NotImplementedException("Unexpected subtype of GraphConnectionConstraintDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GraphConnectionConstraintDefinition(
                fromNodeToNodeList: fragment.FromNodeToNodeList.SelectList(FromMutable),
                deleteAction: fragment.DeleteAction,
                constraintIdentifier: FromMutable(fragment.ConstraintIdentifier)
            );
        }
        
        public static GraphMatchCompositeExpression FromMutable(ScriptDom.GraphMatchCompositeExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GraphMatchCompositeExpression))) { throw new NotImplementedException("Unexpected subtype of GraphMatchCompositeExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GraphMatchCompositeExpression(
                leftNode: FromMutable(fragment.LeftNode),
                edge: FromMutable(fragment.Edge),
                rightNode: FromMutable(fragment.RightNode),
                arrowOnRight: fragment.ArrowOnRight
            );
        }
        
        public static GraphMatchExpression FromMutable(ScriptDom.GraphMatchExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GraphMatchExpression))) { throw new NotImplementedException("Unexpected subtype of GraphMatchExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GraphMatchExpression(
                leftNode: FromMutable(fragment.LeftNode),
                edge: FromMutable(fragment.Edge),
                rightNode: FromMutable(fragment.RightNode),
                arrowOnRight: fragment.ArrowOnRight
            );
        }
        
        public static GraphMatchLastNodePredicate FromMutable(ScriptDom.GraphMatchLastNodePredicate fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GraphMatchLastNodePredicate))) { throw new NotImplementedException("Unexpected subtype of GraphMatchLastNodePredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GraphMatchLastNodePredicate(
                leftExpression: FromMutable(fragment.LeftExpression),
                rightExpression: FromMutable(fragment.RightExpression)
            );
        }
        
        public static GraphMatchNodeExpression FromMutable(ScriptDom.GraphMatchNodeExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GraphMatchNodeExpression))) { throw new NotImplementedException("Unexpected subtype of GraphMatchNodeExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GraphMatchNodeExpression(
                node: FromMutable(fragment.Node),
                usesLastNode: fragment.UsesLastNode
            );
        }
        
        public static GraphMatchPredicate FromMutable(ScriptDom.GraphMatchPredicate fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GraphMatchPredicate))) { throw new NotImplementedException("Unexpected subtype of GraphMatchPredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GraphMatchPredicate(
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static GraphMatchRecursivePredicate FromMutable(ScriptDom.GraphMatchRecursivePredicate fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GraphMatchRecursivePredicate))) { throw new NotImplementedException("Unexpected subtype of GraphMatchRecursivePredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GraphMatchRecursivePredicate(
                function: fragment.Function,
                outerNodeExpression: FromMutable(fragment.OuterNodeExpression),
                expression: fragment.Expression.SelectList(FromMutable),
                recursiveQuantifier: FromMutable(fragment.RecursiveQuantifier),
                anchorOnLeft: fragment.AnchorOnLeft
            );
        }
        
        public static GraphRecursiveMatchQuantifier FromMutable(ScriptDom.GraphRecursiveMatchQuantifier fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GraphRecursiveMatchQuantifier))) { throw new NotImplementedException("Unexpected subtype of GraphRecursiveMatchQuantifier not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GraphRecursiveMatchQuantifier(
                isPlusSign: fragment.IsPlusSign,
                lowerLimit: FromMutable(fragment.LowerLimit),
                upperLimit: FromMutable(fragment.UpperLimit)
            );
        }
        
        public static GridParameter FromMutable(ScriptDom.GridParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GridParameter))) { throw new NotImplementedException("Unexpected subtype of GridParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GridParameter(
                parameter: fragment.Parameter,
                @value: fragment.Value
            );
        }
        
        public static GridsSpatialIndexOption FromMutable(ScriptDom.GridsSpatialIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GridsSpatialIndexOption))) { throw new NotImplementedException("Unexpected subtype of GridsSpatialIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GridsSpatialIndexOption(
                gridParameters: fragment.GridParameters.SelectList(FromMutable)
            );
        }
        
        public static GroupByClause FromMutable(ScriptDom.GroupByClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GroupByClause))) { throw new NotImplementedException("Unexpected subtype of GroupByClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GroupByClause(
                groupByOption: fragment.GroupByOption,
                all: fragment.All,
                groupingSpecifications: fragment.GroupingSpecifications.SelectList(FromMutable)
            );
        }
        
        public static GroupingSetsGroupingSpecification FromMutable(ScriptDom.GroupingSetsGroupingSpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.GroupingSetsGroupingSpecification))) { throw new NotImplementedException("Unexpected subtype of GroupingSetsGroupingSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GroupingSetsGroupingSpecification(
                sets: fragment.Sets.SelectList(FromMutable)
            );
        }
        
        public static HadrAvailabilityGroupDatabaseOption FromMutable(ScriptDom.HadrAvailabilityGroupDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.HadrAvailabilityGroupDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of HadrAvailabilityGroupDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new HadrAvailabilityGroupDatabaseOption(
                groupName: FromMutable(fragment.GroupName),
                hadrOption: fragment.HadrOption,
                optionKind: fragment.OptionKind
            );
        }
        
        public static HadrDatabaseOption FromMutable(ScriptDom.HadrDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.HadrDatabaseOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as HadrDatabaseOption; }
            return new HadrDatabaseOption(
                hadrOption: fragment.HadrOption,
                optionKind: fragment.OptionKind
            );
        }
        
        public static HavingClause FromMutable(ScriptDom.HavingClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.HavingClause))) { throw new NotImplementedException("Unexpected subtype of HavingClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new HavingClause(
                searchCondition: FromMutable(fragment.SearchCondition)
            );
        }
        
        public static Identifier FromMutable(ScriptDom.Identifier fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.Identifier))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as Identifier; }
            return new Identifier(
                @value: fragment.Value,
                quoteType: fragment.QuoteType
            );
        }
        
        public static IdentifierAtomicBlockOption FromMutable(ScriptDom.IdentifierAtomicBlockOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IdentifierAtomicBlockOption))) { throw new NotImplementedException("Unexpected subtype of IdentifierAtomicBlockOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IdentifierAtomicBlockOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static IdentifierDatabaseOption FromMutable(ScriptDom.IdentifierDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IdentifierDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of IdentifierDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IdentifierDatabaseOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static IdentifierLiteral FromMutable(ScriptDom.IdentifierLiteral fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IdentifierLiteral))) { throw new NotImplementedException("Unexpected subtype of IdentifierLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IdentifierLiteral(
                quoteType: fragment.QuoteType,
                @value: fragment.Value,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static IdentifierOrScalarExpression FromMutable(ScriptDom.IdentifierOrScalarExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IdentifierOrScalarExpression))) { throw new NotImplementedException("Unexpected subtype of IdentifierOrScalarExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IdentifierOrScalarExpression(
                identifier: FromMutable(fragment.Identifier),
                scalarExpression: FromMutable(fragment.ScalarExpression)
            );
        }
        
        public static IdentifierOrValueExpression FromMutable(ScriptDom.IdentifierOrValueExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IdentifierOrValueExpression))) { throw new NotImplementedException("Unexpected subtype of IdentifierOrValueExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IdentifierOrValueExpression(
                identifier: FromMutable(fragment.Identifier),
                valueExpression: FromMutable(fragment.ValueExpression)
            );
        }
        
        public static IdentifierPrincipalOption FromMutable(ScriptDom.IdentifierPrincipalOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IdentifierPrincipalOption))) { throw new NotImplementedException("Unexpected subtype of IdentifierPrincipalOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IdentifierPrincipalOption(
                identifier: FromMutable(fragment.Identifier),
                optionKind: fragment.OptionKind
            );
        }
        
        public static IdentifierSnippet FromMutable(ScriptDom.IdentifierSnippet fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IdentifierSnippet))) { throw new NotImplementedException("Unexpected subtype of IdentifierSnippet not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IdentifierSnippet(
                script: fragment.Script,
                @value: fragment.Value,
                quoteType: fragment.QuoteType
            );
        }
        
        public static IdentityFunctionCall FromMutable(ScriptDom.IdentityFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IdentityFunctionCall))) { throw new NotImplementedException("Unexpected subtype of IdentityFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IdentityFunctionCall(
                dataType: FromMutable(fragment.DataType),
                seed: FromMutable(fragment.Seed),
                increment: FromMutable(fragment.Increment)
            );
        }
        
        public static IdentityOptions FromMutable(ScriptDom.IdentityOptions fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IdentityOptions))) { throw new NotImplementedException("Unexpected subtype of IdentityOptions not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IdentityOptions(
                identitySeed: FromMutable(fragment.IdentitySeed),
                identityIncrement: FromMutable(fragment.IdentityIncrement),
                isIdentityNotForReplication: fragment.IsIdentityNotForReplication
            );
        }
        
        public static IdentityValueKeyOption FromMutable(ScriptDom.IdentityValueKeyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IdentityValueKeyOption))) { throw new NotImplementedException("Unexpected subtype of IdentityValueKeyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IdentityValueKeyOption(
                identityPhrase: FromMutable(fragment.IdentityPhrase),
                optionKind: fragment.OptionKind
            );
        }
        
        public static IfStatement FromMutable(ScriptDom.IfStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IfStatement))) { throw new NotImplementedException("Unexpected subtype of IfStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IfStatement(
                predicate: FromMutable(fragment.Predicate),
                thenStatement: FromMutable(fragment.ThenStatement),
                elseStatement: FromMutable(fragment.ElseStatement)
            );
        }
        
        public static IgnoreDupKeyIndexOption FromMutable(ScriptDom.IgnoreDupKeyIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IgnoreDupKeyIndexOption))) { throw new NotImplementedException("Unexpected subtype of IgnoreDupKeyIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IgnoreDupKeyIndexOption(
                suppressMessagesOption: fragment.SuppressMessagesOption,
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static IIfCall FromMutable(ScriptDom.IIfCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IIfCall))) { throw new NotImplementedException("Unexpected subtype of IIfCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IIfCall(
                predicate: FromMutable(fragment.Predicate),
                thenExpression: FromMutable(fragment.ThenExpression),
                elseExpression: FromMutable(fragment.ElseExpression),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static IndexDefinition FromMutable(ScriptDom.IndexDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IndexDefinition))) { throw new NotImplementedException("Unexpected subtype of IndexDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IndexDefinition(
                name: FromMutable(fragment.Name),
                unique: fragment.Unique,
                indexType: FromMutable(fragment.IndexType),
                indexOptions: fragment.IndexOptions.SelectList(FromMutable),
                columns: fragment.Columns.SelectList(FromMutable),
                includeColumns: fragment.IncludeColumns.SelectList(FromMutable),
                onFileGroupOrPartitionScheme: FromMutable(fragment.OnFileGroupOrPartitionScheme),
                filterPredicate: FromMutable(fragment.FilterPredicate),
                fileStreamOn: FromMutable(fragment.FileStreamOn)
            );
        }
        
        public static IndexExpressionOption FromMutable(ScriptDom.IndexExpressionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IndexExpressionOption))) { throw new NotImplementedException("Unexpected subtype of IndexExpressionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IndexExpressionOption(
                expression: FromMutable(fragment.Expression),
                optionKind: fragment.OptionKind
            );
        }
        
        public static IndexStateOption FromMutable(ScriptDom.IndexStateOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IndexStateOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as IndexStateOption; }
            return new IndexStateOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static IndexTableHint FromMutable(ScriptDom.IndexTableHint fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IndexTableHint))) { throw new NotImplementedException("Unexpected subtype of IndexTableHint not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IndexTableHint(
                indexValues: fragment.IndexValues.SelectList(FromMutable),
                hintKind: fragment.HintKind
            );
        }
        
        public static IndexType FromMutable(ScriptDom.IndexType fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IndexType))) { throw new NotImplementedException("Unexpected subtype of IndexType not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IndexType(
                indexTypeKind: fragment.IndexTypeKind
            );
        }
        
        public static InlineDerivedTable FromMutable(ScriptDom.InlineDerivedTable fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.InlineDerivedTable))) { throw new NotImplementedException("Unexpected subtype of InlineDerivedTable not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InlineDerivedTable(
                rowValues: fragment.RowValues.SelectList(FromMutable),
                columns: fragment.Columns.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static InlineFunctionOption FromMutable(ScriptDom.InlineFunctionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.InlineFunctionOption))) { throw new NotImplementedException("Unexpected subtype of InlineFunctionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InlineFunctionOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static InlineResultSetDefinition FromMutable(ScriptDom.InlineResultSetDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.InlineResultSetDefinition))) { throw new NotImplementedException("Unexpected subtype of InlineResultSetDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InlineResultSetDefinition(
                resultColumnDefinitions: fragment.ResultColumnDefinitions.SelectList(FromMutable),
                resultSetType: fragment.ResultSetType
            );
        }
        
        public static InPredicate FromMutable(ScriptDom.InPredicate fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.InPredicate))) { throw new NotImplementedException("Unexpected subtype of InPredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InPredicate(
                expression: FromMutable(fragment.Expression),
                subquery: FromMutable(fragment.Subquery),
                notDefined: fragment.NotDefined,
                values: fragment.Values.SelectList(FromMutable)
            );
        }
        
        public static InsertBulkColumnDefinition FromMutable(ScriptDom.InsertBulkColumnDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.InsertBulkColumnDefinition))) { throw new NotImplementedException("Unexpected subtype of InsertBulkColumnDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InsertBulkColumnDefinition(
                column: FromMutable(fragment.Column),
                nullNotNull: fragment.NullNotNull
            );
        }
        
        public static InsertBulkStatement FromMutable(ScriptDom.InsertBulkStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.InsertBulkStatement))) { throw new NotImplementedException("Unexpected subtype of InsertBulkStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InsertBulkStatement(
                columnDefinitions: fragment.ColumnDefinitions.SelectList(FromMutable),
                to: FromMutable(fragment.To),
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static InsertMergeAction FromMutable(ScriptDom.InsertMergeAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.InsertMergeAction))) { throw new NotImplementedException("Unexpected subtype of InsertMergeAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InsertMergeAction(
                columns: fragment.Columns.SelectList(FromMutable),
                source: FromMutable(fragment.Source)
            );
        }
        
        public static InsertSpecification FromMutable(ScriptDom.InsertSpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.InsertSpecification))) { throw new NotImplementedException("Unexpected subtype of InsertSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InsertSpecification(
                insertOption: fragment.InsertOption,
                insertSource: FromMutable(fragment.InsertSource),
                columns: fragment.Columns.SelectList(FromMutable),
                target: FromMutable(fragment.Target),
                topRowFilter: FromMutable(fragment.TopRowFilter),
                outputIntoClause: FromMutable(fragment.OutputIntoClause),
                outputClause: FromMutable(fragment.OutputClause)
            );
        }
        
        public static InsertStatement FromMutable(ScriptDom.InsertStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.InsertStatement))) { throw new NotImplementedException("Unexpected subtype of InsertStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InsertStatement(
                insertSpecification: FromMutable(fragment.InsertSpecification),
                withCtesAndXmlNamespaces: FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.SelectList(FromMutable)
            );
        }
        
        public static IntegerLiteral FromMutable(ScriptDom.IntegerLiteral fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IntegerLiteral))) { throw new NotImplementedException("Unexpected subtype of IntegerLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IntegerLiteral(
                @value: fragment.Value,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static InternalOpenRowset FromMutable(ScriptDom.InternalOpenRowset fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.InternalOpenRowset))) { throw new NotImplementedException("Unexpected subtype of InternalOpenRowset not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InternalOpenRowset(
                identifier: FromMutable(fragment.Identifier),
                varArgs: fragment.VarArgs.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static IPv4 FromMutable(ScriptDom.IPv4 fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.IPv4))) { throw new NotImplementedException("Unexpected subtype of IPv4 not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IPv4(
                octetOne: FromMutable(fragment.OctetOne),
                octetTwo: FromMutable(fragment.OctetTwo),
                octetThree: FromMutable(fragment.OctetThree),
                octetFour: FromMutable(fragment.OctetFour)
            );
        }
        
        public static JoinParenthesisTableReference FromMutable(ScriptDom.JoinParenthesisTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.JoinParenthesisTableReference))) { throw new NotImplementedException("Unexpected subtype of JoinParenthesisTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new JoinParenthesisTableReference(
                join: FromMutable(fragment.Join)
            );
        }
        
        public static JsonForClause FromMutable(ScriptDom.JsonForClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.JsonForClause))) { throw new NotImplementedException("Unexpected subtype of JsonForClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new JsonForClause(
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static JsonForClauseOption FromMutable(ScriptDom.JsonForClauseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.JsonForClauseOption))) { throw new NotImplementedException("Unexpected subtype of JsonForClauseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new JsonForClauseOption(
                optionKind: fragment.OptionKind,
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static JsonKeyValue FromMutable(ScriptDom.JsonKeyValue fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.JsonKeyValue))) { throw new NotImplementedException("Unexpected subtype of JsonKeyValue not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new JsonKeyValue(
                jsonKeyName: FromMutable(fragment.JsonKeyName),
                jsonValue: FromMutable(fragment.JsonValue)
            );
        }
        
        public static KeySourceKeyOption FromMutable(ScriptDom.KeySourceKeyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.KeySourceKeyOption))) { throw new NotImplementedException("Unexpected subtype of KeySourceKeyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new KeySourceKeyOption(
                passPhrase: FromMutable(fragment.PassPhrase),
                optionKind: fragment.OptionKind
            );
        }
        
        public static KillQueryNotificationSubscriptionStatement FromMutable(ScriptDom.KillQueryNotificationSubscriptionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.KillQueryNotificationSubscriptionStatement))) { throw new NotImplementedException("Unexpected subtype of KillQueryNotificationSubscriptionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new KillQueryNotificationSubscriptionStatement(
                subscriptionId: FromMutable(fragment.SubscriptionId),
                all: fragment.All
            );
        }
        
        public static KillStatement FromMutable(ScriptDom.KillStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.KillStatement))) { throw new NotImplementedException("Unexpected subtype of KillStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new KillStatement(
                parameter: FromMutable(fragment.Parameter),
                withStatusOnly: fragment.WithStatusOnly
            );
        }
        
        public static KillStatsJobStatement FromMutable(ScriptDom.KillStatsJobStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.KillStatsJobStatement))) { throw new NotImplementedException("Unexpected subtype of KillStatsJobStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new KillStatsJobStatement(
                jobId: FromMutable(fragment.JobId)
            );
        }
        
        public static LabelStatement FromMutable(ScriptDom.LabelStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LabelStatement))) { throw new NotImplementedException("Unexpected subtype of LabelStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LabelStatement(
                @value: fragment.Value
            );
        }
        
        public static LedgerOption FromMutable(ScriptDom.LedgerOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LedgerOption))) { throw new NotImplementedException("Unexpected subtype of LedgerOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LedgerOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static LedgerTableOption FromMutable(ScriptDom.LedgerTableOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LedgerTableOption))) { throw new NotImplementedException("Unexpected subtype of LedgerTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LedgerTableOption(
                optionState: fragment.OptionState,
                appendOnly: fragment.AppendOnly,
                ledgerViewOption: FromMutable(fragment.LedgerViewOption),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LedgerViewOption FromMutable(ScriptDom.LedgerViewOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LedgerViewOption))) { throw new NotImplementedException("Unexpected subtype of LedgerViewOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LedgerViewOption(
                viewName: FromMutable(fragment.ViewName),
                transactionIdColumnName: FromMutable(fragment.TransactionIdColumnName),
                sequenceNumberColumnName: FromMutable(fragment.SequenceNumberColumnName),
                operationTypeColumnName: FromMutable(fragment.OperationTypeColumnName),
                operationTypeDescColumnName: FromMutable(fragment.OperationTypeDescColumnName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LeftFunctionCall FromMutable(ScriptDom.LeftFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LeftFunctionCall))) { throw new NotImplementedException("Unexpected subtype of LeftFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LeftFunctionCall(
                parameters: fragment.Parameters.SelectList(FromMutable),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static LikePredicate FromMutable(ScriptDom.LikePredicate fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LikePredicate))) { throw new NotImplementedException("Unexpected subtype of LikePredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LikePredicate(
                firstExpression: FromMutable(fragment.FirstExpression),
                secondExpression: FromMutable(fragment.SecondExpression),
                notDefined: fragment.NotDefined,
                odbcEscape: fragment.OdbcEscape,
                escapeExpression: FromMutable(fragment.EscapeExpression)
            );
        }
        
        public static LineNoStatement FromMutable(ScriptDom.LineNoStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LineNoStatement))) { throw new NotImplementedException("Unexpected subtype of LineNoStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LineNoStatement(
                lineNo: FromMutable(fragment.LineNo)
            );
        }
        
        public static ListenerIPEndpointProtocolOption FromMutable(ScriptDom.ListenerIPEndpointProtocolOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ListenerIPEndpointProtocolOption))) { throw new NotImplementedException("Unexpected subtype of ListenerIPEndpointProtocolOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ListenerIPEndpointProtocolOption(
                isAll: fragment.IsAll,
                iPv6: FromMutable(fragment.IPv6),
                iPv4PartOne: FromMutable(fragment.IPv4PartOne),
                iPv4PartTwo: FromMutable(fragment.IPv4PartTwo),
                kind: fragment.Kind
            );
        }
        
        public static ListTypeCopyOption FromMutable(ScriptDom.ListTypeCopyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ListTypeCopyOption))) { throw new NotImplementedException("Unexpected subtype of ListTypeCopyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ListTypeCopyOption(
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static LiteralAtomicBlockOption FromMutable(ScriptDom.LiteralAtomicBlockOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralAtomicBlockOption))) { throw new NotImplementedException("Unexpected subtype of LiteralAtomicBlockOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralAtomicBlockOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralAuditTargetOption FromMutable(ScriptDom.LiteralAuditTargetOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralAuditTargetOption))) { throw new NotImplementedException("Unexpected subtype of LiteralAuditTargetOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralAuditTargetOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralAvailabilityGroupOption FromMutable(ScriptDom.LiteralAvailabilityGroupOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralAvailabilityGroupOption))) { throw new NotImplementedException("Unexpected subtype of LiteralAvailabilityGroupOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralAvailabilityGroupOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralBulkInsertOption FromMutable(ScriptDom.LiteralBulkInsertOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralBulkInsertOption))) { throw new NotImplementedException("Unexpected subtype of LiteralBulkInsertOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralBulkInsertOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralDatabaseOption FromMutable(ScriptDom.LiteralDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of LiteralDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralDatabaseOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralEndpointProtocolOption FromMutable(ScriptDom.LiteralEndpointProtocolOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralEndpointProtocolOption))) { throw new NotImplementedException("Unexpected subtype of LiteralEndpointProtocolOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralEndpointProtocolOption(
                @value: FromMutable(fragment.Value),
                kind: fragment.Kind
            );
        }
        
        public static LiteralOpenRowsetCosmosOption FromMutable(ScriptDom.LiteralOpenRowsetCosmosOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralOpenRowsetCosmosOption))) { throw new NotImplementedException("Unexpected subtype of LiteralOpenRowsetCosmosOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralOpenRowsetCosmosOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralOptimizerHint FromMutable(ScriptDom.LiteralOptimizerHint fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralOptimizerHint))) { throw new NotImplementedException("Unexpected subtype of LiteralOptimizerHint not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralOptimizerHint(
                @value: FromMutable(fragment.Value),
                hintKind: fragment.HintKind
            );
        }
        
        public static LiteralOptionValue FromMutable(ScriptDom.LiteralOptionValue fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralOptionValue))) { throw new NotImplementedException("Unexpected subtype of LiteralOptionValue not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralOptionValue(
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static LiteralPayloadOption FromMutable(ScriptDom.LiteralPayloadOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralPayloadOption))) { throw new NotImplementedException("Unexpected subtype of LiteralPayloadOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralPayloadOption(
                @value: FromMutable(fragment.Value),
                kind: fragment.Kind
            );
        }
        
        public static LiteralPrincipalOption FromMutable(ScriptDom.LiteralPrincipalOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralPrincipalOption))) { throw new NotImplementedException("Unexpected subtype of LiteralPrincipalOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralPrincipalOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralRange FromMutable(ScriptDom.LiteralRange fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralRange))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as LiteralRange; }
            return new LiteralRange(
                from: FromMutable(fragment.From),
                to: FromMutable(fragment.To)
            );
        }
        
        public static LiteralReplicaOption FromMutable(ScriptDom.LiteralReplicaOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralReplicaOption))) { throw new NotImplementedException("Unexpected subtype of LiteralReplicaOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralReplicaOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralSessionOption FromMutable(ScriptDom.LiteralSessionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralSessionOption))) { throw new NotImplementedException("Unexpected subtype of LiteralSessionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralSessionOption(
                @value: FromMutable(fragment.Value),
                unit: fragment.Unit,
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralStatisticsOption FromMutable(ScriptDom.LiteralStatisticsOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralStatisticsOption))) { throw new NotImplementedException("Unexpected subtype of LiteralStatisticsOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralStatisticsOption(
                literal: FromMutable(fragment.Literal),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralTableHint FromMutable(ScriptDom.LiteralTableHint fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LiteralTableHint))) { throw new NotImplementedException("Unexpected subtype of LiteralTableHint not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LiteralTableHint(
                @value: FromMutable(fragment.Value),
                hintKind: fragment.HintKind
            );
        }
        
        public static LocationOption FromMutable(ScriptDom.LocationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LocationOption))) { throw new NotImplementedException("Unexpected subtype of LocationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LocationOption(
                locationValue: FromMutable(fragment.LocationValue),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LockEscalationTableOption FromMutable(ScriptDom.LockEscalationTableOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LockEscalationTableOption))) { throw new NotImplementedException("Unexpected subtype of LockEscalationTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LockEscalationTableOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static LoginTypePayloadOption FromMutable(ScriptDom.LoginTypePayloadOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LoginTypePayloadOption))) { throw new NotImplementedException("Unexpected subtype of LoginTypePayloadOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LoginTypePayloadOption(
                isWindows: fragment.IsWindows,
                kind: fragment.Kind
            );
        }
        
        public static LowPriorityLockWaitAbortAfterWaitOption FromMutable(ScriptDom.LowPriorityLockWaitAbortAfterWaitOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LowPriorityLockWaitAbortAfterWaitOption))) { throw new NotImplementedException("Unexpected subtype of LowPriorityLockWaitAbortAfterWaitOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LowPriorityLockWaitAbortAfterWaitOption(
                abortAfterWait: fragment.AbortAfterWait,
                optionKind: fragment.OptionKind
            );
        }
        
        public static LowPriorityLockWaitMaxDurationOption FromMutable(ScriptDom.LowPriorityLockWaitMaxDurationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LowPriorityLockWaitMaxDurationOption))) { throw new NotImplementedException("Unexpected subtype of LowPriorityLockWaitMaxDurationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LowPriorityLockWaitMaxDurationOption(
                maxDuration: FromMutable(fragment.MaxDuration),
                unit: fragment.Unit,
                optionKind: fragment.OptionKind
            );
        }
        
        public static LowPriorityLockWaitTableSwitchOption FromMutable(ScriptDom.LowPriorityLockWaitTableSwitchOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.LowPriorityLockWaitTableSwitchOption))) { throw new NotImplementedException("Unexpected subtype of LowPriorityLockWaitTableSwitchOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LowPriorityLockWaitTableSwitchOption(
                options: fragment.Options.SelectList(FromMutable),
                optionKind: fragment.OptionKind
            );
        }
        
        public static MaxDispatchLatencySessionOption FromMutable(ScriptDom.MaxDispatchLatencySessionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MaxDispatchLatencySessionOption))) { throw new NotImplementedException("Unexpected subtype of MaxDispatchLatencySessionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MaxDispatchLatencySessionOption(
                isInfinite: fragment.IsInfinite,
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static MaxDopConfigurationOption FromMutable(ScriptDom.MaxDopConfigurationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MaxDopConfigurationOption))) { throw new NotImplementedException("Unexpected subtype of MaxDopConfigurationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MaxDopConfigurationOption(
                @value: FromMutable(fragment.Value),
                primary: fragment.Primary,
                optionKind: fragment.OptionKind,
                genericOptionKind: FromMutable(fragment.GenericOptionKind)
            );
        }
        
        public static MaxDurationOption FromMutable(ScriptDom.MaxDurationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MaxDurationOption))) { throw new NotImplementedException("Unexpected subtype of MaxDurationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MaxDurationOption(
                maxDuration: FromMutable(fragment.MaxDuration),
                unit: fragment.Unit,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MaxLiteral FromMutable(ScriptDom.MaxLiteral fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MaxLiteral))) { throw new NotImplementedException("Unexpected subtype of MaxLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MaxLiteral(
                @value: fragment.Value,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static MaxRolloverFilesAuditTargetOption FromMutable(ScriptDom.MaxRolloverFilesAuditTargetOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MaxRolloverFilesAuditTargetOption))) { throw new NotImplementedException("Unexpected subtype of MaxRolloverFilesAuditTargetOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MaxRolloverFilesAuditTargetOption(
                @value: FromMutable(fragment.Value),
                isUnlimited: fragment.IsUnlimited,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MaxSizeAuditTargetOption FromMutable(ScriptDom.MaxSizeAuditTargetOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MaxSizeAuditTargetOption))) { throw new NotImplementedException("Unexpected subtype of MaxSizeAuditTargetOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MaxSizeAuditTargetOption(
                isUnlimited: fragment.IsUnlimited,
                size: FromMutable(fragment.Size),
                unit: fragment.Unit,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MaxSizeDatabaseOption FromMutable(ScriptDom.MaxSizeDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MaxSizeDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of MaxSizeDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MaxSizeDatabaseOption(
                maxSize: FromMutable(fragment.MaxSize),
                units: fragment.Units,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MaxSizeFileDeclarationOption FromMutable(ScriptDom.MaxSizeFileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MaxSizeFileDeclarationOption))) { throw new NotImplementedException("Unexpected subtype of MaxSizeFileDeclarationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MaxSizeFileDeclarationOption(
                maxSize: FromMutable(fragment.MaxSize),
                units: fragment.Units,
                unlimited: fragment.Unlimited,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MemoryOptimizedTableOption FromMutable(ScriptDom.MemoryOptimizedTableOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MemoryOptimizedTableOption))) { throw new NotImplementedException("Unexpected subtype of MemoryOptimizedTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MemoryOptimizedTableOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MemoryPartitionSessionOption FromMutable(ScriptDom.MemoryPartitionSessionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MemoryPartitionSessionOption))) { throw new NotImplementedException("Unexpected subtype of MemoryPartitionSessionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MemoryPartitionSessionOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MergeActionClause FromMutable(ScriptDom.MergeActionClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MergeActionClause))) { throw new NotImplementedException("Unexpected subtype of MergeActionClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MergeActionClause(
                condition: fragment.Condition,
                searchCondition: FromMutable(fragment.SearchCondition),
                action: FromMutable(fragment.Action)
            );
        }
        
        public static MergeSpecification FromMutable(ScriptDom.MergeSpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MergeSpecification))) { throw new NotImplementedException("Unexpected subtype of MergeSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MergeSpecification(
                tableAlias: FromMutable(fragment.TableAlias),
                tableReference: FromMutable(fragment.TableReference),
                searchCondition: FromMutable(fragment.SearchCondition),
                actionClauses: fragment.ActionClauses.SelectList(FromMutable),
                target: FromMutable(fragment.Target),
                topRowFilter: FromMutable(fragment.TopRowFilter),
                outputIntoClause: FromMutable(fragment.OutputIntoClause),
                outputClause: FromMutable(fragment.OutputClause)
            );
        }
        
        public static MergeStatement FromMutable(ScriptDom.MergeStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MergeStatement))) { throw new NotImplementedException("Unexpected subtype of MergeStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MergeStatement(
                mergeSpecification: FromMutable(fragment.MergeSpecification),
                withCtesAndXmlNamespaces: FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.SelectList(FromMutable)
            );
        }
        
        public static MethodSpecifier FromMutable(ScriptDom.MethodSpecifier fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MethodSpecifier))) { throw new NotImplementedException("Unexpected subtype of MethodSpecifier not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MethodSpecifier(
                assemblyName: FromMutable(fragment.AssemblyName),
                className: FromMutable(fragment.ClassName),
                methodName: FromMutable(fragment.MethodName)
            );
        }
        
        public static MirrorToClause FromMutable(ScriptDom.MirrorToClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MirrorToClause))) { throw new NotImplementedException("Unexpected subtype of MirrorToClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MirrorToClause(
                devices: fragment.Devices.SelectList(FromMutable)
            );
        }
        
        public static MoneyLiteral FromMutable(ScriptDom.MoneyLiteral fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MoneyLiteral))) { throw new NotImplementedException("Unexpected subtype of MoneyLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MoneyLiteral(
                @value: fragment.Value,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static MoveConversationStatement FromMutable(ScriptDom.MoveConversationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MoveConversationStatement))) { throw new NotImplementedException("Unexpected subtype of MoveConversationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MoveConversationStatement(
                conversation: FromMutable(fragment.Conversation),
                group: FromMutable(fragment.Group)
            );
        }
        
        public static MoveRestoreOption FromMutable(ScriptDom.MoveRestoreOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MoveRestoreOption))) { throw new NotImplementedException("Unexpected subtype of MoveRestoreOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MoveRestoreOption(
                logicalFileName: FromMutable(fragment.LogicalFileName),
                oSFileName: FromMutable(fragment.OSFileName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static MoveToDropIndexOption FromMutable(ScriptDom.MoveToDropIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MoveToDropIndexOption))) { throw new NotImplementedException("Unexpected subtype of MoveToDropIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MoveToDropIndexOption(
                moveTo: FromMutable(fragment.MoveTo),
                optionKind: fragment.OptionKind
            );
        }
        
        public static MultiPartIdentifier FromMutable(ScriptDom.MultiPartIdentifier fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MultiPartIdentifier))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as MultiPartIdentifier; }
            return new MultiPartIdentifier(
                identifiers: fragment.Identifiers.SelectList(FromMutable)
            );
        }
        
        public static MultiPartIdentifierCallTarget FromMutable(ScriptDom.MultiPartIdentifierCallTarget fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.MultiPartIdentifierCallTarget))) { throw new NotImplementedException("Unexpected subtype of MultiPartIdentifierCallTarget not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MultiPartIdentifierCallTarget(
                multiPartIdentifier: FromMutable(fragment.MultiPartIdentifier)
            );
        }
        
        public static NamedTableReference FromMutable(ScriptDom.NamedTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.NamedTableReference))) { throw new NotImplementedException("Unexpected subtype of NamedTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new NamedTableReference(
                schemaObject: FromMutable(fragment.SchemaObject),
                tableHints: fragment.TableHints.SelectList(FromMutable),
                tableSampleClause: FromMutable(fragment.TableSampleClause),
                temporalClause: FromMutable(fragment.TemporalClause),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static NameFileDeclarationOption FromMutable(ScriptDom.NameFileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.NameFileDeclarationOption))) { throw new NotImplementedException("Unexpected subtype of NameFileDeclarationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new NameFileDeclarationOption(
                logicalFileName: FromMutable(fragment.LogicalFileName),
                isNewName: fragment.IsNewName,
                optionKind: fragment.OptionKind
            );
        }
        
        public static NextValueForExpression FromMutable(ScriptDom.NextValueForExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.NextValueForExpression))) { throw new NotImplementedException("Unexpected subtype of NextValueForExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new NextValueForExpression(
                sequenceName: FromMutable(fragment.SequenceName),
                overClause: FromMutable(fragment.OverClause),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static NullableConstraintDefinition FromMutable(ScriptDom.NullableConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.NullableConstraintDefinition))) { throw new NotImplementedException("Unexpected subtype of NullableConstraintDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new NullableConstraintDefinition(
                nullable: fragment.Nullable,
                constraintIdentifier: FromMutable(fragment.ConstraintIdentifier)
            );
        }
        
        public static NullIfExpression FromMutable(ScriptDom.NullIfExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.NullIfExpression))) { throw new NotImplementedException("Unexpected subtype of NullIfExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new NullIfExpression(
                firstExpression: FromMutable(fragment.FirstExpression),
                secondExpression: FromMutable(fragment.SecondExpression),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static NullLiteral FromMutable(ScriptDom.NullLiteral fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.NullLiteral))) { throw new NotImplementedException("Unexpected subtype of NullLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new NullLiteral(
                @value: fragment.Value,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static NumericLiteral FromMutable(ScriptDom.NumericLiteral fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.NumericLiteral))) { throw new NotImplementedException("Unexpected subtype of NumericLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new NumericLiteral(
                @value: fragment.Value,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static OdbcConvertSpecification FromMutable(ScriptDom.OdbcConvertSpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OdbcConvertSpecification))) { throw new NotImplementedException("Unexpected subtype of OdbcConvertSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OdbcConvertSpecification(
                identifier: FromMutable(fragment.Identifier)
            );
        }
        
        public static OdbcFunctionCall FromMutable(ScriptDom.OdbcFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OdbcFunctionCall))) { throw new NotImplementedException("Unexpected subtype of OdbcFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OdbcFunctionCall(
                name: FromMutable(fragment.Name),
                parametersUsed: fragment.ParametersUsed,
                parameters: fragment.Parameters.SelectList(FromMutable),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static OdbcLiteral FromMutable(ScriptDom.OdbcLiteral fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OdbcLiteral))) { throw new NotImplementedException("Unexpected subtype of OdbcLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OdbcLiteral(
                odbcLiteralType: fragment.OdbcLiteralType,
                isNational: fragment.IsNational,
                @value: fragment.Value,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static OdbcQualifiedJoinTableReference FromMutable(ScriptDom.OdbcQualifiedJoinTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OdbcQualifiedJoinTableReference))) { throw new NotImplementedException("Unexpected subtype of OdbcQualifiedJoinTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OdbcQualifiedJoinTableReference(
                tableReference: FromMutable(fragment.TableReference)
            );
        }
        
        public static OffsetClause FromMutable(ScriptDom.OffsetClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OffsetClause))) { throw new NotImplementedException("Unexpected subtype of OffsetClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OffsetClause(
                offsetExpression: FromMutable(fragment.OffsetExpression),
                fetchExpression: FromMutable(fragment.FetchExpression)
            );
        }
        
        public static OnFailureAuditOption FromMutable(ScriptDom.OnFailureAuditOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnFailureAuditOption))) { throw new NotImplementedException("Unexpected subtype of OnFailureAuditOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnFailureAuditOption(
                onFailureAction: fragment.OnFailureAction,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnlineIndexLowPriorityLockWaitOption FromMutable(ScriptDom.OnlineIndexLowPriorityLockWaitOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnlineIndexLowPriorityLockWaitOption))) { throw new NotImplementedException("Unexpected subtype of OnlineIndexLowPriorityLockWaitOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnlineIndexLowPriorityLockWaitOption(
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static OnlineIndexOption FromMutable(ScriptDom.OnlineIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnlineIndexOption))) { throw new NotImplementedException("Unexpected subtype of OnlineIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnlineIndexOption(
                lowPriorityLockWaitOption: FromMutable(fragment.LowPriorityLockWaitOption),
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffAssemblyOption FromMutable(ScriptDom.OnOffAssemblyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnOffAssemblyOption))) { throw new NotImplementedException("Unexpected subtype of OnOffAssemblyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffAssemblyOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffAtomicBlockOption FromMutable(ScriptDom.OnOffAtomicBlockOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnOffAtomicBlockOption))) { throw new NotImplementedException("Unexpected subtype of OnOffAtomicBlockOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffAtomicBlockOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffAuditTargetOption FromMutable(ScriptDom.OnOffAuditTargetOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnOffAuditTargetOption))) { throw new NotImplementedException("Unexpected subtype of OnOffAuditTargetOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffAuditTargetOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffDatabaseOption FromMutable(ScriptDom.OnOffDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnOffDatabaseOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as OnOffDatabaseOption; }
            return new OnOffDatabaseOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffDialogOption FromMutable(ScriptDom.OnOffDialogOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnOffDialogOption))) { throw new NotImplementedException("Unexpected subtype of OnOffDialogOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffDialogOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffFullTextCatalogOption FromMutable(ScriptDom.OnOffFullTextCatalogOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnOffFullTextCatalogOption))) { throw new NotImplementedException("Unexpected subtype of OnOffFullTextCatalogOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffFullTextCatalogOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffOptionValue FromMutable(ScriptDom.OnOffOptionValue fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnOffOptionValue))) { throw new NotImplementedException("Unexpected subtype of OnOffOptionValue not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffOptionValue(
                optionState: fragment.OptionState
            );
        }
        
        public static OnOffPrimaryConfigurationOption FromMutable(ScriptDom.OnOffPrimaryConfigurationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnOffPrimaryConfigurationOption))) { throw new NotImplementedException("Unexpected subtype of OnOffPrimaryConfigurationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffPrimaryConfigurationOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind,
                genericOptionKind: FromMutable(fragment.GenericOptionKind)
            );
        }
        
        public static OnOffPrincipalOption FromMutable(ScriptDom.OnOffPrincipalOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnOffPrincipalOption))) { throw new NotImplementedException("Unexpected subtype of OnOffPrincipalOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffPrincipalOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffRemoteServiceBindingOption FromMutable(ScriptDom.OnOffRemoteServiceBindingOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnOffRemoteServiceBindingOption))) { throw new NotImplementedException("Unexpected subtype of OnOffRemoteServiceBindingOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffRemoteServiceBindingOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffSessionOption FromMutable(ScriptDom.OnOffSessionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnOffSessionOption))) { throw new NotImplementedException("Unexpected subtype of OnOffSessionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffSessionOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffStatisticsOption FromMutable(ScriptDom.OnOffStatisticsOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OnOffStatisticsOption))) { throw new NotImplementedException("Unexpected subtype of OnOffStatisticsOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OnOffStatisticsOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OpenCursorStatement FromMutable(ScriptDom.OpenCursorStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OpenCursorStatement))) { throw new NotImplementedException("Unexpected subtype of OpenCursorStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OpenCursorStatement(
                cursor: FromMutable(fragment.Cursor)
            );
        }
        
        public static OpenJsonTableReference FromMutable(ScriptDom.OpenJsonTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OpenJsonTableReference))) { throw new NotImplementedException("Unexpected subtype of OpenJsonTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OpenJsonTableReference(
                variable: FromMutable(fragment.Variable),
                rowPattern: FromMutable(fragment.RowPattern),
                schemaDeclarationItems: fragment.SchemaDeclarationItems.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static OpenMasterKeyStatement FromMutable(ScriptDom.OpenMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OpenMasterKeyStatement))) { throw new NotImplementedException("Unexpected subtype of OpenMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OpenMasterKeyStatement(
                password: FromMutable(fragment.Password)
            );
        }
        
        public static OpenQueryTableReference FromMutable(ScriptDom.OpenQueryTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OpenQueryTableReference))) { throw new NotImplementedException("Unexpected subtype of OpenQueryTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OpenQueryTableReference(
                linkedServer: FromMutable(fragment.LinkedServer),
                query: FromMutable(fragment.Query),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static OpenRowsetColumnDefinition FromMutable(ScriptDom.OpenRowsetColumnDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OpenRowsetColumnDefinition))) { throw new NotImplementedException("Unexpected subtype of OpenRowsetColumnDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OpenRowsetColumnDefinition(
                columnOrdinal: FromMutable(fragment.ColumnOrdinal),
                jsonPath: FromMutable(fragment.JsonPath),
                columnIdentifier: FromMutable(fragment.ColumnIdentifier),
                dataType: FromMutable(fragment.DataType),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static OpenRowsetCosmos FromMutable(ScriptDom.OpenRowsetCosmos fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OpenRowsetCosmos))) { throw new NotImplementedException("Unexpected subtype of OpenRowsetCosmos not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OpenRowsetCosmos(
                options: fragment.Options.SelectList(FromMutable),
                withColumns: fragment.WithColumns.SelectList(FromMutable),
                columns: fragment.Columns.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static OpenRowsetCosmosOption FromMutable(ScriptDom.OpenRowsetCosmosOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OpenRowsetCosmosOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as OpenRowsetCosmosOption; }
            return new OpenRowsetCosmosOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static OpenRowsetTableReference FromMutable(ScriptDom.OpenRowsetTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OpenRowsetTableReference))) { throw new NotImplementedException("Unexpected subtype of OpenRowsetTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OpenRowsetTableReference(
                providerName: FromMutable(fragment.ProviderName),
                dataSource: FromMutable(fragment.DataSource),
                userId: FromMutable(fragment.UserId),
                password: FromMutable(fragment.Password),
                providerString: FromMutable(fragment.ProviderString),
                query: FromMutable(fragment.Query),
                @object: FromMutable(fragment.Object),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static OpenSymmetricKeyStatement FromMutable(ScriptDom.OpenSymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OpenSymmetricKeyStatement))) { throw new NotImplementedException("Unexpected subtype of OpenSymmetricKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OpenSymmetricKeyStatement(
                name: FromMutable(fragment.Name),
                decryptionMechanism: FromMutable(fragment.DecryptionMechanism)
            );
        }
        
        public static OpenXmlTableReference FromMutable(ScriptDom.OpenXmlTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OpenXmlTableReference))) { throw new NotImplementedException("Unexpected subtype of OpenXmlTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OpenXmlTableReference(
                variable: FromMutable(fragment.Variable),
                rowPattern: FromMutable(fragment.RowPattern),
                flags: FromMutable(fragment.Flags),
                schemaDeclarationItems: fragment.SchemaDeclarationItems.SelectList(FromMutable),
                tableName: FromMutable(fragment.TableName),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static OperatorAuditOption FromMutable(ScriptDom.OperatorAuditOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OperatorAuditOption))) { throw new NotImplementedException("Unexpected subtype of OperatorAuditOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OperatorAuditOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OptimizeForOptimizerHint FromMutable(ScriptDom.OptimizeForOptimizerHint fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OptimizeForOptimizerHint))) { throw new NotImplementedException("Unexpected subtype of OptimizeForOptimizerHint not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OptimizeForOptimizerHint(
                pairs: fragment.Pairs.SelectList(FromMutable),
                isForUnknown: fragment.IsForUnknown,
                hintKind: fragment.HintKind
            );
        }
        
        public static OptimizerHint FromMutable(ScriptDom.OptimizerHint fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OptimizerHint))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as OptimizerHint; }
            return new OptimizerHint(
                hintKind: fragment.HintKind
            );
        }
        
        public static OrderBulkInsertOption FromMutable(ScriptDom.OrderBulkInsertOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OrderBulkInsertOption))) { throw new NotImplementedException("Unexpected subtype of OrderBulkInsertOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OrderBulkInsertOption(
                columns: fragment.Columns.SelectList(FromMutable),
                isUnique: fragment.IsUnique,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OrderByClause FromMutable(ScriptDom.OrderByClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OrderByClause))) { throw new NotImplementedException("Unexpected subtype of OrderByClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OrderByClause(
                orderByElements: fragment.OrderByElements.SelectList(FromMutable)
            );
        }
        
        public static OrderIndexOption FromMutable(ScriptDom.OrderIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OrderIndexOption))) { throw new NotImplementedException("Unexpected subtype of OrderIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OrderIndexOption(
                columns: fragment.Columns.SelectList(FromMutable),
                optionKind: fragment.OptionKind
            );
        }
        
        public static OutputClause FromMutable(ScriptDom.OutputClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OutputClause))) { throw new NotImplementedException("Unexpected subtype of OutputClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OutputClause(
                selectColumns: fragment.SelectColumns.SelectList(FromMutable)
            );
        }
        
        public static OutputIntoClause FromMutable(ScriptDom.OutputIntoClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OutputIntoClause))) { throw new NotImplementedException("Unexpected subtype of OutputIntoClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OutputIntoClause(
                selectColumns: fragment.SelectColumns.SelectList(FromMutable),
                intoTable: FromMutable(fragment.IntoTable),
                intoTableColumns: fragment.IntoTableColumns.SelectList(FromMutable)
            );
        }
        
        public static OverClause FromMutable(ScriptDom.OverClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.OverClause))) { throw new NotImplementedException("Unexpected subtype of OverClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OverClause(
                windowName: FromMutable(fragment.WindowName),
                partitions: fragment.Partitions.SelectList(FromMutable),
                orderByClause: FromMutable(fragment.OrderByClause),
                windowFrameClause: FromMutable(fragment.WindowFrameClause)
            );
        }
        
        public static PageVerifyDatabaseOption FromMutable(ScriptDom.PageVerifyDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PageVerifyDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of PageVerifyDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PageVerifyDatabaseOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static ParameterizationDatabaseOption FromMutable(ScriptDom.ParameterizationDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ParameterizationDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of ParameterizationDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ParameterizationDatabaseOption(
                isSimple: fragment.IsSimple,
                optionKind: fragment.OptionKind
            );
        }
        
        public static ParameterlessCall FromMutable(ScriptDom.ParameterlessCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ParameterlessCall))) { throw new NotImplementedException("Unexpected subtype of ParameterlessCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ParameterlessCall(
                parameterlessCallType: fragment.ParameterlessCallType,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static ParenthesisExpression FromMutable(ScriptDom.ParenthesisExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ParenthesisExpression))) { throw new NotImplementedException("Unexpected subtype of ParenthesisExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ParenthesisExpression(
                expression: FromMutable(fragment.Expression),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static ParseCall FromMutable(ScriptDom.ParseCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ParseCall))) { throw new NotImplementedException("Unexpected subtype of ParseCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ParseCall(
                stringValue: FromMutable(fragment.StringValue),
                dataType: FromMutable(fragment.DataType),
                culture: FromMutable(fragment.Culture),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static PartitionFunctionCall FromMutable(ScriptDom.PartitionFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PartitionFunctionCall))) { throw new NotImplementedException("Unexpected subtype of PartitionFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PartitionFunctionCall(
                databaseName: FromMutable(fragment.DatabaseName),
                functionName: FromMutable(fragment.FunctionName),
                parameters: fragment.Parameters.SelectList(FromMutable),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static PartitionParameterType FromMutable(ScriptDom.PartitionParameterType fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PartitionParameterType))) { throw new NotImplementedException("Unexpected subtype of PartitionParameterType not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PartitionParameterType(
                dataType: FromMutable(fragment.DataType),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static PartitionSpecifier FromMutable(ScriptDom.PartitionSpecifier fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PartitionSpecifier))) { throw new NotImplementedException("Unexpected subtype of PartitionSpecifier not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PartitionSpecifier(
                number: FromMutable(fragment.Number),
                all: fragment.All
            );
        }
        
        public static PartnerDatabaseOption FromMutable(ScriptDom.PartnerDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PartnerDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of PartnerDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PartnerDatabaseOption(
                partnerServer: FromMutable(fragment.PartnerServer),
                partnerOption: fragment.PartnerOption,
                timeout: FromMutable(fragment.Timeout),
                optionKind: fragment.OptionKind
            );
        }
        
        public static PasswordAlterPrincipalOption FromMutable(ScriptDom.PasswordAlterPrincipalOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PasswordAlterPrincipalOption))) { throw new NotImplementedException("Unexpected subtype of PasswordAlterPrincipalOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PasswordAlterPrincipalOption(
                password: FromMutable(fragment.Password),
                oldPassword: FromMutable(fragment.OldPassword),
                mustChange: fragment.MustChange,
                unlock: fragment.Unlock,
                hashed: fragment.Hashed,
                optionKind: fragment.OptionKind
            );
        }
        
        public static PasswordCreateLoginSource FromMutable(ScriptDom.PasswordCreateLoginSource fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PasswordCreateLoginSource))) { throw new NotImplementedException("Unexpected subtype of PasswordCreateLoginSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PasswordCreateLoginSource(
                password: FromMutable(fragment.Password),
                hashed: fragment.Hashed,
                mustChange: fragment.MustChange,
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static Permission FromMutable(ScriptDom.Permission fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.Permission))) { throw new NotImplementedException("Unexpected subtype of Permission not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new Permission(
                identifiers: fragment.Identifiers.SelectList(FromMutable),
                columns: fragment.Columns.SelectList(FromMutable)
            );
        }
        
        public static PermissionSetAssemblyOption FromMutable(ScriptDom.PermissionSetAssemblyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PermissionSetAssemblyOption))) { throw new NotImplementedException("Unexpected subtype of PermissionSetAssemblyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PermissionSetAssemblyOption(
                permissionSetOption: fragment.PermissionSetOption,
                optionKind: fragment.OptionKind
            );
        }
        
        public static PivotedTableReference FromMutable(ScriptDom.PivotedTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PivotedTableReference))) { throw new NotImplementedException("Unexpected subtype of PivotedTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PivotedTableReference(
                tableReference: FromMutable(fragment.TableReference),
                inColumns: fragment.InColumns.SelectList(FromMutable),
                pivotColumn: FromMutable(fragment.PivotColumn),
                valueColumns: fragment.ValueColumns.SelectList(FromMutable),
                aggregateFunctionIdentifier: FromMutable(fragment.AggregateFunctionIdentifier),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static PortsEndpointProtocolOption FromMutable(ScriptDom.PortsEndpointProtocolOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PortsEndpointProtocolOption))) { throw new NotImplementedException("Unexpected subtype of PortsEndpointProtocolOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PortsEndpointProtocolOption(
                portTypes: fragment.PortTypes,
                kind: fragment.Kind
            );
        }
        
        public static PredicateSetStatement FromMutable(ScriptDom.PredicateSetStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PredicateSetStatement))) { throw new NotImplementedException("Unexpected subtype of PredicateSetStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PredicateSetStatement(
                options: fragment.Options,
                isOn: fragment.IsOn
            );
        }
        
        public static PredictTableReference FromMutable(ScriptDom.PredictTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PredictTableReference))) { throw new NotImplementedException("Unexpected subtype of PredictTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PredictTableReference(
                modelVariable: FromMutable(fragment.ModelVariable),
                modelSubquery: FromMutable(fragment.ModelSubquery),
                dataSource: FromMutable(fragment.DataSource),
                runTime: FromMutable(fragment.RunTime),
                schemaDeclarationItems: fragment.SchemaDeclarationItems.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static PrimaryRoleReplicaOption FromMutable(ScriptDom.PrimaryRoleReplicaOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PrimaryRoleReplicaOption))) { throw new NotImplementedException("Unexpected subtype of PrimaryRoleReplicaOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PrimaryRoleReplicaOption(
                allowConnections: fragment.AllowConnections,
                optionKind: fragment.OptionKind
            );
        }
        
        public static PrincipalOption FromMutable(ScriptDom.PrincipalOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PrincipalOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as PrincipalOption; }
            return new PrincipalOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static PrintStatement FromMutable(ScriptDom.PrintStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PrintStatement))) { throw new NotImplementedException("Unexpected subtype of PrintStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PrintStatement(
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static Privilege80 FromMutable(ScriptDom.Privilege80 fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.Privilege80))) { throw new NotImplementedException("Unexpected subtype of Privilege80 not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new Privilege80(
                columns: fragment.Columns.SelectList(FromMutable),
                privilegeType80: fragment.PrivilegeType80
            );
        }
        
        public static PrivilegeSecurityElement80 FromMutable(ScriptDom.PrivilegeSecurityElement80 fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.PrivilegeSecurityElement80))) { throw new NotImplementedException("Unexpected subtype of PrivilegeSecurityElement80 not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PrivilegeSecurityElement80(
                privileges: fragment.Privileges.SelectList(FromMutable),
                schemaObjectName: FromMutable(fragment.SchemaObjectName),
                columns: fragment.Columns.SelectList(FromMutable)
            );
        }
        
        public static ProcedureOption FromMutable(ScriptDom.ProcedureOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ProcedureOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as ProcedureOption; }
            return new ProcedureOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static ProcedureParameter FromMutable(ScriptDom.ProcedureParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ProcedureParameter))) { throw new NotImplementedException("Unexpected subtype of ProcedureParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ProcedureParameter(
                isVarying: fragment.IsVarying,
                modifier: fragment.Modifier,
                variableName: FromMutable(fragment.VariableName),
                dataType: FromMutable(fragment.DataType),
                nullable: FromMutable(fragment.Nullable),
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static ProcedureReference FromMutable(ScriptDom.ProcedureReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ProcedureReference))) { throw new NotImplementedException("Unexpected subtype of ProcedureReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ProcedureReference(
                name: FromMutable(fragment.Name),
                number: FromMutable(fragment.Number)
            );
        }
        
        public static ProcedureReferenceName FromMutable(ScriptDom.ProcedureReferenceName fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ProcedureReferenceName))) { throw new NotImplementedException("Unexpected subtype of ProcedureReferenceName not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ProcedureReferenceName(
                procedureReference: FromMutable(fragment.ProcedureReference),
                procedureVariable: FromMutable(fragment.ProcedureVariable)
            );
        }
        
        public static ProcessAffinityRange FromMutable(ScriptDom.ProcessAffinityRange fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ProcessAffinityRange))) { throw new NotImplementedException("Unexpected subtype of ProcessAffinityRange not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ProcessAffinityRange(
                from: FromMutable(fragment.From),
                to: FromMutable(fragment.To)
            );
        }
        
        public static ProviderEncryptionSource FromMutable(ScriptDom.ProviderEncryptionSource fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ProviderEncryptionSource))) { throw new NotImplementedException("Unexpected subtype of ProviderEncryptionSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ProviderEncryptionSource(
                name: FromMutable(fragment.Name),
                keyOptions: fragment.KeyOptions.SelectList(FromMutable)
            );
        }
        
        public static ProviderKeyNameKeyOption FromMutable(ScriptDom.ProviderKeyNameKeyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ProviderKeyNameKeyOption))) { throw new NotImplementedException("Unexpected subtype of ProviderKeyNameKeyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ProviderKeyNameKeyOption(
                keyName: FromMutable(fragment.KeyName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QualifiedJoin FromMutable(ScriptDom.QualifiedJoin fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QualifiedJoin))) { throw new NotImplementedException("Unexpected subtype of QualifiedJoin not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QualifiedJoin(
                searchCondition: FromMutable(fragment.SearchCondition),
                qualifiedJoinType: fragment.QualifiedJoinType,
                joinHint: fragment.JoinHint,
                firstTableReference: FromMutable(fragment.FirstTableReference),
                secondTableReference: FromMutable(fragment.SecondTableReference)
            );
        }
        
        public static QueryDerivedTable FromMutable(ScriptDom.QueryDerivedTable fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueryDerivedTable))) { throw new NotImplementedException("Unexpected subtype of QueryDerivedTable not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryDerivedTable(
                queryExpression: FromMutable(fragment.QueryExpression),
                columns: fragment.Columns.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static QueryParenthesisExpression FromMutable(ScriptDom.QueryParenthesisExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueryParenthesisExpression))) { throw new NotImplementedException("Unexpected subtype of QueryParenthesisExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryParenthesisExpression(
                queryExpression: FromMutable(fragment.QueryExpression),
                orderByClause: FromMutable(fragment.OrderByClause),
                offsetClause: FromMutable(fragment.OffsetClause),
                forClause: FromMutable(fragment.ForClause)
            );
        }
        
        public static QuerySpecification FromMutable(ScriptDom.QuerySpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QuerySpecification))) { throw new NotImplementedException("Unexpected subtype of QuerySpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QuerySpecification(
                uniqueRowFilter: fragment.UniqueRowFilter,
                topRowFilter: FromMutable(fragment.TopRowFilter),
                selectElements: fragment.SelectElements.SelectList(FromMutable),
                fromClause: FromMutable(fragment.FromClause),
                whereClause: FromMutable(fragment.WhereClause),
                groupByClause: FromMutable(fragment.GroupByClause),
                havingClause: FromMutable(fragment.HavingClause),
                windowClause: FromMutable(fragment.WindowClause),
                orderByClause: FromMutable(fragment.OrderByClause),
                offsetClause: FromMutable(fragment.OffsetClause),
                forClause: FromMutable(fragment.ForClause)
            );
        }
        
        public static QueryStoreCapturePolicyOption FromMutable(ScriptDom.QueryStoreCapturePolicyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueryStoreCapturePolicyOption))) { throw new NotImplementedException("Unexpected subtype of QueryStoreCapturePolicyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreCapturePolicyOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreDatabaseOption FromMutable(ScriptDom.QueryStoreDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueryStoreDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of QueryStoreDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreDatabaseOption(
                clear: fragment.Clear,
                clearAll: fragment.ClearAll,
                optionState: fragment.OptionState,
                options: fragment.Options.SelectList(FromMutable),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreDataFlushIntervalOption FromMutable(ScriptDom.QueryStoreDataFlushIntervalOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueryStoreDataFlushIntervalOption))) { throw new NotImplementedException("Unexpected subtype of QueryStoreDataFlushIntervalOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreDataFlushIntervalOption(
                flushInterval: FromMutable(fragment.FlushInterval),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreDesiredStateOption FromMutable(ScriptDom.QueryStoreDesiredStateOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueryStoreDesiredStateOption))) { throw new NotImplementedException("Unexpected subtype of QueryStoreDesiredStateOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreDesiredStateOption(
                @value: fragment.Value,
                operationModeSpecified: fragment.OperationModeSpecified,
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreIntervalLengthOption FromMutable(ScriptDom.QueryStoreIntervalLengthOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueryStoreIntervalLengthOption))) { throw new NotImplementedException("Unexpected subtype of QueryStoreIntervalLengthOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreIntervalLengthOption(
                statsIntervalLength: FromMutable(fragment.StatsIntervalLength),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreMaxPlansPerQueryOption FromMutable(ScriptDom.QueryStoreMaxPlansPerQueryOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueryStoreMaxPlansPerQueryOption))) { throw new NotImplementedException("Unexpected subtype of QueryStoreMaxPlansPerQueryOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreMaxPlansPerQueryOption(
                maxPlansPerQuery: FromMutable(fragment.MaxPlansPerQuery),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreMaxStorageSizeOption FromMutable(ScriptDom.QueryStoreMaxStorageSizeOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueryStoreMaxStorageSizeOption))) { throw new NotImplementedException("Unexpected subtype of QueryStoreMaxStorageSizeOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreMaxStorageSizeOption(
                maxQdsSize: FromMutable(fragment.MaxQdsSize),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreSizeCleanupPolicyOption FromMutable(ScriptDom.QueryStoreSizeCleanupPolicyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueryStoreSizeCleanupPolicyOption))) { throw new NotImplementedException("Unexpected subtype of QueryStoreSizeCleanupPolicyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreSizeCleanupPolicyOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreTimeCleanupPolicyOption FromMutable(ScriptDom.QueryStoreTimeCleanupPolicyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueryStoreTimeCleanupPolicyOption))) { throw new NotImplementedException("Unexpected subtype of QueryStoreTimeCleanupPolicyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryStoreTimeCleanupPolicyOption(
                staleQueryThreshold: FromMutable(fragment.StaleQueryThreshold),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueueDelayAuditOption FromMutable(ScriptDom.QueueDelayAuditOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueueDelayAuditOption))) { throw new NotImplementedException("Unexpected subtype of QueueDelayAuditOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueueDelayAuditOption(
                delay: FromMutable(fragment.Delay),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueueExecuteAsOption FromMutable(ScriptDom.QueueExecuteAsOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueueExecuteAsOption))) { throw new NotImplementedException("Unexpected subtype of QueueExecuteAsOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueueExecuteAsOption(
                optionValue: FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueueOption FromMutable(ScriptDom.QueueOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueueOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as QueueOption; }
            return new QueueOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueueProcedureOption FromMutable(ScriptDom.QueueProcedureOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueueProcedureOption))) { throw new NotImplementedException("Unexpected subtype of QueueProcedureOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueueProcedureOption(
                optionValue: FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueueStateOption FromMutable(ScriptDom.QueueStateOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueueStateOption))) { throw new NotImplementedException("Unexpected subtype of QueueStateOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueueStateOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueueValueOption FromMutable(ScriptDom.QueueValueOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.QueueValueOption))) { throw new NotImplementedException("Unexpected subtype of QueueValueOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueueValueOption(
                optionValue: FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind
            );
        }
        
        public static RaiseErrorLegacyStatement FromMutable(ScriptDom.RaiseErrorLegacyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RaiseErrorLegacyStatement))) { throw new NotImplementedException("Unexpected subtype of RaiseErrorLegacyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RaiseErrorLegacyStatement(
                firstParameter: FromMutable(fragment.FirstParameter),
                secondParameter: FromMutable(fragment.SecondParameter)
            );
        }
        
        public static RaiseErrorStatement FromMutable(ScriptDom.RaiseErrorStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RaiseErrorStatement))) { throw new NotImplementedException("Unexpected subtype of RaiseErrorStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RaiseErrorStatement(
                firstParameter: FromMutable(fragment.FirstParameter),
                secondParameter: FromMutable(fragment.SecondParameter),
                thirdParameter: FromMutable(fragment.ThirdParameter),
                optionalParameters: fragment.OptionalParameters.SelectList(FromMutable),
                raiseErrorOptions: fragment.RaiseErrorOptions
            );
        }
        
        public static ReadOnlyForClause FromMutable(ScriptDom.ReadOnlyForClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ReadOnlyForClause))) { throw new NotImplementedException("Unexpected subtype of ReadOnlyForClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ReadOnlyForClause(
                
            );
        }
        
        public static ReadTextStatement FromMutable(ScriptDom.ReadTextStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ReadTextStatement))) { throw new NotImplementedException("Unexpected subtype of ReadTextStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ReadTextStatement(
                column: FromMutable(fragment.Column),
                textPointer: FromMutable(fragment.TextPointer),
                offset: FromMutable(fragment.Offset),
                size: FromMutable(fragment.Size),
                holdLock: fragment.HoldLock
            );
        }
        
        public static RealLiteral FromMutable(ScriptDom.RealLiteral fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RealLiteral))) { throw new NotImplementedException("Unexpected subtype of RealLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RealLiteral(
                @value: fragment.Value,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static ReceiveStatement FromMutable(ScriptDom.ReceiveStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ReceiveStatement))) { throw new NotImplementedException("Unexpected subtype of ReceiveStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ReceiveStatement(
                top: FromMutable(fragment.Top),
                selectElements: fragment.SelectElements.SelectList(FromMutable),
                queue: FromMutable(fragment.Queue),
                into: FromMutable(fragment.Into),
                where: FromMutable(fragment.Where),
                isConversationGroupIdWhere: fragment.IsConversationGroupIdWhere
            );
        }
        
        public static ReconfigureStatement FromMutable(ScriptDom.ReconfigureStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ReconfigureStatement))) { throw new NotImplementedException("Unexpected subtype of ReconfigureStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ReconfigureStatement(
                withOverride: fragment.WithOverride
            );
        }
        
        public static RecoveryDatabaseOption FromMutable(ScriptDom.RecoveryDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RecoveryDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of RecoveryDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RecoveryDatabaseOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static RemoteDataArchiveAlterTableOption FromMutable(ScriptDom.RemoteDataArchiveAlterTableOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RemoteDataArchiveAlterTableOption))) { throw new NotImplementedException("Unexpected subtype of RemoteDataArchiveAlterTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RemoteDataArchiveAlterTableOption(
                rdaTableOption: fragment.RdaTableOption,
                migrationState: fragment.MigrationState,
                isMigrationStateSpecified: fragment.IsMigrationStateSpecified,
                isFilterPredicateSpecified: fragment.IsFilterPredicateSpecified,
                filterPredicate: FromMutable(fragment.FilterPredicate),
                optionKind: fragment.OptionKind
            );
        }
        
        public static RemoteDataArchiveDatabaseOption FromMutable(ScriptDom.RemoteDataArchiveDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RemoteDataArchiveDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of RemoteDataArchiveDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RemoteDataArchiveDatabaseOption(
                optionState: fragment.OptionState,
                settings: fragment.Settings.SelectList(FromMutable),
                optionKind: fragment.OptionKind
            );
        }
        
        public static RemoteDataArchiveDbCredentialSetting FromMutable(ScriptDom.RemoteDataArchiveDbCredentialSetting fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RemoteDataArchiveDbCredentialSetting))) { throw new NotImplementedException("Unexpected subtype of RemoteDataArchiveDbCredentialSetting not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RemoteDataArchiveDbCredentialSetting(
                credential: FromMutable(fragment.Credential),
                settingKind: fragment.SettingKind
            );
        }
        
        public static RemoteDataArchiveDbFederatedServiceAccountSetting FromMutable(ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting))) { throw new NotImplementedException("Unexpected subtype of RemoteDataArchiveDbFederatedServiceAccountSetting not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RemoteDataArchiveDbFederatedServiceAccountSetting(
                isOn: fragment.IsOn,
                settingKind: fragment.SettingKind
            );
        }
        
        public static RemoteDataArchiveDbServerSetting FromMutable(ScriptDom.RemoteDataArchiveDbServerSetting fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RemoteDataArchiveDbServerSetting))) { throw new NotImplementedException("Unexpected subtype of RemoteDataArchiveDbServerSetting not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RemoteDataArchiveDbServerSetting(
                server: FromMutable(fragment.Server),
                settingKind: fragment.SettingKind
            );
        }
        
        public static RemoteDataArchiveTableOption FromMutable(ScriptDom.RemoteDataArchiveTableOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RemoteDataArchiveTableOption))) { throw new NotImplementedException("Unexpected subtype of RemoteDataArchiveTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RemoteDataArchiveTableOption(
                rdaTableOption: fragment.RdaTableOption,
                migrationState: fragment.MigrationState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static RenameAlterRoleAction FromMutable(ScriptDom.RenameAlterRoleAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RenameAlterRoleAction))) { throw new NotImplementedException("Unexpected subtype of RenameAlterRoleAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RenameAlterRoleAction(
                newName: FromMutable(fragment.NewName)
            );
        }
        
        public static RenameEntityStatement FromMutable(ScriptDom.RenameEntityStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RenameEntityStatement))) { throw new NotImplementedException("Unexpected subtype of RenameEntityStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RenameEntityStatement(
                renameEntityType: fragment.RenameEntityType,
                separatorType: fragment.SeparatorType,
                oldName: FromMutable(fragment.OldName),
                newName: FromMutable(fragment.NewName)
            );
        }
        
        public static ResampleStatisticsOption FromMutable(ScriptDom.ResampleStatisticsOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ResampleStatisticsOption))) { throw new NotImplementedException("Unexpected subtype of ResampleStatisticsOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ResampleStatisticsOption(
                partitions: fragment.Partitions.SelectList(FromMutable),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ResourcePoolAffinitySpecification FromMutable(ScriptDom.ResourcePoolAffinitySpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ResourcePoolAffinitySpecification))) { throw new NotImplementedException("Unexpected subtype of ResourcePoolAffinitySpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ResourcePoolAffinitySpecification(
                affinityType: fragment.AffinityType,
                parameterValue: FromMutable(fragment.ParameterValue),
                isAuto: fragment.IsAuto,
                poolAffinityRanges: fragment.PoolAffinityRanges.SelectList(FromMutable)
            );
        }
        
        public static ResourcePoolParameter FromMutable(ScriptDom.ResourcePoolParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ResourcePoolParameter))) { throw new NotImplementedException("Unexpected subtype of ResourcePoolParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ResourcePoolParameter(
                parameterType: fragment.ParameterType,
                parameterValue: FromMutable(fragment.ParameterValue),
                affinitySpecification: FromMutable(fragment.AffinitySpecification)
            );
        }
        
        public static ResourcePoolStatement FromMutable(ScriptDom.ResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ResourcePoolStatement))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as ResourcePoolStatement; }
            return new ResourcePoolStatement(
                name: FromMutable(fragment.Name),
                resourcePoolParameters: fragment.ResourcePoolParameters.SelectList(FromMutable)
            );
        }
        
        public static RestoreMasterKeyStatement FromMutable(ScriptDom.RestoreMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RestoreMasterKeyStatement))) { throw new NotImplementedException("Unexpected subtype of RestoreMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RestoreMasterKeyStatement(
                isForce: fragment.IsForce,
                encryptionPassword: FromMutable(fragment.EncryptionPassword),
                file: FromMutable(fragment.File),
                password: FromMutable(fragment.Password)
            );
        }
        
        public static RestoreOption FromMutable(ScriptDom.RestoreOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RestoreOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as RestoreOption; }
            return new RestoreOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static RestoreServiceMasterKeyStatement FromMutable(ScriptDom.RestoreServiceMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RestoreServiceMasterKeyStatement))) { throw new NotImplementedException("Unexpected subtype of RestoreServiceMasterKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RestoreServiceMasterKeyStatement(
                isForce: fragment.IsForce,
                file: FromMutable(fragment.File),
                password: FromMutable(fragment.Password)
            );
        }
        
        public static RestoreStatement FromMutable(ScriptDom.RestoreStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RestoreStatement))) { throw new NotImplementedException("Unexpected subtype of RestoreStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RestoreStatement(
                databaseName: FromMutable(fragment.DatabaseName),
                devices: fragment.Devices.SelectList(FromMutable),
                files: fragment.Files.SelectList(FromMutable),
                options: fragment.Options.SelectList(FromMutable),
                kind: fragment.Kind
            );
        }
        
        public static ResultColumnDefinition FromMutable(ScriptDom.ResultColumnDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ResultColumnDefinition))) { throw new NotImplementedException("Unexpected subtype of ResultColumnDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ResultColumnDefinition(
                columnDefinition: FromMutable(fragment.ColumnDefinition),
                nullable: FromMutable(fragment.Nullable)
            );
        }
        
        public static ResultSetDefinition FromMutable(ScriptDom.ResultSetDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ResultSetDefinition))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as ResultSetDefinition; }
            return new ResultSetDefinition(
                resultSetType: fragment.ResultSetType
            );
        }
        
        public static ResultSetsExecuteOption FromMutable(ScriptDom.ResultSetsExecuteOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ResultSetsExecuteOption))) { throw new NotImplementedException("Unexpected subtype of ResultSetsExecuteOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ResultSetsExecuteOption(
                resultSetsOptionKind: fragment.ResultSetsOptionKind,
                definitions: fragment.Definitions.SelectList(FromMutable),
                optionKind: fragment.OptionKind
            );
        }
        
        public static RetentionDaysAuditTargetOption FromMutable(ScriptDom.RetentionDaysAuditTargetOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RetentionDaysAuditTargetOption))) { throw new NotImplementedException("Unexpected subtype of RetentionDaysAuditTargetOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RetentionDaysAuditTargetOption(
                days: FromMutable(fragment.Days),
                optionKind: fragment.OptionKind
            );
        }
        
        public static RetentionPeriodDefinition FromMutable(ScriptDom.RetentionPeriodDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RetentionPeriodDefinition))) { throw new NotImplementedException("Unexpected subtype of RetentionPeriodDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RetentionPeriodDefinition(
                duration: FromMutable(fragment.Duration),
                units: fragment.Units,
                isInfinity: fragment.IsInfinity
            );
        }
        
        public static ReturnStatement FromMutable(ScriptDom.ReturnStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ReturnStatement))) { throw new NotImplementedException("Unexpected subtype of ReturnStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ReturnStatement(
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static RevertStatement FromMutable(ScriptDom.RevertStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RevertStatement))) { throw new NotImplementedException("Unexpected subtype of RevertStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RevertStatement(
                cookie: FromMutable(fragment.Cookie)
            );
        }
        
        public static RevokeStatement FromMutable(ScriptDom.RevokeStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RevokeStatement))) { throw new NotImplementedException("Unexpected subtype of RevokeStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RevokeStatement(
                grantOptionFor: fragment.GrantOptionFor,
                cascadeOption: fragment.CascadeOption,
                permissions: fragment.Permissions.SelectList(FromMutable),
                securityTargetObject: FromMutable(fragment.SecurityTargetObject),
                principals: fragment.Principals.SelectList(FromMutable),
                asClause: FromMutable(fragment.AsClause)
            );
        }
        
        public static RevokeStatement80 FromMutable(ScriptDom.RevokeStatement80 fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RevokeStatement80))) { throw new NotImplementedException("Unexpected subtype of RevokeStatement80 not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RevokeStatement80(
                grantOptionFor: fragment.GrantOptionFor,
                cascadeOption: fragment.CascadeOption,
                asClause: FromMutable(fragment.AsClause),
                securityElement80: FromMutable(fragment.SecurityElement80),
                securityUserClause80: FromMutable(fragment.SecurityUserClause80)
            );
        }
        
        public static RightFunctionCall FromMutable(ScriptDom.RightFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RightFunctionCall))) { throw new NotImplementedException("Unexpected subtype of RightFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RightFunctionCall(
                parameters: fragment.Parameters.SelectList(FromMutable),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static RolePayloadOption FromMutable(ScriptDom.RolePayloadOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RolePayloadOption))) { throw new NotImplementedException("Unexpected subtype of RolePayloadOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RolePayloadOption(
                role: fragment.Role,
                kind: fragment.Kind
            );
        }
        
        public static RollbackTransactionStatement FromMutable(ScriptDom.RollbackTransactionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RollbackTransactionStatement))) { throw new NotImplementedException("Unexpected subtype of RollbackTransactionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RollbackTransactionStatement(
                name: FromMutable(fragment.Name)
            );
        }
        
        public static RollupGroupingSpecification FromMutable(ScriptDom.RollupGroupingSpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RollupGroupingSpecification))) { throw new NotImplementedException("Unexpected subtype of RollupGroupingSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RollupGroupingSpecification(
                arguments: fragment.Arguments.SelectList(FromMutable)
            );
        }
        
        public static RouteOption FromMutable(ScriptDom.RouteOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RouteOption))) { throw new NotImplementedException("Unexpected subtype of RouteOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RouteOption(
                optionKind: fragment.OptionKind,
                literal: FromMutable(fragment.Literal)
            );
        }
        
        public static RowValue FromMutable(ScriptDom.RowValue fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.RowValue))) { throw new NotImplementedException("Unexpected subtype of RowValue not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RowValue(
                columnValues: fragment.ColumnValues.SelectList(FromMutable)
            );
        }
        
        public static SaveTransactionStatement FromMutable(ScriptDom.SaveTransactionStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SaveTransactionStatement))) { throw new NotImplementedException("Unexpected subtype of SaveTransactionStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SaveTransactionStatement(
                name: FromMutable(fragment.Name)
            );
        }
        
        public static ScalarExpressionDialogOption FromMutable(ScriptDom.ScalarExpressionDialogOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ScalarExpressionDialogOption))) { throw new NotImplementedException("Unexpected subtype of ScalarExpressionDialogOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ScalarExpressionDialogOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ScalarExpressionRestoreOption FromMutable(ScriptDom.ScalarExpressionRestoreOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ScalarExpressionRestoreOption))) { throw new NotImplementedException("Unexpected subtype of ScalarExpressionRestoreOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ScalarExpressionRestoreOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ScalarExpressionSequenceOption FromMutable(ScriptDom.ScalarExpressionSequenceOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ScalarExpressionSequenceOption))) { throw new NotImplementedException("Unexpected subtype of ScalarExpressionSequenceOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ScalarExpressionSequenceOption(
                optionValue: FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind,
                noValue: fragment.NoValue
            );
        }
        
        public static ScalarExpressionSnippet FromMutable(ScriptDom.ScalarExpressionSnippet fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ScalarExpressionSnippet))) { throw new NotImplementedException("Unexpected subtype of ScalarExpressionSnippet not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ScalarExpressionSnippet(
                script: fragment.Script
            );
        }
        
        public static ScalarFunctionReturnType FromMutable(ScriptDom.ScalarFunctionReturnType fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ScalarFunctionReturnType))) { throw new NotImplementedException("Unexpected subtype of ScalarFunctionReturnType not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ScalarFunctionReturnType(
                dataType: FromMutable(fragment.DataType)
            );
        }
        
        public static ScalarSubquery FromMutable(ScriptDom.ScalarSubquery fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ScalarSubquery))) { throw new NotImplementedException("Unexpected subtype of ScalarSubquery not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ScalarSubquery(
                queryExpression: FromMutable(fragment.QueryExpression),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static SchemaDeclarationItem FromMutable(ScriptDom.SchemaDeclarationItem fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SchemaDeclarationItem))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as SchemaDeclarationItem; }
            return new SchemaDeclarationItem(
                columnDefinition: FromMutable(fragment.ColumnDefinition),
                mapping: FromMutable(fragment.Mapping)
            );
        }
        
        public static SchemaDeclarationItemOpenjson FromMutable(ScriptDom.SchemaDeclarationItemOpenjson fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SchemaDeclarationItemOpenjson))) { throw new NotImplementedException("Unexpected subtype of SchemaDeclarationItemOpenjson not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SchemaDeclarationItemOpenjson(
                asJson: fragment.AsJson,
                columnDefinition: FromMutable(fragment.ColumnDefinition),
                mapping: FromMutable(fragment.Mapping)
            );
        }
        
        public static SchemaObjectFunctionTableReference FromMutable(ScriptDom.SchemaObjectFunctionTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SchemaObjectFunctionTableReference))) { throw new NotImplementedException("Unexpected subtype of SchemaObjectFunctionTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SchemaObjectFunctionTableReference(
                schemaObject: FromMutable(fragment.SchemaObject),
                parameters: fragment.Parameters.SelectList(FromMutable),
                columns: fragment.Columns.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static SchemaObjectName FromMutable(ScriptDom.SchemaObjectName fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SchemaObjectName))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as SchemaObjectName; }
            return new SchemaObjectName(
                identifiers: fragment.Identifiers.SelectList(FromMutable)
            );
        }
        
        public static SchemaObjectNameOrValueExpression FromMutable(ScriptDom.SchemaObjectNameOrValueExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SchemaObjectNameOrValueExpression))) { throw new NotImplementedException("Unexpected subtype of SchemaObjectNameOrValueExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SchemaObjectNameOrValueExpression(
                schemaObjectName: FromMutable(fragment.SchemaObjectName),
                valueExpression: FromMutable(fragment.ValueExpression)
            );
        }
        
        public static SchemaObjectNameSnippet FromMutable(ScriptDom.SchemaObjectNameSnippet fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SchemaObjectNameSnippet))) { throw new NotImplementedException("Unexpected subtype of SchemaObjectNameSnippet not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SchemaObjectNameSnippet(
                script: fragment.Script,
                identifiers: fragment.Identifiers.SelectList(FromMutable)
            );
        }
        
        public static SchemaObjectResultSetDefinition FromMutable(ScriptDom.SchemaObjectResultSetDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SchemaObjectResultSetDefinition))) { throw new NotImplementedException("Unexpected subtype of SchemaObjectResultSetDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SchemaObjectResultSetDefinition(
                name: FromMutable(fragment.Name),
                resultSetType: fragment.ResultSetType
            );
        }
        
        public static SchemaPayloadOption FromMutable(ScriptDom.SchemaPayloadOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SchemaPayloadOption))) { throw new NotImplementedException("Unexpected subtype of SchemaPayloadOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SchemaPayloadOption(
                isStandard: fragment.IsStandard,
                kind: fragment.Kind
            );
        }
        
        public static SearchedCaseExpression FromMutable(ScriptDom.SearchedCaseExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SearchedCaseExpression))) { throw new NotImplementedException("Unexpected subtype of SearchedCaseExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SearchedCaseExpression(
                whenClauses: fragment.WhenClauses.SelectList(FromMutable),
                elseExpression: FromMutable(fragment.ElseExpression),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static SearchedWhenClause FromMutable(ScriptDom.SearchedWhenClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SearchedWhenClause))) { throw new NotImplementedException("Unexpected subtype of SearchedWhenClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SearchedWhenClause(
                whenExpression: FromMutable(fragment.WhenExpression),
                thenExpression: FromMutable(fragment.ThenExpression)
            );
        }
        
        public static SearchPropertyListFullTextIndexOption FromMutable(ScriptDom.SearchPropertyListFullTextIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SearchPropertyListFullTextIndexOption))) { throw new NotImplementedException("Unexpected subtype of SearchPropertyListFullTextIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SearchPropertyListFullTextIndexOption(
                isOff: fragment.IsOff,
                propertyListName: FromMutable(fragment.PropertyListName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static SecondaryRoleReplicaOption FromMutable(ScriptDom.SecondaryRoleReplicaOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SecondaryRoleReplicaOption))) { throw new NotImplementedException("Unexpected subtype of SecondaryRoleReplicaOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SecondaryRoleReplicaOption(
                allowConnections: fragment.AllowConnections,
                optionKind: fragment.OptionKind
            );
        }
        
        public static SecurityPolicyOption FromMutable(ScriptDom.SecurityPolicyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SecurityPolicyOption))) { throw new NotImplementedException("Unexpected subtype of SecurityPolicyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SecurityPolicyOption(
                optionKind: fragment.OptionKind,
                optionState: fragment.OptionState
            );
        }
        
        public static SecurityPredicateAction FromMutable(ScriptDom.SecurityPredicateAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SecurityPredicateAction))) { throw new NotImplementedException("Unexpected subtype of SecurityPredicateAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SecurityPredicateAction(
                actionType: fragment.ActionType,
                securityPredicateType: fragment.SecurityPredicateType,
                functionCall: FromMutable(fragment.FunctionCall),
                targetObjectName: FromMutable(fragment.TargetObjectName),
                securityPredicateOperation: fragment.SecurityPredicateOperation
            );
        }
        
        public static SecurityPrincipal FromMutable(ScriptDom.SecurityPrincipal fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SecurityPrincipal))) { throw new NotImplementedException("Unexpected subtype of SecurityPrincipal not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SecurityPrincipal(
                principalType: fragment.PrincipalType,
                identifier: FromMutable(fragment.Identifier)
            );
        }
        
        public static SecurityTargetObject FromMutable(ScriptDom.SecurityTargetObject fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SecurityTargetObject))) { throw new NotImplementedException("Unexpected subtype of SecurityTargetObject not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SecurityTargetObject(
                objectKind: fragment.ObjectKind,
                objectName: FromMutable(fragment.ObjectName),
                columns: fragment.Columns.SelectList(FromMutable)
            );
        }
        
        public static SecurityTargetObjectName FromMutable(ScriptDom.SecurityTargetObjectName fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SecurityTargetObjectName))) { throw new NotImplementedException("Unexpected subtype of SecurityTargetObjectName not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SecurityTargetObjectName(
                multiPartIdentifier: FromMutable(fragment.MultiPartIdentifier)
            );
        }
        
        public static SecurityUserClause80 FromMutable(ScriptDom.SecurityUserClause80 fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SecurityUserClause80))) { throw new NotImplementedException("Unexpected subtype of SecurityUserClause80 not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SecurityUserClause80(
                users: fragment.Users.SelectList(FromMutable),
                userType80: fragment.UserType80
            );
        }
        
        public static SelectFunctionReturnType FromMutable(ScriptDom.SelectFunctionReturnType fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SelectFunctionReturnType))) { throw new NotImplementedException("Unexpected subtype of SelectFunctionReturnType not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SelectFunctionReturnType(
                selectStatement: FromMutable(fragment.SelectStatement)
            );
        }
        
        public static SelectInsertSource FromMutable(ScriptDom.SelectInsertSource fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SelectInsertSource))) { throw new NotImplementedException("Unexpected subtype of SelectInsertSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SelectInsertSource(
                select: FromMutable(fragment.Select)
            );
        }
        
        public static SelectiveXmlIndexPromotedPath FromMutable(ScriptDom.SelectiveXmlIndexPromotedPath fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SelectiveXmlIndexPromotedPath))) { throw new NotImplementedException("Unexpected subtype of SelectiveXmlIndexPromotedPath not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SelectiveXmlIndexPromotedPath(
                name: FromMutable(fragment.Name),
                path: FromMutable(fragment.Path),
                sQLDataType: FromMutable(fragment.SQLDataType),
                xQueryDataType: FromMutable(fragment.XQueryDataType),
                maxLength: FromMutable(fragment.MaxLength),
                isSingleton: fragment.IsSingleton
            );
        }
        
        public static SelectScalarExpression FromMutable(ScriptDom.SelectScalarExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SelectScalarExpression))) { throw new NotImplementedException("Unexpected subtype of SelectScalarExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SelectScalarExpression(
                expression: FromMutable(fragment.Expression),
                columnName: FromMutable(fragment.ColumnName)
            );
        }
        
        public static SelectSetVariable FromMutable(ScriptDom.SelectSetVariable fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SelectSetVariable))) { throw new NotImplementedException("Unexpected subtype of SelectSetVariable not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SelectSetVariable(
                variable: FromMutable(fragment.Variable),
                expression: FromMutable(fragment.Expression),
                assignmentKind: fragment.AssignmentKind
            );
        }
        
        public static SelectStarExpression FromMutable(ScriptDom.SelectStarExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SelectStarExpression))) { throw new NotImplementedException("Unexpected subtype of SelectStarExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SelectStarExpression(
                qualifier: FromMutable(fragment.Qualifier)
            );
        }
        
        public static SelectStatement FromMutable(ScriptDom.SelectStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SelectStatement))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as SelectStatement; }
            return new SelectStatement(
                queryExpression: FromMutable(fragment.QueryExpression),
                into: FromMutable(fragment.Into),
                on: FromMutable(fragment.On),
                computeClauses: fragment.ComputeClauses.SelectList(FromMutable),
                withCtesAndXmlNamespaces: FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.SelectList(FromMutable)
            );
        }
        
        public static SelectStatementSnippet FromMutable(ScriptDom.SelectStatementSnippet fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SelectStatementSnippet))) { throw new NotImplementedException("Unexpected subtype of SelectStatementSnippet not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SelectStatementSnippet(
                script: fragment.Script,
                queryExpression: FromMutable(fragment.QueryExpression),
                into: FromMutable(fragment.Into),
                on: FromMutable(fragment.On),
                computeClauses: fragment.ComputeClauses.SelectList(FromMutable),
                withCtesAndXmlNamespaces: FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.SelectList(FromMutable)
            );
        }
        
        public static SemanticTableReference FromMutable(ScriptDom.SemanticTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SemanticTableReference))) { throw new NotImplementedException("Unexpected subtype of SemanticTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SemanticTableReference(
                semanticFunctionType: fragment.SemanticFunctionType,
                tableName: FromMutable(fragment.TableName),
                columns: fragment.Columns.SelectList(FromMutable),
                sourceKey: FromMutable(fragment.SourceKey),
                matchedColumn: FromMutable(fragment.MatchedColumn),
                matchedKey: FromMutable(fragment.MatchedKey),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static SendStatement FromMutable(ScriptDom.SendStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SendStatement))) { throw new NotImplementedException("Unexpected subtype of SendStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SendStatement(
                conversationHandles: fragment.ConversationHandles.SelectList(FromMutable),
                messageTypeName: FromMutable(fragment.MessageTypeName),
                messageBody: FromMutable(fragment.MessageBody)
            );
        }
        
        public static SensitivityClassificationOption FromMutable(ScriptDom.SensitivityClassificationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SensitivityClassificationOption))) { throw new NotImplementedException("Unexpected subtype of SensitivityClassificationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SensitivityClassificationOption(
                type: fragment.Type,
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static SequenceOption FromMutable(ScriptDom.SequenceOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SequenceOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as SequenceOption; }
            return new SequenceOption(
                optionKind: fragment.OptionKind,
                noValue: fragment.NoValue
            );
        }
        
        public static ServiceContract FromMutable(ScriptDom.ServiceContract fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ServiceContract))) { throw new NotImplementedException("Unexpected subtype of ServiceContract not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ServiceContract(
                name: FromMutable(fragment.Name),
                action: fragment.Action
            );
        }
        
        public static SessionTimeoutPayloadOption FromMutable(ScriptDom.SessionTimeoutPayloadOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SessionTimeoutPayloadOption))) { throw new NotImplementedException("Unexpected subtype of SessionTimeoutPayloadOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SessionTimeoutPayloadOption(
                isNever: fragment.IsNever,
                timeout: FromMutable(fragment.Timeout),
                kind: fragment.Kind
            );
        }
        
        public static SetCommandStatement FromMutable(ScriptDom.SetCommandStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SetCommandStatement))) { throw new NotImplementedException("Unexpected subtype of SetCommandStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetCommandStatement(
                commands: fragment.Commands.SelectList(FromMutable)
            );
        }
        
        public static SetErrorLevelStatement FromMutable(ScriptDom.SetErrorLevelStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SetErrorLevelStatement))) { throw new NotImplementedException("Unexpected subtype of SetErrorLevelStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetErrorLevelStatement(
                level: FromMutable(fragment.Level)
            );
        }
        
        public static SetFipsFlaggerCommand FromMutable(ScriptDom.SetFipsFlaggerCommand fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SetFipsFlaggerCommand))) { throw new NotImplementedException("Unexpected subtype of SetFipsFlaggerCommand not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetFipsFlaggerCommand(
                complianceLevel: fragment.ComplianceLevel
            );
        }
        
        public static SetIdentityInsertStatement FromMutable(ScriptDom.SetIdentityInsertStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SetIdentityInsertStatement))) { throw new NotImplementedException("Unexpected subtype of SetIdentityInsertStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetIdentityInsertStatement(
                table: FromMutable(fragment.Table),
                isOn: fragment.IsOn
            );
        }
        
        public static SetOffsetsStatement FromMutable(ScriptDom.SetOffsetsStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SetOffsetsStatement))) { throw new NotImplementedException("Unexpected subtype of SetOffsetsStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetOffsetsStatement(
                options: fragment.Options,
                isOn: fragment.IsOn
            );
        }
        
        public static SetRowCountStatement FromMutable(ScriptDom.SetRowCountStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SetRowCountStatement))) { throw new NotImplementedException("Unexpected subtype of SetRowCountStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetRowCountStatement(
                numberRows: FromMutable(fragment.NumberRows)
            );
        }
        
        public static SetSearchPropertyListAlterFullTextIndexAction FromMutable(ScriptDom.SetSearchPropertyListAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SetSearchPropertyListAlterFullTextIndexAction))) { throw new NotImplementedException("Unexpected subtype of SetSearchPropertyListAlterFullTextIndexAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetSearchPropertyListAlterFullTextIndexAction(
                searchPropertyListOption: FromMutable(fragment.SearchPropertyListOption),
                withNoPopulation: fragment.WithNoPopulation
            );
        }
        
        public static SetStatisticsStatement FromMutable(ScriptDom.SetStatisticsStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SetStatisticsStatement))) { throw new NotImplementedException("Unexpected subtype of SetStatisticsStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetStatisticsStatement(
                options: fragment.Options,
                isOn: fragment.IsOn
            );
        }
        
        public static SetStopListAlterFullTextIndexAction FromMutable(ScriptDom.SetStopListAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SetStopListAlterFullTextIndexAction))) { throw new NotImplementedException("Unexpected subtype of SetStopListAlterFullTextIndexAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetStopListAlterFullTextIndexAction(
                stopListOption: FromMutable(fragment.StopListOption),
                withNoPopulation: fragment.WithNoPopulation
            );
        }
        
        public static SetTextSizeStatement FromMutable(ScriptDom.SetTextSizeStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SetTextSizeStatement))) { throw new NotImplementedException("Unexpected subtype of SetTextSizeStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetTextSizeStatement(
                textSize: FromMutable(fragment.TextSize)
            );
        }
        
        public static SetTransactionIsolationLevelStatement FromMutable(ScriptDom.SetTransactionIsolationLevelStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SetTransactionIsolationLevelStatement))) { throw new NotImplementedException("Unexpected subtype of SetTransactionIsolationLevelStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetTransactionIsolationLevelStatement(
                level: fragment.Level
            );
        }
        
        public static SetUserStatement FromMutable(ScriptDom.SetUserStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SetUserStatement))) { throw new NotImplementedException("Unexpected subtype of SetUserStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetUserStatement(
                userName: FromMutable(fragment.UserName),
                withNoReset: fragment.WithNoReset
            );
        }
        
        public static SetVariableStatement FromMutable(ScriptDom.SetVariableStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SetVariableStatement))) { throw new NotImplementedException("Unexpected subtype of SetVariableStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetVariableStatement(
                variable: FromMutable(fragment.Variable),
                separatorType: fragment.SeparatorType,
                identifier: FromMutable(fragment.Identifier),
                functionCallExists: fragment.FunctionCallExists,
                parameters: fragment.Parameters.SelectList(FromMutable),
                expression: FromMutable(fragment.Expression),
                cursorDefinition: FromMutable(fragment.CursorDefinition),
                assignmentKind: fragment.AssignmentKind
            );
        }
        
        public static ShutdownStatement FromMutable(ScriptDom.ShutdownStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ShutdownStatement))) { throw new NotImplementedException("Unexpected subtype of ShutdownStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ShutdownStatement(
                withNoWait: fragment.WithNoWait
            );
        }
        
        public static SimpleAlterFullTextIndexAction FromMutable(ScriptDom.SimpleAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SimpleAlterFullTextIndexAction))) { throw new NotImplementedException("Unexpected subtype of SimpleAlterFullTextIndexAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SimpleAlterFullTextIndexAction(
                actionKind: fragment.ActionKind
            );
        }
        
        public static SimpleCaseExpression FromMutable(ScriptDom.SimpleCaseExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SimpleCaseExpression))) { throw new NotImplementedException("Unexpected subtype of SimpleCaseExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SimpleCaseExpression(
                inputExpression: FromMutable(fragment.InputExpression),
                whenClauses: fragment.WhenClauses.SelectList(FromMutable),
                elseExpression: FromMutable(fragment.ElseExpression),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static SimpleWhenClause FromMutable(ScriptDom.SimpleWhenClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SimpleWhenClause))) { throw new NotImplementedException("Unexpected subtype of SimpleWhenClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SimpleWhenClause(
                whenExpression: FromMutable(fragment.WhenExpression),
                thenExpression: FromMutable(fragment.ThenExpression)
            );
        }
        
        public static SingleValueTypeCopyOption FromMutable(ScriptDom.SingleValueTypeCopyOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SingleValueTypeCopyOption))) { throw new NotImplementedException("Unexpected subtype of SingleValueTypeCopyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SingleValueTypeCopyOption(
                singleValue: FromMutable(fragment.SingleValue)
            );
        }
        
        public static SizeFileDeclarationOption FromMutable(ScriptDom.SizeFileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SizeFileDeclarationOption))) { throw new NotImplementedException("Unexpected subtype of SizeFileDeclarationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SizeFileDeclarationOption(
                size: FromMutable(fragment.Size),
                units: fragment.Units,
                optionKind: fragment.OptionKind
            );
        }
        
        public static SoapMethod FromMutable(ScriptDom.SoapMethod fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SoapMethod))) { throw new NotImplementedException("Unexpected subtype of SoapMethod not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SoapMethod(
                alias: FromMutable(fragment.Alias),
                @namespace: FromMutable(fragment.Namespace),
                action: fragment.Action,
                name: FromMutable(fragment.Name),
                format: fragment.Format,
                schema: fragment.Schema,
                kind: fragment.Kind
            );
        }
        
        public static SourceDeclaration FromMutable(ScriptDom.SourceDeclaration fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SourceDeclaration))) { throw new NotImplementedException("Unexpected subtype of SourceDeclaration not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SourceDeclaration(
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static SpatialIndexRegularOption FromMutable(ScriptDom.SpatialIndexRegularOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SpatialIndexRegularOption))) { throw new NotImplementedException("Unexpected subtype of SpatialIndexRegularOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SpatialIndexRegularOption(
                option: FromMutable(fragment.Option)
            );
        }
        
        public static SqlCommandIdentifier FromMutable(ScriptDom.SqlCommandIdentifier fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SqlCommandIdentifier))) { throw new NotImplementedException("Unexpected subtype of SqlCommandIdentifier not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SqlCommandIdentifier(
                @value: fragment.Value,
                quoteType: fragment.QuoteType
            );
        }
        
        public static SqlDataTypeReference FromMutable(ScriptDom.SqlDataTypeReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SqlDataTypeReference))) { throw new NotImplementedException("Unexpected subtype of SqlDataTypeReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SqlDataTypeReference(
                sqlDataTypeOption: fragment.SqlDataTypeOption,
                parameters: fragment.Parameters.SelectList(FromMutable),
                name: FromMutable(fragment.Name)
            );
        }
        
        public static StateAuditOption FromMutable(ScriptDom.StateAuditOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.StateAuditOption))) { throw new NotImplementedException("Unexpected subtype of StateAuditOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new StateAuditOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static StatementList FromMutable(ScriptDom.StatementList fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.StatementList))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as StatementList; }
            return new StatementList(
                statements: fragment.Statements.SelectList(FromMutable)
            );
        }
        
        public static StatementListSnippet FromMutable(ScriptDom.StatementListSnippet fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.StatementListSnippet))) { throw new NotImplementedException("Unexpected subtype of StatementListSnippet not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new StatementListSnippet(
                script: fragment.Script,
                statements: fragment.Statements.SelectList(FromMutable)
            );
        }
        
        public static StatisticsOption FromMutable(ScriptDom.StatisticsOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.StatisticsOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as StatisticsOption; }
            return new StatisticsOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static StatisticsPartitionRange FromMutable(ScriptDom.StatisticsPartitionRange fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.StatisticsPartitionRange))) { throw new NotImplementedException("Unexpected subtype of StatisticsPartitionRange not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new StatisticsPartitionRange(
                from: FromMutable(fragment.From),
                to: FromMutable(fragment.To)
            );
        }
        
        public static StopListFullTextIndexOption FromMutable(ScriptDom.StopListFullTextIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.StopListFullTextIndexOption))) { throw new NotImplementedException("Unexpected subtype of StopListFullTextIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new StopListFullTextIndexOption(
                isOff: fragment.IsOff,
                stopListName: FromMutable(fragment.StopListName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static StopRestoreOption FromMutable(ScriptDom.StopRestoreOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.StopRestoreOption))) { throw new NotImplementedException("Unexpected subtype of StopRestoreOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new StopRestoreOption(
                mark: FromMutable(fragment.Mark),
                after: FromMutable(fragment.After),
                isStopAt: fragment.IsStopAt,
                optionKind: fragment.OptionKind
            );
        }
        
        public static StringLiteral FromMutable(ScriptDom.StringLiteral fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.StringLiteral))) { throw new NotImplementedException("Unexpected subtype of StringLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new StringLiteral(
                isNational: fragment.IsNational,
                isLargeObject: fragment.IsLargeObject,
                @value: fragment.Value,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static SubqueryComparisonPredicate FromMutable(ScriptDom.SubqueryComparisonPredicate fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SubqueryComparisonPredicate))) { throw new NotImplementedException("Unexpected subtype of SubqueryComparisonPredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SubqueryComparisonPredicate(
                expression: FromMutable(fragment.Expression),
                comparisonType: fragment.ComparisonType,
                subquery: FromMutable(fragment.Subquery),
                subqueryComparisonPredicateType: fragment.SubqueryComparisonPredicateType
            );
        }
        
        public static SystemTimePeriodDefinition FromMutable(ScriptDom.SystemTimePeriodDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SystemTimePeriodDefinition))) { throw new NotImplementedException("Unexpected subtype of SystemTimePeriodDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SystemTimePeriodDefinition(
                startTimeColumn: FromMutable(fragment.StartTimeColumn),
                endTimeColumn: FromMutable(fragment.EndTimeColumn)
            );
        }
        
        public static SystemVersioningTableOption FromMutable(ScriptDom.SystemVersioningTableOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.SystemVersioningTableOption))) { throw new NotImplementedException("Unexpected subtype of SystemVersioningTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SystemVersioningTableOption(
                optionState: fragment.OptionState,
                consistencyCheckEnabled: fragment.ConsistencyCheckEnabled,
                historyTable: FromMutable(fragment.HistoryTable),
                retentionPeriod: FromMutable(fragment.RetentionPeriod),
                optionKind: fragment.OptionKind
            );
        }
        
        public static TableClusteredIndexType FromMutable(ScriptDom.TableClusteredIndexType fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableClusteredIndexType))) { throw new NotImplementedException("Unexpected subtype of TableClusteredIndexType not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableClusteredIndexType(
                columns: fragment.Columns.SelectList(FromMutable),
                columnStore: fragment.ColumnStore,
                orderedColumns: fragment.OrderedColumns.SelectList(FromMutable)
            );
        }
        
        public static TableDataCompressionOption FromMutable(ScriptDom.TableDataCompressionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableDataCompressionOption))) { throw new NotImplementedException("Unexpected subtype of TableDataCompressionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableDataCompressionOption(
                dataCompressionOption: FromMutable(fragment.DataCompressionOption),
                optionKind: fragment.OptionKind
            );
        }
        
        public static TableDefinition FromMutable(ScriptDom.TableDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableDefinition))) { throw new NotImplementedException("Unexpected subtype of TableDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableDefinition(
                columnDefinitions: fragment.ColumnDefinitions.SelectList(FromMutable),
                tableConstraints: fragment.TableConstraints.SelectList(FromMutable),
                indexes: fragment.Indexes.SelectList(FromMutable),
                systemTimePeriod: FromMutable(fragment.SystemTimePeriod)
            );
        }
        
        public static TableDistributionOption FromMutable(ScriptDom.TableDistributionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableDistributionOption))) { throw new NotImplementedException("Unexpected subtype of TableDistributionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableDistributionOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static TableHashDistributionPolicy FromMutable(ScriptDom.TableHashDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableHashDistributionPolicy))) { throw new NotImplementedException("Unexpected subtype of TableHashDistributionPolicy not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableHashDistributionPolicy(
                distributionColumn: FromMutable(fragment.DistributionColumn)
            );
        }
        
        public static TableHint FromMutable(ScriptDom.TableHint fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableHint))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as TableHint; }
            return new TableHint(
                hintKind: fragment.HintKind
            );
        }
        
        public static TableHintsOptimizerHint FromMutable(ScriptDom.TableHintsOptimizerHint fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableHintsOptimizerHint))) { throw new NotImplementedException("Unexpected subtype of TableHintsOptimizerHint not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableHintsOptimizerHint(
                objectName: FromMutable(fragment.ObjectName),
                tableHints: fragment.TableHints.SelectList(FromMutable),
                hintKind: fragment.HintKind
            );
        }
        
        public static TableIndexOption FromMutable(ScriptDom.TableIndexOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableIndexOption))) { throw new NotImplementedException("Unexpected subtype of TableIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableIndexOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static TableNonClusteredIndexType FromMutable(ScriptDom.TableNonClusteredIndexType fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableNonClusteredIndexType))) { throw new NotImplementedException("Unexpected subtype of TableNonClusteredIndexType not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableNonClusteredIndexType(
                
            );
        }
        
        public static TablePartitionOption FromMutable(ScriptDom.TablePartitionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TablePartitionOption))) { throw new NotImplementedException("Unexpected subtype of TablePartitionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TablePartitionOption(
                partitionColumn: FromMutable(fragment.PartitionColumn),
                partitionOptionSpecs: FromMutable(fragment.PartitionOptionSpecs),
                optionKind: fragment.OptionKind
            );
        }
        
        public static TablePartitionOptionSpecifications FromMutable(ScriptDom.TablePartitionOptionSpecifications fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TablePartitionOptionSpecifications))) { throw new NotImplementedException("Unexpected subtype of TablePartitionOptionSpecifications not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TablePartitionOptionSpecifications(
                range: fragment.Range,
                boundaryValues: fragment.BoundaryValues.SelectList(FromMutable)
            );
        }
        
        public static TableReplicateDistributionPolicy FromMutable(ScriptDom.TableReplicateDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableReplicateDistributionPolicy))) { throw new NotImplementedException("Unexpected subtype of TableReplicateDistributionPolicy not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableReplicateDistributionPolicy(
                
            );
        }
        
        public static TableRoundRobinDistributionPolicy FromMutable(ScriptDom.TableRoundRobinDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableRoundRobinDistributionPolicy))) { throw new NotImplementedException("Unexpected subtype of TableRoundRobinDistributionPolicy not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableRoundRobinDistributionPolicy(
                
            );
        }
        
        public static TableSampleClause FromMutable(ScriptDom.TableSampleClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableSampleClause))) { throw new NotImplementedException("Unexpected subtype of TableSampleClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableSampleClause(
                system: fragment.System,
                sampleNumber: FromMutable(fragment.SampleNumber),
                tableSampleClauseOption: fragment.TableSampleClauseOption,
                repeatSeed: FromMutable(fragment.RepeatSeed)
            );
        }
        
        public static TableValuedFunctionReturnType FromMutable(ScriptDom.TableValuedFunctionReturnType fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableValuedFunctionReturnType))) { throw new NotImplementedException("Unexpected subtype of TableValuedFunctionReturnType not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableValuedFunctionReturnType(
                declareTableVariableBody: FromMutable(fragment.DeclareTableVariableBody)
            );
        }
        
        public static TableXmlCompressionOption FromMutable(ScriptDom.TableXmlCompressionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TableXmlCompressionOption))) { throw new NotImplementedException("Unexpected subtype of TableXmlCompressionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TableXmlCompressionOption(
                xmlCompressionOption: FromMutable(fragment.XmlCompressionOption),
                optionKind: fragment.OptionKind
            );
        }
        
        public static TargetDeclaration FromMutable(ScriptDom.TargetDeclaration fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TargetDeclaration))) { throw new NotImplementedException("Unexpected subtype of TargetDeclaration not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TargetDeclaration(
                objectName: FromMutable(fragment.ObjectName),
                targetDeclarationParameters: fragment.TargetDeclarationParameters.SelectList(FromMutable)
            );
        }
        
        public static TargetRecoveryTimeDatabaseOption FromMutable(ScriptDom.TargetRecoveryTimeDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TargetRecoveryTimeDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of TargetRecoveryTimeDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TargetRecoveryTimeDatabaseOption(
                recoveryTime: FromMutable(fragment.RecoveryTime),
                unit: fragment.Unit,
                optionKind: fragment.OptionKind
            );
        }
        
        public static TemporalClause FromMutable(ScriptDom.TemporalClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TemporalClause))) { throw new NotImplementedException("Unexpected subtype of TemporalClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TemporalClause(
                temporalClauseType: fragment.TemporalClauseType,
                startTime: FromMutable(fragment.StartTime),
                endTime: FromMutable(fragment.EndTime)
            );
        }
        
        public static ThrowStatement FromMutable(ScriptDom.ThrowStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ThrowStatement))) { throw new NotImplementedException("Unexpected subtype of ThrowStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ThrowStatement(
                errorNumber: FromMutable(fragment.ErrorNumber),
                message: FromMutable(fragment.Message),
                state: FromMutable(fragment.State)
            );
        }
        
        public static TopRowFilter FromMutable(ScriptDom.TopRowFilter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TopRowFilter))) { throw new NotImplementedException("Unexpected subtype of TopRowFilter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TopRowFilter(
                expression: FromMutable(fragment.Expression),
                percent: fragment.Percent,
                withTies: fragment.WithTies
            );
        }
        
        public static TriggerAction FromMutable(ScriptDom.TriggerAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TriggerAction))) { throw new NotImplementedException("Unexpected subtype of TriggerAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TriggerAction(
                triggerActionType: fragment.TriggerActionType,
                eventTypeGroup: FromMutable(fragment.EventTypeGroup)
            );
        }
        
        public static TriggerObject FromMutable(ScriptDom.TriggerObject fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TriggerObject))) { throw new NotImplementedException("Unexpected subtype of TriggerObject not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TriggerObject(
                name: FromMutable(fragment.Name),
                triggerScope: fragment.TriggerScope
            );
        }
        
        public static TriggerOption FromMutable(ScriptDom.TriggerOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TriggerOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as TriggerOption; }
            return new TriggerOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static TruncateTableStatement FromMutable(ScriptDom.TruncateTableStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TruncateTableStatement))) { throw new NotImplementedException("Unexpected subtype of TruncateTableStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TruncateTableStatement(
                tableName: FromMutable(fragment.TableName),
                partitionRanges: fragment.PartitionRanges.SelectList(FromMutable)
            );
        }
        
        public static TruncateTargetTableSwitchOption FromMutable(ScriptDom.TruncateTargetTableSwitchOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TruncateTargetTableSwitchOption))) { throw new NotImplementedException("Unexpected subtype of TruncateTargetTableSwitchOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TruncateTargetTableSwitchOption(
                truncateTarget: fragment.TruncateTarget,
                optionKind: fragment.OptionKind
            );
        }
        
        public static TryCastCall FromMutable(ScriptDom.TryCastCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TryCastCall))) { throw new NotImplementedException("Unexpected subtype of TryCastCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TryCastCall(
                dataType: FromMutable(fragment.DataType),
                parameter: FromMutable(fragment.Parameter),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static TryCatchStatement FromMutable(ScriptDom.TryCatchStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TryCatchStatement))) { throw new NotImplementedException("Unexpected subtype of TryCatchStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TryCatchStatement(
                tryStatements: FromMutable(fragment.TryStatements),
                catchStatements: FromMutable(fragment.CatchStatements)
            );
        }
        
        public static TryConvertCall FromMutable(ScriptDom.TryConvertCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TryConvertCall))) { throw new NotImplementedException("Unexpected subtype of TryConvertCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TryConvertCall(
                dataType: FromMutable(fragment.DataType),
                parameter: FromMutable(fragment.Parameter),
                style: FromMutable(fragment.Style),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static TryParseCall FromMutable(ScriptDom.TryParseCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TryParseCall))) { throw new NotImplementedException("Unexpected subtype of TryParseCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TryParseCall(
                stringValue: FromMutable(fragment.StringValue),
                dataType: FromMutable(fragment.DataType),
                culture: FromMutable(fragment.Culture),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static TSEqualCall FromMutable(ScriptDom.TSEqualCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TSEqualCall))) { throw new NotImplementedException("Unexpected subtype of TSEqualCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TSEqualCall(
                firstExpression: FromMutable(fragment.FirstExpression),
                secondExpression: FromMutable(fragment.SecondExpression)
            );
        }
        
        public static TSqlBatch FromMutable(ScriptDom.TSqlBatch fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TSqlBatch))) { throw new NotImplementedException("Unexpected subtype of TSqlBatch not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TSqlBatch(
                statements: fragment.Statements.SelectList(FromMutable)
            );
        }
        
        public static TSqlFragmentSnippet FromMutable(ScriptDom.TSqlFragmentSnippet fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TSqlFragmentSnippet))) { throw new NotImplementedException("Unexpected subtype of TSqlFragmentSnippet not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TSqlFragmentSnippet(
                script: fragment.Script
            );
        }
        
        public static TSqlScript FromMutable(ScriptDom.TSqlScript fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TSqlScript))) { throw new NotImplementedException("Unexpected subtype of TSqlScript not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TSqlScript(
                batches: fragment.Batches.SelectList(FromMutable)
            );
        }
        
        public static TSqlStatementSnippet FromMutable(ScriptDom.TSqlStatementSnippet fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.TSqlStatementSnippet))) { throw new NotImplementedException("Unexpected subtype of TSqlStatementSnippet not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TSqlStatementSnippet(
                script: fragment.Script
            );
        }
        
        public static UnaryExpression FromMutable(ScriptDom.UnaryExpression fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UnaryExpression))) { throw new NotImplementedException("Unexpected subtype of UnaryExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UnaryExpression(
                unaryExpressionType: fragment.UnaryExpressionType,
                expression: FromMutable(fragment.Expression)
            );
        }
        
        public static UniqueConstraintDefinition FromMutable(ScriptDom.UniqueConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UniqueConstraintDefinition))) { throw new NotImplementedException("Unexpected subtype of UniqueConstraintDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UniqueConstraintDefinition(
                clustered: fragment.Clustered,
                isPrimaryKey: fragment.IsPrimaryKey,
                isEnforced: fragment.IsEnforced,
                columns: fragment.Columns.SelectList(FromMutable),
                indexOptions: fragment.IndexOptions.SelectList(FromMutable),
                onFileGroupOrPartitionScheme: FromMutable(fragment.OnFileGroupOrPartitionScheme),
                indexType: FromMutable(fragment.IndexType),
                fileStreamOn: FromMutable(fragment.FileStreamOn),
                constraintIdentifier: FromMutable(fragment.ConstraintIdentifier)
            );
        }
        
        public static UnpivotedTableReference FromMutable(ScriptDom.UnpivotedTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UnpivotedTableReference))) { throw new NotImplementedException("Unexpected subtype of UnpivotedTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UnpivotedTableReference(
                tableReference: FromMutable(fragment.TableReference),
                inColumns: fragment.InColumns.SelectList(FromMutable),
                pivotColumn: FromMutable(fragment.PivotColumn),
                valueColumn: FromMutable(fragment.ValueColumn),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static UnqualifiedJoin FromMutable(ScriptDom.UnqualifiedJoin fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UnqualifiedJoin))) { throw new NotImplementedException("Unexpected subtype of UnqualifiedJoin not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UnqualifiedJoin(
                unqualifiedJoinType: fragment.UnqualifiedJoinType,
                firstTableReference: FromMutable(fragment.FirstTableReference),
                secondTableReference: FromMutable(fragment.SecondTableReference)
            );
        }
        
        public static UpdateCall FromMutable(ScriptDom.UpdateCall fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UpdateCall))) { throw new NotImplementedException("Unexpected subtype of UpdateCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UpdateCall(
                identifier: FromMutable(fragment.Identifier)
            );
        }
        
        public static UpdateForClause FromMutable(ScriptDom.UpdateForClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UpdateForClause))) { throw new NotImplementedException("Unexpected subtype of UpdateForClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UpdateForClause(
                columns: fragment.Columns.SelectList(FromMutable)
            );
        }
        
        public static UpdateMergeAction FromMutable(ScriptDom.UpdateMergeAction fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UpdateMergeAction))) { throw new NotImplementedException("Unexpected subtype of UpdateMergeAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UpdateMergeAction(
                setClauses: fragment.SetClauses.SelectList(FromMutable)
            );
        }
        
        public static UpdateSpecification FromMutable(ScriptDom.UpdateSpecification fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UpdateSpecification))) { throw new NotImplementedException("Unexpected subtype of UpdateSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UpdateSpecification(
                setClauses: fragment.SetClauses.SelectList(FromMutable),
                fromClause: FromMutable(fragment.FromClause),
                whereClause: FromMutable(fragment.WhereClause),
                target: FromMutable(fragment.Target),
                topRowFilter: FromMutable(fragment.TopRowFilter),
                outputIntoClause: FromMutable(fragment.OutputIntoClause),
                outputClause: FromMutable(fragment.OutputClause)
            );
        }
        
        public static UpdateStatement FromMutable(ScriptDom.UpdateStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UpdateStatement))) { throw new NotImplementedException("Unexpected subtype of UpdateStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UpdateStatement(
                updateSpecification: FromMutable(fragment.UpdateSpecification),
                withCtesAndXmlNamespaces: FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.SelectList(FromMutable)
            );
        }
        
        public static UpdateStatisticsStatement FromMutable(ScriptDom.UpdateStatisticsStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UpdateStatisticsStatement))) { throw new NotImplementedException("Unexpected subtype of UpdateStatisticsStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UpdateStatisticsStatement(
                schemaObjectName: FromMutable(fragment.SchemaObjectName),
                subElements: fragment.SubElements.SelectList(FromMutable),
                statisticsOptions: fragment.StatisticsOptions.SelectList(FromMutable)
            );
        }
        
        public static UpdateTextStatement FromMutable(ScriptDom.UpdateTextStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UpdateTextStatement))) { throw new NotImplementedException("Unexpected subtype of UpdateTextStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UpdateTextStatement(
                insertOffset: FromMutable(fragment.InsertOffset),
                deleteLength: FromMutable(fragment.DeleteLength),
                sourceColumn: FromMutable(fragment.SourceColumn),
                sourceParameter: FromMutable(fragment.SourceParameter),
                bulk: fragment.Bulk,
                column: FromMutable(fragment.Column),
                textId: FromMutable(fragment.TextId),
                timestamp: FromMutable(fragment.Timestamp),
                withLog: fragment.WithLog
            );
        }
        
        public static UseFederationStatement FromMutable(ScriptDom.UseFederationStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UseFederationStatement))) { throw new NotImplementedException("Unexpected subtype of UseFederationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UseFederationStatement(
                federationName: FromMutable(fragment.FederationName),
                distributionName: FromMutable(fragment.DistributionName),
                @value: FromMutable(fragment.Value),
                filtering: fragment.Filtering
            );
        }
        
        public static UseHintList FromMutable(ScriptDom.UseHintList fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UseHintList))) { throw new NotImplementedException("Unexpected subtype of UseHintList not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UseHintList(
                hints: fragment.Hints.SelectList(FromMutable),
                hintKind: fragment.HintKind
            );
        }
        
        public static UserDataTypeReference FromMutable(ScriptDom.UserDataTypeReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UserDataTypeReference))) { throw new NotImplementedException("Unexpected subtype of UserDataTypeReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UserDataTypeReference(
                parameters: fragment.Parameters.SelectList(FromMutable),
                name: FromMutable(fragment.Name)
            );
        }
        
        public static UserDefinedTypeCallTarget FromMutable(ScriptDom.UserDefinedTypeCallTarget fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UserDefinedTypeCallTarget))) { throw new NotImplementedException("Unexpected subtype of UserDefinedTypeCallTarget not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UserDefinedTypeCallTarget(
                schemaObjectName: FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static UserDefinedTypePropertyAccess FromMutable(ScriptDom.UserDefinedTypePropertyAccess fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UserDefinedTypePropertyAccess))) { throw new NotImplementedException("Unexpected subtype of UserDefinedTypePropertyAccess not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UserDefinedTypePropertyAccess(
                callTarget: FromMutable(fragment.CallTarget),
                propertyName: FromMutable(fragment.PropertyName),
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static UserLoginOption FromMutable(ScriptDom.UserLoginOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UserLoginOption))) { throw new NotImplementedException("Unexpected subtype of UserLoginOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UserLoginOption(
                userLoginOptionType: fragment.UserLoginOptionType,
                identifier: FromMutable(fragment.Identifier)
            );
        }
        
        public static UserRemoteServiceBindingOption FromMutable(ScriptDom.UserRemoteServiceBindingOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UserRemoteServiceBindingOption))) { throw new NotImplementedException("Unexpected subtype of UserRemoteServiceBindingOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UserRemoteServiceBindingOption(
                user: FromMutable(fragment.User),
                optionKind: fragment.OptionKind
            );
        }
        
        public static UseStatement FromMutable(ScriptDom.UseStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.UseStatement))) { throw new NotImplementedException("Unexpected subtype of UseStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new UseStatement(
                databaseName: FromMutable(fragment.DatabaseName)
            );
        }
        
        public static ValuesInsertSource FromMutable(ScriptDom.ValuesInsertSource fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ValuesInsertSource))) { throw new NotImplementedException("Unexpected subtype of ValuesInsertSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ValuesInsertSource(
                isDefaultValues: fragment.IsDefaultValues,
                rowValues: fragment.RowValues.SelectList(FromMutable)
            );
        }
        
        public static VariableMethodCallTableReference FromMutable(ScriptDom.VariableMethodCallTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.VariableMethodCallTableReference))) { throw new NotImplementedException("Unexpected subtype of VariableMethodCallTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new VariableMethodCallTableReference(
                variable: FromMutable(fragment.Variable),
                methodName: FromMutable(fragment.MethodName),
                parameters: fragment.Parameters.SelectList(FromMutable),
                columns: fragment.Columns.SelectList(FromMutable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static VariableReference FromMutable(ScriptDom.VariableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.VariableReference))) { throw new NotImplementedException("Unexpected subtype of VariableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new VariableReference(
                name: fragment.Name,
                collation: FromMutable(fragment.Collation)
            );
        }
        
        public static VariableTableReference FromMutable(ScriptDom.VariableTableReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.VariableTableReference))) { throw new NotImplementedException("Unexpected subtype of VariableTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new VariableTableReference(
                variable: FromMutable(fragment.Variable),
                alias: FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static VariableValuePair FromMutable(ScriptDom.VariableValuePair fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.VariableValuePair))) { throw new NotImplementedException("Unexpected subtype of VariableValuePair not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new VariableValuePair(
                variable: FromMutable(fragment.Variable),
                @value: FromMutable(fragment.Value),
                isForUnknown: fragment.IsForUnknown
            );
        }
        
        public static ViewDistributionOption FromMutable(ScriptDom.ViewDistributionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ViewDistributionOption))) { throw new NotImplementedException("Unexpected subtype of ViewDistributionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ViewDistributionOption(
                @value: FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ViewForAppendOption FromMutable(ScriptDom.ViewForAppendOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ViewForAppendOption))) { throw new NotImplementedException("Unexpected subtype of ViewForAppendOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ViewForAppendOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static ViewHashDistributionPolicy FromMutable(ScriptDom.ViewHashDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ViewHashDistributionPolicy))) { throw new NotImplementedException("Unexpected subtype of ViewHashDistributionPolicy not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ViewHashDistributionPolicy(
                distributionColumn: FromMutable(fragment.DistributionColumn)
            );
        }
        
        public static ViewOption FromMutable(ScriptDom.ViewOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ViewOption))) { return FromMutable(fragment as ScriptDom.TSqlFragment) as ViewOption; }
            return new ViewOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static ViewRoundRobinDistributionPolicy FromMutable(ScriptDom.ViewRoundRobinDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.ViewRoundRobinDistributionPolicy))) { throw new NotImplementedException("Unexpected subtype of ViewRoundRobinDistributionPolicy not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ViewRoundRobinDistributionPolicy(
                
            );
        }
        
        public static WaitAtLowPriorityOption FromMutable(ScriptDom.WaitAtLowPriorityOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WaitAtLowPriorityOption))) { throw new NotImplementedException("Unexpected subtype of WaitAtLowPriorityOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WaitAtLowPriorityOption(
                options: fragment.Options.SelectList(FromMutable),
                optionKind: fragment.OptionKind
            );
        }
        
        public static WaitForStatement FromMutable(ScriptDom.WaitForStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WaitForStatement))) { throw new NotImplementedException("Unexpected subtype of WaitForStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WaitForStatement(
                waitForOption: fragment.WaitForOption,
                parameter: FromMutable(fragment.Parameter),
                timeout: FromMutable(fragment.Timeout),
                statement: FromMutable(fragment.Statement)
            );
        }
        
        public static WhereClause FromMutable(ScriptDom.WhereClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WhereClause))) { throw new NotImplementedException("Unexpected subtype of WhereClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WhereClause(
                searchCondition: FromMutable(fragment.SearchCondition),
                cursor: FromMutable(fragment.Cursor)
            );
        }
        
        public static WhileStatement FromMutable(ScriptDom.WhileStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WhileStatement))) { throw new NotImplementedException("Unexpected subtype of WhileStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WhileStatement(
                predicate: FromMutable(fragment.Predicate),
                statement: FromMutable(fragment.Statement)
            );
        }
        
        public static WindowClause FromMutable(ScriptDom.WindowClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WindowClause))) { throw new NotImplementedException("Unexpected subtype of WindowClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WindowClause(
                windowDefinition: fragment.WindowDefinition.SelectList(FromMutable)
            );
        }
        
        public static WindowDefinition FromMutable(ScriptDom.WindowDefinition fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WindowDefinition))) { throw new NotImplementedException("Unexpected subtype of WindowDefinition not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WindowDefinition(
                windowName: FromMutable(fragment.WindowName),
                refWindowName: FromMutable(fragment.RefWindowName),
                partitions: fragment.Partitions.SelectList(FromMutable),
                orderByClause: FromMutable(fragment.OrderByClause),
                windowFrameClause: FromMutable(fragment.WindowFrameClause)
            );
        }
        
        public static WindowDelimiter FromMutable(ScriptDom.WindowDelimiter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WindowDelimiter))) { throw new NotImplementedException("Unexpected subtype of WindowDelimiter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WindowDelimiter(
                windowDelimiterType: fragment.WindowDelimiterType,
                offsetValue: FromMutable(fragment.OffsetValue)
            );
        }
        
        public static WindowFrameClause FromMutable(ScriptDom.WindowFrameClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WindowFrameClause))) { throw new NotImplementedException("Unexpected subtype of WindowFrameClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WindowFrameClause(
                top: FromMutable(fragment.Top),
                bottom: FromMutable(fragment.Bottom),
                windowFrameType: fragment.WindowFrameType
            );
        }
        
        public static WindowsCreateLoginSource FromMutable(ScriptDom.WindowsCreateLoginSource fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WindowsCreateLoginSource))) { throw new NotImplementedException("Unexpected subtype of WindowsCreateLoginSource not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WindowsCreateLoginSource(
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static WithCtesAndXmlNamespaces FromMutable(ScriptDom.WithCtesAndXmlNamespaces fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WithCtesAndXmlNamespaces))) { throw new NotImplementedException("Unexpected subtype of WithCtesAndXmlNamespaces not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WithCtesAndXmlNamespaces(
                xmlNamespaces: FromMutable(fragment.XmlNamespaces),
                commonTableExpressions: fragment.CommonTableExpressions.SelectList(FromMutable),
                changeTrackingContext: FromMutable(fragment.ChangeTrackingContext)
            );
        }
        
        public static WithinGroupClause FromMutable(ScriptDom.WithinGroupClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WithinGroupClause))) { throw new NotImplementedException("Unexpected subtype of WithinGroupClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WithinGroupClause(
                orderByClause: FromMutable(fragment.OrderByClause),
                hasGraphPath: fragment.HasGraphPath
            );
        }
        
        public static WitnessDatabaseOption FromMutable(ScriptDom.WitnessDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WitnessDatabaseOption))) { throw new NotImplementedException("Unexpected subtype of WitnessDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WitnessDatabaseOption(
                witnessServer: FromMutable(fragment.WitnessServer),
                isOff: fragment.IsOff,
                optionKind: fragment.OptionKind
            );
        }
        
        public static WlmTimeLiteral FromMutable(ScriptDom.WlmTimeLiteral fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WlmTimeLiteral))) { throw new NotImplementedException("Unexpected subtype of WlmTimeLiteral not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WlmTimeLiteral(
                timeString: FromMutable(fragment.TimeString)
            );
        }
        
        public static WorkloadGroupImportanceParameter FromMutable(ScriptDom.WorkloadGroupImportanceParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WorkloadGroupImportanceParameter))) { throw new NotImplementedException("Unexpected subtype of WorkloadGroupImportanceParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WorkloadGroupImportanceParameter(
                parameterValue: fragment.ParameterValue,
                parameterType: fragment.ParameterType
            );
        }
        
        public static WorkloadGroupResourceParameter FromMutable(ScriptDom.WorkloadGroupResourceParameter fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WorkloadGroupResourceParameter))) { throw new NotImplementedException("Unexpected subtype of WorkloadGroupResourceParameter not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WorkloadGroupResourceParameter(
                parameterValue: FromMutable(fragment.ParameterValue),
                parameterType: fragment.ParameterType
            );
        }
        
        public static WriteTextStatement FromMutable(ScriptDom.WriteTextStatement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WriteTextStatement))) { throw new NotImplementedException("Unexpected subtype of WriteTextStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WriteTextStatement(
                sourceParameter: FromMutable(fragment.SourceParameter),
                bulk: fragment.Bulk,
                column: FromMutable(fragment.Column),
                textId: FromMutable(fragment.TextId),
                timestamp: FromMutable(fragment.Timestamp),
                withLog: fragment.WithLog
            );
        }
        
        public static WsdlPayloadOption FromMutable(ScriptDom.WsdlPayloadOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.WsdlPayloadOption))) { throw new NotImplementedException("Unexpected subtype of WsdlPayloadOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WsdlPayloadOption(
                isNone: fragment.IsNone,
                @value: FromMutable(fragment.Value),
                kind: fragment.Kind
            );
        }
        
        public static XmlCompressionOption FromMutable(ScriptDom.XmlCompressionOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.XmlCompressionOption))) { throw new NotImplementedException("Unexpected subtype of XmlCompressionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new XmlCompressionOption(
                isCompressed: fragment.IsCompressed,
                partitionRanges: fragment.PartitionRanges.SelectList(FromMutable),
                optionKind: fragment.OptionKind
            );
        }
        
        public static XmlDataTypeReference FromMutable(ScriptDom.XmlDataTypeReference fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.XmlDataTypeReference))) { throw new NotImplementedException("Unexpected subtype of XmlDataTypeReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new XmlDataTypeReference(
                xmlDataTypeOption: fragment.XmlDataTypeOption,
                xmlSchemaCollection: FromMutable(fragment.XmlSchemaCollection),
                name: FromMutable(fragment.Name)
            );
        }
        
        public static XmlForClause FromMutable(ScriptDom.XmlForClause fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.XmlForClause))) { throw new NotImplementedException("Unexpected subtype of XmlForClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new XmlForClause(
                options: fragment.Options.SelectList(FromMutable)
            );
        }
        
        public static XmlForClauseOption FromMutable(ScriptDom.XmlForClauseOption fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.XmlForClauseOption))) { throw new NotImplementedException("Unexpected subtype of XmlForClauseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new XmlForClauseOption(
                optionKind: fragment.OptionKind,
                @value: FromMutable(fragment.Value)
            );
        }
        
        public static XmlNamespaces FromMutable(ScriptDom.XmlNamespaces fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.XmlNamespaces))) { throw new NotImplementedException("Unexpected subtype of XmlNamespaces not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new XmlNamespaces(
                xmlNamespacesElements: fragment.XmlNamespacesElements.SelectList(FromMutable)
            );
        }
        
        public static XmlNamespacesAliasElement FromMutable(ScriptDom.XmlNamespacesAliasElement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.XmlNamespacesAliasElement))) { throw new NotImplementedException("Unexpected subtype of XmlNamespacesAliasElement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new XmlNamespacesAliasElement(
                identifier: FromMutable(fragment.Identifier),
                @string: FromMutable(fragment.String)
            );
        }
        
        public static XmlNamespacesDefaultElement FromMutable(ScriptDom.XmlNamespacesDefaultElement fragment) {
            if (fragment is null) { return null; }
            if (!object.ReferenceEquals(fragment.GetType(), typeof(ScriptDom.XmlNamespacesDefaultElement))) { throw new NotImplementedException("Unexpected subtype of XmlNamespacesDefaultElement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new XmlNamespacesDefaultElement(
                @string: FromMutable(fragment.String)
            );
        }
    
    }

}
