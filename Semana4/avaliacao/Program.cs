using System;
using System.Collections.Generic;
using System.Linq;

class Treinador
{
	public string? Nome { get; set; }
	public DateTime DataNascimento { get; set; }
	public string? CPF { get; set; }
	public string? CREF { get; set; }
}

class Cliente
{
	public string? Nome { get; set; }
	public DateTime DataNascimento { get; set; }
	public string? CPF { get; set; }
	public double Altura { get; set; }
	public double Peso { get; set; }
}

class Academia
{
	private List<Treinador> treinadores = new List<Treinador>();
	private List<Cliente> clientes = new List<Cliente>();

	public void AdicionarTreinador(Treinador novoTreinador)
	{
  	      treinadores.Add(novoTreinador);
	}

	public void AdicionarCliente(Cliente novoCliente)
	{
       clientes.Add(novoCliente);

	}

public List<Treinador> TreinadoresEntreIdades(int idadeMinima, int idadeMaxima)
   {
       DateTime hoje = DateTime.Today;
       return treinadores.FindAll(t =>
           hoje.Year - t.DataNascimento.Year >= idadeMinima &&
           hoje.Year - t.DataNascimento.Year <= idadeMaxima);
   }


   public List<Cliente> ClientesEntreIdades(int idadeMinima, int idadeMaxima)
   {
       DateTime hoje = DateTime.Today;
       return clientes.FindAll(c =>
           hoje.Year - c.DataNascimento.Year >= idadeMinima &&
           hoje.Year - c.DataNascimento.Year <= idadeMaxima);
   }


   public List<Cliente> ClientesComIMCMaiorQue(double valorIMC)
   {
       return clientes.Where(c => (c.Peso / (c.Altura * c.Altura)) > valorIMC)
                      .OrderBy(c => (c.Peso / (c.Altura * c.Altura)))
                      .ToList();
   }


   public List<Cliente> ClientesOrdemAlfabetica()
   {
       return clientes.OrderBy(c => c.Nome).ToList();
   }


   public List<Cliente> ClientesMaisVelhoParaMaisNovo()
   {
       return clientes.OrderByDescending(c => c.DataNascimento).ToList();
   }


	public List<object> AniversariantesDoMes(int mes)
	{
    	var aniversariantes = new List<object>();

    	aniversariantes.AddRange(treinadores.Where(t => t.DataNascimento.Month == mes));
    	aniversariantes.AddRange(clientes.Where(c => c.DataNascimento.Month == mes));

    	return aniversariantes;
	}
}

class Program
{
	static void Main(string[] args)
	{
    	Academia academia = new Academia();

    	academia.AdicionarTreinador(new Treinador {  });
    	academia.AdicionarCliente(new Cliente { });

    	var treinadoresEntre25e35 = academia.TreinadoresEntreIdades(25, 35);
    	var clientesComIMCMaiorQue25 = academia.ClientesComIMCMaiorQue(25);

    	foreach (var treinador in treinadoresEntre25e35)
    	{
        	Console.WriteLine($"Treinador encontrado: {treinador.Nome}");
    	}

    	Console.WriteLine("Programa executado com sucesso!");
	}
}


