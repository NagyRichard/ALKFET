FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

COPY ["ShoppingList.Api.csproj", "./"]
RUN dotnet restore "ShoppingList.Api.csproj"

COPY . .
RUN dotnet publish "ShoppingList.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "ShoppingList.Api.dll"]