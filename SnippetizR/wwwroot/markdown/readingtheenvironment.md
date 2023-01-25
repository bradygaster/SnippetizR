---
title: Reading the environment
category: Minimal APIs
---

```csharp
var builder = WebApplication.CreateBuilder(args);

// Configure the cert and the key
var app = WebApplication.Create(args);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/oops");
}

app.MapGet("/", () => "Hello World");
app.MapGet("/oops", () => "Oops! An error happened.");
app.Run();
```
