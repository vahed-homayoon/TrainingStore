dotnet tool install --global dotnet-ef --version 8.0.4
dotnet tool update --global dotnet-ef --version 8.0.4
dotnet build
dotnet ef --startup-project ../TrainingStore.Api/ database update
pause