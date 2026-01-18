using Aplicacion.Results;
using Contratos.Requests.Productos;
using Contratos.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Queries.Productos
{
    public class ListaProductosQuery : IRequest<Result<List<ListaProductosDto>>>
    {
        public ListaProductosRequest Request;

        public ListaProductosQuery(ListaProductosRequest request)
        {
            Request = request;
        }
    }
}
