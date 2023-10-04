# Add migration

```shell
cls
$migration = Read-Host -Prompt 'New migration name'
dotnet ef migrations add $migration --project .\src\Infrastructure --startup-project .\src\WebApi --output-dir Persistence\Migrations

```

# Remove last migration

```shell
cls
dotnet ef migrations remove --project .\src\Infrastructure --startup-project .\src\WebApi --force

```

# Update DB

```shell
cls
dotnet ef database update --project .\src\Infrastructure --startup-project .\src\WebApi

```

# Return to migration

```shell
cls
$previous_migration = Read-Host -Prompt 'Previous migration name'
dotnet ef database update $previous_migration --project .\src\Infrastructure --startup-project .\src\WebApi
dotnet ef migrations remove --project .\src\Infrastructure --startup-project .\src\WebApi --force
```

# Drop DB

```shell
cls
dotnet ef database drop --project .\src\Infrastructure --startup-project .\src\WebApi --force

```

# Redo last migration

```shell
cls
$migration = Read-Host -Prompt 'New migration name'
dotnet ef database drop --project .\src\Infrastructure --startup-project .\src\WebApi --force
dotnet ef migrations remove --project .\src\Infrastructure --startup-project .\src\WebApi
dotnet ef migrations add $migration --project .\src\Infrastructure --startup-project .\src\WebApi --output-dir Persistence\Migrations
dotnet ef database update --project .\src\Infrastructure --startup-project .\src\WebApi

```

# Redo last migration (without specify migration name)

```shell
cls
dotnet ef database drop --project .\src\Infrastructure --startup-project .\src\WebApi --force
dotnet ef migrations remove --project .\src\Infrastructure --startup-project .\src\WebApi
dotnet ef migrations add $migration --project .\src\Infrastructure --startup-project .\src\WebApi --output-dir Persistence\Migrations
dotnet ef database update --project .\src\Infrastructure --startup-project .\src\WebApi

```

# Redo last migration (without dropping the DB)

```shell
cls
$migration = Read-Host -Prompt 'New migration name'
dotnet ef migrations remove --project .\src\Infrastructure --startup-project .\src\WebApi --force
dotnet ef migrations add $migration --project .\src\Infrastructure --startup-project .\src\WebApi --output-dir Persistence\Migrations
dotnet ef database update --project .\src\Infrastructure --startup-project .\src\WebApi

```

# Redo last migration (without specify migration name and without dropping the DB)

```shell
cls
dotnet ef migrations remove --project .\src\Infrastructure --startup-project .\src\WebApi --force
dotnet ef migrations add $migration --project .\src\Infrastructure --startup-project .\src\WebApi --output-dir Persistence\Migrations
dotnet ef database update --project .\src\Infrastructure --startup-project .\src\WebApi

```

# Drop & crate DB

```shell
cls
dotnet ef database drop --project .\src\Infrastructure --startup-project .\src\WebApi --force
dotnet ef database update --project .\src\Infrastructure --startup-project .\src\WebApi

```

# Create idempotent script

```shell
cls
dotnet ef migrations script --idempotent --project .\src\Infrastructure --startup-project .\src\WebApi --output .\data\Script.sql

```
