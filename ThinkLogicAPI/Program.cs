using Microsoft.AspNetCore.OData;
using ThinkLogicAPI.Application.Service;
using ThinkLogicAPI.Application.Service.Interface;
using ThinkLogicAPI.Ioc.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddScoped<ICalendarEventService, CalendarEventService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddOData(options => options.Select().Filter().OrderBy());


builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
