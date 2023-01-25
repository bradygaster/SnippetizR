---
title: Customizing the IHostBuilder
category: WebApplicationBuilder
---

```csharp
var builder = WebApplication.CreateBuilder(args);

// Wait 30 seconds for graceful shutdown
builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(30));

var app = builder.Build();
```
