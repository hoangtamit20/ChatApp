@echo off
setlocal EnableDelayedExpansion

echo Select an option:
echo 1. Add Migrations
echo 2. Remove Migrations
echo 3. Update Database

set /p choice=Enter your choice (1/2/3):

if "%choice%"=="1" (
    set /p migrationName=Enter the name of the migration: 
    if not "!migrationName!"=="" (
        echo Adding migration !migrationName!...
        dotnet ef migrations add !migrationName! --project .\Common\ChatApp.Repository\ChatApp.Repository.csproj --startup-project .\Microservice\ChatApp.API\ChatApp.API.csproj -o .\Common\ChatApp.Repository\Data\Migrations
        if !errorlevel! neq 0 (
            echo Failed to add migration.
        ) else (
            echo Migration added successfully.
        )
    ) else (
        echo Migration name cannot be empty.
    )
) else if "%choice%"=="2" (
    echo Removing last migration...
    dotnet ef migrations remove --project .\Common\ChatApp.Repository\ChatApp.Repository.csproj --startup-project .\Microservice\ChatApp.API\ChatApp.API.csproj
    if !errorlevel! neq 0 (
        echo Failed to remove migration.
    ) else (
        echo Migration removed successfully.
    )
) else if "%choice%"=="3" (
    echo Updating database...
    dotnet ef database update --project .\Common\ChatApp.Repository\ChatApp.Repository.csproj --startup-project .\Microservice\ChatApp.API\ChatApp.API.csproj
    if !errorlevel! neq 0 (
        echo Failed to update database.
    ) else (
        echo Database updated successfully.
    )
) else (
    echo Invalid choice.
)

pause
