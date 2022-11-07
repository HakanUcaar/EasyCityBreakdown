using EasyCityBreakdown.Common.Countries.Turkey;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("v1", new OpenApiInfo { Title = "EasyCityBreakdown", Version = "v1" });
    gen.ParameterFilter<CityParameterFilter>();
});

var app = builder.Build();

var port = Environment.GetEnvironmentVariable("PORT");
app.Urls.Add("http://*:" + port);

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");



app.MapGet("/breakdowns", (PlateCodes plateCode) =>
{    
    return EasyCityBreakdown.CityBreakdown.TurkeyAdapter.GetBreakdowns(plateCode);
})
.WithName("Get Outages")
.WithMetadata(new SwaggerOperationAttribute("Get all city outages", "Get all city outages"));

app.Run();

public class CityParameterFilter : IParameterFilter
{
    readonly IServiceScopeFactory _serviceScopeFactory;

    public CityParameterFilter(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        if (parameter.Name.Equals("plateCode", StringComparison.InvariantCultureIgnoreCase))
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                parameter.Schema.Enum = Enum.GetNames(typeof(PlateCodes)).Select(p => new OpenApiString(p)).ToList<IOpenApiAny>();
            }
        }
    }
}