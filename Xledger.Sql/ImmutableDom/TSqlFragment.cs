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
                case 1: {
                    var node = (ScriptDom.AcceleratedDatabaseRecoveryDatabaseOption)fragment;
                    return new AcceleratedDatabaseRecoveryDatabaseOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 2: {
                    var node = (ScriptDom.AddAlterFullTextIndexAction)fragment;
                    return new AddAlterFullTextIndexAction(
                        columns: node.Columns.SelectList(c => (FullTextIndexColumn)FromMutable(c)),
                        withNoPopulation: node.WithNoPopulation
                    );
                }
                case 3: {
                    var node = (ScriptDom.AddFileSpec)fragment;
                    return new AddFileSpec(
                        file: (ScalarExpression)FromMutable(node.File),
                        fileName: (Literal)FromMutable(node.FileName)
                    );
                }
                case 4: {
                    var node = (ScriptDom.AddMemberAlterRoleAction)fragment;
                    return new AddMemberAlterRoleAction(
                        member: (Identifier)FromMutable(node.Member)
                    );
                }
                case 5: {
                    var node = (ScriptDom.AddSearchPropertyListAction)fragment;
                    return new AddSearchPropertyListAction(
                        propertyName: (StringLiteral)FromMutable(node.PropertyName),
                        guid: (StringLiteral)FromMutable(node.Guid),
                        id: (IntegerLiteral)FromMutable(node.Id),
                        description: (StringLiteral)FromMutable(node.Description)
                    );
                }
                case 6: {
                    var node = (ScriptDom.AddSensitivityClassificationStatement)fragment;
                    return new AddSensitivityClassificationStatement(
                        options: node.Options.SelectList(c => (SensitivityClassificationOption)FromMutable(c)),
                        columns: node.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
                    );
                }
                case 7: {
                    var node = (ScriptDom.AddSignatureStatement)fragment;
                    return new AddSignatureStatement(
                        isCounter: node.IsCounter,
                        elementKind: node.ElementKind,
                        element: (SchemaObjectName)FromMutable(node.Element),
                        cryptos: node.Cryptos.SelectList(c => (CryptoMechanism)FromMutable(c))
                    );
                }
                case 8: {
                    var node = (ScriptDom.AdHocDataSource)fragment;
                    return new AdHocDataSource(
                        providerName: (StringLiteral)FromMutable(node.ProviderName),
                        initString: (StringLiteral)FromMutable(node.InitString)
                    );
                }
                case 9: {
                    var node = (ScriptDom.AdHocTableReference)fragment;
                    return new AdHocTableReference(
                        dataSource: (AdHocDataSource)FromMutable(node.DataSource),
                        @object: (SchemaObjectNameOrValueExpression)FromMutable(node.Object),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 10: {
                    var node = (ScriptDom.AlgorithmKeyOption)fragment;
                    return new AlgorithmKeyOption(
                        algorithm: node.Algorithm,
                        optionKind: node.OptionKind
                    );
                }
                case 11: {
                    var node = (ScriptDom.AlterApplicationRoleStatement)fragment;
                    return new AlterApplicationRoleStatement(
                        name: (Identifier)FromMutable(node.Name),
                        applicationRoleOptions: node.ApplicationRoleOptions.SelectList(c => (ApplicationRoleOption)FromMutable(c))
                    );
                }
                case 12: {
                    var node = (ScriptDom.AlterAssemblyStatement)fragment;
                    return new AlterAssemblyStatement(
                        dropFiles: node.DropFiles.SelectList(c => (Literal)FromMutable(c)),
                        isDropAll: node.IsDropAll,
                        addFiles: node.AddFiles.SelectList(c => (AddFileSpec)FromMutable(c)),
                        name: (Identifier)FromMutable(node.Name),
                        parameters: node.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        options: node.Options.SelectList(c => (AssemblyOption)FromMutable(c))
                    );
                }
                case 13: {
                    var node = (ScriptDom.AlterAsymmetricKeyStatement)fragment;
                    return new AlterAsymmetricKeyStatement(
                        name: (Identifier)FromMutable(node.Name),
                        attestedBy: (Literal)FromMutable(node.AttestedBy),
                        kind: node.Kind,
                        encryptionPassword: (Literal)FromMutable(node.EncryptionPassword),
                        decryptionPassword: (Literal)FromMutable(node.DecryptionPassword)
                    );
                }
                case 14: {
                    var node = (ScriptDom.AlterAuthorizationStatement)fragment;
                    return new AlterAuthorizationStatement(
                        securityTargetObject: (SecurityTargetObject)FromMutable(node.SecurityTargetObject),
                        toSchemaOwner: node.ToSchemaOwner,
                        principalName: (Identifier)FromMutable(node.PrincipalName)
                    );
                }
                case 15: {
                    var node = (ScriptDom.AlterAvailabilityGroupAction)fragment;
                    return new AlterAvailabilityGroupAction(
                        actionType: node.ActionType
                    );
                }
                case 16: {
                    var node = (ScriptDom.AlterAvailabilityGroupFailoverAction)fragment;
                    return new AlterAvailabilityGroupFailoverAction(
                        options: node.Options.SelectList(c => (AlterAvailabilityGroupFailoverOption)FromMutable(c)),
                        actionType: node.ActionType
                    );
                }
                case 17: {
                    var node = (ScriptDom.AlterAvailabilityGroupFailoverOption)fragment;
                    return new AlterAvailabilityGroupFailoverOption(
                        optionKind: node.OptionKind,
                        @value: (Literal)FromMutable(node.Value)
                    );
                }
                case 18: {
                    var node = (ScriptDom.AlterAvailabilityGroupStatement)fragment;
                    return new AlterAvailabilityGroupStatement(
                        alterAvailabilityGroupStatementType: node.AlterAvailabilityGroupStatementType,
                        action: (AlterAvailabilityGroupAction)FromMutable(node.Action),
                        name: (Identifier)FromMutable(node.Name),
                        options: node.Options.SelectList(c => (AvailabilityGroupOption)FromMutable(c)),
                        databases: node.Databases.SelectList(c => (Identifier)FromMutable(c)),
                        replicas: node.Replicas.SelectList(c => (AvailabilityReplica)FromMutable(c))
                    );
                }
                case 19: {
                    var node = (ScriptDom.AlterBrokerPriorityStatement)fragment;
                    return new AlterBrokerPriorityStatement(
                        name: (Identifier)FromMutable(node.Name),
                        brokerPriorityParameters: node.BrokerPriorityParameters.SelectList(c => (BrokerPriorityParameter)FromMutable(c))
                    );
                }
                case 20: {
                    var node = (ScriptDom.AlterCertificateStatement)fragment;
                    return new AlterCertificateStatement(
                        kind: node.Kind,
                        attestedBy: (Literal)FromMutable(node.AttestedBy),
                        name: (Identifier)FromMutable(node.Name),
                        activeForBeginDialog: node.ActiveForBeginDialog,
                        privateKeyPath: (Literal)FromMutable(node.PrivateKeyPath),
                        encryptionPassword: (Literal)FromMutable(node.EncryptionPassword),
                        decryptionPassword: (Literal)FromMutable(node.DecryptionPassword)
                    );
                }
                case 21: {
                    var node = (ScriptDom.AlterColumnAlterFullTextIndexAction)fragment;
                    return new AlterColumnAlterFullTextIndexAction(
                        column: (FullTextIndexColumn)FromMutable(node.Column),
                        withNoPopulation: node.WithNoPopulation
                    );
                }
                case 22: {
                    var node = (ScriptDom.AlterColumnEncryptionKeyStatement)fragment;
                    return new AlterColumnEncryptionKeyStatement(
                        alterType: node.AlterType,
                        name: (Identifier)FromMutable(node.Name),
                        columnEncryptionKeyValues: node.ColumnEncryptionKeyValues.SelectList(c => (ColumnEncryptionKeyValue)FromMutable(c))
                    );
                }
                case 23: {
                    var node = (ScriptDom.AlterCredentialStatement)fragment;
                    return new AlterCredentialStatement(
                        name: (Identifier)FromMutable(node.Name),
                        identity: (Literal)FromMutable(node.Identity),
                        secret: (Literal)FromMutable(node.Secret),
                        isDatabaseScoped: node.IsDatabaseScoped
                    );
                }
                case 24: {
                    var node = (ScriptDom.AlterCryptographicProviderStatement)fragment;
                    return new AlterCryptographicProviderStatement(
                        name: (Identifier)FromMutable(node.Name),
                        option: node.Option,
                        file: (Literal)FromMutable(node.File)
                    );
                }
                case 25: {
                    var node = (ScriptDom.AlterDatabaseAddFileGroupStatement)fragment;
                    return new AlterDatabaseAddFileGroupStatement(
                        fileGroup: (Identifier)FromMutable(node.FileGroup),
                        containsFileStream: node.ContainsFileStream,
                        containsMemoryOptimizedData: node.ContainsMemoryOptimizedData,
                        databaseName: (Identifier)FromMutable(node.DatabaseName),
                        useCurrent: node.UseCurrent
                    );
                }
                case 26: {
                    var node = (ScriptDom.AlterDatabaseAddFileStatement)fragment;
                    return new AlterDatabaseAddFileStatement(
                        fileDeclarations: node.FileDeclarations.SelectList(c => (FileDeclaration)FromMutable(c)),
                        fileGroup: (Identifier)FromMutable(node.FileGroup),
                        isLog: node.IsLog,
                        databaseName: (Identifier)FromMutable(node.DatabaseName),
                        useCurrent: node.UseCurrent
                    );
                }
                case 27: {
                    var node = (ScriptDom.AlterDatabaseAuditSpecificationStatement)fragment;
                    return new AlterDatabaseAuditSpecificationStatement(
                        auditState: node.AuditState,
                        parts: node.Parts.SelectList(c => (AuditSpecificationPart)FromMutable(c)),
                        specificationName: (Identifier)FromMutable(node.SpecificationName),
                        auditName: (Identifier)FromMutable(node.AuditName)
                    );
                }
                case 28: {
                    var node = (ScriptDom.AlterDatabaseCollateStatement)fragment;
                    return new AlterDatabaseCollateStatement(
                        collation: (Identifier)FromMutable(node.Collation),
                        databaseName: (Identifier)FromMutable(node.DatabaseName),
                        useCurrent: node.UseCurrent
                    );
                }
                case 29: {
                    var node = (ScriptDom.AlterDatabaseEncryptionKeyStatement)fragment;
                    return new AlterDatabaseEncryptionKeyStatement(
                        regenerate: node.Regenerate,
                        encryptor: (CryptoMechanism)FromMutable(node.Encryptor),
                        algorithm: node.Algorithm
                    );
                }
                case 30: {
                    var node = (ScriptDom.AlterDatabaseModifyFileGroupStatement)fragment;
                    return new AlterDatabaseModifyFileGroupStatement(
                        fileGroup: (Identifier)FromMutable(node.FileGroup),
                        newFileGroupName: (Identifier)FromMutable(node.NewFileGroupName),
                        makeDefault: node.MakeDefault,
                        updatabilityOption: node.UpdatabilityOption,
                        termination: (AlterDatabaseTermination)FromMutable(node.Termination),
                        databaseName: (Identifier)FromMutable(node.DatabaseName),
                        useCurrent: node.UseCurrent
                    );
                }
                case 31: {
                    var node = (ScriptDom.AlterDatabaseModifyFileStatement)fragment;
                    return new AlterDatabaseModifyFileStatement(
                        fileDeclaration: (FileDeclaration)FromMutable(node.FileDeclaration),
                        databaseName: (Identifier)FromMutable(node.DatabaseName),
                        useCurrent: node.UseCurrent
                    );
                }
                case 32: {
                    var node = (ScriptDom.AlterDatabaseModifyNameStatement)fragment;
                    return new AlterDatabaseModifyNameStatement(
                        newDatabaseName: (Identifier)FromMutable(node.NewDatabaseName),
                        databaseName: (Identifier)FromMutable(node.DatabaseName),
                        useCurrent: node.UseCurrent
                    );
                }
                case 33: {
                    var node = (ScriptDom.AlterDatabaseRebuildLogStatement)fragment;
                    return new AlterDatabaseRebuildLogStatement(
                        fileDeclaration: (FileDeclaration)FromMutable(node.FileDeclaration),
                        databaseName: (Identifier)FromMutable(node.DatabaseName),
                        useCurrent: node.UseCurrent
                    );
                }
                case 34: {
                    var node = (ScriptDom.AlterDatabaseRemoveFileGroupStatement)fragment;
                    return new AlterDatabaseRemoveFileGroupStatement(
                        fileGroup: (Identifier)FromMutable(node.FileGroup),
                        databaseName: (Identifier)FromMutable(node.DatabaseName),
                        useCurrent: node.UseCurrent
                    );
                }
                case 35: {
                    var node = (ScriptDom.AlterDatabaseRemoveFileStatement)fragment;
                    return new AlterDatabaseRemoveFileStatement(
                        file: (Identifier)FromMutable(node.File),
                        databaseName: (Identifier)FromMutable(node.DatabaseName),
                        useCurrent: node.UseCurrent
                    );
                }
                case 36: {
                    var node = (ScriptDom.AlterDatabaseScopedConfigurationClearStatement)fragment;
                    return new AlterDatabaseScopedConfigurationClearStatement(
                        option: (DatabaseConfigurationClearOption)FromMutable(node.Option),
                        secondary: node.Secondary
                    );
                }
                case 37: {
                    var node = (ScriptDom.AlterDatabaseScopedConfigurationSetStatement)fragment;
                    return new AlterDatabaseScopedConfigurationSetStatement(
                        option: (DatabaseConfigurationSetOption)FromMutable(node.Option),
                        secondary: node.Secondary
                    );
                }
                case 38: {
                    var node = (ScriptDom.AlterDatabaseSetStatement)fragment;
                    return new AlterDatabaseSetStatement(
                        termination: (AlterDatabaseTermination)FromMutable(node.Termination),
                        options: node.Options.SelectList(c => (DatabaseOption)FromMutable(c)),
                        databaseName: (Identifier)FromMutable(node.DatabaseName),
                        useCurrent: node.UseCurrent
                    );
                }
                case 39: {
                    var node = (ScriptDom.AlterDatabaseTermination)fragment;
                    return new AlterDatabaseTermination(
                        immediateRollback: node.ImmediateRollback,
                        rollbackAfter: (Literal)FromMutable(node.RollbackAfter),
                        noWait: node.NoWait
                    );
                }
                case 40: {
                    var node = (ScriptDom.AlterEndpointStatement)fragment;
                    return new AlterEndpointStatement(
                        name: (Identifier)FromMutable(node.Name),
                        state: node.State,
                        affinity: (EndpointAffinity)FromMutable(node.Affinity),
                        protocol: node.Protocol,
                        protocolOptions: node.ProtocolOptions.SelectList(c => (EndpointProtocolOption)FromMutable(c)),
                        endpointType: node.EndpointType,
                        payloadOptions: node.PayloadOptions.SelectList(c => (PayloadOption)FromMutable(c))
                    );
                }
                case 41: {
                    var node = (ScriptDom.AlterEventSessionStatement)fragment;
                    return new AlterEventSessionStatement(
                        statementType: node.StatementType,
                        dropEventDeclarations: node.DropEventDeclarations.SelectList(c => (EventSessionObjectName)FromMutable(c)),
                        dropTargetDeclarations: node.DropTargetDeclarations.SelectList(c => (EventSessionObjectName)FromMutable(c)),
                        name: (Identifier)FromMutable(node.Name),
                        sessionScope: node.SessionScope,
                        eventDeclarations: node.EventDeclarations.SelectList(c => (EventDeclaration)FromMutable(c)),
                        targetDeclarations: node.TargetDeclarations.SelectList(c => (TargetDeclaration)FromMutable(c)),
                        sessionOptions: node.SessionOptions.SelectList(c => (SessionOption)FromMutable(c))
                    );
                }
                case 42: {
                    var node = (ScriptDom.AlterExternalDataSourceStatement)fragment;
                    return new AlterExternalDataSourceStatement(
                        previousPushDownOption: node.PreviousPushDownOption,
                        name: (Identifier)FromMutable(node.Name),
                        dataSourceType: node.DataSourceType,
                        location: (Literal)FromMutable(node.Location),
                        pushdownOption: node.PushdownOption,
                        externalDataSourceOptions: node.ExternalDataSourceOptions.SelectList(c => (ExternalDataSourceOption)FromMutable(c))
                    );
                }
                case 43: {
                    var node = (ScriptDom.AlterExternalLanguageStatement)fragment;
                    return new AlterExternalLanguageStatement(
                        platform: (Identifier)FromMutable(node.Platform),
                        operation: (Identifier)FromMutable(node.Operation),
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name),
                        externalLanguageFiles: node.ExternalLanguageFiles.SelectList(c => (ExternalLanguageFileOption)FromMutable(c))
                    );
                }
                case 44: {
                    var node = (ScriptDom.AlterExternalLibraryStatement)fragment;
                    return new AlterExternalLibraryStatement(
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name),
                        language: (StringLiteral)FromMutable(node.Language),
                        externalLibraryFiles: node.ExternalLibraryFiles.SelectList(c => (ExternalLibraryFileOption)FromMutable(c))
                    );
                }
                case 45: {
                    var node = (ScriptDom.AlterExternalResourcePoolStatement)fragment;
                    return new AlterExternalResourcePoolStatement(
                        name: (Identifier)FromMutable(node.Name),
                        externalResourcePoolParameters: node.ExternalResourcePoolParameters.SelectList(c => (ExternalResourcePoolParameter)FromMutable(c))
                    );
                }
                case 46: {
                    var node = (ScriptDom.AlterFederationStatement)fragment;
                    return new AlterFederationStatement(
                        name: (Identifier)FromMutable(node.Name),
                        kind: node.Kind,
                        distributionName: (Identifier)FromMutable(node.DistributionName),
                        boundary: (ScalarExpression)FromMutable(node.Boundary)
                    );
                }
                case 47: {
                    var node = (ScriptDom.AlterFullTextCatalogStatement)fragment;
                    return new AlterFullTextCatalogStatement(
                        action: node.Action,
                        name: (Identifier)FromMutable(node.Name),
                        options: node.Options.SelectList(c => (FullTextCatalogOption)FromMutable(c))
                    );
                }
                case 48: {
                    var node = (ScriptDom.AlterFullTextIndexStatement)fragment;
                    return new AlterFullTextIndexStatement(
                        onName: (SchemaObjectName)FromMutable(node.OnName),
                        action: (AlterFullTextIndexAction)FromMutable(node.Action)
                    );
                }
                case 49: {
                    var node = (ScriptDom.AlterFullTextStopListStatement)fragment;
                    return new AlterFullTextStopListStatement(
                        name: (Identifier)FromMutable(node.Name),
                        action: (FullTextStopListAction)FromMutable(node.Action)
                    );
                }
                case 50: {
                    var node = (ScriptDom.AlterFunctionStatement)fragment;
                    return new AlterFunctionStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        returnType: (FunctionReturnType)FromMutable(node.ReturnType),
                        options: node.Options.SelectList(c => (FunctionOption)FromMutable(c)),
                        orderHint: (OrderBulkInsertOption)FromMutable(node.OrderHint),
                        parameters: node.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        statementList: (StatementList)FromMutable(node.StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable(node.MethodSpecifier)
                    );
                }
                case 51: {
                    var node = (ScriptDom.AlterIndexStatement)fragment;
                    return new AlterIndexStatement(
                        all: node.All,
                        alterIndexType: node.AlterIndexType,
                        partition: (PartitionSpecifier)FromMutable(node.Partition),
                        promotedPaths: node.PromotedPaths.SelectList(c => (SelectiveXmlIndexPromotedPath)FromMutable(c)),
                        xmlNamespaces: (XmlNamespaces)FromMutable(node.XmlNamespaces),
                        name: (Identifier)FromMutable(node.Name),
                        onName: (SchemaObjectName)FromMutable(node.OnName),
                        indexOptions: node.IndexOptions.SelectList(c => (IndexOption)FromMutable(c))
                    );
                }
                case 52: {
                    var node = (ScriptDom.AlterLoginAddDropCredentialStatement)fragment;
                    return new AlterLoginAddDropCredentialStatement(
                        isAdd: node.IsAdd,
                        credentialName: (Identifier)FromMutable(node.CredentialName),
                        name: (Identifier)FromMutable(node.Name)
                    );
                }
                case 53: {
                    var node = (ScriptDom.AlterLoginEnableDisableStatement)fragment;
                    return new AlterLoginEnableDisableStatement(
                        isEnable: node.IsEnable,
                        name: (Identifier)FromMutable(node.Name)
                    );
                }
                case 54: {
                    var node = (ScriptDom.AlterLoginOptionsStatement)fragment;
                    return new AlterLoginOptionsStatement(
                        options: node.Options.SelectList(c => (PrincipalOption)FromMutable(c)),
                        name: (Identifier)FromMutable(node.Name)
                    );
                }
                case 55: {
                    var node = (ScriptDom.AlterMasterKeyStatement)fragment;
                    return new AlterMasterKeyStatement(
                        option: node.Option,
                        password: (Literal)FromMutable(node.Password)
                    );
                }
                case 56: {
                    var node = (ScriptDom.AlterMessageTypeStatement)fragment;
                    return new AlterMessageTypeStatement(
                        name: (Identifier)FromMutable(node.Name),
                        validationMethod: node.ValidationMethod,
                        xmlSchemaCollectionName: (SchemaObjectName)FromMutable(node.XmlSchemaCollectionName)
                    );
                }
                case 57: {
                    var node = (ScriptDom.AlterPartitionFunctionStatement)fragment;
                    return new AlterPartitionFunctionStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isSplit: node.IsSplit,
                        boundary: (ScalarExpression)FromMutable(node.Boundary)
                    );
                }
                case 58: {
                    var node = (ScriptDom.AlterPartitionSchemeStatement)fragment;
                    return new AlterPartitionSchemeStatement(
                        name: (Identifier)FromMutable(node.Name),
                        fileGroup: (IdentifierOrValueExpression)FromMutable(node.FileGroup)
                    );
                }
                case 59: {
                    var node = (ScriptDom.AlterProcedureStatement)fragment;
                    return new AlterProcedureStatement(
                        procedureReference: (ProcedureReference)FromMutable(node.ProcedureReference),
                        isForReplication: node.IsForReplication,
                        options: node.Options.SelectList(c => (ProcedureOption)FromMutable(c)),
                        parameters: node.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        statementList: (StatementList)FromMutable(node.StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable(node.MethodSpecifier)
                    );
                }
                case 60: {
                    var node = (ScriptDom.AlterQueueStatement)fragment;
                    return new AlterQueueStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        queueOptions: node.QueueOptions.SelectList(c => (QueueOption)FromMutable(c))
                    );
                }
                case 61: {
                    var node = (ScriptDom.AlterRemoteServiceBindingStatement)fragment;
                    return new AlterRemoteServiceBindingStatement(
                        name: (Identifier)FromMutable(node.Name),
                        options: node.Options.SelectList(c => (RemoteServiceBindingOption)FromMutable(c))
                    );
                }
                case 62: {
                    var node = (ScriptDom.AlterResourceGovernorStatement)fragment;
                    return new AlterResourceGovernorStatement(
                        command: node.Command,
                        classifierFunction: (SchemaObjectName)FromMutable(node.ClassifierFunction)
                    );
                }
                case 63: {
                    var node = (ScriptDom.AlterResourcePoolStatement)fragment;
                    return new AlterResourcePoolStatement(
                        name: (Identifier)FromMutable(node.Name),
                        resourcePoolParameters: node.ResourcePoolParameters.SelectList(c => (ResourcePoolParameter)FromMutable(c))
                    );
                }
                case 64: {
                    var node = (ScriptDom.AlterRoleStatement)fragment;
                    return new AlterRoleStatement(
                        action: (AlterRoleAction)FromMutable(node.Action),
                        name: (Identifier)FromMutable(node.Name)
                    );
                }
                case 65: {
                    var node = (ScriptDom.AlterRouteStatement)fragment;
                    return new AlterRouteStatement(
                        name: (Identifier)FromMutable(node.Name),
                        routeOptions: node.RouteOptions.SelectList(c => (RouteOption)FromMutable(c))
                    );
                }
                case 66: {
                    var node = (ScriptDom.AlterSchemaStatement)fragment;
                    return new AlterSchemaStatement(
                        name: (Identifier)FromMutable(node.Name),
                        objectName: (SchemaObjectName)FromMutable(node.ObjectName),
                        objectKind: node.ObjectKind
                    );
                }
                case 67: {
                    var node = (ScriptDom.AlterSearchPropertyListStatement)fragment;
                    return new AlterSearchPropertyListStatement(
                        name: (Identifier)FromMutable(node.Name),
                        action: (SearchPropertyListAction)FromMutable(node.Action)
                    );
                }
                case 68: {
                    var node = (ScriptDom.AlterSecurityPolicyStatement)fragment;
                    return new AlterSecurityPolicyStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        notForReplication: node.NotForReplication,
                        securityPolicyOptions: node.SecurityPolicyOptions.SelectList(c => (SecurityPolicyOption)FromMutable(c)),
                        securityPredicateActions: node.SecurityPredicateActions.SelectList(c => (SecurityPredicateAction)FromMutable(c)),
                        actionType: node.ActionType
                    );
                }
                case 69: {
                    var node = (ScriptDom.AlterSequenceStatement)fragment;
                    return new AlterSequenceStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        sequenceOptions: node.SequenceOptions.SelectList(c => (SequenceOption)FromMutable(c))
                    );
                }
                case 70: {
                    var node = (ScriptDom.AlterServerAuditSpecificationStatement)fragment;
                    return new AlterServerAuditSpecificationStatement(
                        auditState: node.AuditState,
                        parts: node.Parts.SelectList(c => (AuditSpecificationPart)FromMutable(c)),
                        specificationName: (Identifier)FromMutable(node.SpecificationName),
                        auditName: (Identifier)FromMutable(node.AuditName)
                    );
                }
                case 71: {
                    var node = (ScriptDom.AlterServerAuditStatement)fragment;
                    return new AlterServerAuditStatement(
                        newName: (Identifier)FromMutable(node.NewName),
                        removeWhere: node.RemoveWhere,
                        auditName: (Identifier)FromMutable(node.AuditName),
                        auditTarget: (AuditTarget)FromMutable(node.AuditTarget),
                        options: node.Options.SelectList(c => (AuditOption)FromMutable(c)),
                        predicateExpression: (BooleanExpression)FromMutable(node.PredicateExpression)
                    );
                }
                case 72: {
                    var node = (ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption)fragment;
                    return new AlterServerConfigurationBufferPoolExtensionContainerOption(
                        suboptions: node.Suboptions.SelectList(c => (AlterServerConfigurationBufferPoolExtensionOption)FromMutable(c)),
                        optionKind: node.OptionKind,
                        optionValue: (OptionValue)FromMutable(node.OptionValue)
                    );
                }
                case 73: {
                    var node = (ScriptDom.AlterServerConfigurationBufferPoolExtensionOption)fragment;
                    return new AlterServerConfigurationBufferPoolExtensionOption(
                        optionKind: node.OptionKind,
                        optionValue: (OptionValue)FromMutable(node.OptionValue)
                    );
                }
                case 74: {
                    var node = (ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption)fragment;
                    return new AlterServerConfigurationBufferPoolExtensionSizeOption(
                        sizeUnit: node.SizeUnit,
                        optionKind: node.OptionKind,
                        optionValue: (OptionValue)FromMutable(node.OptionValue)
                    );
                }
                case 75: {
                    var node = (ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption)fragment;
                    return new AlterServerConfigurationDiagnosticsLogMaxSizeOption(
                        sizeUnit: node.SizeUnit,
                        optionKind: node.OptionKind,
                        optionValue: (OptionValue)FromMutable(node.OptionValue)
                    );
                }
                case 76: {
                    var node = (ScriptDom.AlterServerConfigurationDiagnosticsLogOption)fragment;
                    return new AlterServerConfigurationDiagnosticsLogOption(
                        optionKind: node.OptionKind,
                        optionValue: (OptionValue)FromMutable(node.OptionValue)
                    );
                }
                case 77: {
                    var node = (ScriptDom.AlterServerConfigurationExternalAuthenticationContainerOption)fragment;
                    return new AlterServerConfigurationExternalAuthenticationContainerOption(
                        suboptions: node.Suboptions.SelectList(c => (AlterServerConfigurationExternalAuthenticationOption)FromMutable(c)),
                        optionKind: node.OptionKind,
                        optionValue: (OptionValue)FromMutable(node.OptionValue)
                    );
                }
                case 78: {
                    var node = (ScriptDom.AlterServerConfigurationExternalAuthenticationOption)fragment;
                    return new AlterServerConfigurationExternalAuthenticationOption(
                        optionKind: node.OptionKind,
                        optionValue: (OptionValue)FromMutable(node.OptionValue)
                    );
                }
                case 79: {
                    var node = (ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption)fragment;
                    return new AlterServerConfigurationFailoverClusterPropertyOption(
                        optionKind: node.OptionKind,
                        optionValue: (OptionValue)FromMutable(node.OptionValue)
                    );
                }
                case 80: {
                    var node = (ScriptDom.AlterServerConfigurationHadrClusterOption)fragment;
                    return new AlterServerConfigurationHadrClusterOption(
                        optionKind: node.OptionKind,
                        optionValue: (OptionValue)FromMutable(node.OptionValue),
                        isLocal: node.IsLocal
                    );
                }
                case 81: {
                    var node = (ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement)fragment;
                    return new AlterServerConfigurationSetBufferPoolExtensionStatement(
                        options: node.Options.SelectList(c => (AlterServerConfigurationBufferPoolExtensionOption)FromMutable(c))
                    );
                }
                case 82: {
                    var node = (ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement)fragment;
                    return new AlterServerConfigurationSetDiagnosticsLogStatement(
                        options: node.Options.SelectList(c => (AlterServerConfigurationDiagnosticsLogOption)FromMutable(c))
                    );
                }
                case 83: {
                    var node = (ScriptDom.AlterServerConfigurationSetExternalAuthenticationStatement)fragment;
                    return new AlterServerConfigurationSetExternalAuthenticationStatement(
                        options: node.Options.SelectList(c => (AlterServerConfigurationExternalAuthenticationOption)FromMutable(c))
                    );
                }
                case 84: {
                    var node = (ScriptDom.AlterServerConfigurationSetFailoverClusterPropertyStatement)fragment;
                    return new AlterServerConfigurationSetFailoverClusterPropertyStatement(
                        options: node.Options.SelectList(c => (AlterServerConfigurationFailoverClusterPropertyOption)FromMutable(c))
                    );
                }
                case 85: {
                    var node = (ScriptDom.AlterServerConfigurationSetHadrClusterStatement)fragment;
                    return new AlterServerConfigurationSetHadrClusterStatement(
                        options: node.Options.SelectList(c => (AlterServerConfigurationHadrClusterOption)FromMutable(c))
                    );
                }
                case 86: {
                    var node = (ScriptDom.AlterServerConfigurationSetSoftNumaStatement)fragment;
                    return new AlterServerConfigurationSetSoftNumaStatement(
                        options: node.Options.SelectList(c => (AlterServerConfigurationSoftNumaOption)FromMutable(c))
                    );
                }
                case 87: {
                    var node = (ScriptDom.AlterServerConfigurationSoftNumaOption)fragment;
                    return new AlterServerConfigurationSoftNumaOption(
                        optionKind: node.OptionKind,
                        optionValue: (OptionValue)FromMutable(node.OptionValue)
                    );
                }
                case 88: {
                    var node = (ScriptDom.AlterServerConfigurationStatement)fragment;
                    return new AlterServerConfigurationStatement(
                        processAffinity: node.ProcessAffinity,
                        processAffinityRanges: node.ProcessAffinityRanges.SelectList(c => (ProcessAffinityRange)FromMutable(c))
                    );
                }
                case 89: {
                    var node = (ScriptDom.AlterServerRoleStatement)fragment;
                    return new AlterServerRoleStatement(
                        action: (AlterRoleAction)FromMutable(node.Action),
                        name: (Identifier)FromMutable(node.Name)
                    );
                }
                case 90: {
                    var node = (ScriptDom.AlterServiceMasterKeyStatement)fragment;
                    return new AlterServiceMasterKeyStatement(
                        account: (Literal)FromMutable(node.Account),
                        password: (Literal)FromMutable(node.Password),
                        kind: node.Kind
                    );
                }
                case 91: {
                    var node = (ScriptDom.AlterServiceStatement)fragment;
                    return new AlterServiceStatement(
                        name: (Identifier)FromMutable(node.Name),
                        queueName: (SchemaObjectName)FromMutable(node.QueueName),
                        serviceContracts: node.ServiceContracts.SelectList(c => (ServiceContract)FromMutable(c))
                    );
                }
                case 92: {
                    var node = (ScriptDom.AlterSymmetricKeyStatement)fragment;
                    return new AlterSymmetricKeyStatement(
                        isAdd: node.IsAdd,
                        name: (Identifier)FromMutable(node.Name),
                        encryptingMechanisms: node.EncryptingMechanisms.SelectList(c => (CryptoMechanism)FromMutable(c))
                    );
                }
                case 93: {
                    var node = (ScriptDom.AlterTableAddTableElementStatement)fragment;
                    return new AlterTableAddTableElementStatement(
                        existingRowsCheckEnforcement: node.ExistingRowsCheckEnforcement,
                        definition: (TableDefinition)FromMutable(node.Definition),
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName)
                    );
                }
                case 94: {
                    var node = (ScriptDom.AlterTableAlterColumnStatement)fragment;
                    return new AlterTableAlterColumnStatement(
                        columnIdentifier: (Identifier)FromMutable(node.ColumnIdentifier),
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        alterTableAlterColumnOption: node.AlterTableAlterColumnOption,
                        storageOptions: (ColumnStorageOptions)FromMutable(node.StorageOptions),
                        options: node.Options.SelectList(c => (IndexOption)FromMutable(c)),
                        generatedAlways: node.GeneratedAlways,
                        isHidden: node.IsHidden,
                        encryption: (ColumnEncryptionDefinition)FromMutable(node.Encryption),
                        collation: (Identifier)FromMutable(node.Collation),
                        isMasked: node.IsMasked,
                        maskingFunction: (StringLiteral)FromMutable(node.MaskingFunction),
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName)
                    );
                }
                case 95: {
                    var node = (ScriptDom.AlterTableAlterIndexStatement)fragment;
                    return new AlterTableAlterIndexStatement(
                        indexIdentifier: (Identifier)FromMutable(node.IndexIdentifier),
                        alterIndexType: node.AlterIndexType,
                        indexOptions: node.IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName)
                    );
                }
                case 96: {
                    var node = (ScriptDom.AlterTableAlterPartitionStatement)fragment;
                    return new AlterTableAlterPartitionStatement(
                        boundaryValue: (ScalarExpression)FromMutable(node.BoundaryValue),
                        isSplit: node.IsSplit,
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName)
                    );
                }
                case 97: {
                    var node = (ScriptDom.AlterTableChangeTrackingModificationStatement)fragment;
                    return new AlterTableChangeTrackingModificationStatement(
                        isEnable: node.IsEnable,
                        trackColumnsUpdated: node.TrackColumnsUpdated,
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName)
                    );
                }
                case 98: {
                    var node = (ScriptDom.AlterTableConstraintModificationStatement)fragment;
                    return new AlterTableConstraintModificationStatement(
                        existingRowsCheckEnforcement: node.ExistingRowsCheckEnforcement,
                        constraintEnforcement: node.ConstraintEnforcement,
                        all: node.All,
                        constraintNames: node.ConstraintNames.SelectList(c => (Identifier)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName)
                    );
                }
                case 99: {
                    var node = (ScriptDom.AlterTableDropTableElement)fragment;
                    return new AlterTableDropTableElement(
                        tableElementType: node.TableElementType,
                        name: (Identifier)FromMutable(node.Name),
                        dropClusteredConstraintOptions: node.DropClusteredConstraintOptions.SelectList(c => (DropClusteredConstraintOption)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 100: {
                    var node = (ScriptDom.AlterTableDropTableElementStatement)fragment;
                    return new AlterTableDropTableElementStatement(
                        alterTableDropTableElements: node.AlterTableDropTableElements.SelectList(c => (AlterTableDropTableElement)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName)
                    );
                }
                case 101: {
                    var node = (ScriptDom.AlterTableFileTableNamespaceStatement)fragment;
                    return new AlterTableFileTableNamespaceStatement(
                        isEnable: node.IsEnable,
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName)
                    );
                }
                case 102: {
                    var node = (ScriptDom.AlterTableRebuildStatement)fragment;
                    return new AlterTableRebuildStatement(
                        partition: (PartitionSpecifier)FromMutable(node.Partition),
                        indexOptions: node.IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName)
                    );
                }
                case 103: {
                    var node = (ScriptDom.AlterTableSetStatement)fragment;
                    return new AlterTableSetStatement(
                        options: node.Options.SelectList(c => (TableOption)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName)
                    );
                }
                case 104: {
                    var node = (ScriptDom.AlterTableSwitchStatement)fragment;
                    return new AlterTableSwitchStatement(
                        sourcePartitionNumber: (ScalarExpression)FromMutable(node.SourcePartitionNumber),
                        targetPartitionNumber: (ScalarExpression)FromMutable(node.TargetPartitionNumber),
                        targetTable: (SchemaObjectName)FromMutable(node.TargetTable),
                        options: node.Options.SelectList(c => (TableSwitchOption)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName)
                    );
                }
                case 105: {
                    var node = (ScriptDom.AlterTableTriggerModificationStatement)fragment;
                    return new AlterTableTriggerModificationStatement(
                        triggerEnforcement: node.TriggerEnforcement,
                        all: node.All,
                        triggerNames: node.TriggerNames.SelectList(c => (Identifier)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName)
                    );
                }
                case 106: {
                    var node = (ScriptDom.AlterTriggerStatement)fragment;
                    return new AlterTriggerStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        triggerObject: (TriggerObject)FromMutable(node.TriggerObject),
                        options: node.Options.SelectList(c => (TriggerOption)FromMutable(c)),
                        triggerType: node.TriggerType,
                        triggerActions: node.TriggerActions.SelectList(c => (TriggerAction)FromMutable(c)),
                        withAppend: node.WithAppend,
                        isNotForReplication: node.IsNotForReplication,
                        statementList: (StatementList)FromMutable(node.StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable(node.MethodSpecifier)
                    );
                }
                case 107: {
                    var node = (ScriptDom.AlterUserStatement)fragment;
                    return new AlterUserStatement(
                        name: (Identifier)FromMutable(node.Name),
                        userOptions: node.UserOptions.SelectList(c => (PrincipalOption)FromMutable(c))
                    );
                }
                case 108: {
                    var node = (ScriptDom.AlterViewStatement)fragment;
                    return new AlterViewStatement(
                        isRebuild: node.IsRebuild,
                        isDisable: node.IsDisable,
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        viewOptions: node.ViewOptions.SelectList(c => (ViewOption)FromMutable(c)),
                        selectStatement: (SelectStatement)FromMutable(node.SelectStatement),
                        withCheckOption: node.WithCheckOption,
                        isMaterialized: node.IsMaterialized
                    );
                }
                case 109: {
                    var node = (ScriptDom.AlterWorkloadGroupStatement)fragment;
                    return new AlterWorkloadGroupStatement(
                        name: (Identifier)FromMutable(node.Name),
                        workloadGroupParameters: node.WorkloadGroupParameters.SelectList(c => (WorkloadGroupParameter)FromMutable(c)),
                        poolName: (Identifier)FromMutable(node.PoolName),
                        externalPoolName: (Identifier)FromMutable(node.ExternalPoolName)
                    );
                }
                case 110: {
                    var node = (ScriptDom.AlterXmlSchemaCollectionStatement)fragment;
                    return new AlterXmlSchemaCollectionStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        expression: (ScalarExpression)FromMutable(node.Expression)
                    );
                }
                case 111: {
                    var node = (ScriptDom.ApplicationRoleOption)fragment;
                    return new ApplicationRoleOption(
                        optionKind: node.OptionKind,
                        @value: (IdentifierOrValueExpression)FromMutable(node.Value)
                    );
                }
                case 112: {
                    var node = (ScriptDom.AssemblyEncryptionSource)fragment;
                    return new AssemblyEncryptionSource(
                        assembly: (Identifier)FromMutable(node.Assembly)
                    );
                }
                case 113: {
                    var node = (ScriptDom.AssemblyName)fragment;
                    return new AssemblyName(
                        name: (Identifier)FromMutable(node.Name),
                        className: (Identifier)FromMutable(node.ClassName)
                    );
                }
                case 114: {
                    var node = (ScriptDom.AssemblyOption)fragment;
                    return new AssemblyOption(
                        optionKind: node.OptionKind
                    );
                }
                case 115: {
                    var node = (ScriptDom.AssignmentSetClause)fragment;
                    return new AssignmentSetClause(
                        variable: (VariableReference)FromMutable(node.Variable),
                        column: (ColumnReferenceExpression)FromMutable(node.Column),
                        newValue: (ScalarExpression)FromMutable(node.NewValue),
                        assignmentKind: node.AssignmentKind
                    );
                }
                case 116: {
                    var node = (ScriptDom.AsymmetricKeyCreateLoginSource)fragment;
                    return new AsymmetricKeyCreateLoginSource(
                        key: (Identifier)FromMutable(node.Key),
                        credential: (Identifier)FromMutable(node.Credential)
                    );
                }
                case 117: {
                    var node = (ScriptDom.AtTimeZoneCall)fragment;
                    return new AtTimeZoneCall(
                        dateValue: (ScalarExpression)FromMutable(node.DateValue),
                        timeZone: (ScalarExpression)FromMutable(node.TimeZone),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 118: {
                    var node = (ScriptDom.AuditActionGroupReference)fragment;
                    return new AuditActionGroupReference(
                        group: node.Group
                    );
                }
                case 119: {
                    var node = (ScriptDom.AuditActionSpecification)fragment;
                    return new AuditActionSpecification(
                        actions: node.Actions.SelectList(c => (DatabaseAuditAction)FromMutable(c)),
                        principals: node.Principals.SelectList(c => (SecurityPrincipal)FromMutable(c)),
                        targetObject: (SecurityTargetObject)FromMutable(node.TargetObject)
                    );
                }
                case 120: {
                    var node = (ScriptDom.AuditGuidAuditOption)fragment;
                    return new AuditGuidAuditOption(
                        guid: (Literal)FromMutable(node.Guid),
                        optionKind: node.OptionKind
                    );
                }
                case 121: {
                    var node = (ScriptDom.AuditSpecificationPart)fragment;
                    return new AuditSpecificationPart(
                        isDrop: node.IsDrop,
                        details: (AuditSpecificationDetail)FromMutable(node.Details)
                    );
                }
                case 122: {
                    var node = (ScriptDom.AuditTarget)fragment;
                    return new AuditTarget(
                        targetKind: node.TargetKind,
                        targetOptions: node.TargetOptions.SelectList(c => (AuditTargetOption)FromMutable(c))
                    );
                }
                case 123: {
                    var node = (ScriptDom.AuthenticationEndpointProtocolOption)fragment;
                    return new AuthenticationEndpointProtocolOption(
                        authenticationTypes: node.AuthenticationTypes,
                        kind: node.Kind
                    );
                }
                case 124: {
                    var node = (ScriptDom.AuthenticationPayloadOption)fragment;
                    return new AuthenticationPayloadOption(
                        protocol: node.Protocol,
                        certificate: (Identifier)FromMutable(node.Certificate),
                        tryCertificateFirst: node.TryCertificateFirst,
                        kind: node.Kind
                    );
                }
                case 125: {
                    var node = (ScriptDom.AutoCleanupChangeTrackingOptionDetail)fragment;
                    return new AutoCleanupChangeTrackingOptionDetail(
                        isOn: node.IsOn
                    );
                }
                case 126: {
                    var node = (ScriptDom.AutoCreateStatisticsDatabaseOption)fragment;
                    return new AutoCreateStatisticsDatabaseOption(
                        hasIncremental: node.HasIncremental,
                        incrementalState: node.IncrementalState,
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 127: {
                    var node = (ScriptDom.AutomaticTuningCreateIndexOption)fragment;
                    return new AutomaticTuningCreateIndexOption(
                        optionKind: node.OptionKind,
                        @value: node.Value
                    );
                }
                case 128: {
                    var node = (ScriptDom.AutomaticTuningDatabaseOption)fragment;
                    return new AutomaticTuningDatabaseOption(
                        automaticTuningState: node.AutomaticTuningState,
                        options: node.Options.SelectList(c => (AutomaticTuningOption)FromMutable(c)),
                        optionKind: node.OptionKind
                    );
                }
                case 129: {
                    var node = (ScriptDom.AutomaticTuningDropIndexOption)fragment;
                    return new AutomaticTuningDropIndexOption(
                        optionKind: node.OptionKind,
                        @value: node.Value
                    );
                }
                case 130: {
                    var node = (ScriptDom.AutomaticTuningForceLastGoodPlanOption)fragment;
                    return new AutomaticTuningForceLastGoodPlanOption(
                        optionKind: node.OptionKind,
                        @value: node.Value
                    );
                }
                case 131: {
                    var node = (ScriptDom.AutomaticTuningMaintainIndexOption)fragment;
                    return new AutomaticTuningMaintainIndexOption(
                        optionKind: node.OptionKind,
                        @value: node.Value
                    );
                }
                case 132: {
                    var node = (ScriptDom.AutomaticTuningOption)fragment;
                    return new AutomaticTuningOption(
                        optionKind: node.OptionKind,
                        @value: node.Value
                    );
                }
                case 133: {
                    var node = (ScriptDom.AvailabilityModeReplicaOption)fragment;
                    return new AvailabilityModeReplicaOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 134: {
                    var node = (ScriptDom.AvailabilityReplica)fragment;
                    return new AvailabilityReplica(
                        serverName: (StringLiteral)FromMutable(node.ServerName),
                        options: node.Options.SelectList(c => (AvailabilityReplicaOption)FromMutable(c))
                    );
                }
                case 135: {
                    var node = (ScriptDom.BackupCertificateStatement)fragment;
                    return new BackupCertificateStatement(
                        file: (Literal)FromMutable(node.File),
                        name: (Identifier)FromMutable(node.Name),
                        activeForBeginDialog: node.ActiveForBeginDialog,
                        privateKeyPath: (Literal)FromMutable(node.PrivateKeyPath),
                        encryptionPassword: (Literal)FromMutable(node.EncryptionPassword),
                        decryptionPassword: (Literal)FromMutable(node.DecryptionPassword)
                    );
                }
                case 136: {
                    var node = (ScriptDom.BackupDatabaseStatement)fragment;
                    return new BackupDatabaseStatement(
                        files: node.Files.SelectList(c => (BackupRestoreFileInfo)FromMutable(c)),
                        databaseName: (IdentifierOrValueExpression)FromMutable(node.DatabaseName),
                        options: node.Options.SelectList(c => (BackupOption)FromMutable(c)),
                        mirrorToClauses: node.MirrorToClauses.SelectList(c => (MirrorToClause)FromMutable(c)),
                        devices: node.Devices.SelectList(c => (DeviceInfo)FromMutable(c))
                    );
                }
                case 137: {
                    var node = (ScriptDom.BackupEncryptionOption)fragment;
                    return new BackupEncryptionOption(
                        algorithm: node.Algorithm,
                        encryptor: (CryptoMechanism)FromMutable(node.Encryptor),
                        optionKind: node.OptionKind,
                        @value: (ScalarExpression)FromMutable(node.Value)
                    );
                }
                case 138: {
                    var node = (ScriptDom.BackupMasterKeyStatement)fragment;
                    return new BackupMasterKeyStatement(
                        file: (Literal)FromMutable(node.File),
                        password: (Literal)FromMutable(node.Password)
                    );
                }
                case 139: {
                    var node = (ScriptDom.BackupOption)fragment;
                    return new BackupOption(
                        optionKind: node.OptionKind,
                        @value: (ScalarExpression)FromMutable(node.Value)
                    );
                }
                case 140: {
                    var node = (ScriptDom.BackupRestoreFileInfo)fragment;
                    return new BackupRestoreFileInfo(
                        items: node.Items.SelectList(c => (ValueExpression)FromMutable(c)),
                        itemKind: node.ItemKind
                    );
                }
                case 141: {
                    var node = (ScriptDom.BackupServiceMasterKeyStatement)fragment;
                    return new BackupServiceMasterKeyStatement(
                        file: (Literal)FromMutable(node.File),
                        password: (Literal)FromMutable(node.Password)
                    );
                }
                case 142: {
                    var node = (ScriptDom.BackupTransactionLogStatement)fragment;
                    return new BackupTransactionLogStatement(
                        databaseName: (IdentifierOrValueExpression)FromMutable(node.DatabaseName),
                        options: node.Options.SelectList(c => (BackupOption)FromMutable(c)),
                        mirrorToClauses: node.MirrorToClauses.SelectList(c => (MirrorToClause)FromMutable(c)),
                        devices: node.Devices.SelectList(c => (DeviceInfo)FromMutable(c))
                    );
                }
                case 143: {
                    var node = (ScriptDom.BackwardsCompatibleDropIndexClause)fragment;
                    return new BackwardsCompatibleDropIndexClause(
                        index: (ChildObjectName)FromMutable(node.Index)
                    );
                }
                case 144: {
                    var node = (ScriptDom.BeginConversationTimerStatement)fragment;
                    return new BeginConversationTimerStatement(
                        handle: (ScalarExpression)FromMutable(node.Handle),
                        timeout: (ScalarExpression)FromMutable(node.Timeout)
                    );
                }
                case 145: {
                    var node = (ScriptDom.BeginDialogStatement)fragment;
                    return new BeginDialogStatement(
                        isConversation: node.IsConversation,
                        handle: (VariableReference)FromMutable(node.Handle),
                        initiatorServiceName: (IdentifierOrValueExpression)FromMutable(node.InitiatorServiceName),
                        targetServiceName: (ValueExpression)FromMutable(node.TargetServiceName),
                        instanceSpec: (ValueExpression)FromMutable(node.InstanceSpec),
                        contractName: (IdentifierOrValueExpression)FromMutable(node.ContractName),
                        options: node.Options.SelectList(c => (DialogOption)FromMutable(c))
                    );
                }
                case 146: {
                    var node = (ScriptDom.BeginEndAtomicBlockStatement)fragment;
                    return new BeginEndAtomicBlockStatement(
                        options: node.Options.SelectList(c => (AtomicBlockOption)FromMutable(c)),
                        statementList: (StatementList)FromMutable(node.StatementList)
                    );
                }
                case 147: {
                    var node = (ScriptDom.BeginEndBlockStatement)fragment;
                    return new BeginEndBlockStatement(
                        statementList: (StatementList)FromMutable(node.StatementList)
                    );
                }
                case 148: {
                    var node = (ScriptDom.BeginTransactionStatement)fragment;
                    return new BeginTransactionStatement(
                        distributed: node.Distributed,
                        markDefined: node.MarkDefined,
                        markDescription: (ValueExpression)FromMutable(node.MarkDescription),
                        name: (IdentifierOrValueExpression)FromMutable(node.Name)
                    );
                }
                case 149: {
                    var node = (ScriptDom.BinaryExpression)fragment;
                    return new BinaryExpression(
                        binaryExpressionType: node.BinaryExpressionType,
                        firstExpression: (ScalarExpression)FromMutable(node.FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable(node.SecondExpression)
                    );
                }
                case 150: {
                    var node = (ScriptDom.BinaryLiteral)fragment;
                    return new BinaryLiteral(
                        isLargeObject: node.IsLargeObject,
                        @value: node.Value,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 151: {
                    var node = (ScriptDom.BinaryQueryExpression)fragment;
                    return new BinaryQueryExpression(
                        binaryQueryExpressionType: node.BinaryQueryExpressionType,
                        all: node.All,
                        firstQueryExpression: (QueryExpression)FromMutable(node.FirstQueryExpression),
                        secondQueryExpression: (QueryExpression)FromMutable(node.SecondQueryExpression),
                        orderByClause: (OrderByClause)FromMutable(node.OrderByClause),
                        offsetClause: (OffsetClause)FromMutable(node.OffsetClause),
                        forClause: (ForClause)FromMutable(node.ForClause)
                    );
                }
                case 152: {
                    var node = (ScriptDom.BooleanBinaryExpression)fragment;
                    return new BooleanBinaryExpression(
                        binaryExpressionType: node.BinaryExpressionType,
                        firstExpression: (BooleanExpression)FromMutable(node.FirstExpression),
                        secondExpression: (BooleanExpression)FromMutable(node.SecondExpression)
                    );
                }
                case 153: {
                    var node = (ScriptDom.BooleanComparisonExpression)fragment;
                    return new BooleanComparisonExpression(
                        comparisonType: node.ComparisonType,
                        firstExpression: (ScalarExpression)FromMutable(node.FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable(node.SecondExpression)
                    );
                }
                case 154: {
                    var node = (ScriptDom.BooleanExpressionSnippet)fragment;
                    return new BooleanExpressionSnippet(
                        script: node.Script
                    );
                }
                case 155: {
                    var node = (ScriptDom.BooleanIsNullExpression)fragment;
                    return new BooleanIsNullExpression(
                        isNot: node.IsNot,
                        expression: (ScalarExpression)FromMutable(node.Expression)
                    );
                }
                case 156: {
                    var node = (ScriptDom.BooleanNotExpression)fragment;
                    return new BooleanNotExpression(
                        expression: (BooleanExpression)FromMutable(node.Expression)
                    );
                }
                case 157: {
                    var node = (ScriptDom.BooleanParenthesisExpression)fragment;
                    return new BooleanParenthesisExpression(
                        expression: (BooleanExpression)FromMutable(node.Expression)
                    );
                }
                case 158: {
                    var node = (ScriptDom.BooleanTernaryExpression)fragment;
                    return new BooleanTernaryExpression(
                        ternaryExpressionType: node.TernaryExpressionType,
                        firstExpression: (ScalarExpression)FromMutable(node.FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable(node.SecondExpression),
                        thirdExpression: (ScalarExpression)FromMutable(node.ThirdExpression)
                    );
                }
                case 159: {
                    var node = (ScriptDom.BoundingBoxParameter)fragment;
                    return new BoundingBoxParameter(
                        parameter: node.Parameter,
                        @value: (ScalarExpression)FromMutable(node.Value)
                    );
                }
                case 160: {
                    var node = (ScriptDom.BoundingBoxSpatialIndexOption)fragment;
                    return new BoundingBoxSpatialIndexOption(
                        boundingBoxParameters: node.BoundingBoxParameters.SelectList(c => (BoundingBoxParameter)FromMutable(c))
                    );
                }
                case 161: {
                    var node = (ScriptDom.BreakStatement)fragment;
                    return new BreakStatement(
                        
                    );
                }
                case 162: {
                    var node = (ScriptDom.BrokerPriorityParameter)fragment;
                    return new BrokerPriorityParameter(
                        isDefaultOrAny: node.IsDefaultOrAny,
                        parameterType: node.ParameterType,
                        parameterValue: (IdentifierOrValueExpression)FromMutable(node.ParameterValue)
                    );
                }
                case 163: {
                    var node = (ScriptDom.BrowseForClause)fragment;
                    return new BrowseForClause(
                        
                    );
                }
                case 164: {
                    var node = (ScriptDom.BuiltInFunctionTableReference)fragment;
                    return new BuiltInFunctionTableReference(
                        name: (Identifier)FromMutable(node.Name),
                        parameters: node.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 165: {
                    var node = (ScriptDom.BulkInsertOption)fragment;
                    return new BulkInsertOption(
                        optionKind: node.OptionKind
                    );
                }
                case 166: {
                    var node = (ScriptDom.BulkInsertStatement)fragment;
                    return new BulkInsertStatement(
                        from: (IdentifierOrValueExpression)FromMutable(node.From),
                        to: (SchemaObjectName)FromMutable(node.To),
                        options: node.Options.SelectList(c => (BulkInsertOption)FromMutable(c))
                    );
                }
                case 167: {
                    var node = (ScriptDom.BulkOpenRowset)fragment;
                    return new BulkOpenRowset(
                        dataFiles: node.DataFiles.SelectList(c => (StringLiteral)FromMutable(c)),
                        options: node.Options.SelectList(c => (BulkInsertOption)FromMutable(c)),
                        withColumns: node.WithColumns.SelectList(c => (OpenRowsetColumnDefinition)FromMutable(c)),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 168: {
                    var node = (ScriptDom.CastCall)fragment;
                    return new CastCall(
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        parameter: (ScalarExpression)FromMutable(node.Parameter),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 169: {
                    var node = (ScriptDom.CatalogCollationOption)fragment;
                    return new CatalogCollationOption(
                        catalogCollation: node.CatalogCollation,
                        optionKind: node.OptionKind
                    );
                }
                case 170: {
                    var node = (ScriptDom.CellsPerObjectSpatialIndexOption)fragment;
                    return new CellsPerObjectSpatialIndexOption(
                        @value: (Literal)FromMutable(node.Value)
                    );
                }
                case 171: {
                    var node = (ScriptDom.CertificateCreateLoginSource)fragment;
                    return new CertificateCreateLoginSource(
                        certificate: (Identifier)FromMutable(node.Certificate),
                        credential: (Identifier)FromMutable(node.Credential)
                    );
                }
                case 172: {
                    var node = (ScriptDom.CertificateOption)fragment;
                    return new CertificateOption(
                        kind: node.Kind,
                        @value: (Literal)FromMutable(node.Value)
                    );
                }
                case 173: {
                    var node = (ScriptDom.ChangeRetentionChangeTrackingOptionDetail)fragment;
                    return new ChangeRetentionChangeTrackingOptionDetail(
                        retentionPeriod: (Literal)FromMutable(node.RetentionPeriod),
                        unit: node.Unit
                    );
                }
                case 174: {
                    var node = (ScriptDom.ChangeTableChangesTableReference)fragment;
                    return new ChangeTableChangesTableReference(
                        target: (SchemaObjectName)FromMutable(node.Target),
                        sinceVersion: (ValueExpression)FromMutable(node.SinceVersion),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 175: {
                    var node = (ScriptDom.ChangeTableVersionTableReference)fragment;
                    return new ChangeTableVersionTableReference(
                        target: (SchemaObjectName)FromMutable(node.Target),
                        primaryKeyColumns: node.PrimaryKeyColumns.SelectList(c => (Identifier)FromMutable(c)),
                        primaryKeyValues: node.PrimaryKeyValues.SelectList(c => (ScalarExpression)FromMutable(c)),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 176: {
                    var node = (ScriptDom.ChangeTrackingDatabaseOption)fragment;
                    return new ChangeTrackingDatabaseOption(
                        optionState: node.OptionState,
                        details: node.Details.SelectList(c => (ChangeTrackingOptionDetail)FromMutable(c)),
                        optionKind: node.OptionKind
                    );
                }
                case 177: {
                    var node = (ScriptDom.ChangeTrackingFullTextIndexOption)fragment;
                    return new ChangeTrackingFullTextIndexOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 178: {
                    var node = (ScriptDom.CharacterSetPayloadOption)fragment;
                    return new CharacterSetPayloadOption(
                        isSql: node.IsSql,
                        kind: node.Kind
                    );
                }
                case 179: {
                    var node = (ScriptDom.CheckConstraintDefinition)fragment;
                    return new CheckConstraintDefinition(
                        checkCondition: (BooleanExpression)FromMutable(node.CheckCondition),
                        notForReplication: node.NotForReplication,
                        constraintIdentifier: (Identifier)FromMutable(node.ConstraintIdentifier)
                    );
                }
                case 180: {
                    var node = (ScriptDom.CheckpointStatement)fragment;
                    return new CheckpointStatement(
                        duration: (Literal)FromMutable(node.Duration)
                    );
                }
                case 181: {
                    var node = (ScriptDom.ChildObjectName)fragment;
                    return new ChildObjectName(
                        identifiers: node.Identifiers.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 182: {
                    var node = (ScriptDom.ClassifierEndTimeOption)fragment;
                    return new ClassifierEndTimeOption(
                        time: (WlmTimeLiteral)FromMutable(node.Time),
                        optionType: node.OptionType
                    );
                }
                case 183: {
                    var node = (ScriptDom.ClassifierImportanceOption)fragment;
                    return new ClassifierImportanceOption(
                        importance: node.Importance,
                        optionType: node.OptionType
                    );
                }
                case 184: {
                    var node = (ScriptDom.ClassifierMemberNameOption)fragment;
                    return new ClassifierMemberNameOption(
                        memberName: (StringLiteral)FromMutable(node.MemberName),
                        optionType: node.OptionType
                    );
                }
                case 185: {
                    var node = (ScriptDom.ClassifierStartTimeOption)fragment;
                    return new ClassifierStartTimeOption(
                        time: (WlmTimeLiteral)FromMutable(node.Time),
                        optionType: node.OptionType
                    );
                }
                case 186: {
                    var node = (ScriptDom.ClassifierWlmContextOption)fragment;
                    return new ClassifierWlmContextOption(
                        wlmContext: (StringLiteral)FromMutable(node.WlmContext),
                        optionType: node.OptionType
                    );
                }
                case 187: {
                    var node = (ScriptDom.ClassifierWlmLabelOption)fragment;
                    return new ClassifierWlmLabelOption(
                        wlmLabel: (StringLiteral)FromMutable(node.WlmLabel),
                        optionType: node.OptionType
                    );
                }
                case 188: {
                    var node = (ScriptDom.ClassifierWorkloadGroupOption)fragment;
                    return new ClassifierWorkloadGroupOption(
                        workloadGroupName: (StringLiteral)FromMutable(node.WorkloadGroupName),
                        optionType: node.OptionType
                    );
                }
                case 189: {
                    var node = (ScriptDom.CloseCursorStatement)fragment;
                    return new CloseCursorStatement(
                        cursor: (CursorId)FromMutable(node.Cursor)
                    );
                }
                case 190: {
                    var node = (ScriptDom.CloseMasterKeyStatement)fragment;
                    return new CloseMasterKeyStatement(
                        
                    );
                }
                case 191: {
                    var node = (ScriptDom.CloseSymmetricKeyStatement)fragment;
                    return new CloseSymmetricKeyStatement(
                        name: (Identifier)FromMutable(node.Name),
                        all: node.All
                    );
                }
                case 192: {
                    var node = (ScriptDom.CoalesceExpression)fragment;
                    return new CoalesceExpression(
                        expressions: node.Expressions.SelectList(c => (ScalarExpression)FromMutable(c)),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 193: {
                    var node = (ScriptDom.ColumnDefinition)fragment;
                    return new ColumnDefinition(
                        computedColumnExpression: (ScalarExpression)FromMutable(node.ComputedColumnExpression),
                        isPersisted: node.IsPersisted,
                        defaultConstraint: (DefaultConstraintDefinition)FromMutable(node.DefaultConstraint),
                        identityOptions: (IdentityOptions)FromMutable(node.IdentityOptions),
                        isRowGuidCol: node.IsRowGuidCol,
                        constraints: node.Constraints.SelectList(c => (ConstraintDefinition)FromMutable(c)),
                        storageOptions: (ColumnStorageOptions)FromMutable(node.StorageOptions),
                        index: (IndexDefinition)FromMutable(node.Index),
                        generatedAlways: node.GeneratedAlways,
                        isHidden: node.IsHidden,
                        encryption: (ColumnEncryptionDefinition)FromMutable(node.Encryption),
                        isMasked: node.IsMasked,
                        maskingFunction: (StringLiteral)FromMutable(node.MaskingFunction),
                        columnIdentifier: (Identifier)FromMutable(node.ColumnIdentifier),
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 194: {
                    var node = (ScriptDom.ColumnDefinitionBase)fragment;
                    return new ColumnDefinitionBase(
                        columnIdentifier: (Identifier)FromMutable(node.ColumnIdentifier),
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 195: {
                    var node = (ScriptDom.ColumnEncryptionAlgorithmNameParameter)fragment;
                    return new ColumnEncryptionAlgorithmNameParameter(
                        algorithm: (StringLiteral)FromMutable(node.Algorithm),
                        parameterKind: node.ParameterKind
                    );
                }
                case 196: {
                    var node = (ScriptDom.ColumnEncryptionAlgorithmParameter)fragment;
                    return new ColumnEncryptionAlgorithmParameter(
                        encryptionAlgorithm: (StringLiteral)FromMutable(node.EncryptionAlgorithm),
                        parameterKind: node.ParameterKind
                    );
                }
                case 197: {
                    var node = (ScriptDom.ColumnEncryptionDefinition)fragment;
                    return new ColumnEncryptionDefinition(
                        parameters: node.Parameters.SelectList(c => (ColumnEncryptionDefinitionParameter)FromMutable(c))
                    );
                }
                case 198: {
                    var node = (ScriptDom.ColumnEncryptionKeyNameParameter)fragment;
                    return new ColumnEncryptionKeyNameParameter(
                        name: (Identifier)FromMutable(node.Name),
                        parameterKind: node.ParameterKind
                    );
                }
                case 199: {
                    var node = (ScriptDom.ColumnEncryptionKeyValue)fragment;
                    return new ColumnEncryptionKeyValue(
                        parameters: node.Parameters.SelectList(c => (ColumnEncryptionKeyValueParameter)FromMutable(c))
                    );
                }
                case 200: {
                    var node = (ScriptDom.ColumnEncryptionTypeParameter)fragment;
                    return new ColumnEncryptionTypeParameter(
                        encryptionType: node.EncryptionType,
                        parameterKind: node.ParameterKind
                    );
                }
                case 201: {
                    var node = (ScriptDom.ColumnMasterKeyEnclaveComputationsParameter)fragment;
                    return new ColumnMasterKeyEnclaveComputationsParameter(
                        signature: (BinaryLiteral)FromMutable(node.Signature),
                        parameterKind: node.ParameterKind
                    );
                }
                case 202: {
                    var node = (ScriptDom.ColumnMasterKeyNameParameter)fragment;
                    return new ColumnMasterKeyNameParameter(
                        name: (Identifier)FromMutable(node.Name),
                        parameterKind: node.ParameterKind
                    );
                }
                case 203: {
                    var node = (ScriptDom.ColumnMasterKeyPathParameter)fragment;
                    return new ColumnMasterKeyPathParameter(
                        path: (StringLiteral)FromMutable(node.Path),
                        parameterKind: node.ParameterKind
                    );
                }
                case 204: {
                    var node = (ScriptDom.ColumnMasterKeyStoreProviderNameParameter)fragment;
                    return new ColumnMasterKeyStoreProviderNameParameter(
                        name: (StringLiteral)FromMutable(node.Name),
                        parameterKind: node.ParameterKind
                    );
                }
                case 205: {
                    var node = (ScriptDom.ColumnReferenceExpression)fragment;
                    return new ColumnReferenceExpression(
                        columnType: node.ColumnType,
                        multiPartIdentifier: (MultiPartIdentifier)FromMutable(node.MultiPartIdentifier),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 206: {
                    var node = (ScriptDom.ColumnStorageOptions)fragment;
                    return new ColumnStorageOptions(
                        isFileStream: node.IsFileStream,
                        sparseOption: node.SparseOption
                    );
                }
                case 207: {
                    var node = (ScriptDom.ColumnWithSortOrder)fragment;
                    return new ColumnWithSortOrder(
                        column: (ColumnReferenceExpression)FromMutable(node.Column),
                        sortOrder: node.SortOrder
                    );
                }
                case 208: {
                    var node = (ScriptDom.CommandSecurityElement80)fragment;
                    return new CommandSecurityElement80(
                        all: node.All,
                        commandOptions: node.CommandOptions
                    );
                }
                case 209: {
                    var node = (ScriptDom.CommitTransactionStatement)fragment;
                    return new CommitTransactionStatement(
                        delayedDurabilityOption: node.DelayedDurabilityOption,
                        name: (IdentifierOrValueExpression)FromMutable(node.Name)
                    );
                }
                case 210: {
                    var node = (ScriptDom.CommonTableExpression)fragment;
                    return new CommonTableExpression(
                        expressionName: (Identifier)FromMutable(node.ExpressionName),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        queryExpression: (QueryExpression)FromMutable(node.QueryExpression)
                    );
                }
                case 211: {
                    var node = (ScriptDom.CompositeGroupingSpecification)fragment;
                    return new CompositeGroupingSpecification(
                        items: node.Items.SelectList(c => (GroupingSpecification)FromMutable(c))
                    );
                }
                case 212: {
                    var node = (ScriptDom.CompressionDelayIndexOption)fragment;
                    return new CompressionDelayIndexOption(
                        expression: (ScalarExpression)FromMutable(node.Expression),
                        timeUnit: node.TimeUnit,
                        optionKind: node.OptionKind
                    );
                }
                case 213: {
                    var node = (ScriptDom.CompressionEndpointProtocolOption)fragment;
                    return new CompressionEndpointProtocolOption(
                        isEnabled: node.IsEnabled,
                        kind: node.Kind
                    );
                }
                case 214: {
                    var node = (ScriptDom.CompressionPartitionRange)fragment;
                    return new CompressionPartitionRange(
                        from: (ScalarExpression)FromMutable(node.From),
                        to: (ScalarExpression)FromMutable(node.To)
                    );
                }
                case 215: {
                    var node = (ScriptDom.ComputeClause)fragment;
                    return new ComputeClause(
                        computeFunctions: node.ComputeFunctions.SelectList(c => (ComputeFunction)FromMutable(c)),
                        byExpressions: node.ByExpressions.SelectList(c => (ScalarExpression)FromMutable(c))
                    );
                }
                case 216: {
                    var node = (ScriptDom.ComputeFunction)fragment;
                    return new ComputeFunction(
                        computeFunctionType: node.ComputeFunctionType,
                        expression: (ScalarExpression)FromMutable(node.Expression)
                    );
                }
                case 217: {
                    var node = (ScriptDom.ContainmentDatabaseOption)fragment;
                    return new ContainmentDatabaseOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 218: {
                    var node = (ScriptDom.ContinueStatement)fragment;
                    return new ContinueStatement(
                        
                    );
                }
                case 219: {
                    var node = (ScriptDom.ContractMessage)fragment;
                    return new ContractMessage(
                        name: (Identifier)FromMutable(node.Name),
                        sentBy: node.SentBy
                    );
                }
                case 220: {
                    var node = (ScriptDom.ConvertCall)fragment;
                    return new ConvertCall(
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        parameter: (ScalarExpression)FromMutable(node.Parameter),
                        style: (ScalarExpression)FromMutable(node.Style),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 221: {
                    var node = (ScriptDom.CopyColumnOption)fragment;
                    return new CopyColumnOption(
                        columnName: (Identifier)FromMutable(node.ColumnName),
                        defaultValue: (ScalarExpression)FromMutable(node.DefaultValue),
                        fieldNumber: (IntegerLiteral)FromMutable(node.FieldNumber)
                    );
                }
                case 222: {
                    var node = (ScriptDom.CopyCredentialOption)fragment;
                    return new CopyCredentialOption(
                        identity: (StringLiteral)FromMutable(node.Identity),
                        secret: (StringLiteral)FromMutable(node.Secret)
                    );
                }
                case 223: {
                    var node = (ScriptDom.CopyOption)fragment;
                    return new CopyOption(
                        kind: node.Kind,
                        @value: (CopyStatementOptionBase)FromMutable(node.Value)
                    );
                }
                case 224: {
                    var node = (ScriptDom.CopyStatement)fragment;
                    return new CopyStatement(
                        from: node.From.SelectList(c => (StringLiteral)FromMutable(c)),
                        into: (SchemaObjectName)FromMutable(node.Into),
                        options: node.Options.SelectList(c => (CopyOption)FromMutable(c)),
                        optimizerHints: node.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 225: {
                    var node = (ScriptDom.CreateAggregateStatement)fragment;
                    return new CreateAggregateStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        assemblyName: (AssemblyName)FromMutable(node.AssemblyName),
                        parameters: node.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        returnType: (DataTypeReference)FromMutable(node.ReturnType)
                    );
                }
                case 226: {
                    var node = (ScriptDom.CreateApplicationRoleStatement)fragment;
                    return new CreateApplicationRoleStatement(
                        name: (Identifier)FromMutable(node.Name),
                        applicationRoleOptions: node.ApplicationRoleOptions.SelectList(c => (ApplicationRoleOption)FromMutable(c))
                    );
                }
                case 227: {
                    var node = (ScriptDom.CreateAssemblyStatement)fragment;
                    return new CreateAssemblyStatement(
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name),
                        parameters: node.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        options: node.Options.SelectList(c => (AssemblyOption)FromMutable(c))
                    );
                }
                case 228: {
                    var node = (ScriptDom.CreateAsymmetricKeyStatement)fragment;
                    return new CreateAsymmetricKeyStatement(
                        name: (Identifier)FromMutable(node.Name),
                        keySource: (EncryptionSource)FromMutable(node.KeySource),
                        encryptionAlgorithm: node.EncryptionAlgorithm,
                        password: (Literal)FromMutable(node.Password),
                        owner: (Identifier)FromMutable(node.Owner)
                    );
                }
                case 229: {
                    var node = (ScriptDom.CreateAvailabilityGroupStatement)fragment;
                    return new CreateAvailabilityGroupStatement(
                        name: (Identifier)FromMutable(node.Name),
                        options: node.Options.SelectList(c => (AvailabilityGroupOption)FromMutable(c)),
                        databases: node.Databases.SelectList(c => (Identifier)FromMutable(c)),
                        replicas: node.Replicas.SelectList(c => (AvailabilityReplica)FromMutable(c))
                    );
                }
                case 230: {
                    var node = (ScriptDom.CreateBrokerPriorityStatement)fragment;
                    return new CreateBrokerPriorityStatement(
                        name: (Identifier)FromMutable(node.Name),
                        brokerPriorityParameters: node.BrokerPriorityParameters.SelectList(c => (BrokerPriorityParameter)FromMutable(c))
                    );
                }
                case 231: {
                    var node = (ScriptDom.CreateCertificateStatement)fragment;
                    return new CreateCertificateStatement(
                        certificateSource: (EncryptionSource)FromMutable(node.CertificateSource),
                        certificateOptions: node.CertificateOptions.SelectList(c => (CertificateOption)FromMutable(c)),
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name),
                        activeForBeginDialog: node.ActiveForBeginDialog,
                        privateKeyPath: (Literal)FromMutable(node.PrivateKeyPath),
                        encryptionPassword: (Literal)FromMutable(node.EncryptionPassword),
                        decryptionPassword: (Literal)FromMutable(node.DecryptionPassword)
                    );
                }
                case 232: {
                    var node = (ScriptDom.CreateColumnEncryptionKeyStatement)fragment;
                    return new CreateColumnEncryptionKeyStatement(
                        name: (Identifier)FromMutable(node.Name),
                        columnEncryptionKeyValues: node.ColumnEncryptionKeyValues.SelectList(c => (ColumnEncryptionKeyValue)FromMutable(c))
                    );
                }
                case 233: {
                    var node = (ScriptDom.CreateColumnMasterKeyStatement)fragment;
                    return new CreateColumnMasterKeyStatement(
                        name: (Identifier)FromMutable(node.Name),
                        parameters: node.Parameters.SelectList(c => (ColumnMasterKeyParameter)FromMutable(c))
                    );
                }
                case 234: {
                    var node = (ScriptDom.CreateColumnStoreIndexStatement)fragment;
                    return new CreateColumnStoreIndexStatement(
                        name: (Identifier)FromMutable(node.Name),
                        clustered: node.Clustered,
                        onName: (SchemaObjectName)FromMutable(node.OnName),
                        columns: node.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        filterPredicate: (BooleanExpression)FromMutable(node.FilterPredicate),
                        indexOptions: node.IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                        onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable(node.OnFileGroupOrPartitionScheme),
                        orderedColumns: node.OrderedColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
                    );
                }
                case 235: {
                    var node = (ScriptDom.CreateContractStatement)fragment;
                    return new CreateContractStatement(
                        name: (Identifier)FromMutable(node.Name),
                        messages: node.Messages.SelectList(c => (ContractMessage)FromMutable(c)),
                        owner: (Identifier)FromMutable(node.Owner)
                    );
                }
                case 236: {
                    var node = (ScriptDom.CreateCredentialStatement)fragment;
                    return new CreateCredentialStatement(
                        cryptographicProviderName: (Identifier)FromMutable(node.CryptographicProviderName),
                        name: (Identifier)FromMutable(node.Name),
                        identity: (Literal)FromMutable(node.Identity),
                        secret: (Literal)FromMutable(node.Secret),
                        isDatabaseScoped: node.IsDatabaseScoped
                    );
                }
                case 237: {
                    var node = (ScriptDom.CreateCryptographicProviderStatement)fragment;
                    return new CreateCryptographicProviderStatement(
                        name: (Identifier)FromMutable(node.Name),
                        file: (Literal)FromMutable(node.File)
                    );
                }
                case 238: {
                    var node = (ScriptDom.CreateDatabaseAuditSpecificationStatement)fragment;
                    return new CreateDatabaseAuditSpecificationStatement(
                        auditState: node.AuditState,
                        parts: node.Parts.SelectList(c => (AuditSpecificationPart)FromMutable(c)),
                        specificationName: (Identifier)FromMutable(node.SpecificationName),
                        auditName: (Identifier)FromMutable(node.AuditName)
                    );
                }
                case 239: {
                    var node = (ScriptDom.CreateDatabaseEncryptionKeyStatement)fragment;
                    return new CreateDatabaseEncryptionKeyStatement(
                        encryptor: (CryptoMechanism)FromMutable(node.Encryptor),
                        algorithm: node.Algorithm
                    );
                }
                case 240: {
                    var node = (ScriptDom.CreateDatabaseStatement)fragment;
                    return new CreateDatabaseStatement(
                        databaseName: (Identifier)FromMutable(node.DatabaseName),
                        containment: (ContainmentDatabaseOption)FromMutable(node.Containment),
                        fileGroups: node.FileGroups.SelectList(c => (FileGroupDefinition)FromMutable(c)),
                        logOn: node.LogOn.SelectList(c => (FileDeclaration)FromMutable(c)),
                        options: node.Options.SelectList(c => (DatabaseOption)FromMutable(c)),
                        attachMode: node.AttachMode,
                        databaseSnapshot: (Identifier)FromMutable(node.DatabaseSnapshot),
                        copyOf: (MultiPartIdentifier)FromMutable(node.CopyOf),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 241: {
                    var node = (ScriptDom.CreateDefaultStatement)fragment;
                    return new CreateDefaultStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        expression: (ScalarExpression)FromMutable(node.Expression)
                    );
                }
                case 242: {
                    var node = (ScriptDom.CreateEndpointStatement)fragment;
                    return new CreateEndpointStatement(
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name),
                        state: node.State,
                        affinity: (EndpointAffinity)FromMutable(node.Affinity),
                        protocol: node.Protocol,
                        protocolOptions: node.ProtocolOptions.SelectList(c => (EndpointProtocolOption)FromMutable(c)),
                        endpointType: node.EndpointType,
                        payloadOptions: node.PayloadOptions.SelectList(c => (PayloadOption)FromMutable(c))
                    );
                }
                case 243: {
                    var node = (ScriptDom.CreateEventNotificationStatement)fragment;
                    return new CreateEventNotificationStatement(
                        name: (Identifier)FromMutable(node.Name),
                        scope: (EventNotificationObjectScope)FromMutable(node.Scope),
                        withFanIn: node.WithFanIn,
                        eventTypeGroups: node.EventTypeGroups.SelectList(c => (EventTypeGroupContainer)FromMutable(c)),
                        brokerService: (Literal)FromMutable(node.BrokerService),
                        brokerInstanceSpecifier: (Literal)FromMutable(node.BrokerInstanceSpecifier)
                    );
                }
                case 244: {
                    var node = (ScriptDom.CreateEventSessionStatement)fragment;
                    return new CreateEventSessionStatement(
                        name: (Identifier)FromMutable(node.Name),
                        sessionScope: node.SessionScope,
                        eventDeclarations: node.EventDeclarations.SelectList(c => (EventDeclaration)FromMutable(c)),
                        targetDeclarations: node.TargetDeclarations.SelectList(c => (TargetDeclaration)FromMutable(c)),
                        sessionOptions: node.SessionOptions.SelectList(c => (SessionOption)FromMutable(c))
                    );
                }
                case 245: {
                    var node = (ScriptDom.CreateExternalDataSourceStatement)fragment;
                    return new CreateExternalDataSourceStatement(
                        name: (Identifier)FromMutable(node.Name),
                        dataSourceType: node.DataSourceType,
                        location: (Literal)FromMutable(node.Location),
                        pushdownOption: node.PushdownOption,
                        externalDataSourceOptions: node.ExternalDataSourceOptions.SelectList(c => (ExternalDataSourceOption)FromMutable(c))
                    );
                }
                case 246: {
                    var node = (ScriptDom.CreateExternalFileFormatStatement)fragment;
                    return new CreateExternalFileFormatStatement(
                        name: (Identifier)FromMutable(node.Name),
                        formatType: node.FormatType,
                        externalFileFormatOptions: node.ExternalFileFormatOptions.SelectList(c => (ExternalFileFormatOption)FromMutable(c))
                    );
                }
                case 247: {
                    var node = (ScriptDom.CreateExternalLanguageStatement)fragment;
                    return new CreateExternalLanguageStatement(
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name),
                        externalLanguageFiles: node.ExternalLanguageFiles.SelectList(c => (ExternalLanguageFileOption)FromMutable(c))
                    );
                }
                case 248: {
                    var node = (ScriptDom.CreateExternalLibraryStatement)fragment;
                    return new CreateExternalLibraryStatement(
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name),
                        language: (StringLiteral)FromMutable(node.Language),
                        externalLibraryFiles: node.ExternalLibraryFiles.SelectList(c => (ExternalLibraryFileOption)FromMutable(c))
                    );
                }
                case 249: {
                    var node = (ScriptDom.CreateExternalResourcePoolStatement)fragment;
                    return new CreateExternalResourcePoolStatement(
                        name: (Identifier)FromMutable(node.Name),
                        externalResourcePoolParameters: node.ExternalResourcePoolParameters.SelectList(c => (ExternalResourcePoolParameter)FromMutable(c))
                    );
                }
                case 250: {
                    var node = (ScriptDom.CreateExternalStreamingJobStatement)fragment;
                    return new CreateExternalStreamingJobStatement(
                        name: (StringLiteral)FromMutable(node.Name),
                        statement: (StringLiteral)FromMutable(node.Statement)
                    );
                }
                case 251: {
                    var node = (ScriptDom.CreateExternalStreamStatement)fragment;
                    return new CreateExternalStreamStatement(
                        name: (Identifier)FromMutable(node.Name),
                        location: (Literal)FromMutable(node.Location),
                        inputOptions: (Literal)FromMutable(node.InputOptions),
                        outputOptions: (Literal)FromMutable(node.OutputOptions),
                        externalStreamOptions: node.ExternalStreamOptions.SelectList(c => (ExternalStreamOption)FromMutable(c))
                    );
                }
                case 252: {
                    var node = (ScriptDom.CreateExternalTableStatement)fragment;
                    return new CreateExternalTableStatement(
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName),
                        columnDefinitions: node.ColumnDefinitions.SelectList(c => (ExternalTableColumnDefinition)FromMutable(c)),
                        dataSource: (Identifier)FromMutable(node.DataSource),
                        externalTableOptions: node.ExternalTableOptions.SelectList(c => (ExternalTableOption)FromMutable(c)),
                        selectStatement: (SelectStatement)FromMutable(node.SelectStatement)
                    );
                }
                case 253: {
                    var node = (ScriptDom.CreateFederationStatement)fragment;
                    return new CreateFederationStatement(
                        name: (Identifier)FromMutable(node.Name),
                        distributionName: (Identifier)FromMutable(node.DistributionName),
                        dataType: (DataTypeReference)FromMutable(node.DataType)
                    );
                }
                case 254: {
                    var node = (ScriptDom.CreateFullTextCatalogStatement)fragment;
                    return new CreateFullTextCatalogStatement(
                        fileGroup: (Identifier)FromMutable(node.FileGroup),
                        path: (Literal)FromMutable(node.Path),
                        isDefault: node.IsDefault,
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name),
                        options: node.Options.SelectList(c => (FullTextCatalogOption)FromMutable(c))
                    );
                }
                case 255: {
                    var node = (ScriptDom.CreateFullTextIndexStatement)fragment;
                    return new CreateFullTextIndexStatement(
                        onName: (SchemaObjectName)FromMutable(node.OnName),
                        fullTextIndexColumns: node.FullTextIndexColumns.SelectList(c => (FullTextIndexColumn)FromMutable(c)),
                        keyIndexName: (Identifier)FromMutable(node.KeyIndexName),
                        catalogAndFileGroup: (FullTextCatalogAndFileGroup)FromMutable(node.CatalogAndFileGroup),
                        options: node.Options.SelectList(c => (FullTextIndexOption)FromMutable(c))
                    );
                }
                case 256: {
                    var node = (ScriptDom.CreateFullTextStopListStatement)fragment;
                    return new CreateFullTextStopListStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isSystemStopList: node.IsSystemStopList,
                        databaseName: (Identifier)FromMutable(node.DatabaseName),
                        sourceStopListName: (Identifier)FromMutable(node.SourceStopListName),
                        owner: (Identifier)FromMutable(node.Owner)
                    );
                }
                case 257: {
                    var node = (ScriptDom.CreateFunctionStatement)fragment;
                    return new CreateFunctionStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        returnType: (FunctionReturnType)FromMutable(node.ReturnType),
                        options: node.Options.SelectList(c => (FunctionOption)FromMutable(c)),
                        orderHint: (OrderBulkInsertOption)FromMutable(node.OrderHint),
                        parameters: node.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        statementList: (StatementList)FromMutable(node.StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable(node.MethodSpecifier)
                    );
                }
                case 258: {
                    var node = (ScriptDom.CreateIndexStatement)fragment;
                    return new CreateIndexStatement(
                        translated80SyntaxTo90: node.Translated80SyntaxTo90,
                        unique: node.Unique,
                        clustered: node.Clustered,
                        columns: node.Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                        includeColumns: node.IncludeColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable(node.OnFileGroupOrPartitionScheme),
                        filterPredicate: (BooleanExpression)FromMutable(node.FilterPredicate),
                        fileStreamOn: (IdentifierOrValueExpression)FromMutable(node.FileStreamOn),
                        name: (Identifier)FromMutable(node.Name),
                        onName: (SchemaObjectName)FromMutable(node.OnName),
                        indexOptions: node.IndexOptions.SelectList(c => (IndexOption)FromMutable(c))
                    );
                }
                case 259: {
                    var node = (ScriptDom.CreateLoginStatement)fragment;
                    return new CreateLoginStatement(
                        name: (Identifier)FromMutable(node.Name),
                        source: (CreateLoginSource)FromMutable(node.Source)
                    );
                }
                case 260: {
                    var node = (ScriptDom.CreateMasterKeyStatement)fragment;
                    return new CreateMasterKeyStatement(
                        password: (Literal)FromMutable(node.Password)
                    );
                }
                case 261: {
                    var node = (ScriptDom.CreateMessageTypeStatement)fragment;
                    return new CreateMessageTypeStatement(
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name),
                        validationMethod: node.ValidationMethod,
                        xmlSchemaCollectionName: (SchemaObjectName)FromMutable(node.XmlSchemaCollectionName)
                    );
                }
                case 262: {
                    var node = (ScriptDom.CreateOrAlterFunctionStatement)fragment;
                    return new CreateOrAlterFunctionStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        returnType: (FunctionReturnType)FromMutable(node.ReturnType),
                        options: node.Options.SelectList(c => (FunctionOption)FromMutable(c)),
                        orderHint: (OrderBulkInsertOption)FromMutable(node.OrderHint),
                        parameters: node.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        statementList: (StatementList)FromMutable(node.StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable(node.MethodSpecifier)
                    );
                }
                case 263: {
                    var node = (ScriptDom.CreateOrAlterProcedureStatement)fragment;
                    return new CreateOrAlterProcedureStatement(
                        procedureReference: (ProcedureReference)FromMutable(node.ProcedureReference),
                        isForReplication: node.IsForReplication,
                        options: node.Options.SelectList(c => (ProcedureOption)FromMutable(c)),
                        parameters: node.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        statementList: (StatementList)FromMutable(node.StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable(node.MethodSpecifier)
                    );
                }
                case 264: {
                    var node = (ScriptDom.CreateOrAlterTriggerStatement)fragment;
                    return new CreateOrAlterTriggerStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        triggerObject: (TriggerObject)FromMutable(node.TriggerObject),
                        options: node.Options.SelectList(c => (TriggerOption)FromMutable(c)),
                        triggerType: node.TriggerType,
                        triggerActions: node.TriggerActions.SelectList(c => (TriggerAction)FromMutable(c)),
                        withAppend: node.WithAppend,
                        isNotForReplication: node.IsNotForReplication,
                        statementList: (StatementList)FromMutable(node.StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable(node.MethodSpecifier)
                    );
                }
                case 265: {
                    var node = (ScriptDom.CreateOrAlterViewStatement)fragment;
                    return new CreateOrAlterViewStatement(
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        viewOptions: node.ViewOptions.SelectList(c => (ViewOption)FromMutable(c)),
                        selectStatement: (SelectStatement)FromMutable(node.SelectStatement),
                        withCheckOption: node.WithCheckOption,
                        isMaterialized: node.IsMaterialized
                    );
                }
                case 266: {
                    var node = (ScriptDom.CreatePartitionFunctionStatement)fragment;
                    return new CreatePartitionFunctionStatement(
                        name: (Identifier)FromMutable(node.Name),
                        parameterType: (PartitionParameterType)FromMutable(node.ParameterType),
                        range: node.Range,
                        boundaryValues: node.BoundaryValues.SelectList(c => (ScalarExpression)FromMutable(c))
                    );
                }
                case 267: {
                    var node = (ScriptDom.CreatePartitionSchemeStatement)fragment;
                    return new CreatePartitionSchemeStatement(
                        name: (Identifier)FromMutable(node.Name),
                        partitionFunction: (Identifier)FromMutable(node.PartitionFunction),
                        isAll: node.IsAll,
                        fileGroups: node.FileGroups.SelectList(c => (IdentifierOrValueExpression)FromMutable(c))
                    );
                }
                case 268: {
                    var node = (ScriptDom.CreateProcedureStatement)fragment;
                    return new CreateProcedureStatement(
                        procedureReference: (ProcedureReference)FromMutable(node.ProcedureReference),
                        isForReplication: node.IsForReplication,
                        options: node.Options.SelectList(c => (ProcedureOption)FromMutable(c)),
                        parameters: node.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                        statementList: (StatementList)FromMutable(node.StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable(node.MethodSpecifier)
                    );
                }
                case 269: {
                    var node = (ScriptDom.CreateQueueStatement)fragment;
                    return new CreateQueueStatement(
                        onFileGroup: (IdentifierOrValueExpression)FromMutable(node.OnFileGroup),
                        name: (SchemaObjectName)FromMutable(node.Name),
                        queueOptions: node.QueueOptions.SelectList(c => (QueueOption)FromMutable(c))
                    );
                }
                case 270: {
                    var node = (ScriptDom.CreateRemoteServiceBindingStatement)fragment;
                    return new CreateRemoteServiceBindingStatement(
                        service: (Literal)FromMutable(node.Service),
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name),
                        options: node.Options.SelectList(c => (RemoteServiceBindingOption)FromMutable(c))
                    );
                }
                case 271: {
                    var node = (ScriptDom.CreateResourcePoolStatement)fragment;
                    return new CreateResourcePoolStatement(
                        name: (Identifier)FromMutable(node.Name),
                        resourcePoolParameters: node.ResourcePoolParameters.SelectList(c => (ResourcePoolParameter)FromMutable(c))
                    );
                }
                case 272: {
                    var node = (ScriptDom.CreateRoleStatement)fragment;
                    return new CreateRoleStatement(
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name)
                    );
                }
                case 273: {
                    var node = (ScriptDom.CreateRouteStatement)fragment;
                    return new CreateRouteStatement(
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name),
                        routeOptions: node.RouteOptions.SelectList(c => (RouteOption)FromMutable(c))
                    );
                }
                case 274: {
                    var node = (ScriptDom.CreateRuleStatement)fragment;
                    return new CreateRuleStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        expression: (BooleanExpression)FromMutable(node.Expression)
                    );
                }
                case 275: {
                    var node = (ScriptDom.CreateSchemaStatement)fragment;
                    return new CreateSchemaStatement(
                        name: (Identifier)FromMutable(node.Name),
                        statementList: (StatementList)FromMutable(node.StatementList),
                        owner: (Identifier)FromMutable(node.Owner)
                    );
                }
                case 276: {
                    var node = (ScriptDom.CreateSearchPropertyListStatement)fragment;
                    return new CreateSearchPropertyListStatement(
                        name: (Identifier)FromMutable(node.Name),
                        sourceSearchPropertyList: (MultiPartIdentifier)FromMutable(node.SourceSearchPropertyList),
                        owner: (Identifier)FromMutable(node.Owner)
                    );
                }
                case 277: {
                    var node = (ScriptDom.CreateSecurityPolicyStatement)fragment;
                    return new CreateSecurityPolicyStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        notForReplication: node.NotForReplication,
                        securityPolicyOptions: node.SecurityPolicyOptions.SelectList(c => (SecurityPolicyOption)FromMutable(c)),
                        securityPredicateActions: node.SecurityPredicateActions.SelectList(c => (SecurityPredicateAction)FromMutable(c)),
                        actionType: node.ActionType
                    );
                }
                case 278: {
                    var node = (ScriptDom.CreateSelectiveXmlIndexStatement)fragment;
                    return new CreateSelectiveXmlIndexStatement(
                        isSecondary: node.IsSecondary,
                        xmlColumn: (Identifier)FromMutable(node.XmlColumn),
                        promotedPaths: node.PromotedPaths.SelectList(c => (SelectiveXmlIndexPromotedPath)FromMutable(c)),
                        xmlNamespaces: (XmlNamespaces)FromMutable(node.XmlNamespaces),
                        usingXmlIndexName: (Identifier)FromMutable(node.UsingXmlIndexName),
                        pathName: (Identifier)FromMutable(node.PathName),
                        name: (Identifier)FromMutable(node.Name),
                        onName: (SchemaObjectName)FromMutable(node.OnName),
                        indexOptions: node.IndexOptions.SelectList(c => (IndexOption)FromMutable(c))
                    );
                }
                case 279: {
                    var node = (ScriptDom.CreateSequenceStatement)fragment;
                    return new CreateSequenceStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        sequenceOptions: node.SequenceOptions.SelectList(c => (SequenceOption)FromMutable(c))
                    );
                }
                case 280: {
                    var node = (ScriptDom.CreateServerAuditSpecificationStatement)fragment;
                    return new CreateServerAuditSpecificationStatement(
                        auditState: node.AuditState,
                        parts: node.Parts.SelectList(c => (AuditSpecificationPart)FromMutable(c)),
                        specificationName: (Identifier)FromMutable(node.SpecificationName),
                        auditName: (Identifier)FromMutable(node.AuditName)
                    );
                }
                case 281: {
                    var node = (ScriptDom.CreateServerAuditStatement)fragment;
                    return new CreateServerAuditStatement(
                        auditName: (Identifier)FromMutable(node.AuditName),
                        auditTarget: (AuditTarget)FromMutable(node.AuditTarget),
                        options: node.Options.SelectList(c => (AuditOption)FromMutable(c)),
                        predicateExpression: (BooleanExpression)FromMutable(node.PredicateExpression)
                    );
                }
                case 282: {
                    var node = (ScriptDom.CreateServerRoleStatement)fragment;
                    return new CreateServerRoleStatement(
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name)
                    );
                }
                case 283: {
                    var node = (ScriptDom.CreateServiceStatement)fragment;
                    return new CreateServiceStatement(
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name),
                        queueName: (SchemaObjectName)FromMutable(node.QueueName),
                        serviceContracts: node.ServiceContracts.SelectList(c => (ServiceContract)FromMutable(c))
                    );
                }
                case 284: {
                    var node = (ScriptDom.CreateSpatialIndexStatement)fragment;
                    return new CreateSpatialIndexStatement(
                        name: (Identifier)FromMutable(node.Name),
                        @object: (SchemaObjectName)FromMutable(node.Object),
                        spatialColumnName: (Identifier)FromMutable(node.SpatialColumnName),
                        spatialIndexingScheme: node.SpatialIndexingScheme,
                        spatialIndexOptions: node.SpatialIndexOptions.SelectList(c => (SpatialIndexOption)FromMutable(c)),
                        onFileGroup: (IdentifierOrValueExpression)FromMutable(node.OnFileGroup)
                    );
                }
                case 285: {
                    var node = (ScriptDom.CreateStatisticsStatement)fragment;
                    return new CreateStatisticsStatement(
                        name: (Identifier)FromMutable(node.Name),
                        onName: (SchemaObjectName)FromMutable(node.OnName),
                        columns: node.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        statisticsOptions: node.StatisticsOptions.SelectList(c => (StatisticsOption)FromMutable(c)),
                        filterPredicate: (BooleanExpression)FromMutable(node.FilterPredicate)
                    );
                }
                case 286: {
                    var node = (ScriptDom.CreateSymmetricKeyStatement)fragment;
                    return new CreateSymmetricKeyStatement(
                        keyOptions: node.KeyOptions.SelectList(c => (KeyOption)FromMutable(c)),
                        provider: (Identifier)FromMutable(node.Provider),
                        owner: (Identifier)FromMutable(node.Owner),
                        name: (Identifier)FromMutable(node.Name),
                        encryptingMechanisms: node.EncryptingMechanisms.SelectList(c => (CryptoMechanism)FromMutable(c))
                    );
                }
                case 287: {
                    var node = (ScriptDom.CreateSynonymStatement)fragment;
                    return new CreateSynonymStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        forName: (SchemaObjectName)FromMutable(node.ForName)
                    );
                }
                case 288: {
                    var node = (ScriptDom.CreateTableStatement)fragment;
                    return new CreateTableStatement(
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName),
                        asEdge: node.AsEdge,
                        asFileTable: node.AsFileTable,
                        asNode: node.AsNode,
                        definition: (TableDefinition)FromMutable(node.Definition),
                        onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable(node.OnFileGroupOrPartitionScheme),
                        federationScheme: (FederationScheme)FromMutable(node.FederationScheme),
                        textImageOn: (IdentifierOrValueExpression)FromMutable(node.TextImageOn),
                        options: node.Options.SelectList(c => (TableOption)FromMutable(c)),
                        selectStatement: (SelectStatement)FromMutable(node.SelectStatement),
                        ctasColumns: node.CtasColumns.SelectList(c => (Identifier)FromMutable(c)),
                        fileStreamOn: (IdentifierOrValueExpression)FromMutable(node.FileStreamOn)
                    );
                }
                case 289: {
                    var node = (ScriptDom.CreateTriggerStatement)fragment;
                    return new CreateTriggerStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        triggerObject: (TriggerObject)FromMutable(node.TriggerObject),
                        options: node.Options.SelectList(c => (TriggerOption)FromMutable(c)),
                        triggerType: node.TriggerType,
                        triggerActions: node.TriggerActions.SelectList(c => (TriggerAction)FromMutable(c)),
                        withAppend: node.WithAppend,
                        isNotForReplication: node.IsNotForReplication,
                        statementList: (StatementList)FromMutable(node.StatementList),
                        methodSpecifier: (MethodSpecifier)FromMutable(node.MethodSpecifier)
                    );
                }
                case 290: {
                    var node = (ScriptDom.CreateTypeTableStatement)fragment;
                    return new CreateTypeTableStatement(
                        definition: (TableDefinition)FromMutable(node.Definition),
                        options: node.Options.SelectList(c => (TableOption)FromMutable(c)),
                        name: (SchemaObjectName)FromMutable(node.Name)
                    );
                }
                case 291: {
                    var node = (ScriptDom.CreateTypeUddtStatement)fragment;
                    return new CreateTypeUddtStatement(
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        nullableConstraint: (NullableConstraintDefinition)FromMutable(node.NullableConstraint),
                        name: (SchemaObjectName)FromMutable(node.Name)
                    );
                }
                case 292: {
                    var node = (ScriptDom.CreateTypeUdtStatement)fragment;
                    return new CreateTypeUdtStatement(
                        assemblyName: (AssemblyName)FromMutable(node.AssemblyName),
                        name: (SchemaObjectName)FromMutable(node.Name)
                    );
                }
                case 293: {
                    var node = (ScriptDom.CreateUserStatement)fragment;
                    return new CreateUserStatement(
                        userLoginOption: (UserLoginOption)FromMutable(node.UserLoginOption),
                        name: (Identifier)FromMutable(node.Name),
                        userOptions: node.UserOptions.SelectList(c => (PrincipalOption)FromMutable(c))
                    );
                }
                case 294: {
                    var node = (ScriptDom.CreateViewStatement)fragment;
                    return new CreateViewStatement(
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        viewOptions: node.ViewOptions.SelectList(c => (ViewOption)FromMutable(c)),
                        selectStatement: (SelectStatement)FromMutable(node.SelectStatement),
                        withCheckOption: node.WithCheckOption,
                        isMaterialized: node.IsMaterialized
                    );
                }
                case 295: {
                    var node = (ScriptDom.CreateWorkloadClassifierStatement)fragment;
                    return new CreateWorkloadClassifierStatement(
                        classifierName: (Identifier)FromMutable(node.ClassifierName),
                        options: node.Options.SelectList(c => (WorkloadClassifierOption)FromMutable(c))
                    );
                }
                case 296: {
                    var node = (ScriptDom.CreateWorkloadGroupStatement)fragment;
                    return new CreateWorkloadGroupStatement(
                        name: (Identifier)FromMutable(node.Name),
                        workloadGroupParameters: node.WorkloadGroupParameters.SelectList(c => (WorkloadGroupParameter)FromMutable(c)),
                        poolName: (Identifier)FromMutable(node.PoolName),
                        externalPoolName: (Identifier)FromMutable(node.ExternalPoolName)
                    );
                }
                case 297: {
                    var node = (ScriptDom.CreateXmlIndexStatement)fragment;
                    return new CreateXmlIndexStatement(
                        primary: node.Primary,
                        xmlColumn: (Identifier)FromMutable(node.XmlColumn),
                        secondaryXmlIndexName: (Identifier)FromMutable(node.SecondaryXmlIndexName),
                        secondaryXmlIndexType: node.SecondaryXmlIndexType,
                        onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable(node.OnFileGroupOrPartitionScheme),
                        name: (Identifier)FromMutable(node.Name),
                        onName: (SchemaObjectName)FromMutable(node.OnName),
                        indexOptions: node.IndexOptions.SelectList(c => (IndexOption)FromMutable(c))
                    );
                }
                case 298: {
                    var node = (ScriptDom.CreateXmlSchemaCollectionStatement)fragment;
                    return new CreateXmlSchemaCollectionStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        expression: (ScalarExpression)FromMutable(node.Expression)
                    );
                }
                case 299: {
                    var node = (ScriptDom.CreationDispositionKeyOption)fragment;
                    return new CreationDispositionKeyOption(
                        isCreateNew: node.IsCreateNew,
                        optionKind: node.OptionKind
                    );
                }
                case 300: {
                    var node = (ScriptDom.CryptoMechanism)fragment;
                    return new CryptoMechanism(
                        cryptoMechanismType: node.CryptoMechanismType,
                        identifier: (Identifier)FromMutable(node.Identifier),
                        passwordOrSignature: (Literal)FromMutable(node.PasswordOrSignature)
                    );
                }
                case 301: {
                    var node = (ScriptDom.CubeGroupingSpecification)fragment;
                    return new CubeGroupingSpecification(
                        arguments: node.Arguments.SelectList(c => (GroupingSpecification)FromMutable(c))
                    );
                }
                case 302: {
                    var node = (ScriptDom.CursorDefaultDatabaseOption)fragment;
                    return new CursorDefaultDatabaseOption(
                        isLocal: node.IsLocal,
                        optionKind: node.OptionKind
                    );
                }
                case 303: {
                    var node = (ScriptDom.CursorDefinition)fragment;
                    return new CursorDefinition(
                        options: node.Options.SelectList(c => (CursorOption)FromMutable(c)),
                        select: (SelectStatement)FromMutable(node.Select)
                    );
                }
                case 304: {
                    var node = (ScriptDom.CursorId)fragment;
                    return new CursorId(
                        isGlobal: node.IsGlobal,
                        name: (IdentifierOrValueExpression)FromMutable(node.Name)
                    );
                }
                case 305: {
                    var node = (ScriptDom.CursorOption)fragment;
                    return new CursorOption(
                        optionKind: node.OptionKind
                    );
                }
                case 306: {
                    var node = (ScriptDom.DatabaseAuditAction)fragment;
                    return new DatabaseAuditAction(
                        actionKind: node.ActionKind
                    );
                }
                case 307: {
                    var node = (ScriptDom.DatabaseConfigurationClearOption)fragment;
                    return new DatabaseConfigurationClearOption(
                        optionKind: node.OptionKind,
                        planHandle: (BinaryLiteral)FromMutable(node.PlanHandle)
                    );
                }
                case 308: {
                    var node = (ScriptDom.DatabaseConfigurationSetOption)fragment;
                    return new DatabaseConfigurationSetOption(
                        optionKind: node.OptionKind,
                        genericOptionKind: (Identifier)FromMutable(node.GenericOptionKind)
                    );
                }
                case 309: {
                    var node = (ScriptDom.DatabaseOption)fragment;
                    return new DatabaseOption(
                        optionKind: node.OptionKind
                    );
                }
                case 310: {
                    var node = (ScriptDom.DataCompressionOption)fragment;
                    return new DataCompressionOption(
                        compressionLevel: node.CompressionLevel,
                        partitionRanges: node.PartitionRanges.SelectList(c => (CompressionPartitionRange)FromMutable(c)),
                        optionKind: node.OptionKind
                    );
                }
                case 311: {
                    var node = (ScriptDom.DataModificationTableReference)fragment;
                    return new DataModificationTableReference(
                        dataModificationSpecification: (DataModificationSpecification)FromMutable(node.DataModificationSpecification),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 312: {
                    var node = (ScriptDom.DataRetentionTableOption)fragment;
                    return new DataRetentionTableOption(
                        optionState: node.OptionState,
                        filterColumn: (Identifier)FromMutable(node.FilterColumn),
                        retentionPeriod: (RetentionPeriodDefinition)FromMutable(node.RetentionPeriod),
                        optionKind: node.OptionKind
                    );
                }
                case 313: {
                    var node = (ScriptDom.DataTypeSequenceOption)fragment;
                    return new DataTypeSequenceOption(
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        optionKind: node.OptionKind,
                        noValue: node.NoValue
                    );
                }
                case 314: {
                    var node = (ScriptDom.DbccNamedLiteral)fragment;
                    return new DbccNamedLiteral(
                        name: node.Name,
                        @value: (ScalarExpression)FromMutable(node.Value)
                    );
                }
                case 315: {
                    var node = (ScriptDom.DbccOption)fragment;
                    return new DbccOption(
                        optionKind: node.OptionKind
                    );
                }
                case 316: {
                    var node = (ScriptDom.DbccStatement)fragment;
                    return new DbccStatement(
                        dllName: node.DllName,
                        command: node.Command,
                        parenthesisRequired: node.ParenthesisRequired,
                        literals: node.Literals.SelectList(c => (DbccNamedLiteral)FromMutable(c)),
                        options: node.Options.SelectList(c => (DbccOption)FromMutable(c)),
                        optionsUseJoin: node.OptionsUseJoin
                    );
                }
                case 317: {
                    var node = (ScriptDom.DeallocateCursorStatement)fragment;
                    return new DeallocateCursorStatement(
                        cursor: (CursorId)FromMutable(node.Cursor)
                    );
                }
                case 318: {
                    var node = (ScriptDom.DeclareCursorStatement)fragment;
                    return new DeclareCursorStatement(
                        name: (Identifier)FromMutable(node.Name),
                        cursorDefinition: (CursorDefinition)FromMutable(node.CursorDefinition)
                    );
                }
                case 319: {
                    var node = (ScriptDom.DeclareTableVariableBody)fragment;
                    return new DeclareTableVariableBody(
                        variableName: (Identifier)FromMutable(node.VariableName),
                        asDefined: node.AsDefined,
                        definition: (TableDefinition)FromMutable(node.Definition)
                    );
                }
                case 320: {
                    var node = (ScriptDom.DeclareTableVariableStatement)fragment;
                    return new DeclareTableVariableStatement(
                        body: (DeclareTableVariableBody)FromMutable(node.Body)
                    );
                }
                case 321: {
                    var node = (ScriptDom.DeclareVariableElement)fragment;
                    return new DeclareVariableElement(
                        variableName: (Identifier)FromMutable(node.VariableName),
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        nullable: (NullableConstraintDefinition)FromMutable(node.Nullable),
                        @value: (ScalarExpression)FromMutable(node.Value)
                    );
                }
                case 322: {
                    var node = (ScriptDom.DeclareVariableStatement)fragment;
                    return new DeclareVariableStatement(
                        declarations: node.Declarations.SelectList(c => (DeclareVariableElement)FromMutable(c))
                    );
                }
                case 323: {
                    var node = (ScriptDom.DefaultConstraintDefinition)fragment;
                    return new DefaultConstraintDefinition(
                        expression: (ScalarExpression)FromMutable(node.Expression),
                        withValues: node.WithValues,
                        column: (Identifier)FromMutable(node.Column),
                        constraintIdentifier: (Identifier)FromMutable(node.ConstraintIdentifier)
                    );
                }
                case 324: {
                    var node = (ScriptDom.DefaultLiteral)fragment;
                    return new DefaultLiteral(
                        @value: node.Value,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 325: {
                    var node = (ScriptDom.DelayedDurabilityDatabaseOption)fragment;
                    return new DelayedDurabilityDatabaseOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 326: {
                    var node = (ScriptDom.DeleteMergeAction)fragment;
                    return new DeleteMergeAction(
                        
                    );
                }
                case 327: {
                    var node = (ScriptDom.DeleteSpecification)fragment;
                    return new DeleteSpecification(
                        fromClause: (FromClause)FromMutable(node.FromClause),
                        whereClause: (WhereClause)FromMutable(node.WhereClause),
                        target: (TableReference)FromMutable(node.Target),
                        topRowFilter: (TopRowFilter)FromMutable(node.TopRowFilter),
                        outputIntoClause: (OutputIntoClause)FromMutable(node.OutputIntoClause),
                        outputClause: (OutputClause)FromMutable(node.OutputClause)
                    );
                }
                case 328: {
                    var node = (ScriptDom.DeleteStatement)fragment;
                    return new DeleteStatement(
                        deleteSpecification: (DeleteSpecification)FromMutable(node.DeleteSpecification),
                        withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable(node.WithCtesAndXmlNamespaces),
                        optimizerHints: node.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 329: {
                    var node = (ScriptDom.DenyStatement)fragment;
                    return new DenyStatement(
                        cascadeOption: node.CascadeOption,
                        permissions: node.Permissions.SelectList(c => (Permission)FromMutable(c)),
                        securityTargetObject: (SecurityTargetObject)FromMutable(node.SecurityTargetObject),
                        principals: node.Principals.SelectList(c => (SecurityPrincipal)FromMutable(c)),
                        asClause: (Identifier)FromMutable(node.AsClause)
                    );
                }
                case 330: {
                    var node = (ScriptDom.DenyStatement80)fragment;
                    return new DenyStatement80(
                        cascadeOption: node.CascadeOption,
                        securityElement80: (SecurityElement80)FromMutable(node.SecurityElement80),
                        securityUserClause80: (SecurityUserClause80)FromMutable(node.SecurityUserClause80)
                    );
                }
                case 331: {
                    var node = (ScriptDom.DeviceInfo)fragment;
                    return new DeviceInfo(
                        logicalDevice: (IdentifierOrValueExpression)FromMutable(node.LogicalDevice),
                        physicalDevice: (ValueExpression)FromMutable(node.PhysicalDevice),
                        deviceType: node.DeviceType
                    );
                }
                case 332: {
                    var node = (ScriptDom.DiskStatement)fragment;
                    return new DiskStatement(
                        diskStatementType: node.DiskStatementType,
                        options: node.Options.SelectList(c => (DiskStatementOption)FromMutable(c))
                    );
                }
                case 333: {
                    var node = (ScriptDom.DiskStatementOption)fragment;
                    return new DiskStatementOption(
                        optionKind: node.OptionKind,
                        @value: (IdentifierOrValueExpression)FromMutable(node.Value)
                    );
                }
                case 334: {
                    var node = (ScriptDom.DistinctPredicate)fragment;
                    return new DistinctPredicate(
                        firstExpression: (ScalarExpression)FromMutable(node.FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable(node.SecondExpression),
                        isNot: node.IsNot
                    );
                }
                case 335: {
                    var node = (ScriptDom.DropAggregateStatement)fragment;
                    return new DropAggregateStatement(
                        objects: node.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 336: {
                    var node = (ScriptDom.DropAlterFullTextIndexAction)fragment;
                    return new DropAlterFullTextIndexAction(
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        withNoPopulation: node.WithNoPopulation
                    );
                }
                case 337: {
                    var node = (ScriptDom.DropApplicationRoleStatement)fragment;
                    return new DropApplicationRoleStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 338: {
                    var node = (ScriptDom.DropAssemblyStatement)fragment;
                    return new DropAssemblyStatement(
                        withNoDependents: node.WithNoDependents,
                        objects: node.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 339: {
                    var node = (ScriptDom.DropAsymmetricKeyStatement)fragment;
                    return new DropAsymmetricKeyStatement(
                        removeProviderKey: node.RemoveProviderKey,
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 340: {
                    var node = (ScriptDom.DropAvailabilityGroupStatement)fragment;
                    return new DropAvailabilityGroupStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 341: {
                    var node = (ScriptDom.DropBrokerPriorityStatement)fragment;
                    return new DropBrokerPriorityStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 342: {
                    var node = (ScriptDom.DropCertificateStatement)fragment;
                    return new DropCertificateStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 343: {
                    var node = (ScriptDom.DropClusteredConstraintMoveOption)fragment;
                    return new DropClusteredConstraintMoveOption(
                        optionValue: (FileGroupOrPartitionScheme)FromMutable(node.OptionValue),
                        optionKind: node.OptionKind
                    );
                }
                case 344: {
                    var node = (ScriptDom.DropClusteredConstraintStateOption)fragment;
                    return new DropClusteredConstraintStateOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 345: {
                    var node = (ScriptDom.DropClusteredConstraintValueOption)fragment;
                    return new DropClusteredConstraintValueOption(
                        optionValue: (Literal)FromMutable(node.OptionValue),
                        optionKind: node.OptionKind
                    );
                }
                case 346: {
                    var node = (ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption)fragment;
                    return new DropClusteredConstraintWaitAtLowPriorityLockOption(
                        options: node.Options.SelectList(c => (LowPriorityLockWaitOption)FromMutable(c)),
                        optionKind: node.OptionKind
                    );
                }
                case 347: {
                    var node = (ScriptDom.DropColumnEncryptionKeyStatement)fragment;
                    return new DropColumnEncryptionKeyStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 348: {
                    var node = (ScriptDom.DropColumnMasterKeyStatement)fragment;
                    return new DropColumnMasterKeyStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 349: {
                    var node = (ScriptDom.DropContractStatement)fragment;
                    return new DropContractStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 350: {
                    var node = (ScriptDom.DropCredentialStatement)fragment;
                    return new DropCredentialStatement(
                        isDatabaseScoped: node.IsDatabaseScoped,
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 351: {
                    var node = (ScriptDom.DropCryptographicProviderStatement)fragment;
                    return new DropCryptographicProviderStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 352: {
                    var node = (ScriptDom.DropDatabaseAuditSpecificationStatement)fragment;
                    return new DropDatabaseAuditSpecificationStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 353: {
                    var node = (ScriptDom.DropDatabaseEncryptionKeyStatement)fragment;
                    return new DropDatabaseEncryptionKeyStatement(
                        
                    );
                }
                case 354: {
                    var node = (ScriptDom.DropDatabaseStatement)fragment;
                    return new DropDatabaseStatement(
                        databases: node.Databases.SelectList(c => (Identifier)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 355: {
                    var node = (ScriptDom.DropDefaultStatement)fragment;
                    return new DropDefaultStatement(
                        objects: node.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 356: {
                    var node = (ScriptDom.DropEndpointStatement)fragment;
                    return new DropEndpointStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 357: {
                    var node = (ScriptDom.DropEventNotificationStatement)fragment;
                    return new DropEventNotificationStatement(
                        notifications: node.Notifications.SelectList(c => (Identifier)FromMutable(c)),
                        scope: (EventNotificationObjectScope)FromMutable(node.Scope)
                    );
                }
                case 358: {
                    var node = (ScriptDom.DropEventSessionStatement)fragment;
                    return new DropEventSessionStatement(
                        sessionScope: node.SessionScope,
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 359: {
                    var node = (ScriptDom.DropExternalDataSourceStatement)fragment;
                    return new DropExternalDataSourceStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 360: {
                    var node = (ScriptDom.DropExternalFileFormatStatement)fragment;
                    return new DropExternalFileFormatStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 361: {
                    var node = (ScriptDom.DropExternalLanguageStatement)fragment;
                    return new DropExternalLanguageStatement(
                        name: (Identifier)FromMutable(node.Name),
                        owner: (Identifier)FromMutable(node.Owner)
                    );
                }
                case 362: {
                    var node = (ScriptDom.DropExternalLibraryStatement)fragment;
                    return new DropExternalLibraryStatement(
                        name: (Identifier)FromMutable(node.Name),
                        owner: (Identifier)FromMutable(node.Owner)
                    );
                }
                case 363: {
                    var node = (ScriptDom.DropExternalResourcePoolStatement)fragment;
                    return new DropExternalResourcePoolStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 364: {
                    var node = (ScriptDom.DropExternalStreamingJobStatement)fragment;
                    return new DropExternalStreamingJobStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 365: {
                    var node = (ScriptDom.DropExternalStreamStatement)fragment;
                    return new DropExternalStreamStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 366: {
                    var node = (ScriptDom.DropExternalTableStatement)fragment;
                    return new DropExternalTableStatement(
                        objects: node.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 367: {
                    var node = (ScriptDom.DropFederationStatement)fragment;
                    return new DropFederationStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 368: {
                    var node = (ScriptDom.DropFullTextCatalogStatement)fragment;
                    return new DropFullTextCatalogStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 369: {
                    var node = (ScriptDom.DropFullTextIndexStatement)fragment;
                    return new DropFullTextIndexStatement(
                        tableName: (SchemaObjectName)FromMutable(node.TableName)
                    );
                }
                case 370: {
                    var node = (ScriptDom.DropFullTextStopListStatement)fragment;
                    return new DropFullTextStopListStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 371: {
                    var node = (ScriptDom.DropFunctionStatement)fragment;
                    return new DropFunctionStatement(
                        objects: node.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 372: {
                    var node = (ScriptDom.DropIndexClause)fragment;
                    return new DropIndexClause(
                        index: (Identifier)FromMutable(node.Index),
                        @object: (SchemaObjectName)FromMutable(node.Object),
                        options: node.Options.SelectList(c => (IndexOption)FromMutable(c))
                    );
                }
                case 373: {
                    var node = (ScriptDom.DropIndexStatement)fragment;
                    return new DropIndexStatement(
                        dropIndexClauses: node.DropIndexClauses.SelectList(c => (DropIndexClauseBase)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 374: {
                    var node = (ScriptDom.DropLoginStatement)fragment;
                    return new DropLoginStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 375: {
                    var node = (ScriptDom.DropMasterKeyStatement)fragment;
                    return new DropMasterKeyStatement(
                        
                    );
                }
                case 376: {
                    var node = (ScriptDom.DropMemberAlterRoleAction)fragment;
                    return new DropMemberAlterRoleAction(
                        member: (Identifier)FromMutable(node.Member)
                    );
                }
                case 377: {
                    var node = (ScriptDom.DropMessageTypeStatement)fragment;
                    return new DropMessageTypeStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 378: {
                    var node = (ScriptDom.DropPartitionFunctionStatement)fragment;
                    return new DropPartitionFunctionStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 379: {
                    var node = (ScriptDom.DropPartitionSchemeStatement)fragment;
                    return new DropPartitionSchemeStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 380: {
                    var node = (ScriptDom.DropProcedureStatement)fragment;
                    return new DropProcedureStatement(
                        objects: node.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 381: {
                    var node = (ScriptDom.DropQueueStatement)fragment;
                    return new DropQueueStatement(
                        name: (SchemaObjectName)FromMutable(node.Name)
                    );
                }
                case 382: {
                    var node = (ScriptDom.DropRemoteServiceBindingStatement)fragment;
                    return new DropRemoteServiceBindingStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 383: {
                    var node = (ScriptDom.DropResourcePoolStatement)fragment;
                    return new DropResourcePoolStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 384: {
                    var node = (ScriptDom.DropRoleStatement)fragment;
                    return new DropRoleStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 385: {
                    var node = (ScriptDom.DropRouteStatement)fragment;
                    return new DropRouteStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 386: {
                    var node = (ScriptDom.DropRuleStatement)fragment;
                    return new DropRuleStatement(
                        objects: node.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 387: {
                    var node = (ScriptDom.DropSchemaStatement)fragment;
                    return new DropSchemaStatement(
                        schema: (SchemaObjectName)FromMutable(node.Schema),
                        dropBehavior: node.DropBehavior,
                        isIfExists: node.IsIfExists
                    );
                }
                case 388: {
                    var node = (ScriptDom.DropSearchPropertyListAction)fragment;
                    return new DropSearchPropertyListAction(
                        propertyName: (StringLiteral)FromMutable(node.PropertyName)
                    );
                }
                case 389: {
                    var node = (ScriptDom.DropSearchPropertyListStatement)fragment;
                    return new DropSearchPropertyListStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 390: {
                    var node = (ScriptDom.DropSecurityPolicyStatement)fragment;
                    return new DropSecurityPolicyStatement(
                        objects: node.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 391: {
                    var node = (ScriptDom.DropSensitivityClassificationStatement)fragment;
                    return new DropSensitivityClassificationStatement(
                        columns: node.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
                    );
                }
                case 392: {
                    var node = (ScriptDom.DropSequenceStatement)fragment;
                    return new DropSequenceStatement(
                        objects: node.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 393: {
                    var node = (ScriptDom.DropServerAuditSpecificationStatement)fragment;
                    return new DropServerAuditSpecificationStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 394: {
                    var node = (ScriptDom.DropServerAuditStatement)fragment;
                    return new DropServerAuditStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 395: {
                    var node = (ScriptDom.DropServerRoleStatement)fragment;
                    return new DropServerRoleStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 396: {
                    var node = (ScriptDom.DropServiceStatement)fragment;
                    return new DropServiceStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 397: {
                    var node = (ScriptDom.DropSignatureStatement)fragment;
                    return new DropSignatureStatement(
                        isCounter: node.IsCounter,
                        elementKind: node.ElementKind,
                        element: (SchemaObjectName)FromMutable(node.Element),
                        cryptos: node.Cryptos.SelectList(c => (CryptoMechanism)FromMutable(c))
                    );
                }
                case 398: {
                    var node = (ScriptDom.DropStatisticsStatement)fragment;
                    return new DropStatisticsStatement(
                        objects: node.Objects.SelectList(c => (ChildObjectName)FromMutable(c))
                    );
                }
                case 399: {
                    var node = (ScriptDom.DropSymmetricKeyStatement)fragment;
                    return new DropSymmetricKeyStatement(
                        removeProviderKey: node.RemoveProviderKey,
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 400: {
                    var node = (ScriptDom.DropSynonymStatement)fragment;
                    return new DropSynonymStatement(
                        objects: node.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 401: {
                    var node = (ScriptDom.DropTableStatement)fragment;
                    return new DropTableStatement(
                        objects: node.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 402: {
                    var node = (ScriptDom.DropTriggerStatement)fragment;
                    return new DropTriggerStatement(
                        triggerScope: node.TriggerScope,
                        objects: node.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 403: {
                    var node = (ScriptDom.DropTypeStatement)fragment;
                    return new DropTypeStatement(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 404: {
                    var node = (ScriptDom.DropUserStatement)fragment;
                    return new DropUserStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 405: {
                    var node = (ScriptDom.DropViewStatement)fragment;
                    return new DropViewStatement(
                        objects: node.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        isIfExists: node.IsIfExists
                    );
                }
                case 406: {
                    var node = (ScriptDom.DropWorkloadClassifierStatement)fragment;
                    return new DropWorkloadClassifierStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 407: {
                    var node = (ScriptDom.DropWorkloadGroupStatement)fragment;
                    return new DropWorkloadGroupStatement(
                        name: (Identifier)FromMutable(node.Name),
                        isIfExists: node.IsIfExists
                    );
                }
                case 408: {
                    var node = (ScriptDom.DropXmlSchemaCollectionStatement)fragment;
                    return new DropXmlSchemaCollectionStatement(
                        name: (SchemaObjectName)FromMutable(node.Name)
                    );
                }
                case 409: {
                    var node = (ScriptDom.DurabilityTableOption)fragment;
                    return new DurabilityTableOption(
                        durabilityTableOptionKind: node.DurabilityTableOptionKind,
                        optionKind: node.OptionKind
                    );
                }
                case 410: {
                    var node = (ScriptDom.EnabledDisabledPayloadOption)fragment;
                    return new EnabledDisabledPayloadOption(
                        isEnabled: node.IsEnabled,
                        kind: node.Kind
                    );
                }
                case 411: {
                    var node = (ScriptDom.EnableDisableTriggerStatement)fragment;
                    return new EnableDisableTriggerStatement(
                        triggerEnforcement: node.TriggerEnforcement,
                        all: node.All,
                        triggerNames: node.TriggerNames.SelectList(c => (SchemaObjectName)FromMutable(c)),
                        triggerObject: (TriggerObject)FromMutable(node.TriggerObject)
                    );
                }
                case 412: {
                    var node = (ScriptDom.EncryptedValueParameter)fragment;
                    return new EncryptedValueParameter(
                        @value: (BinaryLiteral)FromMutable(node.Value),
                        parameterKind: node.ParameterKind
                    );
                }
                case 413: {
                    var node = (ScriptDom.EncryptionPayloadOption)fragment;
                    return new EncryptionPayloadOption(
                        encryptionSupport: node.EncryptionSupport,
                        algorithmPartOne: node.AlgorithmPartOne,
                        algorithmPartTwo: node.AlgorithmPartTwo,
                        kind: node.Kind
                    );
                }
                case 414: {
                    var node = (ScriptDom.EndConversationStatement)fragment;
                    return new EndConversationStatement(
                        conversation: (ScalarExpression)FromMutable(node.Conversation),
                        withCleanup: node.WithCleanup,
                        errorCode: (ValueExpression)FromMutable(node.ErrorCode),
                        errorDescription: (ValueExpression)FromMutable(node.ErrorDescription)
                    );
                }
                case 415: {
                    var node = (ScriptDom.EndpointAffinity)fragment;
                    return new EndpointAffinity(
                        kind: node.Kind,
                        @value: (Literal)FromMutable(node.Value)
                    );
                }
                case 416: {
                    var node = (ScriptDom.EventDeclaration)fragment;
                    return new EventDeclaration(
                        objectName: (EventSessionObjectName)FromMutable(node.ObjectName),
                        eventDeclarationSetParameters: node.EventDeclarationSetParameters.SelectList(c => (EventDeclarationSetParameter)FromMutable(c)),
                        eventDeclarationActionParameters: node.EventDeclarationActionParameters.SelectList(c => (EventSessionObjectName)FromMutable(c)),
                        eventDeclarationPredicateParameter: (BooleanExpression)FromMutable(node.EventDeclarationPredicateParameter)
                    );
                }
                case 417: {
                    var node = (ScriptDom.EventDeclarationCompareFunctionParameter)fragment;
                    return new EventDeclarationCompareFunctionParameter(
                        name: (EventSessionObjectName)FromMutable(node.Name),
                        sourceDeclaration: (SourceDeclaration)FromMutable(node.SourceDeclaration),
                        eventValue: (ScalarExpression)FromMutable(node.EventValue)
                    );
                }
                case 418: {
                    var node = (ScriptDom.EventDeclarationSetParameter)fragment;
                    return new EventDeclarationSetParameter(
                        eventField: (Identifier)FromMutable(node.EventField),
                        eventValue: (ScalarExpression)FromMutable(node.EventValue)
                    );
                }
                case 419: {
                    var node = (ScriptDom.EventGroupContainer)fragment;
                    return new EventGroupContainer(
                        eventGroup: node.EventGroup
                    );
                }
                case 420: {
                    var node = (ScriptDom.EventNotificationObjectScope)fragment;
                    return new EventNotificationObjectScope(
                        target: node.Target,
                        queueName: (SchemaObjectName)FromMutable(node.QueueName)
                    );
                }
                case 421: {
                    var node = (ScriptDom.EventRetentionSessionOption)fragment;
                    return new EventRetentionSessionOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 422: {
                    var node = (ScriptDom.EventSessionObjectName)fragment;
                    return new EventSessionObjectName(
                        multiPartIdentifier: (MultiPartIdentifier)FromMutable(node.MultiPartIdentifier)
                    );
                }
                case 423: {
                    var node = (ScriptDom.EventSessionStatement)fragment;
                    return new EventSessionStatement(
                        name: (Identifier)FromMutable(node.Name),
                        sessionScope: node.SessionScope,
                        eventDeclarations: node.EventDeclarations.SelectList(c => (EventDeclaration)FromMutable(c)),
                        targetDeclarations: node.TargetDeclarations.SelectList(c => (TargetDeclaration)FromMutable(c)),
                        sessionOptions: node.SessionOptions.SelectList(c => (SessionOption)FromMutable(c))
                    );
                }
                case 424: {
                    var node = (ScriptDom.EventTypeContainer)fragment;
                    return new EventTypeContainer(
                        eventType: node.EventType
                    );
                }
                case 425: {
                    var node = (ScriptDom.ExecutableProcedureReference)fragment;
                    return new ExecutableProcedureReference(
                        procedureReference: (ProcedureReferenceName)FromMutable(node.ProcedureReference),
                        adHocDataSource: (AdHocDataSource)FromMutable(node.AdHocDataSource),
                        parameters: node.Parameters.SelectList(c => (ExecuteParameter)FromMutable(c))
                    );
                }
                case 426: {
                    var node = (ScriptDom.ExecutableStringList)fragment;
                    return new ExecutableStringList(
                        strings: node.Strings.SelectList(c => (ValueExpression)FromMutable(c)),
                        parameters: node.Parameters.SelectList(c => (ExecuteParameter)FromMutable(c))
                    );
                }
                case 427: {
                    var node = (ScriptDom.ExecuteAsClause)fragment;
                    return new ExecuteAsClause(
                        executeAsOption: node.ExecuteAsOption,
                        literal: (Literal)FromMutable(node.Literal)
                    );
                }
                case 428: {
                    var node = (ScriptDom.ExecuteAsFunctionOption)fragment;
                    return new ExecuteAsFunctionOption(
                        executeAs: (ExecuteAsClause)FromMutable(node.ExecuteAs),
                        optionKind: node.OptionKind
                    );
                }
                case 429: {
                    var node = (ScriptDom.ExecuteAsProcedureOption)fragment;
                    return new ExecuteAsProcedureOption(
                        executeAs: (ExecuteAsClause)FromMutable(node.ExecuteAs),
                        optionKind: node.OptionKind
                    );
                }
                case 430: {
                    var node = (ScriptDom.ExecuteAsStatement)fragment;
                    return new ExecuteAsStatement(
                        withNoRevert: node.WithNoRevert,
                        cookie: (VariableReference)FromMutable(node.Cookie),
                        executeContext: (ExecuteContext)FromMutable(node.ExecuteContext)
                    );
                }
                case 431: {
                    var node = (ScriptDom.ExecuteAsTriggerOption)fragment;
                    return new ExecuteAsTriggerOption(
                        executeAsClause: (ExecuteAsClause)FromMutable(node.ExecuteAsClause),
                        optionKind: node.OptionKind
                    );
                }
                case 432: {
                    var node = (ScriptDom.ExecuteContext)fragment;
                    return new ExecuteContext(
                        principal: (ScalarExpression)FromMutable(node.Principal),
                        kind: node.Kind
                    );
                }
                case 433: {
                    var node = (ScriptDom.ExecuteInsertSource)fragment;
                    return new ExecuteInsertSource(
                        execute: (ExecuteSpecification)FromMutable(node.Execute)
                    );
                }
                case 434: {
                    var node = (ScriptDom.ExecuteOption)fragment;
                    return new ExecuteOption(
                        optionKind: node.OptionKind
                    );
                }
                case 435: {
                    var node = (ScriptDom.ExecuteParameter)fragment;
                    return new ExecuteParameter(
                        variable: (VariableReference)FromMutable(node.Variable),
                        parameterValue: (ScalarExpression)FromMutable(node.ParameterValue),
                        isOutput: node.IsOutput
                    );
                }
                case 436: {
                    var node = (ScriptDom.ExecuteSpecification)fragment;
                    return new ExecuteSpecification(
                        variable: (VariableReference)FromMutable(node.Variable),
                        linkedServer: (Identifier)FromMutable(node.LinkedServer),
                        executeContext: (ExecuteContext)FromMutable(node.ExecuteContext),
                        executableEntity: (ExecutableEntity)FromMutable(node.ExecutableEntity)
                    );
                }
                case 437: {
                    var node = (ScriptDom.ExecuteStatement)fragment;
                    return new ExecuteStatement(
                        executeSpecification: (ExecuteSpecification)FromMutable(node.ExecuteSpecification),
                        options: node.Options.SelectList(c => (ExecuteOption)FromMutable(c))
                    );
                }
                case 438: {
                    var node = (ScriptDom.ExistsPredicate)fragment;
                    return new ExistsPredicate(
                        subquery: (ScalarSubquery)FromMutable(node.Subquery)
                    );
                }
                case 439: {
                    var node = (ScriptDom.ExpressionCallTarget)fragment;
                    return new ExpressionCallTarget(
                        expression: (ScalarExpression)FromMutable(node.Expression)
                    );
                }
                case 440: {
                    var node = (ScriptDom.ExpressionGroupingSpecification)fragment;
                    return new ExpressionGroupingSpecification(
                        expression: (ScalarExpression)FromMutable(node.Expression),
                        distributedAggregation: node.DistributedAggregation
                    );
                }
                case 441: {
                    var node = (ScriptDom.ExpressionWithSortOrder)fragment;
                    return new ExpressionWithSortOrder(
                        sortOrder: node.SortOrder,
                        expression: (ScalarExpression)FromMutable(node.Expression)
                    );
                }
                case 442: {
                    var node = (ScriptDom.ExternalCreateLoginSource)fragment;
                    return new ExternalCreateLoginSource(
                        options: node.Options.SelectList(c => (PrincipalOption)FromMutable(c))
                    );
                }
                case 443: {
                    var node = (ScriptDom.ExternalDataSourceLiteralOrIdentifierOption)fragment;
                    return new ExternalDataSourceLiteralOrIdentifierOption(
                        @value: (IdentifierOrValueExpression)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 444: {
                    var node = (ScriptDom.ExternalFileFormatContainerOption)fragment;
                    return new ExternalFileFormatContainerOption(
                        suboptions: node.Suboptions.SelectList(c => (ExternalFileFormatOption)FromMutable(c)),
                        optionKind: node.OptionKind
                    );
                }
                case 445: {
                    var node = (ScriptDom.ExternalFileFormatLiteralOption)fragment;
                    return new ExternalFileFormatLiteralOption(
                        @value: (Literal)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 446: {
                    var node = (ScriptDom.ExternalFileFormatUseDefaultTypeOption)fragment;
                    return new ExternalFileFormatUseDefaultTypeOption(
                        externalFileFormatUseDefaultType: node.ExternalFileFormatUseDefaultType,
                        optionKind: node.OptionKind
                    );
                }
                case 447: {
                    var node = (ScriptDom.ExternalLanguageFileOption)fragment;
                    return new ExternalLanguageFileOption(
                        content: (ScalarExpression)FromMutable(node.Content),
                        fileName: (StringLiteral)FromMutable(node.FileName),
                        path: (StringLiteral)FromMutable(node.Path),
                        platform: (Identifier)FromMutable(node.Platform),
                        parameters: (StringLiteral)FromMutable(node.Parameters),
                        environmentVariables: (StringLiteral)FromMutable(node.EnvironmentVariables)
                    );
                }
                case 448: {
                    var node = (ScriptDom.ExternalLibraryFileOption)fragment;
                    return new ExternalLibraryFileOption(
                        content: (ScalarExpression)FromMutable(node.Content),
                        path: (StringLiteral)FromMutable(node.Path),
                        platform: (Identifier)FromMutable(node.Platform)
                    );
                }
                case 449: {
                    var node = (ScriptDom.ExternalResourcePoolAffinitySpecification)fragment;
                    return new ExternalResourcePoolAffinitySpecification(
                        affinityType: node.AffinityType,
                        parameterValue: (Literal)FromMutable(node.ParameterValue),
                        isAuto: node.IsAuto,
                        poolAffinityRanges: node.PoolAffinityRanges.SelectList(c => (LiteralRange)FromMutable(c))
                    );
                }
                case 450: {
                    var node = (ScriptDom.ExternalResourcePoolParameter)fragment;
                    return new ExternalResourcePoolParameter(
                        parameterType: node.ParameterType,
                        parameterValue: (Literal)FromMutable(node.ParameterValue),
                        affinitySpecification: (ExternalResourcePoolAffinitySpecification)FromMutable(node.AffinitySpecification)
                    );
                }
                case 451: {
                    var node = (ScriptDom.ExternalResourcePoolStatement)fragment;
                    return new ExternalResourcePoolStatement(
                        name: (Identifier)FromMutable(node.Name),
                        externalResourcePoolParameters: node.ExternalResourcePoolParameters.SelectList(c => (ExternalResourcePoolParameter)FromMutable(c))
                    );
                }
                case 452: {
                    var node = (ScriptDom.ExternalStreamLiteralOrIdentifierOption)fragment;
                    return new ExternalStreamLiteralOrIdentifierOption(
                        @value: (IdentifierOrValueExpression)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 453: {
                    var node = (ScriptDom.ExternalTableColumnDefinition)fragment;
                    return new ExternalTableColumnDefinition(
                        columnDefinition: (ColumnDefinitionBase)FromMutable(node.ColumnDefinition),
                        nullableConstraint: (NullableConstraintDefinition)FromMutable(node.NullableConstraint)
                    );
                }
                case 454: {
                    var node = (ScriptDom.ExternalTableDistributionOption)fragment;
                    return new ExternalTableDistributionOption(
                        @value: (ExternalTableDistributionPolicy)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 455: {
                    var node = (ScriptDom.ExternalTableLiteralOrIdentifierOption)fragment;
                    return new ExternalTableLiteralOrIdentifierOption(
                        @value: (IdentifierOrValueExpression)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 456: {
                    var node = (ScriptDom.ExternalTableRejectTypeOption)fragment;
                    return new ExternalTableRejectTypeOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 457: {
                    var node = (ScriptDom.ExternalTableReplicatedDistributionPolicy)fragment;
                    return new ExternalTableReplicatedDistributionPolicy(
                        
                    );
                }
                case 458: {
                    var node = (ScriptDom.ExternalTableRoundRobinDistributionPolicy)fragment;
                    return new ExternalTableRoundRobinDistributionPolicy(
                        
                    );
                }
                case 459: {
                    var node = (ScriptDom.ExternalTableShardedDistributionPolicy)fragment;
                    return new ExternalTableShardedDistributionPolicy(
                        shardingColumn: (Identifier)FromMutable(node.ShardingColumn)
                    );
                }
                case 460: {
                    var node = (ScriptDom.ExtractFromExpression)fragment;
                    return new ExtractFromExpression(
                        expression: (ScalarExpression)FromMutable(node.Expression),
                        extractedElement: (Identifier)FromMutable(node.ExtractedElement)
                    );
                }
                case 461: {
                    var node = (ScriptDom.FailoverModeReplicaOption)fragment;
                    return new FailoverModeReplicaOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 462: {
                    var node = (ScriptDom.FederationScheme)fragment;
                    return new FederationScheme(
                        distributionName: (Identifier)FromMutable(node.DistributionName),
                        columnName: (Identifier)FromMutable(node.ColumnName)
                    );
                }
                case 463: {
                    var node = (ScriptDom.FetchCursorStatement)fragment;
                    return new FetchCursorStatement(
                        fetchType: (FetchType)FromMutable(node.FetchType),
                        intoVariables: node.IntoVariables.SelectList(c => (VariableReference)FromMutable(c)),
                        cursor: (CursorId)FromMutable(node.Cursor)
                    );
                }
                case 464: {
                    var node = (ScriptDom.FetchType)fragment;
                    return new FetchType(
                        orientation: node.Orientation,
                        rowOffset: (ScalarExpression)FromMutable(node.RowOffset)
                    );
                }
                case 465: {
                    var node = (ScriptDom.FileDeclaration)fragment;
                    return new FileDeclaration(
                        options: node.Options.SelectList(c => (FileDeclarationOption)FromMutable(c)),
                        isPrimary: node.IsPrimary
                    );
                }
                case 466: {
                    var node = (ScriptDom.FileDeclarationOption)fragment;
                    return new FileDeclarationOption(
                        optionKind: node.OptionKind
                    );
                }
                case 467: {
                    var node = (ScriptDom.FileEncryptionSource)fragment;
                    return new FileEncryptionSource(
                        isExecutable: node.IsExecutable,
                        file: (Literal)FromMutable(node.File)
                    );
                }
                case 468: {
                    var node = (ScriptDom.FileGroupDefinition)fragment;
                    return new FileGroupDefinition(
                        name: (Identifier)FromMutable(node.Name),
                        fileDeclarations: node.FileDeclarations.SelectList(c => (FileDeclaration)FromMutable(c)),
                        isDefault: node.IsDefault,
                        containsFileStream: node.ContainsFileStream,
                        containsMemoryOptimizedData: node.ContainsMemoryOptimizedData
                    );
                }
                case 469: {
                    var node = (ScriptDom.FileGroupOrPartitionScheme)fragment;
                    return new FileGroupOrPartitionScheme(
                        name: (IdentifierOrValueExpression)FromMutable(node.Name),
                        partitionSchemeColumns: node.PartitionSchemeColumns.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 470: {
                    var node = (ScriptDom.FileGrowthFileDeclarationOption)fragment;
                    return new FileGrowthFileDeclarationOption(
                        growthIncrement: (Literal)FromMutable(node.GrowthIncrement),
                        units: node.Units,
                        optionKind: node.OptionKind
                    );
                }
                case 471: {
                    var node = (ScriptDom.FileNameFileDeclarationOption)fragment;
                    return new FileNameFileDeclarationOption(
                        oSFileName: (Literal)FromMutable(node.OSFileName),
                        optionKind: node.OptionKind
                    );
                }
                case 472: {
                    var node = (ScriptDom.FileStreamDatabaseOption)fragment;
                    return new FileStreamDatabaseOption(
                        nonTransactedAccess: node.NonTransactedAccess,
                        directoryName: (Literal)FromMutable(node.DirectoryName),
                        optionKind: node.OptionKind
                    );
                }
                case 473: {
                    var node = (ScriptDom.FileStreamOnDropIndexOption)fragment;
                    return new FileStreamOnDropIndexOption(
                        fileStreamOn: (IdentifierOrValueExpression)FromMutable(node.FileStreamOn),
                        optionKind: node.OptionKind
                    );
                }
                case 474: {
                    var node = (ScriptDom.FileStreamOnTableOption)fragment;
                    return new FileStreamOnTableOption(
                        @value: (IdentifierOrValueExpression)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 475: {
                    var node = (ScriptDom.FileStreamRestoreOption)fragment;
                    return new FileStreamRestoreOption(
                        fileStreamOption: (FileStreamDatabaseOption)FromMutable(node.FileStreamOption),
                        optionKind: node.OptionKind
                    );
                }
                case 476: {
                    var node = (ScriptDom.FileTableCollateFileNameTableOption)fragment;
                    return new FileTableCollateFileNameTableOption(
                        @value: (Identifier)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 477: {
                    var node = (ScriptDom.FileTableConstraintNameTableOption)fragment;
                    return new FileTableConstraintNameTableOption(
                        @value: (Identifier)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 478: {
                    var node = (ScriptDom.FileTableDirectoryTableOption)fragment;
                    return new FileTableDirectoryTableOption(
                        @value: (Literal)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 479: {
                    var node = (ScriptDom.ForceSeekTableHint)fragment;
                    return new ForceSeekTableHint(
                        indexValue: (IdentifierOrValueExpression)FromMutable(node.IndexValue),
                        columnValues: node.ColumnValues.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        hintKind: node.HintKind
                    );
                }
                case 480: {
                    var node = (ScriptDom.ForeignKeyConstraintDefinition)fragment;
                    return new ForeignKeyConstraintDefinition(
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        referenceTableName: (SchemaObjectName)FromMutable(node.ReferenceTableName),
                        referencedTableColumns: node.ReferencedTableColumns.SelectList(c => (Identifier)FromMutable(c)),
                        deleteAction: node.DeleteAction,
                        updateAction: node.UpdateAction,
                        notForReplication: node.NotForReplication,
                        constraintIdentifier: (Identifier)FromMutable(node.ConstraintIdentifier)
                    );
                }
                case 481: {
                    var node = (ScriptDom.FromClause)fragment;
                    return new FromClause(
                        tableReferences: node.TableReferences.SelectList(c => (TableReference)FromMutable(c)),
                        predictTableReference: node.PredictTableReference.SelectList(c => (PredictTableReference)FromMutable(c))
                    );
                }
                case 482: {
                    var node = (ScriptDom.FullTextCatalogAndFileGroup)fragment;
                    return new FullTextCatalogAndFileGroup(
                        catalogName: (Identifier)FromMutable(node.CatalogName),
                        fileGroupName: (Identifier)FromMutable(node.FileGroupName),
                        fileGroupIsFirst: node.FileGroupIsFirst
                    );
                }
                case 483: {
                    var node = (ScriptDom.FullTextIndexColumn)fragment;
                    return new FullTextIndexColumn(
                        name: (Identifier)FromMutable(node.Name),
                        typeColumn: (Identifier)FromMutable(node.TypeColumn),
                        languageTerm: (IdentifierOrValueExpression)FromMutable(node.LanguageTerm),
                        statisticalSemantics: node.StatisticalSemantics
                    );
                }
                case 484: {
                    var node = (ScriptDom.FullTextPredicate)fragment;
                    return new FullTextPredicate(
                        fullTextFunctionType: node.FullTextFunctionType,
                        columns: node.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        @value: (ValueExpression)FromMutable(node.Value),
                        languageTerm: (ValueExpression)FromMutable(node.LanguageTerm),
                        propertyName: (StringLiteral)FromMutable(node.PropertyName)
                    );
                }
                case 485: {
                    var node = (ScriptDom.FullTextStopListAction)fragment;
                    return new FullTextStopListAction(
                        isAdd: node.IsAdd,
                        isAll: node.IsAll,
                        stopWord: (Literal)FromMutable(node.StopWord),
                        languageTerm: (IdentifierOrValueExpression)FromMutable(node.LanguageTerm)
                    );
                }
                case 486: {
                    var node = (ScriptDom.FullTextTableReference)fragment;
                    return new FullTextTableReference(
                        fullTextFunctionType: node.FullTextFunctionType,
                        tableName: (SchemaObjectName)FromMutable(node.TableName),
                        columns: node.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        searchCondition: (ValueExpression)FromMutable(node.SearchCondition),
                        topN: (ValueExpression)FromMutable(node.TopN),
                        language: (ValueExpression)FromMutable(node.Language),
                        propertyName: (StringLiteral)FromMutable(node.PropertyName),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 487: {
                    var node = (ScriptDom.FunctionCall)fragment;
                    return new FunctionCall(
                        callTarget: (CallTarget)FromMutable(node.CallTarget),
                        functionName: (Identifier)FromMutable(node.FunctionName),
                        parameters: node.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        uniqueRowFilter: node.UniqueRowFilter,
                        overClause: (OverClause)FromMutable(node.OverClause),
                        withinGroupClause: (WithinGroupClause)FromMutable(node.WithinGroupClause),
                        ignoreRespectNulls: node.IgnoreRespectNulls.SelectList(c => (Identifier)FromMutable(c)),
                        trimOptions: (Identifier)FromMutable(node.TrimOptions),
                        jsonParameters: node.JsonParameters.SelectList(c => (JsonKeyValue)FromMutable(c)),
                        absentOrNullOnNull: node.AbsentOrNullOnNull.SelectList(c => (Identifier)FromMutable(c)),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 488: {
                    var node = (ScriptDom.FunctionCallSetClause)fragment;
                    return new FunctionCallSetClause(
                        mutatorFunction: (FunctionCall)FromMutable(node.MutatorFunction)
                    );
                }
                case 489: {
                    var node = (ScriptDom.FunctionOption)fragment;
                    return new FunctionOption(
                        optionKind: node.OptionKind
                    );
                }
                case 490: {
                    var node = (ScriptDom.GeneralSetCommand)fragment;
                    return new GeneralSetCommand(
                        commandType: node.CommandType,
                        parameter: (ScalarExpression)FromMutable(node.Parameter)
                    );
                }
                case 491: {
                    var node = (ScriptDom.GenericConfigurationOption)fragment;
                    return new GenericConfigurationOption(
                        genericOptionState: (IdentifierOrScalarExpression)FromMutable(node.GenericOptionState),
                        optionKind: node.OptionKind,
                        genericOptionKind: (Identifier)FromMutable(node.GenericOptionKind)
                    );
                }
                case 492: {
                    var node = (ScriptDom.GetConversationGroupStatement)fragment;
                    return new GetConversationGroupStatement(
                        groupId: (VariableReference)FromMutable(node.GroupId),
                        queue: (SchemaObjectName)FromMutable(node.Queue)
                    );
                }
                case 493: {
                    var node = (ScriptDom.GlobalFunctionTableReference)fragment;
                    return new GlobalFunctionTableReference(
                        name: (Identifier)FromMutable(node.Name),
                        parameters: node.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 494: {
                    var node = (ScriptDom.GlobalVariableExpression)fragment;
                    return new GlobalVariableExpression(
                        name: node.Name,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 495: {
                    var node = (ScriptDom.GoToStatement)fragment;
                    return new GoToStatement(
                        labelName: (Identifier)FromMutable(node.LabelName)
                    );
                }
                case 496: {
                    var node = (ScriptDom.GrandTotalGroupingSpecification)fragment;
                    return new GrandTotalGroupingSpecification(
                        
                    );
                }
                case 497: {
                    var node = (ScriptDom.GrantStatement)fragment;
                    return new GrantStatement(
                        withGrantOption: node.WithGrantOption,
                        permissions: node.Permissions.SelectList(c => (Permission)FromMutable(c)),
                        securityTargetObject: (SecurityTargetObject)FromMutable(node.SecurityTargetObject),
                        principals: node.Principals.SelectList(c => (SecurityPrincipal)FromMutable(c)),
                        asClause: (Identifier)FromMutable(node.AsClause)
                    );
                }
                case 498: {
                    var node = (ScriptDom.GrantStatement80)fragment;
                    return new GrantStatement80(
                        withGrantOption: node.WithGrantOption,
                        asClause: (Identifier)FromMutable(node.AsClause),
                        securityElement80: (SecurityElement80)FromMutable(node.SecurityElement80),
                        securityUserClause80: (SecurityUserClause80)FromMutable(node.SecurityUserClause80)
                    );
                }
                case 499: {
                    var node = (ScriptDom.GraphConnectionBetweenNodes)fragment;
                    return new GraphConnectionBetweenNodes(
                        fromNode: (SchemaObjectName)FromMutable(node.FromNode),
                        toNode: (SchemaObjectName)FromMutable(node.ToNode)
                    );
                }
                case 500: {
                    var node = (ScriptDom.GraphConnectionConstraintDefinition)fragment;
                    return new GraphConnectionConstraintDefinition(
                        fromNodeToNodeList: node.FromNodeToNodeList.SelectList(c => (GraphConnectionBetweenNodes)FromMutable(c)),
                        deleteAction: node.DeleteAction,
                        constraintIdentifier: (Identifier)FromMutable(node.ConstraintIdentifier)
                    );
                }
                case 501: {
                    var node = (ScriptDom.GraphMatchCompositeExpression)fragment;
                    return new GraphMatchCompositeExpression(
                        leftNode: (GraphMatchNodeExpression)FromMutable(node.LeftNode),
                        edge: (Identifier)FromMutable(node.Edge),
                        rightNode: (GraphMatchNodeExpression)FromMutable(node.RightNode),
                        arrowOnRight: node.ArrowOnRight
                    );
                }
                case 502: {
                    var node = (ScriptDom.GraphMatchExpression)fragment;
                    return new GraphMatchExpression(
                        leftNode: (Identifier)FromMutable(node.LeftNode),
                        edge: (Identifier)FromMutable(node.Edge),
                        rightNode: (Identifier)FromMutable(node.RightNode),
                        arrowOnRight: node.ArrowOnRight
                    );
                }
                case 503: {
                    var node = (ScriptDom.GraphMatchLastNodePredicate)fragment;
                    return new GraphMatchLastNodePredicate(
                        leftExpression: (GraphMatchNodeExpression)FromMutable(node.LeftExpression),
                        rightExpression: (GraphMatchNodeExpression)FromMutable(node.RightExpression)
                    );
                }
                case 504: {
                    var node = (ScriptDom.GraphMatchNodeExpression)fragment;
                    return new GraphMatchNodeExpression(
                        node: (Identifier)FromMutable(node.Node),
                        usesLastNode: node.UsesLastNode
                    );
                }
                case 505: {
                    var node = (ScriptDom.GraphMatchPredicate)fragment;
                    return new GraphMatchPredicate(
                        expression: (BooleanExpression)FromMutable(node.Expression)
                    );
                }
                case 506: {
                    var node = (ScriptDom.GraphMatchRecursivePredicate)fragment;
                    return new GraphMatchRecursivePredicate(
                        function: node.Function,
                        outerNodeExpression: (GraphMatchNodeExpression)FromMutable(node.OuterNodeExpression),
                        expression: node.Expression.SelectList(c => (BooleanExpression)FromMutable(c)),
                        recursiveQuantifier: (GraphRecursiveMatchQuantifier)FromMutable(node.RecursiveQuantifier),
                        anchorOnLeft: node.AnchorOnLeft
                    );
                }
                case 507: {
                    var node = (ScriptDom.GraphRecursiveMatchQuantifier)fragment;
                    return new GraphRecursiveMatchQuantifier(
                        isPlusSign: node.IsPlusSign,
                        lowerLimit: (Literal)FromMutable(node.LowerLimit),
                        upperLimit: (Literal)FromMutable(node.UpperLimit)
                    );
                }
                case 508: {
                    var node = (ScriptDom.GridParameter)fragment;
                    return new GridParameter(
                        parameter: node.Parameter,
                        @value: node.Value
                    );
                }
                case 509: {
                    var node = (ScriptDom.GridsSpatialIndexOption)fragment;
                    return new GridsSpatialIndexOption(
                        gridParameters: node.GridParameters.SelectList(c => (GridParameter)FromMutable(c))
                    );
                }
                case 510: {
                    var node = (ScriptDom.GroupByClause)fragment;
                    return new GroupByClause(
                        groupByOption: node.GroupByOption,
                        all: node.All,
                        groupingSpecifications: node.GroupingSpecifications.SelectList(c => (GroupingSpecification)FromMutable(c))
                    );
                }
                case 511: {
                    var node = (ScriptDom.GroupingSetsGroupingSpecification)fragment;
                    return new GroupingSetsGroupingSpecification(
                        sets: node.Sets.SelectList(c => (GroupingSpecification)FromMutable(c))
                    );
                }
                case 512: {
                    var node = (ScriptDom.HadrAvailabilityGroupDatabaseOption)fragment;
                    return new HadrAvailabilityGroupDatabaseOption(
                        groupName: (Identifier)FromMutable(node.GroupName),
                        hadrOption: node.HadrOption,
                        optionKind: node.OptionKind
                    );
                }
                case 513: {
                    var node = (ScriptDom.HadrDatabaseOption)fragment;
                    return new HadrDatabaseOption(
                        hadrOption: node.HadrOption,
                        optionKind: node.OptionKind
                    );
                }
                case 514: {
                    var node = (ScriptDom.HavingClause)fragment;
                    return new HavingClause(
                        searchCondition: (BooleanExpression)FromMutable(node.SearchCondition)
                    );
                }
                case 515: {
                    var node = (ScriptDom.Identifier)fragment;
                    return new Identifier(
                        @value: node.Value,
                        quoteType: node.QuoteType
                    );
                }
                case 516: {
                    var node = (ScriptDom.IdentifierAtomicBlockOption)fragment;
                    return new IdentifierAtomicBlockOption(
                        @value: (Identifier)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 517: {
                    var node = (ScriptDom.IdentifierDatabaseOption)fragment;
                    return new IdentifierDatabaseOption(
                        @value: (Identifier)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 518: {
                    var node = (ScriptDom.IdentifierLiteral)fragment;
                    return new IdentifierLiteral(
                        quoteType: node.QuoteType,
                        @value: node.Value,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 519: {
                    var node = (ScriptDom.IdentifierOrScalarExpression)fragment;
                    return new IdentifierOrScalarExpression(
                        identifier: (Identifier)FromMutable(node.Identifier),
                        scalarExpression: (ScalarExpression)FromMutable(node.ScalarExpression)
                    );
                }
                case 520: {
                    var node = (ScriptDom.IdentifierOrValueExpression)fragment;
                    return new IdentifierOrValueExpression(
                        identifier: (Identifier)FromMutable(node.Identifier),
                        valueExpression: (ValueExpression)FromMutable(node.ValueExpression)
                    );
                }
                case 521: {
                    var node = (ScriptDom.IdentifierPrincipalOption)fragment;
                    return new IdentifierPrincipalOption(
                        identifier: (Identifier)FromMutable(node.Identifier),
                        optionKind: node.OptionKind
                    );
                }
                case 522: {
                    var node = (ScriptDom.IdentifierSnippet)fragment;
                    return new IdentifierSnippet(
                        script: node.Script,
                        @value: node.Value,
                        quoteType: node.QuoteType
                    );
                }
                case 523: {
                    var node = (ScriptDom.IdentityFunctionCall)fragment;
                    return new IdentityFunctionCall(
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        seed: (ScalarExpression)FromMutable(node.Seed),
                        increment: (ScalarExpression)FromMutable(node.Increment)
                    );
                }
                case 524: {
                    var node = (ScriptDom.IdentityOptions)fragment;
                    return new IdentityOptions(
                        identitySeed: (ScalarExpression)FromMutable(node.IdentitySeed),
                        identityIncrement: (ScalarExpression)FromMutable(node.IdentityIncrement),
                        isIdentityNotForReplication: node.IsIdentityNotForReplication
                    );
                }
                case 525: {
                    var node = (ScriptDom.IdentityValueKeyOption)fragment;
                    return new IdentityValueKeyOption(
                        identityPhrase: (Literal)FromMutable(node.IdentityPhrase),
                        optionKind: node.OptionKind
                    );
                }
                case 526: {
                    var node = (ScriptDom.IfStatement)fragment;
                    return new IfStatement(
                        predicate: (BooleanExpression)FromMutable(node.Predicate),
                        thenStatement: (TSqlStatement)FromMutable(node.ThenStatement),
                        elseStatement: (TSqlStatement)FromMutable(node.ElseStatement)
                    );
                }
                case 527: {
                    var node = (ScriptDom.IgnoreDupKeyIndexOption)fragment;
                    return new IgnoreDupKeyIndexOption(
                        suppressMessagesOption: node.SuppressMessagesOption,
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 528: {
                    var node = (ScriptDom.IIfCall)fragment;
                    return new IIfCall(
                        predicate: (BooleanExpression)FromMutable(node.Predicate),
                        thenExpression: (ScalarExpression)FromMutable(node.ThenExpression),
                        elseExpression: (ScalarExpression)FromMutable(node.ElseExpression),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 529: {
                    var node = (ScriptDom.IndexDefinition)fragment;
                    return new IndexDefinition(
                        name: (Identifier)FromMutable(node.Name),
                        unique: node.Unique,
                        indexType: (IndexType)FromMutable(node.IndexType),
                        indexOptions: node.IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                        columns: node.Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                        includeColumns: node.IncludeColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable(node.OnFileGroupOrPartitionScheme),
                        filterPredicate: (BooleanExpression)FromMutable(node.FilterPredicate),
                        fileStreamOn: (IdentifierOrValueExpression)FromMutable(node.FileStreamOn)
                    );
                }
                case 530: {
                    var node = (ScriptDom.IndexExpressionOption)fragment;
                    return new IndexExpressionOption(
                        expression: (ScalarExpression)FromMutable(node.Expression),
                        optionKind: node.OptionKind
                    );
                }
                case 531: {
                    var node = (ScriptDom.IndexStateOption)fragment;
                    return new IndexStateOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 532: {
                    var node = (ScriptDom.IndexTableHint)fragment;
                    return new IndexTableHint(
                        indexValues: node.IndexValues.SelectList(c => (IdentifierOrValueExpression)FromMutable(c)),
                        hintKind: node.HintKind
                    );
                }
                case 533: {
                    var node = (ScriptDom.IndexType)fragment;
                    return new IndexType(
                        indexTypeKind: node.IndexTypeKind
                    );
                }
                case 534: {
                    var node = (ScriptDom.InlineDerivedTable)fragment;
                    return new InlineDerivedTable(
                        rowValues: node.RowValues.SelectList(c => (RowValue)FromMutable(c)),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 535: {
                    var node = (ScriptDom.InlineFunctionOption)fragment;
                    return new InlineFunctionOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 536: {
                    var node = (ScriptDom.InlineResultSetDefinition)fragment;
                    return new InlineResultSetDefinition(
                        resultColumnDefinitions: node.ResultColumnDefinitions.SelectList(c => (ResultColumnDefinition)FromMutable(c)),
                        resultSetType: node.ResultSetType
                    );
                }
                case 537: {
                    var node = (ScriptDom.InPredicate)fragment;
                    return new InPredicate(
                        expression: (ScalarExpression)FromMutable(node.Expression),
                        subquery: (ScalarSubquery)FromMutable(node.Subquery),
                        notDefined: node.NotDefined,
                        values: node.Values.SelectList(c => (ScalarExpression)FromMutable(c))
                    );
                }
                case 538: {
                    var node = (ScriptDom.InsertBulkColumnDefinition)fragment;
                    return new InsertBulkColumnDefinition(
                        column: (ColumnDefinitionBase)FromMutable(node.Column),
                        nullNotNull: node.NullNotNull
                    );
                }
                case 539: {
                    var node = (ScriptDom.InsertBulkStatement)fragment;
                    return new InsertBulkStatement(
                        columnDefinitions: node.ColumnDefinitions.SelectList(c => (InsertBulkColumnDefinition)FromMutable(c)),
                        to: (SchemaObjectName)FromMutable(node.To),
                        options: node.Options.SelectList(c => (BulkInsertOption)FromMutable(c))
                    );
                }
                case 540: {
                    var node = (ScriptDom.InsertMergeAction)fragment;
                    return new InsertMergeAction(
                        columns: node.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        source: (ValuesInsertSource)FromMutable(node.Source)
                    );
                }
                case 541: {
                    var node = (ScriptDom.InsertSpecification)fragment;
                    return new InsertSpecification(
                        insertOption: node.InsertOption,
                        insertSource: (InsertSource)FromMutable(node.InsertSource),
                        columns: node.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        target: (TableReference)FromMutable(node.Target),
                        topRowFilter: (TopRowFilter)FromMutable(node.TopRowFilter),
                        outputIntoClause: (OutputIntoClause)FromMutable(node.OutputIntoClause),
                        outputClause: (OutputClause)FromMutable(node.OutputClause)
                    );
                }
                case 542: {
                    var node = (ScriptDom.InsertStatement)fragment;
                    return new InsertStatement(
                        insertSpecification: (InsertSpecification)FromMutable(node.InsertSpecification),
                        withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable(node.WithCtesAndXmlNamespaces),
                        optimizerHints: node.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 543: {
                    var node = (ScriptDom.IntegerLiteral)fragment;
                    return new IntegerLiteral(
                        @value: node.Value,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 544: {
                    var node = (ScriptDom.InternalOpenRowset)fragment;
                    return new InternalOpenRowset(
                        identifier: (Identifier)FromMutable(node.Identifier),
                        varArgs: node.VarArgs.SelectList(c => (ScalarExpression)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 545: {
                    var node = (ScriptDom.IPv4)fragment;
                    return new IPv4(
                        octetOne: (Literal)FromMutable(node.OctetOne),
                        octetTwo: (Literal)FromMutable(node.OctetTwo),
                        octetThree: (Literal)FromMutable(node.OctetThree),
                        octetFour: (Literal)FromMutable(node.OctetFour)
                    );
                }
                case 546: {
                    var node = (ScriptDom.JoinParenthesisTableReference)fragment;
                    return new JoinParenthesisTableReference(
                        join: (TableReference)FromMutable(node.Join)
                    );
                }
                case 547: {
                    var node = (ScriptDom.JsonForClause)fragment;
                    return new JsonForClause(
                        options: node.Options.SelectList(c => (JsonForClauseOption)FromMutable(c))
                    );
                }
                case 548: {
                    var node = (ScriptDom.JsonForClauseOption)fragment;
                    return new JsonForClauseOption(
                        optionKind: node.OptionKind,
                        @value: (Literal)FromMutable(node.Value)
                    );
                }
                case 549: {
                    var node = (ScriptDom.JsonKeyValue)fragment;
                    return new JsonKeyValue(
                        jsonKeyName: (ScalarExpression)FromMutable(node.JsonKeyName),
                        jsonValue: (ScalarExpression)FromMutable(node.JsonValue)
                    );
                }
                case 550: {
                    var node = (ScriptDom.KeySourceKeyOption)fragment;
                    return new KeySourceKeyOption(
                        passPhrase: (Literal)FromMutable(node.PassPhrase),
                        optionKind: node.OptionKind
                    );
                }
                case 551: {
                    var node = (ScriptDom.KillQueryNotificationSubscriptionStatement)fragment;
                    return new KillQueryNotificationSubscriptionStatement(
                        subscriptionId: (Literal)FromMutable(node.SubscriptionId),
                        all: node.All
                    );
                }
                case 552: {
                    var node = (ScriptDom.KillStatement)fragment;
                    return new KillStatement(
                        parameter: (ScalarExpression)FromMutable(node.Parameter),
                        withStatusOnly: node.WithStatusOnly
                    );
                }
                case 553: {
                    var node = (ScriptDom.KillStatsJobStatement)fragment;
                    return new KillStatsJobStatement(
                        jobId: (ScalarExpression)FromMutable(node.JobId)
                    );
                }
                case 554: {
                    var node = (ScriptDom.LabelStatement)fragment;
                    return new LabelStatement(
                        @value: node.Value
                    );
                }
                case 555: {
                    var node = (ScriptDom.LedgerOption)fragment;
                    return new LedgerOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 556: {
                    var node = (ScriptDom.LedgerTableOption)fragment;
                    return new LedgerTableOption(
                        optionState: node.OptionState,
                        appendOnly: node.AppendOnly,
                        ledgerViewOption: (LedgerViewOption)FromMutable(node.LedgerViewOption),
                        optionKind: node.OptionKind
                    );
                }
                case 557: {
                    var node = (ScriptDom.LedgerViewOption)fragment;
                    return new LedgerViewOption(
                        viewName: (SchemaObjectName)FromMutable(node.ViewName),
                        transactionIdColumnName: (Identifier)FromMutable(node.TransactionIdColumnName),
                        sequenceNumberColumnName: (Identifier)FromMutable(node.SequenceNumberColumnName),
                        operationTypeColumnName: (Identifier)FromMutable(node.OperationTypeColumnName),
                        operationTypeDescColumnName: (Identifier)FromMutable(node.OperationTypeDescColumnName),
                        optionKind: node.OptionKind
                    );
                }
                case 558: {
                    var node = (ScriptDom.LeftFunctionCall)fragment;
                    return new LeftFunctionCall(
                        parameters: node.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 559: {
                    var node = (ScriptDom.LikePredicate)fragment;
                    return new LikePredicate(
                        firstExpression: (ScalarExpression)FromMutable(node.FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable(node.SecondExpression),
                        notDefined: node.NotDefined,
                        odbcEscape: node.OdbcEscape,
                        escapeExpression: (ScalarExpression)FromMutable(node.EscapeExpression)
                    );
                }
                case 560: {
                    var node = (ScriptDom.LineNoStatement)fragment;
                    return new LineNoStatement(
                        lineNo: (IntegerLiteral)FromMutable(node.LineNo)
                    );
                }
                case 561: {
                    var node = (ScriptDom.ListenerIPEndpointProtocolOption)fragment;
                    return new ListenerIPEndpointProtocolOption(
                        isAll: node.IsAll,
                        iPv6: (Literal)FromMutable(node.IPv6),
                        iPv4PartOne: (IPv4)FromMutable(node.IPv4PartOne),
                        iPv4PartTwo: (IPv4)FromMutable(node.IPv4PartTwo),
                        kind: node.Kind
                    );
                }
                case 562: {
                    var node = (ScriptDom.ListTypeCopyOption)fragment;
                    return new ListTypeCopyOption(
                        options: node.Options.SelectList(c => (CopyStatementOptionBase)FromMutable(c))
                    );
                }
                case 563: {
                    var node = (ScriptDom.LiteralAtomicBlockOption)fragment;
                    return new LiteralAtomicBlockOption(
                        @value: (Literal)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 564: {
                    var node = (ScriptDom.LiteralAuditTargetOption)fragment;
                    return new LiteralAuditTargetOption(
                        @value: (Literal)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 565: {
                    var node = (ScriptDom.LiteralAvailabilityGroupOption)fragment;
                    return new LiteralAvailabilityGroupOption(
                        @value: (Literal)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 566: {
                    var node = (ScriptDom.LiteralBulkInsertOption)fragment;
                    return new LiteralBulkInsertOption(
                        @value: (Literal)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 567: {
                    var node = (ScriptDom.LiteralDatabaseOption)fragment;
                    return new LiteralDatabaseOption(
                        @value: (Literal)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 568: {
                    var node = (ScriptDom.LiteralEndpointProtocolOption)fragment;
                    return new LiteralEndpointProtocolOption(
                        @value: (Literal)FromMutable(node.Value),
                        kind: node.Kind
                    );
                }
                case 569: {
                    var node = (ScriptDom.LiteralOpenRowsetCosmosOption)fragment;
                    return new LiteralOpenRowsetCosmosOption(
                        @value: (Literal)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 570: {
                    var node = (ScriptDom.LiteralOptimizerHint)fragment;
                    return new LiteralOptimizerHint(
                        @value: (Literal)FromMutable(node.Value),
                        hintKind: node.HintKind
                    );
                }
                case 571: {
                    var node = (ScriptDom.LiteralOptionValue)fragment;
                    return new LiteralOptionValue(
                        @value: (Literal)FromMutable(node.Value)
                    );
                }
                case 572: {
                    var node = (ScriptDom.LiteralPayloadOption)fragment;
                    return new LiteralPayloadOption(
                        @value: (Literal)FromMutable(node.Value),
                        kind: node.Kind
                    );
                }
                case 573: {
                    var node = (ScriptDom.LiteralPrincipalOption)fragment;
                    return new LiteralPrincipalOption(
                        @value: (Literal)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 574: {
                    var node = (ScriptDom.LiteralRange)fragment;
                    return new LiteralRange(
                        from: (Literal)FromMutable(node.From),
                        to: (Literal)FromMutable(node.To)
                    );
                }
                case 575: {
                    var node = (ScriptDom.LiteralReplicaOption)fragment;
                    return new LiteralReplicaOption(
                        @value: (Literal)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 576: {
                    var node = (ScriptDom.LiteralSessionOption)fragment;
                    return new LiteralSessionOption(
                        @value: (Literal)FromMutable(node.Value),
                        unit: node.Unit,
                        optionKind: node.OptionKind
                    );
                }
                case 577: {
                    var node = (ScriptDom.LiteralStatisticsOption)fragment;
                    return new LiteralStatisticsOption(
                        literal: (Literal)FromMutable(node.Literal),
                        optionKind: node.OptionKind
                    );
                }
                case 578: {
                    var node = (ScriptDom.LiteralTableHint)fragment;
                    return new LiteralTableHint(
                        @value: (Literal)FromMutable(node.Value),
                        hintKind: node.HintKind
                    );
                }
                case 579: {
                    var node = (ScriptDom.LocationOption)fragment;
                    return new LocationOption(
                        locationValue: (Identifier)FromMutable(node.LocationValue),
                        optionKind: node.OptionKind
                    );
                }
                case 580: {
                    var node = (ScriptDom.LockEscalationTableOption)fragment;
                    return new LockEscalationTableOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 581: {
                    var node = (ScriptDom.LoginTypePayloadOption)fragment;
                    return new LoginTypePayloadOption(
                        isWindows: node.IsWindows,
                        kind: node.Kind
                    );
                }
                case 582: {
                    var node = (ScriptDom.LowPriorityLockWaitAbortAfterWaitOption)fragment;
                    return new LowPriorityLockWaitAbortAfterWaitOption(
                        abortAfterWait: node.AbortAfterWait,
                        optionKind: node.OptionKind
                    );
                }
                case 583: {
                    var node = (ScriptDom.LowPriorityLockWaitMaxDurationOption)fragment;
                    return new LowPriorityLockWaitMaxDurationOption(
                        maxDuration: (Literal)FromMutable(node.MaxDuration),
                        unit: node.Unit,
                        optionKind: node.OptionKind
                    );
                }
                case 584: {
                    var node = (ScriptDom.LowPriorityLockWaitTableSwitchOption)fragment;
                    return new LowPriorityLockWaitTableSwitchOption(
                        options: node.Options.SelectList(c => (LowPriorityLockWaitOption)FromMutable(c)),
                        optionKind: node.OptionKind
                    );
                }
                case 585: {
                    var node = (ScriptDom.MaxDispatchLatencySessionOption)fragment;
                    return new MaxDispatchLatencySessionOption(
                        isInfinite: node.IsInfinite,
                        @value: (Literal)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 586: {
                    var node = (ScriptDom.MaxDopConfigurationOption)fragment;
                    return new MaxDopConfigurationOption(
                        @value: (Literal)FromMutable(node.Value),
                        primary: node.Primary,
                        optionKind: node.OptionKind,
                        genericOptionKind: (Identifier)FromMutable(node.GenericOptionKind)
                    );
                }
                case 587: {
                    var node = (ScriptDom.MaxDurationOption)fragment;
                    return new MaxDurationOption(
                        maxDuration: (Literal)FromMutable(node.MaxDuration),
                        unit: node.Unit,
                        optionKind: node.OptionKind
                    );
                }
                case 588: {
                    var node = (ScriptDom.MaxLiteral)fragment;
                    return new MaxLiteral(
                        @value: node.Value,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 589: {
                    var node = (ScriptDom.MaxRolloverFilesAuditTargetOption)fragment;
                    return new MaxRolloverFilesAuditTargetOption(
                        @value: (Literal)FromMutable(node.Value),
                        isUnlimited: node.IsUnlimited,
                        optionKind: node.OptionKind
                    );
                }
                case 590: {
                    var node = (ScriptDom.MaxSizeAuditTargetOption)fragment;
                    return new MaxSizeAuditTargetOption(
                        isUnlimited: node.IsUnlimited,
                        size: (Literal)FromMutable(node.Size),
                        unit: node.Unit,
                        optionKind: node.OptionKind
                    );
                }
                case 591: {
                    var node = (ScriptDom.MaxSizeDatabaseOption)fragment;
                    return new MaxSizeDatabaseOption(
                        maxSize: (Literal)FromMutable(node.MaxSize),
                        units: node.Units,
                        optionKind: node.OptionKind
                    );
                }
                case 592: {
                    var node = (ScriptDom.MaxSizeFileDeclarationOption)fragment;
                    return new MaxSizeFileDeclarationOption(
                        maxSize: (Literal)FromMutable(node.MaxSize),
                        units: node.Units,
                        unlimited: node.Unlimited,
                        optionKind: node.OptionKind
                    );
                }
                case 593: {
                    var node = (ScriptDom.MemoryOptimizedTableOption)fragment;
                    return new MemoryOptimizedTableOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 594: {
                    var node = (ScriptDom.MemoryPartitionSessionOption)fragment;
                    return new MemoryPartitionSessionOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 595: {
                    var node = (ScriptDom.MergeActionClause)fragment;
                    return new MergeActionClause(
                        condition: node.Condition,
                        searchCondition: (BooleanExpression)FromMutable(node.SearchCondition),
                        action: (MergeAction)FromMutable(node.Action)
                    );
                }
                case 596: {
                    var node = (ScriptDom.MergeSpecification)fragment;
                    return new MergeSpecification(
                        tableAlias: (Identifier)FromMutable(node.TableAlias),
                        tableReference: (TableReference)FromMutable(node.TableReference),
                        searchCondition: (BooleanExpression)FromMutable(node.SearchCondition),
                        actionClauses: node.ActionClauses.SelectList(c => (MergeActionClause)FromMutable(c)),
                        target: (TableReference)FromMutable(node.Target),
                        topRowFilter: (TopRowFilter)FromMutable(node.TopRowFilter),
                        outputIntoClause: (OutputIntoClause)FromMutable(node.OutputIntoClause),
                        outputClause: (OutputClause)FromMutable(node.OutputClause)
                    );
                }
                case 597: {
                    var node = (ScriptDom.MergeStatement)fragment;
                    return new MergeStatement(
                        mergeSpecification: (MergeSpecification)FromMutable(node.MergeSpecification),
                        withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable(node.WithCtesAndXmlNamespaces),
                        optimizerHints: node.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 598: {
                    var node = (ScriptDom.MethodSpecifier)fragment;
                    return new MethodSpecifier(
                        assemblyName: (Identifier)FromMutable(node.AssemblyName),
                        className: (Identifier)FromMutable(node.ClassName),
                        methodName: (Identifier)FromMutable(node.MethodName)
                    );
                }
                case 599: {
                    var node = (ScriptDom.MirrorToClause)fragment;
                    return new MirrorToClause(
                        devices: node.Devices.SelectList(c => (DeviceInfo)FromMutable(c))
                    );
                }
                case 600: {
                    var node = (ScriptDom.MoneyLiteral)fragment;
                    return new MoneyLiteral(
                        @value: node.Value,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 601: {
                    var node = (ScriptDom.MoveConversationStatement)fragment;
                    return new MoveConversationStatement(
                        conversation: (ScalarExpression)FromMutable(node.Conversation),
                        group: (ScalarExpression)FromMutable(node.Group)
                    );
                }
                case 602: {
                    var node = (ScriptDom.MoveRestoreOption)fragment;
                    return new MoveRestoreOption(
                        logicalFileName: (ValueExpression)FromMutable(node.LogicalFileName),
                        oSFileName: (ValueExpression)FromMutable(node.OSFileName),
                        optionKind: node.OptionKind
                    );
                }
                case 603: {
                    var node = (ScriptDom.MoveToDropIndexOption)fragment;
                    return new MoveToDropIndexOption(
                        moveTo: (FileGroupOrPartitionScheme)FromMutable(node.MoveTo),
                        optionKind: node.OptionKind
                    );
                }
                case 604: {
                    var node = (ScriptDom.MultiPartIdentifier)fragment;
                    return new MultiPartIdentifier(
                        identifiers: node.Identifiers.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 605: {
                    var node = (ScriptDom.MultiPartIdentifierCallTarget)fragment;
                    return new MultiPartIdentifierCallTarget(
                        multiPartIdentifier: (MultiPartIdentifier)FromMutable(node.MultiPartIdentifier)
                    );
                }
                case 606: {
                    var node = (ScriptDom.NamedTableReference)fragment;
                    return new NamedTableReference(
                        schemaObject: (SchemaObjectName)FromMutable(node.SchemaObject),
                        tableHints: node.TableHints.SelectList(c => (TableHint)FromMutable(c)),
                        tableSampleClause: (TableSampleClause)FromMutable(node.TableSampleClause),
                        temporalClause: (TemporalClause)FromMutable(node.TemporalClause),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 607: {
                    var node = (ScriptDom.NameFileDeclarationOption)fragment;
                    return new NameFileDeclarationOption(
                        logicalFileName: (IdentifierOrValueExpression)FromMutable(node.LogicalFileName),
                        isNewName: node.IsNewName,
                        optionKind: node.OptionKind
                    );
                }
                case 608: {
                    var node = (ScriptDom.NextValueForExpression)fragment;
                    return new NextValueForExpression(
                        sequenceName: (SchemaObjectName)FromMutable(node.SequenceName),
                        overClause: (OverClause)FromMutable(node.OverClause),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 609: {
                    var node = (ScriptDom.NullableConstraintDefinition)fragment;
                    return new NullableConstraintDefinition(
                        nullable: node.Nullable,
                        constraintIdentifier: (Identifier)FromMutable(node.ConstraintIdentifier)
                    );
                }
                case 610: {
                    var node = (ScriptDom.NullIfExpression)fragment;
                    return new NullIfExpression(
                        firstExpression: (ScalarExpression)FromMutable(node.FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable(node.SecondExpression),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 611: {
                    var node = (ScriptDom.NullLiteral)fragment;
                    return new NullLiteral(
                        @value: node.Value,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 612: {
                    var node = (ScriptDom.NumericLiteral)fragment;
                    return new NumericLiteral(
                        @value: node.Value,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 613: {
                    var node = (ScriptDom.OdbcConvertSpecification)fragment;
                    return new OdbcConvertSpecification(
                        identifier: (Identifier)FromMutable(node.Identifier)
                    );
                }
                case 614: {
                    var node = (ScriptDom.OdbcFunctionCall)fragment;
                    return new OdbcFunctionCall(
                        name: (Identifier)FromMutable(node.Name),
                        parametersUsed: node.ParametersUsed,
                        parameters: node.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 615: {
                    var node = (ScriptDom.OdbcLiteral)fragment;
                    return new OdbcLiteral(
                        odbcLiteralType: node.OdbcLiteralType,
                        isNational: node.IsNational,
                        @value: node.Value,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 616: {
                    var node = (ScriptDom.OdbcQualifiedJoinTableReference)fragment;
                    return new OdbcQualifiedJoinTableReference(
                        tableReference: (TableReference)FromMutable(node.TableReference)
                    );
                }
                case 617: {
                    var node = (ScriptDom.OffsetClause)fragment;
                    return new OffsetClause(
                        offsetExpression: (ScalarExpression)FromMutable(node.OffsetExpression),
                        fetchExpression: (ScalarExpression)FromMutable(node.FetchExpression)
                    );
                }
                case 618: {
                    var node = (ScriptDom.OnFailureAuditOption)fragment;
                    return new OnFailureAuditOption(
                        onFailureAction: node.OnFailureAction,
                        optionKind: node.OptionKind
                    );
                }
                case 619: {
                    var node = (ScriptDom.OnlineIndexLowPriorityLockWaitOption)fragment;
                    return new OnlineIndexLowPriorityLockWaitOption(
                        options: node.Options.SelectList(c => (LowPriorityLockWaitOption)FromMutable(c))
                    );
                }
                case 620: {
                    var node = (ScriptDom.OnlineIndexOption)fragment;
                    return new OnlineIndexOption(
                        lowPriorityLockWaitOption: (OnlineIndexLowPriorityLockWaitOption)FromMutable(node.LowPriorityLockWaitOption),
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 621: {
                    var node = (ScriptDom.OnOffAssemblyOption)fragment;
                    return new OnOffAssemblyOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 622: {
                    var node = (ScriptDom.OnOffAtomicBlockOption)fragment;
                    return new OnOffAtomicBlockOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 623: {
                    var node = (ScriptDom.OnOffAuditTargetOption)fragment;
                    return new OnOffAuditTargetOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 624: {
                    var node = (ScriptDom.OnOffDatabaseOption)fragment;
                    return new OnOffDatabaseOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 625: {
                    var node = (ScriptDom.OnOffDialogOption)fragment;
                    return new OnOffDialogOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 626: {
                    var node = (ScriptDom.OnOffFullTextCatalogOption)fragment;
                    return new OnOffFullTextCatalogOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 627: {
                    var node = (ScriptDom.OnOffOptionValue)fragment;
                    return new OnOffOptionValue(
                        optionState: node.OptionState
                    );
                }
                case 628: {
                    var node = (ScriptDom.OnOffPrimaryConfigurationOption)fragment;
                    return new OnOffPrimaryConfigurationOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind,
                        genericOptionKind: (Identifier)FromMutable(node.GenericOptionKind)
                    );
                }
                case 629: {
                    var node = (ScriptDom.OnOffPrincipalOption)fragment;
                    return new OnOffPrincipalOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 630: {
                    var node = (ScriptDom.OnOffRemoteServiceBindingOption)fragment;
                    return new OnOffRemoteServiceBindingOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 631: {
                    var node = (ScriptDom.OnOffSessionOption)fragment;
                    return new OnOffSessionOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 632: {
                    var node = (ScriptDom.OnOffStatisticsOption)fragment;
                    return new OnOffStatisticsOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 633: {
                    var node = (ScriptDom.OpenCursorStatement)fragment;
                    return new OpenCursorStatement(
                        cursor: (CursorId)FromMutable(node.Cursor)
                    );
                }
                case 634: {
                    var node = (ScriptDom.OpenJsonTableReference)fragment;
                    return new OpenJsonTableReference(
                        variable: (ScalarExpression)FromMutable(node.Variable),
                        rowPattern: (ScalarExpression)FromMutable(node.RowPattern),
                        schemaDeclarationItems: node.SchemaDeclarationItems.SelectList(c => (SchemaDeclarationItemOpenjson)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 635: {
                    var node = (ScriptDom.OpenMasterKeyStatement)fragment;
                    return new OpenMasterKeyStatement(
                        password: (Literal)FromMutable(node.Password)
                    );
                }
                case 636: {
                    var node = (ScriptDom.OpenQueryTableReference)fragment;
                    return new OpenQueryTableReference(
                        linkedServer: (Identifier)FromMutable(node.LinkedServer),
                        query: (StringLiteral)FromMutable(node.Query),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 637: {
                    var node = (ScriptDom.OpenRowsetColumnDefinition)fragment;
                    return new OpenRowsetColumnDefinition(
                        columnOrdinal: (IntegerLiteral)FromMutable(node.ColumnOrdinal),
                        jsonPath: (StringLiteral)FromMutable(node.JsonPath),
                        columnIdentifier: (Identifier)FromMutable(node.ColumnIdentifier),
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 638: {
                    var node = (ScriptDom.OpenRowsetCosmos)fragment;
                    return new OpenRowsetCosmos(
                        options: node.Options.SelectList(c => (OpenRowsetCosmosOption)FromMutable(c)),
                        withColumns: node.WithColumns.SelectList(c => (OpenRowsetColumnDefinition)FromMutable(c)),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 639: {
                    var node = (ScriptDom.OpenRowsetCosmosOption)fragment;
                    return new OpenRowsetCosmosOption(
                        optionKind: node.OptionKind
                    );
                }
                case 640: {
                    var node = (ScriptDom.OpenRowsetTableReference)fragment;
                    return new OpenRowsetTableReference(
                        providerName: (StringLiteral)FromMutable(node.ProviderName),
                        dataSource: (StringLiteral)FromMutable(node.DataSource),
                        userId: (StringLiteral)FromMutable(node.UserId),
                        password: (StringLiteral)FromMutable(node.Password),
                        providerString: (StringLiteral)FromMutable(node.ProviderString),
                        query: (StringLiteral)FromMutable(node.Query),
                        @object: (SchemaObjectName)FromMutable(node.Object),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 641: {
                    var node = (ScriptDom.OpenSymmetricKeyStatement)fragment;
                    return new OpenSymmetricKeyStatement(
                        name: (Identifier)FromMutable(node.Name),
                        decryptionMechanism: (CryptoMechanism)FromMutable(node.DecryptionMechanism)
                    );
                }
                case 642: {
                    var node = (ScriptDom.OpenXmlTableReference)fragment;
                    return new OpenXmlTableReference(
                        variable: (VariableReference)FromMutable(node.Variable),
                        rowPattern: (ValueExpression)FromMutable(node.RowPattern),
                        flags: (ValueExpression)FromMutable(node.Flags),
                        schemaDeclarationItems: node.SchemaDeclarationItems.SelectList(c => (SchemaDeclarationItem)FromMutable(c)),
                        tableName: (SchemaObjectName)FromMutable(node.TableName),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 643: {
                    var node = (ScriptDom.OperatorAuditOption)fragment;
                    return new OperatorAuditOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 644: {
                    var node = (ScriptDom.OptimizeForOptimizerHint)fragment;
                    return new OptimizeForOptimizerHint(
                        pairs: node.Pairs.SelectList(c => (VariableValuePair)FromMutable(c)),
                        isForUnknown: node.IsForUnknown,
                        hintKind: node.HintKind
                    );
                }
                case 645: {
                    var node = (ScriptDom.OptimizerHint)fragment;
                    return new OptimizerHint(
                        hintKind: node.HintKind
                    );
                }
                case 646: {
                    var node = (ScriptDom.OrderBulkInsertOption)fragment;
                    return new OrderBulkInsertOption(
                        columns: node.Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                        isUnique: node.IsUnique,
                        optionKind: node.OptionKind
                    );
                }
                case 647: {
                    var node = (ScriptDom.OrderByClause)fragment;
                    return new OrderByClause(
                        orderByElements: node.OrderByElements.SelectList(c => (ExpressionWithSortOrder)FromMutable(c))
                    );
                }
                case 648: {
                    var node = (ScriptDom.OrderIndexOption)fragment;
                    return new OrderIndexOption(
                        columns: node.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        optionKind: node.OptionKind
                    );
                }
                case 649: {
                    var node = (ScriptDom.OutputClause)fragment;
                    return new OutputClause(
                        selectColumns: node.SelectColumns.SelectList(c => (SelectElement)FromMutable(c))
                    );
                }
                case 650: {
                    var node = (ScriptDom.OutputIntoClause)fragment;
                    return new OutputIntoClause(
                        selectColumns: node.SelectColumns.SelectList(c => (SelectElement)FromMutable(c)),
                        intoTable: (TableReference)FromMutable(node.IntoTable),
                        intoTableColumns: node.IntoTableColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
                    );
                }
                case 651: {
                    var node = (ScriptDom.OverClause)fragment;
                    return new OverClause(
                        windowName: (Identifier)FromMutable(node.WindowName),
                        partitions: node.Partitions.SelectList(c => (ScalarExpression)FromMutable(c)),
                        orderByClause: (OrderByClause)FromMutable(node.OrderByClause),
                        windowFrameClause: (WindowFrameClause)FromMutable(node.WindowFrameClause)
                    );
                }
                case 652: {
                    var node = (ScriptDom.PageVerifyDatabaseOption)fragment;
                    return new PageVerifyDatabaseOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 653: {
                    var node = (ScriptDom.ParameterizationDatabaseOption)fragment;
                    return new ParameterizationDatabaseOption(
                        isSimple: node.IsSimple,
                        optionKind: node.OptionKind
                    );
                }
                case 654: {
                    var node = (ScriptDom.ParameterlessCall)fragment;
                    return new ParameterlessCall(
                        parameterlessCallType: node.ParameterlessCallType,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 655: {
                    var node = (ScriptDom.ParenthesisExpression)fragment;
                    return new ParenthesisExpression(
                        expression: (ScalarExpression)FromMutable(node.Expression),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 656: {
                    var node = (ScriptDom.ParseCall)fragment;
                    return new ParseCall(
                        stringValue: (ScalarExpression)FromMutable(node.StringValue),
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        culture: (ScalarExpression)FromMutable(node.Culture),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 657: {
                    var node = (ScriptDom.PartitionFunctionCall)fragment;
                    return new PartitionFunctionCall(
                        databaseName: (Identifier)FromMutable(node.DatabaseName),
                        functionName: (Identifier)FromMutable(node.FunctionName),
                        parameters: node.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 658: {
                    var node = (ScriptDom.PartitionParameterType)fragment;
                    return new PartitionParameterType(
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 659: {
                    var node = (ScriptDom.PartitionSpecifier)fragment;
                    return new PartitionSpecifier(
                        number: (ScalarExpression)FromMutable(node.Number),
                        all: node.All
                    );
                }
                case 660: {
                    var node = (ScriptDom.PartnerDatabaseOption)fragment;
                    return new PartnerDatabaseOption(
                        partnerServer: (Literal)FromMutable(node.PartnerServer),
                        partnerOption: node.PartnerOption,
                        timeout: (Literal)FromMutable(node.Timeout),
                        optionKind: node.OptionKind
                    );
                }
                case 661: {
                    var node = (ScriptDom.PasswordAlterPrincipalOption)fragment;
                    return new PasswordAlterPrincipalOption(
                        password: (Literal)FromMutable(node.Password),
                        oldPassword: (Literal)FromMutable(node.OldPassword),
                        mustChange: node.MustChange,
                        unlock: node.Unlock,
                        hashed: node.Hashed,
                        optionKind: node.OptionKind
                    );
                }
                case 662: {
                    var node = (ScriptDom.PasswordCreateLoginSource)fragment;
                    return new PasswordCreateLoginSource(
                        password: (Literal)FromMutable(node.Password),
                        hashed: node.Hashed,
                        mustChange: node.MustChange,
                        options: node.Options.SelectList(c => (PrincipalOption)FromMutable(c))
                    );
                }
                case 663: {
                    var node = (ScriptDom.Permission)fragment;
                    return new Permission(
                        identifiers: node.Identifiers.SelectList(c => (Identifier)FromMutable(c)),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 664: {
                    var node = (ScriptDom.PermissionSetAssemblyOption)fragment;
                    return new PermissionSetAssemblyOption(
                        permissionSetOption: node.PermissionSetOption,
                        optionKind: node.OptionKind
                    );
                }
                case 665: {
                    var node = (ScriptDom.PivotedTableReference)fragment;
                    return new PivotedTableReference(
                        tableReference: (TableReference)FromMutable(node.TableReference),
                        inColumns: node.InColumns.SelectList(c => (Identifier)FromMutable(c)),
                        pivotColumn: (ColumnReferenceExpression)FromMutable(node.PivotColumn),
                        valueColumns: node.ValueColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        aggregateFunctionIdentifier: (MultiPartIdentifier)FromMutable(node.AggregateFunctionIdentifier),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 666: {
                    var node = (ScriptDom.PortsEndpointProtocolOption)fragment;
                    return new PortsEndpointProtocolOption(
                        portTypes: node.PortTypes,
                        kind: node.Kind
                    );
                }
                case 667: {
                    var node = (ScriptDom.PredicateSetStatement)fragment;
                    return new PredicateSetStatement(
                        options: node.Options,
                        isOn: node.IsOn
                    );
                }
                case 668: {
                    var node = (ScriptDom.PredictTableReference)fragment;
                    return new PredictTableReference(
                        modelVariable: (ScalarExpression)FromMutable(node.ModelVariable),
                        modelSubquery: (ScalarSubquery)FromMutable(node.ModelSubquery),
                        dataSource: (TableReferenceWithAlias)FromMutable(node.DataSource),
                        runTime: (Identifier)FromMutable(node.RunTime),
                        schemaDeclarationItems: node.SchemaDeclarationItems.SelectList(c => (SchemaDeclarationItem)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 669: {
                    var node = (ScriptDom.PrimaryRoleReplicaOption)fragment;
                    return new PrimaryRoleReplicaOption(
                        allowConnections: node.AllowConnections,
                        optionKind: node.OptionKind
                    );
                }
                case 670: {
                    var node = (ScriptDom.PrincipalOption)fragment;
                    return new PrincipalOption(
                        optionKind: node.OptionKind
                    );
                }
                case 671: {
                    var node = (ScriptDom.PrintStatement)fragment;
                    return new PrintStatement(
                        expression: (ScalarExpression)FromMutable(node.Expression)
                    );
                }
                case 672: {
                    var node = (ScriptDom.Privilege80)fragment;
                    return new Privilege80(
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        privilegeType80: node.PrivilegeType80
                    );
                }
                case 673: {
                    var node = (ScriptDom.PrivilegeSecurityElement80)fragment;
                    return new PrivilegeSecurityElement80(
                        privileges: node.Privileges.SelectList(c => (Privilege80)FromMutable(c)),
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 674: {
                    var node = (ScriptDom.ProcedureOption)fragment;
                    return new ProcedureOption(
                        optionKind: node.OptionKind
                    );
                }
                case 675: {
                    var node = (ScriptDom.ProcedureParameter)fragment;
                    return new ProcedureParameter(
                        isVarying: node.IsVarying,
                        modifier: node.Modifier,
                        variableName: (Identifier)FromMutable(node.VariableName),
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        nullable: (NullableConstraintDefinition)FromMutable(node.Nullable),
                        @value: (ScalarExpression)FromMutable(node.Value)
                    );
                }
                case 676: {
                    var node = (ScriptDom.ProcedureReference)fragment;
                    return new ProcedureReference(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        number: (Literal)FromMutable(node.Number)
                    );
                }
                case 677: {
                    var node = (ScriptDom.ProcedureReferenceName)fragment;
                    return new ProcedureReferenceName(
                        procedureReference: (ProcedureReference)FromMutable(node.ProcedureReference),
                        procedureVariable: (VariableReference)FromMutable(node.ProcedureVariable)
                    );
                }
                case 678: {
                    var node = (ScriptDom.ProcessAffinityRange)fragment;
                    return new ProcessAffinityRange(
                        from: (Literal)FromMutable(node.From),
                        to: (Literal)FromMutable(node.To)
                    );
                }
                case 679: {
                    var node = (ScriptDom.ProviderEncryptionSource)fragment;
                    return new ProviderEncryptionSource(
                        name: (Identifier)FromMutable(node.Name),
                        keyOptions: node.KeyOptions.SelectList(c => (KeyOption)FromMutable(c))
                    );
                }
                case 680: {
                    var node = (ScriptDom.ProviderKeyNameKeyOption)fragment;
                    return new ProviderKeyNameKeyOption(
                        keyName: (Literal)FromMutable(node.KeyName),
                        optionKind: node.OptionKind
                    );
                }
                case 681: {
                    var node = (ScriptDom.QualifiedJoin)fragment;
                    return new QualifiedJoin(
                        searchCondition: (BooleanExpression)FromMutable(node.SearchCondition),
                        qualifiedJoinType: node.QualifiedJoinType,
                        joinHint: node.JoinHint,
                        firstTableReference: (TableReference)FromMutable(node.FirstTableReference),
                        secondTableReference: (TableReference)FromMutable(node.SecondTableReference)
                    );
                }
                case 682: {
                    var node = (ScriptDom.QueryDerivedTable)fragment;
                    return new QueryDerivedTable(
                        queryExpression: (QueryExpression)FromMutable(node.QueryExpression),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 683: {
                    var node = (ScriptDom.QueryParenthesisExpression)fragment;
                    return new QueryParenthesisExpression(
                        queryExpression: (QueryExpression)FromMutable(node.QueryExpression),
                        orderByClause: (OrderByClause)FromMutable(node.OrderByClause),
                        offsetClause: (OffsetClause)FromMutable(node.OffsetClause),
                        forClause: (ForClause)FromMutable(node.ForClause)
                    );
                }
                case 684: {
                    var node = (ScriptDom.QuerySpecification)fragment;
                    return new QuerySpecification(
                        uniqueRowFilter: node.UniqueRowFilter,
                        topRowFilter: (TopRowFilter)FromMutable(node.TopRowFilter),
                        selectElements: node.SelectElements.SelectList(c => (SelectElement)FromMutable(c)),
                        fromClause: (FromClause)FromMutable(node.FromClause),
                        whereClause: (WhereClause)FromMutable(node.WhereClause),
                        groupByClause: (GroupByClause)FromMutable(node.GroupByClause),
                        havingClause: (HavingClause)FromMutable(node.HavingClause),
                        windowClause: (WindowClause)FromMutable(node.WindowClause),
                        orderByClause: (OrderByClause)FromMutable(node.OrderByClause),
                        offsetClause: (OffsetClause)FromMutable(node.OffsetClause),
                        forClause: (ForClause)FromMutable(node.ForClause)
                    );
                }
                case 685: {
                    var node = (ScriptDom.QueryStoreCapturePolicyOption)fragment;
                    return new QueryStoreCapturePolicyOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 686: {
                    var node = (ScriptDom.QueryStoreDatabaseOption)fragment;
                    return new QueryStoreDatabaseOption(
                        clear: node.Clear,
                        clearAll: node.ClearAll,
                        optionState: node.OptionState,
                        options: node.Options.SelectList(c => (QueryStoreOption)FromMutable(c)),
                        optionKind: node.OptionKind
                    );
                }
                case 687: {
                    var node = (ScriptDom.QueryStoreDataFlushIntervalOption)fragment;
                    return new QueryStoreDataFlushIntervalOption(
                        flushInterval: (Literal)FromMutable(node.FlushInterval),
                        optionKind: node.OptionKind
                    );
                }
                case 688: {
                    var node = (ScriptDom.QueryStoreDesiredStateOption)fragment;
                    return new QueryStoreDesiredStateOption(
                        @value: node.Value,
                        operationModeSpecified: node.OperationModeSpecified,
                        optionKind: node.OptionKind
                    );
                }
                case 689: {
                    var node = (ScriptDom.QueryStoreIntervalLengthOption)fragment;
                    return new QueryStoreIntervalLengthOption(
                        statsIntervalLength: (Literal)FromMutable(node.StatsIntervalLength),
                        optionKind: node.OptionKind
                    );
                }
                case 690: {
                    var node = (ScriptDom.QueryStoreMaxPlansPerQueryOption)fragment;
                    return new QueryStoreMaxPlansPerQueryOption(
                        maxPlansPerQuery: (Literal)FromMutable(node.MaxPlansPerQuery),
                        optionKind: node.OptionKind
                    );
                }
                case 691: {
                    var node = (ScriptDom.QueryStoreMaxStorageSizeOption)fragment;
                    return new QueryStoreMaxStorageSizeOption(
                        maxQdsSize: (Literal)FromMutable(node.MaxQdsSize),
                        optionKind: node.OptionKind
                    );
                }
                case 692: {
                    var node = (ScriptDom.QueryStoreSizeCleanupPolicyOption)fragment;
                    return new QueryStoreSizeCleanupPolicyOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 693: {
                    var node = (ScriptDom.QueryStoreTimeCleanupPolicyOption)fragment;
                    return new QueryStoreTimeCleanupPolicyOption(
                        staleQueryThreshold: (Literal)FromMutable(node.StaleQueryThreshold),
                        optionKind: node.OptionKind
                    );
                }
                case 694: {
                    var node = (ScriptDom.QueueDelayAuditOption)fragment;
                    return new QueueDelayAuditOption(
                        delay: (Literal)FromMutable(node.Delay),
                        optionKind: node.OptionKind
                    );
                }
                case 695: {
                    var node = (ScriptDom.QueueExecuteAsOption)fragment;
                    return new QueueExecuteAsOption(
                        optionValue: (ExecuteAsClause)FromMutable(node.OptionValue),
                        optionKind: node.OptionKind
                    );
                }
                case 696: {
                    var node = (ScriptDom.QueueOption)fragment;
                    return new QueueOption(
                        optionKind: node.OptionKind
                    );
                }
                case 697: {
                    var node = (ScriptDom.QueueProcedureOption)fragment;
                    return new QueueProcedureOption(
                        optionValue: (SchemaObjectName)FromMutable(node.OptionValue),
                        optionKind: node.OptionKind
                    );
                }
                case 698: {
                    var node = (ScriptDom.QueueStateOption)fragment;
                    return new QueueStateOption(
                        optionState: node.OptionState,
                        optionKind: node.OptionKind
                    );
                }
                case 699: {
                    var node = (ScriptDom.QueueValueOption)fragment;
                    return new QueueValueOption(
                        optionValue: (ValueExpression)FromMutable(node.OptionValue),
                        optionKind: node.OptionKind
                    );
                }
                case 700: {
                    var node = (ScriptDom.RaiseErrorLegacyStatement)fragment;
                    return new RaiseErrorLegacyStatement(
                        firstParameter: (ScalarExpression)FromMutable(node.FirstParameter),
                        secondParameter: (ValueExpression)FromMutable(node.SecondParameter)
                    );
                }
                case 701: {
                    var node = (ScriptDom.RaiseErrorStatement)fragment;
                    return new RaiseErrorStatement(
                        firstParameter: (ScalarExpression)FromMutable(node.FirstParameter),
                        secondParameter: (ScalarExpression)FromMutable(node.SecondParameter),
                        thirdParameter: (ScalarExpression)FromMutable(node.ThirdParameter),
                        optionalParameters: node.OptionalParameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        raiseErrorOptions: node.RaiseErrorOptions
                    );
                }
                case 702: {
                    var node = (ScriptDom.ReadOnlyForClause)fragment;
                    return new ReadOnlyForClause(
                        
                    );
                }
                case 703: {
                    var node = (ScriptDom.ReadTextStatement)fragment;
                    return new ReadTextStatement(
                        column: (ColumnReferenceExpression)FromMutable(node.Column),
                        textPointer: (ValueExpression)FromMutable(node.TextPointer),
                        offset: (ValueExpression)FromMutable(node.Offset),
                        size: (ValueExpression)FromMutable(node.Size),
                        holdLock: node.HoldLock
                    );
                }
                case 704: {
                    var node = (ScriptDom.RealLiteral)fragment;
                    return new RealLiteral(
                        @value: node.Value,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 705: {
                    var node = (ScriptDom.ReceiveStatement)fragment;
                    return new ReceiveStatement(
                        top: (ScalarExpression)FromMutable(node.Top),
                        selectElements: node.SelectElements.SelectList(c => (SelectElement)FromMutable(c)),
                        queue: (SchemaObjectName)FromMutable(node.Queue),
                        into: (VariableTableReference)FromMutable(node.Into),
                        where: (ValueExpression)FromMutable(node.Where),
                        isConversationGroupIdWhere: node.IsConversationGroupIdWhere
                    );
                }
                case 706: {
                    var node = (ScriptDom.ReconfigureStatement)fragment;
                    return new ReconfigureStatement(
                        withOverride: node.WithOverride
                    );
                }
                case 707: {
                    var node = (ScriptDom.RecoveryDatabaseOption)fragment;
                    return new RecoveryDatabaseOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 708: {
                    var node = (ScriptDom.RemoteDataArchiveAlterTableOption)fragment;
                    return new RemoteDataArchiveAlterTableOption(
                        rdaTableOption: node.RdaTableOption,
                        migrationState: node.MigrationState,
                        isMigrationStateSpecified: node.IsMigrationStateSpecified,
                        isFilterPredicateSpecified: node.IsFilterPredicateSpecified,
                        filterPredicate: (FunctionCall)FromMutable(node.FilterPredicate),
                        optionKind: node.OptionKind
                    );
                }
                case 709: {
                    var node = (ScriptDom.RemoteDataArchiveDatabaseOption)fragment;
                    return new RemoteDataArchiveDatabaseOption(
                        optionState: node.OptionState,
                        settings: node.Settings.SelectList(c => (RemoteDataArchiveDatabaseSetting)FromMutable(c)),
                        optionKind: node.OptionKind
                    );
                }
                case 710: {
                    var node = (ScriptDom.RemoteDataArchiveDbCredentialSetting)fragment;
                    return new RemoteDataArchiveDbCredentialSetting(
                        credential: (Identifier)FromMutable(node.Credential),
                        settingKind: node.SettingKind
                    );
                }
                case 711: {
                    var node = (ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting)fragment;
                    return new RemoteDataArchiveDbFederatedServiceAccountSetting(
                        isOn: node.IsOn,
                        settingKind: node.SettingKind
                    );
                }
                case 712: {
                    var node = (ScriptDom.RemoteDataArchiveDbServerSetting)fragment;
                    return new RemoteDataArchiveDbServerSetting(
                        server: (StringLiteral)FromMutable(node.Server),
                        settingKind: node.SettingKind
                    );
                }
                case 713: {
                    var node = (ScriptDom.RemoteDataArchiveTableOption)fragment;
                    return new RemoteDataArchiveTableOption(
                        rdaTableOption: node.RdaTableOption,
                        migrationState: node.MigrationState,
                        optionKind: node.OptionKind
                    );
                }
                case 714: {
                    var node = (ScriptDom.RenameAlterRoleAction)fragment;
                    return new RenameAlterRoleAction(
                        newName: (Identifier)FromMutable(node.NewName)
                    );
                }
                case 715: {
                    var node = (ScriptDom.RenameEntityStatement)fragment;
                    return new RenameEntityStatement(
                        renameEntityType: node.RenameEntityType,
                        separatorType: node.SeparatorType,
                        oldName: (SchemaObjectName)FromMutable(node.OldName),
                        newName: (Identifier)FromMutable(node.NewName)
                    );
                }
                case 716: {
                    var node = (ScriptDom.ResampleStatisticsOption)fragment;
                    return new ResampleStatisticsOption(
                        partitions: node.Partitions.SelectList(c => (StatisticsPartitionRange)FromMutable(c)),
                        optionKind: node.OptionKind
                    );
                }
                case 717: {
                    var node = (ScriptDom.ResourcePoolAffinitySpecification)fragment;
                    return new ResourcePoolAffinitySpecification(
                        affinityType: node.AffinityType,
                        parameterValue: (Literal)FromMutable(node.ParameterValue),
                        isAuto: node.IsAuto,
                        poolAffinityRanges: node.PoolAffinityRanges.SelectList(c => (LiteralRange)FromMutable(c))
                    );
                }
                case 718: {
                    var node = (ScriptDom.ResourcePoolParameter)fragment;
                    return new ResourcePoolParameter(
                        parameterType: node.ParameterType,
                        parameterValue: (Literal)FromMutable(node.ParameterValue),
                        affinitySpecification: (ResourcePoolAffinitySpecification)FromMutable(node.AffinitySpecification)
                    );
                }
                case 719: {
                    var node = (ScriptDom.ResourcePoolStatement)fragment;
                    return new ResourcePoolStatement(
                        name: (Identifier)FromMutable(node.Name),
                        resourcePoolParameters: node.ResourcePoolParameters.SelectList(c => (ResourcePoolParameter)FromMutable(c))
                    );
                }
                case 720: {
                    var node = (ScriptDom.RestoreMasterKeyStatement)fragment;
                    return new RestoreMasterKeyStatement(
                        isForce: node.IsForce,
                        encryptionPassword: (Literal)FromMutable(node.EncryptionPassword),
                        file: (Literal)FromMutable(node.File),
                        password: (Literal)FromMutable(node.Password)
                    );
                }
                case 721: {
                    var node = (ScriptDom.RestoreOption)fragment;
                    return new RestoreOption(
                        optionKind: node.OptionKind
                    );
                }
                case 722: {
                    var node = (ScriptDom.RestoreServiceMasterKeyStatement)fragment;
                    return new RestoreServiceMasterKeyStatement(
                        isForce: node.IsForce,
                        file: (Literal)FromMutable(node.File),
                        password: (Literal)FromMutable(node.Password)
                    );
                }
                case 723: {
                    var node = (ScriptDom.RestoreStatement)fragment;
                    return new RestoreStatement(
                        databaseName: (IdentifierOrValueExpression)FromMutable(node.DatabaseName),
                        devices: node.Devices.SelectList(c => (DeviceInfo)FromMutable(c)),
                        files: node.Files.SelectList(c => (BackupRestoreFileInfo)FromMutable(c)),
                        options: node.Options.SelectList(c => (RestoreOption)FromMutable(c)),
                        kind: node.Kind
                    );
                }
                case 724: {
                    var node = (ScriptDom.ResultColumnDefinition)fragment;
                    return new ResultColumnDefinition(
                        columnDefinition: (ColumnDefinitionBase)FromMutable(node.ColumnDefinition),
                        nullable: (NullableConstraintDefinition)FromMutable(node.Nullable)
                    );
                }
                case 725: {
                    var node = (ScriptDom.ResultSetDefinition)fragment;
                    return new ResultSetDefinition(
                        resultSetType: node.ResultSetType
                    );
                }
                case 726: {
                    var node = (ScriptDom.ResultSetsExecuteOption)fragment;
                    return new ResultSetsExecuteOption(
                        resultSetsOptionKind: node.ResultSetsOptionKind,
                        definitions: node.Definitions.SelectList(c => (ResultSetDefinition)FromMutable(c)),
                        optionKind: node.OptionKind
                    );
                }
                case 727: {
                    var node = (ScriptDom.RetentionDaysAuditTargetOption)fragment;
                    return new RetentionDaysAuditTargetOption(
                        days: (Literal)FromMutable(node.Days),
                        optionKind: node.OptionKind
                    );
                }
                case 728: {
                    var node = (ScriptDom.RetentionPeriodDefinition)fragment;
                    return new RetentionPeriodDefinition(
                        duration: (IntegerLiteral)FromMutable(node.Duration),
                        units: node.Units,
                        isInfinity: node.IsInfinity
                    );
                }
                case 729: {
                    var node = (ScriptDom.ReturnStatement)fragment;
                    return new ReturnStatement(
                        expression: (ScalarExpression)FromMutable(node.Expression)
                    );
                }
                case 730: {
                    var node = (ScriptDom.RevertStatement)fragment;
                    return new RevertStatement(
                        cookie: (ScalarExpression)FromMutable(node.Cookie)
                    );
                }
                case 731: {
                    var node = (ScriptDom.RevokeStatement)fragment;
                    return new RevokeStatement(
                        grantOptionFor: node.GrantOptionFor,
                        cascadeOption: node.CascadeOption,
                        permissions: node.Permissions.SelectList(c => (Permission)FromMutable(c)),
                        securityTargetObject: (SecurityTargetObject)FromMutable(node.SecurityTargetObject),
                        principals: node.Principals.SelectList(c => (SecurityPrincipal)FromMutable(c)),
                        asClause: (Identifier)FromMutable(node.AsClause)
                    );
                }
                case 732: {
                    var node = (ScriptDom.RevokeStatement80)fragment;
                    return new RevokeStatement80(
                        grantOptionFor: node.GrantOptionFor,
                        cascadeOption: node.CascadeOption,
                        asClause: (Identifier)FromMutable(node.AsClause),
                        securityElement80: (SecurityElement80)FromMutable(node.SecurityElement80),
                        securityUserClause80: (SecurityUserClause80)FromMutable(node.SecurityUserClause80)
                    );
                }
                case 733: {
                    var node = (ScriptDom.RightFunctionCall)fragment;
                    return new RightFunctionCall(
                        parameters: node.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 734: {
                    var node = (ScriptDom.RolePayloadOption)fragment;
                    return new RolePayloadOption(
                        role: node.Role,
                        kind: node.Kind
                    );
                }
                case 735: {
                    var node = (ScriptDom.RollbackTransactionStatement)fragment;
                    return new RollbackTransactionStatement(
                        name: (IdentifierOrValueExpression)FromMutable(node.Name)
                    );
                }
                case 736: {
                    var node = (ScriptDom.RollupGroupingSpecification)fragment;
                    return new RollupGroupingSpecification(
                        arguments: node.Arguments.SelectList(c => (GroupingSpecification)FromMutable(c))
                    );
                }
                case 737: {
                    var node = (ScriptDom.RouteOption)fragment;
                    return new RouteOption(
                        optionKind: node.OptionKind,
                        literal: (Literal)FromMutable(node.Literal)
                    );
                }
                case 738: {
                    var node = (ScriptDom.RowValue)fragment;
                    return new RowValue(
                        columnValues: node.ColumnValues.SelectList(c => (ScalarExpression)FromMutable(c))
                    );
                }
                case 739: {
                    var node = (ScriptDom.SaveTransactionStatement)fragment;
                    return new SaveTransactionStatement(
                        name: (IdentifierOrValueExpression)FromMutable(node.Name)
                    );
                }
                case 740: {
                    var node = (ScriptDom.ScalarExpressionDialogOption)fragment;
                    return new ScalarExpressionDialogOption(
                        @value: (ScalarExpression)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 741: {
                    var node = (ScriptDom.ScalarExpressionRestoreOption)fragment;
                    return new ScalarExpressionRestoreOption(
                        @value: (ScalarExpression)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 742: {
                    var node = (ScriptDom.ScalarExpressionSequenceOption)fragment;
                    return new ScalarExpressionSequenceOption(
                        optionValue: (ScalarExpression)FromMutable(node.OptionValue),
                        optionKind: node.OptionKind,
                        noValue: node.NoValue
                    );
                }
                case 743: {
                    var node = (ScriptDom.ScalarExpressionSnippet)fragment;
                    return new ScalarExpressionSnippet(
                        script: node.Script
                    );
                }
                case 744: {
                    var node = (ScriptDom.ScalarFunctionReturnType)fragment;
                    return new ScalarFunctionReturnType(
                        dataType: (DataTypeReference)FromMutable(node.DataType)
                    );
                }
                case 745: {
                    var node = (ScriptDom.ScalarSubquery)fragment;
                    return new ScalarSubquery(
                        queryExpression: (QueryExpression)FromMutable(node.QueryExpression),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 746: {
                    var node = (ScriptDom.SchemaDeclarationItem)fragment;
                    return new SchemaDeclarationItem(
                        columnDefinition: (ColumnDefinitionBase)FromMutable(node.ColumnDefinition),
                        mapping: (ValueExpression)FromMutable(node.Mapping)
                    );
                }
                case 747: {
                    var node = (ScriptDom.SchemaDeclarationItemOpenjson)fragment;
                    return new SchemaDeclarationItemOpenjson(
                        asJson: node.AsJson,
                        columnDefinition: (ColumnDefinitionBase)FromMutable(node.ColumnDefinition),
                        mapping: (ValueExpression)FromMutable(node.Mapping)
                    );
                }
                case 748: {
                    var node = (ScriptDom.SchemaObjectFunctionTableReference)fragment;
                    return new SchemaObjectFunctionTableReference(
                        schemaObject: (SchemaObjectName)FromMutable(node.SchemaObject),
                        parameters: node.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 749: {
                    var node = (ScriptDom.SchemaObjectName)fragment;
                    return new SchemaObjectName(
                        identifiers: node.Identifiers.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 750: {
                    var node = (ScriptDom.SchemaObjectNameOrValueExpression)fragment;
                    return new SchemaObjectNameOrValueExpression(
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName),
                        valueExpression: (ValueExpression)FromMutable(node.ValueExpression)
                    );
                }
                case 751: {
                    var node = (ScriptDom.SchemaObjectNameSnippet)fragment;
                    return new SchemaObjectNameSnippet(
                        script: node.Script,
                        identifiers: node.Identifiers.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 752: {
                    var node = (ScriptDom.SchemaObjectResultSetDefinition)fragment;
                    return new SchemaObjectResultSetDefinition(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        resultSetType: node.ResultSetType
                    );
                }
                case 753: {
                    var node = (ScriptDom.SchemaPayloadOption)fragment;
                    return new SchemaPayloadOption(
                        isStandard: node.IsStandard,
                        kind: node.Kind
                    );
                }
                case 754: {
                    var node = (ScriptDom.SearchedCaseExpression)fragment;
                    return new SearchedCaseExpression(
                        whenClauses: node.WhenClauses.SelectList(c => (SearchedWhenClause)FromMutable(c)),
                        elseExpression: (ScalarExpression)FromMutable(node.ElseExpression),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 755: {
                    var node = (ScriptDom.SearchedWhenClause)fragment;
                    return new SearchedWhenClause(
                        whenExpression: (BooleanExpression)FromMutable(node.WhenExpression),
                        thenExpression: (ScalarExpression)FromMutable(node.ThenExpression)
                    );
                }
                case 756: {
                    var node = (ScriptDom.SearchPropertyListFullTextIndexOption)fragment;
                    return new SearchPropertyListFullTextIndexOption(
                        isOff: node.IsOff,
                        propertyListName: (Identifier)FromMutable(node.PropertyListName),
                        optionKind: node.OptionKind
                    );
                }
                case 757: {
                    var node = (ScriptDom.SecondaryRoleReplicaOption)fragment;
                    return new SecondaryRoleReplicaOption(
                        allowConnections: node.AllowConnections,
                        optionKind: node.OptionKind
                    );
                }
                case 758: {
                    var node = (ScriptDom.SecurityPolicyOption)fragment;
                    return new SecurityPolicyOption(
                        optionKind: node.OptionKind,
                        optionState: node.OptionState
                    );
                }
                case 759: {
                    var node = (ScriptDom.SecurityPredicateAction)fragment;
                    return new SecurityPredicateAction(
                        actionType: node.ActionType,
                        securityPredicateType: node.SecurityPredicateType,
                        functionCall: (FunctionCall)FromMutable(node.FunctionCall),
                        targetObjectName: (SchemaObjectName)FromMutable(node.TargetObjectName),
                        securityPredicateOperation: node.SecurityPredicateOperation
                    );
                }
                case 760: {
                    var node = (ScriptDom.SecurityPrincipal)fragment;
                    return new SecurityPrincipal(
                        principalType: node.PrincipalType,
                        identifier: (Identifier)FromMutable(node.Identifier)
                    );
                }
                case 761: {
                    var node = (ScriptDom.SecurityTargetObject)fragment;
                    return new SecurityTargetObject(
                        objectKind: node.ObjectKind,
                        objectName: (SecurityTargetObjectName)FromMutable(node.ObjectName),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c))
                    );
                }
                case 762: {
                    var node = (ScriptDom.SecurityTargetObjectName)fragment;
                    return new SecurityTargetObjectName(
                        multiPartIdentifier: (MultiPartIdentifier)FromMutable(node.MultiPartIdentifier)
                    );
                }
                case 763: {
                    var node = (ScriptDom.SecurityUserClause80)fragment;
                    return new SecurityUserClause80(
                        users: node.Users.SelectList(c => (Identifier)FromMutable(c)),
                        userType80: node.UserType80
                    );
                }
                case 764: {
                    var node = (ScriptDom.SelectFunctionReturnType)fragment;
                    return new SelectFunctionReturnType(
                        selectStatement: (SelectStatement)FromMutable(node.SelectStatement)
                    );
                }
                case 765: {
                    var node = (ScriptDom.SelectInsertSource)fragment;
                    return new SelectInsertSource(
                        select: (QueryExpression)FromMutable(node.Select)
                    );
                }
                case 766: {
                    var node = (ScriptDom.SelectiveXmlIndexPromotedPath)fragment;
                    return new SelectiveXmlIndexPromotedPath(
                        name: (Identifier)FromMutable(node.Name),
                        path: (Literal)FromMutable(node.Path),
                        sQLDataType: (DataTypeReference)FromMutable(node.SQLDataType),
                        xQueryDataType: (Literal)FromMutable(node.XQueryDataType),
                        maxLength: (IntegerLiteral)FromMutable(node.MaxLength),
                        isSingleton: node.IsSingleton
                    );
                }
                case 767: {
                    var node = (ScriptDom.SelectScalarExpression)fragment;
                    return new SelectScalarExpression(
                        expression: (ScalarExpression)FromMutable(node.Expression),
                        columnName: (IdentifierOrValueExpression)FromMutable(node.ColumnName)
                    );
                }
                case 768: {
                    var node = (ScriptDom.SelectSetVariable)fragment;
                    return new SelectSetVariable(
                        variable: (VariableReference)FromMutable(node.Variable),
                        expression: (ScalarExpression)FromMutable(node.Expression),
                        assignmentKind: node.AssignmentKind
                    );
                }
                case 769: {
                    var node = (ScriptDom.SelectStarExpression)fragment;
                    return new SelectStarExpression(
                        qualifier: (MultiPartIdentifier)FromMutable(node.Qualifier)
                    );
                }
                case 770: {
                    var node = (ScriptDom.SelectStatement)fragment;
                    return new SelectStatement(
                        queryExpression: (QueryExpression)FromMutable(node.QueryExpression),
                        into: (SchemaObjectName)FromMutable(node.Into),
                        on: (Identifier)FromMutable(node.On),
                        computeClauses: node.ComputeClauses.SelectList(c => (ComputeClause)FromMutable(c)),
                        withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable(node.WithCtesAndXmlNamespaces),
                        optimizerHints: node.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 771: {
                    var node = (ScriptDom.SelectStatementSnippet)fragment;
                    return new SelectStatementSnippet(
                        script: node.Script,
                        queryExpression: (QueryExpression)FromMutable(node.QueryExpression),
                        into: (SchemaObjectName)FromMutable(node.Into),
                        on: (Identifier)FromMutable(node.On),
                        computeClauses: node.ComputeClauses.SelectList(c => (ComputeClause)FromMutable(c)),
                        withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable(node.WithCtesAndXmlNamespaces),
                        optimizerHints: node.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 772: {
                    var node = (ScriptDom.SemanticTableReference)fragment;
                    return new SemanticTableReference(
                        semanticFunctionType: node.SemanticFunctionType,
                        tableName: (SchemaObjectName)FromMutable(node.TableName),
                        columns: node.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        sourceKey: (ScalarExpression)FromMutable(node.SourceKey),
                        matchedColumn: (ColumnReferenceExpression)FromMutable(node.MatchedColumn),
                        matchedKey: (ScalarExpression)FromMutable(node.MatchedKey),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 773: {
                    var node = (ScriptDom.SendStatement)fragment;
                    return new SendStatement(
                        conversationHandles: node.ConversationHandles.SelectList(c => (ScalarExpression)FromMutable(c)),
                        messageTypeName: (IdentifierOrValueExpression)FromMutable(node.MessageTypeName),
                        messageBody: (ScalarExpression)FromMutable(node.MessageBody)
                    );
                }
                case 774: {
                    var node = (ScriptDom.SensitivityClassificationOption)fragment;
                    return new SensitivityClassificationOption(
                        type: node.Type,
                        @value: (Literal)FromMutable(node.Value)
                    );
                }
                case 775: {
                    var node = (ScriptDom.SequenceOption)fragment;
                    return new SequenceOption(
                        optionKind: node.OptionKind,
                        noValue: node.NoValue
                    );
                }
                case 776: {
                    var node = (ScriptDom.ServiceContract)fragment;
                    return new ServiceContract(
                        name: (Identifier)FromMutable(node.Name),
                        action: node.Action
                    );
                }
                case 777: {
                    var node = (ScriptDom.SessionTimeoutPayloadOption)fragment;
                    return new SessionTimeoutPayloadOption(
                        isNever: node.IsNever,
                        timeout: (Literal)FromMutable(node.Timeout),
                        kind: node.Kind
                    );
                }
                case 778: {
                    var node = (ScriptDom.SetCommandStatement)fragment;
                    return new SetCommandStatement(
                        commands: node.Commands.SelectList(c => (SetCommand)FromMutable(c))
                    );
                }
                case 779: {
                    var node = (ScriptDom.SetErrorLevelStatement)fragment;
                    return new SetErrorLevelStatement(
                        level: (ScalarExpression)FromMutable(node.Level)
                    );
                }
                case 780: {
                    var node = (ScriptDom.SetFipsFlaggerCommand)fragment;
                    return new SetFipsFlaggerCommand(
                        complianceLevel: node.ComplianceLevel
                    );
                }
                case 781: {
                    var node = (ScriptDom.SetIdentityInsertStatement)fragment;
                    return new SetIdentityInsertStatement(
                        table: (SchemaObjectName)FromMutable(node.Table),
                        isOn: node.IsOn
                    );
                }
                case 782: {
                    var node = (ScriptDom.SetOffsetsStatement)fragment;
                    return new SetOffsetsStatement(
                        options: node.Options,
                        isOn: node.IsOn
                    );
                }
                case 783: {
                    var node = (ScriptDom.SetRowCountStatement)fragment;
                    return new SetRowCountStatement(
                        numberRows: (ValueExpression)FromMutable(node.NumberRows)
                    );
                }
                case 784: {
                    var node = (ScriptDom.SetSearchPropertyListAlterFullTextIndexAction)fragment;
                    return new SetSearchPropertyListAlterFullTextIndexAction(
                        searchPropertyListOption: (SearchPropertyListFullTextIndexOption)FromMutable(node.SearchPropertyListOption),
                        withNoPopulation: node.WithNoPopulation
                    );
                }
                case 785: {
                    var node = (ScriptDom.SetStatisticsStatement)fragment;
                    return new SetStatisticsStatement(
                        options: node.Options,
                        isOn: node.IsOn
                    );
                }
                case 786: {
                    var node = (ScriptDom.SetStopListAlterFullTextIndexAction)fragment;
                    return new SetStopListAlterFullTextIndexAction(
                        stopListOption: (StopListFullTextIndexOption)FromMutable(node.StopListOption),
                        withNoPopulation: node.WithNoPopulation
                    );
                }
                case 787: {
                    var node = (ScriptDom.SetTextSizeStatement)fragment;
                    return new SetTextSizeStatement(
                        textSize: (ScalarExpression)FromMutable(node.TextSize)
                    );
                }
                case 788: {
                    var node = (ScriptDom.SetTransactionIsolationLevelStatement)fragment;
                    return new SetTransactionIsolationLevelStatement(
                        level: node.Level
                    );
                }
                case 789: {
                    var node = (ScriptDom.SetUserStatement)fragment;
                    return new SetUserStatement(
                        userName: (ValueExpression)FromMutable(node.UserName),
                        withNoReset: node.WithNoReset
                    );
                }
                case 790: {
                    var node = (ScriptDom.SetVariableStatement)fragment;
                    return new SetVariableStatement(
                        variable: (VariableReference)FromMutable(node.Variable),
                        separatorType: node.SeparatorType,
                        identifier: (Identifier)FromMutable(node.Identifier),
                        functionCallExists: node.FunctionCallExists,
                        parameters: node.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        expression: (ScalarExpression)FromMutable(node.Expression),
                        cursorDefinition: (CursorDefinition)FromMutable(node.CursorDefinition),
                        assignmentKind: node.AssignmentKind
                    );
                }
                case 791: {
                    var node = (ScriptDom.ShutdownStatement)fragment;
                    return new ShutdownStatement(
                        withNoWait: node.WithNoWait
                    );
                }
                case 792: {
                    var node = (ScriptDom.SimpleAlterFullTextIndexAction)fragment;
                    return new SimpleAlterFullTextIndexAction(
                        actionKind: node.ActionKind
                    );
                }
                case 793: {
                    var node = (ScriptDom.SimpleCaseExpression)fragment;
                    return new SimpleCaseExpression(
                        inputExpression: (ScalarExpression)FromMutable(node.InputExpression),
                        whenClauses: node.WhenClauses.SelectList(c => (SimpleWhenClause)FromMutable(c)),
                        elseExpression: (ScalarExpression)FromMutable(node.ElseExpression),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 794: {
                    var node = (ScriptDom.SimpleWhenClause)fragment;
                    return new SimpleWhenClause(
                        whenExpression: (ScalarExpression)FromMutable(node.WhenExpression),
                        thenExpression: (ScalarExpression)FromMutable(node.ThenExpression)
                    );
                }
                case 795: {
                    var node = (ScriptDom.SingleValueTypeCopyOption)fragment;
                    return new SingleValueTypeCopyOption(
                        singleValue: (IdentifierOrValueExpression)FromMutable(node.SingleValue)
                    );
                }
                case 796: {
                    var node = (ScriptDom.SizeFileDeclarationOption)fragment;
                    return new SizeFileDeclarationOption(
                        size: (Literal)FromMutable(node.Size),
                        units: node.Units,
                        optionKind: node.OptionKind
                    );
                }
                case 797: {
                    var node = (ScriptDom.SoapMethod)fragment;
                    return new SoapMethod(
                        alias: (Literal)FromMutable(node.Alias),
                        @namespace: (Literal)FromMutable(node.Namespace),
                        action: node.Action,
                        name: (Literal)FromMutable(node.Name),
                        format: node.Format,
                        schema: node.Schema,
                        kind: node.Kind
                    );
                }
                case 798: {
                    var node = (ScriptDom.SourceDeclaration)fragment;
                    return new SourceDeclaration(
                        @value: (EventSessionObjectName)FromMutable(node.Value)
                    );
                }
                case 799: {
                    var node = (ScriptDom.SpatialIndexRegularOption)fragment;
                    return new SpatialIndexRegularOption(
                        option: (IndexOption)FromMutable(node.Option)
                    );
                }
                case 800: {
                    var node = (ScriptDom.SqlCommandIdentifier)fragment;
                    return new SqlCommandIdentifier(
                        @value: node.Value,
                        quoteType: node.QuoteType
                    );
                }
                case 801: {
                    var node = (ScriptDom.SqlDataTypeReference)fragment;
                    return new SqlDataTypeReference(
                        sqlDataTypeOption: node.SqlDataTypeOption,
                        parameters: node.Parameters.SelectList(c => (Literal)FromMutable(c)),
                        name: (SchemaObjectName)FromMutable(node.Name)
                    );
                }
                case 802: {
                    var node = (ScriptDom.StateAuditOption)fragment;
                    return new StateAuditOption(
                        @value: node.Value,
                        optionKind: node.OptionKind
                    );
                }
                case 803: {
                    var node = (ScriptDom.StatementList)fragment;
                    return new StatementList(
                        statements: node.Statements.SelectList(c => (TSqlStatement)FromMutable(c))
                    );
                }
                case 804: {
                    var node = (ScriptDom.StatementListSnippet)fragment;
                    return new StatementListSnippet(
                        script: node.Script,
                        statements: node.Statements.SelectList(c => (TSqlStatement)FromMutable(c))
                    );
                }
                case 805: {
                    var node = (ScriptDom.StatisticsOption)fragment;
                    return new StatisticsOption(
                        optionKind: node.OptionKind
                    );
                }
                case 806: {
                    var node = (ScriptDom.StatisticsPartitionRange)fragment;
                    return new StatisticsPartitionRange(
                        from: (IntegerLiteral)FromMutable(node.From),
                        to: (IntegerLiteral)FromMutable(node.To)
                    );
                }
                case 807: {
                    var node = (ScriptDom.StopListFullTextIndexOption)fragment;
                    return new StopListFullTextIndexOption(
                        isOff: node.IsOff,
                        stopListName: (Identifier)FromMutable(node.StopListName),
                        optionKind: node.OptionKind
                    );
                }
                case 808: {
                    var node = (ScriptDom.StopRestoreOption)fragment;
                    return new StopRestoreOption(
                        mark: (ValueExpression)FromMutable(node.Mark),
                        after: (ValueExpression)FromMutable(node.After),
                        isStopAt: node.IsStopAt,
                        optionKind: node.OptionKind
                    );
                }
                case 809: {
                    var node = (ScriptDom.StringLiteral)fragment;
                    return new StringLiteral(
                        isNational: node.IsNational,
                        isLargeObject: node.IsLargeObject,
                        @value: node.Value,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 810: {
                    var node = (ScriptDom.SubqueryComparisonPredicate)fragment;
                    return new SubqueryComparisonPredicate(
                        expression: (ScalarExpression)FromMutable(node.Expression),
                        comparisonType: node.ComparisonType,
                        subquery: (ScalarSubquery)FromMutable(node.Subquery),
                        subqueryComparisonPredicateType: node.SubqueryComparisonPredicateType
                    );
                }
                case 811: {
                    var node = (ScriptDom.SystemTimePeriodDefinition)fragment;
                    return new SystemTimePeriodDefinition(
                        startTimeColumn: (Identifier)FromMutable(node.StartTimeColumn),
                        endTimeColumn: (Identifier)FromMutable(node.EndTimeColumn)
                    );
                }
                case 812: {
                    var node = (ScriptDom.SystemVersioningTableOption)fragment;
                    return new SystemVersioningTableOption(
                        optionState: node.OptionState,
                        consistencyCheckEnabled: node.ConsistencyCheckEnabled,
                        historyTable: (SchemaObjectName)FromMutable(node.HistoryTable),
                        retentionPeriod: (RetentionPeriodDefinition)FromMutable(node.RetentionPeriod),
                        optionKind: node.OptionKind
                    );
                }
                case 813: {
                    var node = (ScriptDom.TableClusteredIndexType)fragment;
                    return new TableClusteredIndexType(
                        columns: node.Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                        columnStore: node.ColumnStore,
                        orderedColumns: node.OrderedColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
                    );
                }
                case 814: {
                    var node = (ScriptDom.TableDataCompressionOption)fragment;
                    return new TableDataCompressionOption(
                        dataCompressionOption: (DataCompressionOption)FromMutable(node.DataCompressionOption),
                        optionKind: node.OptionKind
                    );
                }
                case 815: {
                    var node = (ScriptDom.TableDefinition)fragment;
                    return new TableDefinition(
                        columnDefinitions: node.ColumnDefinitions.SelectList(c => (ColumnDefinition)FromMutable(c)),
                        tableConstraints: node.TableConstraints.SelectList(c => (ConstraintDefinition)FromMutable(c)),
                        indexes: node.Indexes.SelectList(c => (IndexDefinition)FromMutable(c)),
                        systemTimePeriod: (SystemTimePeriodDefinition)FromMutable(node.SystemTimePeriod)
                    );
                }
                case 816: {
                    var node = (ScriptDom.TableDistributionOption)fragment;
                    return new TableDistributionOption(
                        @value: (TableDistributionPolicy)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 817: {
                    var node = (ScriptDom.TableHashDistributionPolicy)fragment;
                    return new TableHashDistributionPolicy(
                        distributionColumn: (Identifier)FromMutable(node.DistributionColumn)
                    );
                }
                case 818: {
                    var node = (ScriptDom.TableHint)fragment;
                    return new TableHint(
                        hintKind: node.HintKind
                    );
                }
                case 819: {
                    var node = (ScriptDom.TableHintsOptimizerHint)fragment;
                    return new TableHintsOptimizerHint(
                        objectName: (SchemaObjectName)FromMutable(node.ObjectName),
                        tableHints: node.TableHints.SelectList(c => (TableHint)FromMutable(c)),
                        hintKind: node.HintKind
                    );
                }
                case 820: {
                    var node = (ScriptDom.TableIndexOption)fragment;
                    return new TableIndexOption(
                        @value: (TableIndexType)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 821: {
                    var node = (ScriptDom.TableNonClusteredIndexType)fragment;
                    return new TableNonClusteredIndexType(
                        
                    );
                }
                case 822: {
                    var node = (ScriptDom.TablePartitionOption)fragment;
                    return new TablePartitionOption(
                        partitionColumn: (Identifier)FromMutable(node.PartitionColumn),
                        partitionOptionSpecs: (TablePartitionOptionSpecifications)FromMutable(node.PartitionOptionSpecs),
                        optionKind: node.OptionKind
                    );
                }
                case 823: {
                    var node = (ScriptDom.TablePartitionOptionSpecifications)fragment;
                    return new TablePartitionOptionSpecifications(
                        range: node.Range,
                        boundaryValues: node.BoundaryValues.SelectList(c => (ScalarExpression)FromMutable(c))
                    );
                }
                case 824: {
                    var node = (ScriptDom.TableReplicateDistributionPolicy)fragment;
                    return new TableReplicateDistributionPolicy(
                        
                    );
                }
                case 825: {
                    var node = (ScriptDom.TableRoundRobinDistributionPolicy)fragment;
                    return new TableRoundRobinDistributionPolicy(
                        
                    );
                }
                case 826: {
                    var node = (ScriptDom.TableSampleClause)fragment;
                    return new TableSampleClause(
                        system: node.System,
                        sampleNumber: (ScalarExpression)FromMutable(node.SampleNumber),
                        tableSampleClauseOption: node.TableSampleClauseOption,
                        repeatSeed: (ScalarExpression)FromMutable(node.RepeatSeed)
                    );
                }
                case 827: {
                    var node = (ScriptDom.TableValuedFunctionReturnType)fragment;
                    return new TableValuedFunctionReturnType(
                        declareTableVariableBody: (DeclareTableVariableBody)FromMutable(node.DeclareTableVariableBody)
                    );
                }
                case 828: {
                    var node = (ScriptDom.TableXmlCompressionOption)fragment;
                    return new TableXmlCompressionOption(
                        xmlCompressionOption: (XmlCompressionOption)FromMutable(node.XmlCompressionOption),
                        optionKind: node.OptionKind
                    );
                }
                case 829: {
                    var node = (ScriptDom.TargetDeclaration)fragment;
                    return new TargetDeclaration(
                        objectName: (EventSessionObjectName)FromMutable(node.ObjectName),
                        targetDeclarationParameters: node.TargetDeclarationParameters.SelectList(c => (EventDeclarationSetParameter)FromMutable(c))
                    );
                }
                case 830: {
                    var node = (ScriptDom.TargetRecoveryTimeDatabaseOption)fragment;
                    return new TargetRecoveryTimeDatabaseOption(
                        recoveryTime: (Literal)FromMutable(node.RecoveryTime),
                        unit: node.Unit,
                        optionKind: node.OptionKind
                    );
                }
                case 831: {
                    var node = (ScriptDom.TemporalClause)fragment;
                    return new TemporalClause(
                        temporalClauseType: node.TemporalClauseType,
                        startTime: (ScalarExpression)FromMutable(node.StartTime),
                        endTime: (ScalarExpression)FromMutable(node.EndTime)
                    );
                }
                case 832: {
                    var node = (ScriptDom.ThrowStatement)fragment;
                    return new ThrowStatement(
                        errorNumber: (ValueExpression)FromMutable(node.ErrorNumber),
                        message: (ValueExpression)FromMutable(node.Message),
                        state: (ValueExpression)FromMutable(node.State)
                    );
                }
                case 833: {
                    var node = (ScriptDom.TopRowFilter)fragment;
                    return new TopRowFilter(
                        expression: (ScalarExpression)FromMutable(node.Expression),
                        percent: node.Percent,
                        withTies: node.WithTies
                    );
                }
                case 834: {
                    var node = (ScriptDom.TriggerAction)fragment;
                    return new TriggerAction(
                        triggerActionType: node.TriggerActionType,
                        eventTypeGroup: (EventTypeGroupContainer)FromMutable(node.EventTypeGroup)
                    );
                }
                case 835: {
                    var node = (ScriptDom.TriggerObject)fragment;
                    return new TriggerObject(
                        name: (SchemaObjectName)FromMutable(node.Name),
                        triggerScope: node.TriggerScope
                    );
                }
                case 836: {
                    var node = (ScriptDom.TriggerOption)fragment;
                    return new TriggerOption(
                        optionKind: node.OptionKind
                    );
                }
                case 837: {
                    var node = (ScriptDom.TruncateTableStatement)fragment;
                    return new TruncateTableStatement(
                        tableName: (SchemaObjectName)FromMutable(node.TableName),
                        partitionRanges: node.PartitionRanges.SelectList(c => (CompressionPartitionRange)FromMutable(c))
                    );
                }
                case 838: {
                    var node = (ScriptDom.TruncateTargetTableSwitchOption)fragment;
                    return new TruncateTargetTableSwitchOption(
                        truncateTarget: node.TruncateTarget,
                        optionKind: node.OptionKind
                    );
                }
                case 839: {
                    var node = (ScriptDom.TryCastCall)fragment;
                    return new TryCastCall(
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        parameter: (ScalarExpression)FromMutable(node.Parameter),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 840: {
                    var node = (ScriptDom.TryCatchStatement)fragment;
                    return new TryCatchStatement(
                        tryStatements: (StatementList)FromMutable(node.TryStatements),
                        catchStatements: (StatementList)FromMutable(node.CatchStatements)
                    );
                }
                case 841: {
                    var node = (ScriptDom.TryConvertCall)fragment;
                    return new TryConvertCall(
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        parameter: (ScalarExpression)FromMutable(node.Parameter),
                        style: (ScalarExpression)FromMutable(node.Style),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 842: {
                    var node = (ScriptDom.TryParseCall)fragment;
                    return new TryParseCall(
                        stringValue: (ScalarExpression)FromMutable(node.StringValue),
                        dataType: (DataTypeReference)FromMutable(node.DataType),
                        culture: (ScalarExpression)FromMutable(node.Culture),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 843: {
                    var node = (ScriptDom.TSEqualCall)fragment;
                    return new TSEqualCall(
                        firstExpression: (ScalarExpression)FromMutable(node.FirstExpression),
                        secondExpression: (ScalarExpression)FromMutable(node.SecondExpression)
                    );
                }
                case 844: {
                    var node = (ScriptDom.TSqlBatch)fragment;
                    return new TSqlBatch(
                        statements: node.Statements.SelectList(c => (TSqlStatement)FromMutable(c))
                    );
                }
                case 845: {
                    var node = (ScriptDom.TSqlFragmentSnippet)fragment;
                    return new TSqlFragmentSnippet(
                        script: node.Script
                    );
                }
                case 846: {
                    var node = (ScriptDom.TSqlScript)fragment;
                    return new TSqlScript(
                        batches: node.Batches.SelectList(c => (TSqlBatch)FromMutable(c))
                    );
                }
                case 847: {
                    var node = (ScriptDom.TSqlStatementSnippet)fragment;
                    return new TSqlStatementSnippet(
                        script: node.Script
                    );
                }
                case 848: {
                    var node = (ScriptDom.UnaryExpression)fragment;
                    return new UnaryExpression(
                        unaryExpressionType: node.UnaryExpressionType,
                        expression: (ScalarExpression)FromMutable(node.Expression)
                    );
                }
                case 849: {
                    var node = (ScriptDom.UniqueConstraintDefinition)fragment;
                    return new UniqueConstraintDefinition(
                        clustered: node.Clustered,
                        isPrimaryKey: node.IsPrimaryKey,
                        isEnforced: node.IsEnforced,
                        columns: node.Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                        indexOptions: node.IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                        onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable(node.OnFileGroupOrPartitionScheme),
                        indexType: (IndexType)FromMutable(node.IndexType),
                        fileStreamOn: (IdentifierOrValueExpression)FromMutable(node.FileStreamOn),
                        constraintIdentifier: (Identifier)FromMutable(node.ConstraintIdentifier)
                    );
                }
                case 850: {
                    var node = (ScriptDom.UnpivotedTableReference)fragment;
                    return new UnpivotedTableReference(
                        tableReference: (TableReference)FromMutable(node.TableReference),
                        inColumns: node.InColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                        pivotColumn: (Identifier)FromMutable(node.PivotColumn),
                        valueColumn: (Identifier)FromMutable(node.ValueColumn),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 851: {
                    var node = (ScriptDom.UnqualifiedJoin)fragment;
                    return new UnqualifiedJoin(
                        unqualifiedJoinType: node.UnqualifiedJoinType,
                        firstTableReference: (TableReference)FromMutable(node.FirstTableReference),
                        secondTableReference: (TableReference)FromMutable(node.SecondTableReference)
                    );
                }
                case 852: {
                    var node = (ScriptDom.UpdateCall)fragment;
                    return new UpdateCall(
                        identifier: (Identifier)FromMutable(node.Identifier)
                    );
                }
                case 853: {
                    var node = (ScriptDom.UpdateForClause)fragment;
                    return new UpdateForClause(
                        columns: node.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
                    );
                }
                case 854: {
                    var node = (ScriptDom.UpdateMergeAction)fragment;
                    return new UpdateMergeAction(
                        setClauses: node.SetClauses.SelectList(c => (SetClause)FromMutable(c))
                    );
                }
                case 855: {
                    var node = (ScriptDom.UpdateSpecification)fragment;
                    return new UpdateSpecification(
                        setClauses: node.SetClauses.SelectList(c => (SetClause)FromMutable(c)),
                        fromClause: (FromClause)FromMutable(node.FromClause),
                        whereClause: (WhereClause)FromMutable(node.WhereClause),
                        target: (TableReference)FromMutable(node.Target),
                        topRowFilter: (TopRowFilter)FromMutable(node.TopRowFilter),
                        outputIntoClause: (OutputIntoClause)FromMutable(node.OutputIntoClause),
                        outputClause: (OutputClause)FromMutable(node.OutputClause)
                    );
                }
                case 856: {
                    var node = (ScriptDom.UpdateStatement)fragment;
                    return new UpdateStatement(
                        updateSpecification: (UpdateSpecification)FromMutable(node.UpdateSpecification),
                        withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable(node.WithCtesAndXmlNamespaces),
                        optimizerHints: node.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
                    );
                }
                case 857: {
                    var node = (ScriptDom.UpdateStatisticsStatement)fragment;
                    return new UpdateStatisticsStatement(
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName),
                        subElements: node.SubElements.SelectList(c => (Identifier)FromMutable(c)),
                        statisticsOptions: node.StatisticsOptions.SelectList(c => (StatisticsOption)FromMutable(c))
                    );
                }
                case 858: {
                    var node = (ScriptDom.UpdateTextStatement)fragment;
                    return new UpdateTextStatement(
                        insertOffset: (ScalarExpression)FromMutable(node.InsertOffset),
                        deleteLength: (ScalarExpression)FromMutable(node.DeleteLength),
                        sourceColumn: (ColumnReferenceExpression)FromMutable(node.SourceColumn),
                        sourceParameter: (ValueExpression)FromMutable(node.SourceParameter),
                        bulk: node.Bulk,
                        column: (ColumnReferenceExpression)FromMutable(node.Column),
                        textId: (ValueExpression)FromMutable(node.TextId),
                        timestamp: (Literal)FromMutable(node.Timestamp),
                        withLog: node.WithLog
                    );
                }
                case 859: {
                    var node = (ScriptDom.UseFederationStatement)fragment;
                    return new UseFederationStatement(
                        federationName: (Identifier)FromMutable(node.FederationName),
                        distributionName: (Identifier)FromMutable(node.DistributionName),
                        @value: (ScalarExpression)FromMutable(node.Value),
                        filtering: node.Filtering
                    );
                }
                case 860: {
                    var node = (ScriptDom.UseHintList)fragment;
                    return new UseHintList(
                        hints: node.Hints.SelectList(c => (StringLiteral)FromMutable(c)),
                        hintKind: node.HintKind
                    );
                }
                case 861: {
                    var node = (ScriptDom.UserDataTypeReference)fragment;
                    return new UserDataTypeReference(
                        parameters: node.Parameters.SelectList(c => (Literal)FromMutable(c)),
                        name: (SchemaObjectName)FromMutable(node.Name)
                    );
                }
                case 862: {
                    var node = (ScriptDom.UserDefinedTypeCallTarget)fragment;
                    return new UserDefinedTypeCallTarget(
                        schemaObjectName: (SchemaObjectName)FromMutable(node.SchemaObjectName)
                    );
                }
                case 863: {
                    var node = (ScriptDom.UserDefinedTypePropertyAccess)fragment;
                    return new UserDefinedTypePropertyAccess(
                        callTarget: (CallTarget)FromMutable(node.CallTarget),
                        propertyName: (Identifier)FromMutable(node.PropertyName),
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 864: {
                    var node = (ScriptDom.UserLoginOption)fragment;
                    return new UserLoginOption(
                        userLoginOptionType: node.UserLoginOptionType,
                        identifier: (Identifier)FromMutable(node.Identifier)
                    );
                }
                case 865: {
                    var node = (ScriptDom.UserRemoteServiceBindingOption)fragment;
                    return new UserRemoteServiceBindingOption(
                        user: (Identifier)FromMutable(node.User),
                        optionKind: node.OptionKind
                    );
                }
                case 866: {
                    var node = (ScriptDom.UseStatement)fragment;
                    return new UseStatement(
                        databaseName: (Identifier)FromMutable(node.DatabaseName)
                    );
                }
                case 867: {
                    var node = (ScriptDom.ValuesInsertSource)fragment;
                    return new ValuesInsertSource(
                        isDefaultValues: node.IsDefaultValues,
                        rowValues: node.RowValues.SelectList(c => (RowValue)FromMutable(c))
                    );
                }
                case 868: {
                    var node = (ScriptDom.VariableMethodCallTableReference)fragment;
                    return new VariableMethodCallTableReference(
                        variable: (VariableReference)FromMutable(node.Variable),
                        methodName: (Identifier)FromMutable(node.MethodName),
                        parameters: node.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                        columns: node.Columns.SelectList(c => (Identifier)FromMutable(c)),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 869: {
                    var node = (ScriptDom.VariableReference)fragment;
                    return new VariableReference(
                        name: node.Name,
                        collation: (Identifier)FromMutable(node.Collation)
                    );
                }
                case 870: {
                    var node = (ScriptDom.VariableTableReference)fragment;
                    return new VariableTableReference(
                        variable: (VariableReference)FromMutable(node.Variable),
                        alias: (Identifier)FromMutable(node.Alias),
                        forPath: node.ForPath
                    );
                }
                case 871: {
                    var node = (ScriptDom.VariableValuePair)fragment;
                    return new VariableValuePair(
                        variable: (VariableReference)FromMutable(node.Variable),
                        @value: (ScalarExpression)FromMutable(node.Value),
                        isForUnknown: node.IsForUnknown
                    );
                }
                case 872: {
                    var node = (ScriptDom.ViewDistributionOption)fragment;
                    return new ViewDistributionOption(
                        @value: (ViewDistributionPolicy)FromMutable(node.Value),
                        optionKind: node.OptionKind
                    );
                }
                case 873: {
                    var node = (ScriptDom.ViewForAppendOption)fragment;
                    return new ViewForAppendOption(
                        optionKind: node.OptionKind
                    );
                }
                case 874: {
                    var node = (ScriptDom.ViewHashDistributionPolicy)fragment;
                    return new ViewHashDistributionPolicy(
                        distributionColumn: (Identifier)FromMutable(node.DistributionColumn)
                    );
                }
                case 875: {
                    var node = (ScriptDom.ViewOption)fragment;
                    return new ViewOption(
                        optionKind: node.OptionKind
                    );
                }
                case 876: {
                    var node = (ScriptDom.ViewRoundRobinDistributionPolicy)fragment;
                    return new ViewRoundRobinDistributionPolicy(
                        
                    );
                }
                case 877: {
                    var node = (ScriptDom.WaitAtLowPriorityOption)fragment;
                    return new WaitAtLowPriorityOption(
                        options: node.Options.SelectList(c => (LowPriorityLockWaitOption)FromMutable(c)),
                        optionKind: node.OptionKind
                    );
                }
                case 878: {
                    var node = (ScriptDom.WaitForStatement)fragment;
                    return new WaitForStatement(
                        waitForOption: node.WaitForOption,
                        parameter: (ValueExpression)FromMutable(node.Parameter),
                        timeout: (ScalarExpression)FromMutable(node.Timeout),
                        statement: (WaitForSupportedStatement)FromMutable(node.Statement)
                    );
                }
                case 879: {
                    var node = (ScriptDom.WhereClause)fragment;
                    return new WhereClause(
                        searchCondition: (BooleanExpression)FromMutable(node.SearchCondition),
                        cursor: (CursorId)FromMutable(node.Cursor)
                    );
                }
                case 880: {
                    var node = (ScriptDom.WhileStatement)fragment;
                    return new WhileStatement(
                        predicate: (BooleanExpression)FromMutable(node.Predicate),
                        statement: (TSqlStatement)FromMutable(node.Statement)
                    );
                }
                case 881: {
                    var node = (ScriptDom.WindowClause)fragment;
                    return new WindowClause(
                        windowDefinition: node.WindowDefinition.SelectList(c => (WindowDefinition)FromMutable(c))
                    );
                }
                case 882: {
                    var node = (ScriptDom.WindowDefinition)fragment;
                    return new WindowDefinition(
                        windowName: (Identifier)FromMutable(node.WindowName),
                        refWindowName: (Identifier)FromMutable(node.RefWindowName),
                        partitions: node.Partitions.SelectList(c => (ScalarExpression)FromMutable(c)),
                        orderByClause: (OrderByClause)FromMutable(node.OrderByClause),
                        windowFrameClause: (WindowFrameClause)FromMutable(node.WindowFrameClause)
                    );
                }
                case 883: {
                    var node = (ScriptDom.WindowDelimiter)fragment;
                    return new WindowDelimiter(
                        windowDelimiterType: node.WindowDelimiterType,
                        offsetValue: (ScalarExpression)FromMutable(node.OffsetValue)
                    );
                }
                case 884: {
                    var node = (ScriptDom.WindowFrameClause)fragment;
                    return new WindowFrameClause(
                        top: (WindowDelimiter)FromMutable(node.Top),
                        bottom: (WindowDelimiter)FromMutable(node.Bottom),
                        windowFrameType: node.WindowFrameType
                    );
                }
                case 885: {
                    var node = (ScriptDom.WindowsCreateLoginSource)fragment;
                    return new WindowsCreateLoginSource(
                        options: node.Options.SelectList(c => (PrincipalOption)FromMutable(c))
                    );
                }
                case 886: {
                    var node = (ScriptDom.WithCtesAndXmlNamespaces)fragment;
                    return new WithCtesAndXmlNamespaces(
                        xmlNamespaces: (XmlNamespaces)FromMutable(node.XmlNamespaces),
                        commonTableExpressions: node.CommonTableExpressions.SelectList(c => (CommonTableExpression)FromMutable(c)),
                        changeTrackingContext: (ValueExpression)FromMutable(node.ChangeTrackingContext)
                    );
                }
                case 887: {
                    var node = (ScriptDom.WithinGroupClause)fragment;
                    return new WithinGroupClause(
                        orderByClause: (OrderByClause)FromMutable(node.OrderByClause),
                        hasGraphPath: node.HasGraphPath
                    );
                }
                case 888: {
                    var node = (ScriptDom.WitnessDatabaseOption)fragment;
                    return new WitnessDatabaseOption(
                        witnessServer: (Literal)FromMutable(node.WitnessServer),
                        isOff: node.IsOff,
                        optionKind: node.OptionKind
                    );
                }
                case 889: {
                    var node = (ScriptDom.WlmTimeLiteral)fragment;
                    return new WlmTimeLiteral(
                        timeString: (StringLiteral)FromMutable(node.TimeString)
                    );
                }
                case 890: {
                    var node = (ScriptDom.WorkloadGroupImportanceParameter)fragment;
                    return new WorkloadGroupImportanceParameter(
                        parameterValue: node.ParameterValue,
                        parameterType: node.ParameterType
                    );
                }
                case 891: {
                    var node = (ScriptDom.WorkloadGroupResourceParameter)fragment;
                    return new WorkloadGroupResourceParameter(
                        parameterValue: (Literal)FromMutable(node.ParameterValue),
                        parameterType: node.ParameterType
                    );
                }
                case 892: {
                    var node = (ScriptDom.WriteTextStatement)fragment;
                    return new WriteTextStatement(
                        sourceParameter: (ValueExpression)FromMutable(node.SourceParameter),
                        bulk: node.Bulk,
                        column: (ColumnReferenceExpression)FromMutable(node.Column),
                        textId: (ValueExpression)FromMutable(node.TextId),
                        timestamp: (Literal)FromMutable(node.Timestamp),
                        withLog: node.WithLog
                    );
                }
                case 893: {
                    var node = (ScriptDom.WsdlPayloadOption)fragment;
                    return new WsdlPayloadOption(
                        isNone: node.IsNone,
                        @value: (Literal)FromMutable(node.Value),
                        kind: node.Kind
                    );
                }
                case 894: {
                    var node = (ScriptDom.XmlCompressionOption)fragment;
                    return new XmlCompressionOption(
                        isCompressed: node.IsCompressed,
                        partitionRanges: node.PartitionRanges.SelectList(c => (CompressionPartitionRange)FromMutable(c)),
                        optionKind: node.OptionKind
                    );
                }
                case 895: {
                    var node = (ScriptDom.XmlDataTypeReference)fragment;
                    return new XmlDataTypeReference(
                        xmlDataTypeOption: node.XmlDataTypeOption,
                        xmlSchemaCollection: (SchemaObjectName)FromMutable(node.XmlSchemaCollection),
                        name: (SchemaObjectName)FromMutable(node.Name)
                    );
                }
                case 896: {
                    var node = (ScriptDom.XmlForClause)fragment;
                    return new XmlForClause(
                        options: node.Options.SelectList(c => (XmlForClauseOption)FromMutable(c))
                    );
                }
                case 897: {
                    var node = (ScriptDom.XmlForClauseOption)fragment;
                    return new XmlForClauseOption(
                        optionKind: node.OptionKind,
                        @value: (Literal)FromMutable(node.Value)
                    );
                }
                case 898: {
                    var node = (ScriptDom.XmlNamespaces)fragment;
                    return new XmlNamespaces(
                        xmlNamespacesElements: node.XmlNamespacesElements.SelectList(c => (XmlNamespacesElement)FromMutable(c))
                    );
                }
                case 899: {
                    var node = (ScriptDom.XmlNamespacesAliasElement)fragment;
                    return new XmlNamespacesAliasElement(
                        identifier: (Identifier)FromMutable(node.Identifier),
                        @string: (StringLiteral)FromMutable(node.String)
                    );
                }
                case 900: {
                    var node = (ScriptDom.XmlNamespacesDefaultElement)fragment;
                    return new XmlNamespacesDefaultElement(
                        @string: (StringLiteral)FromMutable(node.String)
                    );
                }
                default: throw new NotImplementedException("Type not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library.");
            }
        }
    
    }

}
