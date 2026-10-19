using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Modelo;

internal class Cliente
{

    private string nome;

    public string Nome { get { return nome; } set { nome = value; } }

    private string cpf;

    public string CPF { get { return cpf; } set { cpf = value; } }

    private string email;

    public string EMAIL { get { return email; } set { email = value; } }

    private string profissao;

    public string Profissao { get { return profissao; } set { profissao = value; } }

    private string telefone;

    public string Telefone { get { return telefone; } set { telefone = value; } }

    private Endereco endereco;

    public Endereco Endereco { get { return endereco; } set { endereco = value; } }

}
