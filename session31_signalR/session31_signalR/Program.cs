using Microsoft.AspNetCore.ResponseCompression;
// using session31_signalR.Client.Pages;
using session31_signalR.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

// cấu hình nén dữ liệu từ client để giảm dung lượng của event
// application/octet-stream: giúp tối ưu nén dữ liệu để tăng hiệu suất
builder.Services.AddResponseCompression(opt => {
    opt.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat([
        "application/octet-stream"
    ]);
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(session31_signalR.Client._Imports).Assembly);
// cấu hình route cho SignalR
app.MapHub<ChatHub>("/chathub");
app.Run();
