using ToDoApp.DataAccess.Implementation;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;
using ToDoApp.Services.Implementation;
using ToDoApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region Register Repositories
builder.Services.AddTransient<IRepository<ToDo>, ToDoRepository > ();

builder.Services.AddTransient<IRepository<Category>, CategoryRepository>();
builder.Services.AddTransient<IRepository<Status>, StatusRepository>();
#endregion

#region Register Services
builder.Services.AddTransient<ToDoService, ToDoService>();
builder.Services.AddTransient<IFilterService, FilterService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
