﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("webhook", builder =>
    {
        builder.AddAuthenticationSchemes("Bearer");
        builder.RequireScope("admin_ui_webhooks");
    });
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "http://localhost:5003";
        options.RequireHttpsMetadata = false;
        options.Audience = "admin_ui_webhooks";
    });

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
// Configure middleware pipeline
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers()
    .RequireAuthorization(); // Require authentication by default

// Add global exception handler
app.UseExceptionHandler("/error");

app.Run();
