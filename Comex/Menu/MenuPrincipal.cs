using System;
using System.Collections.Generic;
using System.Text;

namespace Comex.Menu;

using Comex.Modelo;

internal class MenuPrincipal
{

    public MenuPrincipal() { 
    
    }

    public virtual void Executar(Dictionary<string, Cliente> clientes, Dictionary<string, Produto> produtos) { 
    
    }

    public void limpaTela()
    {
        Thread.Sleep(2000);
        Console.Clear();       
    }
}
