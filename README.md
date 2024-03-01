# ASP.NET 6.0 Web API Starter Template with Global Logging

Welcome to the ASP.NET 6.0 Web API Starter Template with Global Logging! This template is designed to jumpstart your web API projects with built-in global logging using Serilog.

## Features

- **ASP.NET 6.0**: Leverage the latest features and improvements in ASP.NET for building robust web APIs.
- **Global Logging with Serilog**: Seamless integration with Serilog ensures comprehensive logging throughout your application.
- **Easy to Use**: Get started quickly with this well-structured and documented template.
- **Customizable**: Tailor the template to your specific project requirements and preferences.

## Getting Started

To get started with this template, follow these steps:

1. Clone or download this repository.
2. Open the solution in Visual Studio or your preferred IDE.
3. Customize the template according to your project needs.
4. Start building your web API with confidence, knowing that global logging is already set up for you.

## Dependencies

- [ASP.NET 6.0](https://dotnet.microsoft.com/apps/aspnet)
- [Serilog](https://serilog.net/)

## Usage

Detailed usage instructions and examples can be found in the project documentation.

## Configuration

In your `Program.cs` file, include the following code snippet to configure global logging with Serilog:

```csharp
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .MinimumLevel.Information()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .MinimumLevel.Override("System", LogEventLevel.Warning)
        // Text Logs
        .WriteTo.File(
            path: "bin/Logs/log-.txt",
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}",
            rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: 7,
            flushToDiskInterval: TimeSpan.FromSeconds(1))
        // Structured Logs
        .WriteTo.File(
            path: "bin/Logs/structured-log-.json", // Global Logs Will Be Stored Here
            formatter: new Serilog.Formatting.Json.JsonFormatter(),
            rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: 7,
            fileSizeLimitBytes: null,
            shared: true,
            flushToDiskInterval: TimeSpan.FromSeconds(1));
});
