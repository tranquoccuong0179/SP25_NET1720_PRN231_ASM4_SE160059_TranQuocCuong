using GraphQL.Server;
using Psychologicaly.GraphQL.GraphQL.GraphQLSchema;
using Psychologicaly.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAppointmentReportService, AppointmentReportService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<UserAccountService>();
builder.Services.AddScoped<AppSchema>();
builder.Services.AddGraphQL()
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader()
                .AddSystemTextJson();
builder.Services.AddControllers()
               .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL<AppSchema>();
});
app.UseGraphQLPlayground("/ui/playground");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
