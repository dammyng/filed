using System.Threading.Tasks;

namespace filed.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}