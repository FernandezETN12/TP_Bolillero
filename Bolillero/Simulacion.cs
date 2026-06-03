namespace TP.Bolillero;

public class Simulacion
{
    public long SimularSinHilos(Bolillero bolillero, List<int> jugada, int simulaciones)
    {
        long ganadas = 0;
        for (int i = 0; i < simulaciones; i++)
        {
            if (bolillero.Jugar(jugada))
            {
                ganadas++;
            }
        }
        return ganadas;
    }

    public long SimularConHilos(Bolillero bolillero, List<int> jugada, int simulaciones, int hilos)
    {
        long totalGanadas = 0;
        Task<long>[] tareas = new Task<long>[hilos];
        int simulacionesPorHilo = simulaciones / hilos;
        int resto = simulaciones % hilos;

        for (int i = 0; i < hilos; i++)
        {
            int sims = simulacionesPorHilo + (i < resto ? 1 : 0);
            Bolillero clon = (Bolillero)bolillero.Clone();
            tareas[i] = Task.Run(() => SimularSinHilos(clon, jugada, sims));
        }

        Task.WaitAll(tareas);
        foreach (var tarea in tareas)
        {
            totalGanadas += tarea.Result;
        }
        return totalGanadas;
    }

    public async Task<long> SimularConHilosAsync(Bolillero bolillero, List<int> jugada, int simulaciones, int hilos)
    {
        long totalGanadas = 0;
        Task<long>[] tareas = new Task<long>[hilos];
        int simulacionesPorHilo = simulaciones / hilos;
        int resto = simulaciones % hilos;

        for (int i = 0; i < hilos; i++)
        {
            int sims = simulacionesPorHilo + (i < resto ? 1 : 0);
            Bolillero clon = (Bolillero)bolillero.Clone();
            tareas[i] = Task.Run(() => SimularSinHilos(clon, jugada, sims));
        }

        await Task.WhenAll(tareas);
        
        foreach (var tarea in tareas)
        {
            totalGanadas += tarea.Result;
        }
        return totalGanadas;
    }
}