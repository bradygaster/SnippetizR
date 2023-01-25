---
title: Developer Exception Page
category: WebApplicationBuilder
---

```csharp
var app = WebApplication.Create(args);

app.MapGet("/", () => { throw new InvalidOperationException(); });
app.Run();
```
