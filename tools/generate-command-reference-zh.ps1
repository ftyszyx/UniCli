param(
    [string]$ProjectPath = "e:\opensource\UniCli\src\UniCli.Unity",
    [string]$CliPath = "e:\opensource\UniCli\publish\win-x64\Release\unicli.exe",
    [string]$OutputPath = "e:\opensource\UniCli\doc\commands.zh-CN.md"
)

$ErrorActionPreference = "Stop"

& py -3 "e:\opensource\UniCli\tools\generate-command-reference-zh.py" `
    --project-path $ProjectPath `
    --cli-path $CliPath `
    --output-path $OutputPath
