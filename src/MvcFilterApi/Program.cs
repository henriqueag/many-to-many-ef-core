using MvcFilterApi.Filter;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(o => {
    o.Filters.Add<EntityNotValidFilter>();
});

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = "900631683747-95s0l14sp6ul945bgi380t128mhpuqk6.apps.googleusercontent.com";
        options.ClientSecret = "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";
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => {
    options.SwaggerEndpoint("v1/swagger.json", "Api interna");
    options.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();