using System;
using System.Collections.Generic;
using System.Linq;

public interface IHabilidad
{
    int Atacar();
    double Defensa();
}
public abstract class PokemonBase : IHabilidad
{
    protected string nombre;
    private string tipo;
    private int defensa;
    private List<int> ataques;
    public PokemonBase(string nombre, string tipo, int defensa, List<int> ataques)
    {
        if (ataques.Count != 3)
        {
            throw new ArgumentException("Deben proporcionarse 3 ataques.");
        }

        if (ataques.Any(ataque => ataque < 0 || ataque > 40))
        {
            throw new ArgumentException("Los ataques deben tener un puntaje entre 0 y 40.");
        }

        if (defensa < 10 || defensa > 35)
        {
            throw new ArgumentException("La defensa debe estar entre 10 y 35.");
        }
        this.nombre = nombre;
        this.tipo = tipo;
        this.defensa = defensa;
        this.ataques = ataques;
    }

    public int Atacar()
    {
        Random rand = new Random();
        int ataqueElegido = ataques[rand.Next(0, ataques.Count)];
        int multiplicador = rand.Next(0, 2); 
        int resultadoAtaque = ataqueElegido * multiplicador;
        return resultadoAtaque;
    }
    public double Defensa()
    {
        return defensa * 0.5; 
    }
    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Tipo: {tipo}");
        Console.WriteLine($"Defensa: {defensa}");
        Console.WriteLine($"Ataques: {string.Join(", ", ataques)}");
    }
}
public class Pokemon : PokemonBase
{
    public Pokemon(string nombre, string tipo, int defensa, List<int> ataques)
        : base(nombre, tipo, defensa, ataques)
    {
    }
    public string GetNombre()
    {
        return base.nombre;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese los datos del Pokemon 1:");
        Console.Write("Nombre: ");
        string nombrePokemon1 = Console.ReadLine();

        Console.Write("Tipo: ");
        string tipoPokemon1 = Console.ReadLine();

        Console.Write("Defensa: ");
        int defensaPokemon1 = int.Parse(Console.ReadLine());

        Console.Write("Ataques (separados por comas): ");
        List<int> ataquesPokemon1 = Console.ReadLine().Split(',').Select(int.Parse).ToList();

        Console.WriteLine("Ingrese los datos del Pokemon 2:");
        Console.Write("Nombre: ");
        string nombrePokemon2 = Console.ReadLine();

        Console.Write("Tipo: ");
        string tipoPokemon2 = Console.ReadLine();

        Console.Write("Defensa: ");
        int defensaPokemon2 = int.Parse(Console.ReadLine());

        Console.Write("Ataques (separados por comas): ");
        List<int> ataquesPokemon2 = Console.ReadLine().Split(',').Select(int.Parse).ToList();

        Pokemon pokemon1 = new Pokemon(nombrePokemon1, tipoPokemon1, defensaPokemon1, ataquesPokemon1);
        Pokemon pokemon2 = new Pokemon(nombrePokemon2, tipoPokemon2, defensaPokemon2, ataquesPokemon2);

        int resultadoBatalla = SimularBatalla(pokemon1, pokemon2);

        if (resultadoBatalla > 0)
        {
            Console.WriteLine($"Gana el Pokemon 1 ({pokemon1.GetNombre()})");
        }
        else if (resultadoBatalla < 0)
        {
            Console.WriteLine($"Gana el Pokemon 2 ({pokemon2.GetNombre()})");
        }
        else
        {
            Console.WriteLine("Empate");
        }
    }
static int SimularBatalla(Pokemon pokemon1, Pokemon pokemon2)
    {
        int resultadoTotal = 0;
        for (int turno = 1; turno <= 3; turno++)
        {
            int ataque1 = pokemon1.Atacar();
            double defensa2 = pokemon2.Defensa();

            int ataque2 = pokemon2.Atacar();
            double defensa1 = pokemon1.Defensa();

            int resultadoTurno = (ataque1 - (int)defensa2) - (ataque2 - (int)defensa1);

            resultadoTotal += resultadoTurno;

            Console.WriteLine($"Turno {turno}: {pokemon1.GetNombre()} atacó con {ataque1}, {pokemon2.GetNombre()} defendió con {defensa2}");
            Console.WriteLine($"Turno {turno}: {pokemon2.GetNombre()} atacó con {ataque2}, {pokemon1.GetNombre()} defendió con {defensa1}");
        }
        return resultadoTotal;
    }
}