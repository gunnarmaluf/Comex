using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Modelo;

internal class Produto
{
    private string nome;

    public string Nome { get { return nome; } set { nome = value; } }

    private string descricao;

    public string Descricao { get { return descricao; } set { descricao = value; } }

    private double preco;

    public double Preco { get { return preco; } set { preco = value; } }

    private int quantidade = 1;

    public int Quantidade { get { return quantidade; } set { quantidade = value; } }

    public Produto(string nome, double preco) { 
        this.nome = nome;
        this.preco = preco;              
    }
    public Produto(string nome)
    {
        this.nome = nome;
        this.preco = 0;        
    }

}
