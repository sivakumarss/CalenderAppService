using CalenderAppService.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(builder =>
        builder.WithOrigins("http://localhost:3000")  // Append here for any other ports  eg: 3001
            .AllowAnyHeader()
            .AllowAnyMethod()));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/bookingslot", () =>
{
    var timeslots = new BookingSlotsService();
    return timeslots.CreateTimeSlots();

});


app.UseCors();

app.Run();
