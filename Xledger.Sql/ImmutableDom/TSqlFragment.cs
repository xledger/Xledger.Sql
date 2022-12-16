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
        
        public static AcceleratedDatabaseRecoveryDatabaseOption FromMutable(ScriptDom.AcceleratedDatabaseRecoveryDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new AcceleratedDatabaseRecoveryDatabaseOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static AddAlterFullTextIndexAction FromMutable(ScriptDom.AddAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            return new AddAlterFullTextIndexAction(
                columns: fragment.Columns.SelectList(c => (FullTextIndexColumn)FromMutable(c)),
                withNoPopulation: fragment.WithNoPopulation
            );
        }
        
        public static AddFileSpec FromMutable(ScriptDom.AddFileSpec fragment) {
            if (fragment is null) { return null; }
            return new AddFileSpec(
                file: (ScalarExpression)FromMutable(fragment.File),
                fileName: (Literal)FromMutable(fragment.FileName)
            );
        }
        
        public static AddMemberAlterRoleAction FromMutable(ScriptDom.AddMemberAlterRoleAction fragment) {
            if (fragment is null) { return null; }
            return new AddMemberAlterRoleAction(
                member: (Identifier)FromMutable(fragment.Member)
            );
        }
        
        public static AddSearchPropertyListAction FromMutable(ScriptDom.AddSearchPropertyListAction fragment) {
            if (fragment is null) { return null; }
            return new AddSearchPropertyListAction(
                propertyName: (StringLiteral)FromMutable(fragment.PropertyName),
                guid: (StringLiteral)FromMutable(fragment.Guid),
                id: (IntegerLiteral)FromMutable(fragment.Id),
                description: (StringLiteral)FromMutable(fragment.Description)
            );
        }
        
        public static AddSensitivityClassificationStatement FromMutable(ScriptDom.AddSensitivityClassificationStatement fragment) {
            if (fragment is null) { return null; }
            return new AddSensitivityClassificationStatement(
                options: fragment.Options.SelectList(c => (SensitivityClassificationOption)FromMutable(c)),
                columns: fragment.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
            );
        }
        
        public static AddSignatureStatement FromMutable(ScriptDom.AddSignatureStatement fragment) {
            if (fragment is null) { return null; }
            return new AddSignatureStatement(
                isCounter: fragment.IsCounter,
                elementKind: fragment.ElementKind,
                element: (SchemaObjectName)FromMutable(fragment.Element),
                cryptos: fragment.Cryptos.SelectList(c => (CryptoMechanism)FromMutable(c))
            );
        }
        
        public static AdHocDataSource FromMutable(ScriptDom.AdHocDataSource fragment) {
            if (fragment is null) { return null; }
            return new AdHocDataSource(
                providerName: (StringLiteral)FromMutable(fragment.ProviderName),
                initString: (StringLiteral)FromMutable(fragment.InitString)
            );
        }
        
        public static AdHocTableReference FromMutable(ScriptDom.AdHocTableReference fragment) {
            if (fragment is null) { return null; }
            return new AdHocTableReference(
                dataSource: (AdHocDataSource)FromMutable(fragment.DataSource),
                @object: (SchemaObjectNameOrValueExpression)FromMutable(fragment.Object),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static AlgorithmKeyOption FromMutable(ScriptDom.AlgorithmKeyOption fragment) {
            if (fragment is null) { return null; }
            return new AlgorithmKeyOption(
                algorithm: fragment.Algorithm,
                optionKind: fragment.OptionKind
            );
        }
        
        public static AlterApplicationRoleStatement FromMutable(ScriptDom.AlterApplicationRoleStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterApplicationRoleStatement(
                name: (Identifier)FromMutable(fragment.Name),
                applicationRoleOptions: fragment.ApplicationRoleOptions.SelectList(c => (ApplicationRoleOption)FromMutable(c))
            );
        }
        
        public static AlterAssemblyStatement FromMutable(ScriptDom.AlterAssemblyStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterAssemblyStatement(
                dropFiles: fragment.DropFiles.SelectList(c => (Literal)FromMutable(c)),
                isDropAll: fragment.IsDropAll,
                addFiles: fragment.AddFiles.SelectList(c => (AddFileSpec)FromMutable(c)),
                name: (Identifier)FromMutable(fragment.Name),
                parameters: fragment.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                options: fragment.Options.SelectList(c => (AssemblyOption)FromMutable(c))
            );
        }
        
        public static AlterAsymmetricKeyStatement FromMutable(ScriptDom.AlterAsymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterAsymmetricKeyStatement(
                name: (Identifier)FromMutable(fragment.Name),
                attestedBy: (Literal)FromMutable(fragment.AttestedBy),
                kind: fragment.Kind,
                encryptionPassword: (Literal)FromMutable(fragment.EncryptionPassword),
                decryptionPassword: (Literal)FromMutable(fragment.DecryptionPassword)
            );
        }
        
        public static AlterAuthorizationStatement FromMutable(ScriptDom.AlterAuthorizationStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterAuthorizationStatement(
                securityTargetObject: (SecurityTargetObject)FromMutable(fragment.SecurityTargetObject),
                toSchemaOwner: fragment.ToSchemaOwner,
                principalName: (Identifier)FromMutable(fragment.PrincipalName)
            );
        }
        
        public static AlterAvailabilityGroupAction FromMutable(ScriptDom.AlterAvailabilityGroupAction fragment) {
            if (fragment is null) { return null; }
            return new AlterAvailabilityGroupAction(
                actionType: fragment.ActionType
            );
        }
        
        public static AlterAvailabilityGroupFailoverAction FromMutable(ScriptDom.AlterAvailabilityGroupFailoverAction fragment) {
            if (fragment is null) { return null; }
            return new AlterAvailabilityGroupFailoverAction(
                options: fragment.Options.SelectList(c => (AlterAvailabilityGroupFailoverOption)FromMutable(c)),
                actionType: fragment.ActionType
            );
        }
        
        public static AlterAvailabilityGroupFailoverOption FromMutable(ScriptDom.AlterAvailabilityGroupFailoverOption fragment) {
            if (fragment is null) { return null; }
            return new AlterAvailabilityGroupFailoverOption(
                optionKind: fragment.OptionKind,
                @value: (Literal)FromMutable(fragment.Value)
            );
        }
        
        public static AlterAvailabilityGroupStatement FromMutable(ScriptDom.AlterAvailabilityGroupStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterAvailabilityGroupStatement(
                alterAvailabilityGroupStatementType: fragment.AlterAvailabilityGroupStatementType,
                action: (AlterAvailabilityGroupAction)FromMutable(fragment.Action),
                name: (Identifier)FromMutable(fragment.Name),
                options: fragment.Options.SelectList(c => (AvailabilityGroupOption)FromMutable(c)),
                databases: fragment.Databases.SelectList(c => (Identifier)FromMutable(c)),
                replicas: fragment.Replicas.SelectList(c => (AvailabilityReplica)FromMutable(c))
            );
        }
        
        public static AlterBrokerPriorityStatement FromMutable(ScriptDom.AlterBrokerPriorityStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterBrokerPriorityStatement(
                name: (Identifier)FromMutable(fragment.Name),
                brokerPriorityParameters: fragment.BrokerPriorityParameters.SelectList(c => (BrokerPriorityParameter)FromMutable(c))
            );
        }
        
        public static AlterCertificateStatement FromMutable(ScriptDom.AlterCertificateStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterCertificateStatement(
                kind: fragment.Kind,
                attestedBy: (Literal)FromMutable(fragment.AttestedBy),
                name: (Identifier)FromMutable(fragment.Name),
                activeForBeginDialog: fragment.ActiveForBeginDialog,
                privateKeyPath: (Literal)FromMutable(fragment.PrivateKeyPath),
                encryptionPassword: (Literal)FromMutable(fragment.EncryptionPassword),
                decryptionPassword: (Literal)FromMutable(fragment.DecryptionPassword)
            );
        }
        
        public static AlterColumnAlterFullTextIndexAction FromMutable(ScriptDom.AlterColumnAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            return new AlterColumnAlterFullTextIndexAction(
                column: (FullTextIndexColumn)FromMutable(fragment.Column),
                withNoPopulation: fragment.WithNoPopulation
            );
        }
        
        public static AlterColumnEncryptionKeyStatement FromMutable(ScriptDom.AlterColumnEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterColumnEncryptionKeyStatement(
                alterType: fragment.AlterType,
                name: (Identifier)FromMutable(fragment.Name),
                columnEncryptionKeyValues: fragment.ColumnEncryptionKeyValues.SelectList(c => (ColumnEncryptionKeyValue)FromMutable(c))
            );
        }
        
        public static AlterCredentialStatement FromMutable(ScriptDom.AlterCredentialStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterCredentialStatement(
                name: (Identifier)FromMutable(fragment.Name),
                identity: (Literal)FromMutable(fragment.Identity),
                secret: (Literal)FromMutable(fragment.Secret),
                isDatabaseScoped: fragment.IsDatabaseScoped
            );
        }
        
        public static AlterCryptographicProviderStatement FromMutable(ScriptDom.AlterCryptographicProviderStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterCryptographicProviderStatement(
                name: (Identifier)FromMutable(fragment.Name),
                option: fragment.Option,
                file: (Literal)FromMutable(fragment.File)
            );
        }
        
        public static AlterDatabaseAddFileGroupStatement FromMutable(ScriptDom.AlterDatabaseAddFileGroupStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseAddFileGroupStatement(
                fileGroup: (Identifier)FromMutable(fragment.FileGroup),
                containsFileStream: fragment.ContainsFileStream,
                containsMemoryOptimizedData: fragment.ContainsMemoryOptimizedData,
                databaseName: (Identifier)FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseAddFileStatement FromMutable(ScriptDom.AlterDatabaseAddFileStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseAddFileStatement(
                fileDeclarations: fragment.FileDeclarations.SelectList(c => (FileDeclaration)FromMutable(c)),
                fileGroup: (Identifier)FromMutable(fragment.FileGroup),
                isLog: fragment.IsLog,
                databaseName: (Identifier)FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseAuditSpecificationStatement FromMutable(ScriptDom.AlterDatabaseAuditSpecificationStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseAuditSpecificationStatement(
                auditState: fragment.AuditState,
                parts: fragment.Parts.SelectList(c => (AuditSpecificationPart)FromMutable(c)),
                specificationName: (Identifier)FromMutable(fragment.SpecificationName),
                auditName: (Identifier)FromMutable(fragment.AuditName)
            );
        }
        
        public static AlterDatabaseCollateStatement FromMutable(ScriptDom.AlterDatabaseCollateStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseCollateStatement(
                collation: (Identifier)FromMutable(fragment.Collation),
                databaseName: (Identifier)FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseEncryptionKeyStatement FromMutable(ScriptDom.AlterDatabaseEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseEncryptionKeyStatement(
                regenerate: fragment.Regenerate,
                encryptor: (CryptoMechanism)FromMutable(fragment.Encryptor),
                algorithm: fragment.Algorithm
            );
        }
        
        public static AlterDatabaseModifyFileGroupStatement FromMutable(ScriptDom.AlterDatabaseModifyFileGroupStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseModifyFileGroupStatement(
                fileGroup: (Identifier)FromMutable(fragment.FileGroup),
                newFileGroupName: (Identifier)FromMutable(fragment.NewFileGroupName),
                makeDefault: fragment.MakeDefault,
                updatabilityOption: fragment.UpdatabilityOption,
                termination: (AlterDatabaseTermination)FromMutable(fragment.Termination),
                databaseName: (Identifier)FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseModifyFileStatement FromMutable(ScriptDom.AlterDatabaseModifyFileStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseModifyFileStatement(
                fileDeclaration: (FileDeclaration)FromMutable(fragment.FileDeclaration),
                databaseName: (Identifier)FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseModifyNameStatement FromMutable(ScriptDom.AlterDatabaseModifyNameStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseModifyNameStatement(
                newDatabaseName: (Identifier)FromMutable(fragment.NewDatabaseName),
                databaseName: (Identifier)FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseRebuildLogStatement FromMutable(ScriptDom.AlterDatabaseRebuildLogStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseRebuildLogStatement(
                fileDeclaration: (FileDeclaration)FromMutable(fragment.FileDeclaration),
                databaseName: (Identifier)FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseRemoveFileGroupStatement FromMutable(ScriptDom.AlterDatabaseRemoveFileGroupStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseRemoveFileGroupStatement(
                fileGroup: (Identifier)FromMutable(fragment.FileGroup),
                databaseName: (Identifier)FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseRemoveFileStatement FromMutable(ScriptDom.AlterDatabaseRemoveFileStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseRemoveFileStatement(
                file: (Identifier)FromMutable(fragment.File),
                databaseName: (Identifier)FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseScopedConfigurationClearStatement FromMutable(ScriptDom.AlterDatabaseScopedConfigurationClearStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseScopedConfigurationClearStatement(
                option: (DatabaseConfigurationClearOption)FromMutable(fragment.Option),
                secondary: fragment.Secondary
            );
        }
        
        public static AlterDatabaseScopedConfigurationSetStatement FromMutable(ScriptDom.AlterDatabaseScopedConfigurationSetStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseScopedConfigurationSetStatement(
                option: (DatabaseConfigurationSetOption)FromMutable(fragment.Option),
                secondary: fragment.Secondary
            );
        }
        
        public static AlterDatabaseSetStatement FromMutable(ScriptDom.AlterDatabaseSetStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseSetStatement(
                termination: (AlterDatabaseTermination)FromMutable(fragment.Termination),
                options: fragment.Options.SelectList(c => (DatabaseOption)FromMutable(c)),
                databaseName: (Identifier)FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
        
        public static AlterDatabaseTermination FromMutable(ScriptDom.AlterDatabaseTermination fragment) {
            if (fragment is null) { return null; }
            return new AlterDatabaseTermination(
                immediateRollback: fragment.ImmediateRollback,
                rollbackAfter: (Literal)FromMutable(fragment.RollbackAfter),
                noWait: fragment.NoWait
            );
        }
        
        public static AlterEndpointStatement FromMutable(ScriptDom.AlterEndpointStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterEndpointStatement(
                name: (Identifier)FromMutable(fragment.Name),
                state: fragment.State,
                affinity: (EndpointAffinity)FromMutable(fragment.Affinity),
                protocol: fragment.Protocol,
                protocolOptions: fragment.ProtocolOptions.SelectList(c => (EndpointProtocolOption)FromMutable(c)),
                endpointType: fragment.EndpointType,
                payloadOptions: fragment.PayloadOptions.SelectList(c => (PayloadOption)FromMutable(c))
            );
        }
        
        public static AlterEventSessionStatement FromMutable(ScriptDom.AlterEventSessionStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterEventSessionStatement(
                statementType: fragment.StatementType,
                dropEventDeclarations: fragment.DropEventDeclarations.SelectList(c => (EventSessionObjectName)FromMutable(c)),
                dropTargetDeclarations: fragment.DropTargetDeclarations.SelectList(c => (EventSessionObjectName)FromMutable(c)),
                name: (Identifier)FromMutable(fragment.Name),
                sessionScope: fragment.SessionScope,
                eventDeclarations: fragment.EventDeclarations.SelectList(c => (EventDeclaration)FromMutable(c)),
                targetDeclarations: fragment.TargetDeclarations.SelectList(c => (TargetDeclaration)FromMutable(c)),
                sessionOptions: fragment.SessionOptions.SelectList(c => (SessionOption)FromMutable(c))
            );
        }
        
        public static AlterExternalDataSourceStatement FromMutable(ScriptDom.AlterExternalDataSourceStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterExternalDataSourceStatement(
                previousPushDownOption: fragment.PreviousPushDownOption,
                name: (Identifier)FromMutable(fragment.Name),
                dataSourceType: fragment.DataSourceType,
                location: (Literal)FromMutable(fragment.Location),
                pushdownOption: fragment.PushdownOption,
                externalDataSourceOptions: fragment.ExternalDataSourceOptions.SelectList(c => (ExternalDataSourceOption)FromMutable(c))
            );
        }
        
        public static AlterExternalLanguageStatement FromMutable(ScriptDom.AlterExternalLanguageStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterExternalLanguageStatement(
                platform: (Identifier)FromMutable(fragment.Platform),
                operation: (Identifier)FromMutable(fragment.Operation),
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name),
                externalLanguageFiles: fragment.ExternalLanguageFiles.SelectList(c => (ExternalLanguageFileOption)FromMutable(c))
            );
        }
        
        public static AlterExternalLibraryStatement FromMutable(ScriptDom.AlterExternalLibraryStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterExternalLibraryStatement(
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name),
                language: (StringLiteral)FromMutable(fragment.Language),
                externalLibraryFiles: fragment.ExternalLibraryFiles.SelectList(c => (ExternalLibraryFileOption)FromMutable(c))
            );
        }
        
        public static AlterExternalResourcePoolStatement FromMutable(ScriptDom.AlterExternalResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterExternalResourcePoolStatement(
                name: (Identifier)FromMutable(fragment.Name),
                externalResourcePoolParameters: fragment.ExternalResourcePoolParameters.SelectList(c => (ExternalResourcePoolParameter)FromMutable(c))
            );
        }
        
        public static AlterFederationStatement FromMutable(ScriptDom.AlterFederationStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterFederationStatement(
                name: (Identifier)FromMutable(fragment.Name),
                kind: fragment.Kind,
                distributionName: (Identifier)FromMutable(fragment.DistributionName),
                boundary: (ScalarExpression)FromMutable(fragment.Boundary)
            );
        }
        
        public static AlterFullTextCatalogStatement FromMutable(ScriptDom.AlterFullTextCatalogStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterFullTextCatalogStatement(
                action: fragment.Action,
                name: (Identifier)FromMutable(fragment.Name),
                options: fragment.Options.SelectList(c => (FullTextCatalogOption)FromMutable(c))
            );
        }
        
        public static AlterFullTextIndexStatement FromMutable(ScriptDom.AlterFullTextIndexStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterFullTextIndexStatement(
                onName: (SchemaObjectName)FromMutable(fragment.OnName),
                action: (AlterFullTextIndexAction)FromMutable(fragment.Action)
            );
        }
        
        public static AlterFullTextStopListStatement FromMutable(ScriptDom.AlterFullTextStopListStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterFullTextStopListStatement(
                name: (Identifier)FromMutable(fragment.Name),
                action: (FullTextStopListAction)FromMutable(fragment.Action)
            );
        }
        
        public static AlterFunctionStatement FromMutable(ScriptDom.AlterFunctionStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterFunctionStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                returnType: (FunctionReturnType)FromMutable(fragment.ReturnType),
                options: fragment.Options.SelectList(c => (FunctionOption)FromMutable(c)),
                orderHint: (OrderBulkInsertOption)FromMutable(fragment.OrderHint),
                parameters: fragment.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                statementList: (StatementList)FromMutable(fragment.StatementList),
                methodSpecifier: (MethodSpecifier)FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static AlterIndexStatement FromMutable(ScriptDom.AlterIndexStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterIndexStatement(
                all: fragment.All,
                alterIndexType: fragment.AlterIndexType,
                partition: (PartitionSpecifier)FromMutable(fragment.Partition),
                promotedPaths: fragment.PromotedPaths.SelectList(c => (SelectiveXmlIndexPromotedPath)FromMutable(c)),
                xmlNamespaces: (XmlNamespaces)FromMutable(fragment.XmlNamespaces),
                name: (Identifier)FromMutable(fragment.Name),
                onName: (SchemaObjectName)FromMutable(fragment.OnName),
                indexOptions: fragment.IndexOptions.SelectList(c => (IndexOption)FromMutable(c))
            );
        }
        
        public static AlterLoginAddDropCredentialStatement FromMutable(ScriptDom.AlterLoginAddDropCredentialStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterLoginAddDropCredentialStatement(
                isAdd: fragment.IsAdd,
                credentialName: (Identifier)FromMutable(fragment.CredentialName),
                name: (Identifier)FromMutable(fragment.Name)
            );
        }
        
        public static AlterLoginEnableDisableStatement FromMutable(ScriptDom.AlterLoginEnableDisableStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterLoginEnableDisableStatement(
                isEnable: fragment.IsEnable,
                name: (Identifier)FromMutable(fragment.Name)
            );
        }
        
        public static AlterLoginOptionsStatement FromMutable(ScriptDom.AlterLoginOptionsStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterLoginOptionsStatement(
                options: fragment.Options.SelectList(c => (PrincipalOption)FromMutable(c)),
                name: (Identifier)FromMutable(fragment.Name)
            );
        }
        
        public static AlterMasterKeyStatement FromMutable(ScriptDom.AlterMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterMasterKeyStatement(
                option: fragment.Option,
                password: (Literal)FromMutable(fragment.Password)
            );
        }
        
        public static AlterMessageTypeStatement FromMutable(ScriptDom.AlterMessageTypeStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterMessageTypeStatement(
                name: (Identifier)FromMutable(fragment.Name),
                validationMethod: fragment.ValidationMethod,
                xmlSchemaCollectionName: (SchemaObjectName)FromMutable(fragment.XmlSchemaCollectionName)
            );
        }
        
        public static AlterPartitionFunctionStatement FromMutable(ScriptDom.AlterPartitionFunctionStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterPartitionFunctionStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isSplit: fragment.IsSplit,
                boundary: (ScalarExpression)FromMutable(fragment.Boundary)
            );
        }
        
        public static AlterPartitionSchemeStatement FromMutable(ScriptDom.AlterPartitionSchemeStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterPartitionSchemeStatement(
                name: (Identifier)FromMutable(fragment.Name),
                fileGroup: (IdentifierOrValueExpression)FromMutable(fragment.FileGroup)
            );
        }
        
        public static AlterProcedureStatement FromMutable(ScriptDom.AlterProcedureStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterProcedureStatement(
                procedureReference: (ProcedureReference)FromMutable(fragment.ProcedureReference),
                isForReplication: fragment.IsForReplication,
                options: fragment.Options.SelectList(c => (ProcedureOption)FromMutable(c)),
                parameters: fragment.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                statementList: (StatementList)FromMutable(fragment.StatementList),
                methodSpecifier: (MethodSpecifier)FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static AlterQueueStatement FromMutable(ScriptDom.AlterQueueStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterQueueStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                queueOptions: fragment.QueueOptions.SelectList(c => (QueueOption)FromMutable(c))
            );
        }
        
        public static AlterRemoteServiceBindingStatement FromMutable(ScriptDom.AlterRemoteServiceBindingStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterRemoteServiceBindingStatement(
                name: (Identifier)FromMutable(fragment.Name),
                options: fragment.Options.SelectList(c => (RemoteServiceBindingOption)FromMutable(c))
            );
        }
        
        public static AlterResourceGovernorStatement FromMutable(ScriptDom.AlterResourceGovernorStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterResourceGovernorStatement(
                command: fragment.Command,
                classifierFunction: (SchemaObjectName)FromMutable(fragment.ClassifierFunction)
            );
        }
        
        public static AlterResourcePoolStatement FromMutable(ScriptDom.AlterResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterResourcePoolStatement(
                name: (Identifier)FromMutable(fragment.Name),
                resourcePoolParameters: fragment.ResourcePoolParameters.SelectList(c => (ResourcePoolParameter)FromMutable(c))
            );
        }
        
        public static AlterRoleStatement FromMutable(ScriptDom.AlterRoleStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterRoleStatement(
                action: (AlterRoleAction)FromMutable(fragment.Action),
                name: (Identifier)FromMutable(fragment.Name)
            );
        }
        
        public static AlterRouteStatement FromMutable(ScriptDom.AlterRouteStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterRouteStatement(
                name: (Identifier)FromMutable(fragment.Name),
                routeOptions: fragment.RouteOptions.SelectList(c => (RouteOption)FromMutable(c))
            );
        }
        
        public static AlterSchemaStatement FromMutable(ScriptDom.AlterSchemaStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterSchemaStatement(
                name: (Identifier)FromMutable(fragment.Name),
                objectName: (SchemaObjectName)FromMutable(fragment.ObjectName),
                objectKind: fragment.ObjectKind
            );
        }
        
        public static AlterSearchPropertyListStatement FromMutable(ScriptDom.AlterSearchPropertyListStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterSearchPropertyListStatement(
                name: (Identifier)FromMutable(fragment.Name),
                action: (SearchPropertyListAction)FromMutable(fragment.Action)
            );
        }
        
        public static AlterSecurityPolicyStatement FromMutable(ScriptDom.AlterSecurityPolicyStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterSecurityPolicyStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                notForReplication: fragment.NotForReplication,
                securityPolicyOptions: fragment.SecurityPolicyOptions.SelectList(c => (SecurityPolicyOption)FromMutable(c)),
                securityPredicateActions: fragment.SecurityPredicateActions.SelectList(c => (SecurityPredicateAction)FromMutable(c)),
                actionType: fragment.ActionType
            );
        }
        
        public static AlterSequenceStatement FromMutable(ScriptDom.AlterSequenceStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterSequenceStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                sequenceOptions: fragment.SequenceOptions.SelectList(c => (SequenceOption)FromMutable(c))
            );
        }
        
        public static AlterServerAuditSpecificationStatement FromMutable(ScriptDom.AlterServerAuditSpecificationStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterServerAuditSpecificationStatement(
                auditState: fragment.AuditState,
                parts: fragment.Parts.SelectList(c => (AuditSpecificationPart)FromMutable(c)),
                specificationName: (Identifier)FromMutable(fragment.SpecificationName),
                auditName: (Identifier)FromMutable(fragment.AuditName)
            );
        }
        
        public static AlterServerAuditStatement FromMutable(ScriptDom.AlterServerAuditStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterServerAuditStatement(
                newName: (Identifier)FromMutable(fragment.NewName),
                removeWhere: fragment.RemoveWhere,
                auditName: (Identifier)FromMutable(fragment.AuditName),
                auditTarget: (AuditTarget)FromMutable(fragment.AuditTarget),
                options: fragment.Options.SelectList(c => (AuditOption)FromMutable(c)),
                predicateExpression: (BooleanExpression)FromMutable(fragment.PredicateExpression)
            );
        }
        
        public static AlterServerConfigurationBufferPoolExtensionContainerOption FromMutable(ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationBufferPoolExtensionContainerOption(
                suboptions: fragment.Suboptions.SelectList(c => (AlterServerConfigurationBufferPoolExtensionOption)FromMutable(c)),
                optionKind: fragment.OptionKind,
                optionValue: (OptionValue)FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationBufferPoolExtensionOption FromMutable(ScriptDom.AlterServerConfigurationBufferPoolExtensionOption fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationBufferPoolExtensionOption(
                optionKind: fragment.OptionKind,
                optionValue: (OptionValue)FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationBufferPoolExtensionSizeOption FromMutable(ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationBufferPoolExtensionSizeOption(
                sizeUnit: fragment.SizeUnit,
                optionKind: fragment.OptionKind,
                optionValue: (OptionValue)FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationDiagnosticsLogMaxSizeOption FromMutable(ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationDiagnosticsLogMaxSizeOption(
                sizeUnit: fragment.SizeUnit,
                optionKind: fragment.OptionKind,
                optionValue: (OptionValue)FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationDiagnosticsLogOption FromMutable(ScriptDom.AlterServerConfigurationDiagnosticsLogOption fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationDiagnosticsLogOption(
                optionKind: fragment.OptionKind,
                optionValue: (OptionValue)FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationExternalAuthenticationContainerOption FromMutable(ScriptDom.AlterServerConfigurationExternalAuthenticationContainerOption fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationExternalAuthenticationContainerOption(
                suboptions: fragment.Suboptions.SelectList(c => (AlterServerConfigurationExternalAuthenticationOption)FromMutable(c)),
                optionKind: fragment.OptionKind,
                optionValue: (OptionValue)FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationExternalAuthenticationOption FromMutable(ScriptDom.AlterServerConfigurationExternalAuthenticationOption fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationExternalAuthenticationOption(
                optionKind: fragment.OptionKind,
                optionValue: (OptionValue)FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationFailoverClusterPropertyOption FromMutable(ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationFailoverClusterPropertyOption(
                optionKind: fragment.OptionKind,
                optionValue: (OptionValue)FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationHadrClusterOption FromMutable(ScriptDom.AlterServerConfigurationHadrClusterOption fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationHadrClusterOption(
                optionKind: fragment.OptionKind,
                optionValue: (OptionValue)FromMutable(fragment.OptionValue),
                isLocal: fragment.IsLocal
            );
        }
        
        public static AlterServerConfigurationSetBufferPoolExtensionStatement FromMutable(ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationSetBufferPoolExtensionStatement(
                options: fragment.Options.SelectList(c => (AlterServerConfigurationBufferPoolExtensionOption)FromMutable(c))
            );
        }
        
        public static AlterServerConfigurationSetDiagnosticsLogStatement FromMutable(ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationSetDiagnosticsLogStatement(
                options: fragment.Options.SelectList(c => (AlterServerConfigurationDiagnosticsLogOption)FromMutable(c))
            );
        }
        
        public static AlterServerConfigurationSetExternalAuthenticationStatement FromMutable(ScriptDom.AlterServerConfigurationSetExternalAuthenticationStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationSetExternalAuthenticationStatement(
                options: fragment.Options.SelectList(c => (AlterServerConfigurationExternalAuthenticationOption)FromMutable(c))
            );
        }
        
        public static AlterServerConfigurationSetFailoverClusterPropertyStatement FromMutable(ScriptDom.AlterServerConfigurationSetFailoverClusterPropertyStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationSetFailoverClusterPropertyStatement(
                options: fragment.Options.SelectList(c => (AlterServerConfigurationFailoverClusterPropertyOption)FromMutable(c))
            );
        }
        
        public static AlterServerConfigurationSetHadrClusterStatement FromMutable(ScriptDom.AlterServerConfigurationSetHadrClusterStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationSetHadrClusterStatement(
                options: fragment.Options.SelectList(c => (AlterServerConfigurationHadrClusterOption)FromMutable(c))
            );
        }
        
        public static AlterServerConfigurationSetSoftNumaStatement FromMutable(ScriptDom.AlterServerConfigurationSetSoftNumaStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationSetSoftNumaStatement(
                options: fragment.Options.SelectList(c => (AlterServerConfigurationSoftNumaOption)FromMutable(c))
            );
        }
        
        public static AlterServerConfigurationSoftNumaOption FromMutable(ScriptDom.AlterServerConfigurationSoftNumaOption fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationSoftNumaOption(
                optionKind: fragment.OptionKind,
                optionValue: (OptionValue)FromMutable(fragment.OptionValue)
            );
        }
        
        public static AlterServerConfigurationStatement FromMutable(ScriptDom.AlterServerConfigurationStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterServerConfigurationStatement(
                processAffinity: fragment.ProcessAffinity,
                processAffinityRanges: fragment.ProcessAffinityRanges.SelectList(c => (ProcessAffinityRange)FromMutable(c))
            );
        }
        
        public static AlterServerRoleStatement FromMutable(ScriptDom.AlterServerRoleStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterServerRoleStatement(
                action: (AlterRoleAction)FromMutable(fragment.Action),
                name: (Identifier)FromMutable(fragment.Name)
            );
        }
        
        public static AlterServiceMasterKeyStatement FromMutable(ScriptDom.AlterServiceMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterServiceMasterKeyStatement(
                account: (Literal)FromMutable(fragment.Account),
                password: (Literal)FromMutable(fragment.Password),
                kind: fragment.Kind
            );
        }
        
        public static AlterServiceStatement FromMutable(ScriptDom.AlterServiceStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterServiceStatement(
                name: (Identifier)FromMutable(fragment.Name),
                queueName: (SchemaObjectName)FromMutable(fragment.QueueName),
                serviceContracts: fragment.ServiceContracts.SelectList(c => (ServiceContract)FromMutable(c))
            );
        }
        
        public static AlterSymmetricKeyStatement FromMutable(ScriptDom.AlterSymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterSymmetricKeyStatement(
                isAdd: fragment.IsAdd,
                name: (Identifier)FromMutable(fragment.Name),
                encryptingMechanisms: fragment.EncryptingMechanisms.SelectList(c => (CryptoMechanism)FromMutable(c))
            );
        }
        
        public static AlterTableAddTableElementStatement FromMutable(ScriptDom.AlterTableAddTableElementStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterTableAddTableElementStatement(
                existingRowsCheckEnforcement: fragment.ExistingRowsCheckEnforcement,
                definition: (TableDefinition)FromMutable(fragment.Definition),
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableAlterColumnStatement FromMutable(ScriptDom.AlterTableAlterColumnStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterTableAlterColumnStatement(
                columnIdentifier: (Identifier)FromMutable(fragment.ColumnIdentifier),
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                alterTableAlterColumnOption: fragment.AlterTableAlterColumnOption,
                storageOptions: (ColumnStorageOptions)FromMutable(fragment.StorageOptions),
                options: fragment.Options.SelectList(c => (IndexOption)FromMutable(c)),
                generatedAlways: fragment.GeneratedAlways,
                isHidden: fragment.IsHidden,
                encryption: (ColumnEncryptionDefinition)FromMutable(fragment.Encryption),
                collation: (Identifier)FromMutable(fragment.Collation),
                isMasked: fragment.IsMasked,
                maskingFunction: (StringLiteral)FromMutable(fragment.MaskingFunction),
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableAlterIndexStatement FromMutable(ScriptDom.AlterTableAlterIndexStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterTableAlterIndexStatement(
                indexIdentifier: (Identifier)FromMutable(fragment.IndexIdentifier),
                alterIndexType: fragment.AlterIndexType,
                indexOptions: fragment.IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableAlterPartitionStatement FromMutable(ScriptDom.AlterTableAlterPartitionStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterTableAlterPartitionStatement(
                boundaryValue: (ScalarExpression)FromMutable(fragment.BoundaryValue),
                isSplit: fragment.IsSplit,
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableChangeTrackingModificationStatement FromMutable(ScriptDom.AlterTableChangeTrackingModificationStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterTableChangeTrackingModificationStatement(
                isEnable: fragment.IsEnable,
                trackColumnsUpdated: fragment.TrackColumnsUpdated,
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableConstraintModificationStatement FromMutable(ScriptDom.AlterTableConstraintModificationStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterTableConstraintModificationStatement(
                existingRowsCheckEnforcement: fragment.ExistingRowsCheckEnforcement,
                constraintEnforcement: fragment.ConstraintEnforcement,
                all: fragment.All,
                constraintNames: fragment.ConstraintNames.SelectList(c => (Identifier)FromMutable(c)),
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableDropTableElement FromMutable(ScriptDom.AlterTableDropTableElement fragment) {
            if (fragment is null) { return null; }
            return new AlterTableDropTableElement(
                tableElementType: fragment.TableElementType,
                name: (Identifier)FromMutable(fragment.Name),
                dropClusteredConstraintOptions: fragment.DropClusteredConstraintOptions.SelectList(c => (DropClusteredConstraintOption)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static AlterTableDropTableElementStatement FromMutable(ScriptDom.AlterTableDropTableElementStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterTableDropTableElementStatement(
                alterTableDropTableElements: fragment.AlterTableDropTableElements.SelectList(c => (AlterTableDropTableElement)FromMutable(c)),
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableFileTableNamespaceStatement FromMutable(ScriptDom.AlterTableFileTableNamespaceStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterTableFileTableNamespaceStatement(
                isEnable: fragment.IsEnable,
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableRebuildStatement FromMutable(ScriptDom.AlterTableRebuildStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterTableRebuildStatement(
                partition: (PartitionSpecifier)FromMutable(fragment.Partition),
                indexOptions: fragment.IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableSetStatement FromMutable(ScriptDom.AlterTableSetStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterTableSetStatement(
                options: fragment.Options.SelectList(c => (TableOption)FromMutable(c)),
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableSwitchStatement FromMutable(ScriptDom.AlterTableSwitchStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterTableSwitchStatement(
                sourcePartitionNumber: (ScalarExpression)FromMutable(fragment.SourcePartitionNumber),
                targetPartitionNumber: (ScalarExpression)FromMutable(fragment.TargetPartitionNumber),
                targetTable: (SchemaObjectName)FromMutable(fragment.TargetTable),
                options: fragment.Options.SelectList(c => (TableSwitchOption)FromMutable(c)),
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTableTriggerModificationStatement FromMutable(ScriptDom.AlterTableTriggerModificationStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterTableTriggerModificationStatement(
                triggerEnforcement: fragment.TriggerEnforcement,
                all: fragment.All,
                triggerNames: fragment.TriggerNames.SelectList(c => (Identifier)FromMutable(c)),
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static AlterTriggerStatement FromMutable(ScriptDom.AlterTriggerStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterTriggerStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                triggerObject: (TriggerObject)FromMutable(fragment.TriggerObject),
                options: fragment.Options.SelectList(c => (TriggerOption)FromMutable(c)),
                triggerType: fragment.TriggerType,
                triggerActions: fragment.TriggerActions.SelectList(c => (TriggerAction)FromMutable(c)),
                withAppend: fragment.WithAppend,
                isNotForReplication: fragment.IsNotForReplication,
                statementList: (StatementList)FromMutable(fragment.StatementList),
                methodSpecifier: (MethodSpecifier)FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static AlterUserStatement FromMutable(ScriptDom.AlterUserStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterUserStatement(
                name: (Identifier)FromMutable(fragment.Name),
                userOptions: fragment.UserOptions.SelectList(c => (PrincipalOption)FromMutable(c))
            );
        }
        
        public static AlterViewStatement FromMutable(ScriptDom.AlterViewStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterViewStatement(
                isRebuild: fragment.IsRebuild,
                isDisable: fragment.IsDisable,
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                viewOptions: fragment.ViewOptions.SelectList(c => (ViewOption)FromMutable(c)),
                selectStatement: (SelectStatement)FromMutable(fragment.SelectStatement),
                withCheckOption: fragment.WithCheckOption,
                isMaterialized: fragment.IsMaterialized
            );
        }
        
        public static AlterWorkloadGroupStatement FromMutable(ScriptDom.AlterWorkloadGroupStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterWorkloadGroupStatement(
                name: (Identifier)FromMutable(fragment.Name),
                workloadGroupParameters: fragment.WorkloadGroupParameters.SelectList(c => (WorkloadGroupParameter)FromMutable(c)),
                poolName: (Identifier)FromMutable(fragment.PoolName),
                externalPoolName: (Identifier)FromMutable(fragment.ExternalPoolName)
            );
        }
        
        public static AlterXmlSchemaCollectionStatement FromMutable(ScriptDom.AlterXmlSchemaCollectionStatement fragment) {
            if (fragment is null) { return null; }
            return new AlterXmlSchemaCollectionStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                expression: (ScalarExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static ApplicationRoleOption FromMutable(ScriptDom.ApplicationRoleOption fragment) {
            if (fragment is null) { return null; }
            return new ApplicationRoleOption(
                optionKind: fragment.OptionKind,
                @value: (IdentifierOrValueExpression)FromMutable(fragment.Value)
            );
        }
        
        public static AssemblyEncryptionSource FromMutable(ScriptDom.AssemblyEncryptionSource fragment) {
            if (fragment is null) { return null; }
            return new AssemblyEncryptionSource(
                assembly: (Identifier)FromMutable(fragment.Assembly)
            );
        }
        
        public static AssemblyName FromMutable(ScriptDom.AssemblyName fragment) {
            if (fragment is null) { return null; }
            return new AssemblyName(
                name: (Identifier)FromMutable(fragment.Name),
                className: (Identifier)FromMutable(fragment.ClassName)
            );
        }
        
        public static AssemblyOption FromMutable(ScriptDom.AssemblyOption fragment) {
            if (fragment is null) { return null; }
            return new AssemblyOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static AssignmentSetClause FromMutable(ScriptDom.AssignmentSetClause fragment) {
            if (fragment is null) { return null; }
            return new AssignmentSetClause(
                variable: (VariableReference)FromMutable(fragment.Variable),
                column: (ColumnReferenceExpression)FromMutable(fragment.Column),
                newValue: (ScalarExpression)FromMutable(fragment.NewValue),
                assignmentKind: fragment.AssignmentKind
            );
        }
        
        public static AsymmetricKeyCreateLoginSource FromMutable(ScriptDom.AsymmetricKeyCreateLoginSource fragment) {
            if (fragment is null) { return null; }
            return new AsymmetricKeyCreateLoginSource(
                key: (Identifier)FromMutable(fragment.Key),
                credential: (Identifier)FromMutable(fragment.Credential)
            );
        }
        
        public static AtTimeZoneCall FromMutable(ScriptDom.AtTimeZoneCall fragment) {
            if (fragment is null) { return null; }
            return new AtTimeZoneCall(
                dateValue: (ScalarExpression)FromMutable(fragment.DateValue),
                timeZone: (ScalarExpression)FromMutable(fragment.TimeZone),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static AuditActionGroupReference FromMutable(ScriptDom.AuditActionGroupReference fragment) {
            if (fragment is null) { return null; }
            return new AuditActionGroupReference(
                group: fragment.Group
            );
        }
        
        public static AuditActionSpecification FromMutable(ScriptDom.AuditActionSpecification fragment) {
            if (fragment is null) { return null; }
            return new AuditActionSpecification(
                actions: fragment.Actions.SelectList(c => (DatabaseAuditAction)FromMutable(c)),
                principals: fragment.Principals.SelectList(c => (SecurityPrincipal)FromMutable(c)),
                targetObject: (SecurityTargetObject)FromMutable(fragment.TargetObject)
            );
        }
        
        public static AuditGuidAuditOption FromMutable(ScriptDom.AuditGuidAuditOption fragment) {
            if (fragment is null) { return null; }
            return new AuditGuidAuditOption(
                guid: (Literal)FromMutable(fragment.Guid),
                optionKind: fragment.OptionKind
            );
        }
        
        public static AuditSpecificationPart FromMutable(ScriptDom.AuditSpecificationPart fragment) {
            if (fragment is null) { return null; }
            return new AuditSpecificationPart(
                isDrop: fragment.IsDrop,
                details: (AuditSpecificationDetail)FromMutable(fragment.Details)
            );
        }
        
        public static AuditTarget FromMutable(ScriptDom.AuditTarget fragment) {
            if (fragment is null) { return null; }
            return new AuditTarget(
                targetKind: fragment.TargetKind,
                targetOptions: fragment.TargetOptions.SelectList(c => (AuditTargetOption)FromMutable(c))
            );
        }
        
        public static AuthenticationEndpointProtocolOption FromMutable(ScriptDom.AuthenticationEndpointProtocolOption fragment) {
            if (fragment is null) { return null; }
            return new AuthenticationEndpointProtocolOption(
                authenticationTypes: fragment.AuthenticationTypes,
                kind: fragment.Kind
            );
        }
        
        public static AuthenticationPayloadOption FromMutable(ScriptDom.AuthenticationPayloadOption fragment) {
            if (fragment is null) { return null; }
            return new AuthenticationPayloadOption(
                protocol: fragment.Protocol,
                certificate: (Identifier)FromMutable(fragment.Certificate),
                tryCertificateFirst: fragment.TryCertificateFirst,
                kind: fragment.Kind
            );
        }
        
        public static AutoCleanupChangeTrackingOptionDetail FromMutable(ScriptDom.AutoCleanupChangeTrackingOptionDetail fragment) {
            if (fragment is null) { return null; }
            return new AutoCleanupChangeTrackingOptionDetail(
                isOn: fragment.IsOn
            );
        }
        
        public static AutoCreateStatisticsDatabaseOption FromMutable(ScriptDom.AutoCreateStatisticsDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new AutoCreateStatisticsDatabaseOption(
                hasIncremental: fragment.HasIncremental,
                incrementalState: fragment.IncrementalState,
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static AutomaticTuningCreateIndexOption FromMutable(ScriptDom.AutomaticTuningCreateIndexOption fragment) {
            if (fragment is null) { return null; }
            return new AutomaticTuningCreateIndexOption(
                optionKind: fragment.OptionKind,
                @value: fragment.Value
            );
        }
        
        public static AutomaticTuningDatabaseOption FromMutable(ScriptDom.AutomaticTuningDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new AutomaticTuningDatabaseOption(
                automaticTuningState: fragment.AutomaticTuningState,
                options: fragment.Options.SelectList(c => (AutomaticTuningOption)FromMutable(c)),
                optionKind: fragment.OptionKind
            );
        }
        
        public static AutomaticTuningDropIndexOption FromMutable(ScriptDom.AutomaticTuningDropIndexOption fragment) {
            if (fragment is null) { return null; }
            return new AutomaticTuningDropIndexOption(
                optionKind: fragment.OptionKind,
                @value: fragment.Value
            );
        }
        
        public static AutomaticTuningForceLastGoodPlanOption FromMutable(ScriptDom.AutomaticTuningForceLastGoodPlanOption fragment) {
            if (fragment is null) { return null; }
            return new AutomaticTuningForceLastGoodPlanOption(
                optionKind: fragment.OptionKind,
                @value: fragment.Value
            );
        }
        
        public static AutomaticTuningMaintainIndexOption FromMutable(ScriptDom.AutomaticTuningMaintainIndexOption fragment) {
            if (fragment is null) { return null; }
            return new AutomaticTuningMaintainIndexOption(
                optionKind: fragment.OptionKind,
                @value: fragment.Value
            );
        }
        
        public static AutomaticTuningOption FromMutable(ScriptDom.AutomaticTuningOption fragment) {
            if (fragment is null) { return null; }
            return new AutomaticTuningOption(
                optionKind: fragment.OptionKind,
                @value: fragment.Value
            );
        }
        
        public static AvailabilityModeReplicaOption FromMutable(ScriptDom.AvailabilityModeReplicaOption fragment) {
            if (fragment is null) { return null; }
            return new AvailabilityModeReplicaOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static AvailabilityReplica FromMutable(ScriptDom.AvailabilityReplica fragment) {
            if (fragment is null) { return null; }
            return new AvailabilityReplica(
                serverName: (StringLiteral)FromMutable(fragment.ServerName),
                options: fragment.Options.SelectList(c => (AvailabilityReplicaOption)FromMutable(c))
            );
        }
        
        public static BackupCertificateStatement FromMutable(ScriptDom.BackupCertificateStatement fragment) {
            if (fragment is null) { return null; }
            return new BackupCertificateStatement(
                file: (Literal)FromMutable(fragment.File),
                name: (Identifier)FromMutable(fragment.Name),
                activeForBeginDialog: fragment.ActiveForBeginDialog,
                privateKeyPath: (Literal)FromMutable(fragment.PrivateKeyPath),
                encryptionPassword: (Literal)FromMutable(fragment.EncryptionPassword),
                decryptionPassword: (Literal)FromMutable(fragment.DecryptionPassword)
            );
        }
        
        public static BackupDatabaseStatement FromMutable(ScriptDom.BackupDatabaseStatement fragment) {
            if (fragment is null) { return null; }
            return new BackupDatabaseStatement(
                files: fragment.Files.SelectList(c => (BackupRestoreFileInfo)FromMutable(c)),
                databaseName: (IdentifierOrValueExpression)FromMutable(fragment.DatabaseName),
                options: fragment.Options.SelectList(c => (BackupOption)FromMutable(c)),
                mirrorToClauses: fragment.MirrorToClauses.SelectList(c => (MirrorToClause)FromMutable(c)),
                devices: fragment.Devices.SelectList(c => (DeviceInfo)FromMutable(c))
            );
        }
        
        public static BackupEncryptionOption FromMutable(ScriptDom.BackupEncryptionOption fragment) {
            if (fragment is null) { return null; }
            return new BackupEncryptionOption(
                algorithm: fragment.Algorithm,
                encryptor: (CryptoMechanism)FromMutable(fragment.Encryptor),
                optionKind: fragment.OptionKind,
                @value: (ScalarExpression)FromMutable(fragment.Value)
            );
        }
        
        public static BackupMasterKeyStatement FromMutable(ScriptDom.BackupMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new BackupMasterKeyStatement(
                file: (Literal)FromMutable(fragment.File),
                password: (Literal)FromMutable(fragment.Password)
            );
        }
        
        public static BackupOption FromMutable(ScriptDom.BackupOption fragment) {
            if (fragment is null) { return null; }
            return new BackupOption(
                optionKind: fragment.OptionKind,
                @value: (ScalarExpression)FromMutable(fragment.Value)
            );
        }
        
        public static BackupRestoreFileInfo FromMutable(ScriptDom.BackupRestoreFileInfo fragment) {
            if (fragment is null) { return null; }
            return new BackupRestoreFileInfo(
                items: fragment.Items.SelectList(c => (ValueExpression)FromMutable(c)),
                itemKind: fragment.ItemKind
            );
        }
        
        public static BackupServiceMasterKeyStatement FromMutable(ScriptDom.BackupServiceMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new BackupServiceMasterKeyStatement(
                file: (Literal)FromMutable(fragment.File),
                password: (Literal)FromMutable(fragment.Password)
            );
        }
        
        public static BackupTransactionLogStatement FromMutable(ScriptDom.BackupTransactionLogStatement fragment) {
            if (fragment is null) { return null; }
            return new BackupTransactionLogStatement(
                databaseName: (IdentifierOrValueExpression)FromMutable(fragment.DatabaseName),
                options: fragment.Options.SelectList(c => (BackupOption)FromMutable(c)),
                mirrorToClauses: fragment.MirrorToClauses.SelectList(c => (MirrorToClause)FromMutable(c)),
                devices: fragment.Devices.SelectList(c => (DeviceInfo)FromMutable(c))
            );
        }
        
        public static BackwardsCompatibleDropIndexClause FromMutable(ScriptDom.BackwardsCompatibleDropIndexClause fragment) {
            if (fragment is null) { return null; }
            return new BackwardsCompatibleDropIndexClause(
                index: (ChildObjectName)FromMutable(fragment.Index)
            );
        }
        
        public static BeginConversationTimerStatement FromMutable(ScriptDom.BeginConversationTimerStatement fragment) {
            if (fragment is null) { return null; }
            return new BeginConversationTimerStatement(
                handle: (ScalarExpression)FromMutable(fragment.Handle),
                timeout: (ScalarExpression)FromMutable(fragment.Timeout)
            );
        }
        
        public static BeginDialogStatement FromMutable(ScriptDom.BeginDialogStatement fragment) {
            if (fragment is null) { return null; }
            return new BeginDialogStatement(
                isConversation: fragment.IsConversation,
                handle: (VariableReference)FromMutable(fragment.Handle),
                initiatorServiceName: (IdentifierOrValueExpression)FromMutable(fragment.InitiatorServiceName),
                targetServiceName: (ValueExpression)FromMutable(fragment.TargetServiceName),
                instanceSpec: (ValueExpression)FromMutable(fragment.InstanceSpec),
                contractName: (IdentifierOrValueExpression)FromMutable(fragment.ContractName),
                options: fragment.Options.SelectList(c => (DialogOption)FromMutable(c))
            );
        }
        
        public static BeginEndAtomicBlockStatement FromMutable(ScriptDom.BeginEndAtomicBlockStatement fragment) {
            if (fragment is null) { return null; }
            return new BeginEndAtomicBlockStatement(
                options: fragment.Options.SelectList(c => (AtomicBlockOption)FromMutable(c)),
                statementList: (StatementList)FromMutable(fragment.StatementList)
            );
        }
        
        public static BeginEndBlockStatement FromMutable(ScriptDom.BeginEndBlockStatement fragment) {
            if (fragment is null) { return null; }
            return new BeginEndBlockStatement(
                statementList: (StatementList)FromMutable(fragment.StatementList)
            );
        }
        
        public static BeginTransactionStatement FromMutable(ScriptDom.BeginTransactionStatement fragment) {
            if (fragment is null) { return null; }
            return new BeginTransactionStatement(
                distributed: fragment.Distributed,
                markDefined: fragment.MarkDefined,
                markDescription: (ValueExpression)FromMutable(fragment.MarkDescription),
                name: (IdentifierOrValueExpression)FromMutable(fragment.Name)
            );
        }
        
        public static BinaryExpression FromMutable(ScriptDom.BinaryExpression fragment) {
            if (fragment is null) { return null; }
            return new BinaryExpression(
                binaryExpressionType: fragment.BinaryExpressionType,
                firstExpression: (ScalarExpression)FromMutable(fragment.FirstExpression),
                secondExpression: (ScalarExpression)FromMutable(fragment.SecondExpression)
            );
        }
        
        public static BinaryLiteral FromMutable(ScriptDom.BinaryLiteral fragment) {
            if (fragment is null) { return null; }
            return new BinaryLiteral(
                isLargeObject: fragment.IsLargeObject,
                @value: fragment.Value,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static BinaryQueryExpression FromMutable(ScriptDom.BinaryQueryExpression fragment) {
            if (fragment is null) { return null; }
            return new BinaryQueryExpression(
                binaryQueryExpressionType: fragment.BinaryQueryExpressionType,
                all: fragment.All,
                firstQueryExpression: (QueryExpression)FromMutable(fragment.FirstQueryExpression),
                secondQueryExpression: (QueryExpression)FromMutable(fragment.SecondQueryExpression),
                orderByClause: (OrderByClause)FromMutable(fragment.OrderByClause),
                offsetClause: (OffsetClause)FromMutable(fragment.OffsetClause),
                forClause: (ForClause)FromMutable(fragment.ForClause)
            );
        }
        
        public static BooleanBinaryExpression FromMutable(ScriptDom.BooleanBinaryExpression fragment) {
            if (fragment is null) { return null; }
            return new BooleanBinaryExpression(
                binaryExpressionType: fragment.BinaryExpressionType,
                firstExpression: (BooleanExpression)FromMutable(fragment.FirstExpression),
                secondExpression: (BooleanExpression)FromMutable(fragment.SecondExpression)
            );
        }
        
        public static BooleanComparisonExpression FromMutable(ScriptDom.BooleanComparisonExpression fragment) {
            if (fragment is null) { return null; }
            return new BooleanComparisonExpression(
                comparisonType: fragment.ComparisonType,
                firstExpression: (ScalarExpression)FromMutable(fragment.FirstExpression),
                secondExpression: (ScalarExpression)FromMutable(fragment.SecondExpression)
            );
        }
        
        public static BooleanExpressionSnippet FromMutable(ScriptDom.BooleanExpressionSnippet fragment) {
            if (fragment is null) { return null; }
            return new BooleanExpressionSnippet(
                script: fragment.Script
            );
        }
        
        public static BooleanIsNullExpression FromMutable(ScriptDom.BooleanIsNullExpression fragment) {
            if (fragment is null) { return null; }
            return new BooleanIsNullExpression(
                isNot: fragment.IsNot,
                expression: (ScalarExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static BooleanNotExpression FromMutable(ScriptDom.BooleanNotExpression fragment) {
            if (fragment is null) { return null; }
            return new BooleanNotExpression(
                expression: (BooleanExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static BooleanParenthesisExpression FromMutable(ScriptDom.BooleanParenthesisExpression fragment) {
            if (fragment is null) { return null; }
            return new BooleanParenthesisExpression(
                expression: (BooleanExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static BooleanTernaryExpression FromMutable(ScriptDom.BooleanTernaryExpression fragment) {
            if (fragment is null) { return null; }
            return new BooleanTernaryExpression(
                ternaryExpressionType: fragment.TernaryExpressionType,
                firstExpression: (ScalarExpression)FromMutable(fragment.FirstExpression),
                secondExpression: (ScalarExpression)FromMutable(fragment.SecondExpression),
                thirdExpression: (ScalarExpression)FromMutable(fragment.ThirdExpression)
            );
        }
        
        public static BoundingBoxParameter FromMutable(ScriptDom.BoundingBoxParameter fragment) {
            if (fragment is null) { return null; }
            return new BoundingBoxParameter(
                parameter: fragment.Parameter,
                @value: (ScalarExpression)FromMutable(fragment.Value)
            );
        }
        
        public static BoundingBoxSpatialIndexOption FromMutable(ScriptDom.BoundingBoxSpatialIndexOption fragment) {
            if (fragment is null) { return null; }
            return new BoundingBoxSpatialIndexOption(
                boundingBoxParameters: fragment.BoundingBoxParameters.SelectList(c => (BoundingBoxParameter)FromMutable(c))
            );
        }
        
        public static BreakStatement FromMutable(ScriptDom.BreakStatement fragment) {
            if (fragment is null) { return null; }
            return new BreakStatement(
                
            );
        }
        
        public static BrokerPriorityParameter FromMutable(ScriptDom.BrokerPriorityParameter fragment) {
            if (fragment is null) { return null; }
            return new BrokerPriorityParameter(
                isDefaultOrAny: fragment.IsDefaultOrAny,
                parameterType: fragment.ParameterType,
                parameterValue: (IdentifierOrValueExpression)FromMutable(fragment.ParameterValue)
            );
        }
        
        public static BrowseForClause FromMutable(ScriptDom.BrowseForClause fragment) {
            if (fragment is null) { return null; }
            return new BrowseForClause(
                
            );
        }
        
        public static BuiltInFunctionTableReference FromMutable(ScriptDom.BuiltInFunctionTableReference fragment) {
            if (fragment is null) { return null; }
            return new BuiltInFunctionTableReference(
                name: (Identifier)FromMutable(fragment.Name),
                parameters: fragment.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static BulkInsertOption FromMutable(ScriptDom.BulkInsertOption fragment) {
            if (fragment is null) { return null; }
            return new BulkInsertOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static BulkInsertStatement FromMutable(ScriptDom.BulkInsertStatement fragment) {
            if (fragment is null) { return null; }
            return new BulkInsertStatement(
                from: (IdentifierOrValueExpression)FromMutable(fragment.From),
                to: (SchemaObjectName)FromMutable(fragment.To),
                options: fragment.Options.SelectList(c => (BulkInsertOption)FromMutable(c))
            );
        }
        
        public static BulkOpenRowset FromMutable(ScriptDom.BulkOpenRowset fragment) {
            if (fragment is null) { return null; }
            return new BulkOpenRowset(
                dataFiles: fragment.DataFiles.SelectList(c => (StringLiteral)FromMutable(c)),
                options: fragment.Options.SelectList(c => (BulkInsertOption)FromMutable(c)),
                withColumns: fragment.WithColumns.SelectList(c => (OpenRowsetColumnDefinition)FromMutable(c)),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static CastCall FromMutable(ScriptDom.CastCall fragment) {
            if (fragment is null) { return null; }
            return new CastCall(
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                parameter: (ScalarExpression)FromMutable(fragment.Parameter),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static CatalogCollationOption FromMutable(ScriptDom.CatalogCollationOption fragment) {
            if (fragment is null) { return null; }
            return new CatalogCollationOption(
                catalogCollation: fragment.CatalogCollation,
                optionKind: fragment.OptionKind
            );
        }
        
        public static CellsPerObjectSpatialIndexOption FromMutable(ScriptDom.CellsPerObjectSpatialIndexOption fragment) {
            if (fragment is null) { return null; }
            return new CellsPerObjectSpatialIndexOption(
                @value: (Literal)FromMutable(fragment.Value)
            );
        }
        
        public static CertificateCreateLoginSource FromMutable(ScriptDom.CertificateCreateLoginSource fragment) {
            if (fragment is null) { return null; }
            return new CertificateCreateLoginSource(
                certificate: (Identifier)FromMutable(fragment.Certificate),
                credential: (Identifier)FromMutable(fragment.Credential)
            );
        }
        
        public static CertificateOption FromMutable(ScriptDom.CertificateOption fragment) {
            if (fragment is null) { return null; }
            return new CertificateOption(
                kind: fragment.Kind,
                @value: (Literal)FromMutable(fragment.Value)
            );
        }
        
        public static ChangeRetentionChangeTrackingOptionDetail FromMutable(ScriptDom.ChangeRetentionChangeTrackingOptionDetail fragment) {
            if (fragment is null) { return null; }
            return new ChangeRetentionChangeTrackingOptionDetail(
                retentionPeriod: (Literal)FromMutable(fragment.RetentionPeriod),
                unit: fragment.Unit
            );
        }
        
        public static ChangeTableChangesTableReference FromMutable(ScriptDom.ChangeTableChangesTableReference fragment) {
            if (fragment is null) { return null; }
            return new ChangeTableChangesTableReference(
                target: (SchemaObjectName)FromMutable(fragment.Target),
                sinceVersion: (ValueExpression)FromMutable(fragment.SinceVersion),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static ChangeTableVersionTableReference FromMutable(ScriptDom.ChangeTableVersionTableReference fragment) {
            if (fragment is null) { return null; }
            return new ChangeTableVersionTableReference(
                target: (SchemaObjectName)FromMutable(fragment.Target),
                primaryKeyColumns: fragment.PrimaryKeyColumns.SelectList(c => (Identifier)FromMutable(c)),
                primaryKeyValues: fragment.PrimaryKeyValues.SelectList(c => (ScalarExpression)FromMutable(c)),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static ChangeTrackingDatabaseOption FromMutable(ScriptDom.ChangeTrackingDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new ChangeTrackingDatabaseOption(
                optionState: fragment.OptionState,
                details: fragment.Details.SelectList(c => (ChangeTrackingOptionDetail)FromMutable(c)),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ChangeTrackingFullTextIndexOption FromMutable(ScriptDom.ChangeTrackingFullTextIndexOption fragment) {
            if (fragment is null) { return null; }
            return new ChangeTrackingFullTextIndexOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static CharacterSetPayloadOption FromMutable(ScriptDom.CharacterSetPayloadOption fragment) {
            if (fragment is null) { return null; }
            return new CharacterSetPayloadOption(
                isSql: fragment.IsSql,
                kind: fragment.Kind
            );
        }
        
        public static CheckConstraintDefinition FromMutable(ScriptDom.CheckConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            return new CheckConstraintDefinition(
                checkCondition: (BooleanExpression)FromMutable(fragment.CheckCondition),
                notForReplication: fragment.NotForReplication,
                constraintIdentifier: (Identifier)FromMutable(fragment.ConstraintIdentifier)
            );
        }
        
        public static CheckpointStatement FromMutable(ScriptDom.CheckpointStatement fragment) {
            if (fragment is null) { return null; }
            return new CheckpointStatement(
                duration: (Literal)FromMutable(fragment.Duration)
            );
        }
        
        public static ChildObjectName FromMutable(ScriptDom.ChildObjectName fragment) {
            if (fragment is null) { return null; }
            return new ChildObjectName(
                identifiers: fragment.Identifiers.SelectList(c => (Identifier)FromMutable(c))
            );
        }
        
        public static ClassifierEndTimeOption FromMutable(ScriptDom.ClassifierEndTimeOption fragment) {
            if (fragment is null) { return null; }
            return new ClassifierEndTimeOption(
                time: (WlmTimeLiteral)FromMutable(fragment.Time),
                optionType: fragment.OptionType
            );
        }
        
        public static ClassifierImportanceOption FromMutable(ScriptDom.ClassifierImportanceOption fragment) {
            if (fragment is null) { return null; }
            return new ClassifierImportanceOption(
                importance: fragment.Importance,
                optionType: fragment.OptionType
            );
        }
        
        public static ClassifierMemberNameOption FromMutable(ScriptDom.ClassifierMemberNameOption fragment) {
            if (fragment is null) { return null; }
            return new ClassifierMemberNameOption(
                memberName: (StringLiteral)FromMutable(fragment.MemberName),
                optionType: fragment.OptionType
            );
        }
        
        public static ClassifierStartTimeOption FromMutable(ScriptDom.ClassifierStartTimeOption fragment) {
            if (fragment is null) { return null; }
            return new ClassifierStartTimeOption(
                time: (WlmTimeLiteral)FromMutable(fragment.Time),
                optionType: fragment.OptionType
            );
        }
        
        public static ClassifierWlmContextOption FromMutable(ScriptDom.ClassifierWlmContextOption fragment) {
            if (fragment is null) { return null; }
            return new ClassifierWlmContextOption(
                wlmContext: (StringLiteral)FromMutable(fragment.WlmContext),
                optionType: fragment.OptionType
            );
        }
        
        public static ClassifierWlmLabelOption FromMutable(ScriptDom.ClassifierWlmLabelOption fragment) {
            if (fragment is null) { return null; }
            return new ClassifierWlmLabelOption(
                wlmLabel: (StringLiteral)FromMutable(fragment.WlmLabel),
                optionType: fragment.OptionType
            );
        }
        
        public static ClassifierWorkloadGroupOption FromMutable(ScriptDom.ClassifierWorkloadGroupOption fragment) {
            if (fragment is null) { return null; }
            return new ClassifierWorkloadGroupOption(
                workloadGroupName: (StringLiteral)FromMutable(fragment.WorkloadGroupName),
                optionType: fragment.OptionType
            );
        }
        
        public static CloseCursorStatement FromMutable(ScriptDom.CloseCursorStatement fragment) {
            if (fragment is null) { return null; }
            return new CloseCursorStatement(
                cursor: (CursorId)FromMutable(fragment.Cursor)
            );
        }
        
        public static CloseMasterKeyStatement FromMutable(ScriptDom.CloseMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new CloseMasterKeyStatement(
                
            );
        }
        
        public static CloseSymmetricKeyStatement FromMutable(ScriptDom.CloseSymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new CloseSymmetricKeyStatement(
                name: (Identifier)FromMutable(fragment.Name),
                all: fragment.All
            );
        }
        
        public static CoalesceExpression FromMutable(ScriptDom.CoalesceExpression fragment) {
            if (fragment is null) { return null; }
            return new CoalesceExpression(
                expressions: fragment.Expressions.SelectList(c => (ScalarExpression)FromMutable(c)),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static ColumnDefinition FromMutable(ScriptDom.ColumnDefinition fragment) {
            if (fragment is null) { return null; }
            return new ColumnDefinition(
                computedColumnExpression: (ScalarExpression)FromMutable(fragment.ComputedColumnExpression),
                isPersisted: fragment.IsPersisted,
                defaultConstraint: (DefaultConstraintDefinition)FromMutable(fragment.DefaultConstraint),
                identityOptions: (IdentityOptions)FromMutable(fragment.IdentityOptions),
                isRowGuidCol: fragment.IsRowGuidCol,
                constraints: fragment.Constraints.SelectList(c => (ConstraintDefinition)FromMutable(c)),
                storageOptions: (ColumnStorageOptions)FromMutable(fragment.StorageOptions),
                index: (IndexDefinition)FromMutable(fragment.Index),
                generatedAlways: fragment.GeneratedAlways,
                isHidden: fragment.IsHidden,
                encryption: (ColumnEncryptionDefinition)FromMutable(fragment.Encryption),
                isMasked: fragment.IsMasked,
                maskingFunction: (StringLiteral)FromMutable(fragment.MaskingFunction),
                columnIdentifier: (Identifier)FromMutable(fragment.ColumnIdentifier),
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static ColumnDefinitionBase FromMutable(ScriptDom.ColumnDefinitionBase fragment) {
            if (fragment is null) { return null; }
            return new ColumnDefinitionBase(
                columnIdentifier: (Identifier)FromMutable(fragment.ColumnIdentifier),
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static ColumnEncryptionAlgorithmNameParameter FromMutable(ScriptDom.ColumnEncryptionAlgorithmNameParameter fragment) {
            if (fragment is null) { return null; }
            return new ColumnEncryptionAlgorithmNameParameter(
                algorithm: (StringLiteral)FromMutable(fragment.Algorithm),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnEncryptionAlgorithmParameter FromMutable(ScriptDom.ColumnEncryptionAlgorithmParameter fragment) {
            if (fragment is null) { return null; }
            return new ColumnEncryptionAlgorithmParameter(
                encryptionAlgorithm: (StringLiteral)FromMutable(fragment.EncryptionAlgorithm),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnEncryptionDefinition FromMutable(ScriptDom.ColumnEncryptionDefinition fragment) {
            if (fragment is null) { return null; }
            return new ColumnEncryptionDefinition(
                parameters: fragment.Parameters.SelectList(c => (ColumnEncryptionDefinitionParameter)FromMutable(c))
            );
        }
        
        public static ColumnEncryptionKeyNameParameter FromMutable(ScriptDom.ColumnEncryptionKeyNameParameter fragment) {
            if (fragment is null) { return null; }
            return new ColumnEncryptionKeyNameParameter(
                name: (Identifier)FromMutable(fragment.Name),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnEncryptionKeyValue FromMutable(ScriptDom.ColumnEncryptionKeyValue fragment) {
            if (fragment is null) { return null; }
            return new ColumnEncryptionKeyValue(
                parameters: fragment.Parameters.SelectList(c => (ColumnEncryptionKeyValueParameter)FromMutable(c))
            );
        }
        
        public static ColumnEncryptionTypeParameter FromMutable(ScriptDom.ColumnEncryptionTypeParameter fragment) {
            if (fragment is null) { return null; }
            return new ColumnEncryptionTypeParameter(
                encryptionType: fragment.EncryptionType,
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnMasterKeyEnclaveComputationsParameter FromMutable(ScriptDom.ColumnMasterKeyEnclaveComputationsParameter fragment) {
            if (fragment is null) { return null; }
            return new ColumnMasterKeyEnclaveComputationsParameter(
                signature: (BinaryLiteral)FromMutable(fragment.Signature),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnMasterKeyNameParameter FromMutable(ScriptDom.ColumnMasterKeyNameParameter fragment) {
            if (fragment is null) { return null; }
            return new ColumnMasterKeyNameParameter(
                name: (Identifier)FromMutable(fragment.Name),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnMasterKeyPathParameter FromMutable(ScriptDom.ColumnMasterKeyPathParameter fragment) {
            if (fragment is null) { return null; }
            return new ColumnMasterKeyPathParameter(
                path: (StringLiteral)FromMutable(fragment.Path),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnMasterKeyStoreProviderNameParameter FromMutable(ScriptDom.ColumnMasterKeyStoreProviderNameParameter fragment) {
            if (fragment is null) { return null; }
            return new ColumnMasterKeyStoreProviderNameParameter(
                name: (StringLiteral)FromMutable(fragment.Name),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static ColumnReferenceExpression FromMutable(ScriptDom.ColumnReferenceExpression fragment) {
            if (fragment is null) { return null; }
            return new ColumnReferenceExpression(
                columnType: fragment.ColumnType,
                multiPartIdentifier: (MultiPartIdentifier)FromMutable(fragment.MultiPartIdentifier),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static ColumnStorageOptions FromMutable(ScriptDom.ColumnStorageOptions fragment) {
            if (fragment is null) { return null; }
            return new ColumnStorageOptions(
                isFileStream: fragment.IsFileStream,
                sparseOption: fragment.SparseOption
            );
        }
        
        public static ColumnWithSortOrder FromMutable(ScriptDom.ColumnWithSortOrder fragment) {
            if (fragment is null) { return null; }
            return new ColumnWithSortOrder(
                column: (ColumnReferenceExpression)FromMutable(fragment.Column),
                sortOrder: fragment.SortOrder
            );
        }
        
        public static CommandSecurityElement80 FromMutable(ScriptDom.CommandSecurityElement80 fragment) {
            if (fragment is null) { return null; }
            return new CommandSecurityElement80(
                all: fragment.All,
                commandOptions: fragment.CommandOptions
            );
        }
        
        public static CommitTransactionStatement FromMutable(ScriptDom.CommitTransactionStatement fragment) {
            if (fragment is null) { return null; }
            return new CommitTransactionStatement(
                delayedDurabilityOption: fragment.DelayedDurabilityOption,
                name: (IdentifierOrValueExpression)FromMutable(fragment.Name)
            );
        }
        
        public static CommonTableExpression FromMutable(ScriptDom.CommonTableExpression fragment) {
            if (fragment is null) { return null; }
            return new CommonTableExpression(
                expressionName: (Identifier)FromMutable(fragment.ExpressionName),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                queryExpression: (QueryExpression)FromMutable(fragment.QueryExpression)
            );
        }
        
        public static CompositeGroupingSpecification FromMutable(ScriptDom.CompositeGroupingSpecification fragment) {
            if (fragment is null) { return null; }
            return new CompositeGroupingSpecification(
                items: fragment.Items.SelectList(c => (GroupingSpecification)FromMutable(c))
            );
        }
        
        public static CompressionDelayIndexOption FromMutable(ScriptDom.CompressionDelayIndexOption fragment) {
            if (fragment is null) { return null; }
            return new CompressionDelayIndexOption(
                expression: (ScalarExpression)FromMutable(fragment.Expression),
                timeUnit: fragment.TimeUnit,
                optionKind: fragment.OptionKind
            );
        }
        
        public static CompressionEndpointProtocolOption FromMutable(ScriptDom.CompressionEndpointProtocolOption fragment) {
            if (fragment is null) { return null; }
            return new CompressionEndpointProtocolOption(
                isEnabled: fragment.IsEnabled,
                kind: fragment.Kind
            );
        }
        
        public static CompressionPartitionRange FromMutable(ScriptDom.CompressionPartitionRange fragment) {
            if (fragment is null) { return null; }
            return new CompressionPartitionRange(
                from: (ScalarExpression)FromMutable(fragment.From),
                to: (ScalarExpression)FromMutable(fragment.To)
            );
        }
        
        public static ComputeClause FromMutable(ScriptDom.ComputeClause fragment) {
            if (fragment is null) { return null; }
            return new ComputeClause(
                computeFunctions: fragment.ComputeFunctions.SelectList(c => (ComputeFunction)FromMutable(c)),
                byExpressions: fragment.ByExpressions.SelectList(c => (ScalarExpression)FromMutable(c))
            );
        }
        
        public static ComputeFunction FromMutable(ScriptDom.ComputeFunction fragment) {
            if (fragment is null) { return null; }
            return new ComputeFunction(
                computeFunctionType: fragment.ComputeFunctionType,
                expression: (ScalarExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static ContainmentDatabaseOption FromMutable(ScriptDom.ContainmentDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new ContainmentDatabaseOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static ContinueStatement FromMutable(ScriptDom.ContinueStatement fragment) {
            if (fragment is null) { return null; }
            return new ContinueStatement(
                
            );
        }
        
        public static ContractMessage FromMutable(ScriptDom.ContractMessage fragment) {
            if (fragment is null) { return null; }
            return new ContractMessage(
                name: (Identifier)FromMutable(fragment.Name),
                sentBy: fragment.SentBy
            );
        }
        
        public static ConvertCall FromMutable(ScriptDom.ConvertCall fragment) {
            if (fragment is null) { return null; }
            return new ConvertCall(
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                parameter: (ScalarExpression)FromMutable(fragment.Parameter),
                style: (ScalarExpression)FromMutable(fragment.Style),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static CopyColumnOption FromMutable(ScriptDom.CopyColumnOption fragment) {
            if (fragment is null) { return null; }
            return new CopyColumnOption(
                columnName: (Identifier)FromMutable(fragment.ColumnName),
                defaultValue: (ScalarExpression)FromMutable(fragment.DefaultValue),
                fieldNumber: (IntegerLiteral)FromMutable(fragment.FieldNumber)
            );
        }
        
        public static CopyCredentialOption FromMutable(ScriptDom.CopyCredentialOption fragment) {
            if (fragment is null) { return null; }
            return new CopyCredentialOption(
                identity: (StringLiteral)FromMutable(fragment.Identity),
                secret: (StringLiteral)FromMutable(fragment.Secret)
            );
        }
        
        public static CopyOption FromMutable(ScriptDom.CopyOption fragment) {
            if (fragment is null) { return null; }
            return new CopyOption(
                kind: fragment.Kind,
                @value: (CopyStatementOptionBase)FromMutable(fragment.Value)
            );
        }
        
        public static CopyStatement FromMutable(ScriptDom.CopyStatement fragment) {
            if (fragment is null) { return null; }
            return new CopyStatement(
                from: fragment.From.SelectList(c => (StringLiteral)FromMutable(c)),
                into: (SchemaObjectName)FromMutable(fragment.Into),
                options: fragment.Options.SelectList(c => (CopyOption)FromMutable(c)),
                optimizerHints: fragment.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
            );
        }
        
        public static CreateAggregateStatement FromMutable(ScriptDom.CreateAggregateStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateAggregateStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                assemblyName: (AssemblyName)FromMutable(fragment.AssemblyName),
                parameters: fragment.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                returnType: (DataTypeReference)FromMutable(fragment.ReturnType)
            );
        }
        
        public static CreateApplicationRoleStatement FromMutable(ScriptDom.CreateApplicationRoleStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateApplicationRoleStatement(
                name: (Identifier)FromMutable(fragment.Name),
                applicationRoleOptions: fragment.ApplicationRoleOptions.SelectList(c => (ApplicationRoleOption)FromMutable(c))
            );
        }
        
        public static CreateAssemblyStatement FromMutable(ScriptDom.CreateAssemblyStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateAssemblyStatement(
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name),
                parameters: fragment.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                options: fragment.Options.SelectList(c => (AssemblyOption)FromMutable(c))
            );
        }
        
        public static CreateAsymmetricKeyStatement FromMutable(ScriptDom.CreateAsymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateAsymmetricKeyStatement(
                name: (Identifier)FromMutable(fragment.Name),
                keySource: (EncryptionSource)FromMutable(fragment.KeySource),
                encryptionAlgorithm: fragment.EncryptionAlgorithm,
                password: (Literal)FromMutable(fragment.Password),
                owner: (Identifier)FromMutable(fragment.Owner)
            );
        }
        
        public static CreateAvailabilityGroupStatement FromMutable(ScriptDom.CreateAvailabilityGroupStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateAvailabilityGroupStatement(
                name: (Identifier)FromMutable(fragment.Name),
                options: fragment.Options.SelectList(c => (AvailabilityGroupOption)FromMutable(c)),
                databases: fragment.Databases.SelectList(c => (Identifier)FromMutable(c)),
                replicas: fragment.Replicas.SelectList(c => (AvailabilityReplica)FromMutable(c))
            );
        }
        
        public static CreateBrokerPriorityStatement FromMutable(ScriptDom.CreateBrokerPriorityStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateBrokerPriorityStatement(
                name: (Identifier)FromMutable(fragment.Name),
                brokerPriorityParameters: fragment.BrokerPriorityParameters.SelectList(c => (BrokerPriorityParameter)FromMutable(c))
            );
        }
        
        public static CreateCertificateStatement FromMutable(ScriptDom.CreateCertificateStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateCertificateStatement(
                certificateSource: (EncryptionSource)FromMutable(fragment.CertificateSource),
                certificateOptions: fragment.CertificateOptions.SelectList(c => (CertificateOption)FromMutable(c)),
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name),
                activeForBeginDialog: fragment.ActiveForBeginDialog,
                privateKeyPath: (Literal)FromMutable(fragment.PrivateKeyPath),
                encryptionPassword: (Literal)FromMutable(fragment.EncryptionPassword),
                decryptionPassword: (Literal)FromMutable(fragment.DecryptionPassword)
            );
        }
        
        public static CreateColumnEncryptionKeyStatement FromMutable(ScriptDom.CreateColumnEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateColumnEncryptionKeyStatement(
                name: (Identifier)FromMutable(fragment.Name),
                columnEncryptionKeyValues: fragment.ColumnEncryptionKeyValues.SelectList(c => (ColumnEncryptionKeyValue)FromMutable(c))
            );
        }
        
        public static CreateColumnMasterKeyStatement FromMutable(ScriptDom.CreateColumnMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateColumnMasterKeyStatement(
                name: (Identifier)FromMutable(fragment.Name),
                parameters: fragment.Parameters.SelectList(c => (ColumnMasterKeyParameter)FromMutable(c))
            );
        }
        
        public static CreateColumnStoreIndexStatement FromMutable(ScriptDom.CreateColumnStoreIndexStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateColumnStoreIndexStatement(
                name: (Identifier)FromMutable(fragment.Name),
                clustered: fragment.Clustered,
                onName: (SchemaObjectName)FromMutable(fragment.OnName),
                columns: fragment.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                filterPredicate: (BooleanExpression)FromMutable(fragment.FilterPredicate),
                indexOptions: fragment.IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable(fragment.OnFileGroupOrPartitionScheme),
                orderedColumns: fragment.OrderedColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
            );
        }
        
        public static CreateContractStatement FromMutable(ScriptDom.CreateContractStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateContractStatement(
                name: (Identifier)FromMutable(fragment.Name),
                messages: fragment.Messages.SelectList(c => (ContractMessage)FromMutable(c)),
                owner: (Identifier)FromMutable(fragment.Owner)
            );
        }
        
        public static CreateCredentialStatement FromMutable(ScriptDom.CreateCredentialStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateCredentialStatement(
                cryptographicProviderName: (Identifier)FromMutable(fragment.CryptographicProviderName),
                name: (Identifier)FromMutable(fragment.Name),
                identity: (Literal)FromMutable(fragment.Identity),
                secret: (Literal)FromMutable(fragment.Secret),
                isDatabaseScoped: fragment.IsDatabaseScoped
            );
        }
        
        public static CreateCryptographicProviderStatement FromMutable(ScriptDom.CreateCryptographicProviderStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateCryptographicProviderStatement(
                name: (Identifier)FromMutable(fragment.Name),
                file: (Literal)FromMutable(fragment.File)
            );
        }
        
        public static CreateDatabaseAuditSpecificationStatement FromMutable(ScriptDom.CreateDatabaseAuditSpecificationStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateDatabaseAuditSpecificationStatement(
                auditState: fragment.AuditState,
                parts: fragment.Parts.SelectList(c => (AuditSpecificationPart)FromMutable(c)),
                specificationName: (Identifier)FromMutable(fragment.SpecificationName),
                auditName: (Identifier)FromMutable(fragment.AuditName)
            );
        }
        
        public static CreateDatabaseEncryptionKeyStatement FromMutable(ScriptDom.CreateDatabaseEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateDatabaseEncryptionKeyStatement(
                encryptor: (CryptoMechanism)FromMutable(fragment.Encryptor),
                algorithm: fragment.Algorithm
            );
        }
        
        public static CreateDatabaseStatement FromMutable(ScriptDom.CreateDatabaseStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateDatabaseStatement(
                databaseName: (Identifier)FromMutable(fragment.DatabaseName),
                containment: (ContainmentDatabaseOption)FromMutable(fragment.Containment),
                fileGroups: fragment.FileGroups.SelectList(c => (FileGroupDefinition)FromMutable(c)),
                logOn: fragment.LogOn.SelectList(c => (FileDeclaration)FromMutable(c)),
                options: fragment.Options.SelectList(c => (DatabaseOption)FromMutable(c)),
                attachMode: fragment.AttachMode,
                databaseSnapshot: (Identifier)FromMutable(fragment.DatabaseSnapshot),
                copyOf: (MultiPartIdentifier)FromMutable(fragment.CopyOf),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static CreateDefaultStatement FromMutable(ScriptDom.CreateDefaultStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateDefaultStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                expression: (ScalarExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static CreateEndpointStatement FromMutable(ScriptDom.CreateEndpointStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateEndpointStatement(
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name),
                state: fragment.State,
                affinity: (EndpointAffinity)FromMutable(fragment.Affinity),
                protocol: fragment.Protocol,
                protocolOptions: fragment.ProtocolOptions.SelectList(c => (EndpointProtocolOption)FromMutable(c)),
                endpointType: fragment.EndpointType,
                payloadOptions: fragment.PayloadOptions.SelectList(c => (PayloadOption)FromMutable(c))
            );
        }
        
        public static CreateEventNotificationStatement FromMutable(ScriptDom.CreateEventNotificationStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateEventNotificationStatement(
                name: (Identifier)FromMutable(fragment.Name),
                scope: (EventNotificationObjectScope)FromMutable(fragment.Scope),
                withFanIn: fragment.WithFanIn,
                eventTypeGroups: fragment.EventTypeGroups.SelectList(c => (EventTypeGroupContainer)FromMutable(c)),
                brokerService: (Literal)FromMutable(fragment.BrokerService),
                brokerInstanceSpecifier: (Literal)FromMutable(fragment.BrokerInstanceSpecifier)
            );
        }
        
        public static CreateEventSessionStatement FromMutable(ScriptDom.CreateEventSessionStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateEventSessionStatement(
                name: (Identifier)FromMutable(fragment.Name),
                sessionScope: fragment.SessionScope,
                eventDeclarations: fragment.EventDeclarations.SelectList(c => (EventDeclaration)FromMutable(c)),
                targetDeclarations: fragment.TargetDeclarations.SelectList(c => (TargetDeclaration)FromMutable(c)),
                sessionOptions: fragment.SessionOptions.SelectList(c => (SessionOption)FromMutable(c))
            );
        }
        
        public static CreateExternalDataSourceStatement FromMutable(ScriptDom.CreateExternalDataSourceStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateExternalDataSourceStatement(
                name: (Identifier)FromMutable(fragment.Name),
                dataSourceType: fragment.DataSourceType,
                location: (Literal)FromMutable(fragment.Location),
                pushdownOption: fragment.PushdownOption,
                externalDataSourceOptions: fragment.ExternalDataSourceOptions.SelectList(c => (ExternalDataSourceOption)FromMutable(c))
            );
        }
        
        public static CreateExternalFileFormatStatement FromMutable(ScriptDom.CreateExternalFileFormatStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateExternalFileFormatStatement(
                name: (Identifier)FromMutable(fragment.Name),
                formatType: fragment.FormatType,
                externalFileFormatOptions: fragment.ExternalFileFormatOptions.SelectList(c => (ExternalFileFormatOption)FromMutable(c))
            );
        }
        
        public static CreateExternalLanguageStatement FromMutable(ScriptDom.CreateExternalLanguageStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateExternalLanguageStatement(
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name),
                externalLanguageFiles: fragment.ExternalLanguageFiles.SelectList(c => (ExternalLanguageFileOption)FromMutable(c))
            );
        }
        
        public static CreateExternalLibraryStatement FromMutable(ScriptDom.CreateExternalLibraryStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateExternalLibraryStatement(
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name),
                language: (StringLiteral)FromMutable(fragment.Language),
                externalLibraryFiles: fragment.ExternalLibraryFiles.SelectList(c => (ExternalLibraryFileOption)FromMutable(c))
            );
        }
        
        public static CreateExternalResourcePoolStatement FromMutable(ScriptDom.CreateExternalResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateExternalResourcePoolStatement(
                name: (Identifier)FromMutable(fragment.Name),
                externalResourcePoolParameters: fragment.ExternalResourcePoolParameters.SelectList(c => (ExternalResourcePoolParameter)FromMutable(c))
            );
        }
        
        public static CreateExternalStreamingJobStatement FromMutable(ScriptDom.CreateExternalStreamingJobStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateExternalStreamingJobStatement(
                name: (StringLiteral)FromMutable(fragment.Name),
                statement: (StringLiteral)FromMutable(fragment.Statement)
            );
        }
        
        public static CreateExternalStreamStatement FromMutable(ScriptDom.CreateExternalStreamStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateExternalStreamStatement(
                name: (Identifier)FromMutable(fragment.Name),
                location: (Literal)FromMutable(fragment.Location),
                inputOptions: (Literal)FromMutable(fragment.InputOptions),
                outputOptions: (Literal)FromMutable(fragment.OutputOptions),
                externalStreamOptions: fragment.ExternalStreamOptions.SelectList(c => (ExternalStreamOption)FromMutable(c))
            );
        }
        
        public static CreateExternalTableStatement FromMutable(ScriptDom.CreateExternalTableStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateExternalTableStatement(
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName),
                columnDefinitions: fragment.ColumnDefinitions.SelectList(c => (ExternalTableColumnDefinition)FromMutable(c)),
                dataSource: (Identifier)FromMutable(fragment.DataSource),
                externalTableOptions: fragment.ExternalTableOptions.SelectList(c => (ExternalTableOption)FromMutable(c)),
                selectStatement: (SelectStatement)FromMutable(fragment.SelectStatement)
            );
        }
        
        public static CreateFederationStatement FromMutable(ScriptDom.CreateFederationStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateFederationStatement(
                name: (Identifier)FromMutable(fragment.Name),
                distributionName: (Identifier)FromMutable(fragment.DistributionName),
                dataType: (DataTypeReference)FromMutable(fragment.DataType)
            );
        }
        
        public static CreateFullTextCatalogStatement FromMutable(ScriptDom.CreateFullTextCatalogStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateFullTextCatalogStatement(
                fileGroup: (Identifier)FromMutable(fragment.FileGroup),
                path: (Literal)FromMutable(fragment.Path),
                isDefault: fragment.IsDefault,
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name),
                options: fragment.Options.SelectList(c => (FullTextCatalogOption)FromMutable(c))
            );
        }
        
        public static CreateFullTextIndexStatement FromMutable(ScriptDom.CreateFullTextIndexStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateFullTextIndexStatement(
                onName: (SchemaObjectName)FromMutable(fragment.OnName),
                fullTextIndexColumns: fragment.FullTextIndexColumns.SelectList(c => (FullTextIndexColumn)FromMutable(c)),
                keyIndexName: (Identifier)FromMutable(fragment.KeyIndexName),
                catalogAndFileGroup: (FullTextCatalogAndFileGroup)FromMutable(fragment.CatalogAndFileGroup),
                options: fragment.Options.SelectList(c => (FullTextIndexOption)FromMutable(c))
            );
        }
        
        public static CreateFullTextStopListStatement FromMutable(ScriptDom.CreateFullTextStopListStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateFullTextStopListStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isSystemStopList: fragment.IsSystemStopList,
                databaseName: (Identifier)FromMutable(fragment.DatabaseName),
                sourceStopListName: (Identifier)FromMutable(fragment.SourceStopListName),
                owner: (Identifier)FromMutable(fragment.Owner)
            );
        }
        
        public static CreateFunctionStatement FromMutable(ScriptDom.CreateFunctionStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateFunctionStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                returnType: (FunctionReturnType)FromMutable(fragment.ReturnType),
                options: fragment.Options.SelectList(c => (FunctionOption)FromMutable(c)),
                orderHint: (OrderBulkInsertOption)FromMutable(fragment.OrderHint),
                parameters: fragment.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                statementList: (StatementList)FromMutable(fragment.StatementList),
                methodSpecifier: (MethodSpecifier)FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static CreateIndexStatement FromMutable(ScriptDom.CreateIndexStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateIndexStatement(
                translated80SyntaxTo90: fragment.Translated80SyntaxTo90,
                unique: fragment.Unique,
                clustered: fragment.Clustered,
                columns: fragment.Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                includeColumns: fragment.IncludeColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable(fragment.OnFileGroupOrPartitionScheme),
                filterPredicate: (BooleanExpression)FromMutable(fragment.FilterPredicate),
                fileStreamOn: (IdentifierOrValueExpression)FromMutable(fragment.FileStreamOn),
                name: (Identifier)FromMutable(fragment.Name),
                onName: (SchemaObjectName)FromMutable(fragment.OnName),
                indexOptions: fragment.IndexOptions.SelectList(c => (IndexOption)FromMutable(c))
            );
        }
        
        public static CreateLoginStatement FromMutable(ScriptDom.CreateLoginStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateLoginStatement(
                name: (Identifier)FromMutable(fragment.Name),
                source: (CreateLoginSource)FromMutable(fragment.Source)
            );
        }
        
        public static CreateMasterKeyStatement FromMutable(ScriptDom.CreateMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateMasterKeyStatement(
                password: (Literal)FromMutable(fragment.Password)
            );
        }
        
        public static CreateMessageTypeStatement FromMutable(ScriptDom.CreateMessageTypeStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateMessageTypeStatement(
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name),
                validationMethod: fragment.ValidationMethod,
                xmlSchemaCollectionName: (SchemaObjectName)FromMutable(fragment.XmlSchemaCollectionName)
            );
        }
        
        public static CreateOrAlterFunctionStatement FromMutable(ScriptDom.CreateOrAlterFunctionStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateOrAlterFunctionStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                returnType: (FunctionReturnType)FromMutable(fragment.ReturnType),
                options: fragment.Options.SelectList(c => (FunctionOption)FromMutable(c)),
                orderHint: (OrderBulkInsertOption)FromMutable(fragment.OrderHint),
                parameters: fragment.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                statementList: (StatementList)FromMutable(fragment.StatementList),
                methodSpecifier: (MethodSpecifier)FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static CreateOrAlterProcedureStatement FromMutable(ScriptDom.CreateOrAlterProcedureStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateOrAlterProcedureStatement(
                procedureReference: (ProcedureReference)FromMutable(fragment.ProcedureReference),
                isForReplication: fragment.IsForReplication,
                options: fragment.Options.SelectList(c => (ProcedureOption)FromMutable(c)),
                parameters: fragment.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                statementList: (StatementList)FromMutable(fragment.StatementList),
                methodSpecifier: (MethodSpecifier)FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static CreateOrAlterTriggerStatement FromMutable(ScriptDom.CreateOrAlterTriggerStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateOrAlterTriggerStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                triggerObject: (TriggerObject)FromMutable(fragment.TriggerObject),
                options: fragment.Options.SelectList(c => (TriggerOption)FromMutable(c)),
                triggerType: fragment.TriggerType,
                triggerActions: fragment.TriggerActions.SelectList(c => (TriggerAction)FromMutable(c)),
                withAppend: fragment.WithAppend,
                isNotForReplication: fragment.IsNotForReplication,
                statementList: (StatementList)FromMutable(fragment.StatementList),
                methodSpecifier: (MethodSpecifier)FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static CreateOrAlterViewStatement FromMutable(ScriptDom.CreateOrAlterViewStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateOrAlterViewStatement(
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                viewOptions: fragment.ViewOptions.SelectList(c => (ViewOption)FromMutable(c)),
                selectStatement: (SelectStatement)FromMutable(fragment.SelectStatement),
                withCheckOption: fragment.WithCheckOption,
                isMaterialized: fragment.IsMaterialized
            );
        }
        
        public static CreatePartitionFunctionStatement FromMutable(ScriptDom.CreatePartitionFunctionStatement fragment) {
            if (fragment is null) { return null; }
            return new CreatePartitionFunctionStatement(
                name: (Identifier)FromMutable(fragment.Name),
                parameterType: (PartitionParameterType)FromMutable(fragment.ParameterType),
                range: fragment.Range,
                boundaryValues: fragment.BoundaryValues.SelectList(c => (ScalarExpression)FromMutable(c))
            );
        }
        
        public static CreatePartitionSchemeStatement FromMutable(ScriptDom.CreatePartitionSchemeStatement fragment) {
            if (fragment is null) { return null; }
            return new CreatePartitionSchemeStatement(
                name: (Identifier)FromMutable(fragment.Name),
                partitionFunction: (Identifier)FromMutable(fragment.PartitionFunction),
                isAll: fragment.IsAll,
                fileGroups: fragment.FileGroups.SelectList(c => (IdentifierOrValueExpression)FromMutable(c))
            );
        }
        
        public static CreateProcedureStatement FromMutable(ScriptDom.CreateProcedureStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateProcedureStatement(
                procedureReference: (ProcedureReference)FromMutable(fragment.ProcedureReference),
                isForReplication: fragment.IsForReplication,
                options: fragment.Options.SelectList(c => (ProcedureOption)FromMutable(c)),
                parameters: fragment.Parameters.SelectList(c => (ProcedureParameter)FromMutable(c)),
                statementList: (StatementList)FromMutable(fragment.StatementList),
                methodSpecifier: (MethodSpecifier)FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static CreateQueueStatement FromMutable(ScriptDom.CreateQueueStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateQueueStatement(
                onFileGroup: (IdentifierOrValueExpression)FromMutable(fragment.OnFileGroup),
                name: (SchemaObjectName)FromMutable(fragment.Name),
                queueOptions: fragment.QueueOptions.SelectList(c => (QueueOption)FromMutable(c))
            );
        }
        
        public static CreateRemoteServiceBindingStatement FromMutable(ScriptDom.CreateRemoteServiceBindingStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateRemoteServiceBindingStatement(
                service: (Literal)FromMutable(fragment.Service),
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name),
                options: fragment.Options.SelectList(c => (RemoteServiceBindingOption)FromMutable(c))
            );
        }
        
        public static CreateResourcePoolStatement FromMutable(ScriptDom.CreateResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateResourcePoolStatement(
                name: (Identifier)FromMutable(fragment.Name),
                resourcePoolParameters: fragment.ResourcePoolParameters.SelectList(c => (ResourcePoolParameter)FromMutable(c))
            );
        }
        
        public static CreateRoleStatement FromMutable(ScriptDom.CreateRoleStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateRoleStatement(
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name)
            );
        }
        
        public static CreateRouteStatement FromMutable(ScriptDom.CreateRouteStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateRouteStatement(
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name),
                routeOptions: fragment.RouteOptions.SelectList(c => (RouteOption)FromMutable(c))
            );
        }
        
        public static CreateRuleStatement FromMutable(ScriptDom.CreateRuleStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateRuleStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                expression: (BooleanExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static CreateSchemaStatement FromMutable(ScriptDom.CreateSchemaStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateSchemaStatement(
                name: (Identifier)FromMutable(fragment.Name),
                statementList: (StatementList)FromMutable(fragment.StatementList),
                owner: (Identifier)FromMutable(fragment.Owner)
            );
        }
        
        public static CreateSearchPropertyListStatement FromMutable(ScriptDom.CreateSearchPropertyListStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateSearchPropertyListStatement(
                name: (Identifier)FromMutable(fragment.Name),
                sourceSearchPropertyList: (MultiPartIdentifier)FromMutable(fragment.SourceSearchPropertyList),
                owner: (Identifier)FromMutable(fragment.Owner)
            );
        }
        
        public static CreateSecurityPolicyStatement FromMutable(ScriptDom.CreateSecurityPolicyStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateSecurityPolicyStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                notForReplication: fragment.NotForReplication,
                securityPolicyOptions: fragment.SecurityPolicyOptions.SelectList(c => (SecurityPolicyOption)FromMutable(c)),
                securityPredicateActions: fragment.SecurityPredicateActions.SelectList(c => (SecurityPredicateAction)FromMutable(c)),
                actionType: fragment.ActionType
            );
        }
        
        public static CreateSelectiveXmlIndexStatement FromMutable(ScriptDom.CreateSelectiveXmlIndexStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateSelectiveXmlIndexStatement(
                isSecondary: fragment.IsSecondary,
                xmlColumn: (Identifier)FromMutable(fragment.XmlColumn),
                promotedPaths: fragment.PromotedPaths.SelectList(c => (SelectiveXmlIndexPromotedPath)FromMutable(c)),
                xmlNamespaces: (XmlNamespaces)FromMutable(fragment.XmlNamespaces),
                usingXmlIndexName: (Identifier)FromMutable(fragment.UsingXmlIndexName),
                pathName: (Identifier)FromMutable(fragment.PathName),
                name: (Identifier)FromMutable(fragment.Name),
                onName: (SchemaObjectName)FromMutable(fragment.OnName),
                indexOptions: fragment.IndexOptions.SelectList(c => (IndexOption)FromMutable(c))
            );
        }
        
        public static CreateSequenceStatement FromMutable(ScriptDom.CreateSequenceStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateSequenceStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                sequenceOptions: fragment.SequenceOptions.SelectList(c => (SequenceOption)FromMutable(c))
            );
        }
        
        public static CreateServerAuditSpecificationStatement FromMutable(ScriptDom.CreateServerAuditSpecificationStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateServerAuditSpecificationStatement(
                auditState: fragment.AuditState,
                parts: fragment.Parts.SelectList(c => (AuditSpecificationPart)FromMutable(c)),
                specificationName: (Identifier)FromMutable(fragment.SpecificationName),
                auditName: (Identifier)FromMutable(fragment.AuditName)
            );
        }
        
        public static CreateServerAuditStatement FromMutable(ScriptDom.CreateServerAuditStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateServerAuditStatement(
                auditName: (Identifier)FromMutable(fragment.AuditName),
                auditTarget: (AuditTarget)FromMutable(fragment.AuditTarget),
                options: fragment.Options.SelectList(c => (AuditOption)FromMutable(c)),
                predicateExpression: (BooleanExpression)FromMutable(fragment.PredicateExpression)
            );
        }
        
        public static CreateServerRoleStatement FromMutable(ScriptDom.CreateServerRoleStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateServerRoleStatement(
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name)
            );
        }
        
        public static CreateServiceStatement FromMutable(ScriptDom.CreateServiceStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateServiceStatement(
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name),
                queueName: (SchemaObjectName)FromMutable(fragment.QueueName),
                serviceContracts: fragment.ServiceContracts.SelectList(c => (ServiceContract)FromMutable(c))
            );
        }
        
        public static CreateSpatialIndexStatement FromMutable(ScriptDom.CreateSpatialIndexStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateSpatialIndexStatement(
                name: (Identifier)FromMutable(fragment.Name),
                @object: (SchemaObjectName)FromMutable(fragment.Object),
                spatialColumnName: (Identifier)FromMutable(fragment.SpatialColumnName),
                spatialIndexingScheme: fragment.SpatialIndexingScheme,
                spatialIndexOptions: fragment.SpatialIndexOptions.SelectList(c => (SpatialIndexOption)FromMutable(c)),
                onFileGroup: (IdentifierOrValueExpression)FromMutable(fragment.OnFileGroup)
            );
        }
        
        public static CreateStatisticsStatement FromMutable(ScriptDom.CreateStatisticsStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateStatisticsStatement(
                name: (Identifier)FromMutable(fragment.Name),
                onName: (SchemaObjectName)FromMutable(fragment.OnName),
                columns: fragment.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                statisticsOptions: fragment.StatisticsOptions.SelectList(c => (StatisticsOption)FromMutable(c)),
                filterPredicate: (BooleanExpression)FromMutable(fragment.FilterPredicate)
            );
        }
        
        public static CreateSymmetricKeyStatement FromMutable(ScriptDom.CreateSymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateSymmetricKeyStatement(
                keyOptions: fragment.KeyOptions.SelectList(c => (KeyOption)FromMutable(c)),
                provider: (Identifier)FromMutable(fragment.Provider),
                owner: (Identifier)FromMutable(fragment.Owner),
                name: (Identifier)FromMutable(fragment.Name),
                encryptingMechanisms: fragment.EncryptingMechanisms.SelectList(c => (CryptoMechanism)FromMutable(c))
            );
        }
        
        public static CreateSynonymStatement FromMutable(ScriptDom.CreateSynonymStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateSynonymStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                forName: (SchemaObjectName)FromMutable(fragment.ForName)
            );
        }
        
        public static CreateTableStatement FromMutable(ScriptDom.CreateTableStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateTableStatement(
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName),
                asEdge: fragment.AsEdge,
                asFileTable: fragment.AsFileTable,
                asNode: fragment.AsNode,
                definition: (TableDefinition)FromMutable(fragment.Definition),
                onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable(fragment.OnFileGroupOrPartitionScheme),
                federationScheme: (FederationScheme)FromMutable(fragment.FederationScheme),
                textImageOn: (IdentifierOrValueExpression)FromMutable(fragment.TextImageOn),
                options: fragment.Options.SelectList(c => (TableOption)FromMutable(c)),
                selectStatement: (SelectStatement)FromMutable(fragment.SelectStatement),
                ctasColumns: fragment.CtasColumns.SelectList(c => (Identifier)FromMutable(c)),
                fileStreamOn: (IdentifierOrValueExpression)FromMutable(fragment.FileStreamOn)
            );
        }
        
        public static CreateTriggerStatement FromMutable(ScriptDom.CreateTriggerStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateTriggerStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                triggerObject: (TriggerObject)FromMutable(fragment.TriggerObject),
                options: fragment.Options.SelectList(c => (TriggerOption)FromMutable(c)),
                triggerType: fragment.TriggerType,
                triggerActions: fragment.TriggerActions.SelectList(c => (TriggerAction)FromMutable(c)),
                withAppend: fragment.WithAppend,
                isNotForReplication: fragment.IsNotForReplication,
                statementList: (StatementList)FromMutable(fragment.StatementList),
                methodSpecifier: (MethodSpecifier)FromMutable(fragment.MethodSpecifier)
            );
        }
        
        public static CreateTypeTableStatement FromMutable(ScriptDom.CreateTypeTableStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateTypeTableStatement(
                definition: (TableDefinition)FromMutable(fragment.Definition),
                options: fragment.Options.SelectList(c => (TableOption)FromMutable(c)),
                name: (SchemaObjectName)FromMutable(fragment.Name)
            );
        }
        
        public static CreateTypeUddtStatement FromMutable(ScriptDom.CreateTypeUddtStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateTypeUddtStatement(
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                nullableConstraint: (NullableConstraintDefinition)FromMutable(fragment.NullableConstraint),
                name: (SchemaObjectName)FromMutable(fragment.Name)
            );
        }
        
        public static CreateTypeUdtStatement FromMutable(ScriptDom.CreateTypeUdtStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateTypeUdtStatement(
                assemblyName: (AssemblyName)FromMutable(fragment.AssemblyName),
                name: (SchemaObjectName)FromMutable(fragment.Name)
            );
        }
        
        public static CreateUserStatement FromMutable(ScriptDom.CreateUserStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateUserStatement(
                userLoginOption: (UserLoginOption)FromMutable(fragment.UserLoginOption),
                name: (Identifier)FromMutable(fragment.Name),
                userOptions: fragment.UserOptions.SelectList(c => (PrincipalOption)FromMutable(c))
            );
        }
        
        public static CreateViewStatement FromMutable(ScriptDom.CreateViewStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateViewStatement(
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                viewOptions: fragment.ViewOptions.SelectList(c => (ViewOption)FromMutable(c)),
                selectStatement: (SelectStatement)FromMutable(fragment.SelectStatement),
                withCheckOption: fragment.WithCheckOption,
                isMaterialized: fragment.IsMaterialized
            );
        }
        
        public static CreateWorkloadClassifierStatement FromMutable(ScriptDom.CreateWorkloadClassifierStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateWorkloadClassifierStatement(
                classifierName: (Identifier)FromMutable(fragment.ClassifierName),
                options: fragment.Options.SelectList(c => (WorkloadClassifierOption)FromMutable(c))
            );
        }
        
        public static CreateWorkloadGroupStatement FromMutable(ScriptDom.CreateWorkloadGroupStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateWorkloadGroupStatement(
                name: (Identifier)FromMutable(fragment.Name),
                workloadGroupParameters: fragment.WorkloadGroupParameters.SelectList(c => (WorkloadGroupParameter)FromMutable(c)),
                poolName: (Identifier)FromMutable(fragment.PoolName),
                externalPoolName: (Identifier)FromMutable(fragment.ExternalPoolName)
            );
        }
        
        public static CreateXmlIndexStatement FromMutable(ScriptDom.CreateXmlIndexStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateXmlIndexStatement(
                primary: fragment.Primary,
                xmlColumn: (Identifier)FromMutable(fragment.XmlColumn),
                secondaryXmlIndexName: (Identifier)FromMutable(fragment.SecondaryXmlIndexName),
                secondaryXmlIndexType: fragment.SecondaryXmlIndexType,
                onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable(fragment.OnFileGroupOrPartitionScheme),
                name: (Identifier)FromMutable(fragment.Name),
                onName: (SchemaObjectName)FromMutable(fragment.OnName),
                indexOptions: fragment.IndexOptions.SelectList(c => (IndexOption)FromMutable(c))
            );
        }
        
        public static CreateXmlSchemaCollectionStatement FromMutable(ScriptDom.CreateXmlSchemaCollectionStatement fragment) {
            if (fragment is null) { return null; }
            return new CreateXmlSchemaCollectionStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                expression: (ScalarExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static CreationDispositionKeyOption FromMutable(ScriptDom.CreationDispositionKeyOption fragment) {
            if (fragment is null) { return null; }
            return new CreationDispositionKeyOption(
                isCreateNew: fragment.IsCreateNew,
                optionKind: fragment.OptionKind
            );
        }
        
        public static CryptoMechanism FromMutable(ScriptDom.CryptoMechanism fragment) {
            if (fragment is null) { return null; }
            return new CryptoMechanism(
                cryptoMechanismType: fragment.CryptoMechanismType,
                identifier: (Identifier)FromMutable(fragment.Identifier),
                passwordOrSignature: (Literal)FromMutable(fragment.PasswordOrSignature)
            );
        }
        
        public static CubeGroupingSpecification FromMutable(ScriptDom.CubeGroupingSpecification fragment) {
            if (fragment is null) { return null; }
            return new CubeGroupingSpecification(
                arguments: fragment.Arguments.SelectList(c => (GroupingSpecification)FromMutable(c))
            );
        }
        
        public static CursorDefaultDatabaseOption FromMutable(ScriptDom.CursorDefaultDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new CursorDefaultDatabaseOption(
                isLocal: fragment.IsLocal,
                optionKind: fragment.OptionKind
            );
        }
        
        public static CursorDefinition FromMutable(ScriptDom.CursorDefinition fragment) {
            if (fragment is null) { return null; }
            return new CursorDefinition(
                options: fragment.Options.SelectList(c => (CursorOption)FromMutable(c)),
                select: (SelectStatement)FromMutable(fragment.Select)
            );
        }
        
        public static CursorId FromMutable(ScriptDom.CursorId fragment) {
            if (fragment is null) { return null; }
            return new CursorId(
                isGlobal: fragment.IsGlobal,
                name: (IdentifierOrValueExpression)FromMutable(fragment.Name)
            );
        }
        
        public static CursorOption FromMutable(ScriptDom.CursorOption fragment) {
            if (fragment is null) { return null; }
            return new CursorOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static DatabaseAuditAction FromMutable(ScriptDom.DatabaseAuditAction fragment) {
            if (fragment is null) { return null; }
            return new DatabaseAuditAction(
                actionKind: fragment.ActionKind
            );
        }
        
        public static DatabaseConfigurationClearOption FromMutable(ScriptDom.DatabaseConfigurationClearOption fragment) {
            if (fragment is null) { return null; }
            return new DatabaseConfigurationClearOption(
                optionKind: fragment.OptionKind,
                planHandle: (BinaryLiteral)FromMutable(fragment.PlanHandle)
            );
        }
        
        public static DatabaseConfigurationSetOption FromMutable(ScriptDom.DatabaseConfigurationSetOption fragment) {
            if (fragment is null) { return null; }
            return new DatabaseConfigurationSetOption(
                optionKind: fragment.OptionKind,
                genericOptionKind: (Identifier)FromMutable(fragment.GenericOptionKind)
            );
        }
        
        public static DatabaseOption FromMutable(ScriptDom.DatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new DatabaseOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static DataCompressionOption FromMutable(ScriptDom.DataCompressionOption fragment) {
            if (fragment is null) { return null; }
            return new DataCompressionOption(
                compressionLevel: fragment.CompressionLevel,
                partitionRanges: fragment.PartitionRanges.SelectList(c => (CompressionPartitionRange)FromMutable(c)),
                optionKind: fragment.OptionKind
            );
        }
        
        public static DataModificationTableReference FromMutable(ScriptDom.DataModificationTableReference fragment) {
            if (fragment is null) { return null; }
            return new DataModificationTableReference(
                dataModificationSpecification: (DataModificationSpecification)FromMutable(fragment.DataModificationSpecification),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static DataRetentionTableOption FromMutable(ScriptDom.DataRetentionTableOption fragment) {
            if (fragment is null) { return null; }
            return new DataRetentionTableOption(
                optionState: fragment.OptionState,
                filterColumn: (Identifier)FromMutable(fragment.FilterColumn),
                retentionPeriod: (RetentionPeriodDefinition)FromMutable(fragment.RetentionPeriod),
                optionKind: fragment.OptionKind
            );
        }
        
        public static DataTypeSequenceOption FromMutable(ScriptDom.DataTypeSequenceOption fragment) {
            if (fragment is null) { return null; }
            return new DataTypeSequenceOption(
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                optionKind: fragment.OptionKind,
                noValue: fragment.NoValue
            );
        }
        
        public static DbccNamedLiteral FromMutable(ScriptDom.DbccNamedLiteral fragment) {
            if (fragment is null) { return null; }
            return new DbccNamedLiteral(
                name: fragment.Name,
                @value: (ScalarExpression)FromMutable(fragment.Value)
            );
        }
        
        public static DbccOption FromMutable(ScriptDom.DbccOption fragment) {
            if (fragment is null) { return null; }
            return new DbccOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static DbccStatement FromMutable(ScriptDom.DbccStatement fragment) {
            if (fragment is null) { return null; }
            return new DbccStatement(
                dllName: fragment.DllName,
                command: fragment.Command,
                parenthesisRequired: fragment.ParenthesisRequired,
                literals: fragment.Literals.SelectList(c => (DbccNamedLiteral)FromMutable(c)),
                options: fragment.Options.SelectList(c => (DbccOption)FromMutable(c)),
                optionsUseJoin: fragment.OptionsUseJoin
            );
        }
        
        public static DeallocateCursorStatement FromMutable(ScriptDom.DeallocateCursorStatement fragment) {
            if (fragment is null) { return null; }
            return new DeallocateCursorStatement(
                cursor: (CursorId)FromMutable(fragment.Cursor)
            );
        }
        
        public static DeclareCursorStatement FromMutable(ScriptDom.DeclareCursorStatement fragment) {
            if (fragment is null) { return null; }
            return new DeclareCursorStatement(
                name: (Identifier)FromMutable(fragment.Name),
                cursorDefinition: (CursorDefinition)FromMutable(fragment.CursorDefinition)
            );
        }
        
        public static DeclareTableVariableBody FromMutable(ScriptDom.DeclareTableVariableBody fragment) {
            if (fragment is null) { return null; }
            return new DeclareTableVariableBody(
                variableName: (Identifier)FromMutable(fragment.VariableName),
                asDefined: fragment.AsDefined,
                definition: (TableDefinition)FromMutable(fragment.Definition)
            );
        }
        
        public static DeclareTableVariableStatement FromMutable(ScriptDom.DeclareTableVariableStatement fragment) {
            if (fragment is null) { return null; }
            return new DeclareTableVariableStatement(
                body: (DeclareTableVariableBody)FromMutable(fragment.Body)
            );
        }
        
        public static DeclareVariableElement FromMutable(ScriptDom.DeclareVariableElement fragment) {
            if (fragment is null) { return null; }
            return new DeclareVariableElement(
                variableName: (Identifier)FromMutable(fragment.VariableName),
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                nullable: (NullableConstraintDefinition)FromMutable(fragment.Nullable),
                @value: (ScalarExpression)FromMutable(fragment.Value)
            );
        }
        
        public static DeclareVariableStatement FromMutable(ScriptDom.DeclareVariableStatement fragment) {
            if (fragment is null) { return null; }
            return new DeclareVariableStatement(
                declarations: fragment.Declarations.SelectList(c => (DeclareVariableElement)FromMutable(c))
            );
        }
        
        public static DefaultConstraintDefinition FromMutable(ScriptDom.DefaultConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            return new DefaultConstraintDefinition(
                expression: (ScalarExpression)FromMutable(fragment.Expression),
                withValues: fragment.WithValues,
                column: (Identifier)FromMutable(fragment.Column),
                constraintIdentifier: (Identifier)FromMutable(fragment.ConstraintIdentifier)
            );
        }
        
        public static DefaultLiteral FromMutable(ScriptDom.DefaultLiteral fragment) {
            if (fragment is null) { return null; }
            return new DefaultLiteral(
                @value: fragment.Value,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static DelayedDurabilityDatabaseOption FromMutable(ScriptDom.DelayedDurabilityDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new DelayedDurabilityDatabaseOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static DeleteMergeAction FromMutable(ScriptDom.DeleteMergeAction fragment) {
            if (fragment is null) { return null; }
            return new DeleteMergeAction(
                
            );
        }
        
        public static DeleteSpecification FromMutable(ScriptDom.DeleteSpecification fragment) {
            if (fragment is null) { return null; }
            return new DeleteSpecification(
                fromClause: (FromClause)FromMutable(fragment.FromClause),
                whereClause: (WhereClause)FromMutable(fragment.WhereClause),
                target: (TableReference)FromMutable(fragment.Target),
                topRowFilter: (TopRowFilter)FromMutable(fragment.TopRowFilter),
                outputIntoClause: (OutputIntoClause)FromMutable(fragment.OutputIntoClause),
                outputClause: (OutputClause)FromMutable(fragment.OutputClause)
            );
        }
        
        public static DeleteStatement FromMutable(ScriptDom.DeleteStatement fragment) {
            if (fragment is null) { return null; }
            return new DeleteStatement(
                deleteSpecification: (DeleteSpecification)FromMutable(fragment.DeleteSpecification),
                withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
            );
        }
        
        public static DenyStatement FromMutable(ScriptDom.DenyStatement fragment) {
            if (fragment is null) { return null; }
            return new DenyStatement(
                cascadeOption: fragment.CascadeOption,
                permissions: fragment.Permissions.SelectList(c => (Permission)FromMutable(c)),
                securityTargetObject: (SecurityTargetObject)FromMutable(fragment.SecurityTargetObject),
                principals: fragment.Principals.SelectList(c => (SecurityPrincipal)FromMutable(c)),
                asClause: (Identifier)FromMutable(fragment.AsClause)
            );
        }
        
        public static DenyStatement80 FromMutable(ScriptDom.DenyStatement80 fragment) {
            if (fragment is null) { return null; }
            return new DenyStatement80(
                cascadeOption: fragment.CascadeOption,
                securityElement80: (SecurityElement80)FromMutable(fragment.SecurityElement80),
                securityUserClause80: (SecurityUserClause80)FromMutable(fragment.SecurityUserClause80)
            );
        }
        
        public static DeviceInfo FromMutable(ScriptDom.DeviceInfo fragment) {
            if (fragment is null) { return null; }
            return new DeviceInfo(
                logicalDevice: (IdentifierOrValueExpression)FromMutable(fragment.LogicalDevice),
                physicalDevice: (ValueExpression)FromMutable(fragment.PhysicalDevice),
                deviceType: fragment.DeviceType
            );
        }
        
        public static DiskStatement FromMutable(ScriptDom.DiskStatement fragment) {
            if (fragment is null) { return null; }
            return new DiskStatement(
                diskStatementType: fragment.DiskStatementType,
                options: fragment.Options.SelectList(c => (DiskStatementOption)FromMutable(c))
            );
        }
        
        public static DiskStatementOption FromMutable(ScriptDom.DiskStatementOption fragment) {
            if (fragment is null) { return null; }
            return new DiskStatementOption(
                optionKind: fragment.OptionKind,
                @value: (IdentifierOrValueExpression)FromMutable(fragment.Value)
            );
        }
        
        public static DistinctPredicate FromMutable(ScriptDom.DistinctPredicate fragment) {
            if (fragment is null) { return null; }
            return new DistinctPredicate(
                firstExpression: (ScalarExpression)FromMutable(fragment.FirstExpression),
                secondExpression: (ScalarExpression)FromMutable(fragment.SecondExpression),
                isNot: fragment.IsNot
            );
        }
        
        public static DropAggregateStatement FromMutable(ScriptDom.DropAggregateStatement fragment) {
            if (fragment is null) { return null; }
            return new DropAggregateStatement(
                objects: fragment.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropAlterFullTextIndexAction FromMutable(ScriptDom.DropAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            return new DropAlterFullTextIndexAction(
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                withNoPopulation: fragment.WithNoPopulation
            );
        }
        
        public static DropApplicationRoleStatement FromMutable(ScriptDom.DropApplicationRoleStatement fragment) {
            if (fragment is null) { return null; }
            return new DropApplicationRoleStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropAssemblyStatement FromMutable(ScriptDom.DropAssemblyStatement fragment) {
            if (fragment is null) { return null; }
            return new DropAssemblyStatement(
                withNoDependents: fragment.WithNoDependents,
                objects: fragment.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropAsymmetricKeyStatement FromMutable(ScriptDom.DropAsymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new DropAsymmetricKeyStatement(
                removeProviderKey: fragment.RemoveProviderKey,
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropAvailabilityGroupStatement FromMutable(ScriptDom.DropAvailabilityGroupStatement fragment) {
            if (fragment is null) { return null; }
            return new DropAvailabilityGroupStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropBrokerPriorityStatement FromMutable(ScriptDom.DropBrokerPriorityStatement fragment) {
            if (fragment is null) { return null; }
            return new DropBrokerPriorityStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropCertificateStatement FromMutable(ScriptDom.DropCertificateStatement fragment) {
            if (fragment is null) { return null; }
            return new DropCertificateStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropClusteredConstraintMoveOption FromMutable(ScriptDom.DropClusteredConstraintMoveOption fragment) {
            if (fragment is null) { return null; }
            return new DropClusteredConstraintMoveOption(
                optionValue: (FileGroupOrPartitionScheme)FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind
            );
        }
        
        public static DropClusteredConstraintStateOption FromMutable(ScriptDom.DropClusteredConstraintStateOption fragment) {
            if (fragment is null) { return null; }
            return new DropClusteredConstraintStateOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static DropClusteredConstraintValueOption FromMutable(ScriptDom.DropClusteredConstraintValueOption fragment) {
            if (fragment is null) { return null; }
            return new DropClusteredConstraintValueOption(
                optionValue: (Literal)FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind
            );
        }
        
        public static DropClusteredConstraintWaitAtLowPriorityLockOption FromMutable(ScriptDom.DropClusteredConstraintWaitAtLowPriorityLockOption fragment) {
            if (fragment is null) { return null; }
            return new DropClusteredConstraintWaitAtLowPriorityLockOption(
                options: fragment.Options.SelectList(c => (LowPriorityLockWaitOption)FromMutable(c)),
                optionKind: fragment.OptionKind
            );
        }
        
        public static DropColumnEncryptionKeyStatement FromMutable(ScriptDom.DropColumnEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new DropColumnEncryptionKeyStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropColumnMasterKeyStatement FromMutable(ScriptDom.DropColumnMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new DropColumnMasterKeyStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropContractStatement FromMutable(ScriptDom.DropContractStatement fragment) {
            if (fragment is null) { return null; }
            return new DropContractStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropCredentialStatement FromMutable(ScriptDom.DropCredentialStatement fragment) {
            if (fragment is null) { return null; }
            return new DropCredentialStatement(
                isDatabaseScoped: fragment.IsDatabaseScoped,
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropCryptographicProviderStatement FromMutable(ScriptDom.DropCryptographicProviderStatement fragment) {
            if (fragment is null) { return null; }
            return new DropCryptographicProviderStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropDatabaseAuditSpecificationStatement FromMutable(ScriptDom.DropDatabaseAuditSpecificationStatement fragment) {
            if (fragment is null) { return null; }
            return new DropDatabaseAuditSpecificationStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropDatabaseEncryptionKeyStatement FromMutable(ScriptDom.DropDatabaseEncryptionKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new DropDatabaseEncryptionKeyStatement(
                
            );
        }
        
        public static DropDatabaseStatement FromMutable(ScriptDom.DropDatabaseStatement fragment) {
            if (fragment is null) { return null; }
            return new DropDatabaseStatement(
                databases: fragment.Databases.SelectList(c => (Identifier)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropDefaultStatement FromMutable(ScriptDom.DropDefaultStatement fragment) {
            if (fragment is null) { return null; }
            return new DropDefaultStatement(
                objects: fragment.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropEndpointStatement FromMutable(ScriptDom.DropEndpointStatement fragment) {
            if (fragment is null) { return null; }
            return new DropEndpointStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropEventNotificationStatement FromMutable(ScriptDom.DropEventNotificationStatement fragment) {
            if (fragment is null) { return null; }
            return new DropEventNotificationStatement(
                notifications: fragment.Notifications.SelectList(c => (Identifier)FromMutable(c)),
                scope: (EventNotificationObjectScope)FromMutable(fragment.Scope)
            );
        }
        
        public static DropEventSessionStatement FromMutable(ScriptDom.DropEventSessionStatement fragment) {
            if (fragment is null) { return null; }
            return new DropEventSessionStatement(
                sessionScope: fragment.SessionScope,
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropExternalDataSourceStatement FromMutable(ScriptDom.DropExternalDataSourceStatement fragment) {
            if (fragment is null) { return null; }
            return new DropExternalDataSourceStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropExternalFileFormatStatement FromMutable(ScriptDom.DropExternalFileFormatStatement fragment) {
            if (fragment is null) { return null; }
            return new DropExternalFileFormatStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropExternalLanguageStatement FromMutable(ScriptDom.DropExternalLanguageStatement fragment) {
            if (fragment is null) { return null; }
            return new DropExternalLanguageStatement(
                name: (Identifier)FromMutable(fragment.Name),
                owner: (Identifier)FromMutable(fragment.Owner)
            );
        }
        
        public static DropExternalLibraryStatement FromMutable(ScriptDom.DropExternalLibraryStatement fragment) {
            if (fragment is null) { return null; }
            return new DropExternalLibraryStatement(
                name: (Identifier)FromMutable(fragment.Name),
                owner: (Identifier)FromMutable(fragment.Owner)
            );
        }
        
        public static DropExternalResourcePoolStatement FromMutable(ScriptDom.DropExternalResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            return new DropExternalResourcePoolStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropExternalStreamingJobStatement FromMutable(ScriptDom.DropExternalStreamingJobStatement fragment) {
            if (fragment is null) { return null; }
            return new DropExternalStreamingJobStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropExternalStreamStatement FromMutable(ScriptDom.DropExternalStreamStatement fragment) {
            if (fragment is null) { return null; }
            return new DropExternalStreamStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropExternalTableStatement FromMutable(ScriptDom.DropExternalTableStatement fragment) {
            if (fragment is null) { return null; }
            return new DropExternalTableStatement(
                objects: fragment.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropFederationStatement FromMutable(ScriptDom.DropFederationStatement fragment) {
            if (fragment is null) { return null; }
            return new DropFederationStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropFullTextCatalogStatement FromMutable(ScriptDom.DropFullTextCatalogStatement fragment) {
            if (fragment is null) { return null; }
            return new DropFullTextCatalogStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropFullTextIndexStatement FromMutable(ScriptDom.DropFullTextIndexStatement fragment) {
            if (fragment is null) { return null; }
            return new DropFullTextIndexStatement(
                tableName: (SchemaObjectName)FromMutable(fragment.TableName)
            );
        }
        
        public static DropFullTextStopListStatement FromMutable(ScriptDom.DropFullTextStopListStatement fragment) {
            if (fragment is null) { return null; }
            return new DropFullTextStopListStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropFunctionStatement FromMutable(ScriptDom.DropFunctionStatement fragment) {
            if (fragment is null) { return null; }
            return new DropFunctionStatement(
                objects: fragment.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropIndexClause FromMutable(ScriptDom.DropIndexClause fragment) {
            if (fragment is null) { return null; }
            return new DropIndexClause(
                index: (Identifier)FromMutable(fragment.Index),
                @object: (SchemaObjectName)FromMutable(fragment.Object),
                options: fragment.Options.SelectList(c => (IndexOption)FromMutable(c))
            );
        }
        
        public static DropIndexStatement FromMutable(ScriptDom.DropIndexStatement fragment) {
            if (fragment is null) { return null; }
            return new DropIndexStatement(
                dropIndexClauses: fragment.DropIndexClauses.SelectList(c => (DropIndexClauseBase)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropLoginStatement FromMutable(ScriptDom.DropLoginStatement fragment) {
            if (fragment is null) { return null; }
            return new DropLoginStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropMasterKeyStatement FromMutable(ScriptDom.DropMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new DropMasterKeyStatement(
                
            );
        }
        
        public static DropMemberAlterRoleAction FromMutable(ScriptDom.DropMemberAlterRoleAction fragment) {
            if (fragment is null) { return null; }
            return new DropMemberAlterRoleAction(
                member: (Identifier)FromMutable(fragment.Member)
            );
        }
        
        public static DropMessageTypeStatement FromMutable(ScriptDom.DropMessageTypeStatement fragment) {
            if (fragment is null) { return null; }
            return new DropMessageTypeStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropPartitionFunctionStatement FromMutable(ScriptDom.DropPartitionFunctionStatement fragment) {
            if (fragment is null) { return null; }
            return new DropPartitionFunctionStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropPartitionSchemeStatement FromMutable(ScriptDom.DropPartitionSchemeStatement fragment) {
            if (fragment is null) { return null; }
            return new DropPartitionSchemeStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropProcedureStatement FromMutable(ScriptDom.DropProcedureStatement fragment) {
            if (fragment is null) { return null; }
            return new DropProcedureStatement(
                objects: fragment.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropQueueStatement FromMutable(ScriptDom.DropQueueStatement fragment) {
            if (fragment is null) { return null; }
            return new DropQueueStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name)
            );
        }
        
        public static DropRemoteServiceBindingStatement FromMutable(ScriptDom.DropRemoteServiceBindingStatement fragment) {
            if (fragment is null) { return null; }
            return new DropRemoteServiceBindingStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropResourcePoolStatement FromMutable(ScriptDom.DropResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            return new DropResourcePoolStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropRoleStatement FromMutable(ScriptDom.DropRoleStatement fragment) {
            if (fragment is null) { return null; }
            return new DropRoleStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropRouteStatement FromMutable(ScriptDom.DropRouteStatement fragment) {
            if (fragment is null) { return null; }
            return new DropRouteStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropRuleStatement FromMutable(ScriptDom.DropRuleStatement fragment) {
            if (fragment is null) { return null; }
            return new DropRuleStatement(
                objects: fragment.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropSchemaStatement FromMutable(ScriptDom.DropSchemaStatement fragment) {
            if (fragment is null) { return null; }
            return new DropSchemaStatement(
                schema: (SchemaObjectName)FromMutable(fragment.Schema),
                dropBehavior: fragment.DropBehavior,
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropSearchPropertyListAction FromMutable(ScriptDom.DropSearchPropertyListAction fragment) {
            if (fragment is null) { return null; }
            return new DropSearchPropertyListAction(
                propertyName: (StringLiteral)FromMutable(fragment.PropertyName)
            );
        }
        
        public static DropSearchPropertyListStatement FromMutable(ScriptDom.DropSearchPropertyListStatement fragment) {
            if (fragment is null) { return null; }
            return new DropSearchPropertyListStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropSecurityPolicyStatement FromMutable(ScriptDom.DropSecurityPolicyStatement fragment) {
            if (fragment is null) { return null; }
            return new DropSecurityPolicyStatement(
                objects: fragment.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropSensitivityClassificationStatement FromMutable(ScriptDom.DropSensitivityClassificationStatement fragment) {
            if (fragment is null) { return null; }
            return new DropSensitivityClassificationStatement(
                columns: fragment.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
            );
        }
        
        public static DropSequenceStatement FromMutable(ScriptDom.DropSequenceStatement fragment) {
            if (fragment is null) { return null; }
            return new DropSequenceStatement(
                objects: fragment.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropServerAuditSpecificationStatement FromMutable(ScriptDom.DropServerAuditSpecificationStatement fragment) {
            if (fragment is null) { return null; }
            return new DropServerAuditSpecificationStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropServerAuditStatement FromMutable(ScriptDom.DropServerAuditStatement fragment) {
            if (fragment is null) { return null; }
            return new DropServerAuditStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropServerRoleStatement FromMutable(ScriptDom.DropServerRoleStatement fragment) {
            if (fragment is null) { return null; }
            return new DropServerRoleStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropServiceStatement FromMutable(ScriptDom.DropServiceStatement fragment) {
            if (fragment is null) { return null; }
            return new DropServiceStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropSignatureStatement FromMutable(ScriptDom.DropSignatureStatement fragment) {
            if (fragment is null) { return null; }
            return new DropSignatureStatement(
                isCounter: fragment.IsCounter,
                elementKind: fragment.ElementKind,
                element: (SchemaObjectName)FromMutable(fragment.Element),
                cryptos: fragment.Cryptos.SelectList(c => (CryptoMechanism)FromMutable(c))
            );
        }
        
        public static DropStatisticsStatement FromMutable(ScriptDom.DropStatisticsStatement fragment) {
            if (fragment is null) { return null; }
            return new DropStatisticsStatement(
                objects: fragment.Objects.SelectList(c => (ChildObjectName)FromMutable(c))
            );
        }
        
        public static DropSymmetricKeyStatement FromMutable(ScriptDom.DropSymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new DropSymmetricKeyStatement(
                removeProviderKey: fragment.RemoveProviderKey,
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropSynonymStatement FromMutable(ScriptDom.DropSynonymStatement fragment) {
            if (fragment is null) { return null; }
            return new DropSynonymStatement(
                objects: fragment.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropTableStatement FromMutable(ScriptDom.DropTableStatement fragment) {
            if (fragment is null) { return null; }
            return new DropTableStatement(
                objects: fragment.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropTriggerStatement FromMutable(ScriptDom.DropTriggerStatement fragment) {
            if (fragment is null) { return null; }
            return new DropTriggerStatement(
                triggerScope: fragment.TriggerScope,
                objects: fragment.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropTypeStatement FromMutable(ScriptDom.DropTypeStatement fragment) {
            if (fragment is null) { return null; }
            return new DropTypeStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropUserStatement FromMutable(ScriptDom.DropUserStatement fragment) {
            if (fragment is null) { return null; }
            return new DropUserStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropViewStatement FromMutable(ScriptDom.DropViewStatement fragment) {
            if (fragment is null) { return null; }
            return new DropViewStatement(
                objects: fragment.Objects.SelectList(c => (SchemaObjectName)FromMutable(c)),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropWorkloadClassifierStatement FromMutable(ScriptDom.DropWorkloadClassifierStatement fragment) {
            if (fragment is null) { return null; }
            return new DropWorkloadClassifierStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropWorkloadGroupStatement FromMutable(ScriptDom.DropWorkloadGroupStatement fragment) {
            if (fragment is null) { return null; }
            return new DropWorkloadGroupStatement(
                name: (Identifier)FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
        
        public static DropXmlSchemaCollectionStatement FromMutable(ScriptDom.DropXmlSchemaCollectionStatement fragment) {
            if (fragment is null) { return null; }
            return new DropXmlSchemaCollectionStatement(
                name: (SchemaObjectName)FromMutable(fragment.Name)
            );
        }
        
        public static DurabilityTableOption FromMutable(ScriptDom.DurabilityTableOption fragment) {
            if (fragment is null) { return null; }
            return new DurabilityTableOption(
                durabilityTableOptionKind: fragment.DurabilityTableOptionKind,
                optionKind: fragment.OptionKind
            );
        }
        
        public static EnabledDisabledPayloadOption FromMutable(ScriptDom.EnabledDisabledPayloadOption fragment) {
            if (fragment is null) { return null; }
            return new EnabledDisabledPayloadOption(
                isEnabled: fragment.IsEnabled,
                kind: fragment.Kind
            );
        }
        
        public static EnableDisableTriggerStatement FromMutable(ScriptDom.EnableDisableTriggerStatement fragment) {
            if (fragment is null) { return null; }
            return new EnableDisableTriggerStatement(
                triggerEnforcement: fragment.TriggerEnforcement,
                all: fragment.All,
                triggerNames: fragment.TriggerNames.SelectList(c => (SchemaObjectName)FromMutable(c)),
                triggerObject: (TriggerObject)FromMutable(fragment.TriggerObject)
            );
        }
        
        public static EncryptedValueParameter FromMutable(ScriptDom.EncryptedValueParameter fragment) {
            if (fragment is null) { return null; }
            return new EncryptedValueParameter(
                @value: (BinaryLiteral)FromMutable(fragment.Value),
                parameterKind: fragment.ParameterKind
            );
        }
        
        public static EncryptionPayloadOption FromMutable(ScriptDom.EncryptionPayloadOption fragment) {
            if (fragment is null) { return null; }
            return new EncryptionPayloadOption(
                encryptionSupport: fragment.EncryptionSupport,
                algorithmPartOne: fragment.AlgorithmPartOne,
                algorithmPartTwo: fragment.AlgorithmPartTwo,
                kind: fragment.Kind
            );
        }
        
        public static EndConversationStatement FromMutable(ScriptDom.EndConversationStatement fragment) {
            if (fragment is null) { return null; }
            return new EndConversationStatement(
                conversation: (ScalarExpression)FromMutable(fragment.Conversation),
                withCleanup: fragment.WithCleanup,
                errorCode: (ValueExpression)FromMutable(fragment.ErrorCode),
                errorDescription: (ValueExpression)FromMutable(fragment.ErrorDescription)
            );
        }
        
        public static EndpointAffinity FromMutable(ScriptDom.EndpointAffinity fragment) {
            if (fragment is null) { return null; }
            return new EndpointAffinity(
                kind: fragment.Kind,
                @value: (Literal)FromMutable(fragment.Value)
            );
        }
        
        public static EventDeclaration FromMutable(ScriptDom.EventDeclaration fragment) {
            if (fragment is null) { return null; }
            return new EventDeclaration(
                objectName: (EventSessionObjectName)FromMutable(fragment.ObjectName),
                eventDeclarationSetParameters: fragment.EventDeclarationSetParameters.SelectList(c => (EventDeclarationSetParameter)FromMutable(c)),
                eventDeclarationActionParameters: fragment.EventDeclarationActionParameters.SelectList(c => (EventSessionObjectName)FromMutable(c)),
                eventDeclarationPredicateParameter: (BooleanExpression)FromMutable(fragment.EventDeclarationPredicateParameter)
            );
        }
        
        public static EventDeclarationCompareFunctionParameter FromMutable(ScriptDom.EventDeclarationCompareFunctionParameter fragment) {
            if (fragment is null) { return null; }
            return new EventDeclarationCompareFunctionParameter(
                name: (EventSessionObjectName)FromMutable(fragment.Name),
                sourceDeclaration: (SourceDeclaration)FromMutable(fragment.SourceDeclaration),
                eventValue: (ScalarExpression)FromMutable(fragment.EventValue)
            );
        }
        
        public static EventDeclarationSetParameter FromMutable(ScriptDom.EventDeclarationSetParameter fragment) {
            if (fragment is null) { return null; }
            return new EventDeclarationSetParameter(
                eventField: (Identifier)FromMutable(fragment.EventField),
                eventValue: (ScalarExpression)FromMutable(fragment.EventValue)
            );
        }
        
        public static EventGroupContainer FromMutable(ScriptDom.EventGroupContainer fragment) {
            if (fragment is null) { return null; }
            return new EventGroupContainer(
                eventGroup: fragment.EventGroup
            );
        }
        
        public static EventNotificationObjectScope FromMutable(ScriptDom.EventNotificationObjectScope fragment) {
            if (fragment is null) { return null; }
            return new EventNotificationObjectScope(
                target: fragment.Target,
                queueName: (SchemaObjectName)FromMutable(fragment.QueueName)
            );
        }
        
        public static EventRetentionSessionOption FromMutable(ScriptDom.EventRetentionSessionOption fragment) {
            if (fragment is null) { return null; }
            return new EventRetentionSessionOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static EventSessionObjectName FromMutable(ScriptDom.EventSessionObjectName fragment) {
            if (fragment is null) { return null; }
            return new EventSessionObjectName(
                multiPartIdentifier: (MultiPartIdentifier)FromMutable(fragment.MultiPartIdentifier)
            );
        }
        
        public static EventSessionStatement FromMutable(ScriptDom.EventSessionStatement fragment) {
            if (fragment is null) { return null; }
            return new EventSessionStatement(
                name: (Identifier)FromMutable(fragment.Name),
                sessionScope: fragment.SessionScope,
                eventDeclarations: fragment.EventDeclarations.SelectList(c => (EventDeclaration)FromMutable(c)),
                targetDeclarations: fragment.TargetDeclarations.SelectList(c => (TargetDeclaration)FromMutable(c)),
                sessionOptions: fragment.SessionOptions.SelectList(c => (SessionOption)FromMutable(c))
            );
        }
        
        public static EventTypeContainer FromMutable(ScriptDom.EventTypeContainer fragment) {
            if (fragment is null) { return null; }
            return new EventTypeContainer(
                eventType: fragment.EventType
            );
        }
        
        public static ExecutableProcedureReference FromMutable(ScriptDom.ExecutableProcedureReference fragment) {
            if (fragment is null) { return null; }
            return new ExecutableProcedureReference(
                procedureReference: (ProcedureReferenceName)FromMutable(fragment.ProcedureReference),
                adHocDataSource: (AdHocDataSource)FromMutable(fragment.AdHocDataSource),
                parameters: fragment.Parameters.SelectList(c => (ExecuteParameter)FromMutable(c))
            );
        }
        
        public static ExecutableStringList FromMutable(ScriptDom.ExecutableStringList fragment) {
            if (fragment is null) { return null; }
            return new ExecutableStringList(
                strings: fragment.Strings.SelectList(c => (ValueExpression)FromMutable(c)),
                parameters: fragment.Parameters.SelectList(c => (ExecuteParameter)FromMutable(c))
            );
        }
        
        public static ExecuteAsClause FromMutable(ScriptDom.ExecuteAsClause fragment) {
            if (fragment is null) { return null; }
            return new ExecuteAsClause(
                executeAsOption: fragment.ExecuteAsOption,
                literal: (Literal)FromMutable(fragment.Literal)
            );
        }
        
        public static ExecuteAsFunctionOption FromMutable(ScriptDom.ExecuteAsFunctionOption fragment) {
            if (fragment is null) { return null; }
            return new ExecuteAsFunctionOption(
                executeAs: (ExecuteAsClause)FromMutable(fragment.ExecuteAs),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExecuteAsProcedureOption FromMutable(ScriptDom.ExecuteAsProcedureOption fragment) {
            if (fragment is null) { return null; }
            return new ExecuteAsProcedureOption(
                executeAs: (ExecuteAsClause)FromMutable(fragment.ExecuteAs),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExecuteAsStatement FromMutable(ScriptDom.ExecuteAsStatement fragment) {
            if (fragment is null) { return null; }
            return new ExecuteAsStatement(
                withNoRevert: fragment.WithNoRevert,
                cookie: (VariableReference)FromMutable(fragment.Cookie),
                executeContext: (ExecuteContext)FromMutable(fragment.ExecuteContext)
            );
        }
        
        public static ExecuteAsTriggerOption FromMutable(ScriptDom.ExecuteAsTriggerOption fragment) {
            if (fragment is null) { return null; }
            return new ExecuteAsTriggerOption(
                executeAsClause: (ExecuteAsClause)FromMutable(fragment.ExecuteAsClause),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExecuteContext FromMutable(ScriptDom.ExecuteContext fragment) {
            if (fragment is null) { return null; }
            return new ExecuteContext(
                principal: (ScalarExpression)FromMutable(fragment.Principal),
                kind: fragment.Kind
            );
        }
        
        public static ExecuteInsertSource FromMutable(ScriptDom.ExecuteInsertSource fragment) {
            if (fragment is null) { return null; }
            return new ExecuteInsertSource(
                execute: (ExecuteSpecification)FromMutable(fragment.Execute)
            );
        }
        
        public static ExecuteOption FromMutable(ScriptDom.ExecuteOption fragment) {
            if (fragment is null) { return null; }
            return new ExecuteOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExecuteParameter FromMutable(ScriptDom.ExecuteParameter fragment) {
            if (fragment is null) { return null; }
            return new ExecuteParameter(
                variable: (VariableReference)FromMutable(fragment.Variable),
                parameterValue: (ScalarExpression)FromMutable(fragment.ParameterValue),
                isOutput: fragment.IsOutput
            );
        }
        
        public static ExecuteSpecification FromMutable(ScriptDom.ExecuteSpecification fragment) {
            if (fragment is null) { return null; }
            return new ExecuteSpecification(
                variable: (VariableReference)FromMutable(fragment.Variable),
                linkedServer: (Identifier)FromMutable(fragment.LinkedServer),
                executeContext: (ExecuteContext)FromMutable(fragment.ExecuteContext),
                executableEntity: (ExecutableEntity)FromMutable(fragment.ExecutableEntity)
            );
        }
        
        public static ExecuteStatement FromMutable(ScriptDom.ExecuteStatement fragment) {
            if (fragment is null) { return null; }
            return new ExecuteStatement(
                executeSpecification: (ExecuteSpecification)FromMutable(fragment.ExecuteSpecification),
                options: fragment.Options.SelectList(c => (ExecuteOption)FromMutable(c))
            );
        }
        
        public static ExistsPredicate FromMutable(ScriptDom.ExistsPredicate fragment) {
            if (fragment is null) { return null; }
            return new ExistsPredicate(
                subquery: (ScalarSubquery)FromMutable(fragment.Subquery)
            );
        }
        
        public static ExpressionCallTarget FromMutable(ScriptDom.ExpressionCallTarget fragment) {
            if (fragment is null) { return null; }
            return new ExpressionCallTarget(
                expression: (ScalarExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static ExpressionGroupingSpecification FromMutable(ScriptDom.ExpressionGroupingSpecification fragment) {
            if (fragment is null) { return null; }
            return new ExpressionGroupingSpecification(
                expression: (ScalarExpression)FromMutable(fragment.Expression),
                distributedAggregation: fragment.DistributedAggregation
            );
        }
        
        public static ExpressionWithSortOrder FromMutable(ScriptDom.ExpressionWithSortOrder fragment) {
            if (fragment is null) { return null; }
            return new ExpressionWithSortOrder(
                sortOrder: fragment.SortOrder,
                expression: (ScalarExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static ExternalCreateLoginSource FromMutable(ScriptDom.ExternalCreateLoginSource fragment) {
            if (fragment is null) { return null; }
            return new ExternalCreateLoginSource(
                options: fragment.Options.SelectList(c => (PrincipalOption)FromMutable(c))
            );
        }
        
        public static ExternalDataSourceLiteralOrIdentifierOption FromMutable(ScriptDom.ExternalDataSourceLiteralOrIdentifierOption fragment) {
            if (fragment is null) { return null; }
            return new ExternalDataSourceLiteralOrIdentifierOption(
                @value: (IdentifierOrValueExpression)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalFileFormatContainerOption FromMutable(ScriptDom.ExternalFileFormatContainerOption fragment) {
            if (fragment is null) { return null; }
            return new ExternalFileFormatContainerOption(
                suboptions: fragment.Suboptions.SelectList(c => (ExternalFileFormatOption)FromMutable(c)),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalFileFormatLiteralOption FromMutable(ScriptDom.ExternalFileFormatLiteralOption fragment) {
            if (fragment is null) { return null; }
            return new ExternalFileFormatLiteralOption(
                @value: (Literal)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalFileFormatUseDefaultTypeOption FromMutable(ScriptDom.ExternalFileFormatUseDefaultTypeOption fragment) {
            if (fragment is null) { return null; }
            return new ExternalFileFormatUseDefaultTypeOption(
                externalFileFormatUseDefaultType: fragment.ExternalFileFormatUseDefaultType,
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalLanguageFileOption FromMutable(ScriptDom.ExternalLanguageFileOption fragment) {
            if (fragment is null) { return null; }
            return new ExternalLanguageFileOption(
                content: (ScalarExpression)FromMutable(fragment.Content),
                fileName: (StringLiteral)FromMutable(fragment.FileName),
                path: (StringLiteral)FromMutable(fragment.Path),
                platform: (Identifier)FromMutable(fragment.Platform),
                parameters: (StringLiteral)FromMutable(fragment.Parameters),
                environmentVariables: (StringLiteral)FromMutable(fragment.EnvironmentVariables)
            );
        }
        
        public static ExternalLibraryFileOption FromMutable(ScriptDom.ExternalLibraryFileOption fragment) {
            if (fragment is null) { return null; }
            return new ExternalLibraryFileOption(
                content: (ScalarExpression)FromMutable(fragment.Content),
                path: (StringLiteral)FromMutable(fragment.Path),
                platform: (Identifier)FromMutable(fragment.Platform)
            );
        }
        
        public static ExternalResourcePoolAffinitySpecification FromMutable(ScriptDom.ExternalResourcePoolAffinitySpecification fragment) {
            if (fragment is null) { return null; }
            return new ExternalResourcePoolAffinitySpecification(
                affinityType: fragment.AffinityType,
                parameterValue: (Literal)FromMutable(fragment.ParameterValue),
                isAuto: fragment.IsAuto,
                poolAffinityRanges: fragment.PoolAffinityRanges.SelectList(c => (LiteralRange)FromMutable(c))
            );
        }
        
        public static ExternalResourcePoolParameter FromMutable(ScriptDom.ExternalResourcePoolParameter fragment) {
            if (fragment is null) { return null; }
            return new ExternalResourcePoolParameter(
                parameterType: fragment.ParameterType,
                parameterValue: (Literal)FromMutable(fragment.ParameterValue),
                affinitySpecification: (ExternalResourcePoolAffinitySpecification)FromMutable(fragment.AffinitySpecification)
            );
        }
        
        public static ExternalResourcePoolStatement FromMutable(ScriptDom.ExternalResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            return new ExternalResourcePoolStatement(
                name: (Identifier)FromMutable(fragment.Name),
                externalResourcePoolParameters: fragment.ExternalResourcePoolParameters.SelectList(c => (ExternalResourcePoolParameter)FromMutable(c))
            );
        }
        
        public static ExternalStreamLiteralOrIdentifierOption FromMutable(ScriptDom.ExternalStreamLiteralOrIdentifierOption fragment) {
            if (fragment is null) { return null; }
            return new ExternalStreamLiteralOrIdentifierOption(
                @value: (IdentifierOrValueExpression)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalTableColumnDefinition FromMutable(ScriptDom.ExternalTableColumnDefinition fragment) {
            if (fragment is null) { return null; }
            return new ExternalTableColumnDefinition(
                columnDefinition: (ColumnDefinitionBase)FromMutable(fragment.ColumnDefinition),
                nullableConstraint: (NullableConstraintDefinition)FromMutable(fragment.NullableConstraint)
            );
        }
        
        public static ExternalTableDistributionOption FromMutable(ScriptDom.ExternalTableDistributionOption fragment) {
            if (fragment is null) { return null; }
            return new ExternalTableDistributionOption(
                @value: (ExternalTableDistributionPolicy)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalTableLiteralOrIdentifierOption FromMutable(ScriptDom.ExternalTableLiteralOrIdentifierOption fragment) {
            if (fragment is null) { return null; }
            return new ExternalTableLiteralOrIdentifierOption(
                @value: (IdentifierOrValueExpression)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalTableRejectTypeOption FromMutable(ScriptDom.ExternalTableRejectTypeOption fragment) {
            if (fragment is null) { return null; }
            return new ExternalTableRejectTypeOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static ExternalTableReplicatedDistributionPolicy FromMutable(ScriptDom.ExternalTableReplicatedDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            return new ExternalTableReplicatedDistributionPolicy(
                
            );
        }
        
        public static ExternalTableRoundRobinDistributionPolicy FromMutable(ScriptDom.ExternalTableRoundRobinDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            return new ExternalTableRoundRobinDistributionPolicy(
                
            );
        }
        
        public static ExternalTableShardedDistributionPolicy FromMutable(ScriptDom.ExternalTableShardedDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            return new ExternalTableShardedDistributionPolicy(
                shardingColumn: (Identifier)FromMutable(fragment.ShardingColumn)
            );
        }
        
        public static ExtractFromExpression FromMutable(ScriptDom.ExtractFromExpression fragment) {
            if (fragment is null) { return null; }
            return new ExtractFromExpression(
                expression: (ScalarExpression)FromMutable(fragment.Expression),
                extractedElement: (Identifier)FromMutable(fragment.ExtractedElement)
            );
        }
        
        public static FailoverModeReplicaOption FromMutable(ScriptDom.FailoverModeReplicaOption fragment) {
            if (fragment is null) { return null; }
            return new FailoverModeReplicaOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static FederationScheme FromMutable(ScriptDom.FederationScheme fragment) {
            if (fragment is null) { return null; }
            return new FederationScheme(
                distributionName: (Identifier)FromMutable(fragment.DistributionName),
                columnName: (Identifier)FromMutable(fragment.ColumnName)
            );
        }
        
        public static FetchCursorStatement FromMutable(ScriptDom.FetchCursorStatement fragment) {
            if (fragment is null) { return null; }
            return new FetchCursorStatement(
                fetchType: (FetchType)FromMutable(fragment.FetchType),
                intoVariables: fragment.IntoVariables.SelectList(c => (VariableReference)FromMutable(c)),
                cursor: (CursorId)FromMutable(fragment.Cursor)
            );
        }
        
        public static FetchType FromMutable(ScriptDom.FetchType fragment) {
            if (fragment is null) { return null; }
            return new FetchType(
                orientation: fragment.Orientation,
                rowOffset: (ScalarExpression)FromMutable(fragment.RowOffset)
            );
        }
        
        public static FileDeclaration FromMutable(ScriptDom.FileDeclaration fragment) {
            if (fragment is null) { return null; }
            return new FileDeclaration(
                options: fragment.Options.SelectList(c => (FileDeclarationOption)FromMutable(c)),
                isPrimary: fragment.IsPrimary
            );
        }
        
        public static FileDeclarationOption FromMutable(ScriptDom.FileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            return new FileDeclarationOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileEncryptionSource FromMutable(ScriptDom.FileEncryptionSource fragment) {
            if (fragment is null) { return null; }
            return new FileEncryptionSource(
                isExecutable: fragment.IsExecutable,
                file: (Literal)FromMutable(fragment.File)
            );
        }
        
        public static FileGroupDefinition FromMutable(ScriptDom.FileGroupDefinition fragment) {
            if (fragment is null) { return null; }
            return new FileGroupDefinition(
                name: (Identifier)FromMutable(fragment.Name),
                fileDeclarations: fragment.FileDeclarations.SelectList(c => (FileDeclaration)FromMutable(c)),
                isDefault: fragment.IsDefault,
                containsFileStream: fragment.ContainsFileStream,
                containsMemoryOptimizedData: fragment.ContainsMemoryOptimizedData
            );
        }
        
        public static FileGroupOrPartitionScheme FromMutable(ScriptDom.FileGroupOrPartitionScheme fragment) {
            if (fragment is null) { return null; }
            return new FileGroupOrPartitionScheme(
                name: (IdentifierOrValueExpression)FromMutable(fragment.Name),
                partitionSchemeColumns: fragment.PartitionSchemeColumns.SelectList(c => (Identifier)FromMutable(c))
            );
        }
        
        public static FileGrowthFileDeclarationOption FromMutable(ScriptDom.FileGrowthFileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            return new FileGrowthFileDeclarationOption(
                growthIncrement: (Literal)FromMutable(fragment.GrowthIncrement),
                units: fragment.Units,
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileNameFileDeclarationOption FromMutable(ScriptDom.FileNameFileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            return new FileNameFileDeclarationOption(
                oSFileName: (Literal)FromMutable(fragment.OSFileName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileStreamDatabaseOption FromMutable(ScriptDom.FileStreamDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new FileStreamDatabaseOption(
                nonTransactedAccess: fragment.NonTransactedAccess,
                directoryName: (Literal)FromMutable(fragment.DirectoryName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileStreamOnDropIndexOption FromMutable(ScriptDom.FileStreamOnDropIndexOption fragment) {
            if (fragment is null) { return null; }
            return new FileStreamOnDropIndexOption(
                fileStreamOn: (IdentifierOrValueExpression)FromMutable(fragment.FileStreamOn),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileStreamOnTableOption FromMutable(ScriptDom.FileStreamOnTableOption fragment) {
            if (fragment is null) { return null; }
            return new FileStreamOnTableOption(
                @value: (IdentifierOrValueExpression)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileStreamRestoreOption FromMutable(ScriptDom.FileStreamRestoreOption fragment) {
            if (fragment is null) { return null; }
            return new FileStreamRestoreOption(
                fileStreamOption: (FileStreamDatabaseOption)FromMutable(fragment.FileStreamOption),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileTableCollateFileNameTableOption FromMutable(ScriptDom.FileTableCollateFileNameTableOption fragment) {
            if (fragment is null) { return null; }
            return new FileTableCollateFileNameTableOption(
                @value: (Identifier)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileTableConstraintNameTableOption FromMutable(ScriptDom.FileTableConstraintNameTableOption fragment) {
            if (fragment is null) { return null; }
            return new FileTableConstraintNameTableOption(
                @value: (Identifier)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static FileTableDirectoryTableOption FromMutable(ScriptDom.FileTableDirectoryTableOption fragment) {
            if (fragment is null) { return null; }
            return new FileTableDirectoryTableOption(
                @value: (Literal)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ForceSeekTableHint FromMutable(ScriptDom.ForceSeekTableHint fragment) {
            if (fragment is null) { return null; }
            return new ForceSeekTableHint(
                indexValue: (IdentifierOrValueExpression)FromMutable(fragment.IndexValue),
                columnValues: fragment.ColumnValues.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                hintKind: fragment.HintKind
            );
        }
        
        public static ForeignKeyConstraintDefinition FromMutable(ScriptDom.ForeignKeyConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            return new ForeignKeyConstraintDefinition(
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                referenceTableName: (SchemaObjectName)FromMutable(fragment.ReferenceTableName),
                referencedTableColumns: fragment.ReferencedTableColumns.SelectList(c => (Identifier)FromMutable(c)),
                deleteAction: fragment.DeleteAction,
                updateAction: fragment.UpdateAction,
                notForReplication: fragment.NotForReplication,
                constraintIdentifier: (Identifier)FromMutable(fragment.ConstraintIdentifier)
            );
        }
        
        public static FromClause FromMutable(ScriptDom.FromClause fragment) {
            if (fragment is null) { return null; }
            return new FromClause(
                tableReferences: fragment.TableReferences.SelectList(c => (TableReference)FromMutable(c)),
                predictTableReference: fragment.PredictTableReference.SelectList(c => (PredictTableReference)FromMutable(c))
            );
        }
        
        public static FullTextCatalogAndFileGroup FromMutable(ScriptDom.FullTextCatalogAndFileGroup fragment) {
            if (fragment is null) { return null; }
            return new FullTextCatalogAndFileGroup(
                catalogName: (Identifier)FromMutable(fragment.CatalogName),
                fileGroupName: (Identifier)FromMutable(fragment.FileGroupName),
                fileGroupIsFirst: fragment.FileGroupIsFirst
            );
        }
        
        public static FullTextIndexColumn FromMutable(ScriptDom.FullTextIndexColumn fragment) {
            if (fragment is null) { return null; }
            return new FullTextIndexColumn(
                name: (Identifier)FromMutable(fragment.Name),
                typeColumn: (Identifier)FromMutable(fragment.TypeColumn),
                languageTerm: (IdentifierOrValueExpression)FromMutable(fragment.LanguageTerm),
                statisticalSemantics: fragment.StatisticalSemantics
            );
        }
        
        public static FullTextPredicate FromMutable(ScriptDom.FullTextPredicate fragment) {
            if (fragment is null) { return null; }
            return new FullTextPredicate(
                fullTextFunctionType: fragment.FullTextFunctionType,
                columns: fragment.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                @value: (ValueExpression)FromMutable(fragment.Value),
                languageTerm: (ValueExpression)FromMutable(fragment.LanguageTerm),
                propertyName: (StringLiteral)FromMutable(fragment.PropertyName)
            );
        }
        
        public static FullTextStopListAction FromMutable(ScriptDom.FullTextStopListAction fragment) {
            if (fragment is null) { return null; }
            return new FullTextStopListAction(
                isAdd: fragment.IsAdd,
                isAll: fragment.IsAll,
                stopWord: (Literal)FromMutable(fragment.StopWord),
                languageTerm: (IdentifierOrValueExpression)FromMutable(fragment.LanguageTerm)
            );
        }
        
        public static FullTextTableReference FromMutable(ScriptDom.FullTextTableReference fragment) {
            if (fragment is null) { return null; }
            return new FullTextTableReference(
                fullTextFunctionType: fragment.FullTextFunctionType,
                tableName: (SchemaObjectName)FromMutable(fragment.TableName),
                columns: fragment.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                searchCondition: (ValueExpression)FromMutable(fragment.SearchCondition),
                topN: (ValueExpression)FromMutable(fragment.TopN),
                language: (ValueExpression)FromMutable(fragment.Language),
                propertyName: (StringLiteral)FromMutable(fragment.PropertyName),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static FunctionCall FromMutable(ScriptDom.FunctionCall fragment) {
            if (fragment is null) { return null; }
            return new FunctionCall(
                callTarget: (CallTarget)FromMutable(fragment.CallTarget),
                functionName: (Identifier)FromMutable(fragment.FunctionName),
                parameters: fragment.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                uniqueRowFilter: fragment.UniqueRowFilter,
                overClause: (OverClause)FromMutable(fragment.OverClause),
                withinGroupClause: (WithinGroupClause)FromMutable(fragment.WithinGroupClause),
                ignoreRespectNulls: fragment.IgnoreRespectNulls.SelectList(c => (Identifier)FromMutable(c)),
                trimOptions: (Identifier)FromMutable(fragment.TrimOptions),
                jsonParameters: fragment.JsonParameters.SelectList(c => (JsonKeyValue)FromMutable(c)),
                absentOrNullOnNull: fragment.AbsentOrNullOnNull.SelectList(c => (Identifier)FromMutable(c)),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static FunctionCallSetClause FromMutable(ScriptDom.FunctionCallSetClause fragment) {
            if (fragment is null) { return null; }
            return new FunctionCallSetClause(
                mutatorFunction: (FunctionCall)FromMutable(fragment.MutatorFunction)
            );
        }
        
        public static FunctionOption FromMutable(ScriptDom.FunctionOption fragment) {
            if (fragment is null) { return null; }
            return new FunctionOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static GeneralSetCommand FromMutable(ScriptDom.GeneralSetCommand fragment) {
            if (fragment is null) { return null; }
            return new GeneralSetCommand(
                commandType: fragment.CommandType,
                parameter: (ScalarExpression)FromMutable(fragment.Parameter)
            );
        }
        
        public static GenericConfigurationOption FromMutable(ScriptDom.GenericConfigurationOption fragment) {
            if (fragment is null) { return null; }
            return new GenericConfigurationOption(
                genericOptionState: (IdentifierOrScalarExpression)FromMutable(fragment.GenericOptionState),
                optionKind: fragment.OptionKind,
                genericOptionKind: (Identifier)FromMutable(fragment.GenericOptionKind)
            );
        }
        
        public static GetConversationGroupStatement FromMutable(ScriptDom.GetConversationGroupStatement fragment) {
            if (fragment is null) { return null; }
            return new GetConversationGroupStatement(
                groupId: (VariableReference)FromMutable(fragment.GroupId),
                queue: (SchemaObjectName)FromMutable(fragment.Queue)
            );
        }
        
        public static GlobalFunctionTableReference FromMutable(ScriptDom.GlobalFunctionTableReference fragment) {
            if (fragment is null) { return null; }
            return new GlobalFunctionTableReference(
                name: (Identifier)FromMutable(fragment.Name),
                parameters: fragment.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static GlobalVariableExpression FromMutable(ScriptDom.GlobalVariableExpression fragment) {
            if (fragment is null) { return null; }
            return new GlobalVariableExpression(
                name: fragment.Name,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static GoToStatement FromMutable(ScriptDom.GoToStatement fragment) {
            if (fragment is null) { return null; }
            return new GoToStatement(
                labelName: (Identifier)FromMutable(fragment.LabelName)
            );
        }
        
        public static GrandTotalGroupingSpecification FromMutable(ScriptDom.GrandTotalGroupingSpecification fragment) {
            if (fragment is null) { return null; }
            return new GrandTotalGroupingSpecification(
                
            );
        }
        
        public static GrantStatement FromMutable(ScriptDom.GrantStatement fragment) {
            if (fragment is null) { return null; }
            return new GrantStatement(
                withGrantOption: fragment.WithGrantOption,
                permissions: fragment.Permissions.SelectList(c => (Permission)FromMutable(c)),
                securityTargetObject: (SecurityTargetObject)FromMutable(fragment.SecurityTargetObject),
                principals: fragment.Principals.SelectList(c => (SecurityPrincipal)FromMutable(c)),
                asClause: (Identifier)FromMutable(fragment.AsClause)
            );
        }
        
        public static GrantStatement80 FromMutable(ScriptDom.GrantStatement80 fragment) {
            if (fragment is null) { return null; }
            return new GrantStatement80(
                withGrantOption: fragment.WithGrantOption,
                asClause: (Identifier)FromMutable(fragment.AsClause),
                securityElement80: (SecurityElement80)FromMutable(fragment.SecurityElement80),
                securityUserClause80: (SecurityUserClause80)FromMutable(fragment.SecurityUserClause80)
            );
        }
        
        public static GraphConnectionBetweenNodes FromMutable(ScriptDom.GraphConnectionBetweenNodes fragment) {
            if (fragment is null) { return null; }
            return new GraphConnectionBetweenNodes(
                fromNode: (SchemaObjectName)FromMutable(fragment.FromNode),
                toNode: (SchemaObjectName)FromMutable(fragment.ToNode)
            );
        }
        
        public static GraphConnectionConstraintDefinition FromMutable(ScriptDom.GraphConnectionConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            return new GraphConnectionConstraintDefinition(
                fromNodeToNodeList: fragment.FromNodeToNodeList.SelectList(c => (GraphConnectionBetweenNodes)FromMutable(c)),
                deleteAction: fragment.DeleteAction,
                constraintIdentifier: (Identifier)FromMutable(fragment.ConstraintIdentifier)
            );
        }
        
        public static GraphMatchCompositeExpression FromMutable(ScriptDom.GraphMatchCompositeExpression fragment) {
            if (fragment is null) { return null; }
            return new GraphMatchCompositeExpression(
                leftNode: (GraphMatchNodeExpression)FromMutable(fragment.LeftNode),
                edge: (Identifier)FromMutable(fragment.Edge),
                rightNode: (GraphMatchNodeExpression)FromMutable(fragment.RightNode),
                arrowOnRight: fragment.ArrowOnRight
            );
        }
        
        public static GraphMatchExpression FromMutable(ScriptDom.GraphMatchExpression fragment) {
            if (fragment is null) { return null; }
            return new GraphMatchExpression(
                leftNode: (Identifier)FromMutable(fragment.LeftNode),
                edge: (Identifier)FromMutable(fragment.Edge),
                rightNode: (Identifier)FromMutable(fragment.RightNode),
                arrowOnRight: fragment.ArrowOnRight
            );
        }
        
        public static GraphMatchLastNodePredicate FromMutable(ScriptDom.GraphMatchLastNodePredicate fragment) {
            if (fragment is null) { return null; }
            return new GraphMatchLastNodePredicate(
                leftExpression: (GraphMatchNodeExpression)FromMutable(fragment.LeftExpression),
                rightExpression: (GraphMatchNodeExpression)FromMutable(fragment.RightExpression)
            );
        }
        
        public static GraphMatchNodeExpression FromMutable(ScriptDom.GraphMatchNodeExpression fragment) {
            if (fragment is null) { return null; }
            return new GraphMatchNodeExpression(
                node: (Identifier)FromMutable(fragment.Node),
                usesLastNode: fragment.UsesLastNode
            );
        }
        
        public static GraphMatchPredicate FromMutable(ScriptDom.GraphMatchPredicate fragment) {
            if (fragment is null) { return null; }
            return new GraphMatchPredicate(
                expression: (BooleanExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static GraphMatchRecursivePredicate FromMutable(ScriptDom.GraphMatchRecursivePredicate fragment) {
            if (fragment is null) { return null; }
            return new GraphMatchRecursivePredicate(
                function: fragment.Function,
                outerNodeExpression: (GraphMatchNodeExpression)FromMutable(fragment.OuterNodeExpression),
                expression: fragment.Expression.SelectList(c => (BooleanExpression)FromMutable(c)),
                recursiveQuantifier: (GraphRecursiveMatchQuantifier)FromMutable(fragment.RecursiveQuantifier),
                anchorOnLeft: fragment.AnchorOnLeft
            );
        }
        
        public static GraphRecursiveMatchQuantifier FromMutable(ScriptDom.GraphRecursiveMatchQuantifier fragment) {
            if (fragment is null) { return null; }
            return new GraphRecursiveMatchQuantifier(
                isPlusSign: fragment.IsPlusSign,
                lowerLimit: (Literal)FromMutable(fragment.LowerLimit),
                upperLimit: (Literal)FromMutable(fragment.UpperLimit)
            );
        }
        
        public static GridParameter FromMutable(ScriptDom.GridParameter fragment) {
            if (fragment is null) { return null; }
            return new GridParameter(
                parameter: fragment.Parameter,
                @value: fragment.Value
            );
        }
        
        public static GridsSpatialIndexOption FromMutable(ScriptDom.GridsSpatialIndexOption fragment) {
            if (fragment is null) { return null; }
            return new GridsSpatialIndexOption(
                gridParameters: fragment.GridParameters.SelectList(c => (GridParameter)FromMutable(c))
            );
        }
        
        public static GroupByClause FromMutable(ScriptDom.GroupByClause fragment) {
            if (fragment is null) { return null; }
            return new GroupByClause(
                groupByOption: fragment.GroupByOption,
                all: fragment.All,
                groupingSpecifications: fragment.GroupingSpecifications.SelectList(c => (GroupingSpecification)FromMutable(c))
            );
        }
        
        public static GroupingSetsGroupingSpecification FromMutable(ScriptDom.GroupingSetsGroupingSpecification fragment) {
            if (fragment is null) { return null; }
            return new GroupingSetsGroupingSpecification(
                sets: fragment.Sets.SelectList(c => (GroupingSpecification)FromMutable(c))
            );
        }
        
        public static HadrAvailabilityGroupDatabaseOption FromMutable(ScriptDom.HadrAvailabilityGroupDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new HadrAvailabilityGroupDatabaseOption(
                groupName: (Identifier)FromMutable(fragment.GroupName),
                hadrOption: fragment.HadrOption,
                optionKind: fragment.OptionKind
            );
        }
        
        public static HadrDatabaseOption FromMutable(ScriptDom.HadrDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new HadrDatabaseOption(
                hadrOption: fragment.HadrOption,
                optionKind: fragment.OptionKind
            );
        }
        
        public static HavingClause FromMutable(ScriptDom.HavingClause fragment) {
            if (fragment is null) { return null; }
            return new HavingClause(
                searchCondition: (BooleanExpression)FromMutable(fragment.SearchCondition)
            );
        }
        
        public static Identifier FromMutable(ScriptDom.Identifier fragment) {
            if (fragment is null) { return null; }
            return new Identifier(
                @value: fragment.Value,
                quoteType: fragment.QuoteType
            );
        }
        
        public static IdentifierAtomicBlockOption FromMutable(ScriptDom.IdentifierAtomicBlockOption fragment) {
            if (fragment is null) { return null; }
            return new IdentifierAtomicBlockOption(
                @value: (Identifier)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static IdentifierDatabaseOption FromMutable(ScriptDom.IdentifierDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new IdentifierDatabaseOption(
                @value: (Identifier)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static IdentifierLiteral FromMutable(ScriptDom.IdentifierLiteral fragment) {
            if (fragment is null) { return null; }
            return new IdentifierLiteral(
                quoteType: fragment.QuoteType,
                @value: fragment.Value,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static IdentifierOrScalarExpression FromMutable(ScriptDom.IdentifierOrScalarExpression fragment) {
            if (fragment is null) { return null; }
            return new IdentifierOrScalarExpression(
                identifier: (Identifier)FromMutable(fragment.Identifier),
                scalarExpression: (ScalarExpression)FromMutable(fragment.ScalarExpression)
            );
        }
        
        public static IdentifierOrValueExpression FromMutable(ScriptDom.IdentifierOrValueExpression fragment) {
            if (fragment is null) { return null; }
            return new IdentifierOrValueExpression(
                identifier: (Identifier)FromMutable(fragment.Identifier),
                valueExpression: (ValueExpression)FromMutable(fragment.ValueExpression)
            );
        }
        
        public static IdentifierPrincipalOption FromMutable(ScriptDom.IdentifierPrincipalOption fragment) {
            if (fragment is null) { return null; }
            return new IdentifierPrincipalOption(
                identifier: (Identifier)FromMutable(fragment.Identifier),
                optionKind: fragment.OptionKind
            );
        }
        
        public static IdentifierSnippet FromMutable(ScriptDom.IdentifierSnippet fragment) {
            if (fragment is null) { return null; }
            return new IdentifierSnippet(
                script: fragment.Script,
                @value: fragment.Value,
                quoteType: fragment.QuoteType
            );
        }
        
        public static IdentityFunctionCall FromMutable(ScriptDom.IdentityFunctionCall fragment) {
            if (fragment is null) { return null; }
            return new IdentityFunctionCall(
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                seed: (ScalarExpression)FromMutable(fragment.Seed),
                increment: (ScalarExpression)FromMutable(fragment.Increment)
            );
        }
        
        public static IdentityOptions FromMutable(ScriptDom.IdentityOptions fragment) {
            if (fragment is null) { return null; }
            return new IdentityOptions(
                identitySeed: (ScalarExpression)FromMutable(fragment.IdentitySeed),
                identityIncrement: (ScalarExpression)FromMutable(fragment.IdentityIncrement),
                isIdentityNotForReplication: fragment.IsIdentityNotForReplication
            );
        }
        
        public static IdentityValueKeyOption FromMutable(ScriptDom.IdentityValueKeyOption fragment) {
            if (fragment is null) { return null; }
            return new IdentityValueKeyOption(
                identityPhrase: (Literal)FromMutable(fragment.IdentityPhrase),
                optionKind: fragment.OptionKind
            );
        }
        
        public static IfStatement FromMutable(ScriptDom.IfStatement fragment) {
            if (fragment is null) { return null; }
            return new IfStatement(
                predicate: (BooleanExpression)FromMutable(fragment.Predicate),
                thenStatement: (TSqlStatement)FromMutable(fragment.ThenStatement),
                elseStatement: (TSqlStatement)FromMutable(fragment.ElseStatement)
            );
        }
        
        public static IgnoreDupKeyIndexOption FromMutable(ScriptDom.IgnoreDupKeyIndexOption fragment) {
            if (fragment is null) { return null; }
            return new IgnoreDupKeyIndexOption(
                suppressMessagesOption: fragment.SuppressMessagesOption,
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static IIfCall FromMutable(ScriptDom.IIfCall fragment) {
            if (fragment is null) { return null; }
            return new IIfCall(
                predicate: (BooleanExpression)FromMutable(fragment.Predicate),
                thenExpression: (ScalarExpression)FromMutable(fragment.ThenExpression),
                elseExpression: (ScalarExpression)FromMutable(fragment.ElseExpression),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static IndexDefinition FromMutable(ScriptDom.IndexDefinition fragment) {
            if (fragment is null) { return null; }
            return new IndexDefinition(
                name: (Identifier)FromMutable(fragment.Name),
                unique: fragment.Unique,
                indexType: (IndexType)FromMutable(fragment.IndexType),
                indexOptions: fragment.IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                columns: fragment.Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                includeColumns: fragment.IncludeColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable(fragment.OnFileGroupOrPartitionScheme),
                filterPredicate: (BooleanExpression)FromMutable(fragment.FilterPredicate),
                fileStreamOn: (IdentifierOrValueExpression)FromMutable(fragment.FileStreamOn)
            );
        }
        
        public static IndexExpressionOption FromMutable(ScriptDom.IndexExpressionOption fragment) {
            if (fragment is null) { return null; }
            return new IndexExpressionOption(
                expression: (ScalarExpression)FromMutable(fragment.Expression),
                optionKind: fragment.OptionKind
            );
        }
        
        public static IndexStateOption FromMutable(ScriptDom.IndexStateOption fragment) {
            if (fragment is null) { return null; }
            return new IndexStateOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static IndexTableHint FromMutable(ScriptDom.IndexTableHint fragment) {
            if (fragment is null) { return null; }
            return new IndexTableHint(
                indexValues: fragment.IndexValues.SelectList(c => (IdentifierOrValueExpression)FromMutable(c)),
                hintKind: fragment.HintKind
            );
        }
        
        public static IndexType FromMutable(ScriptDom.IndexType fragment) {
            if (fragment is null) { return null; }
            return new IndexType(
                indexTypeKind: fragment.IndexTypeKind
            );
        }
        
        public static InlineDerivedTable FromMutable(ScriptDom.InlineDerivedTable fragment) {
            if (fragment is null) { return null; }
            return new InlineDerivedTable(
                rowValues: fragment.RowValues.SelectList(c => (RowValue)FromMutable(c)),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static InlineFunctionOption FromMutable(ScriptDom.InlineFunctionOption fragment) {
            if (fragment is null) { return null; }
            return new InlineFunctionOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static InlineResultSetDefinition FromMutable(ScriptDom.InlineResultSetDefinition fragment) {
            if (fragment is null) { return null; }
            return new InlineResultSetDefinition(
                resultColumnDefinitions: fragment.ResultColumnDefinitions.SelectList(c => (ResultColumnDefinition)FromMutable(c)),
                resultSetType: fragment.ResultSetType
            );
        }
        
        public static InPredicate FromMutable(ScriptDom.InPredicate fragment) {
            if (fragment is null) { return null; }
            return new InPredicate(
                expression: (ScalarExpression)FromMutable(fragment.Expression),
                subquery: (ScalarSubquery)FromMutable(fragment.Subquery),
                notDefined: fragment.NotDefined,
                values: fragment.Values.SelectList(c => (ScalarExpression)FromMutable(c))
            );
        }
        
        public static InsertBulkColumnDefinition FromMutable(ScriptDom.InsertBulkColumnDefinition fragment) {
            if (fragment is null) { return null; }
            return new InsertBulkColumnDefinition(
                column: (ColumnDefinitionBase)FromMutable(fragment.Column),
                nullNotNull: fragment.NullNotNull
            );
        }
        
        public static InsertBulkStatement FromMutable(ScriptDom.InsertBulkStatement fragment) {
            if (fragment is null) { return null; }
            return new InsertBulkStatement(
                columnDefinitions: fragment.ColumnDefinitions.SelectList(c => (InsertBulkColumnDefinition)FromMutable(c)),
                to: (SchemaObjectName)FromMutable(fragment.To),
                options: fragment.Options.SelectList(c => (BulkInsertOption)FromMutable(c))
            );
        }
        
        public static InsertMergeAction FromMutable(ScriptDom.InsertMergeAction fragment) {
            if (fragment is null) { return null; }
            return new InsertMergeAction(
                columns: fragment.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                source: (ValuesInsertSource)FromMutable(fragment.Source)
            );
        }
        
        public static InsertSpecification FromMutable(ScriptDom.InsertSpecification fragment) {
            if (fragment is null) { return null; }
            return new InsertSpecification(
                insertOption: fragment.InsertOption,
                insertSource: (InsertSource)FromMutable(fragment.InsertSource),
                columns: fragment.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                target: (TableReference)FromMutable(fragment.Target),
                topRowFilter: (TopRowFilter)FromMutable(fragment.TopRowFilter),
                outputIntoClause: (OutputIntoClause)FromMutable(fragment.OutputIntoClause),
                outputClause: (OutputClause)FromMutable(fragment.OutputClause)
            );
        }
        
        public static InsertStatement FromMutable(ScriptDom.InsertStatement fragment) {
            if (fragment is null) { return null; }
            return new InsertStatement(
                insertSpecification: (InsertSpecification)FromMutable(fragment.InsertSpecification),
                withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
            );
        }
        
        public static IntegerLiteral FromMutable(ScriptDom.IntegerLiteral fragment) {
            if (fragment is null) { return null; }
            return new IntegerLiteral(
                @value: fragment.Value,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static InternalOpenRowset FromMutable(ScriptDom.InternalOpenRowset fragment) {
            if (fragment is null) { return null; }
            return new InternalOpenRowset(
                identifier: (Identifier)FromMutable(fragment.Identifier),
                varArgs: fragment.VarArgs.SelectList(c => (ScalarExpression)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static IPv4 FromMutable(ScriptDom.IPv4 fragment) {
            if (fragment is null) { return null; }
            return new IPv4(
                octetOne: (Literal)FromMutable(fragment.OctetOne),
                octetTwo: (Literal)FromMutable(fragment.OctetTwo),
                octetThree: (Literal)FromMutable(fragment.OctetThree),
                octetFour: (Literal)FromMutable(fragment.OctetFour)
            );
        }
        
        public static JoinParenthesisTableReference FromMutable(ScriptDom.JoinParenthesisTableReference fragment) {
            if (fragment is null) { return null; }
            return new JoinParenthesisTableReference(
                join: (TableReference)FromMutable(fragment.Join)
            );
        }
        
        public static JsonForClause FromMutable(ScriptDom.JsonForClause fragment) {
            if (fragment is null) { return null; }
            return new JsonForClause(
                options: fragment.Options.SelectList(c => (JsonForClauseOption)FromMutable(c))
            );
        }
        
        public static JsonForClauseOption FromMutable(ScriptDom.JsonForClauseOption fragment) {
            if (fragment is null) { return null; }
            return new JsonForClauseOption(
                optionKind: fragment.OptionKind,
                @value: (Literal)FromMutable(fragment.Value)
            );
        }
        
        public static JsonKeyValue FromMutable(ScriptDom.JsonKeyValue fragment) {
            if (fragment is null) { return null; }
            return new JsonKeyValue(
                jsonKeyName: (ScalarExpression)FromMutable(fragment.JsonKeyName),
                jsonValue: (ScalarExpression)FromMutable(fragment.JsonValue)
            );
        }
        
        public static KeySourceKeyOption FromMutable(ScriptDom.KeySourceKeyOption fragment) {
            if (fragment is null) { return null; }
            return new KeySourceKeyOption(
                passPhrase: (Literal)FromMutable(fragment.PassPhrase),
                optionKind: fragment.OptionKind
            );
        }
        
        public static KillQueryNotificationSubscriptionStatement FromMutable(ScriptDom.KillQueryNotificationSubscriptionStatement fragment) {
            if (fragment is null) { return null; }
            return new KillQueryNotificationSubscriptionStatement(
                subscriptionId: (Literal)FromMutable(fragment.SubscriptionId),
                all: fragment.All
            );
        }
        
        public static KillStatement FromMutable(ScriptDom.KillStatement fragment) {
            if (fragment is null) { return null; }
            return new KillStatement(
                parameter: (ScalarExpression)FromMutable(fragment.Parameter),
                withStatusOnly: fragment.WithStatusOnly
            );
        }
        
        public static KillStatsJobStatement FromMutable(ScriptDom.KillStatsJobStatement fragment) {
            if (fragment is null) { return null; }
            return new KillStatsJobStatement(
                jobId: (ScalarExpression)FromMutable(fragment.JobId)
            );
        }
        
        public static LabelStatement FromMutable(ScriptDom.LabelStatement fragment) {
            if (fragment is null) { return null; }
            return new LabelStatement(
                @value: fragment.Value
            );
        }
        
        public static LedgerOption FromMutable(ScriptDom.LedgerOption fragment) {
            if (fragment is null) { return null; }
            return new LedgerOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static LedgerTableOption FromMutable(ScriptDom.LedgerTableOption fragment) {
            if (fragment is null) { return null; }
            return new LedgerTableOption(
                optionState: fragment.OptionState,
                appendOnly: fragment.AppendOnly,
                ledgerViewOption: (LedgerViewOption)FromMutable(fragment.LedgerViewOption),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LedgerViewOption FromMutable(ScriptDom.LedgerViewOption fragment) {
            if (fragment is null) { return null; }
            return new LedgerViewOption(
                viewName: (SchemaObjectName)FromMutable(fragment.ViewName),
                transactionIdColumnName: (Identifier)FromMutable(fragment.TransactionIdColumnName),
                sequenceNumberColumnName: (Identifier)FromMutable(fragment.SequenceNumberColumnName),
                operationTypeColumnName: (Identifier)FromMutable(fragment.OperationTypeColumnName),
                operationTypeDescColumnName: (Identifier)FromMutable(fragment.OperationTypeDescColumnName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LeftFunctionCall FromMutable(ScriptDom.LeftFunctionCall fragment) {
            if (fragment is null) { return null; }
            return new LeftFunctionCall(
                parameters: fragment.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static LikePredicate FromMutable(ScriptDom.LikePredicate fragment) {
            if (fragment is null) { return null; }
            return new LikePredicate(
                firstExpression: (ScalarExpression)FromMutable(fragment.FirstExpression),
                secondExpression: (ScalarExpression)FromMutable(fragment.SecondExpression),
                notDefined: fragment.NotDefined,
                odbcEscape: fragment.OdbcEscape,
                escapeExpression: (ScalarExpression)FromMutable(fragment.EscapeExpression)
            );
        }
        
        public static LineNoStatement FromMutable(ScriptDom.LineNoStatement fragment) {
            if (fragment is null) { return null; }
            return new LineNoStatement(
                lineNo: (IntegerLiteral)FromMutable(fragment.LineNo)
            );
        }
        
        public static ListenerIPEndpointProtocolOption FromMutable(ScriptDom.ListenerIPEndpointProtocolOption fragment) {
            if (fragment is null) { return null; }
            return new ListenerIPEndpointProtocolOption(
                isAll: fragment.IsAll,
                iPv6: (Literal)FromMutable(fragment.IPv6),
                iPv4PartOne: (IPv4)FromMutable(fragment.IPv4PartOne),
                iPv4PartTwo: (IPv4)FromMutable(fragment.IPv4PartTwo),
                kind: fragment.Kind
            );
        }
        
        public static ListTypeCopyOption FromMutable(ScriptDom.ListTypeCopyOption fragment) {
            if (fragment is null) { return null; }
            return new ListTypeCopyOption(
                options: fragment.Options.SelectList(c => (CopyStatementOptionBase)FromMutable(c))
            );
        }
        
        public static LiteralAtomicBlockOption FromMutable(ScriptDom.LiteralAtomicBlockOption fragment) {
            if (fragment is null) { return null; }
            return new LiteralAtomicBlockOption(
                @value: (Literal)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralAuditTargetOption FromMutable(ScriptDom.LiteralAuditTargetOption fragment) {
            if (fragment is null) { return null; }
            return new LiteralAuditTargetOption(
                @value: (Literal)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralAvailabilityGroupOption FromMutable(ScriptDom.LiteralAvailabilityGroupOption fragment) {
            if (fragment is null) { return null; }
            return new LiteralAvailabilityGroupOption(
                @value: (Literal)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralBulkInsertOption FromMutable(ScriptDom.LiteralBulkInsertOption fragment) {
            if (fragment is null) { return null; }
            return new LiteralBulkInsertOption(
                @value: (Literal)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralDatabaseOption FromMutable(ScriptDom.LiteralDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new LiteralDatabaseOption(
                @value: (Literal)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralEndpointProtocolOption FromMutable(ScriptDom.LiteralEndpointProtocolOption fragment) {
            if (fragment is null) { return null; }
            return new LiteralEndpointProtocolOption(
                @value: (Literal)FromMutable(fragment.Value),
                kind: fragment.Kind
            );
        }
        
        public static LiteralOpenRowsetCosmosOption FromMutable(ScriptDom.LiteralOpenRowsetCosmosOption fragment) {
            if (fragment is null) { return null; }
            return new LiteralOpenRowsetCosmosOption(
                @value: (Literal)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralOptimizerHint FromMutable(ScriptDom.LiteralOptimizerHint fragment) {
            if (fragment is null) { return null; }
            return new LiteralOptimizerHint(
                @value: (Literal)FromMutable(fragment.Value),
                hintKind: fragment.HintKind
            );
        }
        
        public static LiteralOptionValue FromMutable(ScriptDom.LiteralOptionValue fragment) {
            if (fragment is null) { return null; }
            return new LiteralOptionValue(
                @value: (Literal)FromMutable(fragment.Value)
            );
        }
        
        public static LiteralPayloadOption FromMutable(ScriptDom.LiteralPayloadOption fragment) {
            if (fragment is null) { return null; }
            return new LiteralPayloadOption(
                @value: (Literal)FromMutable(fragment.Value),
                kind: fragment.Kind
            );
        }
        
        public static LiteralPrincipalOption FromMutable(ScriptDom.LiteralPrincipalOption fragment) {
            if (fragment is null) { return null; }
            return new LiteralPrincipalOption(
                @value: (Literal)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralRange FromMutable(ScriptDom.LiteralRange fragment) {
            if (fragment is null) { return null; }
            return new LiteralRange(
                from: (Literal)FromMutable(fragment.From),
                to: (Literal)FromMutable(fragment.To)
            );
        }
        
        public static LiteralReplicaOption FromMutable(ScriptDom.LiteralReplicaOption fragment) {
            if (fragment is null) { return null; }
            return new LiteralReplicaOption(
                @value: (Literal)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralSessionOption FromMutable(ScriptDom.LiteralSessionOption fragment) {
            if (fragment is null) { return null; }
            return new LiteralSessionOption(
                @value: (Literal)FromMutable(fragment.Value),
                unit: fragment.Unit,
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralStatisticsOption FromMutable(ScriptDom.LiteralStatisticsOption fragment) {
            if (fragment is null) { return null; }
            return new LiteralStatisticsOption(
                literal: (Literal)FromMutable(fragment.Literal),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LiteralTableHint FromMutable(ScriptDom.LiteralTableHint fragment) {
            if (fragment is null) { return null; }
            return new LiteralTableHint(
                @value: (Literal)FromMutable(fragment.Value),
                hintKind: fragment.HintKind
            );
        }
        
        public static LocationOption FromMutable(ScriptDom.LocationOption fragment) {
            if (fragment is null) { return null; }
            return new LocationOption(
                locationValue: (Identifier)FromMutable(fragment.LocationValue),
                optionKind: fragment.OptionKind
            );
        }
        
        public static LockEscalationTableOption FromMutable(ScriptDom.LockEscalationTableOption fragment) {
            if (fragment is null) { return null; }
            return new LockEscalationTableOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static LoginTypePayloadOption FromMutable(ScriptDom.LoginTypePayloadOption fragment) {
            if (fragment is null) { return null; }
            return new LoginTypePayloadOption(
                isWindows: fragment.IsWindows,
                kind: fragment.Kind
            );
        }
        
        public static LowPriorityLockWaitAbortAfterWaitOption FromMutable(ScriptDom.LowPriorityLockWaitAbortAfterWaitOption fragment) {
            if (fragment is null) { return null; }
            return new LowPriorityLockWaitAbortAfterWaitOption(
                abortAfterWait: fragment.AbortAfterWait,
                optionKind: fragment.OptionKind
            );
        }
        
        public static LowPriorityLockWaitMaxDurationOption FromMutable(ScriptDom.LowPriorityLockWaitMaxDurationOption fragment) {
            if (fragment is null) { return null; }
            return new LowPriorityLockWaitMaxDurationOption(
                maxDuration: (Literal)FromMutable(fragment.MaxDuration),
                unit: fragment.Unit,
                optionKind: fragment.OptionKind
            );
        }
        
        public static LowPriorityLockWaitTableSwitchOption FromMutable(ScriptDom.LowPriorityLockWaitTableSwitchOption fragment) {
            if (fragment is null) { return null; }
            return new LowPriorityLockWaitTableSwitchOption(
                options: fragment.Options.SelectList(c => (LowPriorityLockWaitOption)FromMutable(c)),
                optionKind: fragment.OptionKind
            );
        }
        
        public static MaxDispatchLatencySessionOption FromMutable(ScriptDom.MaxDispatchLatencySessionOption fragment) {
            if (fragment is null) { return null; }
            return new MaxDispatchLatencySessionOption(
                isInfinite: fragment.IsInfinite,
                @value: (Literal)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static MaxDopConfigurationOption FromMutable(ScriptDom.MaxDopConfigurationOption fragment) {
            if (fragment is null) { return null; }
            return new MaxDopConfigurationOption(
                @value: (Literal)FromMutable(fragment.Value),
                primary: fragment.Primary,
                optionKind: fragment.OptionKind,
                genericOptionKind: (Identifier)FromMutable(fragment.GenericOptionKind)
            );
        }
        
        public static MaxDurationOption FromMutable(ScriptDom.MaxDurationOption fragment) {
            if (fragment is null) { return null; }
            return new MaxDurationOption(
                maxDuration: (Literal)FromMutable(fragment.MaxDuration),
                unit: fragment.Unit,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MaxLiteral FromMutable(ScriptDom.MaxLiteral fragment) {
            if (fragment is null) { return null; }
            return new MaxLiteral(
                @value: fragment.Value,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static MaxRolloverFilesAuditTargetOption FromMutable(ScriptDom.MaxRolloverFilesAuditTargetOption fragment) {
            if (fragment is null) { return null; }
            return new MaxRolloverFilesAuditTargetOption(
                @value: (Literal)FromMutable(fragment.Value),
                isUnlimited: fragment.IsUnlimited,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MaxSizeAuditTargetOption FromMutable(ScriptDom.MaxSizeAuditTargetOption fragment) {
            if (fragment is null) { return null; }
            return new MaxSizeAuditTargetOption(
                isUnlimited: fragment.IsUnlimited,
                size: (Literal)FromMutable(fragment.Size),
                unit: fragment.Unit,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MaxSizeDatabaseOption FromMutable(ScriptDom.MaxSizeDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new MaxSizeDatabaseOption(
                maxSize: (Literal)FromMutable(fragment.MaxSize),
                units: fragment.Units,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MaxSizeFileDeclarationOption FromMutable(ScriptDom.MaxSizeFileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            return new MaxSizeFileDeclarationOption(
                maxSize: (Literal)FromMutable(fragment.MaxSize),
                units: fragment.Units,
                unlimited: fragment.Unlimited,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MemoryOptimizedTableOption FromMutable(ScriptDom.MemoryOptimizedTableOption fragment) {
            if (fragment is null) { return null; }
            return new MemoryOptimizedTableOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MemoryPartitionSessionOption FromMutable(ScriptDom.MemoryPartitionSessionOption fragment) {
            if (fragment is null) { return null; }
            return new MemoryPartitionSessionOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static MergeActionClause FromMutable(ScriptDom.MergeActionClause fragment) {
            if (fragment is null) { return null; }
            return new MergeActionClause(
                condition: fragment.Condition,
                searchCondition: (BooleanExpression)FromMutable(fragment.SearchCondition),
                action: (MergeAction)FromMutable(fragment.Action)
            );
        }
        
        public static MergeSpecification FromMutable(ScriptDom.MergeSpecification fragment) {
            if (fragment is null) { return null; }
            return new MergeSpecification(
                tableAlias: (Identifier)FromMutable(fragment.TableAlias),
                tableReference: (TableReference)FromMutable(fragment.TableReference),
                searchCondition: (BooleanExpression)FromMutable(fragment.SearchCondition),
                actionClauses: fragment.ActionClauses.SelectList(c => (MergeActionClause)FromMutable(c)),
                target: (TableReference)FromMutable(fragment.Target),
                topRowFilter: (TopRowFilter)FromMutable(fragment.TopRowFilter),
                outputIntoClause: (OutputIntoClause)FromMutable(fragment.OutputIntoClause),
                outputClause: (OutputClause)FromMutable(fragment.OutputClause)
            );
        }
        
        public static MergeStatement FromMutable(ScriptDom.MergeStatement fragment) {
            if (fragment is null) { return null; }
            return new MergeStatement(
                mergeSpecification: (MergeSpecification)FromMutable(fragment.MergeSpecification),
                withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
            );
        }
        
        public static MethodSpecifier FromMutable(ScriptDom.MethodSpecifier fragment) {
            if (fragment is null) { return null; }
            return new MethodSpecifier(
                assemblyName: (Identifier)FromMutable(fragment.AssemblyName),
                className: (Identifier)FromMutable(fragment.ClassName),
                methodName: (Identifier)FromMutable(fragment.MethodName)
            );
        }
        
        public static MirrorToClause FromMutable(ScriptDom.MirrorToClause fragment) {
            if (fragment is null) { return null; }
            return new MirrorToClause(
                devices: fragment.Devices.SelectList(c => (DeviceInfo)FromMutable(c))
            );
        }
        
        public static MoneyLiteral FromMutable(ScriptDom.MoneyLiteral fragment) {
            if (fragment is null) { return null; }
            return new MoneyLiteral(
                @value: fragment.Value,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static MoveConversationStatement FromMutable(ScriptDom.MoveConversationStatement fragment) {
            if (fragment is null) { return null; }
            return new MoveConversationStatement(
                conversation: (ScalarExpression)FromMutable(fragment.Conversation),
                group: (ScalarExpression)FromMutable(fragment.Group)
            );
        }
        
        public static MoveRestoreOption FromMutable(ScriptDom.MoveRestoreOption fragment) {
            if (fragment is null) { return null; }
            return new MoveRestoreOption(
                logicalFileName: (ValueExpression)FromMutable(fragment.LogicalFileName),
                oSFileName: (ValueExpression)FromMutable(fragment.OSFileName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static MoveToDropIndexOption FromMutable(ScriptDom.MoveToDropIndexOption fragment) {
            if (fragment is null) { return null; }
            return new MoveToDropIndexOption(
                moveTo: (FileGroupOrPartitionScheme)FromMutable(fragment.MoveTo),
                optionKind: fragment.OptionKind
            );
        }
        
        public static MultiPartIdentifier FromMutable(ScriptDom.MultiPartIdentifier fragment) {
            if (fragment is null) { return null; }
            return new MultiPartIdentifier(
                identifiers: fragment.Identifiers.SelectList(c => (Identifier)FromMutable(c))
            );
        }
        
        public static MultiPartIdentifierCallTarget FromMutable(ScriptDom.MultiPartIdentifierCallTarget fragment) {
            if (fragment is null) { return null; }
            return new MultiPartIdentifierCallTarget(
                multiPartIdentifier: (MultiPartIdentifier)FromMutable(fragment.MultiPartIdentifier)
            );
        }
        
        public static NamedTableReference FromMutable(ScriptDom.NamedTableReference fragment) {
            if (fragment is null) { return null; }
            return new NamedTableReference(
                schemaObject: (SchemaObjectName)FromMutable(fragment.SchemaObject),
                tableHints: fragment.TableHints.SelectList(c => (TableHint)FromMutable(c)),
                tableSampleClause: (TableSampleClause)FromMutable(fragment.TableSampleClause),
                temporalClause: (TemporalClause)FromMutable(fragment.TemporalClause),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static NameFileDeclarationOption FromMutable(ScriptDom.NameFileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            return new NameFileDeclarationOption(
                logicalFileName: (IdentifierOrValueExpression)FromMutable(fragment.LogicalFileName),
                isNewName: fragment.IsNewName,
                optionKind: fragment.OptionKind
            );
        }
        
        public static NextValueForExpression FromMutable(ScriptDom.NextValueForExpression fragment) {
            if (fragment is null) { return null; }
            return new NextValueForExpression(
                sequenceName: (SchemaObjectName)FromMutable(fragment.SequenceName),
                overClause: (OverClause)FromMutable(fragment.OverClause),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static NullableConstraintDefinition FromMutable(ScriptDom.NullableConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            return new NullableConstraintDefinition(
                nullable: fragment.Nullable,
                constraintIdentifier: (Identifier)FromMutable(fragment.ConstraintIdentifier)
            );
        }
        
        public static NullIfExpression FromMutable(ScriptDom.NullIfExpression fragment) {
            if (fragment is null) { return null; }
            return new NullIfExpression(
                firstExpression: (ScalarExpression)FromMutable(fragment.FirstExpression),
                secondExpression: (ScalarExpression)FromMutable(fragment.SecondExpression),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static NullLiteral FromMutable(ScriptDom.NullLiteral fragment) {
            if (fragment is null) { return null; }
            return new NullLiteral(
                @value: fragment.Value,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static NumericLiteral FromMutable(ScriptDom.NumericLiteral fragment) {
            if (fragment is null) { return null; }
            return new NumericLiteral(
                @value: fragment.Value,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static OdbcConvertSpecification FromMutable(ScriptDom.OdbcConvertSpecification fragment) {
            if (fragment is null) { return null; }
            return new OdbcConvertSpecification(
                identifier: (Identifier)FromMutable(fragment.Identifier)
            );
        }
        
        public static OdbcFunctionCall FromMutable(ScriptDom.OdbcFunctionCall fragment) {
            if (fragment is null) { return null; }
            return new OdbcFunctionCall(
                name: (Identifier)FromMutable(fragment.Name),
                parametersUsed: fragment.ParametersUsed,
                parameters: fragment.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static OdbcLiteral FromMutable(ScriptDom.OdbcLiteral fragment) {
            if (fragment is null) { return null; }
            return new OdbcLiteral(
                odbcLiteralType: fragment.OdbcLiteralType,
                isNational: fragment.IsNational,
                @value: fragment.Value,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static OdbcQualifiedJoinTableReference FromMutable(ScriptDom.OdbcQualifiedJoinTableReference fragment) {
            if (fragment is null) { return null; }
            return new OdbcQualifiedJoinTableReference(
                tableReference: (TableReference)FromMutable(fragment.TableReference)
            );
        }
        
        public static OffsetClause FromMutable(ScriptDom.OffsetClause fragment) {
            if (fragment is null) { return null; }
            return new OffsetClause(
                offsetExpression: (ScalarExpression)FromMutable(fragment.OffsetExpression),
                fetchExpression: (ScalarExpression)FromMutable(fragment.FetchExpression)
            );
        }
        
        public static OnFailureAuditOption FromMutable(ScriptDom.OnFailureAuditOption fragment) {
            if (fragment is null) { return null; }
            return new OnFailureAuditOption(
                onFailureAction: fragment.OnFailureAction,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnlineIndexLowPriorityLockWaitOption FromMutable(ScriptDom.OnlineIndexLowPriorityLockWaitOption fragment) {
            if (fragment is null) { return null; }
            return new OnlineIndexLowPriorityLockWaitOption(
                options: fragment.Options.SelectList(c => (LowPriorityLockWaitOption)FromMutable(c))
            );
        }
        
        public static OnlineIndexOption FromMutable(ScriptDom.OnlineIndexOption fragment) {
            if (fragment is null) { return null; }
            return new OnlineIndexOption(
                lowPriorityLockWaitOption: (OnlineIndexLowPriorityLockWaitOption)FromMutable(fragment.LowPriorityLockWaitOption),
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffAssemblyOption FromMutable(ScriptDom.OnOffAssemblyOption fragment) {
            if (fragment is null) { return null; }
            return new OnOffAssemblyOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffAtomicBlockOption FromMutable(ScriptDom.OnOffAtomicBlockOption fragment) {
            if (fragment is null) { return null; }
            return new OnOffAtomicBlockOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffAuditTargetOption FromMutable(ScriptDom.OnOffAuditTargetOption fragment) {
            if (fragment is null) { return null; }
            return new OnOffAuditTargetOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffDatabaseOption FromMutable(ScriptDom.OnOffDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new OnOffDatabaseOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffDialogOption FromMutable(ScriptDom.OnOffDialogOption fragment) {
            if (fragment is null) { return null; }
            return new OnOffDialogOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffFullTextCatalogOption FromMutable(ScriptDom.OnOffFullTextCatalogOption fragment) {
            if (fragment is null) { return null; }
            return new OnOffFullTextCatalogOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffOptionValue FromMutable(ScriptDom.OnOffOptionValue fragment) {
            if (fragment is null) { return null; }
            return new OnOffOptionValue(
                optionState: fragment.OptionState
            );
        }
        
        public static OnOffPrimaryConfigurationOption FromMutable(ScriptDom.OnOffPrimaryConfigurationOption fragment) {
            if (fragment is null) { return null; }
            return new OnOffPrimaryConfigurationOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind,
                genericOptionKind: (Identifier)FromMutable(fragment.GenericOptionKind)
            );
        }
        
        public static OnOffPrincipalOption FromMutable(ScriptDom.OnOffPrincipalOption fragment) {
            if (fragment is null) { return null; }
            return new OnOffPrincipalOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffRemoteServiceBindingOption FromMutable(ScriptDom.OnOffRemoteServiceBindingOption fragment) {
            if (fragment is null) { return null; }
            return new OnOffRemoteServiceBindingOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffSessionOption FromMutable(ScriptDom.OnOffSessionOption fragment) {
            if (fragment is null) { return null; }
            return new OnOffSessionOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OnOffStatisticsOption FromMutable(ScriptDom.OnOffStatisticsOption fragment) {
            if (fragment is null) { return null; }
            return new OnOffStatisticsOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OpenCursorStatement FromMutable(ScriptDom.OpenCursorStatement fragment) {
            if (fragment is null) { return null; }
            return new OpenCursorStatement(
                cursor: (CursorId)FromMutable(fragment.Cursor)
            );
        }
        
        public static OpenJsonTableReference FromMutable(ScriptDom.OpenJsonTableReference fragment) {
            if (fragment is null) { return null; }
            return new OpenJsonTableReference(
                variable: (ScalarExpression)FromMutable(fragment.Variable),
                rowPattern: (ScalarExpression)FromMutable(fragment.RowPattern),
                schemaDeclarationItems: fragment.SchemaDeclarationItems.SelectList(c => (SchemaDeclarationItemOpenjson)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static OpenMasterKeyStatement FromMutable(ScriptDom.OpenMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new OpenMasterKeyStatement(
                password: (Literal)FromMutable(fragment.Password)
            );
        }
        
        public static OpenQueryTableReference FromMutable(ScriptDom.OpenQueryTableReference fragment) {
            if (fragment is null) { return null; }
            return new OpenQueryTableReference(
                linkedServer: (Identifier)FromMutable(fragment.LinkedServer),
                query: (StringLiteral)FromMutable(fragment.Query),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static OpenRowsetColumnDefinition FromMutable(ScriptDom.OpenRowsetColumnDefinition fragment) {
            if (fragment is null) { return null; }
            return new OpenRowsetColumnDefinition(
                columnOrdinal: (IntegerLiteral)FromMutable(fragment.ColumnOrdinal),
                jsonPath: (StringLiteral)FromMutable(fragment.JsonPath),
                columnIdentifier: (Identifier)FromMutable(fragment.ColumnIdentifier),
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static OpenRowsetCosmos FromMutable(ScriptDom.OpenRowsetCosmos fragment) {
            if (fragment is null) { return null; }
            return new OpenRowsetCosmos(
                options: fragment.Options.SelectList(c => (OpenRowsetCosmosOption)FromMutable(c)),
                withColumns: fragment.WithColumns.SelectList(c => (OpenRowsetColumnDefinition)FromMutable(c)),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static OpenRowsetCosmosOption FromMutable(ScriptDom.OpenRowsetCosmosOption fragment) {
            if (fragment is null) { return null; }
            return new OpenRowsetCosmosOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static OpenRowsetTableReference FromMutable(ScriptDom.OpenRowsetTableReference fragment) {
            if (fragment is null) { return null; }
            return new OpenRowsetTableReference(
                providerName: (StringLiteral)FromMutable(fragment.ProviderName),
                dataSource: (StringLiteral)FromMutable(fragment.DataSource),
                userId: (StringLiteral)FromMutable(fragment.UserId),
                password: (StringLiteral)FromMutable(fragment.Password),
                providerString: (StringLiteral)FromMutable(fragment.ProviderString),
                query: (StringLiteral)FromMutable(fragment.Query),
                @object: (SchemaObjectName)FromMutable(fragment.Object),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static OpenSymmetricKeyStatement FromMutable(ScriptDom.OpenSymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new OpenSymmetricKeyStatement(
                name: (Identifier)FromMutable(fragment.Name),
                decryptionMechanism: (CryptoMechanism)FromMutable(fragment.DecryptionMechanism)
            );
        }
        
        public static OpenXmlTableReference FromMutable(ScriptDom.OpenXmlTableReference fragment) {
            if (fragment is null) { return null; }
            return new OpenXmlTableReference(
                variable: (VariableReference)FromMutable(fragment.Variable),
                rowPattern: (ValueExpression)FromMutable(fragment.RowPattern),
                flags: (ValueExpression)FromMutable(fragment.Flags),
                schemaDeclarationItems: fragment.SchemaDeclarationItems.SelectList(c => (SchemaDeclarationItem)FromMutable(c)),
                tableName: (SchemaObjectName)FromMutable(fragment.TableName),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static OperatorAuditOption FromMutable(ScriptDom.OperatorAuditOption fragment) {
            if (fragment is null) { return null; }
            return new OperatorAuditOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OptimizeForOptimizerHint FromMutable(ScriptDom.OptimizeForOptimizerHint fragment) {
            if (fragment is null) { return null; }
            return new OptimizeForOptimizerHint(
                pairs: fragment.Pairs.SelectList(c => (VariableValuePair)FromMutable(c)),
                isForUnknown: fragment.IsForUnknown,
                hintKind: fragment.HintKind
            );
        }
        
        public static OptimizerHint FromMutable(ScriptDom.OptimizerHint fragment) {
            if (fragment is null) { return null; }
            return new OptimizerHint(
                hintKind: fragment.HintKind
            );
        }
        
        public static OrderBulkInsertOption FromMutable(ScriptDom.OrderBulkInsertOption fragment) {
            if (fragment is null) { return null; }
            return new OrderBulkInsertOption(
                columns: fragment.Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                isUnique: fragment.IsUnique,
                optionKind: fragment.OptionKind
            );
        }
        
        public static OrderByClause FromMutable(ScriptDom.OrderByClause fragment) {
            if (fragment is null) { return null; }
            return new OrderByClause(
                orderByElements: fragment.OrderByElements.SelectList(c => (ExpressionWithSortOrder)FromMutable(c))
            );
        }
        
        public static OrderIndexOption FromMutable(ScriptDom.OrderIndexOption fragment) {
            if (fragment is null) { return null; }
            return new OrderIndexOption(
                columns: fragment.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                optionKind: fragment.OptionKind
            );
        }
        
        public static OutputClause FromMutable(ScriptDom.OutputClause fragment) {
            if (fragment is null) { return null; }
            return new OutputClause(
                selectColumns: fragment.SelectColumns.SelectList(c => (SelectElement)FromMutable(c))
            );
        }
        
        public static OutputIntoClause FromMutable(ScriptDom.OutputIntoClause fragment) {
            if (fragment is null) { return null; }
            return new OutputIntoClause(
                selectColumns: fragment.SelectColumns.SelectList(c => (SelectElement)FromMutable(c)),
                intoTable: (TableReference)FromMutable(fragment.IntoTable),
                intoTableColumns: fragment.IntoTableColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
            );
        }
        
        public static OverClause FromMutable(ScriptDom.OverClause fragment) {
            if (fragment is null) { return null; }
            return new OverClause(
                windowName: (Identifier)FromMutable(fragment.WindowName),
                partitions: fragment.Partitions.SelectList(c => (ScalarExpression)FromMutable(c)),
                orderByClause: (OrderByClause)FromMutable(fragment.OrderByClause),
                windowFrameClause: (WindowFrameClause)FromMutable(fragment.WindowFrameClause)
            );
        }
        
        public static PageVerifyDatabaseOption FromMutable(ScriptDom.PageVerifyDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new PageVerifyDatabaseOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static ParameterizationDatabaseOption FromMutable(ScriptDom.ParameterizationDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new ParameterizationDatabaseOption(
                isSimple: fragment.IsSimple,
                optionKind: fragment.OptionKind
            );
        }
        
        public static ParameterlessCall FromMutable(ScriptDom.ParameterlessCall fragment) {
            if (fragment is null) { return null; }
            return new ParameterlessCall(
                parameterlessCallType: fragment.ParameterlessCallType,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static ParenthesisExpression FromMutable(ScriptDom.ParenthesisExpression fragment) {
            if (fragment is null) { return null; }
            return new ParenthesisExpression(
                expression: (ScalarExpression)FromMutable(fragment.Expression),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static ParseCall FromMutable(ScriptDom.ParseCall fragment) {
            if (fragment is null) { return null; }
            return new ParseCall(
                stringValue: (ScalarExpression)FromMutable(fragment.StringValue),
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                culture: (ScalarExpression)FromMutable(fragment.Culture),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static PartitionFunctionCall FromMutable(ScriptDom.PartitionFunctionCall fragment) {
            if (fragment is null) { return null; }
            return new PartitionFunctionCall(
                databaseName: (Identifier)FromMutable(fragment.DatabaseName),
                functionName: (Identifier)FromMutable(fragment.FunctionName),
                parameters: fragment.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static PartitionParameterType FromMutable(ScriptDom.PartitionParameterType fragment) {
            if (fragment is null) { return null; }
            return new PartitionParameterType(
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static PartitionSpecifier FromMutable(ScriptDom.PartitionSpecifier fragment) {
            if (fragment is null) { return null; }
            return new PartitionSpecifier(
                number: (ScalarExpression)FromMutable(fragment.Number),
                all: fragment.All
            );
        }
        
        public static PartnerDatabaseOption FromMutable(ScriptDom.PartnerDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new PartnerDatabaseOption(
                partnerServer: (Literal)FromMutable(fragment.PartnerServer),
                partnerOption: fragment.PartnerOption,
                timeout: (Literal)FromMutable(fragment.Timeout),
                optionKind: fragment.OptionKind
            );
        }
        
        public static PasswordAlterPrincipalOption FromMutable(ScriptDom.PasswordAlterPrincipalOption fragment) {
            if (fragment is null) { return null; }
            return new PasswordAlterPrincipalOption(
                password: (Literal)FromMutable(fragment.Password),
                oldPassword: (Literal)FromMutable(fragment.OldPassword),
                mustChange: fragment.MustChange,
                unlock: fragment.Unlock,
                hashed: fragment.Hashed,
                optionKind: fragment.OptionKind
            );
        }
        
        public static PasswordCreateLoginSource FromMutable(ScriptDom.PasswordCreateLoginSource fragment) {
            if (fragment is null) { return null; }
            return new PasswordCreateLoginSource(
                password: (Literal)FromMutable(fragment.Password),
                hashed: fragment.Hashed,
                mustChange: fragment.MustChange,
                options: fragment.Options.SelectList(c => (PrincipalOption)FromMutable(c))
            );
        }
        
        public static Permission FromMutable(ScriptDom.Permission fragment) {
            if (fragment is null) { return null; }
            return new Permission(
                identifiers: fragment.Identifiers.SelectList(c => (Identifier)FromMutable(c)),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c))
            );
        }
        
        public static PermissionSetAssemblyOption FromMutable(ScriptDom.PermissionSetAssemblyOption fragment) {
            if (fragment is null) { return null; }
            return new PermissionSetAssemblyOption(
                permissionSetOption: fragment.PermissionSetOption,
                optionKind: fragment.OptionKind
            );
        }
        
        public static PivotedTableReference FromMutable(ScriptDom.PivotedTableReference fragment) {
            if (fragment is null) { return null; }
            return new PivotedTableReference(
                tableReference: (TableReference)FromMutable(fragment.TableReference),
                inColumns: fragment.InColumns.SelectList(c => (Identifier)FromMutable(c)),
                pivotColumn: (ColumnReferenceExpression)FromMutable(fragment.PivotColumn),
                valueColumns: fragment.ValueColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                aggregateFunctionIdentifier: (MultiPartIdentifier)FromMutable(fragment.AggregateFunctionIdentifier),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static PortsEndpointProtocolOption FromMutable(ScriptDom.PortsEndpointProtocolOption fragment) {
            if (fragment is null) { return null; }
            return new PortsEndpointProtocolOption(
                portTypes: fragment.PortTypes,
                kind: fragment.Kind
            );
        }
        
        public static PredicateSetStatement FromMutable(ScriptDom.PredicateSetStatement fragment) {
            if (fragment is null) { return null; }
            return new PredicateSetStatement(
                options: fragment.Options,
                isOn: fragment.IsOn
            );
        }
        
        public static PredictTableReference FromMutable(ScriptDom.PredictTableReference fragment) {
            if (fragment is null) { return null; }
            return new PredictTableReference(
                modelVariable: (ScalarExpression)FromMutable(fragment.ModelVariable),
                modelSubquery: (ScalarSubquery)FromMutable(fragment.ModelSubquery),
                dataSource: (TableReferenceWithAlias)FromMutable(fragment.DataSource),
                runTime: (Identifier)FromMutable(fragment.RunTime),
                schemaDeclarationItems: fragment.SchemaDeclarationItems.SelectList(c => (SchemaDeclarationItem)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static PrimaryRoleReplicaOption FromMutable(ScriptDom.PrimaryRoleReplicaOption fragment) {
            if (fragment is null) { return null; }
            return new PrimaryRoleReplicaOption(
                allowConnections: fragment.AllowConnections,
                optionKind: fragment.OptionKind
            );
        }
        
        public static PrincipalOption FromMutable(ScriptDom.PrincipalOption fragment) {
            if (fragment is null) { return null; }
            return new PrincipalOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static PrintStatement FromMutable(ScriptDom.PrintStatement fragment) {
            if (fragment is null) { return null; }
            return new PrintStatement(
                expression: (ScalarExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static Privilege80 FromMutable(ScriptDom.Privilege80 fragment) {
            if (fragment is null) { return null; }
            return new Privilege80(
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                privilegeType80: fragment.PrivilegeType80
            );
        }
        
        public static PrivilegeSecurityElement80 FromMutable(ScriptDom.PrivilegeSecurityElement80 fragment) {
            if (fragment is null) { return null; }
            return new PrivilegeSecurityElement80(
                privileges: fragment.Privileges.SelectList(c => (Privilege80)FromMutable(c)),
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c))
            );
        }
        
        public static ProcedureOption FromMutable(ScriptDom.ProcedureOption fragment) {
            if (fragment is null) { return null; }
            return new ProcedureOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static ProcedureParameter FromMutable(ScriptDom.ProcedureParameter fragment) {
            if (fragment is null) { return null; }
            return new ProcedureParameter(
                isVarying: fragment.IsVarying,
                modifier: fragment.Modifier,
                variableName: (Identifier)FromMutable(fragment.VariableName),
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                nullable: (NullableConstraintDefinition)FromMutable(fragment.Nullable),
                @value: (ScalarExpression)FromMutable(fragment.Value)
            );
        }
        
        public static ProcedureReference FromMutable(ScriptDom.ProcedureReference fragment) {
            if (fragment is null) { return null; }
            return new ProcedureReference(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                number: (Literal)FromMutable(fragment.Number)
            );
        }
        
        public static ProcedureReferenceName FromMutable(ScriptDom.ProcedureReferenceName fragment) {
            if (fragment is null) { return null; }
            return new ProcedureReferenceName(
                procedureReference: (ProcedureReference)FromMutable(fragment.ProcedureReference),
                procedureVariable: (VariableReference)FromMutable(fragment.ProcedureVariable)
            );
        }
        
        public static ProcessAffinityRange FromMutable(ScriptDom.ProcessAffinityRange fragment) {
            if (fragment is null) { return null; }
            return new ProcessAffinityRange(
                from: (Literal)FromMutable(fragment.From),
                to: (Literal)FromMutable(fragment.To)
            );
        }
        
        public static ProviderEncryptionSource FromMutable(ScriptDom.ProviderEncryptionSource fragment) {
            if (fragment is null) { return null; }
            return new ProviderEncryptionSource(
                name: (Identifier)FromMutable(fragment.Name),
                keyOptions: fragment.KeyOptions.SelectList(c => (KeyOption)FromMutable(c))
            );
        }
        
        public static ProviderKeyNameKeyOption FromMutable(ScriptDom.ProviderKeyNameKeyOption fragment) {
            if (fragment is null) { return null; }
            return new ProviderKeyNameKeyOption(
                keyName: (Literal)FromMutable(fragment.KeyName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QualifiedJoin FromMutable(ScriptDom.QualifiedJoin fragment) {
            if (fragment is null) { return null; }
            return new QualifiedJoin(
                searchCondition: (BooleanExpression)FromMutable(fragment.SearchCondition),
                qualifiedJoinType: fragment.QualifiedJoinType,
                joinHint: fragment.JoinHint,
                firstTableReference: (TableReference)FromMutable(fragment.FirstTableReference),
                secondTableReference: (TableReference)FromMutable(fragment.SecondTableReference)
            );
        }
        
        public static QueryDerivedTable FromMutable(ScriptDom.QueryDerivedTable fragment) {
            if (fragment is null) { return null; }
            return new QueryDerivedTable(
                queryExpression: (QueryExpression)FromMutable(fragment.QueryExpression),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static QueryParenthesisExpression FromMutable(ScriptDom.QueryParenthesisExpression fragment) {
            if (fragment is null) { return null; }
            return new QueryParenthesisExpression(
                queryExpression: (QueryExpression)FromMutable(fragment.QueryExpression),
                orderByClause: (OrderByClause)FromMutable(fragment.OrderByClause),
                offsetClause: (OffsetClause)FromMutable(fragment.OffsetClause),
                forClause: (ForClause)FromMutable(fragment.ForClause)
            );
        }
        
        public static QuerySpecification FromMutable(ScriptDom.QuerySpecification fragment) {
            if (fragment is null) { return null; }
            return new QuerySpecification(
                uniqueRowFilter: fragment.UniqueRowFilter,
                topRowFilter: (TopRowFilter)FromMutable(fragment.TopRowFilter),
                selectElements: fragment.SelectElements.SelectList(c => (SelectElement)FromMutable(c)),
                fromClause: (FromClause)FromMutable(fragment.FromClause),
                whereClause: (WhereClause)FromMutable(fragment.WhereClause),
                groupByClause: (GroupByClause)FromMutable(fragment.GroupByClause),
                havingClause: (HavingClause)FromMutable(fragment.HavingClause),
                windowClause: (WindowClause)FromMutable(fragment.WindowClause),
                orderByClause: (OrderByClause)FromMutable(fragment.OrderByClause),
                offsetClause: (OffsetClause)FromMutable(fragment.OffsetClause),
                forClause: (ForClause)FromMutable(fragment.ForClause)
            );
        }
        
        public static QueryStoreCapturePolicyOption FromMutable(ScriptDom.QueryStoreCapturePolicyOption fragment) {
            if (fragment is null) { return null; }
            return new QueryStoreCapturePolicyOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreDatabaseOption FromMutable(ScriptDom.QueryStoreDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new QueryStoreDatabaseOption(
                clear: fragment.Clear,
                clearAll: fragment.ClearAll,
                optionState: fragment.OptionState,
                options: fragment.Options.SelectList(c => (QueryStoreOption)FromMutable(c)),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreDataFlushIntervalOption FromMutable(ScriptDom.QueryStoreDataFlushIntervalOption fragment) {
            if (fragment is null) { return null; }
            return new QueryStoreDataFlushIntervalOption(
                flushInterval: (Literal)FromMutable(fragment.FlushInterval),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreDesiredStateOption FromMutable(ScriptDom.QueryStoreDesiredStateOption fragment) {
            if (fragment is null) { return null; }
            return new QueryStoreDesiredStateOption(
                @value: fragment.Value,
                operationModeSpecified: fragment.OperationModeSpecified,
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreIntervalLengthOption FromMutable(ScriptDom.QueryStoreIntervalLengthOption fragment) {
            if (fragment is null) { return null; }
            return new QueryStoreIntervalLengthOption(
                statsIntervalLength: (Literal)FromMutable(fragment.StatsIntervalLength),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreMaxPlansPerQueryOption FromMutable(ScriptDom.QueryStoreMaxPlansPerQueryOption fragment) {
            if (fragment is null) { return null; }
            return new QueryStoreMaxPlansPerQueryOption(
                maxPlansPerQuery: (Literal)FromMutable(fragment.MaxPlansPerQuery),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreMaxStorageSizeOption FromMutable(ScriptDom.QueryStoreMaxStorageSizeOption fragment) {
            if (fragment is null) { return null; }
            return new QueryStoreMaxStorageSizeOption(
                maxQdsSize: (Literal)FromMutable(fragment.MaxQdsSize),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreSizeCleanupPolicyOption FromMutable(ScriptDom.QueryStoreSizeCleanupPolicyOption fragment) {
            if (fragment is null) { return null; }
            return new QueryStoreSizeCleanupPolicyOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueryStoreTimeCleanupPolicyOption FromMutable(ScriptDom.QueryStoreTimeCleanupPolicyOption fragment) {
            if (fragment is null) { return null; }
            return new QueryStoreTimeCleanupPolicyOption(
                staleQueryThreshold: (Literal)FromMutable(fragment.StaleQueryThreshold),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueueDelayAuditOption FromMutable(ScriptDom.QueueDelayAuditOption fragment) {
            if (fragment is null) { return null; }
            return new QueueDelayAuditOption(
                delay: (Literal)FromMutable(fragment.Delay),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueueExecuteAsOption FromMutable(ScriptDom.QueueExecuteAsOption fragment) {
            if (fragment is null) { return null; }
            return new QueueExecuteAsOption(
                optionValue: (ExecuteAsClause)FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueueOption FromMutable(ScriptDom.QueueOption fragment) {
            if (fragment is null) { return null; }
            return new QueueOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueueProcedureOption FromMutable(ScriptDom.QueueProcedureOption fragment) {
            if (fragment is null) { return null; }
            return new QueueProcedureOption(
                optionValue: (SchemaObjectName)FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueueStateOption FromMutable(ScriptDom.QueueStateOption fragment) {
            if (fragment is null) { return null; }
            return new QueueStateOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static QueueValueOption FromMutable(ScriptDom.QueueValueOption fragment) {
            if (fragment is null) { return null; }
            return new QueueValueOption(
                optionValue: (ValueExpression)FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind
            );
        }
        
        public static RaiseErrorLegacyStatement FromMutable(ScriptDom.RaiseErrorLegacyStatement fragment) {
            if (fragment is null) { return null; }
            return new RaiseErrorLegacyStatement(
                firstParameter: (ScalarExpression)FromMutable(fragment.FirstParameter),
                secondParameter: (ValueExpression)FromMutable(fragment.SecondParameter)
            );
        }
        
        public static RaiseErrorStatement FromMutable(ScriptDom.RaiseErrorStatement fragment) {
            if (fragment is null) { return null; }
            return new RaiseErrorStatement(
                firstParameter: (ScalarExpression)FromMutable(fragment.FirstParameter),
                secondParameter: (ScalarExpression)FromMutable(fragment.SecondParameter),
                thirdParameter: (ScalarExpression)FromMutable(fragment.ThirdParameter),
                optionalParameters: fragment.OptionalParameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                raiseErrorOptions: fragment.RaiseErrorOptions
            );
        }
        
        public static ReadOnlyForClause FromMutable(ScriptDom.ReadOnlyForClause fragment) {
            if (fragment is null) { return null; }
            return new ReadOnlyForClause(
                
            );
        }
        
        public static ReadTextStatement FromMutable(ScriptDom.ReadTextStatement fragment) {
            if (fragment is null) { return null; }
            return new ReadTextStatement(
                column: (ColumnReferenceExpression)FromMutable(fragment.Column),
                textPointer: (ValueExpression)FromMutable(fragment.TextPointer),
                offset: (ValueExpression)FromMutable(fragment.Offset),
                size: (ValueExpression)FromMutable(fragment.Size),
                holdLock: fragment.HoldLock
            );
        }
        
        public static RealLiteral FromMutable(ScriptDom.RealLiteral fragment) {
            if (fragment is null) { return null; }
            return new RealLiteral(
                @value: fragment.Value,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static ReceiveStatement FromMutable(ScriptDom.ReceiveStatement fragment) {
            if (fragment is null) { return null; }
            return new ReceiveStatement(
                top: (ScalarExpression)FromMutable(fragment.Top),
                selectElements: fragment.SelectElements.SelectList(c => (SelectElement)FromMutable(c)),
                queue: (SchemaObjectName)FromMutable(fragment.Queue),
                into: (VariableTableReference)FromMutable(fragment.Into),
                where: (ValueExpression)FromMutable(fragment.Where),
                isConversationGroupIdWhere: fragment.IsConversationGroupIdWhere
            );
        }
        
        public static ReconfigureStatement FromMutable(ScriptDom.ReconfigureStatement fragment) {
            if (fragment is null) { return null; }
            return new ReconfigureStatement(
                withOverride: fragment.WithOverride
            );
        }
        
        public static RecoveryDatabaseOption FromMutable(ScriptDom.RecoveryDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new RecoveryDatabaseOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static RemoteDataArchiveAlterTableOption FromMutable(ScriptDom.RemoteDataArchiveAlterTableOption fragment) {
            if (fragment is null) { return null; }
            return new RemoteDataArchiveAlterTableOption(
                rdaTableOption: fragment.RdaTableOption,
                migrationState: fragment.MigrationState,
                isMigrationStateSpecified: fragment.IsMigrationStateSpecified,
                isFilterPredicateSpecified: fragment.IsFilterPredicateSpecified,
                filterPredicate: (FunctionCall)FromMutable(fragment.FilterPredicate),
                optionKind: fragment.OptionKind
            );
        }
        
        public static RemoteDataArchiveDatabaseOption FromMutable(ScriptDom.RemoteDataArchiveDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new RemoteDataArchiveDatabaseOption(
                optionState: fragment.OptionState,
                settings: fragment.Settings.SelectList(c => (RemoteDataArchiveDatabaseSetting)FromMutable(c)),
                optionKind: fragment.OptionKind
            );
        }
        
        public static RemoteDataArchiveDbCredentialSetting FromMutable(ScriptDom.RemoteDataArchiveDbCredentialSetting fragment) {
            if (fragment is null) { return null; }
            return new RemoteDataArchiveDbCredentialSetting(
                credential: (Identifier)FromMutable(fragment.Credential),
                settingKind: fragment.SettingKind
            );
        }
        
        public static RemoteDataArchiveDbFederatedServiceAccountSetting FromMutable(ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting fragment) {
            if (fragment is null) { return null; }
            return new RemoteDataArchiveDbFederatedServiceAccountSetting(
                isOn: fragment.IsOn,
                settingKind: fragment.SettingKind
            );
        }
        
        public static RemoteDataArchiveDbServerSetting FromMutable(ScriptDom.RemoteDataArchiveDbServerSetting fragment) {
            if (fragment is null) { return null; }
            return new RemoteDataArchiveDbServerSetting(
                server: (StringLiteral)FromMutable(fragment.Server),
                settingKind: fragment.SettingKind
            );
        }
        
        public static RemoteDataArchiveTableOption FromMutable(ScriptDom.RemoteDataArchiveTableOption fragment) {
            if (fragment is null) { return null; }
            return new RemoteDataArchiveTableOption(
                rdaTableOption: fragment.RdaTableOption,
                migrationState: fragment.MigrationState,
                optionKind: fragment.OptionKind
            );
        }
        
        public static RenameAlterRoleAction FromMutable(ScriptDom.RenameAlterRoleAction fragment) {
            if (fragment is null) { return null; }
            return new RenameAlterRoleAction(
                newName: (Identifier)FromMutable(fragment.NewName)
            );
        }
        
        public static RenameEntityStatement FromMutable(ScriptDom.RenameEntityStatement fragment) {
            if (fragment is null) { return null; }
            return new RenameEntityStatement(
                renameEntityType: fragment.RenameEntityType,
                separatorType: fragment.SeparatorType,
                oldName: (SchemaObjectName)FromMutable(fragment.OldName),
                newName: (Identifier)FromMutable(fragment.NewName)
            );
        }
        
        public static ResampleStatisticsOption FromMutable(ScriptDom.ResampleStatisticsOption fragment) {
            if (fragment is null) { return null; }
            return new ResampleStatisticsOption(
                partitions: fragment.Partitions.SelectList(c => (StatisticsPartitionRange)FromMutable(c)),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ResourcePoolAffinitySpecification FromMutable(ScriptDom.ResourcePoolAffinitySpecification fragment) {
            if (fragment is null) { return null; }
            return new ResourcePoolAffinitySpecification(
                affinityType: fragment.AffinityType,
                parameterValue: (Literal)FromMutable(fragment.ParameterValue),
                isAuto: fragment.IsAuto,
                poolAffinityRanges: fragment.PoolAffinityRanges.SelectList(c => (LiteralRange)FromMutable(c))
            );
        }
        
        public static ResourcePoolParameter FromMutable(ScriptDom.ResourcePoolParameter fragment) {
            if (fragment is null) { return null; }
            return new ResourcePoolParameter(
                parameterType: fragment.ParameterType,
                parameterValue: (Literal)FromMutable(fragment.ParameterValue),
                affinitySpecification: (ResourcePoolAffinitySpecification)FromMutable(fragment.AffinitySpecification)
            );
        }
        
        public static ResourcePoolStatement FromMutable(ScriptDom.ResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            return new ResourcePoolStatement(
                name: (Identifier)FromMutable(fragment.Name),
                resourcePoolParameters: fragment.ResourcePoolParameters.SelectList(c => (ResourcePoolParameter)FromMutable(c))
            );
        }
        
        public static RestoreMasterKeyStatement FromMutable(ScriptDom.RestoreMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new RestoreMasterKeyStatement(
                isForce: fragment.IsForce,
                encryptionPassword: (Literal)FromMutable(fragment.EncryptionPassword),
                file: (Literal)FromMutable(fragment.File),
                password: (Literal)FromMutable(fragment.Password)
            );
        }
        
        public static RestoreOption FromMutable(ScriptDom.RestoreOption fragment) {
            if (fragment is null) { return null; }
            return new RestoreOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static RestoreServiceMasterKeyStatement FromMutable(ScriptDom.RestoreServiceMasterKeyStatement fragment) {
            if (fragment is null) { return null; }
            return new RestoreServiceMasterKeyStatement(
                isForce: fragment.IsForce,
                file: (Literal)FromMutable(fragment.File),
                password: (Literal)FromMutable(fragment.Password)
            );
        }
        
        public static RestoreStatement FromMutable(ScriptDom.RestoreStatement fragment) {
            if (fragment is null) { return null; }
            return new RestoreStatement(
                databaseName: (IdentifierOrValueExpression)FromMutable(fragment.DatabaseName),
                devices: fragment.Devices.SelectList(c => (DeviceInfo)FromMutable(c)),
                files: fragment.Files.SelectList(c => (BackupRestoreFileInfo)FromMutable(c)),
                options: fragment.Options.SelectList(c => (RestoreOption)FromMutable(c)),
                kind: fragment.Kind
            );
        }
        
        public static ResultColumnDefinition FromMutable(ScriptDom.ResultColumnDefinition fragment) {
            if (fragment is null) { return null; }
            return new ResultColumnDefinition(
                columnDefinition: (ColumnDefinitionBase)FromMutable(fragment.ColumnDefinition),
                nullable: (NullableConstraintDefinition)FromMutable(fragment.Nullable)
            );
        }
        
        public static ResultSetDefinition FromMutable(ScriptDom.ResultSetDefinition fragment) {
            if (fragment is null) { return null; }
            return new ResultSetDefinition(
                resultSetType: fragment.ResultSetType
            );
        }
        
        public static ResultSetsExecuteOption FromMutable(ScriptDom.ResultSetsExecuteOption fragment) {
            if (fragment is null) { return null; }
            return new ResultSetsExecuteOption(
                resultSetsOptionKind: fragment.ResultSetsOptionKind,
                definitions: fragment.Definitions.SelectList(c => (ResultSetDefinition)FromMutable(c)),
                optionKind: fragment.OptionKind
            );
        }
        
        public static RetentionDaysAuditTargetOption FromMutable(ScriptDom.RetentionDaysAuditTargetOption fragment) {
            if (fragment is null) { return null; }
            return new RetentionDaysAuditTargetOption(
                days: (Literal)FromMutable(fragment.Days),
                optionKind: fragment.OptionKind
            );
        }
        
        public static RetentionPeriodDefinition FromMutable(ScriptDom.RetentionPeriodDefinition fragment) {
            if (fragment is null) { return null; }
            return new RetentionPeriodDefinition(
                duration: (IntegerLiteral)FromMutable(fragment.Duration),
                units: fragment.Units,
                isInfinity: fragment.IsInfinity
            );
        }
        
        public static ReturnStatement FromMutable(ScriptDom.ReturnStatement fragment) {
            if (fragment is null) { return null; }
            return new ReturnStatement(
                expression: (ScalarExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static RevertStatement FromMutable(ScriptDom.RevertStatement fragment) {
            if (fragment is null) { return null; }
            return new RevertStatement(
                cookie: (ScalarExpression)FromMutable(fragment.Cookie)
            );
        }
        
        public static RevokeStatement FromMutable(ScriptDom.RevokeStatement fragment) {
            if (fragment is null) { return null; }
            return new RevokeStatement(
                grantOptionFor: fragment.GrantOptionFor,
                cascadeOption: fragment.CascadeOption,
                permissions: fragment.Permissions.SelectList(c => (Permission)FromMutable(c)),
                securityTargetObject: (SecurityTargetObject)FromMutable(fragment.SecurityTargetObject),
                principals: fragment.Principals.SelectList(c => (SecurityPrincipal)FromMutable(c)),
                asClause: (Identifier)FromMutable(fragment.AsClause)
            );
        }
        
        public static RevokeStatement80 FromMutable(ScriptDom.RevokeStatement80 fragment) {
            if (fragment is null) { return null; }
            return new RevokeStatement80(
                grantOptionFor: fragment.GrantOptionFor,
                cascadeOption: fragment.CascadeOption,
                asClause: (Identifier)FromMutable(fragment.AsClause),
                securityElement80: (SecurityElement80)FromMutable(fragment.SecurityElement80),
                securityUserClause80: (SecurityUserClause80)FromMutable(fragment.SecurityUserClause80)
            );
        }
        
        public static RightFunctionCall FromMutable(ScriptDom.RightFunctionCall fragment) {
            if (fragment is null) { return null; }
            return new RightFunctionCall(
                parameters: fragment.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static RolePayloadOption FromMutable(ScriptDom.RolePayloadOption fragment) {
            if (fragment is null) { return null; }
            return new RolePayloadOption(
                role: fragment.Role,
                kind: fragment.Kind
            );
        }
        
        public static RollbackTransactionStatement FromMutable(ScriptDom.RollbackTransactionStatement fragment) {
            if (fragment is null) { return null; }
            return new RollbackTransactionStatement(
                name: (IdentifierOrValueExpression)FromMutable(fragment.Name)
            );
        }
        
        public static RollupGroupingSpecification FromMutable(ScriptDom.RollupGroupingSpecification fragment) {
            if (fragment is null) { return null; }
            return new RollupGroupingSpecification(
                arguments: fragment.Arguments.SelectList(c => (GroupingSpecification)FromMutable(c))
            );
        }
        
        public static RouteOption FromMutable(ScriptDom.RouteOption fragment) {
            if (fragment is null) { return null; }
            return new RouteOption(
                optionKind: fragment.OptionKind,
                literal: (Literal)FromMutable(fragment.Literal)
            );
        }
        
        public static RowValue FromMutable(ScriptDom.RowValue fragment) {
            if (fragment is null) { return null; }
            return new RowValue(
                columnValues: fragment.ColumnValues.SelectList(c => (ScalarExpression)FromMutable(c))
            );
        }
        
        public static SaveTransactionStatement FromMutable(ScriptDom.SaveTransactionStatement fragment) {
            if (fragment is null) { return null; }
            return new SaveTransactionStatement(
                name: (IdentifierOrValueExpression)FromMutable(fragment.Name)
            );
        }
        
        public static ScalarExpressionDialogOption FromMutable(ScriptDom.ScalarExpressionDialogOption fragment) {
            if (fragment is null) { return null; }
            return new ScalarExpressionDialogOption(
                @value: (ScalarExpression)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ScalarExpressionRestoreOption FromMutable(ScriptDom.ScalarExpressionRestoreOption fragment) {
            if (fragment is null) { return null; }
            return new ScalarExpressionRestoreOption(
                @value: (ScalarExpression)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ScalarExpressionSequenceOption FromMutable(ScriptDom.ScalarExpressionSequenceOption fragment) {
            if (fragment is null) { return null; }
            return new ScalarExpressionSequenceOption(
                optionValue: (ScalarExpression)FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind,
                noValue: fragment.NoValue
            );
        }
        
        public static ScalarExpressionSnippet FromMutable(ScriptDom.ScalarExpressionSnippet fragment) {
            if (fragment is null) { return null; }
            return new ScalarExpressionSnippet(
                script: fragment.Script
            );
        }
        
        public static ScalarFunctionReturnType FromMutable(ScriptDom.ScalarFunctionReturnType fragment) {
            if (fragment is null) { return null; }
            return new ScalarFunctionReturnType(
                dataType: (DataTypeReference)FromMutable(fragment.DataType)
            );
        }
        
        public static ScalarSubquery FromMutable(ScriptDom.ScalarSubquery fragment) {
            if (fragment is null) { return null; }
            return new ScalarSubquery(
                queryExpression: (QueryExpression)FromMutable(fragment.QueryExpression),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static SchemaDeclarationItem FromMutable(ScriptDom.SchemaDeclarationItem fragment) {
            if (fragment is null) { return null; }
            return new SchemaDeclarationItem(
                columnDefinition: (ColumnDefinitionBase)FromMutable(fragment.ColumnDefinition),
                mapping: (ValueExpression)FromMutable(fragment.Mapping)
            );
        }
        
        public static SchemaDeclarationItemOpenjson FromMutable(ScriptDom.SchemaDeclarationItemOpenjson fragment) {
            if (fragment is null) { return null; }
            return new SchemaDeclarationItemOpenjson(
                asJson: fragment.AsJson,
                columnDefinition: (ColumnDefinitionBase)FromMutable(fragment.ColumnDefinition),
                mapping: (ValueExpression)FromMutable(fragment.Mapping)
            );
        }
        
        public static SchemaObjectFunctionTableReference FromMutable(ScriptDom.SchemaObjectFunctionTableReference fragment) {
            if (fragment is null) { return null; }
            return new SchemaObjectFunctionTableReference(
                schemaObject: (SchemaObjectName)FromMutable(fragment.SchemaObject),
                parameters: fragment.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static SchemaObjectName FromMutable(ScriptDom.SchemaObjectName fragment) {
            if (fragment is null) { return null; }
            return new SchemaObjectName(
                identifiers: fragment.Identifiers.SelectList(c => (Identifier)FromMutable(c))
            );
        }
        
        public static SchemaObjectNameOrValueExpression FromMutable(ScriptDom.SchemaObjectNameOrValueExpression fragment) {
            if (fragment is null) { return null; }
            return new SchemaObjectNameOrValueExpression(
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName),
                valueExpression: (ValueExpression)FromMutable(fragment.ValueExpression)
            );
        }
        
        public static SchemaObjectNameSnippet FromMutable(ScriptDom.SchemaObjectNameSnippet fragment) {
            if (fragment is null) { return null; }
            return new SchemaObjectNameSnippet(
                script: fragment.Script,
                identifiers: fragment.Identifiers.SelectList(c => (Identifier)FromMutable(c))
            );
        }
        
        public static SchemaObjectResultSetDefinition FromMutable(ScriptDom.SchemaObjectResultSetDefinition fragment) {
            if (fragment is null) { return null; }
            return new SchemaObjectResultSetDefinition(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                resultSetType: fragment.ResultSetType
            );
        }
        
        public static SchemaPayloadOption FromMutable(ScriptDom.SchemaPayloadOption fragment) {
            if (fragment is null) { return null; }
            return new SchemaPayloadOption(
                isStandard: fragment.IsStandard,
                kind: fragment.Kind
            );
        }
        
        public static SearchedCaseExpression FromMutable(ScriptDom.SearchedCaseExpression fragment) {
            if (fragment is null) { return null; }
            return new SearchedCaseExpression(
                whenClauses: fragment.WhenClauses.SelectList(c => (SearchedWhenClause)FromMutable(c)),
                elseExpression: (ScalarExpression)FromMutable(fragment.ElseExpression),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static SearchedWhenClause FromMutable(ScriptDom.SearchedWhenClause fragment) {
            if (fragment is null) { return null; }
            return new SearchedWhenClause(
                whenExpression: (BooleanExpression)FromMutable(fragment.WhenExpression),
                thenExpression: (ScalarExpression)FromMutable(fragment.ThenExpression)
            );
        }
        
        public static SearchPropertyListFullTextIndexOption FromMutable(ScriptDom.SearchPropertyListFullTextIndexOption fragment) {
            if (fragment is null) { return null; }
            return new SearchPropertyListFullTextIndexOption(
                isOff: fragment.IsOff,
                propertyListName: (Identifier)FromMutable(fragment.PropertyListName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static SecondaryRoleReplicaOption FromMutable(ScriptDom.SecondaryRoleReplicaOption fragment) {
            if (fragment is null) { return null; }
            return new SecondaryRoleReplicaOption(
                allowConnections: fragment.AllowConnections,
                optionKind: fragment.OptionKind
            );
        }
        
        public static SecurityPolicyOption FromMutable(ScriptDom.SecurityPolicyOption fragment) {
            if (fragment is null) { return null; }
            return new SecurityPolicyOption(
                optionKind: fragment.OptionKind,
                optionState: fragment.OptionState
            );
        }
        
        public static SecurityPredicateAction FromMutable(ScriptDom.SecurityPredicateAction fragment) {
            if (fragment is null) { return null; }
            return new SecurityPredicateAction(
                actionType: fragment.ActionType,
                securityPredicateType: fragment.SecurityPredicateType,
                functionCall: (FunctionCall)FromMutable(fragment.FunctionCall),
                targetObjectName: (SchemaObjectName)FromMutable(fragment.TargetObjectName),
                securityPredicateOperation: fragment.SecurityPredicateOperation
            );
        }
        
        public static SecurityPrincipal FromMutable(ScriptDom.SecurityPrincipal fragment) {
            if (fragment is null) { return null; }
            return new SecurityPrincipal(
                principalType: fragment.PrincipalType,
                identifier: (Identifier)FromMutable(fragment.Identifier)
            );
        }
        
        public static SecurityTargetObject FromMutable(ScriptDom.SecurityTargetObject fragment) {
            if (fragment is null) { return null; }
            return new SecurityTargetObject(
                objectKind: fragment.ObjectKind,
                objectName: (SecurityTargetObjectName)FromMutable(fragment.ObjectName),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c))
            );
        }
        
        public static SecurityTargetObjectName FromMutable(ScriptDom.SecurityTargetObjectName fragment) {
            if (fragment is null) { return null; }
            return new SecurityTargetObjectName(
                multiPartIdentifier: (MultiPartIdentifier)FromMutable(fragment.MultiPartIdentifier)
            );
        }
        
        public static SecurityUserClause80 FromMutable(ScriptDom.SecurityUserClause80 fragment) {
            if (fragment is null) { return null; }
            return new SecurityUserClause80(
                users: fragment.Users.SelectList(c => (Identifier)FromMutable(c)),
                userType80: fragment.UserType80
            );
        }
        
        public static SelectFunctionReturnType FromMutable(ScriptDom.SelectFunctionReturnType fragment) {
            if (fragment is null) { return null; }
            return new SelectFunctionReturnType(
                selectStatement: (SelectStatement)FromMutable(fragment.SelectStatement)
            );
        }
        
        public static SelectInsertSource FromMutable(ScriptDom.SelectInsertSource fragment) {
            if (fragment is null) { return null; }
            return new SelectInsertSource(
                select: (QueryExpression)FromMutable(fragment.Select)
            );
        }
        
        public static SelectiveXmlIndexPromotedPath FromMutable(ScriptDom.SelectiveXmlIndexPromotedPath fragment) {
            if (fragment is null) { return null; }
            return new SelectiveXmlIndexPromotedPath(
                name: (Identifier)FromMutable(fragment.Name),
                path: (Literal)FromMutable(fragment.Path),
                sQLDataType: (DataTypeReference)FromMutable(fragment.SQLDataType),
                xQueryDataType: (Literal)FromMutable(fragment.XQueryDataType),
                maxLength: (IntegerLiteral)FromMutable(fragment.MaxLength),
                isSingleton: fragment.IsSingleton
            );
        }
        
        public static SelectScalarExpression FromMutable(ScriptDom.SelectScalarExpression fragment) {
            if (fragment is null) { return null; }
            return new SelectScalarExpression(
                expression: (ScalarExpression)FromMutable(fragment.Expression),
                columnName: (IdentifierOrValueExpression)FromMutable(fragment.ColumnName)
            );
        }
        
        public static SelectSetVariable FromMutable(ScriptDom.SelectSetVariable fragment) {
            if (fragment is null) { return null; }
            return new SelectSetVariable(
                variable: (VariableReference)FromMutable(fragment.Variable),
                expression: (ScalarExpression)FromMutable(fragment.Expression),
                assignmentKind: fragment.AssignmentKind
            );
        }
        
        public static SelectStarExpression FromMutable(ScriptDom.SelectStarExpression fragment) {
            if (fragment is null) { return null; }
            return new SelectStarExpression(
                qualifier: (MultiPartIdentifier)FromMutable(fragment.Qualifier)
            );
        }
        
        public static SelectStatement FromMutable(ScriptDom.SelectStatement fragment) {
            if (fragment is null) { return null; }
            return new SelectStatement(
                queryExpression: (QueryExpression)FromMutable(fragment.QueryExpression),
                into: (SchemaObjectName)FromMutable(fragment.Into),
                on: (Identifier)FromMutable(fragment.On),
                computeClauses: fragment.ComputeClauses.SelectList(c => (ComputeClause)FromMutable(c)),
                withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
            );
        }
        
        public static SelectStatementSnippet FromMutable(ScriptDom.SelectStatementSnippet fragment) {
            if (fragment is null) { return null; }
            return new SelectStatementSnippet(
                script: fragment.Script,
                queryExpression: (QueryExpression)FromMutable(fragment.QueryExpression),
                into: (SchemaObjectName)FromMutable(fragment.Into),
                on: (Identifier)FromMutable(fragment.On),
                computeClauses: fragment.ComputeClauses.SelectList(c => (ComputeClause)FromMutable(c)),
                withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
            );
        }
        
        public static SemanticTableReference FromMutable(ScriptDom.SemanticTableReference fragment) {
            if (fragment is null) { return null; }
            return new SemanticTableReference(
                semanticFunctionType: fragment.SemanticFunctionType,
                tableName: (SchemaObjectName)FromMutable(fragment.TableName),
                columns: fragment.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                sourceKey: (ScalarExpression)FromMutable(fragment.SourceKey),
                matchedColumn: (ColumnReferenceExpression)FromMutable(fragment.MatchedColumn),
                matchedKey: (ScalarExpression)FromMutable(fragment.MatchedKey),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static SendStatement FromMutable(ScriptDom.SendStatement fragment) {
            if (fragment is null) { return null; }
            return new SendStatement(
                conversationHandles: fragment.ConversationHandles.SelectList(c => (ScalarExpression)FromMutable(c)),
                messageTypeName: (IdentifierOrValueExpression)FromMutable(fragment.MessageTypeName),
                messageBody: (ScalarExpression)FromMutable(fragment.MessageBody)
            );
        }
        
        public static SensitivityClassificationOption FromMutable(ScriptDom.SensitivityClassificationOption fragment) {
            if (fragment is null) { return null; }
            return new SensitivityClassificationOption(
                type: fragment.Type,
                @value: (Literal)FromMutable(fragment.Value)
            );
        }
        
        public static SequenceOption FromMutable(ScriptDom.SequenceOption fragment) {
            if (fragment is null) { return null; }
            return new SequenceOption(
                optionKind: fragment.OptionKind,
                noValue: fragment.NoValue
            );
        }
        
        public static ServiceContract FromMutable(ScriptDom.ServiceContract fragment) {
            if (fragment is null) { return null; }
            return new ServiceContract(
                name: (Identifier)FromMutable(fragment.Name),
                action: fragment.Action
            );
        }
        
        public static SessionTimeoutPayloadOption FromMutable(ScriptDom.SessionTimeoutPayloadOption fragment) {
            if (fragment is null) { return null; }
            return new SessionTimeoutPayloadOption(
                isNever: fragment.IsNever,
                timeout: (Literal)FromMutable(fragment.Timeout),
                kind: fragment.Kind
            );
        }
        
        public static SetCommandStatement FromMutable(ScriptDom.SetCommandStatement fragment) {
            if (fragment is null) { return null; }
            return new SetCommandStatement(
                commands: fragment.Commands.SelectList(c => (SetCommand)FromMutable(c))
            );
        }
        
        public static SetErrorLevelStatement FromMutable(ScriptDom.SetErrorLevelStatement fragment) {
            if (fragment is null) { return null; }
            return new SetErrorLevelStatement(
                level: (ScalarExpression)FromMutable(fragment.Level)
            );
        }
        
        public static SetFipsFlaggerCommand FromMutable(ScriptDom.SetFipsFlaggerCommand fragment) {
            if (fragment is null) { return null; }
            return new SetFipsFlaggerCommand(
                complianceLevel: fragment.ComplianceLevel
            );
        }
        
        public static SetIdentityInsertStatement FromMutable(ScriptDom.SetIdentityInsertStatement fragment) {
            if (fragment is null) { return null; }
            return new SetIdentityInsertStatement(
                table: (SchemaObjectName)FromMutable(fragment.Table),
                isOn: fragment.IsOn
            );
        }
        
        public static SetOffsetsStatement FromMutable(ScriptDom.SetOffsetsStatement fragment) {
            if (fragment is null) { return null; }
            return new SetOffsetsStatement(
                options: fragment.Options,
                isOn: fragment.IsOn
            );
        }
        
        public static SetRowCountStatement FromMutable(ScriptDom.SetRowCountStatement fragment) {
            if (fragment is null) { return null; }
            return new SetRowCountStatement(
                numberRows: (ValueExpression)FromMutable(fragment.NumberRows)
            );
        }
        
        public static SetSearchPropertyListAlterFullTextIndexAction FromMutable(ScriptDom.SetSearchPropertyListAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            return new SetSearchPropertyListAlterFullTextIndexAction(
                searchPropertyListOption: (SearchPropertyListFullTextIndexOption)FromMutable(fragment.SearchPropertyListOption),
                withNoPopulation: fragment.WithNoPopulation
            );
        }
        
        public static SetStatisticsStatement FromMutable(ScriptDom.SetStatisticsStatement fragment) {
            if (fragment is null) { return null; }
            return new SetStatisticsStatement(
                options: fragment.Options,
                isOn: fragment.IsOn
            );
        }
        
        public static SetStopListAlterFullTextIndexAction FromMutable(ScriptDom.SetStopListAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            return new SetStopListAlterFullTextIndexAction(
                stopListOption: (StopListFullTextIndexOption)FromMutable(fragment.StopListOption),
                withNoPopulation: fragment.WithNoPopulation
            );
        }
        
        public static SetTextSizeStatement FromMutable(ScriptDom.SetTextSizeStatement fragment) {
            if (fragment is null) { return null; }
            return new SetTextSizeStatement(
                textSize: (ScalarExpression)FromMutable(fragment.TextSize)
            );
        }
        
        public static SetTransactionIsolationLevelStatement FromMutable(ScriptDom.SetTransactionIsolationLevelStatement fragment) {
            if (fragment is null) { return null; }
            return new SetTransactionIsolationLevelStatement(
                level: fragment.Level
            );
        }
        
        public static SetUserStatement FromMutable(ScriptDom.SetUserStatement fragment) {
            if (fragment is null) { return null; }
            return new SetUserStatement(
                userName: (ValueExpression)FromMutable(fragment.UserName),
                withNoReset: fragment.WithNoReset
            );
        }
        
        public static SetVariableStatement FromMutable(ScriptDom.SetVariableStatement fragment) {
            if (fragment is null) { return null; }
            return new SetVariableStatement(
                variable: (VariableReference)FromMutable(fragment.Variable),
                separatorType: fragment.SeparatorType,
                identifier: (Identifier)FromMutable(fragment.Identifier),
                functionCallExists: fragment.FunctionCallExists,
                parameters: fragment.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                expression: (ScalarExpression)FromMutable(fragment.Expression),
                cursorDefinition: (CursorDefinition)FromMutable(fragment.CursorDefinition),
                assignmentKind: fragment.AssignmentKind
            );
        }
        
        public static ShutdownStatement FromMutable(ScriptDom.ShutdownStatement fragment) {
            if (fragment is null) { return null; }
            return new ShutdownStatement(
                withNoWait: fragment.WithNoWait
            );
        }
        
        public static SimpleAlterFullTextIndexAction FromMutable(ScriptDom.SimpleAlterFullTextIndexAction fragment) {
            if (fragment is null) { return null; }
            return new SimpleAlterFullTextIndexAction(
                actionKind: fragment.ActionKind
            );
        }
        
        public static SimpleCaseExpression FromMutable(ScriptDom.SimpleCaseExpression fragment) {
            if (fragment is null) { return null; }
            return new SimpleCaseExpression(
                inputExpression: (ScalarExpression)FromMutable(fragment.InputExpression),
                whenClauses: fragment.WhenClauses.SelectList(c => (SimpleWhenClause)FromMutable(c)),
                elseExpression: (ScalarExpression)FromMutable(fragment.ElseExpression),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static SimpleWhenClause FromMutable(ScriptDom.SimpleWhenClause fragment) {
            if (fragment is null) { return null; }
            return new SimpleWhenClause(
                whenExpression: (ScalarExpression)FromMutable(fragment.WhenExpression),
                thenExpression: (ScalarExpression)FromMutable(fragment.ThenExpression)
            );
        }
        
        public static SingleValueTypeCopyOption FromMutable(ScriptDom.SingleValueTypeCopyOption fragment) {
            if (fragment is null) { return null; }
            return new SingleValueTypeCopyOption(
                singleValue: (IdentifierOrValueExpression)FromMutable(fragment.SingleValue)
            );
        }
        
        public static SizeFileDeclarationOption FromMutable(ScriptDom.SizeFileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            return new SizeFileDeclarationOption(
                size: (Literal)FromMutable(fragment.Size),
                units: fragment.Units,
                optionKind: fragment.OptionKind
            );
        }
        
        public static SoapMethod FromMutable(ScriptDom.SoapMethod fragment) {
            if (fragment is null) { return null; }
            return new SoapMethod(
                alias: (Literal)FromMutable(fragment.Alias),
                @namespace: (Literal)FromMutable(fragment.Namespace),
                action: fragment.Action,
                name: (Literal)FromMutable(fragment.Name),
                format: fragment.Format,
                schema: fragment.Schema,
                kind: fragment.Kind
            );
        }
        
        public static SourceDeclaration FromMutable(ScriptDom.SourceDeclaration fragment) {
            if (fragment is null) { return null; }
            return new SourceDeclaration(
                @value: (EventSessionObjectName)FromMutable(fragment.Value)
            );
        }
        
        public static SpatialIndexRegularOption FromMutable(ScriptDom.SpatialIndexRegularOption fragment) {
            if (fragment is null) { return null; }
            return new SpatialIndexRegularOption(
                option: (IndexOption)FromMutable(fragment.Option)
            );
        }
        
        public static SqlCommandIdentifier FromMutable(ScriptDom.SqlCommandIdentifier fragment) {
            if (fragment is null) { return null; }
            return new SqlCommandIdentifier(
                @value: fragment.Value,
                quoteType: fragment.QuoteType
            );
        }
        
        public static SqlDataTypeReference FromMutable(ScriptDom.SqlDataTypeReference fragment) {
            if (fragment is null) { return null; }
            return new SqlDataTypeReference(
                sqlDataTypeOption: fragment.SqlDataTypeOption,
                parameters: fragment.Parameters.SelectList(c => (Literal)FromMutable(c)),
                name: (SchemaObjectName)FromMutable(fragment.Name)
            );
        }
        
        public static StateAuditOption FromMutable(ScriptDom.StateAuditOption fragment) {
            if (fragment is null) { return null; }
            return new StateAuditOption(
                @value: fragment.Value,
                optionKind: fragment.OptionKind
            );
        }
        
        public static StatementList FromMutable(ScriptDom.StatementList fragment) {
            if (fragment is null) { return null; }
            return new StatementList(
                statements: fragment.Statements.SelectList(c => (TSqlStatement)FromMutable(c))
            );
        }
        
        public static StatementListSnippet FromMutable(ScriptDom.StatementListSnippet fragment) {
            if (fragment is null) { return null; }
            return new StatementListSnippet(
                script: fragment.Script,
                statements: fragment.Statements.SelectList(c => (TSqlStatement)FromMutable(c))
            );
        }
        
        public static StatisticsOption FromMutable(ScriptDom.StatisticsOption fragment) {
            if (fragment is null) { return null; }
            return new StatisticsOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static StatisticsPartitionRange FromMutable(ScriptDom.StatisticsPartitionRange fragment) {
            if (fragment is null) { return null; }
            return new StatisticsPartitionRange(
                from: (IntegerLiteral)FromMutable(fragment.From),
                to: (IntegerLiteral)FromMutable(fragment.To)
            );
        }
        
        public static StopListFullTextIndexOption FromMutable(ScriptDom.StopListFullTextIndexOption fragment) {
            if (fragment is null) { return null; }
            return new StopListFullTextIndexOption(
                isOff: fragment.IsOff,
                stopListName: (Identifier)FromMutable(fragment.StopListName),
                optionKind: fragment.OptionKind
            );
        }
        
        public static StopRestoreOption FromMutable(ScriptDom.StopRestoreOption fragment) {
            if (fragment is null) { return null; }
            return new StopRestoreOption(
                mark: (ValueExpression)FromMutable(fragment.Mark),
                after: (ValueExpression)FromMutable(fragment.After),
                isStopAt: fragment.IsStopAt,
                optionKind: fragment.OptionKind
            );
        }
        
        public static StringLiteral FromMutable(ScriptDom.StringLiteral fragment) {
            if (fragment is null) { return null; }
            return new StringLiteral(
                isNational: fragment.IsNational,
                isLargeObject: fragment.IsLargeObject,
                @value: fragment.Value,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static SubqueryComparisonPredicate FromMutable(ScriptDom.SubqueryComparisonPredicate fragment) {
            if (fragment is null) { return null; }
            return new SubqueryComparisonPredicate(
                expression: (ScalarExpression)FromMutable(fragment.Expression),
                comparisonType: fragment.ComparisonType,
                subquery: (ScalarSubquery)FromMutable(fragment.Subquery),
                subqueryComparisonPredicateType: fragment.SubqueryComparisonPredicateType
            );
        }
        
        public static SystemTimePeriodDefinition FromMutable(ScriptDom.SystemTimePeriodDefinition fragment) {
            if (fragment is null) { return null; }
            return new SystemTimePeriodDefinition(
                startTimeColumn: (Identifier)FromMutable(fragment.StartTimeColumn),
                endTimeColumn: (Identifier)FromMutable(fragment.EndTimeColumn)
            );
        }
        
        public static SystemVersioningTableOption FromMutable(ScriptDom.SystemVersioningTableOption fragment) {
            if (fragment is null) { return null; }
            return new SystemVersioningTableOption(
                optionState: fragment.OptionState,
                consistencyCheckEnabled: fragment.ConsistencyCheckEnabled,
                historyTable: (SchemaObjectName)FromMutable(fragment.HistoryTable),
                retentionPeriod: (RetentionPeriodDefinition)FromMutable(fragment.RetentionPeriod),
                optionKind: fragment.OptionKind
            );
        }
        
        public static TableClusteredIndexType FromMutable(ScriptDom.TableClusteredIndexType fragment) {
            if (fragment is null) { return null; }
            return new TableClusteredIndexType(
                columns: fragment.Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                columnStore: fragment.ColumnStore,
                orderedColumns: fragment.OrderedColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
            );
        }
        
        public static TableDataCompressionOption FromMutable(ScriptDom.TableDataCompressionOption fragment) {
            if (fragment is null) { return null; }
            return new TableDataCompressionOption(
                dataCompressionOption: (DataCompressionOption)FromMutable(fragment.DataCompressionOption),
                optionKind: fragment.OptionKind
            );
        }
        
        public static TableDefinition FromMutable(ScriptDom.TableDefinition fragment) {
            if (fragment is null) { return null; }
            return new TableDefinition(
                columnDefinitions: fragment.ColumnDefinitions.SelectList(c => (ColumnDefinition)FromMutable(c)),
                tableConstraints: fragment.TableConstraints.SelectList(c => (ConstraintDefinition)FromMutable(c)),
                indexes: fragment.Indexes.SelectList(c => (IndexDefinition)FromMutable(c)),
                systemTimePeriod: (SystemTimePeriodDefinition)FromMutable(fragment.SystemTimePeriod)
            );
        }
        
        public static TableDistributionOption FromMutable(ScriptDom.TableDistributionOption fragment) {
            if (fragment is null) { return null; }
            return new TableDistributionOption(
                @value: (TableDistributionPolicy)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static TableHashDistributionPolicy FromMutable(ScriptDom.TableHashDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            return new TableHashDistributionPolicy(
                distributionColumn: (Identifier)FromMutable(fragment.DistributionColumn)
            );
        }
        
        public static TableHint FromMutable(ScriptDom.TableHint fragment) {
            if (fragment is null) { return null; }
            return new TableHint(
                hintKind: fragment.HintKind
            );
        }
        
        public static TableHintsOptimizerHint FromMutable(ScriptDom.TableHintsOptimizerHint fragment) {
            if (fragment is null) { return null; }
            return new TableHintsOptimizerHint(
                objectName: (SchemaObjectName)FromMutable(fragment.ObjectName),
                tableHints: fragment.TableHints.SelectList(c => (TableHint)FromMutable(c)),
                hintKind: fragment.HintKind
            );
        }
        
        public static TableIndexOption FromMutable(ScriptDom.TableIndexOption fragment) {
            if (fragment is null) { return null; }
            return new TableIndexOption(
                @value: (TableIndexType)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static TableNonClusteredIndexType FromMutable(ScriptDom.TableNonClusteredIndexType fragment) {
            if (fragment is null) { return null; }
            return new TableNonClusteredIndexType(
                
            );
        }
        
        public static TablePartitionOption FromMutable(ScriptDom.TablePartitionOption fragment) {
            if (fragment is null) { return null; }
            return new TablePartitionOption(
                partitionColumn: (Identifier)FromMutable(fragment.PartitionColumn),
                partitionOptionSpecs: (TablePartitionOptionSpecifications)FromMutable(fragment.PartitionOptionSpecs),
                optionKind: fragment.OptionKind
            );
        }
        
        public static TablePartitionOptionSpecifications FromMutable(ScriptDom.TablePartitionOptionSpecifications fragment) {
            if (fragment is null) { return null; }
            return new TablePartitionOptionSpecifications(
                range: fragment.Range,
                boundaryValues: fragment.BoundaryValues.SelectList(c => (ScalarExpression)FromMutable(c))
            );
        }
        
        public static TableReplicateDistributionPolicy FromMutable(ScriptDom.TableReplicateDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            return new TableReplicateDistributionPolicy(
                
            );
        }
        
        public static TableRoundRobinDistributionPolicy FromMutable(ScriptDom.TableRoundRobinDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            return new TableRoundRobinDistributionPolicy(
                
            );
        }
        
        public static TableSampleClause FromMutable(ScriptDom.TableSampleClause fragment) {
            if (fragment is null) { return null; }
            return new TableSampleClause(
                system: fragment.System,
                sampleNumber: (ScalarExpression)FromMutable(fragment.SampleNumber),
                tableSampleClauseOption: fragment.TableSampleClauseOption,
                repeatSeed: (ScalarExpression)FromMutable(fragment.RepeatSeed)
            );
        }
        
        public static TableValuedFunctionReturnType FromMutable(ScriptDom.TableValuedFunctionReturnType fragment) {
            if (fragment is null) { return null; }
            return new TableValuedFunctionReturnType(
                declareTableVariableBody: (DeclareTableVariableBody)FromMutable(fragment.DeclareTableVariableBody)
            );
        }
        
        public static TableXmlCompressionOption FromMutable(ScriptDom.TableXmlCompressionOption fragment) {
            if (fragment is null) { return null; }
            return new TableXmlCompressionOption(
                xmlCompressionOption: (XmlCompressionOption)FromMutable(fragment.XmlCompressionOption),
                optionKind: fragment.OptionKind
            );
        }
        
        public static TargetDeclaration FromMutable(ScriptDom.TargetDeclaration fragment) {
            if (fragment is null) { return null; }
            return new TargetDeclaration(
                objectName: (EventSessionObjectName)FromMutable(fragment.ObjectName),
                targetDeclarationParameters: fragment.TargetDeclarationParameters.SelectList(c => (EventDeclarationSetParameter)FromMutable(c))
            );
        }
        
        public static TargetRecoveryTimeDatabaseOption FromMutable(ScriptDom.TargetRecoveryTimeDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new TargetRecoveryTimeDatabaseOption(
                recoveryTime: (Literal)FromMutable(fragment.RecoveryTime),
                unit: fragment.Unit,
                optionKind: fragment.OptionKind
            );
        }
        
        public static TemporalClause FromMutable(ScriptDom.TemporalClause fragment) {
            if (fragment is null) { return null; }
            return new TemporalClause(
                temporalClauseType: fragment.TemporalClauseType,
                startTime: (ScalarExpression)FromMutable(fragment.StartTime),
                endTime: (ScalarExpression)FromMutable(fragment.EndTime)
            );
        }
        
        public static ThrowStatement FromMutable(ScriptDom.ThrowStatement fragment) {
            if (fragment is null) { return null; }
            return new ThrowStatement(
                errorNumber: (ValueExpression)FromMutable(fragment.ErrorNumber),
                message: (ValueExpression)FromMutable(fragment.Message),
                state: (ValueExpression)FromMutable(fragment.State)
            );
        }
        
        public static TopRowFilter FromMutable(ScriptDom.TopRowFilter fragment) {
            if (fragment is null) { return null; }
            return new TopRowFilter(
                expression: (ScalarExpression)FromMutable(fragment.Expression),
                percent: fragment.Percent,
                withTies: fragment.WithTies
            );
        }
        
        public static TriggerAction FromMutable(ScriptDom.TriggerAction fragment) {
            if (fragment is null) { return null; }
            return new TriggerAction(
                triggerActionType: fragment.TriggerActionType,
                eventTypeGroup: (EventTypeGroupContainer)FromMutable(fragment.EventTypeGroup)
            );
        }
        
        public static TriggerObject FromMutable(ScriptDom.TriggerObject fragment) {
            if (fragment is null) { return null; }
            return new TriggerObject(
                name: (SchemaObjectName)FromMutable(fragment.Name),
                triggerScope: fragment.TriggerScope
            );
        }
        
        public static TriggerOption FromMutable(ScriptDom.TriggerOption fragment) {
            if (fragment is null) { return null; }
            return new TriggerOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static TruncateTableStatement FromMutable(ScriptDom.TruncateTableStatement fragment) {
            if (fragment is null) { return null; }
            return new TruncateTableStatement(
                tableName: (SchemaObjectName)FromMutable(fragment.TableName),
                partitionRanges: fragment.PartitionRanges.SelectList(c => (CompressionPartitionRange)FromMutable(c))
            );
        }
        
        public static TruncateTargetTableSwitchOption FromMutable(ScriptDom.TruncateTargetTableSwitchOption fragment) {
            if (fragment is null) { return null; }
            return new TruncateTargetTableSwitchOption(
                truncateTarget: fragment.TruncateTarget,
                optionKind: fragment.OptionKind
            );
        }
        
        public static TryCastCall FromMutable(ScriptDom.TryCastCall fragment) {
            if (fragment is null) { return null; }
            return new TryCastCall(
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                parameter: (ScalarExpression)FromMutable(fragment.Parameter),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static TryCatchStatement FromMutable(ScriptDom.TryCatchStatement fragment) {
            if (fragment is null) { return null; }
            return new TryCatchStatement(
                tryStatements: (StatementList)FromMutable(fragment.TryStatements),
                catchStatements: (StatementList)FromMutable(fragment.CatchStatements)
            );
        }
        
        public static TryConvertCall FromMutable(ScriptDom.TryConvertCall fragment) {
            if (fragment is null) { return null; }
            return new TryConvertCall(
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                parameter: (ScalarExpression)FromMutable(fragment.Parameter),
                style: (ScalarExpression)FromMutable(fragment.Style),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static TryParseCall FromMutable(ScriptDom.TryParseCall fragment) {
            if (fragment is null) { return null; }
            return new TryParseCall(
                stringValue: (ScalarExpression)FromMutable(fragment.StringValue),
                dataType: (DataTypeReference)FromMutable(fragment.DataType),
                culture: (ScalarExpression)FromMutable(fragment.Culture),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static TSEqualCall FromMutable(ScriptDom.TSEqualCall fragment) {
            if (fragment is null) { return null; }
            return new TSEqualCall(
                firstExpression: (ScalarExpression)FromMutable(fragment.FirstExpression),
                secondExpression: (ScalarExpression)FromMutable(fragment.SecondExpression)
            );
        }
        
        public static TSqlBatch FromMutable(ScriptDom.TSqlBatch fragment) {
            if (fragment is null) { return null; }
            return new TSqlBatch(
                statements: fragment.Statements.SelectList(c => (TSqlStatement)FromMutable(c))
            );
        }
        
        public static TSqlFragmentSnippet FromMutable(ScriptDom.TSqlFragmentSnippet fragment) {
            if (fragment is null) { return null; }
            return new TSqlFragmentSnippet(
                script: fragment.Script
            );
        }
        
        public static TSqlScript FromMutable(ScriptDom.TSqlScript fragment) {
            if (fragment is null) { return null; }
            return new TSqlScript(
                batches: fragment.Batches.SelectList(c => (TSqlBatch)FromMutable(c))
            );
        }
        
        public static TSqlStatementSnippet FromMutable(ScriptDom.TSqlStatementSnippet fragment) {
            if (fragment is null) { return null; }
            return new TSqlStatementSnippet(
                script: fragment.Script
            );
        }
        
        public static UnaryExpression FromMutable(ScriptDom.UnaryExpression fragment) {
            if (fragment is null) { return null; }
            return new UnaryExpression(
                unaryExpressionType: fragment.UnaryExpressionType,
                expression: (ScalarExpression)FromMutable(fragment.Expression)
            );
        }
        
        public static UniqueConstraintDefinition FromMutable(ScriptDom.UniqueConstraintDefinition fragment) {
            if (fragment is null) { return null; }
            return new UniqueConstraintDefinition(
                clustered: fragment.Clustered,
                isPrimaryKey: fragment.IsPrimaryKey,
                isEnforced: fragment.IsEnforced,
                columns: fragment.Columns.SelectList(c => (ColumnWithSortOrder)FromMutable(c)),
                indexOptions: fragment.IndexOptions.SelectList(c => (IndexOption)FromMutable(c)),
                onFileGroupOrPartitionScheme: (FileGroupOrPartitionScheme)FromMutable(fragment.OnFileGroupOrPartitionScheme),
                indexType: (IndexType)FromMutable(fragment.IndexType),
                fileStreamOn: (IdentifierOrValueExpression)FromMutable(fragment.FileStreamOn),
                constraintIdentifier: (Identifier)FromMutable(fragment.ConstraintIdentifier)
            );
        }
        
        public static UnpivotedTableReference FromMutable(ScriptDom.UnpivotedTableReference fragment) {
            if (fragment is null) { return null; }
            return new UnpivotedTableReference(
                tableReference: (TableReference)FromMutable(fragment.TableReference),
                inColumns: fragment.InColumns.SelectList(c => (ColumnReferenceExpression)FromMutable(c)),
                pivotColumn: (Identifier)FromMutable(fragment.PivotColumn),
                valueColumn: (Identifier)FromMutable(fragment.ValueColumn),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static UnqualifiedJoin FromMutable(ScriptDom.UnqualifiedJoin fragment) {
            if (fragment is null) { return null; }
            return new UnqualifiedJoin(
                unqualifiedJoinType: fragment.UnqualifiedJoinType,
                firstTableReference: (TableReference)FromMutable(fragment.FirstTableReference),
                secondTableReference: (TableReference)FromMutable(fragment.SecondTableReference)
            );
        }
        
        public static UpdateCall FromMutable(ScriptDom.UpdateCall fragment) {
            if (fragment is null) { return null; }
            return new UpdateCall(
                identifier: (Identifier)FromMutable(fragment.Identifier)
            );
        }
        
        public static UpdateForClause FromMutable(ScriptDom.UpdateForClause fragment) {
            if (fragment is null) { return null; }
            return new UpdateForClause(
                columns: fragment.Columns.SelectList(c => (ColumnReferenceExpression)FromMutable(c))
            );
        }
        
        public static UpdateMergeAction FromMutable(ScriptDom.UpdateMergeAction fragment) {
            if (fragment is null) { return null; }
            return new UpdateMergeAction(
                setClauses: fragment.SetClauses.SelectList(c => (SetClause)FromMutable(c))
            );
        }
        
        public static UpdateSpecification FromMutable(ScriptDom.UpdateSpecification fragment) {
            if (fragment is null) { return null; }
            return new UpdateSpecification(
                setClauses: fragment.SetClauses.SelectList(c => (SetClause)FromMutable(c)),
                fromClause: (FromClause)FromMutable(fragment.FromClause),
                whereClause: (WhereClause)FromMutable(fragment.WhereClause),
                target: (TableReference)FromMutable(fragment.Target),
                topRowFilter: (TopRowFilter)FromMutable(fragment.TopRowFilter),
                outputIntoClause: (OutputIntoClause)FromMutable(fragment.OutputIntoClause),
                outputClause: (OutputClause)FromMutable(fragment.OutputClause)
            );
        }
        
        public static UpdateStatement FromMutable(ScriptDom.UpdateStatement fragment) {
            if (fragment is null) { return null; }
            return new UpdateStatement(
                updateSpecification: (UpdateSpecification)FromMutable(fragment.UpdateSpecification),
                withCtesAndXmlNamespaces: (WithCtesAndXmlNamespaces)FromMutable(fragment.WithCtesAndXmlNamespaces),
                optimizerHints: fragment.OptimizerHints.SelectList(c => (OptimizerHint)FromMutable(c))
            );
        }
        
        public static UpdateStatisticsStatement FromMutable(ScriptDom.UpdateStatisticsStatement fragment) {
            if (fragment is null) { return null; }
            return new UpdateStatisticsStatement(
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName),
                subElements: fragment.SubElements.SelectList(c => (Identifier)FromMutable(c)),
                statisticsOptions: fragment.StatisticsOptions.SelectList(c => (StatisticsOption)FromMutable(c))
            );
        }
        
        public static UpdateTextStatement FromMutable(ScriptDom.UpdateTextStatement fragment) {
            if (fragment is null) { return null; }
            return new UpdateTextStatement(
                insertOffset: (ScalarExpression)FromMutable(fragment.InsertOffset),
                deleteLength: (ScalarExpression)FromMutable(fragment.DeleteLength),
                sourceColumn: (ColumnReferenceExpression)FromMutable(fragment.SourceColumn),
                sourceParameter: (ValueExpression)FromMutable(fragment.SourceParameter),
                bulk: fragment.Bulk,
                column: (ColumnReferenceExpression)FromMutable(fragment.Column),
                textId: (ValueExpression)FromMutable(fragment.TextId),
                timestamp: (Literal)FromMutable(fragment.Timestamp),
                withLog: fragment.WithLog
            );
        }
        
        public static UseFederationStatement FromMutable(ScriptDom.UseFederationStatement fragment) {
            if (fragment is null) { return null; }
            return new UseFederationStatement(
                federationName: (Identifier)FromMutable(fragment.FederationName),
                distributionName: (Identifier)FromMutable(fragment.DistributionName),
                @value: (ScalarExpression)FromMutable(fragment.Value),
                filtering: fragment.Filtering
            );
        }
        
        public static UseHintList FromMutable(ScriptDom.UseHintList fragment) {
            if (fragment is null) { return null; }
            return new UseHintList(
                hints: fragment.Hints.SelectList(c => (StringLiteral)FromMutable(c)),
                hintKind: fragment.HintKind
            );
        }
        
        public static UserDataTypeReference FromMutable(ScriptDom.UserDataTypeReference fragment) {
            if (fragment is null) { return null; }
            return new UserDataTypeReference(
                parameters: fragment.Parameters.SelectList(c => (Literal)FromMutable(c)),
                name: (SchemaObjectName)FromMutable(fragment.Name)
            );
        }
        
        public static UserDefinedTypeCallTarget FromMutable(ScriptDom.UserDefinedTypeCallTarget fragment) {
            if (fragment is null) { return null; }
            return new UserDefinedTypeCallTarget(
                schemaObjectName: (SchemaObjectName)FromMutable(fragment.SchemaObjectName)
            );
        }
        
        public static UserDefinedTypePropertyAccess FromMutable(ScriptDom.UserDefinedTypePropertyAccess fragment) {
            if (fragment is null) { return null; }
            return new UserDefinedTypePropertyAccess(
                callTarget: (CallTarget)FromMutable(fragment.CallTarget),
                propertyName: (Identifier)FromMutable(fragment.PropertyName),
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static UserLoginOption FromMutable(ScriptDom.UserLoginOption fragment) {
            if (fragment is null) { return null; }
            return new UserLoginOption(
                userLoginOptionType: fragment.UserLoginOptionType,
                identifier: (Identifier)FromMutable(fragment.Identifier)
            );
        }
        
        public static UserRemoteServiceBindingOption FromMutable(ScriptDom.UserRemoteServiceBindingOption fragment) {
            if (fragment is null) { return null; }
            return new UserRemoteServiceBindingOption(
                user: (Identifier)FromMutable(fragment.User),
                optionKind: fragment.OptionKind
            );
        }
        
        public static UseStatement FromMutable(ScriptDom.UseStatement fragment) {
            if (fragment is null) { return null; }
            return new UseStatement(
                databaseName: (Identifier)FromMutable(fragment.DatabaseName)
            );
        }
        
        public static ValuesInsertSource FromMutable(ScriptDom.ValuesInsertSource fragment) {
            if (fragment is null) { return null; }
            return new ValuesInsertSource(
                isDefaultValues: fragment.IsDefaultValues,
                rowValues: fragment.RowValues.SelectList(c => (RowValue)FromMutable(c))
            );
        }
        
        public static VariableMethodCallTableReference FromMutable(ScriptDom.VariableMethodCallTableReference fragment) {
            if (fragment is null) { return null; }
            return new VariableMethodCallTableReference(
                variable: (VariableReference)FromMutable(fragment.Variable),
                methodName: (Identifier)FromMutable(fragment.MethodName),
                parameters: fragment.Parameters.SelectList(c => (ScalarExpression)FromMutable(c)),
                columns: fragment.Columns.SelectList(c => (Identifier)FromMutable(c)),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static VariableReference FromMutable(ScriptDom.VariableReference fragment) {
            if (fragment is null) { return null; }
            return new VariableReference(
                name: fragment.Name,
                collation: (Identifier)FromMutable(fragment.Collation)
            );
        }
        
        public static VariableTableReference FromMutable(ScriptDom.VariableTableReference fragment) {
            if (fragment is null) { return null; }
            return new VariableTableReference(
                variable: (VariableReference)FromMutable(fragment.Variable),
                alias: (Identifier)FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
        
        public static VariableValuePair FromMutable(ScriptDom.VariableValuePair fragment) {
            if (fragment is null) { return null; }
            return new VariableValuePair(
                variable: (VariableReference)FromMutable(fragment.Variable),
                @value: (ScalarExpression)FromMutable(fragment.Value),
                isForUnknown: fragment.IsForUnknown
            );
        }
        
        public static ViewDistributionOption FromMutable(ScriptDom.ViewDistributionOption fragment) {
            if (fragment is null) { return null; }
            return new ViewDistributionOption(
                @value: (ViewDistributionPolicy)FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
        
        public static ViewForAppendOption FromMutable(ScriptDom.ViewForAppendOption fragment) {
            if (fragment is null) { return null; }
            return new ViewForAppendOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static ViewHashDistributionPolicy FromMutable(ScriptDom.ViewHashDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            return new ViewHashDistributionPolicy(
                distributionColumn: (Identifier)FromMutable(fragment.DistributionColumn)
            );
        }
        
        public static ViewOption FromMutable(ScriptDom.ViewOption fragment) {
            if (fragment is null) { return null; }
            return new ViewOption(
                optionKind: fragment.OptionKind
            );
        }
        
        public static ViewRoundRobinDistributionPolicy FromMutable(ScriptDom.ViewRoundRobinDistributionPolicy fragment) {
            if (fragment is null) { return null; }
            return new ViewRoundRobinDistributionPolicy(
                
            );
        }
        
        public static WaitAtLowPriorityOption FromMutable(ScriptDom.WaitAtLowPriorityOption fragment) {
            if (fragment is null) { return null; }
            return new WaitAtLowPriorityOption(
                options: fragment.Options.SelectList(c => (LowPriorityLockWaitOption)FromMutable(c)),
                optionKind: fragment.OptionKind
            );
        }
        
        public static WaitForStatement FromMutable(ScriptDom.WaitForStatement fragment) {
            if (fragment is null) { return null; }
            return new WaitForStatement(
                waitForOption: fragment.WaitForOption,
                parameter: (ValueExpression)FromMutable(fragment.Parameter),
                timeout: (ScalarExpression)FromMutable(fragment.Timeout),
                statement: (WaitForSupportedStatement)FromMutable(fragment.Statement)
            );
        }
        
        public static WhereClause FromMutable(ScriptDom.WhereClause fragment) {
            if (fragment is null) { return null; }
            return new WhereClause(
                searchCondition: (BooleanExpression)FromMutable(fragment.SearchCondition),
                cursor: (CursorId)FromMutable(fragment.Cursor)
            );
        }
        
        public static WhileStatement FromMutable(ScriptDom.WhileStatement fragment) {
            if (fragment is null) { return null; }
            return new WhileStatement(
                predicate: (BooleanExpression)FromMutable(fragment.Predicate),
                statement: (TSqlStatement)FromMutable(fragment.Statement)
            );
        }
        
        public static WindowClause FromMutable(ScriptDom.WindowClause fragment) {
            if (fragment is null) { return null; }
            return new WindowClause(
                windowDefinition: fragment.WindowDefinition.SelectList(c => (WindowDefinition)FromMutable(c))
            );
        }
        
        public static WindowDefinition FromMutable(ScriptDom.WindowDefinition fragment) {
            if (fragment is null) { return null; }
            return new WindowDefinition(
                windowName: (Identifier)FromMutable(fragment.WindowName),
                refWindowName: (Identifier)FromMutable(fragment.RefWindowName),
                partitions: fragment.Partitions.SelectList(c => (ScalarExpression)FromMutable(c)),
                orderByClause: (OrderByClause)FromMutable(fragment.OrderByClause),
                windowFrameClause: (WindowFrameClause)FromMutable(fragment.WindowFrameClause)
            );
        }
        
        public static WindowDelimiter FromMutable(ScriptDom.WindowDelimiter fragment) {
            if (fragment is null) { return null; }
            return new WindowDelimiter(
                windowDelimiterType: fragment.WindowDelimiterType,
                offsetValue: (ScalarExpression)FromMutable(fragment.OffsetValue)
            );
        }
        
        public static WindowFrameClause FromMutable(ScriptDom.WindowFrameClause fragment) {
            if (fragment is null) { return null; }
            return new WindowFrameClause(
                top: (WindowDelimiter)FromMutable(fragment.Top),
                bottom: (WindowDelimiter)FromMutable(fragment.Bottom),
                windowFrameType: fragment.WindowFrameType
            );
        }
        
        public static WindowsCreateLoginSource FromMutable(ScriptDom.WindowsCreateLoginSource fragment) {
            if (fragment is null) { return null; }
            return new WindowsCreateLoginSource(
                options: fragment.Options.SelectList(c => (PrincipalOption)FromMutable(c))
            );
        }
        
        public static WithCtesAndXmlNamespaces FromMutable(ScriptDom.WithCtesAndXmlNamespaces fragment) {
            if (fragment is null) { return null; }
            return new WithCtesAndXmlNamespaces(
                xmlNamespaces: (XmlNamespaces)FromMutable(fragment.XmlNamespaces),
                commonTableExpressions: fragment.CommonTableExpressions.SelectList(c => (CommonTableExpression)FromMutable(c)),
                changeTrackingContext: (ValueExpression)FromMutable(fragment.ChangeTrackingContext)
            );
        }
        
        public static WithinGroupClause FromMutable(ScriptDom.WithinGroupClause fragment) {
            if (fragment is null) { return null; }
            return new WithinGroupClause(
                orderByClause: (OrderByClause)FromMutable(fragment.OrderByClause),
                hasGraphPath: fragment.HasGraphPath
            );
        }
        
        public static WitnessDatabaseOption FromMutable(ScriptDom.WitnessDatabaseOption fragment) {
            if (fragment is null) { return null; }
            return new WitnessDatabaseOption(
                witnessServer: (Literal)FromMutable(fragment.WitnessServer),
                isOff: fragment.IsOff,
                optionKind: fragment.OptionKind
            );
        }
        
        public static WlmTimeLiteral FromMutable(ScriptDom.WlmTimeLiteral fragment) {
            if (fragment is null) { return null; }
            return new WlmTimeLiteral(
                timeString: (StringLiteral)FromMutable(fragment.TimeString)
            );
        }
        
        public static WorkloadGroupImportanceParameter FromMutable(ScriptDom.WorkloadGroupImportanceParameter fragment) {
            if (fragment is null) { return null; }
            return new WorkloadGroupImportanceParameter(
                parameterValue: fragment.ParameterValue,
                parameterType: fragment.ParameterType
            );
        }
        
        public static WorkloadGroupResourceParameter FromMutable(ScriptDom.WorkloadGroupResourceParameter fragment) {
            if (fragment is null) { return null; }
            return new WorkloadGroupResourceParameter(
                parameterValue: (Literal)FromMutable(fragment.ParameterValue),
                parameterType: fragment.ParameterType
            );
        }
        
        public static WriteTextStatement FromMutable(ScriptDom.WriteTextStatement fragment) {
            if (fragment is null) { return null; }
            return new WriteTextStatement(
                sourceParameter: (ValueExpression)FromMutable(fragment.SourceParameter),
                bulk: fragment.Bulk,
                column: (ColumnReferenceExpression)FromMutable(fragment.Column),
                textId: (ValueExpression)FromMutable(fragment.TextId),
                timestamp: (Literal)FromMutable(fragment.Timestamp),
                withLog: fragment.WithLog
            );
        }
        
        public static WsdlPayloadOption FromMutable(ScriptDom.WsdlPayloadOption fragment) {
            if (fragment is null) { return null; }
            return new WsdlPayloadOption(
                isNone: fragment.IsNone,
                @value: (Literal)FromMutable(fragment.Value),
                kind: fragment.Kind
            );
        }
        
        public static XmlCompressionOption FromMutable(ScriptDom.XmlCompressionOption fragment) {
            if (fragment is null) { return null; }
            return new XmlCompressionOption(
                isCompressed: fragment.IsCompressed,
                partitionRanges: fragment.PartitionRanges.SelectList(c => (CompressionPartitionRange)FromMutable(c)),
                optionKind: fragment.OptionKind
            );
        }
        
        public static XmlDataTypeReference FromMutable(ScriptDom.XmlDataTypeReference fragment) {
            if (fragment is null) { return null; }
            return new XmlDataTypeReference(
                xmlDataTypeOption: fragment.XmlDataTypeOption,
                xmlSchemaCollection: (SchemaObjectName)FromMutable(fragment.XmlSchemaCollection),
                name: (SchemaObjectName)FromMutable(fragment.Name)
            );
        }
        
        public static XmlForClause FromMutable(ScriptDom.XmlForClause fragment) {
            if (fragment is null) { return null; }
            return new XmlForClause(
                options: fragment.Options.SelectList(c => (XmlForClauseOption)FromMutable(c))
            );
        }
        
        public static XmlForClauseOption FromMutable(ScriptDom.XmlForClauseOption fragment) {
            if (fragment is null) { return null; }
            return new XmlForClauseOption(
                optionKind: fragment.OptionKind,
                @value: (Literal)FromMutable(fragment.Value)
            );
        }
        
        public static XmlNamespaces FromMutable(ScriptDom.XmlNamespaces fragment) {
            if (fragment is null) { return null; }
            return new XmlNamespaces(
                xmlNamespacesElements: fragment.XmlNamespacesElements.SelectList(c => (XmlNamespacesElement)FromMutable(c))
            );
        }
        
        public static XmlNamespacesAliasElement FromMutable(ScriptDom.XmlNamespacesAliasElement fragment) {
            if (fragment is null) { return null; }
            return new XmlNamespacesAliasElement(
                identifier: (Identifier)FromMutable(fragment.Identifier),
                @string: (StringLiteral)FromMutable(fragment.String)
            );
        }
        
        public static XmlNamespacesDefaultElement FromMutable(ScriptDom.XmlNamespacesDefaultElement fragment) {
            if (fragment is null) { return null; }
            return new XmlNamespacesDefaultElement(
                @string: (StringLiteral)FromMutable(fragment.String)
            );
        }
    
    }

}
