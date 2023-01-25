---
title: Adding configuration providers
category: WebApplicationBuilder
---

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddIniFile("appsettings.ini");
var app = builder.Build();
```
