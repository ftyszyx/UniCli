# UniCli 中文命令参考

> 由 `unicli commands --json` 自动生成。
> 文档结构与使用说明为中文，命令名、字段名和类型名保持原样，便于与 CLI 输出一一对应。

## 概览

- 命令总数：**149**
- Unity 项目：`e:\opensource\UniCli\src\UniCli.Unity`
- CLI 路径：`e:\opensource\UniCli\publish\win-x64\Release\unicli.exe`

常用调用格式：

```powershell
$env:UNICLI_PROJECT = "e:\opensource\UniCli\src\UniCli.Unity"
& "e:\opensource\UniCli\publish\win-x64\Release\unicli.exe" exec Compile --json
& "e:\opensource\UniCli\publish\win-x64\Release\unicli.exe" exec GameObject.Find --namePattern "Camera" --json
```

## 模块目录

- **核心与通用**：53 条
- **动画**：12 条
- **资源**：33 条
- **游戏对象**：16 条
- **NuGet**：7 条
- **性能分析**：9 条
- **录制**：3 条
- **远程**：5 条
- **场景**：10 条
- **搜索**：1 条

## 核心与通用

### AssemblyDefinition.AddReference

- 原始说明：Add an assembly reference to an existing assembly definition
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `reference` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `addedReference` | `string` | `` |
| `references` | `string[]` | `` |

---

### AssemblyDefinition.Create

- 原始说明：Create a new assembly definition file
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `directory` | `string` | `` |
| `rootNamespace` | `string` | `` |
| `references` | `string[]` | `` |
| `includePlatforms` | `string[]` | `` |
| `excludePlatforms` | `string[]` | `` |
| `allowUnsafeCode` | `bool` | `` |
| `autoReferenced` | `bool` | `true` |
| `defineConstraints` | `string[]` | `` |
| `noEngineReferences` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |

---

### AssemblyDefinition.Get

- 原始说明：Get detailed information about a specific assembly definition
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `rootNamespace` | `string` | `` |
| `references` | `string[]` | `` |
| `includePlatforms` | `string[]` | `` |
| `excludePlatforms` | `string[]` | `` |
| `allowUnsafeCode` | `bool` | `` |
| `autoReferenced` | `bool` | `` |
| `defineConstraints` | `string[]` | `` |
| `noEngineReferences` | `bool` | `` |
| `sourceFiles` | `string[]` | `` |
| `defines` | `string[]` | `` |

---

### AssemblyDefinition.List

- 原始说明：List all assembly definitions in the project
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assemblies` | `AssemblyDefinitionEntry[]` | `` |
| `totalCount` | `int` | `` |

**嵌套类型详情**

- 类型：`AssemblyDefinitionEntry`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.AssemblyDefinitionEntry`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `rootNamespace` | `string` | `` |
| `sourceFileCount` | `int` | `` |
| `referenceCount` | `int` | `` |

---

### AssemblyDefinition.RemoveReference

- 原始说明：Remove an assembly reference from an existing assembly definition
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `reference` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `removedReference` | `string` | `` |
| `references` | `string[]` | `` |

---

### BuildPlayer.Build

- 原始说明：Build the player using BuildPipeline.BuildPlayer
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `target` | `string` | `` |
| `locationPathName` | `string` | `` |
| `scenes` | `string[]` | `` |
| `options` | `string[]` | `` |
| `extraScriptingDefines` | `string[]` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `target` | `string` | `` |
| `targetGroup` | `string` | `` |
| `locationPathName` | `string` | `` |
| `result` | `string` | `` |
| `totalErrorCount` | `int` | `` |
| `totalWarningCount` | `int` | `` |
| `totalBuildTimeSec` | `double` | `` |
| `totalSizeBytes` | `Int64` | `` |
| `steps` | `BuildStepInfo[]` | `` |
| `errors` | `BuildMessageInfo[]` | `` |
| `warnings` | `BuildMessageInfo[]` | `` |

**嵌套类型详情**

- 类型：`BuildStepInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.BuildStepInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `durationSec` | `double` | `` |
| `depth` | `int` | `` |

- 类型：`BuildMessageInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.BuildMessageInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `message` | `string` | `` |

---

### BuildPlayer.Compile

- 原始说明：Compile player scripts for a specific build target
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `target` | `string` | `` |
| `extraScriptingDefines` | `string[]` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `target` | `string` | `` |
| `targetGroup` | `string` | `` |
| `assemblyCount` | `int` | `` |
| `assemblies` | `string[]` | `` |
| `errorCount` | `int` | `` |
| `warningCount` | `int` | `` |
| `errors` | `CompileIssue[]` | `` |
| `warnings` | `CompileIssue[]` | `` |

**嵌套类型详情**

- 类型：`CompileIssue`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.CompileIssue`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `message` | `string` | `` |
| `file` | `string` | `` |
| `line` | `int` | `` |

---

### BuildTarget.GetActive

- 原始说明：Get the active build target and build target group via EditorUserBuildSettings
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `buildTarget` | `string` | `` |
| `buildTargetGroup` | `string` | `` |

---

### BuildTarget.Switch

- 原始说明：Switch the active build target via EditorUserBuildSettings.SwitchActiveBuildTarget
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `target` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `buildTarget` | `string` | `` |
| `buildTargetGroup` | `string` | `` |

---

### Commands.List

- 原始说明：List all available commands with their metadata
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `commands` | `CommandInfo[]` | `` |

**嵌套类型详情**

- 类型：`CommandInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Protocol.CommandInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `description` | `string` | `` |
| `builtIn` | `bool` | `` |
| `module` | `string` | `` |
| `requestFields` | `CommandFieldInfo[]` | `` |
| `responseFields` | `CommandFieldInfo[]` | `` |
| `requestTypeDetails` | `CommandTypeDetail[]` | `` |
| `responseTypeDetails` | `CommandTypeDetail[]` | `` |

- 类型：`CommandFieldInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Protocol.CommandFieldInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `type` | `string` | `` |
| `typeId` | `string` | `` |
| `defaultValue` | `string` | `` |

- 类型：`CommandTypeDetail`
- TypeId：`UniCli.Server.Editor:UniCli.Protocol.CommandTypeDetail`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `typeName` | `string` | `` |
| `typeId` | `string` | `` |
| `fields` | `CommandFieldInfo[]` | `` |

---

### Compile

- 原始说明：Trigger script compilation and return results with error details
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `errorCount` | `int` | `` |
| `warningCount` | `int` | `` |
| `errors` | `CompileIssue[]` | `` |
| `warnings` | `CompileIssue[]` | `` |

**嵌套类型详情**

- 类型：`CompileIssue`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.CompileIssue`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `message` | `string` | `` |
| `file` | `string` | `` |
| `line` | `int` | `` |

---

### Console.Clear

- 原始说明：Clear Unity Editor console logs
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `clearedCount` | `int` | `` |

---

### Console.GetLog

- 原始说明：Retrieve Unity Editor console logs with optional filtering
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `logType` | `string` | `All` |
| `searchText` | `string` | `` |
| `maxCount` | `int` | `100` |
| `stackTraceLines` | `int` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `logs` | `LogEntry[]` | `` |
| `totalCount` | `int` | `` |
| `displayedCount` | `int` | `` |

**嵌套类型详情**

- 类型：`LogEntry`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.LogEntry`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `message` | `string` | `` |
| `stackTrace` | `string` | `` |
| `type` | `string` | `` |
| `timestamp` | `string` | `` |

---

### EditorSettings.Inspect

- 原始说明：Inspect all EditorSettings values
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `unityRemoteDevice` | `string` | `` |
| `unityRemoteCompression` | `string` | `` |
| `unityRemoteResolution` | `string` | `` |
| `unityRemoteJoystickSource` | `string` | `` |
| `serializationMode` | `string` | `` |
| `lineEndingsForNewScripts` | `string` | `` |
| `defaultBehaviorMode` | `string` | `` |
| `prefabModeAllowAutoSave` | `bool` | `` |
| `spritePackerMode` | `string` | `` |
| `spritePackerPaddingPower` | `int` | `` |
| `etcTextureCompressorBehavior` | `int` | `` |
| `etcTextureFastCompressor` | `int` | `` |
| `etcTextureNormalCompressor` | `int` | `` |
| `etcTextureBestCompressor` | `int` | `` |
| `enableTextureStreamingInEditMode` | `bool` | `` |
| `enableTextureStreamingInPlayMode` | `bool` | `` |
| `asyncShaderCompilation` | `bool` | `` |
| `cachingShaderPreprocessor` | `bool` | `` |
| `projectGenerationRootNamespace` | `string` | `` |
| `useLegacyProbeSampleCount` | `bool` | `` |
| `enableCookiesInLightmapper` | `bool` | `` |
| `enableEnlightenBakedGI` | `bool` | `` |
| `enterPlayModeOptionsEnabled` | `bool` | `` |
| `enterPlayModeOptions` | `string` | `` |
| `serializeInlineMappingsOnOneLine` | `bool` | `` |
| `assetPipelineMode` | `string` | `` |
| `cacheServerMode` | `string` | `` |
| `refreshImportMode` | `string` | `` |
| `cacheServerEndpoint` | `string` | `` |
| `cacheServerNamespacePrefix` | `string` | `` |
| `cacheServerEnableDownload` | `bool` | `` |
| `cacheServerEnableUpload` | `bool` | `` |
| `cacheServerEnableAuth` | `bool` | `` |
| `cacheServerEnableTls` | `bool` | `` |
| `cacheServerValidationMode` | `string` | `` |
| `cacheServerDownloadBatchSize` | `int` | `` |
| `gameObjectNamingDigits` | `int` | `` |
| `gameObjectNamingScheme` | `string` | `` |
| `assetNamingUsesSpace` | `bool` | `` |

---

### EditorUserBuildSettings.Inspect

- 原始说明：Inspect all EditorUserBuildSettings values
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `selectedBuildTargetGroup` | `string` | `` |
| `selectedQnxOsVersion` | `string` | `` |
| `selectedQnxArchitecture` | `string` | `` |
| `selectedEmbeddedLinuxArchitecture` | `string` | `` |
| `remoteDeviceInfo` | `bool` | `` |
| `remoteDeviceAddress` | `string` | `` |
| `remoteDeviceUsername` | `string` | `` |
| `remoteDeviceExports` | `string` | `` |
| `pathOnRemoteDevice` | `string` | `` |
| `selectedStandaloneTarget` | `string` | `` |
| `standaloneBuildSubtarget` | `string` | `` |
| `ps4BuildSubtarget` | `string` | `` |
| `ps4HardwareTarget` | `string` | `` |
| `explicitNullChecks` | `bool` | `` |
| `explicitDivideByZeroChecks` | `bool` | `` |
| `explicitArrayBoundsChecks` | `bool` | `` |
| `needSubmissionMaterials` | `bool` | `` |
| `forceInstallation` | `bool` | `` |
| `movePackageToDiscOuterEdge` | `bool` | `` |
| `compressFilesInPackage` | `bool` | `` |
| `buildScriptsOnly` | `bool` | `` |
| `xboxBuildSubtarget` | `string` | `` |
| `streamingInstallLaunchRange` | `int` | `` |
| `xboxOneDeployMethod` | `string` | `` |
| `xboxOneDeployDrive` | `string` | `` |
| `xboxOneAdditionalDebugPorts` | `string` | `` |
| `xboxOneRebootIfDeployFailsAndRetry` | `bool` | `` |
| `androidBuildSubtarget` | `string` | `` |
| `webGLBuildSubtarget` | `string` | `` |
| `androidETC2Fallback` | `string` | `` |
| `androidBuildSystem` | `string` | `` |
| `androidBuildType` | `string` | `` |
| `androidCreateSymbols` | `string` | `` |
| `wsaUWPBuildType` | `string` | `` |
| `wsaUWPSDK` | `string` | `` |
| `wsaMinUWPSDK` | `string` | `` |
| `wsaArchitecture` | `string` | `` |
| `wsaUWPVisualStudioVersion` | `string` | `` |
| `windowsDevicePortalAddress` | `string` | `` |
| `windowsDevicePortalUsername` | `string` | `` |
| `windowsDevicePortalPassword` | `string` | `` |
| `wsaBuildAndRunDeployTarget` | `string` | `` |
| `overrideMaxTextureSize` | `int` | `` |
| `overrideTextureCompression` | `string` | `` |
| `activeBuildTarget` | `string` | `` |
| `development` | `bool` | `` |
| `connectProfiler` | `bool` | `` |
| `buildWithDeepProfilingSupport` | `bool` | `` |
| `allowDebugging` | `bool` | `` |
| `waitForPlayerConnection` | `bool` | `` |
| `exportAsGoogleAndroidProject` | `bool` | `` |
| `buildAppBundle` | `bool` | `` |
| `symlinkSources` | `bool` | `` |
| `iOSXcodeBuildConfig` | `string` | `` |
| `macOSXcodeBuildConfig` | `string` | `` |
| `switchCreateRomFile` | `bool` | `` |
| `switchEnableRomCompression` | `bool` | `` |
| `switchSaveADF` | `bool` | `` |
| `switchRomCompressionType` | `string` | `` |
| `switchRomCompressionLevel` | `int` | `` |
| `switchRomCompressionConfig` | `string` | `` |
| `switchNVNGraphicsDebugger` | `bool` | `` |
| `generateNintendoSwitchShaderInfo` | `bool` | `` |
| `switchNVNShaderDebugging` | `bool` | `` |
| `switchNVNAftermath` | `bool` | `` |
| `switchNVNDrawValidation_Light` | `bool` | `` |
| `switchNVNDrawValidation_Heavy` | `bool` | `` |
| `switchEnableMemoryTracker` | `bool` | `` |
| `switchWaitForMemoryTrackerOnStartup` | `bool` | `` |
| `switchEnableDebugPad` | `bool` | `` |
| `switchRedirectWritesToHostMount` | `bool` | `` |
| `switchHTCSScriptDebugging` | `bool` | `` |
| `switchUseLegacyNvnPoolAllocator` | `bool` | `` |
| `switchEnableUnpublishableErrors` | `bool` | `` |
| `installInBuildFolder` | `bool` | `` |
| `waitForManagedDebugger` | `bool` | `` |
| `managedDebuggerFixedPort` | `int` | `` |

---

### Eval

- 原始说明：Compile and execute C# code dynamically in the Unity Editor context
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `code` | `string` | `` |
| `declarations` | `string` | `` |

**响应字段**

无

---

### Menu.Execute

- 原始说明：Execute a Unity Editor menu item by path
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `menuItemPath` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `executed` | `bool` | `` |
| `menuItemPath` | `string` | `` |

---

### Menu.List

- 原始说明：List available Unity Editor menu items with filtering
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `filterText` | `string` | `` |
| `filterType` | `string` | `contains` |
| `maxCount` | `int` | `200` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `items` | `MenuItemInfo[]` | `` |
| `totalCount` | `int` | `` |
| `filteredCount` | `int` | `` |

**嵌套类型详情**

- 类型：`MenuItemInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.MenuItemInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `priority` | `int` | `` |
| `methodName` | `string` | `` |
| `typeName` | `string` | `` |

---

### Module.Disable

- 原始说明：Disable a module and reload the command dispatcher
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |

**响应字段**

无

---

### Module.Enable

- 原始说明：Enable a module and reload the command dispatcher
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |

**响应字段**

无

---

### Module.List

- 原始说明：List all available modules and their enabled status
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `modules` | `ModuleInfo[]` | `` |

**嵌套类型详情**

- 类型：`ModuleInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.ModuleInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `description` | `string` | `` |
| `enabled` | `bool` | `` |

---

### PackageManager.Add

- 原始说明：Add a package by identifier (e.g., com.unity.foo@1.2.3 or git URL)
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `identifier` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `displayName` | `string` | `` |
| `version` | `string` | `` |
| `source` | `string` | `` |

---

### PackageManager.GetInfo

- 原始说明：Get detailed information about a specific installed package
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `displayName` | `string` | `` |
| `version` | `string` | `` |
| `source` | `string` | `` |
| `description` | `string` | `` |
| `isDirectDependency` | `bool` | `` |
| `latestVersion` | `string` | `` |
| `dependencies` | `string[]` | `` |

---

### PackageManager.List

- 原始说明：List all installed packages in the project
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `packages` | `PackageEntry[]` | `` |
| `totalCount` | `int` | `` |

**嵌套类型详情**

- 类型：`PackageEntry`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PackageEntry`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `displayName` | `string` | `` |
| `version` | `string` | `` |
| `source` | `string` | `` |
| `isDirectDependency` | `bool` | `` |

---

### PackageManager.Remove

- 原始说明：Remove a package by name (e.g., com.unity.cinemachine)
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |

---

### PackageManager.Search

- 原始说明：Search for packages in the Unity registry
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `query` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `packages` | `PackageSearchEntry[]` | `` |
| `totalCount` | `int` | `` |

**嵌套类型详情**

- 类型：`PackageSearchEntry`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PackageSearchEntry`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `displayName` | `string` | `` |
| `version` | `string` | `` |
| `description` | `string` | `` |

---

### PackageManager.Update

- 原始说明：Update a package to a specific version or the latest version
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `version` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `displayName` | `string` | `` |
| `previousVersion` | `string` | `` |
| `version` | `string` | `` |
| `source` | `string` | `` |

---

### PlayMode.Enter

- 原始说明：Enter play mode in Unity Editor
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

无

---

### PlayMode.Exit

- 原始说明：Exit play mode in Unity Editor
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

无

---

### PlayMode.Pause

- 原始说明：Toggle pause state in play mode
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

无

---

### PlayMode.Status

- 原始说明：Get the current play mode state
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `isPlaying` | `bool` | `` |
| `isPaused` | `bool` | `` |
| `isCompiling` | `bool` | `` |

---

### PlayMode.Step

- 原始说明：Advance one frame in play mode
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

无

---

### PlayerSettings.Inspect

- 原始说明：Inspect all PlayerSettings values
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `companyName` | `string` | `` |
| `productName` | `string` | `` |
| `colorSpace` | `string` | `` |
| `defaultScreenWidth` | `int` | `` |
| `defaultScreenHeight` | `int` | `` |
| `defaultWebScreenWidth` | `int` | `` |
| `defaultWebScreenHeight` | `int` | `` |
| `defaultIsNativeResolution` | `bool` | `` |
| `macRetinaSupport` | `bool` | `` |
| `runInBackground` | `bool` | `` |
| `captureSingleScreen` | `bool` | `` |
| `usePlayerLog` | `bool` | `` |
| `resizableWindow` | `bool` | `` |
| `resetResolutionOnWindowResize` | `bool` | `` |
| `bakeCollisionMeshes` | `bool` | `` |
| `useMacAppStoreValidation` | `bool` | `` |
| `dedicatedServerOptimizations` | `bool` | `` |
| `fullScreenMode` | `string` | `` |
| `enable360StereoCapture` | `bool` | `` |
| `stereoRenderingPath` | `string` | `` |
| `enableFrameTimingStats` | `bool` | `` |
| `enableOpenGLProfilerGPURecorders` | `bool` | `` |
| `allowHDRDisplaySupport` | `bool` | `` |
| `useHDRDisplay` | `bool` | `` |
| `hdrBitDepth` | `string` | `` |
| `visibleInBackground` | `bool` | `` |
| `allowFullscreenSwitch` | `bool` | `` |
| `forceSingleInstance` | `bool` | `` |
| `useFlipModelSwapchain` | `bool` | `` |
| `openGLRequireES31` | `bool` | `` |
| `openGLRequireES31AEP` | `bool` | `` |
| `openGLRequireES32` | `bool` | `` |
| `spriteBatchVertexThreshold` | `int` | `` |
| `suppressCommonWarnings` | `bool` | `` |
| `allowUnsafeCode` | `bool` | `` |
| `gcIncremental` | `bool` | `` |
| `keystorePass` | `string` | `` |
| `keyaliasPass` | `string` | `` |
| `gpuSkinning` | `bool` | `` |
| `graphicsJobs` | `bool` | `` |
| `graphicsJobMode` | `string` | `` |
| `xboxPIXTextureCapture` | `bool` | `` |
| `xboxEnableAvatar` | `bool` | `` |
| `xboxOneResolution` | `int` | `` |
| `enableInternalProfiler` | `bool` | `` |
| `actionOnDotNetUnhandledException` | `string` | `` |
| `logObjCUncaughtExceptions` | `bool` | `` |
| `enableCrashReportAPI` | `bool` | `` |
| `applicationIdentifier` | `string` | `` |
| `visionOSBundleVersion` | `string` | `` |
| `tvOSBundleVersion` | `string` | `` |
| `bundleVersion` | `string` | `` |
| `statusBarHidden` | `bool` | `` |
| `stripEngineCode` | `bool` | `` |
| `defaultInterfaceOrientation` | `string` | `` |
| `allowedAutorotateToPortrait` | `bool` | `` |
| `allowedAutorotateToPortraitUpsideDown` | `bool` | `` |
| `allowedAutorotateToLandscapeRight` | `bool` | `` |
| `allowedAutorotateToLandscapeLeft` | `bool` | `` |
| `useAnimatedAutorotation` | `bool` | `` |
| `use32BitDisplayBuffer` | `bool` | `` |
| `preserveFramebufferAlpha` | `bool` | `` |
| `stripUnusedMeshComponents` | `bool` | `` |
| `strictShaderVariantMatching` | `bool` | `` |
| `mipStripping` | `bool` | `` |
| `advancedLicense` | `bool` | `` |
| `aotOptions` | `string` | `` |
| `cursorHotspot` | `Vector2` | `` |
| `accelerometerFrequency` | `int` | `` |
| `mTRendering` | `bool` | `` |
| `muteOtherAudioSources` | `bool` | `` |
| `audioSpatialExperience` | `string` | `` |
| `legacyClampBlendShapeWeights` | `bool` | `` |
| `enableMetalAPIValidation` | `bool` | `` |
| `windowsGamepadBackendHint` | `string` | `` |
| `insecureHttpOption` | `string` | `` |
| `vulkanEnableSetSRGBWrite` | `bool` | `` |
| `vulkanNumSwapchainBuffers` | `UInt32` | `` |
| `vulkanEnableLateAcquireNextImage` | `bool` | `` |
| `vulkanEnablePreTransform` | `bool` | `` |
| `android` | `AndroidSettings` | `` |
| `iOS` | `iOSSettings` | `` |
| `embeddedLinux` | `EmbeddedLinuxSettings` | `` |
| `lumin` | `LuminSettings` | `` |
| `macOS` | `macOSSettings` | `` |
| `pS4` | `PS4Settings` | `` |
| `qNX` | `QNXSettings` | `` |
| `splashScreen` | `SplashScreenSettings` | `` |
| `switch` | `SwitchSettings` | `` |
| `tvOS` | `tvOSSettings` | `` |
| `visionOS` | `VisionOSSettings` | `` |
| `webGL` | `WebGLSettings` | `` |
| `wSA` | `WSASettings` | `` |
| `xboxOne` | `XboxOneSettings` | `` |

**嵌套类型详情**

- 类型：`AndroidSettings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.AndroidSettings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `disableDepthAndStencilBuffers` | `bool` | `` |
| `defaultWindowWidth` | `int` | `` |
| `defaultWindowHeight` | `int` | `` |
| `minimumWindowWidth` | `int` | `` |
| `minimumWindowHeight` | `int` | `` |
| `resizableWindow` | `bool` | `` |
| `fullscreenMode` | `string` | `` |
| `autoRotationBehavior` | `string` | `` |
| `bundleVersionCode` | `int` | `` |
| `minSdkVersion` | `string` | `` |
| `targetSdkVersion` | `string` | `` |
| `preferredInstallLocation` | `string` | `` |
| `forceInternetPermission` | `bool` | `` |
| `forceSDCardPermission` | `bool` | `` |
| `androidTVCompatibility` | `bool` | `` |
| `androidIsGame` | `bool` | `` |
| `aRCoreEnabled` | `bool` | `` |
| `chromeosInputEmulation` | `bool` | `` |
| `targetArchitectures` | `string` | `` |
| `enableArmv9SecurityFeatures` | `bool` | `` |
| `buildApkPerCpuArchitecture` | `bool` | `` |
| `androidTargetDevices` | `string` | `` |
| `splashScreenScale` | `string` | `` |
| `useCustomKeystore` | `bool` | `` |
| `keystoreName` | `string` | `` |
| `keystorePass` | `string` | `` |
| `keyaliasName` | `string` | `` |
| `keyaliasPass` | `string` | `` |
| `licenseVerification` | `bool` | `` |
| `useAPKExpansionFiles` | `bool` | `` |
| `showActivityIndicatorOnLoading` | `string` | `` |
| `blitType` | `string` | `` |
| `maxAspectRatio` | `float` | `` |
| `startInFullscreen` | `bool` | `` |
| `renderOutsideSafeArea` | `bool` | `` |
| `minifyRelease` | `bool` | `` |
| `minifyDebug` | `bool` | `` |
| `optimizedFramePacing` | `bool` | `` |
| `predictiveBackSupport` | `bool` | `` |

- 类型：`iOSSettings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.iOSSettings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `applicationDisplayName` | `string` | `` |
| `buildNumber` | `string` | `` |
| `disableDepthAndStencilBuffers` | `bool` | `` |
| `scriptCallOptimization` | `string` | `` |
| `sdkVersion` | `string` | `` |
| `simulatorSdkArchitecture` | `string` | `` |
| `targetOSVersionString` | `string` | `` |
| `targetDevice` | `string` | `` |
| `prerenderedIcon` | `bool` | `` |
| `requiresPersistentWiFi` | `bool` | `` |
| `requiresFullScreen` | `bool` | `` |
| `statusBarStyle` | `string` | `` |
| `deferSystemGesturesMode` | `string` | `` |
| `hideHomeButton` | `bool` | `` |
| `appInBackgroundBehavior` | `string` | `` |
| `backgroundModes` | `string` | `` |
| `forceHardShadowsOnMetal` | `bool` | `` |
| `appleDeveloperTeamID` | `string` | `` |
| `iOSManualProvisioningProfileID` | `string` | `` |
| `tvOSManualProvisioningProfileID` | `string` | `` |
| `visionOSManualProvisioningProfileID` | `string` | `` |
| `tvOSManualProvisioningProfileType` | `string` | `` |
| `iOSManualProvisioningProfileType` | `string` | `` |
| `visionOSManualProvisioningProfileType` | `string` | `` |
| `appleEnableAutomaticSigning` | `bool` | `` |
| `cameraUsageDescription` | `string` | `` |
| `locationUsageDescription` | `string` | `` |
| `microphoneUsageDescription` | `string` | `` |
| `showActivityIndicatorOnLoading` | `string` | `` |
| `useOnDemandResources` | `bool` | `` |

- 类型：`EmbeddedLinuxSettings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.EmbeddedLinuxSettings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `playerDataPath` | `string` | `` |
| `forceSRGBBlit` | `bool` | `` |
| `enableGamepadInput` | `bool` | `` |
| `hmiLogStartupTiming` | `bool` | `` |

- 类型：`LuminSettings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.LuminSettings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `iconModelFolderPath` | `string` | `` |
| `iconPortalFolderPath` | `string` | `` |
| `certificatePath` | `string` | `` |
| `signPackage` | `bool` | `` |
| `isChannelApp` | `bool` | `` |
| `versionCode` | `int` | `` |
| `versionName` | `string` | `` |

- 类型：`macOSSettings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.macOSSettings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `buildNumber` | `string` | `` |
| `applicationCategoryType` | `string` | `` |
| `cameraUsageDescription` | `string` | `` |
| `microphoneUsageDescription` | `string` | `` |
| `bluetoothUsageDescription` | `string` | `` |
| `targetOSVersion` | `string` | `` |

- 类型：`PS4Settings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.PS4Settings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `npTrophyPackPath` | `string` | `` |
| `npAgeRating` | `int` | `` |
| `npTitleSecret` | `string` | `` |
| `parentalLevel` | `int` | `` |
| `applicationParameter1` | `int` | `` |
| `applicationParameter2` | `int` | `` |
| `applicationParameter3` | `int` | `` |
| `applicationParameter4` | `int` | `` |
| `passcode` | `string` | `` |
| `monoEnv` | `string` | `` |
| `playerPrefsSupport` | `bool` | `` |
| `restrictedAudioUsageRights` | `bool` | `` |
| `useResolutionFallback` | `bool` | `` |
| `contentID` | `string` | `` |
| `category` | `string` | `` |
| `appType` | `int` | `` |
| `masterVersion` | `string` | `` |
| `appVersion` | `string` | `` |
| `remotePlayKeyAssignment` | `string` | `` |
| `remotePlayKeyMappingDir` | `string` | `` |
| `playTogetherPlayerCount` | `int` | `` |
| `enterButtonAssignment` | `string` | `` |
| `paramSfxPath` | `string` | `` |
| `videoOutPixelFormat` | `int` | `` |
| `videoOutInitialWidth` | `int` | `` |
| `sdkOverride` | `string` | `` |
| `videoOutBaseModeInitialWidth` | `int` | `` |
| `videoOutReprojectionRate` | `int` | `` |
| `pronunciationXMLPath` | `string` | `` |
| `pronunciationSIGPath` | `string` | `` |
| `backgroundImagePath` | `string` | `` |
| `startupImagePath` | `string` | `` |
| `startupImagesFolder` | `string` | `` |
| `iconImagesFolder` | `string` | `` |
| `saveDataImagePath` | `string` | `` |
| `bGMPath` | `string` | `` |
| `shareFilePath` | `string` | `` |
| `shareOverlayImagePath` | `string` | `` |
| `privacyGuardImagePath` | `string` | `` |
| `extraSceSysFile` | `string` | `` |
| `patchDayOne` | `bool` | `` |
| `patchPkgPath` | `string` | `` |
| `patchLatestPkgPath` | `string` | `` |
| `patchChangeinfoPath` | `string` | `` |
| `nPtitleDatPath` | `string` | `` |
| `pnSessions` | `bool` | `` |
| `pnPresence` | `bool` | `` |
| `pnFriends` | `bool` | `` |
| `pnGameCustomData` | `bool` | `` |
| `downloadDataSize` | `int` | `` |
| `garlicHeapSize` | `int` | `` |
| `proGarlicHeapSize` | `int` | `` |
| `reprojectionSupport` | `bool` | `` |
| `useAudio3dBackend` | `bool` | `` |
| `audio3dVirtualSpeakerCount` | `int` | `` |
| `useLowGarlicFragmentationMode` | `bool` | `` |
| `socialScreenEnabled` | `int` | `` |
| `attribUserManagement` | `bool` | `` |
| `attribMoveSupport` | `bool` | `` |
| `attrib3DSupport` | `bool` | `` |
| `attribShareSupport` | `bool` | `` |
| `attribExclusiveVR` | `bool` | `` |
| `disableAutoHideSplash` | `bool` | `` |
| `attribCpuUsage` | `int` | `` |
| `videoRecordingFeaturesUsed` | `bool` | `` |
| `contentSearchFeaturesUsed` | `bool` | `` |
| `attribEyeToEyeDistanceSettingVR` | `string` | `` |
| `enableApplicationExit` | `bool` | `` |
| `resetTempFolder` | `bool` | `` |
| `playerPrefsMaxSize` | `int` | `` |
| `attribVROutputEnabled` | `bool` | `` |
| `compatibilityPS5` | `bool` | `` |
| `allowPS5Detection` | `bool` | `` |
| `gpu800MHz` | `bool` | `` |

- 类型：`QNXSettings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.QNXSettings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `playerDataPath` | `string` | `` |
| `forceSRGBBlit` | `bool` | `` |

- 类型：`SplashScreenSettings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.SplashScreenSettings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `animationMode` | `string` | `` |
| `animationBackgroundZoom` | `float` | `` |
| `animationLogoZoom` | `float` | `` |
| `blurBackgroundImage` | `bool` | `` |
| `backgroundColor` | `Color` | `` |
| `drawMode` | `string` | `` |
| `overlayOpacity` | `float` | `` |
| `show` | `bool` | `` |
| `showUnityLogo` | `bool` | `` |
| `unityLogoStyle` | `string` | `` |

- 类型：`SwitchSettings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.SwitchSettings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `socketMemoryPoolSize` | `int` | `` |
| `socketAllocatorPoolSize` | `int` | `` |
| `socketConcurrencyLimit` | `int` | `` |
| `useSwitchCPUProfiler` | `bool` | `` |
| `enableFileSystemTrace` | `bool` | `` |
| `switchLTOSetting` | `int` | `` |
| `systemResourceMemory` | `int` | `` |
| `queueCommandMemory` | `int` | `` |
| `defaultSwitchQueueCommandMemory` | `int` | `` |
| `minimumSwitchQueueCommandMemory` | `int` | `` |
| `queueControlMemory` | `int` | `` |
| `defaultSwitchQueueControlMemory` | `int` | `` |
| `minimumSwitchQueueControlMemory` | `int` | `` |
| `queueComputeMemory` | `int` | `` |
| `defaultSwitchQueueComputeMemory` | `int` | `` |
| `nVNShaderPoolsGranularity` | `int` | `` |
| `nVNDefaultPoolsGranularity` | `int` | `` |
| `nVNOtherPoolsGranularity` | `int` | `` |
| `gpuScratchPoolGranularity` | `int` | `` |
| `allowGpuScratchShrinking` | `bool` | `` |
| `nVNMaxPublicTextureIDCount` | `int` | `` |
| `nVNMaxPublicSamplerIDCount` | `int` | `` |
| `nVNGraphicsFirmwareMemory` | `int` | `` |
| `defaultSwitchNVNGraphicsFirmwareMemory` | `int` | `` |
| `minimumSwitchNVNGraphicsFirmwareMemory` | `int` | `` |
| `maximumSwitchNVNGraphicsFirmwareMemory` | `int` | `` |
| `switchMaxWorkerMultiple` | `int` | `` |
| `screenResolutionBehavior` | `string` | `` |
| `nMETAOverride` | `string` | `` |
| `nMETAOverrideFullPath` | `string` | `` |
| `applicationID` | `string` | `` |
| `nsoDependencies` | `string` | `` |
| `manualHTMLPath` | `string` | `` |
| `accessibleURLPath` | `string` | `` |
| `legalInformationPath` | `string` | `` |
| `mainThreadStackSize` | `int` | `` |
| `presenceGroupId` | `string` | `` |
| `logoHandling` | `string` | `` |
| `releaseVersion` | `string` | `` |
| `displayVersion` | `string` | `` |
| `startupUserAccount` | `string` | `` |
| `supportedLanguages` | `int` | `` |
| `logoType` | `string` | `` |
| `applicationErrorCodeCategory` | `string` | `` |
| `userAccountSaveDataSize` | `int` | `` |
| `userAccountSaveDataJournalSize` | `int` | `` |
| `applicationAttribute` | `string` | `` |
| `cardSpecSize` | `int` | `` |
| `cardSpecClock` | `int` | `` |
| `ratingsMask` | `int` | `` |
| `isUnderParentalControl` | `bool` | `` |
| `isScreenshotEnabled` | `bool` | `` |
| `isVideoCapturingEnabled` | `bool` | `` |
| `isRuntimeAddOnContentInstallEnabled` | `bool` | `` |
| `isDataLossConfirmationEnabled` | `bool` | `` |
| `isUserAccountLockEnabled` | `bool` | `` |
| `supportedNpadStyles` | `string` | `` |
| `nativeFsCacheSize` | `int` | `` |
| `isHoldTypeHorizontal` | `bool` | `` |
| `supportedNpadCount` | `int` | `` |
| `enableTouchScreen` | `bool` | `` |
| `socketConfigEnabled` | `bool` | `` |
| `tcpInitialSendBufferSize` | `int` | `` |
| `tcpInitialReceiveBufferSize` | `int` | `` |
| `tcpAutoSendBufferSizeMax` | `int` | `` |
| `tcpAutoReceiveBufferSizeMax` | `int` | `` |
| `udpSendBufferSize` | `int` | `` |
| `udpReceiveBufferSize` | `int` | `` |
| `socketBufferEfficiency` | `int` | `` |
| `socketInitializeEnabled` | `bool` | `` |
| `networkInterfaceManagerInitializeEnabled` | `bool` | `` |
| `disableHTCSPlayerConnection` | `bool` | `` |
| `useNewStyleFilepaths` | `bool` | `` |
| `switchUseLegacyFmodPriorities` | `bool` | `` |
| `switchUseMicroSleepForYield` | `bool` | `` |
| `switchMicroSleepForYieldTime` | `int` | `` |
| `switchEnableRamDiskSupport` | `bool` | `` |
| `switchRamDiskSpaceSize` | `int` | `` |

- 类型：`tvOSSettings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.tvOSSettings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `sdkVersion` | `string` | `` |
| `simulatorSdkArchitecture` | `string` | `` |
| `buildNumber` | `string` | `` |
| `targetOSVersionString` | `string` | `` |
| `requireExtendedGameController` | `bool` | `` |

- 类型：`VisionOSSettings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.VisionOSSettings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `sdkVersion` | `string` | `` |
| `buildNumber` | `string` | `` |
| `targetOSVersionString` | `string` | `` |

- 类型：`WebGLSettings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.WebGLSettings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `memorySize` | `int` | `` |
| `exceptionSupport` | `string` | `` |
| `dataCaching` | `bool` | `` |
| `emscriptenArgs` | `string` | `` |
| `modulesDirectory` | `string` | `` |
| `template` | `string` | `` |
| `analyzeBuildSize` | `bool` | `` |
| `useEmbeddedResources` | `bool` | `` |
| `threadsSupport` | `bool` | `` |
| `linkerTarget` | `string` | `` |
| `compressionFormat` | `string` | `` |
| `nameFilesAsHashes` | `bool` | `` |
| `debugSymbolMode` | `string` | `` |
| `showDiagnostics` | `bool` | `` |
| `decompressionFallback` | `bool` | `` |
| `wasmArithmeticExceptions` | `string` | `` |
| `initialMemorySize` | `int` | `` |
| `maximumMemorySize` | `int` | `` |
| `memoryGrowthMode` | `string` | `` |
| `linearMemoryGrowthStep` | `int` | `` |
| `geometricMemoryGrowthStep` | `float` | `` |
| `memoryGeometricGrowthCap` | `int` | `` |
| `powerPreference` | `string` | `` |

- 类型：`WSASettings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.WSASettings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `transparentSwapchain` | `bool` | `` |
| `packageName` | `string` | `` |
| `certificatePath` | `string` | `` |
| `certificateSubject` | `string` | `` |
| `certificateIssuer` | `string` | `` |
| `applicationDescription` | `string` | `` |
| `tileShortName` | `string` | `` |
| `tileShowName` | `string` | `` |
| `mediumTileShowName` | `bool` | `` |
| `largeTileShowName` | `bool` | `` |
| `wideTileShowName` | `bool` | `` |
| `defaultTileSize` | `string` | `` |
| `tileForegroundText` | `string` | `` |
| `tileBackgroundColor` | `Color` | `` |
| `inputSource` | `string` | `` |
| `supportStreamingInstall` | `bool` | `` |
| `lastRequiredScene` | `int` | `` |
| `syncCapabilities` | `bool` | `` |
| `vcxProjDefaultLanguage` | `string` | `` |

- 类型：`XboxOneSettings`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PlayerSettingsInspectResponse.XboxOneSettings`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `xTitleMemory` | `int` | `` |
| `defaultLoggingLevel` | `string` | `` |
| `productId` | `string` | `` |
| `updateKey` | `string` | `` |
| `contentId` | `string` | `` |
| `titleId` | `string` | `` |
| `sCID` | `string` | `` |
| `enableVariableGPU` | `bool` | `` |
| `presentImmediateThreshold` | `UInt32` | `` |
| `enable7thCore` | `bool` | `` |
| `disableKinectGpuReservation` | `bool` | `` |
| `enablePIXSampling` | `bool` | `` |
| `gameOsOverridePath` | `string` | `` |
| `packagingOverridePath` | `string` | `` |
| `packagingEncryption` | `string` | `` |
| `packageUpdateGranularity` | `string` | `` |
| `overrideIdentityName` | `string` | `` |
| `overrideIdentityPublisher` | `string` | `` |
| `appManifestOverridePath` | `string` | `` |
| `isContentPackage` | `bool` | `` |
| `enhancedXboxCompatibilityMode` | `bool` | `` |
| `version` | `string` | `` |
| `description` | `string` | `` |
| `persistentLocalStorageSize` | `UInt32` | `` |
| `enableTypeOptimization` | `bool` | `` |
| `monoLoggingLevel` | `int` | `` |

---

### Project.Inspect

- 原始说明：Get Unity project information
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `unityVersion` | `string` | `` |
| `projectPath` | `string` | `` |
| `productName` | `string` | `` |
| `companyName` | `string` | `` |
| `buildTarget` | `string` | `` |
| `isPlaying` | `bool` | `` |
| `processId` | `int` | `` |
| `serverId` | `string` | `` |
| `serverVersion` | `string` | `` |
| `startedAt` | `string` | `` |
| `uptimeSeconds` | `double` | `` |

---

### Screenshot.Capture

- 原始说明：Capture a screenshot of the Game View and save as PNG (requires Play Mode)
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `superSize` | `int` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `width` | `int` | `` |
| `height` | `int` | `` |
| `size` | `Int64` | `` |

---

### Selection.Frame

- 原始说明：Frame an asset in Project view or a GameObject in Scene view
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `instanceId` | `int` | `` |
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `targetName` | `string` | `` |
| `targetType` | `string` | `` |
| `framedIn` | `string` | `` |

---

### Selection.Get

- 原始说明：Get the current selection in the editor
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjects` | `SelectedGameObjectInfo[]` | `` |
| `assets` | `SelectedAssetInfo[]` | `` |

**嵌套类型详情**

- 类型：`SelectedGameObjectInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.SelectedGameObjectInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `name` | `string` | `` |
| `path` | `string` | `` |

- 类型：`SelectedAssetInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.SelectedAssetInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `typeName` | `string` | `` |
| `name` | `string` | `` |

---

### Selection.Ping

- 原始说明：Ping an asset or GameObject in the editor without changing selection
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `instanceId` | `int` | `` |
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `targetName` | `string` | `` |
| `targetType` | `string` | `` |

---

### Selection.SetAsset

- 原始说明：Select an asset by path
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `typeName` | `string` | `` |
| `name` | `string` | `` |

---

### Selection.SetAssets

- 原始说明：Select multiple assets by paths
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPaths` | `string[]` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `selected` | `SelectedAssetInfo[]` | `` |
| `notFound` | `string[]` | `` |

**嵌套类型详情**

- 类型：`SelectedAssetInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.SelectedAssetInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `typeName` | `string` | `` |
| `name` | `string` | `` |

---

### Selection.SetGameObject

- 原始说明：Select a GameObject by path
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `instanceId` | `int` | `` |

---

### Selection.SetGameObjects

- 原始说明：Select multiple GameObjects by paths
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `paths` | `string[]` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `selected` | `SelectedGameObjectInfo[]` | `` |
| `notFound` | `string[]` | `` |

**嵌套类型详情**

- 类型：`SelectedGameObjectInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.SelectedGameObjectInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `name` | `string` | `` |
| `path` | `string` | `` |

---

### TestRunner.List

- 原始说明：List available tests for EditMode or PlayMode
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `mode` | `string` | `EditMode` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `mode` | `string` | `` |
| `total` | `int` | `` |
| `tests` | `TestListEntry[]` | `` |

**嵌套类型详情**

- 类型：`TestListEntry`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.TestListEntry`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `fullName` | `string` | `` |
| `name` | `string` | `` |
| `categories` | `string[]` | `` |

---

### TestRunner.RunEditMode

- 原始说明：Run EditMode tests with optional name/assembly filter
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `testNames` | `string[]` | `` |
| `groupNames` | `string[]` | `` |
| `categories` | `string[]` | `` |
| `assemblies` | `string[]` | `` |
| `resultFilter` | `string` | `failures` |
| `stackTraceLines` | `int` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `passed` | `int` | `` |
| `failed` | `int` | `` |
| `skipped` | `int` | `` |
| `total` | `int` | `` |
| `results` | `TestResult[]` | `` |

**嵌套类型详情**

- 类型：`TestResult`
- TypeId：`UniCli.Server.Editor:UniCli.Protocol.TestResult`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `status` | `string` | `` |
| `duration` | `double` | `` |
| `message` | `string` | `` |
| `stackTrace` | `string` | `` |

---

### TestRunner.RunPlayMode

- 原始说明：Run PlayMode tests with optional name/assembly filter
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `testNames` | `string[]` | `` |
| `groupNames` | `string[]` | `` |
| `categories` | `string[]` | `` |
| `assemblies` | `string[]` | `` |
| `resultFilter` | `string` | `failures` |
| `stackTraceLines` | `int` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `passed` | `int` | `` |
| `failed` | `int` | `` |
| `skipped` | `int` | `` |
| `total` | `int` | `` |
| `results` | `TestResult[]` | `` |

**嵌套类型详情**

- 类型：`TestResult`
- TypeId：`UniCli.Server.Editor:UniCli.Protocol.TestResult`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `status` | `string` | `` |
| `duration` | `double` | `` |
| `message` | `string` | `` |
| `stackTrace` | `string` | `` |

---

### Type.Inspect

- 原始说明：Inspect nested types of a given type
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `typeName` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `typeName` | `string` | `` |
| `nestedTypes` | `TypeInspectNestedInfo[]` | `` |
| `count` | `int` | `` |

**嵌套类型详情**

- 类型：`TypeInspectNestedInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.TypeInspectNestedInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `fullName` | `string` | `` |
| `isStatic` | `bool` | `` |
| `isPublic` | `bool` | `` |
| `memberCount` | `int` | `` |

---

### Type.List

- 原始说明：List types derived from a base type or matching a pattern
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `baseType` | `string` | `` |
| `filter` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `types` | `string[]` | `` |
| `count` | `int` | `` |

---

### Window.Create

- 原始说明：Create a new EditorWindow instance by type name
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `typeName` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `typeName` | `string` | `` |
| `instanceId` | `int` | `` |

---

### Window.Focus

- 原始说明：Focus an already-open EditorWindow by type name
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `typeName` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `typeName` | `string` | `` |

---

### Window.FocusHierarchy

- 原始说明：Focus the Unity Hierarchy window
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `typeName` | `string` | `` |

---

### Window.FocusProject

- 原始说明：Focus the Unity Project window
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `typeName` | `string` | `` |

---

### Window.List

- 原始说明：List all available EditorWindow types
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `windows` | `WindowInfo[]` | `` |

**嵌套类型详情**

- 类型：`WindowInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.WindowInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `typeName` | `string` | `` |

---

### Window.Open

- 原始说明：Open an EditorWindow by type name
- 模块：Core/Uncategorized
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `typeName` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `typeName` | `string` | `` |

---

## 动画

### Animator.CrossFade

- 原始说明：Cross-fade to a state on an Animator (requires PlayMode)
- 模块：Animation
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `stateName` | `string` | `` |
| `layer` | `int` | `` |
| `transitionDuration` | `float` | `` |
| `normalizedTime` | `float` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `stateName` | `string` | `` |
| `layer` | `int` | `` |
| `transitionDuration` | `float` | `` |
| `normalizedTime` | `float` | `` |

---

### Animator.Inspect

- 原始说明：Inspect an Animator component (parameters, current state, controller info)
- 模块：Animation
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `gameObjectPath` | `string` | `` |
| `instanceId` | `int` | `` |
| `enabled` | `bool` | `` |
| `controllerAssetPath` | `string` | `` |
| `parameters` | `AnimatorRuntimeParameterInfo[]` | `` |
| `isPlaying` | `bool` | `` |
| `currentStateName` | `string` | `` |
| `currentStateNormalizedTime` | `float` | `` |

**嵌套类型详情**

- 类型：`AnimatorRuntimeParameterInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.AnimatorRuntimeParameterInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `type` | `string` | `` |
| `value` | `string` | `` |

---

### Animator.Play

- 原始说明：Play a state immediately on an Animator (requires PlayMode)
- 模块：Animation
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `stateName` | `string` | `` |
| `layer` | `int` | `` |
| `normalizedTime` | `float` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `stateName` | `string` | `` |
| `layer` | `int` | `` |
| `normalizedTime` | `float` | `` |

---

### Animator.SetController

- 原始说明：Assign an AnimatorController to an Animator component
- 模块：Animation
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `controllerAssetPath` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `gameObjectPath` | `string` | `` |
| `controllerAssetPath` | `string` | `` |

---

### Animator.SetParameter

- 原始说明：Set an Animator parameter value (requires PlayMode)
- 模块：Animation
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `name` | `string` | `` |
| `value` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `name` | `string` | `` |
| `type` | `string` | `` |
| `value` | `string` | `` |

---

### AnimatorController.AddParameter

- 原始说明：Add a parameter to an AnimatorController
- 模块：Animation
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `name` | `string` | `` |
| `type` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `name` | `string` | `` |
| `type` | `string` | `` |
| `parameterCount` | `int` | `` |

---

### AnimatorController.AddState

- 原始说明：Add a state to an AnimatorController layer
- 模块：Animation
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `name` | `string` | `` |
| `layerIndex` | `int` | `` |
| `motionAssetPath` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `name` | `string` | `` |
| `layerIndex` | `int` | `` |
| `motionName` | `string` | `` |
| `stateCount` | `int` | `` |

---

### AnimatorController.AddTransition

- 原始说明：Add a transition between two states in an AnimatorController
- 模块：Animation
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `sourceStateName` | `string` | `` |
| `destinationStateName` | `string` | `` |
| `layerIndex` | `int` | `` |
| `hasExitTime` | `bool` | `` |
| `exitTime` | `float` | `` |
| `duration` | `float` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `sourceStateName` | `string` | `` |
| `destinationStateName` | `string` | `` |
| `layerIndex` | `int` | `` |
| `hasExitTime` | `bool` | `` |
| `exitTime` | `float` | `` |
| `duration` | `float` | `` |

---

### AnimatorController.AddTransitionCondition

- 原始说明：Add a condition to a transition between two states in an AnimatorController
- 模块：Animation
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `sourceStateName` | `string` | `` |
| `destinationStateName` | `string` | `` |
| `layerIndex` | `int` | `` |
| `transitionIndex` | `int` | `` |
| `parameter` | `string` | `` |
| `mode` | `string` | `` |
| `threshold` | `float` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `sourceStateName` | `string` | `` |
| `destinationStateName` | `string` | `` |
| `parameter` | `string` | `` |
| `mode` | `string` | `` |
| `threshold` | `float` | `` |
| `conditionCount` | `int` | `` |

---

### AnimatorController.Create

- 原始说明：Create a new AnimatorController asset
- 模块：Animation
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `layerCount` | `int` | `` |
| `parameterCount` | `int` | `` |

---

### AnimatorController.Inspect

- 原始说明：Inspect an AnimatorController asset (layers, parameters, states)
- 模块：Animation
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `parameters` | `AnimatorParameterInfo[]` | `` |
| `layers` | `AnimatorLayerInfo[]` | `` |

**嵌套类型详情**

- 类型：`AnimatorParameterInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.AnimatorParameterInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `type` | `string` | `` |
| `defaultFloat` | `float` | `` |
| `defaultInt` | `int` | `` |
| `defaultBool` | `bool` | `` |

- 类型：`AnimatorLayerInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.AnimatorLayerInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `defaultWeight` | `float` | `` |
| `blendingMode` | `string` | `` |
| `states` | `AnimatorStateInfo[]` | `` |

- 类型：`AnimatorStateInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.AnimatorStateInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `motionName` | `string` | `` |
| `isDefault` | `bool` | `` |
| `speed` | `float` | `` |
| `transitionCount` | `int` | `` |

---

### AnimatorController.RemoveParameter

- 原始说明：Remove a parameter from an AnimatorController
- 模块：Animation
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `name` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `name` | `string` | `` |
| `parameterCount` | `int` | `` |

---

## 资源

### AssetDatabase.Copy

- 原始说明：Copy an asset or folder to a new project-relative path
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `sourcePath` | `string` | `` |
| `destinationPath` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `sourcePath` | `string` | `` |
| `destinationPath` | `string` | `` |

---

### AssetDatabase.CreateFolder

- 原始说明：Create a folder under an existing Unity project folder
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `parentFolder` | `string` | `` |
| `folderName` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `guid` | `string` | `` |
| `path` | `string` | `` |

---

### AssetDatabase.CreateMaterialAsset

- 原始说明：Create a material asset at the given path
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `shader` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `guid` | `string` | `` |
| `shaderName` | `string` | `` |

---

### AssetDatabase.CreateScriptableObjectAsset

- 原始说明：Create a ScriptableObject asset by type name
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `typeName` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `guid` | `string` | `` |
| `typeName` | `string` | `` |

---

### AssetDatabase.CreateTextAsset

- 原始说明：Create or overwrite a text-based asset file and import it into Unity
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `content` | `string` | `` |
| `normalizeLineEndings` | `bool` | `true` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `bytes` | `Int64` | `` |
| `imported` | `bool` | `` |

---

### AssetDatabase.Delete

- 原始说明：Delete an asset
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `type` | `string` | `` |

---

### AssetDatabase.Duplicate

- 原始说明：Duplicate an asset or folder, optionally choosing the destination path
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `sourcePath` | `string` | `` |
| `destinationPath` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `sourcePath` | `string` | `` |
| `destinationPath` | `string` | `` |
| `guid` | `string` | `` |

---

### AssetDatabase.Find

- 原始说明：Find assets by filter (e.g. t:Texture, l:MyLabel)
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `filter` | `string` | `` |
| `searchInFolders` | `string[]` | `` |
| `maxResults` | `int` | `100` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assets` | `AssetInfo[]` | `` |
| `totalFound` | `int` | `` |

**嵌套类型详情**

- 类型：`AssetInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.AssetInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `guid` | `string` | `` |
| `path` | `string` | `` |
| `type` | `string` | `` |

---

### AssetDatabase.GetPath

- 原始说明：Convert between asset GUID and path
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `guid` | `string` | `` |
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `guid` | `string` | `` |
| `path` | `string` | `` |
| `type` | `string` | `` |
| `exists` | `bool` | `` |

---

### AssetDatabase.Import

- 原始说明：Reimport an asset or refresh the AssetDatabase
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `forceUpdate` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `refreshed` | `bool` | `` |

---

### AssetDatabase.Move

- 原始说明：Move or rename an asset or folder
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `sourcePath` | `string` | `` |
| `destinationPath` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `sourcePath` | `string` | `` |
| `destinationPath` | `string` | `` |

---

### AssetDatabase.ReadTextAsset

- 原始说明：Read text content from a project asset path
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `maxChars` | `int` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `content` | `string` | `` |
| `bytes` | `Int64` | `` |
| `truncated` | `bool` | `` |

---

### AssetDatabase.Refresh

- 原始说明：Refresh the Unity AssetDatabase
- 模块：Assets
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `refreshed` | `bool` | `` |

---

### AssetDatabase.Rename

- 原始说明：Rename an asset or folder while keeping it in the same parent folder
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `newName` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `oldPath` | `string` | `` |
| `newPath` | `string` | `` |
| `guid` | `string` | `` |

---

### AssetDatabase.WriteTextAsset

- 原始说明：Write text content to an existing or new project asset path
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `content` | `string` | `` |
| `normalizeLineEndings` | `bool` | `true` |
| `createIfMissing` | `bool` | `true` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `bytes` | `Int64` | `` |
| `imported` | `bool` | `` |
| `created` | `bool` | `` |

---

### Material.Create

- 原始说明：Create a new material asset
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `shader` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `guid` | `string` | `` |
| `shaderName` | `string` | `` |

---

### Material.GetColor

- 原始说明：Get a color property from a material (Material.GetColor)
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `guid` | `string` | `` |
| `name` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `guid` | `string` | `` |
| `name` | `string` | `` |
| `value` | `ColorValue` | `` |

**嵌套类型详情**

- 类型：`ColorValue`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.ColorValue`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `r` | `float` | `` |
| `g` | `float` | `` |
| `b` | `float` | `` |
| `a` | `float` | `` |

---

### Material.GetFloat

- 原始说明：Get a float property from a material (Material.GetFloat)
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `guid` | `string` | `` |
| `name` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `guid` | `string` | `` |
| `name` | `string` | `` |
| `value` | `float` | `` |

---

### Material.Inspect

- 原始说明：Inspect Material instance
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `guid` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `color` | `Color` | `` |
| `mainTextureOffset` | `Vector2` | `` |
| `mainTextureScale` | `Vector2` | `` |
| `renderQueue` | `int` | `` |
| `globalIlluminationFlags` | `string` | `` |
| `doubleSidedGI` | `bool` | `` |
| `enableInstancing` | `bool` | `` |
| `passCount` | `int` | `` |
| `isVariant` | `bool` | `` |

---

### Material.SetColor

- 原始说明：Set a color property on a material (Material.SetColor)
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `guid` | `string` | `` |
| `name` | `string` | `` |
| `value` | `ColorValue` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `guid` | `string` | `` |
| `name` | `string` | `` |
| `value` | `ColorValue` | `` |

**嵌套类型详情**

- 类型：`ColorValue`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.ColorValue`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `r` | `float` | `` |
| `g` | `float` | `` |
| `b` | `float` | `` |
| `a` | `float` | `` |

- 类型：`ColorValue`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.ColorValue`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `r` | `float` | `` |
| `g` | `float` | `` |
| `b` | `float` | `` |
| `a` | `float` | `` |

---

### Material.SetFloat

- 原始说明：Set a float property on a material (Material.SetFloat)
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `guid` | `string` | `` |
| `name` | `string` | `` |
| `value` | `float` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `guid` | `string` | `` |
| `name` | `string` | `` |
| `value` | `float` | `` |

---

### Prefab.Apply

- 原始说明：Apply overrides of a prefab instance to the source prefab asset via PrefabUtility
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `assetPath` | `string` | `` |

---

### Prefab.GetStatus

- 原始说明：Get prefab instance status for a GameObject via PrefabUtility
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `status` | `string` | `` |
| `assetPath` | `string` | `` |
| `hasOverrides` | `bool` | `` |
| `isPrefabInstance` | `bool` | `` |

---

### Prefab.Instantiate

- 原始说明：Instantiate a prefab asset into the scene via PrefabUtility
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |
| `parentInstanceId` | `int` | `` |
| `parentPath` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `name` | `string` | `` |
| `assetPath` | `string` | `` |

---

### Prefab.OverrideDetails

- 原始说明：Get property-level override details of a prefab instance
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `maxResults` | `int` | `100` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `assetPath` | `string` | `` |
| `propertyModificationCount` | `int` | `` |
| `modifications` | `PrefabPropertyModificationInfo[]` | `` |

**嵌套类型详情**

- 类型：`PrefabPropertyModificationInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.PrefabPropertyModificationInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `targetObjectName` | `string` | `` |
| `propertyPath` | `string` | `` |
| `value` | `string` | `` |
| `objectReferenceName` | `string` | `` |

---

### Prefab.OverrideStatus

- 原始说明：Inspect override status of a prefab instance
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `prefabRootName` | `string` | `` |
| `assetPath` | `string` | `` |
| `hasOverrides` | `bool` | `` |
| `propertyModificationCount` | `int` | `` |

---

### Prefab.Revert

- 原始说明：Revert overrides of a prefab instance from the source prefab asset
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `assetPath` | `string` | `` |
| `hadOverrides` | `bool` | `` |

---

### Prefab.Save

- 原始说明：Save a GameObject as a prefab asset via PrefabUtility
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `assetPath` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `assetPath` | `string` | `` |

---

### Prefab.Unpack

- 原始说明：Unpack a prefab instance via PrefabUtility, disconnecting it from the source prefab
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `completely` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `unpackMode` | `string` | `` |

---

### PrefabStage.Close

- 原始说明：Close the currently open prefab stage
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `saveChanges` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `closed` | `bool` | `` |
| `saved` | `bool` | `` |
| `assetPath` | `string` | `` |

---

### PrefabStage.GetCurrent

- 原始说明：Get the currently open prefab stage
- 模块：Assets
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `isOpen` | `bool` | `` |
| `assetPath` | `string` | `` |
| `prefabAssetName` | `string` | `` |
| `scenePath` | `string` | `` |

---

### PrefabStage.Open

- 原始说明：Open a prefab asset in Prefab Mode
- 模块：Assets
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `assetPath` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `isOpen` | `bool` | `` |
| `assetPath` | `string` | `` |
| `prefabAssetName` | `string` | `` |
| `scenePath` | `string` | `` |

---

### PrefabStage.SaveCurrent

- 原始说明：Save the currently open prefab stage
- 模块：Assets
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `isOpen` | `bool` | `` |
| `assetPath` | `string` | `` |
| `prefabAssetName` | `string` | `` |
| `scenePath` | `string` | `` |

---

## 游戏对象

### Component.SetProperty

- 原始说明：Set a component property value via SerializedProperty
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `componentInstanceId` | `int` | `` |
| `propertyPath` | `string` | `` |
| `value` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `componentInstanceId` | `int` | `` |
| `propertyPath` | `string` | `` |
| `previousValue` | `string` | `` |
| `currentValue` | `string` | `` |

---

### GameObject.AddComponent

- 原始说明：Add a component to a GameObject by type name
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `typeName` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `typeName` | `string` | `` |
| `instanceId` | `int` | `` |
| `enabled` | `bool` | `` |

---

### GameObject.Create

- 原始说明：Create a new GameObject in the scene
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `parent` | `string` | `` |
| `components` | `string[]` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `name` | `string` | `` |
| `path` | `string` | `` |
| `isActive` | `bool` | `` |
| `components` | `string[]` | `` |

---

### GameObject.CreatePrimitive

- 原始说明：Create a primitive GameObject (Cube, Sphere, Capsule, Cylinder, Plane, Quad)
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `primitiveType` | `string` | `` |
| `name` | `string` | `` |
| `parent` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `name` | `string` | `` |
| `path` | `string` | `` |
| `isActive` | `bool` | `` |
| `components` | `string[]` | `` |

---

### GameObject.Destroy

- 原始说明：Destroy a GameObject from the scene
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `instanceId` | `int` | `` |

---

### GameObject.Duplicate

- 原始说明：Duplicate an existing GameObject in the scene
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `name` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `name` | `string` | `` |
| `path` | `string` | `` |
| `isActive` | `bool` | `` |
| `components` | `string[]` | `` |

---

### GameObject.Find

- 原始说明：Find GameObjects by name, tag, layer, or component
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `namePattern` | `string` | `` |
| `tag` | `string` | `` |
| `layer` | `int` | `-1` |
| `requiredComponents` | `string[]` | `` |
| `includeInactive` | `bool` | `` |
| `maxResults` | `int` | `100` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `results` | `GameObjectResult[]` | `` |
| `totalFound` | `int` | `` |

**嵌套类型详情**

- 类型：`GameObjectResult`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.GameObjectResult`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `name` | `string` | `` |
| `path` | `string` | `` |
| `isActive` | `bool` | `` |
| `components` | `string[]` | `` |
| `sceneName` | `string` | `` |
| `tag` | `string` | `` |
| `layer` | `int` | `` |

---

### GameObject.GetComponents

- 原始说明：Get detailed component information for a GameObject
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `components` | `ComponentDetail[]` | `` |

**嵌套类型详情**

- 类型：`ComponentDetail`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.ComponentDetail`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `typeName` | `string` | `` |
| `enabled` | `bool` | `` |
| `properties` | `SerializedPropertyInfo[]` | `` |

- 类型：`SerializedPropertyInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.SerializedPropertyInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `type` | `string` | `` |
| `value` | `string` | `` |

---

### GameObject.GetHierarchy

- 原始说明：Get the scene hierarchy of GameObjects
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `includeInactive` | `bool` | `` |
| `maxDepth` | `int` | `-1` |
| `includeComponents` | `bool` | `true` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `scenes` | `HierarchyScene[]` | `` |

**嵌套类型详情**

- 类型：`HierarchyScene`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.HierarchyScene`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `nodes` | `HierarchyNode[]` | `` |

- 类型：`HierarchyNode`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.HierarchyNode`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `name` | `string` | `` |
| `depth` | `int` | `` |
| `isActive` | `bool` | `` |
| `components` | `string[]` | `` |
| `children` | `HierarchyNode[]` | `` |
| `tag` | `string` | `` |
| `layer` | `int` | `` |

---

### GameObject.RemoveComponent

- 原始说明：Remove a component from a GameObject by instance ID
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `componentInstanceId` | `int` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `typeName` | `string` | `` |
| `componentInstanceId` | `int` | `` |

---

### GameObject.RemoveComponentByType

- 原始说明：Remove a component from a GameObject by component type name
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `typeName` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `gameObjectName` | `string` | `` |
| `typeName` | `string` | `` |
| `componentInstanceId` | `int` | `` |

---

### GameObject.RemoveMissingScripts

- 原始说明：Remove missing script references from a GameObject
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `instanceId` | `int` | `` |
| `removedCount` | `int` | `` |

---

### GameObject.Rename

- 原始说明：Rename a GameObject
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `name` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `previousName` | `string` | `` |
| `name` | `string` | `` |
| `instanceId` | `int` | `` |

---

### GameObject.SetActive

- 原始说明：Set active state of a GameObject
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `active` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `previousState` | `bool` | `` |
| `currentState` | `bool` | `` |

---

### GameObject.SetParent

- 原始说明：Change the parent of a GameObject (or move to root)
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `parentInstanceId` | `int` | `` |
| `parentPath` | `string` | `` |
| `worldPositionStays` | `bool` | `true` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `name` | `string` | `` |
| `path` | `string` | `` |

---

### GameObject.SetTransform

- 原始说明：Set the local transform (position, rotation, scale) of a GameObject
- 模块：GameObject
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `path` | `string` | `` |
| `position` | `Single[]` | `` |
| `rotation` | `Single[]` | `` |
| `localScale` | `Single[]` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `instanceId` | `int` | `` |
| `name` | `string` | `` |
| `position` | `Single[]` | `` |
| `rotation` | `Single[]` | `` |
| `localScale` | `Single[]` | `` |

---

## NuGet

### NuGet.AddSource

- 原始说明：Add a NuGet package source
- 模块：NuGet
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |

---

### NuGet.Install

- 原始说明：Install a NuGet package by id and optional version
- 模块：NuGet
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `id` | `string` | `` |
| `version` | `string` | `` |
| `source` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `id` | `string` | `` |
| `version` | `string` | `` |

---

### NuGet.List

- 原始说明：List all installed NuGet packages
- 模块：NuGet
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `packages` | `NuGetPackageEntry[]` | `` |
| `totalCount` | `int` | `` |

**嵌套类型详情**

- 类型：`NuGetPackageEntry`
- TypeId：`UniCli.Server.Editor.NuGetForUnity:UniCli.Server.Editor.Handlers.NuGetForUnity.NuGetPackageEntry`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `id` | `string` | `` |
| `version` | `string` | `` |

---

### NuGet.ListSources

- 原始说明：List all configured NuGet package sources
- 模块：NuGet
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `sources` | `NuGetSourceEntry[]` | `` |
| `totalCount` | `int` | `` |

**嵌套类型详情**

- 类型：`NuGetSourceEntry`
- TypeId：`UniCli.Server.Editor.NuGetForUnity:UniCli.Server.Editor.Handlers.NuGetForUnity.NuGetSourceEntry`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `isEnabled` | `bool` | `` |

---

### NuGet.RemoveSource

- 原始说明：Remove a NuGet package source
- 模块：NuGet
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |

---

### NuGet.Restore

- 原始说明：Restore all NuGet packages from packages.config
- 模块：NuGet
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `packageCount` | `int` | `` |

---

### NuGet.Uninstall

- 原始说明：Uninstall a NuGet package by id
- 模块：NuGet
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `id` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `id` | `string` | `` |

---

## 性能分析

### Profiler.AnalyzeFrames

- 原始说明：Analyze recorded frames and return aggregate statistics
- 模块：Profiler
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `startFrame` | `int` | `-1` |
| `endFrame` | `int` | `-1` |
| `topSampleCount` | `int` | `10` |
| `sampleNameFilter` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `analyzedFrameCount` | `int` | `` |
| `startFrame` | `int` | `` |
| `endFrame` | `int` | `` |
| `frameTime` | `FrameTimeStats` | `` |
| `gcAlloc` | `GcAllocStats` | `` |
| `topSamples` | `SampleStats[]` | `` |

**嵌套类型详情**

- 类型：`FrameTimeStats`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.FrameTimeStats`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `avgMs` | `float` | `` |
| `minMs` | `float` | `` |
| `maxMs` | `float` | `` |
| `medianMs` | `float` | `` |
| `p95Ms` | `float` | `` |
| `p99Ms` | `float` | `` |
| `maxFrameIndex` | `int` | `` |

- 类型：`GcAllocStats`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.GcAllocStats`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `totalBytes` | `Int64` | `` |
| `avgBytesPerFrame` | `float` | `` |
| `maxBytesInFrame` | `Int64` | `` |
| `maxFrameIndex` | `int` | `` |
| `framesWithGc` | `int` | `` |

- 类型：`SampleStats`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.SampleStats`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `avgSelfMs` | `float` | `` |
| `maxSelfMs` | `float` | `` |
| `avgTotalMs` | `float` | `` |
| `avgCalls` | `float` | `` |
| `avgGcAllocBytes` | `float` | `` |
| `presentInFrames` | `int` | `` |

---

### Profiler.FindSpikes

- 原始说明：Find frames exceeding frame time or GC allocation thresholds
- 模块：Profiler
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `startFrame` | `int` | `-1` |
| `endFrame` | `int` | `-1` |
| `frameTimeThresholdMs` | `float` | `` |
| `gcThresholdBytes` | `Int64` | `` |
| `limit` | `int` | `20` |
| `samplesPerFrame` | `int` | `5` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `searchedFrameCount` | `int` | `` |
| `startFrame` | `int` | `` |
| `endFrame` | `int` | `` |
| `totalSpikeCount` | `int` | `` |
| `spikes` | `SpikeFrame[]` | `` |

**嵌套类型详情**

- 类型：`SpikeFrame`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.SpikeFrame`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `frameIndex` | `int` | `` |
| `frameTimeMs` | `float` | `` |
| `gcAllocBytes` | `Int64` | `` |
| `totalSampleCount` | `int` | `` |
| `reason` | `string` | `` |
| `topSamples` | `ProfilerSampleInfo[]` | `` |

- 类型：`ProfilerSampleInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.ProfilerSampleInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `totalTimeMs` | `float` | `` |
| `selfTimeMs` | `float` | `` |
| `calls` | `int` | `` |
| `gcAllocBytes` | `Int64` | `` |

---

### Profiler.GetFrameData

- 原始说明：Get CPU profiler sample data for a specific frame
- 模块：Profiler
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `frame` | `int` | `-1` |
| `limit` | `int` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `frameIndex` | `int` | `` |
| `frameTimeMs` | `float` | `` |
| `totalSampleCount` | `int` | `` |
| `samples` | `ProfilerSampleInfo[]` | `` |

**嵌套类型详情**

- 类型：`ProfilerSampleInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.ProfilerSampleInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `totalTimeMs` | `float` | `` |
| `selfTimeMs` | `float` | `` |
| `calls` | `int` | `` |
| `gcAllocBytes` | `Int64` | `` |

---

### Profiler.Inspect

- 原始说明：Get profiler status and memory statistics
- 模块：Profiler
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `enabled` | `bool` | `` |
| `deepProfiling` | `bool` | `` |
| `profileEditor` | `bool` | `` |
| `firstFrameIndex` | `int` | `` |
| `lastFrameIndex` | `int` | `` |
| `frameCount` | `int` | `` |
| `totalAllocatedMemory` | `Int64` | `` |
| `totalReservedMemory` | `Int64` | `` |
| `monoHeapSize` | `Int64` | `` |
| `monoUsedSize` | `Int64` | `` |
| `graphicsMemory` | `Int64` | `` |

---

### Profiler.LoadProfile

- 原始说明：Load profiler data from a .raw file
- 模块：Profiler
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `keepExistingData` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `firstFrameIndex` | `int` | `` |
| `lastFrameIndex` | `int` | `` |
| `frameCount` | `int` | `` |

---

### Profiler.SaveProfile

- 原始说明：Save profiler data to a .raw file
- 模块：Profiler
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `size` | `Int64` | `` |

---

### Profiler.StartRecording

- 原始说明：Start profiler recording
- 模块：Profiler
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `deep` | `bool` | `` |
| `editor` | `bool` | `` |
| `keepFrames` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `enabled` | `bool` | `` |
| `deepProfiling` | `bool` | `` |
| `profileEditor` | `bool` | `` |

---

### Profiler.StopRecording

- 原始说明：Stop profiler recording
- 模块：Profiler
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `firstFrameIndex` | `int` | `` |
| `lastFrameIndex` | `int` | `` |
| `frameCount` | `int` | `` |

---

### Profiler.TakeSnapshot

- 原始说明：Take a memory snapshot (.snap file)
- 模块：Profiler
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `size` | `Int64` | `` |

---

## 录制

### Recorder.StartRecording

- 原始说明：Start recording the Game View as a video (requires Play Mode)
- 模块：Recorder
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `format` | `string` | `` |
| `width` | `int` | `` |
| `height` | `int` | `` |
| `frameRate` | `float` | `` |
| `quality` | `string` | `` |
| `captureAudio` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `format` | `string` | `` |
| `width` | `int` | `` |
| `height` | `int` | `` |
| `frameRate` | `float` | `` |

---

### Recorder.Status

- 原始说明：Get the current recording status
- 模块：Recorder
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `isRecording` | `bool` | `` |

---

### Recorder.StopRecording

- 原始说明：Stop the current video recording
- 模块：Recorder
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `size` | `Int64` | `` |

---

## 远程

### Connection.Connect

- 原始说明：Connect to a target player/device by ID, IP address, or device ID
- 模块：Remote
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `id` | `int` | `` |
| `ip` | `string` | `` |
| `deviceId` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `id` | `int` | `` |
| `name` | `string` | `` |
| `directConnectionUrl` | `string` | `` |

---

### Connection.List

- 原始说明：List available connection targets (players/devices)
- 模块：Remote
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `targets` | `ConnectionTarget[]` | `` |

**嵌套类型详情**

- 类型：`ConnectionTarget`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.ConnectionTarget`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `id` | `int` | `` |
| `name` | `string` | `` |
| `type` | `string` | `` |
| `deviceId` | `string` | `` |
| `isConnected` | `bool` | `` |

---

### Connection.Status

- 原始说明：Get current profiler connection status
- 模块：Remote
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `id` | `int` | `` |
| `name` | `string` | `` |
| `directConnectionUrl` | `string` | `` |

---

### Remote.Invoke

- 原始说明：Invoke a debug command on connected runtime player
- 模块：Remote
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `command` | `string` | `` |
| `data` | `string` | `` |
| `playerId` | `int` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `command` | `string` | `` |
| `success` | `bool` | `` |
| `message` | `string` | `` |
| `data` | `string` | `` |

---

### Remote.List

- 原始说明：List debug commands registered on connected runtime player
- 模块：Remote
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `playerId` | `int` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `commands` | `RuntimeCommandInfo[]` | `` |

**嵌套类型详情**

- 类型：`RuntimeCommandInfo`
- TypeId：`UniCli.Remote:UniCli.Remote.RuntimeCommandInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `description` | `string` | `` |

---

## 场景

### Scene.Close

- 原始说明：Close a loaded scene via EditorSceneManager
- 模块：Scene
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `sceneIndex` | `int` | `-1` |
| `removeScene` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `removed` | `bool` | `` |

---

### Scene.Duplicate

- 原始说明：Duplicate a scene asset to a new path and optionally open it
- 模块：Scene
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `sceneIndex` | `int` | `-1` |
| `destinationPath` | `string` | `` |
| `openAfterDuplicate` | `bool` | `` |
| `additive` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `sourcePath` | `string` | `` |
| `destinationPath` | `string` | `` |
| `sceneName` | `string` | `` |
| `opened` | `bool` | `` |

---

### Scene.GetActive

- 原始说明：Get the active scene via SceneManager
- 模块：Scene
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `buildIndex` | `int` | `` |
| `isDirty` | `bool` | `` |
| `isLoaded` | `bool` | `` |
| `rootCount` | `int` | `` |

---

### Scene.List

- 原始说明：List all loaded scenes via SceneManager
- 模块：Scene
- 内置命令：True

**请求字段**

无

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `scenes` | `SceneInfo[]` | `` |
| `activeSceneName` | `string` | `` |

**嵌套类型详情**

- 类型：`SceneInfo`
- TypeId：`UniCli.Server.Editor:UniCli.Server.Editor.Handlers.SceneInfo`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `buildIndex` | `int` | `` |
| `isDirty` | `bool` | `` |
| `isLoaded` | `bool` | `` |
| `rootCount` | `int` | `` |

---

### Scene.New

- 原始说明：Create a new scene via EditorSceneManager
- 模块：Scene
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `empty` | `bool` | `` |
| `additive` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `buildIndex` | `int` | `` |
| `isDirty` | `bool` | `` |
| `isLoaded` | `bool` | `` |
| `rootCount` | `int` | `` |

---

### Scene.Open

- 原始说明：Open a scene by asset path via EditorSceneManager
- 模块：Scene
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `path` | `string` | `` |
| `additive` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `buildIndex` | `int` | `` |
| `isDirty` | `bool` | `` |
| `isLoaded` | `bool` | `` |
| `rootCount` | `int` | `` |

---

### Scene.RemoveMissingScripts

- 原始说明：Remove missing scripts from all GameObjects in a loaded scene
- 模块：Scene
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `sceneIndex` | `int` | `-1` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `sceneName` | `string` | `` |
| `scenePath` | `string` | `` |
| `removedCount` | `int` | `` |
| `gameObjectCount` | `int` | `` |

---

### Scene.Rename

- 原始说明：Rename a saved scene asset while keeping it in the same folder
- 模块：Scene
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `sceneIndex` | `int` | `-1` |
| `newName` | `string` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `oldPath` | `string` | `` |
| `newPath` | `string` | `` |
| `sceneName` | `string` | `` |

---

### Scene.Save

- 原始说明：Save a scene or all open scenes via EditorSceneManager
- 模块：Scene
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `sceneIndex` | `int` | `-1` |
| `saveAsPath` | `string` | `` |
| `all` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `savedScenePaths` | `string[]` | `` |
| `savedCount` | `int` | `` |

---

### Scene.SetActive

- 原始说明：Set the active scene via SceneManager
- 模块：Scene
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `sceneIndex` | `int` | `-1` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `name` | `string` | `` |
| `path` | `string` | `` |
| `buildIndex` | `int` | `` |
| `isDirty` | `bool` | `` |
| `isLoaded` | `bool` | `` |
| `rootCount` | `int` | `` |

---

## 搜索

### Search

- 原始说明：Search Unity project using Unity Search API
- 模块：Search
- 内置命令：True

**请求字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `query` | `string` | `` |
| `provider` | `string` | `` |
| `maxResults` | `int` | `50` |
| `includePackages` | `bool` | `` |

**响应字段**

| 字段 | 类型 | 默认值 |
|---|---|---|
| `results` | `SearchResultItem[]` | `` |
| `totalCount` | `int` | `` |
| `displayedCount` | `int` | `` |
| `query` | `string` | `` |

**嵌套类型详情**

- 类型：`SearchResultItem`
- TypeId：`UniCli.Server.Editor.Search:UniCli.Server.Editor.Handlers.Search.SearchResultItem`

| 字段 | 类型 | 默认值 |
|---|---|---|
| `id` | `string` | `` |
| `label` | `string` | `` |
| `description` | `string` | `` |
| `provider` | `string` | `` |

---
