---
title: Custom dependency injection container
category: WebApplicationBuilder
---

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register your own things directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory
// for you.
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MyApplicationModule()));

var app = builder.Build();
```
