FROM mcr.microsoft.com/dotnet/sdk:8.0

# Set the working directory inside the container
WORKDIR /app

# Copy the project files into the container
COPY . .

# Restore dependencies
RUN dotnet restore

# Build the application
RUN dotnet build --no-restore

# Set the default command to run the application
CMD ["dotnet", "run"]