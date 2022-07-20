
enum Tipos{
    Asesino, Bardo, Cazador, Clerigo, Druida, Guerrero, Mago,  Paladin, Pirata
}
enum Nombres{
    Vladhimir, Nailhun, Thayron, Annie, Kantz, Drako, Spoon, Lycan, Nerkov
}
enum Apodos{
    CaraCortada, Infierno, Munieko, Trauma, Lucifer, Vendetta, Maestro, Profesor, Perro
}
public class Datos {
    private Tipos tipo;
    private Nombres nombre;
    private Apodos apodo;
    private DateTime fechaDeCreacion;
    private int edad;
    private int salud;

    public DateTime FechaDeCreacion { get => fechaDeCreacion; set => fechaDeCreacion = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Salud { get => salud; set => salud = value; }
    internal Tipos Tipo { get => tipo; set => tipo = value; }
    internal Nombres Nombre { get => nombre; set => nombre = value; }
    internal Apodos Apodo { get => apodo; set => apodo = value; }
}
public class Caracteristicas {
   private int velocidad, destreza, fuerza, nivel, armadura;

    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
}

public class Personaje{
    private Datos datosDePj = new Datos();
    private Caracteristicas caracteristicaDePj = new Caracteristicas();
    DateTime hoy = DateTime.Today;
    private int edad = 0;

    public Datos DatosDePj { get => datosDePj; set => datosDePj = value; }
    public Caracteristicas CaracteristicaDePj { get => caracteristicaDePj; set => caracteristicaDePj = value; }
    public DateTime Hoy { get => hoy; set => hoy = value; }
    public int Edad { get => edad; set => edad = value; }

    public int EdadDePj(DateTime FechaDeCreacion){
        Edad = Hoy.Year - FechaDeCreacion.Year;
        if (FechaDeCreacion.Month > Hoy.Month){
            Edad = Edad - 1;
        }
        return Edad;
    }


    public Personaje cargarPersonaje(){
        Personaje personaje = new Personaje();
        Random rand = new Random();
        int datoRandom = rand.Next(1, 10);
        switch (datoRandom)
        {
            case 1:
                personaje.DatosDePj.Tipo = Tipos.Asesino;
                personaje.datosDePj.Nombre = Nombres.Drako;
                personaje.DatosDePj.Apodo = Apodos.CaraCortada;
                break;
            case 2:
                personaje.DatosDePj.Tipo = Tipos.Bardo;
                personaje.datosDePj.Nombre = Nombres.Annie;
                personaje.DatosDePj.Apodo = Apodos.Vendetta;
                break;
            case 3:
                personaje.DatosDePj.Tipo = Tipos.Cazador;
                personaje.datosDePj.Nombre = Nombres.Kantz;
                personaje.DatosDePj.Apodo = Apodos.Infierno;
                break;
            case 4:
                personaje.DatosDePj.Tipo = Tipos.Clerigo;
                personaje.datosDePj.Nombre = Nombres.Vladhimir;
                personaje.DatosDePj.Apodo = Apodos.Maestro;
                break;
            case 5:
                personaje.DatosDePj.Tipo = Tipos.Druida;
                personaje.datosDePj.Nombre = Nombres.Nailhun;
                personaje.DatosDePj.Apodo = Apodos.Lucifer;
                break;
            case 6:
                personaje.DatosDePj.Tipo = Tipos.Guerrero;
                personaje.datosDePj.Nombre = Nombres.Lycan;
                personaje.DatosDePj.Apodo = Apodos.Munieko;
                break;
            case 7:
                personaje.DatosDePj.Tipo = Tipos.Mago;
                personaje.datosDePj.Nombre = Nombres.Nerkov;
                personaje.DatosDePj.Apodo = Apodos.Profesor;
                break;
            case 8:
                personaje.DatosDePj.Tipo = Tipos.Paladin;
                personaje.datosDePj.Nombre = Nombres.Spoon;
                personaje.DatosDePj.Apodo = Apodos.Perro;
                break;
            case 9:
                personaje.DatosDePj.Tipo = Tipos.Pirata;
                personaje.datosDePj.Nombre = Nombres.Thayron;
                personaje.DatosDePj.Apodo = Apodos.Trauma;
                break;
            default:
                break;
        }

        personaje.DatosDePj.FechaDeCreacion = new DateTime(rand.Next(1800,2015), rand.Next(1,13), rand.Next(1,30));

        personaje.DatosDePj.Edad = personaje.EdadDePj(personaje.DatosDePj.FechaDeCreacion);

        personaje.DatosDePj.Salud = 100;

        personaje.CaracteristicaDePj.Velocidad = rand.Next(1,11);
        personaje.CaracteristicaDePj.Destreza = rand.Next(1,6);
        personaje.CaracteristicaDePj.Fuerza = rand.Next(1,10);
        personaje.CaracteristicaDePj.Nivel = rand.Next(1,11);
        personaje.CaracteristicaDePj.Armadura = rand.Next(1,11);

        return personaje;
    }   

    public void MostrarPersonaje(){
        Console.WriteLine("\n ---------- PERSONAJE ---------- \n");
        Console.WriteLine("Tipo: "+DatosDePj.Tipo);
        Console.WriteLine("Nombre: "+ DatosDePj.Nombre);
        Console.WriteLine("Apodo: "+ DatosDePj.Apodo);
        Console.WriteLine("Fecha de nacimiento del heroe: "+ DatosDePj.FechaDeCreacion);
        Console.WriteLine($"Edad: {DatosDePj.Edad} anios");
        Console.WriteLine($"Salud: {DatosDePj.Salud}");
        Console.WriteLine($"Velocidad: {CaracteristicaDePj.Velocidad} m/s");
        Console.WriteLine($"Destreza: {CaracteristicaDePj.Destreza}");
        Console.WriteLine($"Fuerza: {CaracteristicaDePj.Fuerza}");
        Console.WriteLine($"Nivel: {CaracteristicaDePj.Nivel}");
        Console.WriteLine($"Armadura: {CaracteristicaDePj.Armadura}");
    }


    public void MejorarHabilidades(Personaje HeroeGanador){
        Random rand = new Random();
        int valorRandom = rand.Next(1,4);
        switch (valorRandom)
        {
            case 1:
                HeroeGanador.CaracteristicaDePj.Fuerza = HeroeGanador.CaracteristicaDePj.Fuerza + rand.Next(5,11);
                break;
            case 2:
                HeroeGanador.DatosDePj.Salud = HeroeGanador.DatosDePj.Salud + 10;
                break;
            default:
                HeroeGanador.CaracteristicaDePj.Armadura = HeroeGanador.CaracteristicaDePj.Armadura + rand.Next(1,6);
                break;
        }
    }
}