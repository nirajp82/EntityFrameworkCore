namespace EntityFrameworkCore.Repository
{
    public interface IUnitOfWork
    {
        public IStudentRepository StudentRepository { get; }
        void Save();
    }
}
