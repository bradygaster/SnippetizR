---
title: HTTPS with development certificate
category: Minimal APIs
---

```csharp
var builder = WebApplication.CreateBuilder(args);

// Configure the cert and the key
builder.Configuration["Kestrel:Certificates:Default:Path"] = "site.crt";
builder.Configuration["Kestrel:Certificates:Default:KeyPath"] = "site.key";

var app = builder.Build();

app.Urls.Add("https://localhost:3000");
app.MapGet("/", () => "Hello World");
app.Run();
```
