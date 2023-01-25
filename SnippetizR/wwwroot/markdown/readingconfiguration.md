---
title: Reading configuration
category: Minimal APIs
---

```csharp
var app = WebApplication.Create(args);

Console.WriteLine($"The configuration value is {app.Configuration["key"]}");

app.Run();
```
