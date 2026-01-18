using Aplicacion.Results;
using Contratos.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Queries.Productos
{
    public class ListaProductosQueryHandler : IRequestHandler<ListaProductosQuery, Result<List<ListaProductosDto>>>
    {
        public async Task<Result<List<ListaProductosDto>>> Handle(ListaProductosQuery request, CancellationToken cancellationToken)
        {
            Datos datos = ObtenerDatos();
            return Result.Success(datos.Productos);
        }

        private Datos ObtenerDatos()
        {
            List<ListaProductosDto> productos = new List<ListaProductosDto>();
            ListaProductosDto producto = new ListaProductosDto { Nombre = "Detergente" };
            productos.Add(producto);
            return new Datos
            {
                Productos = productos
            };
        }

        private class Datos
        {
            public List<ListaProductosDto> Productos { get; set; }
        }
    }
}
