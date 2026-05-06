namespace TP.Bolillero;

public class Azar : IAzar
{
    private Random random = new Random();

    public int Siguiente(int max)
    {
        return random.Next(max);
    }
} 