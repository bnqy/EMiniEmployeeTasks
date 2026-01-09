# Use the official .NET 8 container
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-stage
# Set working directory in the container
WORKDIR /src
COPY EMiniEmployeeTasks/EMiniEmployeeTasks.csproj .

RUN dotnet restore

# Copy files from the current folder on machine to
# the /src folder in the container
# COPY . /src

# Copies source code
COPY . .

# Publish binaries
RUN dotnet publish EMiniEmployeeTasks/EMiniEmployeeTasks.csproj -o /publish

# New base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0  
WORKDIR /publish
# Copies from first image          
COPY --from=build-stage /publish .
# Expose HTTP port from "docker" launch profile
EXPOSE 80

# Run the application when the container is started
# ENTRYPOINT ["dotnet", "run", "--project", "EMiniEmployeeTasks/EMiniEmployeeTasks.csproj", "--launch-profile", "docker"]
ENTRYPOINT ["dotnet", "EMiniEmployeeTasks.dll"]