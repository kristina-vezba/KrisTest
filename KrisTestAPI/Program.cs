using System.Reflection;
using System.Text;
using KrisTest.Application.Interfaces;
using KrisTest.Application.Services;
using KrisTest.Domain.Interfaces;
using KrisTest.Infrastructure.Data;
using KrisTest.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IWebUserRepository, WebUserRepository>();
builder.Services.AddScoped<IWebUserService, WebUserService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddHttpClient();

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Bearer")
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["Authentication:Issuer"],
			ValidAudience = builder.Configuration["Authentication:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(
				Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
		};
	}
);

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

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
