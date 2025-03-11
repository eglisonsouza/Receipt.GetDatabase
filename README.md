# Receipt.GetDatabase

## Overview

`Receipt.GetDatabase` is a .NET 8 project that includes an Azure Function to retrieve all products from a Cosmos DB database. The project is written in C# 12.0 and leverages the Azure Functions and Cosmos DB SDKs.

## Project Structure

### Models

- **Product.cs**: Defines the `Product` class with properties for `Name`, `Code`, `Quantity`, `Unity`, and `Value`.

### Functions

- **GetAllProductsFunction.cs**: Contains the Azure Function `GetAllProducts` which retrieves all products from the Cosmos DB container.

## Product Model

The `Product` class is defined as follows:

## GetAllProductsFunction

The `GetAllProductsFunction` class contains the Azure Function `GetAllProducts` which is triggered by an HTTP GET request. It retrieves all products from the specified Cosmos DB container and returns them as a JSON response.

### Environment Variables

- `DatabaseId`: The ID of the Cosmos DB database.
- `ContainerId`: The ID of the Cosmos DB container.

## Running the Project

1. Set up the required environment variables (`DatabaseId` and `ContainerId`).
2. Deploy the Azure Function to your Azure account.
3. Trigger the function by sending an HTTP GET request to the function URL.

## Dependencies

- .NET 8
- Azure Functions SDK
- Azure Cosmos DB SDK

## License

This project is licensed under the MIT License.
