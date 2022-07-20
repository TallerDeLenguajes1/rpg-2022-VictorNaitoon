public class Combate{
    private int pD; //Poder de Ataque
    private int eD; //Efectividad de Disparo
    private int vA; //Valor de Ataque
    private int pDEF; //Poder de Defensa
    private int mDP; //Máximo de daño provocado
    private int dP; //Daño Provocado

    public int PD { get => pD; set => pD = value; }
    public int ED { get => eD; set => eD = value; }
    public int VA { get => vA; set => vA = value; }
    public int PDEF { get => pDEF; set => pDEF = value; }
    public int MDP { get => mDP; set => mDP = value; }
    public int DP { get => dP; set => dP = value; }


    public int PuntosDeCombate(Personaje Atacante, Personaje Defensor){
        Random rand = new Random();

        //Valores de Ataque
        PD = Atacante.CaracteristicaDePj.Destreza * Atacante.CaracteristicaDePj.Fuerza * Atacante.CaracteristicaDePj.Nivel;

        ED = rand.Next(1,101) / 100;

        VA = PD * ED;

        //Valores de Defensa
        PDEF = Defensor.CaracteristicaDePj.Armadura * Defensor.CaracteristicaDePj.Velocidad;


        //Resultado del Enfrentamiento
        MDP = 50000;

        DP = (((VA * ED) - PDEF) / MDP) * 100;

        Defensor.DatosDePj.Salud = Defensor.DatosDePj.Salud - DP;

        return Defensor.DatosDePj.Salud;
    }
}