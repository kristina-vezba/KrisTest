using System.Reflection;
using KrisTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NodaTime;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<KrisTestContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("KrisTestContextConnection"), opt =>
			{
				//Console.WriteLine($"Startup: using connection string: {builder.ConnectionString}");
				opt.UseNodaTime();
				AssemblyName assemblyName = typeof(KrisTestContext).Assembly.GetName();
				opt.MigrationsAssembly(assemblyName.Name);
			})
			.EnableSensitiveDataLogging();
	options.UseSnakeCaseNamingConvention();
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<KrisTestContext>();
	var migrationCount = db.Database.GetPendingMigrations;

	if (migrationCount != null)
	{
		db.Database.Migrate();
	}
}

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

KrisTestContextSeed.Seed(app);

app.Run();
