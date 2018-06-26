# Scutor.AspnetCore.Wireup

![GitHub license](https://img.shields.io/github/license/MDP66/Scutor.AspnetCore.Wireup.svg)


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
