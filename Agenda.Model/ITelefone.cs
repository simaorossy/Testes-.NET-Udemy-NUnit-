
namespace Agenda.Model
{
    public interface ITelefone
    {
        int Id { get; set; }
        string Numero { get; set; }
        int ContatoId { get; set; }
    }
}
