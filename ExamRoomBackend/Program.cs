using ExamRoomBackend.Models;
using ExamRoomBackend.Services;
using Twilio.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add email configuration
builder.Services.Configure<SMTPConfig>(builder.Configuration.GetSection("SMTPConfig"));
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddHttpClient<ITwilioRestClient, TwilioClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
