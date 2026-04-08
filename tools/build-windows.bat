@echo off
setlocal enabledelayedexpansion

rem Build and publish the UniCli Windows x64 CLI binary.
rem Usage:
rem   tools\build-windows.bat
rem   tools\build-windows.bat Release
rem   tools\build-windows.bat Debug win-x64

set "CONFIGURATION=%~1"
if "%CONFIGURATION%"=="" set "CONFIGURATION=Release"

set "RUNTIME_ID=%~2"
if "%RUNTIME_ID%"=="" set "RUNTIME_ID=win-x64"

set "SCRIPT_DIR=%~dp0"
for %%I in ("%SCRIPT_DIR%..") do set "REPO_ROOT=%%~fI"

set "PUBLISH_DIR=%REPO_ROOT%\publish\%RUNTIME_ID%\%CONFIGURATION%"
set "ARCHIVE_PATH=%REPO_ROOT%\publish\unicli-%RUNTIME_ID%.zip"
set "SKILL_DIR=%REPO_ROOT%\.agents\skills\unity-development"
set "SKILL_BIN_DIR=%SKILL_DIR%\win64"
set "SKILL_DOC_DIR=%SKILL_DIR%\doc"
set "CODEX_SKILL_DIR=%USERPROFILE%\.codex\skills\unity-development"
set "CODEX_SKILL_BIN_DIR=%CODEX_SKILL_DIR%\win64"
set "CODEX_SKILL_DOC_DIR=%CODEX_SKILL_DIR%\doc"

echo [1/4] Building protocol project...
dotnet build "%REPO_ROOT%\src\UniCli.Protocol" -c %CONFIGURATION%
if errorlevel 1 goto :error

echo [2/4] Publishing client...
dotnet publish "%REPO_ROOT%\src\UniCli.Client" -c %CONFIGURATION% -r %RUNTIME_ID% -o "%PUBLISH_DIR%"
if errorlevel 1 goto :error

echo [3/4] Syncing skill artifacts...
if not exist "%SKILL_BIN_DIR%" mkdir "%SKILL_BIN_DIR%"
if not exist "%SKILL_DOC_DIR%" mkdir "%SKILL_DOC_DIR%"
if exist "%SKILL_DIR%\unicli.exe" del /q "%SKILL_DIR%\unicli.exe"
copy /y "%PUBLISH_DIR%\unicli.exe" "%SKILL_BIN_DIR%\unicli.exe" >nul
if errorlevel 1 goto :error
powershell -NoProfile -ExecutionPolicy Bypass -Command "Copy-Item -Recurse -Force '%REPO_ROOT%\doc\*' '%SKILL_DOC_DIR%'"
if errorlevel 1 goto :error

if exist "%CODEX_SKILL_DIR%" (
  if not exist "%CODEX_SKILL_BIN_DIR%" mkdir "%CODEX_SKILL_BIN_DIR%"
  if not exist "%CODEX_SKILL_DOC_DIR%" mkdir "%CODEX_SKILL_DOC_DIR%"
  if exist "%CODEX_SKILL_DIR%\unicli.exe" del /q "%CODEX_SKILL_DIR%\unicli.exe"
  copy /y "%PUBLISH_DIR%\unicli.exe" "%CODEX_SKILL_BIN_DIR%\unicli.exe" >nul
  if errorlevel 1 goto :error
  powershell -NoProfile -ExecutionPolicy Bypass -Command "Copy-Item -Recurse -Force '%REPO_ROOT%\doc\*' '%CODEX_SKILL_DOC_DIR%'"
  if errorlevel 1 goto :error
)

if exist "%ARCHIVE_PATH%" del /q "%ARCHIVE_PATH%"

echo [4/4] Creating zip archive...
powershell -NoProfile -ExecutionPolicy Bypass -Command "Compress-Archive -Path '%PUBLISH_DIR%\unicli.exe' -DestinationPath '%ARCHIVE_PATH%'"
if errorlevel 1 goto :error

echo.
echo Build completed successfully.
echo Binary : %PUBLISH_DIR%\unicli.exe
echo Archive: %ARCHIVE_PATH%
echo Skill binary : %SKILL_BIN_DIR%\unicli.exe
echo Skill docs   : %SKILL_DOC_DIR%
exit /b 0

:error
echo.
echo Build failed.
exit /b 1
