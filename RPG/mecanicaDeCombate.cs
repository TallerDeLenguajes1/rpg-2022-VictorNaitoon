public class Combate{
    private double pD; //Poder de Ataque
    private double eD; //Efectividad de Disparo
    private double vA; //Valor de Ataque
    private double pDEF; //Poder de Defensa
    private double mDP; //Máximo de daño provocado
    private double dP; //Daño Provocado

    public double PD { get => pD; set => pD = value; }
    public double ED { get => eD; set => eD = value; }
    public double VA { get => vA; set => vA = value; }
    public double PDEF { get => pDEF; set => pDEF = value; }
    public double MDP { get => mDP; set => mDP = value; }
    public double DP { get => dP; set => dP = value; }


    public double PuntosDeCombate(Personaje Atacante, Personaje Defensor){
        Random rand = new Random();

        //Valores de Ataque
        PD = Atacante.CaracteristicaDePj.Destreza * Atacante.CaracteristicaDePj.Fuerza * Atacante.CaracteristicaDePj.Nivel;
        Console.WriteLine($"Poder de disparo del {Atacante.DatosDePj.Apodo}: "+PD);

        ED = rand.Next(1,101);
        Console.WriteLine("Efectividad del disparo: "+ED);

        VA = (PD * ED) / 100;
        Console.WriteLine("Valor de ataque: "+VA);

        //Valores de Defensa
        PDEF = Defensor.CaracteristicaDePj.Armadura * Defensor.CaracteristicaDePj.Velocidad;
        Console.WriteLine("Poder de defensa: "+PDEF);


        //Resultado del Enfrentamiento
        MDP = 50000;

        DP = (((VA * ED) - PDEF) / MDP) * 100;
        Console.WriteLine("Daño provocado: "+DP);

        Defensor.DatosDePj.Salud = Defensor.DatosDePj.Salud - DP;

        return Defensor.DatosDePj.Salud;
    }
}