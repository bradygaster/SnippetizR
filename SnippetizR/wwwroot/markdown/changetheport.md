---
title: Change the port
category: Minimal APIs
---

```csharp
var app = WebApplication.Create(args);

app.MapGet("/", () => "Hello World");

app.Run("http://localhost:3000");
```
