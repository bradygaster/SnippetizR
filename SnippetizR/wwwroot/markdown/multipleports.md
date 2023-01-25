---
title: Multiple ports
category: Minimal APIs
---

```csharp
var app = WebApplication.Create(args);
app.Urls.Add("http://localhost:3000");
app.Urls.Add("http://localhost:4000");
app.MapGet("/", () => "Hello World");
app.Run();
```
