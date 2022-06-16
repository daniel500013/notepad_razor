var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NotepadDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings")));

// Add services to the container.
builder.Services.AddRazorPages(x =>
{
    x.Conventions.AuthorizePage("/Subjects/Index");
    x.Conventions.AuthorizePage("/Subjects/GetPost");
    x.Conventions.AuthorizePage("/Subjects/EditPost");
    x.Conventions.AuthorizePage("/Subjects/DeletePost");
    x.Conventions.AuthorizePage("/Subjects/CreatePost");
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Subjects/";
    });

builder.Services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
