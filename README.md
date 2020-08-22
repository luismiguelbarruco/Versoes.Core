# Versoes.Core
Versoes.Core

# Migrations commands - Package manager console
migrations add InitialCreate
database update --verbose

# Migrations commands - cli .net core
dotnet ef migrations add InitialCreate
dotnet ef database update --verbose
