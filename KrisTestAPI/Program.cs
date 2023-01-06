using KrisTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<KrisTestContext>(options => options.UseNpgsql(
	"ConnectionStrings:KrisTestContextConnection", x => x.MigrationsAssembly("KrisTestContext")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using ( var scope = app.Services.CreateScope() )
{
	var db = scope.ServiceProvider.GetRequiredService<KrisTestContext>();
	db.Database.EnsureCreated();
	var a = db.Database.GetPendingMigrations;
	if (a != null)
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

app.Run();
