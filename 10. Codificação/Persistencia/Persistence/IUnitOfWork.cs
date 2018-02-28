using Model.Models.EDMX;
namespace Persistencia.Persistence
{
    public interface IUnitOfWork
    {
        void Commit(bool shared);
        IRepositorioGenerico<TB_Odontograma> RepositorioOdontograma { get; }
        IRepositorioGenerico<TB_Paciente> RepositorioPaciente { get; }
        IRepositorioGenerico<TB_Perguntas> RepositorioPerguntas { get; }
        IRepositorioGenerico<TB_Periograma> RepositorioPeriograma { get; }
        IRepositorioGenerico<TB_Pessoa> RepositorioPessoa { get; }
        IRepositorioGenerico<TB_Triagem> RepositorioTriagem { get; }
    }
}
