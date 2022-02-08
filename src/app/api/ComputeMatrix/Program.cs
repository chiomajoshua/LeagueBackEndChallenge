var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IComputeMatrixService, ComputeMatrixService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "League's Compute Matrix Solution", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("pol",
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddRouting(opt => opt.LowercaseUrls = true);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "League's Compute Matrix Solution v1"));
app.UseRouting();
app.UseCors("pol");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();