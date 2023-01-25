---
title: Reading the environment
category: WebApplicationBuilder
---

```csharp
var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    Console.WriteLine($"Running in development");
}

var app = builder.Build();
```
