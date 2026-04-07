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

echo [1/3] Building protocol project...
dotnet build "%REPO_ROOT%\src\UniCli.Protocol" -c %CONFIGURATION%
if errorlevel 1 goto :error

echo [2/3] Publishing client...
dotnet publish "%REPO_ROOT%\src\UniCli.Client" -c %CONFIGURATION% -r %RUNTIME_ID% -o "%PUBLISH_DIR%"
if errorlevel 1 goto :error

if exist "%ARCHIVE_PATH%" del /q "%ARCHIVE_PATH%"

echo [3/3] Creating zip archive...
powershell -NoProfile -ExecutionPolicy Bypass -Command "Compress-Archive -Path '%PUBLISH_DIR%\unicli.exe' -DestinationPath '%ARCHIVE_PATH%'"
if errorlevel 1 goto :error

echo.
echo Build completed successfully.
echo Binary : %PUBLISH_DIR%\unicli.exe
echo Archive: %ARCHIVE_PATH%
exit /b 0

:error
echo.
echo Build failed.
exit /b 1
