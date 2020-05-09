using System.Threading.Tasks;

namespace EntityFrameworkCore.Repository
{
    public interface IUnitOfWork
    {
        public IStudentRepository StudentRepository { get; }

        Task<int> SaveAsync();
    }
}
