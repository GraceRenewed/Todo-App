using Todo_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Todo_App;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<Todo_AppDbContext>(builder.Configuration["Todo_AppDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/toDoItems", (Todo_AppDbContext db) =>
{
    return db.ToDoItems.ToList();
});

app.MapGet("/toDoItems/{id}", (Todo_AppDbContext db, int id) =>
{
    return db.ToDoItems.Single(t => t.Id == id);
});

app.MapPost("/toDoItems", (Todo_AppDbContext db, ToDoItem toDoItem) =>
{
    db.ToDoItems.Add(toDoItem);
    db.SaveChanges();
    return Results.Created($"/toDoItems/{toDoItem.Id}", toDoItem);
});

app.MapDelete("/toDoItems/{id}", (Todo_AppDbContext db, int id) =>
{
    ToDoItem toDoItem = db.ToDoItems.SingleOrDefault(toDoItem => toDoItem.Id == id);
    if (toDoItem == null)
    {
        return Results.NotFound();
    }
    db.ToDoItems.Remove(toDoItem);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPut("/toDoItems/{id}", (Todo_AppDbContext db, int id, ToDoItem toDoItem) =>
{
    ToDoItem toDoItemToUpdate = db.ToDoItems.SingleOrDefault(toDoItem => toDoItem.Id == id);
    if (toDoItemToUpdate == null)
    {
        return Results.NotFound();
    }
    toDoItemToUpdate.Task = toDoItem.Task;
    toDoItemToUpdate.IsCompleted = toDoItem.IsCompleted;
    
    db.SaveChanges();
    return Results.NoContent();
});

app.MapGet("/userProfiles", (Todo_AppDbContext db) =>
{
    return db.UserProfiles.ToList();
});

app.MapGet("/userProfiles/{id}", (Todo_AppDbContext db, int id) =>
{
    return db.UserProfiles.Single(u => u.Id == id);
});

app.MapPost("/userProfiles", (Todo_AppDbContext db, UserProfile userProfile) =>
{
    db.UserProfiles.Add(userProfile);
    db.SaveChanges();
    return Results.Created($"/toDoItems/{userProfile.Id}", userProfile);
});

app.MapPut("/userProfiles/{id}", (Todo_AppDbContext db, int id, UserProfile userProfile) =>
{
    UserProfile userProfileToUpdate = db.UserProfiles.SingleOrDefault(userProfile => userProfile.Id == id);
    if (userProfileToUpdate == null)
    {
        return Results.NotFound();
    }
    userProfileToUpdate.Name = userProfile.Name;

    db.SaveChanges();
    return Results.NoContent();
});

app.Run();
