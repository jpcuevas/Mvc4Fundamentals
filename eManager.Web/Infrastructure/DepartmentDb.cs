using eManager.Domain;
using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eManager.Web.Infrastructure
{
    public class DepartmentDb :DbContext, IDepartmentDataSource
    {
        public DepartmentDb()
            : base("DefaultConnection")
       {

        }

        public DbSet<Employee> Employes { get; set; }
        public DbSet<Department> Departments {get;set;}
        public DbSet<UserProfile> UserProfiles { get; set; }

        void IDepartmentDataSource.Save()
        {
            SaveChanges();
        }

        IQueryable<Employee> IDepartmentDataSource.Employees
        {
            get { return Employes; }
        }

        IQueryable<Department> IDepartmentDataSource.Departments
        {
            get { return Departments; }
        }
    }
}