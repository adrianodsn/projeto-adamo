using System;
using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Repositorio
{
    public interface ICompraRepository : IRepository<Compra>
    {
        Compra ObterCompraIncludeItens(int id);
        List<Compra> BuscarComprasIncludeFornecedor(int fornecedorId, DateTime? dataIni, DateTime? dataFim);

        ItemCompra ObterItemCompraIncludeProduto(int id);
        List<ItemCompra> ObterItensCompraIncludeProduto(int compraId);
        void DeletarItem(int id);
    }
}
