using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistema_metal_calhas_back_end.Models;
using sistema_metal_calhas_back_end.Repository.Interfaces;

namespace sistema_metal_calhas_back_end.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PedidoController : ControllerBase
	{
		private readonly IPedidoRepository _pedidoRepository;

		public PedidoController(IPedidoRepository pedidoRepository)
		{
			_pedidoRepository	= pedidoRepository;
		}

		[HttpGet]
		public async Task<ActionResult<List<PedidoModel>>> BuscarTodosPedidos()
		{
			List<PedidoModel> pedidos = await _pedidoRepository.BuscarTodosPedidos();

			return Ok(pedidos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<PedidoModel>>> BuscarPedidoPorId(int id)
		{
			PedidoModel pedido = await _pedidoRepository.BuscarPedidoPorId(id);

			return Ok(pedido);
		}

		[HttpPost]
		public async Task<ActionResult<PedidoModel>> AdicionarPedido([FromBody] PedidoModel pedido)
		{
			PedidoModel pedidoAdicionado = await _pedidoRepository.AdicionarPedido(pedido);

			return Ok(pedidoAdicionado);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<PedidoModel>> AtualizarPedido([FromBody] PedidoModel pedidoModel, int id)
		{
			pedidoModel.Id = id;
			PedidoModel pedido = await _pedidoRepository.AtualizarPedido(pedidoModel, id);

			return Ok(pedidoModel);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<PedidoModel>> DeletarPedido(int id)
		{
			
			bool resultado = await _pedidoRepository.DeletarPedido(id);

			return Ok(resultado);
		}

	}
}
