namespace EntityFrameworkCore.Repository
{
    internal class UnitOfWork : IUnitOfWork
    {
        #region Private Members
        private IStudentRepository _studentRepository { get; set; }
        private ApplicationContext _context { get; }
        #endregion


        #region Public Members
        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new StudentRepository(_context);

                return _studentRepository;
            }
        }
        #endregion


        #region Constructors
        public UnitOfWork(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }
        #endregion


        #region Public Methods        
        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
