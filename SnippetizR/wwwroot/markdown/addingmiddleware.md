---
title: Adding Middleware
category: WebApplicationBuilder
---

```csharp
var app = WebApplication.Create(args);

// Setup the file server to serve static files
app.UseFileServer();

app.Run();
```
