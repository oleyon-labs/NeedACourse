#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Systems/Identity/NeedACourse.Identity/NeedACourse.Identity.csproj", "Systems/Identity/NeedACourse.Identity/"]
RUN dotnet restore "Systems/Identity/NeedACourse.Identity/NeedACourse.Identity.csproj"
COPY . .
WORKDIR "/src/Systems/Identity/NeedACourse.Identity"
RUN dotnet build "NeedACourse.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NeedACourse.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NeedACourse.Identity.dll"]