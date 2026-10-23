using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Comex.Modelo;

namespace Comex.Filtros;

internal class Filtro
{
    public static List<Produto> OrdenarProdutoPorNome(List<Produto> produtos) 
    {
        List<Produto> produtosOrdenados = produtos.OrderBy(produto => produto.Nome).ToList();
        return produtosOrdenados;
    }

    public static List<Produto> OrdenarProdutoPorPreco(List<Produto> produtos)
    {
        List<Produto> produtosOrdenados = produtos.OrderBy(produto => produto.Preco).ToList();
        return produtosOrdenados;
    }
}
