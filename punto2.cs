using System;
using System.Collections.Generic;

class Jugador
{
    public string Nombres{get;set;} public string Posiciones{get;set;} public int Rendimientos{get;set;}
    public Jugador(string nombre, string posicion, int rendimiento)
    {
        Nombres=nombre;
        Posiciones=posicion;
        Rendimientos=rendimiento;
    }
}
class EscogerJugador
{
    public void Main()
    {
        List<Jugador> registrarJugadores=new List<Jugador>
        {
            new Jugador("Jugador1", "Posición1", 7),
            new Jugador("Jugador2", "Posición2", 8),
            new Jugador("Jugador3", "Posición3", 9),
            new Jugador("Jugador4", "Posición4", 3),
            new Jugador("Jugador5", "Posición5", 5),
            new Jugador("Jugador6", "Posición6", 2),
        };
        SeleccionarJugadores(registrarJugadores);
    }
    public void SeleccionarJugadores(List<Jugador> jugadores)
    {
        Random random = new Random();
        List<Jugador> equipo = new List<Jugador>();
        for (int i = 0; i < 3; i++) 
        {
            int indiceAleatorio = random.Next(jugadores.Count);
            Jugador jugadorSeleccionado = jugadores[indiceAleatorio];
            equipo.Add(jugadorSeleccionado);
            jugadores.RemoveAt(indiceAleatorio);
        }
        Console.WriteLine("El equipo seleccionado es:");
        foreach (Jugador jugador in equipo)
        {
            Console.WriteLine($" Nombre {jugador.Nombres} Posición {jugador.Posiciones} Rendimiento {jugador.Rendimientos}");
        }
    }
}