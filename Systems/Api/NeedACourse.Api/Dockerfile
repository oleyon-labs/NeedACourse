#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Systems/Api/NeedACourse.Api/NeedACourse.Api.csproj", "Systems/Api/NeedACourse.Api/"]
RUN dotnet restore "Systems/Api/NeedACourse.Api/NeedACourse.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/NeedACourse.Api"
RUN dotnet build "NeedACourse.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NeedACourse.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NeedACourse.Api.dll"]