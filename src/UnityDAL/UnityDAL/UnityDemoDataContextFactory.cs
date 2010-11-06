using System.Data.Linq;
using UnityDAL.Interfaces;

namespace UnityDAL
{
    public class UnityDemoDataContextFactory: IDataContextFactory
    {
        private readonly DataContext _context;

        public UnityDemoDataContextFactory()
        {
            _context = UnityDemoModelDataContext.Create();
        }

        public DataContext Context
        {
            get { return _context; }
        }

        public void SaveAll()
        {
            _context.SubmitChanges();
        }
    }
}