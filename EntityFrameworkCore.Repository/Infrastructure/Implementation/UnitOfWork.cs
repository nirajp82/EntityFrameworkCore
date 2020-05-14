using System.Threading.Tasks;

namespace EntityFrameworkCore.Repository
{
    internal class UnitOfWork : IUnitOfWork
    {
        #region Private Members
        private IStudentRepository _studentRepository { get; set; }
        private ApplicationContext _context { get; }
        private IModelHelper _modelHelper { get; }
        #endregion


        #region Public Members
        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new StudentRepository(_context, _modelHelper);

                return _studentRepository;
            }
        }
        #endregion


        #region Constructors
        public UnitOfWork(ApplicationContext applicationContext, IModelHelper modelHelper)
        {
            _context = applicationContext;
            _modelHelper = modelHelper;
        }
        #endregion


        #region Public Methods        
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        #endregion
    }
}
