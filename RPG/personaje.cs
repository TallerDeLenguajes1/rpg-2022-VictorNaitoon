
enum Tipos{
    Asesino, Bardo, Cazador, Clerigo, Druida, Guerrero, Mago,  Paladin, Pirata
}
enum Nombres{
    Vladhimir, Nailhun, Thayron, Annie, Kantz
}
enum Apodos{
    CaraCortada, Infierno, Munieko, Drako, Itachi
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
    private edad = 0;

    public Datos DatosDePj { get => datosDePj; set => datosDePj = value; }
    public Caracteristicas CaracteristicaDePj { get => caracteristicaDePj; set => caracteristicaDePj = value; }
    public DateTime Hoy { get => hoy; set => hoy = value; }
    public int Edad { get => edad; set => edad = value; }

    


}