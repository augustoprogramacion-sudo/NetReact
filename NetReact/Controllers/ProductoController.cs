using Aplicacion.Queries.Productos;
using Aplicacion.Results;
using Contratos.Requests.Productos;
using Contratos.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NetReact.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductoController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> ListaProductos([FromBody] ListaProductosRequest request)
        {
            var result = await _mediator.Send(new ListaProductosQuery(request));
            return Ok(result.Value());
        }
    }
}
