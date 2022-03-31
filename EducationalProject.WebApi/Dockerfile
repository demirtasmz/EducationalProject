#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["EducationalProject.WebApi/EducationalProject.WebApi.csproj", "EducationalProject.WebApi/"]
COPY ["EducationalProject.Business/EducationalProject.Business.csproj", "EducationalProject.Business/"]
COPY ["EducationalProject.Utilities/EducationalProject.Utilities.csproj", "EducationalProject.Utilities/"]
COPY ["EducationalProject.Repository/EducationalProject.Repository.csproj", "EducationalProject.Repository/"]
RUN dotnet restore "EducationalProject.WebApi/EducationalProject.WebApi.csproj"
COPY . .
WORKDIR "/src/EducationalProject.WebApi"
RUN dotnet build "EducationalProject.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EducationalProject.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EducationalProject.WebApi.dll"]