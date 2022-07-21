using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

List<Personaje> ListadoDePj = new List<Personaje>();

ListadoDePj = CargadoDePj();

int Jugador1 = SeleccionarPj(1, 999);   //El numero 999 es porque es como un indefinido
int Jugador2 = SeleccionarPj(2, Jugador1);
int Combate = Lucha(ListadoDePj, Jugador1, Jugador2);

if (Combate == 999){
    Console.WriteLine("Empate");
} else {
    Console.WriteLine("Gano el jugador: "+Combate);
}








List<Personaje> CargadoDePj(){
    for (int i = 0; i < 9; i++)
    {
        Personaje Heore = new Personaje();
        Heore =     Heore.cargarPersonaje();
        ListadoDePj.Add(Heore);
    }
    return ListadoDePj;
}

int SeleccionarPj(int numero, int PjSeleccionado){
    int eleccion;
    do
    {
        Console.WriteLine($"Jugador numero {numero} seleccione un personaje: ");
        eleccion = Convert.ToInt16(Console.ReadLine());
    } while (eleccion < 1 || eleccion > 9);

    while (eleccion == PjSeleccionado)
    {
        Console.WriteLine("El personaje que selecciono ya esta seleccionado, por favor seleccione otro: ");
        eleccion = Convert.ToInt16(Console.ReadLine());
    }
    return eleccion;
}

int Lucha(List<Personaje> ListadoDePj, int Jugador1, int Jugador2){
    Combate PeleaDePj = new Combate();
    Random rand = new Random();
    int EmpiezaAtacando = rand.Next(0,2);
    switch (EmpiezaAtacando)
    {
        case 0:
            Console.WriteLine("Empieza atacando el jugador 1");
            //ListadoDePj[Jugador1].MostrarPersonaje();
            break;
        case 1:
            Console.WriteLine("Empieza atacando el jugador 2");
            //ListadoDePj[Jugador2].MostrarPersonaje();
            break;
    }

    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine($"Ataque numero: {i}");
        if (ListadoDePj[Jugador1].DatosDePj.Salud > 0 && ListadoDePj[Jugador2].DatosDePj.Salud > 0){
            if (EmpiezaAtacando == 0){
                ListadoDePj[Jugador2].DatosDePj.Salud = PeleaDePj.PuntosDeCombate(ListadoDePj[Jugador1], ListadoDePj[Jugador2]);
                Console.WriteLine("Vida restante del Jugador2: "+ListadoDePj[Jugador2].DatosDePj.Salud);
                ListadoDePj[Jugador1].DatosDePj.Salud = PeleaDePj.PuntosDeCombate(ListadoDePj[Jugador2], ListadoDePj[Jugador1]);
                Console.WriteLine("Vida restante del Jugador1: "+ListadoDePj[Jugador1].DatosDePj.Salud);
            } else {
                ListadoDePj[Jugador1].DatosDePj.Salud = PeleaDePj.PuntosDeCombate(ListadoDePj[Jugador2], ListadoDePj[Jugador1]);
                Console.WriteLine("Vida restante del Jugador1: "+ListadoDePj[Jugador1].DatosDePj.Salud);
                ListadoDePj[Jugador2].DatosDePj.Salud = PeleaDePj.PuntosDeCombate(ListadoDePj[Jugador1], ListadoDePj[Jugador2]);
                Console.WriteLine("Vida restante del Jugador2: "+ListadoDePj[Jugador2].DatosDePj.Salud);
            }
        }
    }

    Console.WriteLine("Comprobando vida");

    if (ListadoDePj[Jugador1].DatosDePj.Salud != 0 && ListadoDePj[Jugador2].DatosDePj.Salud != 0){
        Console.WriteLine("Los heroes tienen mas de 0 de salud");
        if (ListadoDePj[Jugador1].DatosDePj.Salud > ListadoDePj[Jugador2].DatosDePj.Salud){
            Console.WriteLine("El Heroe 1 ha ganado el combate");
            ListadoDePj[Jugador1].MejorarHabilidades(ListadoDePj[Jugador1]);
            Console.WriteLine("Mejoramos sus habilidades");
            return Jugador2;
        } else {
            if (ListadoDePj[Jugador2].DatosDePj.Salud > ListadoDePj[Jugador1].DatosDePj.Salud){
                Console.WriteLine("El Heroe 2 ha ganado el Combate");
                ListadoDePj[Jugador2].MejorarHabilidades(ListadoDePj[Jugador2]);
                Console.WriteLine("Mejoramos sus habilidades");
                return Jugador1;
            }
        }
        Console.WriteLine("Los heroes tiene la misma cantidad de vida");
        return 999; //999 Es cuando la Salud de ambos heroes sean iguales.
    } else {
        if (ListadoDePj[Jugador1].DatosDePj.Salud == 0 && ListadoDePj[Jugador2].DatosDePj.Salud == 0){
            Console.WriteLine("Ambos heroes tienen 0 puntos de salud");
            return 999; //999 porque es indefinido lo que nos quiere decir que ambos tienen 0 de vida
        } else {
            if (ListadoDePj[Jugador1].DatosDePj.Salud == 0){
                Console.WriteLine("El personaje 1 perdio el combate");
                return Jugador1;
            } else {
                Console.WriteLine("El personaje 2 perdio el combate");
                return Jugador2;
            }
        }
    }
}