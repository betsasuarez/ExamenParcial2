namespace ExamenParcial2.Service.Interface;

public interface IEncuestaService
{
    public Task<bool> LoginAsync(int res1, double res2, int res3);
}
