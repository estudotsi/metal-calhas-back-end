using Microsoft.EntityFrameworkCore;
using sistema_metal_calhas_back_end.Data;
using sistema_metal_calhas_back_end.Repository;
using sistema_metal_calhas_back_end.Repository.Interfaces;

namespace sistema_metal_calhas_back_end
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddEntityFrameworkNpgsql().AddDbContext<SistemaMetalCalhasDbContext>(
				options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
				);

			builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.UseCors(x => x.AllowAnyHeader()
				  .AllowAnyMethod()
				  .AllowAnyOrigin());

			app.MapControllers();

			app.Run();
		}
	}
}