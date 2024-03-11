using System.ComponentModel.DataAnnotations;

namespace sistema_metal_calhas_back_end.Models
{
	public class PedidoModel
	{
		[Key]
		public int Id { get; set; }
		public DateTime DataVenda { get; set; }
		public string Vendedor { get; set; }
		public string Cliente { get; set; }
		public string Observacao { get; set; }
		public string Valor { get; set; }
		public DateTime DataEntrega { get; set; }
	}
}
