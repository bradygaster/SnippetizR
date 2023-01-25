---
title: Customizing the IWebHostBuilder
category: WebApplicationBuilder
---

```csharp
var builder = WebApplication.CreateBuilder(args);

// Change the HTTP server implemenation to be HTTP.sys based
builder.WebHost.UseHttpSys();

var app = builder.Build();
```
