---
title: Changing the web root
category: WebApplicationBuilder
---

```csharp
var builder = WebApplication.CreateBuilder(args);

// Look for static files in webroot
builder.WebHost.UseWebRoot("webroot");

var app = builder.Build();
```
