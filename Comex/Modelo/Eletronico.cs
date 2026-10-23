using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Modelo;

public class Eletronico : Produto
{
    private double voltagem;

    public double Voltagem { get { return voltagem; } set { voltagem = value; } }

    private double potencia;

    public double Potencia { get { return potencia; } set { potencia = value; } }

    public Eletronico(string nome) : base(nome) 
    { 
           
    }



}
