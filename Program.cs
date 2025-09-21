var builder = WebApplication.CreateBuilder(args);

// Add authentication services
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "OpenIdConnect";
})
    .AddCookie("Cookies")
    .AddOpenIdConnect("OpenIdConnect", options =>
    {
    options.ClientId = "c67dd8e2-56f4-4cf3-8506-a3b07bc1bad2";
    options.Authority = "https://likithk099gmail.b2clogin.com/likithk099gmail.onmicrosoft.com/B2X_1_reqser_signup/v2.0";
    options.ResponseType = "code";
    options.SaveTokens = true;
    options.Scope.Clear();
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("email");
    options.CallbackPath = "/signin-oidc";
    options.SignedOutCallbackPath = "/signout-callback-oidc";
    // B2C does not use client secret for implicit/public clients
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Force HTTPS redirection and use HSTS
app.UseHttpsRedirection();
app.UseHsts();

// Use authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

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

app.Run("https://localhost:5004");
