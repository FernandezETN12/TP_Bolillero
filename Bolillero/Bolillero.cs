namespace TP.Bolillero;

public class Bolillero : ICloneable
{
    private List<int> bolillas;
    private IAzar azar;

    public Bolillero(int N) : this(N, new Azar()) { }

    public Bolillero(int N, IAzar azar)
    {
        this.azar = azar;
        bolillas = new List<int>();
        for (int i = 0; i <= N; i++)
        {
            bolillas.Add(i);
        }
    }

    public object Clone()
    {
        Bolillero clon = new Bolillero(bolillas.Count - 1, azar);
        clon.bolillas = new List<int>(bolillas);
        return clon;
    }

    public int SacarBolilla()
    {
        if (bolillas.Count == 0)
        {
            throw new InvalidOperationException("No hay bolillas en el bolillero.");
        }
        int index = azar.Siguiente(bolillas.Count);
        int bolilla = bolillas[index];
        bolillas.RemoveAt(index);
        return bolilla;
    }

    public bool Jugar(List<int> jugada)
    {
        List<int> sacadas = new List<int>();
        bool gana = true;
        for (int i = 0; i < jugada.Count; i++)
        {
            int b = SacarBolilla();
            sacadas.Add(b);
            if (b != jugada[i])
            {
                gana = false;
                break;
            }
        }
        PonerBolillas(sacadas);
        return gana;
    }

    public void PonerBolillas(List<int> bolillas)
    {
        this.bolillas.AddRange(bolillas);
    }

    public int JugarNVeces(List<int> jugada, int veces)
    {
        int contador = 0;
        for (int i = 0; i < veces; i++)
        {
            if (Jugar(jugada))
            {
                contador++;
            }
        }
        return contador;
    }
}


