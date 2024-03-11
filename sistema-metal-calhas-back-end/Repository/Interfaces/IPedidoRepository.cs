using sistema_metal_calhas_back_end.Models;

namespace sistema_metal_calhas_back_end.Repository.Interfaces
{
	public interface IPedidoRepository
	{
		Task<List<PedidoModel>> BuscarTodosPedidos();
		Task<PedidoModel> BuscarPedidoPorId(int id);
		Task<PedidoModel> AdicionarPedido(PedidoModel pedido);
		Task<PedidoModel> AtualizarPedido(PedidoModel pedido, int id);
		Task<bool> DeletarPedido(int id);
	}
}
