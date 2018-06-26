# Scutor.AspnetCore.Wireup

[![GitHub license](https://img.shields.io/github/license/MDP66/Scutor.AspnetCore.Wireup.png)](https://github.com/MDP66/Scutor.AspnetCore.Wireup/blob/master/LICENSE)[![GitHub issues](https://img.shields.io/github/issues/MDP66/Scutor.AspnetCore.Wireup.png)](https://github.com/MDP66/Scutor.AspnetCore.Wireup/issues)[![GitHub stars](https://img.shields.io/github/stars/MDP66/Scutor.AspnetCore.Wireup.png)](https://github.com/MDP66/Scutor.AspnetCore.Wireup/stargazers)[![NuGet](https://img.shields.io/nuget/v/Nuget.Core.png)](https://www.nuget.org/packages/Scutor.AspnetCore.Wireup/)
[![Build status](https://ci.appveyor.com/api/projects/status/jfwak85h40v4dv6u?svg=true)](https://ci.appveyor.com/project/MDP66/scutor-aspnetcore-wireup)
[![Build status](https://ci.appveyor.com/api/projects/status/jfwak85h40v4dv6u/branch/master?svg=true)](https://ci.appveyor.com/project/MDP66/scutor-aspnetcore-wireup/branch/master)


Current version is : 
Scutor wire up services and classes for asp.net core
> This tool will be updated with further needs or requests

## Usage
First you need to install it via nuget :
```
Install-Package Scutor.AspnetCore.Wireup -Version 1.0.0
```

or install via cli command :
```
dotnet add package Scutor.AspnetCore.Wireup --version 1.0.0
```


Writeup can be done in Startup.cs class, simply with one line of code 

```csharp
  public void ConfigureServices(IServiceCollection services)
  {
    // other services can add here
    // like :
    // services.AddMvc();
    // Transient
    services.WireupTransient(this.GetType().Assembly);            
    // Scoped
    services.WireupScoped(this.GetType().Assembly);            
    // Singleton
    services.WireupSingleton(this.GetType().Assembly);            
  }
```

You can specify search condition for scanning assemblies like this :
```csharp
  public void ConfigureServices(IServiceCollection services)
  {
    // other services can add here
    // like :
    // services.AddMvc();
    services.AddMvc();
    // Transient
    services.WireupTransient(this.GetType().Assembly, "*Transient_types.dll");            
    // Scoped
    services.WireupScoped(this.GetType().Assembly, "*Scoped_types.dll");            
    // Singleton
    services.WireupSingleton(this.GetType().Assembly, "*Singleton_types.dll");            
  }
```
