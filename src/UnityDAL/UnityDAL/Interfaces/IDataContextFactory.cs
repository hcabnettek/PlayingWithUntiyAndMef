using System;
using System.Text;
using System.Data.Linq;

namespace UnityDAL.Interfaces
{
    public interface IDataContextFactory
    {
        DataContext Context { get; }
        void SaveAll();
    }
}