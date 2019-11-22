FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["../MicroQuiz.Services.Auth/src/MicroQuiz.Services.Auth.Api/MicroQuiz.Services.Auth.Api.csproj", "../MicroQuiz.Services.Auth/src/MicroQuiz.Services.Auth.Api/"]
COPY ["../MicroQuiz.Services.Auth/src/MicroQuiz.Services.Auth.Infrastructure/MicroQuiz.Services.Auth.Infrastructure.csproj", "../MicroQuiz.Services.Auth/src/MicroQuiz.Services.Auth.Infrastructure/"]
COPY ["../MicroQuiz.Services.Auth/src/MicroQuiz.Services.Auth.Core/MicroQuiz.Services.Auth.Core.csproj", "../MicroQuiz.Services.Auth/src/MicroQuiz.Services.Auth.Core/"]
COPY ["../MicroQuiz.Services.Auth/src/MicroQuiz.Services.Auth.Application/MicroQuiz.Services.Auth.Application.csproj", "../MicroQuiz.Services.Auth/src/MicroQuiz.Services.Auth.Application/"]
RUN dotnet restore "../MicroQuiz.Services.Auth/src/MicroQuiz.Services.Auth.Api/MicroQuiz.Services.Auth.Api.csproj"
COPY . .
WORKDIR "/src/../MicroQuiz.Services.Auth/src/MicroQuiz.Services.Auth.Api"
RUN dotnet build "MicroQuiz.Services.Auth.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroQuiz.Services.Auth.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroQuiz.Services.Auth.Api.dll"]
