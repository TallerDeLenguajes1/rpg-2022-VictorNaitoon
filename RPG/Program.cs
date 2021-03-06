using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

//LISTADO DE PERSONAJES
List<Personaje> ListadoDePj = new List<Personaje>();
var rand = new Random();
string Ruta =@"D:\MISCOSAS\Desktop\Facultad\Programador Universitario\TALLER DE LENGUAJE 1\Juego\rpg-2022-VictorNaitoon\RPG";
/////////////////////////////////////////////




//ARCHIVO JSON CON TODOS LOS PERSONAJES
string ArchivoJSON = Ruta + @"\Personajes.json";
int eleccionGenerarHeroes, salida = 0;
string miJson;
do
{
    Console.WriteLine("Oprima 1 si desea generar nuevos heroes para los combates");
    Console.WriteLine("Oprima 2 si desea utilizar el listado anterior de heroes");
    eleccionGenerarHeroes = Convert.ToInt16(Console.ReadLine());
    switch (eleccionGenerarHeroes)
    {
        case 1:
            Console.WriteLine("A continuacion se generaran nuevos heroes.");
            //CARGADO DE PERSONAJES
            for (int i = 1; i < 10; i++)
            {
                Personaje Heroe = new Personaje();
                Heroe = Heroe.cargarPersonaje(i);
                ListadoDePj.Add(Heroe);
            }
            //FIN DEL CARGADO DE PERSONAJE

            //SERIALIZACION DEL JSON
            if (!File.Exists(ArchivoJSON)){
                File.Create(ArchivoJSON);
            }

            miJson = JsonSerializer.Serialize(ListadoDePj);
            File.WriteAllText(ArchivoJSON,miJson);
            salida = 0;
            //FIN
            break;
        case 2:
            //DESERIALIZACION DE UN JSON
            Console.WriteLine("Acontinuacion se se cargara la lista con jugadores de partidas anteriores");
            if(!File.Exists(ArchivoJSON)){
                File.Create(ArchivoJSON);
            }

            miJson = File.ReadAllText(ArchivoJSON);
            if (miJson.Length > 0){
                ListadoDePj = JsonSerializer.Deserialize<List<Personaje>>(miJson);
                salida = 0;
            } else {
                Console.WriteLine("Ocurrio un error inesperado, no hay heroes guardados. Por lo tanto, crearemos nuevos heroes");
                //CARGADO DE PERSONAJES
                for (int i = 1; i < 10; i++)
                {
                    Personaje Heroe = new Personaje();
                    Heroe = Heroe.cargarPersonaje(i);
                    ListadoDePj.Add(Heroe);
                }
                //FIN DEL CARGADO DE PERSONAJE

                //SERIALIZACION DEL JSON
                if (!File.Exists(ArchivoJSON)){
                    File.Create(ArchivoJSON);
                }

                miJson = JsonSerializer.Serialize(ListadoDePj);
                File.WriteAllText(ArchivoJSON,miJson);
                salida = 0;
                //FIN
            }
            //FIN
            break;
        default:
            Console.WriteLine("ERROR, ingreso un numero distinto. Por favor, ingrese nuevamente correctamente");
            salida = 1;
            break;
    }
} while (salida != 0);
//FIN



//COMBATES DE TODOS LOS HEROES
Console.WriteLine("Comenzamos con los combates");
int MaximoDePersonajes = ListadoDePj.Count;
for (int i = 0; i < MaximoDePersonajes-1; i++)
{
    Combate Pelea = new Combate();

    Console.WriteLine($"Combate numero {i+1}");

    int Numero1 = rand.Next(0,ListadoDePj.Count);
    int Numero2;
    do
    {
        Numero2 = rand.Next(0,ListadoDePj.Count);
    } while (Numero2 == Numero1);

    Personaje Heroe1 = ListadoDePj[Numero1];
    Personaje Heroe2 = ListadoDePj[Numero2];

    //COMBATE DE LOS DOS HEROES
    for (int j = 1; j < 4; j++)
    {
        Console.WriteLine($"Ataque numero {j}");
        Heroe1.DatosDePj.Salud = Heroe1.DatosDePj.Salud - Pelea.PuntosDeCombate(Heroe2, Heroe1);
        Heroe2.DatosDePj.Salud = Heroe2.DatosDePj.Salud - Pelea.PuntosDeCombate(Heroe1, Heroe2);
    }
    //FIN DEL COMBATE DE LOS DOS HEROES

    if (Heroe1.DatosDePj.Salud == Heroe2.DatosDePj.Salud){
        Console.WriteLine("Los heroes tienen la misma salud");
        int eleccionDelCombate;

        do
        {
            Console.WriteLine("Desea que los heroes vuelvan a combatir? (0:SI, 1:NO): ");
            eleccionDelCombate = Convert.ToInt16(Console.ReadLine());
        } while (eleccionDelCombate != 0 || eleccionDelCombate != 1);

        if (eleccionDelCombate == 0){
            Console.WriteLine("Los Heroes volveran a combatir");
            //NUEVO COMBATE DE LOS HEROES
            for (int j = 1; j < 4; j++)
            {
                Console.WriteLine($"Ataque numero {j}");
                Heroe1.DatosDePj.Salud = Heroe1.DatosDePj.Salud - Pelea.PuntosDeCombate(Heroe2, Heroe1);
                Heroe2.DatosDePj.Salud = Heroe2.DatosDePj.Salud - Pelea.PuntosDeCombate(Heroe1, Heroe2);
            }
            //FIN DEL NUEVO COMBATE DE LOS DOS HEROES
        } else {
            Console.WriteLine("Su eleccion fue de que los heroes no vuelvan a enfrentarse, pero lamentablemente uno de los heroes debe ser eliminado. Lo decidiremos al azar");
            int numeroRandom = rand.Next(0,2);
            if (numeroRandom == 0){
                Console.WriteLine("El Heroe del jugador numero 1 sera eliminado");
                ListadoDePj.Remove(Heroe1);
            } else {
                Console.WriteLine("El Heroe del jugador numero 2 sera eliminado");
                ListadoDePj.Remove(Heroe2);
            }
        }

        if (Heroe1.DatosDePj.Salud > Heroe2.DatosDePj.Salud){
            ListadoDePj.Remove(Heroe2);
        } else {
            ListadoDePj.Remove(Heroe1);
        }
    } else if(Heroe1.DatosDePj.Salud > Heroe2.DatosDePj.Salud){
        ListadoDePj.Remove(Heroe2);
    } else {
        ListadoDePj.Remove(Heroe1);
    }

    Console.WriteLine($"Fin del combate numero {i+1}");
}
Console.WriteLine("Fin de todos los combates");
//FIN DE LOS COMBATES

Console.WriteLine("El Heroe ganador de los combates es: ");
ListadoDePj[0].MostrarPersonaje();
Console.WriteLine("CONGRATULATIONS Winner. It's the best of all time");

//CARGADO DE LOS HEROES GANADORES EN UN ARCHIVO CSV
string ArchivoCSV = Ruta + @"\Ganadores.csv";

FileStream FS;
if (!File.Exists(ArchivoCSV)){
    FS = File.Create(ArchivoCSV);
    FS.Close();
}

using(StreamWriter Linea = File.AppendText(ArchivoCSV)){
    Linea.WriteLine(ListadoDePj[0].DatosDePj.Nombre + "; " + ListadoDePj[0].DatosDePj.Apodo + "; " + ListadoDePj[0].DatosDePj.Tipo + "; " + ListadoDePj[0].DatosDePj.Edad + " anios ; " + ListadoDePj[0].DatosDePj.Salud + "  puntos de vida.");
}
//FIN DEL CARGADO DEL CSV



