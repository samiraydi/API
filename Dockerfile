# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln ./
COPY *.csproj ./
RUN dotnet restore
RUN dotnet tool install --global dotnet-ef --version 5.0.7
ENV PATH="${PATH}:/root/.dotnet/tools"

# copy everything else and build app
COPY . ./
WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore
#CMD ["dotnet", "ef", "--project", "../Migrations", "database", "update"]
#RUN dotnet ef database update
# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80/tcp
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "IIT.Clubs.API.dll"]