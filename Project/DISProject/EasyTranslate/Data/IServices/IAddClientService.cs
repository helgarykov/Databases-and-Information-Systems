using Data.Models;

namespace Data.IServices;

public interface IAddClientService
{
    public IEnumerable<Client> AddClientViaDapper();
}