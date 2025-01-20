using ExpenseTrackProV2;
using ExpenseTrackPro.Application;
using ExpenseTrackPro.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExtension();
builder.Services.AddCors();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddJwtBearerExtension(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.Urls.Add("http://192.168.0.86:5237"); // or use http://*:5237 to bind to all interfaces
app.MapControllers();
app.UseHttpsRedirection();


app.UseCors("AllowAll");
app.Run();
