using System;
using WebApplication.Entities;
using WebApplication.Repositorio;

namespace WebApplication.Services
{
    public class ComprasService
    {
        public static bool ExcluirCompra(UnitOfWork uow, int id) // static não precisa instanciar por exemplo com o new(). Pode chamar direto
        {
            try
            {
                var itensCompra = uow.CompraRepository.ObterItensCompraIncludeProduto(id);

                foreach (var itemCompra in itensCompra)
                {
                    ExcluirItemCompra(uow, itemCompra.Id);
                }

                uow.CompraRepository.Deletar(x => x.Id == id);
                uow.Commit();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ExcluirItemCompra(UnitOfWork uow, int id) // static não precisa instanciar por exemplo com o new(). Pode chamar direto
        {
            var itemCompra = uow.CompraRepository.ObterItemCompraIncludeProduto(id);
            itemCompra.Produto.SetQtdEstoque(itemCompra.Produto.QtdEstoque - itemCompra.Qtd);
            uow.CompraRepository.DeletarItem(id);
        }

        public static void AdicionarItemCompra(UnitOfWork uow, Compra compra, int produtoId, int qtd, decimal valorUnitario)
        {
            var produto = uow.ProdutoRepository.Procurar(produtoId);
            compra.ItensCompra.Add(new ItemCompra(produto, qtd, valorUnitario));
            produto.SetQtdEstoque(produto.QtdEstoque + qtd);
        }
    }
}