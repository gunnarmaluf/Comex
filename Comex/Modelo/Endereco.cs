using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Modelo;

public class Endereco
{
    private string bairro;

    public string Bairro { get { return bairro; } set { bairro = value; } }

    private string cidade;

    public string Cidade { get { return cidade; } set { cidade = value; } }

    private string complemento;

    public string Complemento { get { return complemento; } set { complemento = value; } }

    private string estado;

    public string Estado { get { return estado; } set { estado = value; } }

    private string rua;

    public string Rua { get { return rua; } set { rua = value; } }

    private int numero;

    public int Numero { get { return numero; } set { numero = value; } }
}
