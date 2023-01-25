---
title: Adding services
category: WebApplicationBuilder
---

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add the memory cache services
builder.Services.AddMemoryCache();

// Add a custom scoped service
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

var app = builder.Build();
```
