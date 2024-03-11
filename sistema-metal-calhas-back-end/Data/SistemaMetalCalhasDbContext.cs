using Microsoft.EntityFrameworkCore;
using sistema_metal_calhas_back_end.Models;

namespace sistema_metal_calhas_back_end.Data
{
	public class SistemaMetalCalhasDbContext : DbContext
	{

		protected readonly IConfiguration _configuration;

		//public SistemaMetalCalhasDbContext(IConfiguration configuration)
		//{
		//	_configuration = configuration;
		//}

		//protected override void OnConfiguring(DbContextOptionsBuilder options)
		//{
		//	options.UseNpgsql(_configuration.GetConnectionString("DataBase"));
		//}

		public SistemaMetalCalhasDbContext(DbContextOptions<SistemaMetalCalhasDbContext> options) : base(options)
		{
		}

		public DbSet<PedidoModel> Pedidos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
