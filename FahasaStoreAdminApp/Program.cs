using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian session timeout
    options.Cookie.HttpOnly = true; // Cookie chỉ có thể truy cập thông qua HTTP
    options.Cookie.IsEssential = true; // Cookie là cần thiết cho ứng dụng
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IImageUploader, ImageUploader>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IJwtTokenDecoder, JwtTokenDecoder>();

builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IBannerService, BannerService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IPlatformService, PlatformService>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISubcategoryService, SubcategoryService>();
builder.Services.AddScoped<IPartnerTypeService, PartnerTypeService>();
builder.Services.AddScoped<IPartnerService, PartnerService>();
builder.Services.AddScoped<ICoverTypeService, CoverTypeService>();
builder.Services.AddScoped<IDimensionService, DimensionService>();
builder.Services.AddScoped<IPosterImageService, PosterImageService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Thêm middleware session
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
