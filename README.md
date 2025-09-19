# Cat Facts CLI 🐾

A simple command-line application that fetches cat facts from external API. This application was created as a recruitment task for a company.

## Features ✨

- Fetch random cat facts from [catfact.ninja](https://catfact.ninja) 🐱
- Save facts to a txt file 💾
- View all previously saved cat facts 📖

## Architecture & Design 🏗️

- **N-Layered** architecture with the following structure:
  - **CLI** - Command-line interface handling
  - **Services** - Business logic and external API communication
  - **Repositories** - Data storage and retrieval
  - **Models** - Data transfer objects
  - **Configuration** - Application configuration settings
- **Dependecy Injection**
- **Strongly Typed Configuration**
- Clean Command Handling with **System.CommandLine**
- Configured **HttpClient** with proper **disposal pattern**
- **Safe I/O file** operations

## Run the application 🚀

> [!NOTE]
> Requires .NET 9.0

1. Clone the repository
2. Navigate to the project directory
3. Run `dotnet build` to build the application

## Usage

The application provides the following commands:

### Help ℹ️
```bash
dotnet run -- --help
```
Example output:
```
Description:
  Cat Facts CLI

Usage:
  CatFact [command] [options]

Options:
  -?, -h, --help  Show help and usage information
  --version       Show version information

Commands:
  add   Fetches and saves a random cat fact
  list  Displays saved cat facts
  path  Displays the path to the file where cat facts are saved

```

### Add a new cat fact ➕

Fetches a new cat fact from the external API and saves it to local storage.

```bash
dotnet run add
```

Example output:
```
Cats have a specialized collarbone that allows them to always land on their feet.
```

### List saved cat facts 📋

Displays all previously saved cat facts with their respective lengths.

```bash
dotnet run list
```

Example output:
```
Cat facts:
- Cats have a specialized collarbone that allows them to always land on their feet. (Length: 73)
- Cats make about 100 different sounds. Dogs make only about 10. (Length: 58)
- The world's largest cat measured 48.5 inches long. (Length: 48)
```

### Display path to the file 📁

Displays the path to the file where cat facts are saved.

```bash
dotnet run path
```

Example output:
```
Cat facts are saved at: ...\CatFact\bin\Debug\net9.0\Data\CatFacts.txt
```