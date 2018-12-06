# MLFlow.NET

[![Build Status](https://dev.azure.com/aussiedevcrew/MLFlow.NET/_apis/build/status/MLFlow.NET-ASP.NET%20Core-CI-Github)](https://dev.azure.com/aussiedevcrew/MLFlow.NET/_build/latest?definitionId=4)


[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/MLFlow.NET.svg)](https://www.nuget.org/packages/MLFlow.NET/)



MLFlow.NET is a .NET Standard 2.0 based wrapper for the REST based [MLFlow](https://mlflow.org/) server API . The SDK package allows you to call the MLFlow server API from .NET apps. A sample use case is writing a .NET Core app that validates a machine learning model or API and stores the result in MLFlow.

MLFlow.NET is a work in progress - please provide feedback via the issues tab. 

## Prerequisite

You need .Net core 2.2, you can download it from [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download) 

If you don't have correct .NET SDK you will see this error 

"The current .NET SDK does not support targeting .NET Core 2.2. 
Either target .NET Core 2.1 or lower, or use a version of the .NET SDK that supports .NET Core 2.2."


## Getting Started

Start by installing the MLFlow.NET Package.

```
dotnet add package MLFlow.NET
```
or

```
Install-Package MLFlow.NET
```

### Setting up the [MLFlow](https://mlflow.org/).NET Services

[MLFlow](https://mlflow.org/).NET provides an extension method to integrate with your services provider - much like `services.AddMVC()` in ASP.NET Core projects. 

```csharp
using MLFlow.NET.Lib;
using MLFlow.NET.Lib.Model;
```

For a web application navigate to your Startup.cs class `ConfigureServices` method  add the services:
```csharp
 services.Configure<MLFlowConfiguration>(
                Configuration.GetSection(nameof(MLFlowConfiguration)
            ));

            services.AddMFlowNet();
```


## Configuration

The configuration file needs to be set up. You can see the setup above is using `MLFlowConfiguration`. Edit `appsettings.json` and add the following section, changing values as appropriate. 

```json
"MLFlowConfiguration": {
        "MLFlowServerBaseUrl": "http://localhost:5000",
        "APIBase": "api/2.0/preview/mlflow/"
    }
```

## Setting up the docker container

This SDK is just a wrapper, it does not acually implement MLFLow! You'll need a server to actually store the results. We've provided one in a docker container that is super easy to use. 

Navigate to `/docker` in the repo. You can build the `Dockerfile` if you like, or just use the pre-made container from Docker Hub. 

To use the premade container, type `docker-compose up` in the `/docker` folder. 

This will launch the ML Flow server and expose it on port 5000. 

You can navigate to this address in your browser to see the results. Careful not to rely on this docker-compose orchestrated container - it will not be durable and could remove your data between runs. See the ML FLow doco for information on how to save data to another location. 

## Samples

There are sampes located in the `/samples` folder. They include an ASP.NET Core web app and an .NET Core based console application

# Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
