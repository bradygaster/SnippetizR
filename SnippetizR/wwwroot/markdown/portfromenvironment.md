---
title: Read port from environment
category: Minimal APIs
---

```csharp
var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";
var app = WebApplication.Create(args);
app.MapGet("/", () => "Hello World");
app.Run($"http://localhost:{port}");
```
