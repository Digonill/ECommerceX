namespace EcX.Dominio.Interface
{
    public interface IEntidadeExclusaoLogica : IEntidade
    {
        bool RegistroExcluido { get; set; }
    }
}
