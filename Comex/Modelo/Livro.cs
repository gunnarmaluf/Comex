using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Modelo;

public class Livro : Produto, Identificar
{
    private string isbn;

    public string Isbn { get { return isbn; } set { isbn = value; } }

    private int totalPaginas;

    public int TotalPaginas { get { return totalPaginas; } set { totalPaginas = value; } }

    public Livro(String nome) : base(nome) { 
    
        
    }

    public string Identificar()
    {

        return $"Livro {Nome} \n ISBN:{Isbn}";
    }
}
