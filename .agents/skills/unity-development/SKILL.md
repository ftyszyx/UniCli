---
name: unity-development
description: >-
  用于在任意接入 UniCli 的 Unity 工程中自动化 Unity Editor 工作流，包括安装服务端包、
  导入资源、编译、测试、场景/对象/Prefab/资源操作，以及调用项目内可用的 UniCli 命令。
metadata:
  version: "1.2.5"
---

# UniCli Unity 开发技能

这个技能用于 **任意接入了 UniCli 的 Unity 工程**，适合新项目或已有项目中的 Unity Editor 自动化工作流。

## 首次安装

为避免多开 Unity 工程时连错项目，推荐先把下面两个文件复制到 **当前 Unity 工程根目录** 再执行：

- `win64/unicli.exe`
- `com.yucchiy.unicli-server.zip`

也就是说，推荐目录形态类似：

```text
YourUnityProject/
  Assets/
  Packages/
  unicli.exe
  com.yucchiy.unicli-server.zip
```

如果当前 Unity 工程里还没有 `Packages/com.yucchiy.unicli-server`，先在 **工程根目录** 解压服务端包：

```powershell
$project = (Get-Location).Path
$packageDir = Join-Path $project "Packages"
$serverDir = Join-Path $packageDir "com.yucchiy.unicli-server"
$serverZip = ".\\com.yucchiy.unicli-server.zip"

if (-not (Test-Path $serverDir)) {
  Expand-Archive -Path $serverZip -DestinationPath $packageDir -Force
}
```

然后在 **工程根目录** 直接执行：

```powershell
.\unicli.exe check --json
```

如果你不能在工程根目录执行，再显式指定目标工程路径：

```powershell
$env:UNICLI_PROJECT = "path/to/your-unity-project"
.\win64\unicli.exe check --json
```

## 必须遵守的规则

1. 修改 `Assets/` 或 `Packages/` 下任意文件后，必须运行 `AssetDatabase.Import`，让 Unity 自动生成或刷新 `.meta`，不要手写 `.meta`。
2. 修改任何 Unity C# 代码后，必须运行 `Compile --json` 验证是否通过编译。
3. 需要结构化结果时，统一带 `--json`。
4. 如果 Unity Editor 未连接，先重试 2 到 3 次；仍失败再确认 Editor 是否已打开当前项目。
5. 涉及平台差异时，用 `BuildPlayer.Compile --target <platform> --json` 做额外验证。
6. 测试默认使用最小输出：`TestRunner.RunEditMode --resultFilter failures --json`。
7. 查控制台默认过滤 `Warning,Error`，避免信息噪音。
8. 不要硬记命令列表，优先用 `unicli commands --json` 和 `unicli exec <command> --help` 动态发现。

## 推荐命令前缀

推荐直接进入 Unity 工程根目录执行：

```powershell
$cli = ".\unicli.exe"
```

后续调用统一使用：

```powershell
& $cli check --json
& $cli status --json
& $cli exec Compile --json
& $cli commands --json
```

如果 `unicli.exe` 不在工程根目录，而是仍放在 skill 目录里，再使用：

```powershell
$env:UNICLI_PROJECT = "path/to/your-unity-project"
$cli = "win64/unicli.exe"
```

## 基础工作流

### 1. 连通性检查

```powershell
& $cli check --json
& $cli status --json
```

### 2. 导入与编译

```powershell
& $cli exec AssetDatabase.Import --path "Assets/Scripts/Foo.cs" --json
& $cli exec Compile --json --timeout 120000
```

### 3. 测试

```powershell
& $cli exec TestRunner.RunEditMode --json
& $cli exec TestRunner.RunPlayMode --json
& $cli exec TestRunner.List --mode EditMode --json
```

### 4. 动态执行 C#

```powershell
& $cli eval 'return UnityEngine.Application.unityVersion;' --json
```

## 常用命令类别

### 资源类

- `AssetDatabase.Find`
- `AssetDatabase.GetPath`
- `AssetDatabase.Import`
- `AssetDatabase.Refresh`
- `AssetDatabase.Copy`
- `AssetDatabase.Move`
- `AssetDatabase.Rename`
- `AssetDatabase.Duplicate`
- `AssetDatabase.Delete`
- `AssetDatabase.CreateFolder`
- `AssetDatabase.CreateTextAsset`
- `AssetDatabase.ReadTextAsset`
- `AssetDatabase.WriteTextAsset`
- `AssetDatabase.CreateMaterialAsset`
- `AssetDatabase.CreateScriptableObjectAsset`

### 场景类

- `Scene.List`
- `Scene.GetActive`
- `Scene.Open`
- `Scene.Save`
- `Scene.New`
- `Scene.Close`
- `Scene.SetActive`
- `Scene.Duplicate`
- `Scene.Rename`
- `Scene.RemoveMissingScripts`

### GameObject / Selection 类

- `GameObject.Find`
- `GameObject.Create`
- `GameObject.Destroy`
- `GameObject.Duplicate`
- `GameObject.SetTransform`
- `GameObject.SetParent`
- `GameObject.SetActive`
- `GameObject.AddComponent`
- `GameObject.RemoveComponent`
- `GameObject.RemoveComponentByType`
- `GameObject.RemoveMissingScripts`
- `Selection.Get`
- `Selection.SetAsset`
- `Selection.SetAssets`
- `Selection.SetGameObject`
- `Selection.SetGameObjects`
- `Selection.Ping`
- `Selection.Frame`

### Prefab 类

- `Prefab.Save`
- `Prefab.Instantiate`
- `Prefab.GetStatus`
- `Prefab.Apply`
- `Prefab.Revert`
- `Prefab.OverrideStatus`
- `Prefab.OverrideDetails`
- `Prefab.Unpack`
- `PrefabStage.Open`
- `PrefabStage.GetCurrent`
- `PrefabStage.SaveCurrent`
- `PrefabStage.Close`

### 编辑器窗口类

- `Window.List`
- `Window.Open`
- `Window.Focus`
- `Window.FocusProject`
- `Window.FocusHierarchy`
- `Window.Create`

## 文档入口

完整命令文档优先看：

- 中文版：`doc/commands.zh-CN.md`
- 英文版：`doc/commands.md`

## 推荐执行顺序

1. 先把 `unicli.exe` 和 `com.yucchiy.unicli-server.zip` 放到当前 Unity 工程根目录。
2. 如果缺少 `Packages/com.yucchiy.unicli-server`，先从 zip 安装。
3. `check` / `status`
4. 必要时 `commands --json` 确认命令面
5. 改文件后 `AssetDatabase.Import`
6. 改 C# 后 `Compile --json`
7. 必要时运行 `TestRunner.*`
8. 最后再做功能性命令 smoke test

## 自定义命令开发

需要扩展新的 Unity 侧命令时，建议遵循 UniCli 常见模式：

1. 在项目内负责 UniCli 命令的 handler 目录下添加或修改 `CommandHandler<TRequest, TResponse>`。
2. 请求/响应类型使用 `[Serializable]` + `public fields`。
3. 修改后运行：

```powershell
& $cli exec AssetDatabase.Import --path "Assets/..." --json
& $cli exec Compile --json
& $cli commands --json
```

## 提示

- 多个 Unity 工程同时打开时，最好始终在目标工程根目录执行 `.\unicli.exe`。
- 如果必须跨目录执行，务必显式设置 `UNICLI_PROJECT`。
- 大多数命令都支持 `--help` 查看字段定义。
- 如果你不确定某个类型名或窗口名，先用 `Type.List` / `Window.List`。
- 如果内置命令不够，优先评估是用 `eval` 一次性完成，还是新增 `CommandHandler` 作为可复用命令。
- 如果项目有自己的命令文档，优先以项目文档和 `commands --json` 的实际输出为准。
