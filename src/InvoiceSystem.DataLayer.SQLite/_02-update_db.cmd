dotnet tool install --global dotnet-ef --version 3.1.5
dotnet tool update --global dotnet-ef --version 3.1.5
dotnet build
dotnet ef --startup-project ../InvoiceSystem/ database update --context SQLiteDbContext
pause