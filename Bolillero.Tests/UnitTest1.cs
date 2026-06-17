using TP.Bolillero;
using System.Threading.Tasks;

namespace TP.Bolillero.Tests;

public class UnitTest1
{
    [Fact]
    public void TestBolilleroSacarBolilla()
    {
        Bolillero bolillero = new Bolillero(10);
        int bolilla = bolillero.SacarBolilla();
        Assert.InRange(bolilla, 0, 10);
    }

    [Fact]
    public void TestBolilleroJugar()
    {
        Bolillero bolillero = new Bolillero(5);
        List<int> jugada = new List<int> { 0, 1, 2 };
        bool gana = bolillero.Jugar(jugada);
        Assert.IsType<bool>(gana);
    }

    [Fact]
    public void TestBolilleroJugarNVeces()
    {
        Bolillero bolillero = new Bolillero(5);
        List<int> jugada = new List<int> { 0, 1 };
        int ganadas = bolillero.JugarNVeces(jugada, 10);
        Assert.InRange(ganadas, 0, 10);
    }

    [Fact]
    public void TestBolilleroClone()
    {
        Bolillero original = new Bolillero(5);
        Bolillero clon = (Bolillero)original.Clone();
        Assert.NotSame(original, clon);
        Assert.IsType<Bolillero>(clon);
    }

    [Fact]
    public void TestSimulacionSinHilos()
    {
        Bolillero bolillero = new Bolillero(5);
        Simulacion sim = new Simulacion();
        List<int> jugada = new List<int> { 0, 1 };
        long ganadas = sim.SimularSinHilos(bolillero, jugada, 100);
        Assert.InRange(ganadas, 0, 100);
    }

    [Fact]
    public void TestSimulacionConHilos()
    {
        Bolillero bolillero = new Bolillero(5);
        Simulacion sim = new Simulacion();
        List<int> jugada = new List<int> { 0, 1 };
        long ganadas = sim.SimularConHilos(bolillero, jugada, 100, 4);
        Assert.InRange(ganadas, 0, 100);
    }

    [Fact]
    public async Task TestSimulacionConHilosAsync()
    {
        Bolillero bolillero = new Bolillero(5);
        Simulacion sim = new Simulacion();
        List<int> jugada = new List<int> { 0, 1 };
        long ganadas = await sim.SimularConHilosAsync(bolillero, jugada, 100, 4);
        Assert.InRange(ganadas, 0, 100);
    }
}
