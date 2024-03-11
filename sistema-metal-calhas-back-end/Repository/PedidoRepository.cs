using Microsoft.EntityFrameworkCore;
using sistema_metal_calhas_back_end.Data;
using sistema_metal_calhas_back_end.Models;
using sistema_metal_calhas_back_end.Repository.Interfaces;

namespace sistema_metal_calhas_back_end.Repository
{
	public class PedidoRepository : IPedidoRepository
	{
		private readonly SistemaMetalCalhasDbContext _context;
		public PedidoRepository(SistemaMetalCalhasDbContext sistemaMetalCalhasDbContext) 
		{
			_context= sistemaMetalCalhasDbContext;
		}

		public async Task<List<PedidoModel>> BuscarTodosPedidos()
		{
			return await _context.Pedidos.ToListAsync();
		}

		public async Task<PedidoModel> BuscarPedidoPorId(int id)
		{
			PedidoModel pedidoModel =  await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == id);

			if (pedidoModel == null)
			{
				throw new Exception($"Usuário {id} não encontrado");
			}

			return pedidoModel;
		}

		public async Task<PedidoModel> AdicionarPedido(PedidoModel pedido)
		{
			await _context.Pedidos.AddAsync(pedido);
			await _context.SaveChangesAsync();

			return pedido;
		}

		public async Task<PedidoModel> AtualizarPedido(PedidoModel pedido, int id)
		{
			PedidoModel pedidoModelPoId = await BuscarPedidoPorId(id);

			if(pedidoModelPoId == null)
			{
				throw new Exception($"Usuário {id} não encontrado");
			}

			pedidoModelPoId = pedido;

			_context.Update(pedidoModelPoId);
			await _context.SaveChangesAsync();

			return pedidoModelPoId;
		}

		public async Task<bool> DeletarPedido(int id)
		{
			PedidoModel pedidoModelPoId = await BuscarPedidoPorId(id);

			if (pedidoModelPoId == null)
			{
				throw new Exception($"Usuário {id} não encontrado");
			}

			_context.Pedidos.Remove(pedidoModelPoId);
			await _context.SaveChangesAsync();

			return true;
		}

	}
}
