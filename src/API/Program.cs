using API.Extensions.ServiceCollectionExt;
using API.Extensions.MvcOptionsExt;
using API.Extensions.WebApplicationBuilderExt;
using API.Extensions.WebApplicationExt;
using API.Extensions.ApiBehaviorOptionsExt;
using Coravel;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddConnectionStrings(config: builder.Configuration);

builder.UseCustomSerilog();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ActionResultFilter>();
    options.Filters.Add<GlobalExceptionHandlerFilter>();
}).ConfigureApiBehaviorOptions(apiOptions =>
{
    apiOptions.AddCustomInvalidModelResponse();
});

builder.Services.AddApiVersioningService();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddMapperServices();

builder.Services.AddRepositoryServices();

builder.Services.AddBusinessServices();

builder.Services.AddValidatorServices();

builder.Services.AddScheduler();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCustomScheduler();

app.Run();
