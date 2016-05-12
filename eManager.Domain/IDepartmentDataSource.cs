using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eManager.Domain
{
    public interface IDepartmentDataSource
    {
        IQueryable<Employee> Employees { get; }
        IQueryable<Department> Departments { get; }
        IQueryable<Video> Videos { get; }
        void Save();
        bool ProxyCreationEnable { set; }
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
    }
}
