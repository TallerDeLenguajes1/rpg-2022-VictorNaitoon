
public enum Tipos{
    Asesino, Bardo, Cazador, Clerigo, Druida, Guerrero, Mago,  Paladin, Pirata
}
public enum Nombres{
    Vladhimir, Nailhun, Thayron, Annie, Kantz, Drako, Spoon, Lycan, Nerkov
}
public enum Apodos{
    CaraCortada, Infierno, Munieko, Trauma, Lucifer, Vendetta, Maestro, Profesor, Perro
}
public class Datos {
    public Tipos tipo;
    public Nombres nombre;
    public Apodos apodo;
    private DateTime fechaDeCreacion;
    private int edad;
    private double salud;

    public DateTime FechaDeCreacion { get => fechaDeCreacion; set => fechaDeCreacion = value; }
    public int Edad { get => edad; set => edad = value; }
    public double Salud { get => salud; set => salud = value; }
    public Tipos Tipo { get => tipo; set => tipo = value; }
    public Nombres Nombre { get => nombre; set => nombre = value; }
    public Apodos Apodo { get => apodo; set => apodo = value; }
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


    public Personaje cargarPersonaje(int dato){
        Personaje Heroe = new Personaje();
        Random rand = new Random();
        //int datoRandom = rand.Next(1, 10);
        switch (dato)
        {
            case 1:
                Heroe.DatosDePj.Tipo = Tipos.Asesino;
                Heroe.datosDePj.Nombre = Nombres.Drako;
                Heroe.DatosDePj.Apodo = Apodos.CaraCortada;
                break;
            case 2:
                Heroe.DatosDePj.Tipo = Tipos.Bardo;
                Heroe.datosDePj.Nombre = Nombres.Annie;
                Heroe.DatosDePj.Apodo = Apodos.Vendetta;
                break;
            case 3:
                Heroe.DatosDePj.Tipo = Tipos.Cazador;
                Heroe.datosDePj.Nombre = Nombres.Kantz;
                Heroe.DatosDePj.Apodo = Apodos.Infierno;
                break;
            case 4:
                Heroe.DatosDePj.Tipo = Tipos.Clerigo;
                Heroe.datosDePj.Nombre = Nombres.Vladhimir;
                Heroe.DatosDePj.Apodo = Apodos.Maestro;
                break;
            case 5:
                Heroe.DatosDePj.Tipo = Tipos.Druida;
                Heroe.datosDePj.Nombre = Nombres.Nailhun;
                Heroe.DatosDePj.Apodo = Apodos.Lucifer;
                break;
            case 6:
                Heroe.DatosDePj.Tipo = Tipos.Guerrero;
                Heroe.datosDePj.Nombre = Nombres.Lycan;
                Heroe.DatosDePj.Apodo = Apodos.Munieko;
                break;
            case 7:
                Heroe.DatosDePj.Tipo = Tipos.Mago;
                Heroe.datosDePj.Nombre = Nombres.Nerkov;
                Heroe.DatosDePj.Apodo = Apodos.Profesor;
                break;
            case 8:
                Heroe.DatosDePj.Tipo = Tipos.Paladin;
                Heroe.datosDePj.Nombre = Nombres.Spoon;
                Heroe.DatosDePj.Apodo = Apodos.Perro;
                break;
            case 9:
                Heroe.DatosDePj.Tipo = Tipos.Pirata;
                Heroe.datosDePj.Nombre = Nombres.Thayron;
                Heroe.DatosDePj.Apodo = Apodos.Trauma;
                break;
            default:
                break;
        }

        Heroe.DatosDePj.FechaDeCreacion = new DateTime(rand.Next(1800,2015), rand.Next(1,13), rand.Next(1,30));

        Heroe.DatosDePj.Edad = Heroe.EdadDePj(Heroe.DatosDePj.FechaDeCreacion);

        Heroe.DatosDePj.Salud = 100;

        Heroe.CaracteristicaDePj.Velocidad = rand.Next(1,11);
        Heroe.CaracteristicaDePj.Destreza = rand.Next(1,6);
        Heroe.CaracteristicaDePj.Fuerza = rand.Next(1,10);
        Heroe.CaracteristicaDePj.Nivel = rand.Next(1,11);
        Heroe.CaracteristicaDePj.Armadura = rand.Next(1,11);

        return Heroe;
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