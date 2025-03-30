FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project files into the container
COPY . .

# Restore dependencies
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expose the port your application listens on
EXPOSE 5000

# Set the entry point for the container
ENTRYPOINT ["dotnet", "jsonReader.dll"]

# Build the application
# RUN dotnet build --no-restore

# Set the default command to run the application
# CMD ["dotnet", "run"]