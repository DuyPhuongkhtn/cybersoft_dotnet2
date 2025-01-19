using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using session23_wasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

// tạo project Blazor WebAssembly
// dotnet new blazorwasm -o session23_wasm

// học về cách tạo page mới và render và trang web
// tạo file razor trong folder Pages

// học về cách binding data từ code c# sang html
// dùng @ để binding data cũng như là thực hiện action

// truyền hàm không có tham số
// VD: <button @onclick="ClickMe">Click me</button>
// truyền hàm có tham số
// VD: <button @onclick="() => ClickMe("Hello")">Click me</button>

// muốn truy xuất hình, file thì lưu file vào folder wwwroot
