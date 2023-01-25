---
title: HTTPS with custom certificate
category: Minimal APIs
---

```csharp
var app = WebApplication.Create(args);
app.Urls.Add("https://localhost:3000");
app.MapGet("/", () => "Hello World");
app.Run();
```
