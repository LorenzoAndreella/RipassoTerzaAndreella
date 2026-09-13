using EsRipassoRobot_Andreella;
using System.ComponentModel.Design;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inserimento Robot");
        List<CRobot> listaRobot = InserisciLista();

        Console.WriteLine("Visualizza lista");
        VisualizzaLista(listaRobot);

        Console.WriteLine("Filtra per potenza");
        FiltraPotenza(listaRobot);

        Console.WriteLine("Visualizza per anno");
        CRobot robotPiùRecente = OrdinaAnno(listaRobot);
        Console.WriteLine("Robot più recente");
        Console.WriteLine(robotPiùRecente.Visualizza());

    }

    public static List<CRobot> InserisciLista()
    {
        List<CRobot> ListaRobot = new List<CRobot>();
        int n;
        do
        {
            Console.WriteLine("Quanti robot vuoi inserire? (max 100)");
        }
        while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 100);

        for (int i = 0; i < n; i++)
        {
            string modello;
            float potenza;
            int stato;
            int anno;
            Console.WriteLine("Robot numero " + (i + 1) + ":");
            do
            {
                Console.WriteLine("Modello del robot:");
                modello = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(modello));

            do
            {
                Console.WriteLine("Potenza del robot:");

            } while (!float.TryParse(Console.ReadLine(), out potenza) || potenza < 0);

            do
            {
                Console.WriteLine("Stato del robot (0 guasto; >0 Operativo) :");
            } while (!int.TryParse(Console.ReadLine(), out stato) || stato < 0);

            do
            {
                Console.WriteLine("Anno del robot:");
            } while (!int.TryParse(Console.ReadLine(), out anno) || anno < 1950 || anno > DateTime.Now.Year);

            CRobot robot = new CRobot(modello, potenza, stato, anno);
            ListaRobot.Add(robot);
        }

        return ListaRobot;

    }

    public static void VisualizzaLista(List<CRobot> ListaRobot)
    {
        bool trovato = false;
        foreach (CRobot robot in ListaRobot)
        {
            if (robot.Stato > 0)
            {
                Console.WriteLine(robot.Visualizza());
                trovato = true;
            }

            
        }
        if (trovato == false)
        {
            Console.WriteLine("Nessun robot operativo trovato.");
        }

    }

    public static void FiltraPotenza(List<CRobot> lista)
    {
        float pot;
        do
        {
            Console.WriteLine("Inserisci potenza massima dei robot da visualizzare");
        } while (!float.TryParse(Console.ReadLine(), out pot) || pot < 0);

        bool trovato = false;

        foreach (CRobot robot in lista)
        {
            if (robot.Potenza <= pot)
            {
                Console.WriteLine(robot.Visualizza());
                trovato = true;
            }

        }

        if (trovato == false)
        {
            Console.WriteLine("Nessun robot con potenza minore di " + pot + " trovato");
        }
    }

    public static CRobot OrdinaAnno(List<CRobot> lista)
    {
        
        int n = lista.Count;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (lista[j].Anno > lista[j + 1].Anno)
                {
                    CRobot temp = lista[j];
                    lista[j] = lista[j + 1];
                    lista[j+1] = temp;
                }
            }
        }

        foreach (CRobot robot in lista)
        {
            Console.WriteLine(robot.Visualizza());
        }

        return lista[n-1];
    }
}