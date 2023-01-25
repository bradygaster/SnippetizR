---
title: Reading configuration
category: WebApplicationBuilder
---

```csharp
var builder = WebApplication.CreateBuilder(args);

// Reads the ConnectionStrings section of configuration and looks for a sub key called Todos
var connectionString = builder.Configuration.GetConnectionString("Todos");

Console.WriteLine($"My connection string is {connectionString}");

var app = builder.Build();
```
