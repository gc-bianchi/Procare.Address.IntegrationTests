# Procare Address API Integration Tests

This repository contains integration tests for the Procare Address API. The API takes address information and returns valid shippable matches, and is used to validate addresses for new centers/merchants to ensure the information they provide is actionable.

## Getting Started

### Prerequisites

- .NET 5.0 or later
- An IDE such as Visual Studio or VS Code

### Installation

1. Clone the repository
2. Navigate to the project directory
3. Restore the .NET packages
## Running the tests

To run the tests, use the following command:
dotnet test

## Test Cases

The test cases cover various scenarios, including:

- Valid US addresses
- Valid address with multiple matches
- Non-existent addresses
- Addresses in US territories