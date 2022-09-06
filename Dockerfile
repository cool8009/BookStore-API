FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5017/tcp

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
WORKDIR "/src/BookStore API/."
RUN dotnet build "BookStore API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookStore API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS="http://0.0.0.0:5017"
ENV ASPNETCORE_ENVIRONMENT=Development
COPY --from=publish /app/publish .
RUN ls -la /app
ENTRYPOINT ["dotnet", "BookStore API.dll", "http://0.0.0.0:5017", "--environment=Development"]