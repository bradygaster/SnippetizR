---
title: Creating an application
category: Minimal APIs
---

```csharp
var app = WebApplication.Create(args);
app.MapGet("/", () => "Hello World");
app.Run();
```
