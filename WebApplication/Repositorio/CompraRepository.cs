using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication.Repositorio
{
    public class CompraRepository : Repository<Compra>, ICompraRepository
    {
        readonly ApplicationContext Context;

        public CompraRepository(ApplicationContext context) : base(context)
        {
            Context = context;
        }

        public Compra ObterCompraIncludeItens(int compraId)
        {
            return Context.Compras
                .Include(x => x.ItensCompra)
                .FirstOrDefault(x => x.Id == compraId);
        }

        public List<Compra> BuscarComprasIncludeFornecedor(int fornecedorId, DateTime? dataIni, DateTime? dataFim)
        {
            IQueryable<Compra> compras = Context.Compras
                .Include(x => x.Fornecedor)
                .AsNoTracking()
                .OrderBy(x => x.Data);

            if (!fornecedorId.Equals(0))
            {
                compras = compras.Where(x => x.FornecedorId == fornecedorId);
            }

            if (dataIni != null)
            {
                compras = compras.Where(x => x.Data >= dataIni);
            }

            if (dataFim != null)
            {
                compras = compras.Where(x => x.Data <= dataFim);
            }

            return compras.ToList();
        }

        public ItemCompra ObterItemCompraIncludeProduto(int id)
        {
            return Context.ItensCompra
                .Include(x => x.Produto)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<ItemCompra> ObterItensCompraIncludeProduto(int compraId)
        {
            return Context.ItensCompra
                .Include(x => x.Produto)
                .AsNoTracking()
                .ToList();
        }

        public void DeletarItem(int id)
        {
            var itemCompra = Context.ItensCompra.Find(id);
            Context.ItensCompra.Remove(itemCompra);
        }
    }
}