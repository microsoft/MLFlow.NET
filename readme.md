# MLFlow.NET

[![Build Status](https://dev.azure.com/aussiedevcrew/MLFlow.NET/_apis/build/status/MLFlow.NET-ASP.NET%20Core-CI)](https://dev.azure.com/aussiedevcrew/MLFlow.NET/_build/latest?definitionId=3)


[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/MLFlow.NET.svg)](https://www.nuget.org/packages/MLFlow.NET/)



MLFlow.NET is a .NET Standard 2.0 based wrapper for the REST based [MLFlow](https://mlflow.org/) server API . The SDK package allows you to call the MLFlow server API from .NET apps. A sample use case is writing a .NET Core app that validates a machine learning model or API and stores the result in MLFlow.

## Getting Started

Start by installing the MLFlow.NET Package.

```
dotnet add package MLFlow.NET
```
or

```
Install-Package MLFlow.NET
```

MLFlow.NET provides an extension method to integrate with your services provider - much like `services.AddMVC()` in ASP.NET Core projects. 

```csharp
include MLFlow.NET.Lib
```

In your Startup class add the services:
```
