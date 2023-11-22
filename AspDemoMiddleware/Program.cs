using AspDemoMiddleware.Middlewares;
using AspDemoMiddleware.Models;
using AspDemoMiddleware.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// addScoped - instance je vytvorena pro kazdy request - sdileni stavu mezi komponentami
// addTransient - instance je vytvorena pro kazdy request - pro jednoduche sluzby, bezestavova
// addSingleton - instance je vytvorena jednou pro celou aplikaci
builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(10));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISessionStorage<List<TaskItem>>, SessionStorage<List<TaskItem>>>();
builder.Services.AddScoped<ITaskItemService, TaskItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession(); // zapnuti session

app.UseRouting();
//app.UseMiddleware<RequestTimeMiddleware>();
app.UseRequestTime();

app.UseAuthorization();

//app.Run(async (context) => { await context.Response.WriteAsync("ahoj"); });

app.MapRazorPages();

app.Run();